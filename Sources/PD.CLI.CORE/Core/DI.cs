using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD.Api;
using PD.Api.DataTypes;
using PD.CLI.CORE.Api;
using SimpleInjector;

namespace PD.CLI.CORE.Core {

    public class Di {

        private static readonly Di _instance = new Di();
        private readonly Container _container;

        private Di() {
            _container = new Container();
            RegisterTypes();
        }

        private void Register<TSource, TResult>() where TSource : class where TResult : class, TSource { _container.Register<TSource, TResult>( Lifestyle.Transient ); }

        private void RegisterTypes() {
            //Register<>();
            Register<IDataStorage<IInternalSettings>, DataStorage<IInternalSettings>>();
            Register<ISettingsFactory, SettingsFactory>();

            Register<IDataStorage<IInternalDemonizedProcess>, DataStorage<IInternalDemonizedProcess>>();
            Register<IProcessManager, ProcessManager>();

            Register<ILogManager, LogManager>();

            Register<ILogMethods, LogMethods>();

            Register<ISettingsManager, SettingsManager>();

            Register<ISettingsMethods, SettingsMethods>();

            Register<IAdminProcessMethods, AdminProcessMethods>();
            Register<IAdminApi, AdminApi>();

            //settings -> factory

            //Register<IInternalSettings, InternalSettings>();
            //Register<ISettings, InternalSettings>();
            //Register<ISettingsPassword, InternalSettings>();
        }

        public static Di Instance => _instance;

        public T Get<T>() where T : class => _container.GetInstance<T>();

    }

}