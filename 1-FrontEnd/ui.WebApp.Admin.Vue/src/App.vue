<template>
  <div id="app">
    <navigation-bar title="Admin" :username="username" @logoutSuccessful="logoutSuccessful"/>
    <div class="container-fluid p-0">
      <div class="d-flex flex-column">
        <Menu class="mt-1 mb-1" />
        <main role="main" class="pt-3 px-4">
          <router-view></router-view>
        </main>
      </div>
    </div>
    <login-modal ref="loginModal" @loginSuccessful="loginSuccessful"/>
    <b-modal ref="errorModal" size="lg" body-text-variant="danger" ok-only title="Erro">
      <table class="table">
        <tr>
          <th>Mensagem</th>
          <th>Detalhes</th>
        </tr>
        <tr v-for="(errors, key) in errorObject" :key="key">
          <td>{{ errorMessage(key) }}</td>
          <td>
            <ul>
              <li v-for="(error, index) in errors" :key="index">
                {{ error.error }}
                <b-button v-if="error.exception" v-b-toggle.collapse variant="link" @click="_copyStackTrace(error)">
                  Salvar Detalhes
                </b-button>
              </li>
            </ul>
          </td>
        </tr>
      </table>
    </b-modal>
  </div>
</template>

<script>
import Vue from 'vue'

import feather from 'feather-icons'

import Menu from './components/views/Menu.vue'
import NavigationBar from './components/views/NavigationBar.vue'
import LoginModal from './components/views/LoginModal.vue'

import ErrorList from './ErrorList'

export default {
  name: 'app',

  components: {
    NavigationBar,
    Menu,
    LoginModal
  },

  data () {
    return {
      username: null,
      errorObject: {},
    }
  },

  computed: {
    errorMessage () {
      return key => {
        let message = ErrorList[key]
        return message != null ? message : key
      }
    }
  },

  mounted () {
    feather.replace()

    let token = Vue.localStorage.get('App.Admin.Token')

    if (token == null) {
      this.$refs.loginModal.show()
    }

    this.username = Vue.localStorage.get('App.Admin.Username')

    this.$api.setErrorHandler(json => {
      for (let key in json) {
        Vue.set(this.errorObject, key, [])
        for (let error of json[key])
          this.errorObject[key].push({
            error: error,
            exception: false
          })
      }
      console.log(this.errorObject)
      this.$refs.errorModal.show()
    }, 400)

    this.$api.setErrorHandler(() => {
      this.$refs.loginModal.show()
    }, 401)

    this.$api.setErrorHandler(json => {
      for (let key in json) {
        Vue.set(this.errorObject, key, [])
        this.errorObject[key].push({
          error: json[key].Message,
          exception: json[key]
        })
      }
      this.$refs.errorModal.show()
    }, 500)

    this.$api.setErrorHandler(json => {
      console.log(json)
    }, 502)
  },

  methods: {
    loginSuccessful (username, token) {
      Vue.localStorage.set('App.Admin.Token', token)
      Vue.localStorage.set('App.Admin.Username', username)

      this.$api.setToken(token)
      this.username = username
    },

    logoutSuccessful () {
      Vue.localStorage.remove('Sense.OEE.Admin.Token')
      this.$refs.loginModal.show()
      this.username = null
    },

    _copyStackTrace (exception) {
      console.log('EXCEPTION', exception)
      this.$copyText(exception.StackTraceString)
    },
  }
}
</script>

<!--
<style lang="scss">
@import './assets/scss/bootstrap-custom.scss';
@import '../node_modules/bootstrap/scss/bootstrap.scss';
@import 'bootstrap-vue/dist/bootstrap-vue.css';
@import '../node_modules/@fortawesome/fontawesome-free/css/all.css';

#app {
  font-size: 0.875rem;
}
</style>
-->
