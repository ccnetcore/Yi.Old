const state = { //状态
    load: false
}

const mutations = { //变化//载荷
    OPEN(state) {
        state.load = true;
    },
    CLOSE(state) {
        state.load = false;
    },
}

//在action中可以配合axios进行权限判断
const actions = { //动作
    openLoad(context) {
        context.commit('OPEN')
    },
    closeLoad(context) {
        context.commit('CLOSE')
    }
}

// const getters = { //类似与计算属性 派生属性
//     msg(state) {
//         if (state.count > 80) {
//             return "成绩优异"
//         } else {
//             return "成绩不合格"
//         }
//     }
// }

export default { state, mutations, actions }