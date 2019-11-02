<template>
  <b-navbar toggleable="md" type="dark" variant="dark" sticky class="flex-md-nowrap p-0">
    <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
    <b-navbar-brand href="#" class="brand col-lg-2 col-sm-3 col-md-3 mr-0">{{ title }}</b-navbar-brand>
    <b-collapse is-nav id="nav_collapse">
      <b-navbar-nav class="ml-auto" v-if="username">
        <b-nav-item-dropdown right>
          <template slot="button-content">
            <em>{{ username }}</em>
          </template>
          <b-dropdown-item href="#" @click="logout">Sair</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
export default {
  name: 'navigation-bar',

  props: {
    username: String,
    title: String
  },

  methods: {
    logout () {
      this.$emit('logoutSuccessful')
    }
  }
}
</script>

<style scoped>
.brand {
  padding-top: 0.75rem;
  padding-bottom: 0.75rem;
  font-size: 1rem;
  background-color: rgba(0, 0, 0, 0.25);
  box-shadow: inset -1px 0 0 rgba(0, 0, 0, 0.25);
}
</style>
