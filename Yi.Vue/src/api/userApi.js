import myaxios from '@/util/myaxios'
export default {
    SetRoleByUser(userIds, roleIds) {
        return myaxios({
            url: '/User/SetRoleByUser',
            method: 'post',
            data: { "ids1": userIds, "ids2": roleIds }
        })
    },

    GetRolesByUser() {
        return myaxios({
            url: '/User/GetRolesByUser',
            method: 'get'
        })
    },
    GetRolesByUserId(userId) {
        return myaxios({
            url: `/User/GetRolesByUserId?userId=${userId}`,
            method: 'get'
        })
    },
    GetUserInfoById() {
        return myaxios({
            url: `/User/GetUserInfoById`,
            method: 'get'
        })
    }
}