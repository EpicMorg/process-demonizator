using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PD.Api.DataTypes;

namespace PD.CLI.CORE.Api {

    public interface IInternalDemonizedProcess : IRunningDemonizedProcess, IPasswordedDemonizedProcess {

        int ProcessId { get; }

        Task Start();

        Task Stop();

        Task Restart();

        Task Hide();

        Task Show();

    }

    public class InternalDemonizedProcess : RunningDemonizedProcess, IInternalDemonizedProcess {

        private ISettings _settings;

        private Process process;


        public InternalDemonizedProcess( ISettings settings ) { _settings = settings; }


        public string Key { get; set; }

        public int ProcessId { get; }

        public async Task Start() => await StartInternal().ConfigureAwait(false);

        public async Task Stop() => await StopInternal().ConfigureAwait( false );

        public async Task Restart() {
            await StopInternal().ConfigureAwait(false);
            await StartInternal().ConfigureAwait(false);
        }

        public async Task Hide() {

            //win32 api call here
        }

        public async Task Show() {
            //win32 api call here
        }


        private async Task StopInternal() { throw new System.NotImplementedException(); }
        private async Task StartInternal() { throw new System.NotImplementedException(); }
    }


}