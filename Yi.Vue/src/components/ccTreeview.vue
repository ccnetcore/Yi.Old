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
            <v-btn>{{ item.id }}</v-btn>
              <v-btn>设置接口权限</v-btn>
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
  watch:{
     selection:{//深度监听，可监听到对象、数组的变化
         handler(val, oldVal){
              this.$emit("selection",val);
         },
         deep:true
     }
  },
  methods:{

  }
};
</script>