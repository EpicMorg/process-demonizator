namespace PD.Api.DataTypes {

    public interface ISettings {

        int RestartLimit { get; set; }
        string LogPath { get; set; }

    }

    public class Settings : ISettings {

        public virtual int RestartLimit { get; set; }
        public virtual string LogPath { get; set; }

    }

    partial class SettingsPassword : Settings {

        public virtual string Password { get; set; }

    }

}