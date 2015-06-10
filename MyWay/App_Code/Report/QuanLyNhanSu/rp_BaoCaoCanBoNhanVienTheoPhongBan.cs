using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoCanBoNhanVienTheoPhongBan
/// </summary>
public class rp_BaoCaoCanBoNhanVienTheoPhongBan : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrl_ThangBaoCao;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell15;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell16;
    private XRTableCell xrl_tenphongban;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrtmanhanvien;
    private XRTableCell xrttencbcnv;
    private XRTableCell xrt_ngaysinh;
    private XRTableCell xrtgioitinh;
    private XRTableCell xrtTonGiao;
    private XRTableCell xrtSoCMND;
    private XRTableCell xrtTrinhDo;
    private XRTableCell xrtdienthoai;
    private XRTableCell xrtDiaChiLH;
    private XRTableCell xrtNgayVao;
    private XRTableCell xrtChucDanh;
    private XRTableCell xrtNgayHuongLuong;
    private XRPictureBox xrLogo;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BaoCaoCanBoNhanVienTheoPhongBan()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        // 
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrtstt.Text = STT.ToString();
        STT++;
    }

    public void BindData(ReportFilter filter)
    {
        try
        {
            ReportController rpCtr = new ReportController();
            xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
            xrl_ThangBaoCao.Text = "Ngày báo cáo: " + filter.ReportedDate.ToString().Replace(" 12:00:00 SA", "");
            xrtngayketxuat.Text = new ReportController().GetFooterReport(filter.SessionDepartment, DateTime.Now);
            xrl_TenCongTy.Text = rpCtr.GetCompanyName(filter.SessionDepartment);
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_CanBoByPhongBan", "@MaBoPhan", "@Gender", "@TinhTrang", "@MinSeniority", "@MaxSeniority", "@WhereClause", filter.SelectedDepartment, filter.Gender, filter.WorkingStatus, filter.MinSeniority, filter.MaxSeniority, filter.WhereClause);
            DataSource = table;
            xrtmanhanvien.DataBindings.Add("Text", DataSource, "MA_CB");
            xrttencbcnv.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrt_ngaysinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
            xrtgioitinh.DataBindings.Add("Text", DataSource, "TEN_GIOITINH");
            xrtDiaChiLH.DataBindings.Add("Text", DataSource, "DIA_CHI_LH");
            xrtdienthoai.DataBindings.Add("Text", DataSource, "DI_DONG");
            xrtNgayVao.DataBindings.Add("Text", DataSource, "NGAY_TUYEN_CHINHTHUC", "{0:dd/MM/yyyy}");
            xrtNgayHuongLuong.DataBindings.Add("Text", DataSource, "NgayHuongLuong", "{0:dd/MM/yyyy}");
            xrtChucDanh.DataBindings.Add("Text", DataSource, "TEN_CONGVIEC");
            xrtTonGiao.DataBindings.Add("Text", DataSource, "TEN_TONGIAO");
            xrtTrinhDo.DataBindings.Add("Text", DataSource, "TEN_TRINHDO");
            xrtSoCMND.DataBindings.Add("Text", DataSource, "SO_CMND");
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MA_PHONG", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            xrl_tenphongban.DataBindings.Add("Text", DataSource, "TEN_PHONG");
            //
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
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
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
        string resourceFileName = "rp_BaoCaoCanBoNhanVienTheoPhongBan.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtmanhanvien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrttencbcnv = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtgioitinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtTonGiao = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtSoCMND = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtTrinhDo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtdienthoai = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtDiaChiLH = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtNgayVao = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtChucDanh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtNgayHuongLuong = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_ThangBaoCao = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_tenphongban = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 25.41666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1154F, 25.41666F);
        this.xrTable2.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtmanhanvien,
            this.xrttencbcnv,
            this.xrt_ngaysinh,
            this.xrtgioitinh,
            this.xrtTonGiao,
            this.xrtSoCMND,
            this.xrtTrinhDo,
            this.xrtdienthoai,
            this.xrtDiaChiLH,
            this.xrtNgayVao,
            this.xrtChucDanh,
            this.xrtNgayHuongLuong});
        this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseFont = false;
        this.xrTableRow2.StylePriority.UseTextAlignment = false;
        this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow2.Weight = 1D;
        // 
        // xrtstt
        // 
        this.xrtstt.Name = "xrtstt";
        this.xrtstt.StylePriority.UseTextAlignment = false;
        this.xrtstt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtstt.Weight = 0.36394242884472094D;
        // 
        // xrtmanhanvien
        // 
        this.xrtmanhanvien.Name = "xrtmanhanvien";
        this.xrtmanhanvien.StylePriority.UseTextAlignment = false;
        this.xrtmanhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtmanhanvien.Weight = 0.61313919274441209D;
        // 
        // xrttencbcnv
        // 
        this.xrttencbcnv.Name = "xrttencbcnv";
        this.xrttencbcnv.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrttencbcnv.StylePriority.UsePadding = false;
        this.xrttencbcnv.StylePriority.UseTextAlignment = false;
        this.xrttencbcnv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrttencbcnv.Weight = 1.1783647192750513D;
        // 
        // xrt_ngaysinh
        // 
        this.xrt_ngaysinh.Name = "xrt_ngaysinh";
        this.xrt_ngaysinh.StylePriority.UseTextAlignment = false;
        this.xrt_ngaysinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_ngaysinh.Weight = 0.785896096722414D;
        // 
        // xrtgioitinh
        // 
        this.xrtgioitinh.Name = "xrtgioitinh";
        this.xrtgioitinh.StylePriority.UseTextAlignment = false;
        this.xrtgioitinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtgioitinh.Weight = 0.45685013594112955D;
        // 
        // xrtTonGiao
        // 
        this.xrtTonGiao.Name = "xrtTonGiao";
        this.xrtTonGiao.StylePriority.UseTextAlignment = false;
        this.xrtTonGiao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtTonGiao.Weight = 0.73009688119321514D;
        // 
        // xrtSoCMND
        // 
        this.xrtSoCMND.Name = "xrtSoCMND";
        this.xrtSoCMND.StylePriority.UseTextAlignment = false;
        this.xrtSoCMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtSoCMND.Weight = 0.79029529798191367D;
        // 
        // xrtTrinhDo
        // 
        this.xrtTrinhDo.Name = "xrtTrinhDo";
        this.xrtTrinhDo.StylePriority.UseTextAlignment = false;
        this.xrtTrinhDo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtTrinhDo.Weight = 0.72186461037067473D;
        // 
        // xrtdienthoai
        // 
        this.xrtdienthoai.Name = "xrtdienthoai";
        this.xrtdienthoai.StylePriority.UseTextAlignment = false;
        this.xrtdienthoai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtdienthoai.Weight = 0.83165362152297984D;
        // 
        // xrtDiaChiLH
        // 
        this.xrtDiaChiLH.Name = "xrtDiaChiLH";
        this.xrtDiaChiLH.StylePriority.UseTextAlignment = false;
        this.xrtDiaChiLH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtDiaChiLH.Weight = 1.819900579742695D;
        // 
        // xrtNgayVao
        // 
        this.xrtNgayVao.Name = "xrtNgayVao";
        this.xrtNgayVao.StylePriority.UseTextAlignment = false;
        this.xrtNgayVao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtNgayVao.Weight = 0.84347333131736879D;
        // 
        // xrtChucDanh
        // 
        this.xrtChucDanh.Name = "xrtChucDanh";
        this.xrtChucDanh.StylePriority.UseTextAlignment = false;
        this.xrtChucDanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrtChucDanh.Weight = 0.79588977042618581D;
        // 
        // xrtNgayHuongLuong
        // 
        this.xrtNgayHuongLuong.Name = "xrtNgayHuongLuong";
        this.xrtNgayHuongLuong.StylePriority.UseTextAlignment = false;
        this.xrtNgayHuongLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtNgayHuongLuong.Weight = 0.89862792229638244D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 45F;
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
            this.xrl_ThangBaoCao,
            this.xrl_TitleBC,
            this.xrl_TenCongTy});
        this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.ReportHeader.HeightF = 229F;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.StylePriority.UseFont = false;
        // 
        // xrl_ThangBaoCao
        // 
        this.xrl_ThangBaoCao.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_ThangBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 196F);
        this.xrl_ThangBaoCao.Name = "xrl_ThangBaoCao";
        this.xrl_ThangBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ThangBaoCao.SizeF = new System.Drawing.SizeF(1154F, 23F);
        this.xrl_ThangBaoCao.StylePriority.UseFont = false;
        this.xrl_ThangBaoCao.StylePriority.UseTextAlignment = false;
        this.xrl_ThangBaoCao.Text = "Ngày báo cáo:";
        this.xrl_ThangBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 171F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1154F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BÁO CÁO DANH SÁCH CÁN BỘ NHÂN VIÊN THEO PHÒNG BAN";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 121F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(484.7656F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UsePadding = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 38.33331F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1154F, 38.33331F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell3,
            this.xrTableCell5,
            this.xrTableCell9,
            this.xrTableCell11,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell10,
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
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.36394242884472094D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Mã CB";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.6131391927444122D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "Họ và tên";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 1.1783647192750513D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Ngày sinh";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 0.785896096722414D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "Giới tính";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 0.45685042058880471D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "Tôn giáo";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.73009687268122114D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "Số CMTND";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 0.7902952221260019D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = "Trình độ";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell6.Weight = 0.72186403331536053D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "Điện thoại";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.831654213098267D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "Địa chỉ liên hệ";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 1.8199003649429504D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "Ngày vào";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 0.84347275676606859D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Multiline = true;
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "Vị trí\r\ncông việc";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 0.7958903121195382D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.Text = "Ngày hưởng lương";
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell15.Weight = 0.89862795515433025D;
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
        this.ReportFooter.HeightF = 218F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0.9999911F, 148.9583F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(374.9998F, 148.9583F);
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
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(787.4998F, 148.9583F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(296.5F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(787.4998F, 23.95833F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(296.5F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(374.9998F, 48.95833F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "TRƯỞNG PHÒNG HCNS";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(787.4998F, 48.95833F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(296.5002F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 48.95833F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
        this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1154F, 25.41666F);
        this.xrTable3.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UsePadding = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrl_tenphongban});
        this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.StylePriority.UseFont = false;
        this.xrTableRow3.StylePriority.UseTextAlignment = false;
        this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.Weight = 0.099999969401147248D;
        // 
        // xrl_tenphongban
        // 
        this.xrl_tenphongban.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrl_tenphongban.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrl_tenphongban.Name = "xrl_tenphongban";
        this.xrl_tenphongban.StylePriority.UseBorders = false;
        this.xrl_tenphongban.StylePriority.UseFont = false;
        this.xrl_tenphongban.StylePriority.UseTextAlignment = false;
        this.xrl_tenphongban.Text = "Phòng ban";
        this.xrl_tenphongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrl_tenphongban.Weight = 11.439996499491206D;
        // 
        // xrLogo
        // 
        this.xrLogo.LocationFloat = new DevExpress.Utils.PointFloat(63.54167F, 0F);
        this.xrLogo.Name = "xrLogo";
        this.xrLogo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
        this.xrLogo.SizeF = new System.Drawing.SizeF(110F, 110F);
        this.xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        this.xrLogo.StylePriority.UsePadding = false;
        // 
        // rp_BaoCaoCanBoNhanVienTheoPhongBan
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
        this.Margins = new System.Drawing.Printing.Margins(7, 7, 45, 49);
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
