using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;
using PD.Api.DataTypes;

namespace PD.CLI.CORE.Controllers {

    [RoutePrefix( "Admin/Process" )] //todo:authorize
    public class AdminProcessController : ApiController {

        private readonly IAdminApi _api;

        public AdminProcessController( IAdminApi api ) { _api = api; }

        [HttpGet]
        [Route( "" )]
        public async Task<IEnumerable<IDemonizedProcessBase>> List() => await _api.Process.List().ConfigureAwait( false );

        [HttpGet]
        [Route( "ListFull" )]
        public async Task<IEnumerable<IRunningDemonizedProcess>> ListFull() => await _api.Process.ListFull().ConfigureAwait( false );

        [HttpPost]
        [Route( "Edit" )]
        public async Task Edit( PasswordedDemonizedProcess model ) {
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            await _api.Process.Edit( model ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route( "" )]
        public async Task<int> Create( PasswordedDemonizedProcess model ) {
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            return await _api.Process.Create( model ).ConfigureAwait( false );
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IRunningDemonizedProcess> Get( int id ) => await _api.Process.Get( id ).ConfigureAwait( false );

        [HttpPost]
        [Route( "{id}/Start" )]
        public async Task Start( [FromUri] int id ) => await _api.Process.Start( id ).ConfigureAwait( false );

        [HttpPost]
        [Route( "{id}/Stop" )]
        public async Task Stop( [FromUri] int id ) => await _api.Process.Stop( id ).ConfigureAwait( false );

        [HttpPost]
        [Route( "{id}/Restart" )]
        public async Task Restart( [FromUri] int id ) => await _api.Process.Restart( id ).ConfigureAwait( false );

        [HttpPost]
        [Route( "{id}/Delete" )]
        public async Task Delete( [FromUri] int id ) => await _api.Process.Delete( id ).ConfigureAwait( false );

        [HttpPost]
        [Route( "{id}/Show" )]
        public async Task Show( [FromUri] int id ) => await _api.Process.Show( id ).ConfigureAwait( false );

        [HttpPost]
        [Route( "{id}/Hide" )]
        public async Task Hide( [FromUri] int id ) => await _api.Process.Hide( id ).ConfigureAwait( false );

    }

}