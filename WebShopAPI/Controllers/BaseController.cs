using Microsoft.AspNetCore.Mvc;

namespace WebShopAPI.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]s")]
    public class BaseController : ControllerBase
    {

    }
}
