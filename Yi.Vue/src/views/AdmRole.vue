<template>
  <material-card color="primary" icon="mdi-account-tie">
    <template #title>
      角色管理 — <small class="text-body-1">角色可分配多个菜单</small>
    </template>
    <ccTable
      :defaultItem="defaultItem"
      :headers="headers"
      :axiosUrls="axiosUrls"
    >
    </ccTable>
  </material-card>
</template>
<script>
import userApi from "../api/userApi"
export default {
  created() {
    this.init();
  },
  methods: {
    init() {
     userApi.GetAxiosByRouter(this.$route.path).then(resp=>{
       this.axiosUrls=resp.data;
     })
      
    }
  },
  data: () => ({
    start: true,
    axiosUrls: {
    },
    headers: [
      { text: "编号", align: "start", value: "id" },
      { text: "角色名", value: "role_name", sortable: false },
      { text: "简介", value: "introduce", sortable: false },
      { text: "操作", value: "actions", sortable: false },
    ],
    defaultItem: {
      role_name: "",
      introduce: "",
    },
  }),
};
</script>