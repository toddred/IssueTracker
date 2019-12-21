<template>
  <div id="create">
    <add-issue :issue="issue"></add-issue>
  </div>
</template>
<script>
import addIssue from "../components/add-issue.vue";
export default {
  name: "Create",
  components: { addIssue },
  data() {
    return {
      issue: {
        name: "",
        priority: 1,
        active: true
      }
    };
  },
  methods: {

  }
};
</script>