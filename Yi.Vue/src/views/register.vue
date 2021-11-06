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
      <p class="text-2xl font-weight-semibold text--primary mb-1">
        注册-从这里开始 🚀
      </p>
      <p class="mb-1">加入我们，获得一个有趣的灵魂！</p>
    </v-card-text>

    <!-- login form -->
    <v-card-text>
      <v-form>
        <v-text-field
          v-model="form.username"
          outlined
          label="用户名"
          placeholder="cc"
          class="mb-1"
          counter="20"
        ></v-text-field>

        <v-text-field
          v-model="form.phone"
          outlined
          label="电话"
          placeholder="12345678901"
          class="mb-1"
        >
        </v-text-field>

        <v-row>
          <v-col cols="9">
            <v-text-field
              v-model="code"
              outlined
              label="验证码"
              placeholder="123456"
              class="mb-1"
            >
            </v-text-field>
          </v-col>
          <v-col cols="3">
            <v-btn color="secondary" @click="sendSMS" class="mb-1 mt-1" :disabled="is_en">验证码</v-btn>
          </v-col>
        </v-row>
        <v-text-field
          v-model="form.password"
          outlined
          :type="isPasswordVisible ? 'text' : 'password'"
          label="密码"
          placeholder="············"
          :append-icon="isPasswordVisible ? 'mdi-eye' : 'mdi-eye-off'"
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

        <v-btn block color="primary" class="mt-6" @click="register">
          注册
        </v-btn>
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
      <v-btn v-for="link in socialLink" :key="link.icon" icon class="ms-1">
        <v-icon :color="$vuetify.theme.dark ? link.colorInDark : link.color">
          {{ link.icon }}
        </v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import accoutAPI from "../api/accountApi";
export default {
  methods: {
    sendSMS() {
      this.is_en=true
      accoutAPI.SendSMS(this.form.phone).then(resp=>{
         if (resp.status) {
            this.$dialog.notify.success(resp.msg, {
              position: "top-right",
              timeout: 5000,
            });
          }
      });
    },
    register() {
      accoutAPI
        .register(
          this.form.username,
          this.form.password,
          this.form.phone,
          this.code
        )
        .then((resp) => {
          if (resp.status) {
            this.$dialog.notify.success(resp.msg, {
              position: "top-right",
              timeout: 5000,
            });
            this.$router.push("/login/");
          } 
        });
    },
  },
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
    code: "",
    is_en:false,
    form: {
      phone: "",
      username: "",
      password: "",
    },
  }),
};
</script>