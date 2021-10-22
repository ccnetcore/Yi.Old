<template>
  <v-navigation-drawer
    id="default-drawer"
    v-model="$store.state.home.drawer"
    :dark="dark"
    :right="$vuetify.rtl"
    :src="$store.state.home.drawerImage ? image : ''"
    :mini-variant.sync="$store.state.home.mini"
    mini-variant-width="80"
    app
    width="260"
  >
    <template v-if="$store.state.home.drawerImage" #img="props">
      <v-img :key="image" :gradient="gradient" v-bind="props" />
    </template>

    <div class="px-2">
      <default-drawer-header />

      <v-divider class="mx-3 mb-2" />

      <default-list :items="items" />
    </div>

    <template #append>
      <div class="pa-4 text-center">
        <app-btn
          class="text-none mb-4"
          color="white"
          href="https://vuetifyjs.com"
          small
          text
        >
          Documentation
        </app-btn>

        <app-btn block class="text-none" color="secondary" @click="logout">
          <v-icon left> mdi-package-up </v-icon>

          退出
        </app-btn>
      </div>
    </template>

    <div class="pt-12" />
  </v-navigation-drawer>
</template>

<script>
// Utilities
// import { get, sync } from 'vuex-pathify'

export default {
  methods: {
    logout() {
      this.$store.dispatch("Logout").then((resp) => {
        this.$router.push({ path: "/login" });
      });
    },
  },
  data: () => ({
    image:
      "https://demos.creative-tim.com/material-dashboard-pro/assets/img/sidebar-1.jpg",

    gradient: "rgba(228, 226, 226, 1), rgba(255, 255, 255, 0.7)",

    dark: null,

    items: [
      {
        menu_name: "首页",
        icon: "mdi-view-dashboard",
        router: "/",
      },
      {
        menu_name: "用户角色管理",
        icon: "mdi-account",
        router: "",
        children: [
          {
            menu_name: "用户管理",
            icon: "mdi-account",
            router: "/admuser/",
             children: null,
          },
          {
            menu_name: "角色管理",
            icon: "mdi-account-tie",
            router: "/admrole/",
            children: null,
          },
        ],
      },
      {
        menu_name: "菜单接口管理",
        icon: "mdi-clipboard-outline",
        router: "",
        children: [
          {
            menu_name: "菜单管理",
            icon: "mdi-account",
            router: "/admMenu/",
            children: null,
          },
          {
            menu_name: "接口管理",
            icon: "mdi-account",
            router: "/admMould/",
            children: null,
          },
          {
            menu_name: "角色菜单分配管理",
            icon: "mdi-account",
            router: "/admRoleMenu/",
            children: null,
          },
        ],
      },
      {
        menu_name: "测试路由",
        icon: "mdi-clipboard-outline",
        router: "",
        children: [
          {
            menu_name: "用户信息",
            icon: "mdi-account",
            router: "/userinfo/",
            children: null,
          },
        ],
      },
    ],
  }),
  name: "DefaultDrawer",

  components: {
    DefaultDrawerHeader: () =>
      import(
        /* webpackChunkName: "default-drawer-header" */
        "./widgets/DrawerHeader"
      ),
    DefaultList: () =>
      import(
        /* webpackChunkName: "default-list" */
        "./List"
      ),
  },

  // computed: {
  //   ...get('user', [
  //     'dark',
  //     'gradient',
  //     'image',
  //   ]),
  //   ...get('app', [
  //     'items',
  //     'version',
  //   ]),
  //   ...sync('app', [
  //     'drawer',
  //     'drawerImage',
  //     'mini',
  //   ]),
  // },
};
</script>

<style lang="sass">
#default-drawer
  .v-list-item
    margin-bottom: 8px

  .v-list-item::before,
  .v-list-item::after
    display: none

  .v-list-group__header__prepend-icon,
  .v-list-item__icon
    margin-top: 12px
    margin-bottom: 12px
    margin-left: 4px

  &.v-navigation-drawer--mini-variant
    .v-list-item
      justify-content: flex-start !important
</style>
