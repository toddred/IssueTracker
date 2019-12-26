<template>
  <div id="app">
    <md-app md-mode="reveal">
      <md-app-toolbar class="md-primary">
        <h1 router-link to="/">Bug Tracker</h1>
        <div id="nav">
          <md-button class="md-primary" v-if="!isAuthenticated" router-link to="/login">Login</md-button>
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
