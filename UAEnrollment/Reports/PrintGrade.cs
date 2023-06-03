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
    public partial class PrintGrade : Form
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
            IsEnabled();
            MemoryImage = ControlPrinter.ScrollableControlToBitmap(this.panel2, true, true);
            IsEnabled();
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
            IsEnabled();
        }
        public PrintGrade()
        {
            InitializeComponent();
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

        private void IsEnabled()
        {
            if (this.panel5.Controls.Count <= 0)
            {
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
            }
            else
            {
                this.panel4.Visible = true;
                this.panel5.Visible = true;
                this.panel6.Visible = true;
            }
            if (this.panel8.Controls.Count <= 0)
            {
                this.panel8.Visible = false;
                this.panel7.Visible = false;
                this.panel9.Visible = false;
            }
            else
            {
                this.panel8.Visible = true;
                this.panel7.Visible = true;
                this.panel9.Visible = true;
            }
            if (this.panel10.Controls.Count <= 0)
            {
                this.panel10.Visible = false;
                this.panel11.Visible = false;
                this.panel13.Visible = false;
            }
            else
            {
                this.panel10.Visible = true;
                this.panel11.Visible = true;
                this.panel13.Visible = true;
            }
            if (this.panel15.Controls.Count <= 0)
            {
                this.panel14.Visible = false;
                this.panel15.Visible = false;
                this.panel12.Visible = false;
            }
            else
            {
                this.panel14.Visible = true;
                this.panel15.Visible = true;
                this.panel12.Visible = true;
            }
            if (this.panel16.Controls.Count <= 0)
            {
                this.panel16.Visible = false;
                this.panel17.Visible = false;
                this.panel19.Visible = false;
            }
            else
            {
                this.panel16.Visible = true;
                this.panel17.Visible = true;
                this.panel19.Visible = true;
            }
            if (this.panel21.Controls.Count <= 0)
            {
                this.panel21.Visible = false;
                this.panel20.Visible = false;
                this.panel18.Visible = false;
            }
            else
            {
                this.panel21.Visible = true;
                this.panel20.Visible = true;
                this.panel18.Visible = true;
            }
            if (this.panel22.Controls.Count <= 0)
            {
                this.panel22.Visible = false;
                this.panel23.Visible = false;
                this.panel25.Visible = false;
            }
            else
            {
                this.panel22.Visible = true;
                this.panel23.Visible = true;
                this.panel25.Visible = true;
            }
            if (this.panel27.Controls.Count <= 0)
            {
                this.panel27.Visible = false;
                this.panel24.Visible = false;
                this.panel26.Visible = false;
            }
            else
            {
                this.panel27.Visible = true;
                this.panel24.Visible = true;
                this.panel26.Visible = true;
            }
            if (this.panel29.Controls.Count <= 0)
            {
                this.panel29.Visible = false;
                this.panel28.Visible = false;
                this.panel30.Visible = false;
            }
            else
            {
                this.panel29.Visible = true;
                this.panel28.Visible = true;
                this.panel30.Visible = true;
            }
            if (this.panel32.Controls.Count <= 0)
            {
                this.panel31.Visible = false;
                this.panel32.Visible = false;
                this.panel33.Visible = false;
            }
            else
            {
                this.panel31.Visible = true;
                this.panel32.Visible = true;
                this.panel33.Visible = true;
            }
            if (this.panel35.Controls.Count <= 0)
            {
                this.panel34.Visible = false;
                this.panel35.Visible = false;
                this.panel36.Visible = false;
            }
            else
            {
                this.panel34.Visible = true;
                this.panel35.Visible = true;
                this.panel36.Visible = true;
            }
            if (this.panel38.Controls.Count <= 0)
            {
                this.panel37.Visible = false;
                this.panel38.Visible = false;
                this.panel39.Visible = false;
            }
            else
            {
                this.panel37.Visible = true;
                this.panel38.Visible = true;
                this.panel39.Visible = true;
            }
        }

        private Label ViewLearnAreas(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(159, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }

        private Label ViewRemarks(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(597, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }

        private Label ViewClassifiedGrade(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(272, 2);
            lbl.Visible = true;
            lbl.Width = 50;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }

        private Label ViewSchoolYear(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(423, 2);
            lbl.Visible = true;
            lbl.Width = 50;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }

        private Label ViewAdviser(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(656, 2);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7, FontStyle.Bold);
            lbl.Show();
            return lbl;
        }

        private Label Subjects(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(159, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7);
            lbl.Show();
            return lbl;
        }

        private Label Remarks(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(597, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Palatino Linotype", 7);
            lbl.Show();
            return lbl;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtLRN.Text != string.Empty)
            {
                Print();
                IsEnabled();
            }
            else
            {
                MessageBox.Show("Please Enter LRN.");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void PrintGrade_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            IsEnabled();
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudent.Text != "")
            {
                string StudentID = cmbStudent.Text;
                using (var connections = new MySqlConnection(connectionString))
                {
                    connections.Open();
                    var queryss = "SELECT * FROM studentenrollment where StudentID = '" + StudentID + "'";
                    using (var commandss = new MySqlCommand(queryss, connections))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                txtStudentName.Text = readers.GetValue(7).ToString();
                                txtSex.Text = readers.GetValue(8).ToString();
                                txtDateBirth.Text = readers.GetValue(10).ToString();
                                //txtDateEnrolled_Fee.Text = readers.GetValue(21).ToString();
                            }
                        }
                    }
                    var gradequeryI = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'I'";
                    using (var commandsss = new MySqlCommand(gradequeryI, connections))
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
                                this.panel4.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel4.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel4.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel5.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel5.Controls.Add(ViewRemarks("Remarks"));
                                this.panel6.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel6.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                    var gradequeryII = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'II'";
                    using (var commandsss = new MySqlCommand(gradequeryII, connections))
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
                                this.panel7.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel7.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel7.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel8.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel8.Controls.Add(ViewRemarks("Remarks"));
                                this.panel9.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel9.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                    var gradequeryIII = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'III'";
                    using (var commandsss = new MySqlCommand(gradequeryIII, connections))
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
                                this.panel11.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel11.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel11.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel10.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel10.Controls.Add(ViewRemarks("Remarks"));
                                this.panel13.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel13.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }

                    var gradequeryIV = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'IV'";
                    using (var commandsss = new MySqlCommand(gradequeryIV, connections))
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
                                this.panel12.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel12.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel12.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel15.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel15.Controls.Add(ViewRemarks("Remarks"));
                                this.panel14.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel14.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                    var gradequeryV = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'V'";
                    using (var commandsss = new MySqlCommand(gradequeryV, connections))
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
                                this.panel17.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel17.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel17.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel16.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel16.Controls.Add(ViewRemarks("Remarks"));
                                this.panel19.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel19.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                    var gradequeryVI = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'VI'";
                    using (var commandsss = new MySqlCommand(gradequeryVI, connections))
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
                                this.panel18.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel18.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel18.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel21.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel21.Controls.Add(ViewRemarks("Remarks"));
                                this.panel20.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel20.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                    var gradequeryVII = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'VII'";
                    using (var commandsss = new MySqlCommand(gradequeryVII, connections))
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
                                this.panel23.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel23.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel23.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel22.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel22.Controls.Add(ViewRemarks("Remarks"));
                                this.panel25.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel25.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }

                    var gradequeryVIII = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'VIII'";
                    using (var commandsss = new MySqlCommand(gradequeryVIII, connections))
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
                                this.panel24.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel24.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel24.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel27.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel27.Controls.Add(ViewRemarks("Remarks"));
                                this.panel26.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel26.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }

                    var gradequeryIX = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'IX'";
                    using (var commandsss = new MySqlCommand(gradequeryIX, connections))
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
                                this.panel30.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel30.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel30.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel29.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel29.Controls.Add(ViewRemarks("Remarks"));
                                this.panel28.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel28.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }

                    var gradequeryX = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'X'";
                    using (var commandsss = new MySqlCommand(gradequeryX, connections))
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
                                this.panel33.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel33.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel33.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel32.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel32.Controls.Add(ViewRemarks("Remarks"));
                                this.panel31.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel31.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }

                    var gradequeryXI = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'XI'";
                    using (var commandsss = new MySqlCommand(gradequeryXI, connections))
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
                                this.panel36.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel36.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel36.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel35.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel35.Controls.Add(ViewRemarks("Remarks"));
                                this.panel34.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel34.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }

                    var gradequeryXII = "SELECT * FROM studentgrade WHERE StudentID = '" + StudentID + "' AND ClassifiedGrade = 'XII'";
                    using (var commandsss = new MySqlCommand(gradequeryXII, connections))
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
                                this.panel39.Controls.Add(ViewClassifiedGrade(readerss.GetValue(3).ToString()));
                                this.panel39.Controls.Add(ViewSchoolYear(readerss.GetValue(5).ToString()));
                                this.panel39.Controls.Add(ViewAdviser(readerss.GetValue(6).ToString()));
                                this.panel38.Controls.Add(ViewLearnAreas("Learning Areas"));
                                this.panel38.Controls.Add(ViewRemarks("Remarks"));
                                this.panel37.Controls.Add(Subjects(readerss.GetValue(4).ToString(), count));
                                this.panel37.Controls.Add(Remarks(readerss.GetValue(8).ToString(), count));
                                //this.panel4.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                                //this.panel4.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                                DefaultHeight = DefaultHeight + 20;//
                                //this.panel4.Height += 40;
                                // this.panel1.Height += 40;
                            }
                        }
                    }
                }
                IsEnabled();
                cmbStudent.Enabled = false;
            }
            else
            {
                txtStudentName.Text = string.Empty;
                txtSex.Text = string.Empty;
                txtDateBirth.Text = string.Empty;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentGradeForm studentGradeForm = new StudentGradeForm();
            studentGradeForm.Show();
            this.Dispose();
        }
    }
}
