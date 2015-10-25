using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PD.Api.DataTypes;

namespace PD.Api.Client.Admin {

    public class AdminProcessMethods : IAdminProcessMethods {

        private readonly AdminApi _api;
        private HttpClient _client;

        public AdminProcessMethods( AdminApi api ) {
            _api = api;
            _client = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri(new Uri(_api._server), "Admin/Process/") };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<IEnumerable<IDemonizedProcessBase>> List() { throw new System.NotImplementedException(); }

        public Task<IEnumerable<IRunningDemonizedProcess>> ListFull() { throw new System.NotImplementedException(); }

        public Task Edit( IPasswordedDemonizedProcess model ) { throw new System.NotImplementedException(); }

        public Task<int> Create( IPasswordedDemonizedProcess model ) { throw new System.NotImplementedException(); }

        public Task<IRunningDemonizedProcess> Get( int id ) { throw new System.NotImplementedException(); }

        public Task Start( int id ) { throw new System.NotImplementedException(); }

        public Task Stop( int id ) { throw new System.NotImplementedException(); }

        public Task Restart( int id ) { throw new System.NotImplementedException(); }

        public Task Delete( int id ) { throw new System.NotImplementedException(); }

        public Task Show( int id ) { throw new System.NotImplementedException(); }

        public Task Hide( int id ) { throw new System.NotImplementedException(); }

    }

}