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
    public partial class EnrollmentForm : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public EnrollmentForm()
        {
            InitializeComponent();
            Load += EnrollmentForm_Shown;
            connection = new Connection();
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            txtContactNo.Text = "+63";
        }

        private void txtStudentDateBirth_ValueChanged(object sender, EventArgs e)
        {
            int myAge = DateTime.Today.Year - txtStudentDateBirth.Value.Year; // CurrentYear - YourBirthDate

            txtStudentAge.Text = myAge.ToString();
        }

        private void EnrollmentForm_Shown(object sender, EventArgs e)
        {

        }

        bool ViolationIsEmpty()
        {
            if (cmbStatus.Text.Equals("") ||
                txtRFNo.Text.Equals("") ||
                txtDateEnrolled.Text.Equals("") ||
                txtSchoolYear.Text.Equals("") ||
                txtCurrYear.Text.Equals("") ||
                txtStudentId.Text.Equals("") ||
                txtStudentName.Text.Equals("") ||
                cmbGender.Text.Equals("") ||
                txtStudentAge.Text.Equals("") ||
                txtStudentDateBirth.Text.Equals("") ||
                txtStudentPlaceBirth.Text.Equals("") ||
                txtStudentCitizen.Text.Equals("") ||
                txtStudentAddress.Text.Equals("") ||
                txtStudentReligion.Text.Equals("") ||
                txtFathersName.Text.Equals("") ||
                txtFathersOccupation.Text.Equals("") ||
                txtMothersName.Text.Equals("") ||
                txtMothersOccupation.Text.Equals("") ||
                txtGuardianName.Text.Equals("") ||
                txtAddress.Text.Equals("") ||
                txtStudentRelation.Text.Equals("") ||
                txtContactNo.Text.Equals("+63") ||
                txtSchoolLastAttended.Text.Equals("") ||
                txtSchoolLastAddress.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnBackAddAccount_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            cmbStatus.Text = string.Empty;
            txtRFNo.Text = string.Empty;
            txtSchoolYear.Text = string.Empty;
            txtDateEnrolled.Text = string.Empty;
            txtCurrYear.Text = string.Empty;
            txtStudentId.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            cmbGender.Text = string.Empty;
            txtStudentAge.Text = string.Empty;
            txtStudentDateBirth.Text = string.Empty;
            txtStudentPlaceBirth.Text = string.Empty;
            txtStudentCitizen.Text = string.Empty;
            txtStudentAddress.Text = string.Empty;
            txtStudentReligion.Text = string.Empty;
            txtFathersName.Text = string.Empty;
            txtFathersOccupation.Text = string.Empty;
            txtMothersName.Text = string.Empty;
            txtMothersOccupation.Text = string.Empty;
            txtGuardianName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtStudentRelation.Text = string.Empty;
            txtContactNo.Text = "+63";
            txtSchoolLastAttended.Text = string.Empty;
            txtSchoolLastAddress.Text = string.Empty;

            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
            Console.WriteLine(txtID.Text);
        }

        private void btnAddEnrollment_Click(object sender, EventArgs e)
        {
            string Status = cmbStatus.Text;
            string RFNo = txtRFNo.Text;
            string SchoolYear = txtSchoolYear.Text;
            string DateEnrolled = txtDateEnrolled.Text;
            string CurriculumYear = txtCurrYear.Text;
            string StudentID = txtStudentId.Text;
            string StudentName = txtStudentName.Text;
            string Gender = cmbGender.Text;
            string Age = txtStudentAge.Text;
            string DateofBirth = txtStudentDateBirth.Text;
            string PlaceofBirth = txtStudentPlaceBirth.Text;
            string Citizenship = txtStudentCitizen.Text;
            string StudentAddress = txtStudentAddress.Text;
            string Religion = txtStudentReligion.Text;
            string FathersName = txtFathersName.Text;
            string FathersOccupation = txtFathersOccupation.Text;
            string MothersName = txtMothersName.Text;
            string MothersOccupation = txtMothersOccupation.Text;
            string GuardianName = txtGuardianName.Text;
            string Address = txtAddress.Text;
            string StudentRelation = txtStudentRelation.Text;
            string ContactNumber = txtContactNo.Text;
            string SchoolLastAttended = txtSchoolLastAttended.Text;
            string SchoolLastAddress = txtSchoolLastAddress.Text;

            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentenrollment VALUES('','" + Status + "','" + RFNo + "','" + DateEnrolled + "', '"+ SchoolYear + "'," +
                    "'" + CurriculumYear + "','" + StudentID + "', '"+ StudentName +"', '"+ Gender +"', '"+ Age +"', '"+ DateofBirth +"', '"+ PlaceofBirth +"'," +
                    "'"+ Citizenship + "', '"+ StudentAddress + "', '"+ Religion +"', '"+ FathersName +"', '"+ FathersOccupation +"', '"+ MothersName +"', '"+ MothersOccupation +"'," +
                    "'"+ GuardianName +"', '"+ Address +"', '"+ StudentRelation +"', '"+ ContactNumber +"', '"+ SchoolLastAttended +"', '"+ SchoolLastAddress +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                cmbStatus.Text = string.Empty;
                txtRFNo.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
                txtCurrYear.Text = string.Empty;
                txtStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                cmbGender.Text = string.Empty;
                txtStudentAge.Text = string.Empty;
                txtStudentDateBirth.Text = string.Empty;
                txtStudentPlaceBirth.Text = string.Empty;
                txtStudentCitizen.Text = string.Empty;
                txtStudentAddress.Text = string.Empty;
                txtStudentReligion.Text = string.Empty;
                txtFathersName.Text = string.Empty;
                txtFathersOccupation.Text = string.Empty;
                txtMothersName.Text = string.Empty;
                txtMothersOccupation.Text = string.Empty;
                txtGuardianName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtStudentRelation.Text = string.Empty;
                txtContactNo.Text = "+63";
                txtSchoolLastAttended.Text = string.Empty;
                txtSchoolLastAddress.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateEnrollment_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string Status = cmbStatus.Text;
            string RFNo = txtRFNo.Text;
            string SchoolYear = txtSchoolYear.Text;
            string DateEnrolled = txtDateEnrolled.Text;
            string CurriculumYear = txtCurrYear.Text;
            string StudentID = txtStudentId.Text;
            string StudentName = txtStudentName.Text;
            string Gender = cmbGender.Text;
            string Age = txtStudentAge.Text;
            string DateofBirth = txtStudentDateBirth.Text;
            string PlaceofBirth = txtStudentPlaceBirth.Text;
            string Citizenship = txtStudentCitizen.Text;
            string StudentAddress = txtStudentAddress.Text;
            string Religion = txtStudentReligion.Text;
            string FathersName = txtFathersName.Text;
            string FathersOccupation = txtFathersOccupation.Text;
            string MothersName = txtMothersName.Text;
            string MothersOccupation = txtMothersOccupation.Text;
            string GuardianName = txtGuardianName.Text;
            string Address = txtAddress.Text;
            string StudentRelation = txtStudentRelation.Text;
            string ContactNumber = txtContactNo.Text;
            string SchoolLastAttended = txtSchoolLastAttended.Text;
            string SchoolLastAddress = txtSchoolLastAddress.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `studentenrollment` SET `Status`='" + Status + "', `RFNumber`='" + RFNo + "', `DateEnrolled`='" + DateEnrolled + "'," +
                "`SchoolYear`='" + SchoolYear + "', `CurriculumYear`='" + CurriculumYear +"', `StudentID`='"+ StudentID + "', `StudentName`='"+ StudentName +"'," +
                "`Gender`='"+ Gender +"', `Age`='"+ Age + "', `DateofBirth`='"+ DateofBirth +"', `PlaceofBirth`='"+ PlaceofBirth +"', `Citizenship`='"+ Citizenship +"'," +
                "`StudentAddress`='"+ StudentAddress +"', `Religion`='"+ Religion +"', `FathersName`='"+ FathersName +"', `FathersOccupation`='"+ FathersOccupation + "'," +
                "`MothersName`='"+ MothersName +"', `MothersOccupation`='"+ MothersOccupation +"', `GuardianName`='"+ GuardianName +"', `Address`='"+ Address +"'," +
                "`StudentRelation`='"+ StudentRelation +"', `ContactNumber`='"+ ContactNumber +"', `SchoolLastAttended`='"+ SchoolLastAttended +"', `SchoolLastAttendedAddress`='"+ SchoolLastAddress +"'" +
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
                txtID.Text = string.Empty;
                cmbStatus.Text = string.Empty;
                txtRFNo.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
                txtCurrYear.Text = string.Empty;
                txtStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                cmbGender.Text = string.Empty;
                txtStudentAge.Text = string.Empty;
                txtStudentDateBirth.Text = string.Empty;
                txtStudentPlaceBirth.Text = string.Empty;
                txtStudentCitizen.Text = string.Empty;
                txtStudentAddress.Text = string.Empty;
                txtStudentReligion.Text = string.Empty;
                txtFathersName.Text = string.Empty;
                txtFathersOccupation.Text = string.Empty;
                txtMothersName.Text = string.Empty;
                txtMothersOccupation.Text = string.Empty;
                txtGuardianName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtStudentRelation.Text = string.Empty;
                txtContactNo.Text = "+63";
                txtSchoolLastAttended.Text = string.Empty;
                txtSchoolLastAddress.Text = string.Empty;

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteEnrollment_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `studentenrollment` WHERE ID = '" + ID + "'";

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

                txtID.Text = string.Empty;
                cmbStatus.Text = string.Empty;
                txtRFNo.Text = string.Empty;
                txtSchoolYear.Text = string.Empty;
                txtDateEnrolled.Text = string.Empty;
                txtCurrYear.Text = string.Empty;
                txtStudentId.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                cmbGender.Text = string.Empty;
                txtStudentAge.Text = string.Empty;
                txtStudentDateBirth.Text = string.Empty;
                txtStudentPlaceBirth.Text = string.Empty;
                txtStudentCitizen.Text = string.Empty;
                txtStudentAddress.Text = string.Empty;
                txtStudentReligion.Text = string.Empty;
                txtFathersName.Text = string.Empty;
                txtFathersOccupation.Text = string.Empty;
                txtMothersName.Text = string.Empty;
                txtMothersOccupation.Text = string.Empty;
                txtGuardianName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtStudentRelation.Text = string.Empty;
                txtContactNo.Text = "+63";
                txtSchoolLastAttended.Text = string.Empty;
                txtSchoolLastAddress.Text = string.Empty;

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            cmbStatus.Text = string.Empty;
            txtRFNo.Text = string.Empty;
            txtSchoolYear.Text = string.Empty;
            txtDateEnrolled.Text = string.Empty;
            txtCurrYear.Text = string.Empty;
            txtStudentId.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            cmbGender.Text = string.Empty;
            txtStudentAge.Text = string.Empty;
            txtStudentDateBirth.Text = string.Empty;
            txtStudentPlaceBirth.Text = string.Empty;
            txtStudentCitizen.Text = string.Empty;
            txtStudentAddress.Text = string.Empty;
            txtStudentReligion.Text = string.Empty;
            txtFathersName.Text = string.Empty;
            txtFathersOccupation.Text = string.Empty;
            txtMothersName.Text = string.Empty;
            txtMothersOccupation.Text = string.Empty;
            txtGuardianName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtStudentRelation.Text = string.Empty;
            txtContactNo.Text = "+63";
            txtSchoolLastAttended.Text = string.Empty;
            txtSchoolLastAddress.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contact = "+63";
            var number = contact + txtContactNo.Text;
            Console.WriteLine(number);
        }
    }
}
