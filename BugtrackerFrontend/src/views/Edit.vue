<template>
  <div id="edit">
    <add-issue :issue="issue"></add-issue>
    <button @click="navigateHome">home</button>
  </div>
</template>
<script>
import addIssue from "../components/add-issue.vue";
export default {
  name: "Edit",
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
    navigateHome() {
      this.$router.push("/");
    }
  }
};
</script>