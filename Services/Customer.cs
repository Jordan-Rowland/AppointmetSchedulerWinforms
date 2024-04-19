using jordan_rowland_c969.Database;
using System;
using System.Collections.Generic;
using System.Linq;


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


        public void Create(Global g)
        {
            // Capture the exception if it bubbles up
            ValidateIncomingData();
            Database.Customer.CreateUpdate(g, this, DBAction.CREATE);
    }


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

        
        public void Update(Global g)
        {
            // Capture the exception if it bubbles up
            ValidateIncomingData();
            Database.Customer.CreateUpdate(g, this, DBAction.UPDATE);
        }


        public static void Delete(int customerId) => // Capture the exception if it bubbles up
            Database.Customer.Delete(customerId);


        public void ValidateIncomingData()
        {
            Dictionary<string, string> fieldsToValidate = new Dictionary<string, string>()
            {
                ["Name"] = Name,
                ["Address"] = Address,
                ["Phone"] = Phone,
            };

            List<string> invalidFields = new List<string>();

            foreach (KeyValuePair<string, string> field in fieldsToValidate)
                if (field.Value == "") invalidFields.Add(field.Key);

            if (invalidFields.Any())
                throw new Exception(
                    $"The following fields can not be empty: {string.Join(", ", invalidFields)}"
                );

            // Capture the exception if it bubbles up
            ValidatePhoneNumber(Phone);
        }


        public static void ValidatePhoneNumber(string phone)
        {
            foreach (char s in phone)
            {
                string str = s.ToString();
                if (!int.TryParse(str, out int _))
                    if (str != "-")
                        throw new Exception("Phone Number can only contain digits and dashes.");
            }
        }
    }
}
