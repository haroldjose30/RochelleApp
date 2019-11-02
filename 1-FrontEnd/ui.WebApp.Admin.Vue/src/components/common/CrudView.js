import Vue from 'vue'
import _ from 'lodash'

import BaseObject from './BaseObject'
import {
  ArrowUpIcon,
  ArrowDownIcon,
  PlusIcon,
  LoaderIcon,
  CheckIcon
} from 'vue-feather-icons'

import FlagCheckBoxGroup from './FlagCheckBoxGroup'

export default {
  name: 'crud-view',
  mixins: [BaseObject],

  components: {
    PlusIcon,
    LoaderIcon,
    CheckIcon,
    ArrowUpIcon,
    ArrowDownIcon,
    FlagCheckBoxGroup
  },

  props: {
    title: String,
    apiModule: String,
    apiListName: String,
    apiListMethod: String,
    apiCreateMethod: String,
    apiUpdateMethod: String,
    apiDeleteMethod: String,
    objectModel: Array,
    preBuild: Function,
    allowReordering: {
      type: Boolean,
      default: false
    }
  },

  data () {
    return {
      objects: [],
      objectToDelete: null,
      objectsToUpdate: [],
      filters: {},
      loaded: false,
      canSave: false,
      lastClickedCustomComponentObjectId: null,

      arrowsDisabled: false,

      showObjectAddedAlert: false,
      showObjectDeletedAlert: false,
      showObjectErrorAlert: false,

      errors: [],

      currentPage: 1,
      perPage: 50
    }
  },

  methods: {
    moveUp (object) {
      let oo = this.orderedObjects

      const index = oo.indexOf(object)

      if (index <= 0) {
        return
      }

      let tmp = oo[index].ordering
      oo[index].ordering = oo[index - 1].ordering
      oo[index - 1].ordering = tmp

      this.fieldChanged(oo[index])
      this.fieldChanged(oo[index - 1])
    },

    moveDown (object) {
      let oo = this.orderedObjects

      const index = oo.indexOf(object)

      if (index + 1 >= oo.length) {
        return
      }

      let tmp = oo[index].ordering
      oo[index].ordering = oo[index + 1].ordering
      oo[index + 1].ordering = tmp

      this.fieldChanged(oo[index])
      this.fieldChanged(oo[index + 1])
    },

    addObject () {
      let params = {}
      let object = {}

      this.objectModel.map(om => (object[om.name] = om.value))

      if (this.$props.apiListName) {
        params[this.$props.apiListName] = [object]
      } else {
        params = object
      }

      this.$api.call({
        module: this.$props.apiModule,
        method: this.$props.apiCreateMethod,
        body: params,
        success: objects => {
          this.objectAdded(objects[0])
          this.objectModel.map(om => (om.value = null))

          this.showObjectAddedAlert = true
        },
        error: objects => {
          console.log("error",objects)
          this.errors = objects
          this.showObjectErrorAlert = true
        }
      })
    },

    filter (value, om) {
      if (!value) {
        value = ''
      }



      Vue.set(this.filters, om.name, String(value).trim().toUpperCase())
    },

    prepareDelete (object) {
      this.objectToDelete = object
    },

    deleteObject () {
      let params = {
        id: this.objectToDelete.id,
        deletedBy: "admin"
      }

      this.$api.call({
        module: this.$props.apiModule,
        method: this.$props.apiDeleteMethod,
        parameters: params,
        success: () => {
          let index = this.objects.findIndex(
            obj => obj.id === this.objectToDelete.id
          )
          this.objectDeleted(index)
          this.objectToDelete = null

          this.showObjectDeletedAlert = true
        },
        error: objects => {
          console.log("error",objects)
          this.errors = objects
          this.showObjectErrorAlert = true
        }
      })
    },

    fieldChanged (object) {
      if (this.canSave) {
        this.fieldChangedReal(object)
      }
    },

    fieldChangedReal (object) {
      let index = this.objects.findIndex(obj => obj.id === object.id)

      let doesntExist = true
      for (let obj of this.objectsToUpdate) {
        if (obj === object) {
          doesntExist = false
          break
        }
      }
      if (doesntExist) {
        this.objectsToUpdate.push(object)
      }

      clearTimeout(object.typingTimeout)
      object.typingTimeout = setTimeout(() => {
        // TODO - Make it happen in only one HTTP request
        for (object of this.objectsToUpdate) {
          this.updateDatabase(object)
        }

        this.objectsToUpdate = []
      }, 2000)

      Vue.set(this.objects, index, object)
    },

    updateDatabase (object) {
      this.arrowsDisabled = true

      let index = this.objects.findIndex(obj => obj.id === object.id)
      object.dirty = true
      Vue.set(this.objects, index, object)

      let params = {}
      if (this.$props.apiListName) {
        params[this.$props.apiListName] = [object]
      } else {
        params = object
      }

      this.$api.call({
        module: this.$props.apiModule,
        method: this.$props.apiUpdateMethod,
        body: params,
        success: () => {
          object.dirty = false
          Vue.set(this.objects, index, object)
          clearTimeout(object.typingTimeout)

          object.updated = true
          setTimeout(() => {
            object.updated = false
            Vue.set(this.objects, index, object)
          }, 3000)

          this.arrowsDisabled = false
        },
        error: (objects) => {

          object.dirty = false
          Vue.set(this.objects, index, object)
          clearTimeout(object.typingTimeout)

          this.arrowsDisabled = false

          this.errors = objects.errors
          this.showObjectErrorAlert = true
        }
      })
    },

    build () {
      this.$api.call({
        module: this.$props.apiModule,
        method: this.$props.apiListMethod,
        success: data => {
          this.objects = data.data
          this.loaded = true
        }
      })
    },

    customComponentClicked (objectId) {
      this.lastClickedCustomComponentObjectId = objectId
    },
  },

  computed: {
    orderedObjects () {
      return _.sortBy(this.objects, ['ordering'])
    },

    filteredOrderedObjects () {
      return _.sortBy(
        _.filter(this.objects, row => {
          for (let field in this.filters) {
            let filter = this.filters[field]
            let value = row[field]

            if (value == null) {
              continue
            }

            value = String(value).toUpperCase()

            if (!value.includes(filter)) {
              return false
            }
          }
          return true
        }),
        ['ordering']
      )
    }
  },

  updated: function () {
    this
      .$nextTick()
      .then(() => this.canSave = true)
  },

  mounted () {
    if (this.$props.preBuild) {
      this.$props.preBuild()
    } else {
      this.build()
    }
  }
}