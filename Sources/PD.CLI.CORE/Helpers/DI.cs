﻿using System;
using PD.Api;
using PD.CLI.CORE.Api;
using PD.CLI.CORE.Helpers;
using PD.CLI.CORE.Server;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace PD.CLI.CORE.Core {

    public static class Di {

        private static Container _container;

        static Di() { }

        public static void Initialize() {
            _container = new Container { Options = { DefaultScopedLifestyle = new WebApiRequestLifestyle() } };
            RegisterTypes();
            _container.RegisterWebApiControllers(GlobalConfiguration.HttpConfiguration);
            _container.Verify();
            GlobalConfiguration.HttpConfiguration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);
        }

        private static void RegisterTypes() {
            //shared
            _container.Register<IInternalDemonizedProcess, InternalDemonizedProcess>( Lifestyle.Transient );
            _container.Register<ISettingsFactory, SettingsFactory>( Lifestyle.Singleton );
            _container.Register<IDataStorageFactory, HomeDataStorageFactory>( Lifestyle.Singleton );
            _container.Register<IProcessManager, ProcessManager>( Lifestyle.Singleton );
            _container.Register<ILogManager, LogManager>( Lifestyle.Singleton );
            _container.Register<ISettingsManager, SettingsManager>( Lifestyle.Singleton );
            //admin
            _container.Register<ILogMethods, LogMethods>( Lifestyle.Singleton );
            _container.Register<ISettingsMethods, SettingsMethods>( Lifestyle.Singleton );
            _container.Register<IAdminProcessMethods, AdminProcessMethods>( Lifestyle.Singleton );
            _container.Register<IAdminApi, AdminApi>( Lifestyle.Singleton );
            //client
            _container.Register<IClientProcessMethods, ClientProcessMethods>( Lifestyle.Singleton );
            _container.Register<IClientApi, ClientApi>( Lifestyle.Singleton );
        }

        public static T Get<T>() where T : class => _container.GetInstance<T>();

        public static object Get( Type type ) => _container.GetInstance( type );

    }

}