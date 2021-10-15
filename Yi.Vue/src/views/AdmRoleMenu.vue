<template>
  <v-row>
    <v-col cols="12">
 <v-card class="mx-auto" width="100%"><v-btn color="primary">确定分配</v-btn></v-card>
    </v-col>
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
            <v-btn>id:{{ item.id }}</v-btn>
          </template>
        </v-treeview>
      </v-card></v-col
    >
  </v-row>
</template>
<script>
import roleApi from "../api/roleApi";
import menuApi from "../api/MenuApi";
export default {
  created() {
 this.init();
  },
  methods: {
    init() {
      roleApi.getRole().then((resp) => {
        this.RoleItems = resp.data;
      });

      menuApi.getMenu().then((resp) => {
        this.Menuitems = resp.data;
      });
    },
  },
  data: () => ({
    selectionMenu: [],
    selectionRole: [],
    RoleItems: [],
    Menuitems: [],
  }),
};
</script>