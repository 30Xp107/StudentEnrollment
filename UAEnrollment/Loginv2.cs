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
using UAEnrollment.Pages;

namespace UAEnrollment
{
    public partial class Loginv2 : Form
    {
        public static string Usernamepass;
        public static string StudentID;
        public static string StudentName;
        public static string StudentAddress;
        public static string StudentDateEnrolled;
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public Loginv2()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string queryAdmin = "Select * from adminaccount where " +
                "Username='" + username + "' && " +
                "Password='" + password + "'";

            string queryStudent = "Select * from studentaccount where " +
                "UserName='" + username + "' && " +
                "Password='" + password + "'";

            connection.OpenConnection();
            if(cmbLoginStatus.Text == "Admin")
            { 
                MySqlCommand command = new MySqlCommand(queryAdmin, connection.DatabaseConnection());
                MySqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                }
                if (i > 0)
                {
                    Dashboardv2 dashboardv2 = new Dashboardv2();
                    dashboardv2.Show();
                    this.Hide();


                    string Username = txtUsername.Text;
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        var query = "SELECT * FROM adminaccount where Username = '" + Username + "'";
                        using (var passcommand = new MySqlCommand(query, connection))
                        {
                            using (var readers = passcommand.ExecuteReader())
                            {
                                //Iterate through the rows and add it to the combobox's items
                                while (readers.Read())
                                {
                                    passUsername.Text = readers.GetValue(1).ToString();
                                }
                            }
                        }
                    }
                    Usernamepass = passUsername.Text;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else if(cmbLoginStatus.Text == "Student")
            {
                MySqlCommand command = new MySqlCommand(queryStudent, connection.DatabaseConnection());
                MySqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                }
                if (i > 0)
                {
                    StudentPortal studentPortal = new StudentPortal();
                    studentPortal.Show();
                    this.Hide();


                    string Username = txtUsername.Text;
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        var query = "SELECT * FROM studentaccount where Username = '" + Username + "'";
                        using (var passcommand = new MySqlCommand(query, connection))
                        {
                            using (var readers = passcommand.ExecuteReader())
                            {
                                //Iterate through the rows and add it to the combobox's items
                                while (readers.Read())
                                {
                                    passUsername.Text = readers.GetValue(1).ToString();
                                }
                            }
                        }
                    }
                    Usernamepass = passUsername.Text;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            connection.CloseConnection();
        }

        private void Loginv2_Load(object sender, EventArgs e)
        {
            cmbLoginStatus.Text = "Admin";
            txtPassword.PasswordChar = '*';
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
