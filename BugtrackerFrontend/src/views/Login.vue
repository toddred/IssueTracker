<template>
  <div>
    <md-card>
      <md-card-header>
      </md-card-header>
      <md-card-content>
        <md-field>
          <md-input type="text" v-model="auth_DTO.username" placeholder="username"/>
        </md-field>
                <md-field>
          <md-input @keypress="onEnter" type="password" v-model="auth_DTO.password" placeholder="password" />
        </md-field>
        <md-field>
          <md-button type="submit" @click="loginSubmit">Login</md-button>
        </md-field>
        <md-button @click="$router.push('/register')">Register</md-button>
      </md-card-content>
    </md-card>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "login",
  data() {
      return{
          auth_DTO:{
              password:"",
              username:""
          }
      }
  },
  methods: {
    ...mapActions(["authenticateUser"]),
    loginSubmit() {
      this.authenticateUser(this.auth_DTO);
      this.$router.push('/');
    },
    onEnter(event){
        if (event.keyCode == 13)
            this.loginSubmit()
    }
  }
};
</script>

<style>
</style>