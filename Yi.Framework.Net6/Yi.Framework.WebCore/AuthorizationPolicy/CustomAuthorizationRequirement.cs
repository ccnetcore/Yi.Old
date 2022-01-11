using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.AuthorizationPolicy
{
    //定义策略参数，必须实现这个IAuthorizationRequirement接口
    public class CustomAuthorizationRequirement: IAuthorizationRequirement
    { 
        public CustomAuthorizationRequirement(PolicyEnum policyname)
        {
            this.PolicyName = policyname;
        } 
        public PolicyEnum PolicyName { get; set; }
         
    }
}
