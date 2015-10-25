using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PD.Api.DataTypes;
using static PD.Api.Client.MethodsHelper;

namespace PD.Api.Client {

    public class ClientProcessMethods : IClientProcessMethods {

        private readonly ClientApi _api;
        private readonly HttpClient _client;

        internal ClientProcessMethods( ClientApi api ) {
            _api = api;
            _client = CreateClient( api.Server, "Client/Process/" );
        }

        private async Task<T> Get<T>( string requestUri ) {
            var resp = await _client.GetAsync( requestUri ).ConfigureAwait( false );
            ThrowOnNonSuccess( resp );
            var ret = await resp.Content.ReadAsStringAsync().ConfigureAwait( false );
            var obj = JsonConvert.DeserializeObject<T>( ret );
            return obj;
        }

        public async Task<IEnumerable<IDemonizedProcessBase>> List() => await Get<DemonizedProcessBase[]>( "" ).ConfigureAwait( false );

        public async Task<IRunningDemonizedProcess> Get( int id, string key ) => await Get<RunningDemonizedProcess>( $"{id}?key={key}" ).ConfigureAwait( true );

        public async Task Start( int id, string key ) => await _client.PostClientKey( id, key, "Start" ).ConfigureAwait( false );

        public async Task Stop( int id, string key ) => await _client.PostClientKey( id, key, "Stop" ).ConfigureAwait( false );

        public async Task Restart( int id, string key ) => await _client.PostClientKey( id, key, "Restart" ).ConfigureAwait( false );

        public async Task<bool> CheckPassword( int id, string key ) => bool.Parse( await _client.PostClientKey( id, key, "CheckPassword" ).ConfigureAwait( false ) );

    }

}