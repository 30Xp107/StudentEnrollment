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
    public partial class AddAccount : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public AddAccount()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateAccount.Enabled = false;
                btnDeleteAccount.Enabled = false;
                btnAddAccount.Enabled = true;
            }
            else
            {
                btnUpdateAccount.Enabled = true;
                btnDeleteAccount.Enabled = true;
                btnAddAccount.Enabled = false;
            }
        }

        private void LoadTable()
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
                            cmbStudentId.Items.Add(reader.GetString("StudentID"));
                        }
                    }
                }
            }
            string query_Enrollment = "Select * from studentaccount";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataStudentAccount.DataSource = ds.Tables[0];
                    dataStudentAccount.Columns[0].Visible = false;
                    isUpdaDel();
                }
            }

        }

        bool ViolationIsEmpty()
        {
            if (cmbStudentId.Text.Equals("") ||
                txtStudentName.Text.Equals("") ||
                txtAddress.Text.Equals("") ||
                txtDateEnrolled.Text.Equals("") ||
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

        private void AddAccount_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void txtSearchStudentAccount_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from studentaccount where StudentID like '" + txtSearchStudentAccount.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataStudentAccount.DataSource = dt;
            con.Close();
        }

        private void dataStudentAccount_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataStudentAccount.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                cmbStudentId.Text = row.Cells["StudentID"].Value.ToString();
                txtStudentName.Text = row.Cells["StudentName"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtDateEnrolled.Text = row.Cells["DateEnrolled"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string StudentID = cmbStudentId.Text;
            string StudentName = txtStudentName.Text;
            string Address = txtAddress.Text;
            string DateEnrolled = txtDateEnrolled.Text;
            string Username = txtPassword.Text;
            string Password = txtPassword.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentaccount VALUES('','" + StudentID + "','" + StudentName + "'," +
                    "'" + Address + "', '" + DateEnrolled + "', '"+ Username +"', '"+ Password +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                cmbStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                LoadTable();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string ID = txtId.Text;
            string StudentID = cmbStudentId.Text;
            string StudentName = txtStudentName.Text;
            string Address = txtAddress.Text;
            string DateEnrolled = txtDateEnrolled.Text;
            string Username = txtPassword.Text;
            string Password = txtPassword.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `studentaccount` SET `StudentID`='" + StudentID + "', `StudentName`='" + StudentName + "'," +
                "`Address`='" + Address + "', `DateEnrolled`='" + DateEnrolled + "', `Username`='"+ Username + "', `Password`='"+ Password+"'" +
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
                cmbStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
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

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `studentaccount` WHERE Id = '" + Id + "'";

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
                cmbStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
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

        private void btnClearAccount_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            cmbStudentId.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDateEnrolled.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            isUpdaDel();
        }

        private void btnBackAddAccount_Click(object sender, EventArgs e)
        {
            StudentGradeForm studentGradeForm = new StudentGradeForm();
            studentGradeForm.Show();
            this.Dispose();
        }

        private void cmbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentId.Text != "")
            {
                string StudentID = cmbStudentId.Text;
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
                                txtStudentName.Text = readers.GetValue(7).ToString();
                                txtAddress.Text = readers.GetValue(13).ToString();
                                txtDateEnrolled.Text = readers.GetValue(3).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtId.Text = string.Empty;
                cmbStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }
    }
}
