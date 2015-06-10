using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rpwg_ThongKeNhanSuDieuChuyen
/// </summary>
public class rpwg_ThongKeNhanSuDieuChuyen : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_report_title;
    private XRLabel xrLabel2;
    private XRLabel xrl_tencty;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrtPhongCu;
    private XRTableCell xrtPhongMoi;
    private XRTableCell xrtNgayChuyen;
    private XRTableCell xrtHoTen;
    private XRTableCell xrtChucVuCu;
    private XRTableCell xrtBPMoi;
    private XRTableCell xrtChiNhanh;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell20;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell21;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrtBPCu;
    private XRTableCell xrtChucVuMoi;
    private XRTableCell xrtSoQuyetDinh;
    private XRTableCell xrtPhuCap;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rpwg_ThongKeNhanSuDieuChuyen()
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

    public void BindData(ReportFilterEmployeeProfile filter)
    {
        try
        {
            xrl_tencty.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartmentID);

            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("WG_GetNhanSuDieuChuyen", "@TuNgay", "@DenNgay", filter.TuNgay, filter.DenNgay);

            // bind data
            DataSource = table;
            xrtHoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrtNgayChuyen.DataBindings.Add("Text", DataSource, "NgayCoHieuLuc", "{0:dd/MM/yyyy}");
            // bộ phận cũ
            xrtPhongCu.DataBindings.Add("Text", DataSource, "ChiNhanhCu");
            xrtBPCu.DataBindings.Add("Text", DataSource, "BoPhanCu");
            xrtChucVuCu.DataBindings.Add("Text", DataSource, "ChucVuCu");
            // bộ phận mới
            xrtPhongMoi.DataBindings.Add("Text", DataSource, "ChiNhanhMoi");
            xrtBPMoi.DataBindings.Add("Text", DataSource, "BoPhanMoi");
            xrtChucVuMoi.DataBindings.Add("Text", DataSource, "ChucVuMoi");

            xrtSoQuyetDinh.DataBindings.Add("Text", DataSource, "SoQuyetDinh");

            if (!string.IsNullOrEmpty(filter.ReportTitle))
                xrl_report_title.Text = filter.ReportTitle;
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
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
        string resourceFileName = "rpwg_ThongKeNhanSuDieuChuyen.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtHoTen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtNgayChuyen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtPhongCu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtBPCu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtChucVuCu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtPhongMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtBPMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtChucVuMoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtSoQuyetDinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtPhuCap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtChiNhanh = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_report_title = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_tencty = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
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
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1001F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UsePadding = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtHoTen,
            this.xrtNgayChuyen,
            this.xrtPhongCu,
            this.xrtBPCu,
            this.xrtChucVuCu,
            this.xrtPhongMoi,
            this.xrtBPMoi,
            this.xrtChucVuMoi,
            this.xrtSoQuyetDinh,
            this.xrtPhuCap,
            this.xrtChiNhanh});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrtstt
        // 
        this.xrtstt.Name = "xrtstt";
        this.xrtstt.Weight = 0.0749250596815294D;
        this.xrtstt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrtHoTen
        // 
        this.xrtHoTen.Name = "xrtHoTen";
        this.xrtHoTen.Weight = 0.4250749403184706D;
        // 
        // xrtNgayChuyen
        // 
        this.xrtNgayChuyen.Name = "xrtNgayChuyen";
        this.xrtNgayChuyen.Weight = 0.29970022348257214D;
        // 
        // xrtPhongCu
        // 
        this.xrtPhongCu.Name = "xrtPhongCu";
        this.xrtPhongCu.Weight = 0.16483508099566452D;
        // 
        // xrtBPCu
        // 
        this.xrtBPCu.Name = "xrtBPCu";
        this.xrtBPCu.Weight = 0.19480529388824069D;
        // 
        // xrtChucVuCu
        // 
        this.xrtChucVuCu.Name = "xrtChucVuCu";
        this.xrtChucVuCu.Weight = 0.23976016354251217D;
        // 
        // xrtPhongMoi
        // 
        this.xrtPhongMoi.Name = "xrtPhongMoi";
        this.xrtPhongMoi.Weight = 0.16483518007871056D;
        // 
        // xrtBPMoi
        // 
        this.xrtBPMoi.Name = "xrtBPMoi";
        this.xrtBPMoi.Weight = 0.19480501569353492D;
        // 
        // xrtChucVuMoi
        // 
        this.xrtChucVuMoi.Name = "xrtChucVuMoi";
        this.xrtChucVuMoi.Weight = 0.23976042458822905D;
        // 
        // xrtSoQuyetDinh
        // 
        this.xrtSoQuyetDinh.Name = "xrtSoQuyetDinh";
        this.xrtSoQuyetDinh.Weight = 0.38011982009841966D;
        // 
        // xrtPhuCap
        // 
        this.xrtPhuCap.Name = "xrtPhuCap";
        this.xrtPhuCap.Weight = 0.28471565151309869D;
        // 
        // xrtChiNhanh
        // 
        this.xrtChiNhanh.Name = "xrtChiNhanh";
        this.xrtChiNhanh.Weight = 0.33666314611901771D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 44F;
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
            this.xrl_report_title,
            this.xrLabel2,
            this.xrl_tencty});
        this.ReportHeader.HeightF = 110F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_report_title
        // 
        this.xrl_report_title.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrl_report_title.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65.625F);
        this.xrl_report_title.Name = "xrl_report_title";
        this.xrl_report_title.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_report_title.SizeF = new System.Drawing.SizeF(1001F, 23F);
        this.xrl_report_title.StylePriority.UseFont = false;
        this.xrl_report_title.StylePriority.UseTextAlignment = false;
        this.xrl_report_title.Text = "THỐNG KÊ NHÂN SỰ ĐIỀU CHUYỂN TRONG TUẦN";
        this.xrl_report_title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "PHÒNG HÀNH CHÍNH NHÂN SỰ";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_tencty
        // 
        this.xrl_tencty.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrl_tencty.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_tencty.Name = "xrl_tencty";
        this.xrl_tencty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_tencty.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
        this.xrl_tencty.StylePriority.UseFont = false;
        this.xrl_tencty.StylePriority.UseTextAlignment = false;
        this.xrl_tencty.Text = "CÔNG TY CỔ PHẦN THẾ GIỚI GIẢI TRÍ";
        this.xrl_tencty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 74F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1001F, 74F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell8,
            this.xrTableCell4,
            this.xrTableCell2,
            this.xrTableCell5,
            this.xrTableCell3,
            this.xrTableCell6,
            this.xrTableCell7});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "TT";
        this.xrTableCell1.Weight = 0.074925071114188543D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Họ và tên";
        this.xrTableCell8.Weight = 0.4250749288858115D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Multiline = true;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Ngày điều\r\nđộng/ chuyển";
        this.xrTableCell4.Weight = 0.299700292078527D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable3});
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Weight = 0.59940059177882676D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(199.9999F, 25F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.Text = "Nơi đi";
        this.xrTableCell20.Weight = 3D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(200F, 49F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Multiline = true;
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.Text = "CN/\r\nPhòng";
        this.xrTableCell17.Weight = 0.82500003814697265D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Text = "BP";
        this.xrTableCell18.Weight = 0.97499998092651374D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell19.Multiline = true;
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.Text = "Chức\r\ndanh";
        this.xrTableCell19.Weight = 1.1999999809265136D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5,
            this.xrTable6});
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Weight = 0.59940061464414485D;
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(199.9999F, 25F);
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseBorders = false;
        this.xrTableCell21.Text = "Nơi nhận";
        this.xrTableCell21.Weight = 3D;
        // 
        // xrTable6
        // 
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(200F, 49F);
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell22.Multiline = true;
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseBorders = false;
        this.xrTableCell22.Text = "CN/\r\nPhòng";
        this.xrTableCell22.Weight = 0.82500003814697265D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Text = "BP";
        this.xrTableCell23.Weight = 0.97499998092651374D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell24.Multiline = true;
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseBorders = false;
        this.xrTableCell24.Text = "Chức\r\ndanh";
        this.xrTableCell24.Weight = 1.1999999809265136D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Quyết định số";
        this.xrTableCell3.Weight = 0.38011983438924357D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Multiline = true;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Phụ cấp \r\n(nếu có)";
        this.xrTableCell6.Weight = 0.28471529233705745D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "CHI NHÁNH";
        this.xrTableCell7.Weight = 0.33666337477220043D;
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
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(874.9586F, 39.58333F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0414F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // rpwg_ThongKeNhanSuDieuChuyen
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(50, 49, 44, 0);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
