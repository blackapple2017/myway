using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_DanhSachNhanVienDuocTangQuaTrungThu
/// </summary>
public class rp_DanhSachNhanVienDuocTangQuaTrungThu : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TitleBC;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_manhanvien;
    private XRTableCell xrt_hoten;
    private XRTableCell xrt_ngaysinh;
    private XRTableCell xrt_gioitinh;
    private XRTableCell xrt_congviec;
    private XRTableCell xrt_songuoi;
    private XRTableCell xrt_sotien;
    private XRTableCell xrt_diachi;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_phongban;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell af;
    private XRTableCell xrTableCell1;
    private XRTableCell dd3;
    private XRTableCell bgf;
    private XRTableCell bge;
    private XRTableCell gcv;
    private XRTableCell tsfaf;
    private XRTableCell xrTableCell3;
    private XRTableCell yuio;
    private XRTableCell xrTableCell2;
    private XRTableCell xrt_ghichu;
    private XRPictureBox xrLogo;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DanhSachNhanVienDuocTangQuaTrungThu()
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
        try
        {
            ReportController rpCtr = new ReportController();
            xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
            xrl_TenCongTy.Text = rpCtr.GetCompanyName(filter.SessionDepartment);
            // xrl_ngayBC.Text = "Từ ngày " + string.Format("{0:d}", filter.TuNgay) + " đến ngày " + string.Format("{0:d}", filter.DenNgay);
            xrtngayketxuat.Text = rpCtr.GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
            //Hiện tại đang lấy ra những cán bộ có con em tuổi < 15
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("GetNhanVienTrungThu", "@MaBoPhan", "@Gender", "@TinhTrang", "@MinSeniority", "@MaxSeniority", "@WhereClause", filter.SelectedDepartment, filter.Gender, filter.WorkingStatus, filter.MinSeniority, filter.MaxSeniority, filter.WhereClause);
            if (dt.Rows.Count > 0)
            {
                DataSource = dt;
                xrt_manhanvien.DataBindings.Add("Text", DataSource, "MA_CB");
                xrt_hoten.DataBindings.Add("Text", DataSource, "HO_TEN");
                xrt_gioitinh.DataBindings.Add("Text", DataSource, "TEN_GIOITINH");
                xrt_congviec.DataBindings.Add("Text", DataSource, "TEN_CONGVIEC");
                xrt_songuoi.DataBindings.Add("Text", DataSource, "SoNguoi");
                xrt_ghichu.DataBindings.Add("Text", DataSource, "GHI_CHU");
                xrt_ngaysinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");

                this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                new DevExpress.XtraReports.UI.GroupField("MA_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
                xrt_phongban.DataBindings.Add("Text", DataSource, "TEN_PHONG");
                xrt_sotien.Text = string.Format("{0:N0}", Convert.ToInt64("300000"));
            }
            if (!string.IsNullOrEmpty(filter.Title1))
            {
                xrl_footer1.Text = filter.Title1;
            }
            else
            {
                xrl_footer1.Text = rpCtr.GetTitleOfSignature(xrl_footer1.Text, filter.Title1);
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
        string resourceFileName = "rp_DanhSachNhanVienDuocTangQuaTrungThu.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_manhanvien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_gioitinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_congviec = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_songuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sotien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_diachi = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.af = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.dd3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.bgf = new DevExpress.XtraReports.UI.XRTableCell();
        this.bge = new DevExpress.XtraReports.UI.XRTableCell();
        this.gcv = new DevExpress.XtraReports.UI.XRTableCell();
        this.tsfaf = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.yuio = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(984.5418F, 25F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_manhanvien,
            this.xrt_hoten,
            this.xrt_ngaysinh,
            this.xrt_gioitinh,
            this.xrt_congviec,
            this.xrt_songuoi,
            this.xrt_sotien,
            this.xrt_ghichu,
            this.xrt_diachi});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrt_stt
        // 
        this.xrt_stt.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_stt.Name = "xrt_stt";
        this.xrt_stt.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_stt.StylePriority.UseFont = false;
        this.xrt_stt.StylePriority.UsePadding = false;
        this.xrt_stt.StylePriority.UseTextAlignment = false;
        this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_stt.Weight = 0.0934100593880148D;
        this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrt_manhanvien
        // 
        this.xrt_manhanvien.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_manhanvien.Name = "xrt_manhanvien";
        this.xrt_manhanvien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_manhanvien.StylePriority.UseFont = false;
        this.xrt_manhanvien.StylePriority.UsePadding = false;
        this.xrt_manhanvien.StylePriority.UseTextAlignment = false;
        this.xrt_manhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_manhanvien.Weight = 0.24681215800081377D;
        // 
        // xrt_hoten
        // 
        this.xrt_hoten.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_hoten.Name = "xrt_hoten";
        this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hoten.StylePriority.UseFont = false;
        this.xrt_hoten.StylePriority.UsePadding = false;
        this.xrt_hoten.StylePriority.UseTextAlignment = false;
        this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hoten.Weight = 0.33881024045387609D;
        // 
        // xrt_ngaysinh
        // 
        this.xrt_ngaysinh.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_ngaysinh.Name = "xrt_ngaysinh";
        this.xrt_ngaysinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_ngaysinh.StylePriority.UseFont = false;
        this.xrt_ngaysinh.StylePriority.UsePadding = false;
        this.xrt_ngaysinh.StylePriority.UseTextAlignment = false;
        this.xrt_ngaysinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_ngaysinh.Weight = 0.26271925903072774D;
        // 
        // xrt_gioitinh
        // 
        this.xrt_gioitinh.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_gioitinh.Name = "xrt_gioitinh";
        this.xrt_gioitinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_gioitinh.StylePriority.UseFont = false;
        this.xrt_gioitinh.StylePriority.UsePadding = false;
        this.xrt_gioitinh.StylePriority.UseTextAlignment = false;
        this.xrt_gioitinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_gioitinh.Weight = 0.18293364980111215D;
        // 
        // xrt_congviec
        // 
        this.xrt_congviec.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_congviec.Name = "xrt_congviec";
        this.xrt_congviec.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_congviec.StylePriority.UseFont = false;
        this.xrt_congviec.StylePriority.UsePadding = false;
        this.xrt_congviec.StylePriority.UseTextAlignment = false;
        this.xrt_congviec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_congviec.Weight = 0.32717708702034654D;
        // 
        // xrt_songuoi
        // 
        this.xrt_songuoi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_songuoi.Name = "xrt_songuoi";
        this.xrt_songuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_songuoi.StylePriority.UseFont = false;
        this.xrt_songuoi.StylePriority.UsePadding = false;
        this.xrt_songuoi.StylePriority.UseTextAlignment = false;
        this.xrt_songuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_songuoi.Weight = 0.22177024471855933D;
        // 
        // xrt_sotien
        // 
        this.xrt_sotien.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_sotien.Name = "xrt_sotien";
        this.xrt_sotien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_sotien.StylePriority.UseFont = false;
        this.xrt_sotien.StylePriority.UsePadding = false;
        this.xrt_sotien.StylePriority.UseTextAlignment = false;
        this.xrt_sotien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_sotien.Weight = 0.22078264572340275D;
        // 
        // xrt_ghichu
        // 
        this.xrt_ghichu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_ghichu.Name = "xrt_ghichu";
        this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_ghichu.StylePriority.UseFont = false;
        this.xrt_ghichu.StylePriority.UsePadding = false;
        this.xrt_ghichu.StylePriority.UseTextAlignment = false;
        this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_ghichu.Weight = 0.38295393178708775D;
        // 
        // xrt_diachi
        // 
        this.xrt_diachi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_diachi.Name = "xrt_diachi";
        this.xrt_diachi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_diachi.StylePriority.UseFont = false;
        this.xrt_diachi.StylePriority.UsePadding = false;
        this.xrt_diachi.StylePriority.UseTextAlignment = false;
        this.xrt_diachi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_diachi.Weight = 0.31173149570966419D;
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
        this.BottomMargin.HeightF = 63F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLogo,
            this.xrl_TenCongTy,
            this.xrl_TitleBC});
        this.ReportHeader.HeightF = 210F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 117.5F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(494.1363F, 32.29166F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UsePadding = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 170F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(985.9999F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "DANH SÁCH CÁN BỘ CÓ CON EM NHẬN QUÀ TRUNG THU";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.PageHeader.HeightF = 25F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(984.5419F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.af,
            this.xrTableCell1,
            this.dd3,
            this.bgf,
            this.bge,
            this.gcv,
            this.tsfaf,
            this.xrTableCell3,
            this.xrTableCell2,
            this.yuio});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // af
        // 
        this.af.Name = "af";
        this.af.StylePriority.UseTextAlignment = false;
        this.af.Text = "STT";
        this.af.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.af.Weight = 0.0934100576898129D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "Mã nhân viên";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.2468121580008113D;
        // 
        // dd3
        // 
        this.dd3.Name = "dd3";
        this.dd3.StylePriority.UseTextAlignment = false;
        this.dd3.Text = "Họ tên";
        this.dd3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dd3.Weight = 0.33881027990142631D;
        // 
        // bgf
        // 
        this.bgf.Name = "bgf";
        this.bgf.StylePriority.UseTextAlignment = false;
        this.bgf.Text = "Ngày Sinh";
        this.bgf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.bgf.Weight = 0.262719197821564D;
        // 
        // bge
        // 
        this.bge.Name = "bge";
        this.bge.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.bge.StylePriority.UsePadding = false;
        this.bge.StylePriority.UseTextAlignment = false;
        this.bge.Text = "Giới tính";
        this.bge.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.bge.Weight = 0.18293364912182666D;
        // 
        // gcv
        // 
        this.gcv.Name = "gcv";
        this.gcv.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.gcv.StylePriority.UsePadding = false;
        this.gcv.StylePriority.UseTextAlignment = false;
        this.gcv.Text = "Vị trí công việc";
        this.gcv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.gcv.Weight = 0.32717718954508479D;
        // 
        // tsfaf
        // 
        this.tsfaf.Name = "tsfaf";
        this.tsfaf.StylePriority.UseTextAlignment = false;
        this.tsfaf.Text = "Số người con";
        this.tsfaf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.tsfaf.Weight = 0.22177040549013008D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Mức quà";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 0.22078250034225541D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Loại hợp đồng";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.38295400748721103D;
        // 
        // yuio
        // 
        this.yuio.Name = "yuio";
        this.yuio.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.yuio.StylePriority.UsePadding = false;
        this.yuio.StylePriority.UseTextAlignment = false;
        this.yuio.Text = "Ký nhận";
        this.yuio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.yuio.Weight = 0.31173164724812874D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrl_ten1,
            this.xrtngayketxuat,
            this.xrl_footer1,
            this.xrl_footer3});
        this.ReportFooter.HeightF = 208F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(682.5013F, 151.0417F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(302.4174F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(21.83889F, 151.0417F);
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
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(682.5013F, 26.04167F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(303.4987F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(21.83889F, 51.04167F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "PHÒNG HCNS";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(682.5013F, 51.04167F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(302.0406F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
        this.xrTable3.SizeF = new System.Drawing.SizeF(984.5418F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_phongban});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrt_phongban
        // 
        this.xrt_phongban.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrt_phongban.Name = "xrt_phongban";
        this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
        this.xrt_phongban.StylePriority.UseFont = false;
        this.xrt_phongban.StylePriority.UsePadding = false;
        this.xrt_phongban.StylePriority.UseTextAlignment = false;
        this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_phongban.Weight = 2.9999999999999996D;
        // 
        // xrLogo
        // 
        this.xrLogo.LocationFloat = new DevExpress.Utils.PointFloat(60.54167F, 0F);
        this.xrLogo.Name = "xrLogo";
        this.xrLogo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
        this.xrLogo.SizeF = new System.Drawing.SizeF(110F, 110F);
        this.xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        this.xrLogo.StylePriority.UsePadding = false;
        // 
        // rp_DanhSachNhanVienDuocTangQuaTrungThu
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
        this.Margins = new System.Drawing.Printing.Margins(86, 94, 49, 63);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
