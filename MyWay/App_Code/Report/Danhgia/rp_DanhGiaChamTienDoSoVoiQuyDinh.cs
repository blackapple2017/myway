using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_DanhGiaChamTienDoSoVoiQuyDinh
/// </summary>
public class rp_DanhGiaChamTienDoSoVoiQuyDinh : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
   
    private XRLabel xrt_tieudebaocao;
    private XRLabel xrt_dotdanhgia;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_ngaysinh;
    private XRTableCell xrt_donvi;
    private XRTableCell xrt_ghichu;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRTableCell xrt_phongban;
    private XRTableCell xrt_chucvu;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DanhGiaChamTienDoSoVoiQuyDinh()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
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
            string resourceFileName = "rp_DanhGiaChamTienDoSoVoiQuyDinh.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_DanhGiaChamTienDoSoVoiQuyDinh.ResourceManager;
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_donvi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrt_dotdanhgia = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tieudebaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 28.125F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(825F, 28.125F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrt_ngaysinh,
            this.xrt_chucvu,
            this.xrt_phongban,
            this.xrt_donvi,
            this.xrt_ghichu});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.CanGrow = false;
            this.xrt_stt.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_stt.Multiline = true;
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseFont = false;
            this.xrt_stt.Weight = 0.14762516558797634D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_hovaten.CanGrow = false;
            this.xrt_hovaten.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.StylePriority.UseBorders = false;
            this.xrt_hovaten.StylePriority.UseFont = false;
            this.xrt_hovaten.Weight = 0.6399228329615505D;
            // 
            // xrt_ngaysinh
            // 
            this.xrt_ngaysinh.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_ngaysinh.CanGrow = false;
            this.xrt_ngaysinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ngaysinh.Multiline = true;
            this.xrt_ngaysinh.Name = "xrt_ngaysinh";
            this.xrt_ngaysinh.StylePriority.UseBorders = false;
            this.xrt_ngaysinh.StylePriority.UseFont = false;
            this.xrt_ngaysinh.Weight = 0.40885770564095364D;
            // 
            // xrt_donvi
            // 
            this.xrt_donvi.CanGrow = false;
            this.xrt_donvi.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_donvi.Name = "xrt_donvi";
            this.xrt_donvi.StylePriority.UseFont = false;
            this.xrt_donvi.Weight = 0.5D;
            // 
            // xrt_ghichu
            // 
            this.xrt_ghichu.CanGrow = false;
            this.xrt_ghichu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_ghichu.Name = "xrt_ghichu";
            this.xrt_ghichu.StylePriority.UseFont = false;
            this.xrt_ghichu.Weight = 0.5D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 26F;
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
            this.xrt_dotdanhgia,
            this.xrt_tieudebaocao});
            this.ReportHeader.HeightF = 99F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrt_dotdanhgia
            // 
            this.xrt_dotdanhgia.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrt_dotdanhgia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
            this.xrt_dotdanhgia.Name = "xrt_dotdanhgia";
            this.xrt_dotdanhgia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_dotdanhgia.SizeF = new System.Drawing.SizeF(825F, 23F);
            this.xrt_dotdanhgia.StylePriority.UseFont = false;
            this.xrt_dotdanhgia.StylePriority.UseTextAlignment = false;
            this.xrt_dotdanhgia.Text = "Đợt đánh giá: ......";
            this.xrt_dotdanhgia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_tieudebaocao
            // 
            this.xrt_tieudebaocao.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrt_tieudebaocao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrt_tieudebaocao.Multiline = true;
            this.xrt_tieudebaocao.Name = "xrt_tieudebaocao";
            this.xrt_tieudebaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tieudebaocao.SizeF = new System.Drawing.SizeF(824.9999F, 44.41668F);
            this.xrt_tieudebaocao.StylePriority.UseFont = false;
            this.xrt_tieudebaocao.StylePriority.UseTextAlignment = false;
            this.xrt_tieudebaocao.Text = "DANH SÁCH TRƯỜNG HỢP CÁN BỘ TỰ ĐÁNH GIÁ, CÁN BỘ THAM GIA ĐÁNH GIÁ\r\nQLTT ĐÁNH GIÁ " +
    "CHẬM TIẾN ĐỘ SO VỚI QUY ĐỊNH";
            this.xrt_tieudebaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3});
            this.ReportFooter.HeightF = 214F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportFooter_BeforePrint);
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(604.1667F, 32.99999F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(220.8333F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Giám đốc";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(604.1667F, 10.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(220.8333F, 23F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Ngày 27 tháng 5  năm 2013";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // printForm1
            // 
           
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 28.125F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(825F, 28.125F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell1,
            this.xrTableCell9,
            this.xrTableCell2,
            this.xrTableCell10,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.CanGrow = false;
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.Text = "STT\r\n";
            this.xrTableCell7.Weight = 0.14762516558797634D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.CanGrow = false;
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.Text = "Họ và tên\t";
            this.xrTableCell8.Weight = 0.6399229457864849D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.CanGrow = false;
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.Text = "Ngày sinh\r\n";
            this.xrTableCell1.Weight = 0.40885759281601919D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.CanGrow = false;
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.Text = "Chức vụ";
            this.xrTableCell9.Weight = 0.35365844430880122D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "Phòng ban";
            this.xrTableCell2.Weight = 0.5D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.CanGrow = false;
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.Text = "Đơn vị";
            this.xrTableCell10.Weight = 0.5D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "Ghi chú";
            this.xrTableCell3.Weight = 0.5D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_phongban.CanGrow = false;
            this.xrt_phongban.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.StylePriority.UseBorders = false;
            this.xrt_phongban.StylePriority.UseFont = false;
            this.xrt_phongban.Weight = 0.4999999435875328D;
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_chucvu.CanGrow = false;
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.StylePriority.UseBorders = false;
            this.xrt_chucvu.Weight = 0.35365850072126842D;
            // 
            // rp_DanhGiaChamTienDoSoVoiQuyDinh
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter,
            this.PageHeader});
            this.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Margins = new System.Drawing.Printing.Margins(11, 14, 26, 100);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
