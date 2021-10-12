using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Yi.Framework.ApiMicroservice.Utility;
using Yi.Framework.Interface;
using Yi.Framework.Model;
using Yi.Framework.Service;
using Module = Autofac.Module;

namespace Yi.Framework.ApiMicroservice.Utility
{
    public class CustomAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            //var assembly = this.GetType().GetTypeInfo().Assembly;
            //var builder = new ContainerBuilder();
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(assembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //var feature = new ControllerFeature();
            //manager.PopulateFeature(feature);
            //builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            //builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();

            //containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>().InstancePerDependency(); 瞬态
            //containerBuilder.RegisterType<TestServiceB>().As<ITestServiceB>().SingleInstance(); 单例
            //containerBuilder.RegisterType<TestServiceC>().As<ITestServiceC>().InstancePerLifetimeScope(); 作用域

            containerBuilder.Register(c => new CustomAutofacAop());//AOP注册
            //containerBuilder.RegisterType<A>().As<IA>().EnableInterfaceInterceptors();开启Aop

            //将数据库对象注入
            containerBuilder.RegisterType<DataContext>().As<DbContext>().InstancePerLifetimeScope().EnableInterfaceInterceptors();

            containerBuilder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).EnableInterfaceInterceptors();

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
