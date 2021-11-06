import myaxios from '@/util/myaxios'
export default {
    login(username, password) {
        return myaxios({
            url: '/Account/login',
            method: 'post',
            data: {
                username,
                password
            }
        })
    },
    logout() {
        return myaxios({
            url: '/Account/logout',
            method: 'post',
        })
    },
    register(username, password, phone, code) {
        return myaxios({
            url: `/Account/register?code=${code}`,
            method: 'post',
            data: { username, password, phone }
        })
    },
    email(emailAddress) {
        return myaxios({
            url: `/Account/email?emailAddress=${emailAddress}`,
            method: 'post',
        })
    },
    SendSMS(smsAddress) {
        return myaxios({
            url: `/Account/SendSMS?SMSAddress=${smsAddress}`,
            method: 'post',
        })
    },
    changePassword(user, newPassword) {
        return myaxios({
            url: `/Account/changePassword`,
            method: 'put',
            data: { user, newPassword }
        })
    }

}