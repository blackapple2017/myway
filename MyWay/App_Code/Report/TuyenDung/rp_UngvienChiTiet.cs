using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataController;
using System.Data;
using SoftCore;
using System.Globalization;

/// <summary>
/// Summary description for rp_UngvienChiTiet
/// </summary>
public class rp_UngvienChiTiet : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private XRSubreport xrsRe_ChungChi;
    private sub_TuyenDung_UngVien_BC_CC sub_TuyenDung_UngVien_BC_CC1;
    private XRSubreport xrsRe_KetQuaThiTuyen;
    private sub_TuyenDung_UV_KetQuaThi sub_TuyenDung_UV_KetQuaThi1;
    private XRLabel xrl_footer2;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private ReportHeaderBand ReportHeader;
    private XRSubreport xrsRe_KinhNghiem;
    private sub_TuyenDung_UV_KinhNghiemCT sub_TuyenDung_UV_KinhNghiemCT1;
    private XRSubreport xrsRe_TruongDaoTao;
    private sub_TuyenDung_UngVien_TruongDT sub_TuyenDung_UngVien_TruongDT1;
    private XRLabel xrLabel5;
    private XRLabel xrl_TEN_HETHONG;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrl_NOICAP_CMND;
    private XRLabel xrl_GIOI_TINH;
    private XRLabel xrl_NOI_SINH;
    private XRLabel xrl_EMAIL;
    private XRLabel xrl_NGAYCAP_CMND;
    private XRLabel xrl_SO_CMND;
    private XRLabel xrLabel15;
    private XRLabel xrl_Mail;
    private XRCheckBox xrc_NAM;
    private XRCheckBox xrc_NU;
    private XRLabel xrl_NGAYSINH;
    private XRLabel xrl_DT_NHA;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrl_NGAY_SINH;
    private XRLabel xrl_HO_TEN;
    private XRLabel xrl_HO_KHAU;
    private XRLabel xrl_TON_GIAO;
    private XRLabel xrl_DI_DONG;
    private XRLabel xrl_NOI_O_HIENNAY;
    private XRLabel xrl_DAN_TOC;
    private XRLabel xrLabel13;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_UngvienChiTiet()
    {
        InitializeComponent();

    }


    public void BindData(string MaUngVien, ReportFilter filter)
    {
        ReportController rp = new ReportController();
        string companyname = "CN1";
        string city = "CN1";
        //xrl_TenCongTy.Text = rp.GetCompanyName(companyname).ToUpper();
        //xrl_Title_BC.Text = "BÁO CÁO CHI TIẾT HỒ SƠ ỨNG VIÊN";
        //xrl_NgayBC.Text = "Ngày báo cáo: " + string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        //xrtngayketxuat.Text = rp.GetCityName(city) + ", ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("report_HosoUngvien_ChiTiet", "@MaUngVien", MaUngVien);
        //if (dt.Rows.Count > 0)
        //{
        //    DataSource = dt;
        //    xrl_HoTen.Text += dt.Rows[0]["HO_TEN"].ToString();
        //    xrl_GioiTinh.Text += dt.Rows[0]["GIOI_TINH"].ToString();
        //    xrl_NgaySinh.Text += dt.Rows[0]["NGAY_SINH"].ToString();
        //    xrl_TinhTrangHonNhan.Text += dt.Rows[0]["HON_NHAN"].ToString();
        //    xrl_TT_SucKhoe.Text += dt.Rows[0]["SUC_KHOE"].ToString();
        //    xrl_SoCMND.Text += dt.Rows[0]["SO_CMT"].ToString();
        //    xrl_NgayCap.Text += dt.Rows[0]["NGAY_CAP_CMT"].ToString();
        //    xrl_NoiCap.Text += dt.Rows[0]["NOI_CAP_CMT"].ToString();
        //    xrl_QuocTich.Text += dt.Rows[0]["QUOC_TICH"].ToString();
        //    xrl_TonGiao.Text += dt.Rows[0]["TON_GIAO"].ToString();
        //    xrl_NoiSinh.Text += dt.Rows[0]["NOI_SINH"].ToString();
        //    xrl_SoDienThoai.Text += dt.Rows[0]["DIEN_THOAI"].ToString();
        //    xrl_DiDong.Text += dt.Rows[0]["DI_DONG"].ToString();
        //    xrl_Email.Text += dt.Rows[0]["EMAIL"].ToString();
        //    xrl_DiaChiLienHe.Text += dt.Rows[0]["DIA_CHI_LH"].ToString();
        //    xrl_TrinhDoVanHoa.Text += dt.Rows[0]["TRINH_DO_VH"].ToString();
        //    xrl_TrinhDoTinHoc.Text += dt.Rows[0]["TRINH_DO_TIN_HOC"].ToString();
        //    xrl_TrinhDoNgoaiNgu.Text += dt.Rows[0]["TRINH_DO_NN"].ToString();
        //    xrl_TrinhDoHocVan.Text += dt.Rows[0]["TRINH_DO_HV"].ToString();
        //    xrl_TruongDaoTao.Text += dt.Rows[0]["TRUONG_DAO_TAO"].ToString();
        //    xrl_ChuyenNghanh.Text += dt.Rows[0]["CHUYEN_NGHANH"].ToString();
        //    xrl_UuDiem.Text += dt.Rows[0]["UU_DIEM"].ToString();
        //    xrl_NhuocDiem.Text += dt.Rows[0]["NHUOC_DIEM"].ToString();
        //    xrl_SoThich.Text += dt.Rows[0]["SO_THICH"].ToString();
        //    xrl_GhiChu.Text += dt.Rows[0]["GHI_CHU"].ToString();
        //    xrl_ChucVu.Text += dt.Rows[0]["VI_TRI"].ToString();
        //    xrl_NgayNopHoSo.Text += dt.Rows[0]["NGAY_NOP_HS"].ToString();
        //    xrl_NgayCoTheDiLam.Text += dt.Rows[0]["NGAY_CT_DI_LAM"].ToString();
         
        //    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        // if(  !string.IsNullOrEmpty(dt.Rows[0]["MUC_LUONG_MONG_MUON"].ToString()))
        // {
        //     string luong = double.Parse(dt.Rows[0]["MUC_LUONG_MONG_MUON"].ToString()).ToString("#,###", cul.NumberFormat);
        //    xrl_MucLuongMongMuon.Text +=luong +" VND";
        // }
        //     if( !string.IsNullOrEmpty(dt.Rows[0]["LUONG_TOI_THIEU"].ToString()))
        // {
        //    string luongtoithieu = double.Parse(dt.Rows[0]["LUONG_TOI_THIEU"].ToString()).ToString("#,###", cul.NumberFormat);
        //    xrl_MucLuongToiThieu.Text += luongtoithieu + "VND";
        //     }
        //    xrp_anhdaidien.DataBindings.Add("Image", DataSource, "ANH");
        //    xrl_NhomMau.Text += dt.Rows[0]["NHOM_MAU"].ToString();
        //    xrl_ChieuCao.Text += dt.Rows[0]["CHIEU_CAO"].ToString() +"Cm";
        //    xrl_CanNang.Text += dt.Rows[0]["CAN_NANG"].ToString()+ "Kg";
           
        //    this.sub_TuyenDung_UngVien_BC_CC1.BindData(MaUngVien);
        //    this.sub_TuyenDung_UngVien_TruongDT1.BindData(MaUngVien);
        //    this.sub_TuyenDung_UV_KinhNghiemCT1.BindData(MaUngVien);
        //    this.sub_TuyenDung_UV_KetQuaThi1.BindData(MaUngVien);
        //    ReportController rpCtr = new ReportController();
        //    xrl_footer1.Text = rpCtr.GetTitleOfSignature(xrl_footer1.Text, filter.Title1);
        //    xrl_footer2.Text = rpCtr.GetTitleOfSignature(xrl_footer2.Text, filter.Title2);
        //    xrl_footer3.Text = rpCtr.GetTitleOfSignature(xrl_footer3.Text, filter.Title3);
        //    if (!string.IsNullOrEmpty(filter.Name1))
        //    {
        //        xrl_ten1.Text = filter.Name1;
        //    }
        //    else
        //    {
        //        xrl_ten1.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
        //    }
        //    xrl_ten2.Text = rpCtr.GetHeadOfHRroom(filter.SessionDepartment, filter.Name2);
        //    xrl_ten3.Text = rpCtr.GetDirectorName(filter.SessionDepartment, filter.Name3);

        //}
    }
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing && (components != null))
    //    {
    //        components.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_UngvienChiTiet.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrsRe_KetQuaThiTuyen = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub_TuyenDung_UV_KetQuaThi1 = new sub_TuyenDung_UV_KetQuaThi();
            this.xrsRe_ChungChi = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub_TuyenDung_UngVien_BC_CC1 = new sub_TuyenDung_UngVien_BC_CC();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.sub_TuyenDung_UV_KinhNghiemCT1 = new sub_TuyenDung_UV_KinhNghiemCT();
            this.xrsRe_KinhNghiem = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub_TuyenDung_UngVien_TruongDT1 = new sub_TuyenDung_UngVien_TruongDT();
            this.xrsRe_TruongDaoTao = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TEN_HETHONG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrl_NGAY_SINH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_HO_TEN = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NOI_O_HIENNAY = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_DAN_TOC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_HO_KHAU = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TON_GIAO = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_DI_DONG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_DT_NHA = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_EMAIL = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAYCAP_CMND = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_SO_CMND = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NOICAP_CMND = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_GIOI_TINH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NOI_SINH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrc_NAM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_NU = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrl_NGAYSINH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_Mail = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UV_KetQuaThi1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UngVien_BC_CC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UV_KinhNghiemCT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UngVien_TruongDT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_NOICAP_CMND,
            this.xrl_GIOI_TINH,
            this.xrl_NOI_SINH,
            this.xrl_EMAIL,
            this.xrl_NGAYCAP_CMND,
            this.xrl_SO_CMND,
            this.xrLabel15,
            this.xrl_Mail,
            this.xrc_NAM,
            this.xrc_NU,
            this.xrl_NGAYSINH,
            this.xrl_DT_NHA,
            this.xrPictureBox1,
            this.xrl_NGAY_SINH,
            this.xrl_HO_TEN,
            this.xrl_HO_KHAU,
            this.xrl_TON_GIAO,
            this.xrl_DI_DONG,
            this.xrl_NOI_O_HIENNAY,
            this.xrl_DAN_TOC,
            this.xrLabel13});
            this.Detail.HeightF = 769F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 33F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 47F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_footer2,
            this.xrtngayketxuat,
            this.xrl_footer3,
            this.xrl_footer1,
            this.xrl_ten3,
            this.xrl_ten2,
            this.xrl_ten1});
            this.ReportFooter.HeightF = 196F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(175F, 50F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(222.7652F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "KẾ TOÁN TRƯỞNG";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(385.9165F, 27.00001F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(265.0835F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = ", ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(413F, 50F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(238F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "PHÒNG HCNS";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(161.9514F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(413F, 150F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(238F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(175F, 150F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(222.7653F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 150F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(161.9514F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.Expanded = false;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(773.9583F, 37.5F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrsRe_KetQuaThiTuyen,
            this.xrsRe_KinhNghiem,
            this.xrsRe_ChungChi,
            this.xrsRe_TruongDaoTao});
            this.Detail1.HeightF = 98F;
            this.Detail1.Name = "Detail1";
            // 
            // xrsRe_KetQuaThiTuyen
            // 
            this.xrsRe_KetQuaThiTuyen.LocationFloat = new DevExpress.Utils.PointFloat(0F, 71.00004F);
            this.xrsRe_KetQuaThiTuyen.Name = "xrsRe_KetQuaThiTuyen";
            this.xrsRe_KetQuaThiTuyen.ReportSource = this.sub_TuyenDung_UV_KetQuaThi1;
            this.xrsRe_KetQuaThiTuyen.SizeF = new System.Drawing.SizeF(651F, 26.99996F);
            // 
            // xrsRe_ChungChi
            // 
            this.xrsRe_ChungChi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99995F);
            this.xrsRe_ChungChi.Name = "xrsRe_ChungChi";
            this.xrsRe_ChungChi.ReportSource = this.sub_TuyenDung_UngVien_BC_CC1;
            this.xrsRe_ChungChi.SizeF = new System.Drawing.SizeF(651F, 23F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrl_TEN_HETHONG,
            this.xrLabel3,
            this.xrLabel4});
            this.ReportHeader.HeightF = 133.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrsRe_KinhNghiem
            // 
            this.xrsRe_KinhNghiem.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.99991F);
            this.xrsRe_KinhNghiem.Name = "xrsRe_KinhNghiem";
            this.xrsRe_KinhNghiem.ReportSource = this.sub_TuyenDung_UV_KinhNghiemCT1;
            this.xrsRe_KinhNghiem.SizeF = new System.Drawing.SizeF(651F, 25.00009F);
            // 
            // xrsRe_TruongDaoTao
            // 
            this.xrsRe_TruongDaoTao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrsRe_TruongDaoTao.Name = "xrsRe_TruongDaoTao";
            this.xrsRe_TruongDaoTao.ReportSource = this.sub_TuyenDung_UngVien_TruongDT1;
            this.xrsRe_TruongDaoTao.SizeF = new System.Drawing.SizeF(650.9999F, 23F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(751F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(751F, 20.99998F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Độc lập - Tự do -Hạnh phúc";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(751F, 20.99996F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "HỒ SỨNG VIÊN";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TEN_HETHONG
            // 
            this.xrl_TEN_HETHONG.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrl_TEN_HETHONG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_TEN_HETHONG.LocationFloat = new DevExpress.Utils.PointFloat(0F, 112.5F);
            this.xrl_TEN_HETHONG.Name = "xrl_TEN_HETHONG";
            this.xrl_TEN_HETHONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TEN_HETHONG.SizeF = new System.Drawing.SizeF(751F, 20.99998F);
            this.xrl_TEN_HETHONG.StylePriority.UseBorders = false;
            this.xrl_TEN_HETHONG.StylePriority.UseFont = false;
            this.xrl_TEN_HETHONG.StylePriority.UseTextAlignment = false;
            this.xrl_TEN_HETHONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(615.5803F, 22.99999F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(135.4197F, 161F);
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // xrl_NGAY_SINH
            // 
            this.xrl_NGAY_SINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_SINH.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 45.99997F);
            this.xrl_NGAY_SINH.Name = "xrl_NGAY_SINH";
            this.xrl_NGAY_SINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_SINH.SizeF = new System.Drawing.SizeF(100.8333F, 23F);
            this.xrl_NGAY_SINH.StylePriority.UseFont = false;
            this.xrl_NGAY_SINH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_SINH.Text = "2. Ngày sinh:  ";
            this.xrl_NGAY_SINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_HO_TEN
            // 
            this.xrl_HO_TEN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HO_TEN.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99999F);
            this.xrl_HO_TEN.Name = "xrl_HO_TEN";
            this.xrl_HO_TEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HO_TEN.SizeF = new System.Drawing.SizeF(615.5803F, 23F);
            this.xrl_HO_TEN.StylePriority.UseFont = false;
            this.xrl_HO_TEN.StylePriority.UseTextAlignment = false;
            this.xrl_HO_TEN.Text = "1. Họ và tên:  ";
            this.xrl_HO_TEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOI_O_HIENNAY
            // 
            this.xrl_NOI_O_HIENNAY.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NOI_O_HIENNAY.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 138F);
            this.xrl_NOI_O_HIENNAY.Name = "xrl_NOI_O_HIENNAY";
            this.xrl_NOI_O_HIENNAY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOI_O_HIENNAY.SizeF = new System.Drawing.SizeF(614.5387F, 23F);
            this.xrl_NOI_O_HIENNAY.StylePriority.UseFont = false;
            this.xrl_NOI_O_HIENNAY.StylePriority.UseTextAlignment = false;
            this.xrl_NOI_O_HIENNAY.Text = "11. Nơi ở hiện nay: ";
            this.xrl_NOI_O_HIENNAY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_DAN_TOC
            // 
            this.xrl_DAN_TOC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DAN_TOC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 92.00001F);
            this.xrl_DAN_TOC.Name = "xrl_DAN_TOC";
            this.xrl_DAN_TOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DAN_TOC.SizeF = new System.Drawing.SizeF(337.4999F, 23F);
            this.xrl_DAN_TOC.StylePriority.UseFont = false;
            this.xrl_DAN_TOC.StylePriority.UseTextAlignment = false;
            this.xrl_DAN_TOC.Text = "7. Dân tộc: ";
            this.xrl_DAN_TOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(751F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "I. THÔNG TIN HỒ SƠ";
            // 
            // xrl_HO_KHAU
            // 
            this.xrl_HO_KHAU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HO_KHAU.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.xrl_HO_KHAU.Name = "xrl_HO_KHAU";
            this.xrl_HO_KHAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HO_KHAU.SizeF = new System.Drawing.SizeF(615.5804F, 23.00001F);
            this.xrl_HO_KHAU.StylePriority.UseFont = false;
            this.xrl_HO_KHAU.StylePriority.UseTextAlignment = false;
            this.xrl_HO_KHAU.Text = "10. Hộ khẩu thường trú: ";
            this.xrl_HO_KHAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TON_GIAO
            // 
            this.xrl_TON_GIAO.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TON_GIAO.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 92.00007F);
            this.xrl_TON_GIAO.Name = "xrl_TON_GIAO";
            this.xrl_TON_GIAO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TON_GIAO.SizeF = new System.Drawing.SizeF(278.0804F, 22.99994F);
            this.xrl_TON_GIAO.StylePriority.UseFont = false;
            this.xrl_TON_GIAO.StylePriority.UseTextAlignment = false;
            this.xrl_TON_GIAO.Text = "8.Tôn giáo: ";
            this.xrl_TON_GIAO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_DI_DONG
            // 
            this.xrl_DI_DONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DI_DONG.LocationFloat = new DevExpress.Utils.PointFloat(125F, 161F);
            this.xrl_DI_DONG.Name = "xrl_DI_DONG";
            this.xrl_DI_DONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DI_DONG.SizeF = new System.Drawing.SizeF(212.4999F, 23F);
            this.xrl_DI_DONG.StylePriority.UseFont = false;
            this.xrl_DI_DONG.StylePriority.UseTextAlignment = false;
            this.xrl_DI_DONG.Text = "DĐ: ";
            this.xrl_DI_DONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_DT_NHA
            // 
            this.xrl_DT_NHA.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DT_NHA.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 161.0001F);
            this.xrl_DT_NHA.Name = "xrl_DT_NHA";
            this.xrl_DT_NHA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DT_NHA.SizeF = new System.Drawing.SizeF(278.0804F, 23F);
            this.xrl_DT_NHA.StylePriority.UseFont = false;
            this.xrl_DT_NHA.StylePriority.UseTextAlignment = false;
            this.xrl_DT_NHA.Text = "NR: ";
            this.xrl_DT_NHA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_EMAIL
            // 
            this.xrl_EMAIL.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_EMAIL.LocationFloat = new DevExpress.Utils.PointFloat(0F, 184F);
            this.xrl_EMAIL.Name = "xrl_EMAIL";
            this.xrl_EMAIL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_EMAIL.SizeF = new System.Drawing.SizeF(124.4087F, 23.00002F);
            this.xrl_EMAIL.StylePriority.UseFont = false;
            this.xrl_EMAIL.StylePriority.UseTextAlignment = false;
            this.xrl_EMAIL.Text = "13. Email:                    ";
            this.xrl_EMAIL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAYCAP_CMND
            // 
            this.xrl_NGAYCAP_CMND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_NGAYCAP_CMND.LocationFloat = new DevExpress.Utils.PointFloat(489.3752F, 207.0001F);
            this.xrl_NGAYCAP_CMND.Name = "xrl_NGAYCAP_CMND";
            this.xrl_NGAYCAP_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAYCAP_CMND.SizeF = new System.Drawing.SizeF(261.6246F, 23F);
            this.xrl_NGAYCAP_CMND.StylePriority.UseFont = false;
            this.xrl_NGAYCAP_CMND.StylePriority.UseTextAlignment = false;
            this.xrl_NGAYCAP_CMND.Text = "Ngày cấp: ";
            this.xrl_NGAYCAP_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_SO_CMND
            // 
            this.xrl_SO_CMND.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_SO_CMND.LocationFloat = new DevExpress.Utils.PointFloat(0F, 207F);
            this.xrl_SO_CMND.Name = "xrl_SO_CMND";
            this.xrl_SO_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_SO_CMND.SizeF = new System.Drawing.SizeF(276.6668F, 23.00003F);
            this.xrl_SO_CMND.StylePriority.UseFont = false;
            this.xrl_SO_CMND.StylePriority.UseTextAlignment = false;
            this.xrl_SO_CMND.Text = "14. Số CMTND: ";
            this.xrl_SO_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOICAP_CMND
            // 
            this.xrl_NOICAP_CMND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_NOICAP_CMND.LocationFloat = new DevExpress.Utils.PointFloat(276.6668F, 207F);
            this.xrl_NOICAP_CMND.Name = "xrl_NOICAP_CMND";
            this.xrl_NOICAP_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOICAP_CMND.SizeF = new System.Drawing.SizeF(212.7084F, 23.00003F);
            this.xrl_NOICAP_CMND.StylePriority.UseFont = false;
            this.xrl_NOICAP_CMND.StylePriority.UseTextAlignment = false;
            this.xrl_NOICAP_CMND.Text = "Nơi cấp: ";
            this.xrl_NOICAP_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_GIOI_TINH
            // 
            this.xrl_GIOI_TINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_GIOI_TINH.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 45.99997F);
            this.xrl_GIOI_TINH.Name = "xrl_GIOI_TINH";
            this.xrl_GIOI_TINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_GIOI_TINH.SizeF = new System.Drawing.SizeF(131.8304F, 23.00002F);
            this.xrl_GIOI_TINH.StylePriority.UseFont = false;
            this.xrl_GIOI_TINH.StylePriority.UseTextAlignment = false;
            this.xrl_GIOI_TINH.Text = "3. Giới tính: (v)";
            this.xrl_GIOI_TINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOI_SINH
            // 
            this.xrl_NOI_SINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NOI_SINH.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 68.99999F);
            this.xrl_NOI_SINH.Name = "xrl_NOI_SINH";
            this.xrl_NOI_SINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOI_SINH.SizeF = new System.Drawing.SizeF(614.5386F, 23.00002F);
            this.xrl_NOI_SINH.StylePriority.UseFont = false;
            this.xrl_NOI_SINH.StylePriority.UseTextAlignment = false;
            this.xrl_NOI_SINH.Text = "6. Nơi sinh: ";
            this.xrl_NOI_SINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrc_NAM
            // 
            this.xrc_NAM.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_NAM.LocationFloat = new DevExpress.Utils.PointFloat(469.3303F, 45.99997F);
            this.xrc_NAM.Name = "xrc_NAM";
            this.xrc_NAM.SizeF = new System.Drawing.SizeF(71.25F, 23F);
            this.xrc_NAM.StylePriority.UseFont = false;
            this.xrc_NAM.StylePriority.UseTextAlignment = false;
            this.xrc_NAM.Text = "Nam";
            this.xrc_NAM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrc_NU
            // 
            this.xrc_NU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_NU.LocationFloat = new DevExpress.Utils.PointFloat(544.3303F, 45.99997F);
            this.xrc_NU.Name = "xrc_NU";
            this.xrc_NU.SizeF = new System.Drawing.SizeF(71.25F, 23F);
            this.xrc_NU.StylePriority.UseFont = false;
            this.xrc_NU.StylePriority.UseTextAlignment = false;
            this.xrc_NU.Text = "Nữ";
            this.xrc_NU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrl_NGAYSINH
            // 
            this.xrl_NGAYSINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAYSINH.LocationFloat = new DevExpress.Utils.PointFloat(101.875F, 45.99997F);
            this.xrl_NGAYSINH.Name = "xrl_NGAYSINH";
            this.xrl_NGAYSINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAYSINH.SizeF = new System.Drawing.SizeF(235.625F, 23F);
            this.xrl_NGAYSINH.StylePriority.UseFont = false;
            this.xrl_NGAYSINH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAYSINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 161F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(125F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "12. Điện thoại:  ";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_Mail
            // 
            this.xrl_Mail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_Mail.LocationFloat = new DevExpress.Utils.PointFloat(124.4087F, 184F);
            this.xrl_Mail.Name = "xrl_Mail";
            this.xrl_Mail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_Mail.SizeF = new System.Drawing.SizeF(626.5912F, 23F);
            this.xrl_Mail.StylePriority.UseFont = false;
            this.xrl_Mail.StylePriority.UseTextAlignment = false;
            this.xrl_Mail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rp_UngvienChiTiet
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter,
            this.DetailReport});
            this.Margins = new System.Drawing.Printing.Margins(50, 49, 33, 47);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UV_KetQuaThi1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UngVien_BC_CC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UV_KinhNghiemCT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sub_TuyenDung_UngVien_TruongDT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
