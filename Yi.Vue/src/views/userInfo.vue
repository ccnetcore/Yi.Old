<template>
  <v-container id="user-profile-view" fluid tag="section">
    <v-row justify="center">
      <v-col cols="12" md="4">
        <app-card class="mt-4 text-center">
          <v-img
            class="rounded-circle elevation-6 mt-n12 d-inline-block"
            src="https://demos.creative-tim.com/vue-material-dashboard/img/marc.aba54d65.jpg"
            width="128"
          />

          <v-card-text class="text-center">
            <h6 class="text-h6 mb-2 text--secondary">橙子</h6>

            <h4 class="text-h4 mb-3 text--primary">橙子大大</h4>

            <p class="text--secondary">我认为世界有我而更精彩！难道不是吗？</p>

            <v-btn class="mr-4" color="primary" min-width="100" rounded>
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
            <v-tabs class="pl-4"  v-model="tab">
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
                      <v-text-field color="purple" label="用户名" />
                    </v-col>
                    <v-col cols="12" md="4">
                      <v-text-field color="purple" label="昵称" />
                    </v-col>
                    <v-col cols="12" md="4">
                      <v-text-field color="purple" label="邮箱" />
                    </v-col>

                    <v-col cols="12" md="6">
                      <v-text-field color="purple" label="住址" />
                    </v-col>
                    <v-col cols="12" md="6">
                      <v-text-field color="purple" label="电话" type="number" />
                    </v-col>
                    <v-col cols="12">
                      <v-textarea
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
                              cols="6"
                              sm="3"
                              md="1"
                              >管理员</v-col
                            >
                          </v-row>
                        </v-list-item-subtitle>
                      </v-list-item-content>
                    </v-list-item>
                    <v-list-item>
                      <v-list-item-action></v-list-item-action>

                      <v-list-item-content>
                        <v-list-item-title>拥有接口：</v-list-item-title>
                        <v-list-item-subtitle>
                          <v-row>
                            <v-col
                              cols="6"
                              sm="3"
                              md="1"
                              >增删改查</v-col
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
                        <v-list-item-title>发帖总数：</v-list-item-title>
                        <v-list-item-subtitle>1000</v-list-item-subtitle>
                      </v-list-item-content>
                    </v-list-item>

                    <v-list-item>
                      <v-list-item-action></v-list-item-action>

                      <v-list-item-content>
                        <v-list-item-title>评论总数：</v-list-item-title>
                        <v-list-item-subtitle>500</v-list-item-subtitle>
                      </v-list-item-content>
                    </v-list-item>

                    <v-list-item>
                      <v-list-item-action></v-list-item-action>
                      <v-list-item-content>
                        <v-btn
                          dark
                          color="primary"
              
                          class="ml-0"
                          dense
                        >
                          查看主题
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
                    outlined
                    clearable
                  ></v-text-field>
                  <v-text-field
                    required
                    style="width: 80%"
                    :counter="120"
                    label="新密码"
                  ></v-text-field>
                </v-col>
                </v-card-text>
                </v-card>
                 </v-tab-item>
            </v-tabs-items>




                                <v-col cols="12" class="text-right">
                      <v-btn color="primary" class="ma-4" min-width="100">
                        清空
                      </v-btn>
                      <v-btn color="secondary" min-width="100"> 保存 </v-btn>
                    </v-col>
          </v-form>
        </material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "UserProfileView",
  data: () => ({
    tab: "tab-1",
  }),
};
</script>
