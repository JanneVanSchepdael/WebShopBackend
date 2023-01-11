using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebShopAPI.Extensions;
using Shared;
using Swashbuckle.AspNetCore.Annotations;
using Shared.Product;

namespace WebShopAPI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [SwaggerOperation("Returns a list of products")]
        [HttpGet]
        public async Task<ProductResponse.Index> GetProducts([FromQuery] ProductRequest.Index request)
        {
            return await _unitOfWork.ProductRepository.GetProductsAsync(request);
        }

        [SwaggerOperation("Returns a specific product.")]
        [HttpGet("{id}")]
        public async Task<ProductResponse.Detail> GetDetail([FromRoute] ProductRequest.Detail request)
        {
            return await _unitOfWork.ProductRepository.GetProductDetailAsync(request);
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
