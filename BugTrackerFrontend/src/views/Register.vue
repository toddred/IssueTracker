<template>
  <div>
    <md-card>
      <md-card-header></md-card-header>
      <md-card-content>
        <md-field>
          <md-input type="text" v-model="register_DTO.username" placeholder="username" />
        </md-field>
        <md-field>
          <md-input type="email" v-model="register_DTO.email" placeholder="email" />
        </md-field>
        <md-field>
          <md-input
            @keypress="onEnter"
            type="password"
            v-model="register_DTO.password"
            placeholder="password"
          />
        </md-field>
        <md-field>
          <md-input
            @keypress="onEnter"
            type="password"
            v-model="confirmPassword"
            placeholder="password"
          />
        </md-field>
        <md-field>
          <md-button type="submit" @click="registerSubmit">Create Account</md-button>
        </md-field>
      </md-card-content>
    </md-card>
  </div>
</template>

<script>
import { mapActions } from "vuex";
const ENTER_KEY = 13;
export default {
  name: "login",
  data() {
    return {
      register_DTO: {
        password: "",
        username: "",
        email: ""
      },
      confirmPassword:""
    };
  },
  methods: {
    ...mapActions(["registerUser"]),
    registerSubmit() {
        if(this.confirmPassword === this.register_DTO.password){
            this.registerUser(this.register_DTO);
            this.$router.push("/");
        }
    },
    onEnter(event) {
      if (event.keyCode == ENTER_KEY) 
        this.registerSubmit();
    }
  }
};
</script>

<style>
</style>