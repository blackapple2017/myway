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
using System.Collections;

public partial class Modules_ChamCongDoanhNghiep_DuyetDonNghiPhep : WebBase
{
    Dictionary<string, string> dr = new HoSoController().TraVeTuDienHoSo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            try
            {
                hdfMaDonVi.Text = Session["MaDonVi"].ToString();
                hdfMaCB.Text = new HoSoController().GetByUserID(CurrentUser.ID).MA_CB;
                hdfTenCB.Text = dr[hdfMaCB.Text];
                hdfHCSNDuyet.Text = new DonXinNghiController().CheckCBHCSN(CurrentUser.ID).ToString();
                //if (!bool.Parse(hdfHCSNDuyet.Text))
                //{
                //    btnDuyet.Hide(); //Button1.Hide(); }
                //}
            }
            catch (Exception ex)
            {

            }
        }

    }
    protected void btnDongYKhongDuyetClick(object sender, DirectEventArgs e)
    {
        int dem = 0;
        int khongduyet = 0;
        int dahoantat = 0;
        int demnguoikhongduquyen = 0;
        SelectedRowCollection selectedrow = RowSelectDuyetDonXinNghi.SelectedRows;
        foreach (var item in selectedrow)
        {
            int recordid = int.Parse(item.RecordID);
            var donxinnghi = new DonXinNghiController().GetDonXinNghiByID(recordid);
            if (donxinnghi.MaCBDangDuyet != hdfMaCB.Text && !bool.Parse(hdfHCSNDuyet.Text)) demnguoikhongduquyen++;
            else
                if (donxinnghi.TrangThaiDuyet == DonXinNghiController.KHONG_DUYET) khongduyet++;
                else
                    if (donxinnghi.TrangThaiDuyet == DonXinNghiController.HOANTATTHUTUC) dahoantat++;
                    else
                    {
                        donxinnghi.TrangThaiDuyet = DonXinNghiController.KHONG_DUYET;
                        new DonXinNghiController().UpdateDonXinNghi(donxinnghi);
                        dem++;
                        DAL.DonXinNghiLichSu lichsu = new DAL.DonXinNghiLichSu()
                        {
                            CreatedBy = CurrentUser.ID,
                            CreatedDate = DateTime.Now,
                            GhiChu = txtLyDoKhongDuyet.Text,
                            IDDonXinNghi = recordid,
                            MaCBDuyet = hdfMaCB.Text,
                            NgayDuyet = DateTime.Now,
                            TrangThai = DonXinNghiController.KHONG_DUYET,
                            HCNSDuyet = bool.Parse(hdfHCSNDuyet.Text)
                        };
                        new DonXinNghiController().InsertDonXinNghiLichSu(lichsu);
                    }
        }
        string thongbao = "";
        if (demnguoikhongduquyen > 0) thongbao += "Hiện tại bạn không phải là người được quyền duyệt " + demnguoikhongduquyen.ToString() + " đơn xin nghỉ<br/>";

        if (khongduyet > 0) thongbao += "Đã có " + khongduyet.ToString() + " đơn xin nghỉ không được duyệt <br/>";
        if (dahoantat > 0) thongbao += "Đã có " + dahoantat.ToString() + " đơn xin nghỉ đã hoàn tất thủ tục <br/>";
        if (thongbao != "") X.Msg.Alert("Thông báo", thongbao).Show();
        if (dem > 0) Dialog.ShowNotification("Thông báo", "Bạn đã xác nhận không duyệt " + dem.ToString() + " đơn xin nghỉ<br/>");
        wdKhongDuyet.Hide();
        RM.RegisterClientScriptBlock("resetf1", "grpDuyetDonXinNghiStore.reload(); grpLichSuDonXinNghiStore.reload();");
    }
    protected void btnDuyetClick(object sender, DirectEventArgs e)
    {
        SelectedRowCollection selectedrow = RowSelectDuyetDonXinNghi.SelectedRows;
        foreach (var item in selectedrow)
        {
            hdfIDDonXinNghi.Text = item.RecordID;
            var donxinnghi = new DonXinNghiController().GetDonXinNghiByID(int.Parse(item.RecordID));
            dfNghiTuNgay.SelectedDate = donxinnghi.NghiTuNgay;
            dfNghiDenNgay.SelectedDate = donxinnghi.NghiDenNgay;
            txtSoNgayNghi.Text = donxinnghi.SoNgayNghi.ToString();
            txtSoNgayNghiPhep.Text = donxinnghi.SoNgayNghiTruPhep != null ? donxinnghi.SoNgayNghiTruPhep.Value.ToString() : "";
            txtSoNgayNghiTruLuong.Text = donxinnghi.SoNgayNghiTruLuong != null ? donxinnghi.SoNgayNghiTruLuong.Value.ToString() : "";
            txtSoNgayNghiCheDo.Text = donxinnghi.SoNgayNghiCheDo != null ? donxinnghi.SoNgayNghiCheDo.Value.ToString() : "";
            //txtMaLyDoNghi.Text = donxinnghi.MaLyDoNghi;
            //txtKyHieuChamCong.Text = donxinnghi.KyHieuChamCong;
            //txtPhanTramHuongLuong.Text = donxinnghi.PhanTramHuongLuong;
        }
    }
    protected void btnDongYHoanTatThuTucClick(object sender, DirectEventArgs e)
    {

        try
        {
            int khongduyet = 0;
            int demnguoikhongduquyen = 0;
            DAL.DonXinNghi donxinnghi = new DonXinNghiController().GetDonXinNghiByID(int.Parse(hdfIDDonXinNghi.Text));
            if (donxinnghi.TrangThaiDuyet == DonXinNghiController.KHONG_DUYET) khongduyet++;
            else
            {
                if (donxinnghi.MaCBDangDuyet != "" ) demnguoikhongduquyen++;
                else
                {
                    donxinnghi.TrangThaiDuyet = DonXinNghiController.HOANTATTHUTUC;
                    donxinnghi.SoNgayNghi = double.Parse(txtSoNgayNghi.Text.Replace('.', ','));
                    if (txtSoNgayNghiPhep.Text != "")
                        donxinnghi.SoNgayNghiTruPhep = double.Parse(txtSoNgayNghiPhep.Text.Replace('.', ','));
                    if (txtSoNgayNghiTruLuong.Text != "")
                        donxinnghi.SoNgayNghiTruLuong = double.Parse(txtSoNgayNghiTruLuong.Text.Replace('.', ','));
                    if (txtSoNgayNghiCheDo.Text != "")
                        donxinnghi.SoNgayNghiCheDo = double.Parse(txtSoNgayNghiCheDo.Text.Replace('.', ','));
                    //donxinnghi.MaLyDoNghi = txtMaLyDoNghi.Text;
                    //donxinnghi.KyHieuChamCong = txtKyHieuChamCong.Text;
                    //donxinnghi.PhanTramHuongLuong = txtPhanTramHuongLuong.Text;
                    new DonXinNghiController().UpdateDonXinNghi(donxinnghi);
                    DAL.DonXinNghiLichSu lichsu = new DAL.DonXinNghiLichSu()
                    {
                        IDDonXinNghi = donxinnghi.ID,
                        CreatedBy = CurrentUser.ID,
                        CreatedDate = DateTime.Now,
                        GhiChu = txtGhiChu.Text,
                        MaCBDuyet = "",
                        NgayDuyet = DateTime.Now,
                        TrangThai = DonXinNghiController.HOANTATTHUTUC
                    };
                    new DonXinNghiController().InsertDonXinNghiLichSu(lichsu);
                    wdHoanTatThuTuc.Hide();
                    RM.RegisterClientScriptBlock("rmabc", "grpDuyetDonXinNghiStore.reload(); grpLichSuDonXinNghiStore.reload();");
                    Dialog.ShowNotification("Thông báo", "Đã hoàn tất thủ tục đơn xin nghỉ thành công");
                }
            }
            if (demnguoikhongduquyen > 0) X.Msg.Alert("Thông báo", "Bạn không phải người đang duyệt đơn").Show();
            if (khongduyet > 0) X.Msg.Alert("Thông báo", "Đơn xin nghỉ này đã có trạng thái không được duyệt").Show();
            if (demnguoikhongduquyen == 0 && khongduyet == 0)
                Dialog.ShowNotification("Thông báo", "Đã hoàn tất thủ tục xin nghỉ phép");
            wdHoanTatThuTuc.Hide();
            RM.RegisterClientScriptBlock("abc", "grpDuyetDonXinNghiStore.reload(); grpLichSuDonXinNghiStore.reload();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra " + ex.Message).Show();
        }


    }
    protected void btnDongYDuyetVaChuyenTiepClick(object sender, DirectEventArgs e)
    {
        //try
        //{
        int dem = 0;
        int khongduyet = 0;
        int dahoantat = 0;
        int demnguoikhongduquyen = 0;
        SelectedRowCollection selectedrow = RowSelectDuyetDonXinNghi.SelectedRows;
        foreach (var item in selectedrow)
        {
            int recordid = int.Parse(item.RecordID);
            var donxinnghi = new DonXinNghiController().GetDonXinNghiByID(recordid);
            if (donxinnghi.MaCBDangDuyet != hdfMaCB.Text && !bool.Parse(hdfHCSNDuyet.Text)) demnguoikhongduquyen++;
            else
                if (donxinnghi.TrangThaiDuyet == DonXinNghiController.KHONG_DUYET) khongduyet++;
                else
                    if (donxinnghi.TrangThaiDuyet == DonXinNghiController.HOANTATTHUTUC) dahoantat++;
                    else
                    {
                    //    donxinnghi.TrangThaiDuyet = DonXinNghiController.CHUA_DUYET;
                        donxinnghi.MaCBDangDuyet = cbonhanvien.SelectedItem.Value ?? "";
                        new DonXinNghiController().UpdateDonXinNghi(donxinnghi);
                        dem++;
                        DAL.DonXinNghiLichSu lichsu = new DAL.DonXinNghiLichSu()
                        {
                            CreatedBy = CurrentUser.ID,
                            CreatedDate = DateTime.Now,
                            GhiChu = txtGhiChuDuyetVaChuyenTiep.Text,
                            IDDonXinNghi = recordid,
                            MaCBDuyet = hdfMaCB.Text,
                            NgayDuyet = DateTime.Now,
                            TrangThai = DonXinNghiController.DA_DUYET,
                            HCNSDuyet = bool.Parse(hdfHCSNDuyet.Text)
                        };
                        new DonXinNghiController().InsertDonXinNghiLichSu(lichsu);
                    }
        }
        string thongbao = "";
        if (demnguoikhongduquyen > 0) thongbao += "Hiện tại bạn không phải là người được quyền duyệt " + demnguoikhongduquyen.ToString() + " đơn xin nghỉ<br/>";

        if (khongduyet > 0) thongbao += "Đã có " + khongduyet.ToString() + " đơn xin nghỉ không được duyệt <br/>";
        if (dahoantat > 0) thongbao += "Đã có " + dahoantat.ToString() + " đơn xin nghỉ đã hoàn tất thủ tục <br/>";
        if (thongbao != "") X.Msg.Alert("Thông báo", thongbao).Show();
        if (dem > 0) Dialog.ShowNotification("Thông báo", "Bạn đã xác nhận chuyển tiếp " + dem.ToString() + " đơn xin nghỉ<br/>");
        wdDuyetVaChuyenTiep.Hide();
        RM.RegisterClientScriptBlock("resetf1", "grpDuyetDonXinNghiStore.reload(); grpLichSuDonXinNghiStore.reload();");
    }

    //protected void btnKhongDuyetClick(object sender, DirectEventArgs e)
    //{
    //    SelectedRowCollection selectedRows = RowSelectDuyetDonXinNghi.SelectedRows;
    //    foreach(var item in selectedRows)
    //    {
    //        item.RecordID;
    //        item.
    //    }
    //}
}