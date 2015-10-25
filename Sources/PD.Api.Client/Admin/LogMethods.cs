using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PD.Api.Client {

    public class LogMethods : ILogMethods {

        private readonly AdminApi _api;
        private HttpClient _client;

        public LogMethods( AdminApi api ) {
            _api = api;
            _client = MethodsHelper.CreateClient( api._server, "Admin/Process/" );
        }

        public Task<IEnumerable<string>> Show( int tailCount ) { throw new System.NotImplementedException(); }

    }

}