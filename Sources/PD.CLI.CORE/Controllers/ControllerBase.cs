using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;

namespace PD.CLI.CORE.Controllers {

    public abstract class ControllerBase : ApiController {

        private readonly IAdminApi _api;

        public ControllerBase(IAdminApi api) { _api = api; }

        protected string RemoteIp => Request.GetOwinContext()?.Request?.RemoteIpAddress;

        protected async Task ThrowOnBadKey( string key ) {
            if ( !( await _api.Settings.CheckKey( key ).ConfigureAwait( false ) ) )
                throw new UnauthorizedAccessException( $"Some faggot from [{RemoteIp}] tried to break into our system" );
        }

    }

}