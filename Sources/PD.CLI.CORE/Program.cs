using System;
using System.Threading.Tasks;
using PD.Api;
using PD.CLI.CORE.Api;
using PD.CLI.CORE.Core;
using ServiceStack.Text;

namespace PD.CLI.CORE {

    internal class Program {

        private static void Main( string[] args ) {
            MainAsync(args).Wait();
        }

        private static async Task MainAsync( string[] args ) {
            try {
                var api = Di.Instance.Get<IAdminApi>();
                var settings = await api.Settings.GetSettings().ConfigureAwait( false );
                settings.Dump();
                await api.Settings.SetKey( "hitler" ).ConfigureAwait( false );
                settings = await api.Settings.GetSettings().ConfigureAwait( false );
            }
            catch ( Exception e ) {
                Console.WriteLine( e );
            }
            Console.ReadLine();
        }

    }

}