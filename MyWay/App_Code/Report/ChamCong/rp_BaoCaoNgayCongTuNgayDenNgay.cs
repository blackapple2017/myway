using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_BaoCaoNgayCongTuNgayDenNgay
/// </summary>
public class rp_BaoCaoNgayCongTuNgayDenNgay : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell26;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell8;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell9;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell51;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell52;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrt_thang2hl;
    private XRTableCell xrt_thang8khl;
    private XRTableCell xrTableCell55;
    private XRTableCell xrt_chucvu;
    private XRTableCell xrt_macanbo;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hoten;
    private XRTableCell xrTableCell60;
    private XRTableCell xrt_ngayvaodonvi;
    private XRTableCell xrt_thang1hl;
    private XRTableCell xrt_tonghl;
    private XRTableCell xrt_thang4hl;
    private XRTableCell xrt_thang5hl;
    private XRTableCell xrt_thang3hl;
    private XRTableCell xrt_thang8hl;
    private XRTableCell xrt_thang6hl;
    private XRTableCell xrt_thang7hl;
    private XRTableCell xrt_thang9hl;
    private XRTableCell xrt_thang10hl;
    private XRTableCell xrt_thang11hl;
    private XRTableCell xrt_thang12hl;
    private XRTableCell xrt_thang4khl;
    private XRTableCell xrt_thang6khl;
    private XRTableCell xrt_thang2khl;
    private XRTableCell xrt_thang3khl;
    private XRTableCell xrt_thang1khl;
    private XRTableCell xrt_thang5khl;
    private XRTableCell xrt_thang7khl;
    private XRTableCell xrt_thang3kbh;
    private XRTableCell xrt_thang12khl;
    private XRTableCell xrt_thang10khl;
    private XRTableCell xrt_thang11khl;
    private XRTableCell xrt_thang9khl;
    private XRTableCell xrt_thang1kbh;
    private XRTableCell xrt_tongkhl;
    private XRTableCell xrt_thang2kbh;
    private XRTableCell xrt_thang7kbh;
    private XRTableCell xrt_thang5kbh;
    private XRTableCell xrt_thang4kbh;
    private XRTableCell xrt_thang6kbh;
    private XRTableCell xrt_thang8kbh;
    private XRTableCell xrt_thang11kbh;
    private XRTableCell xrt_thang10kbh;
    private XRTableCell xrt_thang9kbh;
    private XRTableCell xrt_thang12kbh;
    private XRTableCell xrt_tongkbh;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell53;
    private XRPageInfo xrPageInfo1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BaoCaoNgayCongTuNgayDenNgay()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}

    public void BindData(ReportFilter rp)
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
            string resourceFileName = "rp_BaoCaoNgayCongTuNgayDenNgay.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macanbo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayvaodonvi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang1hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang2hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang3hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang4hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang5hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang6hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang7hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang8hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang9hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang10hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang11hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang12hl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tonghl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang1khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang2khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang3khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang4khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang5khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang6khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang7khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang8khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang9khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang10khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang11khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang12khl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongkhl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang1kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang2kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang3kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang4kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang5kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang6kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang7kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang8kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang9kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang10kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang11kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang12kbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongkbh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable8
            // 
            this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable8.SizeF = new System.Drawing.SizeF(2312F, 25F);
            this.xrTable8.StylePriority.UseBorders = false;
            this.xrTable8.StylePriority.UseFont = false;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_macanbo,
            this.xrt_hoten,
            this.xrt_chucvu,
            this.xrt_ngayvaodonvi,
            this.xrTableCell60,
            this.xrt_thang1hl,
            this.xrt_thang2hl,
            this.xrt_thang3hl,
            this.xrt_thang4hl,
            this.xrt_thang5hl,
            this.xrt_thang6hl,
            this.xrt_thang7hl,
            this.xrt_thang8hl,
            this.xrt_thang9hl,
            this.xrt_thang10hl,
            this.xrt_thang11hl,
            this.xrt_thang12hl,
            this.xrt_tonghl,
            this.xrt_thang1khl,
            this.xrt_thang2khl,
            this.xrt_thang3khl,
            this.xrt_thang4khl,
            this.xrt_thang5khl,
            this.xrt_thang6khl,
            this.xrt_thang7khl,
            this.xrt_thang8khl,
            this.xrt_thang9khl,
            this.xrt_thang10khl,
            this.xrt_thang11khl,
            this.xrt_thang12khl,
            this.xrt_tongkhl,
            this.xrt_thang1kbh,
            this.xrt_thang2kbh,
            this.xrt_thang3kbh,
            this.xrt_thang4kbh,
            this.xrt_thang5kbh,
            this.xrt_thang6kbh,
            this.xrt_thang7kbh,
            this.xrt_thang8kbh,
            this.xrt_thang9kbh,
            this.xrt_thang10kbh,
            this.xrt_thang11kbh,
            this.xrt_thang12kbh,
            this.xrt_tongkbh,
            this.xrTableCell55});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseTextAlignment = false;
            this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_stt.Weight = 0.055663885954754577D;
            // 
            // xrt_macanbo
            // 
            this.xrt_macanbo.Name = "xrt_macanbo";
            this.xrt_macanbo.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_macanbo.StylePriority.UsePadding = false;
            this.xrt_macanbo.StylePriority.UseTextAlignment = false;
            this.xrt_macanbo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_macanbo.Weight = 0.13792885876031896D;
            // 
            // xrt_hoten
            // 
            this.xrt_hoten.Name = "xrt_hoten";
            this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hoten.StylePriority.UsePadding = false;
            this.xrt_hoten.StylePriority.UseTextAlignment = false;
            this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hoten.Weight = 0.20729788941908048D;
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_chucvu.StylePriority.UsePadding = false;
            this.xrt_chucvu.StylePriority.UseTextAlignment = false;
            this.xrt_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_chucvu.Weight = 0.18402340832878561D;
            // 
            // xrt_ngayvaodonvi
            // 
            this.xrt_ngayvaodonvi.Name = "xrt_ngayvaodonvi";
            this.xrt_ngayvaodonvi.StylePriority.UseTextAlignment = false;
            this.xrt_ngayvaodonvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngayvaodonvi.Weight = 0.11509310910446009D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Weight = 0.12419500812939706D;
            // 
            // xrt_thang1hl
            // 
            this.xrt_thang1hl.Name = "xrt_thang1hl";
            this.xrt_thang1hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang1hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang1hl.Weight = 0.041192792278672577D;
            // 
            // xrt_thang2hl
            // 
            this.xrt_thang2hl.Name = "xrt_thang2hl";
            this.xrt_thang2hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang2hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang2hl.Weight = 0.05606068211855772D;
            // 
            // xrt_thang3hl
            // 
            this.xrt_thang3hl.Name = "xrt_thang3hl";
            this.xrt_thang3hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang3hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang3hl.Weight = 0.052005919618177576D;
            // 
            // xrt_thang4hl
            // 
            this.xrt_thang4hl.Name = "xrt_thang4hl";
            this.xrt_thang4hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang4hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang4hl.Weight = 0.056061008809759533D;
            // 
            // xrt_thang5hl
            // 
            this.xrt_thang5hl.Name = "xrt_thang5hl";
            this.xrt_thang5hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang5hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang5hl.Weight = 0.057412421414596404D;
            // 
            // xrt_thang6hl
            // 
            this.xrt_thang6hl.Name = "xrt_thang6hl";
            this.xrt_thang6hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang6hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang6hl.Weight = 0.0574125105121969D;
            // 
            // xrt_thang7hl
            // 
            this.xrt_thang7hl.Name = "xrt_thang7hl";
            this.xrt_thang7hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang7hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang7hl.Weight = 0.057412512162152464D;
            // 
            // xrt_thang8hl
            // 
            this.xrt_thang8hl.Name = "xrt_thang8hl";
            this.xrt_thang8hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang8hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang8hl.Weight = 0.060115772960095272D;
            // 
            // xrt_thang9hl
            // 
            this.xrt_thang9hl.Name = "xrt_thang9hl";
            this.xrt_thang9hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang9hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang9hl.Weight = 0.057328481575197016D;
            // 
            // xrt_thang10hl
            // 
            this.xrt_thang10hl.Name = "xrt_thang10hl";
            this.xrt_thang10hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang10hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang10hl.Weight = 0.052090019503266756D;
            // 
            // xrt_thang11hl
            // 
            this.xrt_thang11hl.Name = "xrt_thang11hl";
            this.xrt_thang11hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang11hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang11hl.Weight = 0.04795098139752979D;
            // 
            // xrt_thang12hl
            // 
            this.xrt_thang12hl.Name = "xrt_thang12hl";
            this.xrt_thang12hl.StylePriority.UseTextAlignment = false;
            this.xrt_thang12hl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang12hl.Weight = 0.047629280073832485D;
            // 
            // xrt_tonghl
            // 
            this.xrt_tonghl.Name = "xrt_tonghl";
            this.xrt_tonghl.StylePriority.UseTextAlignment = false;
            this.xrt_tonghl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tonghl.Weight = 0.046277530878060427D;
            // 
            // xrt_thang1khl
            // 
            this.xrt_thang1khl.Name = "xrt_thang1khl";
            this.xrt_thang1khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang1khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang1khl.Weight = 0.040946404414193435D;
            // 
            // xrt_thang2khl
            // 
            this.xrt_thang2khl.Name = "xrt_thang2khl";
            this.xrt_thang2khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang2khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang2khl.Weight = 0.055725043207716374D;
            // 
            // xrt_thang3khl
            // 
            this.xrt_thang3khl.Name = "xrt_thang3khl";
            this.xrt_thang3khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang3khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang3khl.Weight = 0.051694668700538286D;
            // 
            // xrt_thang4khl
            // 
            this.xrt_thang4khl.Name = "xrt_thang4khl";
            this.xrt_thang4khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang4khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang4khl.Weight = 0.05572536494905149D;
            // 
            // xrt_thang5khl
            // 
            this.xrt_thang5khl.Name = "xrt_thang5khl";
            this.xrt_thang5khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang5khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang5khl.Weight = 0.057068877566644478D;
            // 
            // xrt_thang6khl
            // 
            this.xrt_thang6khl.Name = "xrt_thang6khl";
            this.xrt_thang6khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang6khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang6khl.Weight = 0.057068560775176039D;
            // 
            // xrt_thang7khl
            // 
            this.xrt_thang7khl.Name = "xrt_thang7khl";
            this.xrt_thang7khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang7khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang7khl.Weight = 0.057068877566644478D;
            // 
            // xrt_thang8khl
            // 
            this.xrt_thang8khl.Name = "xrt_thang8khl";
            this.xrt_thang8khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang8khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang8khl.Weight = 0.059755902801830456D;
            // 
            // xrt_thang9khl
            // 
            this.xrt_thang9khl.Name = "xrt_thang9khl";
            this.xrt_thang9khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang9khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang9khl.Weight = 0.056985244618980108D;
            // 
            // xrt_thang10khl
            // 
            this.xrt_thang10khl.Name = "xrt_thang10khl";
            this.xrt_thang10khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang10khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang10khl.Weight = 0.051778385795936466D;
            // 
            // xrt_thang11khl
            // 
            this.xrt_thang11khl.Name = "xrt_thang11khl";
            this.xrt_thang11khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang11khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang11khl.Weight = 0.047663650710689967D;
            // 
            // xrt_thang12khl
            // 
            this.xrt_thang12khl.Name = "xrt_thang12khl";
            this.xrt_thang12khl.StylePriority.UseTextAlignment = false;
            this.xrt_thang12khl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang12khl.Weight = 0.047344171464649448D;
            // 
            // xrt_tongkhl
            // 
            this.xrt_tongkhl.Name = "xrt_tongkhl";
            this.xrt_tongkhl.StylePriority.UseTextAlignment = false;
            this.xrt_tongkhl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongkhl.Weight = 0.046000658847056453D;
            // 
            // xrt_thang1kbh
            // 
            this.xrt_thang1kbh.Name = "xrt_thang1kbh";
            this.xrt_thang1kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang1kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang1kbh.Weight = 0.041326074039234828D;
            // 
            // xrt_thang2kbh
            // 
            this.xrt_thang2kbh.Name = "xrt_thang2kbh";
            this.xrt_thang2kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang2kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang2kbh.Weight = 0.05624315070445976D;
            // 
            // xrt_thang3kbh
            // 
            this.xrt_thang3kbh.Name = "xrt_thang3kbh";
            this.xrt_thang3kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang3kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang3kbh.Weight = 0.052175073062672328D;
            // 
            // xrt_thang4kbh
            // 
            this.xrt_thang4kbh.Name = "xrt_thang4kbh";
            this.xrt_thang4kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang4kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang4kbh.Weight = 0.056242992308725509D;
            // 
            // xrt_thang5kbh
            // 
            this.xrt_thang5kbh.Name = "xrt_thang5kbh";
            this.xrt_thang5kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang5kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang5kbh.Weight = 0.057599018189321338D;
            // 
            // xrt_thang6kbh
            // 
            this.xrt_thang6kbh.Name = "xrt_thang6kbh";
            this.xrt_thang6kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang6kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang6kbh.Weight = 0.057599334980789757D;
            // 
            // xrt_thang7kbh
            // 
            this.xrt_thang7kbh.Name = "xrt_thang7kbh";
            this.xrt_thang7kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang7kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang7kbh.Weight = 0.057598859793587143D;
            // 
            // xrt_thang8kbh
            // 
            this.xrt_thang8kbh.Name = "xrt_thang8kbh";
            this.xrt_thang8kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang8kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang8kbh.Weight = 0.060311241545891653D;
            // 
            // xrt_thang9kbh
            // 
            this.xrt_thang9kbh.Name = "xrt_thang9kbh";
            this.xrt_thang9kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang9kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang9kbh.Weight = 0.0575147392840534D;
            // 
            // xrt_thang10kbh
            // 
            this.xrt_thang10kbh.Name = "xrt_thang10kbh";
            this.xrt_thang10kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang10kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang10kbh.Weight = 0.052259822205276224D;
            // 
            // xrt_thang11kbh
            // 
            this.xrt_thang11kbh.Name = "xrt_thang11kbh";
            this.xrt_thang11kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang11kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang11kbh.Weight = 0.0481063700877259D;
            // 
            // xrt_thang12kbh
            // 
            this.xrt_thang12kbh.Name = "xrt_thang12kbh";
            this.xrt_thang12kbh.StylePriority.UseTextAlignment = false;
            this.xrt_thang12kbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang12kbh.Weight = 0.047784005069402676D;
            // 
            // xrt_tongkbh
            // 
            this.xrt_tongkbh.Name = "xrt_tongkbh";
            this.xrt_tongkbh.StylePriority.UseTextAlignment = false;
            this.xrt_tongkbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongkbh.Weight = 0.0464282308070305D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Weight = 0.11083320350382982D;
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
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TenThanhPho,
            this.xrl_TitleBC,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 133F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(1016.667F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(2199.625F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO NGÀY CÔNG TỪ THÁNG 1 ĐẾN THÁNG 3";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(1016.667F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 64F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(2312F, 63.54167F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
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
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell10,
            this.xrTableCell8,
            this.xrTableCell12,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.30318265215335827D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Mã CBNV";
            this.xrTableCell2.Weight = 0.75125255155728354D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ và tên";
            this.xrTableCell4.Weight = 1.1290821412030381D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Chức vụ";
            this.xrTableCell5.Weight = 1.0023144341835102D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Ngày vào \r\nđơn vị\r\n";
            this.xrTableCell6.Weight = 0.6268734123797568D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Số năm làm việc tại đơn vị";
            this.xrTableCell7.Weight = 0.67644880959731846D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Weight = 3.7524820325716974D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(530.9509F, 32.29167F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell26});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "Ngày công hưởng lương trong năm";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell26.Weight = 3D;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.29167F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(530.9508F, 31.25F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20,
            this.xrTableCell17,
            this.xrTableCell21,
            this.xrTableCell14,
            this.xrTableCell22,
            this.xrTableCell18,
            this.xrTableCell23,
            this.xrTableCell15,
            this.xrTableCell24,
            this.xrTableCell19,
            this.xrTableCell25,
            this.xrTableCell16,
            this.xrTableCell50});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.Text = "T1";
            this.xrTableCell20.Weight = 0.17937205242428583D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "T2";
            this.xrTableCell17.Weight = 0.24411428202096355D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "T3";
            this.xrTableCell21.Weight = 0.22645693409822487D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "T4";
            this.xrTableCell14.Weight = 0.24411462688430458D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "T5";
            this.xrTableCell22.Weight = 0.25000006466187641D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "T6";
            this.xrTableCell18.Weight = 0.25000006466187646D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Text = "T7";
            this.xrTableCell23.Weight = 0.24999989223020591D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "T8";
            this.xrTableCell15.Weight = 0.26177128508036118D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "T9";
            this.xrTableCell24.Weight = 0.24963381979373037D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "T10";
            this.xrTableCell19.Weight = 0.22682421355639404D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Text = "T11";
            this.xrTableCell25.Weight = 0.20879988793090964D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "T12";
            this.xrTableCell16.Weight = 0.20739942664170466D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Text = "Tổng";
            this.xrTableCell50.Weight = 0.20151345001516249D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable5});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Weight = 3.73001479518326D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(527.772F, 32.29167F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Ngày công không hưởng lương trong năm";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 3D;
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.29167F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(527.7722F, 31.25F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36,
            this.xrTableCell51});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.Text = "T1";
            this.xrTableCell11.Weight = 0.17937205242428583D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "T2";
            this.xrTableCell13.Weight = 0.24411428202096355D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Text = "T3";
            this.xrTableCell27.Weight = 0.22645693409822487D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "T4";
            this.xrTableCell28.Weight = 0.24411462688430458D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "T5";
            this.xrTableCell29.Weight = 0.25000006466187641D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Text = "T6";
            this.xrTableCell30.Weight = 0.25000006466187646D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "T7";
            this.xrTableCell31.Weight = 0.24999989223020591D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "T8";
            this.xrTableCell32.Weight = 0.26177128508036118D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Text = "T9";
            this.xrTableCell33.Weight = 0.24963381979373037D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Text = "T10";
            this.xrTableCell34.Weight = 0.22682421355639404D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Text = "T11";
            this.xrTableCell35.Weight = 0.20879988793090964D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Text = "T12";
            this.xrTableCell36.Weight = 0.20739942664170466D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Text = "Tổng";
            this.xrTableCell51.Weight = 0.20151345001516249D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7,
            this.xrTable6});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.Weight = 3.7646779428950961D;
            // 
            // xrTable7
            // 
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0.0001220703F, 0F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable7.SizeF = new System.Drawing.SizeF(532.6764F, 32.29167F);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            this.xrTableCell49.Text = "Ngày công không hưởng BHXH";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell49.Weight = 3D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.29167F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(532.6765F, 31.25F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell52});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseBorders = false;
            this.xrTableCell37.Text = "T1";
            this.xrTableCell37.Weight = 0.17937205242428583D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "T2";
            this.xrTableCell38.Weight = 0.24411428202096355D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Text = "T3";
            this.xrTableCell39.Weight = 0.22645693409822487D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "T4";
            this.xrTableCell40.Weight = 0.24411462688430458D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Text = "T5";
            this.xrTableCell41.Weight = 0.25000006466187641D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Text = "T6";
            this.xrTableCell42.Weight = 0.25000006466187646D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Text = "T7";
            this.xrTableCell43.Weight = 0.24999989223020591D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Text = "T8";
            this.xrTableCell44.Weight = 0.26177128508036118D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Text = "T9";
            this.xrTableCell45.Weight = 0.24963381979373037D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Text = "T10";
            this.xrTableCell46.Weight = 0.22682421355639404D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Text = "T11";
            this.xrTableCell47.Weight = 0.20879988793090964D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Text = "T12";
            this.xrTableCell48.Weight = 0.20739942664170466D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Text = "Tổng";
            this.xrTableCell52.Weight = 0.20151345001516249D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Ghi chú";
            this.xrTableCell3.Weight = 0.60367122827568331D;
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
            this.ReportFooter.HeightF = 214F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1897.046F, 150F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(992.7083F, 125F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(97.91666F, 125F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1897.046F, 25F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(97.91666F, 25F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1897.046F, 50F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(281.9166F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(992.7083F, 25F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "PHÒNG TCHC";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable9});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable9
            // 
            this.xrTable9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.xrTable9.SizeF = new System.Drawing.SizeF(2312F, 25F);
            this.xrTable9.StylePriority.UseBorders = false;
            this.xrTable9.StylePriority.UseFont = false;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
            this.xrTableCell53.StylePriority.UseFont = false;
            this.xrTableCell53.StylePriority.UsePadding = false;
            this.xrTableCell53.StylePriority.UseTextAlignment = false;
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell53.Weight = 3.0000000000000004D;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2185.958F, 37.5F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // rp_BaoCaoNgayCongTuNgayDenNgay
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
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 48, 100);
            this.PageHeight = 1654;
            this.PageWidth = 2339;
            this.PaperKind = System.Drawing.Printing.PaperKind.A2;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
