using jordan_rowland_c969.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Database
{
    public static class Address
    {
        //public static AddressStruct getAddress(int addressId)
        //{

        //}

        public static void Create()
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO customer (" +
                // Update to insert correct values for loggedin user
                "customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (" +
                "@customerName, @addressId, 1, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                ")",
                DBConnection.Conn))
            {
                //cmd.Parameters.Add("@customerName", MySqlDbType.VarChar, 50).Value = customer.Name;
                cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = 1;
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = "test";
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = "test";
                cmd.ExecuteNonQuery();
                //return true;
            }
        }

    }

        //public struct AddressStruct
        //{
        //    public int Id { get; set; }
        //    public string Address { get; set; }
        //    public string Address2 { get; set; }
        //    public int CityId { get; set; }
        //    public string PostalCode { get; set; }
        //    public string Phone { get; set; }

        //public AddressStruct(int id, string address, string address2,
        //    int cityId, string postalCode, string phone)
        //{
        //    Id = id;
        //    Address = address;
        //    Address2 = address2;
        //    CityId = cityId;
        //    PostalCode = postalCode;
        //    Phone = phone;
        //}
    //}
}