using OrderMyFood.Business.Repositories.Customer;
using OrderMyFood.Business.Repositories.Restaurant;
using OrderMyFood.Business.Service.Restaurant;
using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;
namespace OrderMyFood.Business.ServiceLogic.Restaurant
{
    public class RestaurantService : IRestaurantService
    {
        public readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseContext<MenuItemMasterModel>> GetRestaurantMenu(int restaurantId)
        {
            var response = await _repository.GetRestaurantMenu(restaurantId);
            return response;
        }

        public async Task<ResponseContext<RestaurantMasterModel>> SearchRestaurants(string criteria)
        {
            var response = await _repository.SearchRestaurants(criteria);
            return response;
        }
    }
}
