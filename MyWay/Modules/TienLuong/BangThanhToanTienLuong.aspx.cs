using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using LinqToExcel;
using System.Globalization;
using Controller.ChamCongDoanhNghiep;
using System.Text;
using System.Data;

public partial class Modules_TienLuong_BangThanhToanTienLuong : WebBase
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        { 
            cbChonThang.SelectedItem.Value = DateTime.Now.AddMonths(-1).Month.ToString();
            spinChonNam.Value = DateTime.Now.AddMonths(-1).Year.ToString();
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            hdfCurrentMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();PagingToolbar.pageIndex=0;PagingToolbar.doLoad();",
            }.AddDepartmentList(br, CurrentUser.ID, true);
           // SetEditor();
        }
    }
    private void SetEditor()
    {
        Ext.Net.TextField txtEditor = new TextField();
        txtEditor.Width = 75;
        txtEditor.ID = "txtEditor";
        grpBangThanhToanTienLuong.ColumnModel.Columns[6].Editor.Add(txtEditor);
        //grpBangThanhToanTienLuong.ColumnModel.Columns[9].Editor.Add(txtEditor);
    }

    #region mapcot
    //private string GetExcelColumnName(int columnNumber)
    //{
    //    int dividend = columnNumber;
    //    string columnName = String.Empty;
    //    int modulo;

    //    while (dividend > 0)
    //    {
    //        modulo = (dividend - 1) % 26;
    //        columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
    //        dividend = (int)((dividend - modulo) / 26);
    //    }

    //    return columnName;
    //}
    #endregion
     
    #region BangTinhLuong
    protected void btnDongYThemBangTinhClick(object sender, DirectEventArgs e)
    {
        var control = new DanhSachBangLuongController();
        int thang = int.Parse(cbChonThang.SelectedItem.Value);
        int nam = int.Parse(spinChonNam.Text);
        if (hdfLoaiCapNhat.Text == "Them")//thêm bảng tính
        {
            if(cbbChonBangChamCong.SelectedIndex==-1)
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bảng chấm công").Show();
                return;
            }
            if (control.CheckTrungThangNam(hdfCurrentMaDonVi.Text, thang, nam, 0))
            {
                X.Msg.Alert("Thông báo", "Tháng " + thang.ToString() + " năm " + nam.ToString() + " đã tồn tại bảng tính lương").Show();
                return;
            }
            if(!new BangThanhToanTienLuongController().CheckDaKhoa(int.Parse(cbbChonBangChamCong.SelectedItem.Value)))
            {
                X.Msg.Alert("Thông báo", "Bảng chấm công này chưa được khóa").Show();
                return;
            }
            DAL.DanhSachBangLuong bang = new DAL.DanhSachBangLuong()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                MA_DONVI = hdfCurrentMaDonVi.Text,
                Month = thang,
                Year = nam,
                Title = txtTenBangTinhLuong.Text
            };
            int idbangtinhluong= control.Insert(bang);
            string loi= new BangThanhToanTienLuongController().InsertToBangThanhToanLuong(hdfMaDonVi.Text,idbangtinhluong, int.Parse(cbbChonBangChamCong.SelectedItem.Value));
            if (loi != "")
                X.Msg.Alert("Thông báo", loi);
            else
            Dialog.ShowNotification("Thông báo", "Đã thêm thành công bảng tính lương tháng " + thang.ToString() + " năm " + nam.ToString());
        }
        else //sửa bảng tính
        {
            DAL.DanhSachBangLuong bang = control.GetByID(int.Parse(hdfRecordID.Text));
            bang.Title = txtTenBangTinhLuong.Text;
            control.Update(bang);
            Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
        }
        wdThemBangTinhLuong.Hide();
        grpDanhSachBangTinhLuong.Reload();
    }
    //protected void btnDongYChonBangChamCongClick(object sender, DirectEventArgs e)
    //{
    //        int idbangchamcong = 0;
    //        idbangchamcong =int.Parse( cbbChonBangChamCong.SelectedItem.Value);
    //        new BangThanhToanTienLuongController().InsertToBangThanhToanLuong(int.Parse(hdfRecordID.Text), idbangchamcong);
    //        Dialog.ShowNotification("Thông báo", "Đã thêm thành công");
    //        grpBangThanhToanTienLuong.Reload();
    //        wdChonBangChamCong.Hide();

    //}
    protected void btnXoaBangTinhLuongClick(object sender, DirectEventArgs e)
    {
        new DanhSachBangLuongController().Delete(int.Parse(hdfRecordID.Text));
        Dialog.ShowNotification("Thông báo", "Đã xóa thành công");
        btnSuaBangTinhLuong.Disabled = true;
        btnXoaBangTinhLuong.Disabled = true;
        wdThemBangTinhLuong.Hide();
        grpDanhSachBangTinhLuong.Reload();
    }
    #endregion
    protected void btnDongYBangTinhLuongClick(object sender, DirectEventArgs e)
    {
        var item = new DanhSachBangLuongController().GetByID(int.Parse(hdfRecordID.Text));
        pnlWrapper.Title = item.Title;
        wdQuanLyBangTinhLuong.Hide();
        double tongtien = new BangThanhToanTienLuongController().SumTongTienLuong(item.ID);
        dpfTongSoTien.Html = "<b style='color:#15428B; font-size:12px;'>Tổng cộng : " + Math.Round(tongtien).ToString("N0") + " VND </i></b>";
        grpThongTinCanBo.Reload();
       // if (!new BangThanhToanTienLuongController().CheckDuLieuBangLuong(int.Parse(hdfRecordID.Text)))
            btnChonBangChamCong.Disabled = false;
    }
    protected void btnTinhLuongClick(object sender, DirectEventArgs e)
    {
        string loi= new BangThanhToanTienLuongController().XuLiCongThuc(int.Parse( hdfRecordID.Text),hdfMaDonVi.Text,"");
        if (loi != "")
            X.Msg.Alert("Thông báo", loi).Show();
        else
            Dialog.ShowNotification("Thông báo", "Đã xử lý tính lương thành công"); 
        grpBangThanhToanTienLuong.Reload();
    }

    protected void grpBangThanhToanTienLuongStoreChange(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<BangThanhToanTienLuongInfo> bangthanhtoan = e.DataHandler.ObjectData<BangThanhToanTienLuongInfo>();
        foreach (var item in bangthanhtoan.Updated)
        {
            var change = new BangThanhToanTienLuongController().GetChiTietLuongByID(item.ID);
            change.LuongCoBan = item.LuongCoBan;
            change.LuongTrachNhiem = item.LuongTrachNhiem;
            change.PhuCapTienAn = item.PhuCapTienAn;
            change.PhuCapChucVu = item.PhuCapChucVu;
            change.PhuCapKiemNhiem = item.PhuCapKiemNhiem;
            change.PhuCapKhac = item.PhuCapKhac;
            change.LuongThoiGianNgayThuong = item.LuongThoiGianNgayThuong;
            change.LuongThemGio = item.LuongThemGio;
            change.LuongThuong = item.LuongThuong;
            change.LuongThang13 = item.LuongThang13;
            change.ATM = item.ATM;
            change.TienMat = item.TienMat;

            new BangThanhToanTienLuongController().UpdateChiTietTienLuong(change);
            grpBangThanhToanTienLuongStore.CommitChanges();
            grpBangThanhToanTienLuong.Reload();
        }
    }

    //protected void grpBangCongThucStoreChanges(object sender, BeforeStoreChangedEventArgs e)
    //{
    //    ChangeRecords<BangCongThucLuongInfo> congthuc = e.DataHandler.ObjectData<BangCongThucLuongInfo>();
    //    foreach (var item in congthuc.Updated)
    //    {
    //        var change = new BangThanhToanTienLuongController().GetCongThucByID(item.PRKEY);
    //        change.TenCotExcel = item.TenCotExcel;
    //        change.CongThuc = item.CongThuc;
    //        change.TieuDeCot = item.TieuDeCot;
    //        change.TenCot = item.TenCot;
    //        new BangThanhToanTienLuongController().UpdateCongThucTinhLuong(change);
    //        grpBangCongThucStore.CommitChanges();
    //    }
    //}
}