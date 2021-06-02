using Autofac;
using Autofac.Extras.DynamicProxy;
using CC.Yi.BLL;
using CC.Yi.Common.Castle;
using CC.Yi.DAL;
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using System;


namespace CC.Yi.API
{
    public partial class Startup
    {
        //动态 面向AOP思想的依赖注入 Autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CustomAutofacAop));
            builder.RegisterGeneric(typeof(BaseDal<>)).As(typeof(IBaseDal<>));
            builder.RegisterType<studentBll>().As<IstudentBll>().EnableInterfaceInterceptors();//表示注入前后要执行Castle，AOP
        }
    }
}