namespace Shared.Order;

public interface IOrderRepository
{
    Task<OrderResponse.Detail> GetOrdersByUserAsync(OrderRequest.Detail request);
    Task<OrderResponse.Create> AddOrderAsync(OrderRequest.Create request);
}
