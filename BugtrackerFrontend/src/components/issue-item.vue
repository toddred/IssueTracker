<template>
  <div>
    <md-list-item>
      <h4>{{issue.name}}</h4>
      <md-button class="md-fab"><md-icon>edit</md-icon></md-button>
      <md-button class="md-accent" @click="archive(issue.id)">Archive</md-button>
    </md-list-item>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
export default {
    name: 'IssueItem',
    props:["issue"],
    methods:{
      ...mapActions(['archiveIssue']),
      archive(id){
        this.archiveIssue(id);
      }
    },
    computed(){
      return {

      }
    }
}
</script>

<style lang="css" scoped>

</style>>

