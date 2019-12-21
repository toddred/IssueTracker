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
  computed:mapGetters(["isAuthenticated"])
}
</script>
<style>
</style>
