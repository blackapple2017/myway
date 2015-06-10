using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoChiTiet1DotTuyenDung
/// </summary>
public class rp_BaoChiTiet1DotTuyenDung : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_NgayBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell10;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrt_vitriungtuyen;
    private XRTableCell xrt_chucvu;
    private XRTableCell xrt_nganhnghe;
    private XRTableCell xrt_hinhthuclamviec;
    private XRTableCell xrt_diadiem;
    private XRTableCell xrt_mucluong;
    private XRTableCell xrt_soluong;
    private XRTableCell xrt_mota;
    private XRTableCell xrt_namkinhnghiem;
    private XRTableCell xrt_bangcap;
    private XRTableCell xrt_gioitinh;
    private XRTableCell xrt_tuoi;
    private XRTableCell xrt_hoso;
    private XRTableCell xrt_hannop;
    private XRTableCell xrt_hinhthucnop;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BaoChiTiet1DotTuyenDung()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    public void BindData(ReportFilter filter)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("GETChiTietMotDotTuyenDung");
        DataSource = table;
        xrt_vitriungtuyen.DataBindings.Add("Text", DataSource, "TenKeHoach");
        xrt_hannop.DataBindings.Add("Text", DataSource, "HanNopHoSo","{0:dd/MM/yyyy}");
        xrt_mota.DataBindings.Add("Text", DataSource, "MoTaCongViec");
        xrt_mucluong.DataBindings.Add("Text", DataSource, "MucLuongDuKienToiDa");
        xrt_soluong.DataBindings.Add("Text", DataSource, "SoLuongCanTuyen");
        xrt_hinhthuclamviec.DataBindings.Add("Text", DataSource, "HinhThucLamViec");
        xrt_diadiem.DataBindings.Add("Text", DataSource, "NoiLamViec");
        xrt_nganhnghe.DataBindings.Add("Text", DataSource, "TEN_CONGVIEC");
        xrt_chucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");

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
        string resourceFileName = "rp_BaoChiTiet1DotTuyenDung.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_vitriungtuyen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_nganhnghe = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hinhthuclamviec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_diadiem = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_mucluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_soluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_mota = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_namkinhnghiem = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_bangcap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_gioitinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hoso = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hannop = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hinhthucnop = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NgayBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 24.99999F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.BorderWidth = 1;
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1080F, 24.99999F);
        this.xrTable2.StylePriority.UseBackColor = false;
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseBorderWidth = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrt_vitriungtuyen,
            this.xrt_chucvu,
            this.xrt_nganhnghe,
            this.xrt_hinhthuclamviec,
            this.xrt_diadiem,
            this.xrt_mucluong,
            this.xrt_soluong,
            this.xrt_mota,
            this.xrt_namkinhnghiem,
            this.xrt_bangcap,
            this.xrt_gioitinh,
            this.xrt_tuoi,
            this.xrt_hoso,
            this.xrt_hannop,
            this.xrt_hinhthucnop});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrtstt
        // 
        this.xrtstt.Name = "xrtstt";
        this.xrtstt.Weight = 0.29023007992085653D;
        this.xrtstt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrtstt_BeforePrint);
        // 
        // xrt_vitriungtuyen
        // 
        this.xrt_vitriungtuyen.Name = "xrt_vitriungtuyen";
        this.xrt_vitriungtuyen.StylePriority.UseTextAlignment = false;
        this.xrt_vitriungtuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_vitriungtuyen.Weight = 0.67134416096161675D;
        // 
        // xrt_chucvu
        // 
        this.xrt_chucvu.Name = "xrt_chucvu";
        this.xrt_chucvu.StylePriority.UseTextAlignment = false;
        this.xrt_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_chucvu.Weight = 0.38949947362645343D;
        // 
        // xrt_nganhnghe
        // 
        this.xrt_nganhnghe.Name = "xrt_nganhnghe";
        this.xrt_nganhnghe.Weight = 0.44934578691831506D;
        // 
        // xrt_hinhthuclamviec
        // 
        this.xrt_hinhthuclamviec.Name = "xrt_hinhthuclamviec";
        this.xrt_hinhthuclamviec.Weight = 0.44974953496124881D;
        // 
        // xrt_diadiem
        // 
        this.xrt_diadiem.Name = "xrt_diadiem";
        this.xrt_diadiem.StylePriority.UseTextAlignment = false;
        this.xrt_diadiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_diadiem.Weight = 0.69136395171378839D;
        // 
        // xrt_mucluong
        // 
        this.xrt_mucluong.Name = "xrt_mucluong";
        this.xrt_mucluong.Weight = 0.42329770905972908D;
        // 
        // xrt_soluong
        // 
        this.xrt_soluong.Name = "xrt_soluong";
        this.xrt_soluong.StylePriority.UseBackColor = false;
        this.xrt_soluong.StylePriority.UseTextAlignment = false;
        this.xrt_soluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_soluong.Weight = 0.33109958561141317D;
        // 
        // xrt_mota
        // 
        this.xrt_mota.Name = "xrt_mota";
        this.xrt_mota.StylePriority.UseTextAlignment = false;
        this.xrt_mota.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_mota.Weight = 0.894724619737376D;
        // 
        // xrt_namkinhnghiem
        // 
        this.xrt_namkinhnghiem.Name = "xrt_namkinhnghiem";
        this.xrt_namkinhnghiem.Weight = 0.38012916237924776D;
        // 
        // xrt_bangcap
        // 
        this.xrt_bangcap.Name = "xrt_bangcap";
        this.xrt_bangcap.Weight = 0.41527868391390205D;
        // 
        // xrt_gioitinh
        // 
        this.xrt_gioitinh.Name = "xrt_gioitinh";
        this.xrt_gioitinh.Weight = 0.25773092079148113D;
        // 
        // xrt_tuoi
        // 
        this.xrt_tuoi.Name = "xrt_tuoi";
        this.xrt_tuoi.StylePriority.UseTextAlignment = false;
        this.xrt_tuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tuoi.Weight = 0.26672386656776054D;
        // 
        // xrt_hoso
        // 
        this.xrt_hoso.Name = "xrt_hoso";
        this.xrt_hoso.StylePriority.UseTextAlignment = false;
        this.xrt_hoso.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hoso.Weight = 0.93717590059944056D;
        // 
        // xrt_hannop
        // 
        this.xrt_hannop.Name = "xrt_hannop";
        this.xrt_hannop.Weight = 0.671306809724667D;
        // 
        // xrt_hinhthucnop
        // 
        this.xrt_hinhthucnop.Name = "xrt_hinhthucnop";
        this.xrt_hinhthucnop.Weight = 0.47094388096632533D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 31F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TitleBC,
            this.xrl_NgayBC,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
        this.ReportHeader.HeightF = 127F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
        this.xrl_TitleBC.Multiline = true;
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1080F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BÁO CÁO CHI TIẾT MỘT ĐỢT TUYỂN DỤNG\r\n";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_NgayBC
        // 
        this.xrl_NgayBC.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_NgayBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
        this.xrl_NgayBC.Name = "xrl_NgayBC";
        this.xrl_NgayBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NgayBC.SizeF = new System.Drawing.SizeF(1080F, 23F);
        this.xrl_NgayBC.StylePriority.UseFont = false;
        this.xrl_NgayBC.StylePriority.UseTextAlignment = false;
        this.xrl_NgayBC.Text = "Ngày báo cáo :16/4/2013";
        this.xrl_NgayBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(434.375F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(434.375F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 72F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.BorderWidth = 1;
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1080F, 71.87499F);
        this.xrTable1.StylePriority.UseBackColor = false;
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseBorderWidth = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell3,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell10,
            this.xrTableCell15,
            this.xrTableCell16});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.Weight = 0.29023014542259462D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Vị trí tuyển dụng";
        this.xrTableCell2.Weight = 0.67134420904270065D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Chức vụ";
        this.xrTableCell4.Weight = 0.38949978754698794D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Ngành nghề";
        this.xrTableCell5.Weight = 0.44934562560280145D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Hình thức làm việc";
        this.xrTableCell3.Weight = 0.44974985480491053D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Địa điểm";
        this.xrTableCell6.Weight = 0.69136410327364139D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Mức lương";
        this.xrTableCell7.Weight = 0.4232978501673757D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBackColor = false;
        this.xrTableCell8.Text = "Số lượng";
        this.xrTableCell8.Weight = 0.3310992100211988D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Mô tả";
        this.xrTableCell9.Weight = 0.89472549617211738D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Năm kinh nghiệm";
        this.xrTableCell11.Weight = 0.38012920528098559D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Bằng cấp";
        this.xrTableCell12.Weight = 0.41527833208010068D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "Giới tính";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell13.Weight = 0.25773096785937721D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "Tuổi";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell14.Weight = 0.26672347054873491D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = "Hồ sơ";
        this.xrTableCell10.Weight = 0.93717723851561041D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Hạn nộp";
        this.xrTableCell15.Weight = 0.67130743943042037D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Text = "Hình thức nộp hồ sơ";
        this.xrTableCell16.Weight = 0.47094299786055804D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrl_ten1,
            this.xrtngayketxuat,
            this.xrl_footer3,
            this.xrl_footer1});
        this.ReportFooter.HeightF = 183F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(747.5928F, 50F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(268.7498F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "TRƯỜNG PHÒNG TUYỂN DỤNG";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(247.5928F, 50F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(307.2916F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP ";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(747.5928F, 25F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(268.7498F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 16 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(747.5928F, 125F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(268.7498F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(247.5928F, 125F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(307.2916F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // rp_BaoChiTiet1DotTuyenDung
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(10, 7, 31, 100);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
    int STT = 1;
    private void xrtstt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrtstt.Text = STT.ToString();
        STT++;
    }
}
