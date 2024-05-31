using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Users.Business.Dtoes;
using Recipe.Users.Business.Interfaces;
using Recipe.Users.Business.Services;
using System.Text.Json;
using System.Threading.Tasks;

namespace Recipe.Users.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private readonly IProducerService _producerService;

        public AuthController(IAuthService authService, IProducerService producerService)
        {
            this._authService = authService;
            this._producerService = producerService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> SignIn(UserLoginRequest request)
        {
            try
            {
                var isSignIn = this._authService.Login(request);

                var message = JsonSerializer.Serialize(isSignIn);
                 
                await this._producerService.ProduceAsync("UserLogin", message);

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
