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
        public async Task<IEnumerable<IDemonizedProcessBase>> List([FromUri]string key) {
            _log.Log( $"Listing processes as admin[{RemoteIp}]" );
            await ThrowOnBadKey( key ).ConfigureAwait( false );
            return await _api.Process.List().ConfigureAwait( false );
        }

        [HttpGet]
        [Route( "ListFull" )]
        public async Task<IEnumerable<IRunningDemonizedProcess>> ListFull([FromUri]string key) {
            _log.Log($"Listing processes(full) as admin[{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            return await _api.Process.ListFull().ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "Edit" )]
        public async Task Edit([FromUri]string key, PasswordedDemonizedProcess model ) {
            _log.Log($"Editing process {model?.Id} [{RemoteIp}]");
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Edit( model ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "" )]
        public async Task<int> Create([FromUri]string key,PasswordedDemonizedProcess model ) {
            _log.Log($"Creating process {model?.Id} [{RemoteIp}]");
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            await ThrowOnBadKey(key).ConfigureAwait(false);
            return await _api.Process.Create( model ).ConfigureAwait( false );
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IRunningDemonizedProcess> Get([FromUri]string key, int id ) {
            _log.Log($"Showing {id} to admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            return await _api.Process.Get( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Start" )]
        public async Task Start([FromUri]string key,[FromUri] int id ) {
            _log.Log($"Starting {id} as admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Start( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Stop" )]
        public async Task Stop([FromUri]string key, [FromUri] int id ) {
            _log.Log($"Stopping {id} as admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Stop( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Restart" )]
        public async Task Restart([FromUri]string key,[FromUri] int id ) {
            _log.Log($"Restarting {id} as admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Restart( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Delete" )]
        public async Task Delete([FromUri]string key, [FromUri] int id ) {
            _log.Log($"Deleting {id} as admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Delete( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Show" )]
        public async Task Show([FromUri]string key,[FromUri] int id ) {
            _log.Log($"Showing window for {id} as admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Show( id ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "{id}/Hide" )]
        public async Task Hide([FromUri]string key,[FromUri] int id ) {
            _log.Log($"Hiding window for {id} as admin [{RemoteIp}]");
            await ThrowOnBadKey(key).ConfigureAwait(false);
            await _api.Process.Hide( id ).ConfigureAwait( false );
        }
        

        private async Task ThrowOnBadKey( string key ) {
            if ( !( await _api.Settings.CheckKey( key ).ConfigureAwait( false ) ) )
                throw new UnauthorizedAccessException( $"Some faggot from [{RemoteIp}] tried to break into our system" );
        }
    }

}