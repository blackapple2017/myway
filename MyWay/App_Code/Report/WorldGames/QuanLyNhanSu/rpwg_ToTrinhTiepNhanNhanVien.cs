using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rpwg_ToTrinhTiepNhanNhanVien
/// </summary>
public class rpwg_ToTrinhTiepNhanNhanVien : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private XRRichText xrRichText3;
    private XRRichText xrRichText4;
    private XRRichText xrDate;
    private XRLine xrLine1;
    private XRRichText xrRichText1;
    private XRRichText xrRichText2;
    private XRRichText xrRichText5;
    private XRRichText xrRichText6;
    private XRRichText xrRichText7;
    private XRRichText xrRichText8;
    private XRRichText xrRichText9;
    private XRRichText xrRichText10;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell6;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrHoTen;
    private XRTableCell xrTrinhDo;
    private XRTableCell xrNgayBatDauHocViec;
    private XRTableCell xrHinhThucLamViec;
    private XRRichText xrRichText12;
    private XRRichText xrRichText13;
    private XRRichText xrRichText14;
    private XRRichText xrRichText16;
    private XRRichText xrRichText15;
    private XRLine xrLine2;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rpwg_ToTrinhTiepNhanNhanVien()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
	
	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
            string resourceFileName = "rpwg_ToTrinhTiepNhanNhanVien.resx";
            System.Resources.ResourceManager resources = global::Resources.rpwg_ToTrinhTiepNhanNhanVien.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrDate = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText5 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText6 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText7 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText8 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText9 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText10 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrHoTen = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTrinhDo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrNgayBatDauHocViec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHinhThucLamViec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrRichText12 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText13 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText14 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText15 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText16 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).BeginInit();
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
            // TopMargin
            // 
            this.TopMargin.HeightF = 31F;
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
            this.xrLine2,
            this.xrTable1,
            this.xrRichText10,
            this.xrRichText9,
            this.xrRichText8,
            this.xrRichText7,
            this.xrRichText6,
            this.xrRichText5,
            this.xrRichText2,
            this.xrRichText1,
            this.xrRichText3,
            this.xrRichText4,
            this.xrDate,
            this.xrLine1});
            this.ReportHeader.HeightF = 323.0417F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText16,
            this.xrRichText15,
            this.xrRichText14,
            this.xrRichText13,
            this.xrRichText12});
            this.ReportFooter.HeightF = 787.4583F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(59.375F, 59.08334F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(218.3335F, 2F);
            // 
            // xrRichText3
            // 
            this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(354.5087F, 10.00001F);
            this.xrRichText3.Name = "xrRichText3";
            this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
            this.xrRichText3.SizeF = new System.Drawing.SizeF(357.4914F, 23F);
            // 
            // xrRichText4
            // 
            this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(354.5087F, 35.00001F);
            this.xrRichText4.Name = "xrRichText4";
            this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
            this.xrRichText4.SizeF = new System.Drawing.SizeF(357.4914F, 17F);
            // 
            // xrDate
            // 
            this.xrDate.LocationFloat = new DevExpress.Utils.PointFloat(354.5087F, 59.08334F);
            this.xrDate.Name = "xrDate";
            this.xrDate.SerializableRtfString = resources.GetString("xrDate.SerializableRtfString");
            this.xrDate.SizeF = new System.Drawing.SizeF(357.4914F, 23F);
            // 
            // xrRichText1
            // 
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 11.08335F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(337.0001F, 23F);
            // 
            // xrRichText2
            // 
            this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 36.08335F);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
            this.xrRichText2.SizeF = new System.Drawing.SizeF(337.0001F, 23F);
            // 
            // xrRichText5
            // 
            this.xrRichText5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 71.50002F);
            this.xrRichText5.Name = "xrRichText5";
            this.xrRichText5.SerializableRtfString = resources.GetString("xrRichText5.SerializableRtfString");
            this.xrRichText5.SizeF = new System.Drawing.SizeF(277.7085F, 23F);
            // 
            // xrRichText6
            // 
            this.xrRichText6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 103.5F);
            this.xrRichText6.Name = "xrRichText6";
            this.xrRichText6.SerializableRtfString = resources.GetString("xrRichText6.SerializableRtfString");
            this.xrRichText6.SizeF = new System.Drawing.SizeF(712F, 25F);
            // 
            // xrRichText7
            // 
            this.xrRichText7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 128.875F);
            this.xrRichText7.Name = "xrRichText7";
            this.xrRichText7.SerializableRtfString = resources.GetString("xrRichText7.SerializableRtfString");
            this.xrRichText7.SizeF = new System.Drawing.SizeF(711.9999F, 44.875F);
            // 
            // xrRichText8
            // 
            this.xrRichText8.LocationFloat = new DevExpress.Utils.PointFloat(46.79158F, 174.6667F);
            this.xrRichText8.Name = "xrRichText8";
            this.xrRichText8.SerializableRtfString = resources.GetString("xrRichText8.SerializableRtfString");
            this.xrRichText8.SizeF = new System.Drawing.SizeF(277.7085F, 20F);
            // 
            // xrRichText9
            // 
            this.xrRichText9.LocationFloat = new DevExpress.Utils.PointFloat(29.16667F, 194.6667F);
            this.xrRichText9.Name = "xrRichText9";
            this.xrRichText9.SerializableRtfString = resources.GetString("xrRichText9.SerializableRtfString");
            this.xrRichText9.SizeF = new System.Drawing.SizeF(652.625F, 63.62498F);
            // 
            // xrRichText10
            // 
            this.xrRichText10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 258.2917F);
            this.xrRichText10.Name = "xrRichText10";
            this.xrRichText10.SerializableRtfString = resources.GetString("xrRichText10.SerializableRtfString");
            this.xrRichText10.SizeF = new System.Drawing.SizeF(292.7083F, 19.79169F);
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 284.5F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(713F, 38.54166F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell6});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Họ và Tên";
            this.xrTableCell7.Weight = 0.73632540709507588D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Chức danh";
            this.xrTableCell2.Weight = 0.81764201970682338D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Thời gian nhận việc";
            this.xrTableCell3.Weight = 0.65922271248034381D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Ghi chú";
            this.xrTableCell6.Weight = 0.62832475843208035D;
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
            this.xrHoTen,
            this.xrTrinhDo,
            this.xrNgayBatDauHocViec,
            this.xrHinhThucLamViec});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrHoTen
            // 
            this.xrHoTen.Name = "xrHoTen";
            this.xrHoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrHoTen.StylePriority.UsePadding = false;
            this.xrHoTen.StylePriority.UseTextAlignment = false;
            this.xrHoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrHoTen.Weight = 0.77739384933407463D;
            // 
            // xrTrinhDo
            // 
            this.xrTrinhDo.Name = "xrTrinhDo";
            this.xrTrinhDo.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTrinhDo.StylePriority.UsePadding = false;
            this.xrTrinhDo.StylePriority.UseTextAlignment = false;
            this.xrTrinhDo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTrinhDo.Weight = 0.86324578883102876D;
            // 
            // xrNgayBatDauHocViec
            // 
            this.xrNgayBatDauHocViec.Name = "xrNgayBatDauHocViec";
            this.xrNgayBatDauHocViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrNgayBatDauHocViec.StylePriority.UsePadding = false;
            this.xrNgayBatDauHocViec.StylePriority.UseTextAlignment = false;
            this.xrNgayBatDauHocViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrNgayBatDauHocViec.Weight = 0.69599079918560425D;
            // 
            // xrHinhThucLamViec
            // 
            this.xrHinhThucLamViec.Name = "xrHinhThucLamViec";
            this.xrHinhThucLamViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrHinhThucLamViec.StylePriority.UsePadding = false;
            this.xrHinhThucLamViec.StylePriority.UseTextAlignment = false;
            this.xrHinhThucLamViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrHinhThucLamViec.Weight = 0.66336956264929225D;
            // 
            // xrRichText12
            // 
            this.xrRichText12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrRichText12.Name = "xrRichText12";
            this.xrRichText12.SerializableRtfString = resources.GetString("xrRichText12.SerializableRtfString");
            this.xrRichText12.SizeF = new System.Drawing.SizeF(713F, 348.2917F);
            // 
            // xrRichText13
            // 
            this.xrRichText13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrRichText13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 348.3749F);
            this.xrRichText13.Name = "xrRichText13";
            this.xrRichText13.SerializableRtfString = resources.GetString("xrRichText13.SerializableRtfString");
            this.xrRichText13.SizeF = new System.Drawing.SizeF(324.5001F, 143.8333F);
            this.xrRichText13.StylePriority.UseBorders = false;
            // 
            // xrRichText14
            // 
            this.xrRichText14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrRichText14.LocationFloat = new DevExpress.Utils.PointFloat(324.5F, 348.3749F);
            this.xrRichText14.Name = "xrRichText14";
            this.xrRichText14.SerializableRtfString = resources.GetString("xrRichText14.SerializableRtfString");
            this.xrRichText14.SizeF = new System.Drawing.SizeF(387.5F, 143.8333F);
            this.xrRichText14.StylePriority.UseBorders = false;
            // 
            // xrRichText15
            // 
            this.xrRichText15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrRichText15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 492.2082F);
            this.xrRichText15.Name = "xrRichText15";
            this.xrRichText15.SerializableRtfString = resources.GetString("xrRichText15.SerializableRtfString");
            this.xrRichText15.SizeF = new System.Drawing.SizeF(324.5001F, 133.4167F);
            this.xrRichText15.StylePriority.UseBorders = false;
            // 
            // xrRichText16
            // 
            this.xrRichText16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrRichText16.LocationFloat = new DevExpress.Utils.PointFloat(325.5F, 492.2082F);
            this.xrRichText16.Name = "xrRichText16";
            this.xrRichText16.SerializableRtfString = resources.GetString("xrRichText16.SerializableRtfString");
            this.xrRichText16.SizeF = new System.Drawing.SizeF(387.5F, 133.4167F);
            this.xrRichText16.StylePriority.UseBorders = false;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(447.4167F, 52.00002F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(167.4913F, 2F);
            // 
            // rpwg_ToTrinhTiepNhanNhanVien
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(68, 69, 31, 0);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
