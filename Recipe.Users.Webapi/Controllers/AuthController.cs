using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Users.Business.Dtoes;
using Recipe.Users.Business.Interfaces;

namespace Recipe.Users.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService { get; set; }

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("login")]
        public ActionResult<UserResponse> SignIn(UserLoginRequest request)
        {
            try
            {
                var isSignIn = this._authService.Login(request);
                return Ok(isSignIn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public ActionResult<UserResponse> SignUp(UserRegistrationRequest request)
        {
            try
            {
                var isSignIn = this._authService.Registration(request);
                return Ok(isSignIn.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
