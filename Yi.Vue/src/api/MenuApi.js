import myaxios from '@/util/myaxios'
export default {
    getMenu() {
        return myaxios({
            url: '/Menu/GetMenu',
            method: 'get'
        })
    },
}