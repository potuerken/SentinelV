using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NobetListesiManager>().As<INobetListesiService>().SingleInstance();
            builder.RegisterType<EfNobetListesiDal>().As<INobetListesiDal>().SingleInstance();


            builder.RegisterType<EfNobetListesiDetayDal>().As<INobetListesiDetayDal>().SingleInstance();

            builder.RegisterType<EfOzelGunListesiDal>().As<IOzelGunListesiDal>().SingleInstance();

            builder.RegisterType<EfPersonelNobetDetayDal>().As<IPersonelNobetDetayDal>().SingleInstance();

            builder.RegisterType<IzinMazeretManager>().As<IIzinMazeretService>().SingleInstance();
            builder.RegisterType<EfIzinMazeretDal>().As<IIzinMazeretDal>().SingleInstance();

            builder.RegisterType<NobetSistemManager>().As<INobetSistemService>().SingleInstance();
            builder.RegisterType<EfNobetSistemDal>().As<INobetSistemiDal>().SingleInstance();

            builder.RegisterType<EfNobetSistemSabitNobetciDal>().As<INobetSistemSabitNobetciDal>().SingleInstance();

            builder.RegisterType<EfNobetSistemRutbeIliskiDal>().As<INobetSistemRutbeIliskiDal>().SingleInstance();

            builder.RegisterType<EfNobetSistemSubeIliskiDal>().As<INobetSistemSubeIliskiDal>().SingleInstance();

            builder.RegisterType<UtilitesManager>().As<IUtilitesService>().SingleInstance();
            builder.RegisterType<EfUtilitesDal>().As<IUtilitesDal>().SingleInstance();

            builder.RegisterType<PersonelManager>().As<IPersonelService>().SingleInstance();
            builder.RegisterType<EfPersonelDal>().As<IPersonelDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();            
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
