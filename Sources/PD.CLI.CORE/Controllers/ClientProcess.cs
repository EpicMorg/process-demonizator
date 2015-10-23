using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;
using PD.Api.DataTypes;

namespace PD.CLI.CORE.Controllers {
    [RoutePrefix("Client/Process")]
    public class ClientProcessController : ApiController, IClientProcessMethods {

        private readonly IClientApi _api;

        public ClientProcessController( IClientApi api ) { _api = api; }
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<IDemonizedProcessBase>> List() => await _api.Process.List().ConfigureAwait( false );
        [HttpGet]
        public async Task<IRunningDemonizedProcess> Get( int id, string key ) => await _api.Process.Get( id, key ).ConfigureAwait( false );
        [HttpPost]
        public async Task Start( int id, string key ) => await _api.Process.Start( id, key ).ConfigureAwait( false );
        [HttpPost]
        public async Task Stop( int id, string key ) => await _api.Process.Stop( id, key ).ConfigureAwait( false );
        [HttpPost]
        public async Task Restart( int id, string key ) => await _api.Process.Restart( id, key ).ConfigureAwait( false );

    }

}