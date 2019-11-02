<template>
  <b-button class="add-button" type="submit" variant="success" @click.prevent="addObject">
    <plus-icon/>
    Adicionar
  </b-button>
</template>

<script>
import { PlusIcon } from 'vue-feather-icons'

export default {
  name: 'add-button',

  components: {
    PlusIcon
  },

  methods: {
    addObject () {
      this.$emit('clicked')
    }
  }
}
</script>
