<template>
  <div id="home">
    <md-list>
      <issue-list></issue-list>
    </md-list>
  </div>
</template>

<script>
import IssueList from "../components/issue-list";


export default {
  name: "Home",
  components: {
    IssueList
  },
};
</script>

<style>
</style>
