using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Repository.DataBase
{
    public class SocialLoginInfo
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // Foreign key to Customer
        public string Provider { get; set; } // e.g., Google, Facebook
        public string ProviderUserId { get; set; } // Unique ID from the provider

        // Navigation property
        public virtual Customer Customer { get; set; }
    }
}

