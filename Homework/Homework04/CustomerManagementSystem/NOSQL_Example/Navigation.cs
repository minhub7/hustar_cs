using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NOSQL_Example
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String loginID = txtCustomerID.Text;
            String loginName = txtName.Text;

            using(SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                connection.Open();
                String sql = $"SELECT * FROM Sales.Customer WHERE CustomerID='{loginID}' AND CustomerName='{loginName}';";
                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        Form frm = new Orders(loginID, loginName);
                        frm.ShowDialog();
                    }
                    else MessageBox.Show("Invalid CustomerID and Name...\n\nPlease create account");
                }
                connection.Close();
            }
        }
        private void btnCreateID_Click(object sender, EventArgs e)
        {
            Form frm = new NewCustomer();
            frm.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
