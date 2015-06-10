using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_BangThanhToanLuongThang
/// </summary>
public class rp_BangThanhToanLuongThang : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrt_STT;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_heso;
    private XRTableCell xrt_thanhtien;
    private XRTableCell xrt_thanhtienlamthem;
    private XRTableCell xrt_phuCapAnCa;
    private XRTableCell xrt_trachnhiem;
    private XRTableCell xrt_tongthunhap;
    private XRTableCell xrt_bhtn;
    private XRTableCell xrt_thuclinh;
    private XRTableCell xrt_socong100;
    private XRTableCell xrt_socong150;
    private XRTableCell xrt_bhxh;
    private XRTableCell xrt_bhyt;
    private PageHeaderBand PageHeader;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_NgayBC;
    private XRLabel xrLabel2;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrLabel1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell12;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell6;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell15;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell22;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell17;
    private ReportFooterBand ReportFooter;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private GroupHeaderBand GroupHeader1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell39;
    private XRLabel xrlDocSo;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrt_tenphong;
    private XRLabel xrl_TongSoTien;
    private XRTableCell xrt_socong;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_BangThanhToanLuongThang()
    {
        InitializeComponent();
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrt_STT.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        //xrtngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //xrl_NgayBC.Text = "Ngày báo cáo: " + string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        //if (!string.IsNullOrEmpty(filter.SalaryBoardTitle))
        //{
        //    xrl_TitleBC.Text = filter.SalaryBoardTitle.ToUpper();
        //}
        //else
        //{
        //    xrl_TitleBC.Text = filter.ReportTitle;
        //}
        //xrl_TenThanhPho.Text = filter.CityName.ToUpper();
        //xrl_TenCongTy.Text = filter.CompanyName.ToUpper();

        //DataTable table = DataHandler.GetInstance().ExecuteDataTable("TienLuong_BangThanhToanLuongThang", "@idBangLuong", filter.IDBangLuong);
        //DataSource = table;
        //xrt_hovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        //xrt_heso.DataBindings.Add("Text", DataSource, "HsLuong");
        //xrt_socong.DataBindings.Add("Text", DataSource, "SoCong");
        //xrt_thanhtien.Text = "";// chưa có
        ////    xrt_socong100.DataBindings.Add("Text", DataSource, "TGIO");
        ////  xrt_socong150.DataBindings.Add("Text", DataSource, "TGIO_CN");
        ////       xrt_thanhtienlamthem.Text = "";//chưa có
        //xrt_phuCapAnCa.DataBindings.Add("Text", DataSource, "PhuCapAnCa");
        ////       xrt_trachnhiem.DataBindings.Add("Text", DataSource, "PhuCapTrachNhiem", "{0:0,0}");
        //xrt_tongthunhap.DataBindings.Add("Text", DataSource, "TongThuNhapNet", "{0:0,0}");
        //xrt_bhxh.DataBindings.Add("Text", DataSource, "GiamTruBHXH", "{0:0,0}");
        //xrt_bhyt.DataBindings.Add("Text", DataSource, "GiamTruBHYT", "{0:0,0}");
        //xrt_bhtn.DataBindings.Add("Text", DataSource, "GiamTruBHTN", "{0:0,0}");
        //xrt_thuclinh.DataBindings.Add("Text", DataSource, "ThucLinh", "{0:0,0}");

        ////DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongSoCong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "TONGCONG")});
        ////xrSummary1.FormatString = "{0:0,0}";
        ////xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongSoCong.Summary = xrSummary1;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongThuNhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "TongLuong")});
        ////xrSummary2.FormatString = "{0:0,0}";
        ////xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongThuNhap.Summary = xrSummary2;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongHeSo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "HS_LUONG")});
        ////xrSummary3.FormatString = "{0:0,0}";
        ////xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongHeSo.Summary = xrSummary3;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongLuuDong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "LuongKhac")});
        ////xrSummary4.FormatString = "{0:0,0}";
        ////xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongLuuDong.Summary = xrSummary4;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongTrachNhieem.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "PhuCapTrachNhiem")});
        ////xrSummary5.FormatString = "{0:0,0}";
        ////xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongTrachNhieem.Summary = xrSummary5;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongBHXH.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "GiamTruBHXH")});
        ////xrSummary6.FormatString = "{0:0,0}";
        ////xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongBHXH.Summary = xrSummary6;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongBHYT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "GiamTruBHYT")});
        ////xrSummary7.FormatString = "{0:0,0}";
        ////xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongBHYT.Summary = xrSummary7;
        //////
        ////DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        ////this.xrtTongBHTN.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
        ////    new DevExpress.XtraReports.UI.XRBinding("Text", null, "GiamTruBHTN")});
        ////xrSummary8.FormatString = "{0:0,0}";
        ////xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        ////this.xrtTongBHTN.Summary = xrSummary8;
        //// xử lý chỗ đọc số
        //long tongThucLinh = long.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("TienLuong_SUMTHUCLINH", "@idBangLuong", filter.IDBangLuong).ToString());
        //xrl_TongSoTien.Text += SoftCore.Util.GetInstance().FormatNumber(tongThucLinh.ToString(),".");
        //xrlDocSo.Text = "Số tiền viết bằng chữ : " + SoftCore.Util.GetInstance().DocTienBangChu(tongThucLinh, "đồng");

        //this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
        //    new DevExpress.XtraReports.UI.GroupField("TEN_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        //xrt_tenphong.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        //if (!string.IsNullOrEmpty(filter.ReportTitle))
        //{
        //    xrl_TitleBC.Text = filter.ReportTitle.ToUpper();
        //}
        //if (!string.IsNullOrEmpty(filter.Footer1))
        //{
        //    xrl_footer1.Text = filter.Footer1;
        //}
        //if (!string.IsNullOrEmpty(filter.Footer2))
        //{
        //    xrl_footer2.Text = filter.Footer2;
        //}
        //if (!string.IsNullOrEmpty(filter.Footer3))
        //{
        //    xrl_footer3.Text = filter.Footer3;
        //}

        //if (!string.IsNullOrEmpty(filter.Ten1))
        //{
        //    xrl_ten1.Text = filter.Ten1;
        //}
        //else
        //{
        //    //S xrl_ten1.Text = filter.NguoiLapBaoCao.ToString();
        //}
        //if (!string.IsNullOrEmpty(filter.Ten2))
        //{
        //    xrl_ten2.Text = filter.Ten2;
        //}
        //if (!string.IsNullOrEmpty(filter.Ten3))
        //{
        //    xrl_ten3.Text = filter.Ten3;
        //}

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
        string resourceFileName = "rp_BangThanhToanLuongThang.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_STT = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_heso = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_socong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_socong100 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_socong150 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thanhtienlamthem = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_phuCapAnCa = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_trachnhiem = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tongthunhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_bhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_bhyt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_bhtn = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thuclinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NgayBC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_TongSoTien = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlDocSo = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_tenphong = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
        this.Detail.HeightF = 27.08334F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTable8
        // 
        this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(1.999956F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(1081F, 27.08334F);
        this.xrTable8.StylePriority.UseBorders = false;
        this.xrTable8.StylePriority.UsePadding = false;
        this.xrTable8.StylePriority.UseTextAlignment = false;
        this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_STT,
            this.xrt_hovaten,
            this.xrt_heso,
            this.xrt_socong,
            this.xrt_thanhtien,
            this.xrt_socong100,
            this.xrt_socong150,
            this.xrt_thanhtienlamthem,
            this.xrt_phuCapAnCa,
            this.xrt_trachnhiem,
            this.xrt_tongthunhap,
            this.xrt_bhxh,
            this.xrt_bhyt,
            this.xrt_bhtn,
            this.xrTableCell39,
            this.xrt_thuclinh});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrt_STT
        // 
        this.xrt_STT.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_STT.Name = "xrt_STT";
        this.xrt_STT.StylePriority.UseFont = false;
        this.xrt_STT.StylePriority.UseTextAlignment = false;
        this.xrt_STT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_STT.Weight = 0.36458339909319831D;
        // 
        // xrt_hovaten
        // 
        this.xrt_hovaten.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_hovaten.Name = "xrt_hovaten";
        this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hovaten.StylePriority.UseFont = false;
        this.xrt_hovaten.StylePriority.UsePadding = false;
        this.xrt_hovaten.StylePriority.UseTextAlignment = false;
        this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hovaten.Weight = 1.2708331739439758D;
        // 
        // xrt_heso
        // 
        this.xrt_heso.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_heso.Name = "xrt_heso";
        this.xrt_heso.StylePriority.UseFont = false;
        this.xrt_heso.StylePriority.UseTextAlignment = false;
        this.xrt_heso.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_heso.Weight = 0.44791686483515275D;
        // 
        // xrt_socong
        // 
        this.xrt_socong.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_socong.Name = "xrt_socong";
        this.xrt_socong.StylePriority.UseFont = false;
        this.xrt_socong.StylePriority.UseTextAlignment = false;
        this.xrt_socong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_socong.Weight = 0.50988359187503762D;
        // 
        // xrt_thanhtien
        // 
        this.xrt_thanhtien.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_thanhtien.Name = "xrt_thanhtien";
        this.xrt_thanhtien.StylePriority.UseFont = false;
        this.xrt_thanhtien.StylePriority.UseTextAlignment = false;
        this.xrt_thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_thanhtien.Weight = 0.91029648128483309D;
        // 
        // xrt_socong100
        // 
        this.xrt_socong100.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_socong100.Name = "xrt_socong100";
        this.xrt_socong100.StylePriority.UseFont = false;
        this.xrt_socong100.StylePriority.UseTextAlignment = false;
        this.xrt_socong100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_socong100.Weight = 0.48971628432235165D;
        // 
        // xrt_socong150
        // 
        this.xrt_socong150.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_socong150.Name = "xrt_socong150";
        this.xrt_socong150.StylePriority.UseFont = false;
        this.xrt_socong150.StylePriority.UseTextAlignment = false;
        this.xrt_socong150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_socong150.Weight = 0.4697462506326594D;
        // 
        // xrt_thanhtienlamthem
        // 
        this.xrt_thanhtienlamthem.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_thanhtienlamthem.Name = "xrt_thanhtienlamthem";
        this.xrt_thanhtienlamthem.StylePriority.UseFont = false;
        this.xrt_thanhtienlamthem.StylePriority.UseTextAlignment = false;
        this.xrt_thanhtienlamthem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_thanhtienlamthem.Weight = 0.62313457979486875D;
        // 
        // xrt_phuCapAnCa
        // 
        this.xrt_phuCapAnCa.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_phuCapAnCa.Name = "xrt_phuCapAnCa";
        this.xrt_phuCapAnCa.StylePriority.UseFont = false;
        this.xrt_phuCapAnCa.StylePriority.UseTextAlignment = false;
        this.xrt_phuCapAnCa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_phuCapAnCa.Weight = 0.83011166401998959D;
        // 
        // xrt_trachnhiem
        // 
        this.xrt_trachnhiem.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_trachnhiem.Name = "xrt_trachnhiem";
        this.xrt_trachnhiem.StylePriority.UseFont = false;
        this.xrt_trachnhiem.StylePriority.UseTextAlignment = false;
        this.xrt_trachnhiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_trachnhiem.Weight = 0.6333269754504055D;
        // 
        // xrt_tongthunhap
        // 
        this.xrt_tongthunhap.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_tongthunhap.Name = "xrt_tongthunhap";
        this.xrt_tongthunhap.StylePriority.UseFont = false;
        this.xrt_tongthunhap.StylePriority.UseTextAlignment = false;
        this.xrt_tongthunhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_tongthunhap.Weight = 0.91694649232172187D;
        // 
        // xrt_bhxh
        // 
        this.xrt_bhxh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_bhxh.Name = "xrt_bhxh";
        this.xrt_bhxh.StylePriority.UseFont = false;
        this.xrt_bhxh.StylePriority.UseTextAlignment = false;
        this.xrt_bhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_bhxh.Weight = 0.5200082961021647D;
        // 
        // xrt_bhyt
        // 
        this.xrt_bhyt.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_bhyt.Name = "xrt_bhyt";
        this.xrt_bhyt.StylePriority.UseFont = false;
        this.xrt_bhyt.StylePriority.UseTextAlignment = false;
        this.xrt_bhyt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_bhyt.Weight = 0.55052362006159239D;
        // 
        // xrt_bhtn
        // 
        this.xrt_bhtn.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_bhtn.Name = "xrt_bhtn";
        this.xrt_bhtn.StylePriority.UseFont = false;
        this.xrt_bhtn.StylePriority.UseTextAlignment = false;
        this.xrt_bhtn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_bhtn.Weight = 0.51659515036104386D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseFont = false;
        this.xrTableCell39.StylePriority.UseTextAlignment = false;
        this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell39.Weight = 0.53678698520364643D;
        // 
        // xrt_thuclinh
        // 
        this.xrt_thuclinh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrt_thuclinh.Name = "xrt_thuclinh";
        this.xrt_thuclinh.StylePriority.UseFont = false;
        this.xrt_thuclinh.StylePriority.UseTextAlignment = false;
        this.xrt_thuclinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrt_thuclinh.Weight = 0.88809055004349347D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 48F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 50F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 66.66667F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(1.999958F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1081F, 66.66667F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell15,
            this.xrTableCell17});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.36458332513889169D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Họ và tên";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 1.2708333949845452D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "Hệ số lương";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.44791656901791382D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Lương TT100%";
        this.xrTableCell5.Weight = 1.4201805168857291D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(1.525879E-05F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(146.5109F, 25F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "Lương TT100%";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 3D;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(1.525879E-05F, 25F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(146.5109F, 41.66664F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell11});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.StylePriority.UseFont = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "Số công";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 0.35416676088647503D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.StylePriority.UseFont = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "Thành tiền";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 0.63229548242984934D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable5});
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Lương làm thêm";
        this.xrTableCell6.Weight = 1.5825972256813443D;
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 25F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(163.2664F, 41.66667F);
        this.xrTable4.StylePriority.UseBorders = false;
        this.xrTable4.StylePriority.UseFont = false;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrTableCell13,
            this.xrTableCell14});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.StylePriority.UseFont = false;
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.Text = "Số công 100%";
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell16.Weight = 0.33680565618238179D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "Số công 150%";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 0.32307132054584D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.StylePriority.UseFont = false;
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "Thành tiền";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell14.Weight = 0.42856571798974047D;
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(163.2664F, 25F);
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell18});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseBorders = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.Text = "Lương làm thêm";
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell18.Weight = 3D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "Phụ cấp ăn";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.830111848905764D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "Trách nhiệm";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.63332649474739222D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "Tổng thu nhập";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 0.91694726884197408D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7,
            this.xrTable6});
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Các khoản trừ";
        this.xrTableCell15.Weight = 2.1239124974761991D;
        // 
        // xrTable7
        // 
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(219.1106F, 25F);
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseBorders = false;
        this.xrTableCell22.StylePriority.UseTextAlignment = false;
        this.xrTableCell22.Text = "Các khoản trừ";
        this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell22.Weight = 3D;
        // 
        // xrTable6
        // 
        this.xrTable6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(219.1105F, 41.66667F);
        this.xrTable6.StylePriority.UseBorders = false;
        this.xrTable6.StylePriority.UseFont = false;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell23});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.StylePriority.UseFont = false;
        this.xrTableCell19.StylePriority.UseTextAlignment = false;
        this.xrTableCell19.Text = "BHXH 7%";
        this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell19.Weight = 0.35763884401548457D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.StylePriority.UseFont = false;
        this.xrTableCell20.StylePriority.UseTextAlignment = false;
        this.xrTableCell20.Text = "BHYT 1,5%";
        this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell20.Weight = 0.37862681705262768D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseBorders = false;
        this.xrTableCell21.StylePriority.UseFont = false;
        this.xrTableCell21.StylePriority.UseTextAlignment = false;
        this.xrTableCell21.Text = "BHTN 1%";
        this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell21.Weight = 0.35529224487303296D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.StylePriority.UseFont = false;
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.Text = "Thuế";
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell23.Weight = 0.36917939983411852D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.Text = "Thực lĩnh";
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.88809018148368879D;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TitleBC,
            this.xrl_NgayBC,
            this.xrLabel2,
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy,
            this.xrLabel1});
        this.ReportHeader.HeightF = 126F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1081F, 23F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "BẢNG THANH TOÁN LƯƠNG THÁNG  ";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_NgayBC
        // 
        this.xrl_NgayBC.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_NgayBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 93F);
        this.xrl_NgayBC.Name = "xrl_NgayBC";
        this.xrl_NgayBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NgayBC.SizeF = new System.Drawing.SizeF(1081F, 23F);
        this.xrl_NgayBC.StylePriority.UseFont = false;
        this.xrl_NgayBC.StylePriority.UseTextAlignment = false;
        this.xrl_NgayBC.Text = "Từ ngày 1/2/2013  đến ngày 28/2/2013";
        this.xrl_NgayBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(725F, 25F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Độc lập - Tự do - Hạnh phúc";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(486.3751F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(486.3751F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(725F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TongSoTien,
            this.xrlDocSo,
            this.xrl_ten3,
            this.xrl_ten2,
            this.xrl_ten1,
            this.xrtngayketxuat,
            this.xrl_footer1,
            this.xrl_footer2,
            this.xrl_footer3});
        this.ReportFooter.HeightF = 233F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_TongSoTien
        // 
        this.xrl_TongSoTien.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        this.xrl_TongSoTien.LocationFloat = new DevExpress.Utils.PointFloat(10.95825F, 10.00001F);
        this.xrl_TongSoTien.Name = "xrl_TongSoTien";
        this.xrl_TongSoTien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TongSoTien.SizeF = new System.Drawing.SizeF(1071F, 23F);
        this.xrl_TongSoTien.StylePriority.UseFont = false;
        this.xrl_TongSoTien.Text = "Tổng số tiền : ";
        // 
        // xrlDocSo
        // 
        this.xrlDocSo.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        this.xrlDocSo.LocationFloat = new DevExpress.Utils.PointFloat(9.999959F, 44.37497F);
        this.xrlDocSo.Name = "xrlDocSo";
        this.xrlDocSo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlDocSo.SizeF = new System.Drawing.SizeF(1071F, 23F);
        this.xrlDocSo.StylePriority.UseFont = false;
        this.xrlDocSo.Text = "Bằng chữ là: ";
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(748.6254F, 200F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(333.3329F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(388.4583F, 200F);
        this.xrl_ten2.Name = "xrl_ten2";
        this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten2.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
        this.xrl_ten2.StylePriority.UseFont = false;
        this.xrl_ten2.StylePriority.UseTextAlignment = false;
        this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(0.9583156F, 200F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(748.6254F, 72.50004F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(333.3329F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày.......tháng.......năm......";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(0.958244F, 97.50004F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "Người lập biểu";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(388.4583F, 97.50004F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(333.3333F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "Kế toán trưởng";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(748.6254F, 97.50004F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(333.3329F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "Giám đốc";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10});
        this.GroupHeader1.HeightF = 27.08334F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable10
        // 
        this.xrTable10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(1.999966F, 0F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable10.SizeF = new System.Drawing.SizeF(1081F, 27.08334F);
        this.xrTable10.StylePriority.UseBorders = false;
        this.xrTable10.StylePriority.UsePadding = false;
        this.xrTable10.StylePriority.UseTextAlignment = false;
        this.xrTable10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_tenphong});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrt_tenphong
        // 
        this.xrt_tenphong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrt_tenphong.Name = "xrt_tenphong";
        this.xrt_tenphong.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 3, 3, 3, 100F);
        this.xrt_tenphong.StylePriority.UseFont = false;
        this.xrt_tenphong.StylePriority.UsePadding = false;
        this.xrt_tenphong.StylePriority.UseTextAlignment = false;
        this.xrt_tenphong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_tenphong.Weight = 10.478500359346135D;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
        this.PageFooter.HeightF = 49F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrPageInfo1.Format = "Trang {0} của {1}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(956.9583F, 9.999974F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // rp_BangThanhToanLuongThang
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader,
            this.ReportFooter,
            this.GroupHeader1,
            this.PageFooter});
        this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(3, 14, 48, 50);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
