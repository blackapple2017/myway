using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for sub_Part2C70
/// </summary>
public class sub_Part2C70 : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell4;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell15;
    private XRTable xrTable9;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell12;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTable xrTable12;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell17;
    private XRTable xrTable13;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell23;
    private XRTable xrTable15;
    private XRTableRow xrTableRow11;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hoten;
    private XRTableCell xrNamSinhNam;
    private XRTableCell xrNamSinhNu;
    private XRTableCell xrSoSoBHXH;
    private XRTableCell xrDotXetTuyen;
    private XRTableCell xrMucHuongSoMoi;
    private XRTableCell xrMucHuongSoChenhLech;
    private XRTableCell xrSoNgayThucSoChenhLech;
    private XRTableCell xrSoNgayThucNghiLuyKe;
    private XRTableCell xrt_ghichu;
    private XRTableCell xrTableCell1;
    private ReportHeaderBand ReportHeader;
    private XRTable xrTable11;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell36;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public sub_Part2C70()
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
        string resourceFileName = "sub_Part2C70.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNamSinhNam = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNamSinhNu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoSoBHXH = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrDotXetTuyen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrMucHuongSoMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrMucHuongSoChenhLech = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoNgayThucSoChenhLech = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoNgayThucNghiLuyKe = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable15});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 0F;
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
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10});
        this.PageHeader.HeightF = 92.70834F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable10
        // 
        this.xrTable10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable10.SizeF = new System.Drawing.SizeF(1079F, 92.70834F);
        this.xrTable10.StylePriority.UseBorders = false;
        this.xrTable10.StylePriority.UseFont = false;
        this.xrTable10.StylePriority.UseTextAlignment = false;
        this.xrTable10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell6,
            this.xrTableCell9,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell23});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Text = "STT";
        this.xrTableCell21.Weight = 0.09011639262354651D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Text = "Họ và tên";
        this.xrTableCell24.Weight = 0.36337204334347745D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Weight = 0.23251881348136486D;
        // 
        // xrTable8
        // 
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(1.525879E-05F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8,
            this.xrTableRow9});
        this.xrTable8.SizeF = new System.Drawing.SizeF(92.85686F, 92.70836F);
        this.xrTable8.StylePriority.UseFont = false;
        this.xrTable8.StylePriority.UseTextAlignment = false;
        this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.Text = "Năm sinh";
        this.xrTableCell4.Weight = 3D;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell7});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.Text = "Nam";
        this.xrTableCell8.Weight = 1.5D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.Text = "Nữ";
        this.xrTableCell7.Weight = 1.5D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Số sổ BHXH";
        this.xrTableCell6.Weight = 0.19642934440522772D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Đợt xét tuyển";
        this.xrTableCell9.Weight = 0.34510762671740813D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable9});
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "xrTableCell15";
        this.xrTableCell15.Weight = 0.44342731620000542D;
        // 
        // xrTable9
        // 
        this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13,
            this.xrTableRow15});
        this.xrTable9.SizeF = new System.Drawing.SizeF(177.0836F, 92.70834F);
        this.xrTable9.StylePriority.UseFont = false;
        this.xrTable9.StylePriority.UseTextAlignment = false;
        this.xrTable9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.Text = "Mức hưởng (đồng)";
        this.xrTableCell12.Weight = 3D;
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.Text = "Số mới";
        this.xrTableCell13.Weight = 1.5D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.StylePriority.UseFont = false;
        this.xrTableCell14.Text = "Số chênh lệch";
        this.xrTableCell14.Weight = 1.5D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable12,
            this.xrTable13});
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Text = "xrTableCell16";
        this.xrTableCell16.Weight = 0.51066645369119068D;
        // 
        // xrTable12
        // 
        this.xrTable12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46.35417F);
        this.xrTable12.Name = "xrTable12";
        this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
        this.xrTable12.SizeF = new System.Drawing.SizeF(204.6945F, 46.35417F);
        this.xrTable12.StylePriority.UseFont = false;
        this.xrTable12.StylePriority.UseTextAlignment = false;
        this.xrTable12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell17});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.Text = "Lũy kế từ đầu năm";
        this.xrTableCell17.Weight = 1.5D;
        // 
        // xrTable13
        // 
        this.xrTable13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable13.Name = "xrTable13";
        this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
        this.xrTable13.SizeF = new System.Drawing.SizeF(204.6945F, 46.35418F);
        this.xrTable13.StylePriority.UseFont = false;
        this.xrTable13.StylePriority.UseTextAlignment = false;
        this.xrTable13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow14
        // 
        this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32});
        this.xrTableRow14.Name = "xrTableRow14";
        this.xrTableRow14.Weight = 1D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell32.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.StylePriority.UseFont = false;
        this.xrTableCell32.Text = "Số ngày thực nghỉ";
        this.xrTableCell32.Weight = 3D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Text = "Nội dung, lý do điều chỉnh";
        this.xrTableCell23.Weight = 0.51022270353589472D;
        // 
        // xrTable15
        // 
        this.xrTable15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable15.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
        this.xrTable15.Name = "xrTable15";
        this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
        this.xrTable15.SizeF = new System.Drawing.SizeF(1079F, 25F);
        this.xrTable15.StylePriority.UseBorders = false;
        this.xrTable15.StylePriority.UseFont = false;
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hoten,
            this.xrNamSinhNam,
            this.xrNamSinhNu,
            this.xrSoSoBHXH,
            this.xrDotXetTuyen,
            this.xrMucHuongSoMoi,
            this.xrMucHuongSoChenhLech,
            this.xrSoNgayThucSoChenhLech,
            this.xrSoNgayThucNghiLuyKe,
            this.xrt_ghichu});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrt_stt
        // 
        this.xrt_stt.Name = "xrt_stt";
        this.xrt_stt.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_stt.StylePriority.UsePadding = false;
        this.xrt_stt.StylePriority.UseTextAlignment = false;
        this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_stt.Weight = 0.10043207922647165D;
        // 
        // xrt_hoten
        // 
        this.xrt_hoten.Name = "xrt_hoten";
        this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hoten.StylePriority.UsePadding = false;
        this.xrt_hoten.StylePriority.UseTextAlignment = false;
        this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        this.xrt_hoten.Weight = 0.40496747393940768D;
        // 
        // xrNamSinhNam
        // 
        this.xrNamSinhNam.Name = "xrNamSinhNam";
        this.xrNamSinhNam.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrNamSinhNam.StylePriority.UsePadding = false;
        this.xrNamSinhNam.StylePriority.UseTextAlignment = false;
        this.xrNamSinhNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNamSinhNam.Weight = 0.12956768302030336D;
        // 
        // xrNamSinhNu
        // 
        this.xrNamSinhNu.Name = "xrNamSinhNu";
        this.xrNamSinhNu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrNamSinhNu.StylePriority.UsePadding = false;
        this.xrNamSinhNu.StylePriority.UseTextAlignment = false;
        this.xrNamSinhNu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNamSinhNu.Weight = 0.12956773092580393D;
        // 
        // xrSoSoBHXH
        // 
        this.xrSoSoBHXH.Name = "xrSoSoBHXH";
        this.xrSoSoBHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrSoSoBHXH.StylePriority.UsePadding = false;
        this.xrSoSoBHXH.StylePriority.UseTextAlignment = false;
        this.xrSoSoBHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSoSoBHXH.Weight = 0.21891468225523483D;
        // 
        // xrDotXetTuyen
        // 
        this.xrDotXetTuyen.Name = "xrDotXetTuyen";
        this.xrDotXetTuyen.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrDotXetTuyen.StylePriority.UsePadding = false;
        this.xrDotXetTuyen.StylePriority.UseTextAlignment = false;
        this.xrDotXetTuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrDotXetTuyen.Weight = 0.38461252523023026D;
        // 
        // xrMucHuongSoMoi
        // 
        this.xrMucHuongSoMoi.Name = "xrMucHuongSoMoi";
        this.xrMucHuongSoMoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrMucHuongSoMoi.StylePriority.UsePadding = false;
        this.xrMucHuongSoMoi.StylePriority.UseTextAlignment = false;
        this.xrMucHuongSoMoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrMucHuongSoMoi.Weight = 0.24617714851044442D;
        // 
        // xrMucHuongSoChenhLech
        // 
        this.xrMucHuongSoChenhLech.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrMucHuongSoChenhLech.Name = "xrMucHuongSoChenhLech";
        this.xrMucHuongSoChenhLech.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrMucHuongSoChenhLech.StylePriority.UseBorders = false;
        this.xrMucHuongSoChenhLech.StylePriority.UsePadding = false;
        this.xrMucHuongSoChenhLech.StylePriority.UseTextAlignment = false;
        this.xrMucHuongSoChenhLech.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrMucHuongSoChenhLech.Weight = 0.24800883767573842D;
        // 
        // xrSoNgayThucSoChenhLech
        // 
        this.xrSoNgayThucSoChenhLech.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrSoNgayThucSoChenhLech.Name = "xrSoNgayThucSoChenhLech";
        this.xrSoNgayThucSoChenhLech.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrSoNgayThucSoChenhLech.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrSoNgayThucSoChenhLech.StylePriority.UseBorders = false;
        this.xrSoNgayThucSoChenhLech.StylePriority.UsePadding = false;
        this.xrSoNgayThucSoChenhLech.StylePriority.UseTextAlignment = false;
        this.xrSoNgayThucSoChenhLech.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSoNgayThucSoChenhLech.Weight = 0.28456218565815822D;
        // 
        // xrSoNgayThucNghiLuyKe
        // 
        this.xrSoNgayThucNghiLuyKe.Name = "xrSoNgayThucNghiLuyKe";
        this.xrSoNgayThucNghiLuyKe.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrSoNgayThucNghiLuyKe.StylePriority.UsePadding = false;
        this.xrSoNgayThucNghiLuyKe.StylePriority.UseTextAlignment = false;
        this.xrSoNgayThucNghiLuyKe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrSoNgayThucNghiLuyKe.Weight = 0.28456134476887679D;
        // 
        // xrt_ghichu
        // 
        this.xrt_ghichu.Name = "xrt_ghichu";
        this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_ghichu.StylePriority.UsePadding = false;
        this.xrt_ghichu.StylePriority.UseTextAlignment = false;
        this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_ghichu.Weight = 0.56862830878933046D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Số chênh lệch";
        this.xrTableCell1.Weight = 1.5D;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable11});
        this.ReportHeader.HeightF = 25F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrTable11
        // 
        this.xrTable11.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
        this.xrTable11.Name = "xrTable11";
        this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12});
        this.xrTable11.SizeF = new System.Drawing.SizeF(1079F, 25F);
        this.xrTable11.StylePriority.UseFont = false;
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseFont = false;
        this.xrTableCell36.StylePriority.UseTextAlignment = false;
        this.xrTableCell36.Text = "Phần II: DANH SÁCH ĐIỀU CHỈNH SỐ ĐÃ ĐƯỢC THANH TOÁN TRONG ĐỢT XÉT TUYỂN ĐỢT TRƯỚC" +
            "";
        this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell36.Weight = 3D;
        // 
        // sub_Part2C70
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(48, 42, 0, 0);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
