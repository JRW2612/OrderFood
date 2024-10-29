using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using OrderMyFood.Business.Service.Restaurant;
using OrderMyFood.DataModels;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        public readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }


        #region Get Restaurant Menu
        [Route("GetMenuByRestaurant/restaurantId")]
        [ProducesResponseType(typeof(IEnumerable<RestaurantMasterModel>),StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetRestaurantMenu(int restaurantId) 
        {
           
            var result = await _restaurantService.GetRestaurantMenu(restaurantId);
            return Ok(result);

        }
        #endregion


        #region Search Restaurants
        [Route("GetRestaurants/criteria")]
        [ProducesResponseType(typeof(IEnumerable<RestaurantMasterModel>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetRestaurants(string criteria)
        {
           
            var result = await _restaurantService.SearchRestaurants(criteria);
            return Ok(result);

        }
        #endregion
    }
}
