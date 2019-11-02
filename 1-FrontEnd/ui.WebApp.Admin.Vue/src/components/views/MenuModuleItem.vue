<template>
  <li class="nav-item">
    <router-link :to="{ name: id }" class="nav-link">
      <span class="feather-icon" :data-feather="icon"></span>
      {{ name }}
      <span class="sr-only">(current)</span>
    </router-link>
  </li>
</template>

<script>
export default {
  name: 'menu-module-item',
  props: {
    id: String,
    icon: String,
    name: String
  }
}
</script>

<style scoped>
.nav-link {
  font-weight: 500;
  color: #333;
}

.nav-link .feather {
  margin-right: 4px;
  color: #999;
}

.nav-link.active {
  color: #007bff;
}

.nav-link:hover .feather,
.nav-link.active .feather {
  color: inherit;
}

.feather-icon {
  width: 16px;
  height: 16px;
  vertical-align: text-bottom;
}
</style>
