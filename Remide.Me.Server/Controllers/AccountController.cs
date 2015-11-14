using System;
using System.Threading.Tasks;
using System.Web.Http;

using Remide.Me.Server.Insractructure.Requests;

namespace Remide.Me.Server.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        [ActionName("login")]
        public Task<IHttpActionResult> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ActionName("register")]
        public Task<IHttpActionResult> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ActionName("logout")]
        public Task<IHttpActionResult> Logout(string userID)
        {
            throw new NotImplementedException();
        }
    }
}