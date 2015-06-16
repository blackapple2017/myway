using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataController;

/// <summary>
/// Summary description for rpwg_BaoCaoDanhSachNhanVienNghiViec
/// </summary>
public class rpwg_BaoCaoDanhSachNhanVienNghiViec : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrReportTitle;
    private XRLabel xrCompanyName;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrSTT;
    private XRTableCell xrLyDoNghi;
    private XRTableCell xrNgayThoiViec;
    private XRTableCell xrFullName;
    private XRTableCell xrTinhTrangBanGiao;
    private XRTableCell xrTinhTrangBH;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_footer3;
    private XRLabel xrl_ten3;
    private XRLabel xrThoiGian;
    private XRTableCell xrTableCell10;
    private XRTableCell xrNgayVaoLV;
    private XRLabel xrl_ThoiGianBaoCao;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell9;
    private XRTableCell xrt_TenPhongBan;
    private XRTableCell xrTableCell2;
    private XRTableCell xrGhiChu;
    private XRTableCell xrTableCell7;
    private XRTableCell xrBoPhan;
    private XRLabel xrl_ten2;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer1;
    private XRLabel xrl_ten1;
    private XRPictureBox xrLogo;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_BaoCaoDanhSachNhanVienNghiViec()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrSTT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        ReportController rpCtr = new ReportController();
        xrCompanyName.Text = rpCtr.GetCompanyName(filter.SessionDepartment);
        xrThoiGian.Text = rpCtr.GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
        if (SoftCore.Util.GetInstance().IsDateNull(filter.StartDate))
        {
            filter.StartDate = new DateTime(1900, 1, 1);
        }
        if (SoftCore.Util.GetInstance().IsDateNull(filter.EndDate))
        {
            filter.EndDate = DateTime.Now;
        }
        //xrl_ThoiGianBaoCao.Text = string.Format(xrl_ThoiGianBaoCao.Text, CommonUtil.GetInstance().GetDateFormat(filter.StartDate.Value), CommonUtil.GetInstance().GetDateFormat(filter.EndDate.Value));
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrReportTitle.Text = filter.ReportTitle.ToUpper();
        } 
        
        DataSource = DataHandler.GetInstance().ExecuteDataTable("report_DanhSachThoiViec", "@startMonth", "@endMonth", "@year", "@maboPhan", filter.StartDate, filter.EndDate, filter.Year, filter.SelectedDepartment);
        xrl_ThoiGianBaoCao.Text = rpCtr.GetFromDateToDate(filter.StartDate,filter.EndDate);
        xrFullName.DataBindings.Add("Text", DataSource, "HO_TEN");
        //  xrDepartment.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        xrNgayVaoLV.DataBindings.Add("Text", DataSource, "NGAY_TUYEN_DTIEN", "{0:dd/MM/yyyy}");
        xrNgayThoiViec.DataBindings.Add("Text", DataSource, "NgayNghi", "{0:dd/MM/yyyy}");
        xrLyDoNghi.DataBindings.Add("Text", DataSource, "TEN_LYDO_NGHI");
        xrTinhTrangBanGiao.DataBindings.Add("Text", DataSource, "BanGiao");
        //xrQuyetDinhSo.DataBindings.Add("Text", DataSource, "SoQuyetDinh");
        xrTinhTrangBH.DataBindings.Add("Text", DataSource, "BaoHiem");
        xrBoPhan.DataBindings.Add("Text", DataSource, "TEN_DONVI");

        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TEN_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrt_TenPhongBan.DataBindings.Add("Text", DataSource, "TEN_DONVI");
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
            string resourceFileName = "rpwg_BaoCaoDanhSachNhanVienNghiViec.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrSTT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrFullName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrBoPhan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrNgayVaoLV = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrNgayThoiViec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLyDoNghi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTinhTrangBanGiao = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTinhTrangBH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrGhiChu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrReportTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCompanyName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ThoiGianBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrThoiGian = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TenPhongBan = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrTable2.SizeF = new System.Drawing.SizeF(1069F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrSTT,
            this.xrFullName,
            this.xrBoPhan,
            this.xrNgayVaoLV,
            this.xrNgayThoiViec,
            this.xrLyDoNghi,
            this.xrTinhTrangBanGiao,
            this.xrTinhTrangBH,
            this.xrGhiChu});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrSTT
            // 
            this.xrSTT.Name = "xrSTT";
            this.xrSTT.StylePriority.UseTextAlignment = false;
            this.xrSTT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrSTT.Weight = 0.11522952144080202D;
            this.xrSTT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrFullName
            // 
            this.xrFullName.Name = "xrFullName";
            this.xrFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrFullName.StylePriority.UsePadding = false;
            this.xrFullName.StylePriority.UseTextAlignment = false;
            this.xrFullName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrFullName.Weight = 0.420954146736592D;
            // 
            // xrBoPhan
            // 
            this.xrBoPhan.Name = "xrBoPhan";
            this.xrBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrBoPhan.StylePriority.UsePadding = false;
            this.xrBoPhan.StylePriority.UseTextAlignment = false;
            this.xrBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrBoPhan.Weight = 0.36482694432178042D;
            // 
            // xrNgayVaoLV
            // 
            this.xrNgayVaoLV.Name = "xrNgayVaoLV";
            this.xrNgayVaoLV.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrNgayVaoLV.StylePriority.UsePadding = false;
            this.xrNgayVaoLV.StylePriority.UseTextAlignment = false;
            this.xrNgayVaoLV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrNgayVaoLV.Weight = 0.23854069549109758D;
            // 
            // xrNgayThoiViec
            // 
            this.xrNgayThoiViec.Name = "xrNgayThoiViec";
            this.xrNgayThoiViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrNgayThoiViec.StylePriority.UsePadding = false;
            this.xrNgayThoiViec.StylePriority.UseTextAlignment = false;
            this.xrNgayThoiViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrNgayThoiViec.Weight = 0.23854069464400249D;
            // 
            // xrLyDoNghi
            // 
            this.xrLyDoNghi.Name = "xrLyDoNghi";
            this.xrLyDoNghi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrLyDoNghi.StylePriority.UsePadding = false;
            this.xrLyDoNghi.StylePriority.UseTextAlignment = false;
            this.xrLyDoNghi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLyDoNghi.Weight = 0.56516439693007425D;
            // 
            // xrTinhTrangBanGiao
            // 
            this.xrTinhTrangBanGiao.Name = "xrTinhTrangBanGiao";
            this.xrTinhTrangBanGiao.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTinhTrangBanGiao.StylePriority.UsePadding = false;
            this.xrTinhTrangBanGiao.StylePriority.UseTextAlignment = false;
            this.xrTinhTrangBanGiao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTinhTrangBanGiao.Weight = 0.36345596331268809D;
            // 
            // xrTinhTrangBH
            // 
            this.xrTinhTrangBH.Name = "xrTinhTrangBH";
            this.xrTinhTrangBH.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTinhTrangBH.StylePriority.UsePadding = false;
            this.xrTinhTrangBH.StylePriority.UseTextAlignment = false;
            this.xrTinhTrangBH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTinhTrangBH.Weight = 0.34664381856148158D;
            // 
            // xrGhiChu
            // 
            this.xrGhiChu.Name = "xrGhiChu";
            this.xrGhiChu.Weight = 0.34664381856148158D;
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
            this.BottomMargin.HeightF = 49F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLogo,
            this.xrReportTitle,
            this.xrCompanyName,
            this.xrl_ThoiGianBaoCao});
            this.ReportHeader.HeightF = 215F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLogo
            // 
            this.xrLogo.LocationFloat = new DevExpress.Utils.PointFloat(81.06012F, 0F);
            this.xrLogo.Name = "xrLogo";
            this.xrLogo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLogo.SizeF = new System.Drawing.SizeF(110F, 110F);
            this.xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrLogo.StylePriority.UsePadding = false;
            // 
            // xrReportTitle
            // 
            this.xrReportTitle.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrReportTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 157.2083F);
            this.xrReportTitle.Name = "xrReportTitle";
            this.xrReportTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrReportTitle.SizeF = new System.Drawing.SizeF(1069F, 23F);
            this.xrReportTitle.StylePriority.UseFont = false;
            this.xrReportTitle.StylePriority.UseTextAlignment = false;
            this.xrReportTitle.Text = "BÁO CÁO NGHỈ VIỆC/ THÔI VIỆC";
            this.xrReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrCompanyName
            // 
            this.xrCompanyName.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110F);
            this.xrCompanyName.Name = "xrCompanyName";
            this.xrCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCompanyName.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
            this.xrCompanyName.StylePriority.UseFont = false;
            this.xrCompanyName.StylePriority.UseTextAlignment = false;
            this.xrCompanyName.Text = "PHÒNG HÀNH CHÍNH NHÂN SỰ";
            this.xrCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ThoiGianBaoCao
            // 
            this.xrl_ThoiGianBaoCao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.xrl_ThoiGianBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 180.2083F);
            this.xrl_ThoiGianBaoCao.Name = "xrl_ThoiGianBaoCao";
            this.xrl_ThoiGianBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ThoiGianBaoCao.SizeF = new System.Drawing.SizeF(1069F, 23F);
            this.xrl_ThoiGianBaoCao.StylePriority.UseFont = false;
            this.xrl_ThoiGianBaoCao.StylePriority.UseTextAlignment = false;
            this.xrl_ThoiGianBaoCao.Text = "Từ ngày {0} đến ngày {1}";
            this.xrl_ThoiGianBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 47F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1069F, 47F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell4,
            this.xrTableCell7,
            this.xrTableCell10,
            this.xrTableCell5,
            this.xrTableCell3,
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.11522950116237446D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ và tên";
            this.xrTableCell4.Weight = 0.42095417986004874D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Bộ phận";
            this.xrTableCell7.Weight = 0.36482693729355831D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Ngày vào\r\nlàm việc";
            this.xrTableCell10.Weight = 0.23854068846287546D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Ngày\r\nnghỉ việc";
            this.xrTableCell5.Weight = 0.23854069710785947D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Lý do nghỉ";
            this.xrTableCell3.Weight = 0.565164222676739D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Tình trạng bàn giao";
            this.xrTableCell6.Weight = 0.36345596759148963D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Tình trạng \r\nBHXH/...";
            this.xrTableCell8.Weight = 0.34664390292252723D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Ghi chú";
            this.xrTableCell2.Weight = 0.34664390292252723D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_footer1,
            this.xrl_ten1,
            this.xrl_ten2,
            this.xrl_footer2,
            this.xrThoiGian,
            this.xrl_ten3,
            this.xrl_footer3});
            this.ReportFooter.HeightF = 164F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.74995F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.4167F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 139.9583F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(304.4167F, 22.99998F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(368.75F, 141F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(304.4166F, 23.00002F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(368.75F, 39.79161F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.4166F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrThoiGian
            // 
            this.xrThoiGian.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrThoiGian.LocationFloat = new DevExpress.Utils.PointFloat(713.5417F, 6.791687F);
            this.xrThoiGian.Name = "xrThoiGian";
            this.xrThoiGian.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrThoiGian.SizeF = new System.Drawing.SizeF(355.4583F, 23F);
            this.xrThoiGian.StylePriority.UseFont = false;
            this.xrThoiGian.StylePriority.UseTextAlignment = false;
            this.xrThoiGian.Text = "Hà Nội, ngày....";
            this.xrThoiGian.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(737.5F, 139.9583F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(304.4166F, 22.99998F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(737.5F, 38.74995F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(304.4166F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.xrTable3.SizeF = new System.Drawing.SizeF(1069F, 25.41666F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrt_TenPhongBan});
            this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseFont = false;
            this.xrTableRow3.StylePriority.UseTextAlignment = false;
            this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.Weight = 0.093749659522817774D;
            // 
            // xrt_TenPhongBan
            // 
            this.xrt_TenPhongBan.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_TenPhongBan.Name = "xrt_TenPhongBan";
            this.xrt_TenPhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_TenPhongBan.StylePriority.UseBorders = false;
            this.xrt_TenPhongBan.StylePriority.UsePadding = false;
            this.xrt_TenPhongBan.StylePriority.UseTextAlignment = false;
            this.xrt_TenPhongBan.Text = "Unit";
            this.xrt_TenPhongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_TenPhongBan.Weight = 10.73625507595513D;
            // 
            // rpwg_BaoCaoDanhSachNhanVienNghiViec
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(52, 48, 49, 49);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
