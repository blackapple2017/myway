using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_DanhSachTaiSanTheoPhongBan
/// </summary>
public class rp_DanhSachTaiSanTheoPhongBan : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private GroupHeaderBand GroupHeader1;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_phongban;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_STT;
    private XRTableCell xrt_MaNhanVien;
    private XRTableCell xrt_TenNhanVien;
    private XRTableCell xrt_SoLuong;
    private XRTableCell xrt_ngaytra;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    private XRLabel xr_ten1;
    private XRLabel xr_footer1;
    private XRTableCell xrTableCell6;
    private XRTableCell xrl_donvitinh;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrl_tinhtrang;
    private XRTableCell xrTableCell8;
    private XRTableCell xrt_ngaynhan;
    private XRLabel xrl_tungay;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell11;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DanhSachTaiSanTheoPhongBan()
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
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrt_STT.Text = STT.ToString();
        STT++;
    }
    public void BinData(ReportFilter filter)
    {
        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        xrl_TenThanhPho.Text = ReportController.GetInstance().GetCityName(filter.SessionDepartment);
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_TitleBC.Text = filter.ReportTitle.ToUpper();
        } 
        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("report_BaoCaoTaiSanTheoPhongBan", "@MaDonVi",
                                                                                                 "@MaBoPhan",
                                                                                                 "@Gender",
                                                                                                 "@WorkingStatus",
                                                                                                 "@MinSeniority",
                                                                                                 "@MaxSeniority",
                                                                                                 "@WhereClause",
                                                                                                filter.SessionDepartment,
                                                                                                filter.SelectedDepartment,
                                                                                                filter.Gender,
                                                                                                filter.WorkingStatus,
                                                                                                filter.MinSeniority,
                                                                                                filter.MaxSeniority,
                                                                                                filter.WhereClause);
        DataSource = table;

        xrt_MaNhanVien.DataBindings.Add("Text", DataSource, "MA_CB"); 
        xrt_TenNhanVien.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrt_SoLuong.DataBindings.Add("Text", DataSource, "MA_VTHH");
        xrl_donvitinh.DataBindings.Add("Text", DataSource, "TEN_VTHH");
        xrl_tinhtrang.DataBindings.Add("Text", DataSource, "SoLuong");
        xrt_ngaynhan.DataBindings.Add("Text", DataSource, "TEN_DVT");
        xrTableCell12.DataBindings.Add("Text", DataSource, "HanSuDung", "{0:dd/MM/yyyy}");
     //   xrt_ngaytra.DataBindings.Add("Text", DataSource, "TEN_DVT", "{0:dd/MM/yyyy}"); 
        xrTableCell10.DataBindings.Add("Text", DataSource, "NGAY_NHAN", "{0:dd/MM/yyyy}");
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrt_phongban.DataBindings.Add("Text", DataSource, "TEN_DONVI");

        xrl_ten3.Text = ReportController.GetInstance().GetDirectorName(filter.SessionDepartment, filter.Name3);
     
    }
    // tên store
    //điều kiện lọc
    // điều kiện lọc
    // phòng ban, mã đơn vị, loại tài sản dạng combo grid
	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
            string resourceFileName = "rp_DanhSachTaiSanTheoPhongBan.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_STT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_MaNhanVien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TenNhanVien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_SoLuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrl_donvitinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrl_tinhtrang = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngaynhan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngaytra = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xr_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_tungay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1079F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_STT,
            this.xrt_MaNhanVien,
            this.xrt_TenNhanVien,
            this.xrt_SoLuong,
            this.xrl_donvitinh,
            this.xrl_tinhtrang,
            this.xrt_ngaynhan,
            this.xrt_ngaytra,
            this.xrTableCell12,
            this.xrTableCell10});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrt_STT
            // 
            this.xrt_STT.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_STT.Name = "xrt_STT";
            this.xrt_STT.StylePriority.UseFont = false;
            this.xrt_STT.Text = "\t";
            this.xrt_STT.Weight = 0.11387851619700924D;
            this.xrt_STT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_MaNhanVien
            // 
            this.xrt_MaNhanVien.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_MaNhanVien.Name = "xrt_MaNhanVien";
            this.xrt_MaNhanVien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrt_MaNhanVien.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrt_MaNhanVien.StylePriority.UseFont = false;
            this.xrt_MaNhanVien.StylePriority.UsePadding = false;
            this.xrt_MaNhanVien.StylePriority.UseTextAlignment = false;
            this.xrt_MaNhanVien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_MaNhanVien.Weight = 0.26737717154461393D;
            // 
            // xrt_TenNhanVien
            // 
            this.xrt_TenNhanVien.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_TenNhanVien.Name = "xrt_TenNhanVien";
            this.xrt_TenNhanVien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrt_TenNhanVien.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrt_TenNhanVien.StylePriority.UseFont = false;
            this.xrt_TenNhanVien.StylePriority.UsePadding = false;
            this.xrt_TenNhanVien.StylePriority.UseTextAlignment = false;
            this.xrt_TenNhanVien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_TenNhanVien.Weight = 0.49907344634223572D;
            // 
            // xrt_SoLuong
            // 
            this.xrt_SoLuong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_SoLuong.Name = "xrt_SoLuong";
            this.xrt_SoLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.xrt_SoLuong.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
            this.xrt_SoLuong.StylePriority.UseFont = false;
            this.xrt_SoLuong.StylePriority.UsePadding = false;
            this.xrt_SoLuong.StylePriority.UseTextAlignment = false;
            this.xrt_SoLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_SoLuong.Weight = 0.2586882173546089D;
            // 
            // xrl_donvitinh
            // 
            this.xrl_donvitinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_donvitinh.Name = "xrl_donvitinh";
            this.xrl_donvitinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrl_donvitinh.StylePriority.UseFont = false;
            this.xrl_donvitinh.StylePriority.UsePadding = false;
            this.xrl_donvitinh.StylePriority.UseTextAlignment = false;
            this.xrl_donvitinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrl_donvitinh.Weight = 0.50631379238468532D;
            // 
            // xrl_tinhtrang
            // 
            this.xrl_tinhtrang.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_tinhtrang.Name = "xrl_tinhtrang";
            this.xrl_tinhtrang.StylePriority.UseFont = false;
            this.xrl_tinhtrang.Weight = 0.21249432822741843D;
            // 
            // xrt_ngaynhan
            // 
            this.xrt_ngaynhan.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ngaynhan.Name = "xrt_ngaynhan";
            this.xrt_ngaynhan.StylePriority.UseFont = false;
            this.xrt_ngaynhan.Weight = 0.25105710813878046D;
            // 
            // xrt_ngaytra
            // 
            this.xrt_ngaytra.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ngaytra.Name = "xrt_ngaytra";
            this.xrt_ngaytra.StylePriority.UseFont = false;
            this.xrt_ngaytra.Weight = 0.44555870990532409D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Weight = 0.44555870990532409D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 11F;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 25F;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(1079F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell1,
            this.xrTableCell5,
            this.xrTableCell2,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell3,
            this.xrTableCell11,
            this.xrTableCell9});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.Weight = 0.14857920193470375D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Mã nhân viên";
            this.xrTableCell1.Weight = 0.34885122352240305D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Nhân viên sử dụng";
            this.xrTableCell5.Weight = 0.65114897021071083D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Thẻ tài sản";
            this.xrTableCell2.Weight = 0.33751473663219372D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Tên tài sản";
            this.xrTableCell6.Weight = 0.66059559057528627D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Số lượng";
            this.xrTableCell7.Weight = 0.27724470163919618D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Đơn vị tính";
            this.xrTableCell8.Weight = 0.32755818995483837D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Tình trạng";
            this.xrTableCell3.Weight = 0.58132757509922406D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Ngày nhận";
            this.xrTableCell9.Weight = 0.581327453345745D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xr_ten1,
            this.xr_footer1,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer3});
            this.ReportFooter.HeightF = 195F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xr_ten1
            // 
            this.xr_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xr_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160.4167F);
            this.xr_ten1.Name = "xr_ten1";
            this.xr_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_ten1.SizeF = new System.Drawing.SizeF(288.2083F, 23F);
            this.xr_ten1.StylePriority.UseFont = false;
            this.xr_ten1.StylePriority.UseTextAlignment = false;
            this.xr_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xr_footer1
            // 
            this.xr_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xr_footer1.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 48.95833F);
            this.xr_footer1.Name = "xr_footer1";
            this.xr_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_footer1.SizeF = new System.Drawing.SizeF(288.2086F, 23F);
            this.xr_footer1.StylePriority.UseFont = false;
            this.xr_footer1.StylePriority.UseTextAlignment = false;
            this.xr_footer1.Text = "PHÒNG HCNS";
            this.xr_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(789.7496F, 160.4167F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(288.2084F, 23.00001F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(790.7913F, 23.95833F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(288.2084F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(790.7913F, 48.95833F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(288.2086F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "TỔNG GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1079F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_phongban});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
            this.xrt_phongban.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
            this.xrt_phongban.StylePriority.UsePadding = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.Text = "Phòng ban";
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_phongban.Weight = 3D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_tungay,
            this.xrl_TitleBC,
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
            this.ReportHeader.HeightF = 126F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_tungay
            // 
            this.xrl_tungay.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_tungay.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 97.99998F);
            this.xrl_tungay.Name = "xrl_tungay";
            this.xrl_tungay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tungay.SizeF = new System.Drawing.SizeF(1079F, 20.00002F);
            this.xrl_tungay.StylePriority.UseFont = false;
            this.xrl_tungay.StylePriority.UseTextAlignment = false;
            this.xrl_tungay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1079F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "DANH SÁCH TÀI SẢN CẤP PHÁT CHO NHÂN VIÊN THEO PHÒNG BAN";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(421.4742F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.5F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(421.4742F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(951.9163F, 22.91667F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Hạn sử dụng";
            this.xrTableCell11.Weight = 0.58132733159226591D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Weight = 0.44555870990532409D;
            // 
            // rp_DanhSachTaiSanTheoPhongBan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.ReportHeader,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(11, 10, 11, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "14.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
