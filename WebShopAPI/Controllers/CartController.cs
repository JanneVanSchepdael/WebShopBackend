using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Cart;
using Shared.Product;
using Swashbuckle.AspNetCore.Annotations;

namespace WebShopAPI.Controllers
{
    public class CartController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [SwaggerOperation("Returns all products in the cart of a specific user.")]
        [HttpGet("{userId}")]
        public async Task<CartResponse.Detail> GetDetail([FromRoute] CartRequest.Detail request)
        {
            return await _unitOfWork.CartRepository.GetCartDetailAsync(request);
        }

        [SwaggerOperation("Creates a new cart.")]
        [HttpPost]
        public async Task<CartResponse.Create> Create([FromBody] CartRequest.Create request)
        {
            return await _unitOfWork.CartRepository.AddCartAsync(request);
        }

        [SwaggerOperation("Edits an existing cart.")]
        [HttpPut("{id}")]
        public async Task<CartResponse.Edit> Edit([FromBody] CartRequest.Edit request)
        {
            return await _unitOfWork.CartRepository.EditCartAsync(request);
        }
    }
}
