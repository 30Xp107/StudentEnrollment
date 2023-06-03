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
using UAEnrollment.ApiUI;

namespace UAEnrollment.Pages
{
    public partial class StudentFeeForm : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public StudentFeeForm()
        {
            InitializeComponent();
            connection = new Connection();
        }
        private void LoadTable()
        {
            string query_Enrollment = "Select * from studentfees";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataStudentFees.DataSource = ds.Tables[0];
                    dataStudentFees.Columns[0].Visible = false;
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
                            cmbStudentIdFees.Items.Add(reader.GetString("StudentID"));
                        }
                    }
                }
            }
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM addfees";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbFees.Items.Add(reader.GetString("Fees"));
                        }
                    }
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
        private void StudentFeeForm_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadComboBox();
        }

        bool ViolationIsEmpty()
        {
            if (cmbStudentIdFees.Text.Equals("") ||
                txtStudentNameFees.Text.Equals("") ||
                txtRFNumFees.Text.Equals("") ||
                txtDateEnrolledFees.Text.Equals("") ||
                cmbFees.Text.Equals("") ||
                txtAmount.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtSearchStudentFees_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from studentfees where StudentID like '" + txtSearchStudentFees.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataStudentFees.DataSource = dt;
            con.Close();
        }

        private void dataStudentFees_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataStudentFees.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                cmbStudentIdFees.Text = row.Cells["StudentID"].Value.ToString();
                txtStudentNameFees.Text = row.Cells["StudentName"].Value.ToString();
                txtRFNumFees.Text = row.Cells["RFNumber"].Value.ToString();
                txtDateEnrolledFees.Text = row.Cells["DateEnrolled"].Value.ToString();
                cmbFees.Text = row.Cells["Fees"].Value.ToString();
                txtAmount.Text = row.Cells["Amount"].Value.ToString();
                txtPayment.Text = row.Cells["Payment"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void btnAddFees_Click(object sender, EventArgs e)
        {
            string StudentID = cmbStudentIdFees.Text;
            string StudentName = txtStudentNameFees.Text;
            string RFNumber = txtRFNumFees.Text;
            string DateEnrolled = txtDateEnrolledFees.Text;
            string Fees = cmbFees.Text;
            string Amount = txtAmount.Text;
            string Payment = txtPayment.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentfees VALUES('','" + StudentID + "','" + StudentName + "','" + RFNumber + "'," +
                    "'" + DateEnrolled + "','" + Fees + "','"+ Amount +"','"+ Payment +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                string ID = txtId.Text;
                cmbStudentIdFees.Text = string.Empty;
                txtStudentNameFees.Text = string.Empty;
                txtRFNumFees.Text = string.Empty;
                txtDateEnrolledFees.Text = string.Empty;
                cmbFees.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtPayment.Text = string.Empty;

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
            string StudentID = cmbStudentIdFees.Text;
            string StudentName = txtStudentNameFees.Text;
            string RFNumber = txtRFNumFees.Text;
            string DateEnrolled = txtDateEnrolledFees.Text;
            string Fees = cmbFees.Text;
            string Amount = txtAmount.Text;
            string Payment = txtPayment.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `studentfees` SET `StudentID`='" + StudentID + "', `StudentName`='" + StudentName + "', " +
                "`RFNumber`='" + RFNumber + "', `DateEnrolled`='" + DateEnrolled + "', `Fees`='" + Fees + "'," +
                "`Amount`='"+ Amount +"', `Payment`='"+ Payment +"'" +
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
                cmbStudentIdFees.Text = string.Empty;
                txtStudentNameFees.Text = string.Empty;
                txtRFNumFees.Text = string.Empty;
                txtDateEnrolledFees.Text = string.Empty;
                cmbFees.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtPayment.Text = string.Empty;
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
            string query = "DELETE FROM `studentfees` WHERE Id = '" + Id + "'";

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
                cmbStudentIdFees.Text = string.Empty;
                txtStudentNameFees.Text = string.Empty;
                txtRFNumFees.Text = string.Empty;
                txtDateEnrolledFees.Text = string.Empty;
                cmbFees.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtPayment.Text = string.Empty;
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
            cmbStudentIdFees.Text = string.Empty;
            txtStudentNameFees.Text = string.Empty;
            txtRFNumFees.Text = string.Empty;
            txtDateEnrolledFees.Text = string.Empty;
            cmbFees.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtPayment.Text = string.Empty;
            isUpdaDel();
        }

        private void btnAdditionalViolation_Click(object sender, EventArgs e)
        {
            AddFeeForm addFeeForm = new AddFeeForm();
            addFeeForm.Show();
            this.Dispose();
        }

        private void btnBackFees_Click(object sender, EventArgs e)
        {
            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void cmbStudentIdFees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentIdFees.Text != "")
            {
                string StudentID = cmbStudentIdFees.Text;
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
                                txtStudentNameFees.Text = readers.GetValue(7).ToString();
                                txtRFNumFees.Text = readers.GetValue(2).ToString();
                                txtDateEnrolledFees.Text = readers.GetValue(3).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtId.Text = string.Empty;
                cmbStudentIdFees.Text = string.Empty;
                txtStudentNameFees.Text = string.Empty;
                txtRFNumFees.Text = string.Empty;
                txtDateEnrolledFees.Text = string.Empty;
                cmbFees.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtPayment.Text = string.Empty;
            }
        }

        private void cmbFees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFees.Text != "")
            {
                string Fees = cmbFees.Text;
                using (var connectionss = new MySqlConnection(connectionString))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM addfees where Fees = '" + Fees + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtAmount.Text = readers.GetValue(2).ToString();
                                txtPayment.Text = readers.GetValue(3).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtId.Text = string.Empty;
                cmbStudentIdFees.Text = string.Empty;
                txtStudentNameFees.Text = string.Empty;
                txtRFNumFees.Text = string.Empty;
                txtDateEnrolledFees.Text = string.Empty;
                cmbFees.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtPayment.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmsMessage smsMessage = new SmsMessage();
            smsMessage.Show();
            this.Dispose();
        }
    }
}
