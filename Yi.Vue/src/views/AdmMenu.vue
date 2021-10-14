<template>
    <v-card class="mx-auto" width="100%">
    <ccTreeview :items="Menuitems"></ccTreeview>
    </v-card>

</template>
<script>
export default {
  data: () => ({
    Menuitems: [
      {
        id: 1,
        menu_name: "用户角色管理",
        children: [
          {
            id: 2,
            menu_name: "用户管理",
            children: [
              {
                id: 4,
                menu_name: "添加",
                children: [],
              },
              {
                id: 5,
                menu_name: "修改",
                children: [],
              },
              {
                id: 7,
                menu_name: "删除",
                children: [],
              },
              {
                id: 8,
                menu_name: "查询",
                children: [],
              },
            ],
          },
          { id: 3, menu_name: "角色管理" },
        ],
      },
    ],
  })
};
</script>