using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for sub_Quatrinh_Daotao
/// </summary>
public class sub_Quatrinh_Daotao : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_TU_NGAY;
    private XRTableCell xrt_DEN_NGAY;
    private XRTableCell xrt_LOAI_HT;
    private XRTableCell xrt_NGUON_KP;
    private XRTableCell xrt_HT_DT;
    private XRTableCell xrt_TRUONG_DT;
    private XRTableCell xrt_CHUYENNGANH;
    private XRTableCell xrt_NUOC_DT;
    private XRTableCell xrt_TRINHDO_TN;
    private XRTableCell xrt_LOAI_CC;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel47;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private ReportFooterBand ReportFooter;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public sub_Quatrinh_Daotao()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
        BindData();
	}
    public void BindData()
    {
        //xrt_TU_NGAY.DataBindings.Add("Text", DataSource, "TU_NGAY");
        //xrt_DEN_NGAY.DataBindings.Add("Text", DataSource,"DEN_NGAY");
        //xrt_LOAI_HT.DataBindings.Add("Text", DataSource, "");
        //xrt_CHUYENNGANH.DataBindings.Add("Text", DataSource, "MA_CHUYENNGANH");
        //xrt_HT_DT.DataBindings.Add("Text", DataSource, "MA_HT_DAOTAO");
        //xrt_TRUONG_DT.DataBindings.Add("Text",DataSource,"TEN_TRUONG");
        //xrt_NUOC_DT.DataBindings.Add("Text", DataSource, "MA_NUOC");
        //xrt_TRINHDO_TN.DataBindings.Add("Text", DataSource, "MA_TRINHDO");
        //xrt_LOAI_CC.DataBindings.Add("Text", DataSource, "MA_XEPLOAI");
        //xrt_NGUON_KP.DataBindings.Add("Text", DataSource, "SO_TIEN","{0:0,0 VNĐ}");
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
            string resourceFileName = "sub_Quatrinh_Daotao.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_TU_NGAY = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_DEN_NGAY = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_LOAI_HT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_CHUYENNGANH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_HT_DT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TRUONG_DT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_NUOC_DT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_TRINHDO_TN = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_LOAI_CC = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_NGUON_KP = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
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
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(699.1664F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_TU_NGAY,
            this.xrt_DEN_NGAY,
            this.xrt_LOAI_HT,
            this.xrt_CHUYENNGANH,
            this.xrt_HT_DT,
            this.xrt_TRUONG_DT,
            this.xrt_NUOC_DT,
            this.xrt_TRINHDO_TN,
            this.xrt_LOAI_CC,
            this.xrt_NGUON_KP});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_TU_NGAY
            // 
            this.xrt_TU_NGAY.Name = "xrt_TU_NGAY";
            this.xrt_TU_NGAY.Weight = 0.24999996965038096D;
            // 
            // xrt_DEN_NGAY
            // 
            this.xrt_DEN_NGAY.Name = "xrt_DEN_NGAY";
            this.xrt_DEN_NGAY.Weight = 0.24519219742387305D;
            // 
            // xrt_LOAI_HT
            // 
            this.xrt_LOAI_HT.Name = "xrt_LOAI_HT";
            this.xrt_LOAI_HT.Weight = 0.23557684443265056D;
            // 
            // xrt_CHUYENNGANH
            // 
            this.xrt_CHUYENNGANH.Name = "xrt_CHUYENNGANH";
            this.xrt_CHUYENNGANH.Weight = 0.51827055743896433D;
            // 
            // xrt_HT_DT
            // 
            this.xrt_HT_DT.Name = "xrt_HT_DT";
            this.xrt_HT_DT.Weight = 0.27692252092228287D;
            // 
            // xrt_TRUONG_DT
            // 
            this.xrt_TRUONG_DT.Name = "xrt_TRUONG_DT";
            this.xrt_TRUONG_DT.Weight = 0.67211530362784333D;
            // 
            // xrt_NUOC_DT
            // 
            this.xrt_NUOC_DT.Name = "xrt_NUOC_DT";
            this.xrt_NUOC_DT.Weight = 0.35288441129988618D;
            // 
            // xrt_TRINHDO_TN
            // 
            this.xrt_TRINHDO_TN.Name = "xrt_TRINHDO_TN";
            this.xrt_TRINHDO_TN.Weight = 0.22932664141117032D;
            // 
            // xrt_LOAI_CC
            // 
            this.xrt_LOAI_CC.Name = "xrt_LOAI_CC";
            this.xrt_LOAI_CC.Weight = 0.19639414045390322D;
            // 
            // xrt_NGUON_KP
            // 
            this.xrt_NGUON_KP.Name = "xrt_NGUON_KP";
            this.xrt_NGUON_KP.Weight = 0.25023929898116437D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 36F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 39F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel47});
            this.ReportHeader.HeightF = 23F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel47
            // 
            this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(699.1664F, 23F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "72. Quá trình đào tạo, bồi dưỡng: ";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.PageHeader.HeightF = 88.00001F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(699.1664F, 88.00001F);
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
            this.xrTableCell3,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Từ ngày";
            this.xrTableCell1.Weight = 0.24999996959293674D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Đến ngày";
            this.xrTableCell2.Weight = 0.24519221503016941D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Loại hình kiến thức";
            this.xrTableCell4.Weight = 0.23557686203894557D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Tên chuyên ngành ĐT -BD";
            this.xrTableCell3.Weight = 0.51827053514605947D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Hình thức đào tạo, bồi dưỡng";
            this.xrTableCell5.Weight = 0.27692255613487526D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Tên trường đào tạo";
            this.xrTableCell6.Weight = 0.67211527075855559D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Nước đào tạo";
            this.xrTableCell7.Weight = 0.35288447548993584D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Trình độ tốt nghiệp";
            this.xrTableCell8.Weight = 0.22932666889212514D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Loại văn bằng, chứng chỉ";
            this.xrTableCell9.Weight = 0.1963941583227567D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Nguồn kinh phí";
            this.xrTableCell10.Weight = 0.25023963646227793D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 39F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // sub_Quatrinh_Daotao
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(70, 78, 36, 39);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
