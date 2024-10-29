using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderMyFood.Business.Repositories.Customer;
using OrderMyFood.DataModels;
using OrderMyFood.Repository.DataBase;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly OrderFoodDbContext _context;

        public CustomerRepository(OrderFoodDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseContext<CustomerMasterModel>> GetCustomerAsync(int customerId)
        {
            var response = new ResponseContext<CustomerMasterModel>();

            try
            {
                // Retrieve the customer data
                var custData = await _context.customers
                    .Where(x => x.Id == customerId)
                    .Select(x => new CustomerMasterModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        PasswordHash = x.PasswordHash,
                        SocialLoginProvider = x.SocialLoginProvider
                    })
                    .FirstOrDefaultAsync(); // Use FirstOrDefaultAsync to get a single record

                // Set the response with the fetched customer data
                if (custData != null)
                {
                    response.Item = custData; // Assuming response has an Item property
                    response.StatusCode = (int)StatusCodes.Status200OK;
                }
                else
                {
                    response.Item = null;
                    response.StatusCode = (int)StatusCodes.Status404NotFound; // Customer not found
                }
            }
            catch (Exception ex)
            {
                response.Item = null;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Error retrieving customer: " + ex.Message; // Optionally log the exception
            }

            return response;
        }

       

        public async Task<ResponseContext<int>> RegisterCustomerAsync(CustomerMasterModel customer)
        {
            var response = new ResponseContext<int>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Create and add the Customer
                var cust = new DataBase.Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    PasswordHash = customer.PasswordHash,
                    SocialLoginProvider = customer.SocialLoginProvider
                };

                await _context.customers.AddAsync(cust);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                // Set the response to include the newly created Customer ID
                response.Item = cust.Id;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "Customer created successfully";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                response.Item = 0;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Customer not created: " + ex.Message;
            }

            return response;
        }


        public async Task<ResponseContext<bool>> UnregisterCustomerAsync(int customerId)
        {
            var response = new ResponseContext<bool>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Retrieve the order entity including related OrderItems
                var custData = await _context.customers
                    .FirstOrDefaultAsync(x => x.Id == customerId);

                if (custData == null)
                {
                    response.Item = false;
                    response.StatusCode = (int)StatusCodes.Status404NotFound;
                    return response;
                }

                // Remove the order and its related order items
                _context.customers.Remove(custData);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                // Set response as success
                response.Item = true;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "Customer Removed";
                return response;
            }
            catch
            {
                await transaction.RollbackAsync();
                response.Item = false;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Unable to Remove Customer";

            }

            return response;
        }

        public async Task<ResponseContext<bool>> UpdateCustomerAsync(CustomerMasterModel customer)
        {
            var response = new ResponseContext<bool>();

            // Begin a transaction scope
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Fetch the existing customer from the database
                var existingCustomer = await _context.customers.FindAsync(customer.Id);

                if (existingCustomer == null)
                {
                    response.Item = false;
                    response.StatusCode = (int)StatusCodes.Status404NotFound;
                    response.Message = "Customer not found";
                    return response;
                }

                // Update the customer properties
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.PasswordHash = customer.PasswordHash;
                existingCustomer.SocialLoginProvider = customer.SocialLoginProvider;

                // Save the changes
                _context.customers.Update(existingCustomer);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                // Set the response to indicate success
                response.Item = true;
                response.StatusCode = (int)StatusCodes.Status200OK;
                response.Message = "Customer updated successfully";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                response.Item = false;
                response.StatusCode = (int)StatusCodes.Status400BadRequest;
                response.Message = "Customer not updated: " + ex.Message;
            }

            return response;
        }

    }

}
