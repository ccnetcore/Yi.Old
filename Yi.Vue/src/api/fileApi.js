import myaxios from '@/util/myaxios'
export default {
    EditIcon(file) {
        return myaxios({
            url: '/File/EditIcon',
            method: 'post',
            headers: { "Content-Type": "multipart/form-data" },
            data: file
        })
    }
}