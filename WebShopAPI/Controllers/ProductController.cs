using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebShopAPI.Extensions;
using Shared;
using Swashbuckle.AspNetCore.Annotations;
using Shared.Product;

namespace WebShopAPI.Controllers;

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
}
