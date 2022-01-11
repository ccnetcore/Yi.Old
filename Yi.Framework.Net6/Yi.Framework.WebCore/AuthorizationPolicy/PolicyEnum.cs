using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.AuthorizationPolicy
{
    public enum PolicyEnum
    {
        /// <summary>
        /// 菜单
        /// </summary>
        MenuPermissions,
        //...还可以定义其他的各种权限策略名称
    }
    public static class PolicyName
    {
        public const  string Menu = "Menu";
    }
}
