<template>


    <v-card class="mx-auto" width="100%">
      <ccTable :defaultItem="defaultItem" :headers="headers" :axiosUrls="axiosUrls" ></ccTable>
    </v-card>

</template>
<script>
import ccTable from "../components/Table.vue"
export default {
  components: {
    ccTable
  },
  data: () => ({
axiosUrls:{
  get:"action/getactions",
  update:"action/updateaction",
  del:"action/delAllaction",
  add:"action/addaction"
},
    headers: [
      {text: "编号",align: "start",value: "id"},
      { text: "权限名", value: "action_name", sortable: false },
      { text: "路由", value: "router", sortable: false },
      { text: "图标", value: "icon", sortable: false },
       { text: "排序", value: "sort", sortable: true },
      { text: "操作", value: "actions", sortable: false },
    ],
   defaultItem: {
      action_name: "test",
      router: "/my/",
      icon: "mdi-lock",
      sort:"1"
    },

    items: [
      {
        title: "Dashboard",
        icon: "mdi-view-dashboard",
        to: "/",
        items: [
          {
            title: "Dashboard",
            icon: "mdi-view-dashboard",
            to: "/",
            items: [
              {
                title: "User Profile",
                icon: "mdi-account",
                to: "/components/profile/",
              },
            ],
          },
        ],
      },
      {
        title: "User Profile",
        icon: "mdi-account",
        to: "/components/profile/",
      },
      {
        title: "Regular Tables",
        icon: "mdi-clipboard-outline",
        to: "/tables/regular/",
      },
      {
        title: "Typography",
        icon: "mdi-format-font",
        to: "/components/typography/",
      },
      {
        title: "Icons",
        icon: "mdi-chart-bubble",
        to: "/components/icons/",
      },
      {
        title: "Google Maps",
        icon: "mdi-map-marker",
        to: "/maps/google/",
      },
      {
        title: "Notifications",
        icon: "mdi-bell",
        to: "/components/notifications/",
      },
    ],
  }),
};
</script>