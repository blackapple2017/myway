using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_DanhSachDenTuyenDung
/// </summary>
public class rp_DanhSachDenTuyenDung : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private GroupHeaderBand GroupHeader1;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TieuDe;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_STT;
    private XRTableCell xrt_MaUV;
    private XRTableCell xrt_HoTen;
    private XRTableCell xrt_GioiTinh;
    private XRTableCell xrt_NamSinh;
    private XRTableCell xrt_TongDiemPV;
    private XRTableCell xrt_LyDoDuaVaoKho;
    private XRTableCell xrt_TruongDaoTao;
    private XRTableCell xrt_ChuyenNghanh;
    private XRTableCell xrt_DaTrungTuyen;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_DotTuyenDung;
    private XRLabel xrl_NgayBaoCao;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DanhSachDenTuyenDung()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;

    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrt_STT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter,string reportType)
    { 
    
     if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
         
            xrl_TieuDe.Text = filter.ReportTitle.ToUpper();
            xrl_NgayBaoCao.Text = "Ngày báo cáo: " + string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        }
    //
        DataTable dt = new DataTable();
        dt = DataController.DataHandler.GetInstance().ExecuteDataTable("report_DanhSachDen_KhoDuTru", "@BlackListOrStore", "@WhereClause", reportType,filter.WhereClause);
        if (dt.Rows.Count > 0)
        {
            DataSource = dt;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TEN_DOT_TD", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            xrt_DotTuyenDung.DataBindings.Add("Text", DataSource, "TEN_DOT_TD");
            xrt_MaUV.DataBindings.Add("Text", DataSource, "MA_UNG_VIEN");
            xrt_HoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrt_GioiTinh.DataBindings.Add("Text", DataSource, "GIOI_TINH");
            xrt_NamSinh.DataBindings.Add("Text", DataSource, "NGAY_SINH");
            xrt_TongDiemPV.DataBindings.Add("Text", DataSource, "TONGDIEM");
            xrt_LyDoDuaVaoKho.DataBindings.Add("Text", DataSource, "LY_DO");
            xrt_TruongDaoTao.DataBindings.Add("Text", DataSource, "TRUONG_DAOTAO");
            xrt_ChuyenNghanh.DataBindings.Add("Text", DataSource, "KHOA");
            xrt_DaTrungTuyen.DataBindings.Add("Text", DataSource, "DA_TRUNG_TUYEN");

            



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
            string resourceFileName = "rp_Danhsachden_KhoDuTruTuyenDung.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_STT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_MaUV = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_HoTen = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_GioiTinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_NamSinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TongDiemPV = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_LyDoDuaVaoKho = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TruongDaoTao = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ChuyenNghanh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_DaTrungTuyen = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_NgayBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TieuDe = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_DotTuyenDung = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail.HeightF = 46.17F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(910F, 46.17F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_STT,
            this.xrt_MaUV,
            this.xrt_HoTen,
            this.xrt_GioiTinh,
            this.xrt_NamSinh,
            this.xrt_TongDiemPV,
            this.xrt_LyDoDuaVaoKho,
            this.xrt_TruongDaoTao,
            this.xrt_ChuyenNghanh,
            this.xrt_DaTrungTuyen});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrt_STT
            // 
            this.xrt_STT.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_STT.Name = "xrt_STT";
            this.xrt_STT.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_STT.StylePriority.UseFont = false;
            this.xrt_STT.StylePriority.UsePadding = false;
            this.xrt_STT.StylePriority.UseTextAlignment = false;
            this.xrt_STT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_STT.Weight = 0.19369492766837648D;
            this.xrt_STT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_MaUV
            // 
            this.xrt_MaUV.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_MaUV.Name = "xrt_MaUV";
            this.xrt_MaUV.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_MaUV.StylePriority.UseFont = false;
            this.xrt_MaUV.StylePriority.UsePadding = false;
            this.xrt_MaUV.StylePriority.UseTextAlignment = false;
            this.xrt_MaUV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_MaUV.Weight = 0.28861830983165448D;
            // 
            // xrt_HoTen
            // 
            this.xrt_HoTen.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_HoTen.Name = "xrt_HoTen";
            this.xrt_HoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_HoTen.StylePriority.UseFont = false;
            this.xrt_HoTen.StylePriority.UsePadding = false;
            this.xrt_HoTen.StylePriority.UseTextAlignment = false;
            this.xrt_HoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_HoTen.Weight = 0.558491191528903D;
            // 
            // xrt_GioiTinh
            // 
            this.xrt_GioiTinh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_GioiTinh.Name = "xrt_GioiTinh";
            this.xrt_GioiTinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_GioiTinh.StylePriority.UseFont = false;
            this.xrt_GioiTinh.StylePriority.UsePadding = false;
            this.xrt_GioiTinh.StylePriority.UseTextAlignment = false;
            this.xrt_GioiTinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_GioiTinh.Weight = 0.26337940935316784D;
            // 
            // xrt_NamSinh
            // 
            this.xrt_NamSinh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_NamSinh.Name = "xrt_NamSinh";
            this.xrt_NamSinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrt_NamSinh.StylePriority.UseFont = false;
            this.xrt_NamSinh.StylePriority.UsePadding = false;
            this.xrt_NamSinh.StylePriority.UseTextAlignment = false;
            this.xrt_NamSinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_NamSinh.Weight = 0.32741260595150834D;
            // 
            // xrt_TongDiemPV
            // 
            this.xrt_TongDiemPV.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_TongDiemPV.Name = "xrt_TongDiemPV";
            this.xrt_TongDiemPV.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrt_TongDiemPV.StylePriority.UseFont = false;
            this.xrt_TongDiemPV.StylePriority.UsePadding = false;
            this.xrt_TongDiemPV.StylePriority.UseTextAlignment = false;
            this.xrt_TongDiemPV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_TongDiemPV.Weight = 0.41741252414725527D;
            // 
            // xrt_LyDoDuaVaoKho
            // 
            this.xrt_LyDoDuaVaoKho.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_LyDoDuaVaoKho.Name = "xrt_LyDoDuaVaoKho";
            this.xrt_LyDoDuaVaoKho.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_LyDoDuaVaoKho.StylePriority.UseFont = false;
            this.xrt_LyDoDuaVaoKho.StylePriority.UsePadding = false;
            this.xrt_LyDoDuaVaoKho.StylePriority.UseTextAlignment = false;
            this.xrt_LyDoDuaVaoKho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_LyDoDuaVaoKho.Weight = 0.54905580327885117D;
            // 
            // xrt_TruongDaoTao
            // 
            this.xrt_TruongDaoTao.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_TruongDaoTao.Name = "xrt_TruongDaoTao";
            this.xrt_TruongDaoTao.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_TruongDaoTao.StylePriority.UseFont = false;
            this.xrt_TruongDaoTao.StylePriority.UsePadding = false;
            this.xrt_TruongDaoTao.StylePriority.UseTextAlignment = false;
            this.xrt_TruongDaoTao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_TruongDaoTao.Weight = 0.582430374947136D;
            // 
            // xrt_ChuyenNghanh
            // 
            this.xrt_ChuyenNghanh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_ChuyenNghanh.Name = "xrt_ChuyenNghanh";
            this.xrt_ChuyenNghanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_ChuyenNghanh.StylePriority.UseFont = false;
            this.xrt_ChuyenNghanh.StylePriority.UsePadding = false;
            this.xrt_ChuyenNghanh.StylePriority.UseTextAlignment = false;
            this.xrt_ChuyenNghanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_ChuyenNghanh.Weight = 0.57761609522583768D;
            // 
            // xrt_DaTrungTuyen
            // 
            this.xrt_DaTrungTuyen.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrt_DaTrungTuyen.Multiline = true;
            this.xrt_DaTrungTuyen.Name = "xrt_DaTrungTuyen";
            this.xrt_DaTrungTuyen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_DaTrungTuyen.StylePriority.UseFont = false;
            this.xrt_DaTrungTuyen.StylePriority.UsePadding = false;
            this.xrt_DaTrungTuyen.StylePriority.UseTextAlignment = false;
            this.xrt_DaTrungTuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_DaTrungTuyen.Weight = 0.33501883860422005D;
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
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_NgayBaoCao,
            this.xrl_TieuDe});
            this.ReportHeader.HeightF = 109.3333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_NgayBaoCao
            // 
            this.xrl_NgayBaoCao.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrl_NgayBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 76.3333F);
            this.xrl_NgayBaoCao.Name = "xrl_NgayBaoCao";
            this.xrl_NgayBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NgayBaoCao.SizeF = new System.Drawing.SizeF(929.9999F, 23F);
            this.xrl_NgayBaoCao.StylePriority.UseFont = false;
            this.xrl_NgayBaoCao.StylePriority.UseTextAlignment = false;
            this.xrl_NgayBaoCao.Text = "Ngày cáo cáo : 28/09/2014";
            this.xrl_NgayBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrl_TieuDe
            // 
            this.xrl_TieuDe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TieuDe.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
            this.xrl_TieuDe.Name = "xrl_TieuDe";
            this.xrl_TieuDe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TieuDe.SizeF = new System.Drawing.SizeF(930F, 27.54168F);
            this.xrl_TieuDe.StylePriority.UseFont = false;
            this.xrl_TieuDe.StylePriority.UseTextAlignment = false;
            this.xrl_TieuDe.Text = "DANH SÁCH ĐEN TUYỀN DỤNG";
            this.xrl_TieuDe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 34.375F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(909.9999F, 34.375F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell3,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "STT";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell11.Weight = 0.19369492766837648D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Mã UV";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell1.Weight = 0.28861830983165448D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Họ Tên";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell2.Weight = 0.558491191528903D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Giới tính";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell4.Weight = 0.26337940935316784D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Năm sinh";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell5.Weight = 0.32741260595150834D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Tổng điểm PV";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell6.Weight = 0.41741252414725527D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Lý do đưa vào kho";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell7.Weight = 0.54905580327885117D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Trường đạo tạo";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell3.Weight = 0.582430374947136D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "Chuyên nghành";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell8.Weight = 0.57761609522583768D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Đã trúng tuyển\r\n";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell9.Weight = 0.33501856407143538D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.HeightF = 34F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(909.9999F, 34F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_DotTuyenDung});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_DotTuyenDung
            // 
            this.xrt_DotTuyenDung.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_DotTuyenDung.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrt_DotTuyenDung.Name = "xrt_DotTuyenDung";
            this.xrt_DotTuyenDung.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
            this.xrt_DotTuyenDung.StylePriority.UseBorders = false;
            this.xrt_DotTuyenDung.StylePriority.UseFont = false;
            this.xrt_DotTuyenDung.StylePriority.UsePadding = false;
            this.xrt_DotTuyenDung.StylePriority.UseTextAlignment = false;
            this.xrt_DotTuyenDung.Text = "Lập trình .NET";
            this.xrt_DotTuyenDung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_DotTuyenDung.Weight = 1.512997577131332D;
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // rp_DanhSachDenTuyenDung
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(78, 92, 0, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
