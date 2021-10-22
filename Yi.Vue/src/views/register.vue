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
        注册-从这里开始 🚀
      </p>
      <p class="mb-2">加入我们，获得一个有趣的灵魂！</p>
    </v-card-text>

    <!-- login form -->
    <v-card-text>
      <v-form>
        <v-text-field
          v-model="form.username"
          outlined
          label="用户名"
          placeholder="JohnDoe"

          class="mb-3"
          counter="20"
        ></v-text-field>

        <v-text-field
          v-model="form.email"
          outlined
          label="邮箱"
          placeholder="john@example.com"

          class="mb-3"
        ></v-text-field>

        <v-text-field
          v-model="form.password"
          outlined
          :type="isPasswordVisible ? 'text' : 'password'"
          label="密码"
          placeholder="············"
          :append-icon="
            isPasswordVisible ? 'mdi-eye' : 'mdi-eye-off'
          "
          @click:append="isPasswordVisible = !isPasswordVisible"
        ></v-text-field>

        <v-checkbox hide-details class="mt-1">
          <template #label>
            <div class="d-flex align-center flex-wrap">
              <span class="me-2">我同意</span
              ><a href="javascript:void(0)">协议 &amp; 策略</a>
            </div>
          </template>
        </v-checkbox>

        <v-btn block color="primary" class="mt-6"> 注册 </v-btn>
      </v-form>
    </v-card-text>

    <!-- create new account  -->
    <v-card-text class="d-flex align-center justify-center flex-wrap mt-2">
      <span class="me-2"> 已经存在账号? </span>
      <router-link :to="{ path: '/login' }"> 跳转登录 </router-link>
    </v-card-text>

    <!-- divider -->
    <v-card-text class="d-flex align-center mt-2">
      <v-divider></v-divider>
      <span class="mx-5">or</span>
      <v-divider></v-divider>
    </v-card-text>

    <!-- social link -->
    <v-card-actions class="d-flex justify-center">
          <v-btn
            v-for="link in socialLink"
            :key="link.icon"
            icon
            class="ms-1"
          >
            <v-icon :color="$vuetify.theme.dark ? link.colorInDark:link.color">
              {{ link.icon }}
            </v-icon>
          </v-btn>
        </v-card-actions>
  </v-card>
</template>
<script>
export default {
  data: () => ({
    socialLink:[
     {
        icon: 'mdi-qqchat',
        color: '#8D5EE0',
        colorInDark: '#8D5EE0',
      },
   {
        icon: 'mdi-facebook',
        color: '#4267b2',
        colorInDark: '#4267b2',
      },
      {
        icon: 'mdi-twitter',
        color: '#1da1f2',
        colorInDark: '#1da1f2',
      },
      {
        icon: 'mdi-github',
        color: '#272727',
        colorInDark: '#fff',
      },
      {
        icon: 'mdi-google',
        color: '#db4437',
        colorInDark: '#db4437',
      },
],

    isPasswordVisible: false,
    form: {
      email: "",
      username: "",
      password: "",
    },
  }),
};
</script>