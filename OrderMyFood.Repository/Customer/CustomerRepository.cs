using OrderMyFood.Business.Repositories.Customer;
using OrderMyFood.DataModels;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<ResponseContext<CustomerMasterModel>> GetCustomerAsync(int customerId)
        {
            var response=await GetCustomerAsync(customerId);
            return response;
        }

        public async Task<ResponseContext<int>> RegisterCustomerAsync(CustomerMasterModel customer)
        {
           var response=await RegisterCustomerAsync(customer);
            return response;
        }

        public async Task<ResponseContext<bool>> UnregisterCustomerAsync(int customerId)
        {
           var response= await UnregisterCustomerAsync(customerId);
            return response;
        }

        public async Task<ResponseContext<bool>> UpdateCustomerAsync(CustomerMasterModel customer)
        {
         var response=await UpdateCustomerAsync(customer);
            return response;

        }
    }

}
