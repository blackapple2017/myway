using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraPrinting;
using DataController;
using System.Text;

/// <summary>
/// Summary description for rpwg_PhieuNhanSu
/// </summary>
public class rpwg_QuyetDinhThoiViec : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel8;
    private XRLine xrLine1;
    private XRLabel xrLabel7;
    private XRLabel xrLabel12;
    private XRRichText xrDieu1;
    private XRRichText xrRichText2;
    private XRRichText xrRichText3;
    private XRRichText xrRichText4;
    private XRLabel xrLabel3;
    private XRLine xrLine3;
    private XRRichText xrRichText7;
    private XRRichText xrRichText8;
    private XRRichText xrRichText9;
    private XRRichText xrRichText11;
    private XRRichText xrRichText13;
    private XRRichText xrRichText14;
    private XRLabel xrLDirector;
    private XRRichText xrRichText5;
    private XRRichText xrReportDate;
    private XRRichText xrRichText6;
    private XRLine xrLine2;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_QuyetDinhThoiViec()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here 
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
    public void BinData(string maCB)
    {
        ReportController rpController = new ReportController();
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("WG_QuyetDinhThoiViec", "@MaCB", maCB);
        string date = "";
        if (!string.IsNullOrEmpty(table.Rows[0]["NgayNghi"].ToString()))
        {
            date = table.Rows[0]["NgayNghi"].ToString().Remove(10);
        }
        xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{0}", table.Rows[0]["HO_TEN"].ToString());
        xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{1}", table.Rows[0]["TEN_CHUCVU"].ToString());
        //xrRichText1.Rtf = rpController.Convertstringtortf(xrRichText1.Rtf, "{0}", table.Rows[0]["TEN_DONVI"].ToString() + " " + table.Rows[0]["ChiNhanh"].ToString());
        xrRichText9.Rtf = rpController.Convertstringtortf(xrRichText9.Rtf, "{0}", table.Rows[0]["HO_TEN"].ToString());
        xrRichText9.Rtf = rpController.Convertstringtortf(xrRichText9.Rtf, "{1}", table.Rows[0]["TEN_CHUCVU"].ToString());
        xrDieu1.Rtf = rpController.Convertstringtortf(xrDieu1.Rtf, "{0}", table.Rows[0]["HO_TEN"].ToString());
        xrDieu1.Rtf = rpController.Convertstringtortf(xrDieu1.Rtf, "{1}", table.Rows[0]["TEN_DONVI"].ToString());
        xrDieu1.Rtf = rpController.Convertstringtortf(xrDieu1.Rtf, "{2}", table.Rows[0]["ChiNhanh"].ToString());
        xrDieu1.Rtf = rpController.Convertstringtortf(xrDieu1.Rtf, "{4}", date);
        xrDieu1.Rtf = rpController.Convertstringtortf(xrDieu1.Rtf, "{3}", table.Rows[0]["ThanhPho"].ToString());
        xrRichText2.Rtf = rpController.Convertstringtortf(xrRichText2.Rtf, "{0}", table.Rows[0]["HO_TEN"].ToString());
        xrRichText2.Rtf = rpController.Convertstringtortf(xrRichText2.Rtf, "{1}", date);
        xrRichText3.Rtf = rpController.Convertstringtortf(xrRichText3.Rtf, "{0}", table.Rows[0]["HO_TEN"].ToString());
        xrRichText3.Rtf = rpController.Convertstringtortf(xrRichText3.Rtf, "{1}", table.Rows[0]["ChiNhanh"].ToString());
        xrRichText3.Rtf = rpController.Convertstringtortf(xrRichText3.Rtf, "{2}", table.Rows[0]["TEN_CHUCVU"].ToString());
        //xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{0}", date);
        xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{0}", table.Rows[0]["SoQuyetDinh"].ToString());
        xrLDirector.Text = "";
        xrReportDate.Rtf = rpController.Convertstringtortf(xrReportDate.Rtf, "{0}", table.Rows[0]["ThanhPho"].ToString() + ", " + CommonUtil.GetInstance().GetDescriptionDay(false, DateTime.Now));
    } 

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        string resourceFileName = "rpwg_QuyetDinhThoiViec.resx";
        System.Resources.ResourceManager resources = global::Resources.rpwg_QuyetDinhThoiViec.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.xrRichText6 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrReportDate = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText5 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrLDirector = new DevExpress.XtraReports.UI.XRLabel();
        this.xrRichText14 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText13 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText11 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText9 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText8 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText7 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
        this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrDieu1 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrReportDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrDieu1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrRichText6,
            this.xrReportDate,
            this.xrRichText5,
            this.xrLDirector,
            this.xrRichText14,
            this.xrRichText13,
            this.xrRichText11,
            this.xrRichText9,
            this.xrRichText8,
            this.xrRichText7,
            this.xrLine3,
            this.xrRichText4,
            this.xrRichText3,
            this.xrRichText2,
            this.xrDieu1,
            this.xrLabel12,
            this.xrLabel7,
            this.xrLine1,
            this.xrLabel3,
            this.xrLabel8,
            this.xrLabel2,
            this.xrLabel1});
        this.Detail.HeightF = 933F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLine2
        // 
        this.xrLine2.ForeColor = System.Drawing.Color.Black;
        this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(245.8331F, 169.875F);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.SizeF = new System.Drawing.SizeF(133.9166F, 9.458328F);
        this.xrLine2.StylePriority.UseForeColor = false;
        // 
        // xrRichText6
        // 
        this.xrRichText6.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrRichText6.LocationFloat = new DevExpress.Utils.PointFloat(0.001462301F, 332.5417F);
        this.xrRichText6.Name = "xrRichText6";
        this.xrRichText6.SerializableRtfString = resources.GetString("xrRichText6.SerializableRtfString");
        this.xrRichText6.SizeF = new System.Drawing.SizeF(649.9985F, 28.20834F);
        this.xrRichText6.StylePriority.UseFont = false;
        // 
        // xrReportDate
        // 
        this.xrReportDate.LocationFloat = new DevExpress.Utils.PointFloat(271.3751F, 65.87505F);
        this.xrReportDate.Name = "xrReportDate";
        this.xrReportDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrReportDate.SerializableRtfString = resources.GetString("xrReportDate.SerializableRtfString");
        this.xrReportDate.SizeF = new System.Drawing.SizeF(378.6249F, 23F);
        this.xrReportDate.StylePriority.UsePadding = false;
        // 
        // xrRichText5
        // 
        this.xrRichText5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 131.5F);
        this.xrRichText5.Name = "xrRichText5";
        this.xrRichText5.SerializableRtfString = resources.GetString("xrRichText5.SerializableRtfString");
        this.xrRichText5.SizeF = new System.Drawing.SizeF(640F, 28.20839F);
        // 
        // xrLDirector
        // 
        this.xrLDirector.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrLDirector.ForeColor = System.Drawing.Color.Black;
        this.xrLDirector.LocationFloat = new DevExpress.Utils.PointFloat(421.8747F, 900F);
        this.xrLDirector.Name = "xrLDirector";
        this.xrLDirector.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLDirector.SizeF = new System.Drawing.SizeF(228.1253F, 23F);
        this.xrLDirector.StylePriority.UseFont = false;
        this.xrLDirector.StylePriority.UseForeColor = false;
        this.xrLDirector.StylePriority.UseTextAlignment = false;
        this.xrLDirector.Text = "Đỗ Đông Nam";
        this.xrLDirector.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrRichText14
        // 
        this.xrRichText14.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 804.0417F);
        this.xrRichText14.Name = "xrRichText14";
        this.xrRichText14.SerializableRtfString = resources.GetString("xrRichText14.SerializableRtfString");
        this.xrRichText14.SizeF = new System.Drawing.SizeF(153.7082F, 23F);
        // 
        // xrRichText13
        // 
        this.xrRichText13.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 840.5834F);
        this.xrRichText13.Name = "xrRichText13";
        this.xrRichText13.SerializableRtfString = resources.GetString("xrRichText13.SerializableRtfString");
        this.xrRichText13.SizeF = new System.Drawing.SizeF(153.7082F, 77.16669F);
        // 
        // xrRichText11
        // 
        this.xrRichText11.LocationFloat = new DevExpress.Utils.PointFloat(471.8751F, 840.5834F);
        this.xrRichText11.Name = "xrRichText11";
        this.xrRichText11.SerializableRtfString = resources.GetString("xrRichText11.SerializableRtfString");
        this.xrRichText11.SizeF = new System.Drawing.SizeF(156.2067F, 23F);
        // 
        // xrRichText9
        // 
        this.xrRichText9.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrRichText9.LocationFloat = new DevExpress.Utils.PointFloat(0.000222524F, 304.3334F);
        this.xrRichText9.Name = "xrRichText9";
        this.xrRichText9.SerializableRtfString = resources.GetString("xrRichText9.SerializableRtfString");
        this.xrRichText9.SizeF = new System.Drawing.SizeF(649.9998F, 28.20834F);
        this.xrRichText9.StylePriority.UseFont = false;
        // 
        // xrRichText8
        // 
        this.xrRichText8.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrRichText8.LocationFloat = new DevExpress.Utils.PointFloat(0.000222524F, 276.1251F);
        this.xrRichText8.Name = "xrRichText8";
        this.xrRichText8.SerializableRtfString = resources.GetString("xrRichText8.SerializableRtfString");
        this.xrRichText8.SizeF = new System.Drawing.SizeF(649.9998F, 28.20834F);
        this.xrRichText8.StylePriority.UseFont = false;
        // 
        // xrRichText7
        // 
        this.xrRichText7.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrRichText7.LocationFloat = new DevExpress.Utils.PointFloat(0.000222524F, 247.9167F);
        this.xrRichText7.Name = "xrRichText7";
        this.xrRichText7.SerializableRtfString = resources.GetString("xrRichText7.SerializableRtfString");
        this.xrRichText7.SizeF = new System.Drawing.SizeF(649.9998F, 28.20839F);
        this.xrRichText7.StylePriority.UseFont = false;
        // 
        // xrLine3
        // 
        this.xrLine3.ForeColor = System.Drawing.Color.Black;
        this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(48.95814F, 36.54172F);
        this.xrLine3.Name = "xrLine3";
        this.xrLine3.SizeF = new System.Drawing.SizeF(133.9166F, 9.458328F);
        this.xrLine3.StylePriority.UseForeColor = false;
        // 
        // xrRichText4
        // 
        this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(29.16667F, 65.87505F);
        this.xrRichText4.Name = "xrRichText4";
        this.xrRichText4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
        this.xrRichText4.SizeF = new System.Drawing.SizeF(203.7082F, 23F);
        this.xrRichText4.StylePriority.UsePadding = false;
        // 
        // xrRichText3
        // 
        this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(0.001462301F, 689.8849F);
        this.xrRichText3.Name = "xrRichText3";
        this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
        this.xrRichText3.SizeF = new System.Drawing.SizeF(649.9985F, 74.87677F);
        // 
        // xrRichText2
        // 
        this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(0.001478195F, 586.2949F);
        this.xrRichText2.Name = "xrRichText2";
        this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
        this.xrRichText2.SizeF = new System.Drawing.SizeF(649.9985F, 103.59F);
        // 
        // xrDieu1
        // 
        this.xrDieu1.LocationFloat = new DevExpress.Utils.PointFloat(0.0008106232F, 430.4583F);
        this.xrDieu1.Name = "xrDieu1";
        this.xrDieu1.SerializableRtfString = resources.GetString("xrDieu1.SerializableRtfString");
        this.xrDieu1.SizeF = new System.Drawing.SizeF(649.9992F, 155.8365F);
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.ForeColor = System.Drawing.Color.Black;
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0.0006834666F, 407.4583F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(649.9993F, 22.99997F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseForeColor = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "QUYẾT ĐỊNH:";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.ForeColor = System.Drawing.Color.Black;
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 210.5834F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(649.9999F, 25.08331F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseForeColor = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "TỔNG GIÁM ĐỐC CÔNG TY CỔ PHẦN AUSTFEED VIỆT NAM";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLine1
        // 
        this.xrLine1.ForeColor = System.Drawing.Color.Black;
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(385.4167F, 46.00007F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(183.9166F, 9.458328F);
        this.xrLine1.StylePriority.UseForeColor = false;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.ForeColor = System.Drawing.Color.Black;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 3.178914E-05F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(297.4167F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseForeColor = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "CÔNG TY CỔ PHẦN AUSTFEED VIỆT NAM";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.ForeColor = System.Drawing.Color.Black;
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 108.5F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(640F, 22.99998F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseForeColor = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "QUYẾT ĐỊNH";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.ForeColor = System.Drawing.Color.Black;
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(271.3751F, 23.00005F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(378.6249F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseForeColor = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Độc lập - Tự do - Hạnh phúc";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.ForeColor = System.Drawing.Color.Black;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(297.4167F, 3.178914E-05F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(352.5833F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseForeColor = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 43F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 34F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // rpwg_QuyetDinhThoiViec
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
        this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        this.Margins = new System.Drawing.Printing.Margins(93, 84, 43, 34);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrReportDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrDieu1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
