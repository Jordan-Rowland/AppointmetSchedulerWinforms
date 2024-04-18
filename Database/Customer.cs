using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace jordan_rowland_c969.Database
{
    public static class Customer
    {
        public static void CreateUpdate(Global g, Services.Customer customer, DBAction action)
        {
            MySqlCommand cmd = new MySqlCommand();
            int countryId = Country.Create(g, customer.Country);
            int cityId = City.Create(g, customer.City, countryId);
            int addressId = Address.Create(g, customer.Address, cityId, customer.Phone);
            if (action == DBAction.CREATE)
            {
                // Try/catch here/ but maybe do it above instead
                cmd = new MySqlCommand(
                    "INSERT INTO customer (" +
                    "customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy" +
                    ") VALUES (" +
                    "@customerName, @addressId, 1, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                    ")",
                    DBConnection.Conn);
            }
            else if (action == DBAction.UPDATE)
            {
                cmd = new MySqlCommand(
                    "UPDATE customer " +
                    "SET customerName = @customerName, " +
                    "addressId = @addressId, " +
                    "lastUpdate = @lastUpdate, " +
                    "lastUpdateBy = @lastUpdateBy " +
                    "WHERE customerID = @customerId",
                    DBConnection.Conn);
            }
                using (cmd)
            {
                cmd.Parameters.Add("@customerName", MySqlDbType.VarChar, 50).Value = customer.Name;
                cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                
                if (action == DBAction.CREATE)
                {
                    cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                }
                else if (action == DBAction.UPDATE)
                    cmd.Parameters.Add("@customerId", MySqlDbType.VarChar, 50).Value = customer.Id;
                
                cmd.ExecuteNonQuery();
            }
        }


        public static CustomerStruct GetCustomer(int customerId)
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT " +
                "customerId " +
                ", customerName" +
                ", a.address" +
                ", ci.city" +
                ", co.country" +
                ", a.phone " +
                "FROM customer AS c " +
                "INNER JOIN address a on a.addressId = c.addressId " +
                "INNER JOIN city ci on ci.cityId = a.cityId " +
                "INNER JOIN country co on co.countryId = ci.countryId " +
                "WHERE customerId = @customerId",
                DBConnection.Conn);
            query.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;
            MySqlDataReader reader = query.ExecuteReader();

            reader.Read();
            CustomerStruct customer = new CustomerStruct()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2),
                City = reader.GetString(3),
                Country = reader.GetString(4),
                Phone = reader.GetString(5),
            };
            reader.Close();
            return customer;
        }


        public static List<CustomerStruct> GetCustomers()
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT " +
                "customerId " +
                ", customerName" +
                ", a.address" +
                ", ci.city" +
                ", co.country" +
                ", a.phone " +
                "FROM customer AS c " +
                "INNER JOIN address a on a.addressId = c.addressId " +
                "INNER JOIN city ci on ci.cityId = a.cityId " +
                "INNER JOIN country co on co.countryId = ci.countryId",
                DBConnection.Conn);
            MySqlDataReader reader = query.ExecuteReader();

            List<CustomerStruct> customers = new List<CustomerStruct>();
            while (reader.Read())
            {
                customers.Add(new CustomerStruct()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Address = reader.GetString(2),
                    City = reader.GetString(3),
                    Country = reader.GetString(4),
                    Phone = reader.GetString(5),
                });

            }
            reader.Close();
            return customers;
        }


        public static void Delete(int customerId)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM customer WHERE customerId = @customerId", DBConnection.Conn))
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;
                cmd.ExecuteNonQuery();
            }
        }
    }

    public struct CustomerStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
