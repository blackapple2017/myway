using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using SoftCore.Security;

public partial class Modules_ChamCongDoanhNghiep_NhanVienNghiDaiNgay : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }
    private DateTime? GetDateTime(DateField datefield)
    {
        if (!SoftCore.Util.GetInstance().IsDateNull(datefield.SelectedDate))
            return datefield.SelectedDate;
        else return null;
    }
    protected void btnSuaClick(object sender, DirectEventArgs e)
    {
        try
        {

            wdThemSuaNghiDaiNgay.Title = "Sửa thông tin nghỉ phép dài ngày";
            wdThemSuaNghiDaiNgay.Icon = Icon.Pencil;
            SelectedRowCollection selectedrow = RowSelectedNghiDaiNgay.SelectedRows;
            int id = int.Parse(selectedrow.FirstOrDefault().RecordID);
            DAL.NghiDaiNgay nghidaingay = new NghiDaiNgayController().GetNghiDaiNgayByID(id);
            hdfPRKEYHOSO.Text = nghidaingay.PR_KEYHOSO.ToString();
            cbonhanvien.Text = new HoSoController().TraVeTenByPRKEY(nghidaingay.PR_KEYHOSO);
            cbbDongBH.SelectedItem.Value = nghidaingay.DongBH == true ? "1" : "0";
            dfNgayNopDon.SelectedDate = nghidaingay.NgayNopDon;
            txtLyDoNghi.Text = nghidaingay.MaLyDoNghi;
            if (nghidaingay.NgayDangKyNghi != null)
                dfNgayDangKyNghi.SelectedDate = nghidaingay.NgayDangKyNghi.Value;
            if (nghidaingay.NgayDiLamLai != null)
                dfNgayDiLamLai.SelectedDate = nghidaingay.NgayDiLamLai.Value;
            if (nghidaingay.NgayNghiThucTe != null)
                dfNgayNghiThucTe.SelectedDate = nghidaingay.NgayNghiThucTe.Value;
            if (nghidaingay.NgayDiLamLaiThucTe != null)
                dfNgayDiLamLaiThucTe.SelectedDate = nghidaingay.NgayDiLamLaiThucTe.Value;
            txtGhiChu.Text = nghidaingay.GhiChu;
            cbonhanvien.Disabled = true;

            btnCapNhatSua.Show();
            btnCapNhatThem.Hide();
            btnCapNhatThemVaDongLai.Hide();
            wdThemSuaNghiDaiNgay.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhatThem_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (new NghiDaiNgayController().CheckTrungThoiGian(decimal.Parse(hdfPRKEYHOSO.Text), dfNgayDangKyNghi.SelectedDate, dfNgayDiLamLai.SelectedDate,0))
                throw new Exception("Khoảng thời gian bị trùng");
            DAL.NghiDaiNgay nghidaingay = new DAL.NghiDaiNgay()
           {
               CreatedBy = CurrentUser.ID,
               CreatedDate = DateTime.Now,
               DongBH = cbbDongBH.SelectedItem.Value == "0" ? false : true,
               GhiChu = txtGhiChu.Text,
               MaLyDoNghi = txtLyDoNghi.Text,
               NgayDangKyNghi = GetDateTime(dfNgayDangKyNghi),
               NgayDiLamLai = GetDateTime(dfNgayDiLamLai),
               NgayDiLamLaiThucTe = GetDateTime(dfNgayDiLamLaiThucTe),
               NgayNopDon = dfNgayNopDon.SelectedDate,
               NgayNghiThucTe = GetDateTime(dfNgayNghiThucTe),
               PR_KEYHOSO = decimal.Parse(hdfPRKEYHOSO.Text)
           };
            new NghiDaiNgayController().Insert(nghidaingay);

            Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
            if (e.ExtraParams["Close"] == "True")
            {
                wdThemSuaNghiDaiNgay.Hide();
            }
            else
            {
                RM.RegisterClientScriptBlock("r1", "resetWindowsThemSuaNghiDaiNgay();");
            }
            RM.RegisterClientScriptBlock("r3", "grpNghiDaiNgayStore.reload();");
            RM.RegisterClientScriptBlock("r4", "resetWindowsThemSuaNghiDaiNgay");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhatSua_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.NghiDaiNgay nghidaingay = new NghiDaiNgayController().GetNghiDaiNgayByID(int.Parse(hdfRecordID.Text));
            nghidaingay.DongBH = cbbDongBH.SelectedItem.Value == "0" ? false : true;
            nghidaingay.GhiChu = txtGhiChu.Text;
            nghidaingay.MaLyDoNghi = txtLyDoNghi.Text;
            nghidaingay.NgayDangKyNghi = GetDateTime(dfNgayDangKyNghi);
            nghidaingay.NgayDiLamLai = GetDateTime(dfNgayDiLamLai);
            nghidaingay.NgayDiLamLaiThucTe = GetDateTime(dfNgayDiLamLaiThucTe);
            nghidaingay.NgayNopDon = dfNgayNopDon.SelectedDate;
            nghidaingay.NgayNghiThucTe = GetDateTime(dfNgayNghiThucTe);

            if (new NghiDaiNgayController().CheckTrungThoiGian(nghidaingay.PR_KEYHOSO, dfNgayDangKyNghi.SelectedDate, dfNgayDiLamLai.SelectedDate,nghidaingay.ID))
                throw new Exception("Khoảng thời gian bị trùng");

            new NghiDaiNgayController().Update(nghidaingay);
            Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
            RM.RegisterClientScriptBlock("r5", "grpNghiDaiNgayStore.reload();");
            wdThemSuaNghiDaiNgay.Hide();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    //protected void btnXoaClick(object sender, DirectEventArgs e)
    //{
    //    int dem = 0;
    //    SelectedRowCollection selectedrow = RowSelectedNghiDaiNgay.SelectedRows;
    //    foreach (var item in selectedrow)
    //    {
    //        int id = int.Parse(item.RecordID);
    //        new NghiDaiNgayController().Delete(id);
    //        dem++;
    //    }
    //    Dialog.ShowNotification("Thông báo", "Bạn đã xóa " + dem.ToString() + " dòng bản ghi");
    //    RM.RegisterClientScriptBlock("fa", "grpNghiDaiNgayStore.reload();");
    //    btnSua.Disabled = true;
    //    btnXoa.Disabled = true;
    //    //hdfRecordID.Text = "";
    //    RM.RegisterClientScriptBlock("gdgdsfgsd", "resetPanelThongTin();");
    //}
    [DirectMethod]
    public void DeleteRecord(int id)
    {
        try
        {
            new NghiDaiNgayController().Delete(id);
            hdfRecordID.Text = "";
            Dialog.ShowNotification("Thông báo", "Bạn đã xóa thành công");
            RM.RegisterClientScriptBlock("gdgdsfgsd", "resetPanelThongTin();");
            hsImage.ImageUrl = "~/Modules/NhanSu/ImageNhanSu/No_person_NoClick.jpg".Replace("~", "");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Bạn không thể xóa thông tin nhân viên nghỉ dài ngày này").Show();
        }
    }
    protected void btnThemClick(object sender, DirectEventArgs e)
    {
        wdThemSuaNghiDaiNgay.Title = "Thêm thông tin nghỉ phép dài ngày";
        wdThemSuaNghiDaiNgay.Icon = Icon.Add;
    }
    [DirectMethod]
    public void DienThongTinNhanVien(int recordid)
    {
        try
        {
            DAL.NghiDaiNgay nghidaingay = new NghiDaiNgayController().GetNghiDaiNgayByID(recordid);
            //nghidaingay.PR_KEYHOSO
            var hoso = new HoSoController().GetByPrKey(nghidaingay.PR_KEYHOSO);
            hsImage.ImageUrl = hoso.PHOTO == null ? "" : hoso.PHOTO.Replace("~", "");
            txtMaCB.Text = hoso.MA_CB;
            txtFullName.Text = hoso.HO_TEN;
            txtBiDanh.Text = hoso.BI_DANH;
            txtDTCoQuan.Text = hoso.DT_CQUAN;
            txtDTNha.Text = hoso.DT_NHA;
            txtSoCMND.Text = hoso.SO_CMND;
            txtBoPhan.Text = new DM_DONVIController().GetNameById(hoso.MA_DONVI);
            txtNgayCapCMND.Text = hoso.NGAYCAP_CMND != null ? hoso.NGAYCAP_CMND.Value.ToString("dd/MM/yyyy") : "";
            txtNoiCapCMND.Text = hoso.MA_NOICAP_CMND != null ? hoso.DM_NOICAP_CMND.TEN_NOICAP_CMND : "";
            txtDiaChi.Text = hoso.DIA_CHI_LH;
            txtNgayThuViec.Text = hoso.NGAY_TUYEN_DTIEN != null ? hoso.NGAY_TUYEN_DTIEN.Value.ToString("dd/MM/yyyy") : "";
            txtNgayNhan.Text = hoso.NGAY_TUYEN_CHINHTHUC != null ? hoso.NGAY_TUYEN_CHINHTHUC.Value.ToString("dd/MM/yyyy") : "";
            txtNgach.Text = hoso.MA_NGACH;
            txtLoaiHD.Text = hoso.MA_LOAI_HDONG != null ? hoso.DM_LOAI_HDONG.TEN_LOAI_HDONG : "";
        }
        catch (Exception ex)
        {

        }
    }
}