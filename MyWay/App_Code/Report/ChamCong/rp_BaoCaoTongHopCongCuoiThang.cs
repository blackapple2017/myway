using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoTongHopCongCuoiThang
/// </summary>
public class rp_BaoCaoTongHopCongCuoiThang : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrt_phongban;
    private XRLabel xrl_TitleBC;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell grpBoPhan;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrlFT2;
    private XRLabel xrlNguoiBC2;
    private XRLabel xrlNguoiBC3;
    private XRLabel xrlNguoiBC1;
    private XRLabel xrlFT3;
    private XRLabel xrlFT1;
    private XRLabel xrtngayketxuat;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell3;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_manhanvien;
    private XRTableCell xrt_tennhanvien;
    private XRTableCell xrtGioCongDinhMuc;
    private XRTableCell xrtSoPhutDiTre;
    private XRTableCell xrtPhep;
    private XRTableCell xrtNghiVoToChuc;
    private XRTableCell xrtTongSoCaLamNgayThuong;
    private XRTableCell xrtLuong300;
    private XRTableCell xrtThoiGianLamThua;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRPageInfo xrPageInfo1;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
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
    private XRTableCell xrtSoLanDiTre;
    private XRTableCell xrtLe;
    private XRTableCell xrtCheDo;
    private XRTableCell xrtGioCongThucTe;
    private XRTableCell xrtSoLanVeSom;
    private XRTableCell xrtSoPhutVeSom;
    private XRTableCell xrtKL;
    private XRTableCell xrtNghiBu;
    private XRTableCell xrtTruGio;
    private XRTableCell xrtLuong150;
    private XRTableCell xrtLuong200;
    private XRTableCell xrtQuenQuetThe;
    private XRTableCell xrtTongSoCaLamNgayLe;
    private XRTableCell xrtTongSoCaLamNgayNghi;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private int idBangTongHopCong = 0;
    private string maDonVi = "";

    public rp_BaoCaoTongHopCongCuoiThang()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public rp_BaoCaoTongHopCongCuoiThang(int idBangTHC, string maDonVi)
    {
        idBangTongHopCong = idBangTHC;
        this.maDonVi = maDonVi;
        InitializeComponent();
    }

    int STT = 0;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        STT++;
        xrt_stt.Text = STT.ToString();
    }
    public void BindData(ReportFilterTimeKeeper rp)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("BC_ChamCong_TongHopCong", "@MaDonVi", "@MaBoPhan", "@MaChucVu", "@MaViTriCongViec", "@IDBangTongHopCong", rp.SessionDepartmentID, rp.CheckedDepartmentID == "" ? rp.ChildrenOfDepartmentID : rp.CheckedDepartmentID, rp.MaChucVu, rp.MaViTriCongViec, rp.IDDanhSachBangTongHopCong);
        if (rp.ThangBaoCao > 0 && rp.NamBaoCao > 0) xrl_TitleBC.Text = "BÁO CÁO BẢNG TỔNG HỢP CÔNG CUỐI THÁNG " + rp.ThangBaoCao + " NĂM " + rp.NamBaoCao;
        if (rp.ReportTitle != "") xrl_TitleBC.Text = rp.ReportTitle;
        //xrt_phongban.Text = new DM_DONVIController().GetNameById(dsChamCong.MA_DONVI);
        xrl_TenCongTy.Text = rp.CompanyName;
        xrl_TenThanhPho.Text = rp.CityName;
        DataSource = table;
        xrt_manhanvien.DataBindings.Add("Text", DataSource, "MA_CB");
        xrt_tennhanvien.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrtGioCongDinhMuc.DataBindings.Add("Text", DataSource, "GioCongDinhMuc");
        xrtGioCongThucTe.DataBindings.Add("Text", DataSource, "GioCongThucTe");
        xrtSoLanDiTre.DataBindings.Add("Text", DataSource, "SoLanDiTre");
        xrtSoLanVeSom.DataBindings.Add("Text", DataSource, "SoLanVeSom");
        xrtSoPhutDiTre.DataBindings.Add("Text", DataSource, "SoPhutDiTre");
        xrtSoPhutVeSom.DataBindings.Add("Text", DataSource, "SoPhutVeSom");
        xrtLe.DataBindings.Add("Text", DataSource, "NghiLe");
        xrtKL.DataBindings.Add("Text", DataSource, "NghiKhongLuong");
        xrtPhep.DataBindings.Add("Text", DataSource, "NghiPhep");
        xrtCheDo.DataBindings.Add("Text", DataSource, "NghiCheDo");
        xrtNghiBu.DataBindings.Add("Text", DataSource, "NghiBu");
        xrtNghiVoToChuc.DataBindings.Add("Text", DataSource, "NghiVoToChuc");
        xrtTruGio.DataBindings.Add("Text", DataSource, "ThoiGianRaNgoaiBiTru");
        xrtTongSoCaLamNgayThuong.DataBindings.Add("Text", DataSource, "TongCaLamViecNgayThuong");
        xrtTongSoCaLamNgayLe.DataBindings.Add("Text", DataSource, "TongCaLamViecNgayLe");
        xrtTongSoCaLamNgayNghi.DataBindings.Add("Text", DataSource, "TongCaLamViecNgayNghi");
        xrtLuong150.DataBindings.Add("Text", DataSource, "150PhanTram");
        xrtLuong200.DataBindings.Add("Text", DataSource, "200PhanTram");
        xrtLuong300.DataBindings.Add("Text", DataSource, "200PhanTram");
        xrtQuenQuetThe.DataBindings.Add("Text", DataSource, "SoLanQuenQuetThe");
        xrtThoiGianLamThua.DataBindings.Add("Text", DataSource, "TongThoiGianLamThuaGio");
        //xrl_23.DataBindings.Add("Text", DataSource, "Ngay23");
        //xrl_24.DataBindings.Add("Text", DataSource, "Ngay24");
        //xrl_25.DataBindings.Add("Text", DataSource, "Ngay25");
        //xrl_26.DataBindings.Add("Text", DataSource, "Ngay26");
        //xrl_27.DataBindings.Add("Text", DataSource, "Ngay27");
        //xrl_28.DataBindings.Add("Text", DataSource, "Ngay28");
        //xrl_29.DataBindings.Add("Text", DataSource, "Ngay29");
        //xrl_30.DataBindings.Add("Text", DataSource, "Ngay30");
        //xrl_31.DataBindings.Add("Text", DataSource, "Ngay31");
        //xrl_HL.DataBindings.Add("Text", DataSource, "HL");
        //xrl_PHEP.DataBindings.Add("Text", DataSource, "PHEP");
        //xrl_KL.DataBindings.Add("Text", DataSource, "NGH_KHONG_LUONG");
        //xrl_TONG.DataBindings.Add("Text", DataSource, "HL");

        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        grpBoPhan.DataBindings.Add("Text", DataSource, "TEN_DONVI").ToString().ToUpper();


        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        if (!string.IsNullOrEmpty(rp.Ten1)) xrlNguoiBC1.Text = rp.Ten1;
        if (!string.IsNullOrEmpty(rp.Ten2)) xrlNguoiBC2.Text = rp.Ten2;
        if (!string.IsNullOrEmpty(rp.Ten3)) xrlNguoiBC3.Text = rp.Ten3;

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
            string resourceFileName = "rp_BaoCaoTongHopCongCuoiThang.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_manhanvien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tennhanvien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtGioCongDinhMuc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtGioCongThucTe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoLanDiTre = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoLanVeSom = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoPhutDiTre = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoPhutVeSom = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtLe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtKL = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtPhep = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtCheDo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtNghiBu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtNghiVoToChuc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTruGio = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongSoCaLamNgayThuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongSoCaLamNgayLe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongSoCaLamNgayNghi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtLuong150 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtLuong200 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtLuong300 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtQuenQuetThe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtThoiGianLamThua = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlFT2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNguoiBC2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNguoiBC3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNguoiBC1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlFT3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlFT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.grpBoPhan = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1598F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_manhanvien,
            this.xrt_tennhanvien,
            this.xrtGioCongDinhMuc,
            this.xrtGioCongThucTe,
            this.xrtSoLanDiTre,
            this.xrtSoLanVeSom,
            this.xrtSoPhutDiTre,
            this.xrtSoPhutVeSom,
            this.xrtLe,
            this.xrtKL,
            this.xrtPhep,
            this.xrtCheDo,
            this.xrtNghiBu,
            this.xrtNghiVoToChuc,
            this.xrtTruGio,
            this.xrtTongSoCaLamNgayThuong,
            this.xrtTongSoCaLamNgayLe,
            this.xrtTongSoCaLamNgayNghi,
            this.xrtLuong150,
            this.xrtLuong200,
            this.xrtLuong300,
            this.xrtQuenQuetThe,
            this.xrtThoiGianLamThua});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_stt.StylePriority.UsePadding = false;
            this.xrt_stt.Weight = 0.10293068145091472D;
            this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_manhanvien
            // 
            this.xrt_manhanvien.Name = "xrt_manhanvien";
            this.xrt_manhanvien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_manhanvien.StylePriority.UsePadding = false;
            this.xrt_manhanvien.StylePriority.UseTextAlignment = false;
            this.xrt_manhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_manhanvien.Weight = 0.25319365922193732D;
            // 
            // xrt_tennhanvien
            // 
            this.xrt_tennhanvien.Name = "xrt_tennhanvien";
            this.xrt_tennhanvien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_tennhanvien.StylePriority.UsePadding = false;
            this.xrt_tennhanvien.StylePriority.UseTextAlignment = false;
            this.xrt_tennhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_tennhanvien.Weight = 0.34775039160580323D;
            // 
            // xrtGioCongDinhMuc
            // 
            this.xrtGioCongDinhMuc.Multiline = true;
            this.xrtGioCongDinhMuc.Name = "xrtGioCongDinhMuc";
            this.xrtGioCongDinhMuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtGioCongDinhMuc.StylePriority.UsePadding = false;
            this.xrtGioCongDinhMuc.StylePriority.UseTextAlignment = false;
            this.xrtGioCongDinhMuc.Text = "\r\n";
            this.xrtGioCongDinhMuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtGioCongDinhMuc.Weight = 0.13019661755340573D;
            // 
            // xrtGioCongThucTe
            // 
            this.xrtGioCongThucTe.Name = "xrtGioCongThucTe";
            this.xrtGioCongThucTe.Weight = 0.13187320771160618D;
            // 
            // xrtSoLanDiTre
            // 
            this.xrtSoLanDiTre.Name = "xrtSoLanDiTre";
            this.xrtSoLanDiTre.Weight = 0.10803819348299508D;
            // 
            // xrtSoLanVeSom
            // 
            this.xrtSoLanVeSom.Name = "xrtSoLanVeSom";
            this.xrtSoLanVeSom.Weight = 0.1241656156818535D;
            // 
            // xrtSoPhutDiTre
            // 
            this.xrtSoPhutDiTre.Name = "xrtSoPhutDiTre";
            this.xrtSoPhutDiTre.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtSoPhutDiTre.StylePriority.UsePadding = false;
            this.xrtSoPhutDiTre.StylePriority.UseTextAlignment = false;
            this.xrtSoPhutDiTre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoPhutDiTre.Weight = 0.13139610697185522D;
            // 
            // xrtSoPhutVeSom
            // 
            this.xrtSoPhutVeSom.Name = "xrtSoPhutVeSom";
            this.xrtSoPhutVeSom.Weight = 0.12030141536161565D;
            // 
            // xrtLe
            // 
            this.xrtLe.Name = "xrtLe";
            this.xrtLe.Weight = 0.10253784771813911D;
            // 
            // xrtKL
            // 
            this.xrtKL.Name = "xrtKL";
            this.xrtKL.Weight = 0.099648589607021471D;
            // 
            // xrtPhep
            // 
            this.xrtPhep.Multiline = true;
            this.xrtPhep.Name = "xrtPhep";
            this.xrtPhep.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtPhep.StylePriority.UsePadding = false;
            this.xrtPhep.Text = "\r\n";
            this.xrtPhep.Weight = 0.11644170353159863D;
            // 
            // xrtCheDo
            // 
            this.xrtCheDo.Name = "xrtCheDo";
            this.xrtCheDo.Weight = 0.10534688934777312D;
            // 
            // xrtNghiBu
            // 
            this.xrtNghiBu.Name = "xrtNghiBu";
            this.xrtNghiBu.Weight = 0.10016736386499825D;
            // 
            // xrtNghiVoToChuc
            // 
            this.xrtNghiVoToChuc.Multiline = true;
            this.xrtNghiVoToChuc.Name = "xrtNghiVoToChuc";
            this.xrtNghiVoToChuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtNghiVoToChuc.StylePriority.UsePadding = false;
            this.xrtNghiVoToChuc.Text = "\r\n";
            this.xrtNghiVoToChuc.Weight = 0.12827814725220058D;
            // 
            // xrtTruGio
            // 
            this.xrtTruGio.Name = "xrtTruGio";
            this.xrtTruGio.Weight = 0.10185603437077398D;
            // 
            // xrtTongSoCaLamNgayThuong
            // 
            this.xrtTongSoCaLamNgayThuong.Multiline = true;
            this.xrtTongSoCaLamNgayThuong.Name = "xrtTongSoCaLamNgayThuong";
            this.xrtTongSoCaLamNgayThuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtTongSoCaLamNgayThuong.StylePriority.UsePadding = false;
            this.xrtTongSoCaLamNgayThuong.Text = "\r\n";
            this.xrtTongSoCaLamNgayThuong.Weight = 0.19061406434717415D;
            // 
            // xrtTongSoCaLamNgayLe
            // 
            this.xrtTongSoCaLamNgayLe.Name = "xrtTongSoCaLamNgayLe";
            this.xrtTongSoCaLamNgayLe.Weight = 0.13029251954124105D;
            // 
            // xrtTongSoCaLamNgayNghi
            // 
            this.xrtTongSoCaLamNgayNghi.Name = "xrtTongSoCaLamNgayNghi";
            this.xrtTongSoCaLamNgayNghi.Weight = 0.15057713129757869D;
            // 
            // xrtLuong150
            // 
            this.xrtLuong150.Name = "xrtLuong150";
            this.xrtLuong150.Weight = 0.12383972714841682D;
            // 
            // xrtLuong200
            // 
            this.xrtLuong200.Name = "xrtLuong200";
            this.xrtLuong200.Weight = 0.13927805765929249D;
            // 
            // xrtLuong300
            // 
            this.xrtLuong300.Multiline = true;
            this.xrtLuong300.Name = "xrtLuong300";
            this.xrtLuong300.Text = "\r\n";
            this.xrtLuong300.Weight = 0.12170486874811747D;
            // 
            // xrtQuenQuetThe
            // 
            this.xrtQuenQuetThe.Name = "xrtQuenQuetThe";
            this.xrtQuenQuetThe.Weight = 0.17182618757957008D;
            // 
            // xrtThoiGianLamThua
            // 
            this.xrtThoiGianLamThua.Name = "xrtThoiGianLamThua";
            this.xrtThoiGianLamThua.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrtThoiGianLamThua.StylePriority.UsePadding = false;
            this.xrtThoiGianLamThua.StylePriority.UseTextAlignment = false;
            this.xrtThoiGianLamThua.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtThoiGianLamThua.Weight = 0.17182618757957008D;
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
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5,
            this.xrl_TitleBC,
            this.xrLabel1,
            this.xrLabel2,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 135.4167F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110.4167F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(1598F, 24.99999F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_phongban});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_phongban.StylePriority.UseFont = false;
            this.xrt_phongban.StylePriority.UsePadding = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_phongban.Weight = 3.9872768136147307D;
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.41665F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1598F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BẢNG TỔNG HỢP CÔNG CUỐI THÁNG";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1115.625F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(451.0416F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1115.625F, 35.00001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(451.0417F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Độc lập - Tự do - Hạnh phúc";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(53.125F, 10.00001F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(451.0416F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(53.125F, 35.00001F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(451.0417F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 68.00001F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1598F, 68.00001F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell11,
            this.xrTableCell6,
            this.xrTableCell12,
            this.xrTableCell9,
            this.xrTableCell15,
            this.xrTableCell7,
            this.xrTableCell13,
            this.xrTableCell18,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell10,
            this.xrTableCell14,
            this.xrTableCell8,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell24,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.Weight = 0.15867718446601944D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Mã cán bộ";
            this.xrTableCell5.Weight = 0.39032159268277361D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Tên cán bộ";
            this.xrTableCell1.Weight = 0.53608940804872685D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Giờ công định mức";
            this.xrTableCell2.Weight = 0.20071018451447764D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Giờ công thực tế";
            this.xrTableCell11.Weight = 0.2032947789568566D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Số lần đi trễ";
            this.xrTableCell6.Weight = 0.16655050329762017D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Số lần về sớm";
            this.xrTableCell12.Weight = 0.19141321670108039D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Số phút đi trễ";
            this.xrTableCell9.Weight = 0.2025592769192951D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Số phút về sớm";
            this.xrTableCell15.Weight = 0.18545580923391891D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.Text = "Nghỉ lễ";
            this.xrTableCell7.Weight = 0.15807162051139467D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "Nghỉ KL";
            this.xrTableCell13.Weight = 0.1536175602664982D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "Nghỉ phép";
            this.xrTableCell18.Weight = 0.17950552435530665D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Nghỉ chế độ";
            this.xrTableCell16.Weight = 0.16240218194161005D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Nghỉ bù";
            this.xrTableCell17.Weight = 0.15441726486753871D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Nghỉ vô tổ chức";
            this.xrTableCell10.Weight = 0.19775264731228326D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Trừ giờ";
            this.xrTableCell14.Weight = 0.15702008941003376D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Tổng số ca làm ngày thường";
            this.xrTableCell8.Weight = 0.29384968491390123D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "Tổng số ca làm ngày lễ";
            this.xrTableCell22.Weight = 0.20085799666288676D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Text = "Tổng số ca làm ngày nghỉ";
            this.xrTableCell23.Weight = 0.23212821746959994D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "Lương 150%";
            this.xrTableCell19.Weight = 0.19091082836592951D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "Lương 200%";
            this.xrTableCell20.Weight = 0.21470963703526791D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "Lương 300%";
            this.xrTableCell21.Weight = 0.18761931498484202D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "Quên quẹt thẻ";
            this.xrTableCell24.Weight = 0.26488635046751596D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Thời gian làm thừa";
            this.xrTableCell3.Weight = 0.26488635046751596D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlFT2,
            this.xrlNguoiBC2,
            this.xrlNguoiBC3,
            this.xrlNguoiBC1,
            this.xrlFT3,
            this.xrlFT1,
            this.xrtngayketxuat});
            this.ReportFooter.HeightF = 195.9167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrlFT2
            // 
            this.xrlFT2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlFT2.LocationFloat = new DevExpress.Utils.PointFloat(622.4794F, 45.83333F);
            this.xrlFT2.Name = "xrlFT2";
            this.xrlFT2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlFT2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlFT2.StylePriority.UseFont = false;
            this.xrlFT2.StylePriority.UseTextAlignment = false;
            this.xrlFT2.Text = "PHÒNG HCNS";
            this.xrlFT2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlNguoiBC2
            // 
            this.xrlNguoiBC2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlNguoiBC2.LocationFloat = new DevExpress.Utils.PointFloat(622.4794F, 170.8333F);
            this.xrlNguoiBC2.Name = "xrlNguoiBC2";
            this.xrlNguoiBC2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNguoiBC2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlNguoiBC2.StylePriority.UseFont = false;
            this.xrlNguoiBC2.StylePriority.UseTextAlignment = false;
            this.xrlNguoiBC2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlNguoiBC3
            // 
            this.xrlNguoiBC3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlNguoiBC3.LocationFloat = new DevExpress.Utils.PointFloat(1253.108F, 170.8333F);
            this.xrlNguoiBC3.Name = "xrlNguoiBC3";
            this.xrlNguoiBC3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNguoiBC3.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlNguoiBC3.StylePriority.UseFont = false;
            this.xrlNguoiBC3.StylePriority.UseTextAlignment = false;
            this.xrlNguoiBC3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlNguoiBC1
            // 
            this.xrlNguoiBC1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlNguoiBC1.LocationFloat = new DevExpress.Utils.PointFloat(48.31942F, 170.8333F);
            this.xrlNguoiBC1.Name = "xrlNguoiBC1";
            this.xrlNguoiBC1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNguoiBC1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlNguoiBC1.StylePriority.UseFont = false;
            this.xrlNguoiBC1.StylePriority.UseTextAlignment = false;
            this.xrlNguoiBC1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlFT3
            // 
            this.xrlFT3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlFT3.LocationFloat = new DevExpress.Utils.PointFloat(1256.027F, 47.91667F);
            this.xrlFT3.Name = "xrlFT3";
            this.xrlFT3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlFT3.SizeF = new System.Drawing.SizeF(301.2634F, 23F);
            this.xrlFT3.StylePriority.UseFont = false;
            this.xrlFT3.StylePriority.UseTextAlignment = false;
            this.xrlFT3.Text = "GIÁM ĐỐC";
            this.xrlFT3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlFT1
            // 
            this.xrlFT1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlFT1.LocationFloat = new DevExpress.Utils.PointFloat(48.31942F, 45.83333F);
            this.xrlFT1.Name = "xrlFT1";
            this.xrlFT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlFT1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrlFT1.StylePriority.UseFont = false;
            this.xrlFT1.StylePriority.UseTextAlignment = false;
            this.xrlFT1.Text = "NGƯỜI LẬP";
            this.xrlFT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1256.027F, 22.91667F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(303.2632F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1461.959F, 35.41667F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0414F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTable8
            // 
            this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable8.SizeF = new System.Drawing.SizeF(1598F, 25.42F);
            this.xrTable8.StylePriority.UseBorders = false;
            this.xrTable8.StylePriority.UseFont = false;
            this.xrTable8.StylePriority.UsePadding = false;
            this.xrTable8.StylePriority.UseTextAlignment = false;
            this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.grpBoPhan});
            this.xrTableRow8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.StylePriority.UseFont = false;
            this.xrTableRow8.StylePriority.UseTextAlignment = false;
            this.xrTableRow8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow8.Weight = 1D;
            // 
            // grpBoPhan
            // 
            this.grpBoPhan.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.grpBoPhan.Name = "grpBoPhan";
            this.grpBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
            this.grpBoPhan.StylePriority.UseFont = false;
            this.grpBoPhan.StylePriority.UsePadding = false;
            this.grpBoPhan.StylePriority.UseTextAlignment = false;
            this.grpBoPhan.Text = "Không thuộc phòng ban nào";
            this.grpBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.grpBoPhan.Weight = 10.829994588379142D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
            this.GroupHeader1.HeightF = 25.42F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // rp_BaoCaoTongHopCongCuoiThang
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter,
            this.GroupHeader1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(26, 30, 49, 0);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}