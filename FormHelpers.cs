using jordan_rowland_c969.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Drawing;


namespace jordan_rowland_c969
{
    public static class FormHelpers
    {
        public static void ConvertDTFieldsToLocal(DataTable dt)
        {

            string[] dtFields = new string[] { "start", "end", "createDate", "lastUpdate" };
            Debug.WriteLine(TimeZoneInfo.Local);
            foreach (DataRow row in dt.Rows)
            {
                foreach (string field in dtFields)
                {
                    if (row.Table.Columns.Contains(field)) 
                        row[field] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)row[field], TimeZoneInfo.Local);
                }
            }
        }


        public static void FillDataGrid(DataGridView dataGrid, MySqlDataAdapter adp)
        {
            DataTable dt;
            dt = new DataTable();
            adp.Fill(dt);
            BindingSource bs = new BindingSource() { DataSource = dt };
            dataGrid.DataSource = bs;

            ConvertDTFieldsToLocal(dt);

            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.ReadOnly = true;
            dataGrid.MultiSelect = false;
            //dataGrid.AutoResizeColumns();
        }


        public static List<ComboItem> GetUserDataSource()
        {
            List<UserStruct> users = User.GetUsers();
            List<ComboItem> userDataSource = new List<ComboItem>();
            foreach (var c in users) userDataSource.Add(new ComboItem { Id = c.Id, Text = c.Name });
            return userDataSource;
        }


        public static class Queries
        {
            public static string CustomerMainQuery { get; } = (
                "SELECT " +
                "cu.customerId AS 'Customer ID' " +
                ", customerName AS Name " +
                ", a.address AS Address " +
                ", ci.city AS City " +
                ", co.country AS Country " +
                ", cu.createDate AS 'Creation Date' " +
                ", cu.lastUpdate AS 'Last Updated' " +
                ", active AS 'Is Active' " +
                "FROM customer cu " +
                "INNER JOIN address a on a.addressID = cu.addressId " +
                "INNER JOIN city ci on ci.cityId = a.cityId " +
                "INNER JOIN country co on co.countryID = ci.countryId " +
                ";"
            );


            public static string AppointmentMainQuery { get; } = (
                "SELECT " +
                "c.customerName Name, " +
                "u.userName 'User Name', " +
                "type 'Type', title 'Title', description 'Description', " +
                "location 'Location', contact 'Contact', url 'Url', " +
                "start 'Start Time', " +
                "end 'End Time' " +
                "FROM appointment a " +
                "INNER JOIN customer c on c.customerId = a.customerId " +
                "INNER JOIN user u on u.userId = a.userId "
            );


            public static string AppointmentMonthlyQuery(DateTime now, string month)
            {
                return $"{AppointmentMainQuery} WHERE start LIKE '{now.Year}-{month}%';";
            }


            public static string AppointmentDailyQuery(DateTime selectedDay)
            {
                return $"{AppointmentMainQuery} WHERE start between " +
                $"DATE('{selectedDay:yyyy-MM-dd}') " +
                $"AND DATE('{selectedDay.AddHours(24):yyyy-MM-dd}') ";
            }
        }

    }

    public class ComboItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
