using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using Controller.DanhGia;

/// <summary>
/// Summary description for rp_BangTongDiemKetQuaDanhGia
/// </summary>
public class rp_BangTongDiemKetQuaDanhGia : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrlblRPTitle;
    private XRLabel xrlblTenDotDG;
    private XRLabel xrlblDonVi;
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
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_macbnv;
    private XRTableCell xrtngaysinh;
    private XRTableCell xrtchucvu;
    private XRTableCell xrtphongban;
    private XRTableCell xrtdiem;
    private XRTableCell xrtghichu;
    private XRLabel xrLblNgayTao;
    private XRLabel xrlblTieuDe1;
    private XRLabel xrlblTieuDe2;
    private XRLabel xrlblTieuDe3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrlblNguoiLap;
    private XRLabel xrlblChuKy2;
    private XRLabel xrlblChuky3;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BangTongDiemKetQuaDanhGia()
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
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    public void BindData(ReportFilter filter)
    {
        //if (filter.TenBaoCao != "")
        //    xrlblRPTitle.Text = filter.TenBaoCao;
        //string tenTP = new HeThongController().GetValueByName(SystemConfigParameter.CITY, filter.MaDonVi);
        //xrLblNgayTao.Text = tenTP + ", ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //DAL.DotDanhGia ddg = new DotDanhGiaController().GetByPrkey(filter.MaDotDanhGia);
        //xrlblTenDotDG.Text = "Đợt đánh giá: " + ddg.TenDotDanhGia;
        //xrlblDonVi.Text = "Đơn vị: " + new DM_DONVIController().GetNameById(filter.MaDonVi);
        //DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_DanhGia_TongHopDiemKetQuaDanhGia", "@MaDotDanhGia", "@MaDonVi", "@MaPhongBan", "@MaChucVu",
        //        "@TuDanhGia", "@QuanLyDG", "@NguoiKhacDG", filter.MaDotDanhGia, filter.MaDonVi, filter.MaPhongBan, filter.MaChucVu, ddg.TL_TuDanhGia, ddg.TL_QuanLyDanhGia, ddg.TL_NguoiKhacDanhGia);
        //DataSource = table;
        //xrt_stt.DataBindings.Add("Text", DataSource, "SK");
        //xrt_hovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        //xrt_macbnv.DataBindings.Add("Text", DataSource, "MA_CB");
        //xrtngaysinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
        //xrtphongban.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        //xrtchucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        //xrtdiem.DataBindings.Add("Text", DataSource, "TrungBinh", "{0:0.00}");

        //// footer
        //if (filter.Footer1 != "")
        //    xrlblTieuDe1.Text = filter.Footer1;
        //if (filter.Footer2 != "")
        //    xrlblTieuDe2.Text = filter.Footer2;
        //if (filter.Footer3 != "")
        //    xrlblTieuDe3.Text = filter.Footer3;

        //xrlblNguoiLap.Text = filter.NguoiLapBaoCao;
        //xrlblChuKy2.Text = filter.Ten2;
        //xrlblChuky3.Text = filter.Ten3;
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_BangTongDiemKetQuaDanhGia.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macbnv = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtchucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtphongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtdiem = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtghichu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrlblDonVi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTenDotDG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblRPTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlblChuky3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblChuKy2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblNguoiLap = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblNgayTao = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(822.9999F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrt_macbnv,
            this.xrtngaysinh,
            this.xrtchucvu,
            this.xrtphongban,
            this.xrtdiem,
            this.xrtghichu});
            this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.StylePriority.UseTextAlignment = false;
            this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseFont = false;
            this.xrt_stt.StylePriority.UseTextAlignment = false;
            this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrt_stt.Weight = 0.13927702596671382D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_hovaten.StylePriority.UseFont = false;
            this.xrt_hovaten.StylePriority.UsePadding = false;
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.4962028305206132D;
            // 
            // xrt_macbnv
            // 
            this.xrt_macbnv.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_macbnv.Name = "xrt_macbnv";
            this.xrt_macbnv.StylePriority.UseFont = false;
            this.xrt_macbnv.StylePriority.UseTextAlignment = false;
            this.xrt_macbnv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_macbnv.Weight = 0.30893089276402125D;
            // 
            // xrtngaysinh
            // 
            this.xrtngaysinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrtngaysinh.Name = "xrtngaysinh";
            this.xrtngaysinh.StylePriority.UseFont = false;
            this.xrtngaysinh.StylePriority.UseTextAlignment = false;
            this.xrtngaysinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtngaysinh.Weight = 0.30065289015011637D;
            // 
            // xrtchucvu
            // 
            this.xrtchucvu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrtchucvu.Name = "xrtchucvu";
            this.xrtchucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrtchucvu.StylePriority.UseFont = false;
            this.xrtchucvu.StylePriority.UsePadding = false;
            this.xrtchucvu.StylePriority.UseTextAlignment = false;
            this.xrtchucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtchucvu.Weight = 0.46704159401156731D;
            // 
            // xrtphongban
            // 
            this.xrtphongban.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrtphongban.Name = "xrtphongban";
            this.xrtphongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrtphongban.StylePriority.UseFont = false;
            this.xrtphongban.StylePriority.UsePadding = false;
            this.xrtphongban.StylePriority.UseTextAlignment = false;
            this.xrtphongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtphongban.Weight = 0.5586841131410154D;
            // 
            // xrtdiem
            // 
            this.xrtdiem.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrtdiem.Name = "xrtdiem";
            this.xrtdiem.StylePriority.UseFont = false;
            this.xrtdiem.StylePriority.UseTextAlignment = false;
            this.xrtdiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtdiem.Weight = 0.21643358202888016D;
            // 
            // xrtghichu
            // 
            this.xrtghichu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrtghichu.Name = "xrtghichu";
            this.xrtghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrtghichu.StylePriority.UseFont = false;
            this.xrtghichu.StylePriority.UsePadding = false;
            this.xrtghichu.StylePriority.UseTextAlignment = false;
            this.xrtghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtghichu.Weight = 0.51277707141707252D;
            // 
            // TopMargin
            // 
            this.TopMargin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.TopMargin.HeightF = 25F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseFont = false;
            this.TopMargin.StylePriority.UseTextAlignment = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StylePriority.UseFont = false;
            this.BottomMargin.StylePriority.UseTextAlignment = false;
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UseTextAlignment = false;
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(823F, 25F);
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
            this.xrTableCell2,
            this.xrTableCell6,
            this.xrTableCell5,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell3});
            this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UseTextAlignment = false;
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 0.13927702596671382D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Họ và tên";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 0.49620289761994041D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Mã CBNV";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 0.30893085706856815D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Ngày sinh ";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell6.Weight = 0.30065284348924709D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Chức vụ";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell5.Weight = 0.46704141424464141D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Phòng ban";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell7.Weight = 0.5586842551990383D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "Điểm";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell8.Weight = 0.21643378812806147D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Ghi chú";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 0.51277691828378935D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblDonVi,
            this.xrlblTenDotDG,
            this.xrlblRPTitle});
            this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.ReportHeader.HeightF = 65F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseFont = false;
            this.ReportHeader.StylePriority.UseTextAlignment = false;
            this.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblDonVi
            // 
            this.xrlblDonVi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblDonVi.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 41.00002F);
            this.xrlblDonVi.Name = "xrlblDonVi";
            this.xrlblDonVi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblDonVi.SizeF = new System.Drawing.SizeF(822.9999F, 20.50001F);
            this.xrlblDonVi.StylePriority.UseFont = false;
            this.xrlblDonVi.StylePriority.UseTextAlignment = false;
            this.xrlblDonVi.Text = "Đơn vị: ..................................";
            this.xrlblDonVi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblTenDotDG
            // 
            this.xrlblTenDotDG.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTenDotDG.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 20.50001F);
            this.xrlblTenDotDG.Name = "xrlblTenDotDG";
            this.xrlblTenDotDG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTenDotDG.SizeF = new System.Drawing.SizeF(822.9999F, 20.50001F);
            this.xrlblTenDotDG.StylePriority.UseFont = false;
            this.xrlblTenDotDG.StylePriority.UseTextAlignment = false;
            this.xrlblTenDotDG.Text = "Đợt đánh giá: ..................................";
            this.xrlblTenDotDG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblRPTitle
            // 
            this.xrlblRPTitle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblRPTitle.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 0F);
            this.xrlblRPTitle.Name = "xrlblRPTitle";
            this.xrlblRPTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblRPTitle.SizeF = new System.Drawing.SizeF(822.9999F, 20.50001F);
            this.xrlblRPTitle.StylePriority.UseFont = false;
            this.xrlblRPTitle.StylePriority.UseTextAlignment = false;
            this.xrlblRPTitle.Text = "BẢNG TỔNG HỢP ĐIỂM KẾT QUẢ ĐÁNH GIÁ";
            this.xrlblRPTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblChuky3,
            this.xrlblChuKy2,
            this.xrlblNguoiLap,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrlblTieuDe3,
            this.xrlblTieuDe2,
            this.xrlblTieuDe1,
            this.xrLblNgayTao});
            this.ReportFooter.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.ReportFooter.HeightF = 174F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            this.ReportFooter.StylePriority.UseTextAlignment = false;
            this.ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblChuky3
            // 
            this.xrlblChuky3.LocationFloat = new DevExpress.Utils.PointFloat(622.9532F, 117.0416F);
            this.xrlblChuky3.Name = "xrlblChuky3";
            this.xrlblChuky3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuky3.SizeF = new System.Drawing.SizeF(170.8334F, 23.00001F);
            this.xrlblChuky3.Text = "Trần Mạnh Hùng";
            // 
            // xrlblChuKy2
            // 
            this.xrlblChuKy2.LocationFloat = new DevExpress.Utils.PointFloat(328.0208F, 117.0416F);
            this.xrlblChuKy2.Name = "xrlblChuKy2";
            this.xrlblChuKy2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuKy2.SizeF = new System.Drawing.SizeF(170.8334F, 23.00001F);
            this.xrlblChuKy2.Text = "Nguyễn Văn A";
            // 
            // xrlblNguoiLap
            // 
            this.xrlblNguoiLap.LocationFloat = new DevExpress.Utils.PointFloat(26.41667F, 117.0416F);
            this.xrlblNguoiLap.Name = "xrlblNguoiLap";
            this.xrlblNguoiLap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblNguoiLap.SizeF = new System.Drawing.SizeF(170.8333F, 23F);
            this.xrlblNguoiLap.Text = "Demo";
            // 
            // xrLabel7
            // 
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(622.9566F, 58.37498F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(170.83F, 23F);
            this.xrLabel7.Text = "(Ký và ghi rõ họ tên)";
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(328.0241F, 58.37498F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(170.83F, 23F);
            this.xrLabel6.Text = "(Ký và ghi rõ họ tên)";
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(26.41667F, 58.37498F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(170.8333F, 23F);
            this.xrLabel5.Text = "(Ký và ghi rõ họ tên)";
            // 
            // xrlblTieuDe3
            // 
            this.xrlblTieuDe3.LocationFloat = new DevExpress.Utils.PointFloat(622.9531F, 45.79166F);
            this.xrlblTieuDe3.Name = "xrlblTieuDe3";
            this.xrlblTieuDe3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe3.SizeF = new System.Drawing.SizeF(170.83F, 12.58333F);
            this.xrlblTieuDe3.Text = "GIÁM ĐỐC";
            // 
            // xrlblTieuDe2
            // 
            this.xrlblTieuDe2.LocationFloat = new DevExpress.Utils.PointFloat(328.0208F, 45.79163F);
            this.xrlblTieuDe2.Name = "xrlblTieuDe2";
            this.xrlblTieuDe2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe2.SizeF = new System.Drawing.SizeF(170.8333F, 12.58336F);
            this.xrlblTieuDe2.Text = "PHÒNG TCHC";
            // 
            // xrlblTieuDe1
            // 
            this.xrlblTieuDe1.LocationFloat = new DevExpress.Utils.PointFloat(26.41668F, 45.79166F);
            this.xrlblTieuDe1.Name = "xrlblTieuDe1";
            this.xrlblTieuDe1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe1.SizeF = new System.Drawing.SizeF(170.8333F, 12.58333F);
            this.xrlblTieuDe1.Text = "NGƯỜI LẬP";
            // 
            // xrLblNgayTao
            // 
            this.xrLblNgayTao.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLblNgayTao.LocationFloat = new DevExpress.Utils.PointFloat(500.5339F, 10.00001F);
            this.xrLblNgayTao.Name = "xrLblNgayTao";
            this.xrLblNgayTao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblNgayTao.SizeF = new System.Drawing.SizeF(322.4661F, 23F);
            this.xrLblNgayTao.StylePriority.UseFont = false;
            this.xrLblNgayTao.StylePriority.UseTextAlignment = false;
            this.xrLblNgayTao.Text = "Ngày 26 tháng 7 năm 2013";
            this.xrLblNgayTao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.StylePriority.UseFont = false;
            this.PageFooter.StylePriority.UseTextAlignment = false;
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // rp_BangTongDiemKetQuaDanhGia
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 25, 100);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
