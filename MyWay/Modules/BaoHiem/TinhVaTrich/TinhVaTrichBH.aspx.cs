using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Ext.Net;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq.Expressions;
using System.Globalization;
using ExtMessage;
using System.IO;
using LinqToExcel;
using System.Xml;
using System.Xml.Xsl;
 
public partial class Modules_BaoHiem_TinhVaTrichBH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearch.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }
    }
    protected void bt_update(object sender, DirectEventArgs e)
    {
        //try
        //{
        int id = Convert.ToInt32("0" + hdfMa.Text);
        double nvbhxh = Convert.ToDouble("0" + nfNVBHXH.Text);
        double nvbhyt = Convert.ToDouble("0" + nfNVBHYT.Text);
        double nvbhtn = Convert.ToDouble("0" + nfNVBHTN.Text);
        double dvbhxh = Convert.ToDouble("0" + nfDVBHXH.Text);
        double dvbhyte = Convert.ToDouble("0" + nfDVBHYT.Text);
        double dvbhtn = Convert.ToDouble("0" + nfDVBHTN.Text);
        new TinhVaTrichController().UpdateTienTrichBH(id, nvbhxh, nvbhyt, nvbhtn, dvbhxh, dvbhyte, dvbhtn);
        grpDangKyDongMoiBaoHiem.Reload();
        wdUpdate.Hide();
        Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
        //}
        //catch (Exception x)
        //{
        //    Dialog.ShowNotification("Thông báo", "Không cập nhật được dữ liệu");
        //}
    }
    protected void grpTinhVaTrichBaoHiem_store_Submit(object sender, StoreSubmitDataEventArgs e)
    {
        //try
        //{
            var json = FormatType.Value.ToString();
            var eSubmit = new StoreSubmitDataEventArgs(json, null);
            var xml = eSubmit.Xml;

            if (xml.InnerText == "")
            {
                X.Msg.Alert("Thông báo", "Không có dữ liệu để xuất ra file Excel").Show();
                return;
            }
            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=Export_Tieu_Chi_Danh_Gia.xls");
            var xtExcel = new System.Xml.Xsl.XslCompiledTransform();
            xtExcel.Load(Server.MapPath("../Export/Excel.xsl"));

            xtExcel.Transform(xml, null, Response.OutputStream);
            Response.End();
        //}
        //catch (Exception ex)
        //{
        //    X.Msg.Alert("Thông báo", ex.Message).Show();
        //}
    }
    public void btnTinhVaTrichLuongClick(object sender, DirectEventArgs e)
    {
        TinhVaTrichController tvc = new TinhVaTrichController();
        if (hdfDaKhoa.Text == "true")
        {
            X.Msg.Alert("Thông báo", "Bảng tính lương này đã bị khóa").Show(); 
            return;
        }
        //true: có check số ngày đi làm tháng trước có <15 ngày không
        int sobanghi = tvc.TinhVaTrichLuongThang(int.Parse("0" + hdfIDBangLuong.Text), false);
        Dialog.ShowNotification("Thông báo", "Đã trích lương thành công cho " + sobanghi.ToString() + " cán bộ thành công");
        RM.RegisterClientScriptBlock("rmlh1", "PagingToolbar1.doLoad();");
    }
}