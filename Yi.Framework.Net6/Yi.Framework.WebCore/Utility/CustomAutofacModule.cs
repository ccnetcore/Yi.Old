using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Yi.Framework.Job;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.WebCore.Utility;
using Module = Autofac.Module;

namespace Yi.Framework.WebCore.Utility
{
    public class CustomAutofacModule : Module
    {
        private Assembly GetDll(string ass)
        {
            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, ass);
            if (!(File.Exists(servicesDllFile)))
            {
                var msg = "service.dll 丢失，请编译后重新生成。";
                throw new Exception(msg);
            }
            return   Assembly.LoadFrom(servicesDllFile); ;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerDependency().EnableInterfaceInterceptors();

            containerBuilder.RegisterType< HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();



            ///反射注入服务层及接口层     
            var assemblysServices = GetDll( "Yi.Framework.Service.dll");
            containerBuilder.RegisterAssemblyTypes(assemblysServices)
                     .AsImplementedInterfaces()
                     .InstancePerDependency()
                     .EnableInterfaceInterceptors();

///反射注册任务调度层
            var assemblysJob = GetDll("Yi.Framework.Job.dll");
            containerBuilder.RegisterAssemblyTypes(assemblysJob)
                     .InstancePerDependency();



            containerBuilder.Register(c => new CustomAutofacAop());//AOP注册


            //containerBuilder.RegisterType<A>().As<IA>().EnableInterfaceInterceptors();开启Aop

            //将数据库对象注入
            //containerBuilder.RegisterType<DataContext>().As<DbContext>().InstancePerLifetimeScope().EnableInterfaceInterceptors();

            //containerBuilder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerDependency().EnableInterfaceInterceptors();



        }

    }
}


public interface IAutofacTest
{
    void Show(int id, string name);
}

[Intercept(typeof(CustomAutofacAop))]
public class AutofacTest : IAutofacTest
{
    public void Show(int id, string name)
    {
        Console.WriteLine($"This is {id} _ {name}");
    }
}
