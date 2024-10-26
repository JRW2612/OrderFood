using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Repository.DataBase
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Foreign key to Order
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // e.g., Credit Card, PayPal, COD
        public bool IsSuccessful { get; set; }
        public DateTime PaymentDate { get; set; }

        // Navigation property
        public virtual Order Order { get; set; }
    }
}
