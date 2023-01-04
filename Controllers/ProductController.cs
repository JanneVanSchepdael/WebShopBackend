using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebShopAPI.Extensions;
using Shared;


namespace WebShopAPI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*
        [HttpPost("{productId}")]
        public async Task<ActionResult> AddProductToCart(int productId)
        {
            // Get Logged in user
            var sourceUserId = User.GetUserId();
            var sourceUser = await _unitOfWork.UserRepository.GetUserByIdAsync(sourceUserId);

            // Find the product
            var product = await _unitOfWork.ProductRepository.GetProductById(productId);
            if (product == null) return BadRequest("Product not found");

            // Add the product to the current user's Cart
            sourceUser.Cart.Products.Add(product);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add product to cart");
        }*/
    }
}
