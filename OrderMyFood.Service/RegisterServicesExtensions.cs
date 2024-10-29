using OrderMyFood.Business.Repositories.Customer;
using OrderMyFood.Business.Repositories.Order;
using OrderMyFood.Business.Repositories.Restaurant;
using OrderMyFood.Business.Service.Customer;
using OrderMyFood.Business.Service.Order;
using OrderMyFood.Business.Service.Restaurant;
using OrderMyFood.Business.ServiceLogic.Customer;
using OrderMyFood.Business.ServiceLogic.Order;
using OrderMyFood.Business.ServiceLogic.Restaurant;
using OrderMyFood.Repository.Customer;
using OrderMyFood.Repository.Order;
using OrderMyFood.Repository.Restaurant;

namespace OrderMyFood.Service
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
     
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IRestaurantService, RestaurantService>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            return services;
        }
    }
}
