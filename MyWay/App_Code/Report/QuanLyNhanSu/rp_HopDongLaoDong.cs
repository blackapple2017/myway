using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataController;
using System.Data;

/// <summary>
/// Summary description for rp_HopDongLaoDong
/// </summary>
public class rp_HopDongLaoDong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrt_hoten;
    private XRLabel xrLabel22;
    private XRLabel xrt_quoctich;
    private XRLabel xrLabel23;
    private XRLabel xrt_ngaysinh;
    private XRLabel xrLabel26;
    private XRLabel xrt_quequan;
    private XRLabel xrLabel27;
    private XRLabel xrt_nghenghiep;
    private XRLabel xrLabel29;
    private XRLabel xrt_hokhauthuongtru;
    private XRLabel xrLabel31;
    private XRLabel xrt_socmnd;
    private XRLabel xrLabel33;
    private XRLabel xrt_ngaycap;
    private XRLabel xrLabel35;
    private XRLabel xrt_congancap;
    private XRLabel xrLabel37;
    private XRLabel xrt_choohientai;
    private XRLabel xrLabel39;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel xrLabel46;
    private XRLabel xrt_loaihopdong;
    private XRLabel xrt_tungay;
    private XRLabel xrLabel49;
    private XRLabel xrt_denngay;
    private XRLabel xrLabel51;
    private XRLabel xrt_donvi;
    private XRLabel xrLabel53;
    private XRLabel xrt_chucdanh;
    private XRLabel xrLabel55;
    private XRLabel xrt_chucvu;
    private XRLabel xrLabel57;
    private XRLabel xrt_congviec;
    private XRLabel xrLabel59;
    private XRLabel xrLabel60;
    private XRLabel xrLabel61;
    private XRLabel xrLabel62;
    private XRLabel xrLabel63;
    private XRLabel xrLabel64;
    private XRLabel xrLabel65;
    private XRLabel xrLabel66;
    private XRLabel xrLabel67;
    private XRLabel xrLabel68;
    private XRLabel xrLabel69;
    private XRLabel xrt_bacluong;
    private XRLabel xrt_hesoluong;
    private XRLabel xrLabel71;
    private XRLabel xrLabel73;
    private XRLabel xrLabel74;
    private XRLabel xrLabel75;
    private XRLabel xrLabel76;
    private XRLabel xrLabel77;
    private XRLabel xrt_theoqudinh;
    private XRLabel xrLabel79;
    private XRLabel xrLabel80;
    private XRLabel xrLabel81;
    private XRLabel xrLabel82;
    private XRLabel xrLabel83;
    private XRLabel xrLabel84;
    private XRLabel xrLabel85;
    private XRLabel xrLabel86;
    private XRLabel xrLabel87;
    private XRLabel xrLabel88;
    private XRLabel xrLabel89;
    private XRLabel xrLabel90;
    private XRLabel xrLabel91;
    private XRLabel xrLabel92;
    private XRLabel xrLabel93;
    private XRLabel xrLabel94;
    private XRLabel xrLabel95;
    private XRLabel xrLabel96;
    private XRLabel xrLabel97;
    private XRLabel xrLabel98;
    private XRLabel xrLabel99;
    private XRLabel xrLabel100;
    private XRLabel xrLabel101;
    private XRLabel xrLabel102;
    private XRLabel xrLabel103;
    private XRLabel xrLabel104;
    private XRLabel xrLabel105;
    private XRLabel xrLabel106;
    private XRLabel xrLabel107;
    private XRLabel xrltenxinghieplamtai;
    private XRLabel xrlNgayKetXuat;
    private XRLabel xrLabel110;
    private XRLabel xrLabel111;
    private XRLabel xrLabel113;
    private XRLabel xrLabel112;
    private XRLabel xrLabel114;
    private XRLine xrLine2;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel3;
    private XRLine xrLine1;
    private XRLabel xrl_tendonvi;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_HopDongLaoDong()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
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
    public void BindData(ReportFilter filter)
    {
        xrl_tendonvi.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        xrltenxinghieplamtai.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        xrlNgayKetXuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("GetHopDongLaoDong", "@IdPrekey", filter.EmployeeCode);
        DataSource = table;
        if (table.Rows.Count > 0)
        {
            xrt_hoten.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrt_quoctich.DataBindings.Add("Text", DataSource, "TEN_NUOC");
            if (!string.IsNullOrEmpty(table.Rows[0]["NGAY_SINH"].ToString()))
            {
                xrt_ngaysinh.Text = "Ngày " + Convert.ToDateTime(table.Rows[0]["NGAY_SINH"]).Day + " tháng " + Convert.ToDateTime(table.Rows[0]["NGAY_SINH"]).Month + " năm " + Convert.ToDateTime(table.Rows[0]["NGAY_SINH"]).Year;
            }
            xrt_quequan.DataBindings.Add("Text", DataSource, "NOI_SINH");
            xrt_nghenghiep.DataBindings.Add("Text", DataSource, "TEN_CONGVIEC");
            xrt_hokhauthuongtru.DataBindings.Add("Text", DataSource, "HO_KHAU");
            xrt_socmnd.DataBindings.Add("Text", DataSource, "SO_CMND");
            xrt_ngaycap.DataBindings.Add("Text", DataSource, "NGAYCAP_CMND", "{0:dd/MM/yyyy}");
            xrt_congancap.DataBindings.Add("Text", DataSource, "TEN_NOICAP_CMND");
            xrt_choohientai.DataBindings.Add("Text", DataSource, "DIA_CHI_LH");
            xrt_loaihopdong.DataBindings.Add("Text", DataSource, "TEN_LOAI_HDONG");
            if (!string.IsNullOrEmpty(table.Rows[0]["NGAY_HDONG"].ToString()))
            {
                xrt_tungay.Text = "Ngày " + Convert.ToDateTime(table.Rows[0]["NGAY_HDONG"]).Day + " tháng " + Convert.ToDateTime(table.Rows[0]["NGAY_HDONG"]).Month + " năm " + Convert.ToDateTime(table.Rows[0]["NGAY_HDONG"]).Year;
            }
            if (!string.IsNullOrEmpty(table.Rows[0]["NGAYKT_HDONG"].ToString()))
            {
                xrt_denngay.Text = "Ngày " + Convert.ToDateTime(table.Rows[0]["NGAYKT_HDONG"]).Day + " tháng " + Convert.ToDateTime(table.Rows[0]["NGAYKT_HDONG"]).Month + " năm " + Convert.ToDateTime(table.Rows[0]["NGAYKT_HDONG"]).Year;
            }
            xrt_donvi.DataBindings.Add("Text", DataSource, "TEN_BOPHAN");
            xrt_chucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
            xrt_bacluong.DataBindings.Add("Text", DataSource, "BacLuong");
            xrt_hesoluong.DataBindings.Add("Text", DataSource, "HeSoLuong");
            xrt_theoqudinh.Text = "Theo quy định của " + table.Rows[0]["TEN_BOPHAN"].ToString();
        }
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_HopDongLaoDong.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_HopDongLaoDong.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel106 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel105 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel104 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel103 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel102 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel101 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel100 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel99 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel98 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel95 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel94 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel93 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel92 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel91 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel90 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_theoqudinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_hesoluong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_bacluong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_congviec = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_chucdanh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_donvi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_denngay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tungay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_loaihopdong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_choohientai = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_congancap = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_ngaycap = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_socmnd = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_hokhauthuongtru = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_nghenghiep = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_quequan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_quoctich = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_hoten = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrl_tendonvi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel114 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel113 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel112 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel111 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel110 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNgayKetXuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrltenxinghieplamtai = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel107 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel106,
            this.xrLabel105,
            this.xrLabel104,
            this.xrLabel103,
            this.xrLabel102,
            this.xrLabel101,
            this.xrLabel100,
            this.xrLabel99,
            this.xrLabel98,
            this.xrLabel97,
            this.xrLabel96,
            this.xrLabel95,
            this.xrLabel94,
            this.xrLabel93,
            this.xrLabel92,
            this.xrLabel91,
            this.xrLabel90,
            this.xrLabel89,
            this.xrLabel88,
            this.xrLabel87,
            this.xrLabel86,
            this.xrLabel85,
            this.xrLabel84,
            this.xrLabel83,
            this.xrLabel82,
            this.xrLabel81,
            this.xrLabel80,
            this.xrLabel79,
            this.xrt_theoqudinh,
            this.xrLabel77,
            this.xrLabel76,
            this.xrLabel75,
            this.xrLabel74,
            this.xrLabel73,
            this.xrt_hesoluong,
            this.xrLabel71,
            this.xrt_bacluong,
            this.xrLabel69,
            this.xrLabel68,
            this.xrLabel67,
            this.xrLabel66,
            this.xrLabel65,
            this.xrLabel64,
            this.xrLabel63,
            this.xrLabel62,
            this.xrLabel61,
            this.xrLabel60,
            this.xrLabel59,
            this.xrt_congviec,
            this.xrLabel57,
            this.xrt_chucvu,
            this.xrLabel55,
            this.xrt_chucdanh,
            this.xrLabel53,
            this.xrt_donvi,
            this.xrLabel51,
            this.xrt_denngay,
            this.xrLabel49,
            this.xrt_tungay,
            this.xrt_loaihopdong,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLabel44,
            this.xrLabel43,
            this.xrLabel42,
            this.xrLabel41,
            this.xrLabel40,
            this.xrLabel39,
            this.xrt_choohientai,
            this.xrLabel37,
            this.xrt_congancap,
            this.xrLabel35,
            this.xrt_ngaycap,
            this.xrLabel33,
            this.xrt_socmnd,
            this.xrLabel31,
            this.xrt_hokhauthuongtru,
            this.xrLabel29,
            this.xrt_nghenghiep,
            this.xrLabel27,
            this.xrLabel26,
            this.xrt_quequan,
            this.xrt_ngaysinh,
            this.xrLabel23,
            this.xrLabel22,
            this.xrt_quoctich,
            this.xrt_hoten,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7});
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Detail.HeightF = 1311F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel106
            // 
            this.xrLabel106.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel106.LocationFloat = new DevExpress.Utils.PointFloat(21.45856F, 1244.875F);
            this.xrLabel106.Name = "xrLabel106";
            this.xrLabel106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel106.SizeF = new System.Drawing.SizeF(842.5414F, 60.49988F);
            this.xrLabel106.StylePriority.UseFont = false;
            this.xrLabel106.Text = resources.GetString("xrLabel106.Text");
            // 
            // xrLabel105
            // 
            this.xrLabel105.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel105.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 1204.167F);
            this.xrLabel105.Name = "xrLabel105";
            this.xrLabel105.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel105.SizeF = new System.Drawing.SizeF(842.5414F, 40.70825F);
            this.xrLabel105.StylePriority.UseFont = false;
            this.xrLabel105.Text = "- Những vấn đề về lao động không ghi trong hợp đồng lao động này thì áp dụng quy " +
    "định của thỏa ước lao động tập thể, trường hợp chưa có thỏa ước tập thể thì áp d" +
    "ụng quy định của pháp luật lao động .";
            // 
            // xrLabel104
            // 
            this.xrLabel104.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel104.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 1181.167F);
            this.xrLabel104.Name = "xrLabel104";
            this.xrLabel104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel104.SizeF = new System.Drawing.SizeF(807.7084F, 23F);
            this.xrLabel104.StylePriority.UseFont = false;
            this.xrLabel104.StylePriority.UseTextAlignment = false;
            this.xrLabel104.Text = "Điều 5: Điều khoản thi hành";
            this.xrLabel104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel103
            // 
            this.xrLabel103.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel103.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 1141.5F);
            this.xrLabel103.Name = "xrLabel103";
            this.xrLabel103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel103.SizeF = new System.Drawing.SizeF(842.5414F, 39.66675F);
            this.xrLabel103.StylePriority.UseFont = false;
            this.xrLabel103.Text = "- Tạm hoãn, chấm dứt hợp đồng lao động, kỷ luật người lao động theo quy định của " +
    "người lao động, thỏa ước lao động tập thể và nội quy của Xí Nghiệp.";
            // 
            // xrLabel102
            // 
            this.xrLabel102.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel102.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 1118.5F);
            this.xrLabel102.Name = "xrLabel102";
            this.xrLabel102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel102.SizeF = new System.Drawing.SizeF(724.3749F, 22.99994F);
            this.xrLabel102.StylePriority.UseFont = false;
            this.xrLabel102.Text = "- Điều hành người lao động hoàn thành công việc theo hợp đồng (Bố trí, điều chuyể" +
    "n, tạm ngừng việc....)";
            // 
            // xrLabel101
            // 
            this.xrLabel101.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel101.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 1095.5F);
            this.xrLabel101.Name = "xrLabel101";
            this.xrLabel101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel101.SizeF = new System.Drawing.SizeF(302.0831F, 23F);
            this.xrLabel101.StylePriority.UseFont = false;
            this.xrLabel101.Text = "2. Quyền hạn:";
            // 
            // xrLabel100
            // 
            this.xrLabel100.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel100.LocationFloat = new DevExpress.Utils.PointFloat(20.41677F, 1050.625F);
            this.xrLabel100.Name = "xrLabel100";
            this.xrLabel100.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel100.SizeF = new System.Drawing.SizeF(843.5833F, 44.875F);
            this.xrLabel100.StylePriority.UseFont = false;
            this.xrLabel100.Text = "- Thanh toán đầy đủ, đúng thời hạn các chế độ và quyền lợi cho người lao động  th" +
    "eo hợp đồng lao động, thỏa ước hợp đồng lao động tập thể( nếu có).";
            // 
            // xrLabel99
            // 
            this.xrLabel99.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel99.LocationFloat = new DevExpress.Utils.PointFloat(20.41672F, 1027.625F);
            this.xrLabel99.Name = "xrLabel99";
            this.xrLabel99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel99.SizeF = new System.Drawing.SizeF(724.3749F, 22.99994F);
            this.xrLabel99.StylePriority.UseFont = false;
            this.xrLabel99.Text = "- Bảo đảm việc làm và thực hiện đầy đủ những điều cam kết trong hợp đồng lao động" +
    ".";
            // 
            // xrLabel98
            // 
            this.xrLabel98.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel98.LocationFloat = new DevExpress.Utils.PointFloat(20.41672F, 1004.625F);
            this.xrLabel98.Name = "xrLabel98";
            this.xrLabel98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel98.SizeF = new System.Drawing.SizeF(302.0831F, 23F);
            this.xrLabel98.StylePriority.UseFont = false;
            this.xrLabel98.Text = "1. Nghĩa vụ: ";
            // 
            // xrLabel97
            // 
            this.xrLabel97.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(342.7084F, 958.6254F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(485.4166F, 23F);
            this.xrLabel97.StylePriority.UseFont = false;
            this.xrLabel97.Text = "Bồi thường thiệt hại do lỗi cá nhân gây nên.";
            // 
            // xrLabel96
            // 
            this.xrLabel96.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 958.6254F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.SizeF = new System.Drawing.SizeF(321.2499F, 23F);
            this.xrLabel96.StylePriority.UseFont = false;
            this.xrLabel96.Text = "- Bồi thường vi phạm kỷ luật và vật chất(13): ";
            // 
            // xrLabel95
            // 
            this.xrLabel95.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel95.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 935.6255F);
            this.xrLabel95.Name = "xrLabel95";
            this.xrLabel95.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel95.SizeF = new System.Drawing.SizeF(724.3749F, 22.99994F);
            this.xrLabel95.StylePriority.UseFont = false;
            this.xrLabel95.Text = "- Chấp hành lệnh điều hành sản xuất kinh doanh, nội quy kỷ luật lao động, an toàn" +
    " lao động.";
            // 
            // xrLabel94
            // 
            this.xrLabel94.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel94.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 912.6254F);
            this.xrLabel94.Name = "xrLabel94";
            this.xrLabel94.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel94.SizeF = new System.Drawing.SizeF(548.3333F, 23F);
            this.xrLabel94.StylePriority.UseFont = false;
            this.xrLabel94.Text = "- Hoàn thành những công việc đã cam kết trong hợp đồng lao động";
            // 
            // xrLabel93
            // 
            this.xrLabel93.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel93.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 889.6253F);
            this.xrLabel93.Name = "xrLabel93";
            this.xrLabel93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel93.SizeF = new System.Drawing.SizeF(302.0831F, 23F);
            this.xrLabel93.StylePriority.UseFont = false;
            this.xrLabel93.Text = "2. Nghĩa vụ: ";
            // 
            // xrLabel92
            // 
            this.xrLabel92.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel92.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 981.6254F);
            this.xrLabel92.Name = "xrLabel92";
            this.xrLabel92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel92.SizeF = new System.Drawing.SizeF(807.7084F, 23F);
            this.xrLabel92.StylePriority.UseFont = false;
            this.xrLabel92.StylePriority.UseTextAlignment = false;
            this.xrLabel92.Text = "Điều 4: Nghĩa vụ và quyền hạn của người sử dụng lao động";
            this.xrLabel92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel91
            // 
            this.xrLabel91.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel91.LocationFloat = new DevExpress.Utils.PointFloat(64.58334F, 848.9169F);
            this.xrLabel91.Name = "xrLabel91";
            this.xrLabel91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel91.SizeF = new System.Drawing.SizeF(809.4167F, 40.70837F);
            this.xrLabel91.StylePriority.UseFont = false;
            this.xrLabel91.Text = "+ Trong thời gian thực hiện hợp đồng lao động nếu người lao động nghỉ trước thời " +
    "hạn Xí Nghiệp sẽ không thanh toán các chế độ theo quy định. ";
            // 
            // xrLabel90
            // 
            this.xrLabel90.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel90.LocationFloat = new DevExpress.Utils.PointFloat(64.58334F, 825.9168F);
            this.xrLabel90.Name = "xrLabel90";
            this.xrLabel90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel90.SizeF = new System.Drawing.SizeF(547.4999F, 23F);
            this.xrLabel90.StylePriority.UseFont = false;
            this.xrLabel90.Text = "+ Nghiêm chỉnh chấp hành nội quy, quy chế của Xí Nghiệp.";
            // 
            // xrLabel89
            // 
            this.xrLabel89.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 802.9169F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(227.5F, 23F);
            this.xrLabel89.StylePriority.UseFont = false;
            this.xrLabel89.Text = "- Những thỏa thuận khác(12): ";
            // 
            // xrLabel88
            // 
            this.xrLabel88.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(181.25F, 779.9167F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(552.083F, 23F);
            this.xrLabel88.StylePriority.UseFont = false;
            this.xrLabel88.Text = "Theo quy định của xí nghiệp và Ban điều hành dự án Nội Bài - Nhật Tân";
            // 
            // xrLabel87
            // 
            this.xrLabel87.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 779.9169F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(160.8333F, 23F);
            this.xrLabel87.StylePriority.UseFont = false;
            this.xrLabel87.Text = "- Chế độ đào tạo(11): ";
            // 
            // xrLabel86
            // 
            this.xrLabel86.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(430.8333F, 756.9167F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(243.7498F, 23F);
            this.xrLabel86.StylePriority.UseFont = false;
            this.xrLabel86.Text = "Theo quy định của BHXHVN";
            // 
            // xrLabel85
            // 
            this.xrLabel85.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(21.45853F, 756.9168F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(409.3748F, 23F);
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.Text = "- Bảo hiểm xã hội, bảo hiểm y tế, bảo hiểm thất nghiệp(10): ";
            // 
            // xrLabel84
            // 
            this.xrLabel84.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(430.8333F, 733.9168F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(243.7498F, 23F);
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.Text = "Theo quy định của Nhà Nước.";
            // 
            // xrLabel83
            // 
            this.xrLabel83.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(21.45852F, 733.9167F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(409.3748F, 23F);
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.Text = "- Chế độ nghỉ ngơi(Nghỉ hàng tuần, phép, năm, lễ tết...):";
            // 
            // xrLabel82
            // 
            this.xrLabel82.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(265.2083F, 710.9168F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(234.1666F, 23F);
            this.xrLabel82.StylePriority.UseFont = false;
            this.xrLabel82.Text = "Theo quy định của Xí nghiệp.";
            // 
            // xrLabel81
            // 
            this.xrLabel81.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(21.45852F, 710.9168F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(243.7498F, 23F);
            this.xrLabel81.StylePriority.UseFont = false;
            this.xrLabel81.Text = "- Được trang bị bảo hộ lao động: ";
            // 
            // xrLabel80
            // 
            this.xrLabel80.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(181.25F, 687.9168F);
            this.xrLabel80.Name = "xrLabel80";
            this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel80.SizeF = new System.Drawing.SizeF(318.1248F, 23F);
            this.xrLabel80.StylePriority.UseFont = false;
            this.xrLabel80.Text = "Theo quy định của Nhà nước";
            // 
            // xrLabel79
            // 
            this.xrLabel79.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(21.45852F, 687.9168F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(159.7915F, 23F);
            this.xrLabel79.StylePriority.UseFont = false;
            this.xrLabel79.Text = "- Chế độ nâng lương: ";
            // 
            // xrt_theoqudinh
            // 
            this.xrt_theoqudinh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_theoqudinh.LocationFloat = new DevExpress.Utils.PointFloat(135.4167F, 664.9168F);
            this.xrt_theoqudinh.Name = "xrt_theoqudinh";
            this.xrt_theoqudinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_theoqudinh.SizeF = new System.Drawing.SizeF(556.2502F, 23F);
            this.xrt_theoqudinh.StylePriority.UseFont = false;
            this.xrt_theoqudinh.Text = "Theo quy định  của ";
            // 
            // xrLabel77
            // 
            this.xrLabel77.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(20.41672F, 664.9168F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(115F, 23F);
            this.xrLabel77.StylePriority.UseFont = false;
            this.xrLabel77.Text = "- Tiền thưởng: ";
            // 
            // xrLabel76
            // 
            this.xrLabel76.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(21.45852F, 641.9168F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(256.6666F, 23F);
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.Text = "- Được trả lương: Hàng tháng.";
            // 
            // xrLabel75
            // 
            this.xrLabel75.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(20.41672F, 618.9167F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(256.6666F, 23F);
            this.xrLabel75.StylePriority.UseFont = false;
            this.xrLabel75.Text = "- Phụ cấp(9): Theo quy định.";
            // 
            // xrLabel74
            // 
            this.xrLabel74.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(181.25F, 595.9167F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(453.3335F, 23F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.Text = "Lương thời gian, lương khoán, lương sản phẩm.";
            // 
            // xrLabel73
            // 
            this.xrLabel73.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(20.41672F, 595.9167F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(160.8333F, 23F);
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.Text = "- Hình thức trả lương:";
            // 
            // xrt_hesoluong
            // 
            this.xrt_hesoluong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_hesoluong.LocationFloat = new DevExpress.Utils.PointFloat(569.7917F, 572.9168F);
            this.xrt_hesoluong.Name = "xrt_hesoluong";
            this.xrt_hesoluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_hesoluong.SizeF = new System.Drawing.SizeF(64.79175F, 23F);
            this.xrt_hesoluong.StylePriority.UseFont = false;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(461.0418F, 572.9168F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(108.75F, 23F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.Text = "- Hệ số lương:";
            // 
            // xrt_bacluong
            // 
            this.xrt_bacluong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_bacluong.LocationFloat = new DevExpress.Utils.PointFloat(398.9583F, 572.9167F);
            this.xrt_bacluong.Name = "xrt_bacluong";
            this.xrt_bacluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_bacluong.SizeF = new System.Drawing.SizeF(49.58337F, 23F);
            this.xrt_bacluong.StylePriority.UseFont = false;
            // 
            // xrLabel69
            // 
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(302.0834F, 572.9167F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(96.87488F, 23F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.Text = "- Bậc lương:";
            // 
            // xrLabel68
            // 
            this.xrLabel68.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(20.4167F, 572.9167F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(281.6666F, 23F);
            this.xrLabel68.StylePriority.UseFont = false;
            this.xrLabel68.Text = "- Mức lương chính hoặc tiền công(8):";
            // 
            // xrLabel67
            // 
            this.xrLabel67.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(247.9167F, 549.9167F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(178.1249F, 23F);
            this.xrLabel67.StylePriority.UseFont = false;
            // 
            // xrLabel66
            // 
            this.xrLabel66.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 549.9167F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(227.5F, 23F);
            this.xrLabel66.StylePriority.UseFont = false;
            this.xrLabel66.Text = "- Phương tiện đi lại làm việc(7):";
            // 
            // xrLabel65
            // 
            this.xrLabel65.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(20.4167F, 526.9167F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(302.0831F, 23F);
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.Text = "1. Quyền lợi";
            // 
            // xrLabel64
            // 
            this.xrLabel64.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(21.45852F, 503.9167F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(807.7084F, 23F);
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.Text = "Điều 3:Nghĩa vụ và quyền lợi của người lao động";
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel63
            // 
            this.xrLabel63.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(323.5416F, 480.9168F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(288.5416F, 23F);
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.Text = "Theo yêu cầu thực tế của công việc";
            // 
            // xrLabel62
            // 
            this.xrLabel62.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(21.45845F, 480.9167F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(302.0831F, 23F);
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.Text = "- Được cấp phát những dụng cụ làm việc: ";
            // 
            // xrLabel61
            // 
            this.xrLabel61.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(199.5833F, 438.1251F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(629.5835F, 42.79166F);
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.Text = "8h/ngày (Do yêu cầu sản xuất có thể huy động làm thêm giờ và sẽ thông báo trước c" +
    "ho người lao động biết).";
            // 
            // xrLabel60
            // 
            this.xrLabel60.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(21.45845F, 438.1251F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(178.1249F, 23F);
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.Text = "- Thời giờ làm việc(6): ";
            // 
            // xrLabel59
            // 
            this.xrLabel59.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 415.1251F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(807.7084F, 23F);
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.Text = "Điều 2: Chế độ làm việc";
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_congviec
            // 
            this.xrt_congviec.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_congviec.LocationFloat = new DevExpress.Utils.PointFloat(199.5833F, 392.1251F);
            this.xrt_congviec.Name = "xrt_congviec";
            this.xrt_congviec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_congviec.SizeF = new System.Drawing.SizeF(340.625F, 23F);
            this.xrt_congviec.StylePriority.UseFont = false;
            this.xrt_congviec.Text = "Theo sự phân công của Giám đốc dự án";
            // 
            // xrLabel57
            // 
            this.xrLabel57.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(21.45844F, 392.1251F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(178.1249F, 23F);
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.Text = "- Công việc phải làm(5):";
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_chucvu.LocationFloat = new DevExpress.Utils.PointFloat(515.2083F, 369.1251F);
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_chucvu.SizeF = new System.Drawing.SizeF(167.2915F, 23F);
            this.xrt_chucvu.StylePriority.UseFont = false;
            // 
            // xrLabel55
            // 
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(347.9167F, 369.1251F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(167.2915F, 23F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.Text = "Chức vụ(nếu có): ";
            // 
            // xrt_chucdanh
            // 
            this.xrt_chucdanh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_chucdanh.LocationFloat = new DevExpress.Utils.PointFloat(199.5833F, 369.1251F);
            this.xrt_chucdanh.Name = "xrt_chucdanh";
            this.xrt_chucdanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_chucdanh.SizeF = new System.Drawing.SizeF(123.9583F, 23F);
            this.xrt_chucdanh.StylePriority.UseFont = false;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(21.45844F, 369.1251F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(178.1249F, 23F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.Text = "- Chức danh chuyên môn: ";
            // 
            // xrt_donvi
            // 
            this.xrt_donvi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_donvi.LocationFloat = new DevExpress.Utils.PointFloat(289.5833F, 346.1251F);
            this.xrt_donvi.Name = "xrt_donvi";
            this.xrt_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_donvi.SizeF = new System.Drawing.SizeF(538.5417F, 23F);
            this.xrt_donvi.StylePriority.UseFont = false;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 346.1251F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(269.1667F, 23F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.Text = "- Địa điểm làm việc(4):";
            // 
            // xrt_denngay
            // 
            this.xrt_denngay.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_denngay.LocationFloat = new DevExpress.Utils.PointFloat(515.2083F, 323.1251F);
            this.xrt_denngay.Name = "xrt_denngay";
            this.xrt_denngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_denngay.SizeF = new System.Drawing.SizeF(269.1666F, 23F);
            this.xrt_denngay.StylePriority.UseFont = false;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(478.75F, 323.1251F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(36.45822F, 23F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.Text = "đến";
            // 
            // xrt_tungay
            // 
            this.xrt_tungay.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_tungay.LocationFloat = new DevExpress.Utils.PointFloat(289.5833F, 323.1251F);
            this.xrt_tungay.Name = "xrt_tungay";
            this.xrt_tungay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tungay.SizeF = new System.Drawing.SizeF(189.1667F, 23F);
            this.xrt_tungay.StylePriority.UseFont = false;
            // 
            // xrt_loaihopdong
            // 
            this.xrt_loaihopdong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_loaihopdong.LocationFloat = new DevExpress.Utils.PointFloat(289.5833F, 300.1251F);
            this.xrt_loaihopdong.Name = "xrt_loaihopdong";
            this.xrt_loaihopdong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_loaihopdong.SizeF = new System.Drawing.SizeF(538.5417F, 23F);
            this.xrt_loaihopdong.StylePriority.UseFont = false;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(20.4167F, 323.1251F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(269.1666F, 23F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.Text = "- Từ ngày: ";
            // 
            // xrLabel45
            // 
            this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 300.1251F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(269.1667F, 23F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.Text = "- Loại hợp đồng lao đồng lao động(3):";
            // 
            // xrLabel44
            // 
            this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(21.45844F, 277.1251F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(807.7084F, 23F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "Điều 1: Thời hạn và công việc  hợp đồng";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(21.45835F, 254.1251F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(807.7084F, 23F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.Text = "Thỏa thuận ký kết hợp đồng lao động và cam kết  làm đúng những điều khoản sau đây" +
    ":";
            // 
            // xrLabel42
            // 
            this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 231.1251F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(197.3331F, 21.875F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.Text = "...........................................";
            // 
            // xrLabel41
            // 
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(566.6667F, 231.1251F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(89.58337F, 23F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.Text = "Tại";
            // 
            // xrLabel40
            // 
            this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(360F, 231.1251F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(98.95831F, 23F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.Text = "cấp ngày: ";
            // 
            // xrLabel39
            // 
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 231.1251F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.Text = "Sổ lao động(nếu có):";
            // 
            // xrt_choohientai
            // 
            this.xrt_choohientai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_choohientai.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 208.125F);
            this.xrt_choohientai.Name = "xrt_choohientai";
            this.xrt_choohientai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_choohientai.SizeF = new System.Drawing.SizeF(227.0833F, 23F);
            this.xrt_choohientai.StylePriority.UseFont = false;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(21.45835F, 208.125F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.Text = "Chỗ ở hiện tại:";
            // 
            // xrt_congancap
            // 
            this.xrt_congancap.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_congancap.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 185.125F);
            this.xrt_congancap.Name = "xrt_congancap";
            this.xrt_congancap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_congancap.SizeF = new System.Drawing.SizeF(197.3334F, 21.875F);
            this.xrt_congancap.StylePriority.UseFont = false;
            this.xrt_congancap.Text = "............................................";
            // 
            // xrLabel35
            // 
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(566.6667F, 184F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(89.58337F, 23F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.Text = "Tại";
            // 
            // xrt_ngaycap
            // 
            this.xrt_ngaycap.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_ngaycap.LocationFloat = new DevExpress.Utils.PointFloat(458.9583F, 185.125F);
            this.xrt_ngaycap.Name = "xrt_ngaycap";
            this.xrt_ngaycap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_ngaycap.SizeF = new System.Drawing.SizeF(98.95831F, 23F);
            this.xrt_ngaycap.StylePriority.UseFont = false;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(360F, 185.125F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(98.95831F, 23F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.Text = "cấp ngày: ";
            // 
            // xrt_socmnd
            // 
            this.xrt_socmnd.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_socmnd.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 185.125F);
            this.xrt_socmnd.Name = "xrt_socmnd";
            this.xrt_socmnd.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_socmnd.SizeF = new System.Drawing.SizeF(128.125F, 23F);
            this.xrt_socmnd.StylePriority.UseFont = false;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(21.45835F, 185.125F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.Text = "Số CMND: ";
            // 
            // xrt_hokhauthuongtru
            // 
            this.xrt_hokhauthuongtru.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_hokhauthuongtru.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 162.125F);
            this.xrt_hokhauthuongtru.Name = "xrt_hokhauthuongtru";
            this.xrt_hokhauthuongtru.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_hokhauthuongtru.SizeF = new System.Drawing.SizeF(227.0833F, 23F);
            this.xrt_hokhauthuongtru.StylePriority.UseFont = false;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(21.45834F, 162.125F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "Hộ khẩu thường trú:";
            // 
            // xrt_nghenghiep
            // 
            this.xrt_nghenghiep.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_nghenghiep.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 139.125F);
            this.xrt_nghenghiep.Name = "xrt_nghenghiep";
            this.xrt_nghenghiep.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_nghenghiep.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrt_nghenghiep.StylePriority.UseFont = false;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(21.45834F, 139.125F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.Text = "Nghề nghiệp(2): ";
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(566.6667F, 117.25F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(89.58337F, 23F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.Text = "Tại";
            // 
            // xrt_quequan
            // 
            this.xrt_quequan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_quequan.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 117.25F);
            this.xrt_quequan.Name = "xrt_quequan";
            this.xrt_quequan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_quequan.SizeF = new System.Drawing.SizeF(197.3332F, 21.875F);
            this.xrt_quequan.StylePriority.UseFont = false;
            this.xrt_quequan.Text = "............................................";
            // 
            // xrt_ngaysinh
            // 
            this.xrt_ngaysinh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_ngaysinh.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 116.125F);
            this.xrt_ngaysinh.Name = "xrt_ngaysinh";
            this.xrt_ngaysinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_ngaysinh.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrt_ngaysinh.StylePriority.UseFont = false;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(21.45834F, 116.125F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Sinh ngày: ";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(566.6667F, 93.12499F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(89.58337F, 23F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "Quốc tịch: ";
            // 
            // xrt_quoctich
            // 
            this.xrt_quoctich.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_quoctich.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 93.12499F);
            this.xrt_quoctich.Name = "xrt_quoctich";
            this.xrt_quoctich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_quoctich.SizeF = new System.Drawing.SizeF(162.5001F, 21.875F);
            this.xrt_quoctich.StylePriority.UseFont = false;
            // 
            // xrt_hoten
            // 
            this.xrt_hoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrt_hoten.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 93.12499F);
            this.xrt_hoten.Name = "xrt_hoten";
            this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_hoten.SizeF = new System.Drawing.SizeF(227.0833F, 23F);
            this.xrt_hoten.StylePriority.UseFont = false;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 93.12499F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Và một bên là Ông(Bà):";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 70.12501F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(632.1251F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "................................................................................." +
    "....................................................................";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(21.45834F, 70.12501F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(72.91667F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Địa chỉ: ";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(664.5831F, 46F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(164.5836F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "..................................";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(569.7917F, 46F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(89.58344F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "Điện thoại: ";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 47.12499F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(308.3333F, 23.00001F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "..................................................................";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 47.12499F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Đại diện cho (1)";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 24.12497F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(308.3333F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "..................................................................";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 24.12497F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Chức vụ:";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(659.375F, 1.124986F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(162.5001F, 21.875F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "....................................";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(569.7917F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(89.58337F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Quốc tịch: ";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(231.875F, 1.124986F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(308.3333F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "..................................................................";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(20.41667F, 1.124986F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(198.9583F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Chúng tôi, một  bên là Ông: ";
            // 
            // TopMargin
            // 
            this.TopMargin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.TopMargin.HeightF = 49F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseFont = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StylePriority.UseFont = false;
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel3,
            this.xrLine1,
            this.xrl_tendonvi,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.ReportHeader.HeightF = 236F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseFont = false;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(106.25F, 121.8334F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(170.8333F, 2F);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 143.625F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(302.0833F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Số: 559/XN-TCCB-LĐ-HC-AT";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 186.3333F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(874F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "HỢP ĐỒNG LAO ĐỘNG";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(418.1666F, 100.9167F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(445.8333F, 40.70834F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM\r\nĐộc Lập - Tự Do - Hạnh Phúc";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(557.2913F, 143.625F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(176.0417F, 2.083336F);
            // 
            // xrl_tendonvi
            // 
            this.xrl_tendonvi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_tendonvi.LocationFloat = new DevExpress.Utils.PointFloat(5.666605F, 100.9167F);
            this.xrl_tendonvi.Name = "xrl_tendonvi";
            this.xrl_tendonvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tendonvi.SizeF = new System.Drawing.SizeF(393.2917F, 20.91667F);
            this.xrl_tendonvi.StylePriority.UseFont = false;
            this.xrl_tendonvi.StylePriority.UseTextAlignment = false;
            this.xrl_tendonvi.Text = "XÍ NGHIỆP CẦU 18 - CIENCO1";
            this.xrl_tendonvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(259.3751F, 27F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(432.2918F, 48F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Ban hành theo thông tư số 2/2003/TT-BLĐTBXH\r\nngày 22/9/2003 của Bộ lao động - Thư" +
    "ơng binh và xã hội";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(298.9583F, 1.666689F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(348.9585F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "MẪU HỢP ĐỒNG LAO ĐỘNG ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.PageHeader.HeightF = 0F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel114,
            this.xrLabel113,
            this.xrLabel112,
            this.xrLabel111,
            this.xrLabel110,
            this.xrlNgayKetXuat,
            this.xrltenxinghieplamtai,
            this.xrLabel107});
            this.ReportFooter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.ReportFooter.HeightF = 229F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            // 
            // xrLabel114
            // 
            this.xrLabel114.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel114.LocationFloat = new DevExpress.Utils.PointFloat(528.3333F, 196F);
            this.xrLabel114.Name = "xrLabel114";
            this.xrLabel114.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel114.SizeF = new System.Drawing.SizeF(323.7917F, 23F);
            this.xrLabel114.StylePriority.UseFont = false;
            this.xrLabel114.StylePriority.UseTextAlignment = false;
            this.xrLabel114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel113
            // 
            this.xrLabel113.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel113.LocationFloat = new DevExpress.Utils.PointFloat(528.3334F, 67.79169F);
            this.xrLabel113.Name = "xrLabel113";
            this.xrLabel113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel113.SizeF = new System.Drawing.SizeF(323.7917F, 23F);
            this.xrLabel113.StylePriority.UseFont = false;
            this.xrLabel113.StylePriority.UseTextAlignment = false;
            this.xrLabel113.Text = "Giám Đốc";
            this.xrLabel113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel112
            // 
            this.xrLabel112.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel112.LocationFloat = new DevExpress.Utils.PointFloat(528.3334F, 45.83327F);
            this.xrLabel112.Multiline = true;
            this.xrLabel112.Name = "xrLabel112";
            this.xrLabel112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel112.SizeF = new System.Drawing.SizeF(323.7917F, 21.95833F);
            this.xrLabel112.StylePriority.UseFont = false;
            this.xrLabel112.StylePriority.UseTextAlignment = false;
            this.xrLabel112.Text = "Người sử dụng lao động";
            this.xrLabel112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel111
            // 
            this.xrLabel111.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel111.LocationFloat = new DevExpress.Utils.PointFloat(20.41677F, 67.79169F);
            this.xrLabel111.Name = "xrLabel111";
            this.xrLabel111.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel111.SizeF = new System.Drawing.SizeF(323.7917F, 23F);
            this.xrLabel111.StylePriority.UseFont = false;
            this.xrLabel111.StylePriority.UseTextAlignment = false;
            this.xrLabel111.Text = "(Ký ghi rõ họ tên)";
            this.xrLabel111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel110
            // 
            this.xrLabel110.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel110.LocationFloat = new DevExpress.Utils.PointFloat(18.91673F, 45.83333F);
            this.xrLabel110.Multiline = true;
            this.xrLabel110.Name = "xrLabel110";
            this.xrLabel110.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel110.SizeF = new System.Drawing.SizeF(323.7917F, 21.95833F);
            this.xrLabel110.StylePriority.UseFont = false;
            this.xrLabel110.StylePriority.UseTextAlignment = false;
            this.xrLabel110.Text = "Người lao động\r\n";
            this.xrLabel110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlNgayKetXuat
            // 
            this.xrlNgayKetXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrlNgayKetXuat.LocationFloat = new DevExpress.Utils.PointFloat(540.2083F, 0F);
            this.xrlNgayKetXuat.Name = "xrlNgayKetXuat";
            this.xrlNgayKetXuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNgayKetXuat.SizeF = new System.Drawing.SizeF(323.7917F, 23F);
            this.xrlNgayKetXuat.StylePriority.UseFont = false;
            this.xrlNgayKetXuat.StylePriority.UseTextAlignment = false;
            this.xrlNgayKetXuat.Text = "Ngày      tháng       năm ";
            this.xrlNgayKetXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrltenxinghieplamtai
            // 
            this.xrltenxinghieplamtai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrltenxinghieplamtai.LocationFloat = new DevExpress.Utils.PointFloat(247.9167F, 0F);
            this.xrltenxinghieplamtai.Name = "xrltenxinghieplamtai";
            this.xrltenxinghieplamtai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrltenxinghieplamtai.SizeF = new System.Drawing.SizeF(292.2916F, 23F);
            this.xrltenxinghieplamtai.StylePriority.UseFont = false;
            this.xrltenxinghieplamtai.Text = "XÍ NGHIỆP CẦU 18 - CIENCO1";
            // 
            // xrLabel107
            // 
            this.xrLabel107.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel107.LocationFloat = new DevExpress.Utils.PointFloat(21.45856F, 0F);
            this.xrLabel107.Name = "xrLabel107";
            this.xrLabel107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel107.SizeF = new System.Drawing.SizeF(226.4581F, 23F);
            this.xrLabel107.StylePriority.UseFont = false;
            this.xrLabel107.Text = "Hợp đồng lao động này làm tại: ";
            // 
            // rp_HopDongLaoDong
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(109, 117, 49, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
