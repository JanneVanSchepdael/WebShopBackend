using Shared;

namespace WebShopAPI.Controllers
{
    public class CartController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
