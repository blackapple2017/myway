using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Controller.DanhGia;
using DAL;
using System.Data;

/// <summary>
/// Summary description for BangTongHopDiemKetQuaDanhGiaCaNam
/// </summary>
public class BangTongHopDiemKetQuaDanhGiaCaNam : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrh_donvi;
    private XRLabel xrt_tieudebaocao;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_ngaysinh;
    private XRTableCell xrt_chucvu;
    private XRLabel xrlblTieuDe3;
    private XRLabel xrLabel14;
    private XRLabel xrlblNgayLapBC;
    private XRLabel xrlblTieuDe1;
    private XRLabel xrLabel10;
    private XRLabel xrlblChuKy1;
    private XRLabel xrlblChuKy3;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrt_phongban;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public BangTongHopDiemKetQuaDanhGiaCaNam()
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
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    public void BindData(ReportFilter filter)
    {
        ReportController rpCtr = new ReportController();
        // lấy danh sách các đợt đánh giá trong năm hiện tại
        List<DAL.DotDanhGia> lists = new DotDanhGiaController().GetDotDanhGiaByYear(filter.Year);
        DataTable datas = CreateDataTable();
        int count = 0;
        foreach (DotDanhGia item in lists)
        {
            // kết quả đánh giá của một đợt đánh giá
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_DanhGia_TongHopDiemKetQuaDanhGia", "@MaDotDanhGia", "@TuDanhGia", "@QuanLyDG", "@NguoiKhacDG", 
                item.ID, item.TL_TuDanhGia, item.TL_QuanLyDanhGia, item.TL_NguoiKhacDanhGia);
            foreach (DataRow dr in table.Rows)
            {
                if (!datas.Columns.Contains(item.ID))   // đã tồn tại DataRow
                {
                    datas.Columns.Add(new DataColumn(item.ID, System.Type.GetType("System.Decimal"))); // Thêm một cột trong dataTable với tên là mã đợt đánh giá 
                    // tạo một XRTableCell
                    XRTableCell it1 = new XRTableCell()
                    {
                        Text = item.TenDotDanhGia,
                        Name = "xrTableRow" + item.ID
                    };
                    this.xrTableRow1.Cells.Add(it1);
                    XRTableCell it2 = new XRTableCell()
                    {
                        Name = "xrt_" + item.ID
                    };
                    it2.DataBindings.Add("Text", DataSource, item.ID, "{0:0.00}");
                    it2.StylePriority.UseTextAlignment = false;
                    it2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    it2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
                    this.xrTableRow2.Cells.Add(it2);
                }
                int index = GetIndexByMaCB(datas, dr["MA_CB"].ToString());
                if (index >= 0)
                {
                    // tạo dữ liệu trong DataTable
                    datas.Rows[index][item.ID] = dr["TrungBinh"];   // Gán giá trị cho cột đó
                }
                else // chưa tồn tại DataRow, cần thêm mới
                {
                    DataRow dtr = datas.NewRow();

                    dtr["SK"] = ++count;
                    dtr["MA_CB"] = dr["MA_CB"];
                    dtr["HO_TEN"] = dr["HO_TEN"];
                    dtr["NGAY_SINH"] = dr["NGAY_SINH"];
                    dtr["TEN_CHUCVU"] = dr["TEN_CHUCVU"];
                    dtr[item.ID] = dr["TrungBinh"];

                    datas.Rows.Add(dtr);
                }
            }
        }
        // tạo một XRTableCell
        XRTableCell ghichu1 = new XRTableCell()
        {
            Text = "Ghi chú",
            Name = "xrTableRowGhiChu"
        };
        this.xrTableRow1.Cells.Add(ghichu1);
        XRTableCell ghichu2 = new XRTableCell()
        {
            Name = "xrt_ghichu",
        };
        ghichu2.StylePriority.UseTextAlignment = false;
        ghichu2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableRow2.Cells.Add(ghichu2);

        if (filter.ReportTitle != "")
            xrt_tieudebaocao.Text = filter.ReportTitle;
        xrh_donvi.Text = "Đơn vị: " + new DM_DONVIController().GetNameById(filter.SessionDepartment);
        xrlblNgayLapBC.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        DataSource = datas;
        xrt_stt.DataBindings.Add("Text", DataSource, "SK");
        xrt_hovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        xrt_ngaysinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
        xrt_chucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");

        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                new DevExpress.XtraReports.UI.GroupField("ChuoiSX", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        xrt_phongban.DataBindings.Add("Text", DataSource, "TEN_PHONG");

        // footer
        xrlblTieuDe1.Text = rpCtr.GetTitleOfSignature(xrlblTieuDe1.Text, filter.Title1);
        xrlblTieuDe3.Text = rpCtr.GetTitleOfSignature(xrlblTieuDe3.Text, filter.Title2);
        // name
        if (!string.IsNullOrEmpty(filter.Name1))
        {
            xrlblChuKy1.Text = filter.Name1;
        }
        else
        {
            xrlblChuKy1.Text = rpCtr.GetCreatedReporterName(filter.SessionDepartment, filter.Reporter);
        }
        xrlblChuKy3.Text = rpCtr.GetHeadAccountant(filter.SessionDepartment, filter.Name2);
    }

    private int GetIndexByMaCB(DataTable datas, string macb)
    {
        for (int i = 0; i < datas.Rows.Count; i++)
        {
            if (datas.Rows[i]["MA_CB"].ToString() == macb)
            {
                return i;
            }
        }
        return -1;
    }

    private DataTable CreateDataTable()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SK");
            dt.Columns.Add("MA_CB");
            dt.Columns.Add("HO_TEN");
            dt.Columns.Add(new DataColumn("NGAY_SINH", System.Type.GetType("System.DateTime")));
            dt.Columns.Add("TEN_CHUCVU");
            dt.Columns.Add("TEN_DONVI");
            dt.Columns.Add("TenDonVi");
            dt.Columns.Add("GHI_CHU");

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "BangTongHopDiemKetQuaDanhGiaCaNam.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrh_donvi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tieudebaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlblChuKy3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblChuKy1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblNgayLapBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTieuDe1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 29.16667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1144F, 29.16667F);
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
            this.xrt_chucvu});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Weight = 0.65625000000000011D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_hovaten.StylePriority.UsePadding = false;
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 2.0208335113525391D;
            // 
            // xrt_ngaysinh
            // 
            this.xrt_ngaysinh.Name = "xrt_ngaysinh";
            this.xrt_ngaysinh.Weight = 1.2975000000000003D;
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_chucvu.StylePriority.UsePadding = false;
            this.xrt_chucvu.StylePriority.UseTextAlignment = false;
            this.xrt_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_chucvu.Weight = 7.4654164886474614D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 24F;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 41.66667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1144F, 41.66667F);
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
            this.xrTableCell5,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.65625000000000011D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Họ và tên\t";
            this.xrTableCell2.Weight = 2.0208335113525391D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Ngày sinh";
            this.xrTableCell5.Weight = 1.2975000000000003D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Chức vụ";
            this.xrTableCell4.Weight = 7.4654164886474614D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrh_donvi,
            this.xrt_tieudebaocao});
            this.ReportHeader.HeightF = 84F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrh_donvi
            // 
            this.xrh_donvi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrh_donvi.LocationFloat = new DevExpress.Utils.PointFloat(43.75F, 35.41667F);
            this.xrh_donvi.Multiline = true;
            this.xrh_donvi.Name = "xrh_donvi";
            this.xrh_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrh_donvi.SizeF = new System.Drawing.SizeF(1076F, 20.50001F);
            this.xrh_donvi.StylePriority.UseFont = false;
            this.xrh_donvi.StylePriority.UseTextAlignment = false;
            this.xrh_donvi.Text = "Đơn vị: ............................\r\n";
            this.xrh_donvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_tieudebaocao
            // 
            this.xrt_tieudebaocao.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrt_tieudebaocao.LocationFloat = new DevExpress.Utils.PointFloat(43.75F, 10.41667F);
            this.xrt_tieudebaocao.Name = "xrt_tieudebaocao";
            this.xrt_tieudebaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tieudebaocao.SizeF = new System.Drawing.SizeF(1076F, 20.50001F);
            this.xrt_tieudebaocao.StylePriority.UseFont = false;
            this.xrt_tieudebaocao.StylePriority.UseTextAlignment = false;
            this.xrt_tieudebaocao.Text = "BẢNG TỔNG HỢP ĐIỂM KẾT QUẢ ĐÁNH GIÁ CẢ NĂM";
            this.xrt_tieudebaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblChuKy3,
            this.xrlblChuKy1,
            this.xrlblTieuDe3,
            this.xrLabel14,
            this.xrlblNgayLapBC,
            this.xrlblTieuDe1,
            this.xrLabel10});
            this.ReportFooter.HeightF = 228F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrlblChuKy3
            // 
            this.xrlblChuKy3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlblChuKy3.LocationFloat = new DevExpress.Utils.PointFloat(825.4635F, 134.3334F);
            this.xrlblChuKy3.Name = "xrlblChuKy3";
            this.xrlblChuKy3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuKy3.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrlblChuKy3.StylePriority.UseFont = false;
            this.xrlblChuKy3.StylePriority.UseTextAlignment = false;
            this.xrlblChuKy3.Text = "Lê Văn Lương";
            this.xrlblChuKy3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlblChuKy1
            // 
            this.xrlblChuKy1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlblChuKy1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 134.3334F);
            this.xrlblChuKy1.Name = "xrlblChuKy1";
            this.xrlblChuKy1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuKy1.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrlblChuKy1.StylePriority.UseFont = false;
            this.xrlblChuKy1.StylePriority.UseTextAlignment = false;
            this.xrlblChuKy1.Text = "Demo";
            this.xrlblChuKy1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlblTieuDe3
            // 
            this.xrlblTieuDe3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTieuDe3.LocationFloat = new DevExpress.Utils.PointFloat(825.4635F, 72.50001F);
            this.xrlblTieuDe3.Name = "xrlblTieuDe3";
            this.xrlblTieuDe3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe3.SizeF = new System.Drawing.SizeF(313.5417F, 10.5F);
            this.xrlblTieuDe3.StylePriority.UseFont = false;
            this.xrlblTieuDe3.StylePriority.UseTextAlignment = false;
            this.xrlblTieuDe3.Text = "GIÁM ĐỐC";
            this.xrlblTieuDe3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(825.4635F, 85.00001F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "(Ký và ghi rõ họ tên)";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblNgayLapBC
            // 
            this.xrlblNgayLapBC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblNgayLapBC.LocationFloat = new DevExpress.Utils.PointFloat(825.4635F, 10.00001F);
            this.xrlblNgayLapBC.Name = "xrlblNgayLapBC";
            this.xrlblNgayLapBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblNgayLapBC.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrlblNgayLapBC.StylePriority.UseFont = false;
            this.xrlblNgayLapBC.StylePriority.UseTextAlignment = false;
            this.xrlblNgayLapBC.Text = "Ngày  27 tháng 7 năm 2013";
            this.xrlblNgayLapBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblTieuDe1
            // 
            this.xrlblTieuDe1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrlblTieuDe1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.50001F);
            this.xrlblTieuDe1.Name = "xrlblTieuDe1";
            this.xrlblTieuDe1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTieuDe1.SizeF = new System.Drawing.SizeF(313.5417F, 10.5F);
            this.xrlblTieuDe1.StylePriority.UseFont = false;
            this.xrlblTieuDe1.StylePriority.UseTextAlignment = false;
            this.xrlblTieuDe1.Text = "NGƯỜI LẬP";
            this.xrlblTieuDe1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 85.00001F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(313.5417F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "(Ký và ghi rõ họ tên)";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1144F, 25F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_phongban});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_phongban.StylePriority.UseBorders = false;
            this.xrt_phongban.StylePriority.UsePadding = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_phongban.Weight = 3D;
            // 
            // BangTongHopDiemKetQuaDanhGiaCaNam
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(11, 14, 24, 100);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
