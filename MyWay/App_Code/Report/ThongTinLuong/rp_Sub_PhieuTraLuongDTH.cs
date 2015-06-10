using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_Sub_PhieuTraLuongDTH
/// </summary>
public class rp_Sub_PhieuTraLuongDTH : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TitleBC;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrlSoCongTT;
    private XRLabel xrlBoPhan;
    private XRLabel xrlHoTen;
    private XRLabel xrlNgayCongTieuChuan;
    private XRLabel xrLabel7;
    private XRLabel xrlTieuDeKi1;
    private XRLabel xrlTieuDeKi3;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell3;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtPhuCapTN;
    private XRTableCell xrTableCell5;
    private XRTableCell xrtBHTN;
    private XRTableRow xrTableRow3;
    private XRTableCell xrtLuongCoBan;
    private XRTableCell xrTableCell8;
    private XRTableCell xrtBHXH;
    private XRTableRow xrTableRow4;
    private XRTableCell xrtPhuCapCV;
    private XRTableCell xrTableCell11;
    private XRTableCell xrtBHYT;
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
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell25;
    private XRTableCell xrtThucLinh;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrtLuongSP;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrtTruLuong;
    private XRTableCell xrTableCell40;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrtThuong;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrtTruTNCN;
    private XRTableCell xrTableCell47;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableCell xrtChuyenCan;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrtTruTamUng;
    private XRTableCell xrTableCell61;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableCell xrtTongThu;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrtTongTru;
    private XRTableCell xrTableCell68;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell49;
    private XRTableCell xrtLamThem;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrtTruKhac;
    private XRTableCell xrTableCell54;
    private XRLabel xrlTenNguoiKy3;
    private XRLabel xrlTenNguoiKi1;
    private XRLabel xrlThangNam;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_Sub_PhieuTraLuongDTH()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    public void BindData(string thangnam, string hoten, string bophan, string socongtt, string ngaycongtieuchuan,
        string luongcoban, string phucapcv, string phucaptn, string luongsp, string thuong,
        string chuyencan, string lamthem, string tongthu, string thuclinh, string bhxh, string bhyt, string bhtn, string truluong,
        string trutncn, string trutamung, string trukhac, string tongtru,string tieudeky1,string tieudeky3, string tennguoiky1,string tennguoiki3)
    {
        xrlThangNam.Text=thangnam;
        xrlHoTen.Text=hoten;
        xrlBoPhan.Text = bophan;
        xrlSoCongTT.Text = socongtt;
        xrlNgayCongTieuChuan.Text = ngaycongtieuchuan;
        xrtLuongCoBan.Text = luongcoban;
        xrtPhuCapCV.Text = phucapcv;
        xrtPhuCapTN.Text = phucaptn;
        xrtLuongSP.Text = luongsp;
        xrtThuong.Text = thuong;
        xrtChuyenCan.Text = chuyencan;
        xrtLamThem.Text = lamthem;
        xrtTongThu.Text = tongthu;
        xrtThucLinh.Text = thuclinh;
        xrtBHXH.Text = bhxh;
        xrtBHYT.Text = bhyt;
        xrtBHTN.Text = bhtn;
        xrtTruLuong.Text = truluong;
        xrtTruTNCN.Text = trutncn;
        xrtTruTamUng.Text = trutamung;
        xrtTruKhac.Text = trukhac;
        xrtTongTru.Text = tongtru;
        if (tieudeky1 != "") xrlTieuDeKi1.Text = tieudeky1;
        if (tieudeky3 != "") xrlTieuDeKi3.Text = tieudeky3;
        if (tennguoiky1 != "") xrlTieuDeKi3.Text = tennguoiky1;
        if (tennguoiky1 != "") xrlTieuDeKi3.Text = tennguoiky1; 
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
            string resourceFileName = "rp_Sub_PhieuTraLuongDTH.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlHoTen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlBoPhan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlSoCongTT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNgayCongTieuChuan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlTieuDeKi1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlTieuDeKi3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtPhuCapTN = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtBHTN = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtLuongCoBan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtBHXH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtPhuCapCV = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtBHYT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtThucLinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtLuongSP = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTruLuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtThuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTruTNCN = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtChuyenCan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTruTamUng = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongThu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongTru = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtLamThem = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTruKhac = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrlTenNguoiKi1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlTenNguoiKy3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlThangNam = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlThangNam,
            this.xrlTenNguoiKy3,
            this.xrlTenNguoiKi1,
            this.xrlNgayCongTieuChuan,
            this.xrLabel7,
            this.xrlSoCongTT,
            this.xrlBoPhan,
            this.xrlHoTen,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy,
            this.xrl_TitleBC,
            this.xrTable1,
            this.xrlTieuDeKi3,
            this.xrlTieuDeKi1});
            this.TopMargin.HeightF = 570F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(451.0417F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.25F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(451.0416F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(48.54167F, 77.16667F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(687.5833F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BẢNG TỔNG HỢP CÔNG CUỐI THÁNG";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 129.1667F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Họ và tên";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 152.1667F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Bộ phận";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175.1667F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Số công TT";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlHoTen
            // 
            this.xrlHoTen.LocationFloat = new DevExpress.Utils.PointFloat(100F, 129.1667F);
            this.xrlHoTen.Name = "xrlHoTen";
            this.xrlHoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlHoTen.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlHoTen.StylePriority.UseTextAlignment = false;
            this.xrlHoTen.Text = "Họ và tên";
            this.xrlHoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlBoPhan
            // 
            this.xrlBoPhan.LocationFloat = new DevExpress.Utils.PointFloat(100F, 152.1667F);
            this.xrlBoPhan.Name = "xrlBoPhan";
            this.xrlBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlBoPhan.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlBoPhan.StylePriority.UseTextAlignment = false;
            this.xrlBoPhan.Text = "Bộ phận";
            this.xrlBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlSoCongTT
            // 
            this.xrlSoCongTT.LocationFloat = new DevExpress.Utils.PointFloat(100F, 175.1667F);
            this.xrlSoCongTT.Name = "xrlSoCongTT";
            this.xrlSoCongTT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlSoCongTT.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlSoCongTT.StylePriority.UseTextAlignment = false;
            this.xrlSoCongTT.Text = "Số công TT";
            this.xrlSoCongTT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(421.8751F, 175.1667F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(153.1249F, 23F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Ngày công tiêu chuẩn";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlNgayCongTieuChuan
            // 
            this.xrlNgayCongTieuChuan.LocationFloat = new DevExpress.Utils.PointFloat(575F, 175.1667F);
            this.xrlNgayCongTieuChuan.Name = "xrlNgayCongTieuChuan";
            this.xrlNgayCongTieuChuan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNgayCongTieuChuan.SizeF = new System.Drawing.SizeF(171.7919F, 23F);
            this.xrlNgayCongTieuChuan.StylePriority.UseTextAlignment = false;
            this.xrlNgayCongTieuChuan.Text = "Số công TT";
            this.xrlNgayCongTieuChuan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlTieuDeKi1
            // 
            this.xrlTieuDeKi1.LocationFloat = new DevExpress.Utils.PointFloat(11.04171F, 461.4583F);
            this.xrlTieuDeKi1.Name = "xrlTieuDeKi1";
            this.xrlTieuDeKi1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTieuDeKi1.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlTieuDeKi1.StylePriority.UseTextAlignment = false;
            this.xrlTieuDeKi1.Text = "Kế toán thanh toán";
            this.xrlTieuDeKi1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlTieuDeKi3
            // 
            this.xrlTieuDeKi3.LocationFloat = new DevExpress.Utils.PointFloat(468.4166F, 461.4583F);
            this.xrlTieuDeKi3.Name = "xrlTieuDeKi3";
            this.xrlTieuDeKi3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTieuDeKi3.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlTieuDeKi3.StylePriority.UseTextAlignment = false;
            this.xrlTieuDeKi3.Text = "Người nhận";
            this.xrlTieuDeKi3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 211.4583F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow3,
            this.xrTableRow4,
            this.xrTableRow2,
            this.xrTableRow7,
            this.xrTableRow8,
            this.xrTableRow10,
            this.xrTableRow9,
            this.xrTableRow11,
            this.xrTableRow6});
            this.xrTable1.SizeF = new System.Drawing.SizeF(752F, 250F);
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell1,
            this.xrTableCell21,
            this.xrTableCell3,
            this.xrTableCell13});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Các khoản thu nhập";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 1.2795877482028719D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Các khoản giảm trừ";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 1D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20,
            this.xrTableCell28,
            this.xrtPhuCapTN,
            this.xrTableCell24,
            this.xrTableCell5,
            this.xrtBHTN,
            this.xrTableCell16});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrtPhuCapTN
            // 
            this.xrtPhuCapTN.Name = "xrtPhuCapTN";
            this.xrtPhuCapTN.StylePriority.UseTextAlignment = false;
            this.xrtPhuCapTN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtPhuCapTN.Weight = 0.61402910313707726D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "BHTN";
            this.xrTableCell5.Weight = 0.5D;
            // 
            // xrtBHTN
            // 
            this.xrtBHTN.Name = "xrtBHTN";
            this.xrtBHTN.StylePriority.UseTextAlignment = false;
            this.xrtBHTN.Text = " ";
            this.xrtBHTN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtBHTN.Weight = 0.5D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell18,
            this.xrTableCell26,
            this.xrtLuongCoBan,
            this.xrTableCell22,
            this.xrTableCell8,
            this.xrtBHXH,
            this.xrTableCell14});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrtLuongCoBan
            // 
            this.xrtLuongCoBan.Name = "xrtLuongCoBan";
            this.xrtLuongCoBan.StylePriority.UseTextAlignment = false;
            this.xrtLuongCoBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtLuongCoBan.Weight = 0.61402908791887D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "BHXH";
            this.xrTableCell8.Weight = 0.5D;
            // 
            // xrtBHXH
            // 
            this.xrtBHXH.Name = "xrtBHXH";
            this.xrtBHXH.StylePriority.UseTextAlignment = false;
            this.xrtBHXH.Text = " ";
            this.xrtBHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtBHXH.Weight = 0.5D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell27,
            this.xrtPhuCapCV,
            this.xrTableCell23,
            this.xrTableCell11,
            this.xrtBHYT,
            this.xrTableCell15});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrtPhuCapCV
            // 
            this.xrtPhuCapCV.Name = "xrtPhuCapCV";
            this.xrtPhuCapCV.StylePriority.UseTextAlignment = false;
            this.xrtPhuCapCV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtPhuCapCV.Weight = 0.61402920966452745D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "BHYT";
            this.xrTableCell11.Weight = 0.5D;
            // 
            // xrtBHYT
            // 
            this.xrtBHYT.Name = "xrtBHYT";
            this.xrtBHYT.StylePriority.UseTextAlignment = false;
            this.xrtBHYT.Text = " ";
            this.xrtBHYT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtBHYT.Weight = 0.5D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "Ghi chú";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell13.Weight = 0.5D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = " ";
            this.xrTableCell14.Weight = 0.5D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = " ";
            this.xrTableCell15.Weight = 0.5D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = " ";
            this.xrTableCell16.Weight = 0.5D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Stt";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 0.084441461461655626D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "1.";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell18.Weight = 0.084441469070759223D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "2.";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell19.Weight = 0.084441438634344834D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "3.";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell20.Weight = 0.084441438634344834D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "Stt";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell21.Weight = 0.13597079033547257D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "8.";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell22.Weight = 0.13597091208113D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "9.";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell23.Weight = 0.1359707903354726D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "10.";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell24.Weight = 0.1359708968629228D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Text = "LươngCB";
            this.xrTableCell26.Weight = 0.66555853092924078D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Text = "Phụ cấp CV";
            this.xrTableCell27.Weight = 0.66555856136565517D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "Phụ cấp TN";
            this.xrTableCell28.Weight = 0.66555856136565517D;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell25,
            this.xrtThucLinh,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell33});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Weight = 0.084441438634344834D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.Text = "Thực lĩnh";
            this.xrTableCell25.Weight = 0.66555856136565517D;
            // 
            // xrtThucLinh
            // 
            this.xrtThucLinh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrtThucLinh.Name = "xrtThucLinh";
            this.xrtThucLinh.StylePriority.UseFont = false;
            this.xrtThucLinh.StylePriority.UseTextAlignment = false;
            this.xrtThucLinh.Text = " ";
            this.xrtThucLinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtThucLinh.Weight = 0.61402910313707726D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Weight = 0.1359708968629228D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Weight = 0.5D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            this.xrTableCell32.Text = " ";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell32.Weight = 0.5D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Weight = 0.5D;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrtLuongSP,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrtTruLuong,
            this.xrTableCell40});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StylePriority.UseFont = false;
            this.xrTableCell34.StylePriority.UseTextAlignment = false;
            this.xrTableCell34.Text = "4.";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell34.Weight = 0.084441438634344834D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Text = "Lương SP";
            this.xrTableCell35.Weight = 0.66555856136565517D;
            // 
            // xrtLuongSP
            // 
            this.xrtLuongSP.Name = "xrtLuongSP";
            this.xrtLuongSP.StylePriority.UseTextAlignment = false;
            this.xrtLuongSP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtLuongSP.Weight = 0.61402910313707726D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseFont = false;
            this.xrTableCell37.StylePriority.UseTextAlignment = false;
            this.xrTableCell37.Text = "11.";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell37.Weight = 0.1359708968629228D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "Trừ lương";
            this.xrTableCell38.Weight = 0.5D;
            // 
            // xrtTruLuong
            // 
            this.xrtTruLuong.Name = "xrtTruLuong";
            this.xrtTruLuong.StylePriority.UseTextAlignment = false;
            this.xrtTruLuong.Text = " ";
            this.xrtTruLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtTruLuong.Weight = 0.5D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = " ";
            this.xrTableCell40.Weight = 0.5D;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrtThuong,
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrtTruTNCN,
            this.xrTableCell47});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseFont = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "5.";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell41.Weight = 0.084441438634344834D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Text = "Thưởng";
            this.xrTableCell42.Weight = 0.66555856136565517D;
            // 
            // xrtThuong
            // 
            this.xrtThuong.Name = "xrtThuong";
            this.xrtThuong.StylePriority.UseTextAlignment = false;
            this.xrtThuong.Text = " ";
            this.xrtThuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtThuong.Weight = 0.61402910313707726D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseFont = false;
            this.xrTableCell44.StylePriority.UseTextAlignment = false;
            this.xrTableCell44.Text = "12.";
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell44.Weight = 0.1359708968629228D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Text = "Trừ TNCN";
            this.xrTableCell45.Weight = 0.5D;
            // 
            // xrtTruTNCN
            // 
            this.xrtTruTNCN.Name = "xrtTruTNCN";
            this.xrtTruTNCN.StylePriority.UseTextAlignment = false;
            this.xrtTruTNCN.Text = " ";
            this.xrtTruTNCN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtTruTNCN.Weight = 0.5D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Text = " ";
            this.xrTableCell47.Weight = 0.5D;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell55,
            this.xrTableCell56,
            this.xrtChuyenCan,
            this.xrTableCell58,
            this.xrTableCell59,
            this.xrtTruTamUng,
            this.xrTableCell61});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StylePriority.UseFont = false;
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            this.xrTableCell55.Text = "6.";
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell55.Weight = 0.084441438634344834D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Text = "Chuyên cần";
            this.xrTableCell56.Weight = 0.66555856136565517D;
            // 
            // xrtChuyenCan
            // 
            this.xrtChuyenCan.Name = "xrtChuyenCan";
            this.xrtChuyenCan.StylePriority.UseTextAlignment = false;
            this.xrtChuyenCan.Text = " ";
            this.xrtChuyenCan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtChuyenCan.Weight = 0.61402910313707726D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.StylePriority.UseFont = false;
            this.xrTableCell58.StylePriority.UseTextAlignment = false;
            this.xrTableCell58.Text = "13.";
            this.xrTableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell58.Weight = 0.1359708968629228D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Text = "Trừ tạm ứng";
            this.xrTableCell59.Weight = 0.5D;
            // 
            // xrtTruTamUng
            // 
            this.xrtTruTamUng.Name = "xrtTruTamUng";
            this.xrtTruTamUng.StylePriority.UseTextAlignment = false;
            this.xrtTruTamUng.Text = " ";
            this.xrtTruTamUng.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtTruTamUng.Weight = 0.5D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.Text = " ";
            this.xrTableCell61.Weight = 0.5D;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell62,
            this.xrTableCell63,
            this.xrtTongThu,
            this.xrTableCell65,
            this.xrTableCell66,
            this.xrtTongTru,
            this.xrTableCell68});
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Weight = 0.084441438634344834D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.StylePriority.UseFont = false;
            this.xrTableCell63.Text = "Tổng thu";
            this.xrTableCell63.Weight = 0.66555856136565517D;
            // 
            // xrtTongThu
            // 
            this.xrtTongThu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrtTongThu.Name = "xrtTongThu";
            this.xrtTongThu.StylePriority.UseFont = false;
            this.xrtTongThu.StylePriority.UseTextAlignment = false;
            this.xrtTongThu.Text = " ";
            this.xrtTongThu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtTongThu.Weight = 0.61402910313707726D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Weight = 0.1359708968629228D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseFont = false;
            this.xrTableCell66.Text = "Tổng trừ";
            this.xrTableCell66.Weight = 0.5D;
            // 
            // xrtTongTru
            // 
            this.xrtTongTru.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrtTongTru.Name = "xrtTongTru";
            this.xrtTongTru.StylePriority.UseFont = false;
            this.xrtTongTru.StylePriority.UseTextAlignment = false;
            this.xrtTongTru.Text = " ";
            this.xrtTongTru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtTongTru.Weight = 0.5D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Text = " ";
            this.xrTableCell68.Weight = 0.5D;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell48,
            this.xrTableCell49,
            this.xrtLamThem,
            this.xrTableCell51,
            this.xrTableCell52,
            this.xrtTruKhac,
            this.xrTableCell54});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.StylePriority.UseFont = false;
            this.xrTableCell48.StylePriority.UseTextAlignment = false;
            this.xrTableCell48.Text = "7.";
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell48.Weight = 0.084441438634344834D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Text = "Làm thêm";
            this.xrTableCell49.Weight = 0.66555856136565517D;
            // 
            // xrtLamThem
            // 
            this.xrtLamThem.Name = "xrtLamThem";
            this.xrtLamThem.StylePriority.UseTextAlignment = false;
            this.xrtLamThem.Text = " ";
            this.xrtLamThem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtLamThem.Weight = 0.61402910313707726D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseFont = false;
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.Text = "14.";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell51.Weight = 0.1359708968629228D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Text = "Trừ khác";
            this.xrTableCell52.Weight = 0.5D;
            // 
            // xrtTruKhac
            // 
            this.xrtTruKhac.Name = "xrtTruKhac";
            this.xrtTruKhac.StylePriority.UseTextAlignment = false;
            this.xrtTruKhac.Text = " ";
            this.xrtTruKhac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrtTruKhac.Weight = 0.5D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Text = " ";
            this.xrTableCell54.Weight = 0.5D;
            // 
            // xrlTenNguoiKi1
            // 
            this.xrlTenNguoiKi1.LocationFloat = new DevExpress.Utils.PointFloat(11.04172F, 547F);
            this.xrlTenNguoiKi1.Name = "xrlTenNguoiKi1";
            this.xrlTenNguoiKi1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTenNguoiKi1.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlTenNguoiKi1.StylePriority.UseTextAlignment = false;
            this.xrlTenNguoiKi1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlTenNguoiKy3
            // 
            this.xrlTenNguoiKy3.LocationFloat = new DevExpress.Utils.PointFloat(471.1667F, 547F);
            this.xrlTenNguoiKy3.Name = "xrlTenNguoiKy3";
            this.xrlTenNguoiKy3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTenNguoiKy3.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrlTenNguoiKy3.StylePriority.UseTextAlignment = false;
            this.xrlTenNguoiKy3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlThangNam
            // 
            this.xrlThangNam.LocationFloat = new DevExpress.Utils.PointFloat(48.54167F, 100.1667F);
            this.xrlThangNam.Name = "xrlThangNam";
            this.xrlThangNam.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlThangNam.SizeF = new System.Drawing.SizeF(687.5833F, 23F);
            this.xrlThangNam.StylePriority.UseTextAlignment = false;
            this.xrlThangNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rp_Sub_PhieuTraLuongDTH
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(40, 35, 570, 0);
            this.PageHeight = 583;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
