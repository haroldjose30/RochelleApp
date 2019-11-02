<script>
import Vue from 'vue'

import AddButton from './AddButton'
import DeleteButton from './DeleteButton'

export default {
  components: {
    AddButton,
    DeleteButton
  },

  methods: {
    objectAdded (object) {
      this.objects.push(object)
    },

    objectDeleted (index) {
      Vue.delete(this.objects, index)
    }
  }
}
</script>
