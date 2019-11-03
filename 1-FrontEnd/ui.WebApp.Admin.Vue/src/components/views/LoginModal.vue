<template>
  <b-modal
    ref="loginModal"
    id="login-modal"
    title="Login"
    @shown="focusUsernameInput"
    no-close-on-backdrop
    no-close-on-esc
    hide-header-close
    ok-title="Entrar"
    ok-only
    @ok.prevent="login"
  >
    <b-form ref="loginForm" class="needs-validation" novalidate @submit.prevent="login">
      <b-form-group>
        <b-form-input
          id="modal-username"
          type="text"
          placeholder="Usuário / E-mail"
          v-model="username"
          required
        />
        <div class="invalid-feedback">Campo obrigatório</div>
      </b-form-group>
      <b-form-group>
        <b-form-input type="password" placeholder="Senha" v-model="password" required/>
        <div class="invalid-feedback">Campo obrigatório</div>
      </b-form-group>
      <input type="submit" style="display:none">
      <div v-if="loginError" class="login-error-message">Usuário ou senha incorretos</div>
    </b-form>
  </b-modal>
</template>

<script>
import $ from 'jquery'

export default {
  name: 'login-modal',

  data () {
    return {
      username: '',
      password: '',
      loginError: false
    }
  },

  methods: {
    focusUsernameInput () {
      $('#modal-username').trigger('focus')
    },

    show () {
      this.$refs.loginModal.show()
    },

    login () {
      if (this.$refs.loginForm.checkValidity() === true) {
        let username = this.$data.username
        username = username.trim()

        let password = this.$data.password

        this.$api.call({
          module: 'Authentication/GenerateToken',
          method: 'post',
          body: {
              Login: username,
              Password: password
          },
          success: data => {
            console.log("data",data);
            
            this.$refs.loginModal.hide()
            this.$emit('loginSuccessful', username, data.data.accessToken)
            //this.$api.setToken(data.data.accessToken)
          },
          error: () => {
            this.loginError = true
          }
        })
      }

      this.$refs.loginForm.classList.add('was-validated')
    }
  }
}
</script>

<style scoped>
.login-error-message {
  width: 100%;
  color: #dc3545;
}
</style>
