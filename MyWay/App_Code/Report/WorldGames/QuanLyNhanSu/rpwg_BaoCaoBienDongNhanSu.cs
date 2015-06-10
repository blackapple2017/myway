using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rpwg_BaoCaoBienDongNhanSu
/// </summary>
public class rpwg_BaoCaoBienDongNhanSu : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTime;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTongDauKy;
    private XRTableCell xrTongTuyenMoi;
    private XRTableCell xrTongNghiViec;
    private XRTableCell xrTongDieuChuyen;
    private XRTableCell xrTongCuoiKy;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrMaCB;
    private XRTableCell xrDepartmentName;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrSoDauKy;
    private XRTableCell xrTuyenMoi;
    private XRTableCell xrNghiViec;
    private XRTableCell xrDieuChuyen;
    private XRTableCell xrSoCuoiKy;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell33;
    private XRTableCell xrChiNhanh;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTongChiNhanhDauKy;
    private XRTableCell xrTongChiNhanhTuyenMoi;
    private XRTableCell xrTongChiNhanhNghiViec;
    private XRTableCell xrTongChiNhanhDieuChuyen;
    private XRTableCell xrTongChiNhanhCuoiKy;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrl_ten1;
    private XRLabel xrl_footer1;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_BaoCaoBienDongNhanSu()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public void BindData(ReportFilter filter)
    {
        xrTime.Text = string.Format("Tháng {0} năm {1}", filter.StartMonth, filter.Year);
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("report_WGTongHopBienDongNhanSu", "@month", "@year", filter.StartMonth, filter.Year);
        int totalDauKy = 0;
        int totalCuoiKy = 0;
        int totalDieuChuyen = 0;
        int totalTuyenMoi = 0;
        int totalNghiViec = 0;
        foreach (DataRow row in table.Rows)
        {
            totalCuoiKy += int.Parse("0" + row["CuoiKy"]);
            totalDauKy += int.Parse("0" + row["DauKy"]);
            totalDieuChuyen += int.Parse("" + row["DieuChuyen"]);
            totalTuyenMoi += int.Parse("0" + row["TuyenMoi"]);
            totalNghiViec += int.Parse("0" + row["NghiViec"]);
        }
        xrTongDauKy.Text = totalDauKy.ToString();
        xrTongTuyenMoi.Text = totalTuyenMoi.ToString();
        xrTongNghiViec.Text = totalNghiViec.ToString();
        xrTongDieuChuyen.Text = totalDieuChuyen.ToString();
        xrTongCuoiKy.Text = totalCuoiKy.ToString();
        DataSource = table;
        xrMaCB.DataBindings.Add("Text", DataSource, "MA_DONVI");
        xrSoDauKy.DataBindings.Add("Text", DataSource, "DauKy");
        xrDepartmentName.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        xrTuyenMoi.DataBindings.Add("Text", DataSource, "TuyenMoi");
        xrNghiViec.DataBindings.Add("Text", DataSource, "NghiViec");
        xrDieuChuyen.DataBindings.Add("Text", DataSource, "DieuChuyen");
        xrSoCuoiKy.DataBindings.Add("Text", DataSource, "CuoiKy");
        xrTongDieuChuyen.DataBindings.Add("Text", DataSource, "TongDieuChuyen");
        //xrTongTuyenMoi.DataBindings.Add("Text", DataSource, "TongTuyenMoi");
        //xrTongCuoiKy.DataBindings.Add("Text", DataSource, "TongCuoiKy");


        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
        new DevExpress.XtraReports.UI.GroupField("ChiNhanh", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrChiNhanh.DataBindings.Add("Text", DataSource, "ChiNhanh");
        xrTongChiNhanhDauKy.DataBindings.Add("Text", DataSource, "TongDauKy");
        xrTongChiNhanhTuyenMoi.DataBindings.Add("Text", DataSource, "TongTuyenMoi");
        xrTongChiNhanhNghiViec.DataBindings.Add("Text", DataSource, "TongNghiViec");
        xrTongChiNhanhDieuChuyen.DataBindings.Add("Text", DataSource, "TongDieuChuyen");
        xrTongChiNhanhCuoiKy.DataBindings.Add("Text", DataSource, "TongCuoiKy");

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
        string resourceFileName = "rpwg_BaoCaoBienDongNhanSu.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrMaCB = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrDepartmentName = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoDauKy = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTuyenMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNghiViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrDieuChuyen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoCuoiKy = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongDauKy = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongTuyenMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongNghiViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongDieuChuyen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCuoiKy = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTime = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrChiNhanh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongChiNhanhDauKy = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongChiNhanhTuyenMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongChiNhanhNghiViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongChiNhanhDieuChuyen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongChiNhanhCuoiKy = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5});
        this.Detail.HeightF = 29.95833F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable5
        // 
        this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(779.9999F, 29.95833F);
        this.xrTable5.StylePriority.UseBorders = false;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrMaCB,
            this.xrDepartmentName,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrSoDauKy,
            this.xrTuyenMoi,
            this.xrNghiViec,
            this.xrDieuChuyen,
            this.xrSoCuoiKy});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrMaCB
        // 
        this.xrMaCB.Name = "xrMaCB";
        this.xrMaCB.StylePriority.UseTextAlignment = false;
        this.xrMaCB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrMaCB.Weight = 0.20629369589682489D;
        // 
        // xrDepartmentName
        // 
        this.xrDepartmentName.Name = "xrDepartmentName";
        this.xrDepartmentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrDepartmentName.StylePriority.UsePadding = false;
        this.xrDepartmentName.StylePriority.UseTextAlignment = false;
        this.xrDepartmentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrDepartmentName.Weight = 0.60941104155884407D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.StylePriority.UseTextAlignment = false;
        this.xrTableCell25.Text = "9002";
        this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell25.Weight = 0.19179784401884334D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseTextAlignment = false;
        this.xrTableCell26.Text = "Số lượng nhân sự";
        this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell26.Weight = 0.40930968601476209D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseTextAlignment = false;
        this.xrTableCell27.Text = "Người";
        this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell27.Weight = 0.24872474161388553D;
        // 
        // xrSoDauKy
        // 
        this.xrSoDauKy.Name = "xrSoDauKy";
        this.xrSoDauKy.StylePriority.UseTextAlignment = false;
        this.xrSoDauKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSoDauKy.Weight = 0.24792424927528564D;
        // 
        // xrTuyenMoi
        // 
        this.xrTuyenMoi.Name = "xrTuyenMoi";
        this.xrTuyenMoi.StylePriority.UseTextAlignment = false;
        this.xrTuyenMoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTuyenMoi.Weight = 0.28619048489348342D;
        // 
        // xrNghiViec
        // 
        this.xrNghiViec.Name = "xrNghiViec";
        this.xrNghiViec.StylePriority.UseTextAlignment = false;
        this.xrNghiViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNghiViec.Weight = 0.2952963465885412D;
        // 
        // xrDieuChuyen
        // 
        this.xrDieuChuyen.Name = "xrDieuChuyen";
        this.xrDieuChuyen.StylePriority.UseTextAlignment = false;
        this.xrDieuChuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrDieuChuyen.Weight = 0.30329384690261785D;
        // 
        // xrSoCuoiKy
        // 
        this.xrSoCuoiKy.Name = "xrSoCuoiKy";
        this.xrSoCuoiKy.StylePriority.UseTextAlignment = false;
        this.xrSoCuoiKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSoCuoiKy.Weight = 0.20175806323691156D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 55F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 43F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.HeightF = 118F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 67.00001F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(780F, 30.29167F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "TỔNG HỢP BIẾN ĐỘNG NHÂN SỰ";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(332.2917F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "PHÒNG HCNS CÔNG TY";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(332.2917F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CÔNG TY CP THẾ GIỚI GIẢI TRÍ ";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable1});
        this.PageHeader.HeightF = 94.54166F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.58334F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(779.9999F, 29.95833F);
        this.xrTable4.StylePriority.UseBorders = false;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTongDauKy,
            this.xrTongTuyenMoi,
            this.xrTongNghiViec,
            this.xrTongDieuChuyen,
            this.xrTongCuoiKy});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 0.20629369589682489D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseFont = false;
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "TỔNG CỘNG";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell14.Weight = 0.60941162843543828D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseFont = false;
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell15.Weight = 0.19179784401884334D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseFont = false;
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell16.Weight = 0.40930956863944318D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.24872474161388558D;
        // 
        // xrTongDauKy
        // 
        this.xrTongDauKy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTongDauKy.Name = "xrTongDauKy";
        this.xrTongDauKy.StylePriority.UseFont = false;
        this.xrTongDauKy.StylePriority.UseTextAlignment = false;
        this.xrTongDauKy.Text = "213";
        this.xrTongDauKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongDauKy.Weight = 0.24792424927528561D;
        // 
        // xrTongTuyenMoi
        // 
        this.xrTongTuyenMoi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTongTuyenMoi.Name = "xrTongTuyenMoi";
        this.xrTongTuyenMoi.StylePriority.UseFont = false;
        this.xrTongTuyenMoi.StylePriority.UseTextAlignment = false;
        this.xrTongTuyenMoi.Text = "10";
        this.xrTongTuyenMoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongTuyenMoi.Weight = 0.28619025014284571D;
        // 
        // xrTongNghiViec
        // 
        this.xrTongNghiViec.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTongNghiViec.Name = "xrTongNghiViec";
        this.xrTongNghiViec.StylePriority.UseFont = false;
        this.xrTongNghiViec.StylePriority.UseTextAlignment = false;
        this.xrTongNghiViec.Text = "(17)";
        this.xrTongNghiViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongNghiViec.Weight = 0.2952961118379035D;
        // 
        // xrTongDieuChuyen
        // 
        this.xrTongDieuChuyen.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTongDieuChuyen.Name = "xrTongDieuChuyen";
        this.xrTongDieuChuyen.StylePriority.UseFont = false;
        this.xrTongDieuChuyen.StylePriority.UseTextAlignment = false;
        this.xrTongDieuChuyen.Text = "0";
        this.xrTongDieuChuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongDieuChuyen.Weight = 0.30329384690261785D;
        // 
        // xrTongCuoiKy
        // 
        this.xrTongCuoiKy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTongCuoiKy.Name = "xrTongCuoiKy";
        this.xrTongCuoiKy.StylePriority.UseFont = false;
        this.xrTongCuoiKy.StylePriority.UseTextAlignment = false;
        this.xrTongCuoiKy.Text = "205";
        this.xrTongCuoiKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCuoiKy.Weight = 0.20175806323691156D;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(780F, 64.58333F);
        this.xrTable1.StylePriority.UseBorders = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "Mã BP";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.20629372763467008D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "Tên bộ phận";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.6094113249878782D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Mã PT";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.1917979380467556D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Multiline = true;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Chỉ tiêu \r\nphân tích";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 0.40930937253511873D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "Đơn vị";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.24872495744611833D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
        this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 1.334462679349459D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(346.9601F, 31.25F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTime});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTime
        // 
        this.xrTime.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTime.Name = "xrTime";
        this.xrTime.StylePriority.UseBorders = false;
        this.xrTime.Text = "Năm 2013";
        this.xrTime.Weight = 3D;
        // 
        // xrTable2
        // 
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.25F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(346.9602F, 33.33334F);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Text = "Số ĐK";
        this.xrTableCell6.Weight = 0.5573578265298611D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Tuyển mới";
        this.xrTableCell8.Weight = 0.64338295256337741D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Nghỉ việc";
        this.xrTableCell9.Weight = 0.66385400598288613D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = "Điều chuyển";
        this.xrTableCell10.Weight = 0.68183442749562917D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Số CK";
        this.xrTableCell11.Weight = 0.4535707874282463D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer3,
            this.xrl_ten1,
            this.xrl_footer1,
            this.xrLabel4,
            this.xrLabel5});
        this.ReportFooter.HeightF = 225F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(472.4586F, 168.5F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(306.5418F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(473.4586F, 56.00001F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(306.5414F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(473.4584F, 79.00003F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(306.5414F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "NGƯỜI DUYỆT";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(36.95075F, 168.5F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(209.375F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(36.95075F, 70.58334F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(209.375F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP BÁO CÁO";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 10.00001F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(59.375F, 23F);
        this.xrLabel4.Text = "Ghi chú:";
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10.41679F, 33.00002F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(477.0833F, 23F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.Text = "1.Tổng nhân sự trên chưa bao gồm: CTV Phiên dịch, GÓC NGHỆ NHÂN";
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
        this.PageFooter.HeightF = 64.66668F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrPageInfo1.Format = "Trang {0} của {1}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(653.9583F, 41.66667F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6});
        this.GroupHeader1.HeightF = 29.95833F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable6
        // 
        this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 0F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(779.9999F, 29.95833F);
        this.xrTable6.StylePriority.UseBorders = false;
        this.xrTable6.StylePriority.UseFont = false;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrChiNhanh,
            this.xrTableCell35,
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTongChiNhanhDauKy,
            this.xrTongChiNhanhTuyenMoi,
            this.xrTongChiNhanhNghiViec,
            this.xrTongChiNhanhDieuChuyen,
            this.xrTongChiNhanhCuoiKy});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.StylePriority.UseTextAlignment = false;
        this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell33.Weight = 0.20629369589682489D;
        // 
        // xrChiNhanh
        // 
        this.xrChiNhanh.Name = "xrChiNhanh";
        this.xrChiNhanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrChiNhanh.StylePriority.UsePadding = false;
        this.xrChiNhanh.StylePriority.UseTextAlignment = false;
        this.xrChiNhanh.Text = "Tổng cộng (Khối VP)";
        this.xrChiNhanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrChiNhanh.Weight = 0.60941115893416287D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseTextAlignment = false;
        this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell35.Weight = 0.19179784401884348D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseTextAlignment = false;
        this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell36.Weight = 0.40930968601476203D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.StylePriority.UseTextAlignment = false;
        this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell37.Weight = 0.24872485898920441D;
        // 
        // xrTongChiNhanhDauKy
        // 
        this.xrTongChiNhanhDauKy.Name = "xrTongChiNhanhDauKy";
        this.xrTongChiNhanhDauKy.StylePriority.UseTextAlignment = false;
        this.xrTongChiNhanhDauKy.Text = "18";
        this.xrTongChiNhanhDauKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongChiNhanhDauKy.Weight = 0.24792448402592326D;
        // 
        // xrTongChiNhanhTuyenMoi
        // 
        this.xrTongChiNhanhTuyenMoi.Name = "xrTongChiNhanhTuyenMoi";
        this.xrTongChiNhanhTuyenMoi.StylePriority.UseTextAlignment = false;
        this.xrTongChiNhanhTuyenMoi.Text = "3";
        this.xrTongChiNhanhTuyenMoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongChiNhanhTuyenMoi.Weight = 0.28619001539220812D;
        // 
        // xrTongChiNhanhNghiViec
        // 
        this.xrTongChiNhanhNghiViec.Name = "xrTongChiNhanhNghiViec";
        this.xrTongChiNhanhNghiViec.StylePriority.UseTextAlignment = false;
        this.xrTongChiNhanhNghiViec.Text = "(3)";
        this.xrTongChiNhanhNghiViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongChiNhanhNghiViec.Weight = 0.2952961118379035D;
        // 
        // xrTongChiNhanhDieuChuyen
        // 
        this.xrTongChiNhanhDieuChuyen.Name = "xrTongChiNhanhDieuChuyen";
        this.xrTongChiNhanhDieuChuyen.StylePriority.UseTextAlignment = false;
        this.xrTongChiNhanhDieuChuyen.Text = "0";
        this.xrTongChiNhanhDieuChuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongChiNhanhDieuChuyen.Weight = 0.30329408165325555D;
        // 
        // xrTongChiNhanhCuoiKy
        // 
        this.xrTongChiNhanhCuoiKy.Name = "xrTongChiNhanhCuoiKy";
        this.xrTongChiNhanhCuoiKy.StylePriority.UseTextAlignment = false;
        this.xrTongChiNhanhCuoiKy.Text = "18";
        this.xrTongChiNhanhCuoiKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongChiNhanhCuoiKy.Weight = 0.20175806323691156D;
        // 
        // rpwg_BaoCaoBienDongNhanSu
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
        this.Margins = new System.Drawing.Printing.Margins(36, 34, 55, 43);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
