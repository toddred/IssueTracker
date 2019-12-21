<template>
  <div>
    <md-card>
      <md-card-header>
        <h3>New Issue</h3>
      </md-card-header>
      <md-card-content>
        <md-field>
          <md-input type="text" v-model="issue.name" placeholder="describe issue" />
        </md-field>
        <md-field>
          <md-button type="submit" @click="onClick">Create</md-button>
        </md-field>
      </md-card-content>
    </md-card>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "addIssue",
  props: ["issue"],
  methods: {
    ...mapActions(["addIssue"]),
    onClick() {
      this.addIssue(this.issue);
      this.$router.push('/')
    }
  }
};
</script>

<style>
</style>