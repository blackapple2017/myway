using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoKhenThuongKyLuatTrongThang
/// </summary>
public class rp_BaoCaoKhenThuongKyLuatTrongThang : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_ngayBC;
    private XRLabel xrl_tencongty;
    private XRLabel xrl_thanhpho;
    private XRLabel xrl_TitleBC;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_STT;
    private XRTableCell xrl_macb;
    private XRTableCell xlHoTen;
    private XRTableCell xlrNgaySinh;
    private XRTableCell xlrGioiTinh;
    private XRTableCell xlrPhongBan;
    private XRTableCell xrtchucvu;
    private XRTableCell xrtsoqd;
    private XRTableCell xrtngayqd;
    private XRTableCell xrtlydokhenthuong;
    private XRTableCell xrthinhthuc;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrl_bophan;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BaoCaoKhenThuongKyLuatTrongThang()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
        // 
        try
        {
            HeThongController ht = new HeThongController();
        }
        catch (Exception ex)
        {
            xrl_TitleBC.Text = ex.Message;
        }

    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrt_STT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        ReportController rpCtr = new ReportController();
        xrl_thanhpho.Text = rpCtr.GetCityName(filter.SessionDepartment);
        xrl_tencongty.Text = rpCtr.GetCompanyName(filter.SessionDepartment);
        xrl_ngayBC.Text = rpCtr.GetFromDateToDate(filter.StartDate, filter.EndDate);
        xrtngayketxuat.Text = rpCtr.GetFooterReport(filter.SessionDepartment, filter.ReportedDate);

        DataTable table = DataHandler.GetInstance().ExecuteDataTable("report_DanhSachKhenThuong", "@MaDonVi", "@Where", filter.SessionDepartment, filter.WhereClause);
        DataSource = table;
        xlHoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrl_macb.DataBindings.Add("Text", DataSource, "MA_CB");
        xlrNgaySinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
        xlrGioiTinh.DataBindings.Add("Text", DataSource, "TEN_GIOITINH");
        xlrPhongBan.DataBindings.Add("Text", DataSource, "TEN_PHONG");
        xrtchucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        xrtsoqd.DataBindings.Add("Text", DataSource, "SO_QD");
        xrtngayqd.DataBindings.Add("Text", DataSource, "NGAY_QD", "{0:dd/MM/yyyy}");
        xrthinhthuc.DataBindings.Add("Text", DataSource, "TEN_HT_KTHUONG");
        xrtlydokhenthuong.DataBindings.Add("Text", DataSource, "TEN_LYDO_KTHUONG");
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrl_ten1.Text = filter.Name1;
        }
        else
        {
            xrl_ten1.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
        }
        xrl_ten3.Text = rpCtr.GetDirectorName(filter.SessionDepartment, filter.Name3);
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_TitleBC.Text = filter.ReportTitle;
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
            string resourceFileName = "rp_BaoCaoKhenThuongKyLuatTrongThang.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_STT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrl_macb = new DevExpress.XtraReports.UI.XRTableCell();
            this.xlHoTen = new DevExpress.XtraReports.UI.XRTableCell();
            this.xlrNgaySinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xlrGioiTinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xlrPhongBan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtchucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtsoqd = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtngayqd = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtlydokhenthuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrthinhthuc = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_ngayBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_tencongty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_thanhpho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrl_bophan = new DevExpress.XtraReports.UI.XRLabel();
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
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1085F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_STT,
            this.xrl_macb,
            this.xlHoTen,
            this.xlrNgaySinh,
            this.xlrGioiTinh,
            this.xlrPhongBan,
            this.xrtchucvu,
            this.xrtsoqd,
            this.xrtngayqd,
            this.xrtlydokhenthuong,
            this.xrthinhthuc});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_STT
            // 
            this.xrt_STT.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_STT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_STT.Name = "xrt_STT";
            this.xrt_STT.StylePriority.UseBorders = false;
            this.xrt_STT.StylePriority.UseFont = false;
            this.xrt_STT.Weight = 0.37500005582198637D;
            // 
            // xrl_macb
            // 
            this.xrl_macb.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrl_macb.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_macb.Name = "xrl_macb";
            this.xrl_macb.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrl_macb.StylePriority.UseBorders = false;
            this.xrl_macb.StylePriority.UseFont = false;
            this.xrl_macb.StylePriority.UsePadding = false;
            this.xrl_macb.StylePriority.UseTextAlignment = false;
            this.xrl_macb.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrl_macb.Weight = 0.697916764178888D;
            // 
            // xlHoTen
            // 
            this.xlHoTen.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xlHoTen.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xlHoTen.Name = "xlHoTen";
            this.xlHoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xlHoTen.StylePriority.UseBorders = false;
            this.xlHoTen.StylePriority.UseFont = false;
            this.xlHoTen.StylePriority.UsePadding = false;
            this.xlHoTen.StylePriority.UseTextAlignment = false;
            this.xlHoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xlHoTen.Weight = 1.3333336527611195D;
            // 
            // xlrNgaySinh
            // 
            this.xlrNgaySinh.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xlrNgaySinh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xlrNgaySinh.Name = "xlrNgaySinh";
            this.xlrNgaySinh.StylePriority.UseBorders = false;
            this.xlrNgaySinh.StylePriority.UseFont = false;
            this.xlrNgaySinh.Weight = 0.80208357990317081D;
            // 
            // xlrGioiTinh
            // 
            this.xlrGioiTinh.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xlrGioiTinh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xlrGioiTinh.Name = "xlrGioiTinh";
            this.xlrGioiTinh.StylePriority.UseBorders = false;
            this.xlrGioiTinh.StylePriority.UseFont = false;
            this.xlrGioiTinh.Weight = 0.6508332561232717D;
            // 
            // xlrPhongBan
            // 
            this.xlrPhongBan.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xlrPhongBan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xlrPhongBan.Name = "xlrPhongBan";
            this.xlrPhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xlrPhongBan.StylePriority.UseBorders = false;
            this.xlrPhongBan.StylePriority.UseFont = false;
            this.xlrPhongBan.StylePriority.UsePadding = false;
            this.xlrPhongBan.StylePriority.UseTextAlignment = false;
            this.xlrPhongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xlrPhongBan.Weight = 1.721459393939105D;
            // 
            // xrtchucvu
            // 
            this.xrtchucvu.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtchucvu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrtchucvu.Name = "xrtchucvu";
            this.xrtchucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtchucvu.StylePriority.UseBorders = false;
            this.xrtchucvu.StylePriority.UseFont = false;
            this.xrtchucvu.StylePriority.UsePadding = false;
            this.xrtchucvu.StylePriority.UseTextAlignment = false;
            this.xrtchucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrtchucvu.Weight = 1.3138551483488739D;
            // 
            // xrtsoqd
            // 
            this.xrtsoqd.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtsoqd.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrtsoqd.Name = "xrtsoqd";
            this.xrtsoqd.StylePriority.UseBorders = false;
            this.xrtsoqd.StylePriority.UseFont = false;
            this.xrtsoqd.Weight = 0.83400863678338988D;
            // 
            // xrtngayqd
            // 
            this.xrtngayqd.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtngayqd.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrtngayqd.Name = "xrtngayqd";
            this.xrtngayqd.StylePriority.UseBorders = false;
            this.xrtngayqd.StylePriority.UseFont = false;
            this.xrtngayqd.Weight = 0.83367263429437755D;
            // 
            // xrtlydokhenthuong
            // 
            this.xrtlydokhenthuong.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtlydokhenthuong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrtlydokhenthuong.Name = "xrtlydokhenthuong";
            this.xrtlydokhenthuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtlydokhenthuong.StylePriority.UseBorders = false;
            this.xrtlydokhenthuong.StylePriority.UseFont = false;
            this.xrtlydokhenthuong.StylePriority.UsePadding = false;
            this.xrtlydokhenthuong.StylePriority.UseTextAlignment = false;
            this.xrtlydokhenthuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrtlydokhenthuong.Weight = 1.250169401283479D;
            // 
            // xrthinhthuc
            // 
            this.xrthinhthuc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrthinhthuc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrthinhthuc.Name = "xrthinhthuc";
            this.xrthinhthuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrthinhthuc.StylePriority.UseBorders = false;
            this.xrthinhthuc.StylePriority.UseFont = false;
            this.xrthinhthuc.StylePriority.UsePadding = false;
            this.xrthinhthuc.StylePriority.UseTextAlignment = false;
            this.xrthinhthuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrthinhthuc.Weight = 1.0376693643114345D;
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
            this.BottomMargin.HeightF = 49F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ngayBC,
            this.xrl_tencongty,
            this.xrl_thanhpho,
            this.xrl_TitleBC});
            this.ReportHeader.HeightF = 110.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_ngayBC
            // 
            this.xrl_ngayBC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_ngayBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrl_ngayBC.Name = "xrl_ngayBC";
            this.xrl_ngayBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ngayBC.SizeF = new System.Drawing.SizeF(1085F, 23F);
            this.xrl_ngayBC.StylePriority.UseFont = false;
            this.xrl_ngayBC.StylePriority.UseTextAlignment = false;
            this.xrl_ngayBC.Text = "Từ ngày ... đến ngày ...";
            this.xrl_ngayBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrl_tencongty
            // 
            this.xrl_tencongty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_tencongty.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99999F);
            this.xrl_tencongty.Name = "xrl_tencongty";
            this.xrl_tencongty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tencongty.SizeF = new System.Drawing.SizeF(344.7499F, 23F);
            this.xrl_tencongty.StylePriority.UseFont = false;
            this.xrl_tencongty.StylePriority.UseTextAlignment = false;
            this.xrl_tencongty.Text = "CÔNG TY CỔ PHẦN THẾ GIỚI GIẢI TRÍ";
            this.xrl_tencongty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_thanhpho
            // 
            this.xrl_thanhpho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_thanhpho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_thanhpho.Name = "xrl_thanhpho";
            this.xrl_thanhpho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_thanhpho.SizeF = new System.Drawing.SizeF(344.7499F, 23F);
            this.xrl_thanhpho.StylePriority.UseFont = false;
            this.xrl_thanhpho.StylePriority.UseTextAlignment = false;
            this.xrl_thanhpho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_thanhpho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1085F, 23.00001F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO KHEN THƯỞNG KÝ LUẬT";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 41.45834F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1085F, 41.45834F);
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell3,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBorders = false;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.37500001173753095D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Mã cán bộ";
            this.xrTableCell2.Weight = 0.69791659821576546D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Họ tên";
            this.xrTableCell7.Weight = 1.3333336482689893D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Ngày sinh";
            this.xrTableCell4.Weight = 0.80208341384065063D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Giới tính";
            this.xrTableCell3.Weight = 0.65083310545666861D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Phòng ban";
            this.xrTableCell5.Weight = 1.7214591706882605D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Chức vụ";
            this.xrTableCell6.Weight = 1.3138543287197235D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Số QĐ";
            this.xrTableCell8.Weight = 0.83400919869706591D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Ngày QĐ";
            this.xrTableCell9.Weight = 0.83367260727366754D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Lý do";
            this.xrTableCell10.Weight = 1.2501692182436912D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Hình thức";
            this.xrTableCell11.Weight = 1.0376679875636086D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten1,
            this.xrl_ten2,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer2,
            this.xrl_footer3,
            this.xrl_footer1});
            this.ReportFooter.HeightF = 161F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 135.4167F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(305.5832F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(361.9583F, 135.4167F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(368.8486F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(771.9583F, 135.4167F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(313.0417F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(771.9583F, 10.41667F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(313.0417F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(361.9583F, 35.41667F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(374.8486F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "PHÒNG TCHC";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(771.9583F, 35.41667F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(313.0417F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.41667F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(305.5832F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_bophan});
            this.GroupHeader1.HeightF = 23F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(958.9583F, 38.54167F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrl_bophan
            // 
            this.xrl_bophan.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrl_bophan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_bophan.Name = "xrl_bophan";
            this.xrl_bophan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrl_bophan.SizeF = new System.Drawing.SizeF(1085F, 23F);
            this.xrl_bophan.StylePriority.UseBorders = false;
            // 
            // rp_BaoCaoKhenThuongKyLuatTrongThang
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(6, 9, 50, 49);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
