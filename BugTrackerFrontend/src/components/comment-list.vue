<template>
  <div>
    <h4>Comments</h4>
    <div v-if="issue.comments !== null">
    <ul>
      <li v-for=" comment in issue.comments" :key="comment.id">comment</li>
    </ul>
    </div>

  </div>
</template>

<script>
export default {
    name:"CommentList",
    props:["issue"],


};
</script>

<style>
</style>