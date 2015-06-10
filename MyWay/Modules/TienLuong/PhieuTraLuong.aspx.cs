using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DataController;

public partial class Modules_TienLuong_PhieuTraLuong : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            DAL.HOSO hs = new HoSoController().GetByUserID(CurrentUser.ID);
            hdfMaCB.Text = hs.MA_CB;
            if (hs == null)
            {
                return;
            }
            DAL.DanhSachBangLuong item = new DanhSachBangLuongController().GetLastest(Session["MaDonVi"].ToString());

            LoadSalarySheet(item.ID, item.Month, item.Year);
            dpfHoTen.Text = hs.HO_TEN;
            dpfBoPhan.Text = DataHandler.GetInstance().ExecuteScalar("select TEN_DONVI from DM_DONVI where MA_DONVI = " + hs.MA_DONVI).ToString();
        }
    }
    private const string LuongCB =         "Lương cơ bản : {0:n0}";
    private const string LuongTrachNhiem = "Lương trách nhiệm : {0:n0} ";
    private const string PhuCapAnCa =      "Phụ cấp ăn ca : {0:n0}";
    private const string PhuCapChucVu =    "Phụ cấp chức vụ : {0:n0}";
    private const string PhuCapKiemNhiem = "Phụ cấp kiêm nhiệm : {0:n0}";
    private const string PhuCapKhac =      "Phụ cấp khác : {0:n0}";
    private const string Luong100 =        "Lương 100% : {0:n0}";
    private const string Luong150 =        "Lương 150% : {0:n0}";
    private const string Luong200 =        "Lương 200% : {0:n0}";
    private const string Luong300 =        "Lương 300% : {0:n0}";
    private const string LuongThang13 =    "Lương tháng 13 : {0:n0}";
    private const string BHXH =            "BHXH : {0:n0}";
    private const string BHYT =            "BHYT : {0:n0}";
    private const string BHTN =            "BHXH : {0:n0}";
    private const string KPCD =            "KPCĐ : {0:n0}";
    private const string GiamTruTienAn =   "Giảm trừ tiền ăn : {0:n0}";
    private const string GiamTruTienPhat = "Giảm trừ tiền phạt : {0:n0}";

    private const string TongSoTienDuocLinh="Tổng số tiền được lĩnh : {0:n0}";
    private void LoadSalarySheet(int idBangLuong, int month, int year)
    {
        try
        {
            DAL.BangThanhToanLuong thanhToanLuong = new BangThanhToanTienLuongController().GetSalarySheet(hdfMaCB.Text, idBangLuong);
            if (thanhToanLuong != null)
            {
                dpfPhieuLuong.Text = "Tháng " + month + " Năm " + year;
                dpfTongSoTien.Text = string.Format(TongSoTienDuocLinh, thanhToanLuong.ThucLinh);
                dpfLuongCB.Text = string.Format(LuongCB, thanhToanLuong.LuongCoBan);
                dpfLuongTrachNhiem.Text = string.Format(LuongTrachNhiem, thanhToanLuong.LuongTrachNhiem);
                dpfPhuCapAnCa.Text = string.Format(PhuCapAnCa, thanhToanLuong.PhuCapTienAn);
                dpfPhuCapChucVu.Text = string.Format(PhuCapChucVu, thanhToanLuong.PhuCapChucVu);
                dpfPhuCapKiemNhiem.Text = string.Format(PhuCapKiemNhiem, thanhToanLuong.PhuCapKiemNhiem);

                dpfPhuCapKhac.Text = string.Format(PhuCapKhac, thanhToanLuong.PhuCapKhac);
                dpfLuong100.Text = string.Format(Luong100, thanhToanLuong.Luong100PhanTram);
                dpfLuong150.Text = string.Format(Luong150, thanhToanLuong.Luong150PhanTram);
                dpfLuong200.Text = string.Format(Luong200, thanhToanLuong.Luong200PhanTram);
                dpfLuong300.Text = string.Format(Luong300, thanhToanLuong.Luong300PhanTram);

                dpfBHXH.Text = string.Format(BHXH, thanhToanLuong.GiamTruBHXH);
                dpfBHTN.Text = string.Format(BHTN, thanhToanLuong.GiamTruBHTN);
                dpfBHYT.Text = string.Format(BHYT, thanhToanLuong.GiamTruBHYT);
                dpfGiamTruTienAn.Text = string.Format(GiamTruTienAn, thanhToanLuong.GiamTruAnCa);
                dpfGiamTruTienPhat.Text = string.Format(GiamTruTienPhat, thanhToanLuong.GiamTruTienPhat);
                dpfKPCD.Text = string.Format(KPCD, thanhToanLuong.GiamTruPhiCongDoan);
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void grpDanhSachPhieuLuong_RowClick(object sender, DirectEventArgs e)
    {
        try
        {
            LoadSalarySheet(int.Parse(e.ExtraParams["idBangLuong"]), int.Parse(e.ExtraParams["month"]), int.Parse(e.ExtraParams["year"]));
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}