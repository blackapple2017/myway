using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_ThongKeLyDoNghiViec
/// </summary>
public class rp_ThongKeLyDoNghiViec : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_NgayBaoCao;
    private XRLabel xrl_TenCongTy;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell10;
    private XRTableCell xrt_TenPhongBan;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_STT;
    private XRTableCell xr_phongBan;
    private XRTableCell xrSoLuong;
    private XRTableCell xrNam;
    private XRTableCell xrNu;
    private XRTableCell xrKhac;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRLabel xrLabel1;
    private XRTableCell xrSauDaiHoc;
    private XRTableCell xrDaiHoc;
    private XRLabel xrLabel2;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_ThongKeLyDoNghiViec()
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

    public void BindData(ReportFilter filter)
    {
        try
        {
            ReportController controller = new ReportController();
            if (!string.IsNullOrEmpty(filter.ReportTitle))
            {
                xrl_TitleBC.Text = filter.ReportTitle;
            }
            xrLabel2.Text = new ReportWorldgame().GetLocationName(filter.SelectedDepartment);
            xrl_TenThanhPho.Text = controller.GetCityName(filter.SessionDepartment);
            xrl_TenCongTy.Text = controller.GetCompanyName(filter.SessionDepartment);
            xrl_ten2.Text = controller.GetHeadOfHRroom(filter.SessionDepartment, filter.Name1);
            xrl_ten3.Text = controller.GetDirectorName(filter.SessionDepartment, filter.Name2);

            xrl_footer2.Text = controller.GetTitleOfSignature(xrl_footer2.Text, filter.Title1);
            xrl_footer3.Text = controller.GetTitleOfSignature(xrl_footer3.Text, filter.Title2);
            xrtngayketxuat.Text = controller.GetFooterReport(filter.SessionDepartment, filter.ReportedDate);

            if (SoftCore.Util.GetInstance().IsDateNull(filter.StartDate))
            {
                filter.StartDate = new DateTime(1900, 1, 1);
            }
            if (SoftCore.Util.GetInstance().IsDateNull(filter.EndDate))
            {
                filter.EndDate = DateTime.Now;
            }
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("report_ThongKeLyDoThoiViec", "@startDate", "@endDate", "@mabophan", filter.StartDate, filter.EndDate, filter.SelectedDepartment);
            DataSource = table;

            if (filter.StartDate.Value.Year == 1900)
            {
                xrl_NgayBaoCao.Text = "Từ trước đây cho đến " + CommonUtil.GetInstance().GetDateFormat(filter.EndDate.Value);
            }
            else
            {
                xrl_NgayBaoCao.Text = string.Format(xrl_NgayBaoCao.Text, CommonUtil.GetInstance().GetDateFormat(filter.StartDate.Value), CommonUtil.GetInstance().GetDateFormat(filter.EndDate.Value)); 
            }
            xr_phongBan.DataBindings.Add("Text", DataSource, "TEN_DONVI");
            xrSoLuong.DataBindings.Add("Text", DataSource, "Count");
            xrNam.DataBindings.Add("Text", DataSource, "Nam");
            xrNu.DataBindings.Add("Text", DataSource, "Nu");
            xrDaiHoc.DataBindings.Add("Text", DataSource, "DaiHoc");
            xrKhac.DataBindings.Add("Text", DataSource, "Khac");
            xrSauDaiHoc.DataBindings.Add("Text", DataSource, "SauDaiHoc");

            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TEN_LYDO_NGHI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            xrt_TenPhongBan.DataBindings.Add("Text", DataSource, "TEN_LYDO_NGHI");

        }
        catch (Exception ex)
        {
            xrl_TitleBC.Text = ex.Message;
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
        string resourceFileName = "rp_ThongKeLyDoNghiViec.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_STT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xr_phongBan = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSoLuong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNam = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrKhac = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrDaiHoc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrSauDaiHoc = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NgayBaoCao = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_TenPhongBan = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
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
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(758.5821F, 25F);
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
            this.xr_phongBan,
            this.xrSoLuong,
            this.xrNam,
            this.xrNu,
            this.xrKhac,
            this.xrDaiHoc,
            this.xrSauDaiHoc});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseBorders = false;
        this.xrTableRow2.Weight = 1D;
        // 
        // xrt_STT
        // 
        this.xrt_STT.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_STT.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_STT.Name = "xrt_STT";
        this.xrt_STT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_STT.StylePriority.UseBorders = false;
        this.xrt_STT.StylePriority.UseFont = false;
        this.xrt_STT.StylePriority.UsePadding = false;
        this.xrt_STT.StylePriority.UseTextAlignment = false;
        this.xrt_STT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_STT.Weight = 0.53125D;
        this.xrt_STT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xr_phongBan
        // 
        this.xr_phongBan.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xr_phongBan.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xr_phongBan.Name = "xr_phongBan";
        this.xr_phongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xr_phongBan.StylePriority.UseBorders = false;
        this.xr_phongBan.StylePriority.UseFont = false;
        this.xr_phongBan.StylePriority.UsePadding = false;
        this.xr_phongBan.StylePriority.UseTextAlignment = false;
        this.xr_phongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xr_phongBan.Weight = 2.3677410128807335D;
        // 
        // xrSoLuong
        // 
        this.xrSoLuong.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrSoLuong.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrSoLuong.Name = "xrSoLuong";
        this.xrSoLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrSoLuong.StylePriority.UseBorders = false;
        this.xrSoLuong.StylePriority.UseFont = false;
        this.xrSoLuong.StylePriority.UsePadding = false;
        this.xrSoLuong.StylePriority.UseTextAlignment = false;
        this.xrSoLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSoLuong.Weight = 0.7594848266834533D;
        // 
        // xrNam
        // 
        this.xrNam.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrNam.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrNam.Name = "xrNam";
        this.xrNam.StylePriority.UseBorders = false;
        this.xrNam.StylePriority.UseFont = false;
        this.xrNam.StylePriority.UseTextAlignment = false;
        this.xrNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNam.Weight = 0.50754262803302552D;
        // 
        // xrNu
        // 
        this.xrNu.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrNu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrNu.Name = "xrNu";
        this.xrNu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrNu.StylePriority.UseBorders = false;
        this.xrNu.StylePriority.UseFont = false;
        this.xrNu.StylePriority.UsePadding = false;
        this.xrNu.StylePriority.UseTextAlignment = false;
        this.xrNu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNu.Weight = 0.45041553867957185D;
        // 
        // xrKhac
        // 
        this.xrKhac.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrKhac.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrKhac.Name = "xrKhac";
        this.xrKhac.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrKhac.StylePriority.UseBorders = false;
        this.xrKhac.StylePriority.UseFont = false;
        this.xrKhac.StylePriority.UsePadding = false;
        this.xrKhac.StylePriority.UseTextAlignment = false;
        this.xrKhac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrKhac.Weight = 1.1278551293136558D;
        // 
        // xrDaiHoc
        // 
        this.xrDaiHoc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrDaiHoc.Name = "xrDaiHoc";
        this.xrDaiHoc.StylePriority.UseBorders = false;
        this.xrDaiHoc.Weight = 1.1278559562871857D;
        // 
        // xrSauDaiHoc
        // 
        this.xrSauDaiHoc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrSauDaiHoc.Name = "xrSauDaiHoc";
        this.xrSauDaiHoc.StylePriority.UseBorders = false;
        this.xrSauDaiHoc.Weight = 1.1278559562871857D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 24F;
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
            this.xrLabel2,
            this.xrl_TitleBC,
            this.xrl_TenThanhPho,
            this.xrl_NgayBaoCao,
            this.xrl_TenCongTy});
        this.ReportHeader.HeightF = 144F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 47.99998F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(437.6954F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Chi nhánh :";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 93.66671F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(758.9999F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "THỐNG KÊ LÝ DO THÔI VIỆC";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(438.5416F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_NgayBaoCao
        // 
        this.xrl_NgayBaoCao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_NgayBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 116.6667F);
        this.xrl_NgayBaoCao.Name = "xrl_NgayBaoCao";
        this.xrl_NgayBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NgayBaoCao.SizeF = new System.Drawing.SizeF(758.9999F, 23.00001F);
        this.xrl_NgayBaoCao.StylePriority.UseFont = false;
        this.xrl_NgayBaoCao.StylePriority.UseTextAlignment = false;
        this.xrl_NgayBaoCao.Text = "Từ ngày : {0} đến ngày {1}";
        this.xrl_NgayBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(438.5417F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_footer2,
            this.xrl_footer3,
            this.xrtngayketxuat,
            this.xrl_ten2,
            this.xrl_ten3});
        this.ReportFooter.HeightF = 164F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 36.45833F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "PHÒNG HCNS";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(476.5832F, 36.45833F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(281.9166F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "TỔNG GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(476.5832F, 11.45833F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(2.000936F, 136.4583F);
        this.xrl_ten2.Name = "xrl_ten2";
        this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
        this.xrl_ten2.StylePriority.UseFont = false;
        this.xrl_ten2.StylePriority.UseTextAlignment = false;
        this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(476.5832F, 136.4583F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.GroupHeader1.HeightF = 25.41666F;
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
        this.xrTable3.SizeF = new System.Drawing.SizeF(758.4997F, 25.41666F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrt_TenPhongBan});
        this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.StylePriority.UseFont = false;
        this.xrTableRow3.StylePriority.UseTextAlignment = false;
        this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.Weight = 0.028569675410424031D;
        // 
        // xrt_TenPhongBan
        // 
        this.xrt_TenPhongBan.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_TenPhongBan.Name = "xrt_TenPhongBan";
        this.xrt_TenPhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrt_TenPhongBan.StylePriority.UseBorders = false;
        this.xrt_TenPhongBan.StylePriority.UsePadding = false;
        this.xrt_TenPhongBan.StylePriority.UseTextAlignment = false;
        this.xrt_TenPhongBan.Text = "Lý do thôi việc";
        this.xrt_TenPhongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_TenPhongBan.Weight = 10.801435060067524D;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 55F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(758.4996F, 55F);
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
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell3,
            this.xrTableCell5,
            this.xrTableCell6});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.StylePriority.UseBorders = false;
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.Weight = 0.53125D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Bộ phận / phòng ban";
        this.xrTableCell7.Weight = 2.4583335340940105D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Số lượng ";
        this.xrTableCell4.Weight = 0.78321894363701028D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Nam";
        this.xrTableCell3.Weight = 0.523403169863263D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Nữ";
        this.xrTableCell5.Weight = 0.46449061420571769D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrTable4});
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Weight = 3.4893029048353084D;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(106.6525F, 2.310637F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(106.6527F, 20.68938F);
        this.xrLabel1.StylePriority.UseBorders = false;
        this.xrLabel1.Text = "Trình độ";
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = DevExpress.XtraPrinting.BorderSide.Top;
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(320.8042F, 32F);
        this.xrTable4.StylePriority.UseBorders = false;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell8,
            this.xrTableCell9});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.Text = "PTTH/TC/Khác";
        this.xrTableCell2.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.Text = "Đại học";
        this.xrTableCell8.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.Text = "Sau Đại học";
        this.xrTableCell9.Weight = 1D;
        // 
        // rp_ThongKeLyDoNghiViec
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.PageHeader});
        this.Margins = new System.Drawing.Printing.Margins(43, 48, 24, 100);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
