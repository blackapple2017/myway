using DAL;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtMessage;
using SoftCore;
using SoftCore.AccessHistory;
using SoftCore.Security;
using System.Globalization;

public partial class Modules_BaoHiem_CheDoBaoHiem : WebBase
{
    static decimal LuongDongBHThangLienKe = 0, LuongToiThieuChung = 0, LuongBHBQ6Thang = 0;
    int SoNgayNghi;
    static int ThoiGianDongBHXH = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (X.IsAjaxRequest) return;
        hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        ThoiGianBaoCao.SelectedItem.Value = DateTime.Now.Month.ToString();
        NamBaoCao.Value = DateTime.Now.Year;
        hdfMenuID.SetValue(MenuID);
        new DTH.BorderLayout()
        {
            menuID = MenuID,
            script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; grpNhanVienCheDo_Store.reload();"
        }.AddDepartmentList(br, CurrentUser.ID, true);
        int tongso;
        int nu;
        new BaoHiemController().DemSoLaoDong(out tongso, out nu);
        // txtSoTaiKhoan.Text=ReportController.GetInstance().get
        txtTongSoLaoDong.Text = tongso.ToString();
        txtTrongDoNu.Text = nu.ToString();
    }
    [DirectMethod]
    public void DeleteRecord_dauphieu(int Id)
    {
        //new BHDauPhieuController().Delete(Convert.ToInt32(hdfMadauphieu.Text));
        //Dialog.ShowNotification("Đã xóa thành công");
        //try
        //{
        //    foreach (var item in RowSelectionModel4.SelectedRows)
        //    {
        //        new BHDauPhieuController().Delete(Convert.ToInt32(item.RecordID));

        //    }
        //}
        //catch (Exception ex)
        //{
        //    Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        //}
    }
    public void Delete_DauPhieu(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel4.SelectedRows)
            {
                new BHDauPhieuController().Delete(int.Parse("0" + item.RecordID));
            }
            grpDanhSachBaoCao.Reload();
            RM.RegisterClientScriptBlock("resetAfterDelete", "resetAfterDelete();");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    protected void LoadEdit_DauPhieu(object sender, DirectEventArgs e)
    {
        DAL.BHDAUPHIEU bhdp = new DAL.BHDAUPHIEU();
        bhdp = new BHDauPhieuController().GetByPrKey(int.Parse("0" + hdfMadauphieu.Text));
        ThoiGianBaoCao.SelectedItem.Text = new BHDauPhieuController().GetQuy(bhdp.TuNgay, bhdp.DenNgay);
        ThoiGianBaoCao.SelectedItem.Value = new BHDauPhieuController().GetQuy(bhdp.TuNgay, bhdp.DenNgay);
        NamBaoCao.Value = bhdp.TuNgay.Year;
        cboloaichungtu.Value = bhdp.LoaiChungTu;
        cboloaichungtu.Text = bhdp.LoaiChungTu;
        txttenchungtu.Text = bhdp.TenChungTu;
        txtsochungtu.Text = bhdp.So;
        txtSoTaiKhoan.Text = bhdp.SoTaiKhoan;
        txtMoTai.Text = bhdp.MoTaiNganHang;
        txtTongSoLaoDong.Text = bhdp.TongSoLaoDong.ToString();
        txtTrongDoNu.Text = bhdp.SoLaoDongNu.ToString();
        txtTongQuyLuong.Text = bhdp.TongQuyLuongTrongQuy.ToString();
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
        wdQuanLyDanhSachBienDongEdit.Hide();
        //Dialog.ShowNotification("Cập nhật dữ liệu thành công");
        grpDanhSachBaoCao.Reload();
        grpChiTietBaoCao.Reload();
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
        dp.MaDonVi = Session["MaDonVi"].ToString();
        dp.LoaiChungTu = cboloaichungtu.SelectedIndex.ToString() != "-1" ? cboloaichungtu.Value.ToString() : "0";
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
        //Dialog.ShowNotification("Cập nhật dữ liệu thành công");
        if (e.ExtraParams["D"] == "True") wdQuanLyDanhSachBienDongEdit.Hide();
        grpDanhSachBaoCao.Reload();
    }

    public void cbbCheDo1Store_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        int count;
        cbbCheDo1Store.DataSource = new CheDoBaoHiemController().GetAllChild(Session["MaDonVi"].ToString(), out count);
        cbbCheDo1Store.DataBind();
    }
    public void cbbDieuKienHuong1Store_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        if (hdfIDCheDoBaoHiem.Text == "") return;
        int count;
        cbbDieuKienHuong1Store.DataSource = new BangTinhCheDoBaoHiemController().GetByIDCheDoNghi(Session["MaDonVi"].ToString(), out count, int.Parse("0" + hdfIDCheDoBaoHiem.Text));
        cbbDieuKienHuong1Store.DataBind();
    }
    //click vào nút thêm, hoặc sửa. load thông tin của nhân viên
    protected void btnAddXemTheoNhanVien_Click(object sender, DirectEventArgs e)
    {
        //txtThoiGianDong1.StyleSpec = "color:black";
        //txtSoNgayNghi1.StyleSpec = "color:black";
        //new BaoHiemController().ClearControl(wdXemTheoNhanVien);
        DAL.BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByIDNhanVien_BaoHiem(int.Parse(hdfIDNhanVienBaoHiem.Text));
        txtMaCanBo1.Text = nvbh.MaNhanVien;
        txtHoTen1.Text = nvbh.HoTen;
        if (!Util.GetInstance().IsDateNull(nvbh.NgaySinh))
            dfNgaySinh1.SelectedDate = (DateTime)nvbh.NgaySinh;
        txtSoSoBHXH1.Text = nvbh.SoSoBHXH;
        txtSoCMND1.Text = nvbh.SoCMTND;
        txtThoiGianDong1.Text = new BaoHiemController().ChuyenSoThangDongBH(Convert.ToInt32(nvbh.ThoiGianDongBaoHiem));
        ThoiGianDongBHXH = Convert.ToInt32(nvbh.ThoiGianDongBaoHiem);

        if (string.IsNullOrEmpty(nvbh.SoSoBHXH))
        {
            txtSoSoBHXH1.StyleSpec = "color:red;";
            Dialog.ShowNotification("Nhân viên này chưa có số sổ BHXH");
        }
        // chkDaThanhToan1.Checked = true;
        if (hdfwdShow.Text == "Sua")
        {
            int iddieukienhuong;
            DAL.BHCHITIETCHEDOBAOHIEM chitiet = new CheDoBaoHiemController().GetChiTietCheDoBaoHiemByID(int.Parse(hdfIDChiTietCheDoBaoHiem.Text));
            iddieukienhuong = chitiet.IDBangTinhCheDoBaoHiem;
            DAL.BHBANGTINHCHEDOBAOHIEM bangtinh = new BangTinhCheDoBaoHiemController().GetByPrKey(chitiet.IDBangTinhCheDoBaoHiem);
            //cbbCheDo1Store
            // RM.RegisterClientScriptBlock("abc","cbbCheDo1Store.reload();");
            cbbCheDo1.SetValue(bangtinh.IDCheDoBaoHiem);
            hdfIDCheDoBaoHiem.Text = bangtinh.IDCheDoBaoHiem.ToString();
            RM.RegisterClientScriptBlock("abc", "cbbDieuKienHuong1Store.reload();");
            hdfDieuKienHuong.Text = bangtinh.IDBangTinhCheDoBaoHiem.ToString();
            cbbDieuKienHuong1.SetValue(iddieukienhuong);
            cbbDieuKienHuong1.Text = bangtinh.TenDieuKienHuong;
            if (!Util.GetInstance().IsDateNull(chitiet.NgayBatDau))
                dfNgayBatDau1.SelectedDate = chitiet.NgayBatDau;
            if (!Util.GetInstance().IsDateNull(chitiet.NgayKetThuc))
                dfNgayKetThuc1.SelectedDate = chitiet.NgayKetThuc;
            txtSoTienDeNghi1.Text = chitiet.SoTienDeNghi.ToString();
            txtSoNgayNghi1.Text = chitiet.SoNgayNghi.ToString();
            chkDaThanhToan1.Checked = chitiet.TinhTrangThanhToan;
            txtChiTieuLuong1.Text = chitiet.TienLuongTinhHuong.ToString();
            txtGhiChu1.Text = chitiet.GhiChu;
            txtLuyKe1.Text = new CheDoBaoHiemController().TinhSoNgayNghiNhanVien(int.Parse(hdfIDNhanVienBaoHiem.Text), int.Parse(hdfIDCheDoBaoHiem.Text)).ToString();
        }

    }
    protected void btnCapNhatXemTheoNhanVienClick(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfwdShow.Text == "Them")
            {
                BHCHITIETCHEDOBAOHIEM chitiet = new BHCHITIETCHEDOBAOHIEM();
                chitiet.IDNhanVien_BaoHiem = int.Parse("0" + hdfIDNhanVienBaoHiem.Text);
                chitiet.IDBangTinhCheDoBaoHiem = int.Parse("0" + hdfDieuKienHuong.Text);
                chitiet.MucDoSuyGiamKhaNangLaoDong = "";
                chitiet.NgayBatDau = dfNgayBatDau1.SelectedDate;
                chitiet.NgayKetThuc = dfNgayKetThuc1.SelectedDate;
                chitiet.SoNgayNghi = int.Parse("0" + txtSoNgayNghi1.Text);
                chitiet.SoTienDeNghi = decimal.Parse("0" + txtSoTienDeNghi1.Value);
                chitiet.TinhTrangThanhToan = chkDaThanhToan1.Checked;
                chitiet.TienLuongTinhHuong = decimal.Parse("0" + txtChiTieuLuong1.Text);
                chitiet.GhiChu = txtGhiChu1.Text;
                chitiet.UserID = CurrentUser.ID;
                chitiet.DateCreate = DateTime.Now;
                chitiet.MaDonVi = Session["MaDonVi"].ToString();
                new CheDoBaoHiemController().InsertChiTietCheDoBaoHiem(chitiet);
            }
            else
            {
                BHCHITIETCHEDOBAOHIEM chitiet = new CheDoBaoHiemController().GetChiTietCheDoBaoHiemByID(int.Parse("0" + hdfIDChiTietCheDoBaoHiem.Text));
                chitiet.IDNhanVien_BaoHiem = int.Parse("0" + hdfIDNhanVienBaoHiem.Text);
                chitiet.IDBangTinhCheDoBaoHiem = int.Parse("0" + hdfDieuKienHuong.Text);
                chitiet.MucDoSuyGiamKhaNangLaoDong = "";
                chitiet.NgayBatDau = dfNgayBatDau1.SelectedDate;
                chitiet.NgayKetThuc = dfNgayKetThuc1.SelectedDate;
                chitiet.SoNgayNghi = int.Parse("0" + txtSoNgayNghi1.Text);
                chitiet.SoTienDeNghi = decimal.Parse("0" + txtSoTienDeNghi1.Text);
                chitiet.TinhTrangThanhToan = chkDaThanhToan1.Checked;
                chitiet.GhiChu = txtGhiChu1.Text;
                new CheDoBaoHiemController().CapNhatChiTietCheDoBaoHiem(chitiet);

            }
            //Dialog.ShowNotification("Cập nhật dữ liệu  thành công");
            grpChiTietNhanVien.Reload();
            grpNhanVienCheDo.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra: " + ex.Message);
        }
    }

    // 1 số biến dùng chung cho việc tính toán trong 
    // cái này nguy cơ bị lỗi rất cao
    // nếu người dùng nhập lại chế độ bảo hiểm khi xóa hết ds chế độ bảo hiểm cũ đi
    [DirectMethod]
    public void cbbCheDo1_Selected()
    {
        cbbDieuKienHuong1.Reset();
        txtLuyKe1.Text = new CheDoBaoHiemController().TinhSoNgayNghiNhanVien(int.Parse("0" + hdfIDNhanVienBaoHiem.Text), int.Parse("0" + hdfIDCheDoBaoHiem.Text)).ToString();
        DateTime date;
        if (!Util.GetInstance().IsDateNull(dfNgayBatDau1.SelectedDate))
            date = dfNgayBatDau1.SelectedDate;
        else
        {
            date = DateTime.Now;
        }
        new BHCHEDOBAOHIEMController().TinhChiTieu(date, int.Parse("0" + hdfIDNhanVienBaoHiem.Text), out LuongDongBHThangLienKe, out LuongToiThieuChung, out LuongBHBQ6Thang);
        switch (int.Parse(cbbCheDo1.Value.ToString()))
        {
            case 23:
            case 24:
            case 76:
                txtChiTieuLuong1.FieldLabel = "Lương đóng BH tháng liền kề";
                txtChiTieuLuong1.Text = LuongDongBHThangLienKe.ToString("n0");
                break;
            case 20:
            case 21:
            case 22:
                txtChiTieuLuong1.FieldLabel = "Lương tối thiểu chung";
                txtChiTieuLuong1.Text = LuongToiThieuChung.ToString("n0");
                break;
            case 26:
            case 27:
            case 28:
            case 29:
            case 75:
                txtChiTieuLuong1.FieldLabel = "Lương đóng BH bình quân 6 tháng";
                txtChiTieuLuong1.Text = LuongBHBQ6Thang.ToString("n0");
                break;
        }
    }
    [DirectMethod]// kiểm tra thời gian đóng bảo hiểm có đủ không
    public void cbbDieuKienHuong1_Selected()
    {
        DAL.BHBANGTINHCHEDOBAOHIEM dongbangtinh = new BangTinhCheDoBaoHiemController().GetByPrKey(int.Parse("0" + hdfDieuKienHuong.Text));
        if (((decimal)ThoiGianDongBHXH) < dongbangtinh.DKThoiGianDongBH)
        {
            txtThoiGianDong1.StyleSpec = "color:red";
            Dialog.ShowNotification("Nhân viên chưa đủ thời gian đóng để hưởng chế độ BH này");
        }
        else
        {
            txtThoiGianDong1.StyleSpec = "color:black";
        }
    }

    //hàm xử lý sau khi ng dùng chọn ngày bắt đầu và ngày kết thúc
    [DirectMethod]
    public void TuDongTinhNgayTien()
    {
        SoNgayNghi = (dfNgayKetThuc1.SelectedDate - dfNgayBatDau1.SelectedDate).Days + 1;
        txtSoNgayNghi1.Text = SoNgayNghi.ToString();
        DAL.BHBANGTINHCHEDOBAOHIEM btcdbh = new BangTinhCheDoBaoHiemController().GetByPrKey(int.Parse("0" + hdfDieuKienHuong.Text));

        if (SoNgayNghi + int.Parse(txtLuyKe1.Text) > btcdbh.DKThoiGianToiDaHuongCheDo)
        {
            txtSoNgayNghi1.StyleSpec = "color:red";
            Dialog.ShowNotification("Nhân viên có thời gian nghỉ lớn hơn thời gian cho phép");
        }
        else
        {
            txtSoNgayNghi1.StyleSpec = "color:black";
        }
        int congchuan = 24;// int.Parse("0" + new HeThongController().GetValueByName("CONG_CHUAN", Session["MaDonVi"].ToString()));
        //if (congchuan == 0) DateTime.DaysInMonth(dfNgayBatDau1.SelectedDate.Year, dfNgayBatDau1.SelectedDate.Month);
        string congthucdathay = "";
        new BHCHEDOBAOHIEMController().TinhChiTieu(dfNgayBatDau1.SelectedDate, int.Parse("0" + hdfIDNhanVienBaoHiem.Text), out LuongDongBHThangLienKe, out LuongToiThieuChung, out LuongBHBQ6Thang);
        switch (int.Parse(cbbCheDo1.Value.ToString()))
        {
            case 23:
            case 24:
            case 76:
                txtChiTieuLuong1.FieldLabel = "Lương đóng BH tháng liền kề";
                txtChiTieuLuong1.Text = LuongDongBHThangLienKe.ToString("n0");
                break;
            case 20:
            case 21:
            case 22:
                txtChiTieuLuong1.FieldLabel = "Lương tối thiểu chung";
                txtChiTieuLuong1.Text = LuongToiThieuChung.ToString("n0");
                break;
            case 26:
            case 27:
            case 28:
            case 29:
            case 75:
                txtChiTieuLuong1.FieldLabel = "Lương đóng BH bình quân 6 tháng";
                txtChiTieuLuong1.Text = LuongBHBQ6Thang.ToString("n0");
                break;
        }

        decimal sotien = new BHCHEDOBAOHIEMController().XuLyCongThuc(btcdbh.CongThuc, LuongToiThieuChung, LuongDongBHThangLienKe, LuongBHBQ6Thang, SoNgayNghi, congchuan, out congthucdathay);
        txtSoTienDeNghi1.Text = ((long)sotien / 1000 * 1000).ToString("0");
        tipSoTienDeNghi.Html = btcdbh.CongThuc + "\n =" + congthucdathay;
    }
    [DirectMethod]
    public void XoaDongNhanVienCheDo(int idnhanvienchedo)
    {
        DAL.BHCHITIETCHEDOBAOHIEM bdbh = new CheDoBaoHiemController().GetChiTietCheDoBaoHiemByID(idnhanvienchedo);
        new CheDoBaoHiemController().DeleteChiTietCheDoBaoHiem(bdbh);
        //Dialog.ShowNotification("Đã xóa thành công");
        grpChiTietNhanVien.Reload();
        grpNhanVienCheDo.Reload();
    }
}