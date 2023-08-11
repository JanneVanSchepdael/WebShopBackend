namespace Shared.Order;

public interface IOrderRepository
{
    Task<OrderResponse.Index> GetOrdersByUserAsync(OrderRequest.Index request);
    Task<OrderResponse.Create> AddOrderAsync(OrderRequest.Create request);
}
