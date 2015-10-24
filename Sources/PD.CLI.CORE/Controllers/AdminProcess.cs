using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;
using PD.Api.DataTypes;
using PD.CLI.CORE.Core;

namespace PD.CLI.CORE.Controllers {

    [RoutePrefix( "Admin/Process" )] //todo:authorize
    public class AdminProcessController : ApiController {

        private readonly IAdminApi _api;
        private readonly ILogManager _log;
        private string RemoteIp => Request.GetOwinContext()?.Request?.RemoteIpAddress;

        public AdminProcessController( IAdminApi api, ILogManager log ) {
            _api = api;
            _log = log;
        }

        [HttpGet]
        [Route( "" )]
        public async Task<IEnumerable<IDemonizedProcessBase>> List() {
            _log.Log( $"Listing processes as admin[{RemoteIp}]" );
            return await _api.Process.List().ConfigureAwait( false );
        }

        [HttpGet]
        [Route( "ListFull" )]
        public async Task<IEnumerable<IRunningDemonizedProcess>> ListFull() {
            _log.Log($"Listing processes(full) as admin[{RemoteIp}]");
            return await _api.Process.ListFull().ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "Edit" )]
        public async Task Edit( PasswordedDemonizedProcess model ) {
            _log.Log($"Editing process {model?.Id} [{RemoteIp}]");
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            await _api.Process.Edit( model ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "" )]
        public async Task<int> Create( PasswordedDemonizedProcess model ) {
            _log.Log($"Creating process {model?.Id} [{RemoteIp}]");
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            return await _api.Process.Create( model ).ConfigureAwait( false );
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IRunningDemonizedProcess> Get( int id ) {
            _log.Log($"Showing {id} to admin [{RemoteIp}]");
            return await _api.Process.Get( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Start" )]
        public async Task Start( [FromUri] int id ) {
            _log.Log($"Starting {id} as admin [{RemoteIp}]");
            await _api.Process.Start( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Stop" )]
        public async Task Stop( [FromUri] int id ) {
            _log.Log($"Stopping {id} as admin [{RemoteIp}]");
            await _api.Process.Stop( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Restart" )]
        public async Task Restart( [FromUri] int id ) {
            _log.Log($"Restarting {id} as admin [{RemoteIp}]");
            await _api.Process.Restart( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Delete" )]
        public async Task Delete( [FromUri] int id ) {
            _log.Log($"Deleting {id} as admin [{RemoteIp}]");
            await _api.Process.Delete( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Show" )]
        public async Task Show( [FromUri] int id ) {
            _log.Log($"Showing window for {id} as admin [{RemoteIp}]");
            await _api.Process.Show( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Hide" )]
        public async Task Hide( [FromUri] int id ) {
            _log.Log($"Hiding window for {id} as admin [{RemoteIp}]");
            await _api.Process.Hide( id ).ConfigureAwait( false );
        }

    }

}