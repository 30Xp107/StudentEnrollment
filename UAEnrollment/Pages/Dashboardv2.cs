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
    public partial class Dashboardv2 : Form
    {
        public static string passStudentID;
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public Dashboardv2()
        {
            InitializeComponent();
            Load += Dashboardv2_Shown;
            connection = new Connection();
        }
        private void LoadTable()
        {

            string AccountID = txtUser.Text;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM adminaccount where AccountID = '" + AccountID + "'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var readers = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (readers.Read())
                        {
                            txtAccountName.Text = readers.GetValue(2).ToString();
                            txtAccountID.Text = readers.GetValue(1).ToString();
                        }
                    }
                }
            }

            string query_Enrollment = "Select * from studentenrollment";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataDashBoardv2.DataSource = ds.Tables[0];
                    dataDashBoardv2.Columns[0].Visible = false;
                    dataDashBoardv2.Columns[1].Visible = false;
                    dataDashBoardv2.Columns[2].Visible = false;
                    dataDashBoardv2.Columns[3].Visible = false;
                    dataDashBoardv2.Columns[4].Visible = false;
                    dataDashBoardv2.Columns[5].Visible = false;
                    dataDashBoardv2.Columns[9].Visible = false;
                    dataDashBoardv2.Columns[10].Visible = false;
                    dataDashBoardv2.Columns[11].Visible = false;
                    dataDashBoardv2.Columns[12].Visible = false;
                    dataDashBoardv2.Columns[13].Visible = false;
                    dataDashBoardv2.Columns[14].Visible = false;
                    dataDashBoardv2.Columns[15].Visible = false;
                    dataDashBoardv2.Columns[16].Visible = false;
                    dataDashBoardv2.Columns[17].Visible = false;
                    dataDashBoardv2.Columns[18].Visible = false;
                    dataDashBoardv2.Columns[19].Visible = false;
                    dataDashBoardv2.Columns[20].Visible = false;
                    dataDashBoardv2.Columns[21].Visible = false;
                    dataDashBoardv2.Columns[22].Visible = false;
                    dataDashBoardv2.Columns[23].Visible = false;
                    dataDashBoardv2.Columns[24].Visible = false;
                }
            }
        }

        private void Dashboardv2_Load(object sender, EventArgs e)
        {
            //LoadTable();
        }

        private void Dashboardv2_Shown(object sender, EventArgs e)
        {
            txtUser.Text = Loginv2.Usernamepass;
            LoadTable();
        }

        private void txtSearchStudentDashbooard_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from studentenrollment where StudentID like '" + txtSearchStudentDashbooard.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataDashBoardv2.DataSource = dt;
            con.Close();
        }

        private void btnEnrollmentDashboard_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentForm = new EnrollmentForm();
            enrollmentForm.Show();
            this.Dispose();
        }

        private void btnStudentFeesDashboard_Click(object sender, EventArgs e)
        {
            StudentFeeForm studentFeeForm = new StudentFeeForm();
            studentFeeForm.Show();
            this.Dispose();
        }

        private void btnStudentViolationDashboard_Click(object sender, EventArgs e)
        {
            StudentViolationForm studentViolationForm = new StudentViolationForm();
            studentViolationForm.Show();
            this.Dispose();
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            Loginv2 loginv2 = new Loginv2();
            loginv2.Show();
            this.Dispose();
        }

        private void btnStudentGradeDashboard_Click(object sender, EventArgs e)
        {
            StudentGradeForm studentGradeForm = new StudentGradeForm();
            studentGradeForm.Show();
            this.Dispose();
        }

        private void dataDashBoardv2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataDashBoardv2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtStudentID.Text = row.Cells["ID"].Value.ToString();
                // etc.
            }
            passStudentID = txtStudentID.Text;

            EditEnrollmentForm editEnrollmentForm = new EditEnrollmentForm();
            editEnrollmentForm.Show();
            this.Dispose();
        }

        private void btnStudentPortalDashBoard_Click(object sender, EventArgs e)
        {
            StudentPortalAdmin studentPortalAdmin = new StudentPortalAdmin();
            studentPortalAdmin.Show();
            this.Dispose();
        }

        private void txtAccountName_Click(object sender, EventArgs e)
        {
            ProfileAccount profileAccount = new ProfileAccount();
            profileAccount.Show();
            this.Dispose();
        }

        private void txtAccountID_Click(object sender, EventArgs e)
        {
            ProfileAccount profileAccount = new ProfileAccount();
            profileAccount.Show();
            this.Dispose();
        }
    }
}
