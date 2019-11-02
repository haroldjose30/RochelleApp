import Vue from 'vue'
import Router from 'vue-router'

import Index from './components/views/Index.vue'
import Companies from './components/forms/Companies.vue'


Vue.use(Router)

export default new Router({
  mode: 'hash',
  base: process.env.BASE_URL,
  routes: [
    { path: '/', name: 'Index', component: Index },
    { path: '/Companies', name: 'Companies', component: Companies }
  ]
})
