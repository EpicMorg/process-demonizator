using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;
using PD.CLI.CORE.Core;

namespace PD.CLI.CORE.Controllers {

    [RoutePrefix("Admin/Log")]
    public class LogController : ControllerBase {

        private readonly IAdminApi _api;
        private readonly ILogManager _log;

        public LogController( IAdminApi api, ILogManager log ) : base( api ) {
            _api = api;
            _log = log;
        }
        [Route("Show/{tailCount}")]
        [HttpGet]
        public async Task<IEnumerable<string>> Show( [FromUri] string key, int tailCount ) {
            _log.Log( $"Listing processes as admin[{RemoteIp}]" );
            await ThrowOnBadKey( key ).ConfigureAwait( false );
            return await _api.Log.Show( tailCount ).ConfigureAwait( false );
        }

    }

}