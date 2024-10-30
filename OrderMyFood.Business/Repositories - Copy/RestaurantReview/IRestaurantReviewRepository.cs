using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Repositories___Copy.RestaurantReview
{
    public interface IRestaurantReviewRepository
    {
        Task<ResponseContext<int>> AddRestaurantReviewAsync(RestaurantReviewMasterModel restaurantReview);
        Task<ResponseContext<bool>> UpdateRestaurantReviewAsync(RestaurantReviewMasterModel restaurantReview);
        Task<ResponseContext<bool>> DeleteRestaurantReviewAsync(int restaurantReviewId);
        Task<IEnumerable<RestaurantReviewMasterModel>> GetRestaurantReviewAsync(int customerId);
        Task<IEnumerable<RestaurantReviewMasterModel>> GetAllRestaurantReviewAsync();
    }
}

