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
using UAEnrollment.Reports;

namespace UAEnrollment.Pages
{
    public partial class StudentGradeForm : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public StudentGradeForm()
        {
            InitializeComponent();
            connection = new Connection();
        }
        private void LoadTable()
        {
            string query_Enrollment = "Select * from studentgrade";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataStudentGrade.DataSource = ds.Tables[0];
                    dataStudentGrade.Columns[0].Visible = false;
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
                            cmbStudentIdGrade.Items.Add(reader.GetString("StudentID"));
                        }
                    }
                }
            }
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM addsubjects";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbSubject.Items.Add(reader.GetString("Subjects"));
                        }
                    }
                }
            }
        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateGrade.Enabled = false;
                btnDeleteGrade.Enabled = false;
            }
            else
            {
                btnUpdateGrade.Enabled = true;
                btnDeleteGrade.Enabled = true;
            }
        }

        private void StudentGradeForm_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadComboBox();
        }

        bool ViolationIsEmpty()
        {
            if (cmbStudentIdGrade.Text.Equals("") ||
                txtStudentNameGrade.Text.Equals("") ||
                cmbClassifiedGrade.Text.Equals("") ||
                cmbSubject.Text.Equals("") ||
                txtSchoolYear.Text.Equals("") ||
                txtAdviserTeacher.Text.Equals("") ||
                txtFinalGrade.Text.Equals("") ||
                cmbRemarks.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnBackGrade_Click(object sender, EventArgs e)
        {
            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void btnAdditionalViolation_Click(object sender, EventArgs e)
        {
            AddSubjects addSubjects = new AddSubjects();
            addSubjects.Show();
            this.Dispose();
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            string StudentID = cmbStudentIdGrade.Text;
            string StudentName = txtStudentNameGrade.Text;
            string ClassifiedGrade = cmbClassifiedGrade.Text;
            string Subject = cmbSubject.Text;
            string SchoolYear = txtSchoolYear.Text;
            string AdviserTeacher = txtAdviserTeacher.Text;
            string FinalGrade = txtFinalGrade.Text;
            string Remarks = cmbRemarks.Text;

            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentgrade VALUES('','" + StudentID + "','" + StudentName + "','" + ClassifiedGrade + "'," +
                    "'" + Subject + "','" + SchoolYear + "', '"+ AdviserTeacher +"', '"+ FinalGrade +"', '"+ Remarks +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                cmbStudentIdGrade.Text = string.Empty;
                txtStudentNameGrade.Text = string.Empty;
                cmbClassifiedGrade.Text = string.Empty;
                cmbSubject.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtAdviserTeacher.Text = string.Empty;
                txtFinalGrade.Text = string.Empty;
                cmbRemarks.Text = string.Empty;

                LoadTable();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateGrade_Click(object sender, EventArgs e)
        {
            string ID = txtId.Text;
            string StudentID = cmbStudentIdGrade.Text;
            string StudentName = txtStudentNameGrade.Text;
            string ClassifiedGrade = cmbClassifiedGrade.Text;
            string Subject = cmbSubject.Text;
            string SchoolYear = txtSchoolYear.Text;
            string AdviserTeacher = txtAdviserTeacher.Text;
            string FinalGrade = txtFinalGrade.Text;
            string Remarks = cmbRemarks.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `studentgrade` SET `StudentID`='" + StudentID + "', `StudentName`='" + StudentName + "', " +
                "`ClassifiedGrade`='" + ClassifiedGrade + "', `Subject`='" + Subject + "', `SchoolYear`='" + SchoolYear + "'," +
                "`Adviser/Teacher`='"+ AdviserTeacher + "', `FinalGrade`='"+ FinalGrade + "', `Remarks`='"+ Remarks + "'" +
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
                cmbStudentIdGrade.Text = string.Empty;
                txtStudentNameGrade.Text = string.Empty;
                cmbClassifiedGrade.Text = string.Empty;
                cmbSubject.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtAdviserTeacher.Text = string.Empty;
                txtFinalGrade.Text = string.Empty;
                cmbRemarks.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteGrade_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `studentgrade` WHERE Id = '" + Id + "'";

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
                cmbStudentIdGrade.Text = string.Empty;
                txtStudentNameGrade.Text = string.Empty;
                cmbClassifiedGrade.Text = string.Empty;
                cmbSubject.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtAdviserTeacher.Text = string.Empty;
                txtFinalGrade.Text = string.Empty;
                cmbRemarks.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearGrade_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            cmbStudentIdGrade.Text = string.Empty;
            txtStudentNameGrade.Text = string.Empty;
            cmbClassifiedGrade.Text = string.Empty;
            cmbSubject.Text = string.Empty;
            txtSchoolYear.Text = string.Empty;
            txtAdviserTeacher.Text = string.Empty;
            txtFinalGrade.Text = string.Empty;
            cmbRemarks.Text = string.Empty;
            isUpdaDel();
        }

        private void txtSearchStudentGrade_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from studentgrade where StudentID like '" + txtSearchStudentGrade.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataStudentGrade.DataSource = dt;
            con.Close();
        }

        private void dataStudentGrade_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataStudentGrade.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                cmbStudentIdGrade.Text = row.Cells["StudentID"].Value.ToString();
                txtStudentNameGrade.Text = row.Cells["StudentName"].Value.ToString();
                cmbClassifiedGrade.Text = row.Cells["ClassifiedGrade"].Value.ToString();
                cmbSubject.Text = row.Cells["Subject"].Value.ToString();
                txtSchoolYear.Text = row.Cells["SchoolYear"].Value.ToString();
                txtAdviserTeacher.Text = row.Cells["Adviser/Teacher"].Value.ToString();
                txtFinalGrade.Text = row.Cells["FinalGrade"].Value.ToString();
                cmbRemarks.Text = row.Cells["Remarks"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void cmbStudentIdGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentIdGrade.Text != "")
            {
                string StudentID = cmbStudentIdGrade.Text;
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
                                txtStudentNameGrade.Text = readers.GetValue(7).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtId.Text = string.Empty;
                cmbStudentIdGrade.Text = string.Empty;
                txtStudentNameGrade.Text = string.Empty;
                cmbClassifiedGrade.Text = string.Empty;
                cmbSubject.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtAdviserTeacher.Text = string.Empty;
                txtFinalGrade.Text = string.Empty;
                cmbRemarks.Text = string.Empty;
            }
        }

        private void btnStudentAccounts_Click(object sender, EventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
            this.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintGrade printGrade = new PrintGrade();
            printGrade.Show();
            this.Dispose();
        }
    }
}
