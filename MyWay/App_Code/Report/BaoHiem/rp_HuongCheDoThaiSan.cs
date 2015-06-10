using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_HuongCheDoThaiSan
/// </summary>
public class rp_HuongCheDoThaiSan : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportHeaderBand ReportHeader;
    private GroupFooterBand GroupFooter1;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrl_madonvi;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrl_tieudebaocao;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrltendonvi;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell33;
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
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell43;
    private XRTableCell xrt_sttgroup;
    private XRTableRow xrTableRow16;
    private XRTable xrTable15;
    private GroupHeaderBand GroupHeader2;
    private XRTable xrTable16;
    private XRTableRow xrTableRow17;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_sosobhxh;
    private XRTableCell xrt_tienluongbhxh;
    private XRTableCell xrt_thoigiandbhxh;
    private XRTableCell xrt_trongky;
    private XRTableCell xrt_luyke;
    private XRTableCell xrt_sotien;
    private XRTableCell xrt_ghichu;
    private XRTable xrTable19;
    private XRTableRow xrTableRow21;
    private XRTableCell xrt_chuky1;
    private XRLabel xrl_ngayketxuat;
    private XRTable xrTable25;
    private XRTableRow xrTableRow30;
    private XRTableCell xrt_chuky3;
    private XRTable xrTable23;
    private XRTableRow xrTableRow22;
    private XRTableCell xrttieude2;
    private XRTableRow xrTableRow28;
    private XRTableCell xrTableCell56;
    private XRTable xrTable20;
    private XRTableRow xrTableRow23;
    private XRTableCell xrttieude3;
    private XRTableRow xrTableRow24;
    private XRTableCell xrTableCell55;
    private XRLabel xrLabel1;
    private XRTable xrTable18;
    private XRTableRow xrTableRow19;
    private XRTableCell xrttieude1;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell53;
    private XRTable xrTable22;
    private XRTableRow xrTableRow27;
    private XRTableCell xrt_chuky2;
    private XRTable xrTable17;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell cong_sobhxh;
    private XRTableCell cong_tinhtienluong;
    private XRTableCell cong_thoigiandongbhxh;
    private XRTableCell cong_trongky;
    private XRTableCell cong_luyke;
    private XRTableCell cong_sotien;
    private XRTableCell cong_ghichu;
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

    public rp_HuongCheDoThaiSan()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    public enum RomanNumber
    {
        I = 1,
        IV = 4,
        V = 5,
        IX = 9,
        X = 10,
        XL = 40,
        L = 50,
        XC = 90,
        C = 100,
        CD = 400,
        D = 500,
        CM = 900,
        M = 1000
    }

    public void Validate(int number)
    {
        if (number <= 0)
        {
            var message = string.Format("{0} is not a valid number.It must be bbigger than 0.", number);
            throw new ArgumentException(message);
        }
    }
    public string ToRoman(int number)
    {
        Validate(number);
        var romanRepresentation = string.Empty;

        var values = Enum.GetValues(typeof(RomanNumber));

        for (var i = values.Length - 1; i >= 0; --i)
        {
            var value = (int)values.GetValue(i);

            while (number >= value)
            {
                romanRepresentation += Enum.GetName(typeof(RomanNumber), value);

                number -= value;
            }
        }

        return romanRepresentation;
    }
    int STT1 = 1;
    private void Goup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrt_sttgroup.Text = ToRoman(STT1);
        STT1++;
    }

    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrt_stt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter rp)
    { // xử lý  phần header
        BHDauPhieuController bh = new BHDauPhieuController();
        xrltendonvi.Text = ReportController.GetInstance().GetCompanyName(rp.SessionDepartment);
        xrl_madonvi.Text = rp.SessionDepartment;


        int id = 0;
        DAL.BHDAUPHIEU bhdp = null;
        try
        {
            if (!int.TryParse(rp.WhereClause, out id) && rp.WhereClause != "1 = 1")
            {
                rp.WhereClause = rp.WhereClause.Substring(17);
                rp.WhereClause = rp.WhereClause.Substring(0, rp.WhereClause.LastIndexOf("'"));
                int.TryParse(rp.WhereClause, out id);
                //  (IDDauPhieu = N '103')
            }
            bhdp = bh.GetByIdDauPhieu(id);
        }
        catch (Exception)
        {

        }
        // var bhdp = bh.GetByIdDauPhieu(Convert.ToInt32("0" + rp.WhereClause));
        //string Ngay = new BHDauPhieuController().GetQuy(rp.NgayBatDau, rp.NgayKetThuc);
        //if (Ngay == "Quý 1" || Ngay == "Quý 2" || Ngay == "Quý 3" || Ngay == "Quý 4")
        //{
        //    xrl_quynam.Text = Ngay + " năm " + rp.namchungtu;
        //}
        //else
        //{
        //    xrl_quynam.Text = "Tháng " + Ngay + " năm " + rp.namchungtu;
        //}
        DataTable dt = new DataTable();
        if (bhdp != null)
        {
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

            dt = DataHandler.GetInstance().ExecuteDataTable("sp_BHC67aHD", "@NgayBatDau", "@NgayKetThuc", bhdp.TuNgay, bhdp.DenNgay);
        }
        else
        {
            dt = DataHandler.GetInstance().ExecuteDataTable("sp_BHC67aHD", "@NgayBatDau", "@NgayKetThuc", "@StartMonth","@EndMonth", "@Year", rp.StartDate, rp.EndDate, rp.StartMonth,rp.EndMonth, rp.Year);
        }
        DataSource = dt;
        xrt_hovaten.DataBindings.Add("Text", DataSource, "HoTen");
        xrt_sosobhxh.DataBindings.Add("Text", DataSource, "SoSoBHXH");
        // xrt_dieukientinhhuong.DataBindings.Add("Text", DataSource, "TenDieuKienHuong");
        xrt_tienluongbhxh.DataBindings.Add("Text", DataSource, "TienLuongTinhHuong", "{0:n0}");

        xrt_thoigiandbhxh.DataBindings.Add("Text", DataSource, "ThoiGianDongBaoHiem");
        xrt_trongky.DataBindings.Add("Text", DataSource, "SoNgayNghi");
        xrt_luyke.DataBindings.Add("Text", DataSource, "LuyKeTuDauNam");
        xrt_sotien.DataBindings.Add("Text", DataSource, "SoTienDeNghi", "{0:n0}");
        xrt_ghichu.DataBindings.Add("Text", DataSource, "GhiChu");

        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_tinhtienluong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TienLuongTinhHuong")});
        xrSummary2.FormatString = "{0:n0}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_tinhtienluong.Summary = xrSummary2;

        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_trongky.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoNgayNghi")});
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_trongky.Summary = xrSummary4;

        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_luyke.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LuyKeTuDauNam")});
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_luyke.Summary = xrSummary6;

        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        this.cong_sotien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoTienDeNghi","{0:n0}")});
        xrSummary7.FormatString = "{0:0,0}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.cong_sotien.Summary = xrSummary7;

        this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TenCheDoBaoHiem", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrTableCell43.DataBindings.Add("Text", DataSource, "TenCheDoBaoHiem");

        if (!string.IsNullOrEmpty(rp.ReportTitle))
        {
            xrl_tieudebaocao.Text = rp.ReportTitle.ToUpper();
        }
        if (!string.IsNullOrEmpty(rp.Title1))
        {
            xrttieude1.Text = rp.Title1;
        }
        if (!string.IsNullOrEmpty(rp.Title2))
        {
            xrttieude2.Text = rp.Title2;
        }
        if (!string.IsNullOrEmpty(rp.Title3))
        {
            xrttieude3.Text = rp.Title3;
        }
        if (!string.IsNullOrEmpty(rp.Name1))
        {
            xrt_chuky1.Text = rp.Name1;
        }
        if (!string.IsNullOrEmpty(rp.Name2))
        {
            xrt_chuky2.Text = rp.Name2;
        }
        if (!string.IsNullOrEmpty(rp.Name3))
        {
            xrt_chuky3.Text = rp.Name3;
        }
        if (rp.ReportedDate != null)
        {
            xrl_ngayketxuat.Text = ReportController.GetInstance().GetFooterReport(rp.SessionDepartment, rp.ReportedDate);
        }
        else
            xrl_ngayketxuat.Text = ReportController.GetInstance().GetFooterReport(rp.SessionDepartment, DateTime.Now);
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
        string resourceFileName = "rp_HuongCheDoThaiSan.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sosobhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tienluongbhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thoigiandbhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_trongky = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_luyke = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sotien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_madonvi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrl_tieudebaocao = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrltendonvi = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_sobhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_tinhtienluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_thoigiandongbhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_trongky = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_luyke = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_sotien = new DevExpress.XtraReports.UI.XRTableCell();
        this.cong_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable19 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable25 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable23 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable20 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrttieude1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable22 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_chuky2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_sttgroup = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
        this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable16});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable16
        // 
        this.xrTable16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable16.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable16.Name = "xrTable16";
        this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
        this.xrTable16.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable16.StylePriority.UseBorders = false;
        this.xrTable16.StylePriority.UseFont = false;
        this.xrTable16.StylePriority.UseTextAlignment = false;
        this.xrTable16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow17
        // 
        this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrt_sosobhxh,
            this.xrt_tienluongbhxh,
            this.xrt_thoigiandbhxh,
            this.xrt_trongky,
            this.xrt_luyke,
            this.xrt_sotien,
            this.xrt_ghichu});
        this.xrTableRow17.Name = "xrTableRow17";
        this.xrTableRow17.Weight = 1D;
        // 
        // xrt_stt
        // 
        this.xrt_stt.Name = "xrt_stt";
        this.xrt_stt.Text = "1";
        this.xrt_stt.Weight = 0.090116385526435278D;
        this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrt_hovaten
        // 
        this.xrt_hovaten.Name = "xrt_hovaten";
        this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hovaten.StylePriority.UsePadding = false;
        this.xrt_hovaten.StylePriority.UseTextAlignment = false;
        this.xrt_hovaten.Text = "Khám thai";
        this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hovaten.Weight = 0.3633720433434775D;
        // 
        // xrt_sosobhxh
        // 
        this.xrt_sosobhxh.Name = "xrt_sosobhxh";
        this.xrt_sosobhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_sosobhxh.StylePriority.UsePadding = false;
        this.xrt_sosobhxh.StylePriority.UseTextAlignment = false;
        this.xrt_sosobhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_sosobhxh.Weight = 0.20232574817746185D;
        // 
        // xrt_tienluongbhxh
        // 
        this.xrt_tienluongbhxh.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_tienluongbhxh.Name = "xrt_tienluongbhxh";
        this.xrt_tienluongbhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_tienluongbhxh.StylePriority.UseBorders = false;
        this.xrt_tienluongbhxh.StylePriority.UsePadding = false;
        this.xrt_tienluongbhxh.StylePriority.UseTextAlignment = false;
        this.xrt_tienluongbhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_tienluongbhxh.Weight = 0.30348807756290885D;
        // 
        // xrt_thoigiandbhxh
        // 
        this.xrt_thoigiandbhxh.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrt_thoigiandbhxh.Name = "xrt_thoigiandbhxh";
        this.xrt_thoigiandbhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_thoigiandbhxh.StylePriority.UseBorders = false;
        this.xrt_thoigiandbhxh.StylePriority.UsePadding = false;
        this.xrt_thoigiandbhxh.StylePriority.UseTextAlignment = false;
        this.xrt_thoigiandbhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_thoigiandbhxh.Weight = 0.27906985970430592D;
        // 
        // xrt_trongky
        // 
        this.xrt_trongky.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_trongky.Name = "xrt_trongky";
        this.xrt_trongky.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_trongky.StylePriority.UseBorders = false;
        this.xrt_trongky.StylePriority.UsePadding = false;
        this.xrt_trongky.StylePriority.UseTextAlignment = false;
        this.xrt_trongky.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_trongky.Weight = 0.26162791407385538D;
        // 
        // xrt_luyke
        // 
        this.xrt_luyke.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_luyke.Name = "xrt_luyke";
        this.xrt_luyke.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_luyke.StylePriority.UseBorders = false;
        this.xrt_luyke.StylePriority.UsePadding = false;
        this.xrt_luyke.StylePriority.UseTextAlignment = false;
        this.xrt_luyke.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_luyke.Weight = 0.366279076864553D;
        // 
        // xrt_sotien
        // 
        this.xrt_sotien.Name = "xrt_sotien";
        this.xrt_sotien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_sotien.StylePriority.UsePadding = false;
        this.xrt_sotien.StylePriority.UseTextAlignment = false;
        this.xrt_sotien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_sotien.Weight = 0.29360441695812145D;
        // 
        // xrt_ghichu
        // 
        this.xrt_ghichu.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_ghichu.Name = "xrt_ghichu";
        this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_ghichu.StylePriority.UseBorders = false;
        this.xrt_ghichu.StylePriority.UsePadding = false;
        this.xrt_ghichu.StylePriority.UseTextAlignment = false;
        this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_ghichu.Weight = 0.84011647778888088D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 47F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 51F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10,
            this.xrTable14});
        this.PageHeader.Name = "PageHeader";
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
            this.xrTableCell26,
            this.xrTableCell33,
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
        this.xrTableCell25.Weight = 0.20232571269190591D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Multiline = true;
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Text = "Tiền lương tính BHXH\r\n";
        this.xrTableCell26.Weight = 0.30348823547363285D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.StylePriority.UseBorders = false;
        this.xrTableCell33.Text = "Thời gian đóng BHXH";
        this.xrTableCell33.Weight = 0.27906974393267969D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable11,
            this.xrTable12,
            this.xrTable13});
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Text = "xrTableCell22";
        this.xrTableCell22.Weight = 0.92151139414587713D;
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
        this.xrTableCell30.Text = "Số ngày nghỉ ";
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
        this.xrTableCell31.Text = "Trong kỳ";
        this.xrTableCell31.Weight = 1.2499994066029292D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseBorders = false;
        this.xrTableCell29.StylePriority.UseFont = false;
        this.xrTableCell29.Text = "Lũy kế từ đầu năm";
        this.xrTableCell29.Weight = 1.7500005933970708D;
        // 
        // xrTable12
        // 
        this.xrTable12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(225F, 30.83334F);
        this.xrTable12.Name = "xrTable12";
        this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
        this.xrTable12.SizeF = new System.Drawing.SizeF(105.2083F, 42.91666F);
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
        this.xrTableCell28.Text = "Số tiền";
        this.xrTableCell28.Weight = 3D;
        // 
        // xrTable13
        // 
        this.xrTable13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable13.Name = "xrTable13";
        this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
        this.xrTable13.SizeF = new System.Drawing.SizeF(330.2082F, 30.83334F);
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
        this.xrTableCell32.Text = "Số đề nghị";
        this.xrTableCell32.Weight = 3D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Text = "Ghi chú";
        this.xrTableCell23.Weight = 0.84011647778888088D;
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
        this.xrTable14.StylePriority.UseTextAlignment = false;
        this.xrTable14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36,
            this.xrTableCell34,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell35,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell42,
            this.xrTableCell41});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.Text = "A";
        this.xrTableCell36.Weight = 0.090116385526435278D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.Text = "B";
        this.xrTableCell34.Weight = 0.3633720433434775D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Text = "C";
        this.xrTableCell37.Weight = 0.20232574817746185D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.Text = "1";
        this.xrTableCell38.Weight = 0.30348807756290885D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseBorders = false;
        this.xrTableCell35.Text = "2";
        this.xrTableCell35.Weight = 0.27906985970430592D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseBorders = false;
        this.xrTableCell39.Text = "3";
        this.xrTableCell39.Weight = 0.26162791407385538D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.StylePriority.UseBorders = false;
        this.xrTableCell40.Text = "4";
        this.xrTableCell40.Weight = 0.366279076864553D;
        // 
        // xrTableCell42
        // 
        this.xrTableCell42.Name = "xrTableCell42";
        this.xrTableCell42.Text = "5";
        this.xrTableCell42.Weight = 0.29360441695812145D;
        // 
        // xrTableCell41
        // 
        this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell41.Name = "xrTableCell41";
        this.xrTableCell41.StylePriority.UseBorders = false;
        this.xrTableCell41.Text = "D";
        this.xrTableCell41.Weight = 0.84011647778888088D;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7,
            this.xrTable6,
            this.xrTable8,
            this.xrTable9,
            this.xrTable5,
            this.xrTable3,
            this.xrTable2,
            this.xrTable4,
            this.xrTable1});
        this.ReportHeader.HeightF = 212.5F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrTable7
        // 
        this.xrTable7.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 137.5F);
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
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = "Trong đó nữ:";
        this.xrTableCell14.Weight = 0.22674418604651153D;
        // 
        // xrt_trongdonu
        // 
        this.xrt_trongdonu.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_trongdonu.Name = "xrt_trongdonu";
        this.xrt_trongdonu.StylePriority.UseFont = false;
        this.xrt_trongdonu.StylePriority.UseTextAlignment = false;
        this.xrt_trongdonu.Text = "..................................";
        this.xrt_trongdonu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrt_trongdonu.Weight = 1.2732558139534884D;
        // 
        // xrTable6
        // 
        this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 112.5F);
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
        this.xrTableCell11.Weight = 0.11627912654433133D;
        // 
        // xrt_motai
        // 
        this.xrt_motai.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrt_motai.Name = "xrt_motai";
        this.xrt_motai.StylePriority.UseFont = false;
        this.xrt_motai.StylePriority.UseTextAlignment = false;
        this.xrt_motai.Text = "..................................";
        this.xrt_motai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrt_motai.Weight = 1.3837208734556685D;
        // 
        // xrTable8
        // 
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162.5F);
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
        this.xrTableCell17.Weight = 0.57848842886991281D;
        // 
        // xrt_tongquy
        // 
        this.xrt_tongquy.Name = "xrt_tongquy";
        this.xrt_tongquy.Text = "..............................................";
        this.xrt_tongquy.Weight = 1.6424418320766716D;
        // 
        // xrTable9
        // 
        this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(913.5416F, 187.5F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable9.SizeF = new System.Drawing.SizeF(161.4583F, 25F);
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
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
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
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(932.2917F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(138.5416F, 25F);
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
        this.xrTableCell5.Text = "Mẫu số: C 67a- HD";
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
        this.xrl_madonvi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrl_madonvi.Name = "xrl_madonvi";
        this.xrl_madonvi.StylePriority.UseFont = false;
        this.xrl_madonvi.Text = "...............................";
        this.xrl_madonvi.Weight = 1.5D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(1075F, 25F);
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
        this.xrl_tieudebaocao.Name = "xrl_tieudebaocao";
        this.xrl_tieudebaocao.StylePriority.UseFont = false;
        this.xrl_tieudebaocao.StylePriority.UseTextAlignment = false;
        this.xrl_tieudebaocao.Text = "DANH SÁCH NGƯỜI LAO ĐỘNG  ĐỀ NGHỊ HƯỞNG CHẾ ĐỘ THAI SẢN";
        this.xrl_tieudebaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrl_tieudebaocao.Weight = 3D;
        // 
        // xrTable1
        // 
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(803.125F, 25F);
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
        this.xrltendonvi.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrltendonvi.Name = "xrltendonvi";
        this.xrltendonvi.StylePriority.UseFont = false;
        this.xrltendonvi.Text = "...............................";
        this.xrltendonvi.Weight = 6.53125D;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.HeightF = 0F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable17,
            this.xrTable19,
            this.xrl_ngayketxuat,
            this.xrTable25,
            this.xrTable23,
            this.xrTable20,
            this.xrLabel1,
            this.xrTable18,
            this.xrTable22});
        this.ReportFooter.HeightF = 259F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrTable17
        // 
        this.xrTable17.BorderColor = System.Drawing.SystemColors.ControlText;
        this.xrTable17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable17.Name = "xrTable17";
        this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
        this.xrTable17.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable17.StylePriority.UseBorderColor = false;
        this.xrTable17.StylePriority.UseBorders = false;
        // 
        // xrTableRow18
        // 
        this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell51,
            this.xrTableCell52,
            this.cong_sobhxh,
            this.cong_tinhtienluong,
            this.cong_thoigiandongbhxh,
            this.cong_trongky,
            this.cong_luyke,
            this.cong_sotien,
            this.cong_ghichu});
        this.xrTableRow18.Name = "xrTableRow18";
        this.xrTableRow18.Weight = 1D;
        // 
        // xrTableCell51
        // 
        this.xrTableCell51.Name = "xrTableCell51";
        this.xrTableCell51.Weight = 0.090116371332212925D;
        // 
        // xrTableCell52
        // 
        this.xrTableCell52.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell52.Name = "xrTableCell52";
        this.xrTableCell52.StylePriority.UseFont = false;
        this.xrTableCell52.StylePriority.UseTextAlignment = false;
        this.xrTableCell52.Text = "Cộng";
        this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell52.Weight = 0.36337185881858647D;
        // 
        // cong_sobhxh
        // 
        this.cong_sobhxh.Name = "cong_sobhxh";
        this.cong_sobhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_sobhxh.StylePriority.UsePadding = false;
        this.cong_sobhxh.StylePriority.UseTextAlignment = false;
        this.cong_sobhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cong_sobhxh.Weight = 0.20232591850813042D;
        // 
        // cong_tinhtienluong
        // 
        this.cong_tinhtienluong.Name = "cong_tinhtienluong";
        this.cong_tinhtienluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_tinhtienluong.StylePriority.UsePadding = false;
        this.cong_tinhtienluong.StylePriority.UseTextAlignment = false;
        this.cong_tinhtienluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cong_tinhtienluong.Weight = 0.30348798530046334D;
        // 
        // cong_thoigiandongbhxh
        // 
        this.cong_thoigiandongbhxh.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cong_thoigiandongbhxh.Name = "cong_thoigiandongbhxh";
        this.cong_thoigiandongbhxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_thoigiandongbhxh.StylePriority.UseBorders = false;
        this.cong_thoigiandongbhxh.StylePriority.UsePadding = false;
        this.cong_thoigiandongbhxh.StylePriority.UseTextAlignment = false;
        this.cong_thoigiandongbhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cong_thoigiandongbhxh.Weight = 0.27906985615575036D;
        // 
        // cong_trongky
        // 
        this.cong_trongky.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cong_trongky.Name = "cong_trongky";
        this.cong_trongky.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_trongky.StylePriority.UseBorders = false;
        this.cong_trongky.StylePriority.UsePadding = false;
        this.cong_trongky.StylePriority.UseTextAlignment = false;
        this.cong_trongky.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cong_trongky.Weight = 0.26162820682969212D;
        // 
        // cong_luyke
        // 
        this.cong_luyke.Name = "cong_luyke";
        this.cong_luyke.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_luyke.StylePriority.UseBorders = false;
        this.cong_luyke.StylePriority.UsePadding = false;
        this.cong_luyke.StylePriority.UseTextAlignment = false;
        this.cong_luyke.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cong_luyke.Weight = 0.366278901211051D;
        // 
        // cong_sotien
        // 
        this.cong_sotien.Name = "cong_sotien";
        this.cong_sotien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cong_sotien.StylePriority.UsePadding = false;
        this.cong_sotien.StylePriority.UseTextAlignment = false;
        this.cong_sotien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cong_sotien.Weight = 0.29360426082167523D;
        // 
        // cong_ghichu
        // 
        this.cong_ghichu.Name = "cong_ghichu";
        this.cong_ghichu.Weight = 0.8401166410224381D;
        // 
        // xrTable19
        // 
        this.xrTable19.LocationFloat = new DevExpress.Utils.PointFloat(30.20827F, 222.5F);
        this.xrTable19.Name = "xrTable19";
        this.xrTable19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow21});
        this.xrTable19.SizeF = new System.Drawing.SizeF(162.4999F, 36.45833F);
        this.xrTable19.StylePriority.UseTextAlignment = false;
        this.xrTable19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow21
        // 
        this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky1});
        this.xrTableRow21.Name = "xrTableRow21";
        this.xrTableRow21.Weight = 1D;
        // 
        // xrt_chuky1
        // 
        this.xrt_chuky1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuky1.Name = "xrt_chuky1";
        this.xrt_chuky1.StylePriority.UseFont = false;
        this.xrt_chuky1.Weight = 3D;
        // 
        // xrl_ngayketxuat
        // 
        this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(773.9583F, 62.08337F);
        this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
        this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(296.875F, 18.83335F);
        this.xrl_ngayketxuat.StylePriority.UseFont = false;
        this.xrl_ngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrl_ngayketxuat.Text = "Ngày...... tháng........ năm.......";
        this.xrl_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTable25
        // 
        this.xrTable25.LocationFloat = new DevExpress.Utils.PointFloat(841.1458F, 222.5F);
        this.xrTable25.Name = "xrTable25";
        this.xrTable25.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow30});
        this.xrTable25.SizeF = new System.Drawing.SizeF(162.4999F, 36.45833F);
        this.xrTable25.StylePriority.UseTextAlignment = false;
        this.xrTable25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow30
        // 
        this.xrTableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky3});
        this.xrTableRow30.Name = "xrTableRow30";
        this.xrTableRow30.Weight = 1D;
        // 
        // xrt_chuky3
        // 
        this.xrt_chuky3.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuky3.Name = "xrt_chuky3";
        this.xrt_chuky3.StylePriority.UseFont = false;
        this.xrt_chuky3.Weight = 3D;
        // 
        // xrTable23
        // 
        this.xrTable23.LocationFloat = new DevExpress.Utils.PointFloat(433.3334F, 84.99998F);
        this.xrTable23.Name = "xrTable23";
        this.xrTable23.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow22,
            this.xrTableRow28});
        this.xrTable23.SizeF = new System.Drawing.SizeF(162.4999F, 50.00001F);
        this.xrTable23.StylePriority.UseTextAlignment = false;
        this.xrTable23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow22
        // 
        this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrttieude2});
        this.xrTableRow22.Name = "xrTableRow22";
        this.xrTableRow22.Weight = 1D;
        // 
        // xrttieude2
        // 
        this.xrttieude2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrttieude2.Name = "xrttieude2";
        this.xrttieude2.StylePriority.UseFont = false;
        this.xrttieude2.Text = "Kế toán trưởng ";
        this.xrttieude2.Weight = 3D;
        // 
        // xrTableRow28
        // 
        this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell56});
        this.xrTableRow28.Name = "xrTableRow28";
        this.xrTableRow28.Weight = 1D;
        // 
        // xrTableCell56
        // 
        this.xrTableCell56.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell56.Name = "xrTableCell56";
        this.xrTableCell56.StylePriority.UseFont = false;
        this.xrTableCell56.Text = "(Ký, đóng dấu)";
        this.xrTableCell56.Weight = 3D;
        // 
        // xrTable20
        // 
        this.xrTable20.LocationFloat = new DevExpress.Utils.PointFloat(841.1458F, 84.99998F);
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
        this.xrttieude3.Text = "Thủ trưởng đơn vị";
        this.xrttieude3.Weight = 3D;
        // 
        // xrTableRow24
        // 
        this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell55});
        this.xrTableRow24.Name = "xrTableRow24";
        this.xrTableRow24.Weight = 1D;
        // 
        // xrTableCell55
        // 
        this.xrTableCell55.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell55.Name = "xrTableCell55";
        this.xrTableCell55.StylePriority.UseFont = false;
        this.xrTableCell55.Text = "(Ký họ tên)";
        this.xrTableCell55.Weight = 3D;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1.041571F, 37.08337F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(1073.958F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Ghi chú: Trường hợp nghỉ tập trung phải ghi rõ địa chỉ cơ sở nghỉ và thời gian ng" +
            "hỉ từ ngày ...... đến ngày........";
        // 
        // xrTable18
        // 
        this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(30.20827F, 84.99998F);
        this.xrTable18.Name = "xrTable18";
        this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19,
            this.xrTableRow20});
        this.xrTable18.SizeF = new System.Drawing.SizeF(162.4999F, 50.00001F);
        this.xrTable18.StylePriority.UseTextAlignment = false;
        this.xrTable18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        // xrTableRow20
        // 
        this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53});
        this.xrTableRow20.Name = "xrTableRow20";
        this.xrTableRow20.Weight = 1D;
        // 
        // xrTableCell53
        // 
        this.xrTableCell53.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrTableCell53.Name = "xrTableCell53";
        this.xrTableCell53.StylePriority.UseFont = false;
        this.xrTableCell53.Text = "(Ký, họ tên)";
        this.xrTableCell53.Weight = 3D;
        // 
        // xrTable22
        // 
        this.xrTable22.LocationFloat = new DevExpress.Utils.PointFloat(433.3334F, 222.5F);
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
        // xrTableCell50
        // 
        this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell50.Name = "xrTableCell50";
        this.xrTableCell50.StylePriority.UseBorders = false;
        this.xrTableCell50.Weight = 0.84011647778888088D;
        // 
        // xrTableCell49
        // 
        this.xrTableCell49.Name = "xrTableCell49";
        this.xrTableCell49.Weight = 0.29360441695812145D;
        // 
        // xrTableCell48
        // 
        this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell48.Name = "xrTableCell48";
        this.xrTableCell48.StylePriority.UseBorders = false;
        this.xrTableCell48.Weight = 0.366279076864553D;
        // 
        // xrTableCell47
        // 
        this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell47.Name = "xrTableCell47";
        this.xrTableCell47.StylePriority.UseBorders = false;
        this.xrTableCell47.Weight = 0.26162791407385538D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.StylePriority.UseBorders = false;
        this.xrTableCell46.Weight = 0.27906985970430592D;
        // 
        // xrTableCell45
        // 
        this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell45.Name = "xrTableCell45";
        this.xrTableCell45.StylePriority.UseBorders = false;
        this.xrTableCell45.Weight = 0.30348807756290885D;
        // 
        // xrTableCell44
        // 
        this.xrTableCell44.Name = "xrTableCell44";
        this.xrTableCell44.Weight = 0.20232574817746185D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Name = "xrTableCell43";
        this.xrTableCell43.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell43.StylePriority.UsePadding = false;
        this.xrTableCell43.StylePriority.UseTextAlignment = false;
        this.xrTableCell43.Text = "Khám thai";
        this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell43.Weight = 0.3633720433434775D;
        // 
        // xrt_sttgroup
        // 
        this.xrt_sttgroup.Name = "xrt_sttgroup";
        this.xrt_sttgroup.Text = "I";
        this.xrt_sttgroup.Weight = 0.090116385526435278D;
        this.xrt_sttgroup.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Goup_BeforePrint);
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_sttgroup,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell49,
            this.xrTableCell50});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrTable15
        // 
        this.xrTable15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable15.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable15.Name = "xrTable15";
        this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
        this.xrTable15.SizeF = new System.Drawing.SizeF(1075F, 25F);
        this.xrTable15.StylePriority.UseBorders = false;
        this.xrTable15.StylePriority.UseFont = false;
        this.xrTable15.StylePriority.UseTextAlignment = false;
        this.xrTable15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // GroupHeader2
        // 
        this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable15});
        this.GroupHeader2.HeightF = 25F;
        this.GroupHeader2.Level = 1;
        this.GroupHeader2.Name = "GroupHeader2";
        // 
        // rp_HuongCheDoThaiSan
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader,
            this.GroupHeader2,
            this.GroupFooter1,
            this.ReportFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(68, 25, 47, 51);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
