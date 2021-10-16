<template>
  <v-dialog v-model="dialog" persistent max-width="600px">
    <template v-slot:activator="{ on, attrs }">
      <v-btn class="ma-2" color="primary" dark v-bind="attrs" v-on="on">
        {{ headers }}
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="text-h5">{{ headers }}</span>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12">
              <v-combobox
                v-model="select"
                :items="items"
                label="请点击选择"
                multiple
                chips
                :item-text="itemText"
              ></v-combobox>
            </v-col>
          </v-row>
        </v-container>
        <small>*可多选</small>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="dialog = false"> 关闭 </v-btn>
      <div @click="dialog = false"> <slot name="save" ></slot> </div>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: {
    headers: {
      type: String
    },
    items:{
        type:Array
    },
    itemText:{
        type: String
    }
  },
  name: "ccCombobox",
  data() {
    return {
      dialog: false,
      select: [],
    };
  },
  watch:{
     select:{//深度监听，可监听到对象、数组的变化
         handler(val, oldVal){
              this.$emit("select",val);
         },
         deep:true
     }
  },
};
</script>