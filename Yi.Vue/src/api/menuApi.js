import myaxios from '@/util/myaxios'
export default {
    getMenu() {
        return myaxios({
            url: '/Menu/GetMenu',
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
    addMenu(data) {
        return myaxios({
            url: '/Menu/addMenu',
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
    geTopMenuByUser() {
        return myaxios({
            url: '/Menu/geTopMenuByUser',
            method: 'get'
        })
    }
}