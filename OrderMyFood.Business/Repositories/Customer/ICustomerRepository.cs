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
         Task<ResponseContext<int>> RegisterCustomerAsync(CustomerMasterModel customer);
         Task<ResponseContext<bool>> UpdateCustomerAsync(CustomerMasterModel customer);
         Task<ResponseContext<bool>> UnregisterCustomerAsync(int customerId);
         Task<ResponseContext<CustomerMasterModel>> GetCustomerAsync(int customerId);


    }
}
