<template>
  <nav class="bg-light sidebar">
    <ul class="nav flex-row">
      <menu-module name="" :items="items"/>
    </ul>
  </nav>
</template>

<script>
import MenuModule from './MenuModule.vue'

export default {
  name: 'Menu',

  data () {
    return {
      items: [
        { id: 'Companies', name: 'Empresas', icon: 'layers' },
        { id: 'Users', name: 'Usuários', icon: 'layers' },
        { id: 'Customers', name: 'Clientes', icon: 'layers' },
        { id: 'Products', name: 'Produtos/Serviços', icon: 'layers' },
        { id: 'ParamConfigurations', name: 'ParamConfigurations', icon: 'layers' },
      ]
    }
  },

  components: {
    MenuModule
  }
}
</script>

<style scoped>
.sidebar {
  box-shadow: inset -1px 0 0 rgba(0, 0, 0, 0.1);
  position: sticky
}
</style>
