using OrderMyFood.Business.Repositories.Order;
using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;
namespace OrderMyFood.Repository.Order
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<ResponseContext<bool>> CancelOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseContext<OrderMasterModel>> GetOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseContext<int>> PlaceOrderAsync(OrderMasterModel order)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseContext<bool>> UpdateOrderAsync(OrderMasterModel order)
        {
            throw new NotImplementedException();
        }
    }
}
