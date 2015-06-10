using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_DonDeNghiHuongTroCapThaiSan
/// </summary>
public class rp_DonDeNghiHuongTroCapThaiSan : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private ReportFooterBand ReportFooter;
    private XRLabel xrt_tenthanhpho;
    private XRLabel xrt_ngay1;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel23;
    private XRLabel xrLabel22;
    private XRLabel xrt_ngay2;
    private XRLabel xrLabel24;
    private XRLine xrLine1;
    private XRLabel xrt_hoten;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DonDeNghiHuongTroCapThaiSan()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    public void BinData(ReportFilter rp)
    {
        //string a = xrLabel5.Text.Replace("{1}","d");
        DataTable dt = new DataController.DataHandler().ExecuteDataTable("sp_MauInCheDo", "@IDChiTietCheDoBaoHiem", rp.WhereClause);


        if (!string.IsNullOrEmpty(dt.Rows[0]["SoDienThoai"].ToString()))
        {
           // xrt_sdt.Text = "Số điện thoại (nếu có): " + dt.Rows[0]["SoDienThoai"].ToString();
            xrt_hoten.Text = xrt_hoten.Text.Replace("{9}", dt.Rows[0]["SoDienThoai"].ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{9}", "...................................................................................");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["HoTen"].ToString()))
        {
          //  xrt_hoten.Text = "Họ và tên: " + dt.Rows[0]["HoTen"].ToString();
            xrt_hoten.Text = xrt_hoten.Text.Replace("{1}", dt.Rows[0]["HoTen"].ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{1}", " ................................................");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["SoSoBHXH"].ToString()))
        {
           // xrt_sosobhxh.Text = "Số sổ BHXH: " + dt.Rows[0]["SoSoBHXH"].ToString();
            xrt_hoten.Text = xrt_hoten.Text.Replace("{2}", dt.Rows[0]["SoSoBHXH"].ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{2}", "..........................,");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["SoCMTND"].ToString()))
        {
            //xrt_cmnd.Text = "Số CMND "+dt.Rows[0]["SoCMTND"].ToString();
            xrt_hoten.Text = xrt_hoten.Text.Replace("{3}", dt.Rows[0]["SoCMTND"].ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{3}","...................................");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NoiCapCMND"].ToString()))
        {
            //xrt_noicap.Text = "do " + dt.Rows[0]["NoiCapCMND"].ToString();
            xrt_hoten.Text = xrt_hoten.Text.Replace("{4}", dt.Rows[0]["NoiCapCMND"].ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{4}","...................");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["DiaChiLienHe"].ToString()))
        {
          //  xrt_diachilienhe.Text="Hiện tại cư trú tại: "+dt.Rows[0]["DiaChiLienHe"].ToString();
            xrt_hoten.Text = xrt_hoten.Text.Replace("{8}", dt.Rows[0]["NoiCapCMND"].ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{8}", "..........................................................................................");
        } 
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgayCapCMTND"].ToString()))
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{5}", Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"]).Day.ToString());
            xrt_hoten.Text = xrt_hoten.Text.Replace("{6}", Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"]).Month.ToString());
            xrt_hoten.Text = xrt_hoten.Text.Replace("{7}", Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"]).Year.ToString());
           // xrt_capngay.Text = Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"]).Day + " tháng " + Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"]).Month + " năm " + Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"]).Year;
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{5}", "..."); xrt_hoten.Text = xrt_hoten.Text.Replace("{6}", "..."); xrt_hoten.Text = xrt_hoten.Text.Replace("{7}", "....");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgayBatDau"].ToString()))
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{12}", Convert.ToDateTime(dt.Rows[0]["NgayBatDau"]).Month.ToString());
            xrt_hoten.Text = xrt_hoten.Text.Replace("{13}", Convert.ToDateTime(dt.Rows[0]["NgayBatDau"]).Year.ToString());
           // xrt_ngaybatdau.Text = "Nghỉ việc, không đóng BHXH từ tháng " + Convert.ToDateTime(dt.Rows[0]["NgayBatDau"]).Month + " năm " + Convert.ToDateTime(dt.Rows[0]["NgayBatDau"]).Year;
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{12}"," ... ");
            xrt_hoten.Text = xrt_hoten.Text.Replace("{13}", " ....");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()))
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{14}", Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Day.ToString());
            xrt_hoten.Text = xrt_hoten.Text.Replace("{15}", Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Month.ToString());
            xrt_hoten.Text = xrt_hoten.Text.Replace("{16}", Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Year.ToString());
            //xrt_ngayketthuc.Text = "Sinh con/Nhận nuôi con ngày " + Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Day + " tháng " + Convert.ToDateTime(dt.Rows[0]["NgayBatDau"]).Month + " năm " + Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Year;
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{14}"," ... ");
            xrt_hoten.Text = xrt_hoten.Text.Replace("{15}"," ... ");
            xrt_hoten.Text = xrt_hoten.Text.Replace("{16}", " .... ");
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["ThoiGianDongBaoHiem"].ToString()))
        {
            int nam = 0;
            int thang = 0;
            if (Convert.ToInt32(dt.Rows[0]["ThoiGianDongBaoHiem"])>12)
            {
                nam = nam+Convert.ToInt32(dt.Rows[0]["ThoiGianDongBaoHiem"]) / 12;
                thang =thang+ Convert.ToInt32(dt.Rows[0]["ThoiGianDongBaoHiem"]) % 12;
            }
            else
            {
                thang = Convert.ToInt32(dt.Rows[0]["ThoiGianDongBaoHiem"]);
            }
            xrt_hoten.Text = xrt_hoten.Text.Replace("{10}", nam.ToString());
            xrt_hoten.Text = xrt_hoten.Text.Replace("{11}", thang.ToString());
        }
        else
        {
            xrt_hoten.Text = xrt_hoten.Text.Replace("{10}","...");
            xrt_hoten.Text = xrt_hoten.Text.Replace("{11}", "....");
        }
        xrt_ngay1.Text = ".........., " + "ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        xrt_ngay2.Text = ".........., " + "ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
    }
	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
        string resourceFileName = "rp_DonDeNghiHuongTroCapThaiSan.resx";
        System.Resources.ResourceManager resources = global::Resources.rp_DonDeNghiHuongTroCapThaiSan.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrt_hoten = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_tenthanhpho = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngay2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngay1 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrt_hoten,
            this.xrt_tenthanhpho});
        this.Detail.HeightF = 375F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrt_hoten
        // 
        this.xrt_hoten.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_hoten.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 44.83334F);
        this.xrt_hoten.Multiline = true;
        this.xrt_hoten.Name = "xrt_hoten";
        this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hoten.SizeF = new System.Drawing.SizeF(694.9999F, 320.1667F);
        this.xrt_hoten.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hoten.StylePriority.UseFont = false;
        this.xrt_hoten.StylePriority.UsePadding = false;
        this.xrt_hoten.Text = resources.GetString("xrt_hoten.Text");
        this.xrt_hoten.WordWrap = false;
        // 
        // xrt_tenthanhpho
        // 
        this.xrt_tenthanhpho.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_tenthanhpho.LocationFloat = new DevExpress.Utils.PointFloat(51.04163F, 9.999974F);
        this.xrt_tenthanhpho.Name = "xrt_tenthanhpho";
        this.xrt_tenthanhpho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_tenthanhpho.SizeF = new System.Drawing.SizeF(653.9584F, 23F);
        this.xrt_tenthanhpho.StylePriority.UseFont = false;
        this.xrt_tenthanhpho.Text = "Kính gửi: Bảo hiểm xã hội huyện/ quận: .........................................." +
            "...................................................";
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
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel24,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.HeightF = 239F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLine1
        // 
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(282.9166F, 109.5F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(159.375F, 2F);
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 187.5416F);
        this.xrLabel24.Multiline = true;
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(705F, 17.79166F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UsePadding = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "HƯỞNG TRỢ CẤP THAI SẢN";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 157.25F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(705F, 19.87497F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UsePadding = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "ĐƠN ĐỀ NGHỊ \r\n";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 86.50001F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(705F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Độc lập - Tự do - Hạnh phúc ";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 63.49999F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(705F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(536.3751F, 10.00001F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(168.6249F, 28.58333F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Mẫu số 11B-HSB";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.HeightF = 0F;
        this.PageHeader.Name = "PageHeader";
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel23,
            this.xrLabel22,
            this.xrt_ngay2,
            this.xrLabel20,
            this.xrLabel19,
            this.xrt_ngay1});
        this.ReportFooter.HeightF = 213F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(399.1667F, 48.08337F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(305.8333F, 23F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "(Ký, ghi rõ họ tên)";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(399.1667F, 23.00002F);
        this.xrLabel22.Multiline = true;
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(305.8333F, 25.08333F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "Người làm đơn";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrt_ngay2
        // 
        this.xrt_ngay2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrt_ngay2.LocationFloat = new DevExpress.Utils.PointFloat(399.1667F, 0F);
        this.xrt_ngay2.Name = "xrt_ngay2";
        this.xrt_ngay2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngay2.SizeF = new System.Drawing.SizeF(305.8333F, 23F);
        this.xrt_ngay2.StylePriority.UseFont = false;
        this.xrt_ngay2.Text = "..............., ngày ....... tháng ....... năm .........";
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 65.7917F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(305.8333F, 23F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "(Ký, đóng dấu)";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel19
        // 
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
        this.xrLabel19.Multiline = true;
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(305.8333F, 42.79167F);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "Xác  nhận của chính quyền \r\nđịa phương nơi cư trú";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrt_ngay1
        // 
        this.xrt_ngay1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrt_ngay1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrt_ngay1.Name = "xrt_ngay1";
        this.xrt_ngay1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngay1.SizeF = new System.Drawing.SizeF(305.8333F, 23F);
        this.xrt_ngay1.StylePriority.UseFont = false;
        this.xrt_ngay1.Text = "..............., ngày ....... tháng ....... năm .........";
        // 
        // rp_DonDeNghiHuongTroCapThaiSan
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
        this.Margins = new System.Drawing.Printing.Margins(73, 48, 49, 100);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
