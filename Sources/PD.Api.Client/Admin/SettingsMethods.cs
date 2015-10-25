using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PD.Api.DataTypes;

namespace PD.Api.Client.Admin {

    public class SettingsMethods : ISettingsMethods {

        private readonly AdminApi _api;
        private HttpClient _client;

        public SettingsMethods( AdminApi api ) {
            _api = api;

            _client = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri(new Uri(_api._server), "Admin/Settings/") };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<ISettings> GetSettings() { throw new System.NotImplementedException(); }

        public Task SetSettings( ISettings settings ) { throw new System.NotImplementedException(); }

        public Task SetKey( string key ) { throw new System.NotImplementedException(); }

        public Task<bool> CheckKey( string key ) { throw new System.NotImplementedException(); }

    }

}