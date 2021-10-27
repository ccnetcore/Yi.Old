import myaxios from '@/util/myaxios'
export default {
    SetRoleByUser(userIds, roleIds) {
        return myaxios({
            url: '/User/SetRoleByUser',
            method: 'post',
            data: { "ids1": userIds, "ids2": roleIds }
        })
    },

    GetRolesByHttpUser() {
        return myaxios({
            url: '/User/GetRolesByHttpUser',
            method: 'get'
        })
    },
    GetRolesByUserId(userId) {
        return myaxios({
            url: `/User/GetRolesByUserId?userId=${userId}`,
            method: 'get'
        })
    },
    GetUserInRolesByHttpUser() {
        return myaxios({
            url: `/User/GetUserInRolesByHttpUser`,
            method: 'get'
        })
    },
    GetMenuByHttpUser() {
        return myaxios({
            url: `/User/GetMenuByHttpUser`,
            method: 'get'
        })
    },
    GetAxiosByRouter(router) {
        return myaxios({
            url: `/User/GetRouterByUserId?router=${router}`,
            method: 'get'
        })
    }
}