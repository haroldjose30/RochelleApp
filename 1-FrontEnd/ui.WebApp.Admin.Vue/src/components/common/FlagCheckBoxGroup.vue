<template>
  <b-form-checkbox-group
    class="d-flex flex-column"
    :options="options"
    v-model="flagMap"
    @change="selectionChanged"
  />
</template>

<script>
export default {
  data () {
    return {
      flagMap: []
    }
  },

  props: {
    options: Array,
    flags: Number
  },

  mounted () {
    this.flagMap = []

    for (let option of this.options) {
      let mask = 1 << (option.value - 1)
      if (this.flags & mask) {
        // Flag is set :D
        this.flagMap.push(option.value)
      }
    }
  },

  methods: {
    selectionChanged (selectedValues) {
      let flags = 0

      for (let value of selectedValues) {
        flags |= 1 << (value - 1)
      }

      this.$emit('flagsChanged', flags)
    }
  }
}
</script>
