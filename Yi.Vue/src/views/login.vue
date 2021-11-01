<template>
  <v-card class="auth-card">
    <!-- logo -->
    <v-card-title class="d-flex align-center justify-center py-7">
      <router-link to="/" class="d-flex align-center">
        <v-img
          :src="require('@/assets/logo.svg')"
          max-height="30px"
          max-width="30px"
          alt="logo"
          contain
          class="me-3"
        ></v-img>
        <h2 class="text-2xl font-weight-semibold">Yi-Framework</h2>
      </router-link>
    </v-card-title>

    <!-- title -->
    <v-card-text>
      <p class="text-2xl font-weight-semibold text--primary mb-2">
        欢迎来到CCNetCore! 👋🏻
      </p>
      <p class="mb-2">登入你的用户，开始畅游一切</p>
    </v-card-text>

    <!-- login form -->
    <v-card-text>
      <v-form>
        <v-text-field
          v-model="form.username"
          outlined
          label="用户"
          placeholder="123456789@qq.com"
          counter="20"
        ></v-text-field>

        <v-text-field
          v-model="form.password"
          outlined
          :type="isPasswordVisible ? 'text' : 'password'"
          label="密码"
          placeholder="············"
          :append-icon="isPasswordVisible ? 'mdi-eye' : 'mdi-eye-off'"
          @click:append="isPasswordVisible = !isPasswordVisible"
        ></v-text-field>

        <div class="d-flex align-center justify-space-between flex-wrap">
          <v-checkbox label="记住密码" hide-details class="me-3 mt-1">
          </v-checkbox>

          <!-- forgot link -->
          <a href="javascript:void(0)" class="mt-1"> 忘记密码? </a>
        </div>

        <v-btn block color="primary" @click="login" class="mt-6"> 登录 </v-btn>
      </v-form>
    </v-card-text>

    <!-- create new account  -->
    <v-card-text class="d-flex align-center justify-center flex-wrap mt-2">
      <span class="me-2"> 没有我们的账号? </span>
      <router-link :to="{ path: '/register' }"> 注册账号 </router-link>
    </v-card-text>

    <!-- divider -->
    <v-card-text class="d-flex align-center mt-2">
      <v-divider></v-divider>
      <span class="mx-5">or</span>
      <v-divider></v-divider>
    </v-card-text>

    <!-- social links -->
    <v-card-actions class="d-flex justify-center ">
      <v-btn v-for="link in socialLink" :key="link.icon" icon class="ms-1">
        <v-icon :color="$vuetify.theme.dark ? link.colorInDark : link.color">
          {{ link.icon }}
        </v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  data: () => ({
    socialLink: [
      {
        icon: "mdi-qqchat",
        color: "#8D5EE0",
        colorInDark: "#8D5EE0",
      },
      {
        icon: "mdi-facebook",
        color: "#4267b2",
        colorInDark: "#4267b2",
      },
      {
        icon: "mdi-twitter",
        color: "#1da1f2",
        colorInDark: "#1da1f2",
      },
      {
        icon: "mdi-github",
        color: "#272727",
        colorInDark: "#fff",
      },
      {
        icon: "mdi-google",
        color: "#db4437",
        colorInDark: "#db4437",
      },
    ],

    isPasswordVisible: false,
    form: {
      username: "",
      password: "",
    },
  }),
  methods: {
    login() {
      this.$store.dispatch("Login", this.form).then((resp) => {
        if (resp.status) {
          this.$router.push("/");
        } else {
          this.$dialog.notify.error(resp.msg, {
            position: "top-right",
            timeout: 5000,
          });
        }
      });
    },
  },
};
</script>
