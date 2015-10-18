using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using PD.Api.DataTypes;
using PD.CLI.CORE.Core;

namespace PD.CLI.CORE.Api {

    public interface IInternalDemonizedProcess : IRunningDemonizedProcess, IPasswordedDemonizedProcess {

        int? ProcessId { get; }

        Task Start();

        Task Stop();

        Task Restart();

        Task Hide();

        Task Show();

    }

    public class InternalDemonizedProcess : RunningDemonizedProcess, IInternalDemonizedProcess {

        private readonly SemaphoreSlim _event = new SemaphoreSlim(0,1);

        private readonly object statusLocker = new object();

        private ISettings _settings;

        private Process process;

        public InternalDemonizedProcess( ISettingsFactory settings ) { _settings = settings.Get(); }

        public string Key { get; set; }

        public int? ProcessId => process?.Id;

        public async Task Start() {
            if ( Status != Status.NotRunning ) return;
            lock ( statusLocker ) {
                if ( Status != Status.NotRunning ) return;
                Status = Status.Starting;
            }
            StartInternal();
            lock ( statusLocker ) Status = Status.Running;
        }

        public async Task Stop() {
            if ( Status != Status.Running ) return;
            lock ( statusLocker ) {
                if ( Status != Status.Running ) return;
                Status = Status.Stopping;
            }
            await StopInternal().ConfigureAwait( false );
            lock ( statusLocker ) Status = Status.NotRunning;
        }

        public async Task Restart() {
            if ( Status != Status.Running ) return;
            lock ( statusLocker ) {
                if ( Status != Status.Running ) return;
                Status = Status.Restarting;
            }
            await StopInternal().ConfigureAwait( false );
            await StartInternal().ConfigureAwait( false );
            lock ( statusLocker ) Status = Status.Running;
        }

        public async Task Hide() {
            //win32 api call here
        }

        public async Task Show() {
            //win32 api call here
        }

        private async Task StopInternal() { }

        private async Task StartInternal() {
            for ( int i = 0; i < _settings.RestartLimit; i++ ) {
                var process = new Process() {
                    StartInfo = {
                        Arguments = Arguments,
                        FileName = Path,
                        CreateNoWindow = HideOnStart,
                        WindowStyle = HideOnStart ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal,
                        UseShellExecute = false,
                    }
                };
                try {
                    process.Exited += (a, b) => _event.Release();
                    await _event.WaitAsync().ConfigureAwait( false );
                    process.Start();
                }
                catch(Exception ex) {
                    _event.Release();//
                }
                if ( !Autorestart ) {
                    break;
                }

            }
        }

    }

}