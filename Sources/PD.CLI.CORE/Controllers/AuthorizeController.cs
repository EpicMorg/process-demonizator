using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace PD.CLI.CORE.Controllers {

    public class AuthorizeController : ApiController {
        [HttpGet]
        public async Task<IHttpActionResult> Authorize( string key = null)
        {
            List<Claim> claims = null;
            if ( key == null ) {
                claims = new List<Claim> { new Claim(ClaimTypes.Name, "Anon"), new Claim(ClaimTypes.NameIdentifier, "Anon") };
            }
            else if ( true ) {
                claims = new List<Claim> { new Claim( ClaimTypes.Name, "Admin" ), new Claim( ClaimTypes.NameIdentifier, "Admin" ), new Claim( ClaimTypes.Role, "Admin" ) };
            }

            //var response = ActionContext.Request.CreateResponse();
            var properties = new AuthenticationProperties() { IsPersistent = true };
            var identity = new ClaimsIdentity( claims, DefaultAuthenticationTypes.ApplicationCookie );
            var manager = Request.GetOwinContext().Authentication;
            manager.SignIn( properties, identity );
            return Ok();
        }

    }

}