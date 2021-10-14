<template>
    <v-card class="mx-auto" width="100%">
      <v-btn>设置角色</v-btn>
      <ccTable :defaultItem="defaultItem" :headers="headers" :axiosUrls="axiosUrls" ></ccTable>
    </v-card>

</template>
<script>
import ccTable from "@/components/Table.vue"
export default {
  components: {
    ccTable
  },
  data: () => ({
axiosUrls:{
  get:"user/getuser",
  update:"user/updateuser",
  del:"user/delListuser",
  add:"user/adduser"
},
    headers: [
      {text: "编号",align: "start",value: "id"},
      { text: "用户名", value: "username", sortable: false },
      { text: "密码", value: "password", sortable: false },
      { text: "图标", value: "icon", sortable: false },
       { text: "昵称", value: "nick", sortable: true },
       { text: "邮箱", value: "email", sortable: true },
        { text: "IP", value: "ip", sortable: false },
        { text: "年龄", value: "age", sortable: false },
      { text: "操作", value: "actions", sortable: false },
    ],
   defaultItem: {
      username: "test",
      password: "123",
      icon: "mdi-lock",
      nick:"橙子",
      age:18
    }
  }),
};
</script>