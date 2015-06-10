using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAL;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BangTheoDoiDiMuonVeSom
/// </summary>
public class rp_BangTheoDoiDiMuonVeSom : DevExpress.XtraReports.UI.XtraReport
{
    #region properties
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrltenbaocao;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell8;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell44;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell c5;
    private XRTableCell c6;
    private XRTableCell c7;
    private XRTableCell c8;
    private XRTableCell c9;
    private XRTableCell c10;
    private XRTableCell c11;
    private XRTableCell c12;
    private XRTableCell c13;
    private XRTableCell c14;
    private XRTableCell c15;
    private XRTableCell c16;
    private XRTableCell c17;
    private XRTableCell c18;
    private XRTableCell c19;
    private XRTableCell c20;
    private XRTableCell c21;
    private XRTableCell c22;
    private XRTableCell c23;
    private XRTableCell c24;
    private XRTableCell c25;
    private XRTableCell c26;
    private XRTableCell c27;
    private XRTableCell c28;
    private XRTableCell c29;
    private XRTableCell c30;
    private XRTableCell c31;
    private XRTableCell xrtTGVeSom;
    private XRTableCell xrlHoten;
    private XRTableCell xrlSTT;
    private XRTableCell MNV;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell grpBoPhan;
    private GroupHeaderBand GroupHeader1;
    private XRTableCell xrTableCell4;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell h1;
    private XRTableCell h2;
    private XRTableCell h3;
    private XRTableCell h4;
    private XRTableCell h5;
    private XRTableCell h6;
    private XRTableCell h7;
    private XRTableCell h8;
    private XRTableCell h9;
    private XRTableCell h10;
    private XRTableCell h11;
    private XRTableCell h12;
    private XRTableCell h13;
    private XRTableCell h14;
    private XRTableCell h15;
    private XRTableCell h16;
    private XRTableCell h17;
    private XRTableCell h18;
    private XRTableCell h19;
    private XRTableCell h20;
    private XRTableCell h21;
    private XRTableCell h22;
    private XRTableCell h23;
    private XRTableCell h24;
    private XRTableCell h25;
    private XRTableCell h26;
    private XRTableCell h27;
    private XRTableCell h28;
    private XRTableCell h29;
    private XRTableCell h30;
    private XRTableCell h31;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell45;
    private XRTableCell c4;
    private XRTable xrTable39;
    private XRTableRow xrTableRow70;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell9;
    private XRTable xrTable38;
    private XRTableRow xrTableRow69;
    private XRTableCell xrTableCell3;
    private XRTableCell xrtTGDiMuon;
    private XRTableCell xrtSoLanDiMuon;
    private XRTableCell xrtSoLanVeSom;
    #endregion
    private XRTableCell c3;
    private XRTableCell c1;
    private XRTableCell c2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;


    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BangTheoDoiDiMuonVeSom()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here

    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrlSTT.Text = STT.ToString();
        STT++;
    }
    public void Bindata(ReportFilter filter)
    {

        xrl_TenCongTy.Text = new ReportController().GetCompanyName(filter.SessionDepartment);
        xrl_TenThanhPho.Text = new ReportController().GetCityName(filter.SessionDepartment);
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrltenbaocao.Text = filter.ReportTitle;
        }
        xrltenbaocao.Text = "BÁO CÁO ĐI MUỘN VỀ SỚM THÁNG " + filter.StartMonth + " NĂM " + filter.Year;
 
        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //var data = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_BangTheoDoiDiMuonVeSom","@MaDonVi", "@MaBoPhan", "@StartMonth","@Year",filter.SessionDepartment, filter.SelectedDepartment, filter.StartMonth, filter.Year);
        //DataSource = data;
        //c1.DataBindings.Add("Text", DataSource, "Ngay01");
        //c2.DataBindings.Add("Text", DataSource, "Ngay02");
        //c3.DataBindings.Add("Text", DataSource, "Ngay03");
        //c4.DataBindings.Add("Text", DataSource, "Ngay04");
        //c5.DataBindings.Add("Text", DataSource, "Ngay05");
        //c6.DataBindings.Add("Text", DataSource, "Ngay06");
        //c7.DataBindings.Add("Text", DataSource, "Ngay07");
        //c8.DataBindings.Add("Text", DataSource, "Ngay08");
        //c9.DataBindings.Add("Text", DataSource, "Ngay09");
        //c10.DataBindings.Add("Text", DataSource, "Ngay10");
        //c11.DataBindings.Add("Text", DataSource, "Ngay11");
        //c12.DataBindings.Add("Text", DataSource, "Ngay12");
        //c13.DataBindings.Add("Text", DataSource, "Ngay13");
        //c14.DataBindings.Add("Text", DataSource, "Ngay14");
        //c15.DataBindings.Add("Text", DataSource, "Ngay15");
        //c16.DataBindings.Add("Text", DataSource, "Ngay16");
        //c17.DataBindings.Add("Text", DataSource, "Ngay17");
        //c18.DataBindings.Add("Text", DataSource, "Ngay18");
        //c19.DataBindings.Add("Text", DataSource, "Ngay19");
        //c20.DataBindings.Add("Text", DataSource, "Ngay20");
        //c21.DataBindings.Add("Text", DataSource, "Ngay21");
        //c22.DataBindings.Add("Text", DataSource, "Ngay22");
        //c23.DataBindings.Add("Text", DataSource, "Ngay23");
        //c24.DataBindings.Add("Text", DataSource, "Ngay24");
        //c25.DataBindings.Add("Text", DataSource, "Ngay25");
        //c26.DataBindings.Add("Text", DataSource, "Ngay26");
        //c27.DataBindings.Add("Text", DataSource, "Ngay27");
        //c28.DataBindings.Add("Text", DataSource, "Ngay28");
        //c29.DataBindings.Add("Text", DataSource, "Ngay29");
        //c30.DataBindings.Add("Text", DataSource, "Ngay30");
        //c31.DataBindings.Add("Text", DataSource, "Ngay31");
        //xrtSoLanDiMuon.DataBindings.Add("Text", DataSource, "SoLanDiMuon");
        //xrtTGDiMuon.DataBindings.Add("Text", DataSource, "ThoiGianDiMuon"); 
        //xrtSoLanVeSom.DataBindings.Add("Text", DataSource, "SoLanVeSom");
        //xrtTGVeSom.DataBindings.Add("Text", DataSource, "ThoiGianVeSom");
      
        MNV.DataBindings.Add("Text", DataSource, "MaCB"); 
        xrlHoten.DataBindings.Add("Text", DataSource, "HoTen");

        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
        new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        grpBoPhan.DataBindings.Add("Text", DataSource, "TEN_DONVI");

        if (!string.IsNullOrEmpty(filter.Title1)) xrl_footer1.Text = filter.Title1;
        if (!string.IsNullOrEmpty(filter.Title2)) xrl_footer3.Text = filter.Title2;
        if (!string.IsNullOrEmpty(filter.Name1)) xrl_ten1.Text = filter.Name1;
        if (!string.IsNullOrEmpty(filter.Name2)) xrl_ten3.Text = filter.Name2; ; 
     //   FindDayOfWeek(rp);
    }
    DevExpress.XtraReports.UI.XRTableCell GetControlByName(string Name)
    {
        foreach (DevExpress.XtraReports.UI.XRTableCell c in this.xrTableRow2.Cells)
            if (c.Name == Name)
                return c;

        return null;
    }
    DevExpress.XtraReports.UI.XRTableCell GetControlByName1(string Name)
    {
        foreach (DevExpress.XtraReports.UI.XRTableCell c in this.xrTableRow4.Cells)
            if (c.Name == Name)
                return c;

        return null;
    }

    //private void FindDayOfWeek(ReportFillterInfoChamCong rp)
    //{
    //    int year = Convert.ToInt32(rp.nam_chamcong);
    //    int month = Convert.ToInt32(rp.thang);
    //    int totalDay = DateTime.DaysInMonth(year, month);//tổng số ngày trong tháng 
         
    //    DevExpress.XtraReports.UI.XRTableCell h = new XRTableCell();
    //    for (int i = 1; i <= totalDay; i++)
    //    {
    //        h = GetControlByName("h" + i);
    //        h.Text = i + "        " + GetVietnameseDayOfWeek(new DateTime(year, month, i).DayOfWeek.ToString()); 
    //    }  
    //}

    //private string GetVietnameseDayOfWeek(string dayOfWeek)
    // {
    //    switch (dayOfWeek)
    //    {
    //        case "Monday":
    //            return "T2";
    //        case "Tuesday":
    //            return "T3";
    //        case "Wednesday":
    //            return "T4";
    //        case "Thursday":
    //            return "T5";
    //        case "Friday":
    //            return "T6";
    //        case "Saturday":
    //            return "T7";
    //        case "Sunday":
    //            return "CN";
    //        default:
    //            return "";
    //    }
    //}

    //set weekend style + today style


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
        string resourceFileName = "rp_BangTheoDoiDiMuonVeSom.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlSTT = new DevExpress.XtraReports.UI.XRTableCell();
        this.MNV = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrlHoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.c1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtSoLanDiMuon = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtTGDiMuon = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtSoLanVeSom = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrtTGVeSom = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.grpBoPhan = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrltenbaocao = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.h1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable39 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow70 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable38 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow69 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
        this.Detail.HeightF = 30.20834F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(1719F, 30.20834F);
        this.xrTable4.StylePriority.UseBorders = false;
        this.xrTable4.StylePriority.UseTextAlignment = false;
        this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlSTT,
            this.MNV,
            this.xrlHoten,
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.c6,
            this.c7,
            this.c8,
            this.c9,
            this.c10,
            this.c11,
            this.c12,
            this.c13,
            this.c14,
            this.c15,
            this.c16,
            this.c17,
            this.c18,
            this.c19,
            this.c20,
            this.c21,
            this.c22,
            this.c23,
            this.c24,
            this.c25,
            this.c26,
            this.c27,
            this.c28,
            this.c29,
            this.c30,
            this.c31,
            this.xrtSoLanDiMuon,
            this.xrtTGDiMuon,
            this.xrtSoLanVeSom,
            this.xrtTGVeSom});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrlSTT
        // 
        this.xrlSTT.Name = "xrlSTT";
        this.xrlSTT.Weight = 0.27450147442041239D;
        this.xrlSTT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // MNV
        // 
        this.MNV.Name = "MNV";
        this.MNV.Weight = 0.42504643634718875D;
        // 
        // xrlHoten
        // 
        this.xrlHoten.Name = "xrlHoten";
        this.xrlHoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 3, 100F);
        this.xrlHoten.StylePriority.UsePadding = false;
        this.xrlHoten.StylePriority.UseTextAlignment = false;
        this.xrlHoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrlHoten.Weight = 0.8579894502448302D;
        // 
        // c1
        // 
        this.c1.Name = "c1";
        this.c1.Weight = 0.22555450096946966D;
        // 
        // c2
        // 
        this.c2.Name = "c2";
        this.c2.Weight = 0.22555450147725834D;
        // 
        // c3
        // 
        this.c3.Name = "c3";
        this.c3.Weight = 0.2255540701944955D;
        // 
        // c4
        // 
        this.c4.Name = "c4";
        this.c4.Weight = 0.22555432744078718D;
        // 
        // c5
        // 
        this.c5.Name = "c5";
        this.c5.Weight = 0.22555430335041948D;
        // 
        // c6
        // 
        this.c6.Name = "c6";
        this.c6.Weight = 0.22555413083725484D;
        // 
        // c7
        // 
        this.c7.Name = "c7";
        this.c7.Weight = 0.22555465915864925D;
        // 
        // c8
        // 
        this.c8.Name = "c8";
        this.c8.Weight = 0.22555435726065565D;
        // 
        // c9
        // 
        this.c9.Name = "c9";
        this.c9.Weight = 0.22555431413251836D;
        // 
        // c10
        // 
        this.c10.Name = "c10";
        this.c10.Weight = 0.22555396910623859D;
        // 
        // c11
        // 
        this.c11.Name = "c11";
        this.c11.Weight = 0.22555433569656969D;
        // 
        // c12
        // 
        this.c12.Name = "c12";
        this.c12.Weight = 0.2255543356966242D;
        // 
        // c13
        // 
        this.c13.Name = "c13";
        this.c13.Weight = 0.22555398756431366D;
        // 
        // c14
        // 
        this.c14.Name = "c14";
        this.c14.Weight = 0.22555502264325189D;
        // 
        // c15
        // 
        this.c15.Name = "c15";
        this.c15.Weight = 0.22555434501434002D;
        // 
        // c16
        // 
        this.c16.Name = "c16";
        this.c16.Weight = 0.22555399834651313D;
        // 
        // c17
        // 
        this.c17.Name = "c17";
        this.c17.Weight = 0.22555399834647383D;
        // 
        // c18
        // 
        this.c18.Name = "c18";
        this.c18.Weight = 0.22555467761674419D;
        // 
        // c19
        // 
        this.c19.Name = "c19";
        this.c19.Weight = 0.22555467761702175D;
        // 
        // c20
        // 
        this.c20.Name = "c20";
        this.c20.Weight = 0.2255546991809646D;
        // 
        // c21
        // 
        this.c21.Name = "c21";
        this.c21.Weight = 0.22555329751206155D;
        // 
        // c22
        // 
        this.c22.Name = "c22";
        this.c22.Weight = 0.22555398756444312D;
        // 
        // c23
        // 
        this.c23.Name = "c23";
        this.c23.Weight = 0.22555441884724548D;
        // 
        // c24
        // 
        this.c24.Name = "c24";
        this.c24.Weight = 0.22555470228693553D;
        // 
        // c25
        // 
        this.c25.Name = "c25";
        this.c25.Weight = 0.22555401223447502D;
        // 
        // c26
        // 
        this.c26.Name = "c26";
        this.c26.Weight = 0.22555328218930792D;
        // 
        // c27
        // 
        this.c27.Name = "c27";
        this.c27.Weight = 0.22555535234653024D;
        // 
        // c28
        // 
        this.c28.Name = "c28";
        this.c28.Weight = 0.22555328218934834D;
        // 
        // c29
        // 
        this.c29.Name = "c29";
        this.c29.Weight = 0.2255539891617141D;
        // 
        // c30
        // 
        this.c30.Name = "c30";
        this.c30.Weight = 0.22555463833409162D;
        // 
        // c31
        // 
        this.c31.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.c31.Name = "c31";
        this.c31.StylePriority.UseBorders = false;
        this.c31.Weight = 0.225556057335475D;
        // 
        // xrtSoLanDiMuon
        // 
        this.xrtSoLanDiMuon.Name = "xrtSoLanDiMuon";
        this.xrtSoLanDiMuon.Weight = 0.28264356788059652D;
        // 
        // xrtTGDiMuon
        // 
        this.xrtTGDiMuon.Name = "xrtTGDiMuon";
        this.xrtTGDiMuon.Weight = 0.28617715974624114D;
        // 
        // xrtSoLanVeSom
        // 
        this.xrtSoLanVeSom.Name = "xrtSoLanVeSom";
        this.xrtSoLanVeSom.Weight = 0.31263100934075744D;
        // 
        // xrtTGVeSom
        // 
        this.xrtTGVeSom.Name = "xrtTGVeSom";
        this.xrtTGVeSom.Weight = 0.28617797918349058D;
        // 
        // xrTable9
        // 
        this.xrTable9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable9.SizeF = new System.Drawing.SizeF(1719F, 25F);
        this.xrTable9.StylePriority.UseBorders = false;
        this.xrTable9.StylePriority.UseTextAlignment = false;
        this.xrTable9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.grpBoPhan});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // grpBoPhan
        // 
        this.grpBoPhan.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.grpBoPhan.Name = "grpBoPhan";
        this.grpBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 0, 0, 0, 100F);
        this.grpBoPhan.StylePriority.UseFont = false;
        this.grpBoPhan.StylePriority.UsePadding = false;
        this.grpBoPhan.StylePriority.UseTextAlignment = false;
        this.grpBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.grpBoPhan.Weight = 6.0033898138233175D;
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
            this.xrLabel2,
            this.xrLabel1,
            this.xrltenbaocao,
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
        this.ReportHeader.HeightF = 135F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel2
        // 
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1459.57F, 107.2084F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(153.5F, 17.79166F);
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Ký hiệu: Đi muộn/Về sớm";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel1
        // 
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1633.625F, 107.2084F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(75.375F, 17.79166F);
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "ĐVT: Phút";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrltenbaocao
        // 
        this.xrltenbaocao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrltenbaocao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 73.74995F);
        this.xrltenbaocao.Multiline = true;
        this.xrltenbaocao.Name = "xrltenbaocao";
        this.xrltenbaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrltenbaocao.SizeF = new System.Drawing.SizeF(1719F, 23F);
        this.xrltenbaocao.StylePriority.UseFont = false;
        this.xrltenbaocao.StylePriority.UseTextAlignment = false;
        this.xrltenbaocao.Text = "BÁO CÁO ĐI MUỘN VỀ SỚM ";
        this.xrltenbaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.00001F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(435.1307F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "Xí Nghiệp Môi trường đô thị";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(435.1308F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "Ủy ban nhân dân Huyện Từ Liêm";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 70F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1719F, 70F);
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell2,
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell1});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.StylePriority.UseBorders = false;
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "STT";
        this.xrTableCell8.Weight = 0.23305085237003623D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Mã cán bộ";
        this.xrTableCell2.Weight = 0.36086293228070604D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Họ tên";
        this.xrTableCell7.Weight = 0.7284303668272043D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable8});
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Weight = 5.9363393727912079D;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 27.08333F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1236.917F, 42.91666F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.h1,
            this.h2,
            this.h3,
            this.h4,
            this.h5,
            this.h6,
            this.h7,
            this.h8,
            this.h9,
            this.h10,
            this.h11,
            this.h12,
            this.h13,
            this.h14,
            this.h15,
            this.h16,
            this.h17,
            this.h18,
            this.h19,
            this.h20,
            this.h21,
            this.h22,
            this.h23,
            this.h24,
            this.h25,
            this.h26,
            this.h27,
            this.h28,
            this.h29,
            this.h30,
            this.h31});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // h1
        // 
        this.h1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.h1.Name = "h1";
        this.h1.StylePriority.UseFont = false;
        this.h1.Text = "1";
        this.h1.Weight = 0.19354835514224042D;
        // 
        // h2
        // 
        this.h2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.h2.Name = "h2";
        this.h2.StylePriority.UseFont = false;
        this.h2.Text = "2";
        this.h2.Weight = 0.19354835514224039D;
        // 
        // h3
        // 
        this.h3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.h3.Name = "h3";
        this.h3.StylePriority.UseFont = false;
        this.h3.Text = "3";
        this.h3.Weight = 0.19354835514224042D;
        // 
        // h4
        // 
        this.h4.Name = "h4";
        this.h4.Text = "4";
        this.h4.Weight = 0.19354835514224039D;
        // 
        // h5
        // 
        this.h5.Name = "h5";
        this.h5.Text = "5";
        this.h5.Weight = 0.19354835514224036D;
        // 
        // h6
        // 
        this.h6.Name = "h6";
        this.h6.Text = "6";
        this.h6.Weight = 0.19354835514224045D;
        // 
        // h7
        // 
        this.h7.Name = "h7";
        this.h7.Text = "7";
        this.h7.Weight = 0.19354835514224036D;
        // 
        // h8
        // 
        this.h8.Name = "h8";
        this.h8.Text = "8";
        this.h8.Weight = 0.19354835514224039D;
        // 
        // h9
        // 
        this.h9.Name = "h9";
        this.h9.Text = "9";
        this.h9.Weight = 0.19354835514224039D;
        // 
        // h10
        // 
        this.h10.Name = "h10";
        this.h10.Text = "10";
        this.h10.Weight = 0.19354835514224034D;
        // 
        // h11
        // 
        this.h11.Name = "h11";
        this.h11.Text = "11";
        this.h11.Weight = 0.19354835514224034D;
        // 
        // h12
        // 
        this.h12.Name = "h12";
        this.h12.Text = "12";
        this.h12.Weight = 0.19354835514224042D;
        // 
        // h13
        // 
        this.h13.Name = "h13";
        this.h13.Text = "13";
        this.h13.Weight = 0.1935483736004493D;
        // 
        // h14
        // 
        this.h14.Name = "h14";
        this.h14.Text = "14";
        this.h14.Weight = 0.1935483736004493D;
        // 
        // h15
        // 
        this.h15.Name = "h15";
        this.h15.Text = "15";
        this.h15.Weight = 0.19354829976761345D;
        // 
        // h16
        // 
        this.h16.Name = "h16";
        this.h16.Text = "16";
        this.h16.Weight = 0.1935483736004493D;
        // 
        // h17
        // 
        this.h17.Name = "h17";
        this.h17.Text = "17";
        this.h17.Weight = 0.19354837360044974D;
        // 
        // h18
        // 
        this.h18.Name = "h18";
        this.h18.Text = "18";
        this.h18.Weight = 0.1935483736004493D;
        // 
        // h19
        // 
        this.h19.Name = "h19";
        this.h19.Text = "19";
        this.h19.Weight = 0.1935483736004493D;
        // 
        // h20
        // 
        this.h20.Name = "h20";
        this.h20.Text = "20";
        this.h20.Weight = 0.19354837360044974D;
        // 
        // h21
        // 
        this.h21.Name = "h21";
        this.h21.Text = "21";
        this.h21.Weight = 0.1935483736004493D;
        // 
        // h22
        // 
        this.h22.Name = "h22";
        this.h22.Text = "22";
        this.h22.Weight = 0.19354837360044952D;
        // 
        // h23
        // 
        this.h23.Name = "h23";
        this.h23.Text = "23";
        this.h23.Weight = 0.19354837360044974D;
        // 
        // h24
        // 
        this.h24.Name = "h24";
        this.h24.Text = "24";
        this.h24.Weight = 0.19354835514224045D;
        // 
        // h25
        // 
        this.h25.Name = "h25";
        this.h25.Text = "25";
        this.h25.Weight = 0.19354835514224045D;
        // 
        // h26
        // 
        this.h26.Name = "h26";
        this.h26.Text = "26";
        this.h26.Weight = 0.19354831514945425D;
        // 
        // h27
        // 
        this.h27.Name = "h27";
        this.h27.Text = "27";
        this.h27.Weight = 0.19354831514945436D;
        // 
        // h28
        // 
        this.h28.Name = "h28";
        this.h28.Text = "28";
        this.h28.Weight = 0.19354831514945448D;
        // 
        // h29
        // 
        this.h29.Name = "h29";
        this.h29.Text = "29";
        this.h29.Weight = 0.19354833206947913D;
        // 
        // h30
        // 
        this.h30.Name = "h30";
        this.h30.Text = "30";
        this.h30.Weight = 0.19354837744590947D;
        // 
        // h31
        // 
        this.h31.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.h31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.h31.Name = "h31";
        this.h31.StylePriority.UseBorders = false;
        this.h31.StylePriority.UseFont = false;
        this.h31.Text = "31";
        this.h31.Weight = 0.1935457932966578D;
        // 
        // xrTable8
        // 
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(1236.918F, 27.08333F);
        this.xrTable8.StylePriority.UseFont = false;
        this.xrTable8.StylePriority.UseTextAlignment = false;
        this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell45
        // 
        this.xrTableCell45.Borders = DevExpress.XtraPrinting.BorderSide.Top;
        this.xrTableCell45.Name = "xrTableCell45";
        this.xrTableCell45.StylePriority.UseBorders = false;
        this.xrTableCell45.Text = "NGÀY LÀM VIỆC TRONG THÁNG";
        this.xrTableCell45.Weight = 1.00625D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable39,
            this.xrTable38,
            this.xrTable7,
            this.xrTable3});
        this.xrTableCell1.Multiline = true;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Weight = 0.99131564236615655D;
        // 
        // xrTable39
        // 
        this.xrTable39.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable39.LocationFloat = new DevExpress.Utils.PointFloat(100.6249F, 27.08333F);
        this.xrTable39.Name = "xrTable39";
        this.xrTable39.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow70});
        this.xrTable39.SizeF = new System.Drawing.SizeF(105.9293F, 42.91669F);
        this.xrTable39.StylePriority.UseBorders = false;
        // 
        // xrTableRow70
        // 
        this.xrTableRow70.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell9});
        this.xrTableRow70.Name = "xrTableRow70";
        this.xrTableRow70.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Số lần";
        this.xrTableCell5.Weight = 0.55304721674882806D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.Text = "TG";
        this.xrTableCell9.Weight = 0.50625129700356086D;
        // 
        // xrTable38
        // 
        this.xrTable38.LocationFloat = new DevExpress.Utils.PointFloat(100.625F, 0F);
        this.xrTable38.Name = "xrTable38";
        this.xrTable38.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow69});
        this.xrTable38.SizeF = new System.Drawing.SizeF(105.9291F, 27.08334F);
        // 
        // xrTableRow69
        // 
        this.xrTableRow69.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
        this.xrTableRow69.Name = "xrTableRow69";
        this.xrTableRow69.Weight = 1D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.Text = "Về sớm";
        this.xrTableCell3.Weight = 1.00625D;
        // 
        // xrTable7
        // 
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0.0003662109F, 0F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(100.6245F, 27.08334F);
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell44});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell44
        // 
        this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell44.Name = "xrTableCell44";
        this.xrTableCell44.StylePriority.UseBorders = false;
        this.xrTableCell44.Text = "Đi muộn";
        this.xrTableCell44.Weight = 1.00625D;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0.0003662109F, 27.08333F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(100.6245F, 42.91668F);
        this.xrTable3.StylePriority.UseBorders = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell38,
            this.xrTableCell39});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.Text = "Số lần";
        this.xrTableCell38.Weight = 0.49999999999999983D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseBorders = false;
        this.xrTableCell39.Text = "TG";
        this.xrTableCell39.Weight = 0.5062500000000002D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten1,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer3,
            this.xrl_footer1});
        this.ReportFooter.HeightF = 220F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(385.3583F, 147.5F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(209.375F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1306.529F, 147.5F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(306.5418F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1306.529F, 10.00001F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(306.5414F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1306.529F, 35.00001F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(306.5414F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "TRƯỞNG BỘ PHẬN";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(385.3583F, 35.00001F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(209.375F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP BÁO CÁO";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(925.9583F, 45.83333F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable9});
        this.GroupHeader1.HeightF = 25F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // rp_BangTheoDoiDiMuonVeSom
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
        this.Margins = new System.Drawing.Printing.Margins(17, 16, 49, 100);
        this.PageHeight = 1268;
        this.PageWidth = 1752;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3Extra;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
