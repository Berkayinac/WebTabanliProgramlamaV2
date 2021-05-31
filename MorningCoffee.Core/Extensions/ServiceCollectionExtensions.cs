using Microsoft.Extensions.DependencyInjection;
using MorningCoffee.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
