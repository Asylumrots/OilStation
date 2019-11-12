<template>
  <div class="dashboard-container">
    <div class="dashboard-text">用户姓名: {{ name }}</div>
    <!-- <div class="dashboard-text">当前时间: {{ time }}</div> -->
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'NotFound',
  methods:{
  },
  computed: {
    ...mapGetters([
      'name' 
    ])
  }
}
</script>

<style lang="scss" scoped>
.dashboard {
  &-container {
    margin: 30px;
  }
  &-text {
    font-size: 30px;
    line-height: 46px;
  }
}
</style>
