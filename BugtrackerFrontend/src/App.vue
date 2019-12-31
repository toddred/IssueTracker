<template>
  <div id="app">
    <md-app md-mode="reveal">
      <md-app-toolbar class="md-primary">
        <router-link to="/">
        <h1>Bug Tracker</h1>
        </router-link>
        <div id="nav" >
          <router-link to="/login" v-if="!isAuthenticated">
            <md-button class="md-primary">Login</md-button>
          </router-link>
          
          <md-button v-else @click="logout">Logout</md-button>
        </div>
      </md-app-toolbar>
      <md-app-content>
        <router-view />
      </md-app-content>
    </md-app>
  </div>
</template>
<script>
import { mapGetters } from "vuex";

export default {
  name:'App',
  computed:mapGetters(["isAuthenticated"]),
  methods:{
    logout(){
      this.$store.dispatch('logout');
    }
  }
  
}
</script>
<style>
</style>
