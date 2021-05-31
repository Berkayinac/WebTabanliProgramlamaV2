using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MorningCoffee.Core.CrossCuttingConcerns.Autofac.Caching;
using MorningCoffee.Core.CrossCuttingConcerns.Autofac.Caching.Microsoft;
using MorningCoffee.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MorningCoffee.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
