using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoChiTietMotDotTuyenDung
/// </summary>
public class rp_BaoCaoChiTietMotDotTuyenDung : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ThangBaoCao;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xr_tenkehoach;
    private XRTableCell xr_ngaybatdau;
    private XRTableCell xr_yeucaudoivoiungvien;
    private XRTableCell xr_stt;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xr_detailstt;
    private XRTableCell xrt_lydotuyen;
    private XRTableCell xrt_PhongBan;
    private XRTableCell xr_detailtenkehoach;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrt_soluong;
    private XRTableCell xrt_kinhphidutru;
    private XRTableCell xrtNgayBatDau;
    private XRTableCell xrt_NgayKetThuc;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BaoCaoChiTietMotDotTuyenDung()
	{
		InitializeComponent();
		 try
        { 
            HeThongController ht = new HeThongController();
            string city = "CITY";
          
            xrl_ThangBaoCao.Text = "Ngày báo cáo:" + string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            xrtngayketxuat.Text = " Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        }
        catch(Exception ex)
        {
            xrl_TitleBC.Text = ex.Message;
        }
       
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xr_detailstt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        //xrl_TenCongTy.Text = filter.TenDonVi;
        //xrl_TenThanhPho.Text = filter.TenThanhPho;
        //if (string.IsNullOrEmpty(filter.thang) || string.IsNullOrEmpty(filter.TenBaoCao))
        //{
        //    xrl_TitleBC.Text = "BÁO CÁO CHI TIẾT 1 ĐỢT TUYỂN DỤNG";
        //}
        //else
        //{
        //    xrl_TitleBC.Text = filter.TenBaoCao.ToUpper();
        //}
        //DataTable table = DataHandler.GetInstance().ExecuteDataTable("rp_ChiTietMotDotTuyenDung", "@MaDonVi", "@TrangThaiXuLy", "@MaPhongBan", filter.MaDonVi,"",filter.MaPhongBan);
        //DataSource = table;
        //xr_detailtenkehoach.DataBindings.Add("Text", DataSource, "TenKeHoach");
        //xrt_kinhphidutru.DataBindings.Add("Text", DataSource, "KinhPhiDuTru","{0:0,0}");
        //xrt_lydotuyen.DataBindings.Add("Text", DataSource, "LyDoTuyen");
        //xrt_NgayKetThuc.DataBindings.Add("Text", DataSource, "HanNopHoSo", "{0:dd/MM/yyyy}");
        //xrt_PhongBan.DataBindings.Add("Text", DataSource, "TEN_PHONG");
        //xrtNgayBatDau.DataBindings.Add("Text", DataSource, "NgayBatDau", "{0:dd/MM/yyyy}");
        //xrt_soluong.DataBindings.Add("Text", DataSource, "SoLuongCanTuyen");
        //xrt_lydotuyen.DataBindings.Add("Text", DataSource, "NgayBatDau","{0:dd/MM/yyyy}");
      

        //if (!string.IsNullOrEmpty(filter.Footer1))
        //{
        //    xrl_footer1.Text = filter.Footer1;
        //}
        //if (!string.IsNullOrEmpty(filter.Footer2))
        //{
        //    xrl_footer2.Text = filter.Footer2;
        //}
        //if (!string.IsNullOrEmpty(filter.Footer3))
        //{
        //    xrl_footer3.Text = filter.Footer3;
        //}

        //if (!string.IsNullOrEmpty(filter.Ten1))
        //{
        //    xrl_ten1.Text = filter.Ten1;
        //}
        //else
        //{
        //    xrl_ten1.Text = filter.NguoiLapBaoCao.ToString();
        //}
        //if (!string.IsNullOrEmpty(filter.Ten2))
        //{
        //    xrl_ten2.Text = filter.Ten2;
        //}
        //if (!string.IsNullOrEmpty(filter.Ten3))
        //{
        //    xrl_ten3.Text = filter.Ten3;
        //}
       // this.xr_yeucaudoivoiungvien.Weight = 1.1539266933738963D;
       // this.xr_yeucaudoivoiungvien.Weight = 0.1;
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
            string resourceFileName = "rp_BaoCaoChiTietMotDotTuyenDung.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xr_detailstt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_detailtenkehoach = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_lydotuyen = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_PhongBan = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_ThangBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xr_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_tenkehoach = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_ngaybatdau = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_yeucaudoivoiungvien = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_soluong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_kinhphidutru = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtNgayBatDau = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_NgayKetThuc = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
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
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1075.708F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xr_detailstt,
            this.xr_detailtenkehoach,
            this.xrt_lydotuyen,
            this.xrt_soluong,
            this.xrt_kinhphidutru,
            this.xrtNgayBatDau,
            this.xrt_NgayKetThuc,
            this.xrt_PhongBan});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xr_detailstt
            // 
            this.xr_detailstt.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_detailstt.Name = "xr_detailstt";
            this.xr_detailstt.StylePriority.UseBorders = false;
            this.xr_detailstt.Weight = 0.10795204762668853D;
            this.xr_detailstt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xr_detailtenkehoach
            // 
            this.xr_detailtenkehoach.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_detailtenkehoach.Name = "xr_detailtenkehoach";
            this.xr_detailtenkehoach.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xr_detailtenkehoach.StylePriority.UseBorders = false;
            this.xr_detailtenkehoach.StylePriority.UsePadding = false;
            this.xr_detailtenkehoach.StylePriority.UseTextAlignment = false;
            this.xr_detailtenkehoach.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xr_detailtenkehoach.Weight = 0.61870217160470065D;
            // 
            // xrt_lydotuyen
            // 
            this.xrt_lydotuyen.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_lydotuyen.Name = "xrt_lydotuyen";
            this.xrt_lydotuyen.StylePriority.UseBorders = false;
            this.xrt_lydotuyen.Weight = 0.63866735845096256D;
            // 
            // xrt_PhongBan
            // 
            this.xrt_PhongBan.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_PhongBan.Name = "xrt_PhongBan";
            this.xrt_PhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_PhongBan.StylePriority.UseBorders = false;
            this.xrt_PhongBan.StylePriority.UsePadding = false;
            this.xrt_PhongBan.StylePriority.UseTextAlignment = false;
            this.xrt_PhongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_PhongBan.Weight = 0.37858670503072145D;
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
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ThangBaoCao,
            this.xrl_TitleBC,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 113F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_ThangBaoCao
            // 
            this.xrl_ThangBaoCao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_ThangBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.58332F);
            this.xrl_ThangBaoCao.Name = "xrl_ThangBaoCao";
            this.xrl_ThangBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ThangBaoCao.SizeF = new System.Drawing.SizeF(1075.708F, 23.00001F);
            this.xrl_ThangBaoCao.StylePriority.UseFont = false;
            this.xrl_ThangBaoCao.StylePriority.UseTextAlignment = false;
            this.xrl_ThangBaoCao.Text = "Tháng 3 năm 2013";
            this.xrl_ThangBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.58334F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1075.708F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO CHI TIẾT CỦA ĐỢT TUYỂN DỤNG";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.083333F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(477.4739F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 27.08333F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(477.4739F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 29.16667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1076F, 29.16667F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xr_stt,
            this.xr_tenkehoach,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xr_ngaybatdau,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xr_yeucaudoivoiungvien});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xr_stt
            // 
            this.xr_stt.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xr_stt.Name = "xr_stt";
            this.xr_stt.StylePriority.UseFont = false;
            this.xr_stt.StylePriority.UseTextAlignment = false;
            this.xr_stt.Text = "STT";
            this.xr_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xr_stt.Weight = 0.1079228305462125D;
            // 
            // xr_tenkehoach
            // 
            this.xr_tenkehoach.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xr_tenkehoach.Name = "xr_tenkehoach";
            this.xr_tenkehoach.StylePriority.UseFont = false;
            this.xr_tenkehoach.StylePriority.UseTextAlignment = false;
            this.xr_tenkehoach.Text = "Tên kế hoạch";
            this.xr_tenkehoach.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xr_tenkehoach.Weight = 0.61853419094723816D;
            // 
            // xr_ngaybatdau
            // 
            this.xr_ngaybatdau.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xr_ngaybatdau.Name = "xr_ngaybatdau";
            this.xr_ngaybatdau.StylePriority.UseFont = false;
            this.xr_ngaybatdau.StylePriority.UseTextAlignment = false;
            this.xr_ngaybatdau.Text = "Kinh phí dự trù";
            this.xr_ngaybatdau.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xr_ngaybatdau.Weight = 0.31152706429860849D;
            // 
            // xr_yeucaudoivoiungvien
            // 
            this.xr_yeucaudoivoiungvien.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xr_yeucaudoivoiungvien.Name = "xr_yeucaudoivoiungvien";
            this.xr_yeucaudoivoiungvien.StylePriority.UseFont = false;
            this.xr_yeucaudoivoiungvien.StylePriority.UseTextAlignment = false;
            this.xr_yeucaudoivoiungvien.Text = "Phòng ban";
            this.xr_yeucaudoivoiungvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xr_yeucaudoivoiungvien.Weight = 0.37929821014404297D;
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
            this.ReportFooter.HeightF = 194F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(787.4995F, 161F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(288.2083F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(374.9994F, 161F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(295.9726F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 161F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(295.9726F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(787.4995F, 18.75F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(288.2084F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 43.75F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(297.9736F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(787.4995F, 43.75F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(288.2086F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(374.9994F, 43.75F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(297.9735F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "PHÒNG TCHC";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.HeightF = 29F;
            this.GroupHeader1.Name = "GroupHeader1";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(939.9583F, 30.20833F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Lý do tuyển";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.6384939526979807D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Số lượng";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 0.30028760477512745D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Ngày bắt đầu";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.32429151995917688D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Ngày kết thúc";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 0.31964462663161264D;
            // 
            // xrt_soluong
            // 
            this.xrt_soluong.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_soluong.Name = "xrt_soluong";
            this.xrt_soluong.StylePriority.UseBorders = false;
            this.xrt_soluong.Weight = 0.30036893131951048D;
            // 
            // xrt_kinhphidutru
            // 
            this.xrt_kinhphidutru.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_kinhphidutru.Name = "xrt_kinhphidutru";
            this.xrt_kinhphidutru.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_kinhphidutru.StylePriority.UseBorders = false;
            this.xrt_kinhphidutru.StylePriority.UsePadding = false;
            this.xrt_kinhphidutru.StylePriority.UseTextAlignment = false;
            this.xrt_kinhphidutru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_kinhphidutru.Weight = 0.31161174829065336D;
            // 
            // xrtNgayBatDau
            // 
            this.xrtNgayBatDau.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtNgayBatDau.Name = "xrtNgayBatDau";
            this.xrtNgayBatDau.StylePriority.UseBorders = false;
            this.xrtNgayBatDau.Weight = 0.32437978304435305D;
            // 
            // xrt_NgayKetThuc
            // 
            this.xrt_NgayKetThuc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_NgayKetThuc.Name = "xrt_NgayKetThuc";
            this.xrt_NgayKetThuc.StylePriority.UseBorders = false;
            this.xrt_NgayKetThuc.Weight = 0.31973125463241003D;
            // 
            // rp_BaoCaoChiTietMotDotTuyenDung
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 12, 50, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
