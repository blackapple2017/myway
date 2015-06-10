using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Controller.DanhGia;
using System.Data;

/// <summary>
/// Summary description for rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi
/// </summary>
public class rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrlblTenDotDG;
    private XRLabel xrlblRpTitle;
    private XRLabel xrlblNgayDanhGia;
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
    private XRTableCell xrt_donvi;
    private XRTableCell xrt_songuoiduoctructiep;
    private XRTableCell xrt_ghichu;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_phongban;
    private XRTableCell xrt_tongcbnv;
    private XRTableCell xrt_songuotudanhgia;
    private XRTableCell xrt_songuoiduoccanbodanhgia;
    private XRLabel xrlblNgayTao;
    private XRLabel xrLabel12;
    private XRLabel xrlblTieuDe3;
    private XRLabel xrLabel14;
    private XRLabel xrlblTieuDe1;
    private XRLabel xrLabel10;
    private XRLabel xrlblTieuDe2;
    private XRLabel xrlblNguoiLapBC;
    private XRLabel xrlblChuKy2;
    private XRLabel xrlblChuKy3;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi()
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

    public void BindData(ReportFilter filter)
    {
        //if (filter.TenBaoCao != "")
        //    xrlblRpTitle.Text = filter.TenBaoCao;
        //if (!filter.NgayDanhGia.ToString().Contains("0001"))
        //    xrlblNgayDanhGia.Text = "Ngày: " + filter.NgayDanhGia.Date;
        //xrlblNgayTao.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //DAL.DotDanhGia ddg = new DotDanhGiaController().GetByPrkey(filter.MaDotDanhGia);
        //xrlblTenDotDG.Text = "Đợt đánh giá: " + ddg.TenDotDanhGia;
        //xrlblNgayDanhGia.Text = "Ngày: " + filter.NgayDanhGia.ToString("dd/MM/yyyy");
        //DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_DanhGia_TheoDoiTongHopTienDoDanhGia", "@MaDotDanhGia", "@Ngay", filter.MaDotDanhGia, filter.NgayDanhGia);
        //DataSource = table;
        //xrt_stt.DataBindings.Add("Text", DataSource, "SK");
        //xrt_phongban.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        //xrt_donvi.Text = new DM_DONVIController().GetNameById(filter.MaDonVi);
        //xrt_tongcbnv.DataBindings.Add("Text", DataSource, "TongCanBo");
        //xrt_songuotudanhgia.DataBindings.Add("Text", DataSource, "TongTuDG");
        //xrt_songuoiduoctructiep.DataBindings.Add("Text", DataSource, "TongNguoiKhacDG");
        //xrt_songuoiduoccanbodanhgia.DataBindings.Add("Text", DataSource, "TongQLDG");

        //// footer
        //if (filter.Footer1 != "")
        //    xrlblTieuDe1.Text = filter.Footer1;
        //if (filter.Footer2 != "")
        //    xrlblTieuDe2.Text = filter.Footer2;
        //if (filter.Footer3 != "")
        //    xrlblTieuDe3.Text = filter.Footer3;

        //xrlblNguoiLapBC.Text = filter.NguoiLapBaoCao;
        //xrlblChuKy2.Text = filter.Ten2;
        //xrlblChuKy3.Text = filter.Ten3;
    }

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
            string resourceFileName = "rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_donvi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongcbnv = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_songuotudanhgia = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_songuoiduoctructiep = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_songuoiduoccanbodanhgia = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrlblNgayDanhGia = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTenDotDG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblRpTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlblChuKy3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblChuKy2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblNguoiLapBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblNgayTao = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
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
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(823.9999F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_phongban,
            this.xrt_donvi,
            this.xrt_tongcbnv,
            this.xrt_songuotudanhgia,
            this.xrt_songuoiduoctructiep,
            this.xrt_songuoiduoccanbodanhgia,
            this.xrt_ghichu});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseTextAlignment = false;
            this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_stt.Weight = 0.13652898972237265D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_phongban.StylePriority.UsePadding = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_phongban.Weight = 0.47785201572947616D;
            // 
            // xrt_donvi
            // 
            this.xrt_donvi.Name = "xrt_donvi";
            this.xrt_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_donvi.StylePriority.UsePadding = false;
            this.xrt_donvi.StylePriority.UseTextAlignment = false;
            this.xrt_donvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_donvi.Weight = 0.59170172592393111D;
            // 
            // xrt_tongcbnv
            // 
            this.xrt_tongcbnv.Name = "xrt_tongcbnv";
            this.xrt_tongcbnv.StylePriority.UseTextAlignment = false;
            this.xrt_tongcbnv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongcbnv.Weight = 0.31291783578228283D;
            // 
            // xrt_songuotudanhgia
            // 
            this.xrt_songuotudanhgia.Name = "xrt_songuotudanhgia";
            this.xrt_songuotudanhgia.StylePriority.UseTextAlignment = false;
            this.xrt_songuotudanhgia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_songuotudanhgia.Weight = 0.32332718862677379D;
            // 
            // xrt_songuoiduoctructiep
            // 
            this.xrt_songuoiduoctructiep.Name = "xrt_songuoiduoctructiep";
            this.xrt_songuoiduoctructiep.StylePriority.UseTextAlignment = false;
            this.xrt_songuoiduoctructiep.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_songuoiduoctructiep.Weight = 0.39869333841928173D;
            // 
            // xrt_songuoiduoccanbodanhgia
            // 
            this.xrt_songuoiduoccanbodanhgia.Name = "xrt_songuoiduoccanbodanhgia";
            this.xrt_songuoiduoccanbodanhgia.StylePriority.UseTextAlignment = false;
            this.xrt_songuoiduoccanbodanhgia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_songuoiduoccanbodanhgia.Weight = 0.41172559913827189D;
            // 
            // xrt_ghichu
            // 
            this.xrt_ghichu.Name = "xrt_ghichu";
            this.xrt_ghichu.StylePriority.UseTextAlignment = false;
            this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrt_ghichu.Weight = 0.34725330665761012D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 25F;
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
            this.xrlblNgayDanhGia,
            this.xrlblTenDotDG,
            this.xrlblRpTitle});
            this.ReportHeader.HeightF = 76.00004F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrlblNgayDanhGia
            // 
            this.xrlblNgayDanhGia.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblNgayDanhGia.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblNgayDanhGia.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 55.50003F);
            this.xrlblNgayDanhGia.Name = "xrlblNgayDanhGia";
            this.xrlblNgayDanhGia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblNgayDanhGia.SizeF = new System.Drawing.SizeF(823.9999F, 20.50001F);
            this.xrlblNgayDanhGia.StylePriority.UseBorders = false;
            this.xrlblNgayDanhGia.StylePriority.UseFont = false;
            this.xrlblNgayDanhGia.StylePriority.UseTextAlignment = false;
            this.xrlblNgayDanhGia.Text = "Ngày: ......................";
            this.xrlblNgayDanhGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblTenDotDG
            // 
            this.xrlblTenDotDG.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblTenDotDG.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTenDotDG.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 35.00001F);
            this.xrlblTenDotDG.Name = "xrlblTenDotDG";
            this.xrlblTenDotDG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTenDotDG.SizeF = new System.Drawing.SizeF(823.9999F, 20.50001F);
            this.xrlblTenDotDG.StylePriority.UseBorders = false;
            this.xrlblTenDotDG.StylePriority.UseFont = false;
            this.xrlblTenDotDG.StylePriority.UseTextAlignment = false;
            this.xrlblTenDotDG.Text = "Đợt đánh giá: ...........";
            this.xrlblTenDotDG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblRpTitle
            // 
            this.xrlblRpTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblRpTitle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblRpTitle.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 10.00001F);
            this.xrlblRpTitle.Name = "xrlblRpTitle";
            this.xrlblRpTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblRpTitle.SizeF = new System.Drawing.SizeF(823.9999F, 20.50001F);
            this.xrlblRpTitle.StylePriority.UseBorders = false;
            this.xrlblRpTitle.StylePriority.UseFont = false;
            this.xrlblRpTitle.StylePriority.UseTextAlignment = false;
            this.xrlblRpTitle.Text = "THEO DÕI TỔNG HỢP TIẾN ĐỘ ĐÁNH GIÁ  THEO ĐƠN VỊ";
            this.xrlblRpTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 45.83333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(824F, 45.83333F);
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
            this.xrTableCell8,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.37499999999999994D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Phòng ban";
            this.xrTableCell2.Weight = 1.3125001525878908D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Đơn vị";
            this.xrTableCell4.Weight = 1.6252074432373047D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Tổng CBNV của đơn vị";
            this.xrTableCell5.Weight = 0.85947902679443366D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Số người đã tự đánh giá";
            this.xrTableCell6.Weight = 0.88807252883911125D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Số người đã được người khác đánh giá";
            this.xrTableCell7.Weight = 1.0950787067413335D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Số người đã được người quản lý đánh giá";
            this.xrTableCell8.Weight = 1.1308727884292606D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Ghi chú";
            this.xrTableCell3.Weight = 0.95378935337066639D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblChuKy3,
            this.xrlblChuKy2,
            this.xrlblNguoiLapBC,
            this.xrLabel12,
            this.xrlblTieuDe3,
            this.xrLabel14,
            this.xrlblTieuDe1,
            this.xrLabel10,
            this.xrlblTieuDe2,
            this.xrlblNgayTao});
            this.ReportFooter.HeightF = 199F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrlblChuKy3
            // 
            this.xrlblChuKy3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblChuKy3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlblChuKy3.LocationFloat = new DevExpress.Utils.PointFloat(537.5001F, 112.4584F);
            this.xrlblChuKy3.Name = "xrlblChuKy3";
            this.xrlblChuKy3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuKy3.SizeF = new System.Drawing.SizeF(286.4998F, 23F);
            this.xrlblChuKy3.StylePriority.UseBorders = false;
            this.xrlblChuKy3.StylePriority.UseFont = false;
            this.xrlblChuKy3.Text = "Trần Quang Khải";
            // 
            // xrlblChuKy2
            // 
            this.xrlblChuKy2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblChuKy2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlblChuKy2.LocationFloat = new DevExpress.Utils.PointFloat(252.0833F, 112.4584F);
            this.xrlblChuKy2.Name = "xrlblChuKy2";
            this.xrlblChuKy2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuKy2.SizeF = new System.Drawing.SizeF(250F, 23F);
            this.xrlblChuKy2.StylePriority.UseBorders = false;
            this.xrlblChuKy2.StylePriority.UseFont = false;
            this.xrlblChuKy2.Text = "Trần Duy Hưng";
            // 
            // xrlblNguoiLapBC
            // 
            this.xrlblNguoiLapBC.BorderWidth = 0;
            this.xrlblNguoiLapBC.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlblNguoiLapBC.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 112.4584F);
            this.xrlblNguoiLapBC.Name = "xrlblNguoiLapBC";
            this.xrlblNguoiLapBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblNguoiLapBC.SizeF = new System.Drawing.SizeF(232.2917F, 23.00001F);
            this.xrlblNguoiLapBC.StylePriority.UseBorderWidth = false;
            this.xrlblNguoiLapBC.StylePriority.UseFont = false;
            this.xrlblNguoiLapBC.Text = "Demo";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(252.0833F, 57.91667F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(250F, 23F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "(Ký và ghi rõ họ tên)";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblTieuDe3
            // 
            this.xrlblTieuDe3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblTieuDe3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTieuDe3.LocationFloat = new DevExpress.Utils.PointFloat(537.5001F, 45.41667F);
            this.xrlblTieuDe3.Name = "xrlblTieuDe3";
            this.xrlblTieuDe3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe3.SizeF = new System.Drawing.SizeF(286.4999F, 10.5F);
            this.xrlblTieuDe3.StylePriority.UseBorders = false;
            this.xrlblTieuDe3.StylePriority.UseFont = false;
            this.xrlblTieuDe3.StylePriority.UseTextAlignment = false;
            this.xrlblTieuDe3.Text = "GIÁM ĐỐC";
            this.xrlblTieuDe3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(537.5001F, 57.91667F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(286.4999F, 23F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "(Ký và ghi rõ họ tên)";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblTieuDe1
            // 
            this.xrlblTieuDe1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblTieuDe1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTieuDe1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 45.41667F);
            this.xrlblTieuDe1.Name = "xrlblTieuDe1";
            this.xrlblTieuDe1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe1.SizeF = new System.Drawing.SizeF(232.2917F, 10.5F);
            this.xrlblTieuDe1.StylePriority.UseBorders = false;
            this.xrlblTieuDe1.StylePriority.UseFont = false;
            this.xrlblTieuDe1.StylePriority.UseTextAlignment = false;
            this.xrlblTieuDe1.Text = "NGƯỜI LẬP";
            this.xrlblTieuDe1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 57.91667F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(232.2917F, 23F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "(Ký và ghi rõ họ tên)";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblTieuDe2
            // 
            this.xrlblTieuDe2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblTieuDe2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTieuDe2.LocationFloat = new DevExpress.Utils.PointFloat(252.0833F, 45.41667F);
            this.xrlblTieuDe2.Name = "xrlblTieuDe2";
            this.xrlblTieuDe2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe2.SizeF = new System.Drawing.SizeF(250F, 10.5F);
            this.xrlblTieuDe2.StylePriority.UseBorders = false;
            this.xrlblTieuDe2.StylePriority.UseFont = false;
            this.xrlblTieuDe2.StylePriority.UseTextAlignment = false;
            this.xrlblTieuDe2.Text = "PHÒNG TCHC";
            this.xrlblTieuDe2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblNgayTao
            // 
            this.xrlblNgayTao.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlblNgayTao.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblNgayTao.LocationFloat = new DevExpress.Utils.PointFloat(646.9166F, 10.00001F);
            this.xrlblNgayTao.Name = "xrlblNgayTao";
            this.xrlblNgayTao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblNgayTao.SizeF = new System.Drawing.SizeF(177.0834F, 23F);
            this.xrlblNgayTao.StylePriority.UseBorders = false;
            this.xrlblNgayTao.StylePriority.UseFont = false;
            this.xrlblNgayTao.Text = "Ngày 27 tháng 7 năm 2013";
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 25, 100);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
