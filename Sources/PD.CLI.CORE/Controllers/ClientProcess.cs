using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using PD.Api;
using PD.Api.DataTypes;
using PD.CLI.CORE.Core;

namespace PD.CLI.CORE.Controllers {

    [RoutePrefix( "Client/Process" )]
    public class ClientProcessController : ApiController//, IClientProcessMethods {
    { 

        private readonly IClientApi _api;
        private readonly ILogManager _manager;

        public ClientProcessController( IClientApi api, ILogManager manager ) {
            _api = api;
            _manager = manager;
        }

        [Route( "" )]
        [HttpGet]
        public async Task<IEnumerable<IDemonizedProcessBase>> List() {
            _manager.Log($"Listing processes[{Request.GetOwinContext()?.Request?.RemoteIpAddress}]");
            return await _api.Process.List().ConfigureAwait( false );
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IRunningDemonizedProcess> Get( int id, KeyWrapper v ) {
            _manager.Log($"Showing {id}[{Request.GetOwinContext()?.Request?.RemoteIpAddress}]");
            return await _api.Process.Get( id, v.Key ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Start" )]
        public async Task Start( [FromUri] int id, [FromBody] KeyWrapper v ) {
            _manager.Log($"Starting {id}[{Request.GetOwinContext()?.Request?.RemoteIpAddress}]");
            await _api.Process.Start( id, v.Key ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Stop" )]
        public async Task Stop( [FromUri] int id, [FromBody] KeyWrapper v ) {
            _manager.Log($"Stopping {id}[{Request.GetOwinContext()?.Request?.RemoteIpAddress}]");
            await _api.Process.Stop( id, v.Key ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Restart" )]
        public async Task Restart( [FromUri] int id, [FromBody] KeyWrapper v ) {
            _manager.Log($"Restarting {id}[{Request.GetOwinContext()?.Request?.RemoteIpAddress}]");
            await _api.Process.Restart( id, v.Key ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/CheckPassword" )]
        public async Task<bool> CheckPassword( [FromUri] int id, [FromBody] KeyWrapper v ) {
            _manager.Log( $"Checking password for {id}[{Request.GetOwinContext()?.Request?.RemoteIpAddress}]" );
            return await _api.Process.CheckPassword( id, v.Key ).ConfigureAwait( false );
        }
    }
    // FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK FUCK
    // http://blog.codenamed.nl/2015/05/12/why-your-frombody-parameter-is-always-null/
    public class KeyWrapper {

        [HttpBindRequired]
        public string Key { get; set; }

    }
}