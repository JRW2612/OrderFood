using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.Repositories.Customer
{
    public interface ICustomerRepository
    {
        public Task<ResponseContext<int>> RegisterCustomerAsync(CustomerMasterModel customer);
        public Task<ResponseContext<bool>> UpdateCustomerAsync(CustomerMasterModel customer);
        public Task<ResponseContext<bool>> UnregisterCustomerAsync(int customerId);
        public Task<ResponseContext<CustomerMasterModel>> GetCustomerAsync(int customerId);
    }
}
