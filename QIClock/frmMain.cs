using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace QIClock
{
    public partial class frmGetData : Form
    {
        public frmGetData()
        {
            InitializeComponent();
            this.RecordSuccess = new List<bool>();
            this.ListErr = new List<string>();
            this.DataSource = new List<Entity>();
            this.binding = new BindingSource();
            this.binding.DataSource = this.DataSource;
        }

        private IList<Entity> DataSource
        {
            get;set;
        }

        private IList<bool> RecordSuccess
        {
            get;
            set;
        }

        private IList<string> ListErr
        {
            get;
            set;
        }

        private bool Connect()
        {
            string IP = Configure.IP;
            int PORT = int.Parse(Configure.Port);
            return axdigisoft1.Connect_Net(ref IP, ref PORT);
        }

        private void getDataIClock()
        {

            if (this.Connect())
            {
                this.RecordSuccess.Clear();
                int dwMachineNumber = 1;
                string dwEnrollNumber = "";
                int dwVerifyMode = 0;
                int dwInOutMode = 0;
                int dwYear = 0;
                int dwMonth = 0;
                int dwDay = 0;
                int dwHour = 0;
                int dwMinute = 0;
                int dwSecond = 0;
                int dwWorkCode = 0;
                int count = 1;

                this.binding.CancelEdit();
                if (this.binding.List.Count > 0)
                {
                    this.binding.Clear();
                    //this.DataSource.Clear();
                }

                if (Configure.IsAuto)
                {

                    DateTime currentDate = DateTime.Now;
                    DateTime beforeDate = currentDate.AddDays(-Configure.NumberDays);

                    while (axdigisoft1.SSR_GetGeneralLogData(ref dwMachineNumber, ref dwEnrollNumber, ref dwVerifyMode,
                            ref dwInOutMode, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond, ref dwWorkCode))
                    {
                        DateTime d = new DateTime(dwYear, dwMonth, dwDay);
                        TimeSpan t = currentDate.Subtract(d);
                        if (t.TotalDays <= Configure.NumberDays && t.TotalDays >= 0)
                        {
                            Entity record = new Entity()
                            {
                                STT = count,
                                EnrollNumber = dwEnrollNumber,
                                VerifyMode = dwVerifyMode,
                                InOutMode = dwInOutMode,
                                Date = dwDay + "-" + dwMonth + "-" + dwYear,
                                Hour = dwHour + ":" + dwMinute + ":" + dwSecond
                            };

                            this.DataSource.Add(record);

                            ChamCongeReference.InOutTimeSoapClient chamcong = new ChamCongeReference.InOutTimeSoapClient();
                            string id = dwEnrollNumber + dwDay + dwMonth + dwYear + dwHour + dwMinute + dwSecond;
                            DateTime ngayChamCong = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
                            try
                            {
                                ChamCongeReference.UpdateDataRequest r = new ChamCongeReference.UpdateDataRequest();
                                ChamCongeReference.UpdateDataRequestBody rbody = new ChamCongeReference.UpdateDataRequestBody(id, dwEnrollNumber, "", dwInOutMode == 1 ? true : false, ngayChamCong);
                                r.Body = rbody;
                                RecordSuccess.Add(chamcong.UpdateData(r).Body.UpdateDataResult);
                            }
                            catch (Exception ex)
                            {
                                string entity = "";
                                if (id == null)
                                {
                                    entity += "id ";
                                }
                                if (dwEnrollNumber == null)
                                {
                                    entity += "dwEnrollNumber ";
                                }
                                if (dwInOutMode == null)
                                {
                                    entity += "dwInOutMode ";
                                }
                                if (ngayChamCong == null)
                                {
                                    entity += "ngayChamCong ";
                                }
                                if (chamcong == null)
                                {
                                    entity += "ChamCongWS";
                                }
                                RecordSuccess.Add(false);
                                ListErr.Add(ex.ToString() + " "+ entity);
                            }

                            count++;
                        }
                    }

                }
                else
                {
                    while (axdigisoft1.SSR_GetGeneralLogData(ref dwMachineNumber, ref dwEnrollNumber, ref dwVerifyMode,
                               ref dwInOutMode, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond, ref dwWorkCode))
                    {
                        DateTime d = new DateTime(dwYear, dwMonth, dwDay);
                        int result1 = DateTime.Compare(Configure.FromDate, d);// < 0 FromDate earlier than d
                        int result2 = DateTime.Compare(Configure.ToDate, d);// > 0 FromDate later than d
                        if (result1 <= 0 && result2 >= 0)
                        {

                            Entity record = new Entity()
                            {
                                STT = count,
                                EnrollNumber = dwEnrollNumber,
                                VerifyMode = dwVerifyMode,
                                InOutMode = dwInOutMode,
                                Date = dwDay + "-" + dwMonth + "-" + dwYear,
                                Hour = dwHour + ":" + dwMinute + ":" + dwSecond
                            };

                            this.DataSource.Add(record);
                            ChamCongeReference.InOutTimeSoapClient chamcong = new ChamCongeReference.InOutTimeSoapClient();
                            string id = dwEnrollNumber + dwDay + dwMonth + dwYear + dwHour + dwMinute + dwSecond;
                            DateTime ngayChamCong = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
                            try
                            {
                                ChamCongeReference.UpdateDataRequest r = new ChamCongeReference.UpdateDataRequest();
                                ChamCongeReference.UpdateDataRequestBody rbody = new ChamCongeReference.UpdateDataRequestBody(id, dwEnrollNumber, "", dwInOutMode == 1 ? true : false, ngayChamCong);
                                r.Body = rbody;
                                RecordSuccess.Add(chamcong.UpdateData(r).Body.UpdateDataResult);
                            }
                            catch (Exception ex)
                            {
                                string entity = "";
                                if (id == null)
                                {
                                    entity += "id ";
                                }
                                if (dwEnrollNumber == null)
                                {
                                    entity += "dwEnrollNumber ";
                                }
                                if (dwInOutMode == null)
                                {
                                    entity += "dwInOutMode ";
                                }
                                if (ngayChamCong == null)
                                {
                                    entity += "ngayChamCong ";
                                }
                                if (chamcong == null)
                                {
                                    entity += "ChamCongWS";
                                }

                                RecordSuccess.Add(false);
                                ListErr.Add(ex.ToString() + " " + entity);
                            }

                            count++;
                        }
                    }
                }
            }

        }

        private BindingSource binding
        {
            get;
            set;
        }

        private void frmGetData_Load(object sender, EventArgs e)
        {
            this.tblChamCong.DataSource = binding;

            loadConfigure();

            if (Configure.IsAuto)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnGetData.Enabled = false;
                
            }
            else
            {
                btnGetData.Enabled = true;
                btnStart.Enabled = false;
                btnStop.Enabled = false;
            }
        }

        private void loadConfigure()
        {
            if (
                ConfigurationManager.AppSettings["IP"].Length != 0)
            {
                Configure.IP = ConfigurationManager.AppSettings["IP"];
            }
            else
            {
                Configure.IP = "127.0.0.1";
            }

            if (
                ConfigurationManager.AppSettings["Port"].Length != 0)
            {
                Configure.Port = ConfigurationManager.AppSettings["Port"];
            }
            else
            {
                Configure.Port = "4307";
            }
            if (
                ConfigurationManager.AppSettings["Auto"].Length != 0)
            {
                Configure.IsAuto = bool.Parse(ConfigurationManager.AppSettings["Auto"]);
            }
            else
            {
                Configure.isTime = false;
            }
            if (
                ConfigurationManager.AppSettings["Time"].Length != 0)
            {
                Configure.Time = DateTime.Parse(ConfigurationManager.AppSettings["Time"]);
            }
            else
            {
                Configure.Time = DateTime.Now;
            }
            if (
                ConfigurationManager.AppSettings["NumberOfDays"].Length != 0)
            {
                Configure.NumberDays = int.Parse(ConfigurationManager.AppSettings["NumberOfDays"]);
            }
            else
            {
                Configure.NumberDays = 2;
            }
            if (
                ConfigurationManager.AppSettings["FromDate"].Length != 0)
            {
                Configure.FromDate = DateTime.Parse(ConfigurationManager.AppSettings["FromDate"]);
            }
            else
            {
                Configure.FromDate = DateTime.Now.AddDays(-2);
            }

            if (
                ConfigurationManager.AppSettings["ToDate"].Length != 0)
            {
                Configure.ToDate = DateTime.Parse(ConfigurationManager.AppSettings["ToDate"]);
            }
            else
            {
                Configure.ToDate = DateTime.Now;
            }

            if (
               ConfigurationManager.AppSettings["isTime"].Length != 0)
            {
                Configure.isTime = bool.Parse(ConfigurationManager.AppSettings["isTime"]);
            }
            else
            {
                Configure.isTime = false;
            }
            if (
               ConfigurationManager.AppSettings["Interval"].Length != 0)
            {
                Configure.Interval = int.Parse(ConfigurationManager.AppSettings["Interval"]);
            }
            else
            {
                Configure.Interval = 120;
            }
            if (!Configure.isTime)
            {
                this.timer1.Interval = 1000 * Configure.Interval * 60;
            }
            else
            {
                this.timer1.Interval = 1000;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Configure.isTime)
            {
                if (DateTime.Now.ToShortTimeString() == Configure.Time.ToShortTimeString())
                {
                    popupContainerControl1.Show();
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
            else
            {
                if (!backgroundWorker1.IsBusy)
                {
                    popupContainerControl1.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            getDataIClock();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           

            popupContainerControl1.Hide();
//            this.dtIClock.AcceptChanges();
            //StringBuilder sm = new StringBuilder();
            //sm.Append(String.Format("Số bản ghi: {0}", RecordSuccess.Count));
            //sm.AppendLine(String.Format("Số bản ghi up thành công: {0}", RecordSuccess.Count(m => m == true)));
            //sm.AppendLine(String.Format("Số bản ghi up thất bại: {0}", RecordSuccess.Count(m => m == false)));
            CurrencyManager cm = (CurrencyManager)this.tblChamCong.BindingContext[this.binding];
            if (cm != null)
            {
                cm.Refresh();
            }
            Log(RecordSuccess.Count, RecordSuccess.Count(m => m == true), RecordSuccess.Count(m => m == false), "");
            if (!Configure.IsAuto)
            {
                btnGetData.Enabled = true;
                this.timer1.Stop();
            }
            if (!btnSetting.Enabled)
            {
                btnSetting.Enabled = true;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void btnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmConfigure f = new frmConfigure();
            f.ShowDialog();
            loadConfigure();
            if (Configure.IsAuto)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnGetData.Enabled = false;
            }
            else
            {
                btnGetData.Enabled = true;
                btnStart.Enabled = false;
                btnStop.Enabled = false;
            }
        }

        private void btnGetData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnGetData.Enabled = false;
            this.btnSetting.Enabled = false;
            this.popupContainerControl1.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnStop.Enabled = true;
            this.btnStart.Enabled = false;
            this.btnSetting.Enabled = false;
            //popupContainerControl1.Show();
            this.timer1.Start();
        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnSetting.Enabled = true;
            this.timer1.Stop();
            this.popupContainerControl1.Hide();
        }

        private void Log(int Total, int Success, int Fail, string err)
        {
           

            if (File.Exists("log.xml"))
            {
                XDocument doc = XDocument.Load("log.xml");
                XElement Log = doc.Element("Log");
                Log.Add(new XElement("Date",
                    new XAttribute("logDate", DateTime.Now.ToString()),
                    new XElement("Total", Total.ToString()),
                    new XElement("Succes", Success.ToString()),
                    new XElement("Fail", Fail.ToString()),
                    new XElement("Error", ListErr.Count != 0 ? ListErr.First().ToString() : "")));
                doc.Save("log.xml");
                
            }
            else
            {
                XmlWriter writer = XmlWriter.Create("log.xml", null);
                writer.WriteStartElement("Log");
                writer.WriteStartElement("Date"); 
                writer.WriteAttributeString("logDate", DateTime.Now.ToString());       
                writer.WriteElementString("Total", Total.ToString());
                writer.WriteElementString("Success", Success.ToString());
                writer.WriteElementString("Fail", Fail.ToString());
                writer.WriteElementString("Error", ListErr.Count != 0  ? ListErr.First().ToString() : "");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
            
        }

        private void frmGetData_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState || FormWindowState.Maximized == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        int count = 0;
        private void frmGetData_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                const string message = "Khi tắt phần mềm dữ liệu chấm công sẽ không được cập nhật. Bạn có chắc chắn muốn tắt không?";
                const string caption = "Xác nhận";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
               
                if (result == DialogResult.Yes)
                {
                    if (count == 0)
                    {
                        if (this.timer1 != null)
                            this.timer1.Stop();
                        axdigisoft1.Disconnect();
                        ListErr.Add("Program stopped");
                        Log(0, 0, 0, "");
                    }
                    
                    count++;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                ListErr.Add("Error when closing form: " + ex.Message);
                Log(0, 0, 1, "");
            }
        }
    }
}
