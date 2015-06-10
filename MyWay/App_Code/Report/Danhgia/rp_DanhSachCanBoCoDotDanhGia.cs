using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using System.Data;
using DataController;
using DevExpress.XtraPivotGrid;
using System.Collections.Generic;
using Controller.DanhGia;
using DAL;

/// <summary>
/// Summary description for rp_DanhSachCanBoCoDotDanhGia
/// </summary>
public class rp_DanhSachCanBoCoDotDanhGia : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRLabel xrt_tieudebaocao;
    private XRLabel xrh_donvi;
    private XRLabel xrh_chucvu;
    private XRLabel xrh_nam;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_macbnv;
    private XRTableCell xrt_ngaysinh;
    private XRTableCell xrt_chucvu;
    private XRTableCell xrt_phongban;
    private XRTableCell xrt_donvi;
    private XRTableCell xrt_stt;
    private XRLabel xrlblNgayLapBC;
    private XRLabel xrLabel10;
    private XRLabel xrlblChuKy3;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DanhSachCanBoCoDotDanhGia()
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
        // lấy danh sách các đợt đánh giá trong năm hiện tại
        //List<DAL.DotDanhGia> lists = new DotDanhGiaController().GetDotDanhGiaByYear(DateTime.Now.Year);
        //DataTable datas = CreateDataTable();
        //int count = 0;
        //foreach (DotDanhGia item in lists)
        //{
        //    // kết quả đánh giá của một đợt đánh giá
        //    DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_DanhGia_TongHopDiemKetQuaDanhGia", "@MaDotDanhGia", "@MaDonVi",
        //        "@MaPhongBan", "@MaChucVu", "@TuDanhGia", "@QuanLyDG", "@NguoiKhacDG", item.ID, filter.MaDonVi, filter.MaPhongBan,
        //        filter.MaChucVu, item.TL_TuDanhGia, item.TL_QuanLyDanhGia, item.TL_NguoiKhacDanhGia);
        //    foreach (DataRow dr in table.Rows)
        //    {
        //        if (!datas.Columns.Contains("Diem" + item.ID))   // đã tồn tại DataRow
        //        {
        //            // Thêm một cột trong dataTable với tên là mã đợt đánh giá 
        //            datas.Columns.Add(new DataColumn("Diem" + item.ID, System.Type.GetType("System.Decimal")));
        //            datas.Columns.Add(new DataColumn("XepLoai" + item.ID));
        //            // điều chỉnh chiều rộng các cột
        //            float add = 16, tong = 0;
        //            for (int i = count + 1; i < lists.Count; i++)
        //            {
        //                tong += add--;
        //            }
        //            // tạo một XRTableCell
        //            GenerateXrTable(item, tong);
        //        }
        //        // lấy danh sách các thang điểm xếp hạng
        //        DataTable loaiXH = new LoaiXepHangController().GetByMaDotDanhGia(item.ID);
        //        int index = GetIndexByMaCB(datas, dr["MA_CB"].ToString());
        //        if (index >= 0)
        //        {
        //            // tạo dữ liệu trong DataTable
        //            datas.Rows[index]["Diem" + item.ID] = dr["TrungBinh"];   // Gán giá trị cho cột đó
        //            if (dr["TrungBinh"].ToString() != null && dr["TrungBinh"].ToString() != "")
        //            {
        //                datas.Rows[index]["XepLoai" + item.ID] = GetTenXepLoai(loaiXH, decimal.Parse(dr["TrungBinh"].ToString()));
        //            }
        //            else
        //            {
        //                datas.Rows[index]["XepLoai" + item.ID] = "";
        //            }
        //        }
        //        else // chưa tồn tại DataRow, cần thêm mới
        //        {
        //            DataRow dtr = datas.NewRow();

        //            dtr["SK"] = ++count;
        //            dtr["MA_CB"] = dr["MA_CB"];
        //            dtr["HO_TEN"] = dr["HO_TEN"];
        //            dtr["NGAY_SINH"] = dr["NGAY_SINH"];
        //            dtr["TEN_CHUCVU"] = dr["TEN_CHUCVU"];
        //            dtr["TEN_DONVI"] = dr["TEN_DONVI"];
        //            dtr["TenDonVi"] = dr["TenDonVi"];
        //            dtr["Diem" + item.ID] = dr["TrungBinh"];
        //            if (dr["TrungBinh"].ToString() != null && dr["TrungBinh"].ToString() != "")
        //            {
        //                dtr["XepLoai" + item.ID] = GetTenXepLoai(loaiXH, decimal.Parse(dr["TrungBinh"].ToString()));
        //            }
        //            else
        //            {
        //                dtr["XepLoai" + item.ID] = "";
        //            }

        //            datas.Rows.Add(dtr);
        //        }
        //    }
        //}
        //// tạo một XRTableCell
        //XRTableCell ghichu1 = new XRTableCell()
        //{
        //    Text = "Ghi chú",
        //    Name = "xrTableRowGhiChu"
        //};
        //this.xrTableRow1.Cells.Add(ghichu1);
        //XRTableCell ghichu2 = new XRTableCell()
        //{
        //    Name = "xrt_ghichu",
        //};
        //ghichu2.StylePriority.UseTextAlignment = false;
        //ghichu2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        //this.xrTableRow6.Cells.Add(ghichu2);

        //if (filter.TenBaoCao != "")
        //    xrt_tieudebaocao.Text = filter.TenBaoCao;
        //xrh_donvi.Text = "Đơn vị: " + new DM_DONVIController().GetNameById(filter.MaDonVi);
        //if (filter.TenChucVu != "")
        //    xrh_chucvu.Text = "Chức vụ: " + filter.TenChucVu;
        //else
        //    xrh_chucvu.Text = "";
        //if (filter.NgayDanhGia != null)
        //{
        //    xrh_nam.Text = "Năm: " + filter.NgayDanhGia.Year;
        //}
        //xrlblNgayLapBC.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //DataSource = datas;
        //xrt_stt.DataBindings.Add("Text", DataSource, "SK");
        //xrt_hovaten.DataBindings.Add("Text", DataSource, "HO_TEN");
        //xrt_macbnv.DataBindings.Add("Text", DataSource, "MA_CB");
        //xrt_ngaysinh.DataBindings.Add("Text", DataSource, "NGAY_SINH", "{0:dd/MM/yyyy}");
        //xrt_chucvu.DataBindings.Add("Text", DataSource, "TEN_CHUCVU");
        //xrt_phongban.DataBindings.Add("Text", DataSource, "TEN_DONVI");
        //xrt_donvi.DataBindings.Add("Text", DataSource, "TenDonVi");

        //xrlblChuKy3.Text = filter.Ten3;
    }

    private void GenerateXrTable(DotDanhGia item, float add)
    {
        float WIDTH = (float)180;
        float HEIGHT = (float)75.62;
        // #############################################
        // tạo 1 cell chứa table vừa tạo
        XRTableCell xrtc = new XRTableCell()
        {
            Name = "xrTableCellh" + item.ID,
            //Borders = DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right,
            HeightF = HEIGHT,
            WidthF = WIDTH + add,
        };
        this.xrTableRow1.Cells.Add(xrtc);
        //
        // tạo mới 1 table header
        //
        XRTable xrtableh1 = new XRTable()
        {
            Name = "xrth1_" + item.ID,
            HeightF = HEIGHT,
            WidthF = WIDTH + add,
            Borders = DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Right,
        };
        xrtc.Controls.Add(xrtableh1);
        //
        // tạo 2 table row
        //
        XRTableRow xrtablerowh1 = new XRTableRow()
        {
            Name = "xrtrh_" + item.ID + "1",
            WidthF = WIDTH + add,
        };
        XRTableRow xrtablerowh2 = new XRTableRow()
        {
            Name = "xrtrh_" + item.ID + "2",
            WidthF = WIDTH + add,
        };

        xrtableh1.Rows.Add(xrtablerowh1);
        xrtableh1.Rows.Add(xrtablerowh2);
        //
        // tạo 1 cell cho table row 1
        //
        XRTableCell xrtablecellh1 = new XRTableCell()
        {
            Name = "xrtch_" + item.ID + "1",
            Text = item.TenDotDanhGia,
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
            WidthF = WIDTH + add,
        };
        xrtablecellh1.StylePriority.UseTextAlignment = false;

        xrtablerowh1.Cells.Add(xrtablecellh1);
        //
        // tạo 2 cell cho table row 2
        //
        // cell 1
        XRTableCell xrtablecellh2 = new XRTableCell()
        {
            Name = "xrtch_" + item.ID + "2",
            Text = "Điểm",
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
            WidthF = WIDTH / 2,
            Borders = DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right,
        };
        xrtablecellh2.StylePriority.UseTextAlignment = false;
        // cell 2
        XRTableCell xrtablecellh3 = new XRTableCell()
        {
            Name = "xrtch_" + item.ID + "3",
            Text = "Xếp loại",
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft,
            WidthF = WIDTH / 2 + add,
            Borders = DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right,
            Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F)
        };
        xrtablecellh3.StylePriority.UseTextAlignment = false;

        xrtablerowh2.Cells.Add(xrtablecellh2);
        xrtablerowh2.Cells.Add(xrtablecellh3);
        // ####################################################
        // tạo 1 cell chứa table vừa tạo
        XRTableCell xrtc2 = new XRTableCell()
        {
            Name = "xrTableCelld" + item.ID,
            Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Right,
            //Borders = DevExpress.XtraPrinting.BorderSide.None,
            WidthF = WIDTH + add,
            //HeightF = (float)29.79,
        };
        this.xrTableRow6.Cells.Add(xrtc2);
        //
        // tạo mới một table detail
        //
        XRTable xrtabled = new XRTable()
        {
            Name = "xrtd_" + item.ID,
            //HeightF = (float)29.79,
            WidthF = WIDTH + add - 1,
            Borders = DevExpress.XtraPrinting.BorderSide.None,
        };
        xrtc2.Controls.Add(xrtabled);
        //
        // tạo 1 table row
        //
        XRTableRow xrtablerowd1 = new XRTableRow()
        {
            Name = "xrtrd_" + item.ID + "1",
            WidthF = WIDTH + add - 1,
            Borders = DevExpress.XtraPrinting.BorderSide.None,
        };
        xrtabled.Rows.Add(xrtablerowd1);
        //
        // tạo 2 cell cho table row
        //
        // cell 1
        XRTableCell xrtablecelld1 = new XRTableCell()
        {
            Name = "xrtcd_" + item.ID + "1",
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter,
            WidthF = WIDTH / 2,
            Font = new Font(Font.FontFamily, Font.Size, FontStyle.Regular),
            Borders = DevExpress.XtraPrinting.BorderSide.None,
            Multiline = true,
        };
        xrtablecelld1.StylePriority.UseTextAlignment = false;
        xrtablecelld1.DataBindings.Add("Text", DataSource, "Diem" + item.ID, "{0:0.00}");
        // cell 2
        XRTableCell xrtablecelld2 = new XRTableCell()
        {
            Name = "xrtcd_" + item.ID + "2",
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft,
            WidthF = WIDTH / 2 + add,
            Font = new Font(Font.FontFamily, Font.Size, FontStyle.Regular),
            Borders = DevExpress.XtraPrinting.BorderSide.Right,
            Multiline = true,
        };
        xrtablecelld2.StylePriority.UseTextAlignment = false;
        xrtablecelld2.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
        xrtablecelld2.DataBindings.Add("Text", DataSource, "XepLoai" + item.ID);

        xrtablerowd1.Cells.Add(xrtablecelld1);
        xrtablerowd1.Cells.Add(xrtablecelld2);
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

    private string GetTenXepLoai(DataTable loaiXH, decimal trungBinh)
    {
        foreach (DataRow item in loaiXH.Rows)
        {
            decimal tuDiem = decimal.Parse(item["TuDiem"].ToString());
            decimal denDiem = decimal.Parse(item["DenDiem"].ToString());

            if (trungBinh >= tuDiem && trungBinh <= denDiem)
                return item["TenXepHang"].ToString();
        }
        return "";
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
            dt.Columns.Add("TenXepLoai");

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
            string resourceFileName = "rp_DanhSachCanBoCoDotDanhGia.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_macbnv = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ngaysinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chucvu = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_phongban = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_donvi = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrh_nam = new DevExpress.XtraReports.UI.XRLabel();
            this.xrh_chucvu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrh_donvi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tieudebaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlblChuKy3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblNgayLapBC = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6});
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Detail.HeightF = 29.79167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable6
            // 
            this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(1158F, 29.79167F);
            this.xrTable6.StylePriority.UseBorders = false;
            this.xrTable6.StylePriority.UseFont = false;
            this.xrTable6.StylePriority.UseTextAlignment = false;
            this.xrTable6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrt_macbnv,
            this.xrt_ngaysinh,
            this.xrt_chucvu,
            this.xrt_phongban,
            this.xrt_donvi});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.StylePriority.UseFont = false;
            this.xrt_stt.Weight = 0.18835270098475104D;
            // 
            // xrt_hovaten
            // 
            this.xrt_hovaten.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_hovaten.Name = "xrt_hovaten";
            this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_hovaten.StylePriority.UseFont = false;
            this.xrt_hovaten.StylePriority.UsePadding = false;
            this.xrt_hovaten.StylePriority.UseTextAlignment = false;
            this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_hovaten.Weight = 0.32235973544261048D;
            // 
            // xrt_macbnv
            // 
            this.xrt_macbnv.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_macbnv.Name = "xrt_macbnv";
            this.xrt_macbnv.StylePriority.UseFont = false;
            this.xrt_macbnv.Weight = 0.22901291615987518D;
            // 
            // xrt_ngaysinh
            // 
            this.xrt_ngaysinh.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_ngaysinh.Name = "xrt_ngaysinh";
            this.xrt_ngaysinh.StylePriority.UseFont = false;
            this.xrt_ngaysinh.Weight = 0.33890155934563576D;
            // 
            // xrt_chucvu
            // 
            this.xrt_chucvu.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_chucvu.Name = "xrt_chucvu";
            this.xrt_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_chucvu.StylePriority.UseFont = false;
            this.xrt_chucvu.StylePriority.UsePadding = false;
            this.xrt_chucvu.StylePriority.UseTextAlignment = false;
            this.xrt_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_chucvu.Weight = 0.36968685953288D;
            // 
            // xrt_phongban
            // 
            this.xrt_phongban.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_phongban.Name = "xrt_phongban";
            this.xrt_phongban.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_phongban.StylePriority.UseFont = false;
            this.xrt_phongban.StylePriority.UsePadding = false;
            this.xrt_phongban.StylePriority.UseTextAlignment = false;
            this.xrt_phongban.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_phongban.Weight = 0.38703892030214582D;
            // 
            // xrt_donvi
            // 
            this.xrt_donvi.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.xrt_donvi.Name = "xrt_donvi";
            this.xrt_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrt_donvi.StylePriority.UseFont = false;
            this.xrt_donvi.StylePriority.UsePadding = false;
            this.xrt_donvi.StylePriority.UseTextAlignment = false;
            this.xrt_donvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_donvi.Weight = 0.64699269002858129D;
            // 
            // TopMargin
            // 
            this.TopMargin.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.TopMargin.HeightF = 25F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseFont = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StylePriority.UseFont = false;
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrh_nam,
            this.xrh_chucvu,
            this.xrh_donvi,
            this.xrt_tieudebaocao});
            this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.ReportHeader.HeightF = 92.75003F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseFont = false;
            // 
            // xrh_nam
            // 
            this.xrh_nam.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrh_nam.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.25002F);
            this.xrh_nam.Name = "xrh_nam";
            this.xrh_nam.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrh_nam.SizeF = new System.Drawing.SizeF(1149.75F, 20.50001F);
            this.xrh_nam.StylePriority.UseFont = false;
            this.xrh_nam.StylePriority.UseTextAlignment = false;
            this.xrh_nam.Text = "Năm: ...... ";
            this.xrh_nam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrh_chucvu
            // 
            this.xrh_chucvu.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrh_chucvu.LocationFloat = new DevExpress.Utils.PointFloat(0F, 51.75002F);
            this.xrh_chucvu.Name = "xrh_chucvu";
            this.xrh_chucvu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrh_chucvu.SizeF = new System.Drawing.SizeF(1149.75F, 20.50001F);
            this.xrh_chucvu.StylePriority.UseFont = false;
            this.xrh_chucvu.StylePriority.UseTextAlignment = false;
            this.xrh_chucvu.Text = "Chức vụ ......";
            this.xrh_chucvu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrh_donvi
            // 
            this.xrh_donvi.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrh_donvi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.25F);
            this.xrh_donvi.Name = "xrh_donvi";
            this.xrh_donvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrh_donvi.SizeF = new System.Drawing.SizeF(1149.75F, 20.50001F);
            this.xrh_donvi.StylePriority.UseFont = false;
            this.xrh_donvi.StylePriority.UseTextAlignment = false;
            this.xrh_donvi.Text = "Đơn vị: ......";
            this.xrh_donvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_tieudebaocao
            // 
            this.xrt_tieudebaocao.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrt_tieudebaocao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrt_tieudebaocao.Name = "xrt_tieudebaocao";
            this.xrt_tieudebaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tieudebaocao.SizeF = new System.Drawing.SizeF(1149.75F, 20.50001F);
            this.xrt_tieudebaocao.StylePriority.UseFont = false;
            this.xrt_tieudebaocao.StylePriority.UseTextAlignment = false;
            this.xrt_tieudebaocao.Text = "DANH SÁCH TỔNG HỢP ĐIỂM VÀ XẾP LOẠI CÁN BỘ";
            this.xrt_tieudebaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.PageHeader.HeightF = 76.66667F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1158F, 76.66667F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell8});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "STT";
            this.xrTableCell5.Weight = 0.188352700524631D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ và tên";
            this.xrTableCell4.Weight = 0.32235973590273048D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Mã CBNV";
            this.xrTableCell6.Weight = 0.22901291615987524D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Ngày sinh";
            this.xrTableCell1.Weight = 0.33890155934563559D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Chức vụ";
            this.xrTableCell7.Weight = 0.36968685953287977D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Phòng ban";
            this.xrTableCell2.Weight = 0.38703892030214593D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Đơn vị";
            this.xrTableCell8.Weight = 0.64699269002858173D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblChuKy3,
            this.xrLabel10,
            this.xrlblNgayLapBC});
            this.ReportFooter.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.ReportFooter.HeightF = 159.125F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            // 
            // xrlblChuKy3
            // 
            this.xrlblChuKy3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlblChuKy3.LocationFloat = new DevExpress.Utils.PointFloat(686.8926F, 106.2084F);
            this.xrlblChuKy3.Name = "xrlblChuKy3";
            this.xrlblChuKy3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblChuKy3.SizeF = new System.Drawing.SizeF(307.6489F, 23F);
            this.xrlblChuKy3.StylePriority.UseFont = false;
            this.xrlblChuKy3.StylePriority.UseTextAlignment = false;
            this.xrlblChuKy3.Text = "Nguyễn Văn An";
            this.xrlblChuKy3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(686.8926F, 48.20836F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(308.6486F, 23.62499F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Giám đốc";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblNgayLapBC
            // 
            this.xrlblNgayLapBC.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlblNgayLapBC.LocationFloat = new DevExpress.Utils.PointFloat(686.8926F, 24.58337F);
            this.xrlblNgayLapBC.Name = "xrlblNgayLapBC";
            this.xrlblNgayLapBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblNgayLapBC.SizeF = new System.Drawing.SizeF(308.6486F, 23.62499F);
            this.xrlblNgayLapBC.StylePriority.UseFont = false;
            this.xrlblNgayLapBC.StylePriority.UseTextAlignment = false;
            this.xrlblNgayLapBC.Text = "Ngày 26 tháng 7 năm 2013";
            this.xrlblNgayLapBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.StylePriority.UseFont = false;
            // 
            // rp_DanhSachCanBoCoDotDanhGia
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(10, 1, 25, 100);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
