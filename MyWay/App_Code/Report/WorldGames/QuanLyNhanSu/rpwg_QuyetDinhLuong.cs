using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rpwg_QuyetDinhLuong
/// </summary>
public class rpwg_QuyetDinhLuong : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRRichText xrRichText1;
    private XRRichText xrRichText2;
    private XRLine xrLine1;
    private XRRichText xrRichText3;
    private XRRichText xrRichText4;
    private XRLine xrLine2;
    private XRRichText xrRichText5;
    private XRRichText xrRichText6;
    private XRRichText xrRichText7;
    private XRRichText xrRichText8;
    private XRRichText xrRichText9;
    private XRRichText xrRichText10;
    private XRRichText xrRichText11;
    private XRRichText xrRichText12;
    private XRRichText xrRichText13;
    private XRRichText xrRichText14;
    private XRRichText xrRichText15;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrtstt;
    private XRTableCell xrtHoTen;
    private XRTableCell xrtMucLuong;
    private XRTableCell xrtMucPhuCap;
    private XRTableCell xrtTongThuNhap;
    private XRRichText xrRichText16;
    private XRRichText xrRichText17;
    private XRRichText xrRichText18;
    private XRRichText xrRichText19;
    private XRRichText xrRichText20;
    private XRRichText xrtNguoiKy;
    private XRRichText xrRichText21;
    private XRLine xrLine3;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rpwg_QuyetDinhLuong()
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

    public void BindData(ReportFilterQuyetDinhLuong filter)
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("WG_GetQuyetDinhLuong", "@IdQuyetDinhLuong", filter.ID);
            if (table.Rows.Count > 0)
            {
                string hoTen = table.Rows[0]["HO_TEN"].ToString();
                string chucVu = table.Rows[0]["TEN_CHUCVU"].ToString();
                ReportController rpController = new ReportController();
                // Số : {0}
                xrRichText21.Rtf = rpController.Convertstringtortf(xrRichText21.Rtf, "{0}", table.Rows[0]["SoQuyetDinh"].ToString());
                // Hà nội, ngày {0} tháng {1} năm {2}
                xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{0}", DateTime.Now.ToString("dd"));
                xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{1}", DateTime.Now.ToString("MM"));
                xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{2}", DateTime.Now.ToString("yyyy"));
                // về việc phụ cấp kiêm nhiệm
                xrRichText7.Rtf = rpController.Convertstringtortf(xrRichText7.Rtf, "{0}", hoTen);
                // Phòng {0} {1} thuộc CT CPTGGT)
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{0}", table.Rows[0]["TEN_DONVI"].ToString());
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{1}", table.Rows[0]["TenChiNhanh"].ToString());
                // Căn cứ vào sự nỗ lực và cố gắng của {0} - {1} trong thời gian qua
                xrRichText11.Rtf = rpController.Convertstringtortf(xrRichText11.Rtf, "{0}", chucVu);
                xrRichText11.Rtf = rpController.Convertstringtortf(xrRichText11.Rtf, "{1}", hoTen);
                // a.	Phụ cấp kiêm nhiệm đối với {0}  {1} - {2} thuộc Công ty CPTGGT kể từ ngày {3}:
                xrRichText14.Rtf = rpController.Convertstringtortf(xrRichText14.Rtf, "{0}", chucVu.Trim());
                xrRichText14.Rtf = rpController.Convertstringtortf(xrRichText14.Rtf, "{1}", hoTen);
                xrRichText14.Rtf = rpController.Convertstringtortf(xrRichText14.Rtf, "{2}", table.Rows[0]["TEN_DONVI"].ToString());
                xrRichText14.Rtf = rpController.Convertstringtortf(xrRichText14.Rtf, "{3}", table.Rows[0]["NgayApDungPhuCap"].ToString().Remove(10));
                // thông tin lương, phụ cấp
                DataSource = table;
                xrtHoTen.DataBindings.Add("Text", DataSource, "HO_TEN");
                xrtMucLuong.DataBindings.Add("Text", DataSource, "LuongCung", "{0:n0}");
                xrtMucPhuCap.DataBindings.Add("Text", DataSource, "MucPhuCap", "{0:n0}");
                xrtTongThuNhap.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                // Điều 2. {0}, Phòng HCNS và nhân viên {1} chịu trách nhiệm thi hành quyết định này.
                xrRichText17.Rtf = rpController.Convertstringtortf(xrRichText17.Rtf, "{1}", hoTen);
                // Quyết định này có hiệu lực kể từ ngày {0} ./.
                xrRichText18.Rtf = rpController.Convertstringtortf(xrRichText18.Rtf, "{0}", table.Rows[0]["NgayHieuLuc"].ToString().Remove(10));

                // Footer
                if (!string.IsNullOrEmpty(filter.TenNguoiKy))
                    xrtNguoiKy.Text = filter.TenNguoiKy;
            }
            else
            {
                ExtMessage.Dialog.Alert("Không có dữ liệu");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
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
            string resourceFileName = "rpwg_QuyetDinhLuong.resx";
            System.Resources.ResourceManager resources = global::Resources.rpwg_QuyetDinhLuong.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrtNguoiKy = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText20 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText19 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText18 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText17 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText16 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtstt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtHoTen = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtMucLuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtMucPhuCap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtTongThuNhap = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrRichText15 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText14 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText13 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText12 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText11 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText10 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText9 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText8 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText7 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText6 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText5 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrRichText21 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this.xrtNguoiKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine3,
            this.xrRichText21,
            this.xrtNguoiKy,
            this.xrRichText20,
            this.xrRichText19,
            this.xrRichText18,
            this.xrRichText17,
            this.xrRichText16,
            this.xrTable2,
            this.xrTable1,
            this.xrRichText15,
            this.xrRichText14,
            this.xrRichText13,
            this.xrRichText12,
            this.xrRichText11,
            this.xrRichText10,
            this.xrRichText9,
            this.xrRichText8,
            this.xrRichText7,
            this.xrRichText6,
            this.xrRichText5,
            this.xrLine2,
            this.xrRichText4,
            this.xrRichText3,
            this.xrLine1,
            this.xrRichText2,
            this.xrRichText1});
            this.Detail.HeightF = 817F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrtNguoiKy
            // 
            this.xrtNguoiKy.LocationFloat = new DevExpress.Utils.PointFloat(376.0417F, 753.3333F);
            this.xrtNguoiKy.Name = "xrtNguoiKy";
            this.xrtNguoiKy.SerializableRtfString = resources.GetString("xrtNguoiKy.SerializableRtfString");
            this.xrtNguoiKy.SizeF = new System.Drawing.SizeF(251.0417F, 23F);
            // 
            // xrRichText20
            // 
            this.xrRichText20.LocationFloat = new DevExpress.Utils.PointFloat(376.0416F, 661.6667F);
            this.xrRichText20.Name = "xrRichText20";
            this.xrRichText20.SerializableRtfString = resources.GetString("xrRichText20.SerializableRtfString");
            this.xrRichText20.SizeF = new System.Drawing.SizeF(251.0417F, 23F);
            // 
            // xrRichText19
            // 
            this.xrRichText19.LocationFloat = new DevExpress.Utils.PointFloat(22.91667F, 661.6666F);
            this.xrRichText19.Name = "xrRichText19";
            this.xrRichText19.SerializableRtfString = resources.GetString("xrRichText19.SerializableRtfString");
            this.xrRichText19.SizeF = new System.Drawing.SizeF(100F, 68.83331F);
            // 
            // xrRichText18
            // 
            this.xrRichText18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 621.4583F);
            this.xrRichText18.Name = "xrRichText18";
            this.xrRichText18.SerializableRtfString = resources.GetString("xrRichText18.SerializableRtfString");
            this.xrRichText18.SizeF = new System.Drawing.SizeF(650F, 23F);
            // 
            // xrRichText17
            // 
            this.xrRichText17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 576.5834F);
            this.xrRichText17.Name = "xrRichText17";
            this.xrRichText17.SerializableRtfString = resources.GetString("xrRichText17.SerializableRtfString");
            this.xrRichText17.SizeF = new System.Drawing.SizeF(650F, 44.875F);
            // 
            // xrRichText16
            // 
            this.xrRichText16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 511.9167F);
            this.xrRichText16.Name = "xrRichText16";
            this.xrRichText16.SerializableRtfString = resources.GetString("xrRichText16.SerializableRtfString");
            this.xrRichText16.SizeF = new System.Drawing.SizeF(650F, 64.66656F);
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 486.9167F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(650F, 24.99997F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtstt,
            this.xrtHoTen,
            this.xrtMucLuong,
            this.xrtMucPhuCap,
            this.xrtTongThuNhap});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrtstt
            // 
            this.xrtstt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrtstt.Name = "xrtstt";
            this.xrtstt.StylePriority.UseFont = false;
            this.xrtstt.StylePriority.UseTextAlignment = false;
            this.xrtstt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtstt.Weight = 0.1971152672400841D;
            this.xrtstt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrtHoTen
            // 
            this.xrtHoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrtHoTen.Name = "xrtHoTen";
            this.xrtHoTen.StylePriority.UseFont = false;
            this.xrtHoTen.StylePriority.UseTextAlignment = false;
            this.xrtHoTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtHoTen.Weight = 0.71634631817157457D;
            // 
            // xrtMucLuong
            // 
            this.xrtMucLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrtMucLuong.Name = "xrtMucLuong";
            this.xrtMucLuong.StylePriority.UseFont = false;
            this.xrtMucLuong.StylePriority.UseTextAlignment = false;
            this.xrtMucLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtMucLuong.Weight = 0.69230764535757217D;
            // 
            // xrtMucPhuCap
            // 
            this.xrtMucPhuCap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrtMucPhuCap.Name = "xrtMucPhuCap";
            this.xrtMucPhuCap.StylePriority.UseFont = false;
            this.xrtMucPhuCap.StylePriority.UseTextAlignment = false;
            this.xrtMucPhuCap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtMucPhuCap.Weight = 0.69230766883263217D;
            // 
            // xrtTongThuNhap
            // 
            this.xrtTongThuNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrtTongThuNhap.Name = "xrtTongThuNhap";
            this.xrtTongThuNhap.StylePriority.UseFont = false;
            this.xrtTongThuNhap.StylePriority.UseTextAlignment = false;
            this.xrtTongThuNhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtTongThuNhap.Weight = 0.7019231003981371D;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 442.125F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(650F, 44.79166F);
            this.xrTable1.StylePriority.UseBorders = false;
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
            this.xrTableCell5});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.Text = "TT";
            this.xrTableCell1.Weight = 0.1971153376652644D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "Họ và tên";
            this.xrTableCell2.Weight = 0.7163462242713341D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "Mức lương \r\nHiện tại";
            this.xrTableCell4.Weight = 0.69230771578275252D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "Mức phụ cấp \r\nkiêm nhiệm";
            this.xrTableCell3.Weight = 0.69230771578275252D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "Tổng thu nhập \r\ngross";
            this.xrTableCell5.Weight = 0.70192300649789663D;
            // 
            // xrRichText15
            // 
            this.xrRichText15.LocationFloat = new DevExpress.Utils.PointFloat(482.2917F, 419.125F);
            this.xrRichText15.Name = "xrRichText15";
            this.xrRichText15.SerializableRtfString = resources.GetString("xrRichText15.SerializableRtfString");
            this.xrRichText15.SizeF = new System.Drawing.SizeF(167.7083F, 23F);
            // 
            // xrRichText14
            // 
            this.xrRichText14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 376.3333F);
            this.xrRichText14.Name = "xrRichText14";
            this.xrRichText14.SerializableRtfString = resources.GetString("xrRichText14.SerializableRtfString");
            this.xrRichText14.SizeF = new System.Drawing.SizeF(650F, 42.79169F);
            // 
            // xrRichText13
            // 
            this.xrRichText13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 353.3333F);
            this.xrRichText13.Name = "xrRichText13";
            this.xrRichText13.SerializableRtfString = resources.GetString("xrRichText13.SerializableRtfString");
            this.xrRichText13.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
            // 
            // xrRichText12
            // 
            this.xrRichText12.LocationFloat = new DevExpress.Utils.PointFloat(82.29166F, 330.3333F);
            this.xrRichText12.Name = "xrRichText12";
            this.xrRichText12.SerializableRtfString = resources.GetString("xrRichText12.SerializableRtfString");
            this.xrRichText12.SizeF = new System.Drawing.SizeF(516.6666F, 23F);
            // 
            // xrRichText11
            // 
            this.xrRichText11.LocationFloat = new DevExpress.Utils.PointFloat(44.79167F, 284.4167F);
            this.xrRichText11.Name = "xrRichText11";
            this.xrRichText11.SerializableRtfString = resources.GetString("xrRichText11.SerializableRtfString");
            this.xrRichText11.SizeF = new System.Drawing.SizeF(595.2083F, 45.91663F);
            // 
            // xrRichText10
            // 
            this.xrRichText10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrRichText10.LocationFloat = new DevExpress.Utils.PointFloat(44.79167F, 261.4167F);
            this.xrRichText10.Name = "xrRichText10";
            this.xrRichText10.SerializableRtfString = resources.GetString("xrRichText10.SerializableRtfString");
            this.xrRichText10.SizeF = new System.Drawing.SizeF(595.2083F, 23F);
            this.xrRichText10.StylePriority.UseBorders = false;
            // 
            // xrRichText9
            // 
            this.xrRichText9.LocationFloat = new DevExpress.Utils.PointFloat(82.29166F, 222.875F);
            this.xrRichText9.Name = "xrRichText9";
            this.xrRichText9.SerializableRtfString = resources.GetString("xrRichText9.SerializableRtfString");
            this.xrRichText9.SizeF = new System.Drawing.SizeF(516.6666F, 17.79166F);
            // 
            // xrRichText8
            // 
            this.xrRichText8.LocationFloat = new DevExpress.Utils.PointFloat(44.79167F, 164.7083F);
            this.xrRichText8.Name = "xrRichText8";
            this.xrRichText8.SerializableRtfString = resources.GetString("xrRichText8.SerializableRtfString");
            this.xrRichText8.SizeF = new System.Drawing.SizeF(554.1666F, 23F);
            // 
            // xrRichText7
            // 
            this.xrRichText7.LocationFloat = new DevExpress.Utils.PointFloat(44.79167F, 141.7083F);
            this.xrRichText7.Name = "xrRichText7";
            this.xrRichText7.SerializableRtfString = resources.GetString("xrRichText7.SerializableRtfString");
            this.xrRichText7.SizeF = new System.Drawing.SizeF(554.1666F, 23F);
            // 
            // xrRichText6
            // 
            this.xrRichText6.LocationFloat = new DevExpress.Utils.PointFloat(211.4583F, 118.7083F);
            this.xrRichText6.Name = "xrRichText6";
            this.xrRichText6.SerializableRtfString = resources.GetString("xrRichText6.SerializableRtfString");
            this.xrRichText6.SizeF = new System.Drawing.SizeF(247.9166F, 23F);
            // 
            // xrRichText5
            // 
            this.xrRichText5.LocationFloat = new DevExpress.Utils.PointFloat(347.9167F, 57.45834F);
            this.xrRichText5.Name = "xrRichText5";
            this.xrRichText5.SerializableRtfString = resources.GetString("xrRichText5.SerializableRtfString");
            this.xrRichText5.SizeF = new System.Drawing.SizeF(292.0833F, 23F);
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(181.25F, 187.7083F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(294.7916F, 11.45833F);
            // 
            // xrRichText4
            // 
            this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(304.1667F, 23F);
            this.xrRichText4.Name = "xrRichText4";
            this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
            this.xrRichText4.SizeF = new System.Drawing.SizeF(322.9167F, 23F);
            // 
            // xrRichText3
            // 
            this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(264.1667F, 0F);
            this.xrRichText3.Name = "xrRichText3";
            this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
            this.xrRichText3.SizeF = new System.Drawing.SizeF(385.8333F, 23F);
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(44.79167F, 46F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(137.5F, 11.45832F);
            // 
            // xrRichText2
            // 
            this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(22.91667F, 23F);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
            this.xrRichText2.SizeF = new System.Drawing.SizeF(175F, 23F);
            // 
            // xrRichText1
            // 
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(22.91667F, 0F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(175F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
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
            // xrRichText21
            // 
            this.xrRichText21.LocationFloat = new DevExpress.Utils.PointFloat(22.91667F, 57.45834F);
            this.xrRichText21.Name = "xrRichText21";
            this.xrRichText21.SerializableRtfString = resources.GetString("xrRichText21.SerializableRtfString");
            this.xrRichText21.SizeF = new System.Drawing.SizeF(226.0416F, 23F);
            // 
            // xrLine3
            // 
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(394.7917F, 46F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(137.5F, 11.45832F);
            // 
            // rpwg_QuyetDinhLuong
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 30, 0);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrtNguoiKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
