using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_PhieuTraLuong
/// </summary>
public class rp_PhieuTraLuong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrt_luongcoban;
    private XRTableCell xrTableCell8;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrt_cackhoanthu;
    private XRTableCell xrTableCell12;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrt_thoigianthang;
    private XRTableCell xrTableCell16;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrt_ngayconthucte;
    private XRTableCell xrTableCell20;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrt_ngayconghuongluongthoigian;
    private XRTableCell xrTableCell24;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrt_ngayletetnghihuongluong;
    private XRTableCell xrTableCell28;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrt_ngaynghiphep;
    private XRTableCell xrTableCell32;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrt_tongngaycongtinhluongtg;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrt_luongthoigian;
    private XRTableCell xrTableCell40;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrt_luongthemgio;
    private XRTableCell xrTableCell44;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrt_giolamthem1;
    private XRTableCell xrTableCell48;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrt_giolamthem2;
    private XRTableCell xrTableCell52;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrt_giolamthem3;
    private XRTableCell xrTableCell56;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrt_luongthemgiotructiep;
    private XRTableCell xrTableCell60;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrt_luongsanpham;
    private XRTableCell xrTableCell64;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrt_sanphamdoanhthu;
    private XRTableCell xrTableCell68;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTableCell xrt_sanpham35;
    private XRTableCell xrTableCell72;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrt_sanpham53;
    private XRTableCell xrTableCell76;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrt_sanphamthem5;
    private XRTableCell xrTableCell80;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrt_phucapgiamtru;
    private XRTableCell xrTableCell84;
    private XRTableRow xrTableRow22;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrt_tylehuongluong;
    private XRTableCell xrTableCell88;
    private XRTableRow xrTableRow23;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrt_tongthunhap;
    private XRTableCell xrTableCell92;
    private XRTableRow xrTableRow24;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrt_khoankhautru;
    private XRTableCell xrTableCell96;
    private XRTableRow xrTableRow25;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrt_baohiemyte;
    private XRTableCell xrTableCell100;
    private XRTableRow xrTableRow26;
    private XRTableCell xrTableCell101;
    private XRTableCell xrt_b;
    private XRTableCell xrt_bhxh_bhtn;
    private XRTableCell xrTableCell104;
    private XRTableRow xrTableRow27;
    private XRTableCell xrTableCell105;
    private XRTableCell xrTableCell106;
    private XRTableCell xrt_thuethunhap;
    private XRTableCell xrTableCell108;
    private XRTableRow xrTableRow28;
    private XRTableCell xrTableCell109;
    private XRTableCell xrTableCell110;
    private XRTableCell xrt_trukhachoacchuathanhtoan;
    private XRTableCell xrTableCell112;
    private XRTableRow xrTableRow29;
    private XRTableCell xrTableCell113;
    private XRTableCell xrTableCell114;
    private XRTableCell xrt_traky1;
    private XRTableCell xrTableCell116;
    private XRTableRow xrTableRow30;
    private XRTableCell xrTableCell117;
    private XRTableCell xrTableCell118;
    private XRTableCell xrt_traky2;
    private XRTableCell xrTableCell120;
    private XRLabel xrl_code;
    private XRTable xrTable2;
    private XRTableRow xrTableRow31;
    private XRTableCell xrt_BHXH;
    private XRTableCell xrtBHTN;
    private XRLabel xrl_hoten;
    private XRLabel xrl_bophan;
    private XRLabel xrl_chucvu;
    private XRLabel xrlNDchucvu;
    private XRLabel xrlNDbophan;
    private XRLabel xrlNDhoten;
    private XRLabel xrlMa;
    private PageFooterBand PageFooter;
    private XRLabel xrl_nguoinhantien;
    private XRLabel xrl_chukynguoinhantien;
    private XRLabel xrl_chukythuquy;
    private XRLabel xrl_thuquy;
    private XRLabel xrLabel3;
    private XRLabel xrl_ngayketxuat;
    private PageHeaderBand PageHeader;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_tenbaocao;
    private XRLabel xrl_ThangTraLuong;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_PhieuTraLuong()
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

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_PhieuTraLuong.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrlMa = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNDhoten = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNDbophan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNDchucvu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_luongcoban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_cackhoanthu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thoigianthang = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayconthucte = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayconghuongluongthoigian = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngayletetnghihuongluong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngaynghiphep = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongngaycongtinhluongtg = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_luongthoigian = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_luongthemgio = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_giolamthem1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_giolamthem2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_giolamthem3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_luongthemgiotructiep = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_luongsanpham = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sanphamdoanhthu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sanpham35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sanpham53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_sanphamthem5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_phucapgiamtru = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tylehuongluong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongthunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_khoankhautru = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_baohiemyte = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_b = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_bhxh_bhtn = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow31 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_BHXH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtBHTN = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuethunhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_trukhachoacchuathanhtoan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow29 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_traky1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell116 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_traky2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrl_chucvu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_hoten = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_code = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_bophan = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrl_thuquy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_nguoinhantien = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_chukynguoinhantien = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_chukythuquy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrl_tenbaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ThangTraLuong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlMa,
            this.xrlNDhoten,
            this.xrlNDbophan,
            this.xrlNDchucvu,
            this.xrTable1,
            this.xrl_chucvu,
            this.xrl_hoten,
            this.xrl_code,
            this.xrl_bophan});
            this.Detail.HeightF = 799F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrlMa
            // 
            this.xrlMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrlMa.LocationFloat = new DevExpress.Utils.PointFloat(490.75F, 0F);
            this.xrlMa.Name = "xrlMa";
            this.xrlMa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlMa.SizeF = new System.Drawing.SizeF(231.25F, 23.00001F);
            this.xrlMa.StylePriority.UseFont = false;
            // 
            // xrlNDhoten
            // 
            this.xrlNDhoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrlNDhoten.LocationFloat = new DevExpress.Utils.PointFloat(154.1667F, 0F);
            this.xrlNDhoten.Name = "xrlNDhoten";
            this.xrlNDhoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNDhoten.SizeF = new System.Drawing.SizeF(271.25F, 23F);
            this.xrlNDhoten.StylePriority.UseFont = false;
            // 
            // xrlNDbophan
            // 
            this.xrlNDbophan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrlNDbophan.LocationFloat = new DevExpress.Utils.PointFloat(530.7288F, 22.99999F);
            this.xrlNDbophan.Name = "xrlNDbophan";
            this.xrlNDbophan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNDbophan.SizeF = new System.Drawing.SizeF(191.2708F, 23.00001F);
            this.xrlNDbophan.StylePriority.UseFont = false;
            // 
            // xrlNDchucvu
            // 
            this.xrlNDchucvu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrlNDchucvu.LocationFloat = new DevExpress.Utils.PointFloat(154.1667F, 22.99999F);
            this.xrlNDchucvu.Name = "xrlNDchucvu";
            this.xrlNDchucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNDchucvu.SizeF = new System.Drawing.SizeF(196.9997F, 23F);
            this.xrlNDchucvu.StylePriority.UseFont = false;
            // 
            // xrTable1
            // 
            this.xrTable1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46.00003F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 2, 2, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.xrTableRow3,
            this.xrTableRow4,
            this.xrTableRow5,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow8,
            this.xrTableRow9,
            this.xrTableRow10,
            this.xrTableRow11,
            this.xrTableRow12,
            this.xrTableRow13,
            this.xrTableRow14,
            this.xrTableRow15,
            this.xrTableRow16,
            this.xrTableRow17,
            this.xrTableRow18,
            this.xrTableRow19,
            this.xrTableRow20,
            this.xrTableRow21,
            this.xrTableRow22,
            this.xrTableRow23,
            this.xrTableRow24,
            this.xrTableRow25,
            this.xrTableRow26,
            this.xrTableRow27,
            this.xrTableRow28,
            this.xrTableRow29,
            this.xrTableRow30});
            this.xrTable1.SizeF = new System.Drawing.SizeF(721.9996F, 750F);
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "No";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 0.25850339305644132D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Diễn giải / Description";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 1.8843537498007015D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Thành tiền / Amount(đ)";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 1.2142857142857142D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "R / Ghi chú";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 1.3579591836734695D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrt_luongcoban,
            this.xrTableCell8});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.Weight = 0.25850341796875D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.Text = "Lương cơ bản / Basic salary";
            this.xrTableCell6.Weight = 1.8843537248883928D;
            // 
            // xrt_luongcoban
            // 
            this.xrt_luongcoban.Name = "xrt_luongcoban";
            this.xrt_luongcoban.StylePriority.UseBorders = false;
            this.xrt_luongcoban.StylePriority.UseTextAlignment = false;
            this.xrt_luongcoban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_luongcoban.Weight = 1.2142857142857142D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.Weight = 1.3579591836734695D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrt_cackhoanthu,
            this.xrTableCell12});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.Weight = 0.25850341796875D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.Text = "Các khoản thu / Receipt from";
            this.xrTableCell10.Weight = 1.8843537248883928D;
            // 
            // xrt_cackhoanthu
            // 
            this.xrt_cackhoanthu.Name = "xrt_cackhoanthu";
            this.xrt_cackhoanthu.StylePriority.UseTextAlignment = false;
            this.xrt_cackhoanthu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_cackhoanthu.Weight = 1.2142857142857142D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.Weight = 1.3579591836734695D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrt_thoigianthang,
            this.xrTableCell16});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "1";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell13.Weight = 0.25850344288105864D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.Text = "Thời gian trong tháng";
            this.xrTableCell14.Weight = 1.8843536999760842D;
            // 
            // xrt_thoigianthang
            // 
            this.xrt_thoigianthang.Name = "xrt_thoigianthang";
            this.xrt_thoigianthang.StylePriority.UseBorders = false;
            this.xrt_thoigianthang.StylePriority.UseTextAlignment = false;
            this.xrt_thoigianthang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_thoigianthang.Weight = 1.2142857142857142D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.Weight = 1.3579591836734695D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrt_ngayconthucte,
            this.xrTableCell20});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.Weight = 0.25850341796875D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.Text = "- Ngày công làm việc thực tế";
            this.xrTableCell18.Weight = 1.8843537248883928D;
            // 
            // xrt_ngayconthucte
            // 
            this.xrt_ngayconthucte.Name = "xrt_ngayconthucte";
            this.xrt_ngayconthucte.StylePriority.UseBorders = false;
            this.xrt_ngayconthucte.StylePriority.UseTextAlignment = false;
            this.xrt_ngayconthucte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_ngayconthucte.Weight = 1.2142857142857142D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.Weight = 1.3579591836734695D;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrt_ngayconghuongluongthoigian,
            this.xrTableCell24});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.Weight = 0.25850339305644132D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.Text = "- Ngày công hưởng lương thời gian";
            this.xrTableCell22.Weight = 1.8843537498007015D;
            // 
            // xrt_ngayconghuongluongthoigian
            // 
            this.xrt_ngayconghuongluongthoigian.Name = "xrt_ngayconghuongluongthoigian";
            this.xrt_ngayconghuongluongthoigian.StylePriority.UseBorders = false;
            this.xrt_ngayconghuongluongthoigian.StylePriority.UseTextAlignment = false;
            this.xrt_ngayconghuongluongthoigian.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_ngayconghuongluongthoigian.Weight = 1.2142857142857142D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.Weight = 1.3579591836734695D;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrt_ngayletetnghihuongluong,
            this.xrTableCell28});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.Weight = 0.25850339305644132D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.Text = "- Ngày lễ, tết, nghỉ hưởng lương";
            this.xrTableCell26.Weight = 1.8843537498007015D;
            // 
            // xrt_ngayletetnghihuongluong
            // 
            this.xrt_ngayletetnghihuongluong.Name = "xrt_ngayletetnghihuongluong";
            this.xrt_ngayletetnghihuongluong.StylePriority.UseBorders = false;
            this.xrt_ngayletetnghihuongluong.StylePriority.UseTextAlignment = false;
            this.xrt_ngayletetnghihuongluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_ngayletetnghihuongluong.Weight = 1.2142857142857142D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.Weight = 1.3579591836734695D;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrt_ngaynghiphep,
            this.xrTableCell32});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseBorders = false;
            this.xrTableCell29.Weight = 0.25850339305644132D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseBorders = false;
            this.xrTableCell30.Text = "- Ngày nghỉ phép";
            this.xrTableCell30.Weight = 1.8843537498007015D;
            // 
            // xrt_ngaynghiphep
            // 
            this.xrt_ngaynghiphep.Name = "xrt_ngaynghiphep";
            this.xrt_ngaynghiphep.StylePriority.UseBorders = false;
            this.xrt_ngaynghiphep.StylePriority.UseTextAlignment = false;
            this.xrt_ngaynghiphep.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_ngaynghiphep.Weight = 1.2142857142857142D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.Weight = 1.3579591836734695D;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrt_tongngaycongtinhluongtg,
            this.xrTableCell36});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseBorders = false;
            this.xrTableCell33.Weight = 0.25850344288105864D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StylePriority.UseBorders = false;
            this.xrTableCell34.Text = "- Tổng ngày công tính lương TG";
            this.xrTableCell34.Weight = 1.8843536999760842D;
            // 
            // xrt_tongngaycongtinhluongtg
            // 
            this.xrt_tongngaycongtinhluongtg.Name = "xrt_tongngaycongtinhluongtg";
            this.xrt_tongngaycongtinhluongtg.StylePriority.UseBorders = false;
            this.xrt_tongngaycongtinhluongtg.StylePriority.UseTextAlignment = false;
            this.xrt_tongngaycongtinhluongtg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_tongngaycongtinhluongtg.Weight = 1.2142857142857142D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseBorders = false;
            this.xrTableCell36.Weight = 1.3579591836734695D;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrt_luongthoigian,
            this.xrTableCell40});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.StylePriority.UseBorders = false;
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseTextAlignment = false;
            this.xrTableCell37.Text = "2";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell37.Weight = 0.25850344288105864D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StylePriority.UseBorders = false;
            this.xrTableCell38.Text = "Lương thời gian    Work salary";
            this.xrTableCell38.Weight = 1.8843536999760842D;
            // 
            // xrt_luongthoigian
            // 
            this.xrt_luongthoigian.Name = "xrt_luongthoigian";
            this.xrt_luongthoigian.StylePriority.UseBorders = false;
            this.xrt_luongthoigian.StylePriority.UseTextAlignment = false;
            this.xrt_luongthoigian.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_luongthoigian.Weight = 1.2142857142857142D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.StylePriority.UseBorders = false;
            this.xrTableCell40.Weight = 1.3579591836734695D;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrt_luongthemgio,
            this.xrTableCell44});
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "3";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell41.Weight = 0.25850344288105864D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.Text = "Lương thêm giờ     Overtime salary";
            this.xrTableCell42.Weight = 1.8843536999760842D;
            // 
            // xrt_luongthemgio
            // 
            this.xrt_luongthemgio.Name = "xrt_luongthemgio";
            this.xrt_luongthemgio.StylePriority.UseBorders = false;
            this.xrt_luongthemgio.StylePriority.UseTextAlignment = false;
            this.xrt_luongthemgio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_luongthemgio.Weight = 1.2142857142857142D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.Weight = 1.3579591836734695D;
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrt_giolamthem1,
            this.xrTableCell48});
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Weight = 0.25850344288105864D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Text = "- Giờ làm thêm      Overtime(h)1.5";
            this.xrTableCell46.Weight = 1.8843536999760842D;
            // 
            // xrt_giolamthem1
            // 
            this.xrt_giolamthem1.Name = "xrt_giolamthem1";
            this.xrt_giolamthem1.StylePriority.UseTextAlignment = false;
            this.xrt_giolamthem1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_giolamthem1.Weight = 1.2142857142857142D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Weight = 1.3579591836734695D;
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49,
            this.xrTableCell50,
            this.xrt_giolamthem2,
            this.xrTableCell52});
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Weight = 0.25850344288105864D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Text = "- Giờ làm thêm      Overtime(h)2.0";
            this.xrTableCell50.Weight = 1.8843536999760842D;
            // 
            // xrt_giolamthem2
            // 
            this.xrt_giolamthem2.Name = "xrt_giolamthem2";
            this.xrt_giolamthem2.StylePriority.UseTextAlignment = false;
            this.xrt_giolamthem2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_giolamthem2.Weight = 1.2142857142857142D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Weight = 1.3579591836734695D;
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrt_giolamthem3,
            this.xrTableCell56});
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Weight = 1D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Weight = 0.2585034677933673D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Text = "- Giờ làm thêm      Overtime(h)3.0";
            this.xrTableCell54.Weight = 1.8843536750637755D;
            // 
            // xrt_giolamthem3
            // 
            this.xrt_giolamthem3.Name = "xrt_giolamthem3";
            this.xrt_giolamthem3.StylePriority.UseTextAlignment = false;
            this.xrt_giolamthem3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_giolamthem3.Weight = 1.2142857142857142D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Weight = 1.3579591836734695D;
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell57,
            this.xrTableCell58,
            this.xrt_luongthemgiotructiep,
            this.xrTableCell60});
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Weight = 1D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.StylePriority.UseTextAlignment = false;
            this.xrTableCell57.Text = "4";
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell57.Weight = 0.2585034677933673D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Text = "Lương thêm giờ trực tiếp";
            this.xrTableCell58.Weight = 1.8843536750637755D;
            // 
            // xrt_luongthemgiotructiep
            // 
            this.xrt_luongthemgiotructiep.Name = "xrt_luongthemgiotructiep";
            this.xrt_luongthemgiotructiep.StylePriority.UseTextAlignment = false;
            this.xrt_luongthemgiotructiep.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_luongthemgiotructiep.Weight = 1.2142857142857142D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Weight = 1.3579591836734695D;
            // 
            // xrTableRow16
            // 
            this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrt_luongsanpham,
            this.xrTableCell64});
            this.xrTableRow16.Name = "xrTableRow16";
            this.xrTableRow16.Weight = 1D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.StylePriority.UseTextAlignment = false;
            this.xrTableCell61.Text = "5";
            this.xrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell61.Weight = 0.25850351761798462D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Text = "Lương sản phẩm    Product salary";
            this.xrTableCell62.Weight = 1.884353625239158D;
            // 
            // xrt_luongsanpham
            // 
            this.xrt_luongsanpham.Name = "xrt_luongsanpham";
            this.xrt_luongsanpham.StylePriority.UseTextAlignment = false;
            this.xrt_luongsanpham.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_luongsanpham.Weight = 1.2142857142857142D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Weight = 1.3579591836734695D;
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell65,
            this.xrTableCell66,
            this.xrt_sanphamdoanhthu,
            this.xrTableCell68});
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Weight = 1D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Weight = 0.25850354253029334D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Text = "Sản phẩm, doanh thu   Product, sales";
            this.xrTableCell66.Weight = 1.8843536003268493D;
            // 
            // xrt_sanphamdoanhthu
            // 
            this.xrt_sanphamdoanhthu.Name = "xrt_sanphamdoanhthu";
            this.xrt_sanphamdoanhthu.StylePriority.UseTextAlignment = false;
            this.xrt_sanphamdoanhthu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_sanphamdoanhthu.Weight = 1.2142857142857142D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Weight = 1.3579591836734695D;
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell69,
            this.xrTableCell70,
            this.xrt_sanpham35,
            this.xrTableCell72});
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Weight = 1D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Weight = 0.258503567442602D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.Text = "- Sản phẩm 35%        Product 35%";
            this.xrTableCell70.Weight = 1.8843535754145406D;
            // 
            // xrt_sanpham35
            // 
            this.xrt_sanpham35.Name = "xrt_sanpham35";
            this.xrt_sanpham35.StylePriority.UseTextAlignment = false;
            this.xrt_sanpham35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_sanpham35.Weight = 1.2142857142857142D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Weight = 1.3579591836734695D;
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrt_sanpham53,
            this.xrTableCell76});
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Weight = 1D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.Weight = 0.25850359235491066D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Text = "- Sản phẩm 53%       Product 53%";
            this.xrTableCell74.Weight = 1.884353550502232D;
            // 
            // xrt_sanpham53
            // 
            this.xrt_sanpham53.Name = "xrt_sanpham53";
            this.xrt_sanpham53.StylePriority.UseTextAlignment = false;
            this.xrt_sanpham53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_sanpham53.Weight = 1.2142857142857142D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.Weight = 1.3579591836734695D;
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrt_sanphamthem5,
            this.xrTableCell80});
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Weight = 1D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Weight = 0.25850361726721938D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Text = "- Sản phẩm thêm 5%     Product 5%";
            this.xrTableCell78.Weight = 1.8843535255899233D;
            // 
            // xrt_sanphamthem5
            // 
            this.xrt_sanphamthem5.Name = "xrt_sanphamthem5";
            this.xrt_sanphamthem5.StylePriority.UseTextAlignment = false;
            this.xrt_sanphamthem5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_sanphamthem5.Weight = 1.2142857142857142D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.Weight = 1.3579591836734695D;
            // 
            // xrTableRow21
            // 
            this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell81,
            this.xrTableCell82,
            this.xrt_phucapgiamtru,
            this.xrTableCell84});
            this.xrTableRow21.Name = "xrTableRow21";
            this.xrTableRow21.Weight = 1D;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.StylePriority.UseTextAlignment = false;
            this.xrTableCell81.Text = "6";
            this.xrTableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell81.Weight = 0.25850364217952804D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.Text = "Phụ cấp (+), Giảm trừ(-) / Allow";
            this.xrTableCell82.Weight = 1.8843535006776147D;
            // 
            // xrt_phucapgiamtru
            // 
            this.xrt_phucapgiamtru.Name = "xrt_phucapgiamtru";
            this.xrt_phucapgiamtru.StylePriority.UseTextAlignment = false;
            this.xrt_phucapgiamtru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_phucapgiamtru.Weight = 1.2142857142857142D;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.Weight = 1.3579591836734695D;
            // 
            // xrTableRow22
            // 
            this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell85,
            this.xrTableCell86,
            this.xrt_tylehuongluong,
            this.xrTableCell88});
            this.xrTableRow22.Name = "xrTableRow22";
            this.xrTableRow22.Weight = 1D;
            // 
            // xrTableCell85
            // 
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.Weight = 0.2585036670918367D;
            // 
            // xrTableCell86
            // 
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.Text = "Tỷ lệ hưởng lương     Rate";
            this.xrTableCell86.Weight = 1.884353475765306D;
            // 
            // xrt_tylehuongluong
            // 
            this.xrt_tylehuongluong.Name = "xrt_tylehuongluong";
            this.xrt_tylehuongluong.StylePriority.UseTextAlignment = false;
            this.xrt_tylehuongluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_tylehuongluong.Weight = 1.2142857142857142D;
            // 
            // xrTableCell88
            // 
            this.xrTableCell88.Name = "xrTableCell88";
            this.xrTableCell88.Weight = 1.3579591836734695D;
            // 
            // xrTableRow23
            // 
            this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrt_tongthunhap,
            this.xrTableCell92});
            this.xrTableRow23.Name = "xrTableRow23";
            this.xrTableRow23.Weight = 1D;
            // 
            // xrTableCell89
            // 
            this.xrTableCell89.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.StylePriority.UseFont = false;
            this.xrTableCell89.StylePriority.UseTextAlignment = false;
            this.xrTableCell89.Text = "7";
            this.xrTableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell89.Weight = 0.25850369200414536D;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.StylePriority.UseFont = false;
            this.xrTableCell90.Text = "Tổng thu nhập     Cross salary";
            this.xrTableCell90.Weight = 1.8843534508529973D;
            // 
            // xrt_tongthunhap
            // 
            this.xrt_tongthunhap.Name = "xrt_tongthunhap";
            this.xrt_tongthunhap.StylePriority.UseTextAlignment = false;
            this.xrt_tongthunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_tongthunhap.Weight = 1.2142857142857142D;
            // 
            // xrTableCell92
            // 
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.Weight = 1.3579591836734695D;
            // 
            // xrTableRow24
            // 
            this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrt_khoankhautru,
            this.xrTableCell96});
            this.xrTableRow24.Name = "xrTableRow24";
            this.xrTableRow24.Weight = 1D;
            // 
            // xrTableCell93
            // 
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.Weight = 0.25850339305644132D;
            // 
            // xrTableCell94
            // 
            this.xrTableCell94.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell94.Name = "xrTableCell94";
            this.xrTableCell94.StylePriority.UseFont = false;
            this.xrTableCell94.Text = "Khoản khấu trừ      UNPAID LEAVES";
            this.xrTableCell94.Weight = 1.8843537498007015D;
            // 
            // xrt_khoankhautru
            // 
            this.xrt_khoankhautru.Name = "xrt_khoankhautru";
            this.xrt_khoankhautru.StylePriority.UseTextAlignment = false;
            this.xrt_khoankhautru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_khoankhautru.Weight = 1.2142857142857142D;
            // 
            // xrTableCell96
            // 
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.Weight = 1.3579591836734695D;
            // 
            // xrTableRow25
            // 
            this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrt_baohiemyte,
            this.xrTableCell100});
            this.xrTableRow25.Name = "xrTableRow25";
            this.xrTableRow25.Weight = 1D;
            // 
            // xrTableCell97
            // 
            this.xrTableCell97.Name = "xrTableCell97";
            this.xrTableCell97.StylePriority.UseTextAlignment = false;
            this.xrTableCell97.Text = "8";
            this.xrTableCell97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell97.Weight = 0.258503716916454D;
            // 
            // xrTableCell98
            // 
            this.xrTableCell98.Name = "xrTableCell98";
            this.xrTableCell98.Text = "Bảo hiểm y tế      Health Insurance";
            this.xrTableCell98.Weight = 1.8843534259406887D;
            // 
            // xrt_baohiemyte
            // 
            this.xrt_baohiemyte.Name = "xrt_baohiemyte";
            this.xrt_baohiemyte.StylePriority.UseTextAlignment = false;
            this.xrt_baohiemyte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_baohiemyte.Weight = 1.2142857142857142D;
            // 
            // xrTableCell100
            // 
            this.xrTableCell100.Name = "xrTableCell100";
            this.xrTableCell100.Weight = 1.3579591836734695D;
            // 
            // xrTableRow26
            // 
            this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell101,
            this.xrt_b,
            this.xrt_bhxh_bhtn,
            this.xrTableCell104});
            this.xrTableRow26.Name = "xrTableRow26";
            this.xrTableRow26.Weight = 1D;
            // 
            // xrTableCell101
            // 
            this.xrTableCell101.Name = "xrTableCell101";
            this.xrTableCell101.StylePriority.UseTextAlignment = false;
            this.xrTableCell101.Text = "9";
            this.xrTableCell101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell101.Weight = 0.258503716916454D;
            // 
            // xrt_b
            // 
            this.xrt_b.Name = "xrt_b";
            this.xrt_b.Text = "BHXH, BHTN     Social Insurance";
            this.xrt_b.Weight = 1.8843534259406887D;
            // 
            // xrt_bhxh_bhtn
            // 
            this.xrt_bhxh_bhtn.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.xrt_bhxh_bhtn.Name = "xrt_bhxh_bhtn";
            this.xrt_bhxh_bhtn.StylePriority.UseTextAlignment = false;
            this.xrt_bhxh_bhtn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_bhxh_bhtn.Weight = 1.2142857142857142D;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.866455E-05F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow31});
            this.xrTable2.SizeF = new System.Drawing.SizeF(185.9374F, 25F);
            // 
            // xrTableRow31
            // 
            this.xrTableRow31.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_BHXH,
            this.xrtBHTN});
            this.xrTableRow31.Name = "xrTableRow31";
            this.xrTableRow31.Weight = 1D;
            // 
            // xrt_BHXH
            // 
            this.xrt_BHXH.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrt_BHXH.Name = "xrt_BHXH";
            this.xrt_BHXH.StylePriority.UseBorders = false;
            this.xrt_BHXH.Weight = 1.0621670874881555D;
            // 
            // xrtBHTN
            // 
            this.xrtBHTN.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrtBHTN.Name = "xrtBHTN";
            this.xrtBHTN.StylePriority.UseBorders = false;
            this.xrtBHTN.Weight = 1.0213120885047369D;
            // 
            // xrTableCell104
            // 
            this.xrTableCell104.Name = "xrTableCell104";
            this.xrTableCell104.Weight = 1.3579591836734695D;
            // 
            // xrTableRow27
            // 
            this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell105,
            this.xrTableCell106,
            this.xrt_thuethunhap,
            this.xrTableCell108});
            this.xrTableRow27.Name = "xrTableRow27";
            this.xrTableRow27.Weight = 1D;
            // 
            // xrTableCell105
            // 
            this.xrTableCell105.Name = "xrTableCell105";
            this.xrTableCell105.StylePriority.UseTextAlignment = false;
            this.xrTableCell105.Text = "10";
            this.xrTableCell105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell105.Weight = 0.25850374182876273D;
            // 
            // xrTableCell106
            // 
            this.xrTableCell106.Name = "xrTableCell106";
            this.xrTableCell106.Text = "Thuế TNCN    Income tax";
            this.xrTableCell106.Weight = 1.88435340102838D;
            // 
            // xrt_thuethunhap
            // 
            this.xrt_thuethunhap.Name = "xrt_thuethunhap";
            this.xrt_thuethunhap.StylePriority.UseTextAlignment = false;
            this.xrt_thuethunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_thuethunhap.Weight = 1.2142857142857142D;
            // 
            // xrTableCell108
            // 
            this.xrTableCell108.Name = "xrTableCell108";
            this.xrTableCell108.Weight = 1.3579591836734695D;
            // 
            // xrTableRow28
            // 
            this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell109,
            this.xrTableCell110,
            this.xrt_trukhachoacchuathanhtoan,
            this.xrTableCell112});
            this.xrTableRow28.Name = "xrTableRow28";
            this.xrTableRow28.Weight = 1D;
            // 
            // xrTableCell109
            // 
            this.xrTableCell109.Name = "xrTableCell109";
            this.xrTableCell109.StylePriority.UseTextAlignment = false;
            this.xrTableCell109.Text = "11";
            this.xrTableCell109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell109.Weight = 0.25850376674107139D;
            // 
            // xrTableCell110
            // 
            this.xrTableCell110.Name = "xrTableCell110";
            this.xrTableCell110.Text = "Trừ khác hoặc chưa thanh toán";
            this.xrTableCell110.Weight = 1.8843531768176021D;
            // 
            // xrt_trukhachoacchuathanhtoan
            // 
            this.xrt_trukhachoacchuathanhtoan.Name = "xrt_trukhachoacchuathanhtoan";
            this.xrt_trukhachoacchuathanhtoan.StylePriority.UseTextAlignment = false;
            this.xrt_trukhachoacchuathanhtoan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_trukhachoacchuathanhtoan.Weight = 1.214286112882653D;
            // 
            // xrTableCell112
            // 
            this.xrTableCell112.Name = "xrTableCell112";
            this.xrTableCell112.Weight = 1.3579589843750002D;
            // 
            // xrTableRow29
            // 
            this.xrTableRow29.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell113,
            this.xrTableCell114,
            this.xrt_traky1,
            this.xrTableCell116});
            this.xrTableRow29.Name = "xrTableRow29";
            this.xrTableRow29.Weight = 1D;
            // 
            // xrTableCell113
            // 
            this.xrTableCell113.Name = "xrTableCell113";
            this.xrTableCell113.StylePriority.UseTextAlignment = false;
            this.xrTableCell113.Text = "12";
            this.xrTableCell113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell113.Weight = 0.25850376674107139D;
            // 
            // xrTableCell114
            // 
            this.xrTableCell114.Name = "xrTableCell114";
            this.xrTableCell114.Text = "Trả kỳ 1       First payment";
            this.xrTableCell114.Weight = 1.8843531768176021D;
            // 
            // xrt_traky1
            // 
            this.xrt_traky1.Name = "xrt_traky1";
            this.xrt_traky1.StylePriority.UseTextAlignment = false;
            this.xrt_traky1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_traky1.Weight = 1.214286112882653D;
            // 
            // xrTableCell116
            // 
            this.xrTableCell116.Name = "xrTableCell116";
            this.xrTableCell116.Weight = 1.3579589843750002D;
            // 
            // xrTableRow30
            // 
            this.xrTableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell117,
            this.xrTableCell118,
            this.xrt_traky2,
            this.xrTableCell120});
            this.xrTableRow30.Name = "xrTableRow30";
            this.xrTableRow30.Weight = 1D;
            // 
            // xrTableCell117
            // 
            this.xrTableCell117.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell117.Name = "xrTableCell117";
            this.xrTableCell117.StylePriority.UseFont = false;
            this.xrTableCell117.StylePriority.UseTextAlignment = false;
            this.xrTableCell117.Text = "13";
            this.xrTableCell117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell117.Weight = 0.25850379165338006D;
            // 
            // xrTableCell118
            // 
            this.xrTableCell118.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell118.Name = "xrTableCell118";
            this.xrTableCell118.StylePriority.UseFont = false;
            this.xrTableCell118.Text = "Trả kỳ 2     Second payment";
            this.xrTableCell118.Weight = 1.8843533512037627D;
            // 
            // xrt_traky2
            // 
            this.xrt_traky2.Name = "xrt_traky2";
            this.xrt_traky2.StylePriority.UseTextAlignment = false;
            this.xrt_traky2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrt_traky2.Weight = 1.2142857142857142D;
            // 
            // xrTableCell120
            // 
            this.xrTableCell120.Name = "xrTableCell120";
            this.xrTableCell120.Weight = 1.3579591836734695D;
            // 
            // xrl_chucvu
            // 
            this.xrl_chucvu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_chucvu.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
            this.xrl_chucvu.Name = "xrl_chucvu";
            this.xrl_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_chucvu.SizeF = new System.Drawing.SizeF(154.1667F, 23F);
            this.xrl_chucvu.StylePriority.UseFont = false;
            this.xrl_chucvu.Text = "Chức vụ/Position:  ";
            // 
            // xrl_hoten
            // 
            this.xrl_hoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_hoten.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_hoten.Name = "xrl_hoten";
            this.xrl_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_hoten.SizeF = new System.Drawing.SizeF(154.1667F, 23F);
            this.xrl_hoten.StylePriority.UseFont = false;
            this.xrl_hoten.Text = "Họ và tên/Fullname:  ";
            // 
            // xrl_code
            // 
            this.xrl_code.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_code.LocationFloat = new DevExpress.Utils.PointFloat(425.4167F, 0F);
            this.xrl_code.Name = "xrl_code";
            this.xrl_code.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_code.SizeF = new System.Drawing.SizeF(65.33331F, 23.00001F);
            this.xrl_code.StylePriority.UseFont = false;
            this.xrl_code.Text = "Code:  ";
            // 
            // xrl_bophan
            // 
            this.xrl_bophan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_bophan.LocationFloat = new DevExpress.Utils.PointFloat(351.1664F, 23.00002F);
            this.xrl_bophan.Name = "xrl_bophan";
            this.xrl_bophan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_bophan.SizeF = new System.Drawing.SizeF(179.5623F, 23.00001F);
            this.xrl_bophan.StylePriority.UseFont = false;
            this.xrl_bophan.Text = "Bộ phận/Departmet: ";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 9F;
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
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_nguoinhantien,
            this.xrl_chukynguoinhantien,
            this.xrl_chukythuquy,
            this.xrl_thuquy,
            this.xrLabel3,
            this.xrl_ngayketxuat});
            this.PageFooter.HeightF = 148.4167F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrl_thuquy
            // 
            this.xrl_thuquy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_thuquy.LocationFloat = new DevExpress.Utils.PointFloat(425F, 50F);
            this.xrl_thuquy.Name = "xrl_thuquy";
            this.xrl_thuquy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_thuquy.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
            this.xrl_thuquy.StylePriority.UseFont = false;
            this.xrl_thuquy.StylePriority.UseTextAlignment = false;
            this.xrl_thuquy.Text = "Thủ quỹ/ Treasurer";
            this.xrl_thuquy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(719.9165F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Chúc Ông, Bà và gia đình mạnh khỏe hạnh phúc và thành đạt. Xin cảm ơn !";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ngayketxuat
            // 
            this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(425F, 25F);
            this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
            this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(296.875F, 23F);
            this.xrl_ngayketxuat.StylePriority.UseFont = false;
            this.xrl_ngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrl_ngayketxuat.Text = "Hà Nội ngày .........tháng .........năm...........";
            this.xrl_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_nguoinhantien
            // 
            this.xrl_nguoinhantien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_nguoinhantien.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrl_nguoinhantien.Name = "xrl_nguoinhantien";
            this.xrl_nguoinhantien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_nguoinhantien.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
            this.xrl_nguoinhantien.StylePriority.UseFont = false;
            this.xrl_nguoinhantien.StylePriority.UseTextAlignment = false;
            this.xrl_nguoinhantien.Text = "Người nhận tiền/ Recipient";
            this.xrl_nguoinhantien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_chukynguoinhantien
            // 
            this.xrl_chukynguoinhantien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_chukynguoinhantien.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125F);
            this.xrl_chukynguoinhantien.Name = "xrl_chukynguoinhantien";
            this.xrl_chukynguoinhantien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_chukynguoinhantien.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
            this.xrl_chukynguoinhantien.StylePriority.UseFont = false;
            this.xrl_chukynguoinhantien.StylePriority.UseTextAlignment = false;
            this.xrl_chukynguoinhantien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_chukythuquy
            // 
            this.xrl_chukythuquy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_chukythuquy.LocationFloat = new DevExpress.Utils.PointFloat(425F, 125F);
            this.xrl_chukythuquy.Name = "xrl_chukythuquy";
            this.xrl_chukythuquy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_chukythuquy.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
            this.xrl_chukythuquy.StylePriority.UseFont = false;
            this.xrl_chukythuquy.StylePriority.UseTextAlignment = false;
            this.xrl_chukythuquy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho,
            this.xrl_tenbaocao,
            this.xrl_ThangTraLuong});
            this.PageHeader.HeightF = 111.5417F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrl_tenbaocao
            // 
            this.xrl_tenbaocao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_tenbaocao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
            this.xrl_tenbaocao.Multiline = true;
            this.xrl_tenbaocao.Name = "xrl_tenbaocao";
            this.xrl_tenbaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tenbaocao.SizeF = new System.Drawing.SizeF(722F, 23F);
            this.xrl_tenbaocao.StylePriority.UseFont = false;
            this.xrl_tenbaocao.StylePriority.UseTextAlignment = false;
            this.xrl_tenbaocao.Text = "PHIẾU TRẢ LƯƠNG\r\n";
            this.xrl_tenbaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ThangTraLuong
            // 
            this.xrl_ThangTraLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_ThangTraLuong.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrl_ThangTraLuong.Name = "xrl_ThangTraLuong";
            this.xrl_ThangTraLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ThangTraLuong.SizeF = new System.Drawing.SizeF(722F, 23F);
            this.xrl_ThangTraLuong.StylePriority.UseFont = false;
            this.xrl_ThangTraLuong.StylePriority.UseTextAlignment = false;
            this.xrl_ThangTraLuong.Text = "Tháng 2 năm 2013";
            this.xrl_ThangTraLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "Xí Nghiệp Môi trường đô thị";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "Ủy ban nhân dân Huyện Từ Liêm";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // rp_PhieuTraLuong
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(65, 63, 9, 0);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    public void BindData(ReportFilter rp)
    {
        //if (rp.thang_chamcong == null)
        //{
        //    xrl_ThangTraLuong.Text = "Tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //    xrl_ngayketxuat.Text = "Tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //}
        //else
        //{
        //    xrl_ThangTraLuong.Text = "Tháng " + rp.thang_chamcong + " năm " + rp.nam_chamcong;
        //    xrl_ngayketxuat.Text = "Tháng " + rp.thang_chamcong + " năm " + rp.nam_chamcong;
        //}

        //if (!string.IsNullOrEmpty(rp.TenThanhPho))
        //{
        //    xrl_TenThanhPho.Text = rp.TenThanhPho;
        //}
        //if (!string.IsNullOrEmpty(rp.TenBaoCao))
        //{
        //    xrl_tenbaocao.Text = rp.TenBaoCao;
        //}
        //if (!string.IsNullOrEmpty(rp.TenDonVi))
        //{
        //    xrl_TenCongTy.Text = rp.TenDonVi;
        //}
        //DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_phieutraluong", "@MaDonVi","@Thang","@Nam","@MaPhong", rp.MaDonVi,rp.thang,rp.nam_chamcong,rp.MaPhongBan);
        //DataSource = table;
        //xrlNDhoten.DataBindings.Add("Text", DataSource, "HO_TEN");
        //xrlMa.DataBindings.Add("Text", DataSource, "MaCB");
        //xrlNDbophan.DataBindings.Add("Text", DataSource, "TEN_PHONG");
        //xrlNDchucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        //xrt_luongcoban.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:0,0}");
        //xrt_ngayletetnghihuongluong.DataBindings.Add("Text", DataSource, "LuongNghiLe", "{0:0,0}");
        //xrt_luongthemgio.DataBindings.Add("Text", DataSource, "LuongThemGio", "{0:0,0}");
        //xrt_luongsanpham.DataBindings.Add("Text", DataSource, "LuongSanPham", "{0:0,0}");
        //xrt_baohiemyte.DataBindings.Add("Text", DataSource, "GiamTruBHYT", "{0:0,0}");
        //xrt_BHXH.DataBindings.Add("Text", DataSource, "GiamTruBHXH", "{0:0,0}");
        //xrtBHTN.DataBindings.Add("Text", DataSource, "GiamTruBHTN", "{0:0,0}");
        //xrt_thuethunhap.DataBindings.Add("Text", DataSource, "GiamTruThuNhapCaNhan", "{0:0,0}");
        //if (!string.IsNullOrEmpty(rp.Footer1))
        //{
        //    xrl_nguoinhantien.Text = rp.Footer1;
        //}
        //if (!string.IsNullOrEmpty(rp.Footer3))
        //{
        //    xrl_thuquy.Text = rp.Footer3;
        //}
        //if (!string.IsNullOrEmpty(rp.Ten1))
        //{
        //    xrl_chukynguoinhantien.Text = rp.Ten1;

        //}
        //if (!string.IsNullOrEmpty(rp.Ten3))
        //{
        //    xrl_chukythuquy.Text = rp.Ten3;
        //}
    }
    #endregion
}
