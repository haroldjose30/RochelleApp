<template>
  <b-button
    v-b-modal.confirm-delete-modal
    type="button"
    variant="danger"
    @click.prevent="deleteObject">
    <trash-2-icon class="feather-icon"/>
    Remover
  </b-button>
</template>

<script>
import { Trash2Icon } from 'vue-feather-icons'

export default {
  name: 'delete-button',

  components: {
    Trash2Icon
  },

  props: {
    object: Object
  },

  methods: {
    deleteObject () {
      this.$emit('clicked', this.object)
    }
  }
}
</script>

<style scoped>
.feather-icon {
  width: 16px;
  height: 16px;
  vertical-align: text-bottom;
}
</style>
