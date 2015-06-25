using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAL;
using System.Collections.Generic;
using System.Data;
using DataController;
/// <summary>
/// Summary description for rp_DanhSachNgayPhepConLaiTrongNam
/// </summary>
public class rp_DanhSachNgayPhepConLaiTrongNam : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
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
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell23;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrt_ngayvaocongty;
    private XRTableCell xrt_tongngaynghile;
    private XRTableCell xrt_ngayconlai;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_macanbo;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_tongngayphep;
    private XRTableCell xrt_thang1;
    private XRTableCell xrt_thang2;
    private XRTableCell xrt_thang3;
    private XRTableCell xrt_thang4;
    private XRTableCell xrt_thang5;
    private XRTableCell xrt_thang6;
    private XRTableCell xrt_thang7;
    private XRTableCell xrt_thang8;
    private XRTableCell xrt_thang9;
    private XRTableCell xrt_thang10;
    private XRTableCell xrt_thang11;
    private XRTableCell xrt_thang12;
    private XRTableCell xrt_tongsongaynghi;
    private XRLabel xrl_ten3;
    private XRLabel xrl_footer3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_ten2;
    private XRLabel xrl_footer2;
    private XRLabel xrl_ten1;
    private XRLabel xrl_footer1;
    private XRPageInfo xrPageInfo1;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell41;
    private XRLabel xrLabel1;
    private FormattingRule formattingRule1;
    private FormattingRule formattingRule2;
    private FormattingRule formattingRule3;
    private FormattingRule formattingRule4;
    private FormattingRule formattingRule5;
    private FormattingRule formattingRule6;
    private FormattingRule formattingRule7;
    private FormattingRule formattingRule8;
    private FormattingRule formattingRule9;
    private FormattingRule formattingRule11;
    private FormattingRule formattingRule12;
    private FormattingRule formattingRule10;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DanhSachNgayPhepConLaiTrongNam()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    public void BindData(ReportFilter filter)
    {
        ReportController rp = new ReportController();
        xrl_TenThanhPho.Text = "Mã đơn vị: " + rp.GetCompanyName(filter.SessionDepartment);
        xrl_TenCongTy.Text = "Địa chỉ: " + rp.GetCompanyAddress(filter.SessionDepartment);
        xrLabel1.Text = "Số điện thoại: " + rp.GetCompanyPhoneNumber(filter.SessionDepartment);
        xrl_TitleBC.Text = "BÁO CÁO NGÀY PHÉP CBNV NĂM " + filter.Year.ToString();
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_SoNgayPhepCuaCBNV", "@Year", "@MaBoPhan", "@Gender",filter.Year,  filter.SelectedDepartment, filter.Gender);
        DataSource = table;
        xrt_stt.DataBindings.Add("Text", DataSource, "SK");
        xrt_macanbo.DataBindings.Add("Text", DataSource, "MA_CB");
        xrt_hovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrt_ngayvaocongty.DataBindings.Add("Text", DataSource, "NGAY_TUYEN_DTIEN", "{0:dd/MM/yyyy}");
        xrt_tongngayphep.DataBindings.Add("Text", DataSource, "TongNgayPhepDuocHuong");
        xrt_tongngaynghile.DataBindings.Add("Text", DataSource, "SoNgayPhepNamNay");
        xrt_thang1.DataBindings.Add("Text", DataSource, "Thang1");
        xrt_thang2.DataBindings.Add("Text", DataSource, "Thang2");
        xrt_thang3.DataBindings.Add("Text", DataSource, "Thang3");
        xrt_thang4.DataBindings.Add("Text", DataSource, "Thang4");
        xrt_thang5.DataBindings.Add("Text", DataSource, "Thang5");
        xrt_thang6.DataBindings.Add("Text", DataSource, "Thang6");
        xrt_thang7.DataBindings.Add("Text", DataSource, "Thang7");
        xrt_thang8.DataBindings.Add("Text", DataSource, "Thang8");
        xrt_thang9.DataBindings.Add("Text", DataSource, "Thang9");
        xrt_thang10.DataBindings.Add("Text", DataSource, "Thang10");
        xrt_thang11.DataBindings.Add("Text", DataSource, "Thang11");
        xrt_thang12.DataBindings.Add("Text", DataSource, "Thang12");
        xrt_tongsongaynghi.DataBindings.Add("Text", DataSource, "DaSuDung");
        xrt_ngayconlai.DataBindings.Add("Text", DataSource, "PhepTon");
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TEN_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrTableCell41.DataBindings.Add("Text", DataSource, "TEN_PHONG");
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
            string resourceFileName = "rp_DanhSachNgayPhepConLaiTrongNam.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macanbo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayvaocongty = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongngayphep = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongngaynghile = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule2 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule3 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule4 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule5 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule6 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule7 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule8 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule9 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thang11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule11 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_thang12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule12 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_tongsongaynghi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayconlai = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule10 = new DevExpress.XtraReports.UI.FormattingRule();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
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
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(1364.479F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_macanbo,
            this.xrt_hovaten,
            this.xrt_ngayvaocongty,
            this.xrt_tongngayphep,
            this.xrt_tongngaynghile,
            this.xrt_thang1,
            this.xrt_thang2,
            this.xrt_thang3,
            this.xrt_thang4,
            this.xrt_thang5,
            this.xrt_thang6,
            this.xrt_thang7,
            this.xrt_thang8,
            this.xrt_thang9,
            this.xrt_thang10,
            this.xrt_thang11,
            this.xrt_thang12,
            this.xrt_tongsongaynghi,
            this.xrt_ngayconlai});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseTextAlignment = false;
            this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_stt.Weight = 0.079622235872235825D;
            // 
            // xrt_macanbo
            // 
            this.xrt_macanbo.Name = "xrt_macanbo";
            this.xrt_macanbo.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_macanbo.StylePriority.UsePadding = false;
            this.xrt_macanbo.StylePriority.UseTextAlignment = false;
            this.xrt_macanbo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_macanbo.Weight = 0.22600584475355595D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hovaten.StylePriority.UsePadding = false;
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.25120942305581284D;
            // 
            // xrt_ngayvaocongty
            // 
            this.xrt_ngayvaocongty.Name = "xrt_ngayvaocongty";
            this.xrt_ngayvaocongty.StylePriority.UseTextAlignment = false;
            this.xrt_ngayvaocongty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngayvaocongty.Weight = 0.18018646146507161D;
            // 
            // xrt_tongngayphep
            // 
            this.xrt_tongngayphep.Name = "xrt_tongngayphep";
            this.xrt_tongngayphep.StylePriority.UseTextAlignment = false;
            this.xrt_tongngayphep.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongngayphep.Weight = 0.1756175999559407D;
            // 
            // xrt_tongngaynghile
            // 
            this.xrt_tongngaynghile.Name = "xrt_tongngaynghile";
            this.xrt_tongngaynghile.StylePriority.UseTextAlignment = false;
            this.xrt_tongngaynghile.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongngaynghile.Weight = 0.18090651369212007D;
            // 
            // xrt_thang1
            // 
            this.xrt_thang1.FormattingRules.Add(this.formattingRule1);
            this.xrt_thang1.Name = "xrt_thang1";
            this.xrt_thang1.StylePriority.UseTextAlignment = false;
            this.xrt_thang1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang1.Weight = 0.08353884272844847D;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Condition = "[Thang1]>0";
            // 
            // 
            // 
            this.formattingRule1.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule1.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule1.Name = "formattingRule1";
            // 
            // xrt_thang2
            // 
            this.xrt_thang2.FormattingRules.Add(this.formattingRule2);
            this.xrt_thang2.Name = "xrt_thang2";
            this.xrt_thang2.StylePriority.UseTextAlignment = false;
            this.xrt_thang2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang2.Weight = 0.083538950514734811D;
            // 
            // formattingRule2
            // 
            this.formattingRule2.Condition = "[Thang2]>0";
            // 
            // 
            // 
            this.formattingRule2.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule2.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule2.Name = "formattingRule2";
            // 
            // xrt_thang3
            // 
            this.xrt_thang3.FormattingRules.Add(this.formattingRule3);
            this.xrt_thang3.Name = "xrt_thang3";
            this.xrt_thang3.StylePriority.UseTextAlignment = false;
            this.xrt_thang3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang3.Weight = 0.083538723226261435D;
            // 
            // formattingRule3
            // 
            this.formattingRule3.Condition = "[Thang3]>0";
            // 
            // 
            // 
            this.formattingRule3.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule3.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule3.Name = "formattingRule3";
            // 
            // xrt_thang4
            // 
            this.xrt_thang4.FormattingRules.Add(this.formattingRule4);
            this.xrt_thang4.Name = "xrt_thang4";
            this.xrt_thang4.StylePriority.UseTextAlignment = false;
            this.xrt_thang4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang4.Weight = 0.083538946999964558D;
            // 
            // formattingRule4
            // 
            this.formattingRule4.Condition = "[Thang4]>0";
            // 
            // 
            // 
            this.formattingRule4.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule4.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule4.Name = "formattingRule4";
            // 
            // xrt_thang5
            // 
            this.xrt_thang5.FormattingRules.Add(this.formattingRule5);
            this.xrt_thang5.Name = "xrt_thang5";
            this.xrt_thang5.StylePriority.UseTextAlignment = false;
            this.xrt_thang5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang5.Weight = 0.083538608996229613D;
            // 
            // formattingRule5
            // 
            this.formattingRule5.Condition = "[Thang5]>0";
            // 
            // 
            // 
            this.formattingRule5.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule5.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule5.Name = "formattingRule5";
            // 
            // xrt_thang6
            // 
            this.xrt_thang6.FormattingRules.Add(this.formattingRule6);
            this.xrt_thang6.Name = "xrt_thang6";
            this.xrt_thang6.StylePriority.UseTextAlignment = false;
            this.xrt_thang6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang6.Weight = 0.083538833648625466D;
            // 
            // formattingRule6
            // 
            this.formattingRule6.Condition = "[Thang6]>0";
            // 
            // 
            // 
            this.formattingRule6.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule6.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule6.Name = "formattingRule6";
            // 
            // xrt_thang7
            // 
            this.xrt_thang7.FormattingRules.Add(this.formattingRule7);
            this.xrt_thang7.Name = "xrt_thang7";
            this.xrt_thang7.StylePriority.UseTextAlignment = false;
            this.xrt_thang7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang7.Weight = 0.083539058447469949D;
            // 
            // formattingRule7
            // 
            this.formattingRule7.Condition = "[Thang7]>0";
            // 
            // 
            // 
            this.formattingRule7.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule7.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule7.Name = "formattingRule7";
            // 
            // xrt_thang8
            // 
            this.xrt_thang8.FormattingRules.Add(this.formattingRule8);
            this.xrt_thang8.Name = "xrt_thang8";
            this.xrt_thang8.StylePriority.UseTextAlignment = false;
            this.xrt_thang8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang8.Weight = 0.083539058374245634D;
            // 
            // formattingRule8
            // 
            this.formattingRule8.Condition = "[Thang8]>0";
            // 
            // 
            // 
            this.formattingRule8.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule8.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule8.Name = "formattingRule8";
            // 
            // xrt_thang9
            // 
            this.xrt_thang9.FormattingRules.Add(this.formattingRule9);
            this.xrt_thang9.Name = "xrt_thang9";
            this.xrt_thang9.StylePriority.UseTextAlignment = false;
            this.xrt_thang9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang9.Weight = 0.083538608447046747D;
            // 
            // formattingRule9
            // 
            this.formattingRule9.Condition = "[Thang9]>0";
            // 
            // 
            // 
            this.formattingRule9.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule9.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule9.Name = "formattingRule9";
            // 
            // xrt_thang10
            // 
            this.xrt_thang10.Name = "xrt_thang10";
            this.xrt_thang10.StylePriority.UseTextAlignment = false;
            this.xrt_thang10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang10.Weight = 0.083539283264620567D;
            // 
            // xrt_thang11
            // 
            this.xrt_thang11.FormattingRules.Add(this.formattingRule11);
            this.xrt_thang11.Name = "xrt_thang11";
            this.xrt_thang11.StylePriority.UseTextAlignment = false;
            this.xrt_thang11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang11.Weight = 0.083538608419587657D;
            // 
            // formattingRule11
            // 
            this.formattingRule11.Condition = "[Thang11]>0";
            // 
            // 
            // 
            this.formattingRule11.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule11.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule11.Name = "formattingRule11";
            // 
            // xrt_thang12
            // 
            this.xrt_thang12.FormattingRules.Add(this.formattingRule12);
            this.xrt_thang12.Name = "xrt_thang12";
            this.xrt_thang12.StylePriority.UseTextAlignment = false;
            this.xrt_thang12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thang12.Weight = 0.09121756589255256D;
            // 
            // formattingRule12
            // 
            this.formattingRule12.Condition = "[Thang12]>0";
            // 
            // 
            // 
            this.formattingRule12.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule12.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule12.Name = "formattingRule12";
            // 
            // xrt_tongsongaynghi
            // 
            this.xrt_tongsongaynghi.Name = "xrt_tongsongaynghi";
            this.xrt_tongsongaynghi.StylePriority.UseTextAlignment = false;
            this.xrt_tongsongaynghi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongsongaynghi.Weight = 0.20535154600630007D;
            // 
            // xrt_ngayconlai
            // 
            this.xrt_ngayconlai.Name = "xrt_ngayconlai";
            this.xrt_ngayconlai.StylePriority.UseTextAlignment = false;
            this.xrt_ngayconlai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngayconlai.Weight = 0.20535154600630007D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrl_TitleBC,
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
            this.ReportHeader.HeightF = 120.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(502.0836F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1365F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO NGÀY PHÉP CBNV";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(502.0836F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(502.0836F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 56.25F;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(1364.479F, 56.25F);
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
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell2,
            this.xrTableCell22,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 0.88524588392422265D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.Weight = 0.079622235872235825D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Mã CBNV";
            this.xrTableCell5.Weight = 0.22600585881263677D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Họ và tên";
            this.xrTableCell6.Weight = 0.25120935978994913D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Ngày vào công ty";
            this.xrTableCell1.Weight = 0.18018652473093555D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Tổng ngày phép";
            this.xrTableCell8.Weight = 0.17561776515014047D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Số ngày phép trong năm";
            this.xrTableCell9.Weight = 0.18090651310632502D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 1.0101447298720077D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(548.1721F, 31.25F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.Text = "Số ngày nghỉ của tháng";
            this.xrTableCell23.Weight = 3D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.25F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(548.1719F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrTableCell13,
            this.xrTableCell17,
            this.xrTableCell10,
            this.xrTableCell18,
            this.xrTableCell14,
            this.xrTableCell19,
            this.xrTableCell11,
            this.xrTableCell20,
            this.xrTableCell15,
            this.xrTableCell21,
            this.xrTableCell12});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.Text = "T1";
            this.xrTableCell16.Weight = 0.25D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "T2";
            this.xrTableCell13.Weight = 0.25D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "T3";
            this.xrTableCell17.Weight = 0.25D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "T4";
            this.xrTableCell10.Weight = 0.25D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "T5";
            this.xrTableCell18.Weight = 0.25D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "T6";
            this.xrTableCell14.Weight = 0.25D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "T7";
            this.xrTableCell19.Weight = 0.25D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "T8";
            this.xrTableCell11.Weight = 0.25D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "T9";
            this.xrTableCell20.Weight = 0.25D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "T10";
            this.xrTableCell15.Weight = 0.25D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "T11";
            this.xrTableCell21.Weight = 0.25D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "T12";
            this.xrTableCell12.Weight = 0.27297834169940915D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "Tổng ngày nghỉ";
            this.xrTableCell22.Weight = 0.20535169596754066D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Ngày còn lại";
            this.xrTableCell3.Weight = 0.20535169596754066D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrl_footer3,
            this.xrtngayketxuat,
            this.xrl_ten2,
            this.xrl_footer2,
            this.xrl_ten1,
            this.xrl_footer1});
            this.ReportFooter.HeightF = 205F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1082.062F, 151.0417F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1082.583F, 51.04167F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(281.9166F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1082.583F, 26.04167F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(527.7625F, 151.0417F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(527.7625F, 51.04167F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "PHÒNG TCHC";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 151.0417F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 51.04167F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 100F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1238.958F, 33.38702F);
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
            this.xrTable5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(1364.479F, 25F);
            this.xrTable5.StylePriority.UseBorders = false;
            this.xrTable5.StylePriority.UseFont = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.BackColor = System.Drawing.Color.SkyBlue;
            this.xrTableCell41.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell41.StylePriority.UseBackColor = false;
            this.xrTableCell41.StylePriority.UseFont = false;
            this.xrTableCell41.StylePriority.UsePadding = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell41.Weight = 0.083538608419587657D;
            // 
            // formattingRule10
            // 
            this.formattingRule10.Condition = "[Thang10]>0";
            // 
            // 
            // 
            this.formattingRule10.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formattingRule10.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule10.Name = "formattingRule10";
            // 
            // rp_DanhSachNgayPhepConLaiTrongNam
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
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1,
            this.formattingRule2,
            this.formattingRule3,
            this.formattingRule4,
            this.formattingRule5,
            this.formattingRule6,
            this.formattingRule7,
            this.formattingRule8,
            this.formattingRule9,
            this.formattingRule10,
            this.formattingRule11,
            this.formattingRule12});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 277, 100, 100);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Version = "14.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
