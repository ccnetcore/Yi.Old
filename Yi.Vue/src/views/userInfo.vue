<template>
  <v-container id="user-profile-view" fluid tag="section">
    <v-row justify="center">
      <v-col cols="12" md="4">
        <app-card class="mt-4 text-center">
 <ccAvatar :size="128" class="rounded-circle elevation-6 mt-n12 d-inline-block"></ccAvatar>

          <v-card-text class="text-center">
            <h6 class="text-h6 mb-2 text--secondary">
              {{ userInfo.username }}
            </h6>

            <h4 class="text-h4 mb-3 text--primary">{{ userInfo.nick }}</h4>

            <p class="text--secondary">{{ userInfo.introduction }}</p>
                  <input
                    type="file"
                    ref="imgFile"
                    @change="uploadImage()"
                    class="d-none"
                  />
            <v-btn class="mr-4" @click="choiceImg" color="primary" min-width="100" rounded>
              编辑头像
            </v-btn>
            <v-btn color="primary" min-width="100" rounded> 绑定QQ </v-btn>
          </v-card-text>
        </app-card>
      </v-col>

      <v-col cols="12" md="8">
        <material-card color="primary" icon="mdi-account-outline">
          <template #title>
            用户信息 — <small class="text-body-1">编辑属于你的一切</small>
          </template>

          <v-form>
            <v-tabs class="pl-4" v-model="tab">
              <v-tab href="#tab-1">
                账户信息
                <v-icon>mdi-phone</v-icon>
              </v-tab>

              <v-tab href="#tab-2">
                额外信息
                <v-icon>mdi-account-box</v-icon>
              </v-tab>

              <v-tab href="#tab-3">
                修改密码
                <v-icon>mdi-account-box</v-icon>
              </v-tab>
            </v-tabs>

            <v-tabs-items v-model="tab">
              <v-tab-item :value="'tab-1'">
                <v-card class="py-0">
                  <v-card-text>
                    <div>Account Information</div>
                    <v-row>
                      <v-col cols="12" md="4">
                        <v-text-field
                          color="purple"
                          label="用户名"
                          v-model="editInfo.username"
                          disabled
                        />
                      </v-col>
                      <v-col cols="12" md="4">
                        <v-text-field
                          color="purple"
                          label="昵称"
                          v-model="editInfo.nick"
                        />
                      </v-col>
                      <v-col cols="12" md="4">
                        <v-text-field
                          color="purple"
                          label="邮箱"
                          v-model="editInfo.email"
                        />
                      </v-col>

                      <v-col cols="12" md="6">
                        <v-text-field
                          color="purple"
                          label="住址"
                          v-model="editInfo.address"
                        />
                      </v-col>
                      <v-col cols="12" md="6">
                        <v-text-field
                          color="purple"
                          label="电话"
                          type="number"
                          v-model="editInfo.phone"
                        />
                      </v-col>
                      <v-col cols="12">
                        <v-textarea
                          v-model="editInfo.introduction"
                          color="purple"
                          label="简介"
                          value="空空如也，Ta什么也没有留下"
                        />
                      </v-col>
                    </v-row>
                  </v-card-text>
                </v-card>
              </v-tab-item>
              <v-tab-item :value="'tab-2'">
                <v-card class="py-0 mx-auto">
                  <v-card-text>
                    <div>Extra Information</div>
                    <v-row>
                      <v-col cols="12">
                        <v-list two-line>
                          <v-list-item>
                            <v-list-item-icon>
                              <v-icon color="secondary"> mdi-phone </v-icon>
                            </v-list-item-icon>

                            <v-list-item-content>
                              <v-list-item-title>等级：</v-list-item-title>
                              <v-list-item-subtitle>100</v-list-item-subtitle>
                            </v-list-item-content>

                            <v-list-item-icon>
                              <v-icon>mdi-message-text</v-icon>
                            </v-list-item-icon>
                          </v-list-item>

                          <v-list-item>
                            <v-list-item-action></v-list-item-action>

                            <v-list-item-content>
                              <v-list-item-title>经验：</v-list-item-title>
                              <v-list-item-subtitle>1000</v-list-item-subtitle>
                            </v-list-item-content>

                            <v-list-item-icon>
                              <v-icon>mdi-message-text</v-icon>
                            </v-list-item-icon>
                          </v-list-item>

                          <v-divider inset></v-divider>

                          <v-list-item>
                            <v-list-item-icon>
                              <v-icon color="secondary"> mdi-lock </v-icon>
                            </v-list-item-icon>

                            <v-list-item-content>
                              <v-list-item-title>拥有角色：</v-list-item-title>
                              <v-list-item-subtitle>
                                <v-row>
                                  <v-col
                                    v-for="item in editInfo.roles"
                                    :key="item.id"
                                    cols="6"
                                    sm="3"
                                    md="1"
                                    >{{ item.role_name }}</v-col
                                  >
                                </v-row>
                              </v-list-item-subtitle>
                            </v-list-item-content>
                          </v-list-item>
                          <v-list-item>
                            <v-list-item-action></v-list-item-action>

                            <v-list-item-content>
                              <v-list-item-title>拥有菜单：</v-list-item-title>
                              <v-list-item-subtitle>
                                <v-row>
                                  <v-col
                                    v-for="item in menuInfo"
                                    :key="item.id"
                                    cols="6"
                                    sm="3"
                                    md="1"
                                    >{{ item.menu_name }}</v-col
                                  >
                                </v-row>
                              </v-list-item-subtitle>
                            </v-list-item-content>
                          </v-list-item>

                          <v-divider inset></v-divider>

                          <v-list-item>
                            <v-list-item-icon>
                              <v-icon color="secondary"> mdi-email </v-icon>
                            </v-list-item-icon>

                            <v-list-item-content>
                              <v-list-item-title>等待更新：</v-list-item-title>
                              <v-list-item-subtitle>1000</v-list-item-subtitle>
                            </v-list-item-content>
                          </v-list-item>

                          <v-list-item>
                            <v-list-item-action></v-list-item-action>

                            <v-list-item-content>
                              <v-list-item-title>等待更新：</v-list-item-title>
                              <v-list-item-subtitle>500</v-list-item-subtitle>
                            </v-list-item-content>
                          </v-list-item>

                          <v-list-item>
                            <v-list-item-action></v-list-item-action>
                            <v-list-item-content>
                              <v-btn dark color="primary" class="ml-0" dense>
                                等待更新
                              </v-btn>
                            </v-list-item-content>
                          </v-list-item>
                          <v-divider inset></v-divider>
                        </v-list>
                      </v-col>
                    </v-row>
                  </v-card-text>
                </v-card>
              </v-tab-item>
              <v-tab-item :value="'tab-3'">
                <v-card>
                  <v-card-text>
                    <div>Password Information</div>
                    <v-col cols="12">
                      <v-text-field
                        style="width: 80%"
                        label="原密码"
                        v-model="editInfo.password"
                        outlined
                        clearable
                      ></v-text-field>
                      <v-text-field
                        required
                        style="width: 80%"
                        :counter="120"
                        v-model="newPassword"
                        :disabled="dis_newPassword"
                        label="新密码"
                      ></v-text-field>
                    </v-col>
                  </v-card-text>
                </v-card>
              </v-tab-item>
            </v-tabs-items>

            <v-col cols="12" class="text-right">
              <v-btn color="primary" class="ma-4" min-width="100"> 清空 </v-btn>
              <v-btn color="secondary" @click="save()" min-width="100">
                保存
              </v-btn>
            </v-col>
          </v-form>
        </material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import fileApi from "../api/fileApi";
import userApi from "../api/userApi";
import menuApi from "../api/menuApi";
import accountApi from "../api/accountApi";
export default {
  name: "UserProfileView",
  data: () => ({
    tab: "tab-1",
    userInfo: {},
    editInfo: {},
    newPassword: "",
    dis_newPassword: true,
    menuInfo: [],
  }),
  created() {
    this.init();
  },
  watch: {
    editInfo: {
      handler(val, oldVal) {
        if (val.password.length > 0) {
          this.dis_newPassword = false;
        } else {
          this.dis_newPassword = true;
        }
      },
      deep: true, //true 深度监听
    },
  },

  methods: {
    save() {
      accountApi
        .changePassword(this.editInfo, this.newPassword)
        .then((resp) => {
          if (resp.status) {
            this.$dialog.notify.error(resp.msg, {
              position: "top-right",
              timeout: 5000,
            });
          } else {
            this.$dialog.notify.success(resp.msg, {
              position: "top-right",
              timeout: 5000,
            });
          }
          this.init();
        });
    },
    init() {
      this.newPassword = "";
      userApi.GetUserInRolesByHttpUser().then((resp) => {
        this.userInfo = resp.data;
        this.userInfo.password = "";
        this.editInfo = Object.assign({}, this.userInfo);
        this.$store.commit('SET_USER',this.userInfo)
      });




      menuApi.GetTopMenusByHttpUser().then((resp) => {
        this.menuInfo = resp.data;
      });
    },
choiceImg() {
      this.$refs.imgFile.dispatchEvent(new MouseEvent("click"));
    },
    uploadImage() {
      const file = this.$refs.imgFile.files[0];
      let formData = new FormData();
      formData.append("file", file);
      fileApi.EditIcon(formData).then(resp=>{
        this.init();
                  this.$dialog.notify.success(resp.msg, {
            position: "top-right",
            timeout: 5000,
          });
     })
    },

  },
};
</script>
