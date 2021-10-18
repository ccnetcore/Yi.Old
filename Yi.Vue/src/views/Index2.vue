<template>
  <div>
    <MaterialCard
      title="首页卡片"
      subtitle="微软（Microsoft）是一家美国跨国科技企业，由比尔·盖茨和保罗·艾伦于1975年4月4日创立。"
      heading="头部"
      color="#E91E63"
      :fullHeader="false"
      icon="mdi-view-dashboard"
    ></MaterialCard>
    <MaterialCharCard></MaterialCharCard>
    <MaterialSnackbar></MaterialSnackbar>
    <MaterialStatCard
      value="微软（Microsoft）是一家美国跨国科技企业，由比尔·盖茨和保罗·艾伦于1975年4月4日创立。"
    >
      <template v-slot> 还有什么呢？ </template>
    </MaterialStatCard>
  </div>
</template>
<script>
export default {
  data: () => ({}),
  created() {},
};
</script>