using System.Threading.Tasks;
using System.Web.Http;
using PD.Api;
using PD.CLI.CORE.Core;

namespace PD.CLI.CORE.Controllers {

    [RoutePrefix("Admin/Authorize")]
    public class AuthorizeController : ApiController {

        private readonly IAdminApi _api;

        public AuthorizeController( IAdminApi api ) {
            _api = api;
        }

        [HttpPost]
        [Route("")]
        public async Task<bool> Authorize( KeyWrapper key ) => await _api.Settings.CheckKey( key.Key ).ConfigureAwait( false );

        //{ 

        ////FUCK
        //    //shit's broken 


        //    //List<Claim> claims = null;
        //    //if ( key == null ) {
        //    //    claims = new List<Claim> { new Claim(ClaimTypes.Name, "Anon"), new Claim(ClaimTypes.NameIdentifier, "Anon") };
        //    //}
        //    //else if ( true ) {
        //    //    claims = new List<Claim> { new Claim( ClaimTypes.Name, "Admin" ), new Claim( ClaimTypes.NameIdentifier, "Admin" ), new Claim( ClaimTypes.Role, "Admin" ) };
        //    //}

        //    ////var response = ActionContext.Request.CreateResponse();
        //    //var properties = new AuthenticationProperties() { IsPersistent = true };
        //    //var identity = new ClaimsIdentity( claims, DefaultAuthenticationTypes.ApplicationCookie );
        //    //var manager = Request.GetOwinContext().Authentication;
        //    //manager.SignIn( properties, identity );
        //    //return Ok();
        //}

    }

}