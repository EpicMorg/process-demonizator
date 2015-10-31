using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using PD.CLI.CORE.Core;
using PD.CLI.CORE.Server;

namespace PD.CLI.CORE {

    internal class Program {

        private static void Main(string[] args)
        {
            Di.Initialize();
            var prog = new Program(Di.Get<ILogManager>(), new FileConfiguration() { Url = "http://192.168.0.106:31337" });
            prog.Start();
        }

        private readonly ILogManager _log;
        private readonly FileConfiguration _config;

        public Program( ILogManager log, FileConfiguration config ) {
            _log = log;
            _config = config;
        }

        private void Start() {
            var ts = new CancellationTokenSource();

            var server = StartWobServer(ts.Token);
            var pm = StartProcesses();
            Task.WhenAll( pm, server ).Wait(ts.Token);
        }

        private async Task StartProcesses() {
            _log.Log( $"Starting processes & stuff" );
            var pm = Di.Get<IProcessManager>();
            var procs = await pm.ListFull().ConfigureAwait( false );
            foreach ( var proc in procs )
                await proc.Start().ConfigureAwait( false );
        }

        //xkcd:148
        private async Task StartWobServer( CancellationToken token ) {
            _log.Log( "Web server is starting up..." );
            using ( WebApp.Start<Startup>( _config.Url ) ) {
                Di.Get<ILogManager>().Log( $"Listening on {_config.Url}" );
                await Task.Delay( Timeout.InfiniteTimeSpan, token ).ConfigureAwait( false );
            }

        }

    }

}