<template>
  <v-app>
    <v-container fluid class="grey lighten-5" v-bind:style="{ height: allDiv }">
      <v-row v-bind:style="{ height: allDiv }">
        <!-- -------------------------------公告----------------------------------- -->
        <v-col
          cols="0"
          sm="4"
          md="3"
          class="white d-none d-sm-flex text-center"
        >
          <div style="width: 100%">
            <h1 class="light-blue--text mt-8">{{title}} <br />维基 百科</h1>
            <p class="my-4 title">Angstrong</p>
            <p class="my-4 title">欢迎！在这里，我们无所不谈！</p>

<a href="https://beian.miit.gov.cn">工信部备案号：赣ICP备20008025号-2</a>
            <v-img
              src="../../assets/login.svg"
              contain
              v-bind:style="{ marginTop: imgDiv }"
              style="width: 100%"
            ></v-img>
          </div>
        </v-col>
        <!-- -------------------------------------------------------------------------- -->

        <!-- ------------------------------表单-------------------------------- -->
        <v-col cols="12" sm="8" md="9">
          <v-container class="text-center align-center" fluid>
            <div class="mt-15">
            <router-view></router-view>
            </div>
          </v-container>
        </v-col>
        <!-- --------------------------------------------------------------- -->
      </v-row>
    </v-container>
  </v-app>
</template>
<script>
// import settingApi from "@/api/settingApi";
export default {
  created() {
    this.initialize();
  },
  methods: {
    initialize() {
      // settingApi.getTitle().then((resp) => {
      //   this.title = resp.data;
      // });
    },
  },
  data: () => ({
    title:"",
    allDiv: document.documentElement.clientHeight + "px",
    imgDiv: document.documentElement.clientHeight - 540 + "px",
    //   email: '',
    //   emailRules: [
    //     v => !!v || 'E-mail is required',
    //     v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
    //   ],
  }),
};
</script>
