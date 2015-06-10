using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for PhieuTraLuong1
/// </summary>
public class PhieuTraLuong1 : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_ThangTraLuong;
    private XRLabel xrl_tenbaocao;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell6;
    private XRTableCell xrt_hesoluong;
    private XRTableCell xrTableCell8;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell10;
    private XRTableCell xrt_tongcong;
    private XRTableCell xrTableCell12;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell14;
    private XRTableCell xrt_tongluong;
    private XRTableCell xrTableCell16;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell18;
    private XRTableCell xrt_songuoiphuthuoc;
    private XRTableCell xrTableCell20;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell22;
    private XRTableCell xrt_tonggiamtru;
    private XRTableCell xrTableCell24;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell26;
    private XRTableCell xrt_conlinh;
    private XRTableCell xrTableCell28;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell30;
    private XRTableCell xrt_thuclinh;
    private XRTableCell xrTableCell32;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell34;
    private XRTableCell xrt_tongphucap;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell38;
    private XRTableCell xrt_giamtruthunhapcanhan;
    private XRTableCell xrTableCell40;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell42;
    private XRTableCell xrt_giamtrubhyt;
    private XRTableCell xrTableCell44;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell46;
    private XRTableCell xrt_giamtrubhxh;
    private XRTableCell xrTableCell48;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell50;
    private XRTableCell xrt_giamtruthatnghiep;
    private XRTableCell xrTableCell52;
    private XRLabel xrlNDbophan;
    private XRLabel xrlNDchucvu;
    private XRLabel xrlMa;
    private XRLabel xrlNDhoten;
    private XRLabel xrl_code;
    private XRLabel xrl_bophan;
    private XRLabel xrl_chucvu;
    private XRLabel xrl_hoten;
    private PageFooterBand PageFooter;
    private XRLabel xrl_chukythuquy;
    private XRLabel xrl_chukynguoinhantien;
    private XRLabel xrl_nguoinhantien;
    private XRLabel xrl_ngayketxuat;
    private XRLabel xrl_thuquy;
    private XRLabel xrLabel3;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public PhieuTraLuong1()
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
    public void BindData(ReportFilterSalary rp)
    {
        //if (rp.thang_chamcong == null)
        //{
        //    xrl_ThangTraLuong.Text = "Tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //    xrl_ngayketxuat.Text = "Tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //}
        //else
        //{
        //    xrl_ThangTraLuong.Text = "Tháng " + rp.thang_chamcong + " năm " + rp.nam_chamcong;
        //    xrl_ngayketxuat.Text = "Tháng " + rp.thang_chamcong + " năm " + rp.nam_chamcong;
        //}

        //if (!string.IsNullOrEmpty(rp.TenThanhPho))
        //{
        //    xrl_TenThanhPho.Text = rp.TenThanhPho;
        //}
        //if (!string.IsNullOrEmpty(rp.TenBaoCao))
        //{
        //    xrl_tenbaocao.Text = rp.TenBaoCao;
        //}
        //if (!string.IsNullOrEmpty(rp.TenDonVi))
        //{
        //    xrl_TenCongTy.Text = rp.TenDonVi;
        //}
      // DataTable table = DataHandler.GetInstance().ExecuteDataTable("sp_phieutraluong1", "@MaDonVi", "@MA_PHONG", "@IDBangLuong", rp.MaDonVi, rp.MaPhongBan, rp.Id_BangChamCong);
        DataSource = null;
        xrlNDhoten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrlMa.DataBindings.Add("Text", DataSource, "MaCB");
        xrlNDbophan.DataBindings.Add("Text", DataSource, "TEN_PHONG");
        xrlNDchucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        xrt_hesoluong.DataBindings.Add("Text", DataSource, "HS_LUONG", "{0:0,0}");
        xrt_tongcong.DataBindings.Add("Text", DataSource, "TONGCONG", "{0:0,0}");
        xrt_tongluong.DataBindings.Add("Text", DataSource, "TongLuong","{0:0,0}");
        xrt_songuoiphuthuoc.DataBindings.Add("Text", DataSource, "SONGUOI_PHUTHUOC");
        xrt_tonggiamtru.DataBindings.Add("Text", DataSource, "TongGiamTru","{0:0,0}");
        xrt_thuclinh.DataBindings.Add("Text", DataSource, "ThucLinh","{0:0,0}");
        xrt_conlinh.DataBindings.Add("Text", DataSource, "ConLinh","{0:0,0}");
        xrt_tongphucap.DataBindings.Add("Text", DataSource, "TongPhuCap","{0:0,0}");
        xrt_giamtruthunhapcanhan.DataBindings.Add("Text", DataSource, "GiamTruThuNhapCaNhan", "{0:0,0}");
        xrt_giamtrubhxh.DataBindings.Add("Text", DataSource, "GiamTruBHXH", "{0:0,0}");
        xrt_giamtrubhyt.DataBindings.Add("Text", DataSource, "GiamTruBHYT", "{0:0,0}");
        xrt_giamtruthatnghiep.DataBindings.Add("Text", DataSource, "GiamTruBHTN", "{0:0,0}");
        if (!string.IsNullOrEmpty(rp.Footer1))
        {
            xrl_nguoinhantien.Text = rp.Footer1;
        }
        if (!string.IsNullOrEmpty(rp.Footer3))
        {
            xrl_thuquy.Text = rp.Footer3;
        }
        if (!string.IsNullOrEmpty(rp.Ten1))
        {
            xrl_chukynguoinhantien.Text = rp.Ten1;

        }
        if (!string.IsNullOrEmpty(rp.Ten3))
        {
            xrl_chukythuquy.Text = rp.Ten3;
        }
    }
	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
        string resourceFileName = "PhieuTraLuong1.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrlNDbophan = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNDchucvu = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlMa = new DevExpress.XtraReports.UI.XRLabel();
        this.xrlNDhoten = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_code = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_bophan = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_chucvu = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_hoten = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hesoluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tongcong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tongluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_songuoiphuthuoc = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tonggiamtru = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_conlinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_thuclinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_tongphucap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_giamtruthunhapcanhan = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_giamtrubhyt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_giamtrubhxh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_giamtruthatnghiep = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ThangTraLuong = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_tenbaocao = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrl_chukythuquy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_chukynguoinhantien = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_nguoinhantien = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_thuquy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlNDbophan,
            this.xrlNDchucvu,
            this.xrlMa,
            this.xrlNDhoten,
            this.xrl_code,
            this.xrl_bophan,
            this.xrl_chucvu,
            this.xrl_hoten,
            this.xrTable1,
            this.xrLabel3});
        this.Detail.HeightF = 478F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrlNDbophan
        // 
        this.xrlNDbophan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrlNDbophan.LocationFloat = new DevExpress.Utils.PointFloat(537.5F, 51.12502F);
        this.xrlNDbophan.Name = "xrlNDbophan";
        this.xrlNDbophan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNDbophan.SizeF = new System.Drawing.SizeF(193.4999F, 23.00001F);
        this.xrlNDbophan.StylePriority.UseFont = false;
        // 
        // xrlNDchucvu
        // 
        this.xrlNDchucvu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrlNDchucvu.LocationFloat = new DevExpress.Utils.PointFloat(154.1667F, 51.12502F);
        this.xrlNDchucvu.Name = "xrlNDchucvu";
        this.xrlNDchucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNDchucvu.SizeF = new System.Drawing.SizeF(196.9997F, 23F);
        this.xrlNDchucvu.StylePriority.UseFont = false;
        // 
        // xrlMa
        // 
        this.xrlMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrlMa.LocationFloat = new DevExpress.Utils.PointFloat(488.25F, 10.00001F);
        this.xrlMa.Name = "xrlMa";
        this.xrlMa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlMa.SizeF = new System.Drawing.SizeF(242.75F, 23.00001F);
        this.xrlMa.StylePriority.UseFont = false;
        // 
        // xrlNDhoten
        // 
        this.xrlNDhoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrlNDhoten.LocationFloat = new DevExpress.Utils.PointFloat(154.1667F, 10.00001F);
        this.xrlNDhoten.Name = "xrlNDhoten";
        this.xrlNDhoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrlNDhoten.SizeF = new System.Drawing.SizeF(271.25F, 23F);
        this.xrlNDhoten.StylePriority.UseFont = false;
        // 
        // xrl_code
        // 
        this.xrl_code.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_code.LocationFloat = new DevExpress.Utils.PointFloat(425.4167F, 10.00001F);
        this.xrl_code.Name = "xrl_code";
        this.xrl_code.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_code.SizeF = new System.Drawing.SizeF(62.83328F, 23.00001F);
        this.xrl_code.StylePriority.UseFont = false;
        this.xrl_code.Text = "Code:  ";
        // 
        // xrl_bophan
        // 
        this.xrl_bophan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_bophan.LocationFloat = new DevExpress.Utils.PointFloat(351.1664F, 51.125F);
        this.xrl_bophan.Name = "xrl_bophan";
        this.xrl_bophan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_bophan.SizeF = new System.Drawing.SizeF(186.3336F, 23.00001F);
        this.xrl_bophan.StylePriority.UseFont = false;
        this.xrl_bophan.Text = "Bộ phận/Departmet: ";
        // 
        // xrl_chucvu
        // 
        this.xrl_chucvu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_chucvu.LocationFloat = new DevExpress.Utils.PointFloat(0F, 51.12502F);
        this.xrl_chucvu.Name = "xrl_chucvu";
        this.xrl_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_chucvu.SizeF = new System.Drawing.SizeF(154.1667F, 23F);
        this.xrl_chucvu.StylePriority.UseFont = false;
        this.xrl_chucvu.Text = "Chức vụ/Position:  ";
        // 
        // xrl_hoten
        // 
        this.xrl_hoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_hoten.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
        this.xrl_hoten.Name = "xrl_hoten";
        this.xrl_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_hoten.SizeF = new System.Drawing.SizeF(154.1667F, 23F);
        this.xrl_hoten.StylePriority.UseFont = false;
        this.xrl_hoten.Text = "Họ và tên/Fullname:  ";
        // 
        // xrTable1
        // 
        this.xrTable1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0.0005722046F, 86.54166F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 2, 2, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.xrTableRow3,
            this.xrTableRow4,
            this.xrTableRow5,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow8,
            this.xrTableRow9,
            this.xrTableRow10,
            this.xrTableRow11,
            this.xrTableRow12,
            this.xrTableRow13});
        this.xrTable1.SizeF = new System.Drawing.SizeF(730.9995F, 325F);
        this.xrTable1.StylePriority.UseBorderColor = false;
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Diễn giải / Description";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell2.Weight = 1.6590911800639763D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "Thành tiền / Amount(đ)";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell3.Weight = 1.2416194950923862D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "R / Ghi chú";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell4.Weight = 1.8143913656599637D;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrt_hesoluong,
            this.xrTableCell8});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Text = "Hệ số lương";
        this.xrTableCell6.Weight = 1.6590911800639763D;
        // 
        // xrt_hesoluong
        // 
        this.xrt_hesoluong.Name = "xrt_hesoluong";
        this.xrt_hesoluong.StylePriority.UseBorders = false;
        this.xrt_hesoluong.StylePriority.UseTextAlignment = false;
        this.xrt_hesoluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_hesoluong.Weight = 1.2416194950923862D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.Weight = 1.8143913656599637D;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrt_tongcong,
            this.xrTableCell12});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.StylePriority.UseFont = false;
        this.xrTableCell10.Text = "Tổng công ";
        this.xrTableCell10.Weight = 1.6590911800639763D;
        // 
        // xrt_tongcong
        // 
        this.xrt_tongcong.Name = "xrt_tongcong";
        this.xrt_tongcong.StylePriority.UseTextAlignment = false;
        this.xrt_tongcong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_tongcong.Weight = 1.2416194950923862D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.Weight = 1.8143913656599637D;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrt_tongluong,
            this.xrTableCell16});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.Text = "Tổng lương";
        this.xrTableCell14.Weight = 1.6590911800639763D;
        // 
        // xrt_tongluong
        // 
        this.xrt_tongluong.Name = "xrt_tongluong";
        this.xrt_tongluong.StylePriority.UseBorders = false;
        this.xrt_tongluong.StylePriority.UseTextAlignment = false;
        this.xrt_tongluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_tongluong.Weight = 1.2416194950923862D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.Weight = 1.8143913656599637D;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell18,
            this.xrt_songuoiphuthuoc,
            this.xrTableCell20});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseBorders = false;
        this.xrTableCell18.Text = "Số người phụ thuộc ";
        this.xrTableCell18.Weight = 1.6590911800639763D;
        // 
        // xrt_songuoiphuthuoc
        // 
        this.xrt_songuoiphuthuoc.Name = "xrt_songuoiphuthuoc";
        this.xrt_songuoiphuthuoc.StylePriority.UseBorders = false;
        this.xrt_songuoiphuthuoc.StylePriority.UseTextAlignment = false;
        this.xrt_songuoiphuthuoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_songuoiphuthuoc.Weight = 1.2416194950923862D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.Weight = 1.8143913656599637D;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22,
            this.xrt_tonggiamtru,
            this.xrTableCell24});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseBorders = false;
        this.xrTableCell22.Text = "Tổng giảm trừ";
        this.xrTableCell22.Weight = 1.6590911800639763D;
        // 
        // xrt_tonggiamtru
        // 
        this.xrt_tonggiamtru.Name = "xrt_tonggiamtru";
        this.xrt_tonggiamtru.StylePriority.UseBorders = false;
        this.xrt_tonggiamtru.StylePriority.UseTextAlignment = false;
        this.xrt_tonggiamtru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_tonggiamtru.Weight = 1.2416194950923862D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseBorders = false;
        this.xrTableCell24.Weight = 1.8143913656599637D;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell26,
            this.xrt_conlinh,
            this.xrTableCell28});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.Text = "Còn lĩnh";
        this.xrTableCell26.Weight = 1.6590911800639763D;
        // 
        // xrt_conlinh
        // 
        this.xrt_conlinh.Name = "xrt_conlinh";
        this.xrt_conlinh.StylePriority.UseBorders = false;
        this.xrt_conlinh.StylePriority.UseTextAlignment = false;
        this.xrt_conlinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_conlinh.Weight = 1.2416194950923862D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.Weight = 1.8143913656599637D;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell30,
            this.xrt_thuclinh,
            this.xrTableCell32});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.StylePriority.UseBorders = false;
        this.xrTableCell30.Text = "Thực lĩnh";
        this.xrTableCell30.Weight = 1.6590911800639763D;
        // 
        // xrt_thuclinh
        // 
        this.xrt_thuclinh.Name = "xrt_thuclinh";
        this.xrt_thuclinh.StylePriority.UseBorders = false;
        this.xrt_thuclinh.StylePriority.UseTextAlignment = false;
        this.xrt_thuclinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_thuclinh.Weight = 1.2416194950923862D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.Weight = 1.8143913656599637D;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell34,
            this.xrt_tongphucap,
            this.xrTableCell36});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.StylePriority.UseBorders = false;
        this.xrTableCell34.Text = "Tổng phụ cấp";
        this.xrTableCell34.Weight = 1.6590911800639763D;
        // 
        // xrt_tongphucap
        // 
        this.xrt_tongphucap.Name = "xrt_tongphucap";
        this.xrt_tongphucap.StylePriority.UseBorders = false;
        this.xrt_tongphucap.StylePriority.UseTextAlignment = false;
        this.xrt_tongphucap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_tongphucap.Weight = 1.2416194950923862D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.Weight = 1.8143913656599637D;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell38,
            this.xrt_giamtruthunhapcanhan,
            this.xrTableCell40});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.StylePriority.UseBorders = false;
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.Text = "Giảm trừ thu nhập cá nhân";
        this.xrTableCell38.Weight = 1.6590911800639763D;
        // 
        // xrt_giamtruthunhapcanhan
        // 
        this.xrt_giamtruthunhapcanhan.Name = "xrt_giamtruthunhapcanhan";
        this.xrt_giamtruthunhapcanhan.StylePriority.UseBorders = false;
        this.xrt_giamtruthunhapcanhan.StylePriority.UseTextAlignment = false;
        this.xrt_giamtruthunhapcanhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_giamtruthunhapcanhan.Weight = 1.2416194950923862D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.StylePriority.UseBorders = false;
        this.xrTableCell40.Weight = 1.8143913656599637D;
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell42,
            this.xrt_giamtrubhyt,
            this.xrTableCell44});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell42
        // 
        this.xrTableCell42.Name = "xrTableCell42";
        this.xrTableCell42.StylePriority.UseBorders = false;
        this.xrTableCell42.Text = "Giảm trừ Bảo hiểm Y Tế";
        this.xrTableCell42.Weight = 1.6590911800639763D;
        // 
        // xrt_giamtrubhyt
        // 
        this.xrt_giamtrubhyt.Name = "xrt_giamtrubhyt";
        this.xrt_giamtrubhyt.StylePriority.UseBorders = false;
        this.xrt_giamtrubhyt.StylePriority.UseTextAlignment = false;
        this.xrt_giamtrubhyt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_giamtrubhyt.Weight = 1.2416194950923862D;
        // 
        // xrTableCell44
        // 
        this.xrTableCell44.Name = "xrTableCell44";
        this.xrTableCell44.StylePriority.UseBorders = false;
        this.xrTableCell44.Weight = 1.8143913656599637D;
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell46,
            this.xrt_giamtrubhxh,
            this.xrTableCell48});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.Text = "Giảm trừ Bảo hiểm xã hội";
        this.xrTableCell46.Weight = 1.6590911800639763D;
        // 
        // xrt_giamtrubhxh
        // 
        this.xrt_giamtrubhxh.Name = "xrt_giamtrubhxh";
        this.xrt_giamtrubhxh.StylePriority.UseTextAlignment = false;
        this.xrt_giamtrubhxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_giamtrubhxh.Weight = 1.2416194950923862D;
        // 
        // xrTableCell48
        // 
        this.xrTableCell48.Name = "xrTableCell48";
        this.xrTableCell48.Weight = 1.8143913656599637D;
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell50,
            this.xrt_giamtruthatnghiep,
            this.xrTableCell52});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrTableCell50
        // 
        this.xrTableCell50.Name = "xrTableCell50";
        this.xrTableCell50.Text = "Giảm trừ thất nghiệp";
        this.xrTableCell50.Weight = 1.6590911800639763D;
        // 
        // xrt_giamtruthatnghiep
        // 
        this.xrt_giamtruthatnghiep.Name = "xrt_giamtruthatnghiep";
        this.xrt_giamtruthatnghiep.StylePriority.UseTextAlignment = false;
        this.xrt_giamtruthatnghiep.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrt_giamtruthatnghiep.Weight = 1.2416194950923862D;
        // 
        // xrTableCell52
        // 
        this.xrTableCell52.Name = "xrTableCell52";
        this.xrTableCell52.Weight = 1.8143913656599637D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 12F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 284F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TenThanhPho,
            this.xrl_TenCongTy,
            this.xrl_ThangTraLuong,
            this.xrl_tenbaocao});
        this.PageHeader.HeightF = 110.5F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "Ủy ban nhân dân Huyện Từ Liêm";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "Xí Nghiệp Môi trường đô thị";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ThangTraLuong
        // 
        this.xrl_ThangTraLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_ThangTraLuong.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
        this.xrl_ThangTraLuong.Name = "xrl_ThangTraLuong";
        this.xrl_ThangTraLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ThangTraLuong.SizeF = new System.Drawing.SizeF(722F, 23F);
        this.xrl_ThangTraLuong.StylePriority.UseFont = false;
        this.xrl_ThangTraLuong.StylePriority.UseTextAlignment = false;
        this.xrl_ThangTraLuong.Text = "Tháng 2 năm 2013";
        this.xrl_ThangTraLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_tenbaocao
        // 
        this.xrl_tenbaocao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_tenbaocao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.5F);
        this.xrl_tenbaocao.Multiline = true;
        this.xrl_tenbaocao.Name = "xrl_tenbaocao";
        this.xrl_tenbaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_tenbaocao.SizeF = new System.Drawing.SizeF(722F, 23F);
        this.xrl_tenbaocao.StylePriority.UseFont = false;
        this.xrl_tenbaocao.StylePriority.UseTextAlignment = false;
        this.xrl_tenbaocao.Text = "PHIẾU TRẢ LƯƠNG\r\n";
        this.xrl_tenbaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_chukythuquy,
            this.xrl_chukynguoinhantien,
            this.xrl_nguoinhantien,
            this.xrl_ngayketxuat,
            this.xrl_thuquy});
        this.PageFooter.HeightF = 166F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrl_chukythuquy
        // 
        this.xrl_chukythuquy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_chukythuquy.LocationFloat = new DevExpress.Utils.PointFloat(433.0416F, 143F);
        this.xrl_chukythuquy.Name = "xrl_chukythuquy";
        this.xrl_chukythuquy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_chukythuquy.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
        this.xrl_chukythuquy.StylePriority.UseFont = false;
        this.xrl_chukythuquy.StylePriority.UseTextAlignment = false;
        this.xrl_chukythuquy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_chukynguoinhantien
        // 
        this.xrl_chukynguoinhantien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_chukynguoinhantien.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 143F);
        this.xrl_chukynguoinhantien.Name = "xrl_chukynguoinhantien";
        this.xrl_chukynguoinhantien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_chukynguoinhantien.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
        this.xrl_chukynguoinhantien.StylePriority.UseFont = false;
        this.xrl_chukynguoinhantien.StylePriority.UseTextAlignment = false;
        this.xrl_chukynguoinhantien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_nguoinhantien
        // 
        this.xrl_nguoinhantien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_nguoinhantien.LocationFloat = new DevExpress.Utils.PointFloat(8.041573F, 25F);
        this.xrl_nguoinhantien.Name = "xrl_nguoinhantien";
        this.xrl_nguoinhantien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_nguoinhantien.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
        this.xrl_nguoinhantien.StylePriority.UseFont = false;
        this.xrl_nguoinhantien.StylePriority.UseTextAlignment = false;
        this.xrl_nguoinhantien.Text = "Người nhận tiền/ Recipient";
        this.xrl_nguoinhantien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ngayketxuat
        // 
        this.xrl_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(433.0416F, 0F);
        this.xrl_ngayketxuat.Name = "xrl_ngayketxuat";
        this.xrl_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ngayketxuat.SizeF = new System.Drawing.SizeF(296.875F, 23F);
        this.xrl_ngayketxuat.StylePriority.UseFont = false;
        this.xrl_ngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrl_ngayketxuat.Text = "Hà Nội ngày .........tháng .........năm...........";
        this.xrl_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_thuquy
        // 
        this.xrl_thuquy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_thuquy.LocationFloat = new DevExpress.Utils.PointFloat(433.0416F, 25F);
        this.xrl_thuquy.Name = "xrl_thuquy";
        this.xrl_thuquy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_thuquy.SizeF = new System.Drawing.SizeF(296.8749F, 23F);
        this.xrl_thuquy.StylePriority.UseFont = false;
        this.xrl_thuquy.StylePriority.UseTextAlignment = false;
        this.xrl_thuquy.Text = "Thủ quỹ/ Treasurer";
        this.xrl_thuquy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1.083867F, 435.4167F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(729.916F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Chúc Ông, Bà và gia đình mạnh khỏe hạnh phúc và thành đạt. Xin cảm ơn !";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PhieuTraLuong1
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
        this.Margins = new System.Drawing.Printing.Margins(61, 58, 12, 284);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
