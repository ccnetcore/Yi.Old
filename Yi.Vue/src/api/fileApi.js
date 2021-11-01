import myaxios from '@/util/myaxios'
export default {
    Upload(file) {
        return myaxios({
            url: '/File/Upload',
            method: 'post',
            headers: { "Content-Type": "multipart/form-data" },
            data: file
        })
    }
}