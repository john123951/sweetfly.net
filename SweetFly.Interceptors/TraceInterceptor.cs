using System;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace SweetFly.Interceptors
{
    /// <summary>
    /// 调试用拦截器
    /// </summary>
    public class TraceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var methodInfo = string.Format(" ---- Target:[{0}] (Method:[{1}]) ---- {2}",
                                            invocation.TargetType.FullName,
                                            invocation.Method.Name,
                                            DateTime.Now);
            var argumentsInfo = string.Join(",", invocation.Arguments);

            Trace.WriteLine(methodInfo);
            Trace.WriteLine(argumentsInfo);
            invocation.Proceed();
            Trace.WriteLine(methodInfo + "ReturnValue=" + invocation.ReturnValue);
        }
    }
}
