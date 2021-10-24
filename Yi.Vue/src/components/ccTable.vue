<template>
  <v-data-table
    :headers="headers"
    :items="desserts"
    sort-by="calories"
    class="elevation-1"
    item-key="id"
    show-select
    v-model="selected"
    :search="search"
  >
    <slot />
    <template v-slot:top>
      <!-- 搜索框 -->
      <v-toolbar flat>
        <v-spacer></v-spacer>
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="搜索"
          single-line
          hide-details
          class="mx-4"
        ></v-text-field>

        <v-btn
          v-if="axiosUrls.add != null"
          color="primary"
          dark
          class="mb-2 mx-2"
          @click="dialog = true"
        >
          添加新项
        </v-btn>

        <!-- 添加提示框 -->
        <v-dialog
          v-if="axiosUrls.add != null"
          v-model="dialog"
          max-width="500px"
        >
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                    v-for="(value, key, index) in editedItem"
                    :key="index"
                  >
                    <v-text-field
                      v-model="editedItem[key]"
                      :label="key"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="close"> 取消 </v-btn>
              <v-btn color="blue darken-1" text @click="save"> 保存 </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>

        <v-btn
          v-if="axiosUrls.del != null"
          color="secondary"
          class="mb-2"
          @click="deleteItem(null)"
        >
          删除所选
        </v-btn>
      </v-toolbar>
    </template>

    <!-- 表格中的删除和修改 -->
    <template v-slot:item.actions="{ item }">
      <slot name="action" :item="item"></slot>

      <v-icon
        v-if="axiosUrls.update != null"
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon v-if="axiosUrls.del != null" small @click="deleteItem(item)">
        mdi-delete
      </v-icon>
    </template>

    <!-- 初始化 -->
    <template v-slot:no-data>
      <v-btn color="primary" @click="initialize"> 刷新 </v-btn>
    </template>
  </v-data-table>
</template>
<script>
import itemApi from "./TableApi.js";
export default {
  name: "ccTable",
  props: {
    defaultItem: {
      type: Object,
    },
    headers: {
      type: Array,
    },
    axiosUrls: {
      type: Object,
    },
  },
  data: () => ({
    page: 1,
    selected: [],
    search: "",
    dialog: false,
    desserts: [],
    editedIndex: -1,
    editedItem: {},
  }),

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "添加数据" : "编辑数据";
    },
  },

  watch: {
    axiosUrls: {
      handler(val, oldVal) {
        this.dataInit(val.get);
      },
      deep: true,
    },
    selected: {
      handler(val, oldVal) {
        this.$emit("selected", val);
      },
      deep: true,
    },
    dialog(val) {
      val || this.close();
    },
  },

  created() {
    this.initialize();
  },

  methods: {
    dataInit(getStr) {
      itemApi.getItem(getStr).then((resp) => {
        const response = resp.data;
        this.desserts = response;
      });
    },
    initialize() {
      if(this.axiosUrls.get!=undefined && this.axiosUrls.get!=null )
      {
         this.dataInit(this.axiosUrls.get)
      }
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    // 添加和修改都打开同一个编辑框

    editItem(item) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },

    async deleteItem(item) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);

      var p = await this.$dialog.warning({
        text: "你确定要删除此条记录吗？?",
        title: "警告",
        actions: {
          false: "取消",
          true: "确定",
        },
      });
      if (p) {
        this.deleteItemConfirm();
      }
    },
    deleteItemConfirm() {
      var Ids = [];
      if (this.editedIndex > -1) {
        Ids.push(this.editedItem.id);
      } else {
        this.selected.forEach(function (item) {
          Ids.push(item.id);
        });
      }
      itemApi
        .delItemList(this.axiosUrls.del, Ids)
        .then(() => this.initialize());
    },
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    save() {
      if (this.editedIndex > -1) {
        itemApi
          .updateItem(this.axiosUrls.update, this.editedItem)
          .then(() => this.initialize());
      } else {
        itemApi
          .addItem(this.axiosUrls.add, this.editedItem)
          .then(() => this.initialize());
      }
      this.close();
    },
  },
};
</script>