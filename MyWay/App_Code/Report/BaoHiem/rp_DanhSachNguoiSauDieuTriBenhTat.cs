using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_DanhSachNguoiSauDieuTriBenhTat
/// </summary>
public class rp_DanhSachNguoiSauDieuTriBenhTat : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private ReportHeaderBand ReportHeader;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrl_tieudebaocao;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrl_madonvi;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrltendonvi;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell22;
    private XRTable xrTable11;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell30;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell29;
    private XRTable xrTable12;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell28;
    private XRTable xrTable13;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell23;
    private XRTable xrTable14;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell39;
    private XRTable xrTable15;
    private XRTableRow xrTableRow16;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hoten;
    private XRTableCell xrt_sobhxh;
    private XRTableCell xrt_mucdosuygiam;
    private XRTableCell xrt_nghitaigiadinh;
    private XRTableCell xrt_nghitaptrung;
    private XRTableCell xrt_sotientrocap;
    private XRTableCell xrt_ghichu;
    private GroupFooterBand GroupFooter1;
    private XRTable xrTable16;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell cong_sobhxh;
    private XRTableCell cong_mucdosuygiam;
    private XRTableCell cong_taigiadinh;
    private XRTableCell cong_nghitaptrung;
    private XRTableCell cong_sotientrocap;
    private XRTableCell cong_ghichu;
    private XRLabel xrl_ngayketxuat;
    private XRTable xrTable20;
    private XRTableRow xrTableRow23;
    private XRTableCell xrttieude3;
    private XRTableRow xrTableRow24;
    private XRTableCell xrTableCell48;
    private XRTable xrTable19;
    private XRTableRow xrTableRow21;
    private XRTableCell xrttieude2;
    private XRTableRow xrTableRow22;
    private XRTableCell xrTableCell46;
    private XRTable xrTable21;
    private XRTableRow xrTableRow25;
    private XRTableCell xrttieude4;
    private XRTableRow xrTableRow26;
    private XRTableCell xrTableCell50;
    private XRTable xrTable24;
    private XRTableRow xrTableRow29;
    private XRTableCell xrt_chuky4;
    private XRTable xrTable23;
    private XRTableRow xrTableRow28;
    private XRTableCell xrt_chuky3;
    private XRTable xrTable22;
    private XRTableRow xrTableRow27;
    private XRTableCell xrt_chuky2;
    private XRTable xrTable18;
    private XRTableRow xrTableRow20;
    private XRTableCell xrt_chuky1;
    private XRLabel xrLabel1;
    private XRTable xrTable17;
    private XRTableRow xrTableRow19;
    private XRTableCell xrttieude1;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell43;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell12;
    private XRTableCell xrt_tonglaodong;
    private XRTableCell xrTableCell14;
    private XRTableCell xrt_trongdonu;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell10;
    private XRTableCell xrl_sotaikhoan;
    private XRTableCell xrTableCell11;
    private XRTableCell xrt_motai;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrt_tongquy;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell19;
    private XRTableCell xrt_sochungtu;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrl_quynam;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DanhSachNguoiSauDieuTriBenhTat()
    {
        InitializeComponent();
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrt_stt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        // xử lý  phần header
        BHDauPhieuController bh = new BHDauPhieuController();
        xrltendonvi.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        xrl_madonvi.Text = filter.SessionDepartment;
        int id = 0;
        DAL.BHDAUPHIEU bhdp = null;
        try
        {
            if (!int.TryParse(filter.WhereClause, out id) && filter.WhereClause != "1 = 1")
            {
                filter.WhereClause = filter.WhereClause.Substring(17);
                filter.WhereClause = filter.WhereClause.Substring(0, filter.WhereClause.LastIndexOf("'"));
                int.TryParse(filter.WhereClause, out id);
                //  (IDDauPhieu = N '103')
            }
            bhdp = bh.GetByIdDauPhieu(id);
        }
        catch (Exception)
        {

        }
        DataTable dt = new DataTable();

       // var bhdp = bh.GetByIdDauPhieu(Convert.ToInt32("0" + filter.WhereClause));
        if (bhdp != null)
        {
            string Ngay = new BHDauPhieuController().GetQuy(bhdp.TuNgay, bhdp.DenNgay);
            if (Ngay == "Quý 1" || Ngay == "Quý 2" || Ngay == "Quý 3" || Ngay == "Quý 4")
            {
                xrl_quynam.Text = Ngay + " năm " + bhdp.DenNgay.Year;
            }
            else
            {
                xrl_quynam.Text = "Tháng " + Ngay + " năm " + bhdp.DenNgay.Year;
            }
            if (!string.IsNullOrEmpty(bhdp.SoTaiKhoan))
            {
                xrl_sotaikhoan.Text = " " + bhdp.SoTaiKhoan;
            }
            if (!string.IsNullOrEmpty(bhdp.MoTaiNganHang))
            {
                xrt_motai.Text = " " + bhdp.MoTaiNganHang;
            }
            if (!string.IsNullOrEmpty(bhdp.SoLaoDongNu.ToString()))
            {
                xrt_trongdonu.Text = " " + bhdp.SoLaoDongNu.ToString();
            }
            if (!string.IsNullOrEmpty(bhdp.TongSoLaoDong.ToString()))
            {
                xrt_tonglaodong.Text = " " + bhdp.TongSoLaoDong.ToString();
            }
            if (!string.IsNullOrEmpty(bhdp.TongQuyLuongTrongQuy.ToString()))
            {
                xrt_tongquy.Text = " " + bhdp.TongQuyLuongTrongQuy.ToString();
            }
            if (!string.IsNullOrEmpty(bhdp.So))
            {
                xrt_sochungtu.Text = " " + bhdp.So.ToString();
            }

            //xử lý phần detail
            dt = DataHandler.GetInstance().ExecuteDataTable("sp_BHC70aHD", "@NgayBatDau", "@NgayKetThuc", bhdp.TuNgay, bhdp.DenNgay);
        }
        else if (filter.StartDate != null && filter.EndDate != null)
        {
            dt = DataHandler.GetInstance().ExecuteDataTable("sp_BHC70aHD", "@NgayBatDau", "@NgayKetThuc", filter.StartDate, filter.EndDate);
        }
        DataSource = dt;
        xrt_hoten.DataBindings.Add("Text", DataSource, "HoTen");
        xrt_sobhxh.DataBindings.Add("Text", DataSource, "SoSoBHXH", "{0:n0}");
        xrt_mucdosuygiam.DataBindings.Add("Text", DataSource, "MucDoSuyGiamKNLD");

        xrt_nghitaigiadinh.DataBindings.Add("Text", DataSource, "TaiGia");
        xrt_nghitaptrung.DataBindings.Add("Text", DataSource, "TapTrung");
        // xrt_luykedaunam.DataBindings.Add("Text", DataSource, "LuyKeTuDauNam");
        xrt_sotientrocap.DataBindings.Add("Text", DataSource, "SoTienDeNghi", "{0:n0}");
        xrt_ghichu.DataBindings.Add("Text", DataSource, "GhiChu");

        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_taigiadinh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TaiGia")});
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_taigiadinh.Summary = xrSummary3;

        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_nghitaptrung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TapTrung")});
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_nghitaptrung.Summary = xrSummary4;
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_sotientrocap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoTienDeNghi")});
        xrSummary5.FormatString = "{0:n0}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_sotientrocap.Summary = xrSummary5;

        if (!string.IsNullOrEmpty(filter.ReportTitle))
        {
            xrl_tieudebaocao.Text = filter.ReportTitle.ToUpper();
        }
        xrltendonvi.Text = ReportController.GetInstance().GetCompanyName(filter.SessionDepartment);
        if (!string.IsNullOrEmpty(filter.SessionDepartment))
        {
            xrl_madonvi.Text = filter.SessionDepartment;
        }
        if (!string.IsNullOrEmpty(filter.Title1))
        {
            xrttieude1.Text = filter.Title1;
        }
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrttieude2.Text = filter.Title2;
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrttieude3.Text = filter.Title3;
        }
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrt_chuky1.Text = filter.Name1;
        }
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrt_chuky2.Text = filter.Name2;
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrt_chuky3.Text = filter.Name3;
        }
        if (filter.ReportedDate != null)
        {
            xrl_ngayketxuat.Text = ReportController.GetInstance().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        }
        else
        {
            xrl_ngayketxuat.Text = ReportController.GetInstance().GetFooterReport(filter.SessionDepartment, DateTime.Now);
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
        string resourceFileName = "rp_DanhSachNguoiSauDieuTriBenhTat.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sobhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_mucdosuygiam = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_nghitaigiadinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_nghitaptrung = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sotientrocap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable20 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable19 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable21 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable24 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow29 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable23 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable22 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tonglaodong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_trongdonu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_sotaikhoan = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_motai = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tongquy = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sochungtu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrl_quynam = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrl_tieudebaocao = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_madonvi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrltendonvi = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_sobhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_mucdosuygiam = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_taigiadinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_nghitaptrung = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_sotientrocap = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable15});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable15
        // 
        this.xrTable15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable15.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable15.Name = "xrTable15";
        this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
        this.xrTable15.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable15.StylePriority.UseBorders = false;
        this.xrTable15.StylePriority.UseFont = false;
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hoten,
            this.xrt_sobhxh,
            this.xrt_mucdosuygiam,
            this.xrt_nghitaigiadinh,
            this.xrt_nghitaptrung,
            this.xrt_sotientrocap,
            this.xrt_ghichu});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrt_stt
        // 
        this.xrt_stt.Name = "xrt_stt";
        this.xrt_stt.StylePriority.UseTextAlignment = false;
        this.xrt_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_stt.Weight = 0.10043207922647165D;
        this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrt_hoten
        // 
        this.xrt_hoten.Name = "xrt_hoten";
        this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hoten.StylePriority.UsePadding = false;
        this.xrt_hoten.StylePriority.UseTextAlignment = false;
        this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hoten.Weight = 0.40496747393940768D;
        // 
        // xrt_sobhxh
        // 
        this.xrt_sobhxh.Name = "xrt_sobhxh";
        this.xrt_sobhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_sobhxh.StylePriority.UsePadding = false;
        this.xrt_sobhxh.StylePriority.UseTextAlignment = false;
        this.xrt_sobhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_sobhxh.Weight = 0.1943845491631086D;
        // 
        // xrt_mucdosuygiam
        // 
        this.xrt_mucdosuygiam.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_mucdosuygiam.Name = "xrt_mucdosuygiam";
        this.xrt_mucdosuygiam.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_mucdosuygiam.StylePriority.UseBorders = false;
        this.xrt_mucdosuygiam.StylePriority.UsePadding = false;
        this.xrt_mucdosuygiam.StylePriority.UseTextAlignment = false;
        this.xrt_mucdosuygiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_mucdosuygiam.Weight = 0.53455725736396253D;
        // 
        // xrt_nghitaigiadinh
        // 
        this.xrt_nghitaigiadinh.Name = "xrt_nghitaigiadinh";
        this.xrt_nghitaigiadinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_nghitaigiadinh.StylePriority.UsePadding = false;
        this.xrt_nghitaigiadinh.StylePriority.UseTextAlignment = false;
        this.xrt_nghitaigiadinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_nghitaigiadinh.Weight = 0.31395382548487472D;
        // 
        // xrt_nghitaptrung
        // 
        this.xrt_nghitaptrung.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_nghitaptrung.Name = "xrt_nghitaptrung";
        this.xrt_nghitaptrung.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_nghitaptrung.StylePriority.UseBorders = false;
        this.xrt_nghitaptrung.StylePriority.UsePadding = false;
        this.xrt_nghitaptrung.StylePriority.UseTextAlignment = false;
        this.xrt_nghitaptrung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_nghitaptrung.Weight = 0.31395297560580943D;
        // 
        // xrt_sotientrocap
        // 
        this.xrt_sotientrocap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_sotientrocap.Name = "xrt_sotientrocap";
        this.xrt_sotientrocap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_sotientrocap.StylePriority.UseBorders = false;
        this.xrt_sotientrocap.StylePriority.UsePadding = false;
        this.xrt_sotientrocap.StylePriority.UseTextAlignment = false;
        this.xrt_sotientrocap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_sotientrocap.Weight = 0.379030532836914D;
        // 
        // xrt_ghichu
        // 
        this.xrt_ghichu.Name = "xrt_ghichu";
        this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_ghichu.StylePriority.UsePadding = false;
        this.xrt_ghichu.StylePriority.UseTextAlignment = false;
        this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_ghichu.Weight = 0.75872130637945134D;
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
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable14,
            this.xrTable10});
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.StylePriority.UseTextAlignment = false;
        this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable14
        // 
        this.xrTable14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
        this.xrTable14.Name = "xrTable14";
        this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
        this.xrTable14.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable14.StylePriority.UseBorders = false;
        this.xrTable14.StylePriority.UseFont = false;
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36,
            this.xrTableCell33,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell26,
            this.xrTableCell34,
            this.xrTableCell39,
            this.xrTableCell35});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.Text = "A";
        this.xrTableCell36.Weight = 0.10043207922647161D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.Text = "B";
        this.xrTableCell33.Weight = 0.4049676016874092D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Text = "C";
        this.xrTableCell37.Weight = 0.19438450658044149D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.Text = "D";
        this.xrTableCell38.Weight = 0.53455725736396265D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.Text = "1";
        this.xrTableCell26.Weight = 0.31395370838253994D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.StylePriority.UseBorders = false;
        this.xrTableCell34.Text = "2";
        this.xrTableCell34.Weight = 0.31395349546920415D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseBorders = false;
        this.xrTableCell39.Text = "3";
        this.xrTableCell39.Weight = 0.37903022233829942D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseBorders = false;
        this.xrTableCell35.Text = "E";
        this.xrTableCell35.Weight = 0.75872112895167154D;
        // 
        // xrTable10
        // 
        this.xrTable10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable10.SizeF = new System.Drawing.SizeF(1075F, 75F);
        this.xrTable10.StylePriority.UseBorders = false;
        this.xrTable10.StylePriority.UseFont = false;
        this.xrTable10.StylePriority.UseTextAlignment = false;
        this.xrTable10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell27,
            this.xrTableCell22,
            this.xrTableCell23});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Text = "STT";
        this.xrTableCell21.Weight = 0.09011639262354651D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Text = "Họ và tên";
        this.xrTableCell24.Weight = 0.36337204334347745D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Text = "Số sổ BHXH";
        this.xrTableCell25.Weight = 0.1744186933650527D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseBorders = false;
        this.xrTableCell27.Text = "Mức độ suy giảm khả năng lao động do TNLĐ - BNN";
        this.xrTableCell27.Weight = 0.47965124352033756D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable11,
            this.xrTable12,
            this.xrTable13});
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Text = "xrTableCell22";
        this.xrTableCell22.Weight = 0.90351168724225639D;
        // 
        // xrTable11
        // 
        this.xrTable11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30.83334F);
        this.xrTable11.Name = "xrTable11";
        this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12,
            this.xrTableRow11});
        this.xrTable11.SizeF = new System.Drawing.SizeF(225.0001F, 42.91666F);
        this.xrTable11.StylePriority.UseFont = false;
        this.xrTable11.StylePriority.UseTextAlignment = false;
        this.xrTable11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell30});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.StylePriority.UseFont = false;
        this.xrTableCell30.Text = "Số ngày nghỉ trong kỳ";
        this.xrTableCell30.Weight = 3D;
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell31,
            this.xrTableCell29});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell31.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseBorders = false;
        this.xrTableCell31.StylePriority.UseFont = false;
        this.xrTableCell31.Text = "Nghỉ tại gia đình";
        this.xrTableCell31.Weight = 1.5D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseBorders = false;
        this.xrTableCell29.StylePriority.UseFont = false;
        this.xrTableCell29.Text = "Nghỉ tập trung";
        this.xrTableCell29.Weight = 1.5D;
        // 
        // xrTable12
        // 
        this.xrTable12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(225F, 30.83334F);
        this.xrTable12.Name = "xrTable12";
        this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
        this.xrTable12.SizeF = new System.Drawing.SizeF(135.8192F, 42.91666F);
        this.xrTable12.StylePriority.UseFont = false;
        this.xrTable12.StylePriority.UseTextAlignment = false;
        this.xrTable12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 2D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.StylePriority.UseFont = false;
        this.xrTableCell28.Text = "Số tiền trợ cấp";
        this.xrTableCell28.Weight = 3D;
        // 
        // xrTable13
        // 
        this.xrTable13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable13.Name = "xrTable13";
        this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
        this.xrTable13.SizeF = new System.Drawing.SizeF(360.8192F, 30.83334F);
        this.xrTable13.StylePriority.UseFont = false;
        this.xrTable13.StylePriority.UseTextAlignment = false;
        this.xrTable13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow14
        // 
        this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32});
        this.xrTableRow14.Name = "xrTableRow14";
        this.xrTableRow14.Weight = 1D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell32.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.StylePriority.UseFont = false;
        this.xrTableCell32.Text = "Số đơn vị đề nghị";
        this.xrTableCell32.Weight = 3D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Text = "Ghi chú";
        this.xrTableCell23.Weight = 0.68079063390344485D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ngayketxuat,
            this.xrTable20,
            this.xrTable19,
            this.xrTable21,
            this.xrTable24,
            this.xrTable23,
            this.xrTable22,
            this.xrTable18,
            this.xrLabel1,
            this.xrTable17});
        this.ReportFooter.HeightF = 274F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ngayketxuat
        // 
        this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(800F, 35.00001F);
        this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
        this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(269.7917F, 33.41667F);
        this.xrl_ngayketxuat.StylePriority.UseFont = false;
        this.xrl_ngayketxuat.Text = "Ngày...... tháng........ năm.......";
        // 
        // xrTable20
        // 
        this.xrTable20.LocationFloat = new DevExpress.Utils.PointFloat(600F, 97.50001F);
        this.xrTable20.Name = "xrTable20";
        this.xrTable20.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow23,
            this.xrTableRow24});
        this.xrTable20.SizeF = new System.Drawing.SizeF(162.4999F, 50.00001F);
        this.xrTable20.StylePriority.UseTextAlignment = false;
        this.xrTable20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow23
        // 
        this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrttieude3});
        this.xrTableRow23.Name = "xrTableRow23";
        this.xrTableRow23.Weight = 1D;
        // 
        // xrttieude3
        // 
        this.xrttieude3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrttieude3.Name = "xrttieude3";
        this.xrttieude3.StylePriority.UseFont = false;
        this.xrttieude3.Text = "Kế toán trưởng";
        this.xrttieude3.Weight = 3D;
        // 
        // xrTableRow24
        // 
        this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell48});
        this.xrTableRow24.Name = "xrTableRow24";
        this.xrTableRow24.Weight = 1D;
        // 
        // xrTableCell48
        // 
        this.xrTableCell48.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell48.Name = "xrTableCell48";
        this.xrTableCell48.StylePriority.UseFont = false;
        this.xrTableCell48.Text = "(Ký họ tên)";
        this.xrTableCell48.Weight = 3D;
        // 
        // xrTable19
        // 
        this.xrTable19.LocationFloat = new DevExpress.Utils.PointFloat(325F, 97.50001F);
        this.xrTable19.Name = "xrTable19";
        this.xrTable19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow21,
            this.xrTableRow22});
        this.xrTable19.SizeF = new System.Drawing.SizeF(162.4999F, 50.00001F);
        this.xrTable19.StylePriority.UseTextAlignment = false;
        this.xrTable19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow21
        // 
        this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrttieude2});
        this.xrTableRow21.Name = "xrTableRow21";
        this.xrTableRow21.Weight = 1D;
        // 
        // xrttieude2
        // 
        this.xrttieude2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrttieude2.Name = "xrttieude2";
        this.xrttieude2.StylePriority.UseFont = false;
        this.xrttieude2.Text = "Công đoàn công sở";
        this.xrttieude2.Weight = 3D;
        // 
        // xrTableRow22
        // 
        this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell46});
        this.xrTableRow22.Name = "xrTableRow22";
        this.xrTableRow22.Weight = 1D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.StylePriority.UseFont = false;
        this.xrTableCell46.Text = "(Ký, đóng dấu)";
        this.xrTableCell46.Weight = 3D;
        // 
        // xrTable21
        // 
        this.xrTable21.LocationFloat = new DevExpress.Utils.PointFloat(887.5F, 97.50001F);
        this.xrTable21.Name = "xrTable21";
        this.xrTable21.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow25,
            this.xrTableRow26});
        this.xrTable21.SizeF = new System.Drawing.SizeF(162.4999F, 50.00001F);
        this.xrTable21.StylePriority.UseTextAlignment = false;
        this.xrTable21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow25
        // 
        this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrttieude4});
        this.xrTableRow25.Name = "xrTableRow25";
        this.xrTableRow25.Weight = 1D;
        // 
        // xrttieude4
        // 
        this.xrttieude4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrttieude4.Name = "xrttieude4";
        this.xrttieude4.StylePriority.UseFont = false;
        this.xrttieude4.Text = "Người lập";
        this.xrttieude4.Weight = 3D;
        // 
        // xrTableRow26
        // 
        this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell50});
        this.xrTableRow26.Name = "xrTableRow26";
        this.xrTableRow26.Weight = 1D;
        // 
        // xrTableCell50
        // 
        this.xrTableCell50.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell50.Name = "xrTableCell50";
        this.xrTableCell50.StylePriority.UseFont = false;
        this.xrTableCell50.Text = "(Ký họ tên)";
        this.xrTableCell50.Weight = 3D;
        // 
        // xrTable24
        // 
        this.xrTable24.LocationFloat = new DevExpress.Utils.PointFloat(887.5F, 235F);
        this.xrTable24.Name = "xrTable24";
        this.xrTable24.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow29});
        this.xrTable24.SizeF = new System.Drawing.SizeF(162.4999F, 36.45833F);
        this.xrTable24.StylePriority.UseTextAlignment = false;
        this.xrTable24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow29
        // 
        this.xrTableRow29.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky4});
        this.xrTableRow29.Name = "xrTableRow29";
        this.xrTableRow29.Weight = 1D;
        // 
        // xrt_chuky4
        // 
        this.xrt_chuky4.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuky4.Name = "xrt_chuky4";
        this.xrt_chuky4.StylePriority.UseFont = false;
        this.xrt_chuky4.Weight = 3D;
        // 
        // xrTable23
        // 
        this.xrTable23.LocationFloat = new DevExpress.Utils.PointFloat(600F, 235F);
        this.xrTable23.Name = "xrTable23";
        this.xrTable23.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow28});
        this.xrTable23.SizeF = new System.Drawing.SizeF(162.4999F, 36.45833F);
        this.xrTable23.StylePriority.UseTextAlignment = false;
        this.xrTable23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow28
        // 
        this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky3});
        this.xrTableRow28.Name = "xrTableRow28";
        this.xrTableRow28.Weight = 1D;
        // 
        // xrt_chuky3
        // 
        this.xrt_chuky3.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuky3.Name = "xrt_chuky3";
        this.xrt_chuky3.StylePriority.UseFont = false;
        this.xrt_chuky3.Weight = 3D;
        // 
        // xrTable22
        // 
        this.xrTable22.LocationFloat = new DevExpress.Utils.PointFloat(325F, 235F);
        this.xrTable22.Name = "xrTable22";
        this.xrTable22.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow27});
        this.xrTable22.SizeF = new System.Drawing.SizeF(162.4999F, 36.45833F);
        this.xrTable22.StylePriority.UseTextAlignment = false;
        this.xrTable22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow27
        // 
        this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky2});
        this.xrTableRow27.Name = "xrTableRow27";
        this.xrTableRow27.Weight = 1D;
        // 
        // xrt_chuky2
        // 
        this.xrt_chuky2.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuky2.Name = "xrt_chuky2";
        this.xrt_chuky2.StylePriority.UseFont = false;
        this.xrt_chuky2.Weight = 3D;
        // 
        // xrTable18
        // 
        this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(37.5F, 235F);
        this.xrTable18.Name = "xrTable18";
        this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
        this.xrTable18.SizeF = new System.Drawing.SizeF(162.4999F, 36.45833F);
        this.xrTable18.StylePriority.UseTextAlignment = false;
        this.xrTable18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow20
        // 
        this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky1});
        this.xrTableRow20.Name = "xrTableRow20";
        this.xrTableRow20.Weight = 1D;
        // 
        // xrt_chuky1
        // 
        this.xrt_chuky1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuky1.Name = "xrt_chuky1";
        this.xrt_chuky1.StylePriority.UseFont = false;
        this.xrt_chuky1.Weight = 3D;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(1075F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Ghi chú: Trường hợp nghỉ tập trung phải ghi rõ địa chỉ cơ sở nghỉ và thời gian ng" +
            "hỉ từ ngày ...... đến ngày........";
        // 
        // xrTable17
        // 
        this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(37.5F, 97.50001F);
        this.xrTable17.Name = "xrTable17";
        this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19,
            this.xrTableRow18});
        this.xrTable17.SizeF = new System.Drawing.SizeF(162.4999F, 50.00001F);
        this.xrTable17.StylePriority.UseTextAlignment = false;
        this.xrTable17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow19
        // 
        this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrttieude1});
        this.xrTableRow19.Name = "xrTableRow19";
        this.xrTableRow19.Weight = 1D;
        // 
        // xrttieude1
        // 
        this.xrttieude1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrttieude1.Name = "xrttieude1";
        this.xrttieude1.StylePriority.UseFont = false;
        this.xrttieude1.Text = "Người lập";
        this.xrttieude1.Weight = 3D;
        // 
        // xrTableRow18
        // 
        this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell43});
        this.xrTableRow18.Name = "xrTableRow18";
        this.xrTableRow18.Weight = 1D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell43.Name = "xrTableCell43";
        this.xrTableCell43.StylePriority.UseFont = false;
        this.xrTableCell43.Text = "(Ký, họ tên)";
        this.xrTableCell43.Weight = 3D;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7,
            this.xrTable6,
            this.xrTable8,
            this.xrTable9,
            this.xrTable5,
            this.xrTable4,
            this.xrTable3,
            this.xrTable2,
            this.xrTable1});
        this.ReportHeader.HeightF = 232F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrTable7
        // 
        this.xrTable7.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 155F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable7.StylePriority.UseFont = false;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrt_tonglaodong,
            this.xrTableCell14,
            this.xrt_trongdonu});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "Tổng số lao động:";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrTableCell12.Weight = 1.0930232274255087D;
        // 
        // xrt_tonglaodong
        // 
        this.xrt_tonglaodong.Name = "xrt_tonglaodong";
        this.xrt_tonglaodong.Text = ".........................................";
        this.xrt_tonglaodong.Weight = 0.40697677257449127D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Multiline = true;
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = "Trong đó nữ:";
        this.xrTableCell14.Weight = 0.2063952920603197D;
        // 
        // xrt_trongdonu
        // 
        this.xrt_trongdonu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_trongdonu.Name = "xrt_trongdonu";
        this.xrt_trongdonu.StylePriority.UseFont = false;
        this.xrt_trongdonu.StylePriority.UseTextAlignment = false;
        this.xrt_trongdonu.Text = "..................................";
        this.xrt_trongdonu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrt_trongdonu.Weight = 1.2936047079396802D;
        // 
        // xrTable6
        // 
        this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable6.StylePriority.UseFont = false;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrl_sotaikhoan,
            this.xrTableCell11,
            this.xrt_motai});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "Số hiệu tài khoản: ";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrTableCell10.Weight = 1.0930232274255087D;
        // 
        // xrl_sotaikhoan
        // 
        this.xrl_sotaikhoan.Name = "xrl_sotaikhoan";
        this.xrl_sotaikhoan.Text = ".........................................";
        this.xrl_sotaikhoan.Weight = 0.40697677257449127D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Mở tại:";
        this.xrTableCell11.Weight = 0.14244191724200575D;
        // 
        // xrt_motai
        // 
        this.xrt_motai.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_motai.Name = "xrt_motai";
        this.xrt_motai.StylePriority.UseFont = false;
        this.xrt_motai.StylePriority.UseTextAlignment = false;
        this.xrt_motai.Text = "..................................";
        this.xrt_motai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrt_motai.Weight = 1.3575580827579943D;
        // 
        // xrTable8
        // 
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 180F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable8.StylePriority.UseFont = false;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrt_tongquy});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrTableCell16.Weight = 0.7790697390534157D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Text = "   Tổng quỹ lương trong(tháng) quý:";
        this.xrTableCell17.Weight = 0.5813950365643169D;
        // 
        // xrt_tongquy
        // 
        this.xrt_tongquy.Name = "xrt_tongquy";
        this.xrt_tongquy.Text = "................................................................................." +
            ".....................";
        this.xrt_tongquy.Weight = 1.6395352243822674D;
        // 
        // xrTable9
        // 
        this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(1000F, 205F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable9.SizeF = new System.Drawing.SizeF(75F, 25F);
        this.xrTable9.StylePriority.UseFont = false;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrt_sochungtu});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseFont = false;
        this.xrTableCell19.Text = "Số:";
        this.xrTableCell19.Weight = 1.1138616015357368D;
        // 
        // xrt_sochungtu
        // 
        this.xrt_sochungtu.Name = "xrt_sochungtu";
        this.xrt_sochungtu.Text = ".........";
        this.xrt_sochungtu.Weight = 1.8861383984642637D;
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 105F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(1075F, 25F);
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrl_quynam});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrl_quynam
        // 
        this.xrl_quynam.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrl_quynam.Name = "xrl_quynam";
        this.xrl_quynam.StylePriority.UseFont = false;
        this.xrl_quynam.StylePriority.UseTextAlignment = false;
        this.xrl_quynam.Text = "Tháng....quý.....năm.......";
        this.xrl_quynam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrl_quynam.Weight = 3D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(1075F, 55F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrl_tieudebaocao});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrl_tieudebaocao
        // 
        this.xrl_tieudebaocao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_tieudebaocao.Multiline = true;
        this.xrl_tieudebaocao.Name = "xrl_tieudebaocao";
        this.xrl_tieudebaocao.StylePriority.UseFont = false;
        this.xrl_tieudebaocao.StylePriority.UseTextAlignment = false;
        this.xrl_tieudebaocao.Text = "DANH SÁCH NGƯỜI LAO ĐỘNG ĐỀ NGHỊ HƯỞNG TRỢ CẤP NGHỈ DSPHSK \r\nSAU ĐIỀU TRỊ THƯƠNG " +
            "TẬT, BỆNH TẬT DO TNLĐ- BNN";
        this.xrl_tieudebaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrl_tieudebaocao.Weight = 3D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(937.5F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(137.5F, 25F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.Text = "Mẫu số: C 70a- HD";
        this.xrTableCell5.Weight = 3D;
        // 
        // xrTable2
        // 
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(300F, 25F);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrl_madonvi});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.Text = "Mã đơn vị:";
        this.xrTableCell3.Weight = 1.5D;
        // 
        // xrl_madonvi
        // 
        this.xrl_madonvi.Name = "xrl_madonvi";
        this.xrl_madonvi.Text = "...............................";
        this.xrl_madonvi.Weight = 1.5D;
        // 
        // xrTable1
        // 
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(803.1248F, 25F);
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrltendonvi});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.Text = "Tên cơ quan(đơn vị):";
        this.xrTableCell2.Weight = 1.5D;
        // 
        // xrltendonvi
        // 
        this.xrltendonvi.Name = "xrltendonvi";
        this.xrltendonvi.Text = "...............................";
        this.xrltendonvi.Weight = 6.5312481689453126D;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable16});
        this.GroupFooter1.HeightF = 25F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // xrTable16
        // 
        this.xrTable16.BorderColor = System.Drawing.SystemColors.ControlText;
        this.xrTable16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable16.Name = "xrTable16";
        this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
        this.xrTable16.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable16.StylePriority.UseBorderColor = false;
        this.xrTable16.StylePriority.UseBorders = false;
        // 
        // xrTableRow17
        // 
        this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell40,
            this.xrTableCell41,
            this.cong_sobhxh,
            this.cong_mucdosuygiam,
            this.cong_taigiadinh,
            this.cong_nghitaptrung,
            this.cong_sotientrocap,
            this.cong_ghichu});
        this.xrTableRow17.Name = "xrTableRow17";
        this.xrTableRow17.Weight = 1D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.Weight = 0.10043208632358283D;
        // 
        // xrTableCell41
        // 
        this.xrTableCell41.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell41.Name = "xrTableCell41";
        this.xrTableCell41.StylePriority.UseFont = false;
        this.xrTableCell41.StylePriority.UseTextAlignment = false;
        this.xrTableCell41.Text = "Cộng";
        this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell41.Weight = 0.40496748103651886D;
        // 
        // cong_sobhxh
        // 
        this.cong_sobhxh.Name = "cong_sobhxh";
        this.cong_sobhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_sobhxh.StylePriority.UsePadding = false;
        this.cong_sobhxh.StylePriority.UseTextAlignment = false;
        this.cong_sobhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cong_sobhxh.Weight = 0.19438463432844289D;
        // 
        // cong_mucdosuygiam
        // 
        this.cong_mucdosuygiam.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cong_mucdosuygiam.Name = "cong_mucdosuygiam";
        this.cong_mucdosuygiam.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_mucdosuygiam.StylePriority.UseBorders = false;
        this.cong_mucdosuygiam.StylePriority.UsePadding = false;
        this.cong_mucdosuygiam.StylePriority.UseTextAlignment = false;
        this.cong_mucdosuygiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cong_mucdosuygiam.Weight = 0.53455725026685141D;
        // 
        // cong_taigiadinh
        // 
        this.cong_taigiadinh.Name = "cong_taigiadinh";
        this.cong_taigiadinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_taigiadinh.StylePriority.UsePadding = false;
        this.cong_taigiadinh.StylePriority.UseTextAlignment = false;
        this.cong_taigiadinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cong_taigiadinh.Weight = 0.3139537474166515D;
        // 
        // cong_nghitaptrung
        // 
        this.cong_nghitaptrung.Name = "cong_nghitaptrung";
        this.cong_nghitaptrung.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_nghitaptrung.StylePriority.UsePadding = false;
        this.cong_nghitaptrung.StylePriority.UseTextAlignment = false;
        this.cong_nghitaptrung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cong_nghitaptrung.Weight = 0.3139529791543651D;
        // 
        // cong_sotientrocap
        // 
        this.cong_sotientrocap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cong_sotientrocap.Name = "cong_sotientrocap";
        this.cong_sotientrocap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_sotientrocap.StylePriority.UseBorders = false;
        this.cong_sotientrocap.StylePriority.UsePadding = false;
        this.cong_sotientrocap.StylePriority.UseTextAlignment = false;
        this.cong_sotientrocap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cong_sotientrocap.Weight = 0.37903053638546963D;
        // 
        // cong_ghichu
        // 
        this.cong_ghichu.Name = "cong_ghichu";
        this.cong_ghichu.Weight = 0.75872128508811776D;
        // 
        // rp_DanhSachNguoiSauDieuTriBenhTat
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupFooter1});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(75, 19, 50, 100);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
