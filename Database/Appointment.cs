using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using jordan_rowland_c969.Services;
using MySql.Data.MySqlClient;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace jordan_rowland_c969.Database
{
    public static class Appointment
    {

        public static void Create(Global g, Services.Appointment appointment)
        {
            // Try/catch here/ but maybe do it above instead
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO appointment (" +
                "customerId, userId, title, description, location, contact, " +
                "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (" +
                "@customerId, @userId, @title, @description, @location, @contact, " +
                "@type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                ")",
                DBConnection.Conn))
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = appointment.CustomerId;
                cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = appointment.UserId;
                cmd.Parameters.Add("@title", MySqlDbType.VarChar, 50).Value = appointment.Title;
                cmd.Parameters.Add("@description", MySqlDbType.VarChar, 50).Value = appointment.Description;
                cmd.Parameters.Add("@location", MySqlDbType.VarChar, 50).Value = appointment.Location;
                cmd.Parameters.Add("@contact", MySqlDbType.VarChar, 50).Value = appointment.Contact;
                cmd.Parameters.Add("@type", MySqlDbType.VarChar, 50).Value = appointment.Type;
                cmd.Parameters.Add("@url", MySqlDbType.VarChar, 50).Value = appointment.Url;
                cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = appointment.Start;
                cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = appointment.Start.AddMinutes(45);
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                cmd.ExecuteNonQuery();
            }
        }

            public static AppointmentStruct GetAppointment(int appointmentId)
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT " +
                "a.appointmentID " +
                ", a.customerId" +
                ", a.userId" +
                ", title" +
                ", description" +
                ", location" +
                ", contact" +
                ", type" +
                ", url" +
                ", start" +
                ", u.userName" +
                ", c.customerName " +
                "FROM appointment a " +
                "INNER JOIN user u on u.userId = a.userId " +
                "INNER JOIN customer c on c.customerId = a.customerId " +
                "WHERE a.appointmentId = @appointmentId",
                DBConnection.Conn);
            query.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            MySqlDataReader reader = query.ExecuteReader();

            reader.Read();
            AppointmentStruct appointment = new AppointmentStruct()
            {
                AppointmentId = reader.GetInt32(0),
                CustomerId = reader.GetInt32(1),
                UserId = reader.GetInt32(2),
                Title = reader.GetString(3),
                Description = reader.GetString(4),
                Location = reader.GetString(5),
                Contact = reader.GetString(6),
                Type = reader.GetString(7),
                Url = reader.GetString(8),
                Start = reader.GetDateTime(9),
                UserName = reader.GetString(10),
                CustomerName = reader.GetString(11),
            };
            reader.Close();
            return appointment;
        }

        public static void Update(Global g, Services.Appointment appointment)
        {
            // Try/catch here/ but maybe do it above instead
            using (MySqlCommand cmd = new MySqlCommand(
                "UPDATE appointment SET " +
                "title = @title, " +
                "description = @description, " +
                "location = @location, " +
                "contact = @contact, " +
                "type = @type, " +
                "url = @url, " +
                "start = @start, " +
                "end = @end, " +
                "createDate = @createDate, " +
                "createdBy = @createdBy, " +
                "lastUpdate = @lastUpdate, " +
                "lastUpdateBy = @lastUpdateBy " +
                "WHERE appointmentId = @appointmentId",
                DBConnection.Conn))
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = appointment.CustomerId;
                cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = appointment.UserId;
                cmd.Parameters.Add("@title", MySqlDbType.VarChar, 50).Value = appointment.Title;
                cmd.Parameters.Add("@description", MySqlDbType.VarChar, 50).Value = appointment.Description;
                cmd.Parameters.Add("@location", MySqlDbType.VarChar, 50).Value = appointment.Location;
                cmd.Parameters.Add("@contact", MySqlDbType.VarChar, 50).Value = appointment.Contact;
                cmd.Parameters.Add("@type", MySqlDbType.VarChar, 50).Value = appointment.Type;
                cmd.Parameters.Add("@url", MySqlDbType.VarChar, 50).Value = appointment.Url;
                cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = appointment.Start;
                cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = appointment.Start.AddMinutes(45);
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                cmd.Parameters.Add("@appointmentId", MySqlDbType.VarChar, 50).Value = appointment.AppointmentId;
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int appointmentId)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM appointment WHERE appointmentId = @appointmentId", DBConnection.Conn))
            {
                cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
                cmd.ExecuteNonQuery();
            }
        }
    }

    public struct AppointmentStruct
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
    }
}
