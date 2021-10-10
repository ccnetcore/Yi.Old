import myaxios from '@/utils/myaxios'
export default {
    getItem(url) {
        return myaxios({
            url: url,
            method: 'get'
        })
    },
    addItem(url, data) {
        return myaxios({
            url: url,
            method: 'post',
            data: data
        })
    },
    updateItem(url, data) {
        return myaxios({
            url: url,
            method: 'cut',
            data: data
        })
    },
    delItemList(url, Ids) {
        return myaxios({
            url: url,
            method: 'del',
            data: Ids
        })
    },
}