<template>
  <v-card class="mx-auto" width="100%">
    {{select}}
    <ccCombobox headers='设置角色' :items="items" @select="getSelect" itemText="role_name"></ccCombobox>
    <ccTable
      :defaultItem="defaultItem"
      :headers="headers"
      :axiosUrls="axiosUrls"
    ></ccTable>
  </v-card>
</template>
<script>
export default {
  methods:{
    getSelect(data){
this.select=data;
    }
  },
  data: () => ({
    select:[],
     items: [{id:1,role_name:"管理员"},{id:1,role_name:"超级管理员"}],
    axiosUrls: {
      get: "user/getuser",
      update: "user/updateuser",
      del: "user/delListuser",
      add: "user/adduser",
    },
    headers: [
      { text: "编号", align: "start", value: "id" },
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
      nick: "橙子",
      age: 18,
    },
  }),
};
</script>