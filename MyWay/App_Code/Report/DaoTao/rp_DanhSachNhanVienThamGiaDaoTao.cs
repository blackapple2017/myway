using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_DanhSachNhanVienThamGiaDaoTao
/// </summary>
public class rp_DanhSachNhanVienThamGiaDaoTao : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_NgayBaoCao;
    private XRLabel xrl_TenCongTy;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hoten;
    private XRTableCell xrt_Email;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer1;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrl_groupphongban;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLTenKhoaDaoTao;
    private XRLabel xrLMaKhoaHoc;
    private XRLabel xrLThoiGianBatDau;
    private XRLabel xrLThoiGianKetThuc;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRTableCell xrTDienThoai;
    private XRTableCell xrTChucVu;
    private XRTableCell xrTDiem;
    private XRTableCell xrTKetQua;
    private XRTableCell xrTableCell6;
    private XRTableCell xrMaCB;
    private XRPictureBox xrLogo;
    private XRTableCell xrTableCell8;
    private XRTableCell xrDiaDiemLamViec;
    private XRTableRow xrTableRow5;
    private XRTableCell xrtGhiChu;
    private XRTableCell xrtGiaoVienNhanXet;
    private XRTableRow xrTableRow4;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_DanhSachNhanVienThamGiaDaoTao()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrt_stt.Text = STT.ToString();
        STT++;
    }
    public void BindData(ReportFilter filter)
    { 
        try
        {
            ReportController rpCtr = new ReportController();
            xrl_NgayBaoCao.Text = "Ngày báo cáo: " + string.Format("{0:dd/MM/yyyy}", DateTime.Now);            
            xrLogo.ImageUrl = ReportController.GetInstance().GetLogoCompany(filter.SessionDepartment);
            xrtngayketxuat.Text = new ReportController().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
            xrl_TenCongTy.Text = rpCtr.GetCompanyName(filter.SessionDepartment);
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("GetDanhSachNhanVienThamGiaDaoTao", "@MaDonVi",
                                                                                             "@MaBoPhan",
                                                                                             "@Gender",
                                                                                             "@WorkingStatus",
                                                                                             "@MinSeniority",
                                                                                             "@MaxSeniority",
                                                                                             "@WhereClause",
                                                                                            filter.SessionDepartment,
                                                                                            filter.SelectedDepartment,
                                                                                            filter.Gender,
                                                                                            filter.WorkingStatus,
                                                                                            filter.MinSeniority,
                                                                                            filter.MaxSeniority,
                                                                                            filter.WhereClause);
            DataSource = table;
            xrLTenKhoaDaoTao.DataBindings.Add("Text", DataSource, "TEN_KHOA_HOC"); 
            xrLThoiGianBatDau.DataBindings.Add("Text", DataSource, "TU_NGAY", "{0:dd/MM/yyyy}");
            xrLThoiGianKetThuc.DataBindings.Add("Text", DataSource, "DEN_NGAY", "{0:dd/MM/yyyy}"); 
            xrLMaKhoaHoc.DataBindings.Add("Text", DataSource, "MA");
            xrt_hoten.DataBindings.Add("Text", DataSource, "HO_TEN");
            xrTDienThoai.DataBindings.Add("Text", DataSource, "DI_DONG");
            xrMaCB.DataBindings.Add("Text", DataSource, "MaCanBo");
            xrt_Email.DataBindings.Add("Text", DataSource, "EMAIL");
            xrTChucVu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU"); 
            xrTDiem.DataBindings.Add("Text", DataSource, "SoDiem");
            xrTKetQua.DataBindings.Add("Text", DataSource, "KetQua");
            xrDiaDiemLamViec.DataBindings.Add("Text", DataSource, "TEN_DIADIEM");
            xrtGhiChu.DataBindings.Add("Text", DataSource, "GhiChu", "Ghi chú: {0}");
            xrtGiaoVienNhanXet.DataBindings.Add("Text", DataSource, "NhanXetCuaGiaoVien", "Giáo viên nhận xét: {0}");
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MA_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)});
            xrl_groupphongban.DataBindings.Add("Text", DataSource, "TEN_PHONG").ToString().ToUpper();
            

            if (!string.IsNullOrEmpty(filter.Title1))
            {
                xrl_footer1.Text = filter.Title1;
            }
            else
            {
                xrl_footer1.Text = rpCtr.GetTitleOfSignature(xrl_footer1.Text, filter.Title1);
            }
            if (!string.IsNullOrEmpty(filter.Title2))
            {
                xrl_footer2.Text = filter.Title2;
            }
            else
            {
                xrl_footer2.Text = rpCtr.GetTitleOfSignature(xrl_footer2.Text, filter.Title2);
            }
            if (!string.IsNullOrEmpty(filter.Title3))
            {
                xrl_footer3.Text = filter.Title3;
            }
            else
            {
                xrl_footer3.Text = rpCtr.GetTitleOfSignature(xrl_footer3.Text, filter.Title3);
            }
            if (!string.IsNullOrEmpty(filter.Name1))
            {
                xrl_ten1.Text = filter.Name1;
            }
            else
            {
                xrl_ten1.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
            }
            if (!string.IsNullOrEmpty(filter.Name2))
            {
                xrl_ten2.Text = filter.Name2;
            }
            else
            {
                xrl_ten2.Text = rpCtr.GetHeadOfHRroom(filter.SessionDepartment, filter.Name2);
            }
            if (!string.IsNullOrEmpty(filter.Name3))
            {
                xrl_ten3.Text = filter.Name3;
            }
            else
            {
                xrl_ten3.Text = rpCtr.GetDirectorName(filter.SessionDepartment, filter.Name3);
            }
            //tieu de
            if (!string.IsNullOrEmpty(filter.ReportTitle))
            {
                xrl_TitleBC.Text = filter.ReportTitle;
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
            string resourceFileName = "rp_DanhSachNhanVienThamGiaDaoTao.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrMaCB = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTDienThoai = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_Email = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTChucVu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrDiaDiemLamViec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTDiem = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTKetQua = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLThoiGianBatDau = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLThoiGianKetThuc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLMaKhoaHoc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLTenKhoaDaoTao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NgayBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrl_groupphongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtGhiChu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtGiaoVienNhanXet = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 79.16666F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow5,
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1111F, 75F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrMaCB,
            this.xrt_hoten,
            this.xrTDienThoai,
            this.xrt_Email,
            this.xrTChucVu,
            this.xrDiaDiemLamViec,
            this.xrTDiem,
            this.xrTKetQua});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Weight = 0.13613175372688136D;
            this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrMaCB
            // 
            this.xrMaCB.Name = "xrMaCB";
            this.xrMaCB.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrMaCB.StylePriority.UsePadding = false;
            this.xrMaCB.StylePriority.UseTextAlignment = false;
            this.xrMaCB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrMaCB.Weight = 0.24181243739861111D;
            // 
            // xrt_hoten
            // 
            this.xrt_hoten.Name = "xrt_hoten";
            this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrt_hoten.StylePriority.UsePadding = false;
            this.xrt_hoten.StylePriority.UseTextAlignment = false;
            this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hoten.Weight = 0.37370310817048974D;
            // 
            // xrTDienThoai
            // 
            this.xrTDienThoai.Name = "xrTDienThoai";
            this.xrTDienThoai.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrTDienThoai.StylePriority.UsePadding = false;
            this.xrTDienThoai.StylePriority.UseTextAlignment = false;
            this.xrTDienThoai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTDienThoai.Weight = 0.37821026699876847D;
            // 
            // xrt_Email
            // 
            this.xrt_Email.Name = "xrt_Email";
            this.xrt_Email.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrt_Email.StylePriority.UsePadding = false;
            this.xrt_Email.StylePriority.UseTextAlignment = false;
            this.xrt_Email.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_Email.Weight = 0.31677914573635213D;
            // 
            // xrTChucVu
            // 
            this.xrTChucVu.Name = "xrTChucVu";
            this.xrTChucVu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrTChucVu.StylePriority.UsePadding = false;
            this.xrTChucVu.StylePriority.UseTextAlignment = false;
            this.xrTChucVu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTChucVu.Weight = 0.31453102659405191D;
            // 
            // xrDiaDiemLamViec
            // 
            this.xrDiaDiemLamViec.Name = "xrDiaDiemLamViec";
            this.xrDiaDiemLamViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrDiaDiemLamViec.StylePriority.UsePadding = false;
            this.xrDiaDiemLamViec.StylePriority.UseTextAlignment = false;
            this.xrDiaDiemLamViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrDiaDiemLamViec.Weight = 0.42537394682357482D;
            // 
            // xrTDiem
            // 
            this.xrTDiem.Name = "xrTDiem";
            this.xrTDiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
            this.xrTDiem.StylePriority.UsePadding = false;
            this.xrTDiem.StylePriority.UseTextAlignment = false;
            this.xrTDiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTDiem.Weight = 0.32568001666279456D;
            // 
            // xrTKetQua
            // 
            this.xrTKetQua.Name = "xrTKetQua";
            this.xrTKetQua.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrTKetQua.StylePriority.UsePadding = false;
            this.xrTKetQua.StylePriority.UseTextAlignment = false;
            this.xrTKetQua.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTKetQua.Weight = 0.48777829788847565D;
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
            this.BottomMargin.HeightF = 35F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLogo,
            this.xrLThoiGianBatDau,
            this.xrLThoiGianKetThuc,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLMaKhoaHoc,
            this.xrLTenKhoaDaoTao,
            this.xrLabel2,
            this.xrLabel1,
            this.xrl_TitleBC,
            this.xrl_NgayBaoCao,
            this.xrl_TenCongTy});
            this.ReportHeader.HeightF = 304F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLogo
            // 
            this.xrLogo.LocationFloat = new DevExpress.Utils.PointFloat(57.45833F, 0F);
            this.xrLogo.Name = "xrLogo";
            this.xrLogo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLogo.SizeF = new System.Drawing.SizeF(110F, 110F);
            this.xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrLogo.StylePriority.UsePadding = false;
            // 
            // xrLThoiGianBatDau
            // 
            this.xrLThoiGianBatDau.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLThoiGianBatDau.LocationFloat = new DevExpress.Utils.PointFloat(755.7022F, 223F);
            this.xrLThoiGianBatDau.Name = "xrLThoiGianBatDau";
            this.xrLThoiGianBatDau.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLThoiGianBatDau.SizeF = new System.Drawing.SizeF(305.5002F, 23F);
            this.xrLThoiGianBatDau.StylePriority.UseFont = false;
            // 
            // xrLThoiGianKetThuc
            // 
            this.xrLThoiGianKetThuc.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLThoiGianKetThuc.LocationFloat = new DevExpress.Utils.PointFloat(755.7022F, 248F);
            this.xrLThoiGianKetThuc.Name = "xrLThoiGianKetThuc";
            this.xrLThoiGianKetThuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLThoiGianKetThuc.SizeF = new System.Drawing.SizeF(305.4998F, 23F);
            this.xrLThoiGianKetThuc.StylePriority.UseFont = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(617.2441F, 223F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(138.4581F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Thời gian bắt đầu:";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(617.2441F, 248F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(138.4582F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Thời gian kết thúc:";
            // 
            // xrLMaKhoaHoc
            // 
            this.xrLMaKhoaHoc.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLMaKhoaHoc.LocationFloat = new DevExpress.Utils.PointFloat(155.1191F, 248F);
            this.xrLMaKhoaHoc.Name = "xrLMaKhoaHoc";
            this.xrLMaKhoaHoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLMaKhoaHoc.SizeF = new System.Drawing.SizeF(369.7917F, 23F);
            this.xrLMaKhoaHoc.StylePriority.UseFont = false;
            // 
            // xrLTenKhoaDaoTao
            // 
            this.xrLTenKhoaDaoTao.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLTenKhoaDaoTao.LocationFloat = new DevExpress.Utils.PointFloat(155.1191F, 225F);
            this.xrLTenKhoaDaoTao.Name = "xrLTenKhoaDaoTao";
            this.xrLTenKhoaDaoTao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLTenKhoaDaoTao.SizeF = new System.Drawing.SizeF(369.7917F, 23F);
            this.xrLTenKhoaDaoTao.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(25.9524F, 248F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(129.1667F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Mã khoa học: ";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(25.9524F, 225F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(129.1667F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Tên khóa đào tạo: ";
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 161.5F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1111F, 23.00002F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "DANH SÁCH NHÂN VIÊN THAM GIA ĐÀO TẠO";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_NgayBaoCao
            // 
            this.xrl_NgayBaoCao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_NgayBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 186.5F);
            this.xrl_NgayBaoCao.Name = "xrl_NgayBaoCao";
            this.xrl_NgayBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NgayBaoCao.SizeF = new System.Drawing.SizeF(1111F, 23.00002F);
            this.xrl_NgayBaoCao.StylePriority.UseFont = false;
            this.xrl_NgayBaoCao.StylePriority.UseTextAlignment = false;
            this.xrl_NgayBaoCao.Text = "Từ ngày 14/3/2013 đến ngày 14/3/2013";
            this.xrl_NgayBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 111.5F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(755.7023F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UsePadding = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 27.08333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1111F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell6,
            this.xrTableCell4,
            this.xrTableCell7,
            this.xrTableCell5,
            this.xrTableCell2,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.13613175372688136D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Mã nhân viên";
            this.xrTableCell6.Weight = 0.26635428843281772D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ tên";
            this.xrTableCell4.Weight = 0.39796953344286617D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Số điện thoại";
            this.xrTableCell7.Weight = 0.40276938016246006D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Email";
            this.xrTableCell5.Weight = 0.33734924344000616D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Chức vụ";
            this.xrTableCell2.Weight = 0.33495529764773629D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Địa điểm làm việc";
            this.xrTableCell8.Weight = 0.45299554682979237D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Điểm";
            this.xrTableCell9.Weight = 0.34682806942193689D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Kết quả";
            this.xrTableCell10.Weight = 0.51945208170069779D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten1,
            this.xrl_ten2,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer3,
            this.xrl_footer2,
            this.xrl_footer1});
            this.ReportFooter.HeightF = 167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 134F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(295.9319F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(399.2502F, 134F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(295.9319F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(835.7085F, 134F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(289.2498F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(809.7493F, 12.5F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(289.2498F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(809.7493F, 37.5F);
            this.xrl_footer3.Multiline = true;
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(289.25F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "PHÒNG HCNS";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(397.2493F, 37.5F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(297.9328F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "TRƯỞNG PHÒNG HCNS";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(22.24928F, 37.5F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(297.9328F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StylePriority.UseBackColor = false;
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
            this.xrTable3.SizeF = new System.Drawing.SizeF(1111F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrl_groupphongban});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrl_groupphongban
            // 
            this.xrl_groupphongban.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrl_groupphongban.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_groupphongban.Name = "xrl_groupphongban";
            this.xrl_groupphongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrl_groupphongban.StylePriority.UseBorders = false;
            this.xrl_groupphongban.StylePriority.UseFont = false;
            this.xrl_groupphongban.StylePriority.UsePadding = false;
            this.xrl_groupphongban.StylePriority.UseTextAlignment = false;
            this.xrl_groupphongban.Text = "Phòng ban";
            this.xrl_groupphongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrl_groupphongban.Weight = 3D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtGhiChu});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrtGhiChu
            // 
            this.xrtGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.xrtGhiChu.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.xrtGhiChu.Multiline = true;
            this.xrtGhiChu.Name = "xrtGhiChu";
            this.xrtGhiChu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrtGhiChu.StylePriority.UseBackColor = false;
            this.xrtGhiChu.StylePriority.UseFont = false;
            this.xrtGhiChu.StylePriority.UsePadding = false;
            this.xrtGhiChu.StylePriority.UseTextAlignment = false;
            this.xrtGhiChu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtGhiChu.Weight = 1.4999999999999998D;
            // 
            // xrtGiaoVienNhanXet
            // 
            this.xrtGiaoVienNhanXet.BackColor = System.Drawing.Color.Transparent;
            this.xrtGiaoVienNhanXet.BorderColor = System.Drawing.Color.Black;
            this.xrtGiaoVienNhanXet.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.xrtGiaoVienNhanXet.Multiline = true;
            this.xrtGiaoVienNhanXet.Name = "xrtGiaoVienNhanXet";
            this.xrtGiaoVienNhanXet.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrtGiaoVienNhanXet.StylePriority.UseBackColor = false;
            this.xrtGiaoVienNhanXet.StylePriority.UseBorderColor = false;
            this.xrtGiaoVienNhanXet.StylePriority.UseFont = false;
            this.xrtGiaoVienNhanXet.StylePriority.UsePadding = false;
            this.xrtGiaoVienNhanXet.StylePriority.UseTextAlignment = false;
            this.xrtGiaoVienNhanXet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtGiaoVienNhanXet.Weight = 4.4999999999999991D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtGiaoVienNhanXet});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // rp_DanhSachNhanVienThamGiaDaoTao
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupHeader1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(34, 24, 50, 35);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
