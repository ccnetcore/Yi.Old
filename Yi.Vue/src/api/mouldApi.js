import myaxios from '@/util/myaxios'
export default {
    getMould() {
        return myaxios({
            url: '/Mould/GetMould',
            method: 'get'
        })
    }

}