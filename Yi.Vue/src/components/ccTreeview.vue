<template>
  <div>
    <v-divider></v-divider>
    <app-btn  dark class="ma-4" @click="dialog = true"> 添加新项 </app-btn>
    <app-btn dark class="my-4"  color="secondary" @click="deleteItem(null)">
      删除所选
    </app-btn>
    
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

    <v-treeview
    open-on-click
      selectable
      :items="desserts"
      :selection-type="selectionType"
      v-model="selection"
      return-object
      open-all
      hoverable
      item-text="menu_name"
    >
      <template v-slot:append="{ item }">
        <v-btn class="mr-2">编号:{{ item.id }}</v-btn>
        <v-btn class="mr-2">图标:{{ item.icon }}</v-btn>
        <v-btn class="mr-2">路由:{{ item.router }}</v-btn>
        <v-btn v-if="item.mould" class="mr-2">接口名:{{ item.mould.mould_name }}</v-btn>
        <v-btn  v-if="item.mould" class="mr-2">接口地址:{{ item.mould.url }}</v-btn>
        <ccCombobox
          headers="设置接口权限"
          itemText="url"
          :items="mouldList"
          @select="getSelect"
        >
          <template v-slot:save>
            <v-btn @click="setMould(item)" color="blue darken-1" text>
              保存</v-btn
            >
          </template>
        </ccCombobox>
         <app-btn
          @click="
            parentId = item.id;
            dialog = true;
          "
          >添加子菜单</app-btn
        >
        <app-btn class="mx-2" @click="editItem(item)">编辑</app-btn>
        
        <app-btn color="secondary" class="mr-2" @click="deleteItem(item)">删除</app-btn>
       
      </template>
    </v-treeview>
  </div>
</template>
<script>
import mouldApi from "../api/mouldApi";
import menuApi from "../api/menuApi";
export default {
  name: "ccTreeview",

  data: () => ({
    mouldSelect: [],
    mouldList: [],
    desserts: [],
    selectionType: "independent",
    selection: [],
    dialog: false,
    editedItem: {},
    editedIndex: -1,
    parentId: 0,
    defaultItem: {
      icon: "mdi-start",
      router: "test",
      menu_name: "测试",
      is_show:1
    },
  }),
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "添加数据" : "编辑数据";
    },
  },
  created() {
    this.init();
  },
  methods: {
    setMould(item) {
      menuApi.SetMouldByMenu(item.id, this.mouldSelect[0].id).then((resp) => {
        this.$dialog.notify.info(resp.msg, {
          position: "top-right",
          timeout: 5000,
        });
               this.init();
      });
    },

    getSelect(data) {
      this.mouldSelect = data;
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
        this.selection.forEach(function (item) {
          Ids.push(item.id);
        });
      }
      menuApi.DelListMenu(Ids).then(() => this.init());
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    init() {
      this.parentId = 0;
      mouldApi.getMould().then((resp) => {
        this.mouldList = resp.data;
      });

      menuApi.getMenu().then((resp) => {
        this.desserts = resp.data;
      });
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    editItem(item) {
      this.editedIndex = item.id;
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },

    save() {
      if (this.editedIndex > -1) {
        menuApi.UpdateMenu(this.editedItem).then(() => this.init());
      } else {
        if (this.parentId == 0) {
          menuApi.addMenu(this.editedItem).then(() => {
            this.init();
          });
        } else {
          menuApi.addChildrenMenu(this.parentId, this.editedItem).then(() => {
            this.init();
          });
        }
      }
      this.close();
    },
  },
  watch: {
    selection: {
      //深度监听，可监听到对象、数组的变化
      handler(val, oldVal) {
        this.$emit("selection", val);
      },
      deep: true,
    },
    dialog(val) {
      val || this.close();
    },
  },
};
</script>