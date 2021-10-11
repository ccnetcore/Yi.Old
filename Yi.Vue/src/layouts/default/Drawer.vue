<template>
  <v-navigation-drawer
    id="default-drawer"
    v-model="drawer"
    :dark="dark"
    :right="$vuetify.rtl"
    :src="drawerImage ? image : ''"
    :mini-variant.sync="mini"
    mini-variant-width="80"
    app
    width="260"
  >
    <template
      v-if="drawerImage"
      #img="props"
    >
      <v-img
        :key="image"
        :gradient="gradient"
        v-bind="props"
      />
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

        <app-btn
          block
          class="text-none"
          color="secondary"
          href="https://store.vuetifyjs.com/products/vuetify-material-dashboard-pro"
        >
          <v-icon left>
            mdi-package-up
          </v-icon>

          Upgrade to Pro
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
    data:()=>({
        gradient: [
    'rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)',
    'rgba(228, 226, 226, 1), rgba(255, 255, 255, 0.7)',
    'rgba(244, 67, 54, .8), rgba(244, 67, 54, .8)',
  ],
        images: [
    'https://demos.creative-tim.com/material-dashboard-pro/assets/img/sidebar-1.jpg',
    'https://demos.creative-tim.com/material-dashboard-pro/assets/img/sidebar-2.jpg',
    'https://demos.creative-tim.com/material-dashboard-pro/assets/img/sidebar-3.jpg',
    'https://demos.creative-tim.com/material-dashboard-pro/assets/img/sidebar-4.jpg',
  ],
      dark:null,
      mini: false,
      items: [
      {
        title: "首页",
        icon: "mdi-view-dashboard",
        to: "/"
      },
      {
        title: "用户管理",
        icon: "mdi-account",
        to: "/admuser/",
      },
      {
        title: "角色管理",
        icon: "mdi-clipboard-outline",
        to: "/admrole/",
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
    name: 'DefaultDrawer',

    components: {
      DefaultDrawerHeader: () => import(
        /* webpackChunkName: "default-drawer-header" */
        './widgets/DrawerHeader'
      ),
      DefaultList: () => import(
        /* webpackChunkName: "default-list" */
        './List'
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
  }
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
