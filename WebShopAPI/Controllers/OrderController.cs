using Azure;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Shared;
using Shared.Cart;
using Shared.Order;
using Swashbuckle.AspNetCore.Annotations;

namespace WebShopAPI.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [SwaggerOperation("Creates a new order.")]
        [HttpPost]
        public async Task<OrderResponse.Create> Create([FromBody] OrderRequest.Create request)
        {
            var response = await _unitOfWork.OrderRepository.AddOrderAsync(request);
            await _unitOfWork.Complete();
            return response;
        }

        [SwaggerOperation("Returns all orders of a specific user.")]
        [HttpGet("{userId}")]
        public async Task<OrderResponse.Index> GetDetail([FromRoute] OrderRequest.Index request)
        {
            return await _unitOfWork.OrderRepository.GetOrdersByUserAsync(request);
        }
    }
}
