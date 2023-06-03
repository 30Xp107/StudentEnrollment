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
    public partial class AddSubjects : Form
    {
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public AddSubjects()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void LoadTable()
        {
            string query_Enrollment = "Select * from addsubjects";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);
                    dataAddSubjects.DataSource = ds.Tables[0];
                    dataAddSubjects.Columns[0].Visible = false;
                    isUpdaDel();
                }
            }

        }

        private void isUpdaDel()
        {
            if (txtId.Text == string.Empty)
            {
                btnUpdateSubjects.Enabled = false;
                btnDeleteSubjects.Enabled = false;
                btnAddSubjects.Enabled = true;
            }
            else
            {
                btnUpdateSubjects.Enabled = true;
                btnDeleteSubjects.Enabled = true;
                btnAddSubjects.Enabled = false;
            }
        }

        bool ViolationIsEmpty()
        {
            if (txtSubjects.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddSubjects_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void dataAddSubjects_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataAddSubjects.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtSubjects.Text = row.Cells["Subjects"].Value.ToString();
                isUpdaDel();
                // etc.
            }
        }

        private void txtSearchAddSubjects_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from addsubjects where Subjects like '" + txtSearchAddSubjects.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataAddSubjects.DataSource = dt;
            con.Close();
        }

        private void btnBackAddFees_Click(object sender, EventArgs e)
        {
            StudentGradeForm studentGradeForm = new StudentGradeForm();
            studentGradeForm.Show();
            this.Dispose();
        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            string Subjects = txtSubjects.Text;
            if (ViolationIsEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO addsubjects VALUES('','" + Subjects + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtId.Text = string.Empty;
                txtSubjects.Text = string.Empty;

                LoadTable();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnUpdateSubjects_Click(object sender, EventArgs e)
        {
            string ID = txtId.Text;
            string Subjects = txtSubjects.Text;

            // Update the properties of the row with ID 1
            string query = "UPDATE `addsubjects` SET `Subjects`='" + Subjects + "'" +
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
                txtSubjects.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteSubjects_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            // Delete the item with ID 1
            string query = "DELETE FROM `addsubjects` WHERE Id = '" + Id + "'";

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
                txtSubjects.Text = string.Empty;
                LoadTable();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearSubjects_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtSubjects.Text = string.Empty;
            isUpdaDel();
        }
    }
}
