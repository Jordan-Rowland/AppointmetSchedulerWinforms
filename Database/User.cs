using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Database
{
    internal class User
    {
        public static List<UserStruct> GetUsers()
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT userId, userName FROM user",
                DBConnection.Conn);
            MySqlDataReader reader = query.ExecuteReader();

            List<UserStruct> users = new List<UserStruct>();
            while (reader.Read())
            {
                users.Add(new UserStruct()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                });

            }
            reader.Close();
            return users;
        }
    }

    public struct UserStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
