import Vue from 'vue'
import App from './App.vue'
import router from './router'
//import store from './store'

import BootstrapVue from 'bootstrap-vue'
import VueLocalStorage from 'vue-localstorage'
import VueClipboard from 'vue-clipboard2'

import Api from './Api.js'
import Config from './Config.js'

import moment from 'moment-timezone'

import datePicker from 'vue-bootstrap-datetimepicker'
import 'bootstrap/dist/css/bootstrap.css'
import 'pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css'

import $ from 'jquery'

moment.locale('pt-br')
// moment.tz.setDefault('America/Sao_Paulo')
Vue.prototype.$moment = moment

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(VueLocalStorage)
Vue.use(VueClipboard)

$.extend(true, $.fn.datetimepicker.defaults, {
  icons: {
    time: 'far fa-clock',
    date: 'far fa-calendar',
    up: 'fas fa-arrow-up',
    down: 'fas fa-arrow-down',
    previous: 'fas fa-chevron-left',
    next: 'fas fa-chevron-right',
    today: 'fas fa-calendar-check',
    clear: 'far fa-trash-alt',
    close: 'far fa-times-circle'
  }
})

Vue.use(datePicker)

Vue.prototype.$api = new Api(Config.API_URL)
let token = Vue.localStorage.get('Sense.OEE.Admin.Token')

if (token) {
  Vue.prototype.$api.setToken(token)
}

new Vue({
  router,
  //store,
  render: h => h(App)
}).$mount('#app')
