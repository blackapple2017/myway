using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using System.IO;
using System.Xml.Linq;
using SoftCore.AccessHistory;
using SoftCore;

public partial class Modules_TuyenDung_BaoCaoTuyenDung_BaoCaoKetQuaTuyenDung : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();

            SetChartDefault();
        }
    }

    protected void btnSetChartDefault_Click(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfChartUrl.Text))
        {
            XDocument xDoc = XDocument.Load(Server.MapPath("XMLConfig.xml"));
            var linkChart = (from t in xDoc.Descendants("Chart")
                             where t.Attribute("userid").Value == CurrentUser.ID.ToString()
                             select t.Element("UserSetDefault"));
            if (linkChart.Count() != 0)
            {
                linkChart.FirstOrDefault().Value = hdfChartUrl.Text;
                xDoc.Save(Server.MapPath("XMLConfig.xml"));
            }
            else //Tạo mới
            {
                XElement column = new XElement("Chart",
                                      new XElement("UserSetDefault", hdfChartUrl.Text));
                column.SetAttributeValue("userid", CurrentUser.ID);
                xDoc.Root.Add(column);
                xDoc.Save(Server.MapPath("XMLConfig.xml"));
            }


            //Ghi log cho việc thay đổi chart mặc định
            string chartName = string.Empty;
            if (hdfChartUrl.Text.Contains("Country"))
            {
                chartName = "Biểu đồ quốc tịch";
            }
            else
                chartName = hdfChartUrl.Text;
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = "Thay đổi chart mặc định",
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
                MOTA = "Biểu đồ : " + chartName,
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
    }

    private void SetChartDefault()
    {
        if (new FileInfo(Server.MapPath("XMLConfig.xml")).Exists)
        {
            XDocument xDoc = XDocument.Load(Server.MapPath("XMLConfig.xml"));
            try
            {
                var UserSetDefault = (from t in xDoc.Descendants("Chart")
                                      where t.Attribute("userid").Value == CurrentUser.ID.ToString()
                                      select t.Element("UserSetDefault"));
                if (UserSetDefault.Count() != 0)
                {
                    hdfChartUrl.Text = UserSetDefault.FirstOrDefault().Value;
                    lblIframe.Html = string.Format("<iframe height='500' frameborder='0' id='iframeChart' width='100%' src='{0}' />", UserSetDefault.FirstOrDefault().Value);
                }
                else
                {
                    lblIframe.Html = "<iframe height='500' frameborder='0' id='iframeChart' width='100%' src='chart/PieChar.aspx?type=NguonUngVien' />";
                }
            }
            catch (Exception ex)
            {
                X.MessageBox.Alert("Thông báo", ex.Message).Show();
            }
        }
    }

    [DirectMethod]
    public void showWindowMoRong()
    {
        string str_get = hdfChartUrl.Text + "&height=460&size=260";
        wdMoRong.AutoLoad.Url = str_get;
        wdMoRong.AutoLoad.Mode = LoadMode.IFrame;
        wdMoRong.Render(this.Form);
        wdMoRong.Show();
    }

    [DirectMethod]
    public void ReloadStore(int id)
    {
        
    }

    //<ext:RecordField Name="MaKHTD" />
    //                    <ext:RecordField Name="TenKHTD" />
    //                    <ext:RecordField Name="TenPhong" />
    //                    <ext:RecordField Name="TenCongViec" />
    //                    <ext:RecordField Name="TyLeDatSoLoai" />
    //                    <ext:RecordField Name="TyLeTiepNhanThuViec" />
    //                    <ext:RecordField Name="TyLeTiepNhanChinhThuc" />
    //                    <ext:RecordField Name="TyLeNghiSauTuyenDung" />

    //private void BuildSet1()
    //{
    //    if (X.IsAjaxRequest)
    //    {
    //        this.grp_ThongKe_Store.RemoveFields();
    //    }

    //    grp_ThongKe_Store.AddField(new RecordField("MaKHTD"));
    //    grp_ThongKe_Store.AddField(new RecordField("TenPhong"));
    //    grp_ThongKe_Store.AddField(new RecordField("TenCongViec"));
    //    grp_ThongKe_Store.AddField(new RecordField("TyLeDatSoLoai"));
    //    grp_ThongKe_Store.AddField(new RecordField("TyLeTiepNhanThuViec"));
    //    grp_ThongKe_Store.AddField(new RecordField("TyLeTiepNhanChinhThuc"));
    //    grp_ThongKe_Store.AddField(new RecordField("TyLeNghiSauTuyenDung"));
    //    grp_ThongKe_Store.ClearMeta();

    //    BindSet1();

    //    this.GridPanel1.ColumnModel.Columns.Add(new Column { DataIndex = "StringField", Header = "String" });
    //    this.GridPanel1.ColumnModel.Columns.Add(new Column { DataIndex = "IntField", Header = "Int" });
    //    this.GridPanel1.ColumnModel.Columns.Add(new Column { DataIndex = "Timestamp", Header = "Timestamp" });

    //    if (X.IsAjaxRequest)
    //    {
    //        this.Store1.Set("sortInfo", null);
    //        this.Store1.Set("multiSortInfo", null);
    //        this.GridPanel1.Reconfigure();
    //    }
    //}

    //private void BindSet1()
    //{
    //    string now = DateTime.Now.ToLongTimeString();

    //    this.Store1.DataSource = new List<object>
    //                                 {
    //                                     new {StringField = "Set1_1", IntField = 1, Timestamp = now},
    //                                     new {StringField = "Set1_2", IntField = 2, Timestamp = now},
    //                                     new {StringField = "Set1_3", IntField = 3, Timestamp = now}
    //                                 };
    //    this.Store1.DataBind();
    //}
}