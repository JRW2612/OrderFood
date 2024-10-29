using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMyFood.Business.Service.Customer;
using OrderMyFood.Business.Service.Order;

namespace OrderMyFood.Service.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OrderMyFood.DataModels;
    using System.Threading.Tasks;
    using static OrderMyFood.DataModels.Helper.Helper;

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Route to get a customer by ID
        [HttpGet("{customerId:int}")]
        public async Task<ActionResult> GetCustomer(int customerId)
        {
            var response = await _customerService.GetCustomerAsync(customerId);
            return Ok(response);
        }

        // Route to register a new customer
        [HttpPost("register")]
        public async Task<ActionResult> RegisterCustomer([FromBody] CustomerMasterModel customer)
        {
            var response = await _customerService.RegisterCustomerAsync(customer);
            return Ok(response);
        }

        // Route to unregister a customer by ID
        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> UnregisterCustomer(int customerId)
        {
            var response = await _customerService.UnregisterCustomerAsync(customerId);
            return Ok(response);
        }

        // Route to update an existing customer
        [HttpPut("update")]
        public async Task<ActionResult> UpdateCustomer([FromBody] CustomerMasterModel customer)
        {
            var response = await _customerService.UpdateCustomerAsync(customer);
            return Ok(response);
        }

       
    }
}
