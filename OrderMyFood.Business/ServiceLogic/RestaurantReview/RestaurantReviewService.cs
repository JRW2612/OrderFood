using OrderMyFood.Business.Repositories.Restaurant;
using OrderMyFood.Business.Repositories___Copy.RestaurantReview;
using OrderMyFood.Business.Service.RestaurantReview;
using OrderMyFood.DataModels;
using OrderMyFood.DataModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.ServiceLogic.RestaurantReview
{
    public class RestaurantReviewService:IRestaurantReviewService
    {
        public readonly IRestaurantReviewRepository _repository;

        public RestaurantReviewService(IRestaurantReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseContext<int>> AddRestaurantReviewAsync(RestaurantReviewMasterModel restaurantReview)
        {
            var response = await _repository.AddRestaurantReviewAsync(restaurantReview);
            return response;
        }

        public async Task<ResponseContext<bool>> DeleteRestaurantReviewAsync(int restaurantReviewId)
        {
            var response = await _repository.DeleteRestaurantReviewAsync(restaurantReviewId);
            return response;
        }

        public async Task<IEnumerable<RestaurantReviewMasterModel>> GetAllRestaurantReviewAsync()
        {
            var response = await _repository.GetAllRestaurantReviewAsync();
            return response;
        }

        public async Task<IEnumerable<RestaurantReviewMasterModel>> GetRestaurantReviewAsync(int customerId)
        {
            var response = await _repository.GetRestaurantReviewAsync(customerId);
            return response;
        }

        public async Task<ResponseContext<bool>> UpdateRestaurantReviewAsync(RestaurantReviewMasterModel restaurantReview)
        {
            var response = await _repository.UpdateRestaurantReviewAsync(restaurantReview);
            return response;
        }
    }
}
