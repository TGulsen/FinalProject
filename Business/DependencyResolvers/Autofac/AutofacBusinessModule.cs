using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        //Business ile ilgili olanlar burada yer alacak. Startup.cs deki otomatik newleme işlemini burada yaparız.

        protected override void Load(ContainerBuilder builder)
        {
            //services.AddSingleton<IProductService,ProductManager>();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            //Tek bir instance oluşturarak, tüm isteklere aynı referansla yanıt verir.Üstlerinle yazılanlarla aynı anlama sahipler.

            //services.AddSingleton<IProductDal, EfProductdal>();
            builder.RegisterType<EfProductdal>().As<IProductDal>().SingleInstance();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
