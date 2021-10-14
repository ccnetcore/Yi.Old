<template>
 
    <v-row>
      <v-col cols="12" md="4" lg="4">
         <v-card class="mx-auto" width="100%">
        <v-treeview
          selectable
          :items="RoleItems"
          v-model="selectionRole"
          return-object
          open-all
          hoverable
          item-text="role_name"
        >
        </v-treeview>
         </v-card>
      </v-col>

      <v-col cols="12" md="8" lg="8">
         <v-card class="mx-auto" width="100%">
        <v-treeview
          selectable
          :items="Menuitems"
          selection-type="leaf"
          v-model="selectionMenu"
          return-object
          open-all
          hoverable
          item-text="menu_name"
        >
          <template v-slot:append="{ item }">
            <v-btn>{{ item.id }}</v-btn>
          </template>
        </v-treeview>
          </v-card></v-col
      >

    </v-row>

</template>
<script>
export default {
  data: () => ({
    selectionMenu: [],
    selectionRole: [],
    RoleItems: [
      { id: 1, role_name: "管理员", sex: "测试" },
      { id: 2, role_name: "超级管理员", sex: "测试" },
    ],
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
  }),
};
</script>