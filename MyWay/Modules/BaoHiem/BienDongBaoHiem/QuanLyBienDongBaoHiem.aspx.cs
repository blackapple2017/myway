using DAL;
using Ext.Net;
using Ext.Net.UX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore;
using SoftCore.AccessHistory;
using SoftCore.Security;
using System.Data;
using System.Messaging;
using ExtMessage;
using DataController;
using System.Globalization;


public partial class Modules_BaoHiem_QuanLyBienDongBaoHiem : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            ThoiGianBaoCao.SelectedItem.Value = DateTime.Now.Month.ToString();
            NamBaoCao.Value = DateTime.Now.Year;
            hdfMenuID.SetValue(MenuID);
            // load west
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');#{txtSearchKey}.reset();#{PagingToolbar1}.pageIndex = 0; #{grpBienDongBaoHiemStore}.reload(); #{grpChiTietNhanVienStore}.removeAll();#{Button1}.disable();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
            int tongso;
            int nu;
            new BaoHiemController().DemSoLaoDong(out tongso, out nu);
            txtTongSoLaoDong.Text = tongso.ToString();
            txtTrongDoNu.Text = nu.ToString();
        }
        // BHNHANVIEN_BAOHIEM1.AfterClickAcceptButton += ucChooseEmployee1_AfterClickAcceptButton;
    }
    #region Đầu phiếu
    [DirectMethod]
    public void DeleteRecord_dauphieu(int Id)
    {
        //DAL.BHDAUPHIEU bhdp = new BHDauPhieuController().GetByIdDauPhieu(Id);
        //var dt = new BHDauPhieuController().GetDauPhieuByParent(bhdp.IDDauPhieu.ToString());
        //foreach (var item in dt)
        //{
        //    new BHDauPhieuController().Delete(Convert.ToInt32(item.IdDauPhieu));
        //}
        new BHDauPhieuController().Delete(Convert.ToInt32(hdfMadauphieu.Text));

    }
    protected void LoadEdit_DauPhieu(object sender, DirectEventArgs e)
    {
        DAL.BHDAUPHIEU bhdp = new DAL.BHDAUPHIEU();
        bhdp = new BHDauPhieuController().GetByPrKey(Convert.ToInt32(hdfMadauphieu.Text));
        cboloaichungtu.Value = bhdp.LoaiChungTu;
        cboloaichungtu.Text = bhdp.LoaiChungTu;
        txttenchungtu.Text = bhdp.TenChungTu;
        txtsochungtu.Text = bhdp.So;
        txtSoTaiKhoan.Text = bhdp.SoTaiKhoan;
        txtMoTai.Text = bhdp.MoTaiNganHang;
        txtTongSoLaoDong.Text = bhdp.TongSoLaoDong.ToString();
        txtTrongDoNu.Text = bhdp.SoLaoDongNu.ToString();
        txtTongQuyLuong.Text = bhdp.TongQuyLuongTrongQuy.ToString();
        ThoiGianBaoCao.SelectedItem.Text = new BHDauPhieuController().GetQuy(bhdp.TuNgay, bhdp.DenNgay);
        ThoiGianBaoCao.SelectedItem.Value = new BHDauPhieuController().GetQuy(bhdp.TuNgay, bhdp.DenNgay);
        wdQuanLyDanhSachBienDongEdit.Title = "Sửa chứng từ";
        wdQuanLyDanhSachBienDongEdit.Icon = Icon.Pencil;
        wdQuanLyDanhSachBienDongEdit.Show();
    }
    protected void resetwindown_dauphieu(Object sender, DirectEventArgs e)
    {
        wdQuanLyDanhSachBienDongEdit.Title = "Thêm mới chứng từ";
        wdQuanLyDanhSachBienDongEdit.Icon = Icon.Add;
    }
    protected void bt_update(object sender, DirectEventArgs e)
    {
        DateTime? TuNgay = null;
        DateTime? DenNgay = null;
        DAL.BHDAUPHIEU dp = new DAL.BHDAUPHIEU();
        BHDauPhieuController bh = new BHDauPhieuController();
        bh.Quy(ThoiGianBaoCao.SelectedItem.Value.ToString(), Convert.ToInt32(NamBaoCao.Value), out TuNgay, out DenNgay);
        dp.TuNgay = Convert.ToDateTime(TuNgay);
        dp.DenNgay = Convert.ToDateTime(DenNgay);
        dp.IDDauPhieu = string.IsNullOrEmpty(hdfMadauphieu.Text) == true ? 0 : Convert.ToInt32(hdfMadauphieu.Text);
        dp.TenChungTu = txttenchungtu.Text;
        dp.DateCreate = DateTime.Now;
        dp.NgayThang = DateTime.Now;
        dp.SoTaiKhoan = txtSoTaiKhoan.Text;
        dp.MoTaiNganHang = txtMoTai.Text;
        dp.SoLaoDongNu = string.IsNullOrEmpty(txtTrongDoNu.Text) == true ? 0 : Convert.ToInt32(txtTrongDoNu.Text);
        dp.TongSoLaoDong = string.IsNullOrEmpty(txtTongSoLaoDong.Text) == true ? 0 : Convert.ToInt32(txtTongSoLaoDong.Text);
        dp.TongQuyLuongTrongQuy = string.IsNullOrEmpty(txtTongQuyLuong.Text) == true ? 0 : Convert.ToDecimal(txtTongQuyLuong.Text);
        new BHDauPhieuController().Update(dp);
        hdfTuNgay.Text = Convert.ToDateTime(TuNgay).ToString();
        hdfDenNgay.Text = Convert.ToDateTime(DenNgay).ToString();
        wdQuanLyDanhSachBienDongEdit.Hide();
        grpDanhSachBaoCao.Reload();
        Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");

    }
    protected void bt_themmoichungtu(object sender, DirectEventArgs e)
    {
        DAL.BHDAUPHIEU dp = new DAL.BHDAUPHIEU();
        DateTime? TuNgay = null;
        DateTime? DenNgay = null;
        BHDauPhieuController bh = new BHDauPhieuController();
        bh.Quy(ThoiGianBaoCao.SelectedItem.Value.ToString(), Convert.ToInt32(NamBaoCao.Value), out TuNgay, out DenNgay);
        dp.TuNgay = Convert.ToDateTime(TuNgay);
        dp.DenNgay = Convert.ToDateTime(DenNgay);
        #region comment của a khởi
        //DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
        //dtfi.ShortDatePattern = "dd-MM-yyyy";
        //dtfi.DateSeparator = "-";
        //switch (ThoiGianBaoCao.SelectedItem.Value.ToString())
        //{
        //    case "Quý 1":
        //        if (Convert.ToInt32(NamBaoCao.Value) == DateTime.Now.Year)
        //        {
        //            string ngay1 = DateTime.DaysInMonth(DateTime.Now.Year, 3).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-01-" + DateTime.Now.Year + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay1 + "-03-" + DateTime.Now.Year + "", dtfi);
        //            break;
        //        }
        //        else
        //        {
        //            string ngay1 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao.Value), 3).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-01-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay1 + "-03-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            break;
        //        }
        //    case "Quý 2":
        //        if (Convert.ToInt32(NamBaoCao.Value) == DateTime.Now.Year)
        //        {
        //            string ngay2 = DateTime.DaysInMonth(DateTime.Now.Year, 6).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-04-" + DateTime.Now.Year + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay2 + "-06-" + DateTime.Now.Year + "", dtfi);
        //            break;
        //        }
        //        else
        //        {
        //            string ngay2 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao.Value), 6).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-04-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay2 + "-06-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            break;
        //        }
        //    case "Quý 3":
        //        if (Convert.ToInt32(NamBaoCao.Value) == DateTime.Now.Year)
        //        {
        //            string ngay3 = DateTime.DaysInMonth(DateTime.Now.Year, 9).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-07-" + DateTime.Now.Year + "-", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay3 + "-09-" + DateTime.Now.Year + "", dtfi);
        //            break;
        //        }
        //        else
        //        {
        //            string ngay3 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao.Value), 9).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-07-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay3 + "-09-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            break;
        //        }
        //    case "Quý 4":
        //        if (Convert.ToInt32(NamBaoCao.Value) == DateTime.Now.Year)
        //        {
        //            string ngay4 = DateTime.DaysInMonth(DateTime.Now.Year, 12).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-10-" + DateTime.Now.Year + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay4 + "-12-" + DateTime.Now.Year + "", dtfi);
        //            break;
        //        }
        //        else
        //        {
        //            string ngay4 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao.Value), 12).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-10-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay4 + "-12-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            break;
        //        }
        //    default:
        //        if (Convert.ToInt32(NamBaoCao.Value) == DateTime.Now.Year)
        //        {
        //            string ngay5 = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ThoiGianBaoCao.SelectedItem.Value)).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-" + Convert.ToInt32(ThoiGianBaoCao.SelectedItem.Value) + "-" + DateTime.Now.Year + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay5 + "-" + Convert.ToInt32(ThoiGianBaoCao.SelectedItem.Value) + "-" + DateTime.Now.Year + "", dtfi);
        //            break;
        //        }
        //        else
        //        {
        //            string ngay5 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao.Value), Convert.ToInt32(ThoiGianBaoCao.SelectedItem.Value)).ToString();
        //            dp.TuNgay = Convert.ToDateTime("01-" + Convert.ToInt32(ThoiGianBaoCao.SelectedItem.Value) + "-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            dp.DenNgay = Convert.ToDateTime("" + ngay5 + "-" + Convert.ToInt32(ThoiGianBaoCao.SelectedItem.Value) + "-" + Convert.ToInt32(NamBaoCao.Value) + "", dtfi);
        //            break;
        //        }
        //}
        #endregion
        dp.MaDonVi = Session["MaDonVi"].ToString();
        if (cboloaichungtu.SelectedIndex.ToString() != "-1")
        {
            dp.LoaiChungTu = cboloaichungtu.Value.ToString();
        }
        else
        {
            dp.LoaiChungTu = "0";
        }
        dp.TenChungTu = txttenchungtu.Text;
        dp.DateCreate = DateTime.Now;
        dp.NgayThang = DateTime.Now;
        dp.SoTaiKhoan = txtSoTaiKhoan.Text;
        dp.MoTaiNganHang = txtMoTai.Text;
        dp.SoLaoDongNu = string.IsNullOrEmpty(txtTrongDoNu.Text) == true ? 0 : Convert.ToInt32(txtTrongDoNu.Text);
        dp.TongSoLaoDong = string.IsNullOrEmpty(txtTongSoLaoDong.Text) == true ? 0 : Convert.ToInt32(txtTongSoLaoDong.Text);
        dp.TongQuyLuongTrongQuy = string.IsNullOrEmpty(txtTongQuyLuong.Text) == true ? 0 : Convert.ToDecimal(txtTongQuyLuong.Text);
        new BHDauPhieuController().Insert(dp);

        //tạm thời reset ở đây. bao giờ có time reset ở trên kia sau
        cboloaichungtu.Reset();
        txtsochungtu.Reset();
        txttenchungtu.Reset(); txtSoTaiKhoan.Reset(); txtMoTai.Reset();
        txtTongQuyLuong.Reset();
        int tongso;
        int nu;
        new BaoHiemController().DemSoLaoDong(out tongso, out nu);
        txtTongSoLaoDong.Text = tongso.ToString();
        txtTrongDoNu.Text = nu.ToString();

        Notification.Show(new NotificationConfig
        {
            Title = "Thông báo từ hệ thống",
            Icon = Icon.Information,
            Html = "Cập nhật dữ liệu thành công!",
            AutoHide = true,
            HideDelay = 2000,
            AlignCfg = new NotificationAlignConfig
            {
                ElementAnchor = AnchorPoint.BottomRight
            }
        });


        if (e.ExtraParams["D"] == "True")
        {
            wdQuanLyDanhSachBienDongEdit.Hide();
        }
        grpDanhSachBaoCao.Reload();

    }

    #endregion
    protected void bt_click(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfLoaiBienDong.Text))
        {
            DAL.BHQUYDINHBIENDONG qdbd = new BHQUYDINHBIENDONGController().Lay1QuyDinhBienDong(Convert.ToInt32(hdfLoaiBienDong.Text));
            tgfChonBienDong1.Text = qdbd.TenBienDong;
            hdfMaLoaiBienDong.Text = qdbd.MaBienDong;
            bool bhxh, bhyt, bhtn; string tenloaihdong;
            new QuanLyThongTinBaoHiemController().GetHoSoHopDong(int.Parse(hdfIdNhanVien_BaoHiem.Text), out bhxh, out bhyt, out bhtn, out tenloaihdong);
            if (bhxh)
                if (qdbd.IsBHXH != null) chkBHXH1.Checked = (bool)qdbd.IsBHXH ^ bool.Parse(hdfIsBHXH.Text);
            if (bhyt)
                if (qdbd.IsBHYT != null) chkBHYT1.Checked = (bool)qdbd.IsBHYT ^ bool.Parse(hdfIsBHYT.Text);
            if (bhtn)
                if (qdbd.IsBHTN != null) chkBHTN1.Checked = (bool)qdbd.IsBHTN ^ bool.Parse(hdfIsBHTN.Text);
            if (qdbd.IDCheDoBaoHiem != null)
            {
                hdfIDLoaiCheDo.Text = qdbd.IDCheDoBaoHiem.ToString();
                // RM.RegisterClientScriptBlock("rlst", "#{cbbLoaiCheDo1_Store}.reload();");
            }
            hdfIDQuyDinhBienDong.Text = qdbd.IDQuyDinhBienDong.ToString();// dt.Rows[0]["IDQuyDinhBienDong"].ToString();
            // string Id = dt.Rows[0][0].ToString();
            if (qdbd.LoaiAnhHuong == "TMD" || qdbd.LoaiAnhHuong == "GMD")
            {
                //tabPanel.Add(pnlThongTinLuong);
                //pnlThongTinLuong.Hidden = false;
                //pnlThongTinLuong.Show();
                //tabPanel.Add(pnlTruyThoaithu);
                //pnlTruyThoaithu.Hidden = false;
                //pnlTruyThoaithu.Show();
                txtDienGiai1.Text = "QĐ số: " + txtTTSoQD.Text;
                RM.RegisterClientScriptBlock("rl6", "#{pnlThongTinLuong1}.enable();");//#{tabPanel1}.addTab(#{pnlThongTinLuong1});
                //RM.RegisterClientScriptBlock("rl2", "#{pnlTruyThoaithu}.show();#{tabPanel}.addTab(#{pnlTruyThoaithu});");
                // RM.RegisterClientScriptBlock("rl5", "#{tabPanel1}.setActiveTab(#{pnlThongTinChung1});");
            }
            else
            {
                if (qdbd.MaBienDong == "TDMBH")
                    txtDienGiai1.Text = "HĐ số: " + tenloaihdong.Replace("Hợp đồng lao động", "HĐLĐ").Replace("Hợp đồng", "HĐ");
                else
                    txtDienGiai1.Text = "";
                RM.RegisterClientScriptBlock("rl7", "#{pnlThongTinLuong1}.disable();");//#{tabPanel1}.closeTab(#{pnlThongTinLuong1}, 'hide');
                //RM.RegisterClientScriptBlock("rl4", "#{tabPanel}.closeTab(#{pnlTruyThoaithu}, 'hide');");
            }
            if (qdbd.LoaiAnhHuong.Contains("TruyThu"))
            {
                //RM.RegisterClientScriptBlock("r8", "#{pnlTruyThoaithu1}.enable();");//#{tabPanel1}.addTab(#{pnlThongTinLuong1});
                RM.RegisterClientScriptBlock("fr", "hideThoaiThu(); showTruyThu();");
            }
            else
            {
                //RM.RegisterClientScriptBlock("rl9", "#{pnlTruyThoaithu1}.disable();");//#{tabPanel1}.closeTab(#{pnlThongTinLuong1}, 'hide');
                RM.RegisterClientScriptBlock("rl4", "hideTruyThu(); hideThoaiThu();");
            }
            if (qdbd.LoaiAnhHuong.Contains("ThoaiThu"))
            {
                RM.RegisterClientScriptBlock("fr", "hideTruyThu(); showThoaiThu();");
            }
            else
            {
                RM.RegisterClientScriptBlock("fr", "hideThoaiThu(); hideTruyThu();");
            }
        }
    }
    [DirectMethod]
    public void btnTTDongYClick()
    {
        decimal tongluongpccu = (txtTTLuongBHCu.Text == "" ? 0 : decimal.Parse(txtTTLuongBHCu.Text)) + (txtTTPCTNNCu.Text == "" ? 0 : decimal.Parse(txtTTPCTNNCu.Text))
            + (txtTTPCTNVKCu.Text == "" ? 0 : decimal.Parse(txtTTPCTNVKCu.Text)) + (txtTTPhuCapCVCu.Text == "" ? 0 : decimal.Parse(txtTTPhuCapCVCu.Text));
        decimal tongluongpcmoi = (txtTTLuongBHMoi.Text == "" ? 0 : decimal.Parse(txtTTLuongBHMoi.Text)) + (txtTTPCTNNMoi.Text == "" ? 0 : decimal.Parse(txtTTPCTNNMoi.Text))
            + (txtTTPCTNVKMoi.Text == "" ? 0 : decimal.Parse(txtTTPCTNVKMoi.Text)) + (txtTTPhuCapCVMoi.Text == "" ? 0 : decimal.Parse(txtTTPhuCapCVMoi.Text));
        if (tongluongpccu == tongluongpcmoi)
        {
            Dialog.ShowNotification("Thông báo", "Lương và phụ cấp hiện tại hiện đang bằng mức lương mới nhất");
            wdThayDoiLuongPhuCap.Hide();
            return;
        }

        if (tongluongpccu > tongluongpcmoi)
        {
            hdfLoaiBienDong.Text = new BHQUYDINHBIENDONGController().LayIDBienDongByMa("GMD").ToString();
            Dialog.ShowNotification("Thông báo", "Quyết định lương mới nhất làm giảm mức đóng");
        }
        else
        {
            hdfLoaiBienDong.Text = new BHQUYDINHBIENDONGController().LayIDBienDongByMa("TMD").ToString();
            Dialog.ShowNotification("Thông báo", "Quyết định lương mới nhất làm tăng mức đóng");
        }
        //fix vậy đã
        //thay đổi thông tin lương mới
        txtLuongDongBHXHMoi1.Text = txtTTLuongBHMoi.Text;
        txtPhuCapCVMoi1.Text = txtTTPhuCapCVMoi.Text;
        txtPhuCapTNVKMoi1.Text = txtTTPCTNVKMoi.Text;
        txtPhuCapTNNMoi1.Text = txtTTPCTNNMoi.Text;
        txtDienGiai1.Text = "QĐ số: " + txtTTSoQD.Text;
        dfTuNgay1.SelectedDate = dfTTNgayHieuLuc.SelectedDate;

        DAL.BHQUYDINHBIENDONG qdbd = new BHQUYDINHBIENDONGController().Lay1QuyDinhBienDong(Convert.ToInt32(hdfLoaiBienDong.Text));
        tgfChonBienDong1.Text = qdbd.TenBienDong;
        hdfMaLoaiBienDong.Text = qdbd.MaBienDong;
        if (qdbd.IDCheDoBaoHiem != null)
        {
            hdfIDLoaiCheDo.Text = qdbd.IDCheDoBaoHiem.ToString();
            // RM.RegisterClientScriptBlock("rlst", "#{cbbLoaiCheDo1_Store}.reload();");
        }
        hdfIDQuyDinhBienDong.Text = qdbd.IDQuyDinhBienDong.ToString();// dt.Rows[0]["IDQuyDinhBienDong"].ToString();

        RM.RegisterClientScriptBlock("rl6", "#{pnlThongTinLuong1}.enable();");//#{tabPanel1}.addTab(#{pnlThongTinLuong1});   
        if (qdbd.LoaiAnhHuong == "TruyThu" || qdbd.LoaiAnhHuong == "ThoaiThu")
        {
            RM.RegisterClientScriptBlock("r8", "#{pnlTruyThoaithu1}.enable();");//#{tabPanel1}.addTab(#{pnlThongTinLuong1});
        }
        else
        {
            RM.RegisterClientScriptBlock("rl9", "#{pnlTruyThoaithu1}.disable();");//#{tabPanel1}.closeTab(#{pnlThongTinLuong1}, 'hide');
            //RM.RegisterClientScriptBlock("rl4", "#{tabPanel}.closeTab(#{pnlTruyThoaithu}, 'hide');");
        }
        wdThayDoiLuongPhuCap.Hide();
        // RM.RegisterClientScriptBlock("abcd", "ClearControlThongTin();");
    }
    // sự kiện nút lưu thêm
    protected void bt_addclick(object sender, DirectEventArgs e)
    {
        //get usercontrol all
        DAL.BHBIENDONGBAOHIEM bdbh = new DAL.BHBIENDONGBAOHIEM();
        bdbh.MaNhanVien = txtMaCanBo1.Text;
        bdbh.HoTen = txtHoTen1.Text;
        bdbh.NgaySinh = Convert.ToDateTime(dfNgaySinh1.Value);
        bdbh.MaSo = txtSoSoBHXH1.Text;
        bdbh.IDQuyDinhBienDong = Convert.ToInt32(hdfIDQuyDinhBienDong.Text);
        bdbh.IDNhanVien_BaoHiem = Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text);
        bdbh.TuNgay = Convert.ToDateTime(dfTuNgay1.Value);

        if (!new SoftCore.Util().IsDateNull(dfDenNgay1.SelectedDate))
            bdbh.DenNgay = Convert.ToDateTime(dfDenNgay1.Value);
        DAL.BHQUYDINHBIENDONG qdbd = new BHQUYDINHBIENDONGController().Lay1QuyDinhBienDong(bdbh.IDQuyDinhBienDong);
        BHNHANVIEN_BAOHIEM hs = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(hdfMaNhanVien.Value.ToString());
        if (!string.IsNullOrEmpty(hs.LuongBaoHiem.ToString()))
        {
            txtLuongDongBHXHCu1.Text = hs.LuongBaoHiem.ToString();
            txtLuongDongBHXHMoi1.Text = txtLuongDongBHXHCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapCV.ToString()))
        {
            txtPhuCapCVCu1.Text = hs.PhuCapCV.ToString();
            txtPhuCapCVMoi1.Text = txtPhuCapCVCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapTNVK.ToString()))
        {
            txtPhuCapTNVKCu1.Text = hs.PhuCapTNVK.ToString();
            txtPhuCapTNVKMoi1.Text = txtPhuCapTNVKCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapTNN.ToString()))
        {
            txtPhuCapTNNCu1.Text = hs.PhuCapTNN.ToString();
            txtPhuCapTNNMoi1.Text = txtPhuCapTNNCu1.Text;
        }

        if (qdbd.LoaiAnhHuong == "TMD" || qdbd.LoaiAnhHuong == "GMD")
        {
            bdbh.TienLuongCu = txtLuongDongBHXHCu1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHCu1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKCu = txtPhuCapTNVKCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKCu1.Text.Replace('.', ','));
            bdbh.PhuCapNgheCu = txtPhuCapTNNCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNCu1.Text.Replace('.', ','));
            bdbh.PhuCapCVCu = txtPhuCapCVCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVCu1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
            bdbh.PhuCapCVMoi = txtPhuCapCVMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNNgheMoi = txtPhuCapTNNMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKMoi = txtPhuCapTNVKMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKMoi1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
        }
        if (qdbd.LoaiAnhHuong == "TLD")
        {
            bdbh.TienLuongCu = 0;
            bdbh.PhuCapTNVKCu = 0;
            bdbh.PhuCapNgheCu = 0;
            bdbh.PhuCapCVCu = 0;
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
            bdbh.PhuCapCVMoi = txtPhuCapCVMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNNgheMoi = txtPhuCapTNNMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKMoi = txtPhuCapTNVKMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKMoi1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
        }
        if (qdbd.LoaiAnhHuong == "GLD")
        {
            bdbh.TienLuongCu = txtLuongDongBHXHCu1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHCu1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKCu = txtPhuCapTNVKCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKCu1.Text.Replace('.', ','));
            bdbh.PhuCapNgheCu = txtPhuCapTNNCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNCu1.Text.Replace('.', ','));
            bdbh.PhuCapCVCu = txtPhuCapCVCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVCu1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = 0;
            bdbh.PhuCapCVMoi = 0;
            bdbh.PhuCapTNNgheMoi = 0;
            bdbh.PhuCapTNVKMoi = 0;
            bdbh.TienLuongMoi = 0;
        }
        if (qdbd.LoaiAnhHuong.Contains("TruyThu"))
        {
            bdbh.TruyThuBHXH = nfTruyThuBHXH.Text == "" ? 0 : Convert.ToDecimal(nfTruyThuBHXH.Text.Replace('.', ','));
            bdbh.TruyThuBHYT = nfTruyThuBHYT.Text == "" ? 0 : Convert.ToDecimal(nfTruyThuBHYT.Text.Replace('.', ','));
        }
        if (qdbd.LoaiAnhHuong.Contains("ThoaiThu"))
        {
            bdbh.ThoaiThuBHXH = nfThoaiThuBHXH.Text == "" ? 0 : Convert.ToDecimal(nfThoaiThuBHXH.Text.Replace('.', ','));
            bdbh.ThoaiThuBHYT = nfThoaiThuBHYT.Text == "" ? 0 : Convert.ToDecimal(nfThoaiThuBHYT.Text.Replace('.', ','));
        }
        bdbh.DaCoSo = chkDaCoSo.Checked;
        bdbh.KhongTraThe = chkKhongTraThe.Checked;
        bdbh.DienGiai = txtDienGiai1.Text;
        bdbh.UserID = CurrentUser.ID;
        bdbh.MaDonVi = Session["MaDonVi"].ToString();
        bdbh.DateCreate = DateTime.Now;
        //bdbh.ThangDangKy = DateTime.Now;
        if (!SoftCore.Util.GetInstance().IsDateNull(dfNgayDangKyVoiCQBH.SelectedDate))
        {
            bdbh.ThangDangKy = (DateTime)dfNgayDangKyVoiCQBH.Value;
        }
        bdbh.ChucVu = "";

        //update tinh trangg dong cho nhan vien
        BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text));
        nvbh.IDNhanVien_BaoHiem = Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text);
        nvbh.DangDongBHXH = chkBHXH1.Checked;
        nvbh.DangDongBHYT = chkBHYT1.Checked;
        nvbh.DangDongBHTN = chkBHTN1.Checked;
        bdbh.NgaySinh = nvbh.NgaySinh;
        bdbh.GioiTinh = nvbh.GioiTinh ?? true;
        bdbh.Loai = qdbd.LoaiAnhHuong;

        new QuanLyBienDongBaoHiemController().InsertBienDongBaoHiem(bdbh);
        new NhanVien_BaoHiemController().UpdateNhanVien_BaoHiem(nvbh);
        Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
        if (e.ExtraParams["Command"] == "Insert")
        {
            if (hdfMaLoaiBienDong.Text == "TMD" || hdfMaLoaiBienDong.Text == "GMD")
                UpdateNguocNhanVien_BaoHiem();
        }


        if (e.ExtraParams["Close"] == "True")
        {
            //wdThemSuaBienDongNhanVien.Hide();
            wdThemSuaBienDongNhanVien.Hide();
        }
        grpChiTietNhanVien.Reload();
        grpBienDongBaoHiem.Reload();
        // update ngược lại bảng NHANVIEN_BAOHIEM

    }

    [DirectMethod]
    public void UpdateNguocNhanVien_BaoHiem()
    {
        BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text));

        nvbh.IDNhanVien_BaoHiem = Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text);
        if (!string.IsNullOrEmpty(txtLuongDongBHXHMoi1.Text))
        {
            nvbh.LuongBaoHiem = Convert.ToDecimal(txtLuongDongBHXHMoi1.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapTNNMoi1.Text))
        {
            nvbh.PhuCapTNN = Convert.ToDecimal(txtPhuCapTNNMoi1.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapCVMoi1.Text))
        {
            nvbh.PhuCapCV = Convert.ToDecimal(txtPhuCapCVMoi1.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapTNVKMoi1.Text))
        {
            nvbh.PhuCapTNVK = Convert.ToDecimal(txtPhuCapTNVKMoi1.Text);
        }

        NhanVien_BaoHiemController nvc = new NhanVien_BaoHiemController();
        nvc.UpdateNhanVien_BaoHiem(nvbh);

    }

    //sự kiện cập nhật sửa
    protected void btnCapNhatSua_Click(object sender, DirectEventArgs e)
    {
        QuanLyBienDongBaoHiemController qlbd = new QuanLyBienDongBaoHiemController();
        BHBIENDONGBAOHIEM bdbh = qlbd.GetBienDongBaoHiemByID(int.Parse(hdfChiTietID.Text));
        bdbh.IDQuyDinhBienDong = int.Parse(hdfIDQuyDinhBienDong.Text);
        bdbh.TuNgay = (DateTime)dfTuNgay1.Value;

        if (!SoftCore.Util.GetInstance().IsDateNull(dfDenNgay1.SelectedDate))
        {
            bdbh.DenNgay = (DateTime)dfDenNgay1.Value;
        }
        if (!SoftCore.Util.GetInstance().IsDateNull(dfNgayDangKyVoiCQBH.SelectedDate))
        {
            bdbh.ThangDangKy = (DateTime)dfNgayDangKyVoiCQBH.Value;
        }
        DAL.BHQUYDINHBIENDONG qdbd = new BHQUYDINHBIENDONGController().Lay1QuyDinhBienDong(bdbh.IDQuyDinhBienDong);
        bdbh.Loai = qdbd.LoaiAnhHuong;
        BHNHANVIEN_BAOHIEM hs = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(hdfMaNhanVien.Value.ToString());
        if (!string.IsNullOrEmpty(hs.LuongBaoHiem.ToString()))
        {
            txtLuongDongBHXHCu1.Text = hs.LuongBaoHiem.ToString();
            txtLuongDongBHXHMoi1.Text = txtLuongDongBHXHCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapCV.ToString()))
        {
            txtPhuCapCVCu1.Text = hs.PhuCapCV.ToString();
            txtPhuCapCVMoi1.Text = txtPhuCapCVCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapTNVK.ToString()))
        {
            txtPhuCapTNVKCu1.Text = hs.PhuCapTNVK.ToString();
            txtPhuCapTNVKMoi1.Text = txtPhuCapTNVKCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapTNN.ToString()))
        {
            txtPhuCapTNNCu1.Text = hs.PhuCapTNN.ToString();
            txtPhuCapTNNMoi1.Text = txtPhuCapTNNCu1.Text;
        }
        if (qdbd.LoaiAnhHuong == "TMD" || qdbd.LoaiAnhHuong == "GMD")
        {
            bdbh.TienLuongCu = txtLuongDongBHXHCu1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHCu1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKCu = txtPhuCapTNVKCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKCu1.Text.Replace('.', ','));
            bdbh.PhuCapNgheCu = txtPhuCapTNNCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNCu1.Text.Replace('.', ','));
            bdbh.PhuCapCVCu = txtPhuCapCVCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVCu1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
            bdbh.PhuCapCVMoi = txtPhuCapCVMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNNgheMoi = txtPhuCapTNNMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKMoi = txtPhuCapTNVKMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKMoi1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));

            if (e.ExtraParams["Command"] == "Insert")
            {
                if (hdfMaLoaiBienDong.Text == "TMD" || hdfMaLoaiBienDong.Text == "GMD")
                    UpdateNguocNhanVien_BaoHiem();
            }
        }
        else if (qdbd.LoaiAnhHuong == "TruyThu")
        {
            bdbh.TruyThuBHXH = nfTruyThuBHXH.Text == "" ? 0 : Convert.ToDecimal(nfTruyThuBHXH.Text.Replace('.', ','));
            bdbh.TruyThuBHYT = nfTruyThuBHYT.Text == "" ? 0 : Convert.ToDecimal(nfTruyThuBHYT.Text.Replace('.', ','));
        }
        else if (qdbd.LoaiAnhHuong == "ThoaiThu")
        {
            bdbh.ThoaiThuBHYT = nfThoaiThuBHYT.Text == "" ? 0 : Convert.ToDecimal(nfThoaiThuBHYT.Text.Replace('.', ','));
            bdbh.ThoaiThuBHXH = nfThoaiThuBHXH.Text == "" ? 0 : Convert.ToDecimal(nfThoaiThuBHXH.Text.Replace('.', ','));
        }
        else
        {
            bdbh.TienLuongCu = txtLuongDongBHXHCu1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHCu1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKCu = txtPhuCapTNVKCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKCu1.Text.Replace('.', ','));
            bdbh.PhuCapNgheCu = txtPhuCapTNNCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNCu1.Text.Replace('.', ','));
            bdbh.PhuCapCVCu = txtPhuCapCVCu1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVCu1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
            bdbh.PhuCapCVMoi = txtPhuCapCVMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapCVMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNNgheMoi = txtPhuCapTNNMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNNMoi1.Text.Replace('.', ','));
            bdbh.PhuCapTNVKMoi = txtPhuCapTNVKMoi1.Text == "" ? 0 : Convert.ToDecimal(txtPhuCapTNVKMoi1.Text.Replace('.', ','));
            bdbh.TienLuongMoi = txtLuongDongBHXHMoi1.Text == "" ? 0 : Convert.ToDecimal(txtLuongDongBHXHMoi1.Text.Replace('.', ','));
        }

        bdbh.KhongTraThe = chkKhongTraThe.Checked;
        bdbh.DaCoSo = chkDaCoSo.Checked;
        bdbh.DienGiai = txtDienGiai1.Text;
        qlbd.UpdateBienDongBaoHiem(bdbh);

        //update tinh trangg dong cho nhan vien
        BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text));
        nvbh.IDNhanVien_BaoHiem = Convert.ToInt32(hdfIdNhanVien_BaoHiem.Text);
        nvbh.DangDongBHXH = chkBHXH1.Checked;
        nvbh.DangDongBHYT = chkBHYT1.Checked;
        nvbh.DangDongBHTN = chkBHTN1.Checked;
        new NhanVien_BaoHiemController().UpdateNhanVien_BaoHiem(nvbh);


        Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
        if (e.ExtraParams["Close"] == "True")
        {
            wdThemSuaBienDongNhanVien.Hide();
        }
        grpChiTietNhanVien.Reload();
        grpBienDongBaoHiem.Reload();

    }
    [DirectMethod]//khi kích vào nút thêm, tự động load dữ liệu của nhân viên
    public void loadThongTinNhanVien()
    {
        btnLayThayDoiTuQuyetDinhLuong.Disabled = false;
        BHNHANVIEN_BAOHIEM hs = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(hdfMaNhanVien.Value.ToString());
        txtMaCanBo1.Text = hs.MaNhanVien;
        dfNgaySinh1.Value = hs.NgaySinh;
        txtLuongDongBH1.Text = hs.LuongBaoHiem.ToString();
        txtHoTen1.Text = hs.HoTen;
        txtSoSoBHXH1.Text = hs.SoSoBHXH;
        txtThoiGianDongBHXH1.Text = new BaoHiemController().ChuyenSoThangDongBH(Convert.ToInt32(hs.ThoiGianDongBaoHiem));
        hdfIdNhanVien_BaoHiem.Text = hs.IDNhanVien_BaoHiem.ToString();
        //set check vaf hidden field cho check
        chkBHTN1.Checked = (bool)hs.DangDongBHTN;
        chkBHYT1.Checked = (bool)hs.DangDongBHYT;
        chkBHXH1.Checked = (bool)hs.DangDongBHXH;
        hdfIsBHXH.Text = hs.DangDongBHXH.ToString();
        hdfIsBHYT.Text = hs.DangDongBHYT.ToString();
        hdfIsBHTN.Text = hs.DangDongBHTN.ToString();
        //if (hs.TrangThaiCapTheBHYT != null)
        //    chkKhongTraThe.Checked = hs.TrangThaiCapTheBHYT == "DaCapThe" ? true : false;
        chkKhongTraThe.Checked = false;
        if (hs.TrangThaiCapSoBHXH != null)
            chkDaCoSo.Checked = hs.TrangThaiCapSoBHXH == "DaCapSo" ? true : false;
        if (!string.IsNullOrEmpty(hs.LuongBaoHiem.ToString()))
        {
            txtLuongDongBHXHCu1.Text = hs.LuongBaoHiem.ToString();
            txtLuongDongBHXHMoi1.Text = txtLuongDongBHXHCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapCV.ToString()))
        {
            txtPhuCapCVCu1.Text = hs.PhuCapCV.ToString();
            txtPhuCapCVMoi1.Text = txtPhuCapCVCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapTNVK.ToString()))
        {
            txtPhuCapTNVKCu1.Text = hs.PhuCapTNVK.ToString();
            txtPhuCapTNVKMoi1.Text = txtPhuCapTNVKCu1.Text;
        }
        if (!string.IsNullOrEmpty(hs.PhuCapTNN.ToString()))
        {
            txtPhuCapTNNCu1.Text = hs.PhuCapTNN.ToString();
            txtPhuCapTNNMoi1.Text = txtPhuCapTNNCu1.Text;
        }
        dfTuNgay1.SelectedDate = DateTime.Now;
        #region Xử lý thay đổi thông tin lương từ quyết định lương
        txtTTLuongBHCu.Text = txtLuongDongBHXHCu1.Text;
        txtTTPhuCapCVCu.Text = txtPhuCapCVCu1.Text;
        txtTTPCTNVKCu.Text = txtPhuCapTNVKCu1.Text;
        txtTTPCTNNCu.Text = txtPhuCapTNNCu1.Text;
        string soquyetdinh;
        string tenquyetdinh;
        DateTime? ngayky;
        DateTime? Ngayhieuluc;
        DateTime? Hethieuluc;
        decimal? luongbaohiem;
        decimal? phucapcv;
        decimal? phucaptnn;
        decimal? phucaptnvk;
        decimal? phucapkhac;
        new BaoHiemController().TTQuyetDinhLuongMoiNhat(hs.IDNhanVien_BaoHiem, out soquyetdinh, out tenquyetdinh, out ngayky, out Ngayhieuluc, out Hethieuluc, out luongbaohiem, out phucapcv, out phucaptnn, out phucaptnvk, out phucapkhac);
        txtTTSoQD.Text = soquyetdinh;
        txtTTTenQD.Text = tenquyetdinh;
        if (!new SoftCore.Util().IsDateNull(Ngayhieuluc))
            dfTTNgayHieuLuc.SelectedDate = (DateTime)Ngayhieuluc;
        if (!new SoftCore.Util().IsDateNull(Hethieuluc))
            dfTTNgayHetHieuLuc.SelectedDate = (DateTime)Hethieuluc;

        if (luongbaohiem != null)
        {
            txtTTLuongBHMoi.Text = luongbaohiem.ToString();
            txtLuongDongBHXHMoi1.Text = txtLuongDongBHXHCu1.Text;
        }
        if (phucapcv != null)
        {
            txtTTPhuCapCVMoi.Text = phucapcv.ToString();
            txtPhuCapCVMoi1.Text = txtPhuCapCVCu1.Text;
        }
        if (phucaptnn != null)
        {
            txtTTPCTNNMoi.Text = phucaptnn.ToString();
            txtPhuCapTNNMoi1.Text = txtPhuCapTNNCu1.Text;
        }
        if (phucaptnvk != null)
        {
            txtTTPCTNVKMoi.Text = phucaptnvk.ToString();
            txtPhuCapTNVKMoi1.Text = txtPhuCapTNVKCu1.Text;
        }
        #endregion
    }

    [DirectMethod]
    public void XoaChiTietBienDong(int id)
    {
        DAL.BHBIENDONGBAOHIEM bdbh = new QuanLyBienDongBaoHiemController().GetBienDongBaoHiemByID(id);
        new QuanLyBienDongBaoHiemController().DeleteBienDongBaoHiem(bdbh);
        //Dialog.ShowNotification("Thông báo", "Đã xoá thành công");
        //grpChiTietNhanVien.Reload();
        //grpBienDongBaoHiem.Reload();
    }
    [DirectMethod] //khi kích vào nút sửa, tự động load dữ liệu biến động
    public void loadThongTinBienDong()
    {// thay đổi title icon windown
        wdThemSuaBienDongNhanVien.Title = "Sửa biến động cho nhân viên";
        wdThemSuaBienDongNhanVien.Icon = Icon.Pencil;
        ChiTietNhanVienBienDongInfo bdbh = new QuanLyBienDongBaoHiemController().GetByIDBienDongBaoHiem(int.Parse(hdfChiTietID.Text));
        txtMaCanBo1.Text = bdbh.MaNhanVien;
        txtHoTen1.Text = bdbh.HoTen;
        dfNgaySinh1.Value = bdbh.NgaySinh;
        txtSoSoBHXH1.Text = bdbh.MaSo;
        // thông tin về truy thu thoái thu
        nfTruyThuBHXH.Text = bdbh.TruyThuBHXH.ToString();
        nfTruyThuBHYT.Text = bdbh.TruyThuBHYT.ToString();
        nfThoaiThuBHXH.Text = bdbh.ThoaiThuBHXH.ToString();
        nfThoaiThuBHYT.Text = bdbh.ThoaiThuBHYT.ToString();
        //thong tin nhan vien
        DAL.BHNHANVIEN_BAOHIEM hs = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(hdfMaNhanVien.Value.ToString());
        txtLuongDongBH1.Text = hs.LuongBaoHiem.ToString();
        txtThoiGianDongBHXH1.Text = new BaoHiemController().ChuyenSoThangDongBH((int)hs.ThoiGianDongBaoHiem);
        // check 
        chkBHTN1.SetValue(hs.DangDongBHTN);
        chkBHYT1.SetValue(hs.DangDongBHYT);
        chkBHXH1.SetValue(hs.DangDongBHXH);
        hdfIsBHXH.Text = hs.DangDongBHXH.ToString();
        hdfIsBHYT.Text = hs.DangDongBHYT.ToString();
        hdfIsBHTN.Text = hs.DangDongBHTN.ToString();

        //thông tin quy định biến động
        DAL.BHQUYDINHBIENDONG qdbd = new BHQUYDINHBIENDONGController().Lay1QuyDinhBienDong(bdbh.IDQuyDinhBienDong);
        //set 1 số id cho hiddenfield
        hdfIdNhanVien_BaoHiem.Text = hs.IDNhanVien_BaoHiem.ToString();
        hdfIDQuyDinhBienDong.Text = qdbd.IDQuyDinhBienDong.ToString();
        hdfIDLoaiCheDo.Text = qdbd.IDCheDoBaoHiem.ToString();
        hdfMaLoaiBienDong.Text = qdbd.MaBienDong;
        tgfChonBienDong1.Text = qdbd.TenBienDong; //dt.Rows[0]["TenBienDong"].ToString();
        hdfMaLoaiBienDong.Text = qdbd.MaBienDong;
        chkBHXH1.Checked = (bool)qdbd.IsBHXH;// (bool)dt.Rows[0]["IsBHXH"];
        chkBHYT1.Checked = (bool)qdbd.IsBHYT;// (bool)dt.Rows[0]["IsBHYT"];
        chkBHTN1.Checked = (bool)qdbd.IsBHTN;// (bool)dt.Rows[0]["IsBHTN"];
        if (qdbd.IDCheDoBaoHiem != null)
        {
            hdfIDLoaiCheDo.Text = qdbd.IDCheDoBaoHiem.ToString();
            //       RM.RegisterClientScriptBlock("rlst", "#{cbbLoaiCheDo1_Store}.reload();");
        }
        hdfIDQuyDinhBienDong.Text = qdbd.IDQuyDinhBienDong.ToString();// dt.Rows[0]["IDQuyDinhBienDong"].ToString();


        txtLuongDongBHXHCu1.Text = bdbh.TienLuongCu.ToString();
        txtPhuCapTNVKCu1.Text = bdbh.PhuCapTNVKCu.ToString();
        txtPhuCapTNNCu1.Text = bdbh.PhuCapNgheCu.ToString();
        txtPhuCapCVCu1.Text = bdbh.PhuCapCVCu.ToString();
        txtLuongDongBHXHMoi1.Text = bdbh.TienLuongMoi.ToString();
        txtPhuCapCVMoi1.Text = bdbh.PhuCapCVMoi.ToString();
        txtPhuCapTNNMoi1.Text = bdbh.PhuCapTNNgheMoi.ToString();
        txtPhuCapTNVKMoi1.Text = bdbh.PhuCapTNVKMoi.ToString();
        txtLuongDongBHXHMoi1.Text = bdbh.TienLuongMoi.ToString();
        //if (qdbd.LoaiAnhHuong == "TMD" || qdbd.LoaiAnhHuong == "GMD")
        //{
        //    RM.RegisterClientScriptBlock("rl10", "#{pnlThongTinLuong1}.enable();");//#{tabPanel1}.addTab(#{pnlThongTinLuong1});
        //}
        //else
        //{
        //    RM.RegisterClientScriptBlock("rl11", "#{pnlThongTinLuong1}.disable();");//#{tabPanel1}.closeTab(#{pnlThongTinLuong1}, 'hide');
        //}

        //if (qdbd.LoaiAnhHuong == "TruyThu" || qdbd.LoaiAnhHuong == "ThoaiThu")
        //{
        //    RM.RegisterClientScriptBlock("rl2", "#{pnlTruyThoaithu1}.enable();");//#{tabPanel1}.addTab(#{pnlThongTinLuong1});
        //}
        //else
        //{
        //    RM.RegisterClientScriptBlock("rl13", "#{pnlTruyThoaithu1}.disable();");//#{tabPanel1}.closeTab(#{pnlThongTinLuong1}, 'hide');
        //    //RM.RegisterClientScriptBlock("rl4", "#{tabPanel}.closeTab(#{pnlTruyThoaithu}, 'hide');");
        //}

        dfTuNgay1.Value = bdbh.TuNgay.Value;
        if (bdbh.DenNgay != null)
            dfDenNgay1.Value = bdbh.DenNgay;
        if (bdbh.ThangDangKy.HasValue)
        {
            dfNgayDangKyVoiCQBH.Value = bdbh.ThangDangKy.Value;
        }
        chkDaCoSo.Checked = (bool)bdbh.DaCoSo;
        chkKhongTraThe.Checked = (bool)bdbh.KhongTraThe;
        txtDienGiai1.Text = bdbh.DienGiai;
        //Thông tin chế độ.
    }
    protected void ResetWindown(object sender, DirectEventArgs e)
    {
        wdThemSuaBienDongNhanVien.Title = "Thêm mới biến động cho nhân viên";
        wdThemSuaBienDongNhanVien.Icon = Icon.Add;
    }
    //protected void cbbLoaiCheDo1_Store_Refresh(object sender, StoreRefreshDataEventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(hdfIDLoaiCheDo.Text))
    //    {
    //        List<CheDoBaoHiemInfo> list = new CheDoBaoHiemController().LayConTheoMaCha(int.Parse(hdfIDLoaiCheDo.Text));
    //        List<object> obj = new List<object>();
    //        obj.Add(new {ID=0, MaCheDoBaoHiem = "000", TenCheDoBaoHiem = "Không chọn chế độ bảo hiểm"});
    //        foreach (var item in list)
    //        {
    //            obj.Add(new {ID=item.IDCheDoBaoHiem, MaCheDoBaoHiem = item.MaCheDoBaohiem, TenCheDoBaoHiem = item.TenCheDoBaoHiem });
    //        }
    //        cbbLoaiCheDo1_Store.DataSource=obj;
    //        cbbLoaiCheDo1_Store.DataBind();
    //    }
    //    //List<DM_NOICAP_CMND> lists = new DM_NOICAP_CMNDController().GetByAll();
    //    //List<object> obj = new List<object>();
    //    //foreach (var item in lists)
    //    //{
    //    //    obj.Add(new { MA_NOICAP_CMND = item.MA_NOICAP_CMND, TEN_NOICAP_CMND = item.TEN_NOICAP_CMND });
    //    //}
    //    //cbx_noicapcmnd_Store.DataSource = obj;
    //    //cbx_noicapcmnd_Store.DataBind();
    //}
}