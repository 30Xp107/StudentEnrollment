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
    public partial class Login : Form
    {
        Connection connection;
        public Login()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Hide();*/


            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string query = "Select * from login where " +
                "username='" + username + "' && " +
                "password='" + password + "'";
            connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection.DatabaseConnection());
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            if(i > 0)
            {
                Dashboard dashboardv2 = new Dashboard();
                dashboardv2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
            connection.CloseConnection();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
