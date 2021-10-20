import axios from 'axios'
import store from '../store/index'
import vm from '../main'
// import VuetifyDialogPlugin from 'vuetify-dialog/nuxt/index';
const myaxios = axios.create({
        // baseURL:'/'// 
        baseURL: process.env.VUE_APP_BASE_API, // /dev-apis
        timeout: 50000,
        headers: {
            'Authorization': 'Bearer ' + ""
        },
    })
    // 请求拦截器
myaxios.interceptors.request.use(function(config) {
    config.headers.Authorization = 'Bearer ' + store.state.user.token;
    store.dispatch("openLoad");
    return config;
}, function(error) {
    return Promise.reject(error);
});

// 响应拦截器
myaxios.interceptors.response.use(async function(response) {
    const resp = response.data
    if (resp.code == undefined && resp.msg == undefined) {
        vm.$dialog.notify.error("错误代码：无，原因：与服务器失去连接", {
            position: "top-right",
            timeout: 5000,
        });
    } else if (resp.code == 401) {
        const res = await vm.$dialog.error({
            text: `错误代码：${resp.code}，原因：${resp.msg}<br>是否重新进行登录？`,
            title: '错误',
            actions: {
                'false': '取消',
                'true': '跳转'
            }
        });
        if (res) {
            vm.$router.push({ path: "/login" });
        }

    } else if (resp.code !== 200) {
        vm.$dialog.notify.error(`错误代码：${resp.code}，原因：${resp.msg}`, {
            position: "top-right",
            timeout: 5000,
        });
    }

    store.dispatch("closeLoad");
    return resp;
}, async function(error) {
    const resp = error.response.data
    if (resp.code == undefined && resp.msg == undefined) {
        vm.$dialog.notify.error("错误代码：无，原因：与服务器失去连接", {
            position: "top-right",
            timeout: 5000,
        });
    } else if (resp.code == 401) {
        const res = await vm.$dialog.error({
            text: `错误代码：${resp.code}，原因：${resp.msg}<br>是否重新进行登录？`,
            title: '错误',
            actions: {
                'false': '取消',
                'true': '跳转'
            }
        });
        if (res) {
            vm.$store.dispatch("Logout").then((resp) => {
                vm.$router.push({ path: "/login" });
            });
        }

    } else if (resp.code !== 200) {
        vm.$dialog.notify.error(`错误代码：${resp.code}，原因：${resp.msg}`, {
            position: "top-right",
            timeout: 5000,
        });
    }

    store.dispatch("closeLoad");
    return Promise.reject(error);
});
export default myaxios