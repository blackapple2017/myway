using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using DAL;
using System.Globalization;
/// <summary>
/// Summary description for rp_DanhSachKhenThuongNhanVienTheoPhongBan
/// </summary>
public class rp_DanhSachKhenThuongNhanVienTheoPhongBan : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private GroupHeaderBand GroupHeader1;
    private ReportFooterBand ReportFooter;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrt_tungay;
    private XRLabel xrt_tenbaocao;
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
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
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
    private XRTableCell xrt_phongban;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_macb;
    private XRTableCell xrt_hoten;
    private XRTableCell xrt_gioitinh;
    private XRTableCell xrt_chucvu;
    private XRTableCell xrt_hinhthuckhenthuong;
    private XRTableCell xrt_lydokhenthuong;
    private XRTableCell xrt_soqd;
    private XRTableCell xrt_ngayquyetdinh;
    private XRTableCell xrt_sotienkhenthuong;
    private XRTableCell xrt_ghichu;
    private XRLabel xrLabel4;
    private XRLabel xrl_footer1;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten3;
    private XRLabel xrl_footer3;
    private XRTableCell xrTableCell23;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_ngayketxuat;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DanhSachKhenThuongNhanVienTheoPhongBan()
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
    public void BinData(ReportFilter filter)
    {
        //xrt_tungay.Text = "Từ ngày " + Convert.ToDateTime(filter.TuNgay).ToString("dd/MM/yyyy") + " Đến ngày " + Convert.ToDateTime(filter.DenNgay).ToString("dd/MM/yyyy");
        //xrl_TenCongTy.Text = filter.TenDonVi;
        //xrl_TenThanhPho.Text = filter.TenThanhPho.ToUpper();
        //DataTable dt = DataHandler.GetInstance().ExecuteDataTable("GetNhanVienKhenThuongTheoPhong", "@MaDonVi", "@MaBoPhan", "@TuNgay", "@DenNgay","@HinhThucKT","@LyDoKT", filter.MaDonVi, filter.MaBoPhan, filter.TuNgay, filter.DenNgay,filter.Ma_HinhThucKhenThuong,filter.Ma_LyDoKhenThuong);
        //if (dt.Rows.Count > 0)
        //{
        //    DataSource = dt;
        //    xrt_macb.DataBindings.Add("Text", DataSource, "MA_CB");
        //    xrt_hoten.DataBindings.Add("Text", DataSource, "HO_TEN");
        //    xrt_gioitinh.DataBindings.Add("Text", DataSource, "GioiTinh");
        //    xrt_chucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        //    xrt_hinhthuckhenthuong.DataBindings.Add("Text", DataSource, "TEN_HT_KTHUONG");
        //    xrt_lydokhenthuong.DataBindings.Add("Text", DataSource, "TEN_LYDO_KTHUONG");
        //    xrt_soqd.DataBindings.Add("Text", DataSource, "SoQuyetDinh");
        //    xrt_ngayquyetdinh.DataBindings.Add("Text", DataSource, "SoNgayQuyetDinh", "{0:dd/MM/yyyy}");
        //    xrt_sotienkhenthuong.DataBindings.Add("Text", DataSource, "SoTien", "{0:n0}");
        //    this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
        //    new DevExpress.XtraReports.UI.GroupField("TEN_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        //    xrt_phongban.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        //    xrl_ngayketxuat.Text="Ngày "+DateTime.Now.Day+" tháng "+DateTime.Now.Month+" năm "+DateTime.Now.Year;
        //}
        //if (!string.IsNullOrEmpty(filter.TenBaoCao))
        //{
        //    xrt_tenbaocao.Text = filter.TenBaoCao.ToUpper();
        //}
        //if (!string.IsNullOrEmpty(filter.Footer1))
        //{
        //    xrl_footer1.Text = filter.Footer1;
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
        //if (!string.IsNullOrEmpty(filter.Ten3))
        //{
        //    xrl_ten3.Text = filter.Ten3;
        //}

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

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_DanhSachKhenThuongNhanVienTheoPhongBan.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macb = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_gioitinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hinhthuckhenthuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_lydokhenthuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_soqd = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayquyetdinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sotienkhenthuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tungay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tenbaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.Detail.HeightF = 27.08334F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(1145F, 27.08334F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_macb,
            this.xrt_hoten,
            this.xrt_gioitinh,
            this.xrt_chucvu,
            this.xrt_hinhthuckhenthuong,
            this.xrt_lydokhenthuong,
            this.xrt_soqd,
            this.xrt_ngayquyetdinh,
            this.xrt_sotienkhenthuong,
            this.xrt_ghichu});
            this.xrTableRow4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.StylePriority.UseFont = false;
            this.xrTableRow4.StylePriority.UseTextAlignment = false;
            this.xrTableRow4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow4.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseFont = false;
            this.xrt_stt.Weight = 0.33333328247070315D;
            this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_macb
            // 
            this.xrt_macb.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_macb.Name = "xrt_macb";
            this.xrt_macb.StylePriority.UseFont = false;
            this.xrt_macb.Weight = 0.82291671752929685D;
            // 
            // xrt_hoten
            // 
            this.xrt_hoten.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_hoten.Name = "xrt_hoten";
            this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hoten.StylePriority.UseFont = false;
            this.xrt_hoten.StylePriority.UsePadding = false;
            this.xrt_hoten.StylePriority.UseTextAlignment = false;
            this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hoten.Weight = 1.3479165649414062D;
            // 
            // xrt_gioitinh
            // 
            this.xrt_gioitinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_gioitinh.Name = "xrt_gioitinh";
            this.xrt_gioitinh.StylePriority.UseFont = false;
            this.xrt_gioitinh.Weight = 0.53541656494140621D;
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_chucvu.StylePriority.UseFont = false;
            this.xrt_chucvu.StylePriority.UsePadding = false;
            this.xrt_chucvu.StylePriority.UseTextAlignment = false;
            this.xrt_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_chucvu.Weight = 1.2333337402343747D;
            // 
            // xrt_hinhthuckhenthuong
            // 
            this.xrt_hinhthuckhenthuong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_hinhthuckhenthuong.Name = "xrt_hinhthuckhenthuong";
            this.xrt_hinhthuckhenthuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hinhthuckhenthuong.StylePriority.UseFont = false;
            this.xrt_hinhthuckhenthuong.StylePriority.UsePadding = false;
            this.xrt_hinhthuckhenthuong.StylePriority.UseTextAlignment = false;
            this.xrt_hinhthuckhenthuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hinhthuckhenthuong.Weight = 1.6395828247070312D;
            // 
            // xrt_lydokhenthuong
            // 
            this.xrt_lydokhenthuong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_lydokhenthuong.Name = "xrt_lydokhenthuong";
            this.xrt_lydokhenthuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_lydokhenthuong.StylePriority.UseFont = false;
            this.xrt_lydokhenthuong.StylePriority.UsePadding = false;
            this.xrt_lydokhenthuong.StylePriority.UseTextAlignment = false;
            this.xrt_lydokhenthuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_lydokhenthuong.Weight = 1.4833337402343749D;
            // 
            // xrt_soqd
            // 
            this.xrt_soqd.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_soqd.Name = "xrt_soqd";
            this.xrt_soqd.StylePriority.UseFont = false;
            this.xrt_soqd.Weight = 1.2333334350585936D;
            // 
            // xrt_ngayquyetdinh
            // 
            this.xrt_ngayquyetdinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ngayquyetdinh.Name = "xrt_ngayquyetdinh";
            this.xrt_ngayquyetdinh.StylePriority.UseFont = false;
            this.xrt_ngayquyetdinh.Weight = 0.97291625976562524D;
            // 
            // xrt_sotienkhenthuong
            // 
            this.xrt_sotienkhenthuong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_sotienkhenthuong.Name = "xrt_sotienkhenthuong";
            this.xrt_sotienkhenthuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_sotienkhenthuong.StylePriority.UseFont = false;
            this.xrt_sotienkhenthuong.StylePriority.UsePadding = false;
            this.xrt_sotienkhenthuong.StylePriority.UseTextAlignment = false;
            this.xrt_sotienkhenthuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_sotienkhenthuong.Weight = 1.0802081298828121D;
            // 
            // xrt_ghichu
            // 
            this.xrt_ghichu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ghichu.Name = "xrt_ghichu";
            this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_ghichu.StylePriority.UseFont = false;
            this.xrt_ghichu.StylePriority.UsePadding = false;
            this.xrt_ghichu.StylePriority.UseTextAlignment = false;
            this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_ghichu.Weight = 0.767708740234375D;
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
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable1});
            this.PageHeader.HeightF = 65.62502F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 38.54167F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1145F, 27.08334F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22});
            this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.StylePriority.UseTextAlignment = false;
            this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "1";
            this.xrTableCell12.Weight = 0.33333328247070315D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "2";
            this.xrTableCell13.Weight = 0.82291671752929685D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "3";
            this.xrTableCell14.Weight = 1.3479165649414062D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "4";
            this.xrTableCell15.Weight = 0.53541656494140621D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "5";
            this.xrTableCell16.Weight = 1.2333337402343747D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "6";
            this.xrTableCell17.Weight = 1.6395828247070312D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "7";
            this.xrTableCell18.Weight = 1.4833337402343749D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "8";
            this.xrTableCell19.Weight = 1.2333334350585936D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "9";
            this.xrTableCell20.Weight = 0.97291625976562524D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "10";
            this.xrTableCell21.Weight = 1.0802081298828121D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "11";
            this.xrTableCell22.Weight = 0.767708740234375D;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(1145F, 38.54167F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell7,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell4,
            this.xrTableCell9,
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell3});
            this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UseTextAlignment = false;
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.33333328247070315D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Mã CBNV";
            this.xrTableCell2.Weight = 0.82291671752929685D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Họ và tên";
            this.xrTableCell7.Weight = 1.3479165649414062D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Giới tính ";
            this.xrTableCell5.Weight = 0.53541656494140621D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Chức vụ";
            this.xrTableCell6.Weight = 1.2333337402343747D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Hình thức khen thưởng";
            this.xrTableCell4.Weight = 1.6395831298828123D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Lý do khen thưởng";
            this.xrTableCell9.Weight = 1.4833331298828121D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Số QĐ";
            this.xrTableCell8.Weight = 1.2333337402343749D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Ngày quyết định";
            this.xrTableCell10.Weight = 0.97291625976562524D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Số tiền khen thưởng";
            this.xrTableCell11.Weight = 1.0802081298828121D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Ghi chú";
            this.xrTableCell3.Weight = 0.767708740234375D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.GroupHeader1.HeightF = 27.08334F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1145F, 27.08334F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrt_phongban});
            this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseFont = false;
            this.xrTableRow3.StylePriority.UseTextAlignment = false;
            this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.Weight = 0.099999999999999659D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.StylePriority.UseBorders = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.Text = "     ";
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_phongban.Weight = 11.35D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ngayketxuat,
            this.xrl_ten3,
            this.xrl_footer3,
            this.xrl_ten1,
            this.xrl_footer1,
            this.xrLabel4});
            this.ReportFooter.HeightF = 250F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ngayketxuat
            // 
            this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(908.8544F, 61.12496F);
            this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
            this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(197.9166F, 23F);
            this.xrl_ngayketxuat.StylePriority.UseFont = false;
            this.xrl_ngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrl_ngayketxuat.Text = "Ngày 15 tháng 8 năm 2013";
            this.xrl_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(924.4793F, 196.6249F);
            this.xrl_ten3.Multiline = true;
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(924.4793F, 84.12495F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "BAN GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(40.20831F, 196.9583F);
            this.xrl_ten1.Multiline = true;
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(40.20831F, 84.12495F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 9.999974F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1145F, 26.125F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "    Mục đích: Thống kê danh sách CBNV khen thưởng : Hình thức khen thưởng, lý do " +
    "khen thưởng, số QĐ, ngày quyết định, ghi chú, Số tiền khen thưởng.";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy,
            this.xrt_tungay,
            this.xrt_tenbaocao});
            this.ReportHeader.HeightF = 117F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(484.7656F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(484.7656F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_tungay
            // 
            this.xrt_tungay.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_tungay.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 85.04165F);
            this.xrt_tungay.Name = "xrt_tungay";
            this.xrt_tungay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tungay.SizeF = new System.Drawing.SizeF(1145F, 17.95835F);
            this.xrt_tungay.StylePriority.UseFont = false;
            this.xrt_tungay.StylePriority.UseTextAlignment = false;
            this.xrt_tungay.Text = "Từ ngày ....... Đến ngày ..........";
            this.xrt_tungay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_tenbaocao
            // 
            this.xrt_tenbaocao.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrt_tenbaocao.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 63.0833F);
            this.xrt_tenbaocao.Name = "xrt_tenbaocao";
            this.xrt_tenbaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tenbaocao.SizeF = new System.Drawing.SizeF(1145F, 21.95834F);
            this.xrt_tenbaocao.StylePriority.UseFont = false;
            this.xrt_tenbaocao.StylePriority.UseTextAlignment = false;
            this.xrt_tenbaocao.Text = "DANH SÁCH CÁN BỘ NHÂN VIÊN ĐƯỢC KHEN THƯỞNG";
            this.xrt_tenbaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1018.958F, 50F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // rp_DanhSachKhenThuongNhanVienTheoPhongBan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportFooter,
            this.ReportHeader,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 12, 49, 100);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
