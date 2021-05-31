using MorningCoffee.Core.CrossCuttingConcerns.Autofac.Caching;
using MorningCoffee.Core.Utilities.Interceptors;
using MorningCoffee.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace MorningCoffee.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        ICacheManager _cacheManager;
        string _pattern;
        public CacheRemoveAspect(string pattern)
        {
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            _pattern = pattern;
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
