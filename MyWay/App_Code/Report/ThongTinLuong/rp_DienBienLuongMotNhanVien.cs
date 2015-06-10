using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_DienBienLuongCopy
/// </summary>
public class rp_DienBienLuongMotNhanVien : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_ngayBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell12;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_sttt;
    private XRTableCell xrt_soquyetdinh;
    private XRTableCell xrt_mucLuong;
    private XRTableCell xrt_luongdongbh;
    private XRTableCell xrt_tongPhuCap;
    private XRTableCell xrt_ngayhieuluc;
    private XRTableCell xrt_ghichu;
    private XRLabel xrl_reporter;
    private XRLabel xrl_phongHCNS;
    private XRLabel xrl_chukyGiamDoc;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_titleHCNS;
    private XRLabel xrl_TongGiamDoc;
    private XRLabel xrl_footer1;
    private XRLabel xrl_HoTen;
    private XRLabel xrl_PhongBan;
    private XRLabel xrl_ViTriCongViec;
    private XRLabel xrl_ChucVu;
    private XRTableCell xrTableCell5;
    private XRLabel xr_TuyenChinhThuc;
    private XRLabel xrThamNien;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DienBienLuongMotNhanVien()
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
    public void BindData(ReportFilter filter)
    {
        try
        {
            ReportController controller = new ReportController();
            if (!SoftCore.Util.GetInstance().IsDateNull(filter.StartDate) && !SoftCore.Util.GetInstance().IsDateNull(filter.EndDate))
            {
                xrl_ngayBC.Text = controller.GetFromDateToDate(filter.StartDate, filter.EndDate);
            }
            DataTable tableHoSo = DataHandler.GetInstance().ExecuteDataTable("report_ThongTinHoSo", "@prKeyHoSo", filter.EmployeeCode);
            if (tableHoSo.Rows.Count > 0)
            {
                xrl_HoTen.Text += tableHoSo.Rows[0]["HO_TEN"].ToString();
                xrl_PhongBan.Text += tableHoSo.Rows[0]["TEN_DONVI"].ToString();
                xrl_ChucVu.Text += tableHoSo.Rows[0]["TEN_CHUCVU"].ToString();
                xrl_ViTriCongViec.Text += tableHoSo.Rows[0]["TEN_CONGVIEC"].ToString();
                xrThamNien.Text += tableHoSo.Rows[0]["ThamNien"].ToString();
                if (!string.IsNullOrEmpty(tableHoSo.Rows[0]["NGAY_TUYEN_CHINHTHUC"].ToString()))
                {
                    xr_TuyenChinhThuc.Text += tableHoSo.Rows[0]["NGAY_TUYEN_CHINHTHUC"].ToString().Remove(tableHoSo.Rows[0]["NGAY_TUYEN_CHINHTHUC"].ToString().IndexOf(' '));
                }
            }
            xrtngayketxuat.Text = controller.GetFooterReport(filter.SessionDepartment, DateTime.Now);
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("report_GetSalaryHistoryOfAnEmployee", "@prkeyHoSo", "@TuNgay", "@DenNgay", filter.EmployeeCode, filter.StartDate, filter.EndDate);
            if (dt.Rows.Count > 0)
            {
                DataSource = dt;
                xrt_soquyetdinh.DataBindings.Add("Text", DataSource, "SoQuyetDinh");
                xrt_mucLuong.DataBindings.Add("Text", DataSource, "LuongCung", "{0:n0}");
                xrt_luongdongbh.DataBindings.Add("Text", DataSource, "LuongDongBHXH", "{0:n0}");
                xrt_tongPhuCap.DataBindings.Add("Text", DataSource, "TongTien", "{0:n0}");
                xrt_ngayhieuluc.DataBindings.Add("Text", DataSource, "NgayHieuLuc", "{0:dd/MM/yyyy}");
                xrt_ghichu.DataBindings.Add("Text", DataSource, "GhiChu");
            }
            if (!string.IsNullOrEmpty(filter.ReportTitle))
            {
                xrl_TitleBC.Text = filter.ReportTitle.ToUpper();
            }

            if (!string.IsNullOrEmpty(filter.Name1))
            {
                xrl_reporter.Text = filter.Name1;
            }
            else
            {
                xrl_reporter.Text = controller.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
            }
            xrl_TenThanhPho.Text = controller.GetCityName(filter.SessionDepartment);
            xrl_TenCongTy.Text = controller.GetCompanyName(filter.SessionDepartment);
            xrl_titleHCNS.Text = controller.GetTitleOfSignature(xrl_titleHCNS.Text, filter.Title1);
            xrl_TongGiamDoc.Text = controller.GetTitleOfSignature(xrl_TongGiamDoc.Text, filter.Title2);
            xrl_chukyGiamDoc.Text = controller.GetDirectorName(filter.SessionDepartment, filter.Name2);
            xrl_phongHCNS.Text = controller.GetHeadOfHRroom(filter.SessionDepartment, filter.Name1);
        }
        catch (Exception)
        {
            
            throw;
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
        string resourceFileName = "rp_DienBienLuongMotNhanVien.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_sttt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_soquyetdinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_mucLuong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_luongdongbh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tongPhuCap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ngayhieuluc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_ViTriCongViec = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ChucVu = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_PhongBan = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_HoTen = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ngayBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_reporter = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_phongHCNS = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_chukyGiamDoc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_titleHCNS = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TongGiamDoc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xr_TuyenChinhThuc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrThamNien = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrt_soquyetdinh,
            this.xrt_mucLuong,
            this.xrt_luongdongbh,
            this.xrt_tongPhuCap,
            this.xrt_ngayhieuluc,
            this.xrt_ghichu});
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
        // xrt_soquyetdinh
        // 
        this.xrt_soquyetdinh.Name = "xrt_soquyetdinh";
        this.xrt_soquyetdinh.StylePriority.UseTextAlignment = false;
        this.xrt_soquyetdinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_soquyetdinh.Weight = 0.32820658407952358D;
        // 
        // xrt_mucLuong
        // 
        this.xrt_mucLuong.Name = "xrt_mucLuong";
        this.xrt_mucLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_mucLuong.StylePriority.UsePadding = false;
        this.xrt_mucLuong.StylePriority.UseTextAlignment = false;
        this.xrt_mucLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_mucLuong.Weight = 0.60362149997370507D;
        // 
        // xrt_luongdongbh
        // 
        this.xrt_luongdongbh.Name = "xrt_luongdongbh";
        this.xrt_luongdongbh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_luongdongbh.StylePriority.UsePadding = false;
        this.xrt_luongdongbh.StylePriority.UseTextAlignment = false;
        this.xrt_luongdongbh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_luongdongbh.Weight = 0.39637859709323792D;
        // 
        // xrt_tongPhuCap
        // 
        this.xrt_tongPhuCap.Name = "xrt_tongPhuCap";
        this.xrt_tongPhuCap.StylePriority.UseTextAlignment = false;
        this.xrt_tongPhuCap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tongPhuCap.Weight = 0.39365244934102184D;
        // 
        // xrt_ngayhieuluc
        // 
        this.xrt_ngayhieuluc.Name = "xrt_ngayhieuluc";
        this.xrt_ngayhieuluc.StylePriority.UseTextAlignment = false;
        this.xrt_ngayhieuluc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_ngayhieuluc.Weight = 0.34552877943732108D;
        // 
        // xrt_ghichu
        // 
        this.xrt_ghichu.Name = "xrt_ghichu";
        this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_ghichu.StylePriority.UsePadding = false;
        this.xrt_ghichu.StylePriority.UseTextAlignment = false;
        this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_ghichu.Weight = 0.57168286695128712D;
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
            this.xrThamNien,
            this.xr_TuyenChinhThuc,
            this.xrl_ViTriCongViec,
            this.xrl_ChucVu,
            this.xrl_PhongBan,
            this.xrl_HoTen,
            this.xrl_TitleBC,
            this.xrl_ngayBC,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
        this.ReportHeader.HeightF = 190F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_ViTriCongViec
        // 
        this.xrl_ViTriCongViec.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_ViTriCongViec.LocationFloat = new DevExpress.Utils.PointFloat(314.3752F, 152F);
        this.xrl_ViTriCongViec.Name = "xrl_ViTriCongViec";
        this.xrl_ViTriCongViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ViTriCongViec.SizeF = new System.Drawing.SizeF(356.042F, 23F);
        this.xrl_ViTriCongViec.StylePriority.UseFont = false;
        this.xrl_ViTriCongViec.StylePriority.UseTextAlignment = false;
        this.xrl_ViTriCongViec.Text = "Vị trí công việc :";
        this.xrl_ViTriCongViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_ChucVu
        // 
        this.xrl_ChucVu.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_ChucVu.LocationFloat = new DevExpress.Utils.PointFloat(0F, 152F);
        this.xrl_ChucVu.Name = "xrl_ChucVu";
        this.xrl_ChucVu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ChucVu.SizeF = new System.Drawing.SizeF(314.3752F, 23F);
        this.xrl_ChucVu.StylePriority.UseFont = false;
        this.xrl_ChucVu.StylePriority.UseTextAlignment = false;
        this.xrl_ChucVu.Text = "Chức vụ : ";
        this.xrl_ChucVu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_PhongBan
        // 
        this.xrl_PhongBan.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_PhongBan.LocationFloat = new DevExpress.Utils.PointFloat(314.3752F, 129F);
        this.xrl_PhongBan.Name = "xrl_PhongBan";
        this.xrl_PhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_PhongBan.SizeF = new System.Drawing.SizeF(356.042F, 23F);
        this.xrl_PhongBan.StylePriority.UseFont = false;
        this.xrl_PhongBan.StylePriority.UseTextAlignment = false;
        this.xrl_PhongBan.Text = "Phòng ban :";
        this.xrl_PhongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_HoTen
        // 
        this.xrl_HoTen.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_HoTen.LocationFloat = new DevExpress.Utils.PointFloat(0F, 129F);
        this.xrl_HoTen.Name = "xrl_HoTen";
        this.xrl_HoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_HoTen.SizeF = new System.Drawing.SizeF(314.3752F, 23F);
        this.xrl_HoTen.StylePriority.UseFont = false;
        this.xrl_HoTen.StylePriority.UseTextAlignment = false;
        this.xrl_HoTen.Text = "Họ tên : ";
        this.xrl_HoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
        this.xrl_TitleBC.Text = "DIỄN BIẾN LƯƠNG CỦA NHÂN VIÊN";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_ngayBC
        // 
        this.xrl_ngayBC.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrl_ngayBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
        this.xrl_ngayBC.Name = "xrl_ngayBC";
        this.xrl_ngayBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ngayBC.SizeF = new System.Drawing.SizeF(1044.958F, 23F);
        this.xrl_ngayBC.StylePriority.UseFont = false;
        this.xrl_ngayBC.StylePriority.UseTextAlignment = false;
        this.xrl_ngayBC.Text = "Từ ngày.... đến ngày......";
        this.xrl_ngayBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        this.PageHeader.HeightF = 35F;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(1044.958F, 34.625F);
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
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell5,
            this.xrTableCell3,
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
        this.xrTableCell1.Text = "Số quyết định";
        this.xrTableCell1.Weight = 0.32820658481735104D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Mức lương";
        this.xrTableCell7.Weight = 0.6036213111958707D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Lương đóng BHXH";
        this.xrTableCell2.Weight = 0.39637873484722064D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Ngày hiệu lực";
        this.xrTableCell3.Weight = 0.34552877198978554D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Ghi chú";
        this.xrTableCell12.Weight = 0.571682923999798D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_reporter,
            this.xrl_phongHCNS,
            this.xrl_chukyGiamDoc,
            this.xrtngayketxuat,
            this.xrl_titleHCNS,
            this.xrl_TongGiamDoc,
            this.xrl_footer1});
        this.ReportFooter.HeightF = 175F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_reporter
        // 
        this.xrl_reporter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_reporter.LocationFloat = new DevExpress.Utils.PointFloat(20.16659F, 131.25F);
        this.xrl_reporter.Name = "xrl_reporter";
        this.xrl_reporter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_reporter.SizeF = new System.Drawing.SizeF(238.6402F, 23F);
        this.xrl_reporter.StylePriority.UseFont = false;
        this.xrl_reporter.StylePriority.UseTextAlignment = false;
        this.xrl_reporter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_phongHCNS
        // 
        this.xrl_phongHCNS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_phongHCNS.LocationFloat = new DevExpress.Utils.PointFloat(395.1666F, 131.25F);
        this.xrl_phongHCNS.Name = "xrl_phongHCNS";
        this.xrl_phongHCNS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_phongHCNS.SizeF = new System.Drawing.SizeF(245.7076F, 23F);
        this.xrl_phongHCNS.StylePriority.UseFont = false;
        this.xrl_phongHCNS.StylePriority.UseTextAlignment = false;
        this.xrl_phongHCNS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_chukyGiamDoc
        // 
        this.xrl_chukyGiamDoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_chukyGiamDoc.LocationFloat = new DevExpress.Utils.PointFloat(795.1666F, 131.25F);
        this.xrl_chukyGiamDoc.Name = "xrl_chukyGiamDoc";
        this.xrl_chukyGiamDoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_chukyGiamDoc.SizeF = new System.Drawing.SizeF(240.752F, 23F);
        this.xrl_chukyGiamDoc.StylePriority.UseFont = false;
        this.xrl_chukyGiamDoc.StylePriority.UseTextAlignment = false;
        this.xrl_chukyGiamDoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(795.1666F, 6.25F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(241.8331F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_titleHCNS
        // 
        this.xrl_titleHCNS.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_titleHCNS.LocationFloat = new DevExpress.Utils.PointFloat(395.1666F, 31.25F);
        this.xrl_titleHCNS.Name = "xrl_titleHCNS";
        this.xrl_titleHCNS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_titleHCNS.SizeF = new System.Drawing.SizeF(247.7086F, 23F);
        this.xrl_titleHCNS.StylePriority.UseFont = false;
        this.xrl_titleHCNS.StylePriority.UseTextAlignment = false;
        this.xrl_titleHCNS.Text = "PHÒNG HCNS";
        this.xrl_titleHCNS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TongGiamDoc
        // 
        this.xrl_TongGiamDoc.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TongGiamDoc.LocationFloat = new DevExpress.Utils.PointFloat(795.1666F, 31.25F);
        this.xrl_TongGiamDoc.Name = "xrl_TongGiamDoc";
        this.xrl_TongGiamDoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TongGiamDoc.SizeF = new System.Drawing.SizeF(241.8334F, 23F);
        this.xrl_TongGiamDoc.StylePriority.UseFont = false;
        this.xrl_TongGiamDoc.StylePriority.UseTextAlignment = false;
        this.xrl_TongGiamDoc.Text = "TỔNG GIÁM ĐỐC";
        this.xrl_TongGiamDoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(20.16659F, 31.25F);
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
        this.PageFooter.HeightF = 214F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrPageInfo1.Format = "Trang {0} của {1}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(955.3746F, 38.54167F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(89.58374F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Tổng phụ cấp";
        this.xrTableCell5.Weight = 0.39365244365331287D;
        // 
        // xrLabel1
        // 
        this.xr_TuyenChinhThuc.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xr_TuyenChinhThuc.LocationFloat = new DevExpress.Utils.PointFloat(670.4172F, 129F);
        this.xr_TuyenChinhThuc.Name = "xrLabel1";
        this.xr_TuyenChinhThuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xr_TuyenChinhThuc.SizeF = new System.Drawing.SizeF(374.5408F, 23F);
        this.xr_TuyenChinhThuc.StylePriority.UseFont = false;
        this.xr_TuyenChinhThuc.StylePriority.UseTextAlignment = false;
        this.xr_TuyenChinhThuc.Text = "Ngày tuyển chính thức :";
        this.xr_TuyenChinhThuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrThamNien
        // 
        this.xrThamNien.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrThamNien.LocationFloat = new DevExpress.Utils.PointFloat(670.4172F, 152F);
        this.xrThamNien.Name = "xrThamNien";
        this.xrThamNien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrThamNien.SizeF = new System.Drawing.SizeF(374.5408F, 23F);
        this.xrThamNien.StylePriority.UseFont = false;
        this.xrThamNien.StylePriority.UseTextAlignment = false;
        this.xrThamNien.Text = "Thâm niên :";
        this.xrThamNien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // rp_DienBienLuongMotNhanVien
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
