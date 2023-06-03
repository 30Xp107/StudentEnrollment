using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAEnrollment.Pages
{
    public partial class AddFeeForm : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public AddFeeForm()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void LoadTable()
        {
            string query_Enrollment = "Select * from addfees";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataAddFees.DataSource = ds.Tables[0];
                    dataAddFees.Columns[0].Visible = false;
                    isUpdaDel();
                }
            }

        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateFees.Enabled = false;
                btnDeleteFees.Enabled = false;
                btnAddFees.Enabled = true;
            }
            else
            {
                btnUpdateFees.Enabled = true;
                btnDeleteFees.Enabled = true;
                btnAddFees.Enabled = false;
            }
        }

        bool ViolationIsEmpty()
        {
            if (txtAddFees.Text.Equals("") ||
                txtAddAmount.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddFeeForm_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void dataAddFees_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataAddFees.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtAddFees.Text = row.Cells["Fees"].Value.ToString();
                txtAddAmount.Text = row.Cells["Amount"].Value.ToString();
                txtAddPayment.Text = row.Cells["Payment"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void txtSearchAddFees_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from addfees where Fees like '" + txtSearchAddFees.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataAddFees.DataSource = dt;
            con.Close();
        }

        private void btnAddFees_Click(object sender, EventArgs e)
        {
            string Fees = txtAddFees.Text;
            string Amount = txtAddAmount.Text;
            string Payment = txtAddPayment.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO addfees VALUES('','" + Fees + "','" + Amount + "', '"+ Payment +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                txtAddFees.Text = string.Empty;
                txtAddAmount.Text = string.Empty;
                txtAddPayment.Text = string.Empty;

                LoadTable();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateFees_Click(object sender, EventArgs e)
        {
            string ID = txtId.Text;
            string Fees = txtAddFees.Text;
            string Amount = txtAddAmount.Text;
            string Payment = txtAddPayment.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `addfees` SET `Fees`='" + Fees + "', `Amount`='" + Amount + "', `Payment`='"+ Payment +"'" +
                " WHERE Id = '" + ID + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Succesfully Update!!!");
                // Succesfully updated
                txtId.Text = string.Empty;
                txtAddFees.Text = string.Empty;
                txtAddAmount.Text = string.Empty;
                txtAddPayment.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteFees_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `addfees` WHERE Id = '" + Id + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Delete Succesfully");
                // Succesfully deleted

                txtId.Text = string.Empty;
                txtAddFees.Text = string.Empty;
                txtAddAmount.Text = string.Empty;
                txtAddPayment.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearFees_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtAddFees.Text = string.Empty;
            txtAddAmount.Text = string.Empty;
            txtAddPayment.Text = string.Empty;
            isUpdaDel();
        }

        private void btnBackAddFees_Click(object sender, EventArgs e)
        {
            StudentFeeForm studentFeeForm = new StudentFeeForm();
            studentFeeForm.Show();
            this.Dispose();
        }
    }
}
