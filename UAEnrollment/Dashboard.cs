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
    public partial class Dashboard : Form
    {
        Connection connection;
        public Dashboard()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void EnrollmentTab_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Student_ID = txtStudentId.Text;
            string RFNo = txtRFNo.Text;
            string SchoolYear = txtSchoolYear.Text;
            string CurrYear = txtCurrYear.Text;
            string StudentName = txtStuName.Text;
            string StudentAge = txtStuAge.Text;
            string StudentDB = datestudentdb.Text;
            string PlaceofBirth = txtStuPlaceofBirth.Text;
            string Citizenship = txtStuCitizen.Text;
            string StudentAddress = txtStuAddress.Text;
            string StudentReligion = txtStuReligion.Text;
            string FName = txtFName.Text;
            string FOccu = txtFOccu.Text;
            string MName = txtMName.Text;
            string MOccu = txtMOccu.Text;
            string NameGuardian = txtNameGuardian.Text;
            string RelationStudent = txtRelatoStu.Text;
            string Address = txtAddress.Text;
            string SchoolLast = txtSchoLastAtte.Text;
            string SchoolAdd = txtSLAAddress.Text;
            string EnrolledDate = dateenrolled.Text;

            if(isNotEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO enrollment VALUES('','" + Student_ID + "','" + RFNo + "','"+ SchoolYear + "','"+ CurrYear + "','"+ StudentName + "'," +
                    "'"+ StudentAge + "','"+ StudentDB + "','"+ PlaceofBirth + "','"+ Citizenship + "','"+ StudentAddress + "','"+ StudentReligion + "','"+ FName + "'," +
                    "'"+ FOccu + "','"+ MName + "','"+ MOccu + "','"+ NameGuardian + "','"+ RelationStudent + "','"+ Address + "','"+ SchoolLast + "','"+ SchoolAdd + "'," +
                    "'"+ EnrolledDate + "')";
                MySqlCommand command = new MySqlCommand(insert, connection.DatabaseConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtStudentId.Text = "";
                txtRFNo.Text = "";
                txtSchoolYear.Text = "";
                txtCurrYear.Text = "";
                txtStuName.Text = "";
                txtStuAge.Text = "";
                datestudentdb.Text = "";
                txtStuPlaceofBirth.Text = "";
                txtStuCitizen.Text = "";
                txtStuAddress.Text = "";
                txtStuReligion.Text = "";
                txtFName.Text = "";
                txtFOccu.Text = "";
                txtMName.Text = "";
                txtMOccu.Text = "";
                txtNameGuardian.Text = "";
                txtRelatoStu.Text = "";
                txtAddress.Text = "";
                txtSchoLastAtte.Text = "";
                txtSLAAddress.Text = "";
                dateenrolled.Text = "";

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
                string query_Enrollment = "Select * from enrollment";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                    {
                        DataSet ds = new DataSet();
                        adapater.Fill(ds);
                        data_Enrollment.DataSource = ds.Tables[0];
                    }
                }
                using (var connections = new MySqlConnection(connectionString))
                {
                    connections.Open();
                    var querys = "SELECT * FROM enrollment";
                    using (var commands = new MySqlCommand(querys, connections))
                    {
                        using (var reader = commands.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cmb_Student_Id_Fee.Items.Add(reader.GetString("Student_ID"));
                                cmbStudentId_Vio.Items.Add(reader.GetString("Student_ID"));
                                /*cmb_StudentID_Por.Items.Add(reader.GetString("Student_ID"));*/
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }

            bool isNotEmpty()
            {
                if(txtStudentId.Text.Equals("") || 
                    txtRFNo.Text.Equals("") ||
                    txtSchoolYear.Text.Equals("") ||
                    txtCurrYear.Text.Equals("") ||
                    txtStuName.Text.Equals("") ||
                    txtStuAge.Text.Equals("") ||
                    txtStuPlaceofBirth.Text.Equals("") ||
                    txtStuCitizen.Text.Equals("") ||
                    txtStuAddress.Text.Equals("") ||
                    txtStuReligion.Text.Equals("") ||
                    txtFName.Text.Equals("") ||
                    txtFOccu.Text.Equals("") ||
                    txtMOccu.Text.Equals("") ||
                    txtNameGuardian.Text.Equals("") ||
                    txtRelatoStu.Text.Equals("") ||
                    txtAddress.Text.Equals("") ||
                    txtSchoLastAtte.Text.Equals("") ||
                    txtSLAAddress.Text.Equals(""))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void txtRFNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRFNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void datestudentdb_ValueChanged(object sender, EventArgs e)
        {
            int myAge = DateTime.Today.Year - datestudentdb.Value.Year; // CurrentYear - YourBirthDate

            txtStuAge.Text = myAge.ToString();
        }

        private void dateStudentdb_KeyPress(object sender, KeyPressEventArgs e)
        {
            int myAge = DateTime.Today.Year - datestudentdb.Value.Year; // CurrentYear - YourBirthDate

            txtStuAge.Text = myAge.ToString();
        }

        private void txtSchoolYear_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCurrYear_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentFeeTab_Click(object sender, EventArgs e)
        {

        }

        private void Dashboardv2_Load(object sender, EventArgs e)
        {

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
            
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM enrollment";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmb_Student_Id_Fee.Items.Add(reader.GetString("Student_ID"));
                            cmbStudentId_Vio.Items.Add(reader.GetString("Student_ID"));
                            /*cmb_StudentID_Por.Items.Add(reader.GetString("Student_ID"));*/
                        }
                    }
                }
            }
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM add_violation";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmb_violation.Items.Add(reader.GetString("Violation"));
                        }
                    }
                }
            }

            string query_Enrollment = "Select * from enrollment";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    data_Enrollment.DataSource = ds.Tables[0];
                    data_Enrollment.Columns[0].Visible = false;
                }
            }

            string query_stuFees = "Select * from student_fees";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_stuFees, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    data_studentFees.DataSource = ds.Tables[0];
                    data_studentFees.Columns[0].Visible = false;
                }
            }
            string query_stuVio = "Select * from violation";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_stuVio, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    data_violation.DataSource = ds.Tables[0];
                    data_violation.Columns[0].Visible = false;
                }
            }
            /*string query_stuPort = "Select * from studentaccount";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_stuPort, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    data_StudentPortal.DataSource = ds.Tables[0];
                    data_StudentPortal.Columns[0].Visible = false;
                }
            }*/

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string StudentID = cmb_Student_Id_Fee.Text;
            string Student_Name = txtStudentName_Fee.Text;
            string RFNumber = txtRFNumber_Fee.Text;
            string DateEnrolled = txtDateEnrolled_Fee.Text;
            string Fees = txt_Fees_Fee.Text;
            string Amount = txt_Amount_Fee.Text;
            string Payment = txt_Payment_Fee.Text;
            if(StudentFeesIsNotEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO student_fees VALUES('','" + StudentID + "','" + Student_Name + "','"+ RFNumber + "', '"+ DateEnrolled + "', '"+ Fees + "'," +
                    "'"+ Amount + "', '"+ Payment + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                cmb_Student_Id_Fee.Text = "";
                txtStudentName_Fee.Text = "";
                txtRFNumber_Fee.Text = "";
                txtDateEnrolled_Fee.Text = "";
                txt_Fees_Fee.Text = "";
                txt_Amount_Fee.Text = "";
                txt_Payment_Fee.Text = "";

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True"; //Set your MySQL connection string here.
                string query = "Select * from student_fees"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_studentFees.DataSource = ds.Tables[0];
                        data_studentFees.Columns[0].Visible = false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        bool StudentFeesIsNotEmpty()
        {
            if (txtStudentName_Fee.Text.Equals("") ||
                txtRFNumber_Fee.Text.Equals("") ||
                txtDateEnrolled_Fee.Text.Equals("") ||
                txt_Fees_Fee.Text.Equals("") ||
                txt_Amount_Fee.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string Student_Name = txtStudentName_Fee.Text;
            string RFNumber = txtRFNumber_Fee.Text;
            string DateEnrolled = txtDateEnrolled_Fee.Text;
            string Fees = txt_Fees_Fee.Text;
            string Amount = txt_Amount_Fee.Text;
            string Payment = txt_Payment_Fee.Text;
            string id = txtId.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Update the properties of the row with ID 1
            string query = "UPDATE `student_fees` SET `StudentName`='" + Student_Name+ "', `RFNumber`='" + RFNumber + "', " +
                "`DateEnrolled`='" + DateEnrolled + "', `Fees`='"+ Fees + "', `Amount`='"+ Amount +"', `Payment`='"+ Payment +"'" +
                " WHERE id = '" + id + "'";

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
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment"; //Set your MySQL connection string here.
                string querys = "Select * from student_fees"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_studentFees.DataSource = ds.Tables[0];
                        data_studentFees.Columns[0].Visible = false;
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

        private void data_studentfees_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in data_studentFees.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                cmb_Student_Id_Fee.Text = row.Cells["StudentID"].Value.ToString();
                txtStudentName_Fee.Text = row.Cells["StudentName"].Value.ToString();
                txtRFNumber_Fee.Text = row.Cells["RFNumber"].Value.ToString();
                txtDateEnrolled_Fee.Text = row.Cells["DateEnrolled"].Value.ToString();
                txt_Fees_Fee.Text = row.Cells["Fees"].Value.ToString();
                txt_Amount_Fee.Text = row.Cells["Amount"].Value.ToString();
                txt_Payment_Fee.Text = row.Cells["Payment"].Value.ToString();
                // etc.
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Delete the item with ID 1
            string query = "DELETE FROM `student_fees` WHERE id = '" + id + "'";

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
                string querys = "Select * from student_fees"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_studentFees.DataSource = ds.Tables[0];
                        data_studentFees.Columns[0].Visible = false;
                    }
                }
                txtId.Text = "";
                cmb_Student_Id_Fee.Text = "";
                txtStudentName_Fee.Text = "";
                txtRFNumber_Fee.Text = "";
                txtDateEnrolled_Fee.Text = "";
                txt_Fees_Fee.Text = "";
                txt_Amount_Fee.Text = "";
                txt_Payment_Fee.Text = "";
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            string StudentID = cmbStudentId_Vio.Text;
            string Student_Name = txtStudentName_Vio.Text;
            string RFNumber = txtStudentAddress_Vio.Text;
            string Violation = cmb_violation.Text;
            string Description = txtDescription.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO violation VALUES('','" + StudentID + "','" + Student_Name + "','" + RFNumber + "', " +
                    "'" + Violation + "', '" + Description + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                cmbStudentId_Vio.Text = "";
                txtStudentName_Vio.Text = "";
                txtStudentAddress_Vio.Text = "";
                cmb_violation.Text = "";
                txtDescription.Text = "";

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True"; //Set your MySQL connection string here.
                string query = "Select * from violation"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_violation.DataSource = ds.Tables[0];
                        data_violation.Columns[0].Visible = false;
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
            if (cmbStudentId_Vio.Text.Equals("") ||
                txtStudentName_Vio.Text.Equals("") ||
                txtStudentAddress_Vio.Text.Equals("") ||
                cmb_violation.Text.Equals("") ||
                txtDescription.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Additional_Violation add_Violation = new Additional_Violation();
            add_Violation.Show();
            this.Hide();
        }

        private void cmb_violation_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_violation.Text != "")
            {
                string Violation = cmb_violation.Text;
                var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
                using (var connectionss = new MySqlConnection(connectionStringss))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM add_violation where Violation = '" + Violation + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtDescription.Text = readers.GetValue(2).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtDescription.Text = ""; 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtStudentId.Text = "";
            txtRFNo.Text = "";
            txtSchoolYear.Text = "";
            txtCurrYear.Text = "";
            txtStuName.Text = "";
            txtStuAge.Text = "";
            datestudentdb.Text = "";
            txtStuPlaceofBirth.Text = "";
            txtStuCitizen.Text = "";
            txtStuAddress.Text = "";
            txtStuReligion.Text = "";
            txtFName.Text = "";
            txtFOccu.Text = "";
            txtMName.Text = "";
            txtMOccu.Text = "";
            txtNameGuardian.Text = "";
            txtRelatoStu.Text = "";
            txtAddress.Text = "";
            txtSchoLastAtte.Text = "";
            txtSLAAddress.Text = "";
            dateenrolled.Text = "";
        }

        private void cmb_Student_Id_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_Student_Id_Fee.Text != "")
            {
                string Student_ID = cmb_Student_Id_Fee.Text;
                var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
                using (var connectionss = new MySqlConnection(connectionStringss))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM enrollment where Student_ID = '" + Student_ID + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtStudentName_Fee.Text = readers.GetValue(5).ToString();
                                txtRFNumber_Fee.Text = readers.GetValue(2).ToString();
                                txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtStudentName_Fee.Text = "";
                txtRFNumber_Fee.Text = "";
                txtDateEnrolled_Fee.Text = "";
            }
        }

        private void cmbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbStudentId_Vio.Text != "")
            {
                string Student_ID = cmbStudentId_Vio.Text;
                var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
                using (var connectionss = new MySqlConnection(connectionStringss))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM enrollment where Student_ID = '" + Student_ID + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtStudentName_Vio.Text = readers.GetValue(5).ToString();
                                txtStudentAddress_Vio.Text = readers.GetValue(10).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtStudentName_Fee.Text = "";
                txtRFNumber_Fee.Text = "";
                txtDateEnrolled_Fee.Text = "";
            }
        }

        private void data_violation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in data_violation.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId_Vio.Text = row.Cells["Id"].Value.ToString();
                cmbStudentId_Vio.Text = row.Cells["StudentId"].Value.ToString();
                txtStudentName_Vio.Text = row.Cells["StudentName"].Value.ToString();
                txtStudentAddress_Vio.Text = row.Cells["Address"].Value.ToString();
                cmb_violation.Text = row.Cells["Violation"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                // etc.
            }
        }

        /*private void cmb_StudentID_Por_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_StudentID_Por.Text != "")
            {
                string Student_ID = cmb_StudentID_Por.Text;
                var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
                using (var connectionss = new MySqlConnection(connectionStringss))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM enrollment where Student_ID = '" + Student_ID + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtStudentName_Por.Text = readers.GetValue(5).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtStudentName_Por.Text = "";
            }
        }*/

        /*private void bunifuButton9_Click(object sender, EventArgs e)
        {
            string StudentID = cmb_StudentID_Por.Text;
            string Student_Name = txtStudentName_Por.Text;
            string Username = txtUsername_Por.Text;
            string Password = txtPassword_Por.Text;
            if (StudentPortalIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentaccount VALUES('','" + StudentID + "','" + Student_Name + "','" + Username + "', " +
                    "'" + Password + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                cmb_StudentID_Por.Text = "";
                txtStudentName_Por.Text = "";
                txtUsername_Por.Text = "";
                txtPassword_Por.Text = "";

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True"; //Set your MySQL connection string here.
                string query = "Select * from studentaccount"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_violation.DataSource = ds.Tables[0];
                        data_violation.Columns[0].Visible = false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }*/
        /*bool StudentPortalIsEmpty()
        {
            if (cmb_StudentID_Por.Text.Equals("") ||
                txtStudentName_Por.Text.Equals("") ||
                txtUsername_Por.Text.Equals("") ||
                txtPassword_Por.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/

        private void data_Enrollment_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in data_Enrollment.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtEnID.Text = row.Cells["Id"].Value.ToString();
                txtStudentId.Text = row.Cells["Student_ID"].Value.ToString();
                txtRFNo.Text = row.Cells["RFNo"].Value.ToString();
                txtSchoolYear.Text = row.Cells["SchoolYear"].Value.ToString();
                txtCurrYear.Text = row.Cells["CurrYear"].Value.ToString();
                txtStuName.Text = row.Cells["StudentName"].Value.ToString();
                txtStuAge.Text = row.Cells["StudentAge"].Value.ToString();
                datestudentdb.Text = row.Cells["StudentDB"].Value.ToString();
                txtStuPlaceofBirth.Text = row.Cells["PlaceofBirth"].Value.ToString();
                txtStuCitizen.Text = row.Cells["Citizenship"].Value.ToString();
                txtStuAddress.Text = row.Cells["StudentAddress"].Value.ToString();
                txtStuReligion.Text = row.Cells["StudentReligion"].Value.ToString();
                txtFName.Text = row.Cells["FName"].Value.ToString();
                txtFOccu.Text = row.Cells["FOccu"].Value.ToString();
                txtMName.Text = row.Cells["MName"].Value.ToString();
                txtMOccu.Text = row.Cells["MOccu"].Value.ToString();
                txtNameGuardian.Text = row.Cells["NameGuardian"].Value.ToString();
                txtRelatoStu.Text = row.Cells["RelationStudent"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtSchoLastAtte.Text = row.Cells["SchoolLast"].Value.ToString();
                txtSLAAddress.Text = row.Cells["SchoolAdd"].Value.ToString();
                dateenrolled.Text = row.Cells["EnrolledDate"].Value.ToString();
                // etc.
            }
        }

        private void btnEnEdit_Click(object sender, EventArgs e)
        {
            string ID = txtEnID.Text;
            string Student_ID = txtStudentId.Text;
            string RFNo = txtRFNo.Text;
            string SchoolYear = txtSchoolYear.Text;
            string CurrYear = txtCurrYear.Text;
            string StudentName = txtStuName.Text;
            string StudentAge = txtStuAge.Text;
            string StudentDB = datestudentdb.Text;
            string PlaceofBirth = txtStuPlaceofBirth.Text;
            string Citizenship = txtStuCitizen.Text;
            string StudentAddress = txtStuAddress.Text;
            string StudentReligion = txtStuReligion.Text;
            string FName = txtFName.Text;
            string FOccu = txtFOccu.Text;
            string MName = txtMName.Text;
            string MOccu = txtMOccu.Text;
            string NameGuardian = txtNameGuardian.Text;
            string RelationStudent = txtRelatoStu.Text;
            string Address = txtAddress.Text;
            string SchoolLast = txtSchoLastAtte.Text;
            string SchoolAdd = txtSLAAddress.Text;
            string EnrolledDate = dateenrolled.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Update the properties of the row with ID 1
            string query = "UPDATE `enrollment` SET `Student_ID`='" + Student_ID + "', `RFNo`='" + RFNo + "', " +
                "`SchoolYear`='" + SchoolYear + "', `CurrYear`='" + CurrYear + "', `StudentName`='" + StudentName + "', `StudentAge`='" + StudentAge + "', " +
                "`StudentDB`='" + StudentDB + "', `PlaceofBirth`='"+ PlaceofBirth + "', `Citizenship`='"+ Citizenship + "', `StudentAddress`='"+ StudentAddress + "'," +
                "`StudentReligion`='"+ StudentReligion + "', `FName`='"+FName+ "', `FOccu`='"+ FOccu + "', `MName`='"+ MName + "', `MOccu`='"+ MOccu + "', `NameGuardian`='"+ NameGuardian + "'," +
                "`RelationStudent`='"+ RelationStudent + "', `Address`='"+ Address + "', `SchoolLast`='"+ SchoolLast + "', `SchoolAdd`='"+ SchoolAdd + "', `EnrolledDate`='"+ EnrolledDate + "'" +
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
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment"; //Set your MySQL connection string here.
                string querys = "Select * from enrollment"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_Enrollment.DataSource = ds.Tables[0];
                        data_Enrollment.Columns[0].Visible = false;
                    }
                }
                txtEnID.Text = "";
                txtStudentId.Text = "";
                txtRFNo.Text = "";
                txtSchoolYear.Text = "";
                txtCurrYear.Text = "";
                txtStuName.Text = "";
                txtStuAge.Text = "";
                datestudentdb.Text = "";
                txtStuPlaceofBirth.Text = "";
                txtStuCitizen.Text = "";
                txtStuAddress.Text = "";
                txtStuReligion.Text = "";
                txtFName.Text = "";
                txtFOccu.Text = "";
                txtMName.Text = "";
                txtMOccu.Text = "";
                txtNameGuardian.Text = "";
                txtRelatoStu.Text = "";
                txtAddress.Text = "";
                txtSchoLastAtte.Text = "";
                txtSLAAddress.Text = "";
                dateenrolled.Text = "";
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnEnDelete_Click(object sender, EventArgs e)
        {
            string Id = txtEnID.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Delete the item with ID 1
            string query = "DELETE FROM `enrollment` WHERE Id = '" + Id + "'";

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
                string querys = "Select * from enrollment"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_Enrollment.DataSource = ds.Tables[0];
                    }
                }
                txtEnID.Text = "";
                txtStudentId.Text = "";
                txtRFNo.Text = "";
                txtSchoolYear.Text = "";
                txtCurrYear.Text = "";
                txtStuName.Text = "";
                txtStuAge.Text = "";
                datestudentdb.Text = "";
                txtStuPlaceofBirth.Text = "";
                txtStuCitizen.Text = "";
                txtStuAddress.Text = "";
                txtStuReligion.Text = "";
                txtFName.Text = "";
                txtFOccu.Text = "";
                txtMName.Text = "";
                txtMOccu.Text = "";
                txtNameGuardian.Text = "";
                txtRelatoStu.Text = "";
                txtAddress.Text = "";
                txtSchoLastAtte.Text = "";
                txtSLAAddress.Text = "";
                dateenrolled.Text = "";
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVioEdit_Click(object sender, EventArgs e)
        {
            string ID = txtId_Vio.Text;
            string StudentID = cmbStudentId_Vio.Text;
            string StudentName = txtStudentName_Vio.Text;
            string Address = txtStudentAddress_Vio.Text;
            string Violation = cmb_violation.Text;
            string Description = txtDescription.Text;

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Update the properties of the row with ID 1
            string query = "UPDATE `violation` SET `StudentID`='" + StudentID + "', `StudentName`='" + StudentName + "', `Address`='"+ Address + "'," +
                "`Violation`='"+ Violation + "', `Description`='"+ Description + "'" +
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
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment"; //Set your MySQL connection string here.
                string querys = "Select * from violation"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_violation.DataSource = ds.Tables[0];
                        data_violation.Columns[0].Visible = false;
                    }
                }
                txtId_Vio.Text = "";
                cmbStudentId_Vio.Text = "";
                txtStudentName_Vio.Text = "";
                txtStudentAddress_Vio.Text = "";
                cmb_violation.Text = "";
                txtDescription.Text = "";
                
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVioRemove_Click(object sender, EventArgs e)
        {
            string Id = txtId_Vio.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Delete the item with ID 1
            string query = "DELETE FROM `violation` WHERE Id = '" + Id + "'";

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
                string querys = "Select * from violation"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_Enrollment.DataSource = ds.Tables[0];
                        data_Enrollment.Columns[0].Visible = false;
                    }
                }

                txtId_Vio.Text = "";
                cmbStudentId_Vio.Text = "";
                txtStudentName_Vio.Text = "";
                txtStudentAddress_Vio.Text = "";
                cmb_violation.Text = "";
                txtDescription.Text = "";

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVioCancel_Click(object sender, EventArgs e)
        {
            txtId_Vio.Text = "";
            cmbStudentId_Vio.Text = "";
            txtStudentName_Vio.Text = "";
            txtStudentAddress_Vio.Text = "";
            cmb_violation.Text = "";
            txtDescription.Text = "";
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_Por_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Por_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentName_Por_TextChanged(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void data_StudentPortal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Student_Account student_Account = new Student_Account();
            student_Account.Show();
            this.Hide();
        }
    }
}
