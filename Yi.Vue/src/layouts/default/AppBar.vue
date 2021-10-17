<template>
  <v-app-bar
    id="default-app-bar"
    app
    absolute
    class="v-bar--underline"
    color="transparent"
    :clipped-left="$vuetify.rtl"
    :clipped-right="!$vuetify.rtl"
    height="70"
    flat
  >
    <v-app-bar-nav-icon class="hidden-md-and-up" @click="$store.state.home.drawer = !$store.state.home.drawer;" />

    <default-drawer-toggle class="hidden-sm-and-down" />

    <v-toolbar-title class="font-weight-light text-h5" v-text="name" />

    <v-spacer />

    <default-search class="hidden-sm-and-down" />

    <default-go-home />

    <default-notifications />

    <default-account />
    
  </v-app-bar>
</template>

<script>
// Utilities
// import { get, sync } from 'vuex-pathify'

export default {
  
  data: () => ({
    name: "系统",
  }),
  name: "DefaultBar",

  components: {
    DefaultAccount: () =>
      import(
        /* webpackChunkName: "default-account" */
        "./widgets/Account"
      ),
    DefaultDrawerToggle: () =>
      import(
        /* webpackChunkName: "default-drawer-toggle" */
        "./widgets/DrawerToggle"
      ),
    DefaultGoHome: () =>
      import(
        /* webpackChunkName: "default-go-home" */
        "./widgets/GoHome"
      ),
    DefaultNotifications: () =>
      import(
        /* webpackChunkName: "default-notifications" */
        "./widgets/Notifications"
      ),
    DefaultSearch: () =>
      import(
        /* webpackChunkName: "default-search" */
        "./widgets/Search"
      ),
  },

  // computed: {
  //   ...sync('app', [
  //     'drawer',
  //     'mini',
  //   ]),
  //   name: get('route/name'),
  // },
};
</script>
