using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_ap_BangTongHopChiTietTienCom
/// </summary>
public class rp_ap_BangTongHopChiTietTienCom : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrlChiTietTienCom;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
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
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell40;
    private XRTableCell xrGoupTen;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrSTT;
    private XRTableCell xrTen;
    private XRTableCell xrNgay1;
    private XRTableCell xrNgay2;
    private XRTableCell xrNgay3;
    private XRTableCell xrNgay4;
    private XRTableCell xrNgay5;
    private XRTableCell xrNgay6;
    private XRTableCell xrNgay7;
    private XRTableCell xrNgay8;
    private XRTableCell xrNgay9;
    private XRTableCell xrNgay10;
    private XRTableCell xrNgay11;
    private XRTableCell xrNgay12;
    private XRTableCell xrNgay13;
    private XRTableCell xrNgay14;
    private XRTableCell xrNgay15;
    private XRTableCell xrNgay16;
    private XRTableCell xrNgay17;
    private XRTableCell xrNgay18;
    private XRTableCell xrNgay19;
    private XRTableCell xrNgay20;
    private XRTableCell xrNgay21;
    private XRTableCell xrNgay22;
    private XRTableCell xrNgay23;
    private XRTableCell xrNgay24;
    private XRTableCell xrNgay25;
    private XRTableCell xrNgay26;
    private XRTableCell xrNgay27;
    private XRTableCell xrNgay28;
    private XRTableCell xrNgay29;
    private XRTableCell xrNgay30;
    private XRTableCell xrNgay31;
    private XRTableCell xrTongXuat;
    private XRTableCell xrThanhTien;
    private XRTableCell xrComKhac;
    private XRTableCell xrTongComKhacVaXuat;
    private ReportFooterBand ReportFooter;
    private GroupFooterBand GroupFooter4;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell155;
    private XRTableCell xrTableCell156;
    private XRTableCell xrCongNgay1;
    private XRTableCell xrCongNgay2;
    private XRTableCell xrCongNgay3;
    private XRTableCell xrCongNgay4;
    private XRTableCell xrCongNgay5;
    private XRTableCell xrCongNgay6;
    private XRTableCell xrCongNgay7;
    private XRTableCell xrCongNgay8;
    private XRTableCell xrCongNgay9;
    private XRTableCell xrCongNgay10;
    private XRTableCell xrCongNgay11;
    private XRTableCell xrCongNgay12;
    private XRTableCell xrCongNgay13;
    private XRTableCell xrCongNgay15;
    private XRTableCell xrCongNgay16;
    private XRTableCell xrCongNgay17;
    private XRTableCell xrCongNgay18;
    private XRTableCell xrCongNgay19;
    private XRTableCell xrCongNgay20;
    private XRTableCell xrCongNgay21;
    private XRTableCell xrCongNgay22;
    private XRTableCell xrCongNgay23;
    private XRTableCell xrCongNgay24;
    private XRTableCell xrCongNgay25;
    private XRTableCell xrCongNgay26;
    private XRTableCell xrCongNgay27;
    private XRTableCell xrCongNgay28;
    private XRTableCell xrCongNgay29;
    private XRTableCell xrCongNgay30;
    private XRTableCell xrCongNgay31;
    private XRTableCell xrCongTongXuat;
    private XRTableCell xrCongThanhTien;
    private XRTableCell xrCongComKhac;
    private XRTableCell xrCongTongComKhacVaXuat;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell192;
    private XRTableCell xrTableCell193;
    private XRTableCell xrTongCongNgay1;
    private XRTableCell xrTongCongNgay2;
    private XRTableCell xrTongCongNgay3;
    private XRTableCell xrTongCongNgay4;
    private XRTableCell xrTongCongNgay5;
    private XRTableCell xrTongCongNgay6;
    private XRTableCell xrTongCongNgay7;
    private XRTableCell xrTongCongNgay8;
    private XRTableCell xrTongCongNgay9;
    private XRTableCell xrTongCongNgay10;
    private XRTableCell xrTongCongNgay11;
    private XRTableCell xrTongCongNgay12;
    private XRTableCell xrTongCongNgay13;
    private XRTableCell xrTongCongNgay14;
    private XRTableCell xrTongCongNgay15;
    private XRTableCell xrTongCongNgay16;
    private XRTableCell xrTongCongNgay17;
    private XRTableCell xrTongCongNgay18;
    private XRTableCell xrTongCongNgay19;
    private XRTableCell xrTongCongNgay20;
    private XRTableCell xrTongCongNgay21;
    private XRTableCell xrTongCongNgay22;
    private XRTableCell xrTongCongNgay23;
    private XRTableCell xrTongCongNgay24;
    private XRTableCell xrTongCongNgay25;
    private XRTableCell xrTongCongNgay26;
    private XRTableCell xrTongCongNgay27;
    private XRTableCell xrTongCongNgay28;
    private XRTableCell xrTongCongNgay29;
    private XRTableCell xrTongCongNgay30;
    private XRTableCell xrTongCongNgay31;
    private XRTableCell xrTongCongTongXuat;
    private XRTableCell xrTongCongThanhTien;
    private XRTableCell xrTongCongComKhac;
    private XRTableCell xrTongCongCongTongComKhacVaXuat;
    private XRTableCell xrCongNgay14;
    private DevExpress.XtraReports.UI.XRLabel xrlNgayLapPhieu;
    private DevExpress.XtraReports.UI.XRLabel xrlTen2;
    private DevExpress.XtraReports.UI.XRLabel xrl_footer2;
    private DevExpress.XtraReports.UI.XRLabel xrl;
    private DevExpress.XtraReports.UI.XRLabel xrl_footer1;
    private DevExpress.XtraReports.UI.XRLabel xrlTenPhuTrachChiNhanh;
    private DevExpress.XtraReports.UI.XRLabel xrl_NguoiLap;
    private DevExpress.XtraReports.UI.XRLabel xrl_footer3;
    private DevExpress.XtraReports.UI.XRLabel xrlThuKho;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_ap_BangTongHopChiTietTienCom()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

    }
    int STT = 1;
    private void xrSTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrSTT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        xrlNgayLapPhieu.Text = " Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //xrl_TenCongTy.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartmentID);
        //xrl_ThanhPho.Text = ReportController.GetInstance().GetCityName(filter.SessionDepartmentID);
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_ChamCongCom", "@MaBoPhan", "@Month", "@Year","@whereClause", filter.SelectedDepartment, filter.StartMonth, filter.Year, filter.WhereClause);
        DataSource = table;
        if (table!=null)
        {
            xrTen.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrNgay1.DataBindings.Add("Text", DataSource, "Ngay1");
            xrNgay2.DataBindings.Add("Text", DataSource, "Ngay2");
            xrNgay3.DataBindings.Add("Text", DataSource, "Ngay3");
            xrNgay4.DataBindings.Add("Text", DataSource, "Ngay4");
            xrNgay5.DataBindings.Add("Text", DataSource, "Ngay5");
            xrNgay6.DataBindings.Add("Text", DataSource, "Ngay6");
            xrNgay7.DataBindings.Add("Text", DataSource, "Ngay7");
            xrNgay8.DataBindings.Add("Text", DataSource, "Ngay8");
            xrNgay9.DataBindings.Add("Text", DataSource, "Ngay9");
            xrNgay10.DataBindings.Add("Text", DataSource, "Ngay10");
            xrNgay11.DataBindings.Add("Text", DataSource, "Ngay11");
            xrNgay12.DataBindings.Add("Text", DataSource, "Ngay12");
            xrNgay13.DataBindings.Add("Text", DataSource, "Ngay13");
            xrNgay14.DataBindings.Add("Text", DataSource, "Ngay14");
            xrNgay15.DataBindings.Add("Text", DataSource, "Ngay15");
            xrNgay16.DataBindings.Add("Text", DataSource, "Ngay16");
            xrNgay17.DataBindings.Add("Text", DataSource, "Ngay17");
            xrNgay18.DataBindings.Add("Text", DataSource, "Ngay18");
            xrNgay19.DataBindings.Add("Text", DataSource, "Ngay19");
            xrNgay20.DataBindings.Add("Text", DataSource, "Ngay20");
            xrNgay21.DataBindings.Add("Text", DataSource, "Ngay21");
            xrNgay22.DataBindings.Add("Text", DataSource, "Ngay22");
            xrNgay23.DataBindings.Add("Text", DataSource, "Ngay23");
            xrNgay24.DataBindings.Add("Text", DataSource, "Ngay24");
            xrNgay25.DataBindings.Add("Text", DataSource, "Ngay25");
            xrNgay26.DataBindings.Add("Text", DataSource, "Ngay26");
            xrNgay27.DataBindings.Add("Text", DataSource, "Ngay27");
            xrNgay28.DataBindings.Add("Text", DataSource, "Ngay28");
            xrNgay29.DataBindings.Add("Text", DataSource, "Ngay29");
            xrNgay30.DataBindings.Add("Text", DataSource, "Ngay30");
            xrNgay31.DataBindings.Add("Text", DataSource, "Ngay31");
            xrTongXuat.DataBindings.Add("Text", DataSource, "TongXuat");
            xrCongTongXuat.DataBindings.Add("Text", DataSource, "TongXuat");
            xrTongCongTongXuat.DataBindings.Add("Text", DataSource, "TongXuat");
            xrThanhTien.DataBindings.Add("Text", DataSource, "ThanhTien");
            xrCongThanhTien.DataBindings.Add("Text", DataSource, "ThanhTien");
            xrTongCongThanhTien.DataBindings.Add("Text", DataSource, "ThanhTien");
            xrCongNgay1.DataBindings.Add("Text", DataSource, "Ngay1");
            xrCongNgay2.DataBindings.Add("Text", DataSource, "Ngay2");
            xrCongNgay3.DataBindings.Add("Text", DataSource, "Ngay3");
            xrCongNgay4.DataBindings.Add("Text", DataSource, "Ngay4");
            xrCongNgay5.DataBindings.Add("Text", DataSource, "Ngay5");
            xrCongNgay6.DataBindings.Add("Text", DataSource, "Ngay6");
            xrCongNgay7.DataBindings.Add("Text", DataSource, "Ngay7");
            xrCongNgay8.DataBindings.Add("Text", DataSource, "Ngay8");
            xrCongNgay9.DataBindings.Add("Text", DataSource, "Ngay9");
            xrCongNgay10.DataBindings.Add("Text", DataSource, "Ngay10");
            xrCongNgay11.DataBindings.Add("Text", DataSource, "Ngay11");
            xrCongNgay12.DataBindings.Add("Text", DataSource, "Ngay12");
            xrCongNgay13.DataBindings.Add("Text", DataSource, "Ngay13");
            xrCongNgay14.DataBindings.Add("Text", DataSource, "Ngay14");
            xrCongNgay15.DataBindings.Add("Text", DataSource, "Ngay15");
            xrCongNgay16.DataBindings.Add("Text", DataSource, "Ngay16");
            xrCongNgay17.DataBindings.Add("Text", DataSource, "Ngay17");
            xrCongNgay18.DataBindings.Add("Text", DataSource, "Ngay18");
            xrCongNgay19.DataBindings.Add("Text", DataSource, "Ngay19");
            xrCongNgay20.DataBindings.Add("Text", DataSource, "Ngay20");
            xrCongNgay21.DataBindings.Add("Text", DataSource, "Ngay21");
            xrCongNgay22.DataBindings.Add("Text", DataSource, "Ngay22");
            xrCongNgay23.DataBindings.Add("Text", DataSource, "Ngay23");
            xrCongNgay24.DataBindings.Add("Text", DataSource, "Ngay24");
            xrCongNgay25.DataBindings.Add("Text", DataSource, "Ngay25");
            xrCongNgay26.DataBindings.Add("Text", DataSource, "Ngay26");
            xrCongNgay27.DataBindings.Add("Text", DataSource, "Ngay27");
            xrCongNgay28.DataBindings.Add("Text", DataSource, "Ngay28");
            xrCongNgay29.DataBindings.Add("Text", DataSource, "Ngay29");
            xrCongNgay30.DataBindings.Add("Text", DataSource, "Ngay30");
            xrCongNgay31.DataBindings.Add("Text", DataSource, "Ngay31");
            xrTongCongNgay1.DataBindings.Add("Text", DataSource, "Ngay1");
            xrTongCongNgay2.DataBindings.Add("Text", DataSource, "Ngay2");
            xrTongCongNgay3.DataBindings.Add("Text", DataSource, "Ngay3");
            xrTongCongNgay4.DataBindings.Add("Text", DataSource, "Ngay4");
            xrTongCongNgay5.DataBindings.Add("Text", DataSource, "Ngay5");
            xrTongCongNgay6.DataBindings.Add("Text", DataSource, "Ngay6");
            xrTongCongNgay7.DataBindings.Add("Text", DataSource, "Ngay7");
            xrTongCongNgay8.DataBindings.Add("Text", DataSource, "Ngay8");
            xrTongCongNgay9.DataBindings.Add("Text", DataSource, "Ngay9");
            xrTongCongNgay10.DataBindings.Add("Text", DataSource, "Ngay10");
            xrTongCongNgay11.DataBindings.Add("Text", DataSource, "Ngay11");
            xrTongCongNgay12.DataBindings.Add("Text", DataSource, "Ngay12");
            xrTongCongNgay13.DataBindings.Add("Text", DataSource, "Ngay13");
            xrTongCongNgay14.DataBindings.Add("Text", DataSource, "Ngay14");
            xrTongCongNgay15.DataBindings.Add("Text", DataSource, "Ngay15");
            xrTongCongNgay16.DataBindings.Add("Text", DataSource, "Ngay16");
            xrTongCongNgay17.DataBindings.Add("Text", DataSource, "Ngay17");
            xrTongCongNgay18.DataBindings.Add("Text", DataSource, "Ngay18");
            xrTongCongNgay19.DataBindings.Add("Text", DataSource, "Ngay19");
            xrTongCongNgay20.DataBindings.Add("Text", DataSource, "Ngay20");
            xrTongCongNgay21.DataBindings.Add("Text", DataSource, "Ngay21");
            xrTongCongNgay22.DataBindings.Add("Text", DataSource, "Ngay22");
            xrTongCongNgay23.DataBindings.Add("Text", DataSource, "Ngay23");
            xrTongCongNgay24.DataBindings.Add("Text", DataSource, "Ngay24");
            xrTongCongNgay25.DataBindings.Add("Text", DataSource, "Ngay25");
            xrTongCongNgay26.DataBindings.Add("Text", DataSource, "Ngay26");
            xrTongCongNgay27.DataBindings.Add("Text", DataSource, "Ngay27");
            xrTongCongNgay28.DataBindings.Add("Text", DataSource, "Ngay28");
            xrTongCongNgay29.DataBindings.Add("Text", DataSource, "Ngay29");
            xrTongCongNgay30.DataBindings.Add("Text", DataSource, "Ngay30");
            xrTongCongNgay31.DataBindings.Add("Text", DataSource, "Ngay31");
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TEN_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            xrGoupTen.DataBindings.Add("Text", DataSource, "TEN_DONVI"); 
        }

        if (!string.IsNullOrEmpty(filter.Title1))
        {
            xrl_footer1.Text = filter.Title1;
        }
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrl_footer2.Text = filter.Title2;
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrl_footer3.Text = filter.Title3;
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrlThuKho.Text = filter.Name3;
        }
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrlTenPhuTrachChiNhanh.Text = filter.Name1;
        }

        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrlTen2.Text = filter.Name2;
        }
        if (!string.IsNullOrEmpty(filter.Reporter))
        {
            xrl_NguoiLap.Text = filter.Reporter;
        }
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrlChiTietTienCom.Text = filter.ReportTitle;
        }
        else
        {

            xrlChiTietTienCom.Text = "BẢNG TỔNG HỢP CHI TIẾT TIỀN CƠM THÁNG " + filter.StartMonth + "/" + filter.Year;

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
        string resourceFileName = "rp_ap_BangTongHopChiTietTienCom.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary17 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary18 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary19 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary20 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary21 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary22 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary23 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary24 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary25 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary26 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary27 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary28 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary29 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary30 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary31 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary32 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary33 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary34 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary35 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary36 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary37 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary38 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary39 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary40 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary41 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary42 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary43 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary44 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary45 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary46 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary47 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary48 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary49 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary50 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary51 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary52 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary53 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary54 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary55 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary56 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary57 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary58 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary59 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary60 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary61 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary62 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary63 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary64 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary65 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary66 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrSTT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrNgay31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongXuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrThanhTien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrComKhac = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongComKhacVaXuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrlChiTietTienCom = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrGoupTen = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlThuKho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNgayLapPhieu = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlTen2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlTenPhuTrachChiNhanh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NguoiLap = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell192 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell193 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongNgay31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongTongXuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongThanhTien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongComKhac = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTongCongCongTongComKhacVaXuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell156 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongNgay31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongTongXuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongThanhTien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongComKhac = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrCongTongComKhacVaXuat = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.Detail.Dpi = 254F;
        this.Detail.HeightF = 71F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.Dpi = 254F;
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(3506F, 69.06252F);
        this.xrTable3.StylePriority.UseBorders = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrSTT,
            this.xrTen,
            this.xrNgay1,
            this.xrNgay2,
            this.xrNgay3,
            this.xrNgay4,
            this.xrNgay5,
            this.xrNgay6,
            this.xrNgay7,
            this.xrNgay8,
            this.xrNgay9,
            this.xrNgay10,
            this.xrNgay11,
            this.xrNgay12,
            this.xrNgay13,
            this.xrNgay14,
            this.xrNgay15,
            this.xrNgay16,
            this.xrNgay17,
            this.xrNgay18,
            this.xrNgay19,
            this.xrNgay20,
            this.xrNgay21,
            this.xrNgay22,
            this.xrNgay23,
            this.xrNgay24,
            this.xrNgay25,
            this.xrNgay26,
            this.xrNgay27,
            this.xrNgay28,
            this.xrNgay29,
            this.xrNgay30,
            this.xrNgay31,
            this.xrTongXuat,
            this.xrThanhTien,
            this.xrComKhac,
            this.xrTongComKhacVaXuat});
        this.xrTableRow3.Dpi = 254F;
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrSTT
        // 
        this.xrSTT.Dpi = 254F;
        this.xrSTT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrSTT.Name = "xrSTT";
        this.xrSTT.StylePriority.UseFont = false;
        this.xrSTT.StylePriority.UseTextAlignment = false;
        this.xrSTT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrSTT.Weight = 0.075673852624445384D;
        this.xrSTT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSTT_BeforePrint);
        // 
        // xrTen
        // 
        this.xrTen.Dpi = 254F;
        this.xrTen.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTen.Name = "xrTen";
        this.xrTen.StylePriority.UseFont = false;
        this.xrTen.StylePriority.UseTextAlignment = false;
        this.xrTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTen.Weight = 0.38131059688618363D;
        // 
        // xrNgay1
        // 
        this.xrNgay1.Dpi = 254F;
        this.xrNgay1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay1.Name = "xrNgay1";
        this.xrNgay1.StylePriority.UseFont = false;
        this.xrNgay1.StylePriority.UseTextAlignment = false;
        this.xrNgay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay1.Weight = 0.065420561050489462D;
        // 
        // xrNgay2
        // 
        this.xrNgay2.Dpi = 254F;
        this.xrNgay2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay2.Name = "xrNgay2";
        this.xrNgay2.StylePriority.UseFont = false;
        this.xrNgay2.StylePriority.UseTextAlignment = false;
        this.xrNgay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay2.Weight = 0.065420561819507908D;
        // 
        // xrNgay3
        // 
        this.xrNgay3.Dpi = 254F;
        this.xrNgay3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay3.Name = "xrNgay3";
        this.xrNgay3.StylePriority.UseFont = false;
        this.xrNgay3.StylePriority.UseTextAlignment = false;
        this.xrNgay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay3.Weight = 0.065420560624142476D;
        // 
        // xrNgay4
        // 
        this.xrNgay4.Dpi = 254F;
        this.xrNgay4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay4.Name = "xrNgay4";
        this.xrNgay4.StylePriority.UseFont = false;
        this.xrNgay4.StylePriority.UseTextAlignment = false;
        this.xrNgay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay4.Weight = 0.065420559918079935D;
        // 
        // xrNgay5
        // 
        this.xrNgay5.Dpi = 254F;
        this.xrNgay5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay5.Name = "xrNgay5";
        this.xrNgay5.StylePriority.UseFont = false;
        this.xrNgay5.StylePriority.UseTextAlignment = false;
        this.xrNgay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay5.Weight = 0.065420561735218291D;
        // 
        // xrNgay6
        // 
        this.xrNgay6.Dpi = 254F;
        this.xrNgay6.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay6.Name = "xrNgay6";
        this.xrNgay6.StylePriority.UseFont = false;
        this.xrNgay6.StylePriority.UseTextAlignment = false;
        this.xrNgay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay6.Weight = 0.06542056206195164D;
        // 
        // xrNgay7
        // 
        this.xrNgay7.Dpi = 254F;
        this.xrNgay7.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay7.Name = "xrNgay7";
        this.xrNgay7.StylePriority.UseFont = false;
        this.xrNgay7.StylePriority.UseTextAlignment = false;
        this.xrNgay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay7.Weight = 0.06542056189107634D;
        // 
        // xrNgay8
        // 
        this.xrNgay8.Dpi = 254F;
        this.xrNgay8.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay8.Name = "xrNgay8";
        this.xrNgay8.StylePriority.UseFont = false;
        this.xrNgay8.StylePriority.UseTextAlignment = false;
        this.xrNgay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay8.Weight = 0.065420559500345421D;
        // 
        // xrNgay9
        // 
        this.xrNgay9.Dpi = 254F;
        this.xrNgay9.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay9.Name = "xrNgay9";
        this.xrNgay9.StylePriority.UseFont = false;
        this.xrNgay9.StylePriority.UseTextAlignment = false;
        this.xrNgay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay9.Weight = 0.065420559204691628D;
        // 
        // xrNgay10
        // 
        this.xrNgay10.Dpi = 254F;
        this.xrNgay10.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay10.Name = "xrNgay10";
        this.xrNgay10.StylePriority.UseFont = false;
        this.xrNgay10.StylePriority.UseTextAlignment = false;
        this.xrNgay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay10.Weight = 0.0654205614642468D;
        // 
        // xrNgay11
        // 
        this.xrNgay11.Dpi = 254F;
        this.xrNgay11.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay11.Name = "xrNgay11";
        this.xrNgay11.StylePriority.UseFont = false;
        this.xrNgay11.StylePriority.UseTextAlignment = false;
        this.xrNgay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay11.Weight = 0.065420560780497766D;
        // 
        // xrNgay12
        // 
        this.xrNgay12.Dpi = 254F;
        this.xrNgay12.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay12.Name = "xrNgay12";
        this.xrNgay12.StylePriority.UseFont = false;
        this.xrNgay12.StylePriority.UseTextAlignment = false;
        this.xrNgay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay12.Weight = 0.065420559235208231D;
        // 
        // xrNgay13
        // 
        this.xrNgay13.Dpi = 254F;
        this.xrNgay13.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay13.Name = "xrNgay13";
        this.xrNgay13.StylePriority.UseFont = false;
        this.xrNgay13.StylePriority.UseTextAlignment = false;
        this.xrNgay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay13.Weight = 0.065420559235208231D;
        // 
        // xrNgay14
        // 
        this.xrNgay14.Dpi = 254F;
        this.xrNgay14.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay14.Name = "xrNgay14";
        this.xrNgay14.StylePriority.UseFont = false;
        this.xrNgay14.StylePriority.UseTextAlignment = false;
        this.xrNgay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay14.Weight = 0.065420559702278114D;
        // 
        // xrNgay15
        // 
        this.xrNgay15.Dpi = 254F;
        this.xrNgay15.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay15.Name = "xrNgay15";
        this.xrNgay15.StylePriority.UseFont = false;
        this.xrNgay15.StylePriority.UseTextAlignment = false;
        this.xrNgay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay15.Weight = 0.065420560890493362D;
        // 
        // xrNgay16
        // 
        this.xrNgay16.Dpi = 254F;
        this.xrNgay16.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay16.Name = "xrNgay16";
        this.xrNgay16.StylePriority.UseFont = false;
        this.xrNgay16.StylePriority.UseTextAlignment = false;
        this.xrNgay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay16.Weight = 0.065420559940086428D;
        // 
        // xrNgay17
        // 
        this.xrNgay17.Dpi = 254F;
        this.xrNgay17.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay17.Name = "xrNgay17";
        this.xrNgay17.StylePriority.UseFont = false;
        this.xrNgay17.StylePriority.UseTextAlignment = false;
        this.xrNgay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay17.Weight = 0.0654205592746663D;
        // 
        // xrNgay18
        // 
        this.xrNgay18.Dpi = 254F;
        this.xrNgay18.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay18.Name = "xrNgay18";
        this.xrNgay18.StylePriority.UseFont = false;
        this.xrNgay18.StylePriority.UseTextAlignment = false;
        this.xrNgay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay18.Weight = 0.065420561174654D;
        // 
        // xrNgay19
        // 
        this.xrNgay19.Dpi = 254F;
        this.xrNgay19.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay19.Name = "xrNgay19";
        this.xrNgay19.StylePriority.UseFont = false;
        this.xrNgay19.StylePriority.UseTextAlignment = false;
        this.xrNgay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay19.Weight = 0.065420561174653974D;
        // 
        // xrNgay20
        // 
        this.xrNgay20.Dpi = 254F;
        this.xrNgay20.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay20.Name = "xrNgay20";
        this.xrNgay20.StylePriority.UseFont = false;
        this.xrNgay20.StylePriority.UseTextAlignment = false;
        this.xrNgay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay20.Weight = 0.065420559218239166D;
        // 
        // xrNgay21
        // 
        this.xrNgay21.Dpi = 254F;
        this.xrNgay21.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay21.Name = "xrNgay21";
        this.xrNgay21.StylePriority.UseFont = false;
        this.xrNgay21.StylePriority.UseTextAlignment = false;
        this.xrNgay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay21.Weight = 0.06542055968331309D;
        // 
        // xrNgay22
        // 
        this.xrNgay22.Dpi = 254F;
        this.xrNgay22.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay22.Name = "xrNgay22";
        this.xrNgay22.StylePriority.UseFont = false;
        this.xrNgay22.StylePriority.UseTextAlignment = false;
        this.xrNgay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay22.Weight = 0.065420561359215451D;
        // 
        // xrNgay23
        // 
        this.xrNgay23.Dpi = 254F;
        this.xrNgay23.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay23.Name = "xrNgay23";
        this.xrNgay23.StylePriority.UseFont = false;
        this.xrNgay23.StylePriority.UseTextAlignment = false;
        this.xrNgay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay23.Weight = 0.065420562890738276D;
        // 
        // xrNgay24
        // 
        this.xrNgay24.Dpi = 254F;
        this.xrNgay24.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay24.Name = "xrNgay24";
        this.xrNgay24.StylePriority.UseFont = false;
        this.xrNgay24.StylePriority.UseTextAlignment = false;
        this.xrNgay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay24.Weight = 0.065420561368639579D;
        // 
        // xrNgay25
        // 
        this.xrNgay25.Dpi = 254F;
        this.xrNgay25.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay25.Name = "xrNgay25";
        this.xrNgay25.StylePriority.UseFont = false;
        this.xrNgay25.StylePriority.UseTextAlignment = false;
        this.xrNgay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay25.Weight = 0.065420559919183829D;
        // 
        // xrNgay26
        // 
        this.xrNgay26.Dpi = 254F;
        this.xrNgay26.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay26.Name = "xrNgay26";
        this.xrNgay26.StylePriority.UseFont = false;
        this.xrNgay26.StylePriority.UseTextAlignment = false;
        this.xrNgay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay26.Weight = 0.063472032120056476D;
        // 
        // xrNgay27
        // 
        this.xrNgay27.Dpi = 254F;
        this.xrNgay27.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay27.Name = "xrNgay27";
        this.xrNgay27.StylePriority.UseFont = false;
        this.xrNgay27.StylePriority.UseTextAlignment = false;
        this.xrNgay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay27.Weight = 0.0654205678618358D;
        // 
        // xrNgay28
        // 
        this.xrNgay28.Dpi = 254F;
        this.xrNgay28.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay28.Name = "xrNgay28";
        this.xrNgay28.StylePriority.UseFont = false;
        this.xrNgay28.StylePriority.UseTextAlignment = false;
        this.xrNgay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay28.Weight = 0.065420556202700708D;
        // 
        // xrNgay29
        // 
        this.xrNgay29.Dpi = 254F;
        this.xrNgay29.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay29.Name = "xrNgay29";
        this.xrNgay29.StylePriority.UseFont = false;
        this.xrNgay29.StylePriority.UseTextAlignment = false;
        this.xrNgay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay29.Weight = 0.0654205612235725D;
        // 
        // xrNgay30
        // 
        this.xrNgay30.Dpi = 254F;
        this.xrNgay30.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay30.Name = "xrNgay30";
        this.xrNgay30.StylePriority.UseFont = false;
        this.xrNgay30.StylePriority.UseTextAlignment = false;
        this.xrNgay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay30.Weight = 0.065420561223572482D;
        // 
        // xrNgay31
        // 
        this.xrNgay31.Dpi = 254F;
        this.xrNgay31.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrNgay31.Name = "xrNgay31";
        this.xrNgay31.StylePriority.UseFont = false;
        this.xrNgay31.StylePriority.UseTextAlignment = false;
        this.xrNgay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay31.Weight = 0.065420558484745275D;
        // 
        // xrTongXuat
        // 
        this.xrTongXuat.Dpi = 254F;
        this.xrTongXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongXuat.Multiline = true;
        this.xrTongXuat.Name = "xrTongXuat";
        this.xrTongXuat.StylePriority.UseFont = false;
        this.xrTongXuat.StylePriority.UseTextAlignment = false;
        this.xrTongXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongXuat.Weight = 0.091758705620433825D;
        // 
        // xrThanhTien
        // 
        this.xrThanhTien.Dpi = 254F;
        this.xrThanhTien.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrThanhTien.Name = "xrThanhTien";
        this.xrThanhTien.StylePriority.UseFont = false;
        this.xrThanhTien.StylePriority.UseTextAlignment = false;
        this.xrThanhTien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrThanhTien.Weight = 0.13678844791197703D;
        // 
        // xrComKhac
        // 
        this.xrComKhac.Dpi = 254F;
        this.xrComKhac.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrComKhac.Name = "xrComKhac";
        this.xrComKhac.StylePriority.UseFont = false;
        this.xrComKhac.StylePriority.UseTextAlignment = false;
        this.xrComKhac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrComKhac.Weight = 0.10620221021467734D;
        // 
        // xrTongComKhacVaXuat
        // 
        this.xrTongComKhacVaXuat.Dpi = 254F;
        this.xrTongComKhacVaXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongComKhacVaXuat.Name = "xrTongComKhacVaXuat";
        this.xrTongComKhacVaXuat.StylePriority.UseFont = false;
        this.xrTongComKhacVaXuat.StylePriority.UseTextAlignment = false;
        this.xrTongComKhacVaXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongComKhacVaXuat.Weight = 0.18217733450897397D;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 254F;
        this.TopMargin.HeightF = 101F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 254F;
        this.BottomMargin.HeightF = 34F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlChiTietTienCom});
        this.ReportHeader.Dpi = 254F;
        this.ReportHeader.HeightF = 341F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrlChiTietTienCom
        // 
        this.xrlChiTietTienCom.Dpi = 254F;
        this.xrlChiTietTienCom.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
        this.xrlChiTietTienCom.LocationFloat = new DevExpress.Utils.PointFloat(0F, 89.85248F);
        this.xrlChiTietTienCom.Name = "xrlChiTietTienCom";
        this.xrlChiTietTienCom.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlChiTietTienCom.SizeF = new System.Drawing.SizeF(3531F, 98.1075F);
        this.xrlChiTietTienCom.StylePriority.UseFont = false;
        this.xrlChiTietTienCom.StylePriority.UseTextAlignment = false;
        this.xrlChiTietTienCom.Text = "BẢNG TỔNG HỢP CHI TIẾT TIỀN CƠM THÁNG 2/2014";
        this.xrlChiTietTienCom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.Dpi = 254F;
        this.PageHeader.HeightF = 140.5F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Dpi = 254F;
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(3506F, 140.5F);
        this.xrTable1.StylePriority.UseBorders = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell20,
            this.xrTableCell11,
            this.xrTableCell1,
            this.xrTableCell10,
            this.xrTableCell8,
            this.xrTableCell22,
            this.xrTableCell21,
            this.xrTableCell23,
            this.xrTableCell29,
            this.xrTableCell28,
            this.xrTableCell31,
            this.xrTableCell30,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell32,
            this.xrTableCell13,
            this.xrTableCell33,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell34,
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell2,
            this.xrTableCell26,
            this.xrTableCell35,
            this.xrTableCell17,
            this.xrTableCell16,
            this.xrTableCell36,
            this.xrTableCell27,
            this.xrTableCell18,
            this.xrTableCell15,
            this.xrTableCell19,
            this.xrTableCell37,
            this.xrTableCell3});
        this.xrTableRow1.Dpi = 254F;
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Dpi = 254F;
        this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "STT";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 0.075673852624445384D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Dpi = 254F;
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "Họ tên";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.38131059688618363D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Dpi = 254F;
        this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseFont = false;
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = "1";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell6.Weight = 0.06542056105048949D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Dpi = 254F;
        this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseFont = false;
        this.xrTableCell20.StylePriority.UseTextAlignment = false;
        this.xrTableCell20.Text = "2";
        this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell20.Weight = 0.06542056181950788D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Dpi = 254F;
        this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseFont = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "3";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 0.065420560624142476D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Dpi = 254F;
        this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "4";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.065420559918079935D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Dpi = 254F;
        this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseFont = false;
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "5";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 0.065420561735218291D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Dpi = 254F;
        this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseFont = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "6";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 0.06542056206195164D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Dpi = 254F;
        this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseFont = false;
        this.xrTableCell22.StylePriority.UseTextAlignment = false;
        this.xrTableCell22.Text = "7";
        this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell22.Weight = 0.06542056189107634D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Dpi = 254F;
        this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseFont = false;
        this.xrTableCell21.StylePriority.UseTextAlignment = false;
        this.xrTableCell21.Text = "8";
        this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell21.Weight = 0.065420559500345421D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Dpi = 254F;
        this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseFont = false;
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.Text = "9";
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell23.Weight = 0.065420559204691628D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Dpi = 254F;
        this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseFont = false;
        this.xrTableCell29.StylePriority.UseTextAlignment = false;
        this.xrTableCell29.Text = "10";
        this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell29.Weight = 0.0654205614642468D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Dpi = 254F;
        this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseFont = false;
        this.xrTableCell28.StylePriority.UseTextAlignment = false;
        this.xrTableCell28.Text = "11";
        this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell28.Weight = 0.065420560780497766D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell31.Dpi = 254F;
        this.xrTableCell31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseBorders = false;
        this.xrTableCell31.StylePriority.UseFont = false;
        this.xrTableCell31.StylePriority.UseTextAlignment = false;
        this.xrTableCell31.Text = "12";
        this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell31.Weight = 0.065420559235208231D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Dpi = 254F;
        this.xrTableCell30.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.StylePriority.UseFont = false;
        this.xrTableCell30.StylePriority.UseTextAlignment = false;
        this.xrTableCell30.Text = "13";
        this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell30.Weight = 0.065420559235208231D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Dpi = 254F;
        this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseFont = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "14";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.065420559702278114D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Dpi = 254F;
        this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "15";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.065420560890493362D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Dpi = 254F;
        this.xrTableCell32.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseFont = false;
        this.xrTableCell32.StylePriority.UseTextAlignment = false;
        this.xrTableCell32.Text = "16";
        this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell32.Weight = 0.065420559940086428D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Dpi = 254F;
        this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "17";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 0.0654205592746663D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Dpi = 254F;
        this.xrTableCell33.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.StylePriority.UseFont = false;
        this.xrTableCell33.StylePriority.UseTextAlignment = false;
        this.xrTableCell33.Text = "18";
        this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell33.Weight = 0.065420561174654D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Dpi = 254F;
        this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseFont = false;
        this.xrTableCell24.StylePriority.UseTextAlignment = false;
        this.xrTableCell24.Text = "19";
        this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell24.Weight = 0.065420561174653974D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Dpi = 254F;
        this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.StylePriority.UseFont = false;
        this.xrTableCell25.StylePriority.UseTextAlignment = false;
        this.xrTableCell25.Text = "20";
        this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell25.Weight = 0.065420559218239166D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Dpi = 254F;
        this.xrTableCell34.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.StylePriority.UseFont = false;
        this.xrTableCell34.StylePriority.UseTextAlignment = false;
        this.xrTableCell34.Text = "21";
        this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell34.Weight = 0.06542055968331309D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Dpi = 254F;
        this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "22";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 0.065420561359215451D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Dpi = 254F;
        this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseFont = false;
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "23";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell14.Weight = 0.065420559649704058D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Dpi = 254F;
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "24";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.0654205613686396D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Dpi = 254F;
        this.xrTableCell26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseFont = false;
        this.xrTableCell26.StylePriority.UseTextAlignment = false;
        this.xrTableCell26.Text = "25";
        this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell26.Weight = 0.065420559919183829D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Dpi = 254F;
        this.xrTableCell35.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseFont = false;
        this.xrTableCell35.StylePriority.UseTextAlignment = false;
        this.xrTableCell35.Text = "26";
        this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell35.Weight = 0.063472316395548845D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Dpi = 254F;
        this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.Text = "27";
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.064569422510841523D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Dpi = 254F;
        this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseFont = false;
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.Text = "28";
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell16.Weight = 0.066271437181073839D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Dpi = 254F;
        this.xrTableCell36.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseFont = false;
        this.xrTableCell36.StylePriority.UseTextAlignment = false;
        this.xrTableCell36.Text = "29";
        this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell36.Weight = 0.065420358846592627D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Dpi = 254F;
        this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseFont = false;
        this.xrTableCell27.StylePriority.UseTextAlignment = false;
        this.xrTableCell27.Text = "30";
        this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell27.Weight = 0.065420567751862169D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Dpi = 254F;
        this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseFont = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.Text = "31";
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell18.Weight = 0.065420359348799639D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Dpi = 254F;
        this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell15.Multiline = true;
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseFont = false;
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.Text = "Tổng \r\nxuất  20000";
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell15.Weight = 0.091759133200296786D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Dpi = 254F;
        this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseFont = false;
        this.xrTableCell19.StylePriority.UseTextAlignment = false;
        this.xrTableCell19.Text = "Thành Tiền";
        this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell19.Weight = 0.13678845448648797D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Dpi = 254F;
        this.xrTableCell37.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.StylePriority.UseFont = false;
        this.xrTableCell37.StylePriority.UseTextAlignment = false;
        this.xrTableCell37.Text = "Cơm CN khác";
        this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell37.Weight = 0.10620242564823657D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Dpi = 254F;
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Thành tiền";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 0.1821770632438397D;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.GroupHeader1.Dpi = 254F;
        this.GroupHeader1.HeightF = 75.5417F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Dpi = 254F;
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(3506F, 75.5417F);
        this.xrTable2.StylePriority.UseBorders = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell38,
            this.xrGoupTen,
            this.xrTableCell40});
        this.xrTableRow2.Dpi = 254F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Dpi = 254F;
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.Weight = 0.2330738915749922D;
        // 
        // xrGoupTen
        // 
        this.xrGoupTen.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrGoupTen.Dpi = 254F;
        this.xrGoupTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrGoupTen.Name = "xrGoupTen";
        this.xrGoupTen.StylePriority.UseBorders = false;
        this.xrGoupTen.StylePriority.UseFont = false;
        this.xrGoupTen.StylePriority.UseTextAlignment = false;
        this.xrGoupTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrGoupTen.Weight = 1.1744290255629528D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell40.Dpi = 254F;
        this.xrTableCell40.Font = new System.Drawing.Font("Times New Roman", 18F);
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.StylePriority.UseBorders = false;
        this.xrTableCell40.StylePriority.UseFont = false;
        this.xrTableCell40.Weight = 7.8324366949027358D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_footer3,
            this.xrlThuKho,
            this.xrlNgayLapPhieu,
            this.xrlTen2,
            this.xrl_footer2,
            this.xrl,
            this.xrl_footer1,
            this.xrlTenPhuTrachChiNhanh,
            this.xrl_NguoiLap,
            this.xrTable8});
        this.ReportFooter.Dpi = 254F;
        this.ReportFooter.HeightF = 550F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Dpi = 254F;
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1886.479F, 190.5F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(515.9377F, 58.42F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "THỦ KHO";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrlThuKho
        // 
        this.xrlThuKho.Dpi = 254F;
        this.xrlThuKho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlThuKho.LocationFloat = new DevExpress.Utils.PointFloat(1886.479F, 349.25F);
        this.xrlThuKho.Name = "xrlThuKho";
        this.xrlThuKho.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlThuKho.SizeF = new System.Drawing.SizeF(515.9377F, 58.42F);
        this.xrlThuKho.StylePriority.UseFont = false;
        this.xrlThuKho.StylePriority.UseTextAlignment = false;
        this.xrlThuKho.Text = "Đỗ thị Trang";
        this.xrlThuKho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrlNgayLapPhieu
        // 
        this.xrlNgayLapPhieu.Dpi = 254F;
        this.xrlNgayLapPhieu.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlNgayLapPhieu.LocationFloat = new DevExpress.Utils.PointFloat(2794F, 127F);
        this.xrlNgayLapPhieu.Name = "xrlNgayLapPhieu";
        this.xrlNgayLapPhieu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlNgayLapPhieu.SizeF = new System.Drawing.SizeF(640.2917F, 58.41999F);
        this.xrlNgayLapPhieu.StylePriority.UseFont = false;
        this.xrlNgayLapPhieu.StylePriority.UseTextAlignment = false;
        this.xrlNgayLapPhieu.Text = "Hà nội, ngày 28 tháng 2 năm 2014";
        this.xrlNgayLapPhieu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlTen2
        // 
        this.xrlTen2.Dpi = 254F;
        this.xrlTen2.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlTen2.LocationFloat = new DevExpress.Utils.PointFloat(992.7914F, 349.25F);
        this.xrlTen2.Name = "xrlTen2";
        this.xrlTen2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlTen2.SizeF = new System.Drawing.SizeF(515.9377F, 58.42F);
        this.xrlTen2.StylePriority.UseFont = false;
        this.xrlTen2.StylePriority.UseTextAlignment = false;
        this.xrlTen2.Text = "Mai thị Nga";
        this.xrlTen2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Dpi = 254F;
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(992.7914F, 190.5F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(515.9377F, 58.42F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "P.TP - HCNS";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl
        // 
        this.xrl.Dpi = 254F;
        this.xrl.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl.LocationFloat = new DevExpress.Utils.PointFloat(2794F, 190.5F);
        this.xrl.Name = "xrl";
        this.xrl.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl.SizeF = new System.Drawing.SizeF(640.2917F, 58.42F);
        this.xrl.StylePriority.UseFont = false;
        this.xrl.StylePriority.UseTextAlignment = false;
        this.xrl.Text = "NGƯỜI LẬP";
        this.xrl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Dpi = 254F;
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(95.25F, 190.5F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(515.9375F, 58.42F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "PHỤ TRÁCH CHI NHÁNH";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrlTenPhuTrachChiNhanh
        // 
        this.xrlTenPhuTrachChiNhanh.Dpi = 254F;
        this.xrlTenPhuTrachChiNhanh.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlTenPhuTrachChiNhanh.LocationFloat = new DevExpress.Utils.PointFloat(95.25F, 349.25F);
        this.xrlTenPhuTrachChiNhanh.Name = "xrlTenPhuTrachChiNhanh";
        this.xrlTenPhuTrachChiNhanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlTenPhuTrachChiNhanh.SizeF = new System.Drawing.SizeF(515.9375F, 58.42F);
        this.xrlTenPhuTrachChiNhanh.StylePriority.UseFont = false;
        this.xrlTenPhuTrachChiNhanh.StylePriority.UseTextAlignment = false;
        this.xrlTenPhuTrachChiNhanh.Text = "Vương Anh Tuấn";
        this.xrlTenPhuTrachChiNhanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_NguoiLap
        // 
        this.xrl_NguoiLap.Dpi = 254F;
        this.xrl_NguoiLap.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_NguoiLap.LocationFloat = new DevExpress.Utils.PointFloat(2794F, 349.25F);
        this.xrl_NguoiLap.Name = "xrl_NguoiLap";
        this.xrl_NguoiLap.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_NguoiLap.SizeF = new System.Drawing.SizeF(640.2917F, 58.42F);
        this.xrl_NguoiLap.StylePriority.UseFont = false;
        this.xrl_NguoiLap.StylePriority.UseTextAlignment = false;
        this.xrl_NguoiLap.Text = "Phùng thị thu hà";
        this.xrl_NguoiLap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable8
        // 
        this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable8.Dpi = 254F;
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(3506F, 62.31252F);
        this.xrTable8.StylePriority.UseBorders = false;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell192,
            this.xrTableCell193,
            this.xrTongCongNgay1,
            this.xrTongCongNgay2,
            this.xrTongCongNgay3,
            this.xrTongCongNgay4,
            this.xrTongCongNgay5,
            this.xrTongCongNgay6,
            this.xrTongCongNgay7,
            this.xrTongCongNgay8,
            this.xrTongCongNgay9,
            this.xrTongCongNgay10,
            this.xrTongCongNgay11,
            this.xrTongCongNgay12,
            this.xrTongCongNgay13,
            this.xrTongCongNgay14,
            this.xrTongCongNgay15,
            this.xrTongCongNgay16,
            this.xrTongCongNgay17,
            this.xrTongCongNgay18,
            this.xrTongCongNgay19,
            this.xrTongCongNgay20,
            this.xrTongCongNgay21,
            this.xrTongCongNgay22,
            this.xrTongCongNgay23,
            this.xrTongCongNgay24,
            this.xrTongCongNgay25,
            this.xrTongCongNgay26,
            this.xrTongCongNgay27,
            this.xrTongCongNgay28,
            this.xrTongCongNgay29,
            this.xrTongCongNgay30,
            this.xrTongCongNgay31,
            this.xrTongCongTongXuat,
            this.xrTongCongThanhTien,
            this.xrTongCongComKhac,
            this.xrTongCongCongTongComKhacVaXuat});
        this.xrTableRow8.Dpi = 254F;
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell192
        // 
        this.xrTableCell192.Dpi = 254F;
        this.xrTableCell192.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell192.Name = "xrTableCell192";
        this.xrTableCell192.StylePriority.UseFont = false;
        this.xrTableCell192.StylePriority.UseTextAlignment = false;
        this.xrTableCell192.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell192.Weight = 0.075673852624445384D;
        // 
        // xrTableCell193
        // 
        this.xrTableCell193.Dpi = 254F;
        this.xrTableCell193.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell193.Name = "xrTableCell193";
        this.xrTableCell193.StylePriority.UseFont = false;
        this.xrTableCell193.StylePriority.UseTextAlignment = false;
        this.xrTableCell193.Text = "Tổng Cộng";
        this.xrTableCell193.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell193.Weight = 0.38131059688618363D;
        // 
        // xrTongCongNgay1
        // 
        this.xrTongCongNgay1.Dpi = 254F;
        this.xrTongCongNgay1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay1.Name = "xrTongCongNgay1";
        this.xrTongCongNgay1.StylePriority.UseFont = false;
        this.xrTongCongNgay1.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:n0}";
        xrSummary1.IgnoreNullValues = true;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay1.Summary = xrSummary1;
        this.xrTongCongNgay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay1.Weight = 0.065420561050489462D;
        // 
        // xrTongCongNgay2
        // 
        this.xrTongCongNgay2.Dpi = 254F;
        this.xrTongCongNgay2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay2.Name = "xrTongCongNgay2";
        this.xrTongCongNgay2.StylePriority.UseFont = false;
        this.xrTongCongNgay2.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:n0}";
        xrSummary2.IgnoreNullValues = true;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay2.Summary = xrSummary2;
        this.xrTongCongNgay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay2.Weight = 0.065420561819507908D;
        // 
        // xrTongCongNgay3
        // 
        this.xrTongCongNgay3.Dpi = 254F;
        this.xrTongCongNgay3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay3.Name = "xrTongCongNgay3";
        this.xrTongCongNgay3.StylePriority.UseFont = false;
        this.xrTongCongNgay3.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:n0}";
        xrSummary3.IgnoreNullValues = true;
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay3.Summary = xrSummary3;
        this.xrTongCongNgay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay3.Weight = 0.065420560624142476D;
        // 
        // xrTongCongNgay4
        // 
        this.xrTongCongNgay4.Dpi = 254F;
        this.xrTongCongNgay4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay4.Name = "xrTongCongNgay4";
        this.xrTongCongNgay4.StylePriority.UseFont = false;
        this.xrTongCongNgay4.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:n0}";
        xrSummary4.IgnoreNullValues = true;
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay4.Summary = xrSummary4;
        this.xrTongCongNgay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay4.Weight = 0.065420559918079935D;
        // 
        // xrTongCongNgay5
        // 
        this.xrTongCongNgay5.Dpi = 254F;
        this.xrTongCongNgay5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay5.Name = "xrTongCongNgay5";
        this.xrTongCongNgay5.StylePriority.UseFont = false;
        this.xrTongCongNgay5.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:n0}";
        xrSummary5.IgnoreNullValues = true;
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay5.Summary = xrSummary5;
        this.xrTongCongNgay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay5.Weight = 0.065420561735218291D;
        // 
        // xrTongCongNgay6
        // 
        this.xrTongCongNgay6.Dpi = 254F;
        this.xrTongCongNgay6.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay6.Name = "xrTongCongNgay6";
        this.xrTongCongNgay6.StylePriority.UseFont = false;
        this.xrTongCongNgay6.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:n0}";
        xrSummary6.IgnoreNullValues = true;
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay6.Summary = xrSummary6;
        this.xrTongCongNgay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay6.Weight = 0.06542056206195164D;
        // 
        // xrTongCongNgay7
        // 
        this.xrTongCongNgay7.Dpi = 254F;
        this.xrTongCongNgay7.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay7.Name = "xrTongCongNgay7";
        this.xrTongCongNgay7.StylePriority.UseFont = false;
        this.xrTongCongNgay7.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:n0}";
        xrSummary7.IgnoreNullValues = true;
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay7.Summary = xrSummary7;
        this.xrTongCongNgay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay7.Weight = 0.06542056189107634D;
        // 
        // xrTongCongNgay8
        // 
        this.xrTongCongNgay8.Dpi = 254F;
        this.xrTongCongNgay8.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay8.Name = "xrTongCongNgay8";
        this.xrTongCongNgay8.StylePriority.UseFont = false;
        this.xrTongCongNgay8.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:n0}";
        xrSummary8.IgnoreNullValues = true;
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay8.Summary = xrSummary8;
        this.xrTongCongNgay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay8.Weight = 0.065420559500345421D;
        // 
        // xrTongCongNgay9
        // 
        this.xrTongCongNgay9.Dpi = 254F;
        this.xrTongCongNgay9.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay9.Name = "xrTongCongNgay9";
        this.xrTongCongNgay9.StylePriority.UseFont = false;
        this.xrTongCongNgay9.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:n0}";
        xrSummary9.IgnoreNullValues = true;
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay9.Summary = xrSummary9;
        this.xrTongCongNgay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay9.Weight = 0.065420559204691628D;
        // 
        // xrTongCongNgay10
        // 
        this.xrTongCongNgay10.Dpi = 254F;
        this.xrTongCongNgay10.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay10.Name = "xrTongCongNgay10";
        this.xrTongCongNgay10.StylePriority.UseFont = false;
        this.xrTongCongNgay10.StylePriority.UseTextAlignment = false;
        xrSummary10.FormatString = "{0:n0}";
        xrSummary10.IgnoreNullValues = true;
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay10.Summary = xrSummary10;
        this.xrTongCongNgay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay10.Weight = 0.0654205614642468D;
        // 
        // xrTongCongNgay11
        // 
        this.xrTongCongNgay11.Dpi = 254F;
        this.xrTongCongNgay11.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay11.Name = "xrTongCongNgay11";
        this.xrTongCongNgay11.StylePriority.UseFont = false;
        this.xrTongCongNgay11.StylePriority.UseTextAlignment = false;
        xrSummary11.FormatString = "{0:n0}";
        xrSummary11.IgnoreNullValues = true;
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay11.Summary = xrSummary11;
        this.xrTongCongNgay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay11.Weight = 0.065420560780497766D;
        // 
        // xrTongCongNgay12
        // 
        this.xrTongCongNgay12.Dpi = 254F;
        this.xrTongCongNgay12.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay12.Name = "xrTongCongNgay12";
        this.xrTongCongNgay12.StylePriority.UseFont = false;
        this.xrTongCongNgay12.StylePriority.UseTextAlignment = false;
        xrSummary12.FormatString = "{0:n0}";
        xrSummary12.IgnoreNullValues = true;
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay12.Summary = xrSummary12;
        this.xrTongCongNgay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay12.Weight = 0.065420559235208231D;
        // 
        // xrTongCongNgay13
        // 
        this.xrTongCongNgay13.Dpi = 254F;
        this.xrTongCongNgay13.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay13.Name = "xrTongCongNgay13";
        this.xrTongCongNgay13.StylePriority.UseFont = false;
        this.xrTongCongNgay13.StylePriority.UseTextAlignment = false;
        xrSummary13.FormatString = "{0:n0}";
        xrSummary13.IgnoreNullValues = true;
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay13.Summary = xrSummary13;
        this.xrTongCongNgay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay13.Weight = 0.065420559235208231D;
        // 
        // xrTongCongNgay14
        // 
        this.xrTongCongNgay14.Dpi = 254F;
        this.xrTongCongNgay14.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay14.Name = "xrTongCongNgay14";
        this.xrTongCongNgay14.StylePriority.UseFont = false;
        this.xrTongCongNgay14.StylePriority.UseTextAlignment = false;
        xrSummary14.FormatString = "{0:n0}";
        xrSummary14.IgnoreNullValues = true;
        xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay14.Summary = xrSummary14;
        this.xrTongCongNgay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay14.Weight = 0.065420559702278114D;
        // 
        // xrTongCongNgay15
        // 
        this.xrTongCongNgay15.Dpi = 254F;
        this.xrTongCongNgay15.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay15.Name = "xrTongCongNgay15";
        this.xrTongCongNgay15.StylePriority.UseFont = false;
        this.xrTongCongNgay15.StylePriority.UseTextAlignment = false;
        xrSummary15.FormatString = "{0:n0}";
        xrSummary15.IgnoreNullValues = true;
        xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay15.Summary = xrSummary15;
        this.xrTongCongNgay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay15.Weight = 0.065420560890493362D;
        // 
        // xrTongCongNgay16
        // 
        this.xrTongCongNgay16.Dpi = 254F;
        this.xrTongCongNgay16.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay16.Name = "xrTongCongNgay16";
        this.xrTongCongNgay16.StylePriority.UseFont = false;
        this.xrTongCongNgay16.StylePriority.UseTextAlignment = false;
        xrSummary16.FormatString = "{0:n0}";
        xrSummary16.IgnoreNullValues = true;
        xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay16.Summary = xrSummary16;
        this.xrTongCongNgay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay16.Weight = 0.065420559940086428D;
        // 
        // xrTongCongNgay17
        // 
        this.xrTongCongNgay17.Dpi = 254F;
        this.xrTongCongNgay17.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay17.Name = "xrTongCongNgay17";
        this.xrTongCongNgay17.StylePriority.UseFont = false;
        this.xrTongCongNgay17.StylePriority.UseTextAlignment = false;
        xrSummary17.FormatString = "{0:n0}";
        xrSummary17.IgnoreNullValues = true;
        xrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay17.Summary = xrSummary17;
        this.xrTongCongNgay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay17.Weight = 0.0654205592746663D;
        // 
        // xrTongCongNgay18
        // 
        this.xrTongCongNgay18.Dpi = 254F;
        this.xrTongCongNgay18.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay18.Name = "xrTongCongNgay18";
        this.xrTongCongNgay18.StylePriority.UseFont = false;
        this.xrTongCongNgay18.StylePriority.UseTextAlignment = false;
        xrSummary18.FormatString = "{0:n0}";
        xrSummary18.IgnoreNullValues = true;
        xrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay18.Summary = xrSummary18;
        this.xrTongCongNgay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay18.Weight = 0.065420561174654D;
        // 
        // xrTongCongNgay19
        // 
        this.xrTongCongNgay19.Dpi = 254F;
        this.xrTongCongNgay19.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay19.Name = "xrTongCongNgay19";
        this.xrTongCongNgay19.StylePriority.UseFont = false;
        this.xrTongCongNgay19.StylePriority.UseTextAlignment = false;
        xrSummary19.FormatString = "{0:n0}";
        xrSummary19.IgnoreNullValues = true;
        xrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay19.Summary = xrSummary19;
        this.xrTongCongNgay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay19.Weight = 0.065420561174653974D;
        // 
        // xrTongCongNgay20
        // 
        this.xrTongCongNgay20.Dpi = 254F;
        this.xrTongCongNgay20.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay20.Name = "xrTongCongNgay20";
        this.xrTongCongNgay20.StylePriority.UseFont = false;
        this.xrTongCongNgay20.StylePriority.UseTextAlignment = false;
        xrSummary20.FormatString = "{0:n0}";
        xrSummary20.IgnoreNullValues = true;
        xrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay20.Summary = xrSummary20;
        this.xrTongCongNgay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay20.Weight = 0.065420559218239166D;
        // 
        // xrTongCongNgay21
        // 
        this.xrTongCongNgay21.Dpi = 254F;
        this.xrTongCongNgay21.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay21.Name = "xrTongCongNgay21";
        this.xrTongCongNgay21.StylePriority.UseFont = false;
        this.xrTongCongNgay21.StylePriority.UseTextAlignment = false;
        xrSummary21.FormatString = "{0:n0}";
        xrSummary21.IgnoreNullValues = true;
        xrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay21.Summary = xrSummary21;
        this.xrTongCongNgay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay21.Weight = 0.06542055968331309D;
        // 
        // xrTongCongNgay22
        // 
        this.xrTongCongNgay22.Dpi = 254F;
        this.xrTongCongNgay22.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay22.Name = "xrTongCongNgay22";
        this.xrTongCongNgay22.StylePriority.UseFont = false;
        this.xrTongCongNgay22.StylePriority.UseTextAlignment = false;
        xrSummary22.FormatString = "{0:n0}";
        xrSummary22.IgnoreNullValues = true;
        xrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay22.Summary = xrSummary22;
        this.xrTongCongNgay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay22.Weight = 0.065420561359215451D;
        // 
        // xrTongCongNgay23
        // 
        this.xrTongCongNgay23.Dpi = 254F;
        this.xrTongCongNgay23.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay23.Name = "xrTongCongNgay23";
        this.xrTongCongNgay23.StylePriority.UseFont = false;
        this.xrTongCongNgay23.StylePriority.UseTextAlignment = false;
        xrSummary23.FormatString = "{0:n0}";
        xrSummary23.IgnoreNullValues = true;
        xrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay23.Summary = xrSummary23;
        this.xrTongCongNgay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay23.Weight = 0.065420562890738276D;
        // 
        // xrTongCongNgay24
        // 
        this.xrTongCongNgay24.Dpi = 254F;
        this.xrTongCongNgay24.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay24.Name = "xrTongCongNgay24";
        this.xrTongCongNgay24.StylePriority.UseFont = false;
        this.xrTongCongNgay24.StylePriority.UseTextAlignment = false;
        xrSummary24.FormatString = "{0:n0}";
        xrSummary24.IgnoreNullValues = true;
        xrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay24.Summary = xrSummary24;
        this.xrTongCongNgay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay24.Weight = 0.065420561368639579D;
        // 
        // xrTongCongNgay25
        // 
        this.xrTongCongNgay25.Dpi = 254F;
        this.xrTongCongNgay25.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay25.Name = "xrTongCongNgay25";
        this.xrTongCongNgay25.StylePriority.UseFont = false;
        this.xrTongCongNgay25.StylePriority.UseTextAlignment = false;
        xrSummary25.FormatString = "{0:n0}";
        xrSummary25.IgnoreNullValues = true;
        xrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay25.Summary = xrSummary25;
        this.xrTongCongNgay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay25.Weight = 0.065420559919183829D;
        // 
        // xrTongCongNgay26
        // 
        this.xrTongCongNgay26.Dpi = 254F;
        this.xrTongCongNgay26.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay26.Name = "xrTongCongNgay26";
        this.xrTongCongNgay26.StylePriority.UseFont = false;
        this.xrTongCongNgay26.StylePriority.UseTextAlignment = false;
        xrSummary26.FormatString = "{0:n0}";
        xrSummary26.IgnoreNullValues = true;
        xrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay26.Summary = xrSummary26;
        this.xrTongCongNgay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay26.Weight = 0.063472108412855513D;
        // 
        // xrTongCongNgay27
        // 
        this.xrTongCongNgay27.Dpi = 254F;
        this.xrTongCongNgay27.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay27.Name = "xrTongCongNgay27";
        this.xrTongCongNgay27.StylePriority.UseFont = false;
        this.xrTongCongNgay27.StylePriority.UseTextAlignment = false;
        xrSummary27.FormatString = "{0:n0}";
        xrSummary27.IgnoreNullValues = true;
        xrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay27.Summary = xrSummary27;
        this.xrTongCongNgay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay27.Weight = 0.064569696699007792D;
        // 
        // xrTongCongNgay28
        // 
        this.xrTongCongNgay28.Dpi = 254F;
        this.xrTongCongNgay28.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay28.Name = "xrTongCongNgay28";
        this.xrTongCongNgay28.StylePriority.UseFont = false;
        this.xrTongCongNgay28.StylePriority.UseTextAlignment = false;
        xrSummary28.FormatString = "{0:n0}";
        xrSummary28.IgnoreNullValues = true;
        xrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay28.Summary = xrSummary28;
        this.xrTongCongNgay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay28.Weight = 0.066271433893818385D;
        // 
        // xrTongCongNgay29
        // 
        this.xrTongCongNgay29.Dpi = 254F;
        this.xrTongCongNgay29.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay29.Name = "xrTongCongNgay29";
        this.xrTongCongNgay29.StylePriority.UseFont = false;
        this.xrTongCongNgay29.StylePriority.UseTextAlignment = false;
        xrSummary29.FormatString = "{0:n0}";
        xrSummary29.IgnoreNullValues = true;
        xrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay29.Summary = xrSummary29;
        this.xrTongCongNgay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay29.Weight = 0.0654203457900133D;
        // 
        // xrTongCongNgay30
        // 
        this.xrTongCongNgay30.Dpi = 254F;
        this.xrTongCongNgay30.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay30.Name = "xrTongCongNgay30";
        this.xrTongCongNgay30.StylePriority.UseFont = false;
        this.xrTongCongNgay30.StylePriority.UseTextAlignment = false;
        xrSummary30.FormatString = "{0:n0}";
        xrSummary30.IgnoreNullValues = true;
        xrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay30.Summary = xrSummary30;
        this.xrTongCongNgay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay30.Weight = 0.065420985562401252D;
        // 
        // xrTongCongNgay31
        // 
        this.xrTongCongNgay31.Dpi = 254F;
        this.xrTongCongNgay31.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongNgay31.Name = "xrTongCongNgay31";
        this.xrTongCongNgay31.StylePriority.UseFont = false;
        this.xrTongCongNgay31.StylePriority.UseTextAlignment = false;
        xrSummary31.FormatString = "{0:n0}";
        xrSummary31.IgnoreNullValues = true;
        xrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongNgay31.Summary = xrSummary31;
        this.xrTongCongNgay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongNgay31.Weight = 0.065419938297226365D;
        // 
        // xrTongCongTongXuat
        // 
        this.xrTongCongTongXuat.Dpi = 254F;
        this.xrTongCongTongXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongTongXuat.Multiline = true;
        this.xrTongCongTongXuat.Name = "xrTongCongTongXuat";
        this.xrTongCongTongXuat.StylePriority.UseFont = false;
        this.xrTongCongTongXuat.StylePriority.UseTextAlignment = false;
        xrSummary32.FormatString = "{0:n0}";
        xrSummary32.IgnoreNullValues = true;
        xrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongTongXuat.Summary = xrSummary32;
        this.xrTongCongTongXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongTongXuat.Weight = 0.091759129959262539D;
        // 
        // xrTongCongThanhTien
        // 
        this.xrTongCongThanhTien.Dpi = 254F;
        this.xrTongCongThanhTien.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongThanhTien.Name = "xrTongCongThanhTien";
        this.xrTongCongThanhTien.StylePriority.UseFont = false;
        this.xrTongCongThanhTien.StylePriority.UseTextAlignment = false;
        xrSummary33.FormatString = "{0:n0}";
        xrSummary33.IgnoreNullValues = true;
        xrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTongCongThanhTien.Summary = xrSummary33;
        this.xrTongCongThanhTien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongThanhTien.Weight = 0.13678845448648797D;
        // 
        // xrTongCongComKhac
        // 
        this.xrTongCongComKhac.Dpi = 254F;
        this.xrTongCongComKhac.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongComKhac.Name = "xrTongCongComKhac";
        this.xrTongCongComKhac.StylePriority.UseFont = false;
        this.xrTongCongComKhac.StylePriority.UseTextAlignment = false;
        this.xrTongCongComKhac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongComKhac.Weight = 0.10620242564823654D;
        // 
        // xrTongCongCongTongComKhacVaXuat
        // 
        this.xrTongCongCongTongComKhacVaXuat.Dpi = 254F;
        this.xrTongCongCongTongComKhacVaXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTongCongCongTongComKhacVaXuat.Name = "xrTongCongCongTongComKhacVaXuat";
        this.xrTongCongCongTongComKhacVaXuat.StylePriority.UseFont = false;
        this.xrTongCongCongTongComKhacVaXuat.StylePriority.UseTextAlignment = false;
        this.xrTongCongCongTongComKhacVaXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTongCongCongTongComKhacVaXuat.Weight = 0.18217701662323577D;
        // 
        // GroupFooter4
        // 
        this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7});
        this.GroupFooter4.Dpi = 254F;
        this.GroupFooter4.HeightF = 69.06252F;
        this.GroupFooter4.Name = "GroupFooter4";
        // 
        // xrTable7
        // 
        this.xrTable7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable7.Dpi = 254F;
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(3506F, 69.06252F);
        this.xrTable7.StylePriority.UseBorders = false;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell155,
            this.xrTableCell156,
            this.xrCongNgay1,
            this.xrCongNgay2,
            this.xrCongNgay3,
            this.xrCongNgay4,
            this.xrCongNgay5,
            this.xrCongNgay6,
            this.xrCongNgay7,
            this.xrCongNgay8,
            this.xrCongNgay9,
            this.xrCongNgay10,
            this.xrCongNgay11,
            this.xrCongNgay12,
            this.xrCongNgay13,
            this.xrCongNgay14,
            this.xrCongNgay15,
            this.xrCongNgay16,
            this.xrCongNgay17,
            this.xrCongNgay18,
            this.xrCongNgay19,
            this.xrCongNgay20,
            this.xrCongNgay21,
            this.xrCongNgay22,
            this.xrCongNgay23,
            this.xrCongNgay24,
            this.xrCongNgay25,
            this.xrCongNgay26,
            this.xrCongNgay27,
            this.xrCongNgay28,
            this.xrCongNgay29,
            this.xrCongNgay30,
            this.xrCongNgay31,
            this.xrCongTongXuat,
            this.xrCongThanhTien,
            this.xrCongComKhac,
            this.xrCongTongComKhacVaXuat});
        this.xrTableRow7.Dpi = 254F;
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell155
        // 
        this.xrTableCell155.Dpi = 254F;
        this.xrTableCell155.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell155.Name = "xrTableCell155";
        this.xrTableCell155.StylePriority.UseFont = false;
        this.xrTableCell155.StylePriority.UseTextAlignment = false;
        this.xrTableCell155.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell155.Weight = 0.075673852624445384D;
        // 
        // xrTableCell156
        // 
        this.xrTableCell156.Dpi = 254F;
        this.xrTableCell156.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell156.Name = "xrTableCell156";
        this.xrTableCell156.StylePriority.UseFont = false;
        this.xrTableCell156.StylePriority.UseTextAlignment = false;
        this.xrTableCell156.Text = "Cộng";
        this.xrTableCell156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell156.Weight = 0.38131059688618363D;
        // 
        // xrCongNgay1
        // 
        this.xrCongNgay1.Dpi = 254F;
        this.xrCongNgay1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay1.Name = "xrCongNgay1";
        this.xrCongNgay1.StylePriority.UseFont = false;
        this.xrCongNgay1.StylePriority.UseTextAlignment = false;
        xrSummary34.FormatString = "{0:n0}";
        xrSummary34.IgnoreNullValues = true;
        xrSummary34.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay1.Summary = xrSummary34;
        this.xrCongNgay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay1.Weight = 0.065420561050489462D;
        // 
        // xrCongNgay2
        // 
        this.xrCongNgay2.Dpi = 254F;
        this.xrCongNgay2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay2.Name = "xrCongNgay2";
        this.xrCongNgay2.StylePriority.UseFont = false;
        this.xrCongNgay2.StylePriority.UseTextAlignment = false;
        xrSummary35.FormatString = "{0:n0}";
        xrSummary35.IgnoreNullValues = true;
        xrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay2.Summary = xrSummary35;
        this.xrCongNgay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay2.Weight = 0.065420561819507908D;
        // 
        // xrCongNgay3
        // 
        this.xrCongNgay3.Dpi = 254F;
        this.xrCongNgay3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay3.Name = "xrCongNgay3";
        this.xrCongNgay3.StylePriority.UseFont = false;
        this.xrCongNgay3.StylePriority.UseTextAlignment = false;
        xrSummary36.FormatString = "{0:n0}";
        xrSummary36.IgnoreNullValues = true;
        xrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay3.Summary = xrSummary36;
        this.xrCongNgay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay3.Weight = 0.065420560624142476D;
        // 
        // xrCongNgay4
        // 
        this.xrCongNgay4.Dpi = 254F;
        this.xrCongNgay4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay4.Name = "xrCongNgay4";
        this.xrCongNgay4.StylePriority.UseFont = false;
        this.xrCongNgay4.StylePriority.UseTextAlignment = false;
        xrSummary37.FormatString = "{0:n0}";
        xrSummary37.IgnoreNullValues = true;
        xrSummary37.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay4.Summary = xrSummary37;
        this.xrCongNgay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay4.Weight = 0.065420559918079935D;
        // 
        // xrCongNgay5
        // 
        this.xrCongNgay5.Dpi = 254F;
        this.xrCongNgay5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay5.Name = "xrCongNgay5";
        this.xrCongNgay5.StylePriority.UseFont = false;
        this.xrCongNgay5.StylePriority.UseTextAlignment = false;
        xrSummary38.FormatString = "{0:n0}";
        xrSummary38.IgnoreNullValues = true;
        xrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay5.Summary = xrSummary38;
        this.xrCongNgay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay5.Weight = 0.065420561735218291D;
        // 
        // xrCongNgay6
        // 
        this.xrCongNgay6.Dpi = 254F;
        this.xrCongNgay6.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay6.Name = "xrCongNgay6";
        this.xrCongNgay6.StylePriority.UseFont = false;
        this.xrCongNgay6.StylePriority.UseTextAlignment = false;
        xrSummary39.FormatString = "{0:n0}";
        xrSummary39.IgnoreNullValues = true;
        xrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay6.Summary = xrSummary39;
        this.xrCongNgay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay6.Weight = 0.06542056206195164D;
        // 
        // xrCongNgay7
        // 
        this.xrCongNgay7.Dpi = 254F;
        this.xrCongNgay7.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay7.Name = "xrCongNgay7";
        this.xrCongNgay7.StylePriority.UseFont = false;
        this.xrCongNgay7.StylePriority.UseTextAlignment = false;
        xrSummary40.FormatString = "{0:n0}";
        xrSummary40.IgnoreNullValues = true;
        xrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay7.Summary = xrSummary40;
        this.xrCongNgay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay7.Weight = 0.06542056189107634D;
        // 
        // xrCongNgay8
        // 
        this.xrCongNgay8.Dpi = 254F;
        this.xrCongNgay8.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay8.Name = "xrCongNgay8";
        this.xrCongNgay8.StylePriority.UseFont = false;
        this.xrCongNgay8.StylePriority.UseTextAlignment = false;
        xrSummary41.FormatString = "{0:n0}";
        xrSummary41.IgnoreNullValues = true;
        xrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay8.Summary = xrSummary41;
        this.xrCongNgay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay8.Weight = 0.065420559500345421D;
        // 
        // xrCongNgay9
        // 
        this.xrCongNgay9.Dpi = 254F;
        this.xrCongNgay9.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay9.Name = "xrCongNgay9";
        this.xrCongNgay9.StylePriority.UseFont = false;
        this.xrCongNgay9.StylePriority.UseTextAlignment = false;
        xrSummary42.FormatString = "{0:n0}";
        xrSummary42.IgnoreNullValues = true;
        xrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay9.Summary = xrSummary42;
        this.xrCongNgay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay9.Weight = 0.065420559204691628D;
        // 
        // xrCongNgay10
        // 
        this.xrCongNgay10.Dpi = 254F;
        this.xrCongNgay10.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay10.Name = "xrCongNgay10";
        this.xrCongNgay10.StylePriority.UseFont = false;
        this.xrCongNgay10.StylePriority.UseTextAlignment = false;
        xrSummary43.FormatString = "{0:n0}";
        xrSummary43.IgnoreNullValues = true;
        xrSummary43.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay10.Summary = xrSummary43;
        this.xrCongNgay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay10.Weight = 0.0654205614642468D;
        // 
        // xrCongNgay11
        // 
        this.xrCongNgay11.Dpi = 254F;
        this.xrCongNgay11.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay11.Name = "xrCongNgay11";
        this.xrCongNgay11.StylePriority.UseFont = false;
        this.xrCongNgay11.StylePriority.UseTextAlignment = false;
        xrSummary44.FormatString = "{0:n0}";
        xrSummary44.IgnoreNullValues = true;
        xrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay11.Summary = xrSummary44;
        this.xrCongNgay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay11.Weight = 0.065420560780497766D;
        // 
        // xrCongNgay12
        // 
        this.xrCongNgay12.Dpi = 254F;
        this.xrCongNgay12.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay12.Name = "xrCongNgay12";
        this.xrCongNgay12.StylePriority.UseFont = false;
        this.xrCongNgay12.StylePriority.UseTextAlignment = false;
        xrSummary45.FormatString = "{0:n0}";
        xrSummary45.IgnoreNullValues = true;
        xrSummary45.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay12.Summary = xrSummary45;
        this.xrCongNgay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay12.Weight = 0.065420559235208231D;
        // 
        // xrCongNgay13
        // 
        this.xrCongNgay13.Dpi = 254F;
        this.xrCongNgay13.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay13.Name = "xrCongNgay13";
        this.xrCongNgay13.StylePriority.UseFont = false;
        this.xrCongNgay13.StylePriority.UseTextAlignment = false;
        xrSummary46.FormatString = "{0:n0}";
        xrSummary46.IgnoreNullValues = true;
        xrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay13.Summary = xrSummary46;
        this.xrCongNgay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay13.Weight = 0.065420559235208231D;
        // 
        // xrCongNgay14
        // 
        this.xrCongNgay14.Dpi = 254F;
        this.xrCongNgay14.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay14.Name = "xrCongNgay14";
        this.xrCongNgay14.StylePriority.UseFont = false;
        this.xrCongNgay14.StylePriority.UseTextAlignment = false;
        xrSummary47.FormatString = "{0:n0}";
        xrSummary47.IgnoreNullValues = true;
        xrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay14.Summary = xrSummary47;
        this.xrCongNgay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay14.Weight = 0.065420559702278114D;
        // 
        // xrCongNgay15
        // 
        this.xrCongNgay15.Dpi = 254F;
        this.xrCongNgay15.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay15.Name = "xrCongNgay15";
        this.xrCongNgay15.StylePriority.UseFont = false;
        this.xrCongNgay15.StylePriority.UseTextAlignment = false;
        xrSummary48.FormatString = "{0:n0}";
        xrSummary48.IgnoreNullValues = true;
        xrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay15.Summary = xrSummary48;
        this.xrCongNgay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay15.Weight = 0.065420560890493362D;
        // 
        // xrCongNgay16
        // 
        this.xrCongNgay16.Dpi = 254F;
        this.xrCongNgay16.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay16.Name = "xrCongNgay16";
        this.xrCongNgay16.StylePriority.UseFont = false;
        this.xrCongNgay16.StylePriority.UseTextAlignment = false;
        xrSummary49.FormatString = "{0:n0}";
        xrSummary49.IgnoreNullValues = true;
        xrSummary49.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay16.Summary = xrSummary49;
        this.xrCongNgay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay16.Weight = 0.065420559940086428D;
        // 
        // xrCongNgay17
        // 
        this.xrCongNgay17.Dpi = 254F;
        this.xrCongNgay17.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay17.Name = "xrCongNgay17";
        this.xrCongNgay17.StylePriority.UseFont = false;
        this.xrCongNgay17.StylePriority.UseTextAlignment = false;
        xrSummary50.FormatString = "{0:n0}";
        xrSummary50.IgnoreNullValues = true;
        xrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay17.Summary = xrSummary50;
        this.xrCongNgay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay17.Weight = 0.0654205592746663D;
        // 
        // xrCongNgay18
        // 
        this.xrCongNgay18.Dpi = 254F;
        this.xrCongNgay18.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay18.Name = "xrCongNgay18";
        this.xrCongNgay18.StylePriority.UseFont = false;
        this.xrCongNgay18.StylePriority.UseTextAlignment = false;
        xrSummary51.FormatString = "{0:n0}";
        xrSummary51.IgnoreNullValues = true;
        xrSummary51.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay18.Summary = xrSummary51;
        this.xrCongNgay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay18.Weight = 0.065420561174654D;
        // 
        // xrCongNgay19
        // 
        this.xrCongNgay19.Dpi = 254F;
        this.xrCongNgay19.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay19.Name = "xrCongNgay19";
        this.xrCongNgay19.StylePriority.UseFont = false;
        this.xrCongNgay19.StylePriority.UseTextAlignment = false;
        xrSummary52.FormatString = "{0:n0}";
        xrSummary52.IgnoreNullValues = true;
        xrSummary52.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay19.Summary = xrSummary52;
        this.xrCongNgay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay19.Weight = 0.065420561174653974D;
        // 
        // xrCongNgay20
        // 
        this.xrCongNgay20.Dpi = 254F;
        this.xrCongNgay20.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay20.Name = "xrCongNgay20";
        this.xrCongNgay20.StylePriority.UseFont = false;
        this.xrCongNgay20.StylePriority.UseTextAlignment = false;
        xrSummary53.FormatString = "{0:n0}";
        xrSummary53.IgnoreNullValues = true;
        xrSummary53.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay20.Summary = xrSummary53;
        this.xrCongNgay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay20.Weight = 0.065420559218239166D;
        // 
        // xrCongNgay21
        // 
        this.xrCongNgay21.Dpi = 254F;
        this.xrCongNgay21.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay21.Name = "xrCongNgay21";
        this.xrCongNgay21.StylePriority.UseFont = false;
        this.xrCongNgay21.StylePriority.UseTextAlignment = false;
        xrSummary54.FormatString = "{0:n0}";
        xrSummary54.IgnoreNullValues = true;
        xrSummary54.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay21.Summary = xrSummary54;
        this.xrCongNgay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay21.Weight = 0.06542055968331309D;
        // 
        // xrCongNgay22
        // 
        this.xrCongNgay22.Dpi = 254F;
        this.xrCongNgay22.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay22.Name = "xrCongNgay22";
        this.xrCongNgay22.StylePriority.UseFont = false;
        this.xrCongNgay22.StylePriority.UseTextAlignment = false;
        xrSummary55.FormatString = "{0:n0}";
        xrSummary55.IgnoreNullValues = true;
        xrSummary55.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay22.Summary = xrSummary55;
        this.xrCongNgay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay22.Weight = 0.065420561359215451D;
        // 
        // xrCongNgay23
        // 
        this.xrCongNgay23.Dpi = 254F;
        this.xrCongNgay23.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay23.Name = "xrCongNgay23";
        this.xrCongNgay23.StylePriority.UseFont = false;
        this.xrCongNgay23.StylePriority.UseTextAlignment = false;
        xrSummary56.FormatString = "{0:n0}";
        xrSummary56.IgnoreNullValues = true;
        xrSummary56.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay23.Summary = xrSummary56;
        this.xrCongNgay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay23.Weight = 0.065420562890738276D;
        // 
        // xrCongNgay24
        // 
        this.xrCongNgay24.Dpi = 254F;
        this.xrCongNgay24.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay24.Name = "xrCongNgay24";
        this.xrCongNgay24.StylePriority.UseFont = false;
        this.xrCongNgay24.StylePriority.UseTextAlignment = false;
        xrSummary57.FormatString = "{0:n0}";
        xrSummary57.IgnoreNullValues = true;
        xrSummary57.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay24.Summary = xrSummary57;
        this.xrCongNgay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay24.Weight = 0.065420561368639579D;
        // 
        // xrCongNgay25
        // 
        this.xrCongNgay25.Dpi = 254F;
        this.xrCongNgay25.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay25.Name = "xrCongNgay25";
        this.xrCongNgay25.StylePriority.UseFont = false;
        this.xrCongNgay25.StylePriority.UseTextAlignment = false;
        xrSummary58.FormatString = "{0:n0}";
        xrSummary58.IgnoreNullValues = true;
        xrSummary58.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay25.Summary = xrSummary58;
        this.xrCongNgay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay25.Weight = 0.065420559919183829D;
        // 
        // xrCongNgay26
        // 
        this.xrCongNgay26.Dpi = 254F;
        this.xrCongNgay26.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay26.Name = "xrCongNgay26";
        this.xrCongNgay26.StylePriority.UseFont = false;
        this.xrCongNgay26.StylePriority.UseTextAlignment = false;
        xrSummary59.FormatString = "{0:n0}";
        xrSummary59.IgnoreNullValues = true;
        xrSummary59.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay26.Summary = xrSummary59;
        this.xrCongNgay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay26.Weight = 0.063472105600754516D;
        // 
        // xrCongNgay27
        // 
        this.xrCongNgay27.Dpi = 254F;
        this.xrCongNgay27.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay27.Name = "xrCongNgay27";
        this.xrCongNgay27.StylePriority.UseFont = false;
        this.xrCongNgay27.StylePriority.UseTextAlignment = false;
        xrSummary60.FormatString = "{0:n0}";
        xrSummary60.IgnoreNullValues = true;
        xrSummary60.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay27.Summary = xrSummary60;
        this.xrCongNgay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay27.Weight = 0.065614843234216388D;
        // 
        // xrCongNgay28
        // 
        this.xrCongNgay28.Dpi = 254F;
        this.xrCongNgay28.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay28.Name = "xrCongNgay28";
        this.xrCongNgay28.StylePriority.UseFont = false;
        this.xrCongNgay28.StylePriority.UseTextAlignment = false;
        xrSummary61.FormatString = "{0:n0}";
        xrSummary61.IgnoreNullValues = true;
        xrSummary61.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay28.Summary = xrSummary61;
        this.xrCongNgay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay28.Weight = 0.065420980541529464D;
        // 
        // xrCongNgay29
        // 
        this.xrCongNgay29.Dpi = 254F;
        this.xrCongNgay29.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay29.Name = "xrCongNgay29";
        this.xrCongNgay29.StylePriority.UseFont = false;
        this.xrCongNgay29.StylePriority.UseTextAlignment = false;
        xrSummary62.FormatString = "{0:n0}";
        xrSummary62.IgnoreNullValues = true;
        xrSummary62.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay29.Summary = xrSummary62;
        this.xrCongNgay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay29.Weight = 0.065225854984073475D;
        // 
        // xrCongNgay30
        // 
        this.xrCongNgay30.Dpi = 254F;
        this.xrCongNgay30.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay30.Name = "xrCongNgay30";
        this.xrCongNgay30.StylePriority.UseFont = false;
        this.xrCongNgay30.StylePriority.UseTextAlignment = false;
        xrSummary63.FormatString = "{0:n0}";
        xrSummary63.IgnoreNullValues = true;
        xrSummary63.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay30.Summary = xrSummary63;
        this.xrCongNgay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay30.Weight = 0.06561526746307153D;
        // 
        // xrCongNgay31
        // 
        this.xrCongNgay31.Dpi = 254F;
        this.xrCongNgay31.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongNgay31.Name = "xrCongNgay31";
        this.xrCongNgay31.StylePriority.UseFont = false;
        this.xrCongNgay31.StylePriority.UseTextAlignment = false;
        xrSummary64.FormatString = "{0:n0}";
        xrSummary64.IgnoreNullValues = true;
        xrSummary64.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongNgay31.Summary = xrSummary64;
        this.xrCongNgay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay31.Weight = 0.065225447491286531D;
        // 
        // xrCongTongXuat
        // 
        this.xrCongTongXuat.Dpi = 254F;
        this.xrCongTongXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongTongXuat.Multiline = true;
        this.xrCongTongXuat.Name = "xrCongTongXuat";
        this.xrCongTongXuat.StylePriority.UseFont = false;
        this.xrCongTongXuat.StylePriority.UseTextAlignment = false;
        xrSummary65.FormatString = "{0:n0}";
        xrSummary65.IgnoreNullValues = true;
        xrSummary65.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongTongXuat.Summary = xrSummary65;
        this.xrCongTongXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongTongXuat.Weight = 0.091759338864532081D;
        // 
        // xrCongThanhTien
        // 
        this.xrCongThanhTien.Dpi = 254F;
        this.xrCongThanhTien.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongThanhTien.Name = "xrCongThanhTien";
        this.xrCongThanhTien.StylePriority.UseFont = false;
        this.xrCongThanhTien.StylePriority.UseTextAlignment = false;
        xrSummary66.FormatString = "{0:n0}";
        xrSummary66.IgnoreNullValues = true;
        xrSummary66.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrCongThanhTien.Summary = xrSummary66;
        this.xrCongThanhTien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongThanhTien.Weight = 0.13678846096855638D;
        // 
        // xrCongComKhac
        // 
        this.xrCongComKhac.Dpi = 254F;
        this.xrCongComKhac.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongComKhac.Name = "xrCongComKhac";
        this.xrCongComKhac.StylePriority.UseFont = false;
        this.xrCongComKhac.StylePriority.UseTextAlignment = false;
        this.xrCongComKhac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongComKhac.Weight = 0.10620221674296701D;
        // 
        // xrCongTongComKhacVaXuat
        // 
        this.xrCongTongComKhacVaXuat.Dpi = 254F;
        this.xrCongTongComKhacVaXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrCongTongComKhacVaXuat.Name = "xrCongTongComKhacVaXuat";
        this.xrCongTongComKhacVaXuat.StylePriority.UseFont = false;
        this.xrCongTongComKhacVaXuat.StylePriority.UseTextAlignment = false;
        this.xrCongTongComKhacVaXuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongTongComKhacVaXuat.Weight = 0.18217701948155804D;
        // 
        // rp_ap_BangTongHopChiTietTienCom
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportFooter,
            this.GroupFooter4});
        this.Dpi = 254F;
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(0, 0, 101, 34);
        this.PageHeight = 2499;
        this.PageWidth = 3531;
        this.PaperKind = System.Drawing.Printing.PaperKind.IsoB4;
        this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
        this.SnapGridSize = 31.75F;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

}
