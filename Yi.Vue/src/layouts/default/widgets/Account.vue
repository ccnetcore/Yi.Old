<template>
  <v-menu
    bottom
    left
    min-width="200"
    offset-y
    origin="top right"
    transition="scale-transition"
  >
    <template v-slot:activator="{ attrs, on }">
      <v-btn class="ml-2" min-width="0" text v-bind="attrs" v-on="on">
        <!-- <v-icon>mdi-account</v-icon> -->
        <ccAvatar :size="36" class="elevation-2"></ccAvatar>
      </v-btn>
    </template>

    <v-list :tile="false" flat nav>
      <app-bar-item to="/"
        ><v-list-item-title v-text="'用户名：'+$store.state.user.user.username"
      /></app-bar-item>
      <app-bar-item to="/"
        ><v-list-item-title v-text="'称号：'+$store.state.user.user.nick"
      /></app-bar-item>

      <v-divider class="mb-2 mt-2" />

      <template v-for="(p, i) in profile">
        <v-divider v-if="p.divider" :key="`divider-${i}`" class="mb-2 mt-2" />

        <app-bar-item v-else :key="`item-${i}`" to="/">
          <v-list-item-title v-text="p.title" />
        </app-bar-item>
      </template>
    </v-list>
  </v-menu>
</template>

<script>
export default {
  name: "DefaultAccount",
    data: () => ({
      profile: [
        { title: "用户信息" },
        { title: "设置" },
        { divider: true },
        { title: "登出" },
      ],
    }),
};
</script>
