using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.DataModels
{
    public class MenuItemMasterModel
    {
        public int Id { get; set; } // Unique identifier for the menu item
        public int RestaurantId { get; set; } // Foreign key to the Restaurant
        public string Name { get; set; } // Name of the menu item
        public string Description { get; set; } // Description of the menu item
        public decimal Price { get; set; } // Price of the menu item
        public string Cuisine { get; set; } // Type of cuisine (e.g., Italian, Chinese)
        public bool IsAvailable { get; set; } // Indicates if the item is currently available
        public string DietaryInfo { get; set; } // Dietary information (e.g., Vegan, Gluten-Free)

        // Navigation property
        public virtual RestaurantMasterModel Restaurant { get; set; } // Navigation property to the Restaurant
    }
}
