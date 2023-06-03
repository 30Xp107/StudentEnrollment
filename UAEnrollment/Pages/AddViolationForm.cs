using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAEnrollment.Pages
{
    public partial class AddViolationForm : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public AddViolationForm()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void LoadTable()
        {
            string query_Enrollment = "Select * from addviolation";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataAddViolation.DataSource = ds.Tables[0];
                    dataAddViolation.Columns[0].Visible = false;
                    isUpdaDel();
                }
            }

        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateViolaiton.Enabled = false;
                btnDeleteViolation.Enabled = false;
                btnAddViolation.Enabled = true;
            }
            else
            {
                btnUpdateViolaiton.Enabled = true;
                btnDeleteViolation.Enabled = true;
                btnAddViolation.Enabled = false;
            }
        }

        bool ViolationIsEmpty()
        {
            if (txtViolation.Text.Equals("") ||
                txtDescription.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddViolationForm_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void dataViolation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataAddViolation.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtViolation.Text = row.Cells["Violation"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void txtSearchAddViolation_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter  adapt = new MySqlDataAdapter("select * from addviolation where Violation like '" + txtSearchAddViolation.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataAddViolation.DataSource = dt;
            con.Close();
        }

        private void btnAddViolation_Click(object sender, EventArgs e)
        {
            string Violation = txtViolation.Text;
            string Description = txtDescription.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO addviolation VALUES('','" + Violation + "','" + Description + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                txtViolation.Text = string.Empty;
                txtDescription.Text = string.Empty;

                LoadTable();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateViolaiton_Click(object sender, EventArgs e)
        {
            string ID = txtId.Text;
            string Violation = txtViolation.Text;
            string Description = txtDescription.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `addviolation` SET `Violation`='"+ Violation + "', `Description`='"+ Description + "'" +
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
                txtViolation.Text = string.Empty;
                txtDescription.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteViolation_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `addviolation` WHERE Id = '" + Id + "'";

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
                txtViolation.Text = string.Empty;
                txtDescription.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearViolation_Click(object sender, EventArgs e)
        {
            txtViolation.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtId.Text = string.Empty;
            isUpdaDel();
        }
        private void btnBackViolation_Click(object sender, EventArgs e)
        {
            StudentViolationForm studentViolationForm = new StudentViolationForm();
            studentViolationForm.Show();
            this.Dispose();
        }

        private void txtId_Click(object sender, EventArgs e)
        {

        }
    }
}
