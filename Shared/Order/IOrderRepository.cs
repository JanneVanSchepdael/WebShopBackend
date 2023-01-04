namespace Shared.Order;

public interface IOrderRepository
{
    Task<OrderResponse.Detail> GetOrderById(OrderRequest.Detail request);
    //Task<List<Order>> GetOrdersByUser(int userId);
}
