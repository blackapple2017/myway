using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_NhanVienTraLuongQuaTaiKhoanNganHang
/// </summary>
public class rp_NhanVienTraLuongQuaTaiKhoanNganHang : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private GroupFooterBand GroupFooter1;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrlCompanyName;
    private XRLabel xlrTK;
    private XRLabel xrl_Title;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xr_detailStt;
    private XRTableCell xr_detailHovaten;
    private XRTableCell xr_detailSotien;
    private XRTableCell xr_detailSotaikhoan;
    private XRTableCell xr_detailtainganhnag;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell11;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell9;
    private XRTable xrTable6;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell15;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRLabel xrLabel5;
    private XRLabel xlrAddress;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_NhanVienTraLuongQuaTaiKhoanNganHang()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xr_detailStt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    {
        ////  DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_NhanVienChuaCoBHYT", "@MaDonVi", "@MaPhongBan", "@MaTrinhDo", "@MaChucVu", filter.MaDonVi, filter.MaPhongBan, filter.MaTrinhDo, filter.MaChucVu);
        //DataTable table = DataHandler.GetInstance().ExecuteDataTable("TienLuong_ThanhToanQuaNganHang", "@IdBangLuong", filter.IDBangLuong);
        //DataSource = table;
        //xr_detailHovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        //xr_detailSotaikhoan.DataBindings.Add("Text", DataSource, "SO_TAI_KHOAN");
        //xr_detailtainganhnag.DataBindings.Add("Text", DataSource, "TEN_NH");
        //xr_detailSotien.DataBindings.Add("Text", DataSource, "ATM", "{0:n0}");
        //// long money = long.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("TienLuong_TongSoTienATM", "@IdBangLuong", filter.IDBangLuong).ToString().Replace(",", "."));
        //xrTableCell8.Text = DataController.DataHandler.GetInstance().ExecuteScalar("TienLuong_TongSoTienATM", "@IdBangLuong", filter.IDBangLuong).ToString();// money + " (" + SoftCore.Util.GetInstance().DocTienBangChu(money, "đồng") + ")";

        //DAL.DanhSachBangLuong salaryBoard = new DanhSachBangLuongController().GetByID(filter.IDBangLuong);
        //xrl_Title.Text += salaryBoard.Month + " NĂM " + salaryBoard.Year;
        //DAL.DM_DONVI dv = new DM_DONVIController().GetById(filter.SessionDepartmentID);
        //xrlCompanyName.Text = dv.TEN_DONVI.ToUpper();
        //xlrTK.Text += dv.SO_TAI_KHOAN;
        //xlrAddress.Text = dv.DIA_CHI; 
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
        string resourceFileName = "rp_NhanVienTraLuongQuaTaiKhoanNganHang.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xr_detailStt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xr_detailHovaten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xr_detailSotien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xr_detailSotaikhoan = new DevExpress.XtraReports.UI.XRTableCell();
        this.xr_detailtainganhnag = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xlrTK = new DevExpress.XtraReports.UI.XRLabel();
        this.xlrAddress = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlCompanyName = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_Title = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 34.375F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1075F, 34.375F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xr_detailStt,
            this.xr_detailHovaten,
            this.xr_detailSotien,
            this.xr_detailSotaikhoan,
            this.xr_detailtainganhnag});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xr_detailStt
        // 
        this.xr_detailStt.Name = "xr_detailStt";
        this.xr_detailStt.Weight = 0.49479171752929685D;
        this.xr_detailStt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xr_detailHovaten
        // 
        this.xr_detailHovaten.Name = "xr_detailHovaten";
        this.xr_detailHovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
        this.xr_detailHovaten.StylePriority.UsePadding = false;
        this.xr_detailHovaten.StylePriority.UseTextAlignment = false;
        this.xr_detailHovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xr_detailHovaten.Weight = 3.1302085876464849D;
        // 
        // xr_detailSotien
        // 
        this.xr_detailSotien.Name = "xr_detailSotien";
        this.xr_detailSotien.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 100F);
        this.xr_detailSotien.StylePriority.UsePadding = false;
        this.xr_detailSotien.StylePriority.UseTextAlignment = false;
        this.xr_detailSotien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xr_detailSotien.Weight = 1.6354165649414059D;
        // 
        // xr_detailSotaikhoan
        // 
        this.xr_detailSotaikhoan.Name = "xr_detailSotaikhoan";
        this.xr_detailSotaikhoan.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xr_detailSotaikhoan.StylePriority.UsePadding = false;
        this.xr_detailSotaikhoan.StylePriority.UseTextAlignment = false;
        this.xr_detailSotaikhoan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xr_detailSotaikhoan.Weight = 2.3177081298828126D;
        // 
        // xr_detailtainganhnag
        // 
        this.xr_detailtainganhnag.Name = "xr_detailtainganhnag";
        this.xr_detailtainganhnag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xr_detailtainganhnag.StylePriority.UsePadding = false;
        this.xr_detailtainganhnag.StylePriority.UseTextAlignment = false;
        this.xr_detailtainganhnag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xr_detailtainganhnag.Weight = 3.171875D;
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
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xlrTK,
            this.xlrAddress,
            this.xrlCompanyName,
            this.xrl_Title});
        this.ReportHeader.HeightF = 126F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xlrTK
        // 
        this.xlrTK.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xlrTK.LocationFloat = new DevExpress.Utils.PointFloat(0F, 58.00002F);
        this.xlrTK.Name = "xlrTK";
        this.xlrTK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xlrTK.SizeF = new System.Drawing.SizeF(1075F, 23F);
        this.xlrTK.StylePriority.UseFont = false;
        this.xlrTK.StylePriority.UseTextAlignment = false;
        this.xlrTK.Text = "SỐ TK: ";
        this.xlrTK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xlrAddress
        // 
        this.xlrAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xlrAddress.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.00001F);
        this.xlrAddress.Name = "xlrAddress";
        this.xlrAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xlrAddress.SizeF = new System.Drawing.SizeF(1075F, 23F);
        this.xlrAddress.StylePriority.UseFont = false;
        this.xlrAddress.StylePriority.UseTextAlignment = false;
        this.xlrAddress.Text = "TẦNG 7, ĐÊ LA THÀNH - ĐỐNG ĐA - HÀ NỘI";
        this.xlrAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrlCompanyName
        // 
        this.xrlCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrlCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
        this.xrlCompanyName.Name = "xrlCompanyName";
        this.xrlCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlCompanyName.SizeF = new System.Drawing.SizeF(1075F, 23F);
        this.xrlCompanyName.StylePriority.UseFont = false;
        this.xrlCompanyName.StylePriority.UseTextAlignment = false;
        this.xrlCompanyName.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrlCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_Title
        // 
        this.xrl_Title.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_Title.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.00001F);
        this.xrl_Title.Name = "xrl_Title";
        this.xrl_Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_Title.SizeF = new System.Drawing.SizeF(1075F, 33.00001F);
        this.xrl_Title.StylePriority.UseFont = false;
        this.xrl_Title.StylePriority.UseTextAlignment = false;
        this.xrl_Title.Text = "DANH SÁCH ĐỔ LƯƠNG THÁNG ";
        this.xrl_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 34.375F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1075F, 34.375F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell5,
            this.xrTableCell3});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "STT";
        this.xrTableCell4.Weight = 0.49479171752929685D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Họ và tên";
        this.xrTableCell1.Weight = 3.1302085876464849D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Số tiền (VNĐ)";
        this.xrTableCell2.Weight = 1.6354165649414059D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Số tài khoản ";
        this.xrTableCell5.Weight = 2.3177081298828126D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Tại ngân hàng";
        this.xrTableCell3.Weight = 3.171875D;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.GroupFooter1.HeightF = 34.375F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1075F, 34.375F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Weight = 0.49479171752929685D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
        this.xrTableCell7.StylePriority.UsePadding = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "TỔNG CỘNG";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell7.Weight = 3.1302085876464849D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
        this.xrTableCell8.StylePriority.UsePadding = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "483.000.000";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell8.Weight = 7.1249996948242185D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable4});
        this.ReportFooter.HeightF = 188F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrTable6
        // 
        this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(765.0001F, 21.875F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8,
            this.xrTableRow9});
        this.xrTable6.SizeF = new System.Drawing.SizeF(300F, 105.2083F);
        this.xrTable6.StylePriority.UseFont = false;
        this.xrTable6.StylePriority.UseTextAlignment = false;
        this.xrTable6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell15});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Người yêu cầu";
        this.xrTableCell15.Weight = 3D;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrTableCell17});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Text = "Kế toán trưởng";
        this.xrTableCell16.Weight = 1.4479168701171874D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Multiline = true;
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Text = "Giám đốc";
        this.xrTableCell17.Weight = 1.5520831298828126D;
        // 
        // xrTable4
        // 
        this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 21.875F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5,
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(300F, 105.2083F);
        this.xrTable4.StylePriority.UseFont = false;
        this.xrTable4.StylePriority.UseTextAlignment = false;
        this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Xác nhận của ngân hàng";
        this.xrTableCell12.Weight = 3D;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell11});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Giao dịch viên";
        this.xrTableCell9.Weight = 1.3958334350585937D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Multiline = true;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Kiểm soát\r\n";
        this.xrTableCell11.Weight = 1.6041665649414063D;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5});
        this.PageFooter.HeightF = 56F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrLabel5
        // 
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(894.7917F, 10.00001F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(146.875F, 33.33333F);
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Trang 1/2";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // rp_NhanVienTraLuongQuaTaiKhoanNganHang
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupFooter1,
            this.ReportFooter,
            this.PageFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(11, 14, 50, 100);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
