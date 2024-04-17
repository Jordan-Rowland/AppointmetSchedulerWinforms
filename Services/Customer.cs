using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jordan_rowland_c969.Services
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public bool Create() => Database.Customer.Create(this);


        //public static bool Create(Dictionary<string, string> customerData)
        //{
        //    Customer customer = new Customer()
        //    {

        //    }
        //    return Database.Customer.Create(customer);
        //}

    }

}


