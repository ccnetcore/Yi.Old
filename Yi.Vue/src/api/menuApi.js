import myaxios from '@/util/myaxios'
export default {
    GetMenuInMould() {
        return myaxios({
            url: '/Menu/GetMenuInMould',
            method: 'get'
        })
    },
    addChildrenMenu(id, data) {
        return myaxios({
            url: '/Menu/addChildrenMenu',
            method: 'post',
            data: { parentId: id, data }
        })
    },
    UpdateMenu(data) {
        return myaxios({
            url: '/Menu/UpdateMenu',
            method: 'put',
            data: data
        })
    },
    DelListMenu(ids) {
        return myaxios({
            url: '/Menu/DelListMenu',
            method: 'delete',
            data: ids
        })
    },
    AddTopMenu(data) {
        return myaxios({
            url: '/Menu/AddTopMenu',
            method: 'post',
            data: data
        })
    },
    SetMouldByMenu(menuId, mouldId) {
        return myaxios({
            url: '/Menu/SetMouldByMenu',
            method: 'post',
            data: { id1: menuId, id2: mouldId }
        })
    },
    GetTopMenusByHttpUser() {
        return myaxios({
            url: '/Menu/GetTopMenusByHttpUser',
            method: 'get'
        })
    }
}