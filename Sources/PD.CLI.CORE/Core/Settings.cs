using PD.Api.DataTypes;

namespace PD.CLI.CORE.Core {

    public interface ISettingsManager {

        ISettingsPassword Settings { get; set; }

    }

    public class SettingsManager : ISettingsManager {

        public ISettingsPassword Settings { get; set; }

    }

    public interface IInternalSettings : ISettingsPassword {

        string ConfigPath { get; }

    }

    public class InternalSettings : SettingsPassword, IInternalSettings {

        public string ConfigPath { get; }

    }

    public interface ISettingsFactory : IFactory<IInternalSettings> {

    }

    public class SettingsFactory : ISettingsFactory {

        private IDataStorage<IInternalSettings> _dataStorage;

        public SettingsFactory( IDataStorage<IInternalSettings> dataStorage ) { _dataStorage = dataStorage; }

        public IInternalSettings Get() => _dataStorage.Load( "settings.xml" );

    }

}