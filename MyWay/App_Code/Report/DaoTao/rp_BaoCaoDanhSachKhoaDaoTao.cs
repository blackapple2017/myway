using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoDanhSachKhoaDaoTao
/// </summary>
public class rp_BaoCaoDanhSachKhoaDaoTao : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private PageHeaderBand PageHeader;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_Stt;
    private XRTableCell xrKinhPhiDuKien;
    private XRTableCell xrKinhPhiThucTe;
    private XRTableCell xrGhiChu;
    private ReportFooterBand ReportFooter;
    private XRTableCell xrTenKeHoach;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private GroupHeaderBand GroupHeader1;
    private XRTableCell xrThoiGianBatDau;
    private XRTableCell xrThoiGianKetThuc;
    private XRTableCell xrMaKeHoach;
    private XRTableCell xrThoiLuong;
    private XRTableCell xrHVThucTe;
    private XRTableCell xrHVDuKien;
    private XRPictureBox xrLogo;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private FormattingRule formattingRule1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrtTongHocVienDuKien;
    private XRTableCell xrtTongHocVienThucTe;
    private XRTableCell xrtKinhPhiThucTe;
    private XRTableCell xrTableCell8;
    private XRTableCell xrtKinhPhiDuKien;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BaoCaoDanhSachKhoaDaoTao()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrt_Stt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
        xrtngayketxuat.Text = new ReportController().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_DanhSachKhoaDaoTao", "@_MaDonVi","@MaBoPhan", "@_TuNgay", "@_DenNgay", "@WhereClause", "@StartMonth", "@EndMonth", "@Year",
                                                                    filter.SessionDepartment,filter.SelectedDepartment, filter.StartDate, filter.EndDate, filter.WhereClause, filter.StartMonth, filter.EndMonth, filter.Year);

        if (table.Rows.Count > 0)
        {
            DataSource = table;
            xrTenKeHoach.DataBindings.Add("Text", DataSource, "TEN_KHOA_HOC");
            xrHVDuKien.DataBindings.Add("Text", DataSource, "SOLUONG_HOCVIEN");
            xrThoiGianBatDau.DataBindings.Add("Text", DataSource, "TU_NGAY", "{0:dd/MM/yyyy}");
            xrThoiGianKetThuc.DataBindings.Add("Text", DataSource, "DEN_NGAY", "{0:dd/MM/yyyy}");
            xrHVThucTe.DataBindings.Add("Text", DataSource, "SoLuongThucTe", "{0:n0}");
            xrMaKeHoach.DataBindings.Add("Text", DataSource, "MA");
            xrKinhPhiDuKien.DataBindings.Add("Text", DataSource, "KINHPHI_DUKIEN", "{0:n0}");
            xrKinhPhiThucTe.DataBindings.Add("Text", DataSource, "KINHPHI_THUCTE", "{0:n0}");

            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.xrtTongHocVienDuKien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SOLUONG_HOCVIEN")});
            xrSummary1.FormatString = "{0:0,0}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrtTongHocVienDuKien.Summary = xrSummary1;

            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.xrtTongHocVienThucTe.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoLuongThucTe")});
            xrSummary2.FormatString = "{0:0,0}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrtTongHocVienThucTe.Summary = xrSummary2;

            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.xrtKinhPhiDuKien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "KINHPHI_DUKIEN")});
            xrSummary3.FormatString = "{0:0,0}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrtKinhPhiDuKien.Summary = xrSummary3;

            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.xrtKinhPhiThucTe.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "KINHPHI_THUCTE")});
            xrSummary4.FormatString = "{0:0,0}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrtKinhPhiThucTe.Summary = xrSummary4;
        }
        ReportController rpCtr = new ReportController();

        if (!string.IsNullOrEmpty(filter.Title1))
        {
            xrl_footer1.Text = filter.Title1;
        }
        else
        {
            xrl_footer1.Text = rpCtr.GetTitleOfSignature(xrl_footer1.Text, filter.Title1);
        }
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrl_footer2.Text = filter.Title2;
        }
        else
        {
            xrl_footer2.Text = rpCtr.GetTitleOfSignature(xrl_footer2.Text, filter.Title2);
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrl_footer3.Text = filter.Title3;
        }
        else
        {
            xrl_footer3.Text = rpCtr.GetTitleOfSignature(xrl_footer3.Text, filter.Title3);
        }
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrl_ten1.Text = filter.Name1;
        }
        else
        {
            xrl_ten1.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
        }
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrl_ten2.Text = filter.Name2;
        }
        else
        {
            xrl_ten2.Text = rpCtr.GetHeadOfHRroom(filter.SessionDepartment, filter.Name2);
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrl_ten3.Text = filter.Name3;
        }
        else
        {
            xrl_ten3.Text = rpCtr.GetDirectorName(filter.SessionDepartment, filter.Name3);
        }
        //tieu de
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_TitleBC.Text = filter.ReportTitle;
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
            string resourceFileName = "rp_BaoCaoDanhSachKhoaDaoTao.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_Stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrMaKeHoach = new DevExpress.XtraReports.UI.XRTableCell();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrTenKeHoach = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrThoiGianBatDau = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrThoiGianKetThuc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHVDuKien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHVThucTe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrThoiLuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrKinhPhiDuKien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrKinhPhiThucTe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrGhiChu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongHocVienDuKien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongHocVienThucTe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtKinhPhiDuKien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtKinhPhiThucTe = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
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
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1156F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_Stt,
            this.xrMaKeHoach,
            this.xrTenKeHoach,
            this.xrThoiGianBatDau,
            this.xrThoiGianKetThuc,
            this.xrHVDuKien,
            this.xrHVThucTe,
            this.xrThoiLuong,
            this.xrKinhPhiDuKien,
            this.xrKinhPhiThucTe,
            this.xrGhiChu});
            this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.KeepTogether = false;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.StylePriority.UseTextAlignment = false;
            this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_Stt
            // 
            this.xrt_Stt.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_Stt.Name = "xrt_Stt";
            this.xrt_Stt.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_Stt.StylePriority.UseFont = false;
            this.xrt_Stt.StylePriority.UsePadding = false;
            this.xrt_Stt.StylePriority.UseTextAlignment = false;
            this.xrt_Stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_Stt.Weight = 0.35416665980020634D;
            this.xrt_Stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrMaKeHoach
            // 
            this.xrMaKeHoach.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrMaKeHoach.FormattingRules.Add(this.formattingRule1);
            this.xrMaKeHoach.Name = "xrMaKeHoach";
            this.xrMaKeHoach.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrMaKeHoach.StylePriority.UseFont = false;
            this.xrMaKeHoach.StylePriority.UsePadding = false;
            this.xrMaKeHoach.StylePriority.UseTextAlignment = false;
            this.xrMaKeHoach.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrMaKeHoach.Weight = 0.88476548780222108D;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Condition = "[MA] == \'Tổng\'";
            // 
            // 
            // 
            this.formattingRule1.Formatting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.formattingRule1.Formatting.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.formattingRule1.Name = "formattingRule1";
            // 
            // xrTenKeHoach
            // 
            this.xrTenKeHoach.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTenKeHoach.FormattingRules.Add(this.formattingRule1);
            this.xrTenKeHoach.Name = "xrTenKeHoach";
            this.xrTenKeHoach.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTenKeHoach.StylePriority.UseFont = false;
            this.xrTenKeHoach.StylePriority.UsePadding = false;
            this.xrTenKeHoach.StylePriority.UseTextAlignment = false;
            this.xrTenKeHoach.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTenKeHoach.Weight = 1.4889319034366695D;
            // 
            // xrThoiGianBatDau
            // 
            this.xrThoiGianBatDau.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrThoiGianBatDau.FormattingRules.Add(this.formattingRule1);
            this.xrThoiGianBatDau.Name = "xrThoiGianBatDau";
            this.xrThoiGianBatDau.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrThoiGianBatDau.StylePriority.UseFont = false;
            this.xrThoiGianBatDau.StylePriority.UsePadding = false;
            this.xrThoiGianBatDau.StylePriority.UseTextAlignment = false;
            this.xrThoiGianBatDau.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrThoiGianBatDau.Weight = 0.936850749207868D;
            // 
            // xrThoiGianKetThuc
            // 
            this.xrThoiGianKetThuc.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrThoiGianKetThuc.FormattingRules.Add(this.formattingRule1);
            this.xrThoiGianKetThuc.Name = "xrThoiGianKetThuc";
            this.xrThoiGianKetThuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrThoiGianKetThuc.StylePriority.UseFont = false;
            this.xrThoiGianKetThuc.StylePriority.UsePadding = false;
            this.xrThoiGianKetThuc.StylePriority.UseTextAlignment = false;
            this.xrThoiGianKetThuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrThoiGianKetThuc.Weight = 0.9368507699312999D;
            // 
            // xrHVDuKien
            // 
            this.xrHVDuKien.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrHVDuKien.FormattingRules.Add(this.formattingRule1);
            this.xrHVDuKien.Name = "xrHVDuKien";
            this.xrHVDuKien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrHVDuKien.StylePriority.UseFont = false;
            this.xrHVDuKien.StylePriority.UsePadding = false;
            this.xrHVDuKien.StylePriority.UseTextAlignment = false;
            this.xrHVDuKien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrHVDuKien.Weight = 0.9368507440610081D;
            // 
            // xrHVThucTe
            // 
            this.xrHVThucTe.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrHVThucTe.FormattingRules.Add(this.formattingRule1);
            this.xrHVThucTe.Name = "xrHVThucTe";
            this.xrHVThucTe.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrHVThucTe.StylePriority.UseFont = false;
            this.xrHVThucTe.StylePriority.UsePadding = false;
            this.xrHVThucTe.StylePriority.UseTextAlignment = false;
            this.xrHVThucTe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrHVThucTe.Weight = 0.93685074406100832D;
            // 
            // xrThoiLuong
            // 
            this.xrThoiLuong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrThoiLuong.FormattingRules.Add(this.formattingRule1);
            this.xrThoiLuong.Name = "xrThoiLuong";
            this.xrThoiLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrThoiLuong.StylePriority.UseFont = false;
            this.xrThoiLuong.StylePriority.UsePadding = false;
            this.xrThoiLuong.StylePriority.UseTextAlignment = false;
            this.xrThoiLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrThoiLuong.Weight = 1.0305358194765819D;
            // 
            // xrKinhPhiDuKien
            // 
            this.xrKinhPhiDuKien.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrKinhPhiDuKien.FormattingRules.Add(this.formattingRule1);
            this.xrKinhPhiDuKien.Name = "xrKinhPhiDuKien";
            this.xrKinhPhiDuKien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrKinhPhiDuKien.StylePriority.UseFont = false;
            this.xrKinhPhiDuKien.StylePriority.UsePadding = false;
            this.xrKinhPhiDuKien.StylePriority.UseTextAlignment = false;
            this.xrKinhPhiDuKien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrKinhPhiDuKien.Weight = 0.93685074742591656D;
            // 
            // xrKinhPhiThucTe
            // 
            this.xrKinhPhiThucTe.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrKinhPhiThucTe.FormattingRules.Add(this.formattingRule1);
            this.xrKinhPhiThucTe.Name = "xrKinhPhiThucTe";
            this.xrKinhPhiThucTe.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrKinhPhiThucTe.StylePriority.UseFont = false;
            this.xrKinhPhiThucTe.StylePriority.UsePadding = false;
            this.xrKinhPhiThucTe.StylePriority.UseTextAlignment = false;
            this.xrKinhPhiThucTe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrKinhPhiThucTe.Weight = 0.9368506931106062D;
            // 
            // xrGhiChu
            // 
            this.xrGhiChu.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrGhiChu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrGhiChu.FormattingRules.Add(this.formattingRule1);
            this.xrGhiChu.Name = "xrGhiChu";
            this.xrGhiChu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrGhiChu.StylePriority.UseBorders = false;
            this.xrGhiChu.StylePriority.UseFont = false;
            this.xrGhiChu.StylePriority.UsePadding = false;
            this.xrGhiChu.StylePriority.UseTextAlignment = false;
            this.xrGhiChu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrGhiChu.Weight = 1.4504902700657567D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 46F;
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
            this.xrLogo,
            this.xrl_TitleBC,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 202F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLogo
            // 
            this.xrLogo.LocationFloat = new DevExpress.Utils.PointFloat(55.20833F, 0F);
            this.xrLogo.Name = "xrLogo";
            this.xrLogo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLogo.SizeF = new System.Drawing.SizeF(110F, 110F);
            this.xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrLogo.StylePriority.UsePadding = false;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 152.4167F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1156F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO DANH SÁCH  KẾ HOẠCH ĐÀO TẠO";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 114.9167F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(588.9323F, 22.99999F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 53.33332F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1156F, 53.33332F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell17,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell15});
            this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UseTextAlignment = false;
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 0.35416665980020634D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Mã kế hoạch";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell7.Weight = 0.884765615232717D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Tên kế hoạch đào tạo";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 1.4889317760061736D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Thời gian\r\nbắt đầu";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 0.936850571518859D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell17.StylePriority.UsePadding = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Thời gian\r\nkết thúc";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell17.Weight = 0.93685061436513128D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Số học viên\r\ndự kiến";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell5.Weight = 0.9368506143651314D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Số học viên\r\nthực tế";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell6.Weight = 0.936850604631076D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Thời lượng";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell10.Weight = 1.0305356475463354D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "Kinh phí\r\ndự kiến";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell11.Weight = 0.936850586730404D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "Kinh phí\r\nthực tế";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell12.Weight = 0.936850514063882D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100F);
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "Ghi chú";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell15.Weight = 1.4504895508193156D;
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
            this.ReportFooter.HeightF = 150F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(842.7083F, 123.5416F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(295.4998F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(430.2083F, 123.5416F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(55.20833F, 123.5416F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(842.7083F, 15.20831F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(295.4998F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(37.80397F, 34.99997F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(842.7083F, 40.20831F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(295.5F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(430.2083F, 40.20831F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "TRƯỞNG PHÒNG HCNS";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.GroupHeader1.HeightF = 35.00001F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1001.174F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrtTongHocVienDuKien,
            this.xrtTongHocVienThucTe,
            this.xrTableCell8,
            this.xrtKinhPhiDuKien,
            this.xrtKinhPhiThucTe});
            this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseFont = false;
            this.xrTableRow3.StylePriority.UseTextAlignment = false;
            this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Tổng cộng";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell4.Weight = 4.6015663191831617D;
            // 
            // xrtTongHocVienDuKien
            // 
            this.xrtTongHocVienDuKien.Name = "xrtTongHocVienDuKien";
            this.xrtTongHocVienDuKien.Weight = 0.93685119673804373D;
            // 
            // xrtTongHocVienThucTe
            // 
            this.xrtTongHocVienThucTe.Name = "xrtTongHocVienThucTe";
            this.xrtTongHocVienThucTe.Weight = 0.93685025397193589D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Weight = 1.0305358979373551D;
            // 
            // xrtKinhPhiDuKien
            // 
            this.xrtKinhPhiDuKien.Name = "xrtKinhPhiDuKien";
            this.xrtKinhPhiDuKien.Weight = 0.93685106882019475D;
            // 
            // xrtKinhPhiThucTe
            // 
            this.xrtKinhPhiThucTe.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrtKinhPhiThucTe.Name = "xrtKinhPhiThucTe";
            this.xrtKinhPhiThucTe.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtKinhPhiThucTe.StylePriority.UseFont = false;
            this.xrtKinhPhiThucTe.StylePriority.UsePadding = false;
            this.xrtKinhPhiThucTe.StylePriority.UseTextAlignment = false;
            this.xrtKinhPhiThucTe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrtKinhPhiThucTe.Weight = 0.93685049701183232D;
            // 
            // rp_BaoCaoDanhSachKhoaDaoTao
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1});
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(6, 7, 46, 49);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
