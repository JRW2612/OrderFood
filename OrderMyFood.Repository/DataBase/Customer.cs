using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Repository.DataBase
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SocialLoginProvider { get; set; }

        public static implicit operator Customer(CustomerMasterModel v)
        {
            throw new NotImplementedException();
        }
    }
}
