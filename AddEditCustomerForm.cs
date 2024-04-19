using jordan_rowland_c969.Database;
using jordan_rowland_c969.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jordan_rowland_c969
{
    public partial class AddEditCustomerForm : Form
    {
        bool EditMode = false;
        int customerId { get; set; }
        Global g { get; set; }

        public AddEditCustomerForm(Global global)
        {
            g = global;
            InitializeComponent();
            checkAndDisableSave();
        }

        public AddEditCustomerForm(Global global, Services.Customer customer)
        {
            g = global;
            InitializeComponent();
            EditMode = true;
            customerId = customer.Id;
            lbl_Title.Text = "Update Customer";
            txt_Name.Text = customer.Name;
            txt_Address.Text = customer.Address;
            txt_City.Text = customer.City;
            txt_Country.Text = customer.Country;
            txt_PhoneNumber.Text = customer.Phone;
            checkAndDisableSave();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Services.Customer customer = new Services.Customer()
                {
                    Name = txt_Name.Text,
                    Address = txt_Address.Text,
                    City = txt_City.Text,
                    Country = txt_Country.Text,
                    Phone = txt_PhoneNumber.Text,
                };

                if (EditMode)
                {
                    customer.Id = customerId;
                    customer.Update(g);
                }
                else customer.Create(g);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e) => Close();

        private void checkAndDisableSave()
        {
            List<string> fields = new List<string>()
            {
                txt_Name.Text,
                txt_Address.Text,
                txt_City.Text,
                txt_Country.Text,
                txt_PhoneNumber.Text,
            };
            foreach (string field in fields)
            {
                if (field == "")
                {
                    btn_Save.Enabled = false;
                    break;
                }
                else btn_Save.Enabled = true;
            }
        }


        private void txt_Name_TextChanged(object sender, EventArgs e) => checkAndDisableSave();
        private void txt_Address_TextChanged(object sender, EventArgs e) => checkAndDisableSave();
        private void txt_City_TextChanged(object sender, EventArgs e) => checkAndDisableSave();
        private void txt_Country_TextChanged(object sender, EventArgs e) => checkAndDisableSave();
        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e) => checkAndDisableSave();
    }
}
