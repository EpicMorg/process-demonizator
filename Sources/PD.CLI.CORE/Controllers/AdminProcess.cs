using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;
using PD.Api.DataTypes;

namespace PD.CLI.CORE.Controllers {
    [RoutePrefix("Admin/Process")]//todo:authorize
    public class AdminProcessController : ApiController {

        private readonly IAdminApi _api;

        public AdminProcessController( IAdminApi api ) { _api = api; }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<IDemonizedProcessBase>> List() => await _api.Process.List().ConfigureAwait( false );

        [HttpGet]
        [Route("ListFull")]
        public async Task<IEnumerable<IRunningDemonizedProcess>> ListFull() => await _api.Process.ListFull().ConfigureAwait( false );

        [HttpPost]
        [Route("Edit")]
        public async Task Edit( PasswordedDemonizedProcess model ) {
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            await _api.Process.Edit( model ).ConfigureAwait( false );
        }

        [HttpPost]
        [Route("")]
        public async Task<int> Create( PasswordedDemonizedProcess model ) {
            if ( !ModelState.IsValid ) throw new ArgumentException( nameof( model ) );
            return await _api.Process.Create( model ).ConfigureAwait( false );
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IRunningDemonizedProcess> Get( int id ) => await _api.Process.Get( id ).ConfigureAwait( false );

        [HttpPost]
        public async Task Start( int id ) => await _api.Process.Start( id ).ConfigureAwait( false );

        [HttpPost]
        public async Task Stop( int id ) => await _api.Process.Stop( id ).ConfigureAwait( false );

        [HttpPost]
        public async Task Restart( int id ) => await _api.Process.Restart( id ).ConfigureAwait( false );

        [HttpPost]
        public async Task Delete( int id ) => await _api.Process.Delete( id ).ConfigureAwait( false );

        [HttpPost]
        public async Task Show( int id ) => await _api.Process.Show( id ).ConfigureAwait( false );

        [HttpPost]
        public async Task Hide( int id ) => await _api.Process.Hide( id ).ConfigureAwait( false );

    }

}