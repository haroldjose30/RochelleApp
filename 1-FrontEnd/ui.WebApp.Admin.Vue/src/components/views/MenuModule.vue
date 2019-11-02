<template>
  <li class="nav-item">
    <a v-if="name != ''" class="nav-link">{{ name }}</a>
    <ul class="nav flex-row pl-2">
      <MenuModuleItem
        v-for="item in items"
        :key="item.id"
        :id="item.id"
        :name="item.name"
        :icon="item.icon"
      />
    </ul>
  </li>
</template>

<script>
import MenuModuleItem from './MenuModuleItem.vue'

export default {
  name: 'menu-module-item',
  components: {
    MenuModuleItem
  },
  props: {
    name: String,
    items: Array
  }
}
</script>

<style scoped>
.nav-link {
  font-weight: 500;
  color: #333;
}
</style>
