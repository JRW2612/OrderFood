using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderMyFood.Business.Repositories.Restaurant;
using OrderMyFood.DataModels;
using OrderMyFood.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;
namespace OrderMyFood.Repository.Restaurant
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public readonly OrderFoodDbContext _context;
        public RestaurantRepository(OrderFoodDbContext context) 
        {
          _context= context;
        }
        public async Task<ResponseContext<MenuItemMasterModel>> GetRestaurantMenu(int restaurantId)
        {
            ResponseContext<MenuItemMasterModel> response = new ResponseContext<MenuItemMasterModel>();

            try
            {
                var entity = await _context.menuitems.Select(x => new MenuItemMasterModel
                {
                    Id = x.Id,                // Unique identifier for the menu item
                    RestaurantId = x.RestaurantId, // Foreign key to the Restaurant
                    Name = x.Name,            // Name of the menu item
                    Description = x.Description, // Description of the menu item
                    Price = x.Price,          // Price of the menu item
                    Cuisine = x.Cuisine,      // Type of cuisine (e.g., Italian, Chinese)
                    IsAvailable = x.IsAvailable, // Indicates if the item is currently available
                    DietaryInfo = x.DietaryInfo // Dietary information (e.g., Vegan, Gluten-Free)
                }).ToListAsync();

                response.Items = entity;
                response.StatusCode = StatusCodes.Status200OK;
                return response;
            }
            catch
            {
                response.Items = null;
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }
        }

        public async Task<ResponseContext<RestaurantMasterModel>> SearchRestaurants(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
