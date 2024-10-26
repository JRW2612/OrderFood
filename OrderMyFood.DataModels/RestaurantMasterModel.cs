using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.DataModels
{
    public class RestaurantMasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public decimal AverageRating { get; set; }
        public decimal PriceRange { get; set; }
    }
}
