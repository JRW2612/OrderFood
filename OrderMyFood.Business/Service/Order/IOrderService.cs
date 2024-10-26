using OrderMyFood.Business.Repositories.Order;
using OrderMyFood.DataModels;
using OrderMyFood.DataModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Service.Order
{
    public interface IOrderService : IOrderRepository
    {
        public Task<ResponseContext<bool>> CancelOrderAsync(int orderId);
        public Task<ResponseContext<OrderMasterModel>> GetOrderAsync(int orderId);
        public Task<ResponseContext<int>> PlaceOrderAsync(OrderMasterModel order);
        public Task<ResponseContext<bool>> UpdateOrderAsync(OrderMasterModel order);
       
    }
}
