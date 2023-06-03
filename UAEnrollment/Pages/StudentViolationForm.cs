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
    public partial class StudentViolationForm : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public StudentViolationForm()
        {
            InitializeComponent();
            connection = new Connection();
        }
        private void LoadTable()
        {
            string query_Enrollment = "Select * from studentviolation";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataStudentViolation.DataSource = ds.Tables[0];
                    dataStudentViolation.Columns[0].Visible = false;
                    isUpdaDel();
                }
            }
        }

        private void LoadComboBox()
        {
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM studentenrollment";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbStudentIdViolation.Items.Add(reader.GetString("StudentID"));
                        }
                    }
                }
            }
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM addviolation";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbViolation.Items.Add(reader.GetString("Violation"));
                        }
                    }
                }
            }
        }

        private void StudentViolationForm_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadComboBox();
        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateViolaiton.Enabled = false;
                btnDeleteViolation.Enabled = false;
                btnAdditionalViolation.Enabled = true;
            }
            else
            {
                btnUpdateViolaiton.Enabled = true;
                btnDeleteViolation.Enabled = true;
                btnAdditionalViolation.Enabled = false;
            }
        }

        bool ViolationIsEmpty()
        {
            if (cmbStudentIdViolation.Text.Equals("") ||
                txtStudentNameViolation.Text.Equals("") ||
                txtAddressViolation.Text.Equals("") ||
                cmbViolation.Text.Equals("") ||
                txtDescriptionViolation.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtSearchStudentViolation_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from studentviolation where StudentID like '" + txtSearchStudentViolation.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataStudentViolation.DataSource = dt;
            con.Close();
        }

        private void btnAddViolation_Click(object sender, EventArgs e)
        {
            string StudentID = cmbStudentIdViolation.Text;
            string StudentName = txtStudentNameViolation.Text;
            string Address = txtAddressViolation.Text;
            string Violation = cmbViolation.Text;
            string Description = txtDescriptionViolation.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentviolation VALUES('','"+ StudentID + "','"+ StudentName +"','"+ Address +"'," +
                    "'" + Violation + "','" + Description + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                cmbStudentIdViolation.Text = string.Empty;
                txtStudentNameViolation.Text = string.Empty;
                txtAddressViolation.Text = string.Empty;
                cmbViolation.Text = string.Empty;
                txtDescriptionViolation.Text = string.Empty;

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
            string StudentID = cmbStudentIdViolation.Text;
            string StudentName = txtStudentNameViolation.Text;
            string Address = txtAddressViolation.Text;
            string Violation = cmbViolation.Text;
            string Description = txtDescriptionViolation.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `studentviolation` SET `StudentID`='"+ StudentID + "', `StudentName`='" + StudentName +"', " +
                "`Address`='" + Address + "', `Violation`='" + Violation + "', `Description`='" + Description + "'" +
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
                cmbStudentIdViolation.Text = string.Empty;
                txtStudentNameViolation.Text = string.Empty;
                txtAddressViolation.Text = string.Empty;
                cmbViolation.Text = string.Empty;
                txtDescriptionViolation.Text = string.Empty;
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
            string query = "DELETE FROM `studentviolation` WHERE Id = '" + Id + "'";

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
                cmbStudentIdViolation.Text = string.Empty;
                txtStudentNameViolation.Text = string.Empty;
                txtAddressViolation.Text = string.Empty;
                cmbViolation.Text = string.Empty;
                txtDescriptionViolation.Text = string.Empty;
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
            txtId.Text = string.Empty;
            cmbStudentIdViolation.Text = string.Empty;
            txtStudentNameViolation.Text = string.Empty;
            txtAddressViolation.Text = string.Empty;
            cmbViolation.Text = string.Empty;
            txtDescriptionViolation.Text = string.Empty;
            isUpdaDel();
        }

        private void btnAdditionalViolation_Click(object sender, EventArgs e)
        {
            AddViolationForm addViolationForm = new AddViolationForm();
            addViolationForm.Show();
            this.Dispose();
        }
        private void btnBackViolation_Click(object sender, EventArgs e)
        {
            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void cmbStudentIdViolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentIdViolation.Text != "")
            {
                string StudentID = cmbStudentIdViolation.Text;
                using (var connectionss = new MySqlConnection(connectionString))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM studentenrollment where StudentID = '" + StudentID + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtStudentNameViolation.Text = readers.GetValue(7).ToString();
                                txtAddressViolation.Text = readers.GetValue(13).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtId.Text = string.Empty;
                cmbStudentIdViolation.Text = string.Empty;
                txtStudentNameViolation.Text = string.Empty;
                txtAddressViolation.Text = string.Empty;
                cmbViolation.Text = string.Empty;
                txtDescriptionViolation.Text = string.Empty;
            }
        }

        private void cmbViolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbViolation.Text != "")
            {
                string Violation = cmbViolation.Text;
                using (var connectionss = new MySqlConnection(connectionString))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM addviolation where Violation = '" + Violation + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtDescriptionViolation.Text = readers.GetValue(2).ToString();
                                //txtAddressViolation.Text = readers.GetValue(10).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtId.Text = string.Empty;
                cmbStudentIdViolation.Text = string.Empty;
                txtStudentNameViolation.Text = string.Empty;
                txtAddressViolation.Text = string.Empty;
                cmbViolation.Text = string.Empty;
                txtDescriptionViolation.Text = string.Empty;
            }
        }

        private void dataStudentViolation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataStudentViolation.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                cmbStudentIdViolation.Text = row.Cells["StudentID"].Value.ToString();
                txtStudentNameViolation.Text = row.Cells["StudentName"].Value.ToString();
                txtAddressViolation.Text = row.Cells["Address"].Value.ToString();
                cmbViolation.Text = row.Cells["Violation"].Value.ToString();
                txtDescriptionViolation.Text = row.Cells["Description"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }
    }
}
