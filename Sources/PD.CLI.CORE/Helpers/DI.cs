using PD.Api;
using PD.CLI.CORE.Api;
using SimpleInjector;

namespace PD.CLI.CORE.Core {

    public class Di {

        private readonly Container _container;

        private Di() {
            _container = new Container();
            RegisterTypes();
        }

        private void RegisterTypes() {
            //shared
            _container.Register<ISettingsFactory, SettingsFactory>( Lifestyle.Singleton );
            _container.Register<IDataStorageFactory, HomeDataStorageFactory>( Lifestyle.Singleton);
            _container.Register<IProcessManager, ProcessManager>( Lifestyle.Singleton );
            _container.Register<ILogManager, LogManager>( Lifestyle.Singleton );
            _container.Register<ISettingsManager, SettingsManager>( Lifestyle.Singleton);
            //admin
            _container.Register<ILogMethods, LogMethods>(Lifestyle.Singleton);
            _container.Register<ISettingsMethods, SettingsMethods>( Lifestyle.Singleton);
            _container.Register<IAdminProcessMethods, AdminProcessMethods>( Lifestyle.Singleton );
            _container.Register<IAdminApi, AdminApi>( Lifestyle.Singleton );
            //client
            _container.Register<IClientProcessMethods, ClientProcessMethods>(Lifestyle.Singleton);
            _container.Register<IClientApi, ClientApi>(Lifestyle.Singleton);
        }

        public static Di Instance { get; } = new Di();

        public T Get<T>() where T : class => _container.GetInstance<T>();

    }

}