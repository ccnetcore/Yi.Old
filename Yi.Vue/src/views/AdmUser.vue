<template>
  <material-card color="primary" icon="mdi-account-outline">
    <template #title>
      用户管理 — <small class="text-body-1">用户可拥有多个角色</small>
    </template>
    <ccCombobox
      headers="设置角色"
      :items="roleItems"
      @select="getSelect"
      itemText="role_name"
    >
      <template v-slot:save>
        <v-btn @click="setRole" color="blue darken-1" text> 保存</v-btn>
      </template>
    </ccCombobox>
    <ccTable
      :defaultItem="defaultItem"
      :headers="headers"
      :axiosUrls="axiosUrls"
      @selected="getTableSelect"
    >
      <template v-slot:action="{ item }">
        <v-icon small class="mr-2" @click="showItem(item)"> mdi-eye </v-icon>
      </template>
    </ccTable>
  </material-card>
</template>
<script>
import userApi from "../api/userApi";
import roleApi from "../api/roleApi";
export default {
  created() {
    this.init();
  },

  methods: {
    async showItem(item) {
      var strInfo = "";
      roleApi.GetRolesByUserId(item.id).then(async (resp) => {
        const roleData = resp.data;
        strInfo += "拥有的角色:<br>";
        roleData.forEach((u) => {
          strInfo += u.role_name + "<br>";
        });

        strInfo += "<hr>";
        Object.keys(item).forEach(async function (key) {
          strInfo += key + ":" + item[key] + "<br>";
        });

        await this.$dialog.confirm({
          text: strInfo,
          title: "信息详情",
          actions: {
            true: "关闭",
          },
        });
      });
    },
    init() {
      userApi.GetAxiosByRouter(this.$route.path).then((resp) => {
        this.axiosUrls = resp.data;
      });
      roleApi.getRole().then((resp) => {
        this.roleItems = resp.data;
      });
    },
    setRole() {
      var userIds = [];
      var roleIds = [];
      this.TableSelect.forEach((item) => {
        userIds.push(item.id);
      });
      this.select.forEach((item) => {
        roleIds.push(item.id);
      });
      userApi.SetRoleByUser(userIds, roleIds).then((resp) => {
        this.$dialog.notify.success(resp.msg, {
          position: "top-right",
          timeout: 5000,
        });
      });
    },
    getTableSelect(data) {
      this.TableSelect = data;
    },

    getSelect(data) {
      this.select = data;
    },
  },
  data: () => ({
    TableSelect: [],
    select: [],
    roleItems: [],
    axiosUrls: {},
    headers: [
      { text: "编号", align: "start", value: "id" },
      { text: "用户名", value: "username", sortable: false },
      { text: "密码", value: "password", sortable: false },
      { text: "图标", value: "icon", sortable: false },
      { text: "昵称", value: "nick", sortable: true },
      { text: "邮箱", value: "email", sortable: true },
      { text: "IP", value: "ip", sortable: false },
      { text: "年龄", value: "age", sortable: false },
      { text: "地址", value: "address", sortable: false },
      { text: "电话", value: "phone", sortable: false },
      { text: "操作", value: "actions", sortable: false },
    ],
    defaultItem: {
      username: "test",
      password: "123",
      icon: "mdi-lock",
      nick: "橙子",
      age: 18,
      address: "中国",
      phone: "",
    },
  }),
};
</script>