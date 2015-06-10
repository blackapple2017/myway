using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rpwg_BangNhanXetCBNVSauThuViec
/// </summary>
public class rpwg_BangNhanXetCBNVSauThuViec : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrlReportTitle;
    private XRLabel xrlBoPhan;
    private XRLabel xrlTenCongTy;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLine xrLine1;
    private XRLabel xrLabel6;
    private XRLabel xrlHoTen;
    private XRLabel xrLabel8;
    private XRLabel xrlPhongBan;
    private XRLabel xrlChucVu;
    private XRLabel xrLabel10;
    private XRLabel xrlNgaySinh;
    private XRLabel xrLabel12;
    private XRLabel xrlQueQuan;
    private XRLabel xrLabel14;
    private XRLabel xrlDiem;
    private XRLabel xrLabel28;
    private XRLabel xrlNgayVao;
    private XRLabel xrLabel26;
    private XRLabel xrlChuyenNganh;
    private XRLabel xrLabel24;
    private XRLabel xrlTrinhDo;
    private XRLabel xrLabel22;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrtchatluonglamviec;
    private XRTableCell xrtkyhopdongct;
    private XRTableCell xrtcanbonhanxet;
    private XRTableCell xrtchaphanhkyluat;
    private XRTableCell xrtnhanxet;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel15;
    private XRLabel xrlNguoiKy;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_BangNhanXetCBNVSauThuViec()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrtstt.Text = STT.ToString();
        STT++;
    }

    public void BindData(ReportFilterEmployeeProfile filter)
    {
        try
        {
            //xrlTenCongTy.Text = filter.CompanyName.ToUpper();
            //string tenBoPhan = new DM_DONVIController().GetNameById(filter.MaBoPhan);
            //if (!string.IsNullOrEmpty(tenBoPhan))
            //{
            //    xrlBoPhan.Text = tenBoPhan;
            //}
            if (!string.IsNullOrEmpty(filter.ReportTitle))
            {
                xrlReportTitle.Text = filter.ReportTitle;
            }
            DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("WG_NhanXetCanBoSauThuViec", "@MaCB", filter.MaCB);
            // bind data for employee
            if (data.Rows.Count > 0)
            {
                DataRow item = data.Rows[0];
                xrlHoTen.Text = item["HO_TEN"].ToString();
                xrlPhongBan.Text = item["TEN_DONVI"].ToString();
                xrlChucVu.Text = item["TEN_CHUCVU"].ToString();
                xrlNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", item["NGAY_SINH"].ToString());
                xrlQueQuan.Text = item["QueQuan"].ToString();
                xrlTrinhDo.Text = item["TEN_TRINHDO"].ToString();
                xrlChuyenNganh.Text = item["TEN_CHUYENNGANH"].ToString();
                xrlNgayVao.Text = string.Format("{0:dd/MM/yyyy}", item["NGAY_TUYEN_DTIEN"].ToString());
            }
            // bind số dòng nhận xét phía dưới
            DataTable table = CreateDataTable(4);
            DataSource = table;
            xrtcanbonhanxet.DataBindings.Add("Text", DataSource, "HoTen");
            xrtchatluonglamviec.DataBindings.Add("Text", DataSource, "ChatLuong");
            xrtchaphanhkyluat.DataBindings.Add("Text", DataSource, "YThuc");
            xrtkyhopdongct.DataBindings.Add("Text", DataSource, "DeXuatHD");
            xrtnhanxet.DataBindings.Add("Text", DataSource, "NhanXet");

            // Footer
            if (!string.IsNullOrEmpty(filter.Ten1))
                xrlNguoiKy.Text = filter.Ten1;
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }

    private DataTable CreateDataTable(int numberRow)
    {
        DataTable table = new DataTable();
        for (int i = 0; i < numberRow; i++)
        {
            DataRow dr = table.NewRow();
            dr["HoTen"] = "";
            dr["ChatLuong"] = "";
            dr["YThuc"] = "";
            dr["DeXuatHD"] = "";
            dr["NhanXet"] = "";

            table.Rows.Add(dr);
        }
        return table;
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
            string resourceFileName = "rpwg_BangNhanXetCBNVSauThuViec.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcanbonhanxet = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtchatluonglamviec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtchaphanhkyluat = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtkyhopdongct = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtnhanxet = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrlDiem = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNgayVao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlChuyenNganh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlTrinhDo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlQueQuan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNgaySinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlChucVu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPhongBan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlHoTen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlReportTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlBoPhan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlTenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlNguoiKy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1103F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtcanbonhanxet,
            this.xrtchatluonglamviec,
            this.xrtchaphanhkyluat,
            this.xrtkyhopdongct,
            this.xrtnhanxet});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrtstt
            // 
            this.xrtstt.Name = "xrtstt";
            this.xrtstt.Weight = 0.10618756690766801D;
            this.xrtstt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrtcanbonhanxet
            // 
            this.xrtcanbonhanxet.Name = "xrtcanbonhanxet";
            this.xrtcanbonhanxet.Weight = 0.60199463565541111D;
            // 
            // xrtchatluonglamviec
            // 
            this.xrtchatluonglamviec.Name = "xrtchatluonglamviec";
            this.xrtchatluonglamviec.Weight = 0.67565709375390459D;
            // 
            // xrtchaphanhkyluat
            // 
            this.xrtchaphanhkyluat.Name = "xrtchaphanhkyluat";
            this.xrtchaphanhkyluat.Weight = 0.57456997591683634D;
            // 
            // xrtkyhopdongct
            // 
            this.xrtkyhopdongct.Name = "xrtkyhopdongct";
            this.xrtkyhopdongct.Weight = 0.66341774245546D;
            // 
            // xrtnhanxet
            // 
            this.xrtnhanxet.Name = "xrtnhanxet";
            this.xrtnhanxet.Weight = 0.37817298531071997D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 61F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 40F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlDiem,
            this.xrLabel28,
            this.xrlNgayVao,
            this.xrLabel26,
            this.xrlChuyenNganh,
            this.xrLabel24,
            this.xrlTrinhDo,
            this.xrLabel22,
            this.xrlQueQuan,
            this.xrLabel14,
            this.xrlNgaySinh,
            this.xrLabel12,
            this.xrlChucVu,
            this.xrLabel10,
            this.xrlPhongBan,
            this.xrLabel8,
            this.xrlHoTen,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrlReportTitle,
            this.xrlBoPhan,
            this.xrlTenCongTy,
            this.xrLine1});
            this.ReportHeader.HeightF = 209F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrlDiem
            // 
            this.xrlDiem.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlDiem.LocationFloat = new DevExpress.Utils.PointFloat(997.0864F, 162.5833F);
            this.xrlDiem.Name = "xrlDiem";
            this.xrlDiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlDiem.SizeF = new System.Drawing.SizeF(105.9136F, 23F);
            this.xrlDiem.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlDiem.StylePriority.UseFont = false;
            this.xrlDiem.StylePriority.UseTextAlignment = false;
            this.xrlDiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(846.4583F, 162.5833F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(149.6281F, 23F);
            this.xrLabel28.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Điểm kiểm tra nội quy:";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlNgayVao
            // 
            this.xrlNgayVao.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlNgayVao.LocationFloat = new DevExpress.Utils.PointFloat(720.0416F, 162.5833F);
            this.xrlNgayVao.Name = "xrlNgayVao";
            this.xrlNgayVao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNgayVao.SizeF = new System.Drawing.SizeF(126.4166F, 23F);
            this.xrlNgayVao.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlNgayVao.StylePriority.UseFont = false;
            this.xrlNgayVao.StylePriority.UseTextAlignment = false;
            this.xrlNgayVao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(621.875F, 162.5833F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(98.16663F, 23F);
            this.xrLabel26.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "Ngày vào làm:";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlChuyenNganh
            // 
            this.xrlChuyenNganh.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlChuyenNganh.LocationFloat = new DevExpress.Utils.PointFloat(423.625F, 162.5833F);
            this.xrlChuyenNganh.Name = "xrlChuyenNganh";
            this.xrlChuyenNganh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlChuyenNganh.SizeF = new System.Drawing.SizeF(197.2466F, 23F);
            this.xrlChuyenNganh.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlChuyenNganh.StylePriority.UseFont = false;
            this.xrlChuyenNganh.StylePriority.UseTextAlignment = false;
            this.xrlChuyenNganh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(322.5416F, 162.5833F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel24.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Chuyên ngành:";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlTrinhDo
            // 
            this.xrlTrinhDo.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlTrinhDo.LocationFloat = new DevExpress.Utils.PointFloat(64F, 162.5833F);
            this.xrlTrinhDo.Name = "xrlTrinhDo";
            this.xrlTrinhDo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTrinhDo.SizeF = new System.Drawing.SizeF(258.29F, 23F);
            this.xrlTrinhDo.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlTrinhDo.StylePriority.UseFont = false;
            this.xrlTrinhDo.StylePriority.UseTextAlignment = false;
            this.xrlTrinhDo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162.5833F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(63F, 23F);
            this.xrLabel22.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Trình độ:";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlQueQuan
            // 
            this.xrlQueQuan.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlQueQuan.LocationFloat = new DevExpress.Utils.PointFloat(72.87502F, 139.5833F);
            this.xrlQueQuan.Name = "xrlQueQuan";
            this.xrlQueQuan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlQueQuan.SizeF = new System.Drawing.SizeF(1030.125F, 23F);
            this.xrlQueQuan.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlQueQuan.StylePriority.UseFont = false;
            this.xrlQueQuan.StylePriority.UseTextAlignment = false;
            this.xrlQueQuan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 139.5833F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(71.875F, 23F);
            this.xrLabel14.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Quê quán:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlNgaySinh
            // 
            this.xrlNgaySinh.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlNgaySinh.LocationFloat = new DevExpress.Utils.PointFloat(922.9199F, 115.5833F);
            this.xrlNgaySinh.Name = "xrlNgaySinh";
            this.xrlNgaySinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNgaySinh.SizeF = new System.Drawing.SizeF(180.08F, 23F);
            this.xrlNgaySinh.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlNgaySinh.StylePriority.UseFont = false;
            this.xrlNgaySinh.StylePriority.UseTextAlignment = false;
            this.xrlNgaySinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(846.4583F, 115.5833F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(76.45837F, 23F);
            this.xrLabel12.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Sinh ngày:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlChucVu
            // 
            this.xrlChucVu.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlChucVu.LocationFloat = new DevExpress.Utils.PointFloat(687.5001F, 115.5833F);
            this.xrlChucVu.Name = "xrlChucVu";
            this.xrlChucVu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlChucVu.SizeF = new System.Drawing.SizeF(158.9583F, 23F);
            this.xrlChucVu.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlChucVu.StylePriority.UseFont = false;
            this.xrlChucVu.StylePriority.UseTextAlignment = false;
            this.xrlChucVu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(621.8751F, 115.5833F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(65.625F, 23F);
            this.xrLabel10.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Chức vụ:";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlPhongBan
            // 
            this.xrlPhongBan.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlPhongBan.LocationFloat = new DevExpress.Utils.PointFloat(382.5417F, 115.5833F);
            this.xrlPhongBan.Name = "xrlPhongBan";
            this.xrlPhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPhongBan.SizeF = new System.Drawing.SizeF(238.33F, 23F);
            this.xrlPhongBan.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlPhongBan.StylePriority.UseFont = false;
            this.xrlPhongBan.StylePriority.UseTextAlignment = false;
            this.xrlPhongBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(322.5416F, 115.5833F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(60F, 23F);
            this.xrLabel8.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Bộ phận:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlHoTen
            // 
            this.xrlHoTen.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlHoTen.LocationFloat = new DevExpress.Utils.PointFloat(52F, 115.5833F);
            this.xrlHoTen.Name = "xrlHoTen";
            this.xrlHoTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlHoTen.SizeF = new System.Drawing.SizeF(270.29F, 23F);
            this.xrlHoTen.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrlHoTen.StylePriority.UseFont = false;
            this.xrlHoTen.StylePriority.UseTextAlignment = false;
            this.xrlHoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115.5833F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(51.04167F, 23F);
            this.xrLabel6.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Họ tên:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(638.5417F, 25F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(464.4581F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Độc lập - Tự do - Hạnh phúc";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(638.5417F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(464.4582F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlReportTitle
            // 
            this.xrlReportTitle.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrlReportTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.xrlReportTitle.Name = "xrlReportTitle";
            this.xrlReportTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlReportTitle.SizeF = new System.Drawing.SizeF(1103F, 23F);
            this.xrlReportTitle.StylePriority.UseFont = false;
            this.xrlReportTitle.StylePriority.UseTextAlignment = false;
            this.xrlReportTitle.Text = "BẢNG NHẬN XÉT CBNV SAU THỜI GIAN THỬ VIỆC";
            this.xrlReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlBoPhan
            // 
            this.xrlBoPhan.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrlBoPhan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrlBoPhan.Name = "xrlBoPhan";
            this.xrlBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlBoPhan.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
            this.xrlBoPhan.StylePriority.UseFont = false;
            this.xrlBoPhan.StylePriority.UseTextAlignment = false;
            this.xrlBoPhan.Text = "BAN HCNS";
            this.xrlBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlTenCongTy
            // 
            this.xrlTenCongTy.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrlTenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrlTenCongTy.Name = "xrlTenCongTy";
            this.xrlTenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTenCongTy.SizeF = new System.Drawing.SizeF(351.0417F, 23F);
            this.xrlTenCongTy.StylePriority.UseFont = false;
            this.xrlTenCongTy.StylePriority.UseTextAlignment = false;
            this.xrlTenCongTy.Text = "CÔNG TY CỔ PHẦN THẾ GIỚI GIẢI TRÍ";
            this.xrlTenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(793.75F, 47.99998F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(156.25F, 10.49998F);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 58.33333F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(976.9586F, 35.33332F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0414F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 52.08333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1103F, 52.08333F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell4,
            this.xrTableCell2,
            this.xrTableCell6,
            this.xrTableCell3,
            this.xrTableCell5});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "TT";
            this.xrTableCell1.Weight = 0.10618752540596144D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ tên CB nhận xét";
            this.xrTableCell4.Weight = 0.60199459415370438D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Chất lượng làm việc";
            this.xrTableCell2.Weight = 0.675657259760731D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Ý thức chấp hành kỷ luật";
            this.xrTableCell6.Weight = 0.57456997591683634D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Đề xuất với TGĐ tiếp nhận ký HĐ chính thức";
            this.xrTableCell3.Weight = 0.66341757644863364D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "CB nhận xét\r\n(Ký tên)";
            this.xrTableCell5.Weight = 0.37817306831413317D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlNguoiKy,
            this.xrLabel15});
            this.ReportFooter.HeightF = 133F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrlNguoiKy
            // 
            this.xrlNguoiKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrlNguoiKy.LocationFloat = new DevExpress.Utils.PointFloat(793.7499F, 110F);
            this.xrlNguoiKy.Name = "xrlNguoiKy";
            this.xrlNguoiKy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNguoiKy.SizeF = new System.Drawing.SizeF(281.1248F, 23F);
            this.xrlNguoiKy.StylePriority.UseFont = false;
            this.xrlNguoiKy.StylePriority.UseTextAlignment = false;
            this.xrlNguoiKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(793.75F, 20.41664F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(281.1248F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "XÉT DUYỆT CỦA LÃNH ĐẠO";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // rpwg_BangNhanXetCBNVSauThuViec
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageFooter,
            this.PageHeader,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(35, 31, 61, 40);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
