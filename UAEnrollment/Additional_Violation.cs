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

namespace UAEnrollment
{
    public partial class Additional_Violation : Form
    {
        Connection connection;
        public Additional_Violation()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string Violation = txtViolation.Text;
            string Description = txtDescription.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO add_violation VALUES('','" + Violation + "','" + Description + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtViolation.Text = "";
                txtDescription.Text = "";

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True"; //Set your MySQL connection string here.
                string query = "Select * from add_violation"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_Violation.DataSource = ds.Tables[0];
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
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

        private void Additional_Violation_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
         
            string query = "Select * from add_violation";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    data_Violation.DataSource = ds.Tables[0];
                }
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            txtViolation.Text = "";
            txtDescription.Text = "";
            Dashboard dashboardv2 = new Dashboard();
            dashboardv2.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string Violation = txtViolation.Text;
            string Description = txtDescription.Text;
            string id = txtId.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Update the properties of the row with ID 1
            string query = "UPDATE `add_violation` SET `Violation`='" + Violation + "', `Description`='" + Description + "'" +
                " WHERE Id = '" + id + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Succesfully Update!!!");
                txtViolation.Text = "";
                txtDescription.Text = "";
                // Succesfully updated
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment"; //Set your MySQL connection string here.
                string querys = "Select * from add_violation"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_Violation.DataSource = ds.Tables[0];
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Delete the item with ID 1
            string query = "DELETE FROM `add_violation` WHERE id = '" + id + "'";

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

                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment"; //Set your MySQL connection string here.
                string querys = "Select * from add_violation"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_Violation.DataSource = ds.Tables[0];
                    }
                }
                txtId.Text = "";
                txtViolation.Text = "";
                txtDescription.Text = "";
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void data_Violation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in data_Violation.SelectedCells)
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
                // etc.
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
