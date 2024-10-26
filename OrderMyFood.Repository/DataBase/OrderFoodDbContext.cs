using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Repository.DataBase
{
    public class OrderFoodDbContext:DbContext
    {
        public OrderFoodDbContext(DbContextOptions<OrderFoodDbContext> options):base(options)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<MenuItem> menuitems { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<RestaurantReview> restaurantReviews { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<SocialLoginInfo> socialLoginInfos { get; set; }





    }
}
