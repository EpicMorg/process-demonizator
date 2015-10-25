namespace PD.Api.Client.Admin {

    public class AdminApi : IAdminApi {

        internal readonly string _server;

        public AdminApi( string server ) {
            _server = server;
            Process = new AdminProcessMethods(this);
            Settings = new SettingsMethods(this);
            Log = new LogMethods(this);
        }

        public IAdminProcessMethods Process { get; }
        public ISettingsMethods Settings { get; }
        public ILogMethods Log { get; }
    }

}