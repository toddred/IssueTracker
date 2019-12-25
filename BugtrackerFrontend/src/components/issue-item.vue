<template>
  <div>
    <md-list-item>
      <span>
        <h4>{{issue.name}}</h4>
        <p>{{datetime}}</p>
      </span>
      <md-button class="md-accent" @click="editItem(issue)">Edit</md-button>
      <md-button class="md-accent" @click="archive(issue.id)">Archive</md-button>
    </md-list-item>
  </div>
</template>

<script>
import { mapActions } from "vuex";
export default {
  name: "IssueItem",
  props: ["issue"],
  computed: {
    datetime: function() {
      let dt = "";

      if (this.issue.modifiedOn) {
        dt += "Edited on ";
        let date = new Date(this.issue.modifiedOn);
        dt += date.toLocaleDateString();
      } else {
        let date = new Date(this.issue.createdOn);
        dt += date.toLocaleDateString();
      }
      return dt;
    }
  },
  methods: {
    ...mapActions(["archiveIssue"]),
    archive(id) {
      this.archiveIssue(id);
    },
    editItem(issue) {
      this.$router.push({ name: "edit", params: { issue } });
    }
  }
};
</script>

<style lang="css" scoped>
</style>>

