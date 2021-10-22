<template>
<v-app>
  <div class="auth-wrapper auth-v1">

    <div class="auth-inner">
      <router-view></router-view>
    </div>

    <!-- background triangle shape  -->
    <img
      class="auth-mask-bg"
      height="173"
      :src="
        require(`@/assets/mask-${$vuetify.theme.dark ? 'dark' : 'light'}.png`)
      "
    />

    <!-- tree -->
    <v-img
      class="auth-tree"
      width="247"
      height="185"
      src="@/assets/tree.png"
    ></v-img>

    <!-- tree  -->
    <v-img
      class="auth-tree-3"
      width="377"
      height="289"
      src="@/assets/tree-3.png"
    ></v-img>
  </div>
</v-app>
</template>
<style lang="scss">
@import "@/styles/auth.scss";
</style>