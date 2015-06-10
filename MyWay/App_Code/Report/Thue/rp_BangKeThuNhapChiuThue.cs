using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using Ext.Net;

/// <summary>
/// Summary description for rp_BangKeThuNhapChiuThue
/// </summary>
public class rp_BangKeThuNhapChiuThue : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private PageFooterBand PageFooter;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrl_tentochuc;
    private XRLabel xrLabel15;
    private XRLabel xrlMaSoThue;
    private XRLabel xrLabel11;
    private XRLabel xrl_kytinhthue;
    private XRLabel xrLabel14;
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
    private XRTableCell xrTableCell9;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell11;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTable xrTable4;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell19;
    private XRTable xrTable5;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell20;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrt_socmnd;
    private XRTableCell xrt_baohiembatbuoc;
    private XRTableCell xrt_sothueconphaikhautru;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_masothue;
    private XRTableCell xrt_thunhapchiuthue;
    private XRTableCell xrt_SoNPT;
    private XRTableCell xrt_tongsothanggiamtru;
    private XRTableCell xrt_Tuthien;
    private XRTableCell xrt_TNCT_LamCanCu;
    private XRTableCell xrt_sothueTNCN;
    private XRTableCell xrt_tongsothuephainop;
    private XRTableCell xrt_tongsothuedanopthua;
    private XRPageInfo xrPageInfo1;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel27;
    private XRLabel xrlNguoiBC3;
    private XRLabel xrLabel28;
    private XRLabel xrl_ngayketxuat;
    private XRLabel xrLabel25;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel2;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BangKeThuNhapChiuThue()
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
        xrt_SoNPT.DataBindings.Add("Text", DataSource, "SoNguoiPhuThuoc");
        // xrt_luykedaunam.DataBindings.Add("Text", DataSource, "LuyKeTuDauNam");
        xrt_tongsothanggiamtru.DataBindings.Add("Text", DataSource, "TongSoThangGiamTru", "{0:n0}");
        xrt_baohiembatbuoc.DataBindings.Add("Text", DataSource, "BaoHiem", "{0:n0}");
        xrt_TNCT_LamCanCu.DataBindings.Add("Text", DataSource, "ThuNhapTinhThue", "{0:n0}");
        // xrt_TNCT_LamCanCu.DataBindings.Add("Text", DataSource, "ThuNhapTinhThue", "{0:n0}");
        xrt_sothueTNCN.DataBindings.Add("Text", DataSource, "SoThuePhaiNop", "{0:n0}");


        xrl_ngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
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
            string resourceFileName = "rp_BangKeThuNhapChiuThue.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_BangKeThuNhapChiuThue.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_masothue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_socmnd = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thunhapchiuthue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_SoNPT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongsothanggiamtru = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_Tuthien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_baohiembatbuoc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TNCT_LamCanCu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sothueTNCN = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongsothuephainop = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongsothuedanopthua = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sothueconphaikhautru = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_kytinhthue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlMaSoThue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_tentochuc = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNguoiBC3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
            this.Detail.HeightF = 23.95833F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable8
            // 
            this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(1.041619F, 0F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable8.SizeF = new System.Drawing.SizeF(1120.958F, 23.95833F);
            this.xrTable8.StylePriority.UseBorders = false;
            this.xrTable8.StylePriority.UsePadding = false;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrt_masothue,
            this.xrt_socmnd,
            this.xrt_thunhapchiuthue,
            this.xrt_SoNPT,
            this.xrt_tongsothanggiamtru,
            this.xrt_Tuthien,
            this.xrt_baohiembatbuoc,
            this.xrt_TNCT_LamCanCu,
            this.xrt_sothueTNCN,
            this.xrt_tongsothuephainop,
            this.xrt_tongsothuedanopthua,
            this.xrt_sothueconphaikhautru});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Weight = 0.13479904842147009D;
            this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.29042303372608463D;
            // 
            // xrt_masothue
            // 
            this.xrt_masothue.Name = "xrt_masothue";
            this.xrt_masothue.StylePriority.UseTextAlignment = false;
            this.xrt_masothue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_masothue.Weight = 0.24835992973893428D;
            // 
            // xrt_socmnd
            // 
            this.xrt_socmnd.Name = "xrt_socmnd";
            this.xrt_socmnd.StylePriority.UseTextAlignment = false;
            this.xrt_socmnd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_socmnd.Weight = 0.24835994066789779D;
            // 
            // xrt_thunhapchiuthue
            // 
            this.xrt_thunhapchiuthue.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_thunhapchiuthue.Name = "xrt_thunhapchiuthue";
            this.xrt_thunhapchiuthue.StylePriority.UseBorders = false;
            this.xrt_thunhapchiuthue.StylePriority.UseTextAlignment = false;
            this.xrt_thunhapchiuthue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thunhapchiuthue.Weight = 0.19891803179041262D;
            // 
            // xrt_SoNPT
            // 
            this.xrt_SoNPT.Name = "xrt_SoNPT";
            this.xrt_SoNPT.StylePriority.UseTextAlignment = false;
            this.xrt_SoNPT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_SoNPT.Weight = 0.23975036837527528D;
            // 
            // xrt_tongsothanggiamtru
            // 
            this.xrt_tongsothanggiamtru.Name = "xrt_tongsothanggiamtru";
            this.xrt_tongsothanggiamtru.StylePriority.UseTextAlignment = false;
            this.xrt_tongsothanggiamtru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongsothanggiamtru.Weight = 0.21220048988385026D;
            // 
            // xrt_Tuthien
            // 
            this.xrt_Tuthien.Name = "xrt_Tuthien";
            this.xrt_Tuthien.StylePriority.UseTextAlignment = false;
            this.xrt_Tuthien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_Tuthien.Weight = 0.24007896689343258D;
            // 
            // xrt_baohiembatbuoc
            // 
            this.xrt_baohiembatbuoc.Name = "xrt_baohiembatbuoc";
            this.xrt_baohiembatbuoc.StylePriority.UseTextAlignment = false;
            this.xrt_baohiembatbuoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_baohiembatbuoc.Weight = 0.25401706111670064D;
            // 
            // xrt_TNCT_LamCanCu
            // 
            this.xrt_TNCT_LamCanCu.Name = "xrt_TNCT_LamCanCu";
            this.xrt_TNCT_LamCanCu.StylePriority.UseTextAlignment = false;
            this.xrt_TNCT_LamCanCu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_TNCT_LamCanCu.Weight = 0.19154019687264062D;
            // 
            // xrt_sothueTNCN
            // 
            this.xrt_sothueTNCN.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_sothueTNCN.Name = "xrt_sothueTNCN";
            this.xrt_sothueTNCN.StylePriority.UseBorders = false;
            this.xrt_sothueTNCN.StylePriority.UseTextAlignment = false;
            this.xrt_sothueTNCN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_sothueTNCN.Weight = 0.19904835797354009D;
            // 
            // xrt_tongsothuephainop
            // 
            this.xrt_tongsothuephainop.Name = "xrt_tongsothuephainop";
            this.xrt_tongsothuephainop.StylePriority.UseTextAlignment = false;
            this.xrt_tongsothuephainop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tongsothuephainop.Weight = 0.18083488767317396D;
            // 
            // xrt_tongsothuedanopthua
            // 
            this.xrt_tongsothuedanopthua.Name = "xrt_tongsothuedanopthua";
            this.xrt_tongsothuedanopthua.StylePriority.UseTextAlignment = false;
            this.xrt_tongsothuedanopthua.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tongsothuedanopthua.Weight = 0.18083484343329351D;
            // 
            // xrt_sothueconphaikhautru
            // 
            this.xrt_sothueconphaikhautru.Name = "xrt_sothueconphaikhautru";
            this.xrt_sothueconphaikhautru.StylePriority.UseTextAlignment = false;
            this.xrt_sothueconphaikhautru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_sothueconphaikhautru.Weight = 0.18083484343329351D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 49F;
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
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel1,
            this.xrl_kytinhthue,
            this.xrLabel14,
            this.xrLabel11,
            this.xrlMaSoThue,
            this.xrLabel15,
            this.xrl_tentochuc});
            this.ReportHeader.HeightF = 195F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportHeader_BeforePrint);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(38.54162F, 115.625F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(105.333F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Kỳ tính thuế:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(38.54162F, 164.5833F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(90.74955F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Mã số thuế:";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(38.54162F, 139.5833F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(260.5412F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Tên tổ chức, cá nhân trả thu nhập:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(981.7918F, 9.916687F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(130.2081F, 12.58332F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "05A/KK - TNCN";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(931.7918F, 9.916687F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(46.54175F, 12.58332F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Mẫu số";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(919.2918F, 22.50001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(176.7501F, 53.20833F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "(Ban hành kèm theo Thông tư số 20/2010/TT - BTC ngày 05/02/2010 của Bộ Tài chính";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(211.4583F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(633.4584F, 84.45834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = resources.GetString("xrLabel1.Text");
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_kytinhthue
            // 
            this.xrl_kytinhthue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_kytinhthue.LocationFloat = new DevExpress.Utils.PointFloat(143.8746F, 115.625F);
            this.xrl_kytinhthue.Multiline = true;
            this.xrl_kytinhthue.Name = "xrl_kytinhthue";
            this.xrl_kytinhthue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_kytinhthue.SizeF = new System.Drawing.SizeF(974.5421F, 23F);
            this.xrl_kytinhthue.StylePriority.UseFont = false;
            this.xrl_kytinhthue.StylePriority.UseTextAlignment = false;
            this.xrl_kytinhthue.Text = "\r\n";
            this.xrl_kytinhthue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(1.041619F, 139.5833F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(37.5F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "[02]";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1.041619F, 115.625F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(37.5F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "[01]";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlMaSoThue
            // 
            this.xrlMaSoThue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrlMaSoThue.LocationFloat = new DevExpress.Utils.PointFloat(129.2912F, 164.5833F);
            this.xrlMaSoThue.Multiline = true;
            this.xrlMaSoThue.Name = "xrlMaSoThue";
            this.xrlMaSoThue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlMaSoThue.SizeF = new System.Drawing.SizeF(989.1255F, 23F);
            this.xrlMaSoThue.StylePriority.UseFont = false;
            this.xrlMaSoThue.StylePriority.UseTextAlignment = false;
            this.xrlMaSoThue.Text = "\r\n";
            this.xrlMaSoThue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(1.041619F, 164.5833F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(37.5F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "[03]";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_tentochuc
            // 
            this.xrl_tentochuc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_tentochuc.LocationFloat = new DevExpress.Utils.PointFloat(299.0828F, 139.5833F);
            this.xrl_tentochuc.Name = "xrl_tentochuc";
            this.xrl_tentochuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tentochuc.SizeF = new System.Drawing.SizeF(819.3338F, 23F);
            this.xrl_tentochuc.StylePriority.UseFont = false;
            this.xrl_tentochuc.StylePriority.UseTextAlignment = false;
            this.xrl_tentochuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 145F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(1.041619F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1120.958F, 144.7917F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell9,
            this.xrTableCell8,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.Weight = 0.13479903823316641D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Họ và tên";
            this.xrTableCell5.Weight = 0.29042305413404124D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Mã số thuế";
            this.xrTableCell6.Weight = 0.24835981232780616D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Số CMND/ Hộ chiếu";
            this.xrTableCell1.Weight = 0.24836002744095345D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.Text = "Thu nhập chịu thuế";
            this.xrTableCell7.Weight = 0.19891807262723873D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 0.94604702919810335D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(3.755093E-05F, 40.625F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(353.493F, 104.1667F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell12,
            this.xrTableCell13});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "xrTableCell10";
            this.xrTableCell10.Weight = 1.4331773395399914D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(7.033348E-06F, 37.29166F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(168.8727F, 66.87503F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Số NPT";
            this.xrTableCell17.Weight = 0.8958334350585937D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "Tổng số tháng giảm trừ";
            this.xrTableCell18.Weight = 0.79289337158203121D;
            // 
            // xrTable7
            // 
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(7.033348E-06F, 0F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable7.SizeF = new System.Drawing.SizeF(168.8727F, 37.29166F);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.Text = "Người phụ thuộc";
            this.xrTableCell20.Weight = 3D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Từ thiện, nhân đạo, khuyến học";
            this.xrTableCell12.Weight = 0.7613105248436105D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "Bảo hiểm bắt buộc";
            this.xrTableCell13.Weight = 0.80551213561639812D;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.755093E-05F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(353.4931F, 40.625F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.Text = "Các khoản giảm trừ";
            this.xrTableCell11.Weight = 3D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "TNCT làm căn cứ tính giảm thuế";
            this.xrTableCell9.Weight = 0.19154016284196335D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.Text = "Số thuế TNCN đã khấu trừ";
            this.xrTableCell8.Weight = 0.1990483783919465D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable5});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 0.542504424804781D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0.0001291037F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable4.SizeF = new System.Drawing.SizeF(202.7082F, 40.625F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.Text = "Chi tiết kết quả quyết toán thay cho cá nhân nộp thuế";
            this.xrTableCell19.Weight = 3D;
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(7.033348E-06F, 40.625F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable5.SizeF = new System.Drawing.SizeF(202.7082F, 104.1667F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Tổng số thuế phải nộp";
            this.xrTableCell14.Weight = 1D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Tổng số thuế đã nộp thừa";
            this.xrTableCell15.Weight = 1D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Số thuế còn phải khấu trừ thêm";
            this.xrTableCell16.Weight = 1D;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 119F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(986.8608F, 55.20833F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.xrlNguoiBC3,
            this.xrLabel28,
            this.xrl_ngayketxuat,
            this.xrLabel25});
            this.ReportFooter.HeightF = 233F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(801.0416F, 47.50001F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(317.3751F, 43.83334F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "NGƯỜI ĐẠI DIỆN HỢP PHÁP CỦA TỔ CHỨC, CÁ NHÂN TRẢ THU NHẬP";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlNguoiBC3
            // 
            this.xrlNguoiBC3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlNguoiBC3.LocationFloat = new DevExpress.Utils.PointFloat(801.0416F, 210F);
            this.xrlNguoiBC3.Name = "xrlNguoiBC3";
            this.xrlNguoiBC3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNguoiBC3.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlNguoiBC3.StylePriority.UseFont = false;
            this.xrlNguoiBC3.StylePriority.UseTextAlignment = false;
            this.xrlNguoiBC3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(801.0416F, 97.50001F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(317.3749F, 22.99999F);
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Ký tên, đóng dấu ( ghi rõ họ tên và chức vụ)";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ngayketxuat
            // 
            this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(826.0416F, 22.50001F);
            this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
            this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(294.4584F, 23F);
            this.xrl_ngayketxuat.StylePriority.UseFont = false;
            this.xrl_ngayketxuat.Text = "........., ngày ...... tháng....... năm .......";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(1.041619F, 10.00001F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(782.9999F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Tôi cam đoan số liệu trên là đúng và chịu trách nhiệm trước pháp luật về những số" +
    " liệu đã khai./.";
            // 
            // rp_BangKeThuNhapChiuThue
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(23, 24, 49, 0);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
