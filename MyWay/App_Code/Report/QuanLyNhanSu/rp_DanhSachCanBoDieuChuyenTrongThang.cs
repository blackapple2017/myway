using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_DanhSachCanBoDieuChuyenTrongThang
/// </summary>
public class rp_DanhSachCanBoDieuChuyenTrongThang : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_ngayBC;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TitleBC;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrtmanhanvien;
    private XRTableCell xrthoten;
    private XRTableCell xrtgioitinh;
    private XRTableCell xrt_soquyetdinh;
    private XRTableCell xrt_ngayhieuluc;
    private XRTableCell xrtngaysinh;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrl_tenphong;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell10;
    private XRTableCell xrt_ngayhethieuluc;
    private XRTableCell xrt_bophancu;
    private XRTableCell xrt_tenbophanmoi;
    private XRPictureBox xrLogo;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DanhSachCanBoDieuChuyenTrongThang()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrtstt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        DataTable table = new DataTable();
        xrl_ngayBC.Text = "Tháng " + filter.StartMonth + " năm " + filter.Year;
        table = DataHandler.GetInstance().ExecuteDataTable("sp_DanhSachNhanVienDieuChuyenTrongThang", "@MaBoPhan", "@Gender", "@TinhTrang", "@MinSeniority", "@MaxSeniority", "@Month", "@Year", "@WhereClause", filter.SelectedDepartment, filter.Gender, filter.WorkingStatus, filter.MinSeniority, filter.MaxSeniority, filter.StartMonth, filter.Year, filter.WhereClause);
        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        //xrl_ThanhPho.Text = ReportController.GetInstance().GetCityName(filter.SessionDepartment);

        xrtngayketxuat.Text = ReportController.GetInstance().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        DataSource = table;
        xrtmanhanvien.DataBindings.Add("Text", DataSource, "MA_CB");
        xrthoten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrtngaysinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
        xrtgioitinh.DataBindings.Add("Text", DataSource, "TEN_GIOITINH");
        xrt_tenbophanmoi.DataBindings.Add("Text", DataSource, "TenBoPhanMoi");
        xrt_bophancu.DataBindings.Add("Text", DataSource, "TenBoPhanCu");
        xrt_soquyetdinh.DataBindings.Add("Text", DataSource, "SoQuyetDinh");
        xrt_ngayhieuluc.DataBindings.Add("Text", DataSource, "NgayCoHieuLuc", "{0:dd/MM/yyyy}");
        xrt_ngayhethieuluc.DataBindings.Add("Text", DataSource, "NgayHetHieuLuc", "{0:dd/MM/yyyy}");
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MA_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrl_tenphong.DataBindings.Add("Text", DataSource, "TEN_PHONG");
        ReportController rpCtr = new ReportController();
        if (!string.IsNullOrEmpty(filter.Title1))
        {
            xrl_footer1.Text = filter.Title1;
        }
        else
        {
            xrl_footer1.Text = rpCtr.GetTitleOfSignature(xrl_footer1.Text, filter.Title1);
        }
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrl_footer2.Text = filter.Title2;
        }
        else
        {
            xrl_footer2.Text = rpCtr.GetTitleOfSignature(xrl_footer2.Text, filter.Title2);
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrl_footer3.Text = filter.Title3;
        }
        else
        {
            xrl_footer3.Text = rpCtr.GetTitleOfSignature(xrl_footer3.Text, filter.Title3);
        }
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrl_ten1.Text = filter.Name1;
        }
        else
        {
            xrl_ten1.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
        }
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrl_ten2.Text = filter.Name2;
        }
        else
        {
            xrl_ten2.Text = rpCtr.GetHeadOfHRroom(filter.SessionDepartment, filter.Name2);
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrl_ten3.Text = filter.Name3;
        }
        else
        {
            xrl_ten3.Text = rpCtr.GetDirectorName(filter.SessionDepartment, filter.Name3);
        }
        //tieu de
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_TitleBC.Text = filter.ReportTitle;
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
        string resourceFileName = "rp_DanhSachCanBoDieuChuyenTrongThang.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtmanhanvien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrthoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtgioitinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_soquyetdinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ngayhieuluc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ngayhethieuluc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_bophancu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tenbophanmoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_ngayBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrl_tenphong = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 25.41666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1090F, 25.41666F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UsePadding = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtmanhanvien,
            this.xrthoten,
            this.xrtngaysinh,
            this.xrtgioitinh,
            this.xrt_soquyetdinh,
            this.xrt_ngayhieuluc,
            this.xrt_ngayhethieuluc,
            this.xrt_bophancu,
            this.xrt_tenbophanmoi});
        this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseFont = false;
        this.xrTableRow2.StylePriority.UseTextAlignment = false;
        this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow2.Weight = 1D;
        // 
        // xrtstt
        // 
        this.xrtstt.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtstt.Name = "xrtstt";
        this.xrtstt.StylePriority.UseFont = false;
        this.xrtstt.StylePriority.UseTextAlignment = false;
        this.xrtstt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtstt.Weight = 0.35416665980020634D;
        // 
        // xrtmanhanvien
        // 
        this.xrtmanhanvien.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtmanhanvien.Name = "xrtmanhanvien";
        this.xrtmanhanvien.StylePriority.UseFont = false;
        this.xrtmanhanvien.StylePriority.UseTextAlignment = false;
        this.xrtmanhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtmanhanvien.Weight = 0.98958436374603009D;
        // 
        // xrthoten
        // 
        this.xrthoten.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrthoten.Name = "xrthoten";
        this.xrthoten.StylePriority.UseFont = false;
        this.xrthoten.StylePriority.UseTextAlignment = false;
        this.xrthoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrthoten.Weight = 1.456472535719306D;
        // 
        // xrtngaysinh
        // 
        this.xrtngaysinh.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtngaysinh.Name = "xrtngaysinh";
        this.xrtngaysinh.StylePriority.UseFont = false;
        this.xrtngaysinh.StylePriority.UseTextAlignment = false;
        this.xrtngaysinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtngaysinh.Weight = 1.0293879378644606D;
        // 
        // xrtgioitinh
        // 
        this.xrtgioitinh.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtgioitinh.Name = "xrtgioitinh";
        this.xrtgioitinh.StylePriority.UseFont = false;
        this.xrtgioitinh.StylePriority.UseTextAlignment = false;
        this.xrtgioitinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtgioitinh.Weight = 0.719869685986819D;
        // 
        // xrt_soquyetdinh
        // 
        this.xrt_soquyetdinh.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_soquyetdinh.Name = "xrt_soquyetdinh";
        this.xrt_soquyetdinh.StylePriority.UseFont = false;
        this.xrt_soquyetdinh.StylePriority.UseTextAlignment = false;
        this.xrt_soquyetdinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_soquyetdinh.Weight = 1.095936428699869D;
        // 
        // xrt_ngayhieuluc
        // 
        this.xrt_ngayhieuluc.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_ngayhieuluc.Name = "xrt_ngayhieuluc";
        this.xrt_ngayhieuluc.StylePriority.UseFont = false;
        this.xrt_ngayhieuluc.StylePriority.UseTextAlignment = false;
        this.xrt_ngayhieuluc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_ngayhieuluc.Weight = 1.0972293697635969D;
        // 
        // xrt_ngayhethieuluc
        // 
        this.xrt_ngayhethieuluc.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_ngayhethieuluc.Name = "xrt_ngayhethieuluc";
        this.xrt_ngayhethieuluc.StylePriority.UseFont = false;
        this.xrt_ngayhethieuluc.StylePriority.UseTextAlignment = false;
        this.xrt_ngayhethieuluc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_ngayhethieuluc.Weight = 1.253500870673371D;
        // 
        // xrt_bophancu
        // 
        this.xrt_bophancu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_bophancu.Name = "xrt_bophancu";
        this.xrt_bophancu.StylePriority.UseFont = false;
        this.xrt_bophancu.StylePriority.UseTextAlignment = false;
        this.xrt_bophancu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_bophancu.Weight = 1.4258879865349692D;
        // 
        // xrt_tenbophanmoi
        // 
        this.xrt_tenbophanmoi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_tenbophanmoi.Name = "xrt_tenbophanmoi";
        this.xrt_tenbophanmoi.StylePriority.UseFont = false;
        this.xrt_tenbophanmoi.StylePriority.UseTextAlignment = false;
        this.xrt_tenbophanmoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_tenbophanmoi.Weight = 1.4587790825219134D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 39F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 48F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLogo,
            this.xrl_ngayBC,
            this.xrl_TenCongTy,
            this.xrl_TitleBC});
        this.ReportHeader.HeightF = 230F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_ngayBC
        // 
        this.xrl_ngayBC.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_ngayBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 183.1667F);
        this.xrl_ngayBC.Name = "xrl_ngayBC";
        this.xrl_ngayBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ngayBC.SizeF = new System.Drawing.SizeF(1087F, 23F);
        this.xrl_ngayBC.StylePriority.UseFont = false;
        this.xrl_ngayBC.StylePriority.UseTextAlignment = false;
        this.xrl_ngayBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 118.2083F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(564.5415F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UsePadding = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN THẾ GIỚI GIẢI TRÍ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160.1667F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1087F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BÁO CÁO DANH SÁCH NHÂN VIÊN ĐIỀU CHUYỂN TRONG THÁNG";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 34F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1090F, 34F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell6,
            this.xrTableCell10,
            this.xrTableCell8});
        this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableRow1.StylePriority.UseFont = false;
        this.xrTableRow1.StylePriority.UsePadding = false;
        this.xrTableRow1.StylePriority.UseTextAlignment = false;
        this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell1.Weight = 0.35416665980020634D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Mã nhân viên";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell2.Weight = 0.98958346714861012D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Họ tên";
        this.xrTableCell3.Weight = 1.456472174588654D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Ngày sinh";
        this.xrTableCell4.Weight = 1.029387788321912D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Giới tính";
        this.xrTableCell5.Weight = 0.71986920153506317D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Số quyết định";
        this.xrTableCell9.Weight = 1.095934116829147D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Ngày hiệu lực";
        this.xrTableCell7.Weight = 1.0972287463100576D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Multiline = true;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Ngày hết hiệu lực";
        this.xrTableCell6.Weight = 1.2535006548137753D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = "Tên bộ phận cũ";
        this.xrTableCell10.Weight = 1.4258852404932372D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Tên bộ phận mới";
        this.xrTableCell8.Weight = 1.477968966470578D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten1,
            this.xrl_ten2,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer2,
            this.xrl_footer3,
            this.xrl_footer1});
        this.ReportFooter.HeightF = 224F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(6.999842F, 147.5F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(372.0825F, 147.5F);
        this.xrl_ten2.Name = "xrl_ten2";
        this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
        this.xrl_ten2.StylePriority.UseFont = false;
        this.xrl_ten2.StylePriority.UseTextAlignment = false;
        this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(784.5825F, 147.5F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(302.4174F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(784.5825F, 22.49998F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(303.4987F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(372.0824F, 47.49997F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "TRƯỞNG PHÒNG HCNS";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(784.5825F, 47.49997F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(302.4175F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 47.49997F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.GroupHeader1.HeightF = 25.41666F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1090F, 25.41666F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UsePadding = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrl_tenphong});
        this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.StylePriority.UseFont = false;
        this.xrTableRow3.StylePriority.UseTextAlignment = false;
        this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow3.Weight = 1D;
        // 
        // xrl_tenphong
        // 
        this.xrl_tenphong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrl_tenphong.Name = "xrl_tenphong";
        this.xrl_tenphong.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
        this.xrl_tenphong.StylePriority.UseFont = false;
        this.xrl_tenphong.StylePriority.UsePadding = false;
        this.xrl_tenphong.StylePriority.UseTextAlignment = false;
        this.xrl_tenphong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_tenphong.Weight = 10.870004370089353D;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
        this.PageFooter.Name = "PageFooter";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrPageInfo1.Format = "Trang {0} của {1}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(960.9582F, 67.00001F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
        // rp_DanhSachCanBoDieuChuyenTrongThang
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(4, 6, 39, 48);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
