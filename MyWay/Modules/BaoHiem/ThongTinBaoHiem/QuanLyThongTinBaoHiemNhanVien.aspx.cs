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

public partial class Modules_BaoHiem_QuanLyThongTinBaoHiemNhanVien : SoftCore.Security.WebBase
{
    BaoHiemController bhc = new BaoHiemController();
    SoftCore.Util util = new SoftCore.Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; grpQuanLyThongTinBaoHiem_store.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);

        }
        ucChooseEmployee1.AfterClickAcceptButton += ucChooseEmployee1_AfterClickAcceptButton;
    }
    [DirectMethod]
    public void GetThongTinMoi()
    {
        ReportFilter rp = new ReportFilter();
        // lấy thông tin cũ
        // lấy thông tin  mới
        //Đức Anh dùng where fild để truyền dữ liệu vào báo cáo

        string str = "";
        str += txtHoTenMoi.Text + ",";
        str += nfNgayMoi.Text + ",";
        str += nfThangMoi.Text + ",";
        str += nfNamMoi.Text + ",";
        str += cbbGioiTinhMoi.Text + ",";
        str += txtSoCMNDMoi.Text + ",";
        str += nfNgayCapMoi.Text + ",";
        str += nfThangCapMoi.Text + ",";
        str += nfNamCapMoi.Text + ",";
        str += cbbNoiCapCMNDMoi.Text + ",";
        str += txtDiaChiMoi.Text + ",";
        str += txtNoiDangKyKCBMoi.Text + ",";
        str += txtNoiDungThayDoi.Text + ",";
        str += hdfIDNhanVienBaoHiem.Text;
        rp.WhereClause = str;

        Session.Add("rp", rp);
    }
    //sự kiện sau khi ấn nút click trên thêm
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        QuanLyThongTinBaoHiemController qlc = new QuanLyThongTinBaoHiemController();
        SelectedRowCollection sm = ucChooseEmployee1.SelectedRow;
        foreach (HOSO hs in sm.Select(item => new HoSoController().GetByMaCB(item.RecordID)))
        {
            txtMaCanBo.Text = hs.MA_CB;
            txtSoCMND.Text = hs.SO_CMND;
            dfNgaySinh.Value = hs.NGAY_SINH;
            txtGioiTinh.Text = hs.MA_GIOITINH == "F" ? "Nữ" : "Nam";
            txtHoTen.Text = hs.HO_TEN;
            if (!string.IsNullOrEmpty(hs.MA_CHUCVU))
                txtChucVu.Text = hs.DM_CHUCVU.TEN_CHUCVU;
            if (!string.IsNullOrEmpty(hs.MA_NOICAP_CMND))
                txtNoiCapCMND.Text = hs.DM_NOICAP_CMND.TEN_NOICAP_CMND;
            txtDiaChi.Text = hs.DIA_CHI_LH;

            string soquyetdinh, tenquyetdinh;
            DateTime? ngayky, Ngayhieuluc, Hethieuluc;
            decimal? luongbaohiem, phucapcv, phucaptnn, phucaptnvk, phucapkhac;
            new BaoHiemController().TTQuyetDinhLuongMoiNhat(int.Parse(hs.PR_KEY.ToString()), out soquyetdinh, out tenquyetdinh, out ngayky, out Ngayhieuluc, out Hethieuluc,
                out luongbaohiem, out phucapcv, out phucaptnn, out phucaptnvk, out phucapkhac);

            nfLuongBaoHiem.Value = qlc.GetLuongDongBaoHiem(hs.PR_KEY);
            hdfPhuCap.Text = phucapcv.ToString() + ";" + phucaptnn.ToString() + ";" + phucaptnvk.ToString() + ";" + phucapkhac.ToString();
            nfTongPhuCap.Value = phucapcv + phucaptnn + phucaptnvk + phucapkhac;

            txtSoTheBHYT.Text = hs.SOTHE_BHYT;
            if (!string.IsNullOrEmpty(hs.SOTHE_BHXH))
            {
                cbbTrangThaiCapThe.SetValue("ChuaCapThe");
                hdfTrangThaiCapThe.SetValue("ChuaCapThe");
            }
            else
            {
                cbbTrangThaiCapThe.SetValue("DaCapThe");
                hdfTrangThaiCapThe.SetValue("DaCapThe");
            }
            ddfNoiDangKyKhamChuaBenh.Text = !string.IsNullOrEmpty(hs.MA_NOI_KCB) ? hs.DM_NOI_KCB.TEN_NOI_KCB : "";
            if (!util.IsDateNull(hs.NGAY_DONGBH))
            {
                cbbTuThangBHYT.Value = hs.NGAY_DONGBH.Value.Month;
                spinTuNamBHYT.Value = hs.NGAY_DONGBH.Value.Year;
            }
            if (!util.IsDateNull(hs.NGAY_HETHAN_BHYT))
            {
                cbbDenThangBHYT.Value = hs.NGAY_HETHAN_BHYT.Value.Month;
                spinDenNamBHYT.Value = hs.NGAY_HETHAN_BHYT.Value.Year;
            }
            if (!string.IsNullOrEmpty(hs.MA_NOICAP_BHXH))
                txtNoiCapSoBHXH.Text = hs.DM_NOICAP_BHXH.TEN_NOICAP_BHXH;

            if (!util.IsDateNull(hs.NGAY_DONGBH))
                txtSoSoBHXH.Text = hs.SOTHE_BHXH;

            cbbTrangthaiCapSo.SetValue(string.IsNullOrEmpty(hs.SOTHE_BHXH) ? "ChuaCapSo" : "DaCapSo");
            hdfTrangThaiCapSo.SetValue(string.IsNullOrEmpty(hs.SOTHE_BHXH) ? "ChuaCapSo" : "DaCapSo");
            if (!util.IsDateNull(hs.NGAYCAP_BHXH))
                dfNgayCapSo.SelectedDate = (DateTime)hs.NGAYCAP_BHXH;

            bool bhxh, bhyt, bhtn;
            string tenloaihdong;

            qlc.GetHoSoHopDong(hs.PR_KEY, out bhxh, out bhyt, out bhtn, out tenloaihdong);
            txtLoaiHopDong.Text = tenloaihdong;
            nfSoThangDongTruocThem.Text = "0";
            nfSoNamDongTruocThem.Text = "0";

            chkBHXH.Checked = bhxh;
            chkBHYT.Checked = bhyt;
            chkBHTN.Checked = bhtn;
            if (bhxh == false)
            {
                RM.RegisterClientScriptBlock("rel1", "setDisableBHXH();");
            }
            else
            {
                RM.RegisterClientScriptBlock("rel2", "setEnableBHXH();");
            }
            if (bhyt == false)
            {
                RM.RegisterClientScriptBlock("rel3", "setDisableBHYT();");
            }
            else
            {
                RM.RegisterClientScriptBlock("rel4", "setEnableBHYT();");
            }
        }
    }
    //lưu nhân viên đóng mới
    public void btnLuuThem_Click(object sender, DirectEventArgs e)
    {
        //Kiểm tra nhân viên này đã được lưu ở trên bảng BHNhanVien_BaoHiem chưa
        NhanVien_BaoHiemController nbc = new NhanVien_BaoHiemController();
        if (new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(txtMaCanBo.Text) != null)
        {
            RM.RegisterClientScriptBlock("relTrungCanBo", " alert('Cán bộ này đã được quản lý ở phân hệ bảo hiểm');");
            return;
        }
        if (nfSoThangDongTruocThem.Text == "")
            RM.RegisterClientScriptBlock("relChuaNhapThoiGian", " alert('Bạn chưa nhập thời gian đóng trước khi vào công ty cho cán bộ này');");
        // Lưu thông tin vào bảng bhNhanVien_BaoHiem
        NhanVien_BaoHiemController nvc = new NhanVien_BaoHiemController();
        HoSoController hsc = new HoSoController();
        DAL.HOSO hoso = hsc.GetByMaCB(txtMaCanBo.Text);

        DAL.BHNHANVIEN_BAOHIEM nvbh = new DAL.BHNHANVIEN_BAOHIEM();
        nvbh.IDNhanVien_BaoHiem = int.Parse(hoso.PR_KEY.ToString());
        nvbh.MaNhanVien = hoso.MA_CB;
        nvbh.HoTen = hoso.HO_TEN;
        nvbh.Ten = new CommonUtil().GetFirstNamFromFullName(hoso.HO_TEN);
        nvbh.GioiTinh = hoso.MA_GIOITINH != "F";
        nvbh.NgaySinh = hoso.NGAY_SINH;
        nvbh.HoKhauThuongTruTamTru = hoso.HO_KHAU;
        nvbh.DiaChiLienHe = hoso.DIA_CHI_LH;
        nvbh.SoCMTND = hoso.SO_CMND;
        nvbh.NgayCapCMTND = new SoftCore.Util().IsDateNull(hoso.NGAYCAP_CMND) ? null : hoso.NGAYCAP_CMND;
        nvbh.NoiCapCMTND = hoso.MA_NOICAP_CMND ?? "";
        nvbh.MaChucVu = hoso.MA_CHUCVU;
        nvbh.LuongBaoHiem = decimal.Parse(nfLuongBaoHiem.Value.ToString());
        nvbh.LoaiBHYT = "";

        string[] arr = hdfPhuCap.Text.Split(';');
        nvbh.PhuCapCV = int.Parse(arr[0]);
        nvbh.PhuCapKhac = int.Parse(arr[3]);
        nvbh.PhuCapTNVK = int.Parse(arr[2]);
        nvbh.PhuCapTNN = int.Parse(arr[1]);
        // hdfPhuCap.Text = phucapcv.ToString() + ";" + phucaptnn.ToString() + ";" + phucaptnvk.ToString() + ";" + phucapkhac.ToString();
        nvbh.NoiDangKyKCB = hoso.MA_NOI_KCB;
        nvbh.SoTheBHYT = txtSoTheBHYT.Text;
        nvbh.TuThangBHYT = new BaoHiemController().SetValueDatetime(spinTuNamBHYT, cbbTuThangBHYT, 1);
        nvbh.DenThangBHYT = new BaoHiemController().SetValueDatetime(spinDenNamBHYT, cbbDenThangBHYT, 1);
        nvbh.BHXHTrangThaiDangKyCQBH = chkTrangThaiDangKy.Checked;
        nvbh.NgayDangKyBHXH = new BaoHiemController().SetValueDatetime(spinNamBHXH, cbbThangBHXH, 1);
        //nvbh.TrangThaiCapSoBHXH = cbbTrangthaiCapSo.SelectedItem.Value ?? "ChuaCapSo";
        nvbh.TrangThaiCapSoBHXH = hdfTrangThaiCapSo.Text;
        //nvbh.TrangThaiCapTheBHYT = cbbTrangThaiCapThe.SelectedItem.Value ?? "ChuaCapThe";
        nvbh.TrangThaiCapTheBHYT = hdfTrangThaiCapThe.Text;
        nvbh.NoiCapSoBHXH = txtNoiCapSoBHXH.Text;
        nvbh.SoSoBHXH = txtSoSoBHXH.Text;
        if (!util.IsDateNull(dfNgayCapSo.SelectedDate))
            nvbh.NgayCapSoBHXH = dfNgayCapSo.SelectedDate;
        nvbh.DangDongBHXH = chkBHXH.Checked;
        nvbh.DangDongBHYT = chkBHYT.Checked;
        nvbh.DangDongBHTN = chkBHTN.Checked;

        nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy = int.Parse(nfSoThangDongTruocThem.Text == "" ? "0" : nfSoThangDongTruocThem.Text) + int.Parse(nfSoNamDongTruocThem.Text == "" ? "0" : nfSoNamDongTruocThem.Text) * 12;
        //nvbh.ThoiGianDongBaoHiem = nvc.TinhSoThangDongBaoHiem(nvbh.IDNhanVien_BaoHiem, nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy);
        nvbh.ThoiGianDongBaoHiem = nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy;
        nvbh.MaDonVi = Session["MaDonVi"].ToString();
        nvbh.UserID = CurrentUser.ID;
        nvbh.DateCreate = DateTime.Now;

        QuanLyThongTinBaoHiemController qlc = new QuanLyThongTinBaoHiemController();
        qlc.LuuNhanVienDongMoi(nvbh);
        Dialog.ShowNotification("Cập nhật dữ liệu thành công");

        if (e.ExtraParams["Close"] == "True")
        {
            wdThongTinDongBHNhanVien.Hide();

            RM.RegisterClientScriptBlock("rs30", "grpQuanLyThongTinBaoHiem_store.reload();");
        }
        else
        {
            RM.RegisterClientScriptBlock("rs32", "grpQuanLyThongTinBaoHiem_store.reload();");
        }
        RM.RegisterClientScriptBlock("rs31", "resetFormThem();");

    }
    [DirectMethod] // sự kiện khi nháy vào nút sửa hoặc dbclick
    public void SuaThongTinNhanVien(string manhanvien)
    {
        TabPanel1.ActiveTab = pnlThongTinChung;
        DAL.BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(manhanvien);
        DAL.HOSO hoso = new HoSoController().GetByMaCB(manhanvien);
        txtHoTenCu.Text = nvbh.HoTen;
        if (nvbh.NgaySinh != null && !nvbh.NgaySinh.ToString().Contains("0001"))
        {
            nfNgayCu.Value = DateTime.Parse(nvbh.NgaySinh.ToString()).Day;
            nfThangCu.Value = DateTime.Parse(nvbh.NgaySinh.ToString()).Month;
            nfNamCu.Value = DateTime.Parse(nvbh.NgaySinh.ToString()).Year;
        }
        cbbGioiTinhCu.Value = nvbh.GioiTinh == false ? 0 : 1;
        txtSoCMNDCu.Text = hoso.SO_CMND;
        cbbNoiCapCMNDCu.Text = new DM_NOICAP_CMNDController().GetTenByMa(nvbh.NoiCapCMTND);
        // txtSoCMNDCu.Text = nvbh.SoCMTND;
        if (nvbh.NgayCapCMTND != null && !nvbh.NgayCapCMTND.ToString().Contains("0001"))
        {
            nfNgayCapCu.Value = DateTime.Parse(nvbh.NgayCapCMTND.ToString()).Day;
            nfThangCapCu.Value = DateTime.Parse(nvbh.NgayCapCMTND.ToString()).Month;
            nfNamCapCu.Value = DateTime.Parse(nvbh.NgayCapCMTND.ToString()).Year;
        }
        txtDiaChiCu.Text = nvbh.DiaChiLienHe;
        txtNoiDangKyKCBCu.Text = new DM_NOI_KCBController().GetTenByMa(nvbh.NoiDangKyKCB);


        if (nvbh.HoTen != hoso.HO_TEN) txtHoTenMoi.Text = hoso.HO_TEN;
        if (nvbh.NgaySinh != hoso.NGAY_SINH)
            if (hoso.NGAY_SINH != null && !hoso.NGAY_SINH.ToString().Contains("0001"))
            {
                nfNgayMoi.Value = DateTime.Parse(hoso.NGAY_SINH.ToString()).Day;
                nfThangMoi.Value = DateTime.Parse(hoso.NGAY_SINH.ToString()).Month;
                nfNamMoi.Value = DateTime.Parse(hoso.NGAY_SINH.ToString()).Year;
            }
        if (nvbh.GioiTinh != (hoso.MA_GIOITINH != "F")) cbbGioiTinhMoi.Value = (hoso.MA_GIOITINH != "F");
        if (nvbh.SoCMTND != hoso.SO_CMND) txtSoCMNDMoi.Text = nvbh.SoCMTND;
        if (nvbh.NgayCapCMTND != hoso.NGAYCAP_CMND)
        {
            if (hoso.NGAYCAP_CMND != null && !hoso.NGAYCAP_CMND.ToString().Contains("0001"))
            {
                nfNgayCapMoi.Value = DateTime.Parse(hoso.NGAYCAP_CMND.ToString()).Day;
                nfThangCapMoi.Value = DateTime.Parse(hoso.NGAYCAP_CMND.ToString()).Month;
                nfNamCapMoi.Value = DateTime.Parse(hoso.NGAYCAP_CMND.ToString()).Year;
            }
        }
        if (hoso.MA_NOICAP_CMND != null)
            if (nvbh.NoiCapCMTND != hoso.MA_NOICAP_CMND)
                cbbNoiCapCMNDMoi.Value = hoso.MA_NOICAP_CMND;
        if (nvbh.DiaChiLienHe != hoso.DIA_CHI_LH) txtDiaChiMoi.Text = hoso.DIA_CHI_LH;

        if (nvbh.NoiDangKyKCB != hoso.MA_NOI_KCB)
        {
            txtNoiDangKyKCBMoi.Text = new DM_NOI_KCBController().GetTenByMa(hoso.MA_NOI_KCB);
            txtNoiDangKyKCBMoi.SelectedItem.Value = hoso.MA_NOI_KCB;
        }
        //txtNoiDangKyKCBMoi.Value = hoso.MA_NOI_KCB;

        txtLuongBaoHiemSua.Text = nvbh.LuongBaoHiem.ToString();
        txtPhuCapCVSua.Text = nvbh.PhuCapCV.ToString();
        txtPhuCapKhacSua.Text = nvbh.PhuCapKhac.ToString();
        txtPhuCapTNNgheSua.Text = nvbh.PhuCapTNN.ToString();
        txtPhuCapTNVKSua.Text = nvbh.PhuCapTNVK.ToString();

        txtSoTheBHYTSua.Text = nvbh.SoTheBHYT;


        if (!Util.GetInstance().IsDateNull(nvbh.TuThangBHYT))
        {
            cbbTuThangBHYTSua.Value = nvbh.TuThangBHYT.Value.Month;
            spinTuNamBHYTSua.Value = nvbh.TuThangBHYT.Value.Year;
        }
        if (!Util.GetInstance().IsDateNull(nvbh.DenThangBHYT))
        {
            cbbDenThangBHYTSua.Value = nvbh.DenThangBHYT.Value.Month;
            spinDenNamBHYTSua.Value = nvbh.DenThangBHYT.Value.Year;
        }
        chkDaDangKyCQBHSua.Checked = bool.Parse(nvbh.BHXHTrangThaiDangKyCQBH.ToString());
        if (nvbh.NgayDangKyBHXH != null && !nvbh.NgayDangKyBHXH.ToString().Contains("0001"))
        {
            cbbThangDangKyBHXHSua.Value = nvbh.NgayDangKyBHXH.Value.Month;
            spinNamDangKyBHXHSua.Value = nvbh.NgayDangKyBHXH.Value.Year;
        }
        if (!string.IsNullOrEmpty(nvbh.TrangThaiCapSoBHXH))
        {
            cbbTrangThaiCapSoSua.Value = nvbh.TrangThaiCapSoBHXH;
            hdfTrangThaiCapSoSua.SetValue(nvbh.TrangThaiCapSoBHXH);
        }
        if (!string.IsNullOrEmpty(nvbh.TrangThaiCapTheBHYT))
        {
            cboTrangThaiCapThe.Value = nvbh.TrangThaiCapTheBHYT;
            hdfTrangThaiCapThe.SetValue(nvbh.TrangThaiCapTheBHYT);
        }
        else
        {
            hdfTrangThaiCapThe.SetValue("ChuaCapThe");
        }
        //txtNoiCapSoBHXHSua.Text = nvbh.NoiCapSoBHXH;
        if (!string.IsNullOrEmpty(nvbh.NoiCapSoBHXH))
        {
            hdfNoiCapSoBHXHSua.Text = nvbh.NoiCapSoBHXH;
            txtNoiCapSoBHXHSua.Text = new DM_NOICAPBAOHIEMXHController().GetTenByMa(nvbh.NoiCapSoBHXH);
        }
        if (!string.IsNullOrEmpty(nvbh.SoSoBHXH))
        {
            txtSoSoBHXHSua.Text = nvbh.SoSoBHXH;
        }
        if (nvbh.NgayCapSoBHXH != null && !nvbh.NgayCapSoBHXH.ToString().Contains("0001"))
        {
            dfNgayCapSoBHXHSua.SetValue(nvbh.NgayCapSoBHXH);
        }

        chkDongBHXH.Checked = nvbh.DangDongBHXH;
        chkDongBHYT.Checked = nvbh.DangDongBHYT;
        chkDongBHTN.Checked = nvbh.DangDongBHTN;

        nfSoThangDongTruocSua.Text = (nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy % 12).ToString();
        nfSoNamDongTruocSua.Text = (nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy / 12).ToString();
        RM.RegisterClientScriptBlock("rsSinhNoiDung", "SinhNoiDung();");
        wdThayDoiThongTin.Show();
    }

    //sự kiện nhấn nút lưu sửa
    public void btnSuaThongTin_Click(object sender, DirectEventArgs e)
    {
        NhanVien_BaoHiemController nvc = new NhanVien_BaoHiemController();
        DAL.BHNHANVIEN_BAOHIEM nvbh = nvc.GetNhanVien_BaoHiemByMaNhanVien(hdfIDNhanVienBaoHiem.Text);

        if (txtHoTenMoi.Text != "")
        {
            nvbh.HoTen = txtHoTenMoi.Text;
            nvbh.Ten = new CommonUtil().GetFirstNamFromFullName(txtHoTenMoi.Text);
        }

        if (!string.IsNullOrEmpty(nfNgayMoi.Text) && !string.IsNullOrEmpty(nfThangMoi.Text) && !string.IsNullOrEmpty(nfNamMoi.Text))
            nvbh.NgaySinh = new DateTime(int.Parse(nfNamMoi.Text), int.Parse(nfThangMoi.Text), int.Parse(nfNgayMoi.Text));
        if (cbbGioiTinhMoi.SelectedIndex > -1)
            nvbh.GioiTinh = cbbGioiTinhMoi.Value.ToString() != "0";
        if (!string.IsNullOrEmpty(txtSoCMNDMoi.Text))
            nvbh.SoCMTND = txtSoCMNDMoi.Text;
        if (!string.IsNullOrEmpty(nfNgayCapMoi.Text) && !string.IsNullOrEmpty(nfThangCapMoi.Text) && !string.IsNullOrEmpty(nfNamCapMoi.Text))
            nvbh.NgayCapCMTND = new DateTime(int.Parse(nfNamCapMoi.Text), int.Parse(nfThangCapMoi.Text), int.Parse(nfNgayCapMoi.Text));
        if (cbbNoiCapCMNDMoi.SelectedIndex > -1)
            nvbh.NoiCapCMTND = cbbNoiCapCMNDMoi.Value.ToString();
        if (!string.IsNullOrEmpty(txtDiaChiMoi.Text))
            nvbh.DiaChiLienHe = txtDiaChiMoi.Text;
        nvbh.NoiDangKyKCB = txtNoiDangKyKCBMoi.Value == null ? "" : txtNoiDangKyKCBMoi.Value.ToString();
        nvbh.SoTheBHYT = txtSoTheBHYTSua.Text;
        nvbh.TuThangBHYT = bhc.SetValueDatetime(spinTuNamBHYTSua, cbbTuThangBHYTSua, 1);
        nvbh.DenThangBHYT = bhc.SetValueDatetime(spinDenNamBHYTSua, cbbDenThangBHYTSua, 1);
        nvbh.BHXHTrangThaiDangKyCQBH = chkDaDangKyCQBHSua.Checked;
        nvbh.NgayDangKyBHXH = bhc.SetValueDatetime(spinNamDangKyBHXHSua, cbbThangDangKyBHXHSua, 1);
        nvbh.DangDongBHXH = chkDongBHXH.Checked;
        nvbh.DangDongBHYT = chkDongBHYT.Checked;
        nvbh.DangDongBHTN = chkDongBHTN.Checked;

        //nvbh.TrangThaiCapSoBHXH = cbbTrangThaiCapSoSua.SelectedItem.Value;
        nvbh.TrangThaiCapSoBHXH = hdfTrangThaiCapSoSua.Text;
        //nvbh.TrangThaiCapTheBHYT = cboTrangThaiCapThe.SelectedItem.Value;
        nvbh.TrangThaiCapTheBHYT = hdfTrangThaiCapThe.Text;
        nvbh.NoiCapSoBHXH = hdfNoiCapSoBHXHSua.Text;
        nvbh.SoSoBHXH = txtSoSoBHXHSua.Text;


        if (!string.IsNullOrEmpty(txtLuongBaoHiemSua.Text))
        {
            nvbh.LuongBaoHiem = decimal.Parse(txtLuongBaoHiemSua.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapCVSua.Text))
        {
            nvbh.PhuCapCV = decimal.Parse(txtPhuCapCVSua.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapKhacSua.Text))
        {
            nvbh.PhuCapKhac = decimal.Parse(txtPhuCapKhacSua.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapTNNgheSua.Text))
        {
            nvbh.PhuCapTNN = decimal.Parse(txtPhuCapTNNgheSua.Text);
        }
        if (!string.IsNullOrEmpty(txtPhuCapTNVKSua.Text))
        {
            nvbh.PhuCapTNVK = decimal.Parse(txtPhuCapTNVKSua.Text);
        }

        //if (dfNgayCapSoBHXHSua.Value != null && !dfNgayCapSoBHXHSua.SelectedDate.ToString().Contains("0001"))
        //    nvbh.NgayCapSoBHXH = dfNgayCapSoBHXHSua.SelectedDate;
        if (!Util.GetInstance().IsDateNull(dfNgayCapSoBHXHSua.SelectedDate))
            nvbh.NgayCapSoBHXH = dfNgayCapSoBHXHSua.SelectedDate;
        int thangold = nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy;
        nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy = int.Parse(nfSoThangDongTruocSua.Text == "" ? "0" : nfSoThangDongTruocSua.Text) + int.Parse(nfSoNamDongTruocSua.Text == "" ? "0" : nfSoNamDongTruocSua.Text) * 12;
        nvbh.ThoiGianDongBaoHiem = (nvbh.ThoiGianDongBaoHiem - thangold) + nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy;

        nvc.UpdateNhanVien_BaoHiem(nvbh);

        #region update ngược lại bảng hồ sơ
        var hsc = new HoSoController();
        DAL.HOSO hoso = hsc.GetByMaCB(hdfIDNhanVienBaoHiem.Text);
        if (!string.IsNullOrEmpty(txtHoTenMoi.Text))
        {
            hoso.HO_TEN = txtHoTenMoi.Text;
            hoso.TEN_CB = new CommonUtil().GetFirstNamFromFullName(txtHoTenMoi.Text);
        }
        else hoso.HO_TEN = txtHoTenCu.Text;
        if (!string.IsNullOrEmpty(nfNgayMoi.Text) && !string.IsNullOrEmpty(nfThangMoi.Text) && !string.IsNullOrEmpty(nfNamMoi.Text))
            hoso.NGAY_SINH = new DateTime(int.Parse(nfNamMoi.Text), int.Parse(nfThangMoi.Text), int.Parse(nfNgayMoi.Text));
        else if (!string.IsNullOrEmpty(nfNgayCu.Text) && !string.IsNullOrEmpty(nfThangCu.Text) && !string.IsNullOrEmpty(nfNamCu.Text))
            hoso.NGAY_SINH = new DateTime(int.Parse(nfNamCu.Text), int.Parse(nfThangCu.Text), int.Parse(nfNgayCu.Text));
        if (cbbGioiTinhMoi.SelectedIndex > -1)
            hoso.MA_GIOITINH = cbbGioiTinhMoi.Value.ToString() == "0" ? "F" : "M";
        else hoso.MA_GIOITINH = cbbGioiTinhCu.Value.ToString() == "0" ? "F" : "M";
        if (!string.IsNullOrEmpty(txtSoCMNDMoi.Text))
            hoso.SO_CMND = txtSoCMNDMoi.Text;
        else hoso.SO_CMND = txtSoCMNDCu.Text;
        if (!string.IsNullOrEmpty(nfNgayCapMoi.Text) && !string.IsNullOrEmpty(nfThangCapMoi.Text) && !string.IsNullOrEmpty(nfNamCapMoi.Text))
            hoso.NGAYCAP_CMND = new DateTime(int.Parse(nfNamCapMoi.Text), int.Parse(nfThangCapMoi.Text), int.Parse(nfNgayCapMoi.Text));
        else if (!string.IsNullOrEmpty(nfNgayCapCu.Text) && !string.IsNullOrEmpty(nfThangCapCu.Text) && !string.IsNullOrEmpty(nfNamCapCu.Text))
            hoso.NGAYCAP_CMND = new DateTime(int.Parse(nfNamCapCu.Text), int.Parse(nfThangCapCu.Text), int.Parse(nfNgayCapCu.Text));
        if (cbbNoiCapCMNDMoi.SelectedIndex > -1)
            hoso.MA_NOICAP_CMND = cbbNoiCapCMNDMoi.Value.ToString();
        if (!string.IsNullOrEmpty(txtDiaChiMoi.Text))
            hoso.DIA_CHI_LH = txtDiaChiMoi.Text;
        else hoso.DIA_CHI_LH = txtDiaChiCu.Text;
        if (!string.IsNullOrEmpty(hdfNoiDungKyKCBMoi.Text))
            hoso.MA_NOI_KCB = hdfNoiDungKyKCBMoi.Text;
        if (!string.IsNullOrEmpty(txtSoTheBHYTSua.Text))
            hoso.SOTHE_BHYT = txtSoTheBHYTSua.Text;
        if (cbbTuThangBHYTSua.SelectedIndex > -1 && !string.IsNullOrEmpty(spinTuNamBHYTSua.Value.ToString()))
            hoso.NGAY_DONGBH = new DateTime(int.Parse(spinTuNamBHYTSua.Text), int.Parse(cbbTuThangBHYTSua.Value.ToString()), 1);
        if (cbbDenThangBHYTSua.SelectedIndex > -1 && !string.IsNullOrEmpty(spinDenNamBHYTSua.Value.ToString()))
            hoso.NGAY_HETHAN_BHYT = new DateTime(int.Parse(spinDenNamBHYTSua.Text), int.Parse(cbbDenThangBHYTSua.Value.ToString()), 1);
        //nvbh.NoiCapSoBHXH = txtNoiCapSoBHXHSua.Text;
        if (!string.IsNullOrEmpty(txtSoSoBHXHSua.Text))
            hoso.SOTHE_BHXH = txtSoSoBHXHSua.Text;
        hsc.UpDateHoSoBaoHiem(hoso);
        #endregion
        grpQuanLyThongTinBaoHiem.Reload();
        wdThayDoiThongTin.Hide();
    }
    public void btnXoa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            NhanVien_BaoHiemController control = new NhanVien_BaoHiemController();
            SelectedRowCollection SelectedRows = checkboxSelection.SelectedRows;
            foreach (var item in SelectedRows)
            {
                control.DeleteNhanVienBH(item.RecordID);
            }
            grpQuanLyThongTinBaoHiem.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void cbx_noikcb_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noikcb_Store.DataSource = new DM_NOI_KCBController().GetAll();
        cbx_noikcb_Store.DataBind();
    }
    protected void cbx_noicapbhxh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicapbhxh_Store.DataSource = new DM_NOICAPBAOHIEMXHController().GetAll();
        cbx_noicapbhxh_Store.DataBind();
    }

    protected void txtNoiCapSoBHXHSua_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        Store1.DataSource = new DM_NOICAPBAOHIEMXHController().GetAll();
        Store1.DataBind();
    }
}