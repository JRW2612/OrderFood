using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Repositories.Restaurant
{
    public interface IRestaurantRepository
    {
       public Task<ResponseContext<RestaurantMasterModel>> SearchRestaurants(string criteria);
       public Task<ResponseContext<MenuItemMasterModel>> GetRestaurantMenu(int restaurantId);
    }
}
