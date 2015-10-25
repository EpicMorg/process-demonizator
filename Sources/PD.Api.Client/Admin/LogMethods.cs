using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PD.Api.Client.Admin {

    public class LogMethods : ILogMethods {

        private readonly AdminApi _api;
        private HttpClient _client;

        public LogMethods( AdminApi api ) {
            _api = api;
            _client = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri(new Uri(_api._server), "Admin/Process/") };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<IEnumerable<string>> Show( int tailCount ) { throw new System.NotImplementedException(); }

    }

}