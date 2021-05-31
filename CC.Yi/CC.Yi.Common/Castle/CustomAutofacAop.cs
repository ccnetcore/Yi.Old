using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.Castle
{
    public class CustomAutofacAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            { 
            
            //这里写执行方法前
            }
            invocation.Proceed();//执行具体的实例
            { 
            
            //这里写执行方法后
            }
        }
    }
}
