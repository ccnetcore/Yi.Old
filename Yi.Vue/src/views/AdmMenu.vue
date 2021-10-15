<template>
  <v-card class="mx-auto" width="100%">
    <v-btn color="primary" dark class="mb-2 mx-2" @click="dialog = true">
      添加新项
    </v-btn>
    <v-btn color="primary" dark class="mb-2 mx-2" @click="dialog = true">
      删除所选
    </v-btn>
    <ccTreeview :items="Menuitems"></ccTreeview>
  </v-card>
</template>
<script>
import menuApi from "../api/MenuApi";
export default {
  created() {
    this.init();
  },
  data: () => ({
    Menuitems: [],
  }),
  methods: {
    init() {
      menuApi.getMenu().then((resp) => {
        this.Menuitems = resp.data;
      });
    },
  },
};
</script>