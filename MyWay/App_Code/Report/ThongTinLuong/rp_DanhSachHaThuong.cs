using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_DienBienLuongCopy
/// </summary>
public class rp_DanhSachHaThuong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell6;
    private XRTableCell xrl_Ngay;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell12;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_sttt;
    private XRTableCell xrt_maCB;
    private XRTableCell xrt_HoTen;
    private XRTableCell xrt_NgayViPham;
    private XRTableCell xrt_SoTien;
    private XRTableCell xrt_SoDiem;
    private XRTableCell xrt_LyDo;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private XRTableCell xrt_GioiTinh;
    private XRTableCell xrTableCell7;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DanhSachHaThuong()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrt_sttt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilterSalary filter, bool bangPhat)
    {

        try
        {
            xrl_TenCongTy.Text = filter.CompanyName;
            xrl_TenThanhPho.Text = filter.CityName.ToUpper();

            int id = filter.IdBangThuong;
            if (bangPhat)
            {
                id = filter.IdBangPhat;
            }
            else
            {
                xrl_Ngay.Text = "Ngày";
                xrl_TitleBC.Text = "DANH SÁCH KHEN THƯỞNG THÁNG ";
            }
         //   xrl_TitleBC.Text += new DanhSachThuongPhatController().GetById(id).Month;
            xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_DanhSachThuongPhat", "@IdDanhSachBangThuongPhat", id);
            if (dt.Rows.Count > 0)
            {
                DataSource = dt;
                xrt_maCB.DataBindings.Add("Text", DataSource, "MaCB");
                xrt_HoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
                xrt_GioiTinh.DataBindings.Add("Text", DataSource, "GioiTinh");
                xrt_NgayViPham.DataBindings.Add("Text", DataSource, "Ngay", "{0:dd/MM/yyyy}");
                xrt_SoTien.DataBindings.Add("Text", DataSource, "SoTien", "{0:n0}");
                xrt_SoDiem.DataBindings.Add("Text", DataSource, "SoDiem");
                xrt_LyDo.DataBindings.Add("Text", DataSource, "LyDo");
            }
            if (!string.IsNullOrEmpty(filter.ReportTitle))
            {
                xrl_TitleBC.Text = filter.ReportTitle.ToUpper();
            }
            if (!string.IsNullOrEmpty(filter.Footer1))
            {
                xrl_footer1.Text = filter.Footer1;
            }
            if (!string.IsNullOrEmpty(filter.Footer2))
            {
                xrl_footer2.Text = filter.Footer2;
            }
            if (!string.IsNullOrEmpty(filter.Footer3))
            {
                xrl_footer3.Text = filter.Footer3;
            }

            if (!string.IsNullOrEmpty(filter.Ten1))
            {
                xrl_ten1.Text = filter.Ten1;
            }
            else
            {
                xrl_ten1.Text = filter.Ten1.ToString();
            }

            if (!string.IsNullOrEmpty(filter.Ten2))
            {
                xrl_ten2.Text = filter.Ten2;
            }
            if (!string.IsNullOrEmpty(filter.Ten3))
            {
                xrl_ten3.Text = filter.Ten3;
            }
        }
        catch (Exception ex)
        {
            xrl_TitleBC.Text = "Có lỗi xảy ra : " + ex.Message;
        }
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
        string resourceFileName = "rp_DanhSachHaThuong.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_sttt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_maCB = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_HoTen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_GioiTinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_NgayViPham = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_SoTien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_SoDiem = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_LyDo = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_Ngay = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
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
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1044.958F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_sttt,
            this.xrt_maCB,
            this.xrt_HoTen,
            this.xrt_GioiTinh,
            this.xrt_NgayViPham,
            this.xrt_SoTien,
            this.xrt_SoDiem,
            this.xrt_LyDo});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrt_sttt
        // 
        this.xrt_sttt.Name = "xrt_sttt";
        this.xrt_sttt.StylePriority.UseTextAlignment = false;
        this.xrt_sttt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_sttt.Weight = 0.096422348839708683D;
        this.xrt_sttt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrt_maCB
        // 
        this.xrt_maCB.Name = "xrt_maCB";
        this.xrt_maCB.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrt_maCB.StylePriority.UsePadding = false;
        this.xrt_maCB.StylePriority.UseTextAlignment = false;
        this.xrt_maCB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_maCB.Weight = 0.27912269738313489D;
        // 
        // xrt_HoTen
        // 
        this.xrt_HoTen.Name = "xrt_HoTen";
        this.xrt_HoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrt_HoTen.StylePriority.UsePadding = false;
        this.xrt_HoTen.StylePriority.UseTextAlignment = false;
        this.xrt_HoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_HoTen.Weight = 0.544652391900206D;
        // 
        // xrt_GioiTinh
        // 
        this.xrt_GioiTinh.Name = "xrt_GioiTinh";
        this.xrt_GioiTinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_GioiTinh.StylePriority.UsePadding = false;
        this.xrt_GioiTinh.StylePriority.UseTextAlignment = false;
        this.xrt_GioiTinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_GioiTinh.Weight = 0.20622036871778535D;
        // 
        // xrt_NgayViPham
        // 
        this.xrt_NgayViPham.Name = "xrt_NgayViPham";
        this.xrt_NgayViPham.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_NgayViPham.StylePriority.UsePadding = false;
        this.xrt_NgayViPham.StylePriority.UseTextAlignment = false;
        this.xrt_NgayViPham.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_NgayViPham.Weight = 0.25730800753263439D;
        // 
        // xrt_SoTien
        // 
        this.xrt_SoTien.Name = "xrt_SoTien";
        this.xrt_SoTien.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrt_SoTien.StylePriority.UsePadding = false;
        this.xrt_SoTien.StylePriority.UseTextAlignment = false;
        this.xrt_SoTien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_SoTien.Weight = 0.35002194315097945D;
        // 
        // xrt_SoDiem
        // 
        this.xrt_SoDiem.Name = "xrt_SoDiem";
        this.xrt_SoDiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrt_SoDiem.StylePriority.UsePadding = false;
        this.xrt_SoDiem.StylePriority.UseTextAlignment = false;
        this.xrt_SoDiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_SoDiem.Weight = 0.22136771961988813D;
        // 
        // xrt_LyDo
        // 
        this.xrt_LyDo.Name = "xrt_LyDo";
        this.xrt_LyDo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 3, 3, 3, 100F);
        this.xrt_LyDo.StylePriority.UsePadding = false;
        this.xrt_LyDo.StylePriority.UseTextAlignment = false;
        this.xrt_LyDo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_LyDo.Weight = 0.7803776485714683D;
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
            this.xrl_TitleBC,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
        this.ReportHeader.HeightF = 118F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1044.958F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "DANH SÁCH PHẠT, HẠ THƯỞNG THÁNG ";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.5F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(499.3446F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(499.3446F, 37.5F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 34F;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(1044.958F, 34F);
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
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrl_Ngay,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell12});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "STT";
        this.xrTableCell4.Weight = 0.096422355212466268D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Mã nhân viên";
        this.xrTableCell1.Weight = 0.27912271809320632D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Họ tên";
        this.xrTableCell6.Weight = 0.54465246013574642D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Giới tính";
        this.xrTableCell7.Weight = 0.20622029145460652D;
        // 
        // xrl_Ngay
        // 
        this.xrl_Ngay.Name = "xrl_Ngay";
        this.xrl_Ngay.Text = "Ngày vi phạm";
        this.xrl_Ngay.Weight = 0.25730817913250875D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Multiline = true;
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Số tiền";
        this.xrTableCell8.Weight = 0.35002202741139932D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Số điểm";
        this.xrTableCell9.Weight = 0.22136756892910808D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Lý do";
        this.xrTableCell12.Weight = 0.78037752534676352D;
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
        this.ReportFooter.HeightF = 175F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(20.16684F, 135F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(238.6402F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(395.1668F, 135F);
        this.xrl_ten2.Name = "xrl_ten2";
        this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten2.SizeF = new System.Drawing.SizeF(245.7076F, 23F);
        this.xrl_ten2.StylePriority.UseFont = false;
        this.xrl_ten2.StylePriority.UseTextAlignment = false;
        this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(795.1669F, 135F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(240.752F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(795.1669F, 10.00001F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(241.8331F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(395.1668F, 35.00001F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(247.7086F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "PHÒNG TCHC";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(795.1669F, 35.00001F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(241.8334F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(20.16684F, 35.00001F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(240.6412F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
        this.PageFooter.HeightF = 47F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrPageInfo1.Format = "Trang {0} của {1}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(955.3743F, 9.999974F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(89.58374F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // rp_DanhSachHaThuong
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
        this.Margins = new System.Drawing.Printing.Margins(58, 64, 50, 100);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
