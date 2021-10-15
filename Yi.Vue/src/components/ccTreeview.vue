<template>
  <v-treeview
    selectable
    :items="items"
    :selection-type="selectionType"
    v-model="selection"
    return-object
    open-all
    hoverable
    item-text="menu_name"
  >
    <template v-slot:append="{ item }">
      <v-btn>编号:{{ item.id }}</v-btn>
      <v-btn>图标:{{ item.icon }}</v-btn>
      <v-btn>路由:{{ item.router }}</v-btn>
      <v-btn>设置接口权限</v-btn>
      <v-btn>编辑</v-btn>
      <v-btn>删除</v-btn>
      <v-btn>添加子菜单</v-btn>
    </template>
  </v-treeview>
</template>
<script>
export default {
  name: "ccTreeview",
  props: {
    items: {
      type: Array,
    },
  },
  data: () => ({
    selectionType: "leaf",
    selection: [],
  }),
  watch: {
    selection: {
      //深度监听，可监听到对象、数组的变化
      handler(val, oldVal) {
        this.$emit("selection", val);
      },
      deep: true,
    },
  },
  methods: {},
};
</script>