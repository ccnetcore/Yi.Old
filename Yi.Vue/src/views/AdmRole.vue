<template>
    <v-card class="mx-auto" width="100%">
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
  get:"role/getrole",
  update:"role/updaterole",
  del:"role/delListrole",
  add:"role/addrole"
},
    headers: [
      {text: "编号",align: "start",value: "id"},
      { text: "角色名", value: "role_name", sortable: false },
      { text: "简介", value: "introduce", sortable: false },
      { text: "操作", value: "actions", sortable: false }
    ],
   defaultItem: {
      role_name: "test",
      introduce: "用于测试",
    },
  }),
};
</script>