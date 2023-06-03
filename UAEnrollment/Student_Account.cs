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
    public partial class Student_Account : Form
    {
        Connection connection;
        public Student_Account()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
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
                        data_StudentPortal.DataSource = ds.Tables[0];
                        data_StudentPortal.Columns[0].Visible = false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }
        bool StudentPortalIsEmpty()
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
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            string ID = txtStudentAccID.Text;
            string StudentID = cmb_StudentID_Por.Text;
            string Student_Name = txtStudentName_Por.Text;
            string Student_Username = txtUsername_Por.Text;
            string Student_Password = txtPassword_Por.Text;

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
            // Update the properties of the row with ID 1
            string query = "UPDATE `studentaccount` SET `StudentID`='" + StudentID + "', `Student_Name`='" + Student_Name + "', `Student_Username `='" + Student_Username + "'," +
                "`Student_Password `='" + Student_Password + "'" +
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
                string querys = "Select * from studentaccount"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_StudentPortal.DataSource = ds.Tables[0];
                        data_StudentPortal.Columns[0].Visible = false;
                    }
                }
                txtStudentAccID.Text = "";
                cmb_StudentID_Por.Text = "";
                txtStudentName_Por.Text = "";
                txtUsername_Por.Text = "";
                txtPassword_Por.Text = "";

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStudentAccountCancel_Click(object sender, EventArgs e)
        {
            Dashboard dashboardv2 = new Dashboard();
            dashboardv2.Show();
            this.Hide();
        }

        private void data_StudentPortal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in data_StudentPortal.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtStudentAccID.Text = row.Cells["Id"].Value.ToString();
                cmb_StudentID_Por.Text = row.Cells["Student_ID"].Value.ToString();
                txtStudentName_Por.Text = row.Cells["Student_Name"].Value.ToString();
                txtUsername_Por.Text = row.Cells["Student_Username"].Value.ToString();
                txtPassword_Por.Text = row.Cells["Student_Password"].Value.ToString();
                // etc.
            }
        }

        private void btnStudentAccountDelete_Click(object sender, EventArgs e)
        {
            string Id = txtStudentAccID.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment";
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

                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment"; //Set your MySQL connection string here.
                string querys = "Select * from studentaccount"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        data_StudentPortal.DataSource = ds.Tables[0];
                        data_StudentPortal.Columns[0].Visible = false;
                    }
                }

                txtStudentAccID.Text = "";
                cmb_StudentID_Por.Text = "";
                txtStudentName_Por.Text = "";
                txtUsername_Por.Text = "";
                txtPassword_Por.Text = "";

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void Student_Account_Load(object sender, EventArgs e)
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
                            cmb_StudentID_Por.Items.Add(reader.GetString("Student_ID"));
                        }
                    }
                }
            }
            string query_stuPort = "Select * from studentaccount";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_stuPort, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    data_StudentPortal.DataSource = ds.Tables[0];
                    data_StudentPortal.Columns[0].Visible = false;
                }
            }
        }
    }
}
