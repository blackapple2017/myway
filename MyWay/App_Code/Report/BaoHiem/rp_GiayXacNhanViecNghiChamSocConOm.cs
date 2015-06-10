using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_GiayXacNhanViecNghiChamSocConOm
/// </summary>
public class rp_GiayXacNhanViecNghiChamSocConOm : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLine xrLine1;
    private XRLabel xrLabel4;
    private XRLabel xrt_donvi;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrt_tendonvi;
    private XRLabel xrt_sdt;
    private XRLabel xrLabel12;
    private XRLabel xrt_hoten;
    private XRLabel xrt_gioitinh;
    private XRLabel xrt_sosobhxh;
    private XRLabel xrt_nghenghiep;
    private XRLabel xrt_dv1;
    private XRLabel xrLabel18;
    private XRLabel xrt_tenongba;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrt_ngayketthuc;
    private XRLabel xrt_thoigianhuongchedo;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_GiayXacNhanViecNghiChamSocConOm()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    public void BinData(ReportFilter rp)
    {

        DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_MauInCheDo", "@IDChiTietCheDoBaoHiem", rp.WhereClause);
        if (!string.IsNullOrEmpty(ReportController.GetInstance().GetCompanyName(rp.SessionDepartment)))
        {
            xrt_tendonvi.Text = "      1- Tên, địa chỉ cơ quan, đơn vị quản lý người lao động nghỉ việc chăm sóc con ốm trước đó (cha hoặc mẹ) đã hưởng hết thơi gian theo quy định : " + ReportController.GetInstance().GetCompanyName(rp.SessionDepartment);
            xrt_donvi.Text = ReportController.GetInstance().GetCompanyName(rp.SessionDepartment).ToUpper();
            xrt_dv1.Text = "Đơn vị (hoặc nơi làm việc) " + ReportController.GetInstance().GetCompanyName(rp.SessionDepartment);
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["SoDienThoai"].ToString()))
        {
            xrt_sdt.Text = "      Số điện thoại (nếu có): " + ReportController.GetInstance().GetCompanyPhoneNumber(rp.SessionDepartment);
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["HoTen"].ToString()))
        {
            xrt_hoten.Text = "- Họ tên: " + dt.Rows[0]["HoTen"].ToString();
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["GioiTinh"].ToString()))
        {
            if (dt.Rows[0]["GioiTinh"].ToString() == "True")
            {
                xrt_gioitinh.Text = "Nam/Nữ: " + "Nam";
            }
            else
            {
                xrt_gioitinh.Text = "Nam/Nữ: " + "Nữ";
            }
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["SoSoBHXH"].ToString()))
        {
            xrt_sosobhxh.Text = "- Số sổ BHXH " + dt.Rows[0]["SoSoBHXH"].ToString();
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["NgheNghiep"].ToString()))
        {
            xrt_nghenghiep.Text = "- Nghề nghiệp: " + dt.Rows[0]["NgheNghiep"].ToString();
        }

        if (!string.IsNullOrEmpty(dt.Rows[0]["HoTen"].ToString()))
        {
            xrt_tenongba.Text = "      Đơn vị chúng tôi đã giải quyết chế độ nghỉ việc để chăm sóc con ốm đau cho ông/bà : " + dt.Rows[0]["HoTen"].ToString();
        }
        if (string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()))
        {
            xrt_ngayketthuc.Text = "Tính đến hết ngày " + Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Day + " tháng " + Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Month + " năm " + Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]).Year;
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["ThoiGianToiDaHuongCheDo"].ToString()))
        {
            xrt_thoigianhuongchedo.Text = "Xác nhận người lao động đã hết thời gian hưởng chế độ khi con ốm đau trong một năm theo quy định là " + dt.Rows[0]["ThoiGianToiDaHuongCheDo"].ToString() + " ngày.";
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
        string resourceFileName = "rp_GiayXacNhanViecNghiChamSocConOm.resx";
        System.Resources.ResourceManager resources = global::Resources.rp_GiayXacNhanViecNghiChamSocConOm.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrt_thoigianhuongchedo = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_ngayketthuc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_tenongba = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_dv1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_nghenghiep = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_sosobhxh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_gioitinh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_hoten = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_sdt = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_tendonvi = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrt_donvi = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrt_thoigianhuongchedo,
            this.xrt_ngayketthuc,
            this.xrt_tenongba,
            this.xrLabel18,
            this.xrt_dv1,
            this.xrt_nghenghiep,
            this.xrt_sosobhxh,
            this.xrt_gioitinh,
            this.xrt_hoten,
            this.xrLabel12,
            this.xrt_sdt,
            this.xrt_tendonvi});
        this.Detail.HeightF = 317F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrt_thoigianhuongchedo
        // 
        this.xrt_thoigianhuongchedo.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_thoigianhuongchedo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 256.5836F);
        this.xrt_thoigianhuongchedo.Multiline = true;
        this.xrt_thoigianhuongchedo.Name = "xrt_thoigianhuongchedo";
        this.xrt_thoigianhuongchedo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_thoigianhuongchedo.SizeF = new System.Drawing.SizeF(672.9997F, 39.58304F);
        this.xrt_thoigianhuongchedo.StylePriority.UseFont = false;
        this.xrt_thoigianhuongchedo.Text = "Xác nhận người lao động đã hết thời gian hưởng chế độ khi con ốm đau trong một nă" +
            "m theo quy \r\nđịnh là............. ngày.";
        // 
        // xrt_ngayketthuc
        // 
        this.xrt_ngayketthuc.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_ngayketthuc.LocationFloat = new DevExpress.Utils.PointFloat(0F, 233.5836F);
        this.xrt_ngayketthuc.Name = "xrt_ngayketthuc";
        this.xrt_ngayketthuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_ngayketthuc.SizeF = new System.Drawing.SizeF(672.9997F, 23F);
        this.xrt_ngayketthuc.StylePriority.UseFont = false;
        this.xrt_ngayketthuc.Text = "Tính đến hết ngày…… tháng……năm……";
        // 
        // xrt_tenongba
        // 
        this.xrt_tenongba.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_tenongba.LocationFloat = new DevExpress.Utils.PointFloat(0F, 210.5835F);
        this.xrt_tenongba.Multiline = true;
        this.xrt_tenongba.Name = "xrt_tenongba";
        this.xrt_tenongba.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_tenongba.SizeF = new System.Drawing.SizeF(672.9999F, 23.00003F);
        this.xrt_tenongba.StylePriority.UseFont = false;
        this.xrt_tenongba.Text = "       Đơn vị chúng tôi đã giải quyết chế độ nghỉ việc để chăm sóc con ốm đau cho" +
            " ông/bà :................";
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 189.6667F);
        this.xrLabel18.Multiline = true;
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(672.9999F, 20.91669F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.Text = "       Thuộc đối tượng đang tham gia đóng bảo hiểm xã hội tại đơn vị, có con dưới" +
            " 7 tuổi bị ốm đau";
        // 
        // xrt_dv1
        // 
        this.xrt_dv1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_dv1.LocationFloat = new DevExpress.Utils.PointFloat(276.0415F, 155.2083F);
        this.xrt_dv1.Multiline = true;
        this.xrt_dv1.Name = "xrt_dv1";
        this.xrt_dv1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_dv1.SizeF = new System.Drawing.SizeF(396.9582F, 26.12502F);
        this.xrt_dv1.StylePriority.UseFont = false;
        this.xrt_dv1.Text = "Đơn vị (hoặc nơi làm việc)...................................................";
        // 
        // xrt_nghenghiep
        // 
        this.xrt_nghenghiep.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_nghenghiep.LocationFloat = new DevExpress.Utils.PointFloat(0F, 155.2083F);
        this.xrt_nghenghiep.Multiline = true;
        this.xrt_nghenghiep.Name = "xrt_nghenghiep";
        this.xrt_nghenghiep.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_nghenghiep.SizeF = new System.Drawing.SizeF(276.0415F, 26.12502F);
        this.xrt_nghenghiep.StylePriority.UseFont = false;
        this.xrt_nghenghiep.Text = "- Nghề nghiệp:.......................................";
        // 
        // xrt_sosobhxh
        // 
        this.xrt_sosobhxh.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_sosobhxh.LocationFloat = new DevExpress.Utils.PointFloat(0F, 129.0834F);
        this.xrt_sosobhxh.Multiline = true;
        this.xrt_sosobhxh.Name = "xrt_sosobhxh";
        this.xrt_sosobhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_sosobhxh.SizeF = new System.Drawing.SizeF(349.0416F, 26.12502F);
        this.xrt_sosobhxh.StylePriority.UseFont = false;
        this.xrt_sosobhxh.Text = "- Số sổ BHXH.........................................................";
        // 
        // xrt_gioitinh
        // 
        this.xrt_gioitinh.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_gioitinh.LocationFloat = new DevExpress.Utils.PointFloat(349.0414F, 102.9584F);
        this.xrt_gioitinh.Multiline = true;
        this.xrt_gioitinh.Name = "xrt_gioitinh";
        this.xrt_gioitinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_gioitinh.SizeF = new System.Drawing.SizeF(323.9582F, 26.12502F);
        this.xrt_gioitinh.StylePriority.UseFont = false;
        this.xrt_gioitinh.Text = "Nam/Nữ..............................................................";
        // 
        // xrt_hoten
        // 
        this.xrt_hoten.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_hoten.LocationFloat = new DevExpress.Utils.PointFloat(0F, 102.9584F);
        this.xrt_hoten.Multiline = true;
        this.xrt_hoten.Name = "xrt_hoten";
        this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_hoten.SizeF = new System.Drawing.SizeF(349.0414F, 26.12502F);
        this.xrt_hoten.StylePriority.UseFont = false;
        this.xrt_hoten.Text = "- Họ tên: ..................................................................";
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 76.83334F);
        this.xrLabel12.Multiline = true;
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(672.9999F, 26.12502F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.Text = "       2- Thông tin về người lao động đã nghỉ việc chăm sóc con ốm đau: ";
        // 
        // xrt_sdt
        // 
        this.xrt_sdt.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_sdt.LocationFloat = new DevExpress.Utils.PointFloat(0F, 49.66666F);
        this.xrt_sdt.Multiline = true;
        this.xrt_sdt.Name = "xrt_sdt";
        this.xrt_sdt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_sdt.SizeF = new System.Drawing.SizeF(672.9999F, 27.16668F);
        this.xrt_sdt.StylePriority.UseFont = false;
        this.xrt_sdt.Text = "       Số điện thoại (nếu có): .................................................." +
            ".................................................................";
        // 
        // xrt_tendonvi
        // 
        this.xrt_tendonvi.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrt_tendonvi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
        this.xrt_tendonvi.Multiline = true;
        this.xrt_tendonvi.Name = "xrt_tendonvi";
        this.xrt_tendonvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_tendonvi.SizeF = new System.Drawing.SizeF(672.9999F, 39.66666F);
        this.xrt_tendonvi.StylePriority.UseFont = false;
        this.xrt_tendonvi.Text = resources.GetString("xrt_tendonvi.Text");
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
        this.BottomMargin.HeightF = 268F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrt_donvi,
            this.xrLabel4,
            this.xrLine1,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.HeightF = 224F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 197.9583F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(672.9998F, 23F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "về nghỉ việc để chăm sóc con ốm đau";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 174.9583F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(673F, 23F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "GIẤY XÁC NHẬN ";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(400.0833F, 120.7917F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(272.9167F, 23F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.Text = "............, ngày........... tháng..........năm................";
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80.29166F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(276.0417F, 23F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.Text = "Số: ";
        // 
        // xrt_donvi
        // 
        this.xrt_donvi.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrt_donvi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 57.29163F);
        this.xrt_donvi.Name = "xrt_donvi";
        this.xrt_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_donvi.SizeF = new System.Drawing.SizeF(276.0417F, 23F);
        this.xrt_donvi.StylePriority.UseFont = false;
        this.xrt_donvi.Text = "...............................................................";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.29165F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(276.0417F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.Text = "CƠ QUAN QUẢN LÝ CẤP TRÊN";
        // 
        // xrLine1
        // 
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(411.4583F, 80.29162F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(150F, 2F);
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(298.9583F, 57.29163F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(374.0416F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Độc lập - Tự do - Hạnh phúc ";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(298.9583F, 34.29165F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(374.0416F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(548.9583F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(124.0416F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Mẫu số 5B-HSB";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel20});
        this.ReportFooter.HeightF = 217F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel21
        // 
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(242.7083F, 23.00002F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(430.2915F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "(Ký, đóng dấu)";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(242.7083F, 0F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(430.2915F, 23F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "THỦ TRƯỞNG CƠ QUAN ĐƠN VỊ";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // rp_GiayXacNhanViecNghiChamSocConOm
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
        this.Margins = new System.Drawing.Printing.Margins(89, 64, 49, 268);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
