using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.DataModels
{
    public class OrderMasterModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
       public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItemMasterModel> OrderItems { get; set; }
    }
}
