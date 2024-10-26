using OrderMyFood.Business.Repositories.Restaurant;
using OrderMyFood.DataModels;
using OrderMyFood.DataModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Service.Restaurant
{
    public interface IRestaurantService : IRestaurantRepository
    {
        public Task<ResponseContext<MenuItemMasterModel>>GetRestaurantMenu(int restaurantId);    

        public Task<ResponseContext<RestaurantMasterModel>> SearchRestaurants(string criteria);
       
    }
}
