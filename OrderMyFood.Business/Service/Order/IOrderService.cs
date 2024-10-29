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
    public interface IOrderService 
    {
         Task<ResponseContext<bool>> CancelOrderAsync(int orderId);
         Task<IEnumerable<OrderMasterModel>> GetOrderAsync(int orderId);
         Task<ResponseContext<int>> PlaceOrderAsync(OrderItemMasterModel order);
         Task<ResponseContext<bool>> UpdateOrderAsync(OrderItemMasterModel order);
       
    }
}
