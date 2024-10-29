using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Repositories.Order
{
    public interface IOrderRepository
    {
        public Task<ResponseContext<int>> PlaceOrderAsync(OrderItemMasterModel order);
        public Task<ResponseContext<bool>> UpdateOrderAsync(OrderItemMasterModel order);
        public Task<ResponseContext<bool>> CancelOrderAsync(int orderId);
        public Task<ResponseContext<OrderMasterModel>> GetOrderAsync(int orderId);
    }
}
