using System.Net.Http;
using System.Threading.Tasks;
using PD.Api.DataTypes;

namespace PD.Api.Client {

    public class SettingsMethods : ISettingsMethods {

        private readonly AdminApi _api;
        private HttpClient _client;

        public SettingsMethods( AdminApi api ) {
            _api = api;
            _client = MethodsHelper.CreateClient( api._server, "Admin/Settings/" );
        }

        public Task<ISettings> GetSettings() { throw new System.NotImplementedException(); }

        public Task SetSettings( ISettings settings ) { throw new System.NotImplementedException(); }

        public Task SetKey( string key ) { throw new System.NotImplementedException(); }

        public Task<bool> CheckKey( string key ) { throw new System.NotImplementedException(); }

    }

}