using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoSoLuongLaoDong
/// </summary>
public class rp_BaoCaoSoLuongLaoDong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private GroupHeaderBand GroupHeader1;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell4;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_maphongban;
    private XRTableCell xrt_thang1;
    private XRTableCell xrt_thang2;
    private XRTableCell xrt_thang3;
    private XRTableCell xrt_thang4;
    private XRTableCell xrt_thang5;
    private XRTableCell xrt_thang6;
    private XRTableCell xrt_thang7;
    private XRTableCell xrt_thang8;
    private XRTableCell xrt_thang9;
    private XRTableCell xrt_thang10;
    private XRTableCell xrt_thang11;
    private XRTableCell xrt_thang12;
    private XRTableCell xrt_laodongtrungbinh;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_nhomphongban;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private XRPageInfo xrPageInfo1;
    private GroupFooterBand GroupFooter1;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrt_tong1;
    private XRTableCell xrt_tong2;
    private XRTableCell xrt_tong3;
    private XRTableCell xrt_tong4;
    private XRTableCell xrt_tong5;
    private XRTableCell xrt_tong6;
    private XRTableCell xrt_tong7;
    private XRTableCell xrt_tong8;
    private XRTableCell xrt_tong9;
    private XRTableCell xrt_tong10;
    private XRTableCell xrt_tong11;
    private XRTableCell xrt_tong12;
    private XRTableCell xrt_tong13;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BaoCaoSoLuongLaoDong()
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
        if (!string.IsNullOrEmpty(filter.StartDate.ToString()))
        {
            xrl_TitleBC.Text = "BÁO CÁO SỐ LAO ĐỘNG NĂM " + Convert.ToDateTime(filter.StartDate).Year;
        }

        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        xrl_TenThanhPho.Text = ReportController.GetInstance().GetCityName(filter.SessionDepartment);
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("rp_BaoCaoSoLaoDong", "@MaDonVi", "@MaBoPhan", "@Nam", filter.SessionDepartment, filter.SelectedDepartment, filter.Year);
        DataSource = table;
        xrt_maphongban.DataBindings.Add("Text", DataSource, "MA_DONVI");
        xrt_thang1.DataBindings.Add("Text", DataSource, "thang1");
        xrt_thang2.DataBindings.Add("Text", DataSource, "thang2");
        xrt_thang3.DataBindings.Add("Text", DataSource, "thang3");
        xrt_thang4.DataBindings.Add("Text", DataSource, "thang4");
        xrt_thang5.DataBindings.Add("Text", DataSource, "thang5");
        xrt_thang6.DataBindings.Add("Text", DataSource, "thang6");
        xrt_thang7.DataBindings.Add("Text", DataSource, "thang7");
        xrt_thang8.DataBindings.Add("Text", DataSource, "thang8");
        xrt_thang9.DataBindings.Add("Text", DataSource, "thang9");
        xrt_thang10.DataBindings.Add("Text", DataSource, "thang10");
        xrt_thang11.DataBindings.Add("Text", DataSource, "thang11");
        xrt_thang12.DataBindings.Add("Text", DataSource, "thang12");
        xrt_laodongtrungbinh.DataBindings.Add("Text", DataSource, "trungbinh", "{0:n1}");
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TEN_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrt_nhomphongban.DataBindings.Add("Text", DataSource, "TEN_DONVI");

        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong1.DataBindings.Add("Text", DataSource, "thang1");
        xrSummary1.FormatString = "{0:n0}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary1.Func = SummaryFunc.Sum;
        xrt_tong1.Summary = xrSummary1;
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong2.DataBindings.Add("Text", DataSource, "thang2");
        xrSummary2.FormatString = "{0:n0}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary2.Func = SummaryFunc.Sum;
        xrt_tong2.Summary = xrSummary2;
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong3.DataBindings.Add("Text", DataSource, "thang3");
        xrSummary3.FormatString = "{0:n0}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary3.Func = SummaryFunc.Sum;
        xrt_tong3.Summary = xrSummary3;

        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong4.DataBindings.Add("Text", DataSource, "thang4");
        xrSummary4.FormatString = "{0:n0}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary4.Func = SummaryFunc.Sum;
        xrt_tong4.Summary = xrSummary4;

        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong5.DataBindings.Add("Text", DataSource, "thang5");
        xrSummary5.FormatString = "{0:n0}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary5.Func = SummaryFunc.Sum;
        xrt_tong5.Summary = xrSummary5;

        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong6.DataBindings.Add("Text", DataSource, "thang6");
        xrSummary6.FormatString = "{0:n0}";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary6.Func = SummaryFunc.Sum;
        xrt_tong6.Summary = xrSummary6;

        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong7.DataBindings.Add("Text", DataSource, "thang7");
        xrSummary7.FormatString = "{0:n0}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary7.Func = SummaryFunc.Sum;
        xrt_tong7.Summary = xrSummary7;

        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong8.DataBindings.Add("Text", DataSource, "thang8");
        xrSummary8.FormatString = "{0:n0}";
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary8.Func = SummaryFunc.Sum;
        xrt_tong8.Summary = xrSummary8;

        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong9.DataBindings.Add("Text", DataSource, "thang9");
        xrSummary9.FormatString = "{0:n0}";
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary9.Func = SummaryFunc.Sum;
        xrt_tong9.Summary = xrSummary9;

        DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong10.DataBindings.Add("Text", DataSource, "thang10");
        xrSummary10.FormatString = "{0:n0}";
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary10.Func = SummaryFunc.Sum;
        xrt_tong10.Summary = xrSummary10;

        DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong11.DataBindings.Add("Text", DataSource, "thang11");
        xrSummary11.FormatString = "{0:n0}";
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary11.Func = SummaryFunc.Sum;
        xrt_tong11.Summary = xrSummary11;

        DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong12.DataBindings.Add("Text", DataSource, "thang12");
        xrSummary12.FormatString = "{0:n0}";
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary12.Func = SummaryFunc.Sum;
        xrt_tong12.Summary = xrSummary12;

        DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
        xrt_tong13.DataBindings.Add("Text", DataSource, "trungbinh");
        xrSummary13.FormatString = "{0:n0}";
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        xrSummary13.Func = SummaryFunc.Sum;
        xrt_tong13.Summary = xrSummary13;

        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_TitleBC.Text = filter.ReportTitle.ToUpper();
        }
        if (!string.IsNullOrEmpty(filter.Title1))
        {
            xrl_footer1.Text = filter.Title1;
        }
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrl_footer2.Text = filter.Title2;
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrl_footer3.Text = filter.Title3;
        }

        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrl_ten1.Text = filter.Name1;
        }
        else
        {
            xrl_ten1.Text = filter.Reporter.ToString();
        }
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrl_ten2.Text = filter.Name2;
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrl_ten3.Text = filter.Name3;
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
        string resourceFileName = "rp_BaoCaoSoLuongLaoDong.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_maphongban = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thang12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_laodongtrungbinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_nhomphongban = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tong13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
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
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1148F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_maphongban,
            this.xrt_thang1,
            this.xrt_thang2,
            this.xrt_thang3,
            this.xrt_thang4,
            this.xrt_thang5,
            this.xrt_thang6,
            this.xrt_thang7,
            this.xrt_thang8,
            this.xrt_thang9,
            this.xrt_thang10,
            this.xrt_thang11,
            this.xrt_thang12,
            this.xrt_laodongtrungbinh});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrt_stt
        // 
        this.xrt_stt.Name = "xrt_stt";
        this.xrt_stt.StylePriority.UseTextAlignment = false;
        this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_stt.Weight = 0.11252697668839834D;
        this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrt_maphongban
        // 
        this.xrt_maphongban.Name = "xrt_maphongban";
        this.xrt_maphongban.StylePriority.UseTextAlignment = false;
        this.xrt_maphongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_maphongban.Weight = 0.29136746768752042D;
        // 
        // xrt_thang1
        // 
        this.xrt_thang1.Name = "xrt_thang1";
        this.xrt_thang1.StylePriority.UseTextAlignment = false;
        this.xrt_thang1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang1.Weight = 0.16574270135434255D;
        // 
        // xrt_thang2
        // 
        this.xrt_thang2.Name = "xrt_thang2";
        this.xrt_thang2.StylePriority.UseTextAlignment = false;
        this.xrt_thang2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang2.Weight = 0.17268869021213007D;
        // 
        // xrt_thang3
        // 
        this.xrt_thang3.Name = "xrt_thang3";
        this.xrt_thang3.StylePriority.UseTextAlignment = false;
        this.xrt_thang3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang3.Weight = 0.16229196375670746D;
        // 
        // xrt_thang4
        // 
        this.xrt_thang4.Name = "xrt_thang4";
        this.xrt_thang4.StylePriority.UseTextAlignment = false;
        this.xrt_thang4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang4.Weight = 0.18331305158262878D;
        // 
        // xrt_thang5
        // 
        this.xrt_thang5.Name = "xrt_thang5";
        this.xrt_thang5.StylePriority.UseTextAlignment = false;
        this.xrt_thang5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang5.Weight = 0.1788781713110229D;
        // 
        // xrt_thang6
        // 
        this.xrt_thang6.Name = "xrt_thang6";
        this.xrt_thang6.StylePriority.UseTextAlignment = false;
        this.xrt_thang6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang6.Weight = 0.18738834887016109D;
        // 
        // xrt_thang7
        // 
        this.xrt_thang7.Name = "xrt_thang7";
        this.xrt_thang7.StylePriority.UseTextAlignment = false;
        this.xrt_thang7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang7.Weight = 0.18850739762342764D;
        // 
        // xrt_thang8
        // 
        this.xrt_thang8.Name = "xrt_thang8";
        this.xrt_thang8.StylePriority.UseTextAlignment = false;
        this.xrt_thang8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang8.Weight = 0.19292744952627175D;
        // 
        // xrt_thang9
        // 
        this.xrt_thang9.Name = "xrt_thang9";
        this.xrt_thang9.StylePriority.UseTextAlignment = false;
        this.xrt_thang9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang9.Weight = 0.21882810087984864D;
        // 
        // xrt_thang10
        // 
        this.xrt_thang10.Name = "xrt_thang10";
        this.xrt_thang10.StylePriority.UseTextAlignment = false;
        this.xrt_thang10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang10.Weight = 0.18525421993242325D;
        // 
        // xrt_thang11
        // 
        this.xrt_thang11.Name = "xrt_thang11";
        this.xrt_thang11.StylePriority.UseTextAlignment = false;
        this.xrt_thang11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang11.Weight = 0.19617167748640638D;
        // 
        // xrt_thang12
        // 
        this.xrt_thang12.Name = "xrt_thang12";
        this.xrt_thang12.StylePriority.UseTextAlignment = false;
        this.xrt_thang12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thang12.Weight = 0.18678256443568642D;
        // 
        // xrt_laodongtrungbinh
        // 
        this.xrt_laodongtrungbinh.Name = "xrt_laodongtrungbinh";
        this.xrt_laodongtrungbinh.StylePriority.UseTextAlignment = false;
        this.xrt_laodongtrungbinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_laodongtrungbinh.Weight = 0.37733121865302421D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 47F;
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
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
        this.ReportHeader.HeightF = 89F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 56.25F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1102F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BÁO CÁO SỐ LƯỢNG LAO ĐỘNG ";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99999F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(484.7656F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(484.7656F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 40.625F;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(1148F, 40.625F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell8,
            this.xrTableCell6,
            this.xrTableCell12,
            this.xrTableCell7,
            this.xrTableCell13,
            this.xrTableCell2,
            this.xrTableCell10,
            this.xrTableCell9,
            this.xrTableCell14,
            this.xrTableCell11,
            this.xrTableCell15,
            this.xrTableCell3,
            this.xrTableCell4});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "STT";
        this.xrTableCell5.Weight = 0.08806291890067254D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Mã phòng ban";
        this.xrTableCell1.Weight = 0.22802237539439835D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Tháng 1";
        this.xrTableCell8.Weight = 0.12970913194502332D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Tháng 2";
        this.xrTableCell6.Weight = 0.13514518445808721D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Tháng 3";
        this.xrTableCell12.Weight = 0.12700882060060031D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Tháng 4";
        this.xrTableCell7.Weight = 0.143459536449765D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Text = "Tháng 5";
        this.xrTableCell13.Weight = 0.13998895277604948D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Tháng 6";
        this.xrTableCell2.Weight = 0.1466489547511439D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = "Tháng 7";
        this.xrTableCell10.Weight = 0.14752472097252056D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Tháng 8";
        this.xrTableCell9.Weight = 0.1509839546736364D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = "Tháng 9";
        this.xrTableCell14.Weight = 0.17125339769003029D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Tháng 10";
        this.xrTableCell11.Weight = 0.14497894512332046D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Tháng 11";
        this.xrTableCell15.Weight = 0.1535226138423258D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Tháng 12";
        this.xrTableCell3.Weight = 0.14617500715608542D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Lao động trung bình các tháng";
        this.xrTableCell4.Weight = 0.29529692416294323D;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.GroupHeader1.HeightF = 25F;
        this.GroupHeader1.Name = "GroupHeader1";
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
        this.xrTable3.SizeF = new System.Drawing.SizeF(1148F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_nhomphongban});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrt_nhomphongban
        // 
        this.xrt_nhomphongban.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrt_nhomphongban.Name = "xrt_nhomphongban";
        this.xrt_nhomphongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
        this.xrt_nhomphongban.StylePriority.UseFont = false;
        this.xrt_nhomphongban.StylePriority.UsePadding = false;
        this.xrt_nhomphongban.StylePriority.UseTextAlignment = false;
        this.xrt_nhomphongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_nhomphongban.Weight = 3D;
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
            this.xrl_footer2,
            this.xrTable4});
        this.ReportFooter.HeightF = 239F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(815.4998F, 172.9167F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(296.5F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(402.9998F, 172.9167F);
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
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(27.99981F, 172.9167F);
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
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(815.4998F, 47.91667F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(296.5F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(27.99981F, 72.91666F);
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
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(815.4998F, 72.91666F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(296.5002F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(402.9998F, 72.91666F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "PHÒNG TCHC";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(1148F, 25F);
        this.xrTable4.StylePriority.UseBorders = false;
        this.xrTable4.StylePriority.UseFont = false;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrt_tong1,
            this.xrt_tong2,
            this.xrt_tong3,
            this.xrt_tong4,
            this.xrt_tong5,
            this.xrt_tong6,
            this.xrt_tong7,
            this.xrt_tong8,
            this.xrt_tong9,
            this.xrt_tong10,
            this.xrt_tong11,
            this.xrt_tong12,
            this.xrt_tong13});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.11252697668839834D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseFont = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.Text = "Tổng";
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell18.Weight = 0.29136746768752042D;
        // 
        // xrt_tong1
        // 
        this.xrt_tong1.Name = "xrt_tong1";
        this.xrt_tong1.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:n0}";
        xrSummary1.IgnoreNullValues = true;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong1.Summary = xrSummary1;
        this.xrt_tong1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong1.Weight = 0.16574270135434255D;
        // 
        // xrt_tong2
        // 
        this.xrt_tong2.Name = "xrt_tong2";
        this.xrt_tong2.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:n0}";
        xrSummary2.IgnoreNullValues = true;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong2.Summary = xrSummary2;
        this.xrt_tong2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong2.Weight = 0.17268869021213007D;
        // 
        // xrt_tong3
        // 
        this.xrt_tong3.Name = "xrt_tong3";
        this.xrt_tong3.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:n0}";
        xrSummary3.IgnoreNullValues = true;
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong3.Summary = xrSummary3;
        this.xrt_tong3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong3.Weight = 0.16229196375670746D;
        // 
        // xrt_tong4
        // 
        this.xrt_tong4.Name = "xrt_tong4";
        this.xrt_tong4.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:n0}";
        xrSummary4.IgnoreNullValues = true;
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong4.Summary = xrSummary4;
        this.xrt_tong4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong4.Weight = 0.18331305158262878D;
        // 
        // xrt_tong5
        // 
        this.xrt_tong5.Name = "xrt_tong5";
        this.xrt_tong5.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:n0}";
        xrSummary5.IgnoreNullValues = true;
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong5.Summary = xrSummary5;
        this.xrt_tong5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong5.Weight = 0.1788781713110229D;
        // 
        // xrt_tong6
        // 
        this.xrt_tong6.Name = "xrt_tong6";
        this.xrt_tong6.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:n0}";
        xrSummary6.IgnoreNullValues = true;
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong6.Summary = xrSummary6;
        this.xrt_tong6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong6.Weight = 0.18738834887016109D;
        // 
        // xrt_tong7
        // 
        this.xrt_tong7.Name = "xrt_tong7";
        this.xrt_tong7.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:n0}";
        xrSummary7.IgnoreNullValues = true;
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong7.Summary = xrSummary7;
        this.xrt_tong7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong7.Weight = 0.18850739762342764D;
        // 
        // xrt_tong8
        // 
        this.xrt_tong8.Name = "xrt_tong8";
        this.xrt_tong8.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:n0}";
        xrSummary8.IgnoreNullValues = true;
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong8.Summary = xrSummary8;
        this.xrt_tong8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong8.Weight = 0.19292744952627175D;
        // 
        // xrt_tong9
        // 
        this.xrt_tong9.Name = "xrt_tong9";
        this.xrt_tong9.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:n0}";
        xrSummary9.IgnoreNullValues = true;
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong9.Summary = xrSummary9;
        this.xrt_tong9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong9.Weight = 0.21882810087984864D;
        // 
        // xrt_tong10
        // 
        this.xrt_tong10.Name = "xrt_tong10";
        this.xrt_tong10.StylePriority.UseTextAlignment = false;
        xrSummary10.FormatString = "{0:n0}";
        xrSummary10.IgnoreNullValues = true;
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong10.Summary = xrSummary10;
        this.xrt_tong10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong10.Weight = 0.18525421993242325D;
        // 
        // xrt_tong11
        // 
        this.xrt_tong11.Name = "xrt_tong11";
        this.xrt_tong11.StylePriority.UseTextAlignment = false;
        xrSummary11.FormatString = "{0:n0}";
        xrSummary11.IgnoreNullValues = true;
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong11.Summary = xrSummary11;
        this.xrt_tong11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong11.Weight = 0.19617167748640638D;
        // 
        // xrt_tong12
        // 
        this.xrt_tong12.Name = "xrt_tong12";
        this.xrt_tong12.StylePriority.UseTextAlignment = false;
        xrSummary12.FormatString = "{0:n0}";
        xrSummary12.IgnoreNullValues = true;
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong12.Summary = xrSummary12;
        this.xrt_tong12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tong12.Weight = 0.18678256443568642D;
        // 
        // xrt_tong13
        // 
        this.xrt_tong13.Name = "xrt_tong13";
        this.xrt_tong13.StylePriority.UseTextAlignment = false;
        xrSummary13.FormatString = "{0:n1}";
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrt_tong13.Summary = xrSummary13;
        this.xrt_tong13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_tong13.Weight = 0.37733121865302421D;
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
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1021.958F, 36.45833F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.HeightF = 25F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // rp_BaoCaoSoLuongLaoDong
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportFooter,
            this.PageFooter,
            this.GroupFooter1});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(10, 11, 47, 100);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
