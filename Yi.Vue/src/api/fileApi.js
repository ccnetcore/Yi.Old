import myaxios from '@/util/myaxios'
export default {
    OnPostUploadImage(file) {
        return myaxios({
            url: '/File/OnPostUploadImage',
            method: 'post',
            data: file
        })
    },
    getLogs() {
        return myaxios({
            url: '/File/GetLogs',
            method: 'get'
        })
    }
}