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
import getUrl from '../util/getMould'
export default {
  created(){
this.init();
  },
  methods:{
init(){
  const resp=  [
      {
        menu_name: "首页",
        icon: "mdi-view-dashboard",
        to: "/",
      },
      {
        menu_name: "用户角色管理",
        icon: "mdi-account",
        to: "",
        children: [
          {
            menu_name: "用户管理",
            icon: "mdi-account",
            to: "/admuser/",
            children: [
              {
                menu_name: "get",
                 icon: "mdi-account",
                 to: "/admrole/",
                 mould:{
                   mould_name:"get",
                   url: "666666无敌",
                 }
                
              }
            ],
          },
          {
            menu_name: "角色管理",
            icon: "mdi-account-tie",
            to: "/admrole/",
            children: [],
          },
        ],
      },
      {
        menu_name: "菜单接口管理",
        icon: "mdi-clipboard-outline",
        to: "",
        children: [
          {
            menu_name: "菜单管理",
            icon: "mdi-account",
            to: "/admMenu/",
            children: [],
          },
          {
            menu_name: "接口管理",
            icon: "mdi-account",
            to: "/admMould/",
            children: [],
          },
          {
            menu_name: "角色菜单分配管理",
            icon: "mdi-account",
            to: "/admRoleMenu/",
            children: [],
          },
        ],
      },
      {
        menu_name: "测试路由",
        icon: "mdi-clipboard-outline",
        to: "",
        children: [
          {
            menu_name: "用户信息",
            icon: "mdi-account",
            to: "/userinfo/",
            children: [],
          }
        ],
      },
    ];
var mytest= getUrl.getUrl(resp,"用户管理")
console.log(mytest);
}
  },
  data: () => ({
    axiosUrls: {
      get: "role/getrole",
      update: "role/updaterole",
      del: "role/delListrole",
      add: "role/addrole",
    },
    headers: [
      { text: "编号", align: "start", value: "id" },
      { text: "角色名", value: "role_name", sortable: false },
      { text: "简介", value: "introduce", sortable: false },
      { text: "操作", value: "actions", sortable: false },
    ],
    defaultItem: {
      role_name: "test",
      introduce: "用于测试",
    },
  }),
};
</script>