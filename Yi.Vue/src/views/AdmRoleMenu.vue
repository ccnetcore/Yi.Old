<template>
  <v-row>
    <v-col cols="12">
<material-card color="primary" icon="mdi-account-outline">
    <template #title>
      角色菜单分配管理 — <small class="text-body-1">你可以在这里多角色分配多菜单</small>
    </template><app-btn  class="ma-4" @click="setMenu">确定分配</app-btn></material-card>
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
import menuApi from "../api/menuApi";
export default {
  created() {
 this.init();
  },
watch: {
     selectionRole:{
         handler(val, oldVal){
              if(val.length==1)
              {
                ////
                this.selectionMenu=[{id:38},{id:39}]
              }
         },
         deep:true
     },
  },
  methods: {
    setMenu(){
     var roleIds=[];
     var menuIds=[];
     this.selectionRole.forEach((ele)=>{
       roleIds.push(ele.id)
     })
     this.selectionMenu.forEach((ele)=>{
       menuIds.push(ele.id)
     })
      roleApi.setMenuByRole(roleIds,menuIds).then(resp=>{
                this.$dialog.notify.info(resp.msg, {
          position: "top-right",
          timeout: 5000,
        });
      })
    },
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