import myaxios from '@/util/myaxios'
export default {
    getRoles() {
        return myaxios({
            url: '/Role/getRoles',
            method: 'get'
        })
    },
    AddRole(role) {
        return myaxios({
            url: '/Role/AddRole',
            method: 'post',
            data: role
        })
    },
    delRole(roleId) {
        return myaxios({
            url: `/Role/DelRole?roleId=${roleId}`,
            method: 'get'
        })
    },
    updateRole(role) {
        return myaxios({
            url: '/role/updateRole',
            method: 'post',
            data: role
        })
    },
    delRoleList(Ids) {
        return myaxios({
            url: '/role/delAllRole',
            method: 'post',
            data: Ids
        })
    },
    setAction(Id, Ids) {
        return myaxios({
            url: '/role/setAction',
            method: 'post',
            data: { "Id": Id, "Ids": Ids }
        })
    },
    GetActionByRoleId(roleId) {
        return myaxios({
            url: `/role/GetActionByRoleId?roleId=${roleId}`,
            method: 'get'
        })
    }

}