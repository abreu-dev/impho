using Microsoft.AspNetCore.Mvc;

namespace Impho.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ServiceUnavailable(object value)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, value);
        }
    }
}
