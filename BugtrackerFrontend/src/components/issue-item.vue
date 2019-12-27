<template>
  <div>
    <md-list-item>
      <span>
        <h4>{{issue.name}}</h4>
        <p>{{datetime}}</p>
      </span>
      <span>
        <md-button class="md-accent" @click="close(issue)">Close</md-button>
        <md-button class="md-accent" @click="edit(issue)">Edit</md-button>
        <md-button class="md-accent" @click="archive(issue.id)">Archive</md-button>
      </span>
    </md-list-item>
    <md-list-item>
      <h4>Comments</h4>
      <ul>
        <li v-for=" comment in issue.comments" :key="comment.id">comment</li>
      </ul>
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
    ...mapActions(["archiveIssue","editIssue"]),
    archive(id) {
      this.archiveIssue(id);
    },
    edit(issue) {
      this.$router.push({ name: "edit", params: { issue } });
    },
    close(issue){ 
      issue.closedOn = new Date.now();
      this.editIssue(issue);
    }
  }
};
</script>

<style lang="css" scoped>
</style>>

