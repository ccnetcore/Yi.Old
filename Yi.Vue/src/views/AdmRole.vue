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
export default {
  created() {
    this.init();
  },
  methods: {
    init() {
    }
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
      role_name: "",
      introduce: "",
    },
  }),
};
</script>