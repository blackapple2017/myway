using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataController;

/// <summary>
/// Summary description for rpwg_BangTongHopCBNVChiNhanh
/// </summary>
public class rpwg_BangTongHopCBNVChiNhanh : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrlNguoiBC2;
    private XRLabel xrlFT2;
    private XRLabel xrlTongGiamDoc;
    private XRLabel xrtngayketxuat;
    private XRLabel xrlFT3;
    private XRLabel xrlTruongPhongHCNS;
    private XRLabel xrLabel1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell grpBoPhan;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell35;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrSTT;
    private XRTableCell xrHoTen;
    private XRTableCell xrDanhSachCon;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell39;
    private XRTableCell xrNgaySinh;
    private XRTableCell xrBaoHanGanHetHDLD;
    private XRTableCell xrThoiHanConLai;
    private XRTableCell xrNgayKetThuc;
    private XRTableCell xrNgayBatDau;
    private XRTableCell xrLanKyHDLD;
    private XRTableCell xrThoiHanHDLD;
    private XRTableCell xrLoaiHDLD;
    private XRTableCell xrNgayCap;
    private XRTableCell xrGioiTinh;
    private XRTableCell xrEmail;
    private XRTableCell xrDiDong;
    private XRTableCell xrNoiCap;
    private XRTableCell xrNgayChinhThuc;
    private XRTableCell xrThuViec;
    private XRTableCell xrHoKhauThuongTru;
    private XRTableCell xrNgayThamGiaBH;
    private XRTableCell xrMaSoThueCN;
    private XRTableCell xrChuyenNganh;
    private XRTableCell xrChucDanh;
    private XRTableCell xrNoiOHienTai;
    private XRTableCell xrNgayVao;
    private XRTableCell xrThamNien;
    private XRTableCell xrTrinhDo;
    private XRTableCell xrTinhTrangNghi;
    private XRTableCell xrNgayNghi;
    private XRTableCell xrTongThuNhap;
    private XRTableCell xrSoSo;
    private XRTableCell xrSoTaiKhoan;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell30;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell28;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTableCell xrTableCell100;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTableCell xrMaNhanVien;
    private XRTableCell xrSoCMT;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrt_songayhocviec;
    private XRPictureBox xrLogo;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_BangTongHopCBNVChiNhanh()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        //BindData();
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrSTT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        try
        {
            xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
            xrtngayketxuat.Text = new ReportController().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
            xrl_TenCongTy.Text = new ReportController().GetCompanyName(filter.SessionDepartment);
            DataSource = DataHandler.GetInstance().ExecuteDataTable("report_GetDanhSachNhanSu", "@MaDonVi", "@WhereClause", "@UserID",
                                                                    "@MenuID", "@SelectedMaDonVi",
                                                                    filter.SessionDepartment, filter.WhereClause, filter.UserID, filter.MenuID, filter.SelectedDepartment);
            //DataSource = DataHandler.GetInstance().ExecuteDataTable("report_GetDanhSachNhanSu", "@MaDonVi", "@WhereClause", filter.SessionDepartment, filter.WhereClause);
            if (!string.IsNullOrEmpty(filter.ReportTitle))
                xrl_TitleBC.Text = filter.ReportTitle;
            xrHoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrNgaySinh.DataBindings.Add("Text", DataSource, "NGAY_SINH");
            xrGioiTinh.DataBindings.Add("Text", DataSource, "GioiTinh");
            xrMaNhanVien.DataBindings.Add("Text", DataSource, "MA_CB");
            xrSoCMT.DataBindings.Add("Text", DataSource, "SO_CMND");
            xrNgayCap.DataBindings.Add("Text", DataSource, "NGAYCAP_CMND");
            xrNoiCap.DataBindings.Add("Text", DataSource, "TEN_NOICAP_CMND");
            xrChucDanh.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
            xrThuViec.DataBindings.Add("Text", DataSource, "ThuViec");
            xrHoKhauThuongTru.DataBindings.Add("Text", DataSource, "HO_KHAU");
            xrNoiOHienTai.DataBindings.Add("Text", DataSource, "Noiohientai");
            xrNgayVao.DataBindings.Add("Text", DataSource, "NgayVao");
            xrt_songayhocviec.DataBindings.Add("Text", DataSource, "SoNgayHocViec");
            xrNgayChinhThuc.DataBindings.Add("Text", DataSource, "NGAY_TUYEN_CHINHTHUC");
            xrThamNien.DataBindings.Add("Text", DataSource, "ThamNien");
            xrTrinhDo.DataBindings.Add("Text", DataSource, "TrinhDo");
            xrChuyenNganh.DataBindings.Add("Text", DataSource, "ChuyenNganh");
            xrTinhTrangNghi.DataBindings.Add("Text", DataSource, "DA_NGHI");
            xrNgayNghi.DataBindings.Add("Text", DataSource, "NGAY_NGHI");
            xrTongThuNhap.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
            xrNgayThamGiaBH.DataBindings.Add("Text", DataSource, "NGAY_DONGBH");
            xrSoSo.DataBindings.Add("Text", DataSource, "SOTHE_BHXH");
            xrMaSoThueCN.DataBindings.Add("Text", DataSource, "MST_CANHAN");
            xrSoTaiKhoan.DataBindings.Add("Text", DataSource, "SO_TAI_KHOAN");
            xrDiDong.DataBindings.Add("Text", DataSource, "DI_DONG");
            xrEmail.DataBindings.Add("Text", DataSource, "EMAIL");

            xrLoaiHDLD.DataBindings.Add("Text", DataSource, "LoaiHDLD");
            xrThoiHanHDLD.DataBindings.Add("Text", DataSource, "ThoiHanHDLD");
            xrLanKyHDLD.DataBindings.Add("Text", DataSource, "LanKyHDLD");
            xrNgayBatDau.DataBindings.Add("Text", DataSource, "NgayBatDau");
            xrNgayKetThuc.DataBindings.Add("Text", DataSource, "NgayKetThuc");
            xrThoiHanConLai.DataBindings.Add("Text", DataSource, "ThoiHanConLai");
            xrBaoHanGanHetHDLD.DataBindings.Add("Text", DataSource, "BaoHanGanHetHDLD");
            xrDanhSachCon.DataBindings.Add("Text", DataSource, "DanhSachCon");

            // Footer
            if (!string.IsNullOrEmpty(filter.Name1))
            {
                xrlNguoiBC2.Text = filter.Name1;
            }
            else
            {
                xrlNguoiBC2.Text = filter.Reporter;
            }
            xrlTruongPhongHCNS.Text = new ReportController().GetHeadOfHRroom(filter.SessionDepartment, filter.Name2);
            xrlTongGiamDoc.Text = new ReportController().GetHeadOfHRroom(filter.SessionDepartment, filter.Name3);  

            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            grpBoPhan.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        }
        catch (Exception ex)
        {
            xrl_TitleBC.Text = ex.Message;
        }
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        string resourceFileName = "rpwg_BangTongHopCBNVChiNhanh.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrSTT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrHoTen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgaySinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrGioiTinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrMaNhanVien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoCMT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayCap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNoiCap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrChucDanh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrThuViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrHoKhauThuongTru = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNoiOHienTai = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayVao = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_songayhocviec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayChinhThuc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrThamNien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTrinhDo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrChuyenNganh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTinhTrangNghi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayNghi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongThuNhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayThamGiaBH = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoSo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrMaSoThueCN = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoTaiKhoan = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrDiDong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrEmail = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLoaiHDLD = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrThoiHanHDLD = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLanKyHDLD = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayBatDau = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayKetThuc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrThoiHanConLai = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrBaoHanGanHetHDLD = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrDanhSachCon = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrlTruongPhongHCNS = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNguoiBC2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlFT2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlTongGiamDoc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlFT3 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.grpBoPhan = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.Detail.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.StylePriority.UseFont = false;
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1623F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UsePadding = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrSTT,
            this.xrHoTen,
            this.xrNgaySinh,
            this.xrGioiTinh,
            this.xrMaNhanVien,
            this.xrSoCMT,
            this.xrNgayCap,
            this.xrNoiCap,
            this.xrChucDanh,
            this.xrThuViec,
            this.xrHoKhauThuongTru,
            this.xrNoiOHienTai,
            this.xrNgayVao,
            this.xrt_songayhocviec,
            this.xrNgayChinhThuc,
            this.xrThamNien,
            this.xrTrinhDo,
            this.xrChuyenNganh,
            this.xrTinhTrangNghi,
            this.xrNgayNghi,
            this.xrTongThuNhap,
            this.xrNgayThamGiaBH,
            this.xrSoSo,
            this.xrMaSoThueCN,
            this.xrSoTaiKhoan,
            this.xrDiDong,
            this.xrEmail,
            this.xrLoaiHDLD,
            this.xrThoiHanHDLD,
            this.xrLanKyHDLD,
            this.xrNgayBatDau,
            this.xrNgayKetThuc,
            this.xrThoiHanConLai,
            this.xrBaoHanGanHetHDLD,
            this.xrDanhSachCon});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrSTT
        // 
        this.xrSTT.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrSTT.Name = "xrSTT";
        this.xrSTT.StylePriority.UseFont = false;
        this.xrSTT.StylePriority.UseTextAlignment = false;
        this.xrSTT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSTT.Weight = 0.029463847331330895D;
        this.xrSTT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrHoTen
        // 
        this.xrHoTen.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrHoTen.Name = "xrHoTen";
        this.xrHoTen.StylePriority.UseFont = false;
        this.xrHoTen.Weight = 0.12924222540723185D;
        // 
        // xrNgaySinh
        // 
        this.xrNgaySinh.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgaySinh.Name = "xrNgaySinh";
        this.xrNgaySinh.StylePriority.UseFont = false;
        this.xrNgaySinh.Weight = 0.065563816680485124D;
        // 
        // xrGioiTinh
        // 
        this.xrGioiTinh.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrGioiTinh.Name = "xrGioiTinh";
        this.xrGioiTinh.StylePriority.UseFont = false;
        this.xrGioiTinh.Weight = 0.046210722209345148D;
        // 
        // xrMaNhanVien
        // 
        this.xrMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrMaNhanVien.Name = "xrMaNhanVien";
        this.xrMaNhanVien.StylePriority.UseFont = false;
        this.xrMaNhanVien.Weight = 0.073512001255743933D;
        // 
        // xrSoCMT
        // 
        this.xrSoCMT.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrSoCMT.Name = "xrSoCMT";
        this.xrSoCMT.StylePriority.UseFont = false;
        this.xrSoCMT.Weight = 0.077634014478452487D;
        // 
        // xrNgayCap
        // 
        this.xrNgayCap.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayCap.Name = "xrNgayCap";
        this.xrNgayCap.StylePriority.UseFont = false;
        this.xrNgayCap.Weight = 0.0655637729134885D;
        // 
        // xrNoiCap
        // 
        this.xrNoiCap.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNoiCap.Name = "xrNoiCap";
        this.xrNoiCap.StylePriority.UseFont = false;
        this.xrNoiCap.Weight = 0.090286603366161039D;
        // 
        // xrChucDanh
        // 
        this.xrChucDanh.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrChucDanh.Name = "xrChucDanh";
        this.xrChucDanh.StylePriority.UseFont = false;
        this.xrChucDanh.Weight = 0.093271706632016477D;
        // 
        // xrThuViec
        // 
        this.xrThuViec.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrThuViec.Name = "xrThuViec";
        this.xrThuViec.StylePriority.UseFont = false;
        this.xrThuViec.Weight = 0.064695009104425438D;
        // 
        // xrHoKhauThuongTru
        // 
        this.xrHoKhauThuongTru.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrHoKhauThuongTru.Name = "xrHoKhauThuongTru";
        this.xrHoKhauThuongTru.StylePriority.UseFont = false;
        this.xrHoKhauThuongTru.Weight = 0.14448538888073659D;
        // 
        // xrNoiOHienTai
        // 
        this.xrNoiOHienTai.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNoiOHienTai.Name = "xrNoiOHienTai";
        this.xrNoiOHienTai.StylePriority.UseFont = false;
        this.xrNoiOHienTai.Weight = 0.2159952438004355D;
        // 
        // xrNgayVao
        // 
        this.xrNgayVao.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayVao.Name = "xrNgayVao";
        this.xrNgayVao.StylePriority.UseFont = false;
        this.xrNgayVao.Weight = 0.065619226269658035D;
        // 
        // xrt_songayhocviec
        // 
        this.xrt_songayhocviec.Name = "xrt_songayhocviec";
        this.xrt_songayhocviec.StylePriority.UseTextAlignment = false;
        this.xrt_songayhocviec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_songayhocviec.Weight = 0.051756008698599809D;
        // 
        // xrNgayChinhThuc
        // 
        this.xrNgayChinhThuc.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayChinhThuc.Name = "xrNgayChinhThuc";
        this.xrNgayChinhThuc.StylePriority.UseFont = false;
        this.xrNgayChinhThuc.Weight = 0.0656192249647736D;
        // 
        // xrThamNien
        // 
        this.xrThamNien.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrThamNien.Name = "xrThamNien";
        this.xrThamNien.StylePriority.UseFont = false;
        this.xrThamNien.Weight = 0.10749514920158435D;
        // 
        // xrTrinhDo
        // 
        this.xrTrinhDo.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrTrinhDo.Name = "xrTrinhDo";
        this.xrTrinhDo.StylePriority.UseFont = false;
        this.xrTrinhDo.Weight = 0.073955654843181839D;
        // 
        // xrChuyenNganh
        // 
        this.xrChuyenNganh.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrChuyenNganh.Name = "xrChuyenNganh";
        this.xrChuyenNganh.StylePriority.UseFont = false;
        this.xrChuyenNganh.Weight = 0.091220142626222522D;
        // 
        // xrTinhTrangNghi
        // 
        this.xrTinhTrangNghi.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrTinhTrangNghi.Name = "xrTinhTrangNghi";
        this.xrTinhTrangNghi.StylePriority.UseFont = false;
        this.xrTinhTrangNghi.Weight = 0.062716984635911D;
        // 
        // xrNgayNghi
        // 
        this.xrNgayNghi.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayNghi.Name = "xrNgayNghi";
        this.xrNgayNghi.StylePriority.UseFont = false;
        this.xrNgayNghi.Weight = 0.0608134692441844D;
        // 
        // xrTongThuNhap
        // 
        this.xrTongThuNhap.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrTongThuNhap.Name = "xrTongThuNhap";
        this.xrTongThuNhap.StylePriority.UseFont = false;
        this.xrTongThuNhap.StylePriority.UseTextAlignment = false;
        this.xrTongThuNhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTongThuNhap.Weight = 0.077929711368713017D;
        // 
        // xrNgayThamGiaBH
        // 
        this.xrNgayThamGiaBH.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayThamGiaBH.Name = "xrNgayThamGiaBH";
        this.xrNgayThamGiaBH.StylePriority.UseFont = false;
        this.xrNgayThamGiaBH.Weight = 0.068410257738283256D;
        // 
        // xrSoSo
        // 
        this.xrSoSo.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrSoSo.Name = "xrSoSo";
        this.xrSoSo.StylePriority.UseFont = false;
        this.xrSoSo.Weight = 0.094085113329609713D;
        // 
        // xrMaSoThueCN
        // 
        this.xrMaSoThueCN.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrMaSoThueCN.Name = "xrMaSoThueCN";
        this.xrMaSoThueCN.StylePriority.UseFont = false;
        this.xrMaSoThueCN.Weight = 0.10452873907060582D;
        // 
        // xrSoTaiKhoan
        // 
        this.xrSoTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrSoTaiKhoan.Name = "xrSoTaiKhoan";
        this.xrSoTaiKhoan.StylePriority.UseFont = false;
        this.xrSoTaiKhoan.Weight = 0.10833654026612773D;
        // 
        // xrDiDong
        // 
        this.xrDiDong.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrDiDong.Name = "xrDiDong";
        this.xrDiDong.StylePriority.UseFont = false;
        this.xrDiDong.Weight = 0.092421439942833181D;
        // 
        // xrEmail
        // 
        this.xrEmail.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrEmail.Name = "xrEmail";
        this.xrEmail.StylePriority.UseFont = false;
        this.xrEmail.Weight = 0.15896468021512689D;
        // 
        // xrLoaiHDLD
        // 
        this.xrLoaiHDLD.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrLoaiHDLD.Name = "xrLoaiHDLD";
        this.xrLoaiHDLD.StylePriority.UseFont = false;
        this.xrLoaiHDLD.Weight = 0.0689112880093333D;
        // 
        // xrThoiHanHDLD
        // 
        this.xrThoiHanHDLD.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrThoiHanHDLD.Name = "xrThoiHanHDLD";
        this.xrThoiHanHDLD.StylePriority.UseFont = false;
        this.xrThoiHanHDLD.Weight = 0.069922166919531972D;
        // 
        // xrLanKyHDLD
        // 
        this.xrLanKyHDLD.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrLanKyHDLD.Name = "xrLanKyHDLD";
        this.xrLanKyHDLD.StylePriority.UseFont = false;
        this.xrLanKyHDLD.Weight = 0.055933234872306684D;
        // 
        // xrNgayBatDau
        // 
        this.xrNgayBatDau.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayBatDau.Name = "xrNgayBatDau";
        this.xrNgayBatDau.StylePriority.UseFont = false;
        this.xrNgayBatDau.Weight = 0.06556346279856469D;
        // 
        // xrNgayKetThuc
        // 
        this.xrNgayKetThuc.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrNgayKetThuc.Name = "xrNgayKetThuc";
        this.xrNgayKetThuc.StylePriority.UseFont = false;
        this.xrNgayKetThuc.Weight = 0.065563942279921489D;
        // 
        // xrThoiHanConLai
        // 
        this.xrThoiHanConLai.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrThoiHanConLai.Name = "xrThoiHanConLai";
        this.xrThoiHanConLai.StylePriority.UseFont = false;
        this.xrThoiHanConLai.Weight = 0.048641522137823863D;
        // 
        // xrBaoHanGanHetHDLD
        // 
        this.xrBaoHanGanHetHDLD.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrBaoHanGanHetHDLD.Name = "xrBaoHanGanHetHDLD";
        this.xrBaoHanGanHetHDLD.StylePriority.UseFont = false;
        this.xrBaoHanGanHetHDLD.Weight = 0.064928262819864718D;
        // 
        // xrDanhSachCon
        // 
        this.xrDanhSachCon.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrDanhSachCon.Name = "xrDanhSachCon";
        this.xrDanhSachCon.StylePriority.UseFont = false;
        this.xrDanhSachCon.Weight = 0.18073942568738466D;
        // 
        // TopMargin
        // 
        this.TopMargin.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.TopMargin.HeightF = 54F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.StylePriority.UseFont = false;
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.BottomMargin.HeightF = 38F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.StylePriority.UseFont = false;
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrPageInfo1.Format = "Trang {0} của {1}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1486.959F, 26.66664F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0414F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLogo,
            this.xrLabel4,
            this.xrLabel3,
            this.xrl_TenCongTy,
            this.xrl_TitleBC,
            this.xrTable1});
        this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.ReportHeader.HeightF = 276F;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.StylePriority.UseFont = false;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1171.958F, 113.5416F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(451.0416F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1171.958F, 138.5416F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(451.0417F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Độc lập - Tự do - Hạnh phúc";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 113.5416F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(592.8951F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN THẾ GIỚI GIẢI TRÍ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 161.5417F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1623F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "DANH SÁCH CÁN BỘ CÔNG NHÂN VIÊN";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 196F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1623F, 80F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell11,
            this.xrTableCell6,
            this.xrTableCell12,
            this.xrTableCell9,
            this.xrTableCell13,
            this.xrTableCell18,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell10,
            this.xrTableCell36,
            this.xrTableCell14,
            this.xrTableCell8,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell3,
            this.xrTableCell7,
            this.xrTableCell15,
            this.xrTableCell24,
            this.xrTableCell27,
            this.xrTableCell35,
            this.xrTableCell39});
        this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.StylePriority.UseFont = false;
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.Text = "TT";
        this.xrTableCell4.Weight = 0.051539403801672316D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.Text = "Họ và Tên";
        this.xrTableCell5.Weight = 0.22607496534413846D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.Text = "Ngày sinh";
        this.xrTableCell1.Weight = 0.1146864904874263D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.Text = "Giới Tính";
        this.xrTableCell2.Weight = 0.080833445573565324D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseFont = false;
        this.xrTableCell11.Text = "Mã nhân viên";
        this.xrTableCell11.Weight = 0.12858983787751133D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseFont = false;
        this.xrTableCell6.Text = "Số CMTND";
        this.xrTableCell6.Weight = 0.13580019082501224D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.Text = "Ngày cấp";
        this.xrTableCell12.Weight = 0.11468649459688178D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseFont = false;
        this.xrTableCell9.Text = "Nơi cấp";
        this.xrTableCell9.Weight = 0.15793240969070538D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.Text = "Chức vụ";
        this.xrTableCell13.Weight = 0.16315420201698944D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell18.Multiline = true;
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseFont = false;
        this.xrTableCell18.Text = "Thử việc, thử vị trí, Học việc, chính thức \r\n\r\n";
        this.xrTableCell18.Weight = 0.1131668200486812D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseFont = false;
        this.xrTableCell16.Text = "Hộ khẩu thường trú";
        this.xrTableCell16.Weight = 0.25273900050547127D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.Text = "Nơi ở hiện tại";
        this.xrTableCell17.Weight = 0.37782638187710521D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseFont = false;
        this.xrTableCell10.Text = "Ngày vào";
        this.xrTableCell10.Weight = 0.11478348962775983D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseFont = false;
        this.xrTableCell36.Text = "Số ngày học việc";
        this.xrTableCell36.Weight = 0.090533452355743685D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseFont = false;
        this.xrTableCell14.Text = "Ngày chính thức";
        this.xrTableCell14.Weight = 0.11478349190479109D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseFont = false;
        this.xrTableCell8.Text = "Thâm niên";
        this.xrTableCell8.Weight = 0.18803491352807028D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseFont = false;
        this.xrTableCell22.Text = "Trình độ học vấn";
        this.xrTableCell22.Weight = 0.129365837520145D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseFont = false;
        this.xrTableCell23.Text = "Chuyên ngành đào tạo";
        this.xrTableCell23.Weight = 0.15956521191252976D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseFont = false;
        this.xrTableCell19.Text = "Tình trạng nghỉ";
        this.xrTableCell19.Weight = 0.10970715285825064D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseFont = false;
        this.xrTableCell20.Text = "Ngày nghỉ";
        this.xrTableCell20.Weight = 0.1063768237989491D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseFont = false;
        this.xrTableCell21.Text = " Tổng thu nhập hiện tại ";
        this.xrTableCell21.Weight = 0.13631752617439769D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable4});
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.Weight = 0.28424272468623979D;
        // 
        // xrTable2
        // 
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(87.9101F, 55F);
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell25,
            this.xrTableCell26});
        this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseFont = false;
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.StylePriority.UseBorders = false;
        this.xrTableCell25.StylePriority.UseFont = false;
        this.xrTableCell25.Text = "Tháng bắt đầu tham gia";
        this.xrTableCell25.Weight = 1.2629965964089849D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell26.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.StylePriority.UseFont = false;
        this.xrTableCell26.Text = "Số sổ BHXH";
        this.xrTableCell26.Weight = 1.7370034035910151D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0.01004537F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(87.9F, 25F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell30});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.StylePriority.UseBorders = false;
        this.xrTableCell30.Text = "Tình trạng đóng BHXH";
        this.xrTableCell30.Weight = 3D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.Text = "Mã số TNCN";
        this.xrTableCell7.Weight = 0.182845245215851D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseFont = false;
        this.xrTableCell15.Text = "Tài khoản ngân hàng";
        this.xrTableCell15.Weight = 0.18950591724537888D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseFont = false;
        this.xrTableCell24.Text = "Điện thoại";
        this.xrTableCell24.Weight = 0.16166688921296657D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseFont = false;
        this.xrTableCell27.Text = "Email";
        this.xrTableCell27.Weight = 0.27806705356948269D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7});
        this.xrTableCell35.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseFont = false;
        this.xrTableCell35.Weight = 0.76872609457955021D;
        // 
        // xrTable6
        // 
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(237.75F, 25F);
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.Text = "Hợp đồng lao động";
        this.xrTableCell28.Weight = 3D;
        // 
        // xrTable7
        // 
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(237.75F, 55.00001F);
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell29,
            this.xrTableCell70,
            this.xrTableCell31,
            this.xrTableCell34,
            this.xrTableCell69,
            this.xrTableCell32});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.StylePriority.UseBorders = false;
        this.xrTableCell33.Text = "Loại HĐLĐ";
        this.xrTableCell33.Weight = 0.47042440885514358D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseBorders = false;
        this.xrTableCell29.Text = "Thời hạn HĐLĐ";
        this.xrTableCell29.Weight = 0.4773209751755958D;
        // 
        // xrTableCell70
        // 
        this.xrTableCell70.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell70.Name = "xrTableCell70";
        this.xrTableCell70.StylePriority.UseBorders = false;
        this.xrTableCell70.Text = "Lần ký HĐLĐ";
        this.xrTableCell70.Weight = 0.38182893217549119D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseBorders = false;
        this.xrTableCell31.Text = "Ngày bắt đầu";
        this.xrTableCell31.Weight = 0.44757100401427158D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.StylePriority.UseBorders = false;
        this.xrTableCell34.Text = "Ngày kết thúc";
        this.xrTableCell34.Weight = 0.44757098356988079D;
        // 
        // xrTableCell69
        // 
        this.xrTableCell69.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell69.Name = "xrTableCell69";
        this.xrTableCell69.StylePriority.UseBorders = false;
        this.xrTableCell69.Text = "Thời hạn còn lại (ngày)";
        this.xrTableCell69.Weight = 0.3320463669915249D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.Text = "Báo hạn gần hết HĐLĐ (ngày)";
        this.xrTableCell32.Weight = 0.44323732921809228D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell39.Multiline = true;
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseFont = false;
        this.xrTableCell39.Text = "DANH SÁCH CON \r\nCBNV";
        this.xrTableCell39.Weight = 0.3161557570176271D;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable9});
        this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.PageHeader.HeightF = 25F;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.StylePriority.UseFont = false;
        // 
        // xrTable9
        // 
        this.xrTable9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable9.SizeF = new System.Drawing.SizeF(1623F, 25F);
        this.xrTable9.StylePriority.UseBorders = false;
        this.xrTable9.StylePriority.UseFont = false;
        this.xrTable9.StylePriority.UsePadding = false;
        this.xrTable9.StylePriority.UseTextAlignment = false;
        this.xrTable9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell75,
            this.xrTableCell103,
            this.xrTableCell104,
            this.xrTableCell76,
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell81,
            this.xrTableCell37,
            this.xrTableCell82,
            this.xrTableCell83,
            this.xrTableCell84,
            this.xrTableCell85,
            this.xrTableCell86,
            this.xrTableCell87,
            this.xrTableCell88,
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrTableCell91,
            this.xrTableCell92,
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell95,
            this.xrTableCell96,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99,
            this.xrTableCell100,
            this.xrTableCell101,
            this.xrTableCell102});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell71
        // 
        this.xrTableCell71.Name = "xrTableCell71";
        this.xrTableCell71.Text = "1";
        this.xrTableCell71.Weight = 0.029463847331330895D;
        // 
        // xrTableCell72
        // 
        this.xrTableCell72.Name = "xrTableCell72";
        this.xrTableCell72.Text = "2";
        this.xrTableCell72.Weight = 0.12924222540723185D;
        // 
        // xrTableCell73
        // 
        this.xrTableCell73.Name = "xrTableCell73";
        this.xrTableCell73.Text = "3";
        this.xrTableCell73.Weight = 0.065563813154886907D;
        // 
        // xrTableCell74
        // 
        this.xrTableCell74.Name = "xrTableCell74";
        this.xrTableCell74.Text = "4";
        this.xrTableCell74.Weight = 0.046210718683746932D;
        // 
        // xrTableCell75
        // 
        this.xrTableCell75.Name = "xrTableCell75";
        this.xrTableCell75.Text = "5";
        this.xrTableCell75.Weight = 0.0735120080315029D;
        // 
        // xrTableCell103
        // 
        this.xrTableCell103.Name = "xrTableCell103";
        this.xrTableCell103.Text = "6";
        this.xrTableCell103.Weight = 0.077634010815135768D;
        // 
        // xrTableCell104
        // 
        this.xrTableCell104.Name = "xrTableCell104";
        this.xrTableCell104.Text = "7";
        this.xrTableCell104.Weight = 0.06556377291348861D;
        // 
        // xrTableCell76
        // 
        this.xrTableCell76.Name = "xrTableCell76";
        this.xrTableCell76.Text = "8";
        this.xrTableCell76.Weight = 0.090286367564236664D;
        // 
        // xrTableCell77
        // 
        this.xrTableCell77.Name = "xrTableCell77";
        this.xrTableCell77.Text = "9";
        this.xrTableCell77.Weight = 0.093271872335132455D;
        // 
        // xrTableCell78
        // 
        this.xrTableCell78.Name = "xrTableCell78";
        this.xrTableCell78.Text = "10";
        this.xrTableCell78.Weight = 0.064695009104425438D;
        // 
        // xrTableCell79
        // 
        this.xrTableCell79.Name = "xrTableCell79";
        this.xrTableCell79.Text = "11";
        this.xrTableCell79.Weight = 0.14448539240633485D;
        // 
        // xrTableCell80
        // 
        this.xrTableCell80.Name = "xrTableCell80";
        this.xrTableCell80.Text = "12";
        this.xrTableCell80.Weight = 0.21599511687889986D;
        // 
        // xrTableCell81
        // 
        this.xrTableCell81.Name = "xrTableCell81";
        this.xrTableCell81.Text = "13";
        this.xrTableCell81.Weight = 0.065619226269658021D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Text = "14";
        this.xrTableCell37.Weight = 0.051756008698599823D;
        // 
        // xrTableCell82
        // 
        this.xrTableCell82.Name = "xrTableCell82";
        this.xrTableCell82.Text = "15";
        this.xrTableCell82.Weight = 0.065619224964773584D;
        // 
        // xrTableCell83
        // 
        this.xrTableCell83.Name = "xrTableCell83";
        this.xrTableCell83.Text = "16";
        this.xrTableCell83.Weight = 0.10749534663508424D;
        // 
        // xrTableCell84
        // 
        this.xrTableCell84.Name = "xrTableCell84";
        this.xrTableCell84.Text = "17";
        this.xrTableCell84.Weight = 0.073955654843181839D;
        // 
        // xrTableCell85
        // 
        this.xrTableCell85.Name = "xrTableCell85";
        this.xrTableCell85.Text = "18";
        this.xrTableCell85.Weight = 0.091220142626222522D;
        // 
        // xrTableCell86
        // 
        this.xrTableCell86.Name = "xrTableCell86";
        this.xrTableCell86.Text = "19";
        this.xrTableCell86.Weight = 0.062716984635911D;
        // 
        // xrTableCell87
        // 
        this.xrTableCell87.Name = "xrTableCell87";
        this.xrTableCell87.Text = "20";
        this.xrTableCell87.Weight = 0.0608134692441844D;
        // 
        // xrTableCell88
        // 
        this.xrTableCell88.Name = "xrTableCell88";
        this.xrTableCell88.Text = "21";
        this.xrTableCell88.Weight = 0.077929711368713017D;
        // 
        // xrTableCell89
        // 
        this.xrTableCell89.Name = "xrTableCell89";
        this.xrTableCell89.Text = "22";
        this.xrTableCell89.Weight = 0.068410257738283256D;
        // 
        // xrTableCell90
        // 
        this.xrTableCell90.Name = "xrTableCell90";
        this.xrTableCell90.Text = "23";
        this.xrTableCell90.Weight = 0.094085113329609713D;
        // 
        // xrTableCell91
        // 
        this.xrTableCell91.Name = "xrTableCell91";
        this.xrTableCell91.Text = "24";
        this.xrTableCell91.Weight = 0.10452873907060582D;
        // 
        // xrTableCell92
        // 
        this.xrTableCell92.Name = "xrTableCell92";
        this.xrTableCell92.Text = "25";
        this.xrTableCell92.Weight = 0.10833654026612773D;
        // 
        // xrTableCell93
        // 
        this.xrTableCell93.Name = "xrTableCell93";
        this.xrTableCell93.Text = "26";
        this.xrTableCell93.Weight = 0.092421439942833181D;
        // 
        // xrTableCell94
        // 
        this.xrTableCell94.Name = "xrTableCell94";
        this.xrTableCell94.Text = "27";
        this.xrTableCell94.Weight = 0.15896468726632329D;
        // 
        // xrTableCell95
        // 
        this.xrTableCell95.Name = "xrTableCell95";
        this.xrTableCell95.Text = "28";
        this.xrTableCell95.Weight = 0.0689112844837351D;
        // 
        // xrTableCell96
        // 
        this.xrTableCell96.Name = "xrTableCell96";
        this.xrTableCell96.Text = "29";
        this.xrTableCell96.Weight = 0.069922145765942689D;
        // 
        // xrTableCell97
        // 
        this.xrTableCell97.Name = "xrTableCell97";
        this.xrTableCell97.Text = "30";
        this.xrTableCell97.Weight = 0.055933252500297764D;
        // 
        // xrTableCell98
        // 
        this.xrTableCell98.Name = "xrTableCell98";
        this.xrTableCell98.Text = "31";
        this.xrTableCell98.Weight = 0.0655634627985647D;
        // 
        // xrTableCell99
        // 
        this.xrTableCell99.Name = "xrTableCell99";
        this.xrTableCell99.Text = "32";
        this.xrTableCell99.Weight = 0.0655639422799215D;
        // 
        // xrTableCell100
        // 
        this.xrTableCell100.Name = "xrTableCell100";
        this.xrTableCell100.Text = "33";
        this.xrTableCell100.Weight = 0.048641296499538286D;
        // 
        // xrTableCell101
        // 
        this.xrTableCell101.Name = "xrTableCell101";
        this.xrTableCell101.Text = "34";
        this.xrTableCell101.Weight = 0.0649284884581503D;
        // 
        // xrTableCell102
        // 
        this.xrTableCell102.Name = "xrTableCell102";
        this.xrTableCell102.Text = "35";
        this.xrTableCell102.Weight = 0.18073942568738466D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlTruongPhongHCNS,
            this.xrLabel1,
            this.xrlNguoiBC2,
            this.xrlFT2,
            this.xrlTongGiamDoc,
            this.xrtngayketxuat,
            this.xrlFT3});
        this.ReportFooter.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.ReportFooter.HeightF = 178F;
        this.ReportFooter.Name = "ReportFooter";
        this.ReportFooter.StylePriority.UseFont = false;
        // 
        // xrlTruongPhongHCNS
        // 
        this.xrlTruongPhongHCNS.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrlTruongPhongHCNS.LocationFloat = new DevExpress.Utils.PointFloat(651.0417F, 145.8333F);
        this.xrlTruongPhongHCNS.Name = "xrlTruongPhongHCNS";
        this.xrlTruongPhongHCNS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlTruongPhongHCNS.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlTruongPhongHCNS.StylePriority.UseFont = false;
        this.xrlTruongPhongHCNS.StylePriority.UseTextAlignment = false;
        this.xrlTruongPhongHCNS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(651.0417F, 20.83333F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "TRƯỞNG PHÒNG HCNS";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlNguoiBC2
        // 
        this.xrlNguoiBC2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrlNguoiBC2.LocationFloat = new DevExpress.Utils.PointFloat(118.75F, 145.8333F);
        this.xrlNguoiBC2.Name = "xrlNguoiBC2";
        this.xrlNguoiBC2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNguoiBC2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlNguoiBC2.StylePriority.UseFont = false;
        this.xrlNguoiBC2.StylePriority.UseTextAlignment = false;
        this.xrlNguoiBC2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlFT2
        // 
        this.xrlFT2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrlFT2.LocationFloat = new DevExpress.Utils.PointFloat(118.75F, 20.83333F);
        this.xrlFT2.Name = "xrlFT2";
        this.xrlFT2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlFT2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlFT2.StylePriority.UseFont = false;
        this.xrlFT2.StylePriority.UseTextAlignment = false;
        this.xrlFT2.Text = "NGƯỜI LẬP";
        this.xrlFT2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlTongGiamDoc
        // 
        this.xrlTongGiamDoc.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrlTongGiamDoc.LocationFloat = new DevExpress.Utils.PointFloat(1309.737F, 145.8333F);
        this.xrlTongGiamDoc.Name = "xrlTongGiamDoc";
        this.xrlTongGiamDoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlTongGiamDoc.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlTongGiamDoc.StylePriority.UseFont = false;
        this.xrlTongGiamDoc.StylePriority.UseTextAlignment = false;
        this.xrlTongGiamDoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1309.737F, 15.625F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(303.2632F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlFT3
        // 
        this.xrlFT3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrlFT3.LocationFloat = new DevExpress.Utils.PointFloat(1309.737F, 38.62502F);
        this.xrlFT3.Name = "xrlFT3";
        this.xrlFT3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlFT3.SizeF = new System.Drawing.SizeF(303.2631F, 23F);
        this.xrlFT3.StylePriority.UseFont = false;
        this.xrlFT3.StylePriority.UseTextAlignment = false;
        this.xrlFT3.Text = "TỔNG GIÁM ĐỐC";
        this.xrlFT3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
        this.PageFooter.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.PageFooter.HeightF = 49.66665F;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.StylePriority.UseFont = false;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
        this.GroupHeader1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.GroupHeader1.HeightF = 25.42F;
        this.GroupHeader1.Name = "GroupHeader1";
        this.GroupHeader1.StylePriority.UseFont = false;
        // 
        // xrTable8
        // 
        this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(1623F, 25.42F);
        this.xrTable8.StylePriority.UseBorders = false;
        this.xrTable8.StylePriority.UseFont = false;
        this.xrTable8.StylePriority.UsePadding = false;
        this.xrTable8.StylePriority.UseTextAlignment = false;
        this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.grpBoPhan});
        this.xrTableRow8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.StylePriority.UseFont = false;
        this.xrTableRow8.StylePriority.UseTextAlignment = false;
        this.xrTableRow8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow8.Weight = 1D;
        // 
        // grpBoPhan
        // 
        this.grpBoPhan.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.grpBoPhan.Name = "grpBoPhan";
        this.grpBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
        this.grpBoPhan.StylePriority.UseFont = false;
        this.grpBoPhan.StylePriority.UsePadding = false;
        this.grpBoPhan.StylePriority.UseTextAlignment = false;
        this.grpBoPhan.Text = "Không thuộc phòng ban nào";
        this.grpBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.grpBoPhan.Weight = 10.829994588379142D;
        // 
        // xrLogo
        // 
        this.xrLogo.LocationFloat = new DevExpress.Utils.PointFloat(58.33333F, 0F);
        this.xrLogo.Name = "xrLogo";
        this.xrLogo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
        this.xrLogo.SizeF = new System.Drawing.SizeF(110F, 110F);
        this.xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        this.xrLogo.StylePriority.UsePadding = false;
        // 
        // rpwg_BangTongHopCBNVChiNhanh
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter,
            this.GroupHeader1});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(15, 16, 54, 38);
        this.PageHeight = 1169;
        this.PageWidth = 1654;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

}
