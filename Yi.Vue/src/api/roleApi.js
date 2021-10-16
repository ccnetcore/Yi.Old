import myaxios from '@/util/myaxios'
export default {
    getRole() {
        return myaxios({
            url: '/Role/getRole',
            method: 'get'
        })
    },
    setMenuByRole(roleList, menuList) {
        return myaxios({
            url: '/Role/setMenuByRole',
            method: 'post',
            data: { ids1: roleList, ids2: menuList }
        })
    }
}