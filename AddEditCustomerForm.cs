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
        }

        private void btn_Save_Click(object sender, EventArgs e)
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

        private void btn_Cancel_Click(object sender, EventArgs e) => Close();

        private void AddEditCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
