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
    public partial class Orders : Form
    {
        private String customerID;
        private String customerName;
        private int orderID;
        public Orders(string customerID, string customerName)
        {
            InitializeComponent();
            this.customerID = customerID;
            this.customerName = customerName;
        }
        private bool isOrderDateValid()
        {
            if (numOrderAmount.Value < 1)
            {
                MessageBox.Show("Please specify an order amount");
                return false;
            }
            return true;
        }
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            
            // Ensure the required input is present.
            if (isOrderDateValid())
            {
                // Create the connection.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    // Create SqlCommand and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspPlaceNewOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add the @CustomerID input parameter, which was obtained from uspNewCustomer.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerID"].Value = this.customerID;

                        // Add the @OrderDate input parameter.
                        sqlCommand.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@OrderDate"].Value = dtpOrderDate.Value;

                        // Add the @Amount order amount input parameter.
                        sqlCommand.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int));
                        sqlCommand.Parameters["@Amount"].Value = numOrderAmount.Value;

                        // Add the @Status order status input parameter.
                        // For a new order, the status is always O (open).
                        sqlCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Char, 1));
                        sqlCommand.Parameters["@Status"].Value = "O";

                        // Add the return value for the stored procedure, which is  the order ID.
                        sqlCommand.Parameters.Add(new SqlParameter("@RC", SqlDbType.Int));
                        sqlCommand.Parameters["@RC"].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            //Open connection.
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();

                            // Display the order number.
                            this.orderID = (int)sqlCommand.Parameters["@RC"].Value;
                            MessageBox.Show("Order number " + this.orderID + " has been submitted.");
                        }
                        catch
                        {
                            MessageBox.Show("Order could not be placed.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
        private void btnFindOrders_Click(object sender, EventArgs e)
        {
            Form frm = new FindOrder();
            frm.ShowDialog();
        }
        private void btnOrderFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
