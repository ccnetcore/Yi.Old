const state = {
    drawer: null,
    drawerImage: true,
    mini: false,
    items: [{
            title: 'Dashboard',
            icon: 'mdi-view-dashboard',
            to: '/',
        },
        {
            title: 'User Profile',
            icon: 'mdi-account',
            to: '/components/profile/',
        },
        {
            title: 'Regular Tables',
            icon: 'mdi-clipboard-outline',
            to: '/tables/regular/',
        },
        {
            title: 'Typography',
            icon: 'mdi-format-font',
            to: '/components/typography/',
        },
        {
            title: 'Icons',
            icon: 'mdi-chart-bubble',
            to: '/components/icons/',
        },
        {
            title: 'Google Maps',
            icon: 'mdi-map-marker',
            to: '/maps/google/',
        },
        {
            title: 'Notifications',
            icon: 'mdi-bell',
            to: '/components/notifications/',
        },
    ],
}

const mutations = { //变化//载荷
    SetDrawerImage(state, drawerImage) {
        state.drawerImage = drawerImage
    }
}

//在action中可以配合axios进行权限判断
const actions = { //动作

}
const getters = {}


export default { state, mutations, actions, getters }