using OrderMyFood.Business.Repositories.Order;
using OrderMyFood.Business.Service.Order;
using OrderMyFood.DataModels;
using static OrderMyFood.DataModels.Helper.Helper;
namespace OrderMyFood.Business.ServiceLogic.Order
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseContext<bool>> CancelOrderAsync(int orderId)
        {
            var response = await _repository.CancelOrderAsync(orderId);
            return response;
        }

        public async Task<ResponseContext<OrderMasterModel>> GetOrderAsync(int orderId)
        {
            var response = await _repository.GetOrderAsync(orderId);
            return response;
        }

        public async Task<ResponseContext<int>> PlaceOrderAsync(OrderMasterModel order)
        {
            var response = await _repository.PlaceOrderAsync(order);
            return response;
        }

        public async Task<ResponseContext<bool>> UpdateOrderAsync(OrderMasterModel order)
        {
            var response = await _repository.UpdateOrderAsync(order);
            return response;
        }
    }
}
