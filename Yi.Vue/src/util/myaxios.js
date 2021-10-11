import axios from 'axios'
// import store from '../store/index'
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
    // config.headers.Authorization = 'Bearer ' + store.state.user.token;
    // store.dispatch("openLoad");
    return config;
}, function(error) {
    return Promise.reject(error);
});

// 响应拦截器
myaxios.interceptors.response.use(function(response) {
    const resp = response.data
        // store.dispatch("closeLoad");
    return resp;
}, function(error) {
    const resp = error.response.data
        // if (resp.code == undefined && resp.msg == undefined) {
        //     alert(`错误代码：无，原因：与服务器失去连接`)
        // } else if (resp.code != 200) {
        //     alert(`错误代码：${resp.code}，原因：${resp.msg}`)
        // }
        // store.dispatch("closeLoad");
    return Promise.reject(error);
});
export default myaxios