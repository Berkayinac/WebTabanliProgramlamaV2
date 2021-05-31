using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MorningCoffee.Business.Abstract;
using MorningCoffee.Business.Concrete;
using MorningCoffee.Core.Utilities.Interceptors;
using MorningCoffee.Core.Utilities.Security.JWT;
using MorningCoffee.DataAccess.Abstract;
using MorningCoffee.DataAccess.Concrete.EntityFramework;
using MorningCoffee.DataAccess.Concrete.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCoffeeDal>().As<ICoffeeDal>().SingleInstance();
            builder.RegisterType<CoffeeManager>().As<ICoffeeService>().SingleInstance();

            builder.RegisterType<EfFrappuccinoDal>().As<IFrappuccinoDal>().SingleInstance();
            builder.RegisterType<FrappuccinoManager>().As<IFrappuccinoService>().SingleInstance();

            builder.RegisterType<EfTeaDal>().As<ITeaDal>().SingleInstance();
            builder.RegisterType<TeaManager>().As<ITeaService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
