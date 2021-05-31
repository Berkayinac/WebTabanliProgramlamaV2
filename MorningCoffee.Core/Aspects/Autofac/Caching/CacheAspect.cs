using Castle.DynamicProxy;
using MorningCoffee.Core.CrossCuttingConcerns.Autofac.Caching;
using MorningCoffee.Core.Utilities.Interceptors;
using MorningCoffee.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MorningCoffee.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {

        int _duration;
        ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            _duration = duration;
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.isAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
