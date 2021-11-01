<template>
  <div id="settings-wrapper">
    <v-card
      id="settings"
      class="py-2 px-4"
      color="rgba(0, 0, 0, .3)"
      dark
      flat
      link
      min-width="100"
      style="
        position: fixed;
        top: 115px;
        right: -35px;
        border-radius: 8px;
        z-index: 1;
      "
    >
      <v-icon large> mdi-cog </v-icon>
    </v-card>

    <v-menu
      v-model="menu"
      :close-on-content-click="false"
      activator="#settings"
      bottom
      content-class="v-settings"
      left
      nudge-left="8"
      offset-x
      origin="top right"
      transition="scale-transition"
    >
      <v-card class="text-center mb-0" width="300">
        <v-card-text>
          <strong class="mb-3 d-inline-block">主题颜色</strong>

          <v-item-group v-model="color" mandatory>
            <v-item v-for="color in colors" :key="color" :value="color">
              <template v-slot="{ active, toggle }">
                <v-avatar
                  :class="active && 'v-settings__item--active'"
                  :color="color"
                  class="v-settings__item mx-1"
                  size="25"
                  @click="toggle"
                />
              </template>
            </v-item>
          </v-item-group>

          <v-divider class="my-4 secondary" />

          <strong class="mb-3 d-inline-block">图层颜色</strong>

          <v-item-group v-model="gradient" mandatory>
            <v-item
              v-for="(scrim, index) in gradients"
              :key="scrim"
              :value="index"
              class="mx-1"
            >
              <template v-slot="{ active, toggle }">
                <v-avatar
                  :class="active && 'v-settings__item--active'"
                  :color="scrim"
                  class="v-settings__item"
                  size="24"
                  @click="toggle"
                />
              </template>
            </v-item>
          </v-item-group>

          <v-divider class="my-4 secondary" />

          <v-row align="center" no-gutters>
            <v-col cols="auto"> 主题模式 </v-col>

            <v-spacer />

            <v-col cols="auto">
              <v-switch
                v-model="$vuetify.theme.dark"
                class="ma-0 pa-0"
                color="secondary"
                hide-details
              />
            </v-col>
          </v-row>

          <v-divider class="my-4 secondary" />

          <v-row align="center" no-gutters>
            <v-col cols="auto"> 迷你菜单 </v-col>

            <v-spacer />

            <v-col cols="auto">
              <v-switch
                v-model="$store.state.home.mini"
                class="ma-0 pa-0"
                color="secondary"
                hide-details
              />
            </v-col>
          </v-row>

          <v-divider class="my-4 secondary" />

          <v-row align="center" no-gutters>
            <v-col cols="auto"> 图片菜单 </v-col>

            <v-spacer />

            <v-col cols="auto">
              <v-switch
                v-model="drawerImage"
                class="ma-0 pa-0"
                color="secondary"
                hide-details
              />
            </v-col>
          </v-row>

          <v-divider class="my-4 secondary" />

          <strong class="mb-3 d-inline-block">图片</strong>

          <v-card :disabled="!drawerImage" flat>
            <v-item-group
              v-model="image"
              class="d-flex justify-space-between mb-3"
            >
              <v-item
                v-for="(img, index) in images"
                :key="img"
                :value="index"
                class="mx-1"
              >
                <template v-slot="{ active, toggle }">
                  <v-sheet
                    :class="active && 'v-settings__item--active'"
                    class="d-inline-block v-settings__item"
                    @click="toggle"
                  >
                    <v-img :src="img" height="100" width="50" />
                  </v-sheet>
                </template>
              </v-item>
            </v-item-group>
          </v-card>

          <v-btn
            block
            class="mb-3"
            color="grey darken-1"
            dark
            href="https://github.com/ccnetcore/yi"
            rel="noopener"
            target="_blank"
          >
            Github 地址
          </v-btn>

          <v-btn
            block
            color="info"
            href="https://ccnetcore.com"
            rel="noopener"
            target="_blank"
          >
            加入我们
          </v-btn>

          <div class="my-12" />

          <div>
            <strong class="mb-3 d-inline-block">感谢你的支持！</strong>
          </div>

          <v-btn class="ma-1" color="#55acee" dark rounded>
            <v-icon>mdi-twitter</v-icon>
            - 45
          </v-btn>

          <v-btn class="ma-1" color="#3b5998" dark default rounded>
            <v-icon>mdi-facebook</v-icon>
            - 50
          </v-btn>
        </v-card-text>
      </v-card>
    </v-menu>
  </div>
</template>

<script>
// Mixins
import Proxyable from "vuetify/lib/mixins/proxyable";

// Vuex
// import { get, sync } from 'vuex-pathify'

export default {
  name: "DashboardCoreSettings",

  mixins: [Proxyable],
computed: {


gradients(){
  return this.$store.state.user.gradients},
    image:{
      get(){
              return this.$store.state.user.drawer.image;
            },
            set(value){
                this.$store.commit('SetImage',value)
            }
    },
  gradient:{
            get(){
                 return this.$store.state.user.drawer.gradient;
            },
            set(value){
                this.$store.commit('SetGradient',value)
            }
    },
    images()
    {
     return  this.$store.state.user.images;
    },
        drawerImage:
    {
               get(){
                      return  this.$store.state.home.drawerImage;
            },
            set(value){
                this.$store.commit('SetDrawerImage',value)
            },



    },
                      dark()
    {
     return  this.$store.state.user.dark;
    },
                          drawer()
    {
     return  this.$store.state.home.drawer;
    }
},



  data: () => ({
    color: "#E91E63",
    colors: ["#9C27b0", "#00CAE3", "#4CAF50", "#ff9800", "#E91E63", "#FF5252"],
    menu: false,
    saveImage: "",
  }),

  // computed: {
  //   ...sync('app', [
  //     'drawer',
  //     'drawerImage',
  //     'mini',
  //   ]),
  //   ...sync('user', [
  //     'drawer@gradient',
  //     'drawer@image',
  //   ]),
  //   ...get('user', [
  //     'images',
  //     'gradients',
  //   ]),
  // },

  watch: {
    color(val) {

      this.$vuetify.theme.themes[this.isDark ? "dark" : "light"].primary = val;
                  this.$vuetify.theme.dark=true;
      this.$vuetify.theme.dark=false;
    },
  },
};
</script>

<style lang="sass">
  .v-settings
    .v-item-group > *
      cursor: pointer

    &__item
      border-width: 3px
      border-style: solid
      border-color: transparent !important

      &--active
        border-color: #00cae3 !important
</style>
