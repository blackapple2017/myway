using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BaoCaoTongHopLamThemGio
/// </summary>
public class rp_BaoCaoTongHopLamThemGio : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private PageHeaderBand PageHeader;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell10;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell37;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell48;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell49;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_ngay20;
    private XRTableCell xrTableCell47;
    private XRTableCell xrt_macanbo;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_ngay1;
    private XRTableCell xrt_ngay2;
    private XRTableCell xrt_ngay3;
    private XRTableCell xrt_ngay4;
    private XRTableCell xrt_ngay5;
    private XRTableCell xrt_ngay6;
    private XRTableCell xrt_ngay7;
    private XRTableCell xrt_ngay8;
    private XRTableCell xrt_ngay9;
    private XRTableCell xrt_ngay10;
    private XRTableCell xrt_ngay11;
    private XRTableCell xrt_ngay12;
    private XRTableCell xrt_ngay13;
    private XRTableCell xrt_ngay14;
    private XRTableCell xrt_ngay15;
    private XRTableCell xrt_ngay16;
    private XRTableCell xrt_ngay17;
    private XRTableCell xrt_ngay18;
    private XRTableCell xrt_ngay19;
    private XRTableCell xrt_ngay21;
    private XRTableCell xrt_ngay22;
    private XRTableCell xrt_ngay23;
    private XRTableCell xrt_ngay24;
    private XRTableCell xrt_ngay25;
    private XRTableCell xrt_ngay26;
    private XRTableCell xrt_ngay27;
    private XRTableCell xrt_ngay28;
    private XRTableCell xrt_ngay29;
    private XRTableCell xrt_ngay30;
    private XRTableCell xrt_ngay31;
    private XRTableCell xrtSoNgayThuong;
    private XRTableCell xrtSoGioThuong;
    private XRTableCell xrtSoNgayNghi;
    private XRTableCell xrtSoGioNghi;
    private XRTableCell xrtSoNgayLe;
    private XRTableCell xrtSoGioLe;
    private XRTableCell xrtTongGio;
    private XRLabel xrl_ten2;
    private XRLabel xrl_footer1;
    private XRLabel xrl_ten1;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_ten3;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrtTongNgay;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell grpBoPhan;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BaoCaoTongHopLamThemGio()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrt_stt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilterTimeKeeper rp)
    {

        #region xử lý  phần header 
        xrl_TenCongTy.Text = rp.CompanyName;
        xrl_TenThanhPho.Text = rp.CityName.ToUpper();
        if (rp.ReportTitle != "") xrl_TitleBC.Text = "BÁO CÁO TỔNG HỢP LÀM THÊM GIỜ THÁNG " + rp.ThangBaoCao.ToString() + " NĂM " + rp.NamBaoCao.ToString();
        #endregion
        //#region xử lý phần detail
        DataTable dt = new DataTable();
        dt = DataHandler.GetInstance().ExecuteDataTable("sp_BaoCaoTongHopLamThemGio","@MaDonVi", "@MaBoPhan", "@MaChucVu", "@MaViTriCongViec", "@IDBangChamCong",rp.SessionDepartmentID, rp.CheckedDepartmentID == "" ? rp.ChildrenOfDepartmentID : rp.CheckedDepartmentID, rp.MaChucVu,rp.MaViTriCongViec,rp.IDDanhSachBangTongHopCong);
        DataSource = dt;
        xrt_macanbo.DataBindings.Add("Text", DataSource, "MaCB");
        xrt_hovaten.DataBindings.Add("Text", DataSource, "HoTen");
        xrt_ngay1.DataBindings.Add("Text", DataSource, "Ngay01");
        xrt_ngay2.DataBindings.Add("Text", DataSource, "Ngay02");
        xrt_ngay3.DataBindings.Add("Text", DataSource, "Ngay03");
        xrt_ngay4.DataBindings.Add("Text", DataSource, "Ngay04");
        xrt_ngay5.DataBindings.Add("Text", DataSource, "Ngay05");
        xrt_ngay6.DataBindings.Add("Text", DataSource, "Ngay06");
        xrt_ngay7.DataBindings.Add("Text", DataSource, "Ngay07");
        xrt_ngay8.DataBindings.Add("Text", DataSource, "Ngay08");
        xrt_ngay9.DataBindings.Add("Text", DataSource, "Ngay09");
        xrt_ngay10.DataBindings.Add("Text", DataSource, "Ngay10");
        xrt_ngay11.DataBindings.Add("Text", DataSource, "Ngay11");
        xrt_ngay12.DataBindings.Add("Text", DataSource, "Ngay12");
        xrt_ngay13.DataBindings.Add("Text", DataSource, "Ngay13");
        xrt_ngay14.DataBindings.Add("Text", DataSource, "Ngay14");
        xrt_ngay15.DataBindings.Add("Text", DataSource, "Ngay15");
        xrt_ngay16.DataBindings.Add("Text", DataSource, "Ngay16");
        xrt_ngay17.DataBindings.Add("Text", DataSource, "Ngay17");
        xrt_ngay18.DataBindings.Add("Text", DataSource, "Ngay18");
        xrt_ngay19.DataBindings.Add("Text", DataSource, "Ngay19");
        xrt_ngay20.DataBindings.Add("Text", DataSource, "Ngay20");
        xrt_ngay21.DataBindings.Add("Text", DataSource, "Ngay21");
        xrt_ngay22.DataBindings.Add("Text", DataSource, "Ngay22");
        xrt_ngay23.DataBindings.Add("Text", DataSource, "Ngay23");
        xrt_ngay24.DataBindings.Add("Text", DataSource, "Ngay24");
        xrt_ngay25.DataBindings.Add("Text", DataSource, "Ngay25");
        xrt_ngay26.DataBindings.Add("Text", DataSource, "Ngay26");
        xrt_ngay27.DataBindings.Add("Text", DataSource, "Ngay27");
        xrt_ngay28.DataBindings.Add("Text", DataSource, "Ngay28");
        xrt_ngay29.DataBindings.Add("Text", DataSource, "Ngay29");
        xrt_ngay30.DataBindings.Add("Text", DataSource, "Ngay30");
        xrt_ngay31.DataBindings.Add("Text", DataSource, "Ngay31");
        xrt_ngay31.DataBindings.Add("Text", DataSource, "Ngay31");
        xrtSoNgayThuong.DataBindings.Add("Text", DataSource, "SoNgayThuong");
        xrtSoGioThuong.DataBindings.Add("Text", DataSource, "SoGioThuong");
        xrtSoNgayNghi.DataBindings.Add("Text", DataSource, "SoNgayNghi");
        xrtSoGioNghi.DataBindings.Add("Text", DataSource, "SoGioNghi");
        xrtSoNgayLe.DataBindings.Add("Text", DataSource, "SoNgayLe");
        xrtSoGioLe.DataBindings.Add("Text", DataSource, "SoNgayLe");
        xrtTongNgay.DataBindings.Add("Text", DataSource, "TongNgay");
        xrtTongGio.DataBindings.Add("Text", DataSource, "TongGio");



        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        grpBoPhan.DataBindings.Add("Text", DataSource, "TEN_DONVI").ToString().ToUpper();
        //DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        //this.cong_luyke.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        //    new DevExpress.XtraReports.UI.XRBinding("Text", null, "LuyKeTuDauNam")});
        //// xrSummary2.FormatString = "{0:0,0}";
        //xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        //this.cong_luyke.Summary = xrSummary2;

        //DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        //this.cong_nghitaigiadinh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        //    new DevExpress.XtraReports.UI.XRBinding("Text", null, "TaiGia")});
        //xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        //this.cong_nghitaigiadinh.Summary = xrSummary3;

        //DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        //this.cong_sotien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        //    new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoTienDeNghi")});
        //xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        //xrSummary4.FormatString = "{0:n0}";
        //this.cong_sotien.Summary = xrSummary4;
        //DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        //this.cong_nghitaptrung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        //    new DevExpress.XtraReports.UI.XRBinding("Text", null, "TapTrung")});
        //xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        //this.cong_nghitaptrung.Summary = xrSummary5;


        //if (!string.IsNullOrEmpty(rp.TenBaoCao))
        //{
        //    xrl_tieudebaocao.Text = rp.TenBaoCao.ToUpper();
        //}
        //if (!string.IsNullOrEmpty(rp.TenDonVi))
        //{
        //    xrltendonvi.Text = rp.TenDonVi.ToUpper();
        //}
        //if (!string.IsNullOrEmpty(rp.MaDonVi))
        //{
        //    xrl_madonvi.Text = rp.MaDonVi;
        //}
        //if (!string.IsNullOrEmpty(rp.Ten1))
        //{
        //    xrttieude1.Text = rp.Ten1;
        //}
        //if (!string.IsNullOrEmpty(rp.Ten2))
        //{
        //    xrttieude2.Text = rp.Ten2;
        //}
        //if (!string.IsNullOrEmpty(rp.Ten3))
        //{
        //    xrttieude3.Text = rp.Ten3;
        //}
        //if (!string.IsNullOrEmpty(rp.Ten4))
        //{
        //    xrttieude4.Text = rp.Ten4;
        //}
        if (!string.IsNullOrEmpty(rp.Ten1))  xrl_ten1.Text = rp.Ten1;
        if (!string.IsNullOrEmpty(rp.Ten2)) xrl_ten1.Text = rp.Ten2;
        if (!string.IsNullOrEmpty(rp.Ten3)) xrl_ten1.Text = rp.Ten3; 

        if (rp.Footer1 != "") xrl_footer1.Text = rp.Footer1;
        if (!string.IsNullOrEmpty(rp.Footer2)) xrl_footer2.Text = rp.Footer2; 
        if (!string.IsNullOrEmpty(rp.Footer3))  xrl_footer3.Text = rp.Footer3; 
        xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //#endregion

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
            string resourceFileName = "rp_BaoCaoTongHopLamThemGio.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macanbo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngay31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoNgayThuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoGioThuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoNgayNghi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoGioNghi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoNgayLe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtSoGioLe = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongNgay = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongGio = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.grpBoPhan = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.Detail.HeightF = 25F;
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
            this.xrTable4.SizeF = new System.Drawing.SizeF(2313F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_macanbo,
            this.xrt_hovaten,
            this.xrt_ngay1,
            this.xrt_ngay2,
            this.xrt_ngay3,
            this.xrt_ngay4,
            this.xrt_ngay5,
            this.xrt_ngay6,
            this.xrt_ngay7,
            this.xrt_ngay8,
            this.xrt_ngay9,
            this.xrt_ngay10,
            this.xrt_ngay11,
            this.xrt_ngay12,
            this.xrt_ngay13,
            this.xrt_ngay14,
            this.xrt_ngay15,
            this.xrt_ngay16,
            this.xrt_ngay17,
            this.xrt_ngay18,
            this.xrt_ngay19,
            this.xrt_ngay20,
            this.xrt_ngay21,
            this.xrt_ngay22,
            this.xrt_ngay23,
            this.xrt_ngay24,
            this.xrt_ngay25,
            this.xrt_ngay26,
            this.xrt_ngay27,
            this.xrt_ngay28,
            this.xrt_ngay29,
            this.xrt_ngay30,
            this.xrt_ngay31,
            this.xrtSoNgayThuong,
            this.xrtSoGioThuong,
            this.xrtSoNgayNghi,
            this.xrtSoGioNghi,
            this.xrtSoNgayLe,
            this.xrtSoGioLe,
            this.xrtTongNgay,
            this.xrtTongGio,
            this.xrTableCell47});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Weight = 0.058781112985143436D;
            this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrt_macanbo
            // 
            this.xrt_macanbo.Name = "xrt_macanbo";
            this.xrt_macanbo.Weight = 0.14565284247394539D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hovaten.StylePriority.UsePadding = false;
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.24120369222982707D;
            // 
            // xrt_ngay1
            // 
            this.xrt_ngay1.Name = "xrt_ngay1";
            this.xrt_ngay1.StylePriority.UseTextAlignment = false;
            this.xrt_ngay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay1.Weight = 0.082770275754071809D;
            // 
            // xrt_ngay2
            // 
            this.xrt_ngay2.Name = "xrt_ngay2";
            this.xrt_ngay2.StylePriority.UseTextAlignment = false;
            this.xrt_ngay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay2.Weight = 0.0798989295396677D;
            // 
            // xrt_ngay3
            // 
            this.xrt_ngay3.Name = "xrt_ngay3";
            this.xrt_ngay3.StylePriority.UseTextAlignment = false;
            this.xrt_ngay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay3.Weight = 0.080278554199972429D;
            // 
            // xrt_ngay4
            // 
            this.xrt_ngay4.Name = "xrt_ngay4";
            this.xrt_ngay4.StylePriority.UseTextAlignment = false;
            this.xrt_ngay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay4.Weight = 0.085747475490194125D;
            // 
            // xrt_ngay5
            // 
            this.xrt_ngay5.Name = "xrt_ngay5";
            this.xrt_ngay5.StylePriority.UseTextAlignment = false;
            this.xrt_ngay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay5.Weight = 0.077639261387557057D;
            // 
            // xrt_ngay6
            // 
            this.xrt_ngay6.Name = "xrt_ngay6";
            this.xrt_ngay6.StylePriority.UseTextAlignment = false;
            this.xrt_ngay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay6.Weight = 0.077639257985259447D;
            // 
            // xrt_ngay7
            // 
            this.xrt_ngay7.Name = "xrt_ngay7";
            this.xrt_ngay7.StylePriority.UseTextAlignment = false;
            this.xrt_ngay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay7.Weight = 0.0735854198701052D;
            // 
            // xrt_ngay8
            // 
            this.xrt_ngay8.Name = "xrt_ngay8";
            this.xrt_ngay8.StylePriority.UseTextAlignment = false;
            this.xrt_ngay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay8.Weight = 0.070143461712680155D;
            // 
            // xrt_ngay9
            // 
            this.xrt_ngay9.Name = "xrt_ngay9";
            this.xrt_ngay9.StylePriority.UseTextAlignment = false;
            this.xrt_ngay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay9.Weight = 0.077871437697548562D;
            // 
            // xrt_ngay10
            // 
            this.xrt_ngay10.Name = "xrt_ngay10";
            this.xrt_ngay10.StylePriority.UseTextAlignment = false;
            this.xrt_ngay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay10.Weight = 0.07136825111314643D;
            // 
            // xrt_ngay11
            // 
            this.xrt_ngay11.Name = "xrt_ngay11";
            this.xrt_ngay11.StylePriority.UseTextAlignment = false;
            this.xrt_ngay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay11.Weight = 0.086360020316811115D;
            // 
            // xrt_ngay12
            // 
            this.xrt_ngay12.Name = "xrt_ngay12";
            this.xrt_ngay12.StylePriority.UseTextAlignment = false;
            this.xrt_ngay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay12.Weight = 0.088386613705877137D;
            // 
            // xrt_ngay13
            // 
            this.xrt_ngay13.Name = "xrt_ngay13";
            this.xrt_ngay13.StylePriority.UseTextAlignment = false;
            this.xrt_ngay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay13.Weight = 0.079898399117114383D;
            // 
            // xrt_ngay14
            // 
            this.xrt_ngay14.Name = "xrt_ngay14";
            this.xrt_ngay14.StylePriority.UseTextAlignment = false;
            this.xrt_ngay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay14.Weight = 0.074197979759380139D;
            // 
            // xrt_ngay15
            // 
            this.xrt_ngay15.Name = "xrt_ngay15";
            this.xrt_ngay15.StylePriority.UseTextAlignment = false;
            this.xrt_ngay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay15.Weight = 0.07500847409393957D;
            // 
            // xrt_ngay16
            // 
            this.xrt_ngay16.Name = "xrt_ngay16";
            this.xrt_ngay16.StylePriority.UseTextAlignment = false;
            this.xrt_ngay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay16.Weight = 0.080679795091088177D;
            // 
            // xrt_ngay17
            // 
            this.xrt_ngay17.Name = "xrt_ngay17";
            this.xrt_ngay17.StylePriority.UseTextAlignment = false;
            this.xrt_ngay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay17.Weight = 0.072572122319409807D;
            // 
            // xrt_ngay18
            // 
            this.xrt_ngay18.Name = "xrt_ngay18";
            this.xrt_ngay18.StylePriority.UseTextAlignment = false;
            this.xrt_ngay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay18.Weight = 0.068107753564204815D;
            // 
            // xrt_ngay19
            // 
            this.xrt_ngay19.Name = "xrt_ngay19";
            this.xrt_ngay19.StylePriority.UseTextAlignment = false;
            this.xrt_ngay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay19.Weight = 0.068517632706504739D;
            // 
            // xrt_ngay20
            // 
            this.xrt_ngay20.Name = "xrt_ngay20";
            this.xrt_ngay20.StylePriority.UseTextAlignment = false;
            this.xrt_ngay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay20.Weight = 0.0836912368865513D;
            // 
            // xrt_ngay21
            // 
            this.xrt_ngay21.Name = "xrt_ngay21";
            this.xrt_ngay21.StylePriority.UseTextAlignment = false;
            this.xrt_ngay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay21.Weight = 0.079505406184158744D;
            // 
            // xrt_ngay22
            // 
            this.xrt_ngay22.Name = "xrt_ngay22";
            this.xrt_ngay22.StylePriority.UseTextAlignment = false;
            this.xrt_ngay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay22.Weight = 0.076435637970746428D;
            // 
            // xrt_ngay23
            // 
            this.xrt_ngay23.Name = "xrt_ngay23";
            this.xrt_ngay23.StylePriority.UseTextAlignment = false;
            this.xrt_ngay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay23.Weight = 0.080490241448222144D;
            // 
            // xrt_ngay24
            // 
            this.xrt_ngay24.Name = "xrt_ngay24";
            this.xrt_ngay24.StylePriority.UseTextAlignment = false;
            this.xrt_ngay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay24.Weight = 0.08049006081714688D;
            // 
            // xrt_ngay25
            // 
            this.xrt_ngay25.Name = "xrt_ngay25";
            this.xrt_ngay25.StylePriority.UseTextAlignment = false;
            this.xrt_ngay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay25.Weight = 0.086570843893735261D;
            // 
            // xrt_ngay26
            // 
            this.xrt_ngay26.Name = "xrt_ngay26";
            this.xrt_ngay26.StylePriority.UseTextAlignment = false;
            this.xrt_ngay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay26.Weight = 0.078463051676006951D;
            // 
            // xrt_ngay27
            // 
            this.xrt_ngay27.Name = "xrt_ngay27";
            this.xrt_ngay27.StylePriority.UseTextAlignment = false;
            this.xrt_ngay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay27.Weight = 0.082812212165618709D;
            // 
            // xrt_ngay28
            // 
            this.xrt_ngay28.Name = "xrt_ngay28";
            this.xrt_ngay28.StylePriority.UseTextAlignment = false;
            this.xrt_ngay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay28.Weight = 0.074704420411840028D;
            // 
            // xrt_ngay29
            // 
            this.xrt_ngay29.Name = "xrt_ngay29";
            this.xrt_ngay29.StylePriority.UseTextAlignment = false;
            this.xrt_ngay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay29.Weight = 0.087880175538689362D;
            // 
            // xrt_ngay30
            // 
            this.xrt_ngay30.Name = "xrt_ngay30";
            this.xrt_ngay30.StylePriority.UseTextAlignment = false;
            this.xrt_ngay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay30.Weight = 0.076405133627269223D;
            // 
            // xrt_ngay31
            // 
            this.xrt_ngay31.Name = "xrt_ngay31";
            this.xrt_ngay31.StylePriority.UseTextAlignment = false;
            this.xrt_ngay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ngay31.Weight = 0.0931963855687501D;
            // 
            // xrtSoNgayThuong
            // 
            this.xrtSoNgayThuong.Name = "xrtSoNgayThuong";
            this.xrtSoNgayThuong.StylePriority.UseTextAlignment = false;
            this.xrtSoNgayThuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoNgayThuong.Weight = 0.16542489566725893D;
            // 
            // xrtSoGioThuong
            // 
            this.xrtSoGioThuong.Name = "xrtSoGioThuong";
            this.xrtSoGioThuong.StylePriority.UseTextAlignment = false;
            this.xrtSoGioThuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoGioThuong.Weight = 0.19380382534343146D;
            // 
            // xrtSoNgayNghi
            // 
            this.xrtSoNgayNghi.Name = "xrtSoNgayNghi";
            this.xrtSoNgayNghi.StylePriority.UseTextAlignment = false;
            this.xrtSoNgayNghi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoNgayNghi.Weight = 0.17758657749130674D;
            // 
            // xrtSoGioNghi
            // 
            this.xrtSoGioNghi.Name = "xrtSoGioNghi";
            this.xrtSoGioNghi.StylePriority.UseTextAlignment = false;
            this.xrtSoGioNghi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoGioNghi.Weight = 0.19988466625545542D;
            // 
            // xrtSoNgayLe
            // 
            this.xrtSoNgayLe.Name = "xrtSoNgayLe";
            this.xrtSoNgayLe.StylePriority.UseTextAlignment = false;
            this.xrtSoNgayLe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoNgayLe.Weight = 0.17150644502500684D;
            // 
            // xrtSoGioLe
            // 
            this.xrtSoGioLe.Name = "xrtSoGioLe";
            this.xrtSoGioLe.StylePriority.UseTextAlignment = false;
            this.xrtSoGioLe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtSoGioLe.Weight = 0.17635135623817197D;
            // 
            // xrtTongNgay
            // 
            this.xrtTongNgay.Name = "xrtTongNgay";
            this.xrtTongNgay.StylePriority.UseTextAlignment = false;
            this.xrtTongNgay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtTongNgay.Weight = 0.17899619585875004D;
            // 
            // xrtTongGio
            // 
            this.xrtTongGio.Name = "xrtTongGio";
            this.xrtTongGio.StylePriority.UseTextAlignment = false;
            this.xrtTongGio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtTongGio.Weight = 0.17899619585875004D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Weight = 0.16146936472945569D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
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
            this.xrl_TitleBC,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 109F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 61.45833F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(2313F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO TỔNG HỢP LÀM THÊM GIỜ";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(1016.667F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(1016.667F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrl_ten2,
            this.xrl_footer1,
            this.xrl_ten1,
            this.xrl_footer2,
            this.xrl_footer3,
            this.xrtngayketxuat});
            this.ReportFooter.HeightF = 183F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1912F, 125F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(1000F, 125F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 25F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 125F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(1000F, 25F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "PHÒNG TCHC";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1912.5F, 50F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(281.9166F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1912.5F, 25F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(282.4167F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Ngày 15 tháng 4 năm 2013";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2186.958F, 38.54167F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 86F;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(2313F, 86F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell10,
            this.xrTableCell6,
            this.xrTableCell37});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.30318265215335827D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Mã CBNV";
            this.xrTableCell2.Weight = 0.75125255155728354D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ và tên";
            this.xrTableCell4.Weight = 1.2440878739338379D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable5});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Weight = 12.643466251279207D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.5417F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1259.704F, 47.4583F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell11,
            this.xrTableCell26,
            this.xrTableCell9,
            this.xrTableCell27,
            this.xrTableCell12,
            this.xrTableCell3,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell15,
            this.xrTableCell25,
            this.xrTableCell16,
            this.xrTableCell23,
            this.xrTableCell5,
            this.xrTableCell24,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell17,
            this.xrTableCell22,
            this.xrTableCell20,
            this.xrTableCell33,
            this.xrTableCell21,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.Text = "Ngày \r\n1";
            this.xrTableCell7.Weight = 0.10479044600522924D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Ngày 2";
            this.xrTableCell8.Weight = 0.10115489529511706D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Ngày 3";
            this.xrTableCell11.Weight = 0.10163600533799619D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Multiline = true;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Text = "Ngày\r\n4";
            this.xrTableCell26.Weight = 0.10855957208540432D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Ngày 5";
            this.xrTableCell9.Weight = 0.09829450652355487D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Multiline = true;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Text = "Ngày\r\n6";
            this.xrTableCell27.Weight = 0.098294337358525413D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Ngày \r\n7";
            this.xrTableCell12.Weight = 0.093162039529030544D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Ngày \r\n8";
            this.xrTableCell3.Weight = 0.088804574706083855D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Multiline = true;
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "Ngày\r\n9";
            this.xrTableCell28.Weight = 0.098588445642539421D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Multiline = true;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "Ngày\r\n10";
            this.xrTableCell29.Weight = 0.090354879787069589D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Multiline = true;
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Text = "Ngày\r\n11";
            this.xrTableCell30.Weight = 0.10933504415984177D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "Ngày 12";
            this.xrTableCell13.Weight = 0.11190108969596008D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Ngày 13";
            this.xrTableCell14.Weight = 0.10115482011065949D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Multiline = true;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "Ngày \r\n14";
            this.xrTableCell31.Weight = 0.093937264904466633D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Multiline = true;
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "Ngày\r\n15";
            this.xrTableCell32.Weight = 0.094963683510499677D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Ngày \r\n16";
            this.xrTableCell15.Weight = 0.10214394957526296D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Multiline = true;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Text = "Ngày \r\n17";
            this.xrTableCell25.Weight = 0.091878931003699482D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Ngày \r\n18";
            this.xrTableCell16.Weight = 0.0862272495434048D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Text = "Ngày\r\n19";
            this.xrTableCell23.Weight = 0.08674617736843071D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Ngày\r\n20";
            this.xrTableCell5.Weight = 0.10727664682218856D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Multiline = true;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "Ngày\r\n21";
            this.xrTableCell24.Weight = 0.099336715823601623D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "Ngày\r\n22";
            this.xrTableCell18.Weight = 0.0967708206563984D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "Ngày\r\n23";
            this.xrTableCell19.Weight = 0.10190353858469049D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Ngày\r\n24";
            this.xrTableCell17.Weight = 0.10190323602992302D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "Ngày\r\n25";
            this.xrTableCell22.Weight = 0.10960212602641842D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Multiline = true;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "Ngày\r\n26";
            this.xrTableCell20.Weight = 0.099337340348278513D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Multiline = true;
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Text = "Ngày\r\n27";
            this.xrTableCell33.Weight = 0.10484382919431118D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Multiline = true;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "Ngày\r\n28";
            this.xrTableCell21.Weight = 0.094578761574398928D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Multiline = true;
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Text = "Ngày\r\n29";
            this.xrTableCell34.Weight = 0.11125953639850739D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Multiline = true;
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Text = "Ngày\r\n30";
            this.xrTableCell35.Weight = 0.0967322171680435D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Multiline = true;
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Text = "Ngày\r\n31";
            this.xrTableCell36.Weight = 0.11799047643297604D;
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(1259.704F, 38.5417F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell48});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.StylePriority.UseBorders = false;
            this.xrTableCell48.Text = "NGÀY TRONG THÁNG";
            this.xrTableCell48.Weight = 3D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7,
            this.xrTable3});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.Weight = 7.4404252809574292D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(741.3104F, 38.5417F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.Text = "NGÀY TRONG THÁNG";
            this.xrTableCell49.Weight = 3D;
            // 
            // xrTable7
            // 
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.5417F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable7.SizeF = new System.Drawing.SizeF(741.2499F, 25F);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell50,
            this.xrTableCell51});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.Text = "Ngày thường";
            this.xrTableCell45.Weight = 0.74688564204219166D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Text = "Ngày nghỉ";
            this.xrTableCell46.Weight = 0.78507237103320837D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Text = "Ngày lễ";
            this.xrTableCell50.Weight = 0.72348128038069148D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Text = "Tổng cộng";
            this.xrTableCell51.Weight = 0.74456070654390849D;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 63.5417F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(741.3105F, 23.00001F);
            this.xrTable3.StylePriority.UseBorders = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell38,
            this.xrTableCell42,
            this.xrTableCell39,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell52,
            this.xrTableCell40});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.Text = "Số ngày";
            this.xrTableCell41.Weight = 0.34402596859940571D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "Số giờ";
            this.xrTableCell38.Weight = 0.40304423278166718D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Text = "Số ngày";
            this.xrTableCell42.Weight = 0.36931852238212431D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Text = "Số giờ";
            this.xrTableCell39.Weight = 0.41568976866576696D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Text = "Số ngày";
            this.xrTableCell43.Weight = 0.35667298649802448D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Text = "Số giờ";
            this.xrTableCell44.Weight = 0.36674918262782585D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Text = "Số ngày";
            this.xrTableCell52.Weight = 0.37224966922259284D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "Số giờ";
            this.xrTableCell40.Weight = 0.37224966922259284D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Text = "Chữ ký";
            this.xrTableCell37.Weight = 0.83283109036458169D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
            this.GroupHeader1.HeightF = 25.41666F;
            this.GroupHeader1.Name = "GroupHeader1";
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
            this.xrTable8.SizeF = new System.Drawing.SizeF(2313F, 25.41666F);
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
            // rp_BaoCaoTongHopLamThemGio
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter,
            this.PageHeader,
            this.GroupHeader1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 50, 0);
            this.PageHeight = 1654;
            this.PageWidth = 2339;
            this.PaperKind = System.Drawing.Printing.PaperKind.A2;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

  
}
