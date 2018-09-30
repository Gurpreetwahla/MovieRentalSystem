using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public partial class EditCustomer : Form
    {
        string Id;

        public EditCustomer()
        {
            InitializeComponent();
        }

        public EditCustomer(string Id)
        {
            this.Id = Id;
            DataTable table = new Database().findcustomerbyid(Id);
            InitializeComponent();
            firstname.Text = table.Rows[0]["FirstName"].ToString();
            lastname.Text = table.Rows[0]["LastName"].ToString();
            address.Text = table.Rows[0]["Address"].ToString();
            phoneno.Text = table.Rows[0]["Phone"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (firstname.Text == "" || lastname.Text == "" || address.Text == "" || phoneno.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Database database = new Database();
                database.editcustomer(firstname.Text, lastname.Text, address.Text, phoneno.Text, Id);
                MessageBox.Show("Customer Updated");
                Dispose();
            }
        }
    }
}
