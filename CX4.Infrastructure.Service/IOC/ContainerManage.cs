/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 15:42:00
 ****** 功能描述    ：ContainerManage
 *******************************************************************************/

using Autofac;
using Autofac.Extras.DynamicProxy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CX4.Infrastructure.Service.IOC
{
    /// <summary>
    ///容器管理
    /// </summary>
    public static class ContainerManage
    {
        private static IContainer _container;

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            if (_container == null)
            {
                throw new ArgumentNullException("请先注册容器服务");
            }
            return _container.Resolve<T>();
        }

        /// <summary>
        ///注册服务
        /// </summary>
        /// <returns></returns>
        public static IContainer Register(ContainerBuilder builder)
        {
            if (_container != null)
            {
                throw new InvalidOperationException("你已注册,请勿重复注册");
            }
            RegisterMediator(builder);
            RegisterAssemblyInjectTypes(builder);
            RegisterMuchAssemblyInterceptTypes(builder);
            _container = builder.Build();
            return _container;
        }

        /// <summary>
        /// 注册默认的中介者
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterMediator(ContainerBuilder builder)
        {
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.RegisterType<Mediator>()
                   .AsImplementedInterfaces()
                   .SingleInstance();
        }

        /// <summary>
        /// 加载当前应用程序的程序集
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Assembly> LoadAllAssembly()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        /// <summary>
        ///注册注入的单例服务
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterAssemblyInjectTypes(ContainerBuilder builder)
        {
            var injectTypeList = LoadAllAssembly().SelectMany(k => k.GetTypes().Where(p => p.GetCustomAttribute(typeof(InjectAttribute)) != null && !p.IsAbstract));
            builder.RegisterTypes(injectTypeList.ToArray())
                   .AsSelf()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .EnableClassInterceptors()
                   .SingleInstance();
        }

        /// <summary>
        ///注册单个单例拦截服务
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterAssemblyInterceptTypes(ContainerBuilder builder)
        {
            var intercepTypeList = LoadAllAssembly().SelectMany(k => k.GetTypes().Where(p => p.GetCustomAttribute(typeof(InterceptAttribute)) != null && !p.IsAbstract));
            foreach (var item in intercepTypeList)
            {
                var attr = (InterceptAttribute)item.GetCustomAttribute(typeof(InterceptAttribute));
                var service = attr.InterceptorService;

                var intercepObjList = LoadAllAssembly().SelectMany(k => k.GetTypes().Where(p => p.FullName == service.Description));
                foreach (var intercepObjTypeItem in intercepObjList)
                {
                    builder.RegisterType(intercepObjTypeItem).SingleInstance();
                }
            }
        }

        /// <summary>
        ///支持注册多个单例拦截服务
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterMuchAssemblyInterceptTypes(ContainerBuilder builder)
        {
            var intercepTypeList = LoadAllAssembly().SelectMany(k => k.GetTypes().Where(p => p.GetCustomAttributes(typeof(InterceptAttribute)).Count() > 0 && !p.IsAbstract));
            foreach (var typeItem in intercepTypeList)
            {
                var interceptAttributeList = (IEnumerable<InterceptAttribute>)typeItem.GetCustomAttributes(typeof(InterceptAttribute));
                foreach (var attrItem in interceptAttributeList)
                {
                    var service = attrItem.InterceptorService;
                    var intercepObjList = LoadAllAssembly().SelectMany(k => k.GetTypes().Where(p => p.FullName == service.Description));
                    foreach (var intercepObjTypeItem in intercepObjList)
                    {
                        builder.RegisterType(intercepObjTypeItem).SingleInstance();
                    }
                }
            }
        }
    }
}
