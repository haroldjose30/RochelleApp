import Vue from 'vue'
import Router from 'vue-router'

import Index from './components/views/Index.vue'
import Companies from './components/forms/Companies.vue'
import Users from './components/forms/Users.vue'
import Customers from './components/forms/Customers.vue'
import ParamConfigurations from './components/forms/ParamConfigurations.vue'
import Products from './components/forms/Products.vue'

Vue.use(Router)

export default new Router({
  mode: 'hash',
  base: process.env.BASE_URL,
  routes: [
    { path: '/', name: 'Index', component: Index },
    { path: '/Companies', name: 'Companies', component: Companies },
    { path: '/Users', name: 'Users', component: Users },
    { path: '/Customers', name: 'Customers', component: Customers },
    { path: '/ParamConfigurations', name: 'ParamConfigurations', component: ParamConfigurations },
    { path: '/Products', name: 'Products', component: Products },        
  ]
})
