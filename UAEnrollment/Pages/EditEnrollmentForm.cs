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
    public partial class EditEnrollmentForm : Form
    {
        public static string passStudentID;
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public EditEnrollmentForm()
        {
            InitializeComponent();
            Load += EditEnrollmentForm_Shown;
            connection = new Connection();
        }

        private void LoadDetails()
        {
            string ID = txtID.Text;
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM studentenrollment WHERE ID = '" + ID + "'";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbStatus.Text = (reader.GetString("Status"));
                            txtRFNo.Text = (reader.GetString("RFNumber"));
                            txtDateEnrolled.Text = (reader.GetString("DateEnrolled"));
                            txtSchoolYear.Text = (reader.GetString("SchoolYear"));
                            txtCurrYear.Text = (reader.GetString("CurriculumYear"));
                            txtStudentId.Text = (reader.GetString("StudentID"));
                            txtStudentName.Text = (reader.GetString("StudentName"));
                            cmbGender.Text = (reader.GetString("Gender"));
                            txtStudentAge.Text = (reader.GetString("Age"));
                            txtStudentDateBirth.Text = (reader.GetString("DateofBirth"));
                            txtStudentPlaceBirth.Text = (reader.GetString("PlaceofBirth"));
                            txtStudentCitizen.Text = (reader.GetString("Citizenship"));
                            txtStudentAddress.Text = (reader.GetString("StudentAddress"));
                            txtStudentReligion.Text = (reader.GetString("Religion"));
                            txtFathersName.Text = (reader.GetString("FathersName"));
                            txtFathersOccupation.Text = (reader.GetString("FathersOccupation"));
                            txtMothersName.Text = (reader.GetString("MothersName"));
                            txtMothersOccupation.Text = (reader.GetString("MothersOccupation"));
                            txtGuardianName.Text = (reader.GetString("GuardianName"));
                            txtAddress.Text = (reader.GetString("Address"));
                            txtStudentRelation.Text = (reader.GetString("StudentRelation"));
                            txtContactNo.Text = (reader.GetString("ContactNumber"));
                            txtSchoolLastAttended.Text = (reader.GetString("SchoolLastAttended"));
                            txtSchoolLastAddress.Text = (reader.GetString("SchoolLastAttendedAddress"));
                        }
                    }
                }
                connections.Close();
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
                "`SchoolYear`='" + SchoolYear + "', `CurriculumYear`='" + CurriculumYear + "', `StudentID`='" + StudentID + "', `StudentName`='" + StudentName + "'," +
                "`Gender`='" + Gender + "', `Age`='" + Age + "', `DateofBirth`='" + DateofBirth + "', `PlaceofBirth`='" + PlaceofBirth + "', `Citizenship`='" + Citizenship + "'," +
                "`StudentAddress`='" + StudentAddress + "', `Religion`='" + Religion + "', `FathersName`='" + FathersName + "', `FathersOccupation`='" + FathersOccupation + "'," +
                "`MothersName`='" + MothersName + "', `MothersOccupation`='" + MothersOccupation + "', `GuardianName`='" + GuardianName + "', `Address`='" + Address + "'," +
                "`StudentRelation`='" + StudentRelation + "', `ContactNumber`='" + ContactNumber + "', `SchoolLastAttended`='" + SchoolLastAttended + "', `SchoolLastAttendedAddress`='" + SchoolLastAddress + "'" +
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

                Dashboardv2 dashboardv2 = new Dashboardv2();
                dashboardv2.Show();
                this.Dispose();
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

                Dashboardv2 dashboardv2 = new Dashboardv2();
                dashboardv2.Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void EditEnrollmentForm_Shown(object sender, EventArgs e)
        {
            txtID.Text = Dashboardv2.passStudentID;
            //txtContactNo.Text = "+63";
            LoadDetails();
        }

        private void btnBackAddAccount_Click(object sender, EventArgs e)
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

            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void btnPrintEditEnrollment_Click(object sender, EventArgs e)
        {
            passStudentID = txtStudentId.Text;
            PrintEnrollment printEnrollment = new PrintEnrollment();
            printEnrollment.Show();
            this.Dispose();
        }
    }
}
