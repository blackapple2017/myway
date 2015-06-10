using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for sub_QTDaoTao
/// </summary>
public class sub_QTDaoTao : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel30;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_tentruong;
    private XRTableCell xrt_chuyennghanh;
    private XRTableCell xrt_tuthangnam;
    private XRTableCell xrt_hinhthuc;
    private XRTableCell xrt_vanbang;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public sub_QTDaoTao()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
      
	}
    public void BinData(ReportFilter rp)
    {
        DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("GetSub_QuaTrinhDaoTao","@Id",rp.EmployeeCode);
        if (dt.Rows.Count>0)
        {
            DataSource = dt;
            xrt_tentruong.DataBindings.Add("Text", DataSource, "TEN_TRUONG_DAOTAO");
            xrt_chuyennghanh.DataBindings.Add("Text", DataSource, "TEN_CHUYENNGANH");
            xrt_tuthangnam.DataBindings.Add("Text", DataSource, "thang");
            xrt_hinhthuc.DataBindings.Add("Text", DataSource, "TEN_HT_DAOTAO");
            xrt_vanbang.DataBindings.Add("Text", DataSource, "TEN_TRINHDO");
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
        string resourceFileName = "sub_QTDaoTao.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_tentruong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_chuyennghanh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tuthangnam = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hinhthuc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_vanbang = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0.0001827876F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(773F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_tentruong,
            this.xrt_chuyennghanh,
            this.xrt_tuthangnam,
            this.xrt_hinhthuc,
            this.xrt_vanbang});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrt_tentruong
        // 
        this.xrt_tentruong.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_tentruong.Name = "xrt_tentruong";
        this.xrt_tentruong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_tentruong.StylePriority.UseFont = false;
        this.xrt_tentruong.StylePriority.UsePadding = false;
        this.xrt_tentruong.StylePriority.UseTextAlignment = false;
        this.xrt_tentruong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_tentruong.Weight = 0.5D;
        // 
        // xrt_chuyennghanh
        // 
        this.xrt_chuyennghanh.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_chuyennghanh.Name = "xrt_chuyennghanh";
        this.xrt_chuyennghanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_chuyennghanh.StylePriority.UseFont = false;
        this.xrt_chuyennghanh.StylePriority.UsePadding = false;
        this.xrt_chuyennghanh.StylePriority.UseTextAlignment = false;
        this.xrt_chuyennghanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_chuyennghanh.Weight = 0.5D;
        // 
        // xrt_tuthangnam
        // 
        this.xrt_tuthangnam.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_tuthangnam.Name = "xrt_tuthangnam";
        this.xrt_tuthangnam.StylePriority.UseFont = false;
        this.xrt_tuthangnam.StylePriority.UseTextAlignment = false;
        this.xrt_tuthangnam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrt_tuthangnam.Weight = 0.62435844509012361D;
        // 
        // xrt_hinhthuc
        // 
        this.xrt_hinhthuc.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_hinhthuc.Name = "xrt_hinhthuc";
        this.xrt_hinhthuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hinhthuc.StylePriority.UseFont = false;
        this.xrt_hinhthuc.StylePriority.UsePadding = false;
        this.xrt_hinhthuc.StylePriority.UseTextAlignment = false;
        this.xrt_hinhthuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hinhthuc.Weight = 0.56418445135567041D;
        // 
        // xrt_vanbang
        // 
        this.xrt_vanbang.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrt_vanbang.Name = "xrt_vanbang";
        this.xrt_vanbang.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_vanbang.StylePriority.UseFont = false;
        this.xrt_vanbang.StylePriority.UsePadding = false;
        this.xrt_vanbang.Weight = 0.811457103554206D;
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
        this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(778.9999F, 23F);
        this.xrLabel1.StylePriority.UseBorders = false;
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Ghi chú: Hình thức đào tạo: Chính quy, tại chức, chuyên tu, bồi dưỡng ..../ Văn b" +
            "ằng: TSKH, TS, Ths, Cử nhân, \r\nKỹ sư........................";
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrLabel30});
        this.ReportHeader.HeightF = 67.70831F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(773F, 42.70831F);
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
            this.xrTableCell5,
            this.xrTableCell2,
            this.xrTableCell3});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Tên trường";
        this.xrTableCell4.Weight = 0.5D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Chuyên ngành đào tạo";
        this.xrTableCell1.Weight = 0.5D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Từ tháng, năm - đến tháng năm";
        this.xrTableCell5.Weight = 0.62435825905755271D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Hình thức đào tạo";
        this.xrTableCell2.Weight = 0.56418488704928482D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "Văn bằng chứng chỉ";
        this.xrTableCell3.Weight = 0.81145685389316247D;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 0F);
        this.xrLabel30.Multiline = true;
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(779F, 23F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.Text = "72. Đào tạo, bồi dưỡng về chuyên môn, nghiệp vụ, lý luận chính trị, ngoại ngữ, ti" +
            "n học";
        // 
        // sub_QTDaoTao
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
        this.Margins = new System.Drawing.Printing.Margins(36, 35, 50, 100);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
