using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_BangTongHopThuNhapVaChiuThueVaThueDaNop
/// </summary>
public class rp_BangTongHopThuNhapVaChiuThueVaThueDaNop : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TitleBC;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell32;
    private XRTable xrTable2;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTable xrTable3;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell33;
    private XRTable xrTable4;
    private XRTableRow xrTableRow5;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_macanbo;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_chucvu;
    private XRTableCell xrt_ngayvaodonvi;
    private XRTableCell xrt_thang1thunhap;
    private XRTableCell xrt_thang2thunhap;
    private XRTableCell xrt_thang3thunhap;
    private XRTableCell xrt_thang4thunhap;
    private XRTableCell xrt_thang5thunhap;
    private XRTableCell xrt_thang6thunhap;
    private XRTableCell xrt_thang7thunhap;
    private XRTableCell xrt_thang8thunhap;
    private XRTableCell xrt_thang9thunhap;
    private XRTableCell xrt_thang10thunhap;
    private XRTableCell xrt_thang11thunhap;
    private XRTableCell xrt_thang12thunhap;
    private XRTableCell xrt_tongthunhapchiuthue;
    private XRTableCell xrt_thang1nop;
    private XRTableCell xrt_thang2nop;
    private XRTableCell xrt_thang3nop;
    private XRTableCell xrt_thang4nop;
    private XRTableCell xrt_thang5nop;
    private XRTableCell xrt_thang6nop;
    private XRTableCell xrt_thang7nop;
    private XRTableCell xrt_thang8nop;
    private XRTableCell xrt_thang9nop;
    private XRTableCell xrt_thang10nop;
    private XRTableCell xrt_thang11nop;
    private XRTableCell xrt_thang12nop;
    private XRTableCell xrt_tongthuenop;
    private XRTableCell xrTableCell36;
    private XRTable xrTable5;
    private XRTableRow xrTableRow6;
    private XRTableCell xrt_donvi;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer1;
    private XRPageInfo xrPageInfo1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BangTongHopThuNhapVaChiuThueVaThueDaNop()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    public void BinData(ReportFilter rp)
    {

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
            string resourceFileName = "rp_BangTongHopThuNhapVaChiuThueVaThueDaNop.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macanbo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayvaodonvi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang1thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang2thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang3thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang4thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang5thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang6thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang7thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang8thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang9thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang10thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang11thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang12thunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongthunhapchiuthue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang1nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang2nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang3nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang4nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang5nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang6nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang7nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang8nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang9nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang10nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang11nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang12nop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongthuenop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_donvi = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable4.SizeF = new System.Drawing.SizeF(2337F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_macanbo,
            this.xrt_hovaten,
            this.xrt_chucvu,
            this.xrt_ngayvaodonvi,
            this.xrt_thang1thunhap,
            this.xrt_thang2thunhap,
            this.xrt_thang3thunhap,
            this.xrt_thang4thunhap,
            this.xrt_thang5thunhap,
            this.xrt_thang6thunhap,
            this.xrt_thang7thunhap,
            this.xrt_thang8thunhap,
            this.xrt_thang9thunhap,
            this.xrt_thang10thunhap,
            this.xrt_thang11thunhap,
            this.xrt_thang12thunhap,
            this.xrt_tongthunhapchiuthue,
            this.xrt_thang1nop,
            this.xrt_thang2nop,
            this.xrt_thang3nop,
            this.xrt_thang4nop,
            this.xrt_thang5nop,
            this.xrt_thang6nop,
            this.xrt_thang7nop,
            this.xrt_thang8nop,
            this.xrt_thang9nop,
            this.xrt_thang10nop,
            this.xrt_thang11nop,
            this.xrt_thang12nop,
            this.xrt_tongthuenop,
            this.xrTableCell36});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseTextAlignment = false;
            this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_stt.Weight = 0.049540332407333132D;
            // 
            // xrt_macanbo
            // 
            this.xrt_macanbo.Name = "xrt_macanbo";
            this.xrt_macanbo.Weight = 0.096342074549703116D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hovaten.StylePriority.UsePadding = false;
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.14715474316030169D;
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_chucvu.StylePriority.UsePadding = false;
            this.xrt_chucvu.StylePriority.UseTextAlignment = false;
            this.xrt_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_chucvu.Weight = 0.11238832681873798D;
            // 
            // xrt_ngayvaodonvi
            // 
            this.xrt_ngayvaodonvi.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_ngayvaodonvi.Name = "xrt_ngayvaodonvi";
            this.xrt_ngayvaodonvi.StylePriority.UseBorders = false;
            this.xrt_ngayvaodonvi.StylePriority.UseTextAlignment = false;
            this.xrt_ngayvaodonvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngayvaodonvi.Weight = 0.10710400641347079D;
            // 
            // xrt_thang1thunhap
            // 
            this.xrt_thang1thunhap.Name = "xrt_thang1thunhap";
            this.xrt_thang1thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang1thunhap.StylePriority.UsePadding = false;
            this.xrt_thang1thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang1thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang1thunhap.Weight = 0.099032165762395707D;
            // 
            // xrt_thang2thunhap
            // 
            this.xrt_thang2thunhap.Name = "xrt_thang2thunhap";
            this.xrt_thang2thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang2thunhap.StylePriority.UsePadding = false;
            this.xrt_thang2thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang2thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang2thunhap.Weight = 0.0792165322848554D;
            // 
            // xrt_thang3thunhap
            // 
            this.xrt_thang3thunhap.Name = "xrt_thang3thunhap";
            this.xrt_thang3thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang3thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang3thunhap.Weight = 0.095217683961057842D;
            // 
            // xrt_thang4thunhap
            // 
            this.xrt_thang4thunhap.Name = "xrt_thang4thunhap";
            this.xrt_thang4thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang4thunhap.StylePriority.UsePadding = false;
            this.xrt_thang4thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang4thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang4thunhap.Weight = 0.081130765981025352D;
            // 
            // xrt_thang5thunhap
            // 
            this.xrt_thang5thunhap.Name = "xrt_thang5thunhap";
            this.xrt_thang5thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang5thunhap.StylePriority.UsePadding = false;
            this.xrt_thang5thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang5thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang5thunhap.Weight = 0.092234776782132558D;
            // 
            // xrt_thang6thunhap
            // 
            this.xrt_thang6thunhap.Name = "xrt_thang6thunhap";
            this.xrt_thang6thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang6thunhap.StylePriority.UsePadding = false;
            this.xrt_thang6thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang6thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang6thunhap.Weight = 0.0819300980867868D;
            // 
            // xrt_thang7thunhap
            // 
            this.xrt_thang7thunhap.Name = "xrt_thang7thunhap";
            this.xrt_thang7thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang7thunhap.StylePriority.UsePadding = false;
            this.xrt_thang7thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang7thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang7thunhap.Weight = 0.098468274911040682D;
            // 
            // xrt_thang8thunhap
            // 
            this.xrt_thang8thunhap.Name = "xrt_thang8thunhap";
            this.xrt_thang8thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang8thunhap.StylePriority.UsePadding = false;
            this.xrt_thang8thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang8thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang8thunhap.Weight = 0.0935354746964226D;
            // 
            // xrt_thang9thunhap
            // 
            this.xrt_thang9thunhap.Name = "xrt_thang9thunhap";
            this.xrt_thang9thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang9thunhap.StylePriority.UsePadding = false;
            this.xrt_thang9thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang9thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang9thunhap.Weight = 0.090315498650762632D;
            // 
            // xrt_thang10thunhap
            // 
            this.xrt_thang10thunhap.Name = "xrt_thang10thunhap";
            this.xrt_thang10thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang10thunhap.StylePriority.UsePadding = false;
            this.xrt_thang10thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang10thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang10thunhap.Weight = 0.08146352088497294D;
            // 
            // xrt_thang11thunhap
            // 
            this.xrt_thang11thunhap.Name = "xrt_thang11thunhap";
            this.xrt_thang11thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang11thunhap.StylePriority.UsePadding = false;
            this.xrt_thang11thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang11thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang11thunhap.Weight = 0.0827304508933972D;
            // 
            // xrt_thang12thunhap
            // 
            this.xrt_thang12thunhap.Name = "xrt_thang12thunhap";
            this.xrt_thang12thunhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang12thunhap.StylePriority.UsePadding = false;
            this.xrt_thang12thunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thang12thunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang12thunhap.Weight = 0.088387208970428566D;
            // 
            // xrt_tongthunhapchiuthue
            // 
            this.xrt_tongthunhapchiuthue.Name = "xrt_tongthunhapchiuthue";
            this.xrt_tongthunhapchiuthue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_tongthunhapchiuthue.StylePriority.UsePadding = false;
            this.xrt_tongthunhapchiuthue.StylePriority.UseTextAlignment = false;
            this.xrt_tongthunhapchiuthue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tongthunhapchiuthue.Weight = 0.11823833769184938D;
            // 
            // xrt_thang1nop
            // 
            this.xrt_thang1nop.Name = "xrt_thang1nop";
            this.xrt_thang1nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang1nop.StylePriority.UsePadding = false;
            this.xrt_thang1nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang1nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang1nop.Weight = 0.085301605819584625D;
            // 
            // xrt_thang2nop
            // 
            this.xrt_thang2nop.Name = "xrt_thang2nop";
            this.xrt_thang2nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang2nop.StylePriority.UsePadding = false;
            this.xrt_thang2nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang2nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang2nop.Weight = 0.085301762520884353D;
            // 
            // xrt_thang3nop
            // 
            this.xrt_thang3nop.Name = "xrt_thang3nop";
            this.xrt_thang3nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang3nop.StylePriority.UsePadding = false;
            this.xrt_thang3nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang3nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang3nop.Weight = 0.092244256598652541D;
            // 
            // xrt_thang4nop
            // 
            this.xrt_thang4nop.Name = "xrt_thang4nop";
            this.xrt_thang4nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang4nop.StylePriority.UsePadding = false;
            this.xrt_thang4nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang4nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang4nop.Weight = 0.086521369042843382D;
            // 
            // xrt_thang5nop
            // 
            this.xrt_thang5nop.Name = "xrt_thang5nop";
            this.xrt_thang5nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang5nop.StylePriority.UsePadding = false;
            this.xrt_thang5nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang5nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang5nop.Weight = 0.0989054727615533D;
            // 
            // xrt_thang6nop
            // 
            this.xrt_thang6nop.Name = "xrt_thang6nop";
            this.xrt_thang6nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang6nop.StylePriority.UsePadding = false;
            this.xrt_thang6nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang6nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang6nop.Weight = 0.092103382742297818D;
            // 
            // xrt_thang7nop
            // 
            this.xrt_thang7nop.Name = "xrt_thang7nop";
            this.xrt_thang7nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang7nop.StylePriority.UsePadding = false;
            this.xrt_thang7nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang7nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang7nop.Weight = 0.086661930108713092D;
            // 
            // xrt_thang8nop
            // 
            this.xrt_thang8nop.Name = "xrt_thang8nop";
            this.xrt_thang8nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang8nop.StylePriority.UsePadding = false;
            this.xrt_thang8nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang8nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang8nop.Weight = 0.09890578616415277D;
            // 
            // xrt_thang9nop
            // 
            this.xrt_thang9nop.Name = "xrt_thang9nop";
            this.xrt_thang9nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang9nop.StylePriority.UsePadding = false;
            this.xrt_thang9nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang9nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang9nop.Weight = 0.10938542063643293D;
            // 
            // xrt_thang10nop
            // 
            this.xrt_thang10nop.Name = "xrt_thang10nop";
            this.xrt_thang10nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang10nop.StylePriority.UsePadding = false;
            this.xrt_thang10nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang10nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang10nop.Weight = 0.091700190298058412D;
            // 
            // xrt_thang11nop
            // 
            this.xrt_thang11nop.Name = "xrt_thang11nop";
            this.xrt_thang11nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang11nop.StylePriority.UsePadding = false;
            this.xrt_thang11nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang11nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang11nop.Weight = 0.095781318948571892D;
            // 
            // xrt_thang12nop
            // 
            this.xrt_thang12nop.Name = "xrt_thang12nop";
            this.xrt_thang12nop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_thang12nop.StylePriority.UsePadding = false;
            this.xrt_thang12nop.StylePriority.UseTextAlignment = false;
            this.xrt_thang12nop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thang12nop.Weight = 0.080817441732188688D;
            // 
            // xrt_tongthuenop
            // 
            this.xrt_tongthuenop.Name = "xrt_tongthuenop";
            this.xrt_tongthuenop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrt_tongthuenop.StylePriority.UsePadding = false;
            this.xrt_tongthuenop.StylePriority.UseTextAlignment = false;
            this.xrt_tongthuenop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tongthuenop.Weight = 0.11609184451219512D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell36.StylePriority.UsePadding = false;
            this.xrTableCell36.StylePriority.UseTextAlignment = false;
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell36.Weight = 0.085847945207196741D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 47F;
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
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 95F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 67.00001F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(2317F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BẢNG TỔNG HỢP THU NHẬP CHỊU THUẾ VÀ THUẾ ĐÃ NỘP CBNV TRONG NĂM 2013";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(616.5834F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(616.5834F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrTable2,
            this.xrTable3});
            this.PageHeader.HeightF = 75F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(399.2605F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1870.864F, 75F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32,
            this.xrTableCell62});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "THU NHẬP CHỊU THUẾ";
            this.xrTableCell32.Weight = 1.6635888621830033D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Text = "THUẾ TNCN ĐÃ NỘP";
            this.xrTableCell62.Weight = 1.7168242879415923D;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrTableCell6,
            this.xrTableCell13,
            this.xrTableCell5,
            this.xrTableCell19,
            this.xrTableCell14,
            this.xrTableCell18,
            this.xrTableCell7,
            this.xrTableCell17,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell3,
            this.xrTableCell2,
            this.xrTableCell28,
            this.xrTableCell24,
            this.xrTableCell29,
            this.xrTableCell23,
            this.xrTableCell30,
            this.xrTableCell25,
            this.xrTableCell31,
            this.xrTableCell21,
            this.xrTableCell26,
            this.xrTableCell22,
            this.xrTableCell27,
            this.xrTableCell20,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Tháng 1";
            this.xrTableCell12.Weight = 0.13939299157055413D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Tháng 2";
            this.xrTableCell6.Weight = 0.11150160412680406D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "Tháng 3";
            this.xrTableCell13.Weight = 0.13402387099707547D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Tháng 4";
            this.xrTableCell5.Weight = 0.11419590645344224D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "Tháng5";
            this.xrTableCell19.Weight = 0.12982551243633447D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Tháng 6";
            this.xrTableCell14.Weight = 0.11532089513520799D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "Tháng 7";
            this.xrTableCell18.Weight = 0.13859957331582484D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Tháng 8";
            this.xrTableCell7.Weight = 0.13165598376314019D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Tháng 9";
            this.xrTableCell17.Weight = 0.12712424268409919D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Tháng 10";
            this.xrTableCell15.Weight = 0.11466455634874645D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Tháng 11";
            this.xrTableCell16.Weight = 0.11644710548950667D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Tháng 12";
            this.xrTableCell3.Weight = 0.12440943968827989D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Tổng thu nhập chịu thuế";
            this.xrTableCell2.Weight = 0.16642715913705383D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "Tháng 1";
            this.xrTableCell28.Weight = 0.12006669951712384D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "Tháng 2";
            this.xrTableCell24.Weight = 0.12006647512316704D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "Tháng 3";
            this.xrTableCell29.Weight = 0.1298390563358279D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Text = "Tháng 4";
            this.xrTableCell23.Weight = 0.12178311694194288D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Text = "Tháng 5";
            this.xrTableCell30.Weight = 0.13921490903286374D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Text = "Tháng 6";
            this.xrTableCell25.Weight = 0.1296409445212168D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "Tháng 7";
            this.xrTableCell31.Weight = 0.12198139705202159D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "Tháng 8";
            this.xrTableCell21.Weight = 0.13921490903286377D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Text = "Tháng 9";
            this.xrTableCell26.Weight = 0.15396567083456933D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "Tháng 10";
            this.xrTableCell22.Weight = 0.12907320041866863D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Text = "Tháng 11";
            this.xrTableCell27.Weight = 0.13481768571278627D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "Tháng 12";
            this.xrTableCell20.Weight = 0.1137547225636594D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Tổng thuế TNCN đã nộp";
            this.xrTableCell4.Weight = 0.16340552189181443D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(399.2605F, 74.99999F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell1,
            this.xrTableCell11,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Số TT";
            this.xrTableCell10.Weight = 0.27222069792556125D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Mã CBNV";
            this.xrTableCell1.Weight = 0.52939075920437983D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Họ và tên";
            this.xrTableCell11.Weight = 0.80860431032627034D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Chức vụ";
            this.xrTableCell8.Weight = 0.61756346734786138D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.Text = "Ngày vào\r\n đơn vị";
            this.xrTableCell9.Weight = 0.58852789119063154D;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(2270.125F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable3.SizeF = new System.Drawing.SizeF(66.87524F, 74.99999F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell33.Multiline = true;
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseBorders = false;
            this.xrTableCell33.Text = "Ghi chú";
            this.xrTableCell33.Weight = 2.8163071259947041D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten1,
            this.xrl_ten2,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer3,
            this.xrl_footer2,
            this.xrl_footer1});
            this.ReportFooter.HeightF = 160.5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(78.04171F, 137.5F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 137.5F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1936.792F, 137.5F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(333.3329F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1936.792F, 23.95833F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(333.3329F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = " ngày.......tháng.......năm......";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1936.792F, 48.95833F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(333.3329F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "Giám đốc";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(1012.5F, 48.95833F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "Kế toán trưởng";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(78.04171F, 48.95833F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "Người lập biểu";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2210.958F, 36.45833F);
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
            this.xrTable5});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable5
            // 
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-05F, 0F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable5.SizeF = new System.Drawing.SizeF(2337F, 25F);
            this.xrTable5.StylePriority.UseBorders = false;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_donvi});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrt_donvi
            // 
            this.xrt_donvi.Name = "xrt_donvi";
            this.xrt_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
            this.xrt_donvi.StylePriority.UsePadding = false;
            this.xrt_donvi.StylePriority.UseTextAlignment = false;
            this.xrt_donvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_donvi.Weight = 3D;
            // 
            // rp_BangTongHopThuNhapVaChiuThueVaThueDaNop
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
            this.Margins = new System.Drawing.Printing.Margins(0, 2, 47, 100);
            this.PageHeight = 1654;
            this.PageWidth = 2339;
            this.PaperKind = System.Drawing.Printing.PaperKind.A2;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
