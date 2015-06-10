using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using Ext.Net;

/// <summary>
/// Summary description for rp_BangKeChiuThueCaNhanKhongKyHopDong05B
/// </summary>
public class rp_BangKeChiuThueCaNhanKhongKyHopDong05B : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel4;
    private XRLabel xrLabel1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel3;
    private XRLabel xrLabel11;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRLabel xrLabel2;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_tinhgiamthue;
    private XRTableCell xrt_thuekhautru;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_masothue;
    private XRTableCell xrt_socmnd;
    private XRTableCell xrt_thunhapchiuthue;
    private XRLabel xrLabel28;
    private XRLabel xrLabel27;
    private XRLabel xrlNgayKetXuat;
    private XRLabel xrLabel25;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrl_tentochuc;
    private XRLabel xrlMaSoThue;
    private XRLabel xrl_kytinhthue;
    private XRLabel xrlNguoiBC3;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BangKeChiuThueCaNhanKhongKyHopDong05B()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrt_stt.Text = STT.ToString();
        STT++;
    }

    public void BindData(ReportFilter rp)
    {
        if (SoftCore.Util.GetInstance().IsDateNull(rp.StartDate) || SoftCore.Util.GetInstance().IsDateNull(rp.EndDate))
        {
            X.Msg.Alert("Thông báo", "Vui lòng nhập từ ngày đến ngày").Show();
            return;
        }
        xrl_kytinhthue.Text = new ReportController().CalculateTime(rp.StartDate.Value, rp.EndDate.Value);
        xrl_tentochuc.Text = rp.CompanyName;
        xrlMaSoThue.Text = rp.MaSoThue;
        DataTable dt = new DataTable();
        dt = DataHandler.GetInstance().ExecuteDataTable("BC_Thue_05AKK", "@MaDonVi", "@TuNgay", "@DenNgay", rp.SessionDepartment, rp.StartDate.Value, rp.EndDate.Value);
        DataSource = dt;

        xrt_hovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrt_masothue.DataBindings.Add("Text", DataSource, "MST_CANHAN");
        xrt_socmnd.DataBindings.Add("Text", DataSource, "SO_CMND");
        xrt_thunhapchiuthue.DataBindings.Add("Text", DataSource, "ThuNhapChiuThue", "{0:n0}");

        xrt_tinhgiamthue.DataBindings.Add("Text", DataSource, "ThuNhapTinhThue", "{0:n0}");
        // xrt_TNCT_LamCanCu.DataBindings.Add("Text", DataSource, "ThuNhapTinhThue", "{0:n0}");
        xrt_thuekhautru.DataBindings.Add("Text", DataSource, "SoThuePhaiNop", "{0:n0}");


        xrlNgayKetXuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        xrlNguoiBC3.Text = rp.Name3;
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
            string resourceFileName = "rp_BangKeChiuThueCaNhanKhongKyHopDong05B.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_BangKeChiuThueCaNhanKhongKyHopDong05B.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_masothue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_socmnd = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thunhapchiuthue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tinhgiamthue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuekhautru = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_tentochuc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlMaSoThue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_kytinhthue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlNguoiBC3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNgayKetXuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
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
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1109.917F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrt_masothue,
            this.xrt_socmnd,
            this.xrt_thunhapchiuthue,
            this.xrt_tinhgiamthue,
            this.xrt_thuekhautru});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Weight = 0.14998786864741578D;
            this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.62135986106793917D;
            // 
            // xrt_masothue
            // 
            this.xrt_masothue.Name = "xrt_masothue";
            this.xrt_masothue.StylePriority.UseTextAlignment = false;
            this.xrt_masothue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_masothue.Weight = 0.47586917609416923D;
            // 
            // xrt_socmnd
            // 
            this.xrt_socmnd.Name = "xrt_socmnd";
            this.xrt_socmnd.StylePriority.UseBorders = false;
            this.xrt_socmnd.StylePriority.UseTextAlignment = false;
            this.xrt_socmnd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_socmnd.Weight = 0.53237690668561954D;
            // 
            // xrt_thunhapchiuthue
            // 
            this.xrt_thunhapchiuthue.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_thunhapchiuthue.Name = "xrt_thunhapchiuthue";
            this.xrt_thunhapchiuthue.StylePriority.UseBorders = false;
            this.xrt_thunhapchiuthue.StylePriority.UseTextAlignment = false;
            this.xrt_thunhapchiuthue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thunhapchiuthue.Weight = 0.56100553493839778D;
            // 
            // xrt_tinhgiamthue
            // 
            this.xrt_tinhgiamthue.Name = "xrt_tinhgiamthue";
            this.xrt_tinhgiamthue.StylePriority.UseTextAlignment = false;
            this.xrt_tinhgiamthue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tinhgiamthue.Weight = 0.75643102967620557D;
            // 
            // xrt_thuekhautru
            // 
            this.xrt_thuekhautru.Name = "xrt_thuekhautru";
            this.xrt_thuekhautru.StylePriority.UseTextAlignment = false;
            this.xrt_thuekhautru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thuekhautru.Weight = 0.71148163512786344D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
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
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrl_tentochuc,
            this.xrlMaSoThue,
            this.xrl_kytinhthue,
            this.xrLabel11,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel3});
            this.ReportHeader.HeightF = 193F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(39.58333F, 138.625F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(260.5412F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Tên tổ chức, cá nhân trả thu nhập:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(39.58333F, 165.625F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(90.74955F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Mã số thuế:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(39.58333F, 115.625F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(105.333F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Kỳ tính thuế:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_tentochuc
            // 
            this.xrl_tentochuc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_tentochuc.LocationFloat = new DevExpress.Utils.PointFloat(300.1246F, 138.625F);
            this.xrl_tentochuc.Name = "xrl_tentochuc";
            this.xrl_tentochuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tentochuc.SizeF = new System.Drawing.SizeF(811.8754F, 23F);
            this.xrl_tentochuc.StylePriority.UseFont = false;
            this.xrl_tentochuc.StylePriority.UseTextAlignment = false;
            this.xrl_tentochuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlMaSoThue
            // 
            this.xrlMaSoThue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrlMaSoThue.LocationFloat = new DevExpress.Utils.PointFloat(130.3329F, 165.625F);
            this.xrlMaSoThue.Multiline = true;
            this.xrlMaSoThue.Name = "xrlMaSoThue";
            this.xrlMaSoThue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlMaSoThue.SizeF = new System.Drawing.SizeF(981.6671F, 23F);
            this.xrlMaSoThue.StylePriority.UseFont = false;
            this.xrlMaSoThue.StylePriority.UseTextAlignment = false;
            this.xrlMaSoThue.Text = "\r\n";
            this.xrlMaSoThue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_kytinhthue
            // 
            this.xrl_kytinhthue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_kytinhthue.LocationFloat = new DevExpress.Utils.PointFloat(146.461F, 115.625F);
            this.xrl_kytinhthue.Multiline = true;
            this.xrl_kytinhthue.Name = "xrl_kytinhthue";
            this.xrl_kytinhthue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_kytinhthue.SizeF = new System.Drawing.SizeF(965.539F, 23F);
            this.xrl_kytinhthue.StylePriority.UseFont = false;
            this.xrl_kytinhthue.StylePriority.UseTextAlignment = false;
            this.xrl_kytinhthue.Text = "\r\n";
            this.xrl_kytinhthue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 115.625F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(37.5F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "[01]";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 140.625F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(37.5F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "[02]";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 165.625F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(37.5F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "[03]";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(146.461F, 10.00001F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(730.3334F, 84.45834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = resources.GetString("xrLabel1.Text");
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(893.7087F, 22.58336F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(176.7501F, 53.20833F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "(Ban hành kèm theo Thông tư số 20/2010/TT - BTC ngày 05/02/2010 của Bộ Tài chính";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(904.6525F, 10.00001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(46.54175F, 12.58332F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Mẫu số";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(955.8754F, 10.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(130.2081F, 12.58332F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "05B/BK - TNCN";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrTable1});
            this.PageHeader.HeightF = 60.49999F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(884.0275F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(217.9725F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Đơn vị tính: Việt Nam Đồng";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(2.083143F, 22.99999F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1109.917F, 37.5F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell1,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.Weight = 0.12573747748897549D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Họ và tên";
            this.xrTableCell1.Weight = 0.5208946054561634D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Mã số thuế";
            this.xrTableCell5.Weight = 0.39892775834722727D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Số CMND/ Hộ chiếu";
            this.xrTableCell6.Weight = 0.4462990727218713D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Thu nhập chịu thuế";
            this.xrTableCell7.Weight = 0.4702985999536568D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "TNCT làm căn cứ tính giảm thuế";
            this.xrTableCell2.Weight = 0.63412667532855094D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Số thuế TNCN đã khấu trừ";
            this.xrTableCell3.Weight = 0.59644524603465077D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlNguoiBC3,
            this.xrLabel28,
            this.xrLabel27,
            this.xrlNgayKetXuat,
            this.xrLabel25});
            this.ReportFooter.HeightF = 232.7083F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrlNguoiBC3
            // 
            this.xrlNguoiBC3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlNguoiBC3.LocationFloat = new DevExpress.Utils.PointFloat(777.1087F, 202.4167F);
            this.xrlNguoiBC3.Name = "xrlNguoiBC3";
            this.xrlNguoiBC3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNguoiBC3.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlNguoiBC3.StylePriority.UseFont = false;
            this.xrlNguoiBC3.StylePriority.UseTextAlignment = false;
            this.xrlNguoiBC3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(777.0831F, 85.00001F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(309F, 22.99999F);
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Ký tên, đóng dấu ( ghi rõ họ tên và chức vụ)";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(777.0831F, 35.00001F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(309.0003F, 43.83334F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "NGƯỜI ĐẠI DIỆN HỢP PHÁP CỦA TỔ CHỨC, CÁ NHÂN TRẢ THU NHẬP";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlNgayKetXuat
            // 
            this.xrlNgayKetXuat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrlNgayKetXuat.LocationFloat = new DevExpress.Utils.PointFloat(802.0831F, 10.00001F);
            this.xrlNgayKetXuat.Name = "xrlNgayKetXuat";
            this.xrlNgayKetXuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNgayKetXuat.SizeF = new System.Drawing.SizeF(286.0835F, 23F);
            this.xrlNgayKetXuat.StylePriority.UseFont = false;
            this.xrlNgayKetXuat.Text = "........., ngày ...... tháng....... năm .......";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999974F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(545.2776F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Tôi cam đoan số liệu trên là đúng và chịu trách nhiệm trước pháp luật về những số" +
    " liệu đã khai./.";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(975.9583F, 35.41667F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // rp_BangKeChiuThueCaNhanKhongKyHopDong05B
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(29, 28, 50, 0);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
