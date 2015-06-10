using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataController;

/// <summary>
/// Summary description for rpwg_TiepNhanNhanSu
/// </summary>
public class rpwg_TiepNhanNhanSu : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLine xrLine1;
    private XRRichText xrRichText2;
    private XRRichText xrRichText1;
    private XRRichText xrDate;
    private XRRichText xrRichText4;
    private XRRichText xrRichText3;
    private XRRichText xrRichText6;
    private XRRichText xrRichText7;
    private XRRichText xrRichText8;
    private XRRichText xrRichText9;
    private XRRichText xrRichText10;
    private XRRichText xrRichText11;
    private XRRichText xrRichText12;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrSTT;
    private XRTableCell xrTrinhDo;
    private XRTableCell xrNgayBatDauHocViec;
    private XRTableCell xrHoTen;
    private XRTableCell xrNgaySinh;
    private XRTableCell xrViTriCongViec;
    private XRTableCell xrHinhThucLamViec;
    private ReportFooterBand ReportFooter;
    private XRRichText xrRichText13;
    private XRRichText xrRichText14;
    private XRRichText xrRichText15;
    private XRRichText xrRichText16;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_TiepNhanNhanSu()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrSTT.Text = STT.ToString();
        STT++;
    }

    public void BindData(ReportFilter filter)
    {
        ReportController rpController = new ReportController();
        DataSource = DataHandler.GetInstance().ExecuteDataTable("WG_DanhSachTiepNhanThuViec", "@startdate", "@enddate", filter.StartDate, filter.EndDate);
        xrDate.Rtf = rpController.Convertstringtortf(xrDate.Rtf, "{0}", DateTime.Now.Day.ToString());
        xrDate.Rtf = rpController.Convertstringtortf(xrDate.Rtf, "{1}", DateTime.Now.Month.ToString());
        xrDate.Rtf = rpController.Convertstringtortf(xrDate.Rtf, "{2}", DateTime.Now.Year.ToString());
        xrHoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrNgaySinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
        xrTrinhDo.DataBindings.Add("Text", DataSource, "TEN_TRINHDO");
        xrViTriCongViec.DataBindings.Add("Text", DataSource, "TEN_CONGVIEC");
        xrNgayBatDauHocViec.DataBindings.Add("Text", DataSource, "NGAY_TUYEN_DTIEN", "{0:dd/MM/yyyy}");
        xrHinhThucLamViec.DataBindings.Add("Text", DataSource, "HinhThucLamViec");

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
        string resourceFileName = "rpwg_TiepNhanNhanSu.resx";
        System.Resources.ResourceManager resources = global::Resources.rpwg_TiepNhanNhanSu.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrSTT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrHoTen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgaySinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTrinhDo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrViTriCongViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgayBatDauHocViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrHinhThucLamViec = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrRichText12 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText11 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText10 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText9 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText8 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText7 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText6 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrDate = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrRichText16 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText15 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText14 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText13 = new DevExpress.XtraReports.UI.XRRichText();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(713F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrSTT,
            this.xrHoTen,
            this.xrNgaySinh,
            this.xrTrinhDo,
            this.xrViTriCongViec,
            this.xrNgayBatDauHocViec,
            this.xrHinhThucLamViec});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrSTT
        // 
        this.xrSTT.Name = "xrSTT";
        this.xrSTT.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 3, 3, 3, 100F);
        this.xrSTT.StylePriority.UsePadding = false;
        this.xrSTT.Weight = 0.1204960356253561D;
        this.xrSTT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrHoTen
        // 
        this.xrHoTen.Name = "xrHoTen";
        this.xrHoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 3, 3, 3, 100F);
        this.xrHoTen.StylePriority.UsePadding = false;
        this.xrHoTen.Weight = 0.65689781370871858D;
        // 
        // xrNgaySinh
        // 
        this.xrNgaySinh.Name = "xrNgaySinh";
        this.xrNgaySinh.Weight = 0.4442249688660781D;
        // 
        // xrTrinhDo
        // 
        this.xrTrinhDo.Name = "xrTrinhDo";
        this.xrTrinhDo.Weight = 0.36204343156426688D;
        // 
        // xrViTriCongViec
        // 
        this.xrViTriCongViec.Name = "xrViTriCongViec";
        this.xrViTriCongViec.Weight = 0.52788740588772676D;
        // 
        // xrNgayBatDauHocViec
        // 
        this.xrNgayBatDauHocViec.Name = "xrNgayBatDauHocViec";
        this.xrNgayBatDauHocViec.Weight = 0.4442251561233071D;
        // 
        // xrHinhThucLamViec
        // 
        this.xrHinhThucLamViec.Name = "xrHinhThucLamViec";
        this.xrHinhThucLamViec.Weight = 0.44422518822454637D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 41F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 0F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrRichText12,
            this.xrRichText11,
            this.xrRichText10,
            this.xrRichText9,
            this.xrRichText8,
            this.xrRichText7,
            this.xrRichText6,
            this.xrDate,
            this.xrRichText4,
            this.xrRichText3,
            this.xrLine1,
            this.xrRichText2,
            this.xrRichText1});
        this.ReportHeader.HeightF = 381.25F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 332.2917F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(713F, 48.95834F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell2,
            this.xrTableCell5,
            this.xrTableCell3,
            this.xrTableCell6});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "TT";
        this.xrTableCell1.Weight = 0.11413044548302179D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Họ & Tên";
        this.xrTableCell7.Weight = 0.62219496161205412D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Năm sinh";
        this.xrTableCell4.Weight = 0.42075736860406349D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Trình độ";
        this.xrTableCell2.Weight = 0.34291722430086069D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Dự kiến vị trí";
        this.xrTableCell5.Weight = 0.5D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Ngày bắt đầu học việc";
        this.xrTableCell3.Weight = 0.42075735255344382D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Multiline = true;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Hình thức \r\nLàm việc";
        this.xrTableCell6.Weight = 0.42075754516087949D;
        // 
        // xrRichText12
        // 
        this.xrRichText12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 285.375F);
        this.xrRichText12.Name = "xrRichText12";
        this.xrRichText12.SerializableRtfString = resources.GetString("xrRichText12.SerializableRtfString");
        this.xrRichText12.SizeF = new System.Drawing.SizeF(713F, 23F);
        // 
        // xrRichText11
        // 
        this.xrRichText11.LocationFloat = new DevExpress.Utils.PointFloat(90.625F, 236.5834F);
        this.xrRichText11.Name = "xrRichText11";
        this.xrRichText11.SerializableRtfString = resources.GetString("xrRichText11.SerializableRtfString");
        this.xrRichText11.SizeF = new System.Drawing.SizeF(622.375F, 23.00002F);
        // 
        // xrRichText10
        // 
        this.xrRichText10.LocationFloat = new DevExpress.Utils.PointFloat(90.625F, 213.5833F);
        this.xrRichText10.Name = "xrRichText10";
        this.xrRichText10.SerializableRtfString = resources.GetString("xrRichText10.SerializableRtfString");
        this.xrRichText10.SizeF = new System.Drawing.SizeF(622.375F, 23F);
        // 
        // xrRichText9
        // 
        this.xrRichText9.LocationFloat = new DevExpress.Utils.PointFloat(90.625F, 190.5833F);
        this.xrRichText9.Name = "xrRichText9";
        this.xrRichText9.SerializableRtfString = resources.GetString("xrRichText9.SerializableRtfString");
        this.xrRichText9.SizeF = new System.Drawing.SizeF(622.375F, 23F);
        // 
        // xrRichText8
        // 
        this.xrRichText8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 190.5833F);
        this.xrRichText8.Name = "xrRichText8";
        this.xrRichText8.SerializableRtfString = resources.GetString("xrRichText8.SerializableRtfString");
        this.xrRichText8.SizeF = new System.Drawing.SizeF(90.625F, 23F);
        // 
        // xrRichText7
        // 
        this.xrRichText7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 134.4167F);
        this.xrRichText7.Name = "xrRichText7";
        this.xrRichText7.SerializableRtfString = resources.GetString("xrRichText7.SerializableRtfString");
        this.xrRichText7.SizeF = new System.Drawing.SizeF(713F, 23F);
        // 
        // xrRichText6
        // 
        this.xrRichText6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 102.0417F);
        this.xrRichText6.Name = "xrRichText6";
        this.xrRichText6.SerializableRtfString = resources.GetString("xrRichText6.SerializableRtfString");
        this.xrRichText6.SizeF = new System.Drawing.SizeF(713F, 32.37502F);
        // 
        // xrDate
        // 
        this.xrDate.LocationFloat = new DevExpress.Utils.PointFloat(327.1667F, 47.99998F);
        this.xrDate.Name = "xrDate";
        this.xrDate.SerializableRtfString = resources.GetString("xrDate.SerializableRtfString");
        this.xrDate.SizeF = new System.Drawing.SizeF(385.8333F, 23F);
        // 
        // xrRichText4
        // 
        this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(327.1667F, 25F);
        this.xrRichText4.Name = "xrRichText4";
        this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
        this.xrRichText4.SizeF = new System.Drawing.SizeF(385.8333F, 23F);
        // 
        // xrRichText3
        // 
        this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(327.1667F, 0F);
        this.xrRichText3.Name = "xrRichText3";
        this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
        this.xrRichText3.SizeF = new System.Drawing.SizeF(385.8333F, 23F);
        // 
        // xrLine1
        // 
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(25F, 50F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(137.5F, 11.45832F);
        // 
        // xrRichText2
        // 
        this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrRichText2.Name = "xrRichText2";
        this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
        this.xrRichText2.SizeF = new System.Drawing.SizeF(175F, 23F);
        // 
        // xrRichText1
        // 
        this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrRichText1.Name = "xrRichText1";
        this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
        this.xrRichText1.SizeF = new System.Drawing.SizeF(175F, 23F);
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText16,
            this.xrRichText15,
            this.xrRichText14,
            this.xrRichText13});
        this.ReportFooter.HeightF = 275F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrRichText16
        // 
        this.xrRichText16.LocationFloat = new DevExpress.Utils.PointFloat(28.63789F, 108.2917F);
        this.xrRichText16.Name = "xrRichText16";
        this.xrRichText16.SerializableRtfString = resources.GetString("xrRichText16.SerializableRtfString");
        this.xrRichText16.SizeF = new System.Drawing.SizeF(183.206F, 81.33333F);
        // 
        // xrRichText15
        // 
        this.xrRichText15.LocationFloat = new DevExpress.Utils.PointFloat(387.3749F, 205.1667F);
        this.xrRichText15.Name = "xrRichText15";
        this.xrRichText15.SerializableRtfString = resources.GetString("xrRichText15.SerializableRtfString");
        this.xrRichText15.SizeF = new System.Drawing.SizeF(315.6251F, 23F);
        // 
        // xrRichText14
        // 
        this.xrRichText14.LocationFloat = new DevExpress.Utils.PointFloat(387.3749F, 85.37502F);
        this.xrRichText14.Name = "xrRichText14";
        this.xrRichText14.SerializableRtfString = resources.GetString("xrRichText14.SerializableRtfString");
        this.xrRichText14.SizeF = new System.Drawing.SizeF(315.625F, 23F);
        // 
        // xrRichText13
        // 
        this.xrRichText13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999974F);
        this.xrRichText13.Name = "xrRichText13";
        this.xrRichText13.SerializableRtfString = resources.GetString("xrRichText13.SerializableRtfString");
        this.xrRichText13.SizeF = new System.Drawing.SizeF(713F, 54.62506F);
        // 
        // rpwg_TiepNhanNhanSu
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
        this.Margins = new System.Drawing.Printing.Margins(70, 67, 41, 0);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
