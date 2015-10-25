using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PD.Api.DataTypes;
using static PD.Api.Client.MethodsHelper;
namespace PD.Api.Client {

    public class AdminProcessMethods : IAdminProcessMethods {

        private readonly AdminApi _api;
        private HttpClient _client;
        private string key => _api.Key;
        public AdminProcessMethods( AdminApi api ) {
            _api = api;
            _client = CreateClient( _api._server, "Admin/Process/" );
        }


        public async Task<IEnumerable<IDemonizedProcessBase>> List() => await GetWithKey<RunningDemonizedProcess[]>("").ConfigureAwait(false);

        public async Task<IEnumerable<IRunningDemonizedProcess>> ListFull() => await GetWithKey<RunningDemonizedProcess[]>("ListFull").ConfigureAwait(false);

        public Task Edit( IPasswordedDemonizedProcess model ) { throw new System.NotImplementedException(); }

        public Task<int> Create( IPasswordedDemonizedProcess model ) { throw new System.NotImplementedException(); }

        public async Task<IRunningDemonizedProcess> Get(int id) => await GetWithKey<RunningDemonizedProcess>( $"{id}" ).ConfigureAwait( false );

        private async Task<T> GetWithKey<T>( string str ) {
            var resp = await _client.GetAsync( $"{str}?key={key}" ).ConfigureAwait( false );
            ThrowOnNonSuccess( resp );
            var ret = await resp.Content.ReadAsStringAsync().ConfigureAwait( false );
            return JsonConvert.DeserializeObject<T>(ret);
        }

        public async Task Start( int id ) => await _client.PostClientKey(id, key, "Start").ConfigureAwait(false);

        public async Task Stop( int id ) => await _client.PostClientKey(id, key, "Stop").ConfigureAwait(false);

        public async Task Restart(int id) => await _client.PostClientKey(id, key, "Restart").ConfigureAwait(false);

        public async Task Delete(int id) => await _client.PostClientKey(id, key, "Delete").ConfigureAwait(false);

        public async Task Show(int id) => await _client.PostClientKey(id, key, "Show").ConfigureAwait(false);

        public async Task Hide(int id) => await _client.PostClientKey(id, key, "Hide").ConfigureAwait(false);

    }

}