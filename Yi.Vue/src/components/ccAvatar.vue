<template>
        <v-avatar  :size="size" >
              <!-- <img src="https://z3.ax1x.com/2021/05/09/gJadhD.jpg" /> -->
              <img
                :src="baseurl +'/image/'+$store.state.user.user.icon"
              />
            </v-avatar>
</template>

<script>
  // Utilities
  // import { get } from 'vuex-pathify'

  export default {
    name: 'ccAvatar',
        mounted() {
    this.baseurl = process.env.VUE_APP_BASE_API;
  },
 data:()=>({
    baseurl: "",
 }),
  props: {
    size: {
      type: Number,
    }
  },
  }
</script>
