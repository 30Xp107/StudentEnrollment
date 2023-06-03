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
    public partial class ProfileAccount : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public ProfileAccount()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateProfile.Enabled = false;
                btnDeleteProfile.Enabled = false;
                btnAddProfile.Enabled = true;
            }
            else
            {
                btnUpdateProfile.Enabled = true;
                btnDeleteProfile.Enabled = true;
                btnAddProfile.Enabled = false;
            }
        }

        private void LoadTable()
        {
            string query_Enrollment = "Select * from adminaccount";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataAdminAccount.DataSource = ds.Tables[0];
                    dataAdminAccount.Columns[0].Visible = false;
                    isUpdaDel();
                }
            }

        }

        bool ViolationIsEmpty()
        {
            if (txtAccountID.Text.Equals("") ||
                txtAccountName.Text.Equals("") ||
                txtUsername.Text.Equals("") ||
                txtPassword.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ProfileAccount_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void dataAdminAccount_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataAdminAccount.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtAccountID.Text = row.Cells["AccountID"].Value.ToString();
                txtAccountName.Text = row.Cells["AccountName"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void txtSearchProfile_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from adminaccount where AccountID like '" + txtSearchProfile.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataAdminAccount.DataSource = dt;
            con.Close();
        }

        private void btnBackAddFees_Click(object sender, EventArgs e)
        {
            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            string AccountID = txtAccountID.Text;
            string AccountName = txtAccountName.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO adminaccount VALUES('','" + AccountID + "','" + AccountName + "'," +
                    "'"+ Username +"', '"+ Password +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                txtAccountID.Text = string.Empty;
                txtAccountName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                LoadTable();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string ID = txtId.Text;
            string AccountID = txtAccountID.Text;
            string AccountName = txtAccountName.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `adminaccount` SET `AccountID`='" + AccountID + "', `AccountName`='" + AccountName + "'," +
                "`Username`='"+ Username +"', `Password`='"+ Password +"'" +
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
                txtAccountID.Text = string.Empty;
                txtAccountName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `adminaccount` WHERE Id = '" + Id + "'";

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
                txtAccountID.Text = string.Empty;
                txtAccountName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearProfile_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtAccountID.Text = string.Empty;
            txtAccountName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            isUpdaDel();
        }
    }
}
