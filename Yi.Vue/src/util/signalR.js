//引入安装的signalr包
import * as signalR from '@microsoft/signalr'

const signal = new signalR.HubConnectionBuilder()　　　 //服务器地址
    .withUrl([process.env.VUE_APP_BASE_API] + '/chat', {})
    .build()

/* const signalr = function () {
  var hub
  if (hub === undefined) {
    hub = signal
  }
  return hub
} */
//  自动重连
// async function start() {
//     try {
//         await signal.start()
//         console.log('connected')
//     } catch (err) {
//         console.log(err)
//         setTimeout(() => start(), 5000)
//     }
// }

// signal.onclose(async() => {
//         await start()
//     })
//     //将创建的signal赋值给Vue实例
export default {
    install: function(Vue) {
        Vue.prototype.signalr = signal
    }
}