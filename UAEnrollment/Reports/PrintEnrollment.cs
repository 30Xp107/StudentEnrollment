using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAEnrollment.Pages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UAEnrollment.Reports
{
    public partial class PrintEnrollment : Form
    {
        PrintDocument printDocument = new PrintDocument();
        PrintDialog printDialog = new PrintDialog();
        private int page = 0;
        Bitmap MemoryImage;
        int DefaultHeight = 10;
        int DefaultHeightTotal = 310;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        private void GetPrintArea(Control pnl)
        {
            page = 0;
            MemoryImage = ControlPrinter.ScrollableControlToBitmap(this.panel2, true, true);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        public PrintEnrollment()
        {
            InitializeComponent();
            Load += PrintEnrollment_Shown;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var bitmap = ControlPrinter.ScrollableControlToBitmap(this.panel2, true, true);
            //1 Page

            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(bitmap, (pagearea.Width / 2) - (panel2.Width / 2), panel2.Location.Y);


            //2 Pages

            //var pagearea = e.PageBounds;
            //e.Graphics.DrawImage(MemoryImage, new Rectangle(e.PageBounds.Location, e.PageBounds.Size), new Rectangle(e.PageBounds.Location.X, e.PageBounds.Height * page, e.PageBounds.Width, e.PageBounds.Height), GraphicsUnit.Pixel);
            //e.HasMorePages = e.PageBounds.Height * page < panel2.Size.Height;
            //page++;
        }
        public void Print()
        {
            GetPrintArea(panel2);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            printDialog.Document = printDocument;

            //preview.Document = printDocument;
            //printDialog.ShowDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }
        }
        private Label FeesDisplay(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(3, 4);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }
        private Label AmountDisplay(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(3, 4);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }
        private Label PaymentDisplay(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(3, 4);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }
        private Label TotalDisplay(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(116, DefaultHeight);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }

        private Label Fees(string text, int count)
        {
            //Label lbl = new Label();
            //lbl.Name = "name";
            //lbl.Text = text;
            //lbl.Location = new Point(22, 13);
            //lbl.Visible = true;
            //lbl.Width = 200;
            //lbl.ForeColor = Color.Black;
            //lbl.Font = new Font("Verdana", 10);
            //lbl.Show();
            //return lbl;t
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(12, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7);
            lbl.Show();
            return lbl;
        }
        private Label Amount(string text, int count)
        {
            //Label lbl = new Label();
            //lbl.Name = "name";
            //lbl.Text = text;
            //lbl.Location = new Point(150, 13);
            //lbl.Visible = true;
            //lbl.Width = 200;
            //lbl.ForeColor = Color.Black;
            //lbl.Font = new Font("Verdana", 10);
            //lbl.Show();
            //return lbl;
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(145, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7);
            lbl.Show();
            return lbl;
        }
        private Label Payment(string text, int count)
        {
            //Label lbl = new Label();
            //lbl.Name = "name";
            //lbl.Text = text;
            //lbl.Location = new Point(268, 13);
            //lbl.Visible = true;
            //lbl.Width = 200;
            //lbl.ForeColor = Color.Black;
            //lbl.Font = new Font("Verdana", 10);
            //lbl.Show();
            //return lbl;
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(239, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7);
            lbl.Show();
            return lbl;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
            //if (!string.IsNullOrEmpty(txtSchoolYear.Text))
            //{
            //    Print();
            //}
            //else
            //{
            //    MessageBox.Show("Please Input School Year.");
            //}
        }

        private void LoadData()
        {
            if (cmbStudent.Text != "")
            {
                string StudentID = cmbStudent.Text;
                using (var connectionss = new MySqlConnection(connectionString))
                {
                    connectionss.Open();
                    var queryss = "SELECT * FROM studentenrollment where StudentID = '" + StudentID + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtStatus.Text = readers.GetValue(1).ToString();
                                txtRFNo.Text = readers.GetValue(2).ToString();
                                txtDateEnrolled.Text = readers.GetValue(3).ToString();
                                txtSchoolYear.Text = readers.GetValue(4).ToString();
                                txtCurriculumYear.Text = readers.GetValue(5).ToString();
                                txtStudentID.Text = readers.GetValue(6).ToString();
                                txtStudentName.Text = readers.GetValue(7).ToString();
                                txtSex.Text = readers.GetValue(8).ToString();
                                txtAge.Text = readers.GetValue(9).ToString();
                                txtDateBirth.Text = readers.GetValue(10).ToString();
                                txtPlaceBirth.Text = readers.GetValue(11).ToString();
                                txtCitizenship.Text = readers.GetValue(12).ToString();
                                txtStudentAddress.Text = readers.GetValue(13).ToString();
                                txtReligion.Text = readers.GetValue(14).ToString();
                                txtFathersName.Text = readers.GetValue(15).ToString();
                                txtFathersOccupation.Text = readers.GetValue(16).ToString();
                                txtMothersName.Text = readers.GetValue(17).ToString();
                                txtMothersOccupation.Text = readers.GetValue(18).ToString();
                                txtGuardianName.Text = readers.GetValue(19).ToString();
                                txtAddress.Text = readers.GetValue(20).ToString();
                                txtStudentRelation.Text = readers.GetValue(23).ToString();
                                txtSchoolLastAttended.Text = readers.GetValue(23).ToString();
                                txtSchoolLastAttendedAddress.Text = readers.GetValue(24).ToString();


                                txtStatus1.Text = readers.GetValue(1).ToString();
                                txtRFNo1.Text = readers.GetValue(2).ToString();
                                txtDateEnrolled1.Text = readers.GetValue(3).ToString();
                                txtSchoolYear1.Text = readers.GetValue(4).ToString();
                                txtCurriculumYear1.Text = readers.GetValue(5).ToString();
                                txtStudentID1.Text = readers.GetValue(6).ToString();
                                txtStudentName1.Text = readers.GetValue(7).ToString();
                                txtSex1.Text = readers.GetValue(8).ToString();
                                txtAge1.Text = readers.GetValue(9).ToString();
                                txtDateBirth1.Text = readers.GetValue(10).ToString();
                                txtPlaceBirth1.Text = readers.GetValue(11).ToString();
                                txtCitizenship1.Text = readers.GetValue(12).ToString();
                                txtStudentAddress1.Text = readers.GetValue(13).ToString();
                                txtReligion1.Text = readers.GetValue(14).ToString();
                                txtFathersName1.Text = readers.GetValue(15).ToString();
                                txtFathersOccupation1.Text = readers.GetValue(16).ToString();
                                txtMothersName1.Text = readers.GetValue(17).ToString();
                                txtMothersOccupation1.Text = readers.GetValue(18).ToString();
                                txtGuardianName1.Text = readers.GetValue(19).ToString();
                                txtAddress1.Text = readers.GetValue(20).ToString();
                                txtStudentRelation1.Text = readers.GetValue(23).ToString();
                                txtSchoolLastAttended1.Text = readers.GetValue(23).ToString();
                                txtSchoolLastAttendedAddress1.Text = readers.GetValue(24).ToString();
                            }
                        }
                    }
                }
                string query_Enrollment = "Select * from studentfees Where StudentID = '" + StudentID + "'";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapater = new MySqlDataAdapter(query_Enrollment, conn))
                    {
                        DataSet ds = new DataSet();
                        adapater.Fill(ds);
                        dataPrint.DataSource = ds.Tables[0];
                        dataPrint.Columns[0].Visible = false;
                        dataPrint.Columns[1].Visible = false;
                        dataPrint.Columns[2].Visible = false;
                        dataPrint.Columns[3].Visible = false;
                        dataPrint.Columns[4].Visible = false;
                    }
                }

                int sum = 0;
                for (int i = 0; i < dataPrint.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataPrint.Rows[i].Cells[6].Value);
                }
                txtTotal.Text = "Php " + sum.ToString();
                txtTotal1.Text = "Php " + sum.ToString();

                using (var connections = new MySqlConnection(connectionString))
                {
                    connections.Open();
                    var queryss = "SELECT * FROM studentfees where StudentID = '" + StudentID + "'";
                    using (var commandsss = new MySqlCommand(queryss, connections))
                    {
                        using (var readerss = commandsss.ExecuteReader())
                        {
                            int count = 0;
                            double text = 0.0;
                            //Iterate through the rows and add it to the combobox's items
                            while (readerss.Read())
                            {
                                count++;
                                //this.panel4.Controls.Add(FeesDisplay("Fee"));
                                //this.panel5.Controls.Add(AmountDisplay("Amount"));
                                //this.panel6.Controls.Add(PaymentDisplay("Payment"));
                                //this.panel7.Controls.Add(TotalDisplay(txtTotal.Text));
                                this.panel7.Controls.Add(Fees(readerss.GetValue(5).ToString(), count));
                                this.panel7.Controls.Add(Amount(readerss.GetValue(6).ToString(), count));
                                this.panel7.Controls.Add(Payment(readerss.GetValue(7).ToString(), count));
                                this.panel10.Controls.Add(Fees(readerss.GetValue(5).ToString(), count));
                                this.panel10.Controls.Add(Amount(readerss.GetValue(6).ToString(), count));
                                this.panel10.Controls.Add(Payment(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                }
            }
            else
            {
                txtStudentName.Text = string.Empty;
                txtStudentID.Text = string.Empty;
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadComboBox()
        {
            using (var connections = new MySqlConnection(connectionString))
            {
                connections.Open();
                var querys = "SELECT * FROM studentenrollment";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbStudent.Items.Add(reader.GetString("StudentID"));
                        }
                    }
                }
            }
        }

        private void PrintEnrollment_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboardv2 dashboardv2 = new Dashboardv2();
            dashboardv2.Show();
            this.Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrintEnrollment_Shown(object sender, EventArgs e)
        {
            cmbStudent.Text = EditEnrollmentForm.passStudentID;
            //LoadData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
