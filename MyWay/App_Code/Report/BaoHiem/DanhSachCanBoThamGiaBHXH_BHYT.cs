using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using DataController;
using System.Data;

/// <summary>
/// Summary description for DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH
/// </summary>
public class DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH : XtraReport
{
    private DetailBand Detail;
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_NgayBaoCao;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrl_tendonvi;
    private XRLabel xrl_madonvi;
    private XRLabel xrl_dienthoai;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrTitle2;
    private XRLabel xrt_ngayketxuat;
    private XRLabel xrTitle3;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrt_stt3;
    private XRTableCell xrt_hoten;
    private XRTableCell xrt_maso;
    private XRTableCell xrt_capbac;
    private XRTableCell xrt_tienluongmoi;
    private XRTableCell xrt_chucvumoi;
    private XRTableCell xrt_tnvk;
    private XRTableCell xrt_thamniennghemoi;
    private XRTableCell xrt_tuthangnam;
    private XRTableCell xrt_ghichu;
    private FormattingRule BoiDen;
    private FormattingRule DenNghieng;
    private XRPageInfo xrPageInfo1;
    private FormattingRule Xoa0;
    private XRLabel xrName2;
    private XRLabel xrName3;
    private GroupHeaderBand GroupHeader1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell12;
    private XRLabel xrLabel8;
    private XRLabel xrLabel1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRLabel xrLabel2;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell3;
    private XRTableCell xrt_PCK;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    public DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        xrl_NgayBaoCao.Text = " Tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
    }

    public void BindData(ReportFilter filter)
    {
        var rpc = new ReportController();
        xrl_tendonvi.Text = "TÊN ĐƠN VỊ: " + ReportController.GetInstance().GetCompanyName(filter.SessionDepartment).ToUpper();
        xrl_madonvi.Text = "MÃ ĐƠN VỊ: " + filter.SessionDepartment.ToUpper();
        //xrl_dienthoai.Text = "Điện thoại liên hệ: " + ReportController.GetInstance().GetCompanyPhoneNumber(filter.SessionDepartment);
        xrl_dienthoai.Text = "Địa chỉ: " + ReportController.GetInstance().GetCompanyAddress(filter.SessionDepartment);
        if (!string.IsNullOrEmpty(filter.WhereClause) && filter.WhereClause != "1 = 1")
        {
            BHDauPhieuController bh = new BHDauPhieuController();

            int id = 0;
            DAL.BHDAUPHIEU cd = null;
            try
            {
                if (!int.TryParse(filter.WhereClause, out id))
                {
                    filter.WhereClause = filter.WhereClause.Substring(17);
                    filter.WhereClause = filter.WhereClause.Substring(0, filter.WhereClause.LastIndexOf("'"));
                    int.TryParse(filter.WhereClause, out id);
                    //  (IDDauPhieu = N '103')
                }
                cd = bh.GetByIdDauPhieu(id);
            }
            catch (Exception)
            {
            }

            //filter.WhereClause.Substring()
            //if (cd.TuNgay != null && cd.DenNgay != null)
            //{
                //xrl_NgayBaoCao.Text = ReportController.GetInstance().GetFromDateToDate(cd.TuNgay, cd.DenNgay);
            xrl_NgayBaoCao.Text = "Số 1, tháng " + filter.StartMonth + " năm " + filter.Year ;
            //}

            DataSource = DataHandler.GetInstance().ExecuteDataTable("sp_BHD02-TS",
                    "@WhereClause", "@NgayBatDau", "@NgayKetThuc", "@Month", "@StartMonth", "@EndMonth", "@Year", "@MaBoPhan",
                    filter.WhereClause, filter.StartDate, filter.EndDate, filter.StartMonth, filter.StartMonth, filter.EndMonth, filter.Year, filter.SelectedDepartment);
        }
        else
        {
            //xrl_NgayBaoCao.Text = ReportController.GetInstance().GetFromDateToDate(filter.StartDate, filter.EndDate);
            xrl_NgayBaoCao.Text = "Số 1, tháng " + filter.StartMonth + " năm " + filter.Year;
            DataSource = DataHandler.GetInstance().ExecuteDataTable("sp_BHD02-TS", 
                    "@WhereClause", "@NgayBatDau", "@NgayKetThuc", "@Month", "@StartMonth", "@EndMonth", "@Year", "@MaBoPhan", 
                    filter.WhereClause, filter.StartDate, filter.EndDate, filter.StartMonth, filter.StartMonth, filter.EndMonth, filter.Year, filter.SelectedDepartment);
        }
        xrt_stt3.DataBindings.Add("Text", DataSource, "STT");
        xrt_hoten.DataBindings.Add("Text", DataSource, "HoTen");
        xrt_maso.DataBindings.Add("Text", DataSource, "SoSoBHXH");
        //xrt_ngaysinh.DataBindings.Add("Text", DataSource, "NgaySinh", "{0:dd/MM/yyyy}");
        //xrt_gioitinh.DataBindings.Add("Text", DataSource, "GioiTinh");
        xrt_capbac.DataBindings.Add("Text", DataSource, "ChucVu");
        //xrt_tienluongcu.DataBindings.Add("Text", DataSource, "TienLuongCu", "{0:n0}");
        //xrt_chucvucu.DataBindings.Add("Text", DataSource, "PhuCapCVCu", "{0:n0}");
        //xrt_thamnienvkcu.DataBindings.Add("Text", DataSource, "PhuCapTNVKCu", "{0:n0}");
        //xrt_tnnghe.DataBindings.Add("Text", DataSource, "PhuCapNgheCu", "{0:n0}");
        xrt_tienluongmoi.DataBindings.Add("Text", DataSource, "TienLuongMoi", "{0:n0}");
        xrt_chucvumoi.DataBindings.Add("Text", DataSource, "PhuCapCVMoi", "{0:n0}");
        xrt_tnvk.DataBindings.Add("Text", DataSource, "PhuCapTNVKMoi", "{0:n0}");
        xrt_thamniennghemoi.DataBindings.Add("Text", DataSource, "PhuCapTNNgheMoi", "{0:n0}");
        xrt_PCK.DataBindings.Add("Text", DataSource, "PhuCapKhac", "{0:n0}");
        xrt_tuthangnam.DataBindings.Add("Text", DataSource, "TuNgay");      
        //xrt_denthangnam.DataBindings.Add("Text", DataSource, "DenNgay");
        //xrt_trathe.DataBindings.Add("Text", DataSource, "KhongTraThe");
        //xrt_sobhxh.DataBindings.Add("Text", DataSource, "DaCoSo");
        xrt_ghichu.DataBindings.Add("Text", DataSource, "Ghichu");
        //xrt_ngayketxuat.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        if (filter.ReportedDate != null)
        {
            xrt_ngayketxuat.Text = ReportController.GetInstance().GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        }
        else
        {
            xrt_ngayketxuat.Text = ReportController.GetInstance().GetFooterReport(filter.SessionDepartment, DateTime.Now);
        }
        //this.ShowDesigner();
        //if (!string.IsNullOrEmpty(filter.Title1))
        //{
        //    xrTitle1.Text = filter.Title1;
        //}
        if (!string.IsNullOrEmpty(filter.Title2))
        {
            xrTitle2.Text = filter.Title2;
        }
        if (!string.IsNullOrEmpty(filter.Title3))
        {
            xrTitle3.Text = filter.Title3;
        }
        //if (!string.IsNullOrEmpty(filter.Name1))
        //{
        //    xrName1.Text = filter.Name1;
        //}
        if (!string.IsNullOrEmpty(filter.Name2))
        {
            xrName2.Text = filter.Name2;
        }
        if (!string.IsNullOrEmpty(filter.Name3))
        {
            xrName3.Text = filter.Name3;
        }

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
            string resourceFileName = "DanhSachCanBoThamGiaBHXH_BHYT.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.BoiDen = new DevExpress.XtraReports.UI.FormattingRule();
            this.DenNghieng = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hoten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_maso = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_capbac = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tienluongmoi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvumoi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tnvk = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thamniennghemoi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_PCK = new DevExpress.XtraReports.UI.XRTableCell();
            this.Xoa0 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrt_tuthangnam = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ghichu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_dienthoai = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_madonvi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_tendonvi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NgayBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrName3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrName2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTitle3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTitle2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable6
            // 
            this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable6.FormattingRules.Add(this.BoiDen);
            this.xrTable6.FormattingRules.Add(this.DenNghieng);
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(1069.345F, 25F);
            this.xrTable6.StylePriority.UseBorders = false;
            // 
            // BoiDen
            // 
            this.BoiDen.Condition = "[STT]=\'I\' OR [STT]=\'II\' OR [STT]=\'\'";
            // 
            // 
            // 
            this.BoiDen.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoiDen.Name = "BoiDen";
            // 
            // DenNghieng
            // 
            this.DenNghieng.Condition = "[STT]=\'I.1\' OR [STT]=\'I.2\' OR [STT]=\'II.1\' OR [STT]=\'II.2\'  OR [STT]=\'I.3\'  OR [S" +
    "TT]=\'II.3\'";
            // 
            // 
            // 
            this.DenNghieng.Formatting.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DenNghieng.Name = "DenNghieng";
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt3,
            this.xrt_hoten,
            this.xrt_maso,
            this.xrt_capbac,
            this.xrt_tienluongmoi,
            this.xrt_chucvumoi,
            this.xrt_tnvk,
            this.xrt_thamniennghemoi,
            this.xrt_PCK,
            this.xrt_tuthangnam,
            this.xrt_ghichu});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrt_stt3
            // 
            this.xrt_stt3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrt_stt3.Name = "xrt_stt3";
            this.xrt_stt3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrt_stt3.StylePriority.UseFont = false;
            this.xrt_stt3.StylePriority.UsePadding = false;
            this.xrt_stt3.StylePriority.UseTextAlignment = false;
            this.xrt_stt3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_stt3.Weight = 0.079787231506185344D;
            // 
            // xrt_hoten
            // 
            this.xrt_hoten.Name = "xrt_hoten";
            this.xrt_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_hoten.StylePriority.UseFont = false;
            this.xrt_hoten.StylePriority.UsePadding = false;
            this.xrt_hoten.StylePriority.UseTextAlignment = false;
            this.xrt_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hoten.Weight = 0.32529613058617768D;
            // 
            // xrt_maso
            // 
            this.xrt_maso.Name = "xrt_maso";
            this.xrt_maso.StylePriority.UseFont = false;
            this.xrt_maso.StylePriority.UseTextAlignment = false;
            this.xrt_maso.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_maso.Weight = 0.17000652374105249D;
            // 
            // xrt_capbac
            // 
            this.xrt_capbac.Name = "xrt_capbac";
            this.xrt_capbac.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_capbac.StylePriority.UseFont = false;
            this.xrt_capbac.StylePriority.UsePadding = false;
            this.xrt_capbac.StylePriority.UseTextAlignment = false;
            this.xrt_capbac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_capbac.Weight = 0.25327571402204813D;
            // 
            // xrt_tienluongmoi
            // 
            this.xrt_tienluongmoi.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_tienluongmoi.Name = "xrt_tienluongmoi";
            this.xrt_tienluongmoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_tienluongmoi.StylePriority.UseBorders = false;
            this.xrt_tienluongmoi.StylePriority.UseFont = false;
            this.xrt_tienluongmoi.StylePriority.UsePadding = false;
            this.xrt_tienluongmoi.StylePriority.UseTextAlignment = false;
            this.xrt_tienluongmoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tienluongmoi.Weight = 0.15985707288726858D;
            this.xrt_tienluongmoi.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrt_tienluongcu_BeforePrint);
            // 
            // xrt_chucvumoi
            // 
            this.xrt_chucvumoi.Name = "xrt_chucvumoi";
            this.xrt_chucvumoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_chucvumoi.StylePriority.UseFont = false;
            this.xrt_chucvumoi.StylePriority.UsePadding = false;
            this.xrt_chucvumoi.StylePriority.UseTextAlignment = false;
            this.xrt_chucvumoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_chucvumoi.Weight = 0.13929864566059824D;
            this.xrt_chucvumoi.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrt_tienluongcu_BeforePrint);
            // 
            // xrt_tnvk
            // 
            this.xrt_tnvk.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_tnvk.Name = "xrt_tnvk";
            this.xrt_tnvk.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_tnvk.StylePriority.UseBorders = false;
            this.xrt_tnvk.StylePriority.UseFont = false;
            this.xrt_tnvk.StylePriority.UsePadding = false;
            this.xrt_tnvk.StylePriority.UseTextAlignment = false;
            this.xrt_tnvk.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_tnvk.Weight = 0.15349595656895898D;
            this.xrt_tnvk.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrt_tienluongcu_BeforePrint);
            // 
            // xrt_thamniennghemoi
            // 
            this.xrt_thamniennghemoi.Name = "xrt_thamniennghemoi";
            this.xrt_thamniennghemoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_thamniennghemoi.StylePriority.UseFont = false;
            this.xrt_thamniennghemoi.StylePriority.UsePadding = false;
            this.xrt_thamniennghemoi.StylePriority.UseTextAlignment = false;
            this.xrt_thamniennghemoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrt_thamniennghemoi.Weight = 0.14199534178872258D;
            this.xrt_thamniennghemoi.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrt_tienluongcu_BeforePrint);
            // 
            // xrt_PCK
            // 
            this.xrt_PCK.FormattingRules.Add(this.BoiDen);
            this.xrt_PCK.FormattingRules.Add(this.DenNghieng);
            this.xrt_PCK.FormattingRules.Add(this.Xoa0);
            this.xrt_PCK.Name = "xrt_PCK";
            this.xrt_PCK.Weight = 0.14199565659614588D;
            // 
            // Xoa0
            // 
            // 
            // 
            // 
            this.Xoa0.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.Xoa0.Name = "Xoa0";
            // 
            // xrt_tuthangnam
            // 
            this.xrt_tuthangnam.Name = "xrt_tuthangnam";
            this.xrt_tuthangnam.StylePriority.UseFont = false;
            this.xrt_tuthangnam.StylePriority.UseTextAlignment = false;
            this.xrt_tuthangnam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrt_tuthangnam.Weight = 0.32387116908025354D;
            // 
            // xrt_ghichu
            // 
            this.xrt_ghichu.Name = "xrt_ghichu";
            this.xrt_ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_ghichu.StylePriority.UseFont = false;
            this.xrt_ghichu.StylePriority.UsePadding = false;
            this.xrt_ghichu.StylePriority.UseTextAlignment = false;
            this.xrt_ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_ghichu.Weight = 0.24412225031420917D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 34F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 33F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_dienthoai,
            this.xrl_madonvi,
            this.xrl_tendonvi,
            this.xrLabel4,
            this.xrLabel3,
            this.xrl_TenCongTy,
            this.xrl_NgayBaoCao});
            this.ReportHeader.HeightF = 127F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_dienthoai
            // 
            this.xrl_dienthoai.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 50.25002F);
            this.xrl_dienthoai.Name = "xrl_dienthoai";
            this.xrl_dienthoai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_dienthoai.SizeF = new System.Drawing.SizeF(494.3873F, 23.70833F);
            this.xrl_dienthoai.StylePriority.UseFont = false;
            this.xrl_dienthoai.Text = "Điện thoại liên hệ: 38.343451";
            // 
            // xrl_madonvi
            // 
            this.xrl_madonvi.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 27.25004F);
            this.xrl_madonvi.Name = "xrl_madonvi";
            this.xrl_madonvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_madonvi.SizeF = new System.Drawing.SizeF(245.6283F, 23.00001F);
            this.xrl_madonvi.StylePriority.UseFont = false;
            this.xrl_madonvi.Text = "Mã đơn vị: HVWW--1";
            // 
            // xrl_tendonvi
            // 
            this.xrl_tendonvi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_tendonvi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrl_tendonvi.Name = "xrl_tendonvi";
            this.xrl_tendonvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_tendonvi.SizeF = new System.Drawing.SizeF(700.2913F, 27.25004F);
            this.xrl_tendonvi.StylePriority.UseFont = false;
            this.xrl_tendonvi.Text = "Tên đơn vị: CÔNG TY CỔ PHẦN CÔNG NGHỆ VÀ GIẢI PHÁP SỐ DTHSOFT";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(784.5908F, 23.00002F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(284.754F, 33.41666F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "(Ban hành kèm theo CV số 1018/QĐ-BHXH ngày 10/10/2014 của BHXHVN)\r\n\r\n";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(784.2461F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(285.0987F, 23.00001F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Mẫu D02 - TS";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 73.95834F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(1071F, 23.00001F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "DANH SÁCH  LAO ĐỘNG ĐIỀU CHỈNH ĐÓNG BHXH, BHYT, BHTN";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_NgayBaoCao
            // 
            this.xrl_NgayBaoCao.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrl_NgayBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 96.95835F);
            this.xrl_NgayBaoCao.Name = "xrl_NgayBaoCao";
            this.xrl_NgayBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NgayBaoCao.SizeF = new System.Drawing.SizeF(1071F, 23F);
            this.xrl_NgayBaoCao.StylePriority.UseFont = false;
            this.xrl_NgayBaoCao.StylePriority.UseTextAlignment = false;
            this.xrl_NgayBaoCao.Text = "Số:......., tháng....., năm ......";
            this.xrl_NgayBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrName3,
            this.xrName2,
            this.xrTitle3,
            this.xrt_ngayketxuat,
            this.xrTitle2,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel15,
            this.xrLabel16});
            this.ReportFooter.HeightF = 288F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrName3
            // 
            this.xrName3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrName3.LocationFloat = new DevExpress.Utils.PointFloat(756.4246F, 252.9167F);
            this.xrName3.Name = "xrName3";
            this.xrName3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrName3.SizeF = new System.Drawing.SizeF(205.1653F, 23F);
            this.xrName3.StylePriority.UseFont = false;
            this.xrName3.StylePriority.UseTextAlignment = false;
            this.xrName3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrName2
            // 
            this.xrName2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrName2.LocationFloat = new DevExpress.Utils.PointFloat(127.138F, 252.9167F);
            this.xrName2.Name = "xrName2";
            this.xrName2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrName2.SizeF = new System.Drawing.SizeF(181.2069F, 23F);
            this.xrName2.StylePriority.UseFont = false;
            this.xrName2.StylePriority.UseTextAlignment = false;
            this.xrName2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTitle3
            // 
            this.xrTitle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTitle3.LocationFloat = new DevExpress.Utils.PointFloat(756.4246F, 150F);
            this.xrTitle3.Name = "xrTitle3";
            this.xrTitle3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTitle3.SizeF = new System.Drawing.SizeF(205.1653F, 23F);
            this.xrTitle3.StylePriority.UseFont = false;
            this.xrTitle3.StylePriority.UseTextAlignment = false;
            this.xrTitle3.Text = "THỦ TRƯỞNG ĐƠN VỊ";
            this.xrTitle3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_ngayketxuat
            // 
            this.xrt_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(692.9836F, 115.5416F);
            this.xrt_ngayketxuat.Name = "xrt_ngayketxuat";
            this.xrt_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_ngayketxuat.SizeF = new System.Drawing.SizeF(307.2484F, 23F);
            this.xrt_ngayketxuat.StylePriority.UseFont = false;
            this.xrt_ngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrt_ngayketxuat.Text = "Ngày 26 tháng 9 năm 2013";
            this.xrt_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTitle2
            // 
            this.xrTitle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTitle2.LocationFloat = new DevExpress.Utils.PointFloat(127.138F, 150F);
            this.xrTitle2.Name = "xrTitle2";
            this.xrTitle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTitle2.SizeF = new System.Drawing.SizeF(181.2069F, 23F);
            this.xrTitle2.StylePriority.UseFont = false;
            this.xrTitle2.StylePriority.UseTextAlignment = false;
            this.xrTitle2.Text = "NGƯỜI LẬP BIỂU";
            this.xrTitle2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(1.958656F, 62.58335F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(181.2068F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Tổng số sổ BHXH đề nghị cấp:";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(1.958672F, 39.58333F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(122.8735F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Tổng số tờ khai: ";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(1.958672F, 13.12497F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(640.258F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "PHẦN TỔNG HỢP: ";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(642.2167F, 39.58333F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(181.2068F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "Tổng số sổ BHYT đề nghị cấp:";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(642.2168F, 62.58335F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(358.0152F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "Thời hạn từ __/__/ 201    đến  __/__/ 201";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 60F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(946.9583F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(124.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable1});
            this.PageHeader.HeightF = 140.0417F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable3.FormattingRules.Add(this.BoiDen);
            this.xrTable3.FormattingRules.Add(this.DenNghieng);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115.0417F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1069.345F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell13,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "A";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 0.079787231506185344D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "B";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 0.32529613058617768D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "1";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 0.17000652374105249D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "2";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 0.25327571402204813D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "3";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell13.Weight = 0.15985707288726858D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UsePadding = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "4";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell18.Weight = 0.13929864566059824D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UsePadding = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "5";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell19.Weight = 0.15349595656895898D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UsePadding = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "6";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell20.Weight = 0.14199534178872258D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "7";
            this.xrTableCell21.Weight = 0.14199565659614588D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "8";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell22.Weight = 0.32387116908025354D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UsePadding = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "9";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell23.Weight = 0.24412225031420917D;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1069F, 115.0417F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell7,
            this.xrTableCell5,
            this.xrTableCell12,
            this.xrTableCell11,
            this.xrTableCell15});
            this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UsePadding = false;
            this.xrTableRow1.StylePriority.UseTextAlignment = false;
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.28803177932184237D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "HỌ VÀ TÊN";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 1.1743183782028692D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "SỐ ĐỊNH DANH";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 0.61372321690151788D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "CẤP BẬC, CHỨC VỤ, CHỨC DANH NGHỀ, NƠI LÀM VIỆC";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 0.91432467117574534D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel1,
            this.xrTable2,
            this.xrLabel2});
            this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.Weight = 2.6592786668694712D;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(369.3035F, 25F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "MỨC ĐÓNG";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(80.14163F, 25F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(289.1618F, 27.16665F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "PHỤ CẤP";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(80.14172F, 52.16665F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(289.1617F, 62.87506F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell3});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.Text = "CV";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell14.Weight = 0.91138609466735843D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "TN VK (%)";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell16.Weight = 1.0042748961462162D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "TN NGHỀ (%)";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 0.929029255606237D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "PC KHÁC";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.929029255606237D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.00006F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(80.14172F, 90.04164F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "TIỀN LƯƠNG";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "TỪ THÁNG, NĂM";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 1.1691762324945116D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "GHI CHÚ";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 0.878796134141292D;
            // 
            // DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter,
            this.GroupHeader1,
            this.PageHeader});
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.BoiDen,
            this.DenNghieng,
            this.Xoa0});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 45, 34, 33);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void xrt_tienluongcu_BeforePrint(object sender, PrintEventArgs e)
    {
        XRTableCell cell = (XRTableCell)sender;
        if (cell.Text == "0")
        {
            cell.Text = "";
        }
    }


}
