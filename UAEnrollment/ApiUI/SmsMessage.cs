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
using UAEnrollment.Api;
using UAEnrollment.Pages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UAEnrollment.ApiUI
{
    public partial class SmsMessage : Form
    {
        private IClient m_currentApi;
        private IResponse m_lastResponse;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=uaenrollment; Convert Zero Datetime=True";
        public SmsMessage()
        {
            InitializeComponent();
            LoadAPIs();
        }
        private void LoadAPIs()
        {
            cbApis.Items.Add(new ClickatellWrapperClient(Credentials.CLICKATELL_API_KEY));
            cbApis.Items.Add(new TwilioWrapperClient(Credentials.TWILIO_ACC_SID, Credentials.TWILIO_AUTH_TOKEN));
        }

        private void cbApis_SelectedValueChanged(object sender, EventArgs e)
        {
            m_currentApi = cbApis.SelectedItem as IClient;

            if (m_currentApi == null)
                return;

            if (!m_currentApi.IsInitialized)
                m_currentApi.Init();

            cbCall.Checked = m_currentApi.CanCall;
            cbSms.Checked = m_currentApi.CanSendSms;

            btnCall.Enabled = m_currentApi.CanCall;
            btnText.Enabled = m_currentApi.CanSendSms;

            txtFrom.Enabled = m_currentApi.FromNumberRequired;
        }

        private async void btnText_Click(object sender, EventArgs e)
        {
            btnText.Enabled = false;

            string from = txtFrom.Text;
            string to = txtTo.Text;
            string body = txtBody.Text;

            SetStatus("Sending...");

            m_lastResponse = await m_currentApi.SendSmsAsync(from, to, body);


            btnText.Enabled = true;
            SetStatus();
        }

        private async void btnCall_Click(object sender, EventArgs e)
        {
            btnCall.Enabled = false;

            string from = txtFrom.Text;
            string to = txtTo.Text;
            string body = txtBody.Text;

            SetStatus("Sending...");

            m_lastResponse = await m_currentApi.CallAsync(from, to, body);

            btnCall.Enabled = true;
            SetStatus();
        }

        private void SetStatus()
        {
            if (m_lastResponse == null)
                return;

            SetStatus(m_lastResponse.Status);
        }

        private void SetStatus(string value)
        {
            lblStatus.Text = $"Status: {value}";
        }

        private async void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (m_lastResponse == null || !m_lastResponse.CanUpdate)
                return;

            await m_lastResponse.UpdateAsync();

            SetStatus();
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
                            cmbStudentId.Items.Add(reader.GetString("StudentID"));
                        }
                    }
                }
            }
        }
        private void SmsMessage_Load(object sender, EventArgs e)
        {
            txtFrom.Text = "+1 315 887 3597";
            cbApis.Text = "Twilio Api";
            txtBody.Text = "ST. NICHOLAS PARISH INSTITUTE INC.\r\n\r\nDear Parents, kindly consider this message as a" +
                " gentle reminder for the payment of your tuition fees installment which is due at the end of this month. Please " +
                "see the cashier's office for the amount to be paid in the upcoming installment. It is requested to kindly pay the " +
                "dues before the said date to avoid late fees. We look forward to your timely response and action.";
            LoadComboBox();

            if (txtTo.Text == "" || txtBody.Text == "")
            {
                btnText.Enabled = true;
            }
            else
            {
                btnText.Enabled = false;
            }
        }

        private void cbApis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentId.Text != "")
            {
                string StudentID = cmbStudentId.Text;
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
                                txtStudentName.Text = readers.GetString(7).ToString();
                                txtTo.Text = readers.GetValue(22).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                txtTo.Text = string.Empty;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentFeeForm studentFeeForm = new StudentFeeForm();
            studentFeeForm.Show();
            this.Dispose();
        }
    }
}