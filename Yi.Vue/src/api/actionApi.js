import myaxios from '@/util/myaxios'
export default {
    getActions() {
        return myaxios({
            url: '/Action/getActions',
            method: 'get'
        })
    },
    addAction(action) {
        return myaxios({
            url: '/action/addAction',
            method: 'post',
            data: action
        })
    },
    updateAction(action) {
        return myaxios({
            url: '/action/UpdateAction',
            method: 'post',
            data: action
        })
    },
    delActionList(Ids) {
        return myaxios({
            url: '/action/DelAllAction',
            method: 'post',
            data: Ids
        })
    },
}