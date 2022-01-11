using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;
using Yi.Framework.Model.Models;

namespace Yi.Framework.WebCore.AuthorizationPolicy
{
    //策略验证的Handler  继承AuthorizationHandler 泛型类   泛型参数为  策略参数
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {

        private CacheClientDB _cacheClientDB;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomAuthorizationHandler(CacheClientDB cacheClientDB)
        {
            _cacheClientDB= cacheClientDB;
        }

        //验证的方法就在这里
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        { 
            var currentClaim = context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Sid);

            if (currentClaim==null) //说明没有写入Sid  没有登录
            {
                return Task.CompletedTask; //验证不同过
            }

            int currentUserId = 0;
            if (!string.IsNullOrWhiteSpace(currentClaim.Value))
            {
                currentUserId = Convert.ToInt32(currentClaim.Value);
            }
            DefaultHttpContext httpcontext = (DefaultHttpContext)context.Resource;
            Dictionary<string, string> dicMenueDictionary = new Dictionary<string, string>();
            //现在只需要登录的时候把用户的api路径添加到redis去
            //每次访问的时候进行redis判断一下即可
            //注意一下，redis不能一直保存，和jwt一样搞一个期限
             var menuList=_cacheClientDB.Get<List<menuDto>>(RedisConst.userMenusApi+":"+currentUserId);
            foreach (var k in menuList)
            {
                if (k.mould != null)
                {
                    dicMenueDictionary.Add(k.mould?.id.ToString(), "/api"+ k.mould?.url);
                }
           
            }

            if (dicMenueDictionary.ContainsValue(httpcontext.Request.Path))
            {
                context.Succeed(requirement); //验证通过了
            }
            return Task.CompletedTask; //验证不同过

        }
    }


    /// <summary>
    /// 菜单权限策略
    /// </summary>
    public static class CustomAuthorizationHandlerExtension
    {
        public static Task AuthorizationMenueExtension(this AuthorizationHandlerContext handlerContext, CustomAuthorizationRequirement requirement)
        {
            bool bog = true;
            if (bog)
            {
                return Task.Run(() =>
                 {
                     handlerContext.Succeed(requirement); //验证通过了
                 });
            }
            else
            {
                return Task.CompletedTask; //验证不同过
            }
        }
    }
}
