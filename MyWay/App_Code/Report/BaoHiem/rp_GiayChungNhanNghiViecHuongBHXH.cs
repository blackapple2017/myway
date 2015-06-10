using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_GiayChungNhanNghiViecHuongBHXH
/// </summary>
public class rp_GiayChungNhanNghiViecHuongBHXH : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrt_hoten1;
    private XRLabel xrt_ngaysinh1;
    private XRLabel xrt_donvi1;
    private XRLabel xrt_lydonghi1;
    private XRLabel xrt_songay1;
    private XRLabel xrt_tungay1;
    private XRLabel xrLabel11;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrt_lydonghi2;
    private XRLabel xrt_songay2;
    private XRLabel xrt_tungay2;
    private XRLabel xrt_hoten2;
    private XRLabel xrt_ngaysinh2;
    private XRLabel xrt_donvi2;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrt_ngaythang1;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrt_ngaythang2;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell2;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell3;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell4;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_GiayChungNhanNghiViecHuongBHXH()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    public void BinData(ReportFilter rp)
    {
        DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_MauInCheDo", "@IDChiTietCheDoBaoHiem", rp.WhereClause);
        if (!string.IsNullOrEmpty(dt.Rows[0]["HoTen"].ToString()))
        {
            xrt_hoten1.Text = "Họ và tên: " + dt.Rows[0]["HoTen"].ToString();
            xrt_hoten2.Text = "Họ và tên: " + dt.Rows[0]["HoTen"].ToString();
        }
        if (!string.IsNullOrEmpty(ReportController.GetInstance().GetCompanyName(rp.SessionDepartment)))
        {
            xrt_donvi1.Text = "Đơn vị công tác: " + ReportController.GetInstance().GetCompanyName(rp.SessionDepartment);
            xrt_donvi2.Text = "Đơn vị công tác: " + ReportController.GetInstance().GetCompanyName(rp.SessionDepartment);
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgaySinh"].ToString()))
        {
            string ngaysinh = "";
            ngaysinh = Convert.ToDateTime(dt.Rows[0]["NgaySinh"]).Day.ToString() + "/" + Convert.ToDateTime(dt.Rows[0]["NgaySinh"]).Month.ToString() + "/" + Convert.ToDateTime(dt.Rows[0]["NgaySinh"]).Year.ToString();
            xrt_ngaysinh1.Text = "Năm sinh " + ngaysinh;
            xrt_ngaysinh2.Text = "Năm sinh " + ngaysinh;
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["LyDoNghi"].ToString()))
        {
            xrt_lydonghi2.Text = "Lý do nghỉ việc: " + dt.Rows[0]["LyDoNghi"].ToString();
            xrt_lydonghi1.Text = "Lý do nghỉ việc: " + dt.Rows[0]["LyDoNghi"].ToString();
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["SoNgayNghi"].ToString()))
        {
            xrt_songay1.Text = "Số ngày cho nghỉ: " + dt.Rows[0]["SoNgayNghi"].ToString();
            xrt_songay2.Text = "Số ngày cho nghỉ: " + dt.Rows[0]["SoNgayNghi"].ToString();
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgayBatDau"].ToString()))
        {
            xrt_tungay2.Text = "(Từ ngày " + dt.Rows[0]["NgayBatDau"].ToString().Substring(0, 10) + "đến hết ngày............................................";
            xrt_tungay1.Text = "(Từ ngày " + dt.Rows[0]["NgayBatDau"].ToString().Substring(0, 10) + "đến hết ngày............................................";
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()))
        {
            xrt_tungay1.Text = "Từ ngày ...................................đến hết ngày " + dt.Rows[0]["NgayKetThuc"].ToString().Substring(0, 10);
            xrt_tungay2.Text = "Từ ngày ...................................đến hết ngày " + dt.Rows[0]["NgayKetThuc"].ToString().Substring(0, 10);
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgayBatDau"].ToString()) && (!string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString())))
        {
            xrt_tungay1.Text = "Từ ngày " + dt.Rows[0]["NgayBatDau"].ToString().Substring(0, 10) + " đến hết ngày " + dt.Rows[0]["NgayKetThuc"].ToString().Substring(0, 10);
            xrt_tungay2.Text = "Từ ngày " + dt.Rows[0]["NgayBatDau"].ToString().Substring(0, 10) + " đến hết ngày " + dt.Rows[0]["NgayKetThuc"].ToString().Substring(0, 10);
        }
        xrt_ngaythang1.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        xrt_ngaythang2.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        if (!string.IsNullOrEmpty(dt.Rows[0]["SoNgayNghi"].ToString()))
        {
            xrLabel30.Text = "Số ngày thực nghỉ " + dt.Rows[0]["SoNgayNghi"].ToString() + " ngày";
        }
        xrLabel1.Text = dt.Rows[0]["TEN_NOI_KCB"].ToString().ToUpper();
        xrLabel11.Text = dt.Rows[0]["TEN_NOI_KCB"].ToString().ToUpper();
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
        string resourceFileName = "rp_GiayChungNhanNghiViecHuongBHXH.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_lydonghi2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_songay2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_tungay2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_hoten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngaysinh2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_donvi2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_tungay1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_songay1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_lydonghi1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_donvi1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngaysinh1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_hoten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngaythang2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngaythang1 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrt_lydonghi2,
            this.xrt_songay2,
            this.xrt_tungay2,
            this.xrt_hoten2,
            this.xrt_ngaysinh2,
            this.xrt_donvi2,
            this.xrt_tungay1,
            this.xrt_songay1,
            this.xrt_lydonghi1,
            this.xrt_donvi1,
            this.xrt_ngaysinh1,
            this.xrt_hoten1});
        this.Detail.HeightF = 195F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(430.2084F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(14.58331F, 194.875F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Borders = DevExpress.XtraPrinting.BorderSide.Left;
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.StylePriority.UseBorders = false;
        this.xrTableRow3.Weight = 3.753819034436384D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Weight = 3D;
        // 
        // xrt_lydonghi2
        // 
        this.xrt_lydonghi2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_lydonghi2.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 75F);
        this.xrt_lydonghi2.Name = "xrt_lydonghi2";
        this.xrt_lydonghi2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_lydonghi2.SizeF = new System.Drawing.SizeF(555.4166F, 23F);
        this.xrt_lydonghi2.StylePriority.UseFont = false;
        this.xrt_lydonghi2.Text = "Lý do nghỉ việc: ................................................................" +
            "...............................................................";
        // 
        // xrt_songay2
        // 
        this.xrt_songay2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_songay2.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 112.5F);
        this.xrt_songay2.Name = "xrt_songay2";
        this.xrt_songay2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_songay2.SizeF = new System.Drawing.SizeF(555.4166F, 23F);
        this.xrt_songay2.StylePriority.UseFont = false;
        this.xrt_songay2.Text = "Số ngày cho nghỉ: ..............................................................." +
            "..........................................................";
        // 
        // xrt_tungay2
        // 
        this.xrt_tungay2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_tungay2.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 150F);
        this.xrt_tungay2.Name = "xrt_tungay2";
        this.xrt_tungay2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_tungay2.SizeF = new System.Drawing.SizeF(555.4166F, 23F);
        this.xrt_tungay2.StylePriority.UseFont = false;
        this.xrt_tungay2.Text = "(Từ ngày ...................................đến hết ngày........................." +
            "...................";
        // 
        // xrt_hoten2
        // 
        this.xrt_hoten2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_hoten2.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 0F);
        this.xrt_hoten2.Name = "xrt_hoten2";
        this.xrt_hoten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_hoten2.SizeF = new System.Drawing.SizeF(394.375F, 23F);
        this.xrt_hoten2.StylePriority.UseFont = false;
        this.xrt_hoten2.Text = "Họ và tên: ......................................................................" +
            ".......................";
        // 
        // xrt_ngaysinh2
        // 
        this.xrt_ngaysinh2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_ngaysinh2.LocationFloat = new DevExpress.Utils.PointFloat(865.2084F, 0F);
        this.xrt_ngaysinh2.Name = "xrt_ngaysinh2";
        this.xrt_ngaysinh2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngaysinh2.SizeF = new System.Drawing.SizeF(161.4583F, 23F);
        this.xrt_ngaysinh2.StylePriority.UseFont = false;
        this.xrt_ngaysinh2.Text = "năm sinh..............................";
        // 
        // xrt_donvi2
        // 
        this.xrt_donvi2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_donvi2.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 37.5F);
        this.xrt_donvi2.Name = "xrt_donvi2";
        this.xrt_donvi2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_donvi2.SizeF = new System.Drawing.SizeF(555.4166F, 23F);
        this.xrt_donvi2.StylePriority.UseFont = false;
        this.xrt_donvi2.Text = "Đơn vị công tác: ................................................................" +
            "..............................................................";
        // 
        // xrt_tungay1
        // 
        this.xrt_tungay1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_tungay1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 151.0417F);
        this.xrt_tungay1.Name = "xrt_tungay1";
        this.xrt_tungay1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_tungay1.SizeF = new System.Drawing.SizeF(410.625F, 23F);
        this.xrt_tungay1.StylePriority.UseFont = false;
        this.xrt_tungay1.Text = "(Từ ngày ...................................đến hết ngày........................." +
            "...................";
        // 
        // xrt_songay1
        // 
        this.xrt_songay1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_songay1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110.4167F);
        this.xrt_songay1.Name = "xrt_songay1";
        this.xrt_songay1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_songay1.SizeF = new System.Drawing.SizeF(410.625F, 23F);
        this.xrt_songay1.StylePriority.UseFont = false;
        this.xrt_songay1.Text = "Số ngày cho nghỉ: ..............................................................." +
            "......................";
        // 
        // xrt_lydonghi1
        // 
        this.xrt_lydonghi1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_lydonghi1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.91666F);
        this.xrt_lydonghi1.Name = "xrt_lydonghi1";
        this.xrt_lydonghi1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_lydonghi1.SizeF = new System.Drawing.SizeF(410.625F, 23F);
        this.xrt_lydonghi1.StylePriority.UseFont = false;
        this.xrt_lydonghi1.Text = "Lý do nghỉ việc: ................................................................" +
            ".........................";
        // 
        // xrt_donvi1
        // 
        this.xrt_donvi1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_donvi1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
        this.xrt_donvi1.Name = "xrt_donvi1";
        this.xrt_donvi1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_donvi1.SizeF = new System.Drawing.SizeF(410.625F, 23F);
        this.xrt_donvi1.StylePriority.UseFont = false;
        this.xrt_donvi1.Text = "Đơn vị công tác: ................................................................" +
            ".........................";
        // 
        // xrt_ngaysinh1
        // 
        this.xrt_ngaysinh1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_ngaysinh1.LocationFloat = new DevExpress.Utils.PointFloat(249.5833F, 0F);
        this.xrt_ngaysinh1.Name = "xrt_ngaysinh1";
        this.xrt_ngaysinh1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngaysinh1.SizeF = new System.Drawing.SizeF(161.0417F, 23F);
        this.xrt_ngaysinh1.StylePriority.UseFont = false;
        this.xrt_ngaysinh1.Text = "năm sinh..............................";
        // 
        // xrt_hoten1
        // 
        this.xrt_hoten1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_hoten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrt_hoten1.Name = "xrt_hoten1";
        this.xrt_hoten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_hoten1.SizeF = new System.Drawing.SizeF(249.5833F, 23F);
        this.xrt_hoten1.StylePriority.UseFont = false;
        this.xrt_hoten1.Text = "Họ và tên: ....................................................";
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
            this.xrLabel32,
            this.xrLabel31,
            this.xrTable2,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrTable1,
            this.xrLabel11,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.HeightF = 338F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel32
        // 
        this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(612.5F, 196.875F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(300F, 23F);
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = "NGHỈ VIỆC HƯỞNG BHXH";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel31
        // 
        this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(100F, 196.875F);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.SizeF = new System.Drawing.SizeF(300F, 23F);
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.StylePriority.UseTextAlignment = false;
        this.xrLabel31.Text = "NGHỈ VIỆC HƯỞNG BHXH";
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTable2
        // 
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(430.2083F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(14.58331F, 338F);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseBorders = false;
        this.xrTableRow2.Weight = 3.753819034436384D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Weight = 3D;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(444.7917F, 301F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.Text = "Số: ";
        // 
        // xrLabel21
        // 
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(444.7916F, 278F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(203.125F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.Text = "Quyển số: .......................................";
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(612.5F, 175F);
        this.xrLabel14.Multiline = true;
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(300F, 21.875F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "GIẤY CHỨNG NHẬN\r\n";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(761.4583F, 83.41669F);
        this.xrLabel13.Multiline = true;
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(352.5417F, 37.37497F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "(Ban hành theo QĐ số: 51/2007/QĐ-BTC\r\nngày 22/6/2007 của Bộ trưởng BTC)\r\n";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(761.4583F, 60.41667F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(352.5417F, 23F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Mẫu số: C65 - HD";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTable1
        // 
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(444.7917F, 83.41667F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(113.5417F, 31.25F);
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "SỐ KB/BA";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 3D;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(444.7917F, 60.41667F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(261.4583F, 23F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.Text = "TÊN CƠ SỞ Y TẾ";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 301F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.Text = "Số: ";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 278F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(203.125F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.Text = "Quyển số: .......................................";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(100F, 175F);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(300F, 21.875F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "GIẤY CHỨNG NHẬN\r\n";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60.41667F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(261.4583F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "TÊN CƠ SỞ Y TẾ";
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrLabel30,
            this.xrLabel29,
            this.xrt_ngaythang2,
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel25,
            this.xrLabel24,
            this.xrt_ngaythang1});
        this.ReportFooter.HeightF = 159F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(430.2084F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(14.58331F, 136.9583F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Borders = DevExpress.XtraPrinting.BorderSide.Left;
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.StylePriority.UseBorders = false;
        this.xrTableRow4.Weight = 3.2241449473713155D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Weight = 3D;
        // 
        // xrLabel30
        // 
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 23.00002F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(277.0834F, 23F);
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = "Số ngày thực nghỉ..................... ngày";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel29
        // 
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 0F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(277.0834F, 23F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = "XÁC NHẬN CỦA PHỤ TRÁCH ĐƠN VỊ";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrt_ngaythang2
        // 
        this.xrt_ngaythang2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrt_ngaythang2.LocationFloat = new DevExpress.Utils.PointFloat(875.8752F, 0F);
        this.xrt_ngaythang2.Name = "xrt_ngaythang2";
        this.xrt_ngaythang2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngaythang2.SizeF = new System.Drawing.SizeF(228.125F, 23F);
        this.xrt_ngaythang2.StylePriority.UseFont = false;
        this.xrt_ngaythang2.StylePriority.UseTextAlignment = false;
        this.xrt_ngaythang2.Text = "Ngày..........tháng............năm.................";
        this.xrt_ngaythang2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(875.8752F, 23.00002F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(228.1249F, 23F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "Y Bác Sĩ KCB";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(875.8752F, 48.00002F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(228.125F, 23F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "(Ký, họ tên, đóng dấu)";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(182.5F, 46.00003F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(228.125F, 23F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "(Ký, họ tên)";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(182.5F, 23.00002F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(228.1249F, 23F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "Y Bác Sĩ KCB";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrt_ngaythang1
        // 
        this.xrt_ngaythang1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrt_ngaythang1.LocationFloat = new DevExpress.Utils.PointFloat(182.5F, 0F);
        this.xrt_ngaythang1.Name = "xrt_ngaythang1";
        this.xrt_ngaythang1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngaythang1.SizeF = new System.Drawing.SizeF(228.125F, 23F);
        this.xrt_ngaythang1.StylePriority.UseFont = false;
        this.xrt_ngaythang1.StylePriority.UseTextAlignment = false;
        this.xrt_ngaythang1.Text = "Ngày..........tháng............năm.................";
        this.xrt_ngaythang1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // rp_GiayChungNhanNghiViecHuongBHXH
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(26, 29, 50, 100);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
