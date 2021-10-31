import myaxios from '@/util/myaxios'
export default {
    SetRoleByUser(userIds, roleIds) {
        return myaxios({
            url: '/User/SetRoleByUser',
            method: 'post',
            data: { "ids1": userIds, "ids2": roleIds }
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
            url: `/User/GetAxiosByRouter?router=${router}`,
            method: 'get'
        })
    }
}