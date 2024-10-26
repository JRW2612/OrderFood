using OrderMyFood.Business.Repositories.Customer;
using OrderMyFood.DataModels;
using OrderMyFood.DataModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Service.Customer
{
    public interface ICustomerService : ICustomerRepository
    {
        public Task<ResponseContext<CustomerMasterModel>> GetCustomerAsync(int customerId);
        public Task<ResponseContext<int>> RegisterCustomerAsync(CustomerMasterModel customer);
        public Task<ResponseContext<bool>> UnregisterCustomerAsync(int customerId);
        public Task<ResponseContext<bool>> UpdateCustomerAsync(CustomerMasterModel customer);
       
    }
}
