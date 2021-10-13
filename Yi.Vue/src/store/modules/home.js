const state = { //状态
    plateId: 0,
    discussId: 0,
    plateString: "",
}

const mutations = { //变化//载荷
    SET_PLATEID(state, n) {
        state.plateId = n
    },
    SET_DOSCUSSIDSTRING(state, n) {
        state.plateString = n
    },
    SET_DOSCUSSID(state, n) {
        state.discussId = n
    },
}

//在action中可以配合axios进行权限判断
const actions = { //动作
    set_plateId(context, n) {
        context.commit('SET_PLATEID', n)
    },
    set_plateString(context, n) {
        context.commit('SET_DOSCUSSIDSTRING', n)
    },
    set_discussId(context, n) {
        context.commit('SET_DOSCUSSID', n)
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