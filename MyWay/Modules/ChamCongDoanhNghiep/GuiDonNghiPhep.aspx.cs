using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;
using Controller.ChamCongDoanhNghiep;
using System.Data.SqlClient;
using DataController;
using ExtMessage;
public partial class Modules_ChamCongDoanhNghiep_GuiDonNghiPhep : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            DAL.HOSO hoso = new HoSoController().GetByUserID(CurrentUser.ID);
            hdfMaCanBo.Text = hoso.MA_CB;
            txtTen.Text = hoso.HO_TEN;
            dpfNguoiLamDon.Text = hoso.HO_TEN;
            txtGioiTinh.Text = "Giới tính : "+hoso.MA_GIOITINH == "M" ? "Nam" : "Nữ";
            txtNgaySinh.Text = hoso.NGAY_SINH != null ? hoso.NGAY_SINH.Value.ToString("dd/MM/yyyy") : "";
            txtDiaChi.Text = hoso.DIA_CHI_LH;
            txtDienThoai.Text = hoso.DI_DONG;
            var donvi = new DM_DONVIController().GetById(hoso.MA_DONVI);
            txtDonViCongTac.Text = donvi.TEN_DONVI;
            txtChucVu.Text = hoso.MA_CHUCVU != null ? hoso.DM_CHUCVU.TEN_CHUCVU : "";
            txtNgayThangNam.Text = string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }
    }
    public void btnNopDonClick(object sender, DirectEventArgs e)
    {
        DAL.DonXinNghi donxinnghi = new DAL.DonXinNghi()
        {
            MaCB = hdfMaCanBo.Text,
            NghiTuNgay = dfTuNgay.SelectedDate,
            NghiDenNgay = dfDenNgay.SelectedDate,
            LyDoNghi = txtLyDo.Text,
            CreatedDate = DateTime.Now,
            TrangThaiDuyet = DonXinNghiController.CHUA_DUYET,
            MaCBDangDuyet = cbonhanvien.SelectedItem.Value??"",
            MaLyDoNghi = "",
            SoNgayNghi = (dfDenNgay.SelectedDate - dfTuNgay.SelectedDate).Days + 1,
            CreatedBy = CurrentUser.ID,
        };
        new DonXinNghiController().InsertNewOne(donxinnghi);
        Dialog.ShowNotification("Thông báo", "Đã gửi đơn xin nghỉ thành công cho " + cbonhanvien.SelectedItem.Text);
        RM.RegisterClientScriptBlock("resetgrid", "grpDanhSachDonNghiPhepStore.reload(); resetForm();");
    }
}