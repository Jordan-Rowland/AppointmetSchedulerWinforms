using jordan_rowland_c969.Database;
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
        public string Phone { get; set; }

        public void Create(Global g) => // Capture the exception if it bubbles up
            Database.Customer.Create(g, this);

        public static Customer GetCustomer(int customerId)
        {
            // Capture the exception if it bubbles up
            CustomerStruct customerStruct = Database.Customer.GetCustomer(customerId);
            return new Customer()
            {
                Id = customerStruct.Id,
                Name = customerStruct.Name,
                Address = customerStruct.Address,
                City = customerStruct.City,
                Country = customerStruct.Country,
                Phone = customerStruct.Phone,
            };
        }

        //public static List<Customer> GetCustomers()
        //{
        //    // Capture the exception if it bubbles up
        //    CustomerStruct List<customerStruct> = Database.Customer.GetCustomers(customerId);
        //}

        public void Update(Global g) => // Capture the exception if it bubbles up
            Database.Customer.Update(g, this);

        public static void Delete(int customerId) => // Capture the exception if it bubbles up
            Database.Customer.Delete(customerId);
    }
}
