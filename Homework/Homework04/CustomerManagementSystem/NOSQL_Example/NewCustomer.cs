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
    public partial class NewCustomer : Form
    {
        public NewCustomer()
        {
            InitializeComponent();
        }
        private bool isCustomerNameValid()
        {
            if (txtNewCustomerName.Text == ""){
                MessageBox.Show("Please enter a Name");
                return false;
            }
            return true;
        }
        private bool isCustomerIDValid()
        {
            if (txtNewCustomerID.Text == "")
            {
                MessageBox.Show("Please enter a ID");
                return false;
            }
            return true;
        }
        private void ClearForm()
        {
            txtNewCustomerName.Clear();
            txtNewCustomerID.Clear();
        }
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (isCustomerIDValid() && isCustomerNameValid())
            {
                // Create the connection.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    connection.Open();
                    String sql = $"INSERT INTO Sales.Customer(CustomerID,CustomerName,YTDOrders,YTDSales) Values('{txtNewCustomerID.Text}','{txtNewCustomerName.Text}',0,0);";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        //sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for the stored procedure and specify what to use as its value.
                        //sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", txtNewCustomerID.Text));
                        //sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", txtNewCustomerName.Text));
                        //sqlCommand.Parameters["@CustomerID"].Value = SqlDbType.NVarChar, 40;
                        //sqlCommand.Parameters["@CustomerName"].Value = txtNewCustomerName.Text;

                        try
                        {
                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Complete create new account!");

                            // Customer ID is an IDENTITY value from the database.
                            //this.parsedCustomerID = (String)sqlCommand.Parameters["@CustomerID"].Value;

                            // Put the Customer ID value into the read-only text box.
                            //this.txtNewCustomerID.Text = Convert.ToString(sqlCommand.Parameters["@CustomerID"].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Customer ID was not returned. Account could not be created.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnAddFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
