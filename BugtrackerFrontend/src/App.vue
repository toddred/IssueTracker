<template>
  <div id="app">
    <md-app md-mode="reveal">
      <md-app-toolbar class="md-primary">
        <h1>Bug Tracker</h1>
        <div id="nav">
          <router-link to="/">Home</router-link>|
          <router-link to="/about">About</router-link>|
          <router-link to="/create">Create</router-link>
          <router-link v-if="!isAuthenticated" to="/login">Login</router-link>
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
