using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using Controller.DanhGia;
using System.Xml.Linq;

public partial class Modules_DanhGia_KetQuaDanhGia : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }

    protected void cbxNguoiQLDanhGia_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxNguoiQLDanhGiaStore.DataSource = new KetQuaDanhGiaController().GetManagerEmployee(hdfMaDotDanhGia.Text, hdfRecordID.Text);
        cbxNguoiQLDanhGiaStore.DataBind();
    }

    [DirectMethod]
    public void SetTitleWindowsDetail()
    {
        DAL.HOSO hs = new HoSoController().GetByMaCB(hdfRecordID.Text);
        if (hs != null)
            wdChiTiet.Title = "Kết quả đánh giá chi tiết của cán bộ " + hs.HO_TEN;
        else
            wdChiTiet.Title = "Kết quả đánh giá chi tiết";
    }

    protected void DotDanhGia_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DotDanhGia ddg = new DotDanhGiaController().GetByPrkey(hdfMaDotDanhGia.Text);
            if (ddg != null)
            {
                hdfTuDanhGia.SetValue(ddg.TL_TuDanhGia);
                hdfQuanLyDanhGia.SetValue(ddg.TL_QuanLyDanhGia);
                hdfNguoiKhacDanhGia.SetValue(ddg.TL_NguoiKhacDanhGia);
            }
            grp_TongKetDanhGia.Title = "Đợt đánh giá: " + ddg.TenDotDanhGia;
            grp_TongKetDanhGia.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString());
        }
    }

    protected void cbxTenNguoiDanhGia_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDotDanhGia = hdfMaDotDanhGia.Text;
        string maCB = hdfRecordID.Text;
        cbxTenNguoiDanhGia_Store.DataSource = new KetQuaDanhGiaController().GetDSCanBoDanhGiaMotCanBo(maDotDanhGia, maCB); ;
        cbxTenNguoiDanhGia_Store.DataBind();
    }
}
