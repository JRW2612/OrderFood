using OrderMyFood.Business.Repositories.Customer;
using OrderMyFood.Business.Service.Customer;
using OrderMyFood.DataModels;
using OrderMyFood.DataModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Business.ServiceLogic.Customer
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseContext<CustomerMasterModel>> GetCustomerAsync(int customerId)
        {
            var response = await _repository.GetCustomerAsync(customerId);
            return response;
        }

        public async Task<ResponseContext<int>> RegisterCustomerAsync(CustomerMasterModel customer)
        {
            var response = await _repository.RegisterCustomerAsync(customer);
            return response;
        }

        public async Task<ResponseContext<bool>> UnregisterCustomerAsync(int customerId)
        {
            var response = await _repository.UnregisterCustomerAsync(customerId);
            return response;
        }

        public async Task<ResponseContext<bool>> UpdateCustomerAsync(CustomerMasterModel customer)
        {
            var response = await _repository.UpdateCustomerAsync(customer);
            return response;
        }
    }
}
