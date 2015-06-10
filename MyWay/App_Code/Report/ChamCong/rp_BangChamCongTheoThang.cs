using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAL;
using System.Collections.Generic;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BangChamCongTheoThang
/// </summary>
public class rp_BangChamCongTheoThang : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell15;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrtmanhanvien;
    private XRTableCell xrt_ngaysinh;
    private XRTableCell xrthoten;
    private XRTableCell xrtgioitinh;
    private XRTableCell xrtdiachi;
    private XRTableCell xrtdienthoai;
    private XRTableCell xrtngayvaocongty;
    private XRTableCell xrt_trinhdo;
    private XRTableCell xrtchucvu;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrl_STT;
    private XRTableCell xrl_HOTEN;
    private XRTableCell xrl_01;
    private XRTableCell xrl_02;
    private XRTableCell xrl_03;
    private XRTableCell xrl_04;
    private XRTableCell xrl_05;
    private XRTableCell xrl_06;
    private XRTableCell xrl_07;
    private XRTableCell xrl_11;
    private XRTableCell xrl_12;
    private XRTableCell xrl_TONG;
    private XRTableCell xrl_09;
    private XRTableCell xrl_10;
    private XRTableCell xrl_08;
    private XRTableCell xrl_16;
    private XRTableCell xrl_14;
    private XRTableCell xrl_29;
    private XRTableCell xrl_30;
    private XRTableCell xrl_13;
    private XRTableCell xrl_15;
    private XRTableCell xrl_28;
    private XRTableCell xrl_18;
    private XRTableCell xrl_17;
    private XRTableCell xrl_19;
    private XRTableCell xrl_20;
    private XRTableCell xrl_21;
    private XRTableCell xrl_22;
    private XRTableCell xrl_23;
    private XRTableCell xrl_24;
    private XRTableCell xrl_25;
    private XRTableCell xrl_26;
    private XRTableCell xrl_27;
    private XRTableCell xrl_HL;
    private XRTableCell xrl_NP;
    private XRTableCell xrl_31;
    private XRTableCell xrl_HLTV;
    private XRTableCell xrl_BHXH;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private ReportFooterBand ReportFooter;
    private XRLabel xrtngayketxuat;
    private XRLabel xrlFT1;
    private XRLabel xrlFT3;
    private GroupHeaderBand GroupHeader1;
    private PageFooterBand PageFooter;
    private XRLabel xrlNguoiBC1;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrlFT2;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrt_phongban;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell grpBoPhan;
    private XRLabel xrlNguoiBC2;
    private XRLabel xrlNguoiBC3;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRLabel xrLabel8;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRTableCell xrNB;
    private XRTableCell xrKL;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BangChamCongTheoThang()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

    }
    int STT = 0;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        STT++;
        xrl_STT.Text = STT.ToString();
    }
    public void BindData(ReportFilter rp)
    { 
        // DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_BangChamCongThang", "@MaDonVi", "@MaBoPhan", "@MaChucVu", "@MaViTriCongViec", "@IDBangChamCong", rp.SessionDepartmentID, rp.CheckedDepartmentID == "" ? rp.ChildrenOfDepartmentID : rp.CheckedDepartmentID, rp.MaChucVu, rp.MaViTriCongViec, rp.IDDanhSachBangTongHopCong);
        DataTable table = new DataTable(); ;
        if (!string.IsNullOrEmpty(rp.SelectedDepartment))
        {
            table = DataHandler.GetInstance().ExecuteDataTable("[BaoCaoBangChamCongThang]", "@Month", "@Year", "@MaBoPhan" ,"@WhereClause", rp.StartMonth, rp.Year, rp.SelectedDepartment, rp.WhereClause); 
        }
        else
        {
            table = DataHandler.GetInstance().ExecuteDataTable("[BaoCaoBangChamCongThang]", "@WhereClause", rp.WhereClause); 
        }
        //DAL.DanhSachBangTongHopCong dsBangChamCong = new ChamCongThangController().GetBangChamCong(rp.IDBangChamCong); 
        //xrl_TitleBC.Text = "BÁO CÁO BẢNG CHẤM CÔNG THÁNG " + dsBangChamCong.Month + " NĂM " + dsBangChamCong.Year;
        if (table.Rows.Count > 0)
        {
            DataRow item = table.Rows[0];
            xrl_TitleBC.Text = string.Format(xrl_TitleBC.Text,item["Thang"].ToString());
        }


        xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(rp.SessionDepartment);
        xrl_TenThanhPho.Text = ReportController.GetInstance().GetCityName(rp.SessionDepartment);
        DataSource = table;
        xrl_HOTEN.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrl_01.DataBindings.Add("Text", DataSource, "Ngay01");
        xrl_02.DataBindings.Add("Text", DataSource, "Ngay02");
        xrl_03.DataBindings.Add("Text", DataSource, "Ngay03");
        xrl_04.DataBindings.Add("Text", DataSource, "Ngay04");
        xrl_05.DataBindings.Add("Text", DataSource, "Ngay05");
        xrl_06.DataBindings.Add("Text", DataSource, "Ngay06");
        xrl_07.DataBindings.Add("Text", DataSource, "Ngay07");
        xrl_08.DataBindings.Add("Text", DataSource, "Ngay08");
        xrl_09.DataBindings.Add("Text", DataSource, "Ngay09");
        xrl_10.DataBindings.Add("Text", DataSource, "Ngay10");
        xrl_11.DataBindings.Add("Text", DataSource, "Ngay11");
        xrl_12.DataBindings.Add("Text", DataSource, "Ngay12");
        xrl_13.DataBindings.Add("Text", DataSource, "Ngay13");
        xrl_14.DataBindings.Add("Text", DataSource, "Ngay14");
        xrl_15.DataBindings.Add("Text", DataSource, "Ngay15");
        xrl_16.DataBindings.Add("Text", DataSource, "Ngay16");
        xrl_17.DataBindings.Add("Text", DataSource, "Ngay17");
        xrl_18.DataBindings.Add("Text", DataSource, "Ngay18");
        xrl_19.DataBindings.Add("Text", DataSource, "Ngay19");
        xrl_20.DataBindings.Add("Text", DataSource, "Ngay20");
        xrl_21.DataBindings.Add("Text", DataSource, "Ngay21");
        xrl_22.DataBindings.Add("Text", DataSource, "Ngay22");
        xrl_23.DataBindings.Add("Text", DataSource, "Ngay23");
        xrl_24.DataBindings.Add("Text", DataSource, "Ngay24");
        xrl_25.DataBindings.Add("Text", DataSource, "Ngay25");
        xrl_26.DataBindings.Add("Text", DataSource, "Ngay26");
        xrl_27.DataBindings.Add("Text", DataSource, "Ngay27");
        xrl_28.DataBindings.Add("Text", DataSource, "Ngay28");
        xrl_29.DataBindings.Add("Text", DataSource, "Ngay29");
        xrl_30.DataBindings.Add("Text", DataSource, "Ngay30");
        xrl_31.DataBindings.Add("Text", DataSource, "Ngay31");
        // tạm thời chưa lấy dữ liệu ra
        xrl_HL.DataBindings.Add("Text", DataSource, "HL");
        xrl_HLTV.DataBindings.Add("Text", DataSource, "HLTV");
        xrl_NP.DataBindings.Add("Text", DataSource, "PHEP");
        xrKL.DataBindings.Add("Text", DataSource, "KL");
        xrNB.DataBindings.Add("Text", DataSource, "NB");
        xrl_BHXH.DataBindings.Add("Text", DataSource, "BHXH");
        xrl_TONG.DataBindings.Add("Text", DataSource, "TONG_CONG");

        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MA_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        grpBoPhan.DataBindings.Add("Text", DataSource, "TEN_DONVI").ToString().ToUpper();


        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        if (!string.IsNullOrEmpty(rp.Name1)) xrlNguoiBC1.Text = rp.Name1;
        if (!string.IsNullOrEmpty(rp.Name2)) xrlNguoiBC2.Text = rp.Name2;
        if (!string.IsNullOrEmpty(rp.Name3)) xrlNguoiBC3.Text = rp.Name3; else xrlNguoiBC3.Text = ReportController.GetInstance().GetDirectorName(rp.SessionDepartment, rp.Name3);

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
        string resourceFileName = "rp_BangChamCongTheoThang.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrl_STT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_HOTEN = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_01 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_02 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_03 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_04 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_05 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_06 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_07 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_08 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_09 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_HL = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_HLTV = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_NP = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_BHXH = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_TONG = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtmanhanvien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrthoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtgioitinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtdiachi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtdienthoai = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtngayvaocongty = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_trinhdo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtchucvu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrlNguoiBC3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNguoiBC2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlFT2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNguoiBC1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlFT1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlFT3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.grpBoPhan = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrNB = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrKL = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
        this.Detail.HeightF = 25.41666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(1.902302F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(1134.098F, 25.41666F);
        this.xrTable4.StylePriority.UseBorders = false;
        this.xrTable4.StylePriority.UseFont = false;
        this.xrTable4.StylePriority.UsePadding = false;
        this.xrTable4.StylePriority.UseTextAlignment = false;
        this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrl_STT,
            this.xrl_HOTEN,
            this.xrl_01,
            this.xrl_02,
            this.xrl_03,
            this.xrl_04,
            this.xrl_05,
            this.xrl_06,
            this.xrl_07,
            this.xrl_08,
            this.xrl_09,
            this.xrl_10,
            this.xrl_11,
            this.xrl_12,
            this.xrl_13,
            this.xrl_14,
            this.xrl_15,
            this.xrl_16,
            this.xrl_17,
            this.xrl_18,
            this.xrl_19,
            this.xrl_20,
            this.xrl_21,
            this.xrl_22,
            this.xrl_23,
            this.xrl_24,
            this.xrl_25,
            this.xrl_26,
            this.xrl_27,
            this.xrl_28,
            this.xrl_29,
            this.xrl_30,
            this.xrl_31,
            this.xrl_HL,
            this.xrl_HLTV,
            this.xrl_NP,
            this.xrNB,
            this.xrKL,
            this.xrl_BHXH,
            this.xrl_TONG});
        this.xrTableRow4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.StylePriority.UseFont = false;
        this.xrTableRow4.StylePriority.UseTextAlignment = false;
        this.xrTableRow4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow4.Weight = 1D;
        // 
        // xrl_STT
        // 
        this.xrl_STT.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_STT.Name = "xrl_STT";
        this.xrl_STT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_STT.StylePriority.UseFont = false;
        this.xrl_STT.StylePriority.UsePadding = false;
        this.xrl_STT.StylePriority.UseTextAlignment = false;
        this.xrl_STT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrl_STT.Weight = 0.24461453541770395D;
        // 
        // xrl_HOTEN
        // 
        this.xrl_HOTEN.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_HOTEN.Name = "xrl_HOTEN";
        this.xrl_HOTEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_HOTEN.StylePriority.UseFont = false;
        this.xrl_HOTEN.StylePriority.UsePadding = false;
        this.xrl_HOTEN.StylePriority.UseTextAlignment = false;
        this.xrl_HOTEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_HOTEN.Weight = 1.1251789409202087D;
        // 
        // xrl_01
        // 
        this.xrl_01.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_01.Name = "xrl_01";
        this.xrl_01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_01.StylePriority.UseFont = false;
        this.xrl_01.StylePriority.UsePadding = false;
        this.xrl_01.StylePriority.UseTextAlignment = false;
        this.xrl_01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_01.Weight = 0.23999995058464319D;
        // 
        // xrl_02
        // 
        this.xrl_02.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_02.Name = "xrl_02";
        this.xrl_02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_02.StylePriority.UseFont = false;
        this.xrl_02.StylePriority.UsePadding = false;
        this.xrl_02.StylePriority.UseTextAlignment = false;
        this.xrl_02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_02.Weight = 0.24000021532765858D;
        // 
        // xrl_03
        // 
        this.xrl_03.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_03.Name = "xrl_03";
        this.xrl_03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_03.StylePriority.UseFont = false;
        this.xrl_03.StylePriority.UsePadding = false;
        this.xrl_03.StylePriority.UseTextAlignment = false;
        this.xrl_03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_03.Weight = 0.23999996752089392D;
        // 
        // xrl_04
        // 
        this.xrl_04.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_04.Name = "xrl_04";
        this.xrl_04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_04.StylePriority.UseFont = false;
        this.xrl_04.StylePriority.UsePadding = false;
        this.xrl_04.StylePriority.UseTextAlignment = false;
        this.xrl_04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_04.Weight = 0.24000032053124087D;
        // 
        // xrl_05
        // 
        this.xrl_05.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_05.Name = "xrl_05";
        this.xrl_05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_05.StylePriority.UseFont = false;
        this.xrl_05.StylePriority.UsePadding = false;
        this.xrl_05.StylePriority.UseTextAlignment = false;
        this.xrl_05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_05.Weight = 0.24000006235633276D;
        // 
        // xrl_06
        // 
        this.xrl_06.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_06.Name = "xrl_06";
        this.xrl_06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_06.StylePriority.UseFont = false;
        this.xrl_06.StylePriority.UsePadding = false;
        this.xrl_06.StylePriority.UseTextAlignment = false;
        this.xrl_06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_06.Weight = 0.24000014916250656D;
        // 
        // xrl_07
        // 
        this.xrl_07.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_07.Name = "xrl_07";
        this.xrl_07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_07.StylePriority.UseFont = false;
        this.xrl_07.StylePriority.UsePadding = false;
        this.xrl_07.StylePriority.UseTextAlignment = false;
        this.xrl_07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_07.Weight = 0.24000002046601576D;
        // 
        // xrl_08
        // 
        this.xrl_08.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_08.Name = "xrl_08";
        this.xrl_08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_08.StylePriority.UseFont = false;
        this.xrl_08.StylePriority.UsePadding = false;
        this.xrl_08.StylePriority.UseTextAlignment = false;
        this.xrl_08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_08.Weight = 0.24000011581870706D;
        // 
        // xrl_09
        // 
        this.xrl_09.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_09.Name = "xrl_09";
        this.xrl_09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_09.StylePriority.UseFont = false;
        this.xrl_09.StylePriority.UsePadding = false;
        this.xrl_09.StylePriority.UseTextAlignment = false;
        this.xrl_09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_09.Weight = 0.24000011581870706D;
        // 
        // xrl_10
        // 
        this.xrl_10.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_10.Name = "xrl_10";
        this.xrl_10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_10.StylePriority.UseFont = false;
        this.xrl_10.StylePriority.UsePadding = false;
        this.xrl_10.StylePriority.UseTextAlignment = false;
        this.xrl_10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_10.Weight = 0.24000034470063492D;
        // 
        // xrl_11
        // 
        this.xrl_11.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_11.Name = "xrl_11";
        this.xrl_11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_11.StylePriority.UseFont = false;
        this.xrl_11.StylePriority.UsePadding = false;
        this.xrl_11.StylePriority.UseTextAlignment = false;
        this.xrl_11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_11.Weight = 0.24000019211268286D;
        // 
        // xrl_12
        // 
        this.xrl_12.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_12.Name = "xrl_12";
        this.xrl_12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_12.StylePriority.UseFont = false;
        this.xrl_12.StylePriority.UsePadding = false;
        this.xrl_12.StylePriority.UseTextAlignment = false;
        this.xrl_12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_12.Weight = 0.23999967738584527D;
        // 
        // xrl_13
        // 
        this.xrl_13.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_13.Name = "xrl_13";
        this.xrl_13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_13.StylePriority.UseFont = false;
        this.xrl_13.StylePriority.UsePadding = false;
        this.xrl_13.StylePriority.UseTextAlignment = false;
        this.xrl_13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_13.Weight = 0.2400004255698599D;
        // 
        // xrl_14
        // 
        this.xrl_14.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_14.Name = "xrl_14";
        this.xrl_14.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_14.StylePriority.UseFont = false;
        this.xrl_14.StylePriority.UsePadding = false;
        this.xrl_14.StylePriority.UseTextAlignment = false;
        this.xrl_14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_14.Weight = 0.23999981521805203D;
        // 
        // xrl_15
        // 
        this.xrl_15.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_15.Name = "xrl_15";
        this.xrl_15.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_15.StylePriority.UseFont = false;
        this.xrl_15.StylePriority.UsePadding = false;
        this.xrl_15.StylePriority.UseTextAlignment = false;
        this.xrl_15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_15.Weight = 0.24000004409997988D;
        // 
        // xrl_16
        // 
        this.xrl_16.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_16.Name = "xrl_16";
        this.xrl_16.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_16.StylePriority.UseFont = false;
        this.xrl_16.StylePriority.UsePadding = false;
        this.xrl_16.StylePriority.UseTextAlignment = false;
        this.xrl_16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_16.Weight = 0.24000019668793193D;
        // 
        // xrl_17
        // 
        this.xrl_17.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_17.Name = "xrl_17";
        this.xrl_17.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_17.StylePriority.UseFont = false;
        this.xrl_17.StylePriority.UsePadding = false;
        this.xrl_17.StylePriority.UseTextAlignment = false;
        this.xrl_17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_17.Weight = 0.23999947303897207D;
        // 
        // xrl_18
        // 
        this.xrl_18.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_18.Name = "xrl_18";
        this.xrl_18.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_18.StylePriority.UseFont = false;
        this.xrl_18.StylePriority.UsePadding = false;
        this.xrl_18.StylePriority.UseTextAlignment = false;
        this.xrl_18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_18.Weight = 0.24000069374258781D;
        // 
        // xrl_19
        // 
        this.xrl_19.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_19.Name = "xrl_19";
        this.xrl_19.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_19.StylePriority.UseFont = false;
        this.xrl_19.StylePriority.UsePadding = false;
        this.xrl_19.StylePriority.UseTextAlignment = false;
        this.xrl_19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_19.Weight = 0.24000069374258803D;
        // 
        // xrl_20
        // 
        this.xrl_20.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_20.Name = "xrl_20";
        this.xrl_20.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_20.StylePriority.UseFont = false;
        this.xrl_20.StylePriority.UsePadding = false;
        this.xrl_20.StylePriority.UseTextAlignment = false;
        this.xrl_20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_20.Weight = 0.23999947958743884D;
        // 
        // xrl_21
        // 
        this.xrl_21.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_21.Name = "xrl_21";
        this.xrl_21.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_21.StylePriority.UseFont = false;
        this.xrl_21.StylePriority.UsePadding = false;
        this.xrl_21.StylePriority.UseTextAlignment = false;
        this.xrl_21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_21.Weight = 0.24000070356528802D;
        // 
        // xrl_22
        // 
        this.xrl_22.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_22.Name = "xrl_22";
        this.xrl_22.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_22.StylePriority.UseFont = false;
        this.xrl_22.StylePriority.UsePadding = false;
        this.xrl_22.StylePriority.UseTextAlignment = false;
        this.xrl_22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_22.Weight = 0.24000009485059681D;
        // 
        // xrl_23
        // 
        this.xrl_23.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_23.Name = "xrl_23";
        this.xrl_23.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_23.StylePriority.UseFont = false;
        this.xrl_23.StylePriority.UsePadding = false;
        this.xrl_23.StylePriority.UseTextAlignment = false;
        this.xrl_23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_23.Weight = 0.23999948531734716D;
        // 
        // xrl_24
        // 
        this.xrl_24.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_24.Name = "xrl_24";
        this.xrl_24.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_24.StylePriority.UseFont = false;
        this.xrl_24.StylePriority.UsePadding = false;
        this.xrl_24.StylePriority.UseTextAlignment = false;
        this.xrl_24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_24.Weight = 0.24000070643024202D;
        // 
        // xrl_25
        // 
        this.xrl_25.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_25.Name = "xrl_25";
        this.xrl_25.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_25.StylePriority.UseFont = false;
        this.xrl_25.StylePriority.UsePadding = false;
        this.xrl_25.StylePriority.UseTextAlignment = false;
        this.xrl_25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_25.Weight = 0.24000070663488166D;
        // 
        // xrl_26
        // 
        this.xrl_26.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_26.Name = "xrl_26";
        this.xrl_26.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_26.StylePriority.UseFont = false;
        this.xrl_26.StylePriority.UsePadding = false;
        this.xrl_26.StylePriority.UseTextAlignment = false;
        this.xrl_26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_26.Weight = 0.2399988756817778D;
        // 
        // xrl_27
        // 
        this.xrl_27.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_27.Name = "xrl_27";
        this.xrl_27.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_27.StylePriority.UseFont = false;
        this.xrl_27.StylePriority.UsePadding = false;
        this.xrl_27.StylePriority.UseTextAlignment = false;
        this.xrl_27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_27.Weight = 0.24000009643655346D;
        // 
        // xrl_28
        // 
        this.xrl_28.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_28.Name = "xrl_28";
        this.xrl_28.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_28.StylePriority.UseFont = false;
        this.xrl_28.StylePriority.UsePadding = false;
        this.xrl_28.StylePriority.UseTextAlignment = false;
        this.xrl_28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_28.Weight = 0.2400000964365534D;
        // 
        // xrl_29
        // 
        this.xrl_29.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_29.Name = "xrl_29";
        this.xrl_29.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_29.StylePriority.UseFont = false;
        this.xrl_29.StylePriority.UsePadding = false;
        this.xrl_29.StylePriority.UseTextAlignment = false;
        this.xrl_29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_29.Weight = 0.23999951004214803D;
        // 
        // xrl_30
        // 
        this.xrl_30.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_30.Name = "xrl_30";
        this.xrl_30.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_30.StylePriority.UseFont = false;
        this.xrl_30.StylePriority.UsePadding = false;
        this.xrl_30.StylePriority.UseTextAlignment = false;
        this.xrl_30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_30.Weight = 0.24000069259877563D;
        // 
        // xrl_31
        // 
        this.xrl_31.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrl_31.Name = "xrl_31";
        this.xrl_31.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_31.StylePriority.UseFont = false;
        this.xrl_31.StylePriority.UsePadding = false;
        this.xrl_31.StylePriority.UseTextAlignment = false;
        this.xrl_31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrl_31.Weight = 0.24000009292752689D;
        // 
        // xrl_HL
        // 
        this.xrl_HL.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_HL.Name = "xrl_HL";
        this.xrl_HL.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_HL.StylePriority.UseFont = false;
        this.xrl_HL.StylePriority.UsePadding = false;
        this.xrl_HL.StylePriority.UseTextAlignment = false;
        this.xrl_HL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrl_HL.Weight = 0.30821786602155871D;
        // 
        // xrl_HLTV
        // 
        this.xrl_HLTV.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_HLTV.Name = "xrl_HLTV";
        this.xrl_HLTV.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_HLTV.StylePriority.UseFont = false;
        this.xrl_HLTV.StylePriority.UsePadding = false;
        this.xrl_HLTV.StylePriority.UseTextAlignment = false;
        this.xrl_HLTV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrl_HLTV.Weight = 0.30821430751368944D;
        // 
        // xrl_NP
        // 
        this.xrl_NP.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_NP.Name = "xrl_NP";
        this.xrl_NP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_NP.StylePriority.UseFont = false;
        this.xrl_NP.StylePriority.UsePadding = false;
        this.xrl_NP.StylePriority.UseTextAlignment = false;
        this.xrl_NP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrl_NP.Weight = 0.30821370421039351D;
        // 
        // xrl_BHXH
        // 
        this.xrl_BHXH.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_BHXH.Name = "xrl_BHXH";
        this.xrl_BHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_BHXH.StylePriority.UseFont = false;
        this.xrl_BHXH.StylePriority.UsePadding = false;
        this.xrl_BHXH.StylePriority.UseTextAlignment = false;
        this.xrl_BHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrl_BHXH.Weight = 0.31449298667486492D;
        // 
        // xrl_TONG
        // 
        this.xrl_TONG.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrl_TONG.Name = "xrl_TONG";
        this.xrl_TONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrl_TONG.StylePriority.UseFont = false;
        this.xrl_TONG.StylePriority.UsePadding = false;
        this.xrl_TONG.StylePriority.UseTextAlignment = false;
        this.xrl_TONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrl_TONG.Weight = 0.43130746955834542D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 31F;
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
            this.xrLabel2,
            this.xrLabel1,
            this.xrl_TenCongTy,
            this.xrl_TitleBC,
            this.xrl_TenThanhPho});
        this.ReportHeader.HeightF = 127F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 102F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(1116F, 25F);
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
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(664.9582F, 25F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(451.0417F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Độc lập - Tự do - Hạnh phúc";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(664.9582F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(451.0416F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(451.0417F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 76.99998F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1116F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BẢNG CHẤM CÔNG THÁNG {0}";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(451.0416F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 55F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(1.902302F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1134.098F, 55F);
        this.xrTable1.StylePriority.UseBorders = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell3,
            this.xrTableCell5,
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
        this.xrTableCell1.Multiline = true;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "TT";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.24461428136853994D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Họ tên";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 1.1251779876391439D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrTable2});
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Ngày trong tháng";
        this.xrTableCell5.Weight = 7.4399962709073186D;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.160404E-05F, 0F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(760.3798F, 29.58334F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Ngày trong tháng";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(4.160404E-05F, 29.58336F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(760.3798F, 25.41666F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtmanhanvien,
            this.xrt_ngaysinh,
            this.xrthoten,
            this.xrtgioitinh,
            this.xrtdiachi,
            this.xrtdienthoai,
            this.xrtngayvaocongty,
            this.xrt_trinhdo,
            this.xrtchucvu,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell21,
            this.xrTableCell2,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell22,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell29,
            this.xrTableCell28,
            this.xrTableCell30});
        this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.StylePriority.UseFont = false;
        this.xrTableRow2.StylePriority.UseTextAlignment = false;
        this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow2.Weight = 1D;
        // 
        // xrtstt
        // 
        this.xrtstt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrtstt.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtstt.Name = "xrtstt";
        this.xrtstt.StylePriority.UseBorders = false;
        this.xrtstt.StylePriority.UseFont = false;
        this.xrtstt.StylePriority.UseTextAlignment = false;
        this.xrtstt.Text = "01";
        this.xrtstt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtstt.Weight = 0.24000008710715973D;
        // 
        // xrtmanhanvien
        // 
        this.xrtmanhanvien.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtmanhanvien.Name = "xrtmanhanvien";
        this.xrtmanhanvien.StylePriority.UseFont = false;
        this.xrtmanhanvien.StylePriority.UseTextAlignment = false;
        this.xrtmanhanvien.Text = "02";
        this.xrtmanhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtmanhanvien.Weight = 0.24000009327297261D;
        // 
        // xrt_ngaysinh
        // 
        this.xrt_ngaysinh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrt_ngaysinh.Name = "xrt_ngaysinh";
        this.xrt_ngaysinh.StylePriority.UseFont = false;
        this.xrt_ngaysinh.StylePriority.UseTextAlignment = false;
        this.xrt_ngaysinh.Text = "03";
        this.xrt_ngaysinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_ngaysinh.Weight = 0.24000010317259493D;
        // 
        // xrthoten
        // 
        this.xrthoten.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrthoten.Name = "xrthoten";
        this.xrthoten.StylePriority.UseFont = false;
        this.xrthoten.StylePriority.UseTextAlignment = false;
        this.xrthoten.Text = "04";
        this.xrthoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrthoten.Weight = 0.24000010088669477D;
        // 
        // xrtgioitinh
        // 
        this.xrtgioitinh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtgioitinh.Name = "xrtgioitinh";
        this.xrtgioitinh.StylePriority.UseFont = false;
        this.xrtgioitinh.StylePriority.UseTextAlignment = false;
        this.xrtgioitinh.Text = "05";
        this.xrtgioitinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtgioitinh.Weight = 0.24000008196185813D;
        // 
        // xrtdiachi
        // 
        this.xrtdiachi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtdiachi.Name = "xrtdiachi";
        this.xrtdiachi.StylePriority.UseFont = false;
        this.xrtdiachi.StylePriority.UseTextAlignment = false;
        this.xrtdiachi.Text = "06";
        this.xrtdiachi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtdiachi.Weight = 0.24000009164931319D;
        // 
        // xrtdienthoai
        // 
        this.xrtdienthoai.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtdienthoai.Name = "xrtdienthoai";
        this.xrtdienthoai.StylePriority.UseFont = false;
        this.xrtdienthoai.StylePriority.UseTextAlignment = false;
        this.xrtdienthoai.Text = "07";
        this.xrtdienthoai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtdienthoai.Weight = 0.2400001005033211D;
        // 
        // xrtngayvaocongty
        // 
        this.xrtngayvaocongty.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtngayvaocongty.Name = "xrtngayvaocongty";
        this.xrtngayvaocongty.StylePriority.UseFont = false;
        this.xrtngayvaocongty.StylePriority.UseTextAlignment = false;
        this.xrtngayvaocongty.Text = "08";
        this.xrtngayvaocongty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtngayvaocongty.Weight = 0.24000009194202465D;
        // 
        // xrt_trinhdo
        // 
        this.xrt_trinhdo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrt_trinhdo.Name = "xrt_trinhdo";
        this.xrt_trinhdo.StylePriority.UseFont = false;
        this.xrt_trinhdo.StylePriority.UseTextAlignment = false;
        this.xrt_trinhdo.Text = "09";
        this.xrt_trinhdo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_trinhdo.Weight = 0.24000009675998857D;
        // 
        // xrtchucvu
        // 
        this.xrtchucvu.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrtchucvu.Name = "xrtchucvu";
        this.xrtchucvu.StylePriority.UseFont = false;
        this.xrtchucvu.StylePriority.UseTextAlignment = false;
        this.xrtchucvu.Text = "10";
        this.xrtchucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrtchucvu.Weight = 0.240000097517713D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "11";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.24000007792921918D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = "12";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell6.Weight = 0.24000007767171916D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "13";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.24000008707971665D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "14";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 0.24000008224696823D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "15";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.24000006075709945D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "16";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 0.24000007862240658D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "17";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 0.24000008755506008D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "18";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 0.2400000920213865D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "19";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell14.Weight = 0.24000009425455016D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.Text = "20";
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell16.Weight = 0.24000009537113187D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseTextAlignment = false;
        this.xrTableCell21.Text = "21";
        this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell21.Weight = 0.2400000959294224D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "22";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.24000009620856821D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.Text = "23";
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell23.Weight = 0.24000017264211682D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseTextAlignment = false;
        this.xrTableCell24.Text = "24";
        this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell24.Weight = 0.24000013456491509D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseTextAlignment = false;
        this.xrTableCell22.Text = "25";
        this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell22.Weight = 0.24000011552631428D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.StylePriority.UseTextAlignment = false;
        this.xrTableCell25.Text = "26";
        this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell25.Weight = 0.24000010600701383D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseTextAlignment = false;
        this.xrTableCell26.Text = "27";
        this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell26.Weight = 0.2400001012473636D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseTextAlignment = false;
        this.xrTableCell27.Text = "28";
        this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell27.Weight = 0.24000009886753854D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseTextAlignment = false;
        this.xrTableCell29.Text = "29";
        this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell29.Weight = 0.2400000976776259D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseTextAlignment = false;
        this.xrTableCell28.Text = "30";
        this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell28.Weight = 0.24000009708266967D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.StylePriority.UseTextAlignment = false;
        this.xrTableCell30.Text = "31";
        this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell30.Weight = 0.24000009708266967D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrLabel4});
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Quy ra công ";
        this.xrTableCell12.Weight = 1.8555610428091331D;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 29.58336F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(189F, 25.41666F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UsePadding = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell32,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell31});
        this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.StylePriority.UseFont = false;
        this.xrTableRow3.StylePriority.UseTextAlignment = false;
        this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.Text = "HL";
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.28262795735156571D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseFont = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.Text = "NP";
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell18.Weight = 0.282627961552973D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseFont = false;
        this.xrTableCell19.StylePriority.UseTextAlignment = false;
        this.xrTableCell19.Text = "NB";
        this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell19.Weight = 0.28262795813980135D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseFont = false;
        this.xrTableCell20.StylePriority.UseTextAlignment = false;
        this.xrTableCell20.Text = "KL";
        this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell20.Weight = 0.2826279597975257D;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(189F, 29.58334F);
        this.xrLabel4.StylePriority.UseBorders = false;
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Quy ra công";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.Text = "Tổng";
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell15.Weight = 0.43130817351683315D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel6,
            this.xrLabel5,
            this.xrlNguoiBC3,
            this.xrlNguoiBC2,
            this.xrlFT2,
            this.xrlNguoiBC1,
            this.xrtngayketxuat,
            this.xrlFT1,
            this.xrlFT3,
            this.xrLabel7,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel11});
        this.ReportFooter.HeightF = 226F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrlNguoiBC3
        // 
        this.xrlNguoiBC3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrlNguoiBC3.LocationFloat = new DevExpress.Utils.PointFloat(787.7367F, 203F);
        this.xrlNguoiBC3.Name = "xrlNguoiBC3";
        this.xrlNguoiBC3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNguoiBC3.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlNguoiBC3.StylePriority.UseFont = false;
        this.xrlNguoiBC3.StylePriority.UseTextAlignment = false;
        this.xrlNguoiBC3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlNguoiBC2
        // 
        this.xrlNguoiBC2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrlNguoiBC2.LocationFloat = new DevExpress.Utils.PointFloat(402.8817F, 203F);
        this.xrlNguoiBC2.Name = "xrlNguoiBC2";
        this.xrlNguoiBC2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNguoiBC2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlNguoiBC2.StylePriority.UseFont = false;
        this.xrlNguoiBC2.StylePriority.UseTextAlignment = false;
        this.xrlNguoiBC2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlFT2
        // 
        this.xrlFT2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrlFT2.LocationFloat = new DevExpress.Utils.PointFloat(407.6988F, 97.49998F);
        this.xrlFT2.Name = "xrlFT2";
        this.xrlFT2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlFT2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlFT2.StylePriority.UseFont = false;
        this.xrlFT2.StylePriority.UseTextAlignment = false;
        this.xrlFT2.Text = "XÁC NHẬN CỦA TRƯỞNG PHÒNG";
        this.xrlFT2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlNguoiBC1
        // 
        this.xrlNguoiBC1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrlNguoiBC1.LocationFloat = new DevExpress.Utils.PointFloat(13.73672F, 203F);
        this.xrlNguoiBC1.Name = "xrlNguoiBC1";
        this.xrlNguoiBC1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNguoiBC1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlNguoiBC1.StylePriority.UseFont = false;
        this.xrlNguoiBC1.StylePriority.UseTextAlignment = false;
        this.xrlNguoiBC1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(787.7366F, 72.49998F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(303.2632F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlFT1
        // 
        this.xrlFT1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrlFT1.LocationFloat = new DevExpress.Utils.PointFloat(12.73669F, 97.49998F);
        this.xrlFT1.Name = "xrlFT1";
        this.xrlFT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlFT1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrlFT1.StylePriority.UseFont = false;
        this.xrlFT1.StylePriority.UseTextAlignment = false;
        this.xrlFT1.Text = "NGƯỜI CHẤM CÔNG";
        this.xrlFT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlFT3
        // 
        this.xrlFT3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrlFT3.LocationFloat = new DevExpress.Utils.PointFloat(787.7366F, 97.49998F);
        this.xrlFT3.Name = "xrlFT3";
        this.xrlFT3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlFT3.SizeF = new System.Drawing.SizeF(301.2634F, 23F);
        this.xrlFT3.StylePriority.UseFont = false;
        this.xrlFT3.StylePriority.UseTextAlignment = false;
        this.xrlFT3.Text = "GIÁM ĐỐC";
        this.xrlFT3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 30.83331F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(123.1449F, 23F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.Text = "Ký hiệu báo cáo:";
        // 
        // xrLabel10
        // 
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(273.1475F, 30.83331F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(177.8941F, 23F);
        this.xrLabel10.Text = "LTV: Hưởng lương thử việc";
        // 
        // xrLabel9
        // 
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(141.8975F, 30.83331F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(131.25F, 23F);
        this.xrLabel9.Text = "HL: Hưởng lương";
        // 
        // xrLabel11
        // 
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(451.0416F, 30.83331F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(106.7216F, 23F);
        this.xrLabel11.Text = "NP: Nghỉ phép";
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
        this.GroupHeader1.HeightF = 25.42F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable8
        // 
        this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(1.902294F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(1134.098F, 25.42F);
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
        // PageFooter
        // 
        this.PageFooter.HeightF = 25F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseFont = false;
        this.xrTableCell31.StylePriority.UseTextAlignment = false;
        this.xrTableCell31.Text = "BH";
        this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell31.Weight = 0.28262795979752564D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseFont = false;
        this.xrTableCell32.StylePriority.UseTextAlignment = false;
        this.xrTableCell32.Text = "LTV";
        this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell32.Weight = 0.28262794443963812D;
        // 
        // xrLabel5
        // 
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(557.7632F, 30.83331F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(98.11353F, 23F);
        this.xrLabel5.Text = "NB: Nghỉ bù";
        // 
        // xrLabel6
        // 
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(655.8766F, 30.83331F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(114.0338F, 23F);
        this.xrLabel6.Text = "KL: Không lương";
        // 
        // xrLabel8
        // 
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(769.9104F, 30.83331F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(131.25F, 23F);
        this.xrLabel8.Text = "BH: Bảo hiểm xã hội";
        // 
        // xrNB
        // 
        this.xrNB.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrNB.Name = "xrNB";
        this.xrNB.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrNB.StylePriority.UseFont = false;
        this.xrNB.StylePriority.UsePadding = false;
        this.xrNB.StylePriority.UseTextAlignment = false;
        this.xrNB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrNB.Weight = 0.308215474937548D;
        // 
        // xrKL
        // 
        this.xrKL.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrKL.Name = "xrKL";
        this.xrKL.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrKL.StylePriority.UseFont = false;
        this.xrKL.StylePriority.UsePadding = false;
        this.xrKL.StylePriority.UseTextAlignment = false;
        this.xrKL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrKL.Weight = 0.30821189969995588D;
        // 
        // rp_BangChamCongTheoThang
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.ReportHeader,
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.PageFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(23, 10, 31, 0);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
