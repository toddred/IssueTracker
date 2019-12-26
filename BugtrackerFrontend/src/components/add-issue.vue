<template>
  <div>
    <md-card>
      <md-card-header>
        <h3>New Issue</h3>
    <md-button @click="navigateHome">X</md-button>        

      </md-card-header>
      <md-card-content>
        <md-field>
          <md-input type="text" v-model="issue.name" placeholder="describe issue" />
        </md-field>
        <md-field v-if="issue.id > 0">
          <md-button type="submit" @click="edit">Confirm</md-button>
        </md-field>
        <md-field v-else>
          <md-button type="submit" @click="create">Create</md-button>
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
    ...mapActions(["addIssue", "editIssue"]),
    create() {
      this.addIssue(this.issue);
      this.$router.push("/");
    },
    edit() {
      this.editIssue(this.issue);
      this.$router.push("/");
    },
    navigateHome(){this.$router.push('/');}
  }
};
</script>

<style>
</style>