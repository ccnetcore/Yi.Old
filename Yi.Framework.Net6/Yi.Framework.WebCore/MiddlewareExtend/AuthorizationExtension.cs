using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.WebCore.AuthorizationPolicy;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyName.Menu, polic =>
                {
                    polic.AddRequirements(new CustomAuthorizationRequirement(PolicyEnum.MenuPermissions));
                });
            });

            services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();
            return services;
        }
    }
}
