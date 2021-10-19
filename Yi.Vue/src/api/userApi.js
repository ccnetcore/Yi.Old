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
    }
}