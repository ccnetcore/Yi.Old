using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.Core.SMS
{
   public class AliyunSMSInvoker
    {
        private IOptionsMonitor<SMSOptions> _sMSOptions;
        public AliyunSMSInvoker(IOptionsMonitor<SMSOptions> sMSOptions)
        {
            _sMSOptions = sMSOptions;
        }
        private static AlibabaCloud.SDK.Dysmsapi20170525.Client CreateClient(string accessKeyId, string accessKeySecret)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                // 您的AccessKey ID
                AccessKeyId = accessKeyId,
                // 您的AccessKey Secret
                AccessKeySecret = accessKeySecret,
            };
            // 访问的域名
            config.Endpoint = "dysmsapi.aliyuncs.com";
            return new AlibabaCloud.SDK.Dysmsapi20170525.Client(config);
        }

        public  void SendCode(string code,string phone)
        {
            AlibabaCloud.SDK.Dysmsapi20170525.Client client = CreateClient(_sMSOptions.CurrentValue.ID, _sMSOptions.CurrentValue.Secret);
            AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest sendSmsRequest = new AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest
            {
                PhoneNumbers = phone,
                SignName = _sMSOptions.CurrentValue.Sign,
                TemplateCode = _sMSOptions.CurrentValue.Template,
                TemplateParam = "{\"code\":\""+ code + "\"}",
            };
            // 复制代码运行请自行打印 API 的返回值
            client.SendSms(sendSmsRequest);
        }
    }
}
