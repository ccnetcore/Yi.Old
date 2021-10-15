<template>
    <v-card class="mx-auto" width="100%">
      <ccTable :defaultItem="defaultItem" :headers="headers" :axiosUrls="axiosUrls" ></ccTable>
    </v-card>

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