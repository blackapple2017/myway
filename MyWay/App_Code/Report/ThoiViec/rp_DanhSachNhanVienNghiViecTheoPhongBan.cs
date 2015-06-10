using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;

/// <summary>
/// Summary description for rp_DanhSachNhanVienNghiViecTheoPhongBan
/// </summary>
public class rp_DanhSachNhanVienNghiViecTheoPhongBan : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrt_tenbaocao;
    private XRLabel xrt_tungay;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private ReportFooterBand ReportFooter;
    private XRLabel xrl_ngayketxuat;
    private XRLabel xrl_footer2;
    private XRLabel xrl_ten2;
    private XRLabel xrl_footer3;
    private XRLabel xrl_ten1;
    private XRLabel xrl_footer1;
    private XRLabel xrl_ten3;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell4;
    private XRTableRow xrTableRow1;
    private XRTable xrTable1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable3;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell24;
    private XRTable xrTable4;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell25;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTable xrTable5;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRTable xrTable6;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell17;
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
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell71;
    private XRTableCell xrt_phongban;
    private XRTableCell xrt_maphongban;
    private XRTableCell xrt_nam;
    private XRTableCell xrt_nu;
    private XRTableCell xrt_tong;
    private XRTableCell xrt_saudaihoc;
    private XRTableCell xrt_daihoc;
    private XRTableCell xrt_caodang;
    private XRTableCell xrt_trungcap;
    private XRTableCell xrt_ptth;
    private XRTableCell xrt_khac;
    private XRTableCell xrt_tongTrinhDo;
    private XRTableCell xrt_duoi6thang;
    private XRTableCell xrt_tu6thang1nam;
    private XRTableCell xrt_tu1den3nam;
    private XRTableCell xrt_tren3nam;
    private XRTableCell xrt_tongthamnien;
    private XRTableCell xrt_thuviec;
    private XRTableCell xrt_chinhthuc;
    private XRTableCell xrt_tonghopdong;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DanhSachNhanVienNghiViecTheoPhongBan()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    private void XtraReport1_BeforePrint(object sender, PrintEventArgs e)
    {
        // Create a new rule and add it to a report.
        FormattingRule rule = new FormattingRule();
        this.FormattingRuleSheet.Add(rule);

        // Specify the rule's properties.
        rule.DataSource = this.DataSource;
        rule.DataMember = this.DataMember;
        rule.Condition = "[Level] <=3";
        rule.Formatting.BackColor = Color.WhiteSmoke;
        rule.Formatting.ForeColor = Color.IndianRed;
        rule.Formatting.Font = new Font("Arial", 10, FontStyle.Bold);

        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule);
    }

    public void BinData(ReportFilter filter)
    {
        //xrt_tungay.Text = "Từ ngày " + Convert.ToDateTime(filter.TuNgay).ToString("dd/MM/yyyy") + " Đến ngày " + Convert.ToDateTime(filter.DenNgay).ToString("dd/MM/yyyy");
        //xrl_TenCongTy.Text = filter.TenDonVi;
        //xrl_TenThanhPho.Text = filter.TenThanhPho.ToUpper();
        BaoCaoThongKePhanTichController bcptc = new BaoCaoThongKePhanTichController();
        var bt = bcptc.ThongKeDanhSachCanBoNghiViec("01", true);
        if (bt!=null)
        {
            DataSource = bt;
            xrt_phongban.DataBindings.Add("Text", DataSource, "TenPhongBan");
            xrt_maphongban.DataBindings.Add("Text", DataSource, "MaPhongBan");
            xrt_nam.DataBindings.Add("Text", DataSource, "Nam");
            xrt_nu.DataBindings.Add("Text", DataSource, "Nu");
            xrt_tong.DataBindings.Add("Text", DataSource, "Tong");

            xrt_saudaihoc.DataBindings.Add("Text", DataSource, "SauDaiHoc");
            xrt_daihoc.DataBindings.Add("Text", DataSource, "DaiHoc");
            xrt_caodang.DataBindings.Add("Text", DataSource, "CaoDang");
            xrt_ptth.DataBindings.Add("Text", DataSource, "PTTH");
            xrt_khac.DataBindings.Add("Text", DataSource, "Khac");
            xrt_trungcap.DataBindings.Add("Text", DataSource, "TrungCap");
            xrt_tongTrinhDo.DataBindings.Add("Text", DataSource, "Tong");

            xrt_duoi6thang.DataBindings.Add("Text", DataSource, "Duoi6Thang");
            xrt_tu6thang1nam.DataBindings.Add("Text", DataSource, "Duoi1Nam");
            //xrt_d.DataBindings.Add("Text", DataSource, "Tong");
            xrt_tu1den3nam.DataBindings.Add("Text", DataSource, "Duoi3Nam");
            xrt_tren3nam.DataBindings.Add("Text", DataSource, "Tren3Nam");
            xrt_thuviec.DataBindings.Add("Text", DataSource, "HDThuViec");
            xrt_chinhthuc.DataBindings.Add("Text", DataSource, "HDChinhThuc");
            xrt_tonghopdong.DataBindings.Add("Text", DataSource, "Tong");
            xrt_tongthamnien.DataBindings.Add("Text", DataSource, "Tong");
        }
        xrl_ngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //if (!string.IsNullOrEmpty(filter.TenBaoCao))
        //{
        //    xrt_tenbaocao.Text = filter.TenBaoCao.ToUpper();
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
        //    xrl_ten1.Text = filter.NguoiLapBaoCao.ToString();
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
            string resourceFileName = "rp_DanhSachNhanVienNghiViecTheoPhongBan.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_maphongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_nam = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_nu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_saudaihoc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_daihoc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_caodang = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_trungcap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ptth = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_khac = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongTrinhDo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_duoi6thang = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tu6thang1nam = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tu1den3nam = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tren3nam = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongthamnien = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tonghopdong = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrt_tenbaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tungay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8});
            this.Detail.HeightF = 35.41666F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable8
            // 
            this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0.750041F, 0F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable8.SizeF = new System.Drawing.SizeF(1625.25F, 35.41666F);
            this.xrTable8.StylePriority.UseBorders = false;
            this.xrTable8.StylePriority.UseFont = false;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell71,
            this.xrt_phongban,
            this.xrt_maphongban,
            this.xrt_nam,
            this.xrt_nu,
            this.xrt_tong,
            this.xrt_saudaihoc,
            this.xrt_daihoc,
            this.xrt_caodang,
            this.xrt_trungcap,
            this.xrt_ptth,
            this.xrt_khac,
            this.xrt_tongTrinhDo,
            this.xrt_duoi6thang,
            this.xrt_tu6thang1nam,
            this.xrt_tu1den3nam,
            this.xrt_tren3nam,
            this.xrt_tongthamnien,
            this.xrt_thuviec,
            this.xrt_chinhthuc,
            this.xrt_tonghopdong});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell71.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseBorders = false;
            this.xrTableCell71.StylePriority.UseFont = false;
            this.xrTableCell71.Weight = 0.096985201270117144D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_phongban.StylePriority.UseFont = false;
            this.xrt_phongban.StylePriority.UsePadding = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_phongban.Weight = 0.27938013292426167D;
            // 
            // xrt_maphongban
            // 
            this.xrt_maphongban.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_maphongban.Name = "xrt_maphongban";
            this.xrt_maphongban.StylePriority.UseFont = false;
            this.xrt_maphongban.StylePriority.UseTextAlignment = false;
            this.xrt_maphongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_maphongban.Weight = 0.16893544744994166D;
            // 
            // xrt_nam
            // 
            this.xrt_nam.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_nam.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_nam.Name = "xrt_nam";
            this.xrt_nam.StylePriority.UseBorders = false;
            this.xrt_nam.StylePriority.UseFont = false;
            this.xrt_nam.StylePriority.UseTextAlignment = false;
            this.xrt_nam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_nam.Weight = 0.11621285277024689D;
            // 
            // xrt_nu
            // 
            this.xrt_nu.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_nu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_nu.Name = "xrt_nu";
            this.xrt_nu.StylePriority.UseBorders = false;
            this.xrt_nu.StylePriority.UseFont = false;
            this.xrt_nu.StylePriority.UseTextAlignment = false;
            this.xrt_nu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_nu.Weight = 0.11344427681761393D;
            // 
            // xrt_tong
            // 
            this.xrt_tong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tong.Name = "xrt_tong";
            this.xrt_tong.StylePriority.UseFont = false;
            this.xrt_tong.StylePriority.UseTextAlignment = false;
            this.xrt_tong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tong.Weight = 0.11482850846245254D;
            // 
            // xrt_saudaihoc
            // 
            this.xrt_saudaihoc.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_saudaihoc.Name = "xrt_saudaihoc";
            this.xrt_saudaihoc.StylePriority.UseFont = false;
            this.xrt_saudaihoc.StylePriority.UseTextAlignment = false;
            this.xrt_saudaihoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_saudaihoc.Weight = 0.123558256556815D;
            // 
            // xrt_daihoc
            // 
            this.xrt_daihoc.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_daihoc.Name = "xrt_daihoc";
            this.xrt_daihoc.StylePriority.UseFont = false;
            this.xrt_daihoc.StylePriority.UseTextAlignment = false;
            this.xrt_daihoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_daihoc.Weight = 0.15124562285053164D;
            // 
            // xrt_caodang
            // 
            this.xrt_caodang.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_caodang.Name = "xrt_caodang";
            this.xrt_caodang.StylePriority.UseFont = false;
            this.xrt_caodang.StylePriority.UseTextAlignment = false;
            this.xrt_caodang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_caodang.Weight = 0.16009090482555993D;
            // 
            // xrt_trungcap
            // 
            this.xrt_trungcap.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_trungcap.Name = "xrt_trungcap";
            this.xrt_trungcap.StylePriority.UseFont = false;
            this.xrt_trungcap.StylePriority.UseTextAlignment = false;
            this.xrt_trungcap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_trungcap.Weight = 0.15163037487588063D;
            // 
            // xrt_ptth
            // 
            this.xrt_ptth.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_ptth.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ptth.Name = "xrt_ptth";
            this.xrt_ptth.StylePriority.UseBorders = false;
            this.xrt_ptth.StylePriority.UseFont = false;
            this.xrt_ptth.StylePriority.UseTextAlignment = false;
            this.xrt_ptth.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_ptth.Weight = 0.16585937891899849D;
            // 
            // xrt_khac
            // 
            this.xrt_khac.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_khac.Name = "xrt_khac";
            this.xrt_khac.StylePriority.UseFont = false;
            this.xrt_khac.StylePriority.UseTextAlignment = false;
            this.xrt_khac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_khac.Weight = 0.11753946075144595D;
            // 
            // xrt_tongTrinhDo
            // 
            this.xrt_tongTrinhDo.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tongTrinhDo.Name = "xrt_tongTrinhDo";
            this.xrt_tongTrinhDo.StylePriority.UseFont = false;
            this.xrt_tongTrinhDo.StylePriority.UseTextAlignment = false;
            this.xrt_tongTrinhDo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongTrinhDo.Weight = 0.079083650767885691D;
            // 
            // xrt_duoi6thang
            // 
            this.xrt_duoi6thang.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_duoi6thang.Name = "xrt_duoi6thang";
            this.xrt_duoi6thang.StylePriority.UseFont = false;
            this.xrt_duoi6thang.StylePriority.UseTextAlignment = false;
            this.xrt_duoi6thang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_duoi6thang.Weight = 0.156457074512575D;
            // 
            // xrt_tu6thang1nam
            // 
            this.xrt_tu6thang1nam.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tu6thang1nam.Name = "xrt_tu6thang1nam";
            this.xrt_tu6thang1nam.StylePriority.UseFont = false;
            this.xrt_tu6thang1nam.StylePriority.UseTextAlignment = false;
            this.xrt_tu6thang1nam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tu6thang1nam.Weight = 0.15453414318470235D;
            // 
            // xrt_tu1den3nam
            // 
            this.xrt_tu1den3nam.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tu1den3nam.Name = "xrt_tu1den3nam";
            this.xrt_tu1den3nam.StylePriority.UseFont = false;
            this.xrt_tu1den3nam.StylePriority.UseTextAlignment = false;
            this.xrt_tu1den3nam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tu1den3nam.Weight = 0.17643424449123216D;
            // 
            // xrt_tren3nam
            // 
            this.xrt_tren3nam.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_tren3nam.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tren3nam.Name = "xrt_tren3nam";
            this.xrt_tren3nam.StylePriority.UseBorders = false;
            this.xrt_tren3nam.StylePriority.UseFont = false;
            this.xrt_tren3nam.StylePriority.UseTextAlignment = false;
            this.xrt_tren3nam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tren3nam.Weight = 0.1875867504758883D;
            // 
            // xrt_tongthamnien
            // 
            this.xrt_tongthamnien.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_tongthamnien.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tongthamnien.Name = "xrt_tongthamnien";
            this.xrt_tongthamnien.StylePriority.UseBorders = false;
            this.xrt_tongthamnien.StylePriority.UseFont = false;
            this.xrt_tongthamnien.StylePriority.UseTextAlignment = false;
            this.xrt_tongthamnien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tongthamnien.Weight = 0.098869066718101015D;
            // 
            // xrt_thuviec
            // 
            this.xrt_thuviec.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrt_thuviec.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_thuviec.Name = "xrt_thuviec";
            this.xrt_thuviec.StylePriority.UseBorders = false;
            this.xrt_thuviec.StylePriority.UseFont = false;
            this.xrt_thuviec.StylePriority.UseTextAlignment = false;
            this.xrt_thuviec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_thuviec.Weight = 0.12772396494289337D;
            // 
            // xrt_chinhthuc
            // 
            this.xrt_chinhthuc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_chinhthuc.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_chinhthuc.Name = "xrt_chinhthuc";
            this.xrt_chinhthuc.StylePriority.UseBorders = false;
            this.xrt_chinhthuc.StylePriority.UseFont = false;
            this.xrt_chinhthuc.StylePriority.UseTextAlignment = false;
            this.xrt_chinhthuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_chinhthuc.Weight = 0.12910859266843566D;
            // 
            // xrt_tonghopdong
            // 
            this.xrt_tonghopdong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_tonghopdong.Name = "xrt_tonghopdong";
            this.xrt_tonghopdong.StylePriority.UseFont = false;
            this.xrt_tonghopdong.StylePriority.UseTextAlignment = false;
            this.xrt_tonghopdong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tonghopdong.Weight = 0.13049209376442086D;
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
            this.xrt_tenbaocao,
            this.xrt_tungay,
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
            this.ReportHeader.HeightF = 115F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrt_tenbaocao
            // 
            this.xrt_tenbaocao.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrt_tenbaocao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
            this.xrt_tenbaocao.Name = "xrt_tenbaocao";
            this.xrt_tenbaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tenbaocao.SizeF = new System.Drawing.SizeF(1625.25F, 21.95834F);
            this.xrt_tenbaocao.StylePriority.UseFont = false;
            this.xrt_tenbaocao.StylePriority.UseTextAlignment = false;
            this.xrt_tenbaocao.Text = "DANH SÁCH NHÂN VIÊN THÔI VIỆC THEO PHÒNG BAN";
            this.xrt_tenbaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_tungay
            // 
            this.xrt_tungay.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrt_tungay.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrt_tungay.Name = "xrt_tungay";
            this.xrt_tungay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tungay.SizeF = new System.Drawing.SizeF(1625.25F, 17.95836F);
            this.xrt_tungay.StylePriority.UseFont = false;
            this.xrt_tungay.StylePriority.UseTextAlignment = false;
            this.xrt_tungay.Text = "Từ ngày ....... Đến ngày ..........";
            this.xrt_tungay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(739.9739F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(739.9739F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.HeightF = 7F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ngayketxuat,
            this.xrl_footer2,
            this.xrl_ten2,
            this.xrl_footer3,
            this.xrl_ten1,
            this.xrl_footer1,
            this.xrl_ten3});
            this.ReportFooter.HeightF = 239F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ngayketxuat
            // 
            this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1342.056F, 37.08334F);
            this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
            this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(188.5416F, 23F);
            this.xrl_ngayketxuat.StylePriority.UseFont = false;
            this.xrl_ngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrl_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(706.0213F, 87.08331F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "TRƯỞNG BỘ PHẬN";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(706.0213F, 199.5833F);
            this.xrl_ten2.Multiline = true;
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1354.556F, 87.08331F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "BAN GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(92.47958F, 199.5833F);
            this.xrl_ten1.Multiline = true;
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(92.47958F, 87.08337F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1354.556F, 199.5833F);
            this.xrl_ten3.Multiline = true;
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5,
            this.xrLabel1});
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Text = "`";
            this.xrTableCell26.Weight = 0.38852998515336723D;
            // 
            // xrTable5
            // 
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28.64586F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable5.SizeF = new System.Drawing.SizeF(209.8333F, 57.81247F);
            this.xrTable5.StylePriority.UseBorders = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell14,
            this.xrTableCell15});
            this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseFont = false;
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.Text = "Hợp đồng thử việc ";
            this.xrTableCell10.Weight = 1D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Hợp đồng chính thức";
            this.xrTableCell14.Weight = 1D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.Text = "Tổng";
            this.xrTableCell15.Weight = 1D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(210.5833F, 28.64586F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Loại hợp đồng";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrLabel2});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Weight = 0.77214022140221394D;
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28.64586F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable4.SizeF = new System.Drawing.SizeF(418.5001F, 57.81248F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            this.xrTable4.StylePriority.UseTextAlignment = false;
            this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell47,
            this.xrTableCell16,
            this.xrTableCell21,
            this.xrTableCell23,
            this.xrTableCell25});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell47.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell47.Multiline = true;
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.StylePriority.UseBorders = false;
            this.xrTableCell47.StylePriority.UseFont = false;
            this.xrTableCell47.Text = "Dưới 6 tháng\r\n";
            this.xrTableCell47.Weight = 0.52849406182767555D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.Text = "Từ 6 tháng đến 1 năm";
            this.xrTableCell16.Weight = 0.52199970517623673D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.Text = "Từ 1 đến 3 năm";
            this.xrTableCell21.Weight = 0.5959739941962805D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.Text = "Trên 3 năm";
            this.xrTableCell23.Weight = 0.63364811523425923D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.Text = "Tổng";
            this.xrTableCell25.Weight = 0.32929313586268516D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(418.5F, 28.64586F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Thâm niên";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrLabel3});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Weight = 0.94857011070110719D;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28.64586F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable3.SizeF = new System.Drawing.SizeF(514.1251F, 57.81248F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell18,
            this.xrTableCell11,
            this.xrTableCell20,
            this.xrTableCell12,
            this.xrTableCell22,
            this.xrTableCell24,
            this.xrTableCell13});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.Text = "Sau đại học";
            this.xrTableCell18.Weight = 0.39059098770286288D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.Text = "Đại học";
            this.xrTableCell11.Weight = 0.47811816192560186D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.Text = "Cao đẳng";
            this.xrTableCell20.Weight = 0.506078407070569D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.Text = "Trung cấp";
            this.xrTableCell12.Weight = 0.47933364348249885D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.Text = "PTTH";
            this.xrTableCell22.Weight = 0.52431332952990073D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.Text = "Khác";
            this.xrTableCell24.Weight = 0.37156547028856673D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.Text = "Tổng";
            this.xrTableCell13.Weight = 0.25D;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(514.1249F, 28.64586F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Trình độ";
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrLabel4});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Weight = 0.34432668087667206D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 28.64586F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(186.625F, 57.81247F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8});
            this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.Text = "Nam";
            this.xrTableCell6.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Nữ";
            this.xrTableCell7.Weight = 1D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Tổng";
            this.xrTableCell8.Weight = 1D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(186.6251F, 28.64586F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Giới tính";
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Mã phòng ban";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.17024138052965004D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Phòng ban";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 0.27786747555891089D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 0.096940304520385268D;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell9,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell26});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 3.4583334350585937D;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0.750042F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1625.25F, 86.45834F);
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable1});
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.PageHeader.HeightF = 122F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UseTextAlignment = false;
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable6
            // 
            this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0.7499616F, 86.45834F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable6.SizeF = new System.Drawing.SizeF(1625.25F, 35.41666F);
            this.xrTable6.StylePriority.UseBorders = false;
            this.xrTable6.StylePriority.UseFont = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell27,
            this.xrTableCell48,
            this.xrTableCell40,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell28});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.Text = "1";
            this.xrTableCell17.Weight = 0.096985201270117144D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "2";
            this.xrTableCell29.Weight = 0.27938013292426167D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Text = "3";
            this.xrTableCell30.Weight = 0.16893544744994166D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StylePriority.UseBorders = false;
            this.xrTableCell31.Text = "4";
            this.xrTableCell31.Weight = 0.11621285277024689D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.Text = "5";
            this.xrTableCell32.Weight = 0.11344427681761393D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Text = "6";
            this.xrTableCell33.Weight = 0.11482850846245254D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Text = "7";
            this.xrTableCell34.Weight = 0.123558256556815D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Text = "8";
            this.xrTableCell35.Weight = 0.15124562285053164D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Text = "9";
            this.xrTableCell36.Weight = 0.16009090482555993D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Text = "10";
            this.xrTableCell37.Weight = 0.15163037487588063D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StylePriority.UseBorders = false;
            this.xrTableCell38.Text = "11";
            this.xrTableCell38.Weight = 0.16585937891899849D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Text = "12";
            this.xrTableCell39.Weight = 0.11753946075144595D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Text = "13";
            this.xrTableCell27.Weight = 0.079083650767885691D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Text = "14";
            this.xrTableCell48.Weight = 0.156457074512575D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "15";
            this.xrTableCell40.Weight = 0.15453414318470235D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Text = "17";
            this.xrTableCell42.Weight = 0.17643424449123216D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StylePriority.UseBorders = false;
            this.xrTableCell43.Text = "18";
            this.xrTableCell43.Weight = 0.1875867504758883D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.Text = "19";
            this.xrTableCell44.Weight = 0.098869066718101015D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.Text = "20";
            this.xrTableCell45.Weight = 0.12772396494289337D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.Text = "21";
            this.xrTableCell46.Weight = 0.12910859266843566D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "22";
            this.xrTableCell28.Weight = 0.13049209376442086D;
            // 
            // rp_DanhSachNhanVienNghiViecTheoPhongBan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 49, 100);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
