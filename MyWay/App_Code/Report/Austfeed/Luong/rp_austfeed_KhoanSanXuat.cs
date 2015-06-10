using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Ext.Net;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_austfeed_KhoanSanXuat
/// </summary>
public class rp_austfeed_KhoanSanXuat : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
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
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell38;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTableCell xrTableCell100;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTableCell xrTableCell105;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_austfeed_KhoanSanXuat()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrTableCell71.Text = STT.ToString();
        STT++;
    }
    public void BinData(ReportFilter filter)
    {
        try
        {
            ReportController rp = new ReportController();
            DataTable dt = DataHandler.GetInstance().ExecuteDataTable("rp_austfeed_BaoCaoTongHopLuongKhoan", "@Thang", "@Nam", "@MaDonVi",
                                                                       filter.StartMonth, filter.Year, filter.SelectedDepartment);
            if (dt.Rows.Count > 0)
            {
                DataSource = dt;
                xrTableCell72.DataBindings.Add("Text", DataSource, "MA_CB");
                xrTableCell73.DataBindings.Add("Text", DataSource, "HO_TEN");
                xrTableCell74.DataBindings.Add("Text", DataSource, "Ngay1", "{0:n0}");
                xrTableCell75.DataBindings.Add("Text", DataSource, "Ngay2", "{0:n0}");
                xrTableCell76.DataBindings.Add("Text", DataSource, "Ngay3", "{0:n0}");
                xrTableCell77.DataBindings.Add("Text", DataSource, "Ngay4", "{0:n0}");
                xrTableCell78.DataBindings.Add("Text", DataSource, "Ngay5", "{0:n0}");
                xrTableCell79.DataBindings.Add("Text", DataSource, "Ngay6", "{0:n0}");
                xrTableCell80.DataBindings.Add("Text", DataSource, "Ngay7", "{0:n0}");
                xrTableCell81.DataBindings.Add("Text", DataSource, "Ngay8", "{0:n0}");
                xrTableCell82.DataBindings.Add("Text", DataSource, "Ngay9", "{0:n0}");
                xrTableCell83.DataBindings.Add("Text", DataSource, "Ngay10", "{0:n0}");
                xrTableCell83.DataBindings.Add("Text", DataSource, "Ngay11", "{0:n0}");
                xrTableCell85.DataBindings.Add("Text", DataSource, "Ngay12", "{0:n0}");
                xrTableCell86.DataBindings.Add("Text", DataSource, "Ngay13", "{0:n0}");
                xrTableCell87.DataBindings.Add("Text", DataSource, "Ngay14", "{0:n0}");
                xrTableCell88.DataBindings.Add("Text", DataSource, "Ngay15", "{0:n0}");
                xrTableCell89.DataBindings.Add("Text", DataSource, "Ngay16", "{0:n0}");
                xrTableCell90.DataBindings.Add("Text", DataSource, "Ngay17", "{0:n0}");
                xrTableCell91.DataBindings.Add("Text", DataSource, "Ngay18", "{0:n0}");
                xrTableCell92.DataBindings.Add("Text", DataSource, "Ngay19", "{0:n0}");
                xrTableCell93.DataBindings.Add("Text", DataSource, "Ngay20", "{0:n0}");
                xrTableCell94.DataBindings.Add("Text", DataSource, "Ngay21", "{0:n0}");
                xrTableCell95.DataBindings.Add("Text", DataSource, "Ngay22", "{0:n0}");
                xrTableCell96.DataBindings.Add("Text", DataSource, "Ngay23", "{0:n0}");
                xrTableCell97.DataBindings.Add("Text", DataSource, "Ngay24", "{0:n0}");
                xrTableCell98.DataBindings.Add("Text", DataSource, "Ngay25", "{0:n0}");
                xrTableCell99.DataBindings.Add("Text", DataSource, "Ngay26", "{0:n0}");
                xrTableCell100.DataBindings.Add("Text", DataSource, "Ngay27", "{0:n0}");
                xrTableCell101.DataBindings.Add("Text", DataSource, "Ngay28", "{0:n0}");
                xrTableCell102.DataBindings.Add("Text", DataSource, "Ngay29", "{0:n0}");
                xrTableCell103.DataBindings.Add("Text", DataSource, "Ngay30", "{0:n0}");
                xrTableCell104.DataBindings.Add("Text", DataSource, "Ngay31", "{0:n0}");
                xrTableCell105.DataBindings.Add("Text", DataSource, "TongCong", "{0:n0}");
                //Group header
                this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                new DevExpress.XtraReports.UI.GroupField("MA_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
                xrTableCell38.DataBindings.Add("Text", DataSource, "TEN_DONVI");
                //Title
                xrLabel1.Text = string.Format(xrLabel1.Text, filter.StartMonth, filter.Year);


            }
        }
        catch (Exception e)
        {
            X.Msg.Alert("Thông báo", "Có lỗi: " + e).Show();
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
        string resourceFileName = "rp_austfeed_KhoanSanXuat.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.Detail.HeightF = 32.29167F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1635F, 32.29167F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UsePadding = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell75,
            this.xrTableCell76,
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell81,
            this.xrTableCell82,
            this.xrTableCell83,
            this.xrTableCell84,
            this.xrTableCell85,
            this.xrTableCell86,
            this.xrTableCell87,
            this.xrTableCell88,
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrTableCell91,
            this.xrTableCell92,
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell95,
            this.xrTableCell96,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99,
            this.xrTableCell100,
            this.xrTableCell101,
            this.xrTableCell102,
            this.xrTableCell103,
            this.xrTableCell104,
            this.xrTableCell105});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell71
        // 
        this.xrTableCell71.Name = "xrTableCell71";
        this.xrTableCell71.StylePriority.UseTextAlignment = false;
        this.xrTableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell71.Weight = 0.060015295186174031D;
        this.xrTableCell71.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTableCell72
        // 
        this.xrTableCell72.Name = "xrTableCell72";
        this.xrTableCell72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
        this.xrTableCell72.StylePriority.UsePadding = false;
        this.xrTableCell72.StylePriority.UseTextAlignment = false;
        this.xrTableCell72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell72.Weight = 0.11353211009174312D;
        // 
        // xrTableCell73
        // 
        this.xrTableCell73.Name = "xrTableCell73";
        this.xrTableCell73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
        this.xrTableCell73.StylePriority.UsePadding = false;
        this.xrTableCell73.StylePriority.UseTextAlignment = false;
        this.xrTableCell73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell73.Weight = 0.19648319909332002D;
        // 
        // xrTableCell74
        // 
        this.xrTableCell74.Name = "xrTableCell74";
        this.xrTableCell74.Weight = 0.0788990764442934D;
        // 
        // xrTableCell75
        // 
        this.xrTableCell75.Name = "xrTableCell75";
        this.xrTableCell75.Weight = 0.07889907644429342D;
        // 
        // xrTableCell76
        // 
        this.xrTableCell76.Name = "xrTableCell76";
        this.xrTableCell76.Weight = 0.078899076444293392D;
        // 
        // xrTableCell77
        // 
        this.xrTableCell77.Name = "xrTableCell77";
        this.xrTableCell77.Weight = 0.078899076444293448D;
        // 
        // xrTableCell78
        // 
        this.xrTableCell78.Name = "xrTableCell78";
        this.xrTableCell78.Weight = 0.078899076444293448D;
        // 
        // xrTableCell79
        // 
        this.xrTableCell79.Name = "xrTableCell79";
        this.xrTableCell79.Weight = 0.0788990764442935D;
        // 
        // xrTableCell80
        // 
        this.xrTableCell80.Name = "xrTableCell80";
        this.xrTableCell80.Weight = 0.078899076444293392D;
        // 
        // xrTableCell81
        // 
        this.xrTableCell81.Name = "xrTableCell81";
        this.xrTableCell81.Weight = 0.078899076444293392D;
        // 
        // xrTableCell82
        // 
        this.xrTableCell82.Name = "xrTableCell82";
        this.xrTableCell82.Weight = 0.078899076444293392D;
        // 
        // xrTableCell83
        // 
        this.xrTableCell83.Name = "xrTableCell83";
        this.xrTableCell83.Weight = 0.078899076444293392D;
        // 
        // xrTableCell84
        // 
        this.xrTableCell84.Name = "xrTableCell84";
        this.xrTableCell84.Weight = 0.078899076444293392D;
        // 
        // xrTableCell85
        // 
        this.xrTableCell85.Name = "xrTableCell85";
        this.xrTableCell85.Weight = 0.078899076444293392D;
        // 
        // xrTableCell86
        // 
        this.xrTableCell86.Name = "xrTableCell86";
        this.xrTableCell86.Weight = 0.078899076444293392D;
        // 
        // xrTableCell87
        // 
        this.xrTableCell87.Name = "xrTableCell87";
        this.xrTableCell87.Weight = 0.078899076444293392D;
        // 
        // xrTableCell88
        // 
        this.xrTableCell88.Name = "xrTableCell88";
        this.xrTableCell88.Weight = 0.078899076444293392D;
        // 
        // xrTableCell89
        // 
        this.xrTableCell89.Name = "xrTableCell89";
        this.xrTableCell89.Weight = 0.0822104353970344D;
        // 
        // xrTableCell90
        // 
        this.xrTableCell90.Name = "xrTableCell90";
        this.xrTableCell90.Weight = 0.0822104353970344D;
        // 
        // xrTableCell91
        // 
        this.xrTableCell91.Name = "xrTableCell91";
        this.xrTableCell91.Weight = 0.0822104353970344D;
        // 
        // xrTableCell92
        // 
        this.xrTableCell92.Name = "xrTableCell92";
        this.xrTableCell92.Weight = 0.0822104353970344D;
        // 
        // xrTableCell93
        // 
        this.xrTableCell93.Name = "xrTableCell93";
        this.xrTableCell93.Weight = 0.0822104353970344D;
        // 
        // xrTableCell94
        // 
        this.xrTableCell94.Name = "xrTableCell94";
        this.xrTableCell94.Weight = 0.0822104353970344D;
        // 
        // xrTableCell95
        // 
        this.xrTableCell95.Name = "xrTableCell95";
        this.xrTableCell95.Weight = 0.0822104353970344D;
        // 
        // xrTableCell96
        // 
        this.xrTableCell96.Name = "xrTableCell96";
        this.xrTableCell96.Weight = 0.0822104353970344D;
        // 
        // xrTableCell97
        // 
        this.xrTableCell97.Name = "xrTableCell97";
        this.xrTableCell97.Weight = 0.0822104353970344D;
        // 
        // xrTableCell98
        // 
        this.xrTableCell98.Name = "xrTableCell98";
        this.xrTableCell98.Weight = 0.0822104353970344D;
        // 
        // xrTableCell99
        // 
        this.xrTableCell99.Name = "xrTableCell99";
        this.xrTableCell99.Weight = 0.0822104353970344D;
        // 
        // xrTableCell100
        // 
        this.xrTableCell100.Name = "xrTableCell100";
        this.xrTableCell100.Weight = 0.0822104353970344D;
        // 
        // xrTableCell101
        // 
        this.xrTableCell101.Name = "xrTableCell101";
        this.xrTableCell101.Weight = 0.0822104353970344D;
        // 
        // xrTableCell102
        // 
        this.xrTableCell102.Name = "xrTableCell102";
        this.xrTableCell102.Weight = 0.0822104353970344D;
        // 
        // xrTableCell103
        // 
        this.xrTableCell103.Name = "xrTableCell103";
        this.xrTableCell103.Weight = 0.0822104353970344D;
        // 
        // xrTableCell104
        // 
        this.xrTableCell104.Name = "xrTableCell104";
        this.xrTableCell104.Weight = 0.0822104353970344D;
        // 
        // xrTableCell105
        // 
        this.xrTableCell105.Name = "xrTableCell105";
        this.xrTableCell105.Weight = 0.13111628261181194D;
        // 
        // TopMargin
        // 
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
            this.xrLabel1});
        this.ReportHeader.HeightF = 41F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(1635F, 28.125F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "BÁO CÁO KHOÁN SẢN XUẤT THÁNG {0} NĂM {1}";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 32.29167F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1635F, 32.29167F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell5,
            this.xrTableCell4,
            this.xrTableCell10,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell2,
            this.xrTableCell12,
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell1,
            this.xrTableCell16,
            this.xrTableCell15,
            this.xrTableCell17,
            this.xrTableCell14,
            this.xrTableCell19,
            this.xrTableCell18,
            this.xrTableCell20,
            this.xrTableCell28,
            this.xrTableCell27,
            this.xrTableCell29,
            this.xrTableCell22,
            this.xrTableCell30,
            this.xrTableCell26,
            this.xrTableCell31,
            this.xrTableCell21,
            this.xrTableCell32,
            this.xrTableCell24,
            this.xrTableCell33,
            this.xrTableCell23,
            this.xrTableCell34,
            this.xrTableCell25,
            this.xrTableCell35,
            this.xrTableCell7,
            this.xrTableCell3});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "STT";
        this.xrTableCell6.Weight = 0.060015295186174031D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Mã cán bộ";
        this.xrTableCell5.Weight = 0.11353211009174312D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Họ tên";
        this.xrTableCell4.Weight = 0.19648319909332002D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = "Ngày 1";
        this.xrTableCell10.Weight = 0.0788990764442934D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Ngày 2";
        this.xrTableCell8.Weight = 0.07889907644429342D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Ngày 3";
        this.xrTableCell9.Weight = 0.078899076444293392D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Ngày 4";
        this.xrTableCell2.Weight = 0.078899076444293448D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Ngày 5";
        this.xrTableCell12.Weight = 0.078899076444293448D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Ngày 6";
        this.xrTableCell11.Weight = 0.0788990764442935D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Text = "Ngày 7";
        this.xrTableCell13.Weight = 0.078899076444293392D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Ngày 8";
        this.xrTableCell1.Weight = 0.078899076444293392D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Text = "Ngày 9";
        this.xrTableCell16.Weight = 0.078899076444293392D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Ngày 10";
        this.xrTableCell15.Weight = 0.078899076444293392D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Text = "Ngày 11";
        this.xrTableCell17.Weight = 0.078899076444293392D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = "Ngày 12";
        this.xrTableCell14.Weight = 0.078899076444293392D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.Text = "Ngày 13";
        this.xrTableCell19.Weight = 0.078899076444293392D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Text = "Ngày 14";
        this.xrTableCell18.Weight = 0.078899076444293392D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Text = "Ngày 15";
        this.xrTableCell20.Weight = 0.078899076444293392D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.Text = "Ngày 16";
        this.xrTableCell28.Weight = 0.0822104353970344D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.Text = "Ngày 17";
        this.xrTableCell27.Weight = 0.0822104353970344D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.Text = "Ngày 18";
        this.xrTableCell29.Weight = 0.0822104353970344D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Text = "Ngày 19";
        this.xrTableCell22.Weight = 0.0822104353970344D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.Text = "Ngày 20";
        this.xrTableCell30.Weight = 0.0822104353970344D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Text = "Ngày 21";
        this.xrTableCell26.Weight = 0.0822104353970344D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.Text = "Ngày 22";
        this.xrTableCell31.Weight = 0.0822104353970344D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Text = "Ngày 23";
        this.xrTableCell21.Weight = 0.0822104353970344D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.Text = "Ngày 24";
        this.xrTableCell32.Weight = 0.0822104353970344D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Text = "Ngày 25";
        this.xrTableCell24.Weight = 0.0822104353970344D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.Text = "Ngày 26";
        this.xrTableCell33.Weight = 0.0822104353970344D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Text = "Ngày 27";
        this.xrTableCell23.Weight = 0.0822104353970344D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.Text = "Ngày 28";
        this.xrTableCell34.Weight = 0.0822104353970344D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Text = "Ngày 29";
        this.xrTableCell25.Weight = 0.0822104353970344D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.Text = "Ngày 30";
        this.xrTableCell35.Weight = 0.0822104353970344D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Ngày 31";
        this.xrTableCell7.Weight = 0.0822104353970344D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Tổng";
        this.xrTableCell3.Weight = 0.13111628261181194D;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.GroupHeader1.HeightF = 32.29167F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1635F, 32.29167F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36,
            this.xrTableCell38});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.StylePriority.UseTextAlignment = false;
        this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell36.Weight = 0.060015295186174031D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.StylePriority.UseTextAlignment = false;
        this.xrTableCell38.Text = "Phòng ban";
        this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell38.Weight = 2.9399847048138255D;
        // 
        // rp_austfeed_KhoanSanXuat
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(9, 10, 100, 100);
        this.PageHeight = 1169;
        this.PageWidth = 1654;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
