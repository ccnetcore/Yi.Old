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
import {handUrl} from '../util/getMould'
export default {
  created() {
    this.init();
  },
  methods: {
    recursiveFun(menuList, menuStr) {
      if (this.start) {
        this.getUrlFun(menuList, menuStr);
      }
    },
    getUrlFun(menuList, menuStr) {
      for (var i = 0; i < menuList.length; i++) {
        if (menuList[i].menu_name == menuStr) {
          this.start = false;
        this.axiosUrls= handUrl(menuList[i]);
        } else {
          if (menuList[i].children != undefined && this.start) {
            this.recursiveFun(menuList[i].children, menuStr);
          }
        }
      }
    },
    init() {
      const resp = [
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
                  menu_name: "",
                  icon: "mdi-account",
                  to: "/admrole/",
                  mould: {
                    mould_name: "get",
                    url: "/role/getrole",
                  },
                },
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
            },
          ],
        },
      ];
      this.recursiveFun(resp, "用户管理");
    },
  },
  data: () => ({
    start: true,
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