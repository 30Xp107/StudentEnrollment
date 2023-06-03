using DGVPrinterHelper;
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
    public partial class StudentPortalAdmin : Form
    {
        public static string passStudentID;
        Connection connection;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public StudentPortalAdmin()
        {
            InitializeComponent();
            connection = new Connection();
        }
        private void LoadTable()
        {
            string query_Enrollment = "Select * from studentenrollment";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                {
                    DataSet ds = new DataSet();
                    adapater.Fill(ds);

                    dataStudentPortalAdmin.DataSource = ds.Tables[0];
                    dataStudentPortalAdmin.Columns[0].Visible = false;

                    dataStudentPortalAdminPrint.DataSource = ds.Tables[0];
                    dataStudentPortalAdminPrint.Columns[0].Visible = false;
                    dataStudentPortalAdminPrint.Columns[1].Visible = false;
                    dataStudentPortalAdminPrint.Columns[2].Visible = false;
                    dataStudentPortalAdminPrint.Columns[3].Visible = false;
                    dataStudentPortalAdminPrint.Columns[4].Visible = false;
                    dataStudentPortalAdminPrint.Columns[5].Visible = false;
                    //dataStudentPortalAdmin.Columns[9].Visible = false;
                    //dataStudentPortalAdmin.Columns[10].Visible = false;
                    dataStudentPortalAdminPrint.Columns[11].Visible = false;
                    dataStudentPortalAdminPrint.Columns[12].Visible = false;
                    //dataStudentPortalAdmin.Columns[13].Visible = false;
                    //dataStudentPortalAdmin.Columns[14].Visible = false;
                    //dataStudentPortalAdmin.Columns[15].Visible = false;
                    dataStudentPortalAdminPrint.Columns[16].Visible = false;
                    //dataStudentPortalAdmin.Columns[17].Visible = false;
                    dataStudentPortalAdminPrint.Columns[18].Visible = false;
                    //dataStudentPortalAdmin.Columns[19].Visible = false;
                    dataStudentPortalAdminPrint.Columns[20].Visible = false;
                    dataStudentPortalAdminPrint.Columns[21].Visible = false;
                    dataStudentPortalAdminPrint.Columns[22].Visible = false;
                    dataStudentPortalAdminPrint.Columns[23].Visible = false;
                    dataStudentPortalAdminPrint.Columns[24].Visible = false;
                }
            }
        }

        private void StudentPortalAdmin_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string Name = "School Form (SF 1) School Register";
            string Program = "(This replaces Form 1, Master List & LTS Form 2-Family Background and Profile)";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = Name;
            printer.SubTitle = Program;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Programming Exam";
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            printer.PrintDataGridView(dataStudentPortalAdminPrint);
        }

        private void dataStudentPortalAdmin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataStudentPortalAdmin.SelectedCells)
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

            EditEnrollmentFormPortal editEnrollmentFormPortal = new EditEnrollmentFormPortal();
            editEnrollmentFormPortal.Show();
            this.Dispose();
        }
    }
}
