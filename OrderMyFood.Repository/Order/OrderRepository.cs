using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderMyFood.Business.Repositories.Order;
using OrderMyFood.DataModels;
using OrderMyFood.Repository.DataBase;
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
        public readonly OrderFoodDbContext _context;

        public OrderRepository(OrderFoodDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseContext<bool>> CancelOrderAsync(int orderId)
        {
            var response = new ResponseContext<bool>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Retrieve the order entity including related OrderItems
                var orderData = await _context.orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(x => x.Id == orderId);

                if (orderData == null)
                {
                    response.Item = false;
                    response.StatusCode = (int)StatusCodes.Status404NotFound;
                    return response;
                }

                // Remove the order and its related order items
                _context.orders.Remove(orderData);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                // Set response as success
                response.Item = true;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "Order Cancelled";
                return response;
            }
            catch
            {
                await transaction.RollbackAsync();
                response.Item = false;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Unable to Cancel Order";

            }

            return response;
        }


        public async Task<ResponseContext<OrderMasterModel>> GetOrderAsync(int orderId)
        {
            var response = new ResponseContext<OrderMasterModel>();
            await _context.Database.BeginTransactionAsync();
            try
            {
                // Retrieve the order data
                var orderData = await _context.orders
                    .Where(x => x.Id == orderId)
                    .Select(x => new OrderMasterModel
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        OrderDate = x.OrderDate,
                        OrderItems = x.OrderItems.Select(s => new OrderItemMasterModel
                        {
                            OrderId = s.OrderId,
                            MenuItemId = s.MenuItemId,
                            Quantity = s.Quantity,
                            Price = s.Price
                        }).ToList()
                    }).ToListAsync();

                await _context.Database.CommitTransactionAsync();

                // Set the response with the fetched Order data
                response.Items = orderData;
                response.StatusCode = (int)StatusCodes.Status200OK;
                return response;
            }
            catch
            {
                await _context.Database.RollbackTransactionAsync();
                response.Items = null;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                return response;
            }
        }


        public async Task<ResponseContext<int>> PlaceOrderAsync(OrderItemMasterModel order)
        {
            var response = new ResponseContext<int>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Create and add the OrderItem
                var orderItem = new OrderItem
                {
                    MenuItemId = order.MenuItemId,
                    Quantity = order.Quantity,
                    Price = order.Price
                };

                await _context.orderItems.AddAsync(orderItem);
                await _context.SaveChangesAsync();

                // Create and add the Order
                var orderData = new DataBase.Order
                {
                    OrderItemId = orderItem.Id,
                    OrderDate = DateTime.UtcNow,
                    CustomerId = 100 // Assuming `CustomerId` is passed or default to 100
                };

                await _context.orders.AddAsync(orderData);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                // Set the response to include the newly created Order ID
                response.Item = orderData.Id;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "Order created";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                response.Item = 0;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Order not created";
              
            }

            return response;
        }



        public async Task<ResponseContext<bool>> UpdateOrderAsync(OrderItemMasterModel order)
        {
            var response = new ResponseContext<bool>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Fetch existing OrderItem or create if not found
                var orderItem = await _context.orderItems.FindAsync(order.Id);
                if (orderItem != null)
                {
                    // Update properties if the orderItem exists
                    orderItem.MenuItemId = order.MenuItemId;
                    orderItem.Quantity = order.Quantity;
                    orderItem.Price = order.Price;
                    _context.orderItems.Update(orderItem);
                }
                else
                {
                    // If orderItem does not exist, create a new one
                    orderItem = new OrderItem
                    {
                        Id = order.Id,
                        MenuItemId = order.MenuItemId,
                        Quantity = order.Quantity,
                        Price = order.Price
                    };
                    await _context.orderItems.AddAsync(orderItem);
                }

                await _context.SaveChangesAsync();

                // Fetch or create Order entity based on Id
                var orderData = await _context.orders.FindAsync(order.OrderId);
                if (orderData != null)
                {
                    // Update existing Order's association to OrderItem
                    orderData.OrderItemId = orderItem.Id;
                    _context.orders.Update(orderData);
                }
                else
                {
                    // Create a new Order if it doesn't exist
                    orderData = new DataBase.Order
                    {
                        Id = order.OrderId,
                        OrderItemId = orderItem.Id
                    };
                    await _context.orders.AddAsync(orderData);
                }

                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                // Set response
                response.Item = true;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "order updated successfully";
            }
            catch 
            {
                await transaction.RollbackAsync();
                response.Item = false;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Failed to update order";
            
            }

            return response;
        }

    }
}
