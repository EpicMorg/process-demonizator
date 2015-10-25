using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PD.Api.DataTypes;

namespace PD.Api.Client {

    public class ClientProcessMethods : IClientProcessMethods {

        private readonly ClientApi _api;
        private readonly HttpClient _client;

        internal ClientProcessMethods( ClientApi api ) {
            _api = api;
            _client = new HttpClient( new HttpClientHandler() ) { BaseAddress = new Uri( new Uri( _api._server ), "Client/Process/" ) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<IDemonizedProcessBase>> List() {
            var resp = await _client.GetAsync( "" ).ConfigureAwait( false );
            ThrowOnNonSuccess( resp );
            var ret = await resp.Content.ReadAsStringAsync().ConfigureAwait( false );
            var obj = JsonConvert.DeserializeObject<DemonizedProcessBase[]>( ret );
            return obj;
        }

        public async Task<IRunningDemonizedProcess> Get( int id, string key ) {
            var resp = await _client.GetAsync( $"{id}?key={key}").ConfigureAwait(false);
            ThrowOnNonSuccess(resp);
            var ret = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            var obj = JsonConvert.DeserializeObject<RunningDemonizedProcess>( ret );
            return obj;
        }

        public async Task Start( int id, string key ) => await PostKey( id, key, "Start" ).ConfigureAwait( false );

        public async Task Stop( int id, string key ) => await PostKey(id, key, "Stop").ConfigureAwait(false);

        public async Task Restart( int id, string key ) => await PostKey(id, key, "Restart").ConfigureAwait(false);

        public async Task<bool> CheckPassword( int id, string key) => bool.Parse(await PostKey(id, key, "CheckPassword").ConfigureAwait(false));

        private static void ThrowOnNonSuccess(HttpResponseMessage resp) { if (!resp.IsSuccessStatusCode) throw new Exception($"Bad server response status code({resp.StatusCode})"); }
        private async Task<string> PostKey(int id, string key, string action) {
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("key", key) });
            //Client/Process/2/CheckPassword
            var resp = await _client.PostAsync($"{id}/{action}", content).ConfigureAwait(false);
            ThrowOnNonSuccess(resp);
            var ret = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            return ret;
        }

    }

}