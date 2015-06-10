using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using DevExpress.XtraReports.UI;
/// <summary>
/// Summary description for rp_apTongHopAnCa
/// </summary>
public class rp_apTongHopAnCa : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrlTongHopAnCa;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrlTenchinhanh;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell18;
    private GroupFooterBand GroupFooter1;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_NguoiLap;
    private XRLabel xrlNgayLapPhieu;
    private XRLabel xrlTenPhuTrachChiNhanh;
    private XRLabel xrlTenThuKho;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrSTT;
    private XRTableCell xrHoten;
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
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
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
    private XRTableCell xrCongNgay14;
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
    private DevExpress.XtraReports.UI.XRLabel xrl_footer2;
    private DevExpress.XtraReports.UI.XRLabel xrl_footer1;
    private DevExpress.XtraReports.UI.XRLabel xrl_footer3;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_apTongHopAnCa()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;
    private void xrSTT_BeforePrint_1(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrSTT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        ReportController rpCtr = new ReportController();
        xrlNgayLapPhieu.Text = " Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        xrl_TenCongTy.Text = new ReportController().GetCompanyName(filter.SessionDepartment);
        xrlTenchinhanh.Text = new ReportController().GetCityName(filter.SessionDepartment);
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_ChamCongCom", "@MaBoPhan", "@Month", "@Year","@whereClause", filter.SelectedDepartment, filter.StartMonth, filter.Year, filter.WhereClause);
        DataSource = table;
        xrHoten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrNgay1.DataBindings.Add("Text", DataSource, "TienNgay1" ,"{0:n0}");
        xrNgay2.DataBindings.Add("Text", DataSource, "TienNgay2", "{0:n0}");
        xrNgay3.DataBindings.Add("Text", DataSource, "TienNgay3", "{0:n0}");
        xrNgay4.DataBindings.Add("Text", DataSource, "TienNgay4", "{0:n0}");
        xrNgay5.DataBindings.Add("Text", DataSource, "TienNgay5", "{0:n0}");
        xrNgay6.DataBindings.Add("Text", DataSource, "TienNgay6", "{0:n0}");
        xrNgay7.DataBindings.Add("Text", DataSource, "TienNgay7", "{0:n0}");
        xrNgay8.DataBindings.Add("Text", DataSource, "TienNgay8", "{0:n0}");
        xrNgay9.DataBindings.Add("Text", DataSource, "TienNgay9", "{0:n0}");
        xrNgay10.DataBindings.Add("Text", DataSource, "TienNgay10", "{0:n0}");
        xrNgay11.DataBindings.Add("Text", DataSource, "TienNgay11", "{0:n0}");
        xrNgay12.DataBindings.Add("Text", DataSource, "TienNgay12", "{0:n0}");
        xrNgay13.DataBindings.Add("Text", DataSource, "TienNgay13", "{0:n0}");
        xrNgay14.DataBindings.Add("Text", DataSource, "TienNgay14", "{0:n0}");
        xrNgay15.DataBindings.Add("Text", DataSource, "TienNgay15", "{0:n0}");
        xrNgay16.DataBindings.Add("Text", DataSource, "TienNgay16", "{0:n0}");
        xrNgay17.DataBindings.Add("Text", DataSource, "TienNgay17", "{0:n0}");
        xrNgay18.DataBindings.Add("Text", DataSource, "TienNgay18", "{0:n0}");
        xrNgay19.DataBindings.Add("Text", DataSource, "TienNgay19", "{0:n0}");
        xrNgay20.DataBindings.Add("Text", DataSource, "TienNgay20", "{0:n0}");
        xrNgay21.DataBindings.Add("Text", DataSource, "TienNgay21", "{0:n0}");
        xrNgay22.DataBindings.Add("Text", DataSource, "TienNgay22", "{0:n0}");
        xrNgay23.DataBindings.Add("Text", DataSource, "TienNgay23", "{0:n0}");
        xrNgay24.DataBindings.Add("Text", DataSource, "TienNgay24", "{0:n0}");
        xrNgay25.DataBindings.Add("Text", DataSource, "TienNgay25", "{0:n0}");
        xrNgay26.DataBindings.Add("Text", DataSource, "TienNgay26", "{0:n0}");
        xrNgay27.DataBindings.Add("Text", DataSource, "TienNgay27", "{0:n0}");
        xrNgay28.DataBindings.Add("Text", DataSource, "TienNgay28", "{0:n0}");
        xrNgay29.DataBindings.Add("Text", DataSource, "TienNgay29", "{0:n0}");
        xrNgay30.DataBindings.Add("Text", DataSource, "TienNgay30", "{0:n0}");
        xrNgay31.DataBindings.Add("Text", DataSource, "TienNgay31", "{0:n0}");

        xrCongNgay1.DataBindings.Add("Text", DataSource, "TienNgay1");
        xrCongNgay2.DataBindings.Add("Text", DataSource, "TienNgay2");
        xrCongNgay3.DataBindings.Add("Text", DataSource, "TienNgay3");
        xrCongNgay4.DataBindings.Add("Text", DataSource, "TienNgay4");
        xrCongNgay5.DataBindings.Add("Text", DataSource, "TienNgay5");
        xrCongNgay6.DataBindings.Add("Text", DataSource, "TienNgay6");
        xrCongNgay7.DataBindings.Add("Text", DataSource, "TienNgay7");
        xrCongNgay8.DataBindings.Add("Text", DataSource, "TienNgay8");
        xrCongNgay9.DataBindings.Add("Text", DataSource, "TienNgay9");
        xrCongNgay10.DataBindings.Add("Text", DataSource, "TienNgay10");
        xrCongNgay11.DataBindings.Add("Text", DataSource, "TienNgay11");
        xrCongNgay12.DataBindings.Add("Text", DataSource, "TienNgay12");
        xrCongNgay13.DataBindings.Add("Text", DataSource, "TienNgay13");
        xrCongNgay14.DataBindings.Add("Text", DataSource, "TienNgay14");
        xrCongNgay15.DataBindings.Add("Text", DataSource, "TienNgay15");
        xrCongNgay16.DataBindings.Add("Text", DataSource, "TienNgay16");
        xrCongNgay17.DataBindings.Add("Text", DataSource, "TienNgay17");
        xrCongNgay18.DataBindings.Add("Text", DataSource, "TienNgay18");
        xrCongNgay19.DataBindings.Add("Text", DataSource, "TienNgay19");
        xrCongNgay20.DataBindings.Add("Text", DataSource, "TienNgay20");
        xrCongNgay21.DataBindings.Add("Text", DataSource, "TienNgay21");
        xrCongNgay22.DataBindings.Add("Text", DataSource, "TienNgay22");
        xrCongNgay23.DataBindings.Add("Text", DataSource, "TienNgay23");
        xrCongNgay24.DataBindings.Add("Text", DataSource, "TienNgay24");
        xrCongNgay25.DataBindings.Add("Text", DataSource, "TienNgay25");
        xrCongNgay26.DataBindings.Add("Text", DataSource, "TienNgay26");
        xrCongNgay27.DataBindings.Add("Text", DataSource, "TienNgay27");
        xrCongNgay28.DataBindings.Add("Text", DataSource, "TienNgay28");
        xrCongNgay29.DataBindings.Add("Text", DataSource, "TienNgay29");
        xrCongNgay30.DataBindings.Add("Text", DataSource, "TienNgay30");
        xrCongNgay31.DataBindings.Add("Text", DataSource, "TienNgay31");
        
        xrl_footer1.Text = rpCtr.GetTitleOfSignature(xrl_footer1.Text, filter.Title1);
        xrl_footer2.Text = rpCtr.GetTitleOfSignature(xrl_footer2.Text, filter.Title2);
        xrl_NguoiLap.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrlTenPhuTrachChiNhanh.Text = filter.Name1;
        }
        
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrlTenThuKho.Text = filter.Name2;
        }
        if (!string.IsNullOrEmpty(filter.Reporter))
        {
            xrl_NguoiLap.Text = filter.Reporter;
        }
        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrlTongHopAnCa.Text = filter.ReportTitle;
        }
        else
        {
            
                xrlTongHopAnCa.Text = "TỔNG HỢP AN CA THÁNG " + filter.StartMonth +"/"+filter.Year;
            
        }
        

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
        string resourceFileName = "rp_apTongHopAnCa.resx";
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
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrSTT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrHoten = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrlTenchinhanh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlTongHopAnCa = new DevExpress.XtraReports.UI.XRLabel();
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
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NguoiLap = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNgayLapPhieu = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlTenPhuTrachChiNhanh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlTenThuKho = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.Dpi = 254F;
        this.Detail.HeightF = 86.125F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
        this.xrTable2.SizeF = new System.Drawing.SizeF(4201F, 86.125F);
        this.xrTable2.StylePriority.UseBorders = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrSTT,
            this.xrHoten,
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
            this.xrNgay31});
        this.xrTableRow2.Dpi = 254F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
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
        this.xrSTT.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSTT_BeforePrint_1);
        // 
        // xrHoten
        // 
        this.xrHoten.Dpi = 254F;
        this.xrHoten.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrHoten.Name = "xrHoten";
        this.xrHoten.StylePriority.UseFont = false;
        this.xrHoten.StylePriority.UseTextAlignment = false;
        this.xrHoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrHoten.Weight = 0.38131059688618363D;
        // 
        // xrNgay1
        // 
        this.xrNgay1.Dpi = 254F;
        this.xrNgay1.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay1.Name = "xrNgay1";
        this.xrNgay1.StylePriority.UseFont = false;
        this.xrNgay1.StylePriority.UseTextAlignment = false;
        this.xrNgay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay1.Weight = 0.0673307839337412D;
        // 
        // xrNgay2
        // 
        this.xrNgay2.Dpi = 254F;
        this.xrNgay2.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay2.Name = "xrNgay2";
        this.xrNgay2.StylePriority.UseFont = false;
        this.xrNgay2.StylePriority.UseTextAlignment = false;
        this.xrNgay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay2.Weight = 0.067330780171429072D;
        // 
        // xrNgay3
        // 
        this.xrNgay3.Dpi = 254F;
        this.xrNgay3.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay3.Name = "xrNgay3";
        this.xrNgay3.StylePriority.UseFont = false;
        this.xrNgay3.StylePriority.UseTextAlignment = false;
        this.xrNgay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay3.Weight = 0.067517123478680025D;
        // 
        // xrNgay4
        // 
        this.xrNgay4.Dpi = 254F;
        this.xrNgay4.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay4.Name = "xrNgay4";
        this.xrNgay4.StylePriority.UseFont = false;
        this.xrNgay4.StylePriority.UseTextAlignment = false;
        this.xrNgay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay4.Weight = 0.0673307830339032D;
        // 
        // xrNgay5
        // 
        this.xrNgay5.Dpi = 254F;
        this.xrNgay5.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay5.Name = "xrNgay5";
        this.xrNgay5.StylePriority.UseFont = false;
        this.xrNgay5.StylePriority.UseTextAlignment = false;
        this.xrNgay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay5.Weight = 0.067330780842159488D;
        // 
        // xrNgay6
        // 
        this.xrNgay6.Dpi = 254F;
        this.xrNgay6.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay6.Name = "xrNgay6";
        this.xrNgay6.StylePriority.UseFont = false;
        this.xrNgay6.StylePriority.UseTextAlignment = false;
        this.xrNgay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay6.Weight = 0.067330781658521147D;
        // 
        // xrNgay7
        // 
        this.xrNgay7.Dpi = 254F;
        this.xrNgay7.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay7.Name = "xrNgay7";
        this.xrNgay7.StylePriority.UseFont = false;
        this.xrNgay7.StylePriority.UseTextAlignment = false;
        this.xrNgay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay7.Weight = 0.067330779633302251D;
        // 
        // xrNgay8
        // 
        this.xrNgay8.Dpi = 254F;
        this.xrNgay8.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay8.Name = "xrNgay8";
        this.xrNgay8.StylePriority.UseFont = false;
        this.xrNgay8.StylePriority.UseTextAlignment = false;
        this.xrNgay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay8.Weight = 0.067330780166135584D;
        // 
        // xrNgay9
        // 
        this.xrNgay9.Dpi = 254F;
        this.xrNgay9.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay9.Name = "xrNgay9";
        this.xrNgay9.StylePriority.UseFont = false;
        this.xrNgay9.StylePriority.UseTextAlignment = false;
        this.xrNgay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay9.Weight = 0.067330782086291632D;
        // 
        // xrNgay10
        // 
        this.xrNgay10.Dpi = 254F;
        this.xrNgay10.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay10.Name = "xrNgay10";
        this.xrNgay10.StylePriority.UseFont = false;
        this.xrNgay10.StylePriority.UseTextAlignment = false;
        this.xrNgay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay10.Weight = 0.067330784703058019D;
        // 
        // xrNgay11
        // 
        this.xrNgay11.Dpi = 254F;
        this.xrNgay11.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay11.Name = "xrNgay11";
        this.xrNgay11.StylePriority.UseFont = false;
        this.xrNgay11.StylePriority.UseTextAlignment = false;
        this.xrNgay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay11.Weight = 0.067330779793174172D;
        // 
        // xrNgay12
        // 
        this.xrNgay12.Dpi = 254F;
        this.xrNgay12.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay12.Name = "xrNgay12";
        this.xrNgay12.StylePriority.UseFont = false;
        this.xrNgay12.StylePriority.UseTextAlignment = false;
        this.xrNgay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay12.Weight = 0.06733078149255925D;
        // 
        // xrNgay13
        // 
        this.xrNgay13.Dpi = 254F;
        this.xrNgay13.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay13.Name = "xrNgay13";
        this.xrNgay13.StylePriority.UseFont = false;
        this.xrNgay13.StylePriority.UseTextAlignment = false;
        this.xrNgay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay13.Weight = 0.067330781492559236D;
        // 
        // xrNgay14
        // 
        this.xrNgay14.Dpi = 254F;
        this.xrNgay14.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay14.Name = "xrNgay14";
        this.xrNgay14.StylePriority.UseFont = false;
        this.xrNgay14.StylePriority.UseTextAlignment = false;
        this.xrNgay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay14.Weight = 0.067330783461134483D;
        // 
        // xrNgay15
        // 
        this.xrNgay15.Dpi = 254F;
        this.xrNgay15.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay15.Name = "xrNgay15";
        this.xrNgay15.StylePriority.UseFont = false;
        this.xrNgay15.StylePriority.UseTextAlignment = false;
        this.xrNgay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay15.Weight = 0.06733078295435D;
        // 
        // xrNgay16
        // 
        this.xrNgay16.Dpi = 254F;
        this.xrNgay16.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay16.Name = "xrNgay16";
        this.xrNgay16.StylePriority.UseFont = false;
        this.xrNgay16.StylePriority.UseTextAlignment = false;
        this.xrNgay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay16.Weight = 0.067330776555540511D;
        // 
        // xrNgay17
        // 
        this.xrNgay17.Dpi = 254F;
        this.xrNgay17.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay17.Name = "xrNgay17";
        this.xrNgay17.StylePriority.UseFont = false;
        this.xrNgay17.StylePriority.UseTextAlignment = false;
        this.xrNgay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay17.Weight = 0.067330784623599135D;
        // 
        // xrNgay18
        // 
        this.xrNgay18.Dpi = 254F;
        this.xrNgay18.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay18.Name = "xrNgay18";
        this.xrNgay18.StylePriority.UseFont = false;
        this.xrNgay18.StylePriority.UseTextAlignment = false;
        this.xrNgay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay18.Weight = 0.067330781676293444D;
        // 
        // xrNgay19
        // 
        this.xrNgay19.Dpi = 254F;
        this.xrNgay19.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay19.Name = "xrNgay19";
        this.xrNgay19.StylePriority.UseFont = false;
        this.xrNgay19.StylePriority.UseTextAlignment = false;
        this.xrNgay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay19.Weight = 0.067330775838871759D;
        // 
        // xrNgay20
        // 
        this.xrNgay20.Dpi = 254F;
        this.xrNgay20.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay20.Name = "xrNgay20";
        this.xrNgay20.StylePriority.UseFont = false;
        this.xrNgay20.StylePriority.UseTextAlignment = false;
        this.xrNgay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay20.Weight = 0.06733078020838229D;
        // 
        // xrNgay21
        // 
        this.xrNgay21.Dpi = 254F;
        this.xrNgay21.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay21.Name = "xrNgay21";
        this.xrNgay21.StylePriority.UseFont = false;
        this.xrNgay21.StylePriority.UseTextAlignment = false;
        this.xrNgay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay21.Weight = 0.067330779655354583D;
        // 
        // xrNgay22
        // 
        this.xrNgay22.Dpi = 254F;
        this.xrNgay22.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay22.Name = "xrNgay22";
        this.xrNgay22.StylePriority.UseFont = false;
        this.xrNgay22.StylePriority.UseTextAlignment = false;
        this.xrNgay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay22.Weight = 0.067330788988384571D;
        // 
        // xrNgay23
        // 
        this.xrNgay23.Dpi = 254F;
        this.xrNgay23.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay23.Name = "xrNgay23";
        this.xrNgay23.StylePriority.UseFont = false;
        this.xrNgay23.StylePriority.UseTextAlignment = false;
        this.xrNgay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay23.Weight = 0.067330780601584456D;
        // 
        // xrNgay24
        // 
        this.xrNgay24.Dpi = 254F;
        this.xrNgay24.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay24.Name = "xrNgay24";
        this.xrNgay24.StylePriority.UseFont = false;
        this.xrNgay24.StylePriority.UseTextAlignment = false;
        this.xrNgay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay24.Weight = 0.0673307829703504D;
        // 
        // xrNgay25
        // 
        this.xrNgay25.Dpi = 254F;
        this.xrNgay25.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay25.Name = "xrNgay25";
        this.xrNgay25.StylePriority.UseFont = false;
        this.xrNgay25.StylePriority.UseTextAlignment = false;
        this.xrNgay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay25.Weight = 0.067330782390244218D;
        // 
        // xrNgay26
        // 
        this.xrNgay26.Dpi = 254F;
        this.xrNgay26.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay26.Name = "xrNgay26";
        this.xrNgay26.StylePriority.UseFont = false;
        this.xrNgay26.StylePriority.UseTextAlignment = false;
        this.xrNgay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay26.Weight = 0.067330783070145991D;
        // 
        // xrNgay27
        // 
        this.xrNgay27.Dpi = 254F;
        this.xrNgay27.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay27.Name = "xrNgay27";
        this.xrNgay27.StylePriority.UseFont = false;
        this.xrNgay27.StylePriority.UseTextAlignment = false;
        this.xrNgay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay27.Weight = 0.067330788907567621D;
        // 
        // xrNgay28
        // 
        this.xrNgay28.Dpi = 254F;
        this.xrNgay28.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay28.Name = "xrNgay28";
        this.xrNgay28.StylePriority.UseFont = false;
        this.xrNgay28.StylePriority.UseTextAlignment = false;
        this.xrNgay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay28.Weight = 0.067330784960341283D;
        // 
        // xrNgay29
        // 
        this.xrNgay29.Dpi = 254F;
        this.xrNgay29.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay29.Name = "xrNgay29";
        this.xrNgay29.StylePriority.UseFont = false;
        this.xrNgay29.StylePriority.UseTextAlignment = false;
        this.xrNgay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay29.Weight = 0.067330784906729307D;
        // 
        // xrNgay30
        // 
        this.xrNgay30.Dpi = 254F;
        this.xrNgay30.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay30.Name = "xrNgay30";
        this.xrNgay30.StylePriority.UseFont = false;
        this.xrNgay30.StylePriority.UseTextAlignment = false;
        this.xrNgay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay30.Weight = 0.067330776731404432D;
        // 
        // xrNgay31
        // 
        this.xrNgay31.Dpi = 254F;
        this.xrNgay31.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrNgay31.Name = "xrNgay31";
        this.xrNgay31.StylePriority.UseFont = false;
        this.xrNgay31.StylePriority.UseTextAlignment = false;
        this.xrNgay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrNgay31.Weight = 0.067330801363767623D;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 254F;
        this.TopMargin.HeightF = 137F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 254F;
        this.BottomMargin.HeightF = 79F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlTenchinhanh,
            this.xrl_TenCongTy,
            this.xrlTongHopAnCa});
        this.ReportHeader.Dpi = 254F;
        this.ReportHeader.HeightF = 415F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrlTenchinhanh
        // 
        this.xrlTenchinhanh.Dpi = 254F;
        this.xrlTenchinhanh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrlTenchinhanh.LocationFloat = new DevExpress.Utils.PointFloat(124.9421F, 68.68581F);
        this.xrlTenchinhanh.Name = "xrlTenchinhanh";
        this.xrlTenchinhanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlTenchinhanh.SizeF = new System.Drawing.SizeF(1100.667F, 58.42F);
        this.xrlTenchinhanh.StylePriority.UseFont = false;
        this.xrlTenchinhanh.StylePriority.UseTextAlignment = false;
        this.xrlTenchinhanh.Text = "CHI NHÁNH 1";
        this.xrlTenchinhanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Dpi = 254F;
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(124.9421F, 0F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(1100.667F, 58.42F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN THẾ GIỚI GIẢI TRÍ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlTongHopAnCa
        // 
        this.xrlTongHopAnCa.Dpi = 254F;
        this.xrlTongHopAnCa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
        this.xrlTongHopAnCa.LocationFloat = new DevExpress.Utils.PointFloat(0F, 191.7467F);
        this.xrlTongHopAnCa.Name = "xrlTongHopAnCa";
        this.xrlTongHopAnCa.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlTongHopAnCa.SizeF = new System.Drawing.SizeF(4201F, 98.10747F);
        this.xrlTongHopAnCa.StylePriority.UseFont = false;
        this.xrlTongHopAnCa.StylePriority.UseTextAlignment = false;
        this.xrlTongHopAnCa.Text = "TỔNG HỢP ĂN CA THÁNG 2/2014";
        this.xrlTongHopAnCa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.Dpi = 254F;
        this.PageHeader.HeightF = 109.9375F;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(4201F, 109.9375F);
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
            this.xrTableCell18});
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
        this.xrTableCell6.Weight = 0.0673307839337412D;
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
        this.xrTableCell20.Weight = 0.067330780171429072D;
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
        this.xrTableCell11.Weight = 0.067517123478680025D;
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
        this.xrTableCell1.Weight = 0.0673307830339032D;
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
        this.xrTableCell10.Weight = 0.067330780842159488D;
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
        this.xrTableCell8.Weight = 0.067330781658521147D;
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
        this.xrTableCell22.Weight = 0.067330779633302251D;
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
        this.xrTableCell21.Weight = 0.067330780166135584D;
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
        this.xrTableCell23.Weight = 0.067330782086291632D;
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
        this.xrTableCell29.Weight = 0.067330784703058019D;
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
        this.xrTableCell28.Weight = 0.067330779793174172D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Dpi = 254F;
        this.xrTableCell31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseFont = false;
        this.xrTableCell31.StylePriority.UseTextAlignment = false;
        this.xrTableCell31.Text = "12";
        this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell31.Weight = 0.06733078149255925D;
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
        this.xrTableCell30.Weight = 0.067330781492559236D;
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
        this.xrTableCell9.Weight = 0.067330783461134483D;
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
        this.xrTableCell7.Weight = 0.06733078295435D;
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
        this.xrTableCell32.Weight = 0.067330776555540511D;
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
        this.xrTableCell13.Weight = 0.067330784623599135D;
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
        this.xrTableCell33.Weight = 0.067330781676293444D;
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
        this.xrTableCell24.Weight = 0.067330775838871759D;
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
        this.xrTableCell25.Weight = 0.06733078020838229D;
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
        this.xrTableCell34.Weight = 0.067330779655354583D;
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
        this.xrTableCell12.Weight = 0.067330788988384571D;
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
        this.xrTableCell14.Weight = 0.067330780601584456D;
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
        this.xrTableCell2.Weight = 0.0673307829703504D;
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
        this.xrTableCell26.Weight = 0.067330782390244218D;
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
        this.xrTableCell35.Weight = 0.067330783070145991D;
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
        this.xrTableCell17.Weight = 0.067330788907567621D;
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
        this.xrTableCell16.Weight = 0.067330784960341283D;
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
        this.xrTableCell36.Weight = 0.067330784906729307D;
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
        this.xrTableCell27.Weight = 0.067330776731404432D;
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
        this.xrTableCell18.Weight = 0.067330801363767623D;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.GroupFooter1.Dpi = 254F;
        this.GroupFooter1.HeightF = 86.125F;
        this.GroupFooter1.Name = "GroupFooter1";
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
        this.xrTable3.SizeF = new System.Drawing.SizeF(4201F, 86.125F);
        this.xrTable3.StylePriority.UseBorders = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell67,
            this.xrTableCell68,
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
            this.xrCongNgay31});
        this.xrTableRow3.Dpi = 254F;
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell67
        // 
        this.xrTableCell67.Dpi = 254F;
        this.xrTableCell67.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell67.Name = "xrTableCell67";
        this.xrTableCell67.StylePriority.UseFont = false;
        this.xrTableCell67.StylePriority.UseTextAlignment = false;
        this.xrTableCell67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell67.Weight = 0.075673852624445384D;
        // 
        // xrTableCell68
        // 
        this.xrTableCell68.Dpi = 254F;
        this.xrTableCell68.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell68.Name = "xrTableCell68";
        this.xrTableCell68.StylePriority.UseFont = false;
        this.xrTableCell68.StylePriority.UseTextAlignment = false;
        this.xrTableCell68.Text = "Cộng";
        this.xrTableCell68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell68.Weight = 0.38131059688618363D;
        // 
        // xrCongNgay1
        // 
        this.xrCongNgay1.Dpi = 254F;
        this.xrCongNgay1.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay1.Name = "xrCongNgay1";
        this.xrCongNgay1.StylePriority.UseFont = false;
        this.xrCongNgay1.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:n0}";
        xrSummary1.IgnoreNullValues = true;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay1.Summary = xrSummary1;
        this.xrCongNgay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay1.Weight = 0.0673307839337412D;
        // 
        // xrCongNgay2
        // 
        this.xrCongNgay2.Dpi = 254F;
        this.xrCongNgay2.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay2.Name = "xrCongNgay2";
        this.xrCongNgay2.StylePriority.UseFont = false;
        this.xrCongNgay2.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:n0}";
        xrSummary2.IgnoreNullValues = true;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay2.Summary = xrSummary2;
        this.xrCongNgay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay2.Weight = 0.067330780171429072D;
        // 
        // xrCongNgay3
        // 
        this.xrCongNgay3.Dpi = 254F;
        this.xrCongNgay3.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay3.Name = "xrCongNgay3";
        this.xrCongNgay3.StylePriority.UseFont = false;
        this.xrCongNgay3.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:n0}";
        xrSummary3.IgnoreNullValues = true;
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay3.Summary = xrSummary3;
        this.xrCongNgay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay3.Weight = 0.067517123478680025D;
        // 
        // xrCongNgay4
        // 
        this.xrCongNgay4.Dpi = 254F;
        this.xrCongNgay4.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay4.Name = "xrCongNgay4";
        this.xrCongNgay4.StylePriority.UseFont = false;
        this.xrCongNgay4.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:n0}";
        xrSummary4.IgnoreNullValues = true;
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay4.Summary = xrSummary4;
        this.xrCongNgay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay4.Weight = 0.0673307830339032D;
        // 
        // xrCongNgay5
        // 
        this.xrCongNgay5.Dpi = 254F;
        this.xrCongNgay5.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay5.Name = "xrCongNgay5";
        this.xrCongNgay5.StylePriority.UseFont = false;
        this.xrCongNgay5.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:n0}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay5.Summary = xrSummary5;
        this.xrCongNgay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay5.Weight = 0.067330780842159488D;
        // 
        // xrCongNgay6
        // 
        this.xrCongNgay6.Dpi = 254F;
        this.xrCongNgay6.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay6.Name = "xrCongNgay6";
        this.xrCongNgay6.StylePriority.UseFont = false;
        this.xrCongNgay6.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:n0}";
        xrSummary6.IgnoreNullValues = true;
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay6.Summary = xrSummary6;
        this.xrCongNgay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay6.Weight = 0.067330781658521147D;
        // 
        // xrCongNgay7
        // 
        this.xrCongNgay7.Dpi = 254F;
        this.xrCongNgay7.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay7.Name = "xrCongNgay7";
        this.xrCongNgay7.StylePriority.UseFont = false;
        this.xrCongNgay7.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:n0}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay7.Summary = xrSummary7;
        this.xrCongNgay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay7.Weight = 0.067330779633302251D;
        // 
        // xrCongNgay8
        // 
        this.xrCongNgay8.Dpi = 254F;
        this.xrCongNgay8.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay8.Name = "xrCongNgay8";
        this.xrCongNgay8.StylePriority.UseFont = false;
        this.xrCongNgay8.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:n0}";
        xrSummary8.IgnoreNullValues = true;
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay8.Summary = xrSummary8;
        this.xrCongNgay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay8.Weight = 0.067330780166135584D;
        // 
        // xrCongNgay9
        // 
        this.xrCongNgay9.Dpi = 254F;
        this.xrCongNgay9.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay9.Name = "xrCongNgay9";
        this.xrCongNgay9.StylePriority.UseFont = false;
        this.xrCongNgay9.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:n0}";
        xrSummary9.IgnoreNullValues = true;
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay9.Summary = xrSummary9;
        this.xrCongNgay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay9.Weight = 0.067330782086291632D;
        // 
        // xrCongNgay10
        // 
        this.xrCongNgay10.Dpi = 254F;
        this.xrCongNgay10.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay10.Name = "xrCongNgay10";
        this.xrCongNgay10.StylePriority.UseFont = false;
        this.xrCongNgay10.StylePriority.UseTextAlignment = false;
        xrSummary10.FormatString = "{0:n0}";
        xrSummary10.IgnoreNullValues = true;
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay10.Summary = xrSummary10;
        this.xrCongNgay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay10.Weight = 0.067330784703058019D;
        // 
        // xrCongNgay11
        // 
        this.xrCongNgay11.Dpi = 254F;
        this.xrCongNgay11.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay11.Name = "xrCongNgay11";
        this.xrCongNgay11.StylePriority.UseFont = false;
        this.xrCongNgay11.StylePriority.UseTextAlignment = false;
        xrSummary11.FormatString = "{0:n0}";
        xrSummary11.IgnoreNullValues = true;
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay11.Summary = xrSummary11;
        this.xrCongNgay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay11.Weight = 0.067330779793174172D;
        // 
        // xrCongNgay12
        // 
        this.xrCongNgay12.Dpi = 254F;
        this.xrCongNgay12.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay12.Name = "xrCongNgay12";
        this.xrCongNgay12.StylePriority.UseFont = false;
        this.xrCongNgay12.StylePriority.UseTextAlignment = false;
        xrSummary12.FormatString = "{0:n0}";
        xrSummary12.IgnoreNullValues = true;
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay12.Summary = xrSummary12;
        this.xrCongNgay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay12.Weight = 0.06733078149255925D;
        // 
        // xrCongNgay13
        // 
        this.xrCongNgay13.Dpi = 254F;
        this.xrCongNgay13.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay13.Name = "xrCongNgay13";
        this.xrCongNgay13.StylePriority.UseFont = false;
        this.xrCongNgay13.StylePriority.UseTextAlignment = false;
        xrSummary13.FormatString = "{0:n0}";
        xrSummary13.IgnoreNullValues = true;
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay13.Summary = xrSummary13;
        this.xrCongNgay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay13.Weight = 0.067330781492559236D;
        // 
        // xrCongNgay14
        // 
        this.xrCongNgay14.Dpi = 254F;
        this.xrCongNgay14.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay14.Name = "xrCongNgay14";
        this.xrCongNgay14.StylePriority.UseFont = false;
        this.xrCongNgay14.StylePriority.UseTextAlignment = false;
        xrSummary14.FormatString = "{0:n0}";
        xrSummary14.IgnoreNullValues = true;
        xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay14.Summary = xrSummary14;
        this.xrCongNgay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay14.Weight = 0.067330783461134483D;
        // 
        // xrCongNgay15
        // 
        this.xrCongNgay15.Dpi = 254F;
        this.xrCongNgay15.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay15.Name = "xrCongNgay15";
        this.xrCongNgay15.StylePriority.UseFont = false;
        this.xrCongNgay15.StylePriority.UseTextAlignment = false;
        xrSummary15.FormatString = "{0:n0}";
        xrSummary15.IgnoreNullValues = true;
        xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay15.Summary = xrSummary15;
        this.xrCongNgay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay15.Weight = 0.06733078295435D;
        // 
        // xrCongNgay16
        // 
        this.xrCongNgay16.Dpi = 254F;
        this.xrCongNgay16.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay16.Name = "xrCongNgay16";
        this.xrCongNgay16.StylePriority.UseFont = false;
        this.xrCongNgay16.StylePriority.UseTextAlignment = false;
        xrSummary16.FormatString = "{0:n0}";
        xrSummary16.IgnoreNullValues = true;
        xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay16.Summary = xrSummary16;
        this.xrCongNgay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay16.Weight = 0.067330776555540511D;
        // 
        // xrCongNgay17
        // 
        this.xrCongNgay17.Dpi = 254F;
        this.xrCongNgay17.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay17.Name = "xrCongNgay17";
        this.xrCongNgay17.StylePriority.UseFont = false;
        this.xrCongNgay17.StylePriority.UseTextAlignment = false;
        xrSummary17.FormatString = "{0:n0}";
        xrSummary17.IgnoreNullValues = true;
        xrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay17.Summary = xrSummary17;
        this.xrCongNgay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay17.Weight = 0.067330784623599135D;
        // 
        // xrCongNgay18
        // 
        this.xrCongNgay18.Dpi = 254F;
        this.xrCongNgay18.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay18.Name = "xrCongNgay18";
        this.xrCongNgay18.StylePriority.UseFont = false;
        this.xrCongNgay18.StylePriority.UseTextAlignment = false;
        xrSummary18.FormatString = "{0:n0}";
        xrSummary18.IgnoreNullValues = true;
        xrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay18.Summary = xrSummary18;
        this.xrCongNgay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay18.Weight = 0.067330781676293444D;
        // 
        // xrCongNgay19
        // 
        this.xrCongNgay19.Dpi = 254F;
        this.xrCongNgay19.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay19.Name = "xrCongNgay19";
        this.xrCongNgay19.StylePriority.UseFont = false;
        this.xrCongNgay19.StylePriority.UseTextAlignment = false;
        xrSummary19.FormatString = "{0:n0}";
        xrSummary19.IgnoreNullValues = true;
        xrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay19.Summary = xrSummary19;
        this.xrCongNgay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay19.Weight = 0.067330775838871759D;
        // 
        // xrCongNgay20
        // 
        this.xrCongNgay20.Dpi = 254F;
        this.xrCongNgay20.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay20.Name = "xrCongNgay20";
        this.xrCongNgay20.StylePriority.UseFont = false;
        this.xrCongNgay20.StylePriority.UseTextAlignment = false;
        xrSummary20.FormatString = "{0:n0}";
        xrSummary20.IgnoreNullValues = true;
        xrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay20.Summary = xrSummary20;
        this.xrCongNgay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay20.Weight = 0.06733078020838229D;
        // 
        // xrCongNgay21
        // 
        this.xrCongNgay21.Dpi = 254F;
        this.xrCongNgay21.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay21.Name = "xrCongNgay21";
        this.xrCongNgay21.StylePriority.UseFont = false;
        this.xrCongNgay21.StylePriority.UseTextAlignment = false;
        xrSummary21.FormatString = "{0:n0}";
        xrSummary21.IgnoreNullValues = true;
        xrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay21.Summary = xrSummary21;
        this.xrCongNgay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay21.Weight = 0.067330779655354583D;
        // 
        // xrCongNgay22
        // 
        this.xrCongNgay22.Dpi = 254F;
        this.xrCongNgay22.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay22.Name = "xrCongNgay22";
        this.xrCongNgay22.StylePriority.UseFont = false;
        this.xrCongNgay22.StylePriority.UseTextAlignment = false;
        xrSummary22.FormatString = "{0:n0}";
        xrSummary22.IgnoreNullValues = true;
        xrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay22.Summary = xrSummary22;
        this.xrCongNgay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay22.Weight = 0.067330788988384571D;
        // 
        // xrCongNgay23
        // 
        this.xrCongNgay23.Dpi = 254F;
        this.xrCongNgay23.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay23.Name = "xrCongNgay23";
        this.xrCongNgay23.StylePriority.UseFont = false;
        this.xrCongNgay23.StylePriority.UseTextAlignment = false;
        xrSummary23.FormatString = "{0:n0}";
        xrSummary23.IgnoreNullValues = true;
        xrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay23.Summary = xrSummary23;
        this.xrCongNgay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay23.Weight = 0.067330780601584456D;
        // 
        // xrCongNgay24
        // 
        this.xrCongNgay24.Dpi = 254F;
        this.xrCongNgay24.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay24.Name = "xrCongNgay24";
        this.xrCongNgay24.StylePriority.UseFont = false;
        this.xrCongNgay24.StylePriority.UseTextAlignment = false;
        xrSummary24.FormatString = "{0:n0}";
        xrSummary24.IgnoreNullValues = true;
        xrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay24.Summary = xrSummary24;
        this.xrCongNgay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay24.Weight = 0.0673307829703504D;
        // 
        // xrCongNgay25
        // 
        this.xrCongNgay25.Dpi = 254F;
        this.xrCongNgay25.Font = new System.Drawing.Font("Times New Roman", 5F);
        this.xrCongNgay25.Name = "xrCongNgay25";
        this.xrCongNgay25.StylePriority.UseFont = false;
        this.xrCongNgay25.StylePriority.UseTextAlignment = false;
        xrSummary25.FormatString = "{0:n0}";
        xrSummary25.IgnoreNullValues = true;
        xrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay25.Summary = xrSummary25;
        this.xrCongNgay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay25.Weight = 0.067330782390244218D;
        // 
        // xrCongNgay26
        // 
        this.xrCongNgay26.Dpi = 254F;
        this.xrCongNgay26.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay26.Name = "xrCongNgay26";
        this.xrCongNgay26.StylePriority.UseFont = false;
        this.xrCongNgay26.StylePriority.UseTextAlignment = false;
        xrSummary26.FormatString = "{0:n0}";
        xrSummary26.IgnoreNullValues = true;
        xrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay26.Summary = xrSummary26;
        this.xrCongNgay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay26.Weight = 0.067330783070145991D;
        // 
        // xrCongNgay27
        // 
        this.xrCongNgay27.Dpi = 254F;
        this.xrCongNgay27.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay27.Name = "xrCongNgay27";
        this.xrCongNgay27.StylePriority.UseFont = false;
        this.xrCongNgay27.StylePriority.UseTextAlignment = false;
        xrSummary27.FormatString = "{0:n0}";
        xrSummary27.IgnoreNullValues = true;
        xrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay27.Summary = xrSummary27;
        this.xrCongNgay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay27.Weight = 0.067330788907567621D;
        // 
        // xrCongNgay28
        // 
        this.xrCongNgay28.Dpi = 254F;
        this.xrCongNgay28.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay28.Name = "xrCongNgay28";
        this.xrCongNgay28.StylePriority.UseFont = false;
        this.xrCongNgay28.StylePriority.UseTextAlignment = false;
        xrSummary28.FormatString = "{0:n0}";
        xrSummary28.IgnoreNullValues = true;
        xrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay28.Summary = xrSummary28;
        this.xrCongNgay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay28.Weight = 0.067330784960341283D;
        // 
        // xrCongNgay29
        // 
        this.xrCongNgay29.Dpi = 254F;
        this.xrCongNgay29.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay29.Name = "xrCongNgay29";
        this.xrCongNgay29.StylePriority.UseFont = false;
        this.xrCongNgay29.StylePriority.UseTextAlignment = false;
        xrSummary29.FormatString = "{0:n0}";
        xrSummary29.IgnoreNullValues = true;
        xrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay29.Summary = xrSummary29;
        this.xrCongNgay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay29.Weight = 0.067330784906729307D;
        // 
        // xrCongNgay30
        // 
        this.xrCongNgay30.Dpi = 254F;
        this.xrCongNgay30.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay30.Name = "xrCongNgay30";
        this.xrCongNgay30.StylePriority.UseFont = false;
        this.xrCongNgay30.StylePriority.UseTextAlignment = false;
        xrSummary30.FormatString = "{0:n0}";
        xrSummary30.IgnoreNullValues = true;
        xrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay30.Summary = xrSummary30;
        this.xrCongNgay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay30.Weight = 0.067330776731404432D;
        // 
        // xrCongNgay31
        // 
        this.xrCongNgay31.Dpi = 254F;
        this.xrCongNgay31.Font = new System.Drawing.Font("Times New Roman", 7F);
        this.xrCongNgay31.Name = "xrCongNgay31";
        this.xrCongNgay31.StylePriority.UseFont = false;
        this.xrCongNgay31.StylePriority.UseTextAlignment = false;
        xrSummary31.FormatString = "{0:n0}";
        xrSummary31.IgnoreNullValues = true;
        xrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrCongNgay31.Summary = xrSummary31;
        this.xrCongNgay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrCongNgay31.Weight = 0.067330801363767623D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_footer3,
            this.xrl_footer1,
            this.xrl_footer2,
            this.xrl_NguoiLap,
            this.xrlNgayLapPhieu,
            this.xrlTenPhuTrachChiNhanh,
            this.xrlTenThuKho});
        this.ReportFooter.Dpi = 254F;
        this.ReportFooter.HeightF = 812F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Dpi = 254F;
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(3161.642F, 92.99982F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(640.2917F, 58.42F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "NGƯỜI LẬP";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Dpi = 254F;
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(475.6422F, 92.99982F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(515.9375F, 58.42F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "PHỤ TRÁCH CHI NHÁNH";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Dpi = 254F;
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(1631.642F, 92.99982F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(515.9377F, 58.42F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "THỦ KHO";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrl_NguoiLap
        // 
        this.xrl_NguoiLap.Dpi = 254F;
        this.xrl_NguoiLap.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_NguoiLap.LocationFloat = new DevExpress.Utils.PointFloat(3161.642F, 240.3749F);
        this.xrl_NguoiLap.Name = "xrl_NguoiLap";
        this.xrl_NguoiLap.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrl_NguoiLap.SizeF = new System.Drawing.SizeF(640.2917F, 58.42F);
        this.xrl_NguoiLap.StylePriority.UseFont = false;
        this.xrl_NguoiLap.StylePriority.UseTextAlignment = false;
        this.xrl_NguoiLap.Text = "Phùng thị thu hà";
        this.xrl_NguoiLap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrlNgayLapPhieu
        // 
        this.xrlNgayLapPhieu.Dpi = 254F;
        this.xrlNgayLapPhieu.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlNgayLapPhieu.LocationFloat = new DevExpress.Utils.PointFloat(3161.642F, 24.99993F);
        this.xrlNgayLapPhieu.Name = "xrlNgayLapPhieu";
        this.xrlNgayLapPhieu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlNgayLapPhieu.SizeF = new System.Drawing.SizeF(640.2917F, 58.41999F);
        this.xrlNgayLapPhieu.StylePriority.UseFont = false;
        this.xrlNgayLapPhieu.StylePriority.UseTextAlignment = false;
        this.xrlNgayLapPhieu.Text = "Hà nội, ngày 28 tháng 2 năm 2014";
        this.xrlNgayLapPhieu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlTenPhuTrachChiNhanh
        // 
        this.xrlTenPhuTrachChiNhanh.Dpi = 254F;
        this.xrlTenPhuTrachChiNhanh.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlTenPhuTrachChiNhanh.LocationFloat = new DevExpress.Utils.PointFloat(475.6422F, 240.3749F);
        this.xrlTenPhuTrachChiNhanh.Name = "xrlTenPhuTrachChiNhanh";
        this.xrlTenPhuTrachChiNhanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlTenPhuTrachChiNhanh.SizeF = new System.Drawing.SizeF(515.9375F, 58.42F);
        this.xrlTenPhuTrachChiNhanh.StylePriority.UseFont = false;
        this.xrlTenPhuTrachChiNhanh.StylePriority.UseTextAlignment = false;
        this.xrlTenPhuTrachChiNhanh.Text = "Vương Anh Tuấn";
        this.xrlTenPhuTrachChiNhanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrlTenThuKho
        // 
        this.xrlTenThuKho.Dpi = 254F;
        this.xrlTenThuKho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrlTenThuKho.LocationFloat = new DevExpress.Utils.PointFloat(1631.642F, 240.3749F);
        this.xrlTenThuKho.Name = "xrlTenThuKho";
        this.xrlTenThuKho.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrlTenThuKho.SizeF = new System.Drawing.SizeF(515.9377F, 58.42F);
        this.xrlTenThuKho.StylePriority.UseFont = false;
        this.xrlTenThuKho.StylePriority.UseTextAlignment = false;
        this.xrlTenThuKho.Text = "Đỗ thị Trang";
        this.xrlTenThuKho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // rp_apTongHopAnCa
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupFooter1,
            this.ReportFooter});
        this.Dpi = 254F;
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(0, 0, 137, 79);
        this.PageHeight = 2969;
        this.PageWidth = 4201;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3;
        this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
        this.SnapGridSize = 34F;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    
}
