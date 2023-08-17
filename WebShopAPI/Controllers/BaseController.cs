using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebShopAPI.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]s")]
    public class BaseController : ControllerBase
    {

    }
}
