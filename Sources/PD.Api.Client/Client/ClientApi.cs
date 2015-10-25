namespace PD.Api.Client
{
    public class ClientApi : IClientApi
    {

        internal readonly string _server;

        public ClientApi( string server ) {
            _server = server;
            Process = new ClientProcessMethods( this );
        }

        public IClientProcessMethods Process { get; }

    }

}
