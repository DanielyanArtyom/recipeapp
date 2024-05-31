using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Account.Business.Dtoes;

namespace Recipe.Account.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult UserLogin([FromBody] CreateAccountRequest request)
        {
            return Ok("Inventory update processed successfully.");
        }
    }
}
