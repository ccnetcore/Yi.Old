import Vue from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import VuetifyDialog from 'vuetify-dialog'
import 'vuetify-dialog/dist/vuetify-dialog.css'
import './plugins'
import "./permission"
import store from './store/index'

Vue.config.productionTip = false
Vue.use(VuetifyDialog, {
    context: {
        vuetify
    }
});
let vm = new Vue({
    router,
    store,
    vuetify,
    render: function(h) { return h(App) }
}).$mount('#app')

export default vm;