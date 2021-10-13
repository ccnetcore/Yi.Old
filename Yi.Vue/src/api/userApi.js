import myaxios from '@/util/myaxios'
export default {
    getAllUser() {
        return myaxios({
            url: '/User/getAllUser',
            method: 'get'
        })
    },
    getUserByUserId(userId) {
        if (userId == undefined) {
            userId = 0;
        }
        return myaxios({
            url: `/User/getUserByUserId?userId=${userId}`,
            method: 'get'
        })
    },

    addUser(user) {
        return myaxios({
            url: '/User/addUser',
            method: 'post',
            data: user
        })
    },
    delUser(userId) {
        return myaxios({
            url: `/User/delUser?userId=${userId}`,
            method: 'get'
        })
    },
    updateUser(user) {
        return myaxios({
            url: '/User/updateUser',
            method: 'post',
            data: user
        })
    },
    tryUpdateUser(form) {
        return myaxios({
            url: '/User/tryUpdateUser',
            method: 'post',
            data: form
        })
    },

    delUserList(Ids) {
        return myaxios({
            url: '/User/delAllUser',
            method: 'post',
            data: Ids
        })
    },
    setRole(Id, Ids) {
        return myaxios({
            url: '/User/setRole',
            method: 'post',
            data: { "Id": Id, "Ids": Ids }
        })
    },

    setRoleList(userIds, roleIds) {
        return myaxios({
            url: '/User/setRoleList',
            method: 'post',
            data: { "userIds": userIds, "roleIds": roleIds }
        })
    },
    getRoleByuserId(userId) {
        if (userId == undefined) {
            userId = 0;
        }
        return myaxios({
            url: `/User/getRoleByuserId?userId=${userId}`,
            method: 'get'
        })
    },
    getSpecialAction(userId) {
        return myaxios({
            url: `/User/getSpecialAction?userId=${userId}`,
            method: 'get'
        })
    },
    setSpecialAction(Id, Ids) {
        return myaxios({
            url: '/User/setSpecialAction',
            method: 'post',
            data: { "Id": Id, "Ids": Ids }
        })
    },
    getActionByUserId(userId) {
        if (userId == undefined) {
            userId = 0;
        }
        return myaxios({
            url: `/User/getActionByUserId?userId=${userId}`,
            method: 'get'
        })
    }

}