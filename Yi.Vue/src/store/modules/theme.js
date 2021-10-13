import vuetify from '../../plugins/vuetify';
const state = { //状态
    light: {
        primary: '#1976D2',
        secondary: '#424242',
        accent: '#82B1FF',
        error: '#FF5252',
        info: '#2196F3',
        success: '#4CAF50',
        warning: '#FFC107',
        cyan: "#FAB2B1",
        blue: "#2196F3"
    },
    dark: {}
}

const mutations = { //变化//载荷
    SET_Light(state, n) {
        state.light = n
        vuetify.framework.theme.themes.light = n
    },
}

//在action中可以配合axios进行权限判断
const actions = { //动作
    set_light(context, n) {
        context.commit('SET_Light', n)
    },

}


export default { state, mutations, actions }