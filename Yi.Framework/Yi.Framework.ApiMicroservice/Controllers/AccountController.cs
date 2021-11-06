using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Helper;
using Yi.Framework.Common.Models;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.WebCore;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private IUserService _userService;
        private IMenuService _menuService;
        private RabbitMQInvoker _rabbitMQInvoker;
        private CacheClientDB _cacheClientDB;
        private IRoleService _roleService;
        public AccountController(ILogger<UserController> logger, IUserService userService, IMenuService menuService,RabbitMQInvoker rabbitMQInvoker,CacheClientDB cacheClientDB, IRoleService roleService)
        {
            _logger = logger;
            _userService = userService;
            _menuService = menuService;
            _rabbitMQInvoker = rabbitMQInvoker;
            _cacheClientDB = cacheClientDB;
            _roleService = roleService;
        }


        /// <summary>
        /// 登录方法，要返回data:{user,token} token
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> Login(user _user)
        {
            var user_data = await _userService.Login(_user);
            if (user_data == null)
            {
                return Result.Error("该用户不存在");
            }
            var menuList = await _menuService.GetTopMenuByUserId(user_data.id);
            if ( user_data!=null)
            {               
                var token = MakeJwt.app(new jwtUser() {user=user_data,menuIds= menuList});

                JobModel.visitNum += 1;
                return Result.Success().SetData(new { user = new { user_data.id, user_data.username, user_data.introduction, user_data.icon, user_data.nick }, token });
            }
            return Result.Error();
        }

        /// <summary>
        /// 不用写，单纯制作日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Result Logout()
        {
            return Result.Success();
        }

        /// <summary>
        /// code为验证码,从redis中判断一下code是否正确
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> Register(user _user, string code)
        {
            _user.username=_user.username.Trim();
            if(string.IsNullOrEmpty(_user.username))
            code = code.Trim();

             string trueCode=  _cacheClientDB.Get<string>(RedisConst.keyCode + _user.phone);
            if (code == trueCode)
            {
                //设置默认头像
                var setting = JsonHelper.StrToObj<SettingDto>(_cacheClientDB.Get<string>(RedisConst.key));
                _user.icon = setting.InitIcon;
                //设置默认角色
                if (string.IsNullOrEmpty(setting.InitRole))
                {
                    return Result.Error("无默认角色，请初始化数据库");
                }
                _user.roles = new List<role>();
                _user.roles.Add(await _roleService.GetEntity(u => u.role_name == setting.InitRole));
                await _userService.Register(_user);

                return Result.Success("恭喜，你已加入我们！");
            }
            return Result.Error("验证码有误，请重新输入！");
        }


        /// <summary>
        /// 发送短信，需要将生成的sms+code存入redis
        /// </summary>
        /// <param name="SMSAddress"></param>
        /// <returns></returns>
        [HttpPost]
        public async  Task<Result> SendSMS(string SMSAddress)
        {
            SMSAddress = SMSAddress.Trim();
            if (!await _userService.PhoneIsExsit(SMSAddress))
            {
                SMSQueueModel sMSQueueModel = new SMSQueueModel();
                sMSQueueModel.phone = SMSAddress;
                sMSQueueModel.code =RandomHelper.GenerateCheckCodeNum(6);

                //10分钟过期
                _cacheClientDB.Set(RedisConst.keyCode+sMSQueueModel.phone, sMSQueueModel.code, TimeSpan.FromMinutes(10));

                _rabbitMQInvoker.Send(new Common.IOCOptions.RabbitMQConsumerModel() { ExchangeName = RabbitConst.SMS_Exchange, QueueName = RabbitConst.SMS_Queue_Send }, JsonHelper.ObjToStr(sMSQueueModel));
                return Result.Success("发送短信成功，10分钟后过期，请留意短信接收");
            }
                return Result.Error("该号码已被注册");
        }

        /// <summary>
        /// 发送邮箱，需要先到数据库判断该邮箱是否被人注册过，到userservice写mail_exist方法，还有接口别忘了。
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpPost]//邮箱验证
        public async Task<Result> Email(string emailAddress)
        {
            emailAddress = emailAddress.Trim().ToLower();
            //先判断邮箱是否被注册使用过，如果被使用过，便不让操作
            if (!await _userService.EmailIsExsit(emailAddress))
            {
                string code = RandomHelper.GenerateRandomLetter(6);
                code = code.ToUpper();//全部转为大写
                EmailHelper.sendMail(code, emailAddress);

                //我要把邮箱和对应的code加进到数据库，还有申请时间
                //设置10分钟过期
                //set不存在便添加，如果存在便替换
                //CacheHelper.SetCache<string>(emailAddress, code, TimeSpan.FromSeconds(10));

                return Result.Success("发送邮件成功，请查看邮箱（可能在垃圾箱）");
            }
            else
            {
                return Result.Error("该邮箱已被注册");
            }
            //  邮箱和验证码都要被记住，然后注册时候比对邮箱和验证码是不是都和现在生成的一样
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwdDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<Result> ChangePassword(ChangePwdDto pwdDto)
        {          
            var user_data = await _userService.GetUserById(pwdDto.user.id);
            string msg = "修改成功";
            if (! string.IsNullOrEmpty( pwdDto.newPassword))
            {               
                if (user_data.password == pwdDto.user.password)
                {

                    user_data.password = pwdDto.newPassword;
                    user_data.phone = pwdDto.user.phone;
                    user_data.introduction = pwdDto.user.introduction;
                    user_data.email = pwdDto.user.email;
                    user_data.age = pwdDto.user.age;
                    user_data.address = pwdDto.user.address;
                    user_data.nick = pwdDto.user.nick;

                    
                    await _userService.UpdateAsync(user_data);
                    user_data.password = null;
                    return Result.Success(msg);
                }
                else
                {
                    msg = "密码错误";
                    return Result.Error(msg);
                }
            }

            user_data.phone = pwdDto.user.phone;
            user_data.introduction = pwdDto.user.introduction;
            user_data.email = pwdDto.user.email;
            user_data.age = pwdDto.user.age;
            user_data.address = pwdDto.user.address;
            user_data.nick = pwdDto.user.nick;

            await _userService.UpdateAsync(user_data);


            return Result.Success(msg);
        }
     
    }
}