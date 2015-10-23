using System;
using System.Threading;
using Microsoft.Owin.Hosting;
using PD.CLI.CORE.Core;
using PD.CLI.CORE.Server;

namespace PD.CLI.CORE {

    internal class Program {

        private static void Main( string[] args ) {
            Di.Initialize();
            var config = new FileConfiguration { Url = "http://localhost:31337" };
            Console.WriteLine("Satan server is starting up...");
            using (WebApp.Start<Startup>(config.Url))
            {
                Console.WriteLine($"Listening on {config.Url}");
                Thread.Sleep(Timeout.InfiniteTimeSpan);
            }
            Console.WriteLine("Quitting");
        }

    }

}