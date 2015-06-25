using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace QIClock
{
    public partial class frmConfigure : Form
    {
        public frmConfigure()
        {
            InitializeComponent();
            loadConfigure();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && dxValidationProvider2.Validate())
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                Configure.IP = txtIP.EditValue.ToString();
                Configure.Port = txtPort.EditValue.ToString();

                configuration.AppSettings.Settings["IP"].Value = Configure.IP;
                configuration.AppSettings.Settings["Port"].Value = Configure.Port;
                if (Configure.IsAuto)
                {
                    if (Configure.isTime)
                    {
                        Configure.Time = DateTime.Parse(txtTime.EditValue.ToString());
                    }
                    else
                    {
                        Configure.Interval = int.Parse(txtInterval.EditValue.ToString());
                        configuration.AppSettings.Settings["Interval"].Value = Configure.Interval.ToString();
                        
                    }
                    Configure.NumberDays = int.Parse(txtNumberDays.EditValue.ToString());
                    configuration.AppSettings.Settings["isTime"].Value = Configure.isTime.ToString();
                    configuration.AppSettings.Settings["Time"].Value = Configure.Time.ToString();
                    configuration.AppSettings.Settings["NumberOfDays"].Value = Configure.NumberDays.ToString();
                }
                else
                {
                    Configure.FromDate = DateTime.Parse(deFromDate.EditValue.ToString());
                    Configure.ToDate = DateTime.Parse(deToDate.EditValue.ToString());
                    configuration.AppSettings.Settings["FromDate"].Value = Configure.FromDate.ToString();
                    configuration.AppSettings.Settings["ToDate"].Value = Configure.ToDate.ToString();
                }

                configuration.AppSettings.Settings["Auto"].Value = Configure.IsAuto.ToString();
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
                this.Close();
            }
            
        }

        private void rgMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgMode.EditValue.ToString() == "Auto" )
            {
                Configure.IsAuto = true;
                grAuto.Enabled = true;
                grManu.Enabled = false;
            }
            else if (rgMode.EditValue.ToString() == "Manu")
            {
                Configure.IsAuto = false;
                grAuto.Enabled = false;
                grManu.Enabled = true;
            }
        }

        private void frmConfigure_Load(object sender, EventArgs e)
        {
            
        }

        private void loadConfigure()
        {
            txtIP.EditValue = Configure.IP;
            txtPort.EditValue = Configure.Port;
            if (Configure.IsAuto)
            {
                 rgMode.SelectedIndex = 0;

            }
            else
            {
                rgMode.SelectedIndex = 1;
            }
            txtTime.EditValue = Configure.Time;
            txtNumberDays.EditValue = Configure.NumberDays;
            deFromDate.EditValue = Configure.FromDate;
            deToDate.EditValue = Configure.ToDate;
            if (Configure.isTime)
            {
                radioGroup1.SelectedIndex = 0;
            }
            else
            {
                radioGroup1.SelectedIndex = 1;
            }
            txtInterval.EditValue = Configure.Interval;
        }

        private void radioGroup1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue == "Interval")
            {
                txtTime.Enabled = false;
                txtInterval.Enabled = true;
                Configure.isTime = false;
            }
            else
            {
                txtTime.Enabled = true;
                txtInterval.Enabled = false;
                Configure.isTime = true;
            }
        }
    }
}
