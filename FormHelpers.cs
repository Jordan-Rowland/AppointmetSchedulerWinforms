using jordan_rowland_c969.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            //MySqlDataAdapter adp = new MySqlDataAdapter(query, DBInit.Conn);

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
        }


        public static List<ComboItem> GetUserDataSource()
        {
            List<UserStruct> users = User.GetUsers();
            List<ComboItem> userDataSource = new List<ComboItem>();
            foreach (var c in users) userDataSource.Add(new ComboItem { Id = c.Id, Text = c.Name });
            return userDataSource;
        }
    }

    public class ComboItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
