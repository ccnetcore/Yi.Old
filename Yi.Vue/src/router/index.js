import Vue from 'vue'
import VueRouter from 'vue-router'

import LayoutLogin from '../layouts/login/LayoutLogin.vue'
import login from '../views/login.vue'
import register from '../views/register.vue'
import { trailingSlash } from '@/util/helpers'
import {
    layout,
    route,
} from '@/util/routes'
Vue.use(VueRouter)



const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    scrollBehavior: (to, from, savedPosition) => {
        if (to.hash) return { selector: to.hash }
        if (savedPosition) return savedPosition

        return { x: 0, y: 0 }
    },
    routes: [{
            path: '/layoutLogin',
            name: 'layoutLogin',
            component: LayoutLogin,
            redirect: "/login",
            children: [{
                    path: "/login",
                    name: "login",
                    component: login
                },
                {
                    path: '/register',
                    name: 'register',
                    component: register
                }
            ]
        },
        layout('Default', [
            route('Index'),
            route('AdmUser', null, 'AdmUser'),
            route('AdmRole', null, 'AdmRole'),
        ])
    ]
})
router.beforeEach((to, from, next) => {
    return to.path.endsWith('/') ? next() : next(trailingSlash(to.path))
})
export default router