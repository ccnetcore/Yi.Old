<template>
  <v-card>
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

          <v-btn color="primary" dark class="mb-2 mx-2" @click="dialog = true">
            添加新项
          </v-btn>

          <!-- 添加提示框 -->
          <v-dialog v-model="dialog" max-width="500px">
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

          <v-btn color="red" dark class="mb-2" @click="deleteItem(null)">
            删除所选
          </v-btn>

          <!-- 删除提示框 -->
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="headline"
                >你确定要删除此条记录吗？</v-card-title
              >
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="closeDelete"
                  >取消</v-btn
                >
                <v-btn color="blue darken-1" text @click="deleteItemConfirm"
                  >确定</v-btn
                >
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>

      <!-- 表格中的删除和修改 -->
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
        <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
      </template>

      <!-- 初始化 -->
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> 刷新 </v-btn>
      </template>
    </v-data-table>
  </v-card>
</template>
<script>
import itemApi from './TableApi.js'
export default {
  props: {
    defaultItem: {
      type: Object,
    },
    headers: {
      type: Array,
    },
    axiosUrls:{
        type: Object,
    }
  },

  data: () => ({
    page: 1,
    selected: [],
    search: "",
    dialog: false,
    dialogDelete: false,
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
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  created() {
    this.initialize();
  },

  methods: {
    initialize() {
        itemApi.getItem(this.axiosUrls.get).then((resp) => {
          const response = resp.data;
          this.desserts = response;
        });
    
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

    deleteItem(item) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
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
      alert("多行删除");
        ItemApi.delItemList(this.axiosUrls.del,Ids).then(() => this.initialize());
      this.closeDelete();
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
        alert("多行更新");
        ItemApi.updateItem(this.axiosUrls.update,this.editedItem).then(() => this.initialize());
      } else {
        alert("添加");
        ItemApi.addItem(this.axiosUrls.add,this.editedItem).then(() => this.initialize());
      }
      this.close();
    },
  },
};
</script>