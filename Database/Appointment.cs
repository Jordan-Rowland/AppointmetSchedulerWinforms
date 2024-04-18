using System;
using System.Collections.Generic;
using System.Diagnostics;

using MySql.Data.MySqlClient;


namespace jordan_rowland_c969.Database
{
    public static class Appointment
    {
        public static void CreateUpdate(Global g, Services.Appointment appointment, DBAction action)
        {
            MySqlCommand cmd = new MySqlCommand();
            if (action == DBAction.CREATE)
            {
                cmd = new MySqlCommand(
                "INSERT INTO appointment (" +
                "customerId, userId, title, description, location, contact, " +
                "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (" +
                "@customerId, @userId, @title, @description, @location, @contact, " +
                "@type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                ")",
                DBConnection.Conn);
            }
            else if (action == DBAction.UPDATE)
            {
                cmd = new MySqlCommand(
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
                    DBConnection.Conn);
            }
            // Try/catch here/ but maybe do it above instead
            using (cmd)
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = appointment.CustomerId;
                cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = appointment.UserId;
                cmd.Parameters.Add("@title", MySqlDbType.VarChar, 50).Value = NormalizeStringLength(appointment.Title, 255, defaultValue: "not needed");
                cmd.Parameters.Add("@description", MySqlDbType.VarChar, 50).Value = NormalizeStringLength(appointment.Description, defaultValue: "not needed");
                cmd.Parameters.Add("@location", MySqlDbType.VarChar, 50).Value = NormalizeStringLength(appointment.Location, defaultValue: "not needed");
                cmd.Parameters.Add("@contact", MySqlDbType.VarChar, 50).Value = NormalizeStringLength(appointment.Contact, defaultValue: "not needed");
                cmd.Parameters.Add("@type", MySqlDbType.VarChar, 50).Value = appointment.Type;
                cmd.Parameters.Add("@url", MySqlDbType.VarChar, 50).Value = NormalizeStringLength(appointment.Url, 255, defaultValue: "not needed");
                cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(appointment.Start, TimeZoneInfo.Local);
                cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(appointment.Start.AddMinutes(45), TimeZoneInfo.Local);
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = g.User.Username;

                if (action == DBAction.CREATE)
                {
                    cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = g.User.Username;
                }
                else if (action == DBAction.UPDATE)
                    cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointment.AppointmentId;

                cmd.ExecuteNonQuery();
            }
        }

        private static string NormalizeStringLength(string value, int? maxLength = null, string defaultValue = "")
        {
            if (value == "") return defaultValue;
            if (value.Length < maxLength || maxLength == null) return value;
            return value.Substring(0, maxLength.Value);
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

        // Might not need this
        public static List<AppointmentStruct> GetAppointments()
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
                DBConnection.Conn
            );

            MySqlDataReader reader = query.ExecuteReader();
            List<AppointmentStruct> appointments = new List<AppointmentStruct>();
            while (reader.Read())
            {
                appointments.Add(new AppointmentStruct()
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
                });

            }
            reader.Close();
            return appointments;
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


        public static bool GetOverlappingAppointments(DateTime utcStartTime)
        {
            string strStartTime = utcStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndTime = utcStartTime.AddMinutes(45).ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand query = new MySqlCommand(
                $"SELECT * FROM appointment WHERE (" +
                $"start < '{strStartTime}' AND '{strStartTime}' < end" +
                $") OR (" +
                $"start < '{strEndTime}' AND '{strEndTime}' < end" +
                $")",
                DBConnection.Conn
            );

            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                Debug.WriteLine("\n\nGOT ONE\n\n");
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }


        public static bool GetOverlappingAppointments(DateTime utcStartTime, int appointmentID)
        {
            string strStartTime = utcStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndTime = utcStartTime.AddMinutes(45).ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand query = new MySqlCommand(
                $"SELECT * FROM appointment WHERE ((" +
                $"start < '{strStartTime}' AND '{strStartTime}' < end" +
                $") OR (" +
                $"start < '{strEndTime}' AND '{strEndTime}' < end" +
                $")) AND appointmentId != {appointmentID}",
                DBConnection.Conn
            );

            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                Debug.WriteLine($"\n\nGOT ONE {reader.GetInt32(0)}\n\n");
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
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


    //public enum DBAction { CREATE, UPDATE };
}
