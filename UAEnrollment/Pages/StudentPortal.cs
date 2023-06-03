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
    public partial class StudentPortal : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public StudentPortal()
        {
            InitializeComponent();
            Load += StudentPort_Shown;
            connection = new Connection();
        }

        private void LoadTable()
        {
            string StudentIDAcc = txtUser.Text;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM studentenrollment where StudentID = '" + StudentIDAcc + "'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var readers = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (readers.Read())
                        {
                            txtStudentId.Text = readers.GetValue(6).ToString();
                            txtStudentName.Text = readers.GetValue(7).ToString();
                            txtAddress.Text = readers.GetValue(13).ToString();
                            txtDateEnrolled.Text = readers.GetValue(3).ToString();
                            //label4.Text = readers.GetValue(2).ToString();
                            //label5.Text = readers.GetValue(7).ToString();
                        }
                    }
                }
            }
            string StudentID = txtStudentId.Text;
            string query_Enrollment = "Select * from studentgrade Where StudentID = '"+ StudentID +"'";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataStudentViolation.DataSource = ds.Tables[0];
                    dataStudentViolation.Columns[0].Visible = false;
                }
            }
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            Loginv2 loginv2 = new Loginv2();
            loginv2.Show();
            this.Dispose();
        }

        private void StudentPortal_Load(object sender, EventArgs e)
        {

        }

        private void StudentPort_Shown(object sender, EventArgs e)
        {
            txtUser.Text = Loginv2.Usernamepass;
            LoadTable();
        }
    }
}
