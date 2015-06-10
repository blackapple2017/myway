using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoDanhSachCanBoDuocNangLuong
/// </summary>
public class rp_BaoCaoDanhSachCanBoDuocNangLuong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrtstt;
    private XRTableCell xrtmanhanvien;
    private XRTableCell xrthoten;
    private XRTableCell xrtchucvu;
    private XRTableCell xrtngayhuongluongcu;
    private XRTableCell xrthesocu;
    private XRTableCell xrtbacluongcu;
    private XRTableCell xrtngayhuongluongmoi;
    private XRTableCell xrthesomoi;
    private XRTableCell xrtbacluongmoi;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_NgayBaoCao;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TitleBC;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell7;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrl_tenphong;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRTableCell xrTableCell13;
    private XRTableCell xrt_soquyetdinh;
    /// <summary>
    /// Nguyễn Văn Khởi
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BaoCaoDanhSachCanBoDuocNangLuong()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

        xrl_NgayBaoCao.Text = "Ngày báo cáo:" + string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrtstt.Text = STT.ToString();
        STT++;
    }
    int sott = 1;
    public void BindData(ReportFilter filter)
    {
        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        xrl_TenThanhPho.Text = ReportController.GetInstance().GetCityName(filter.SessionDepartment);
        xrtngayketxuat.Text = ReportController.GetInstance().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        xrl_NgayBaoCao.Text = ReportController.GetInstance().GetFromDateToDate(filter.StartDate, filter.EndDate);
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_CanBoDuocNangLuong", "@MaDonVi", "@MaBoPhan", "@WhereClause", filter.SessionDepartment, filter.SelectedDepartment, filter.WhereClause);
        DataSource = table;
        int c = table.Rows.Count;
        xrtmanhanvien.DataBindings.Add("Text", DataSource, "MA_CB");
        xrthoten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrtngayhuongluongcu.DataBindings.Add("Text", DataSource, "NgayHieuLucCu", "{0:dd/MM/yyyy}");
        xrthesocu.DataBindings.Add("Text", DataSource, "HeSoLuongCu");
        xrtbacluongmoi.DataBindings.Add("Text", DataSource, "BacLuongMoi");
        xrtbacluongcu.DataBindings.Add("Text", DataSource, "BacLuongCu");
        xrtngayhuongluongmoi.DataBindings.Add("Text", DataSource, "NgayHieuLucMoi", "{0:dd/MM/yyyy}");
        xrthesomoi.DataBindings.Add("Text", DataSource, "HeSoLuongMoi");
        xrtchucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        xrt_soquyetdinh.DataBindings.Add("Text", DataSource, "SoQuyetDinh");
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrl_tenphong.DataBindings.Add("Text", DataSource, "TEN_PHONG");
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_TitleBC.Text = filter.ReportTitle.ToUpper();
        }
        if (!string.IsNullOrEmpty(filter.Title1))
        {
            xrl_footer1.Text = filter.Title1;
        }
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrl_footer2.Text = filter.Title2;
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrl_footer3.Text = filter.Title3;
        }

        //if (!string.IsNullOrEmpty(filter.Ten1))
        //{
        //    xrl_ten1.Text = filter.Ten1;
        //}
        //else
        //{
        //    xrl_ten1.Text = filter.NguoiLapBaoCao.ToString();
        //}
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrl_ten1.Text = filter.Name1;
        }
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrl_ten2.Text = filter.Name2;
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrl_ten3.Text = filter.Name3;
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
        string resourceFileName = "rp_BaoCaoDanhSachCanBoDuocNangLuong.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtmanhanvien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrthoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_soquyetdinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtchucvu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtngayhuongluongcu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrthesocu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtbacluongcu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtngayhuongluongmoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrthesomoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtbacluongmoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrl_tenphong = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NgayBaoCao = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5});
        this.Detail.HeightF = 25.41666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTable5
        // 
        this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(1000.598F, 25.41666F);
        this.xrTable5.StylePriority.UseBorders = false;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtmanhanvien,
            this.xrthoten,
            this.xrt_soquyetdinh,
            this.xrtchucvu,
            this.xrtngayhuongluongcu,
            this.xrthesocu,
            this.xrtbacluongcu,
            this.xrtngayhuongluongmoi,
            this.xrthesomoi,
            this.xrtbacluongmoi});
        this.xrTableRow5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.StylePriority.UseFont = false;
        this.xrTableRow5.StylePriority.UseTextAlignment = false;
        this.xrTableRow5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow5.Weight = 1D;
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
        this.xrtmanhanvien.Weight = 0.92708422417805747D;
        // 
        // xrthoten
        // 
        this.xrthoten.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrthoten.Name = "xrthoten";
        this.xrthoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrthoten.StylePriority.UseFont = false;
        this.xrthoten.StylePriority.UsePadding = false;
        this.xrthoten.StylePriority.UseTextAlignment = false;
        this.xrthoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrthoten.Weight = 1.4206921071602781D;
        // 
        // xrt_soquyetdinh
        // 
        this.xrt_soquyetdinh.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_soquyetdinh.Name = "xrt_soquyetdinh";
        this.xrt_soquyetdinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
        this.xrt_soquyetdinh.StylePriority.UseFont = false;
        this.xrt_soquyetdinh.StylePriority.UsePadding = false;
        this.xrt_soquyetdinh.StylePriority.UseTextAlignment = false;
        this.xrt_soquyetdinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_soquyetdinh.Weight = 0.94321462249107335D;
        // 
        // xrtchucvu
        // 
        this.xrtchucvu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtchucvu.Name = "xrtchucvu";
        this.xrtchucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrtchucvu.StylePriority.UseFont = false;
        this.xrtchucvu.StylePriority.UsePadding = false;
        this.xrtchucvu.StylePriority.UseTextAlignment = false;
        this.xrtchucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtchucvu.Weight = 1.0646625482003083D;
        // 
        // xrtngayhuongluongcu
        // 
        this.xrtngayhuongluongcu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtngayhuongluongcu.Name = "xrtngayhuongluongcu";
        this.xrtngayhuongluongcu.StylePriority.UseFont = false;
        this.xrtngayhuongluongcu.StylePriority.UseTextAlignment = false;
        this.xrtngayhuongluongcu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtngayhuongluongcu.Weight = 0.72456623546632759D;
        // 
        // xrthesocu
        // 
        this.xrthesocu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrthesocu.Name = "xrthesocu";
        this.xrthesocu.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
        this.xrthesocu.StylePriority.UseFont = false;
        this.xrthesocu.StylePriority.UsePadding = false;
        this.xrthesocu.StylePriority.UseTextAlignment = false;
        this.xrthesocu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrthesocu.Weight = 0.72456615042338379D;
        // 
        // xrtbacluongcu
        // 
        this.xrtbacluongcu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtbacluongcu.Name = "xrtbacluongcu";
        this.xrtbacluongcu.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
        this.xrtbacluongcu.StylePriority.UseFont = false;
        this.xrtbacluongcu.StylePriority.UsePadding = false;
        this.xrtbacluongcu.StylePriority.UseTextAlignment = false;
        this.xrtbacluongcu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtbacluongcu.Weight = 0.72456783520102475D;
        // 
        // xrtngayhuongluongmoi
        // 
        this.xrtngayhuongluongmoi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtngayhuongluongmoi.Name = "xrtngayhuongluongmoi";
        this.xrtngayhuongluongmoi.StylePriority.UseFont = false;
        this.xrtngayhuongluongmoi.StylePriority.UseTextAlignment = false;
        this.xrtngayhuongluongmoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtngayhuongluongmoi.Weight = 0.70549435645047076D;
        // 
        // xrthesomoi
        // 
        this.xrthesomoi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrthesomoi.Name = "xrthesomoi";
        this.xrthesomoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
        this.xrthesomoi.StylePriority.UseFont = false;
        this.xrthesomoi.StylePriority.UsePadding = false;
        this.xrthesomoi.StylePriority.UseTextAlignment = false;
        this.xrthesomoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrthesomoi.Weight = 0.705495442375912D;
        // 
        // xrtbacluongmoi
        // 
        this.xrtbacluongmoi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrtbacluongmoi.Name = "xrtbacluongmoi";
        this.xrtbacluongmoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
        this.xrtbacluongmoi.StylePriority.UseFont = false;
        this.xrtbacluongmoi.StylePriority.UsePadding = false;
        this.xrtbacluongmoi.StylePriority.UseTextAlignment = false;
        this.xrtbacluongmoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtbacluongmoi.Weight = 0.70549343654221019D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 48F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 51F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6});
        this.GroupHeader1.HeightF = 25.41666F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable6
        // 
        this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(1000.598F, 25.41666F);
        this.xrTable6.StylePriority.UseBorders = false;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrl_tenphong});
        this.xrTableRow6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.StylePriority.UseFont = false;
        this.xrTableRow6.StylePriority.UseTextAlignment = false;
        this.xrTableRow6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow6.Weight = 1D;
        // 
        // xrl_tenphong
        // 
        this.xrl_tenphong.Name = "xrl_tenphong";
        this.xrl_tenphong.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
        this.xrl_tenphong.StylePriority.UsePadding = false;
        this.xrl_tenphong.StylePriority.UseTextAlignment = false;
        this.xrl_tenphong.Text = "agag";
        this.xrl_tenphong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_tenphong.Weight = 9.000003618289254D;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TenCongTy,
            this.xrl_NgayBaoCao,
            this.xrl_TenThanhPho,
            this.xrl_TitleBC});
        this.ReportHeader.HeightF = 125F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(452.4167F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_NgayBaoCao
        // 
        this.xrl_NgayBaoCao.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrl_NgayBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(1.127577F, 89F);
        this.xrl_NgayBaoCao.Name = "xrl_NgayBaoCao";
        this.xrl_NgayBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NgayBaoCao.SizeF = new System.Drawing.SizeF(898.0547F, 25.99999F);
        this.xrl_NgayBaoCao.StylePriority.UseFont = false;
        this.xrl_NgayBaoCao.StylePriority.UseTextAlignment = false;
        this.xrl_NgayBaoCao.Text = "Từ ngày 14/3/2013 đến ngày 14/3/2013";
        this.xrl_NgayBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(452.4166F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0.0002066294F, 64F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(898.0547F, 25F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BÁO CÁO DANH SÁCH CÁN BỘ ĐƯỢC NÂNG LƯƠNG";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 61.24998F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1001F, 61.24998F);
        this.xrTable1.StylePriority.UseBorders = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell7});
        this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.StylePriority.UseFont = false;
        this.xrTableRow1.StylePriority.UseTextAlignment = false;
        this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.35416665980020634D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Mã nhân viên";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.92708299638317848D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Họ tên";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 1.4196063836071886D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "Số quyết định";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 0.94283443081633855D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.Text = "Chức vụ";
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell15.Weight = 1.0642341190870508D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable3,
            this.xrTable2});
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Weight = 4.2920709131141876D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(241.6667F, 25F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(235.3054F, 36.24998F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "Ngày hưởng lương";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 1D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "Hệ số";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "Bậc lương";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 1D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 25F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(241.6667F, 36.24998F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = "Ngày hưởng lương";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell6.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "Hệ số";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "Bậc lương";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 1D;
        // 
        // xrTable2
        // 
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(475.0272F, 25F);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "Lương cũ";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 2.4166665649414063D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "Lương mới";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 2.3336045849846578D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrl_ten2,
            this.xrl_ten1,
            this.xrtngayketxuat,
            this.xrl_footer1,
            this.xrl_footer3,
            this.xrl_footer2});
        this.ReportFooter.HeightF = 230F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(599.7639F, 148F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(299.4183F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(300.3954F, 148F);
        this.xrl_ten2.Name = "xrl_ten2";
        this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten2.SizeF = new System.Drawing.SizeF(290.2025F, 23F);
        this.xrl_ten2.StylePriority.UseFont = false;
        this.xrl_ten2.StylePriority.UseTextAlignment = false;
        this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 148F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(286.9793F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(597.555F, 25F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(300.4998F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 48.00002F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(286.9793F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(597.555F, 48.00002F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(300.5F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(300.3955F, 48.00002F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(292.2034F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "PHÒNG TCHC";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(773.9583F, 38.54167F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // rp_BaoCaoDanhSachCanBoDuocNangLuong
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupFooter1,
            this.PageFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(50, 49, 48, 51);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
