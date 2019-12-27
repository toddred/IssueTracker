<template>
  <div>
    <md-card>
      <md-card-header>
        <h3>Current Issues</h3>
        <md-button router-link to="/create" class="md-fab md-primary">
          <md-icon>add</md-icon>
        </md-button>
      </md-card-header>
      <md-card-content>
        <issue-item v-for="issue in allIssues" :key="issue.id" :issue="issue"></issue-item>
      </md-card-content>
    </md-card>
  </div>
</template>

<script>
import IssueItem from "../components/issue-item.vue";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "IssueList",
  computed: {
    ...mapGetters(["allIssues", "isAuthenticated"])
  },
  components: {
    IssueItem
  },
  methods: {
    ...mapActions["getIssues"]
  },
  created() {
    this.$store.dispatch("getIssues");
  }
};
</script>

<style>
</style>