using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Services
{
    public static class Login
    {
        internal static (bool result, User user) ValidateLogin(
            MySqlConnection conn, string username, string password)
        {
            MySqlCommand query = new MySqlCommand(
                $"SELECT * FROM user WHERE userName = @username and password = @password",
                conn
            );
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                return (true, new User() {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                });
            }
            reader.Close();
            return (false, new User());
        }
    }
}
