<template>
  <div id="edit">
    <add-issue :issue="editIssue"></add-issue>
  </div>
</template>
<script>
import addIssue from "../components/add-issue.vue";

export default {
  name: "Edit",
  props: ["issue"],
  components: { addIssue },
  data() {
    return {
      editIssue: {
        id: 0,
        name:""
      }
    };
  },
  created() {
    this.editIssue = this.issue;
  }
};
</script>