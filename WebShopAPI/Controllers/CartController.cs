using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Cart;
using Shared.Product;
using Swashbuckle.AspNetCore.Annotations;

namespace WebShopAPI.Controllers;

public class CartController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public CartController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [SwaggerOperation("Adds a product to the cart of a specific user.")]
    [HttpPost]
    public async Task<CartResponse.Edit> Add([FromBody] CartRequest.Add request)
    {
        return await _unitOfWork.CartRepository.AddToCartAsync(request);
    }


    [SwaggerOperation("Returns all products in the cart of a specific user.")]
    [HttpGet("{userId}")]
    public async Task<CartResponse.Detail> GetDetail([FromRoute] CartRequest.Detail request)
    {
        return await _unitOfWork.CartRepository.GetCartDetailAsync(request);
    }

    [SwaggerOperation("Edits an existing cart.")]
    [HttpPut]
    public async Task<CartResponse.Edit> Edit([FromBody] CartRequest.Edit request)
    {
        return await _unitOfWork.CartRepository.EditCartAsync(request);
    }
}
