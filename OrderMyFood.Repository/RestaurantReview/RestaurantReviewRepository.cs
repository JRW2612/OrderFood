using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderMyFood.Business.Repositories___Copy.RestaurantReview;
using OrderMyFood.DataModels;
using OrderMyFood.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Repository.RestaurantReview
{
    public class RestaurantReviewRepository: IRestaurantReviewRepository
    {
        public readonly OrderFoodDbContext _context;
        public RestaurantReviewRepository(OrderFoodDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseContext<int>> AddRestaurantReviewAsync(RestaurantReviewMasterModel restaurantReview)
        {
            var response = new ResponseContext<int>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    // Create and add the RestaurantReview
                    var resreview = new DataBase.RestaurantReview
                    {
                        RestaurantId = restaurantReview.RestaurantId,  // Assign actual restaurant ID
                        CustomerId = restaurantReview.CustomerId,      // Assign actual customer ID
                        Comment = "Great place!",         // Replace with actual comment
                        Rating = 4.5m,                    // Replace with actual rating
                        IsModerated = false,              // Replace with actual moderation status
                        ReviewDate = DateTime.UtcNow      // Replace with actual review date if needed
                    };

                    await _context.restaurantReviews.AddAsync(resreview);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    // Set the response to include the newly created RestaurantReview ID
                    response.Item = resreview.Id;
                    response.StatusCode = (int)StatusCodes.Status200OK;
                    response.Message = "Restaurant review created successfully";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                    response.Message = $"Error creating restaurant review: {ex.Message}";
                }

       
            return response;
        }

        public async Task<ResponseContext<bool>> DeleteRestaurantReviewAsync(int restaurantReviewId)
        {
            var response = new ResponseContext<bool>();

            try
            {
                // Retrieve the customer data
                var custData = await _context.restaurantReviews
                .Where(x => x.Id == restaurantReviewId).SingleOrDefaultAsync();
              
                // Set the response with the fetched customer data
                if (custData != null)
                {
                    _context.restaurantReviews.Remove(custData);
                  
                    response.Item =true; // Assuming response has an Item property
                    response.StatusCode = (int)StatusCodes.Status200OK;
                }
                else
                {
                    response.Item =false;
                    response.StatusCode = (int)StatusCodes.Status404NotFound; // Customer not found
                }
                _context.SaveChangesAsync();
                _context.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                response.Item = false;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Error Deleting customer: " + ex.Message; // Optionally log the exception
            }

            return response;
        }

        public async Task<IEnumerable<RestaurantReviewMasterModel>> GetAllRestaurantReviewAsync()
        {
            var response = new ResponseContext<RestaurantReviewMasterModel>();

            try
            {
                // Retrieve the customer data
                var custData = await _context.restaurantReviews             
                .Select(x => new RestaurantReviewMasterModel
                {
                    Id = x.Id,
                    RestaurantId = x.RestaurantId,
                    CustomerId = x.CustomerId,
                    Comment = x.Comment,
                    Rating = x.Rating,
                    IsModerated = x.IsModerated,
                    ReviewDate = x.ReviewDate
                })
                .ToListAsync();
                // Set the response with the fetched customer data
                if (custData != null)
                {
                    response.Items = custData; // Assuming response has an Item property
                    response.StatusCode = (int)StatusCodes.Status200OK;
                }
                else
                {
                    response.Items = null;
                    response.StatusCode = (int)StatusCodes.Status404NotFound; // Customer not found
                }
            }
            catch (Exception ex)
            {
                response.Items = null;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Error retrieving customer: " + ex.Message; // Optionally log the exception
            }

            return (IEnumerable<RestaurantReviewMasterModel>)response;
        }

        public async Task<IEnumerable<RestaurantReviewMasterModel>> GetRestaurantReviewAsync(int customerId)
        {
            var response = new ResponseContext<RestaurantReviewMasterModel>();

            try
            {
                      // Retrieve the customer data
                      var custData = await _context.restaurantReviews
                      .Where(x => x.Id == customerId)
                      .Select(x => new RestaurantReviewMasterModel
                      {
                          Id = x.Id,
                          RestaurantId = x.RestaurantId,
                          CustomerId = x.CustomerId,
                          Comment = x.Comment,
                          Rating = x.Rating,
                          IsModerated = x.IsModerated,
                          ReviewDate = x.ReviewDate
                      })
                      .FirstOrDefaultAsync();
                // Set the response with the fetched customer data
                if (custData != null)
                {
                    response.Items = (IEnumerable<RestaurantReviewMasterModel?>)custData; // Assuming response has an Item property
                    response.StatusCode = (int)StatusCodes.Status200OK;
                }
                else
                {
                    response.Items = null;
                    response.StatusCode = (int)StatusCodes.Status404NotFound; // Customer not found
                }
            }
            catch (Exception ex)
            {
                response.Items = null;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Error retrieving customer: " + ex.Message; // Optionally log the exception
            }

            return (IEnumerable<RestaurantReviewMasterModel>)response;
        }

        public async Task<ResponseContext<bool>> UpdateRestaurantReviewAsync(RestaurantReviewMasterModel restaurantReview)
        {
            var response = new ResponseContext<bool>();

            // Begin a transaction scope
           var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Retrieve the existing RestaurantReview by ID (assuming restaurantReview.Id is provided)
                var resreview = await _context.restaurantReviews
                    .FirstOrDefaultAsync(r => r.Id == restaurantReview.Id);

                if (resreview == null)
                {
                    response.StatusCode = (int)StatusCodes.Status404NotFound;
                    response.Message = "Restaurant review not found.";
                    return response;
                }

                // Update fields with new data
                resreview.RestaurantId = restaurantReview.RestaurantId;
                resreview.CustomerId = restaurantReview.CustomerId;
                resreview.Comment = restaurantReview.Comment ?? "Updated comment";  // Replace with actual comment
                resreview.Rating = restaurantReview.Rating;
                resreview.IsModerated = restaurantReview.IsModerated;  // Replace with actual moderation status
                resreview.ReviewDate = DateTime.UtcNow;                // Replace with actual review date if needed

                // Save changes to the existing review
                _context.restaurantReviews.Update(resreview);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                // Set the response to confirm the update
                response.Item = true;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "Restaurant review updated successfully";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                response.Item = false;
                response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                response.Message = $"Error updating restaurant review: {ex.Message}";
            }

            return response;

        }
    }
}
