<template>

<material-card color="primary" icon="mdi-account-outline">
    <template #title>
      接口管理 — <small class="text-body-1">接口可被菜单拥有</small>
    </template>
      <ccTable :defaultItem="defaultItem" :headers="headers" :axiosUrls="axiosUrls" ></ccTable>
  </material-card>
</template>
<script>
export default {
  data: () => ({
axiosUrls:{
  get:"mould/getmould",
  update:"mould/updatemould",
  del:"mould/delListmould",
  add:"mould/addmould"
},
    headers: [
      {text: "编号",align: "start",value: "id"},
      { text: "接口名", value: "mould_name", sortable: false },
      { text: "接口地址", value: "url", sortable: false },
      { text: "操作", value: "actions", sortable: false }
    ],
   defaultItem: {
      mould_name: "test",
      url: "test/test",
    },
  }),
};
</script>