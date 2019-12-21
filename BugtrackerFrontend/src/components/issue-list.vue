<template>
  <div>
    <md-card>
      <md-card-header>
        <h3>Current Issues</h3>
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
  //props: ["issues"],
  computed: {
    ...mapGetters(['allIssues', 'authenticated'])},
  components: {
    IssueItem
  },
  methods:{
    ...mapActions['getIssues']
  },
    created() {
      if(this.authenticated){
        this.$store.dispatch('secureIssues');
      }else{
        this.$store.dispatch('getIssues');
      }
     
  }
};
</script>

<style>
</style>