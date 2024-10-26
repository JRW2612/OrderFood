using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Repository.DataBase
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; } // Foreign key to MenuItem
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Price per item

        // Navigation property
        public virtual MenuItem MenuItem { get; set; }
    }
}
