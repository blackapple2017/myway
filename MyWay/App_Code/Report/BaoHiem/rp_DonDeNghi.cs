using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_DonDeNghi
/// </summary>
public class rp_DonDeNghi : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell2;
    private XRLine xrLine1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell3;
    private XRTable xrTable3;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell4;
    private XRLabel xrLabel1;
    private XRTable xrTable4;
    private XRTableRow xrTableRow5;
    private XRTableCell xrlkinhgui;
    private XRTable xrTable5;
    private XRTableRow xrTableRow6;
    private XRTableCell xrlhoten;
    private XRTable xrTable6;
    private XRTableRow xrTableRow7;
    private XRTableCell xrlmaso;
    private XRTable xrTable7;
    private XRTableRow xrTableRow8;
    private XRTableCell xrlnamsinh;
    private XRTable xrTable8;
    private XRTableRow xrTableRow9;
    private XRTableCell xrlgioitinh;
    private XRTable xrTable9;
    private XRTableRow xrTableRow10;
    private XRTableCell xrlcmt;
    private XRTable xrTable10;
    private XRTableRow xrTableRow11;
    private XRTableCell xrlnoicap;
    private XRTable xrTable11;
    private XRTableRow xrTableRow12;
    private XRTableCell xrlngaycap;
    private XRTable xrTable12;
    private XRTableRow xrTableRow13;
    private XRTableCell xrldonvi;
    private XRTable xrTable13;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell7;
    private XRTable xrTable14;
    private XRTableRow xrTableRow15;
    private XRTableCell xrlnoidungthaydoi;
    private XRTable xrTable15;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell9;
    private XRTable xrTable16;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell10;
    private XRTable xrTable17;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell11;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_DonDeNghi()
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

    public void BindData(ReportFilter rp)
    {
        //string filter dạng hoten_bh,ngaysinh_bh,thangsinh_bh,namsinh_bh,gioitinh_bh,socmnd_bh,ngaycmnd_bh,thangcmnd_bh,namcmnd_bh,noicapcmnd_bh,diachi_bh,noidangky_bh,noidungthaydoi,manhanvien_baohiem 
        string hoten_bh =rp.WhereClause.Split(',')[0];
        string ngaysinh_bh=rp.WhereClause.Split(',')[1];
        string thangsinh_bh=rp.WhereClause.Split(',')[2];
        string namsinh_bh=rp.WhereClause.Split(',')[3];
        string gioitinh_bh=rp.WhereClause.Split(',')[4];
        string socmnd_bh=rp.WhereClause.Split(',')[5];
        string ngaycmnd_bh=rp.WhereClause.Split(',')[6];
        string thangcmnd_bh=rp.WhereClause.Split(',')[7];
        string namcmnd_bh=rp.WhereClause.Split(',')[8];
        string noicapcmnd_bh=rp.WhereClause.Split(',')[9];
        string diachi_bh=rp.WhereClause.Split(',')[10];
        string noidangky_bh=rp.WhereClause.Split(',')[11];
        string noidungthaydoi=rp.WhereClause.Split(',')[12];
        string manhanvien_baohiem=rp.WhereClause.Split(',')[13];   
        DAL.BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByMaNhanVien(manhanvien_baohiem);
        if (!string.IsNullOrEmpty(hoten_bh))
        {
            xrlhoten.Text = "- Tên tôi là (viết chữ in hoa có dấu): " + hoten_bh.ToUpper();
        }
        else
        {
            if (!string.IsNullOrEmpty(nvbh.HoTen))
            {
                xrlhoten.Text = "- Tên tôi là (viết chữ in hoa có dấu): " + nvbh.HoTen.ToUpper();
            }
        }
        if (!string.IsNullOrEmpty(ngaysinh_bh) && !string.IsNullOrEmpty(thangsinh_bh) && !string.IsNullOrEmpty(namsinh_bh))
        {
            xrlnamsinh.Text = "- Ngày tháng năm sinh: " + ngaysinh_bh + "/" + thangsinh_bh + "/" + namsinh_bh;
        }
        else
        {
            if (nvbh.NgaySinh != null && !nvbh.NgaySinh.ToString().Contains("0001"))
            {
                xrlnamsinh.Text = "- Ngày tháng năm sinh: " + Convert.ToDateTime(nvbh.NgaySinh).Day + "/" + Convert.ToDateTime(nvbh.NgaySinh).Month + "/" + Convert.ToDateTime(nvbh.NgaySinh).Year;
            }
        }
        if (!string.IsNullOrEmpty(gioitinh_bh))
        {
            if (gioitinh_bh == "0")
            {
                xrlgioitinh.Text = "Giới tính: " + "Nữ";
            }
            else
            {
                xrlgioitinh.Text = "Giới tính: " + "Nam";
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(nvbh.GioiTinh.ToString()))
            {
                if (nvbh.GioiTinh == true)
                {
                    xrlgioitinh.Text = "Giới tính: " + "Nam";
                }
                else
                {
                    xrlgioitinh.Text = "Giới tính: " + "Nữ";
                }

            }
        } 
        string tendonvi = new DM_DONVIController().GetNameById(nvbh.MaDonVi);
        if (!string.IsNullOrEmpty(tendonvi))
        {
            xrldonvi.Text = "- Đơn vị: " + tendonvi;
        }
        if (!string.IsNullOrEmpty(socmnd_bh))
        {
            xrlcmt.Text = "- CMT số: " + socmnd_bh;
        }
        else
        {
            if (!string.IsNullOrEmpty(nvbh.SoCMTND))
            {
                xrlcmt.Text = "- CMT số: " + nvbh.SoCMTND;
            }
        }
        if (!string.IsNullOrEmpty(noicapcmnd_bh))
        {
            xrlnoicap.Text = "nơi cấp: " + noicapcmnd_bh;
        }
        else
        {
            if (!string.IsNullOrEmpty(nvbh.NoiCapCMTND))
            {
                xrlnoicap.Text = "nơi cấp: " + nvbh.NoiCapCMTND;
            }
        }
        if (!string.IsNullOrEmpty(ngaycmnd_bh) && !string.IsNullOrEmpty(thangcmnd_bh) && !string.IsNullOrEmpty(namcmnd_bh))
        {
            xrlngaycap.Text = "ngày cấp: " + ngaycmnd_bh + "/" + thangcmnd_bh + "/" + namcmnd_bh;
        }
        else
        {
            // txtSoCMNDCu.Text = nvbh.SoCMTND;
            if (nvbh.NgayCapCMTND != null && !nvbh.NgayCapCMTND.ToString().Contains("0001"))
            {
                xrlngaycap.Text = "ngày cấp: " + Convert.ToDateTime(nvbh.NgayCapCMTND).Day + "/" + Convert.ToDateTime(nvbh.NgayCapCMTND).Month + "/" + Convert.ToDateTime(nvbh.NgayCapCMTND).Year;
            }
        }
        if (!string.IsNullOrEmpty(noidungthaydoi))
        {
            xrlnoidungthaydoi.Text = noidungthaydoi;
        }
    }
    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        string resourceFileName = "rp_DonDeNghi.resx";
        System.Resources.ResourceManager resources = global::Resources.rp_DonDeNghi.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlnoidungthaydoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrldonvi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlngaycap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlnoicap = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlcmt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlgioitinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlnamsinh = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlmaso = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlhoten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrlkinhgui = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable17,
            this.xrTable16,
            this.xrTable15,
            this.xrTable14,
            this.xrTable13,
            this.xrTable12,
            this.xrTable11,
            this.xrTable10,
            this.xrTable9,
            this.xrTable8,
            this.xrTable7,
            this.xrTable6,
            this.xrTable5,
            this.xrTable4});
        this.Detail.HeightF = 539.5834F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable17
        // 
        this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 511.4583F);
        this.xrTable17.Name = "xrTable17";
        this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
        this.xrTable17.SizeF = new System.Drawing.SizeF(715.0417F, 28.125F);
        // 
        // xrTableRow18
        // 
        this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11});
        this.xrTableRow18.Name = "xrTableRow18";
        this.xrTableRow18.Weight = 1D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseFont = false;
        this.xrTableCell11.Text = "        Tôi  xin cam đoan những nội dung trên là đúng sự thật và xin chịu hoàn to" +
            "àn trách nhiệm trước pháp luật.";
        this.xrTableCell11.Weight = 3D;
        // 
        // xrTable16
        // 
        this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 355.2084F);
        this.xrTable16.Name = "xrTable16";
        this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
        this.xrTable16.SizeF = new System.Drawing.SizeF(715.0417F, 156.25F);
        // 
        // xrTableRow17
        // 
        this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10});
        this.xrTableRow17.Name = "xrTableRow17";
        this.xrTableRow17.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseFont = false;
        this.xrTableCell10.Text = resources.GetString("xrTableCell10.Text");
        this.xrTableCell10.Weight = 3D;
        // 
        // xrTable15
        // 
        this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 330.2084F);
        this.xrTable15.Name = "xrTable15";
        this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
        this.xrTable15.SizeF = new System.Drawing.SizeF(715.0417F, 25F);
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseFont = false;
        this.xrTableCell9.Text = "Hồ sơ gửi kèm:";
        this.xrTableCell9.Weight = 3D;
        // 
        // xrTable14
        // 
        this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 175F);
        this.xrTable14.Name = "xrTable14";
        this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
        this.xrTable14.SizeF = new System.Drawing.SizeF(715.0417F, 155.2084F);
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlnoidungthaydoi});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrlnoidungthaydoi
        // 
        this.xrlnoidungthaydoi.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlnoidungthaydoi.Name = "xrlnoidungthaydoi";
        this.xrlnoidungthaydoi.StylePriority.UseFont = false;
        this.xrlnoidungthaydoi.Text = resources.GetString("xrlnoidungthaydoi.Text");
        this.xrlnoidungthaydoi.Weight = 3D;
        // 
        // xrTable13
        // 
        this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 150F);
        this.xrTable13.Name = "xrTable13";
        this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
        this.xrTable13.SizeF = new System.Drawing.SizeF(715.0417F, 25F);
        // 
        // xrTableRow14
        // 
        this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7});
        this.xrTableRow14.Name = "xrTableRow14";
        this.xrTableRow14.Weight = 1D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.Text = "Nội dung:";
        this.xrTableCell7.Weight = 3D;
        // 
        // xrTable12
        // 
        this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 125F);
        this.xrTable12.Name = "xrTable12";
        this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
        this.xrTable12.SizeF = new System.Drawing.SizeF(715.0417F, 25F);
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrldonvi});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrldonvi
        // 
        this.xrldonvi.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrldonvi.Name = "xrldonvi";
        this.xrldonvi.StylePriority.UseFont = false;
        this.xrldonvi.Text = "- Đơn vị:  ......................................................................" +
            "................................................................................" +
            ".........";
        this.xrldonvi.Weight = 3D;
        // 
        // xrTable11
        // 
        this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(521.75F, 100F);
        this.xrTable11.Name = "xrTable11";
        this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12});
        this.xrTable11.SizeF = new System.Drawing.SizeF(193.2917F, 25F);
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlngaycap});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrlngaycap
        // 
        this.xrlngaycap.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlngaycap.Name = "xrlngaycap";
        this.xrlngaycap.StylePriority.UseFont = false;
        this.xrlngaycap.Text = "ngày cấp: ......../......../.........";
        this.xrlngaycap.Weight = 3D;
        // 
        // xrTable10
        // 
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(274.4166F, 100F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
        this.xrTable10.SizeF = new System.Drawing.SizeF(247.3333F, 24.99999F);
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlnoicap});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrlnoicap
        // 
        this.xrlnoicap.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlnoicap.Name = "xrlnoicap";
        this.xrlnoicap.StylePriority.UseFont = false;
        this.xrlnoicap.Text = "nơi cấp: ..................................................,";
        this.xrlnoicap.Weight = 3D;
        // 
        // xrTable9
        // 
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable9.SizeF = new System.Drawing.SizeF(274.4167F, 24.99999F);
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlcmt});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrlcmt
        // 
        this.xrlcmt.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlcmt.Name = "xrlcmt";
        this.xrlcmt.StylePriority.UseFont = false;
        this.xrlcmt.Text = "- CMT số: ...........................................,";
        this.xrlcmt.Weight = 3D;
        // 
        // xrTable8
        // 
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(281.7083F, 75F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable8.SizeF = new System.Drawing.SizeF(434.2917F, 24.99999F);
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlgioitinh});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrlgioitinh
        // 
        this.xrlgioitinh.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlgioitinh.Name = "xrlgioitinh";
        this.xrlgioitinh.StylePriority.UseFont = false;
        this.xrlgioitinh.Text = "Giới tính: ......................................................................" +
            ".....................";
        this.xrlgioitinh.Weight = 3D;
        // 
        // xrTable7
        // 
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable7.SizeF = new System.Drawing.SizeF(281.7083F, 24.99999F);
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlnamsinh});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrlnamsinh
        // 
        this.xrlnamsinh.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlnamsinh.Name = "xrlnamsinh";
        this.xrlnamsinh.StylePriority.UseFont = false;
        this.xrlnamsinh.Text = "- Ngày tháng năm sinh: ......./......../.........,";
        this.xrlnamsinh.Weight = 3D;
        // 
        // xrTable6
        // 
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 50F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable6.SizeF = new System.Drawing.SizeF(715.0417F, 25F);
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlmaso});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrlmaso
        // 
        this.xrlmaso.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlmaso.Name = "xrlmaso";
        this.xrlmaso.StylePriority.UseFont = false;
        this.xrlmaso.Text = "- Mã số quản lý:  ..............................................................." +
            "................................................................................" +
            ".....";
        this.xrlmaso.Weight = 3D;
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 25F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable5.SizeF = new System.Drawing.SizeF(715.0417F, 25F);
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlhoten});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrlhoten
        // 
        this.xrlhoten.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlhoten.Name = "xrlhoten";
        this.xrlhoten.StylePriority.UseFont = false;
        this.xrlhoten.Text = "- Tên tôi là (viết chữ in hoa có dấu): .........................................." +
            "...........................................................................";
        this.xrlhoten.Weight = 3D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable4.SizeF = new System.Drawing.SizeF(715.0417F, 25F);
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrlkinhgui});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrlkinhgui
        // 
        this.xrlkinhgui.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrlkinhgui.Name = "xrlkinhgui";
        this.xrlkinhgui.StylePriority.UseFont = false;
        this.xrlkinhgui.Text = "Kính gửi: Bảo hiểm xã hội ......................................................." +
            ".............................................................................";
        this.xrlkinhgui.Weight = 3D;
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
        // PageHeader
        // 
        this.PageHeader.HeightF = 0F;
        this.PageHeader.Name = "PageHeader";
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrTable3,
            this.xrTable2,
            this.xrLine1,
            this.xrTable1});
        this.ReportHeader.HeightF = 180F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 133.7917F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(715.0417F, 31.33336F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "ĐƠN ĐỀ NGHỊ";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTable3
        // 
        this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(415.0417F, 68.75F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable3.SizeF = new System.Drawing.SizeF(300F, 51.24998F);
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
        this.xrTableCell4.Multiline = true;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.Text = "( Ban hành kèm theo QĐ số:   /QĐ. BHXH \r\nngày ...../....../2011 của BHXH Việt Nam" +
            "";
        this.xrTableCell4.Weight = 3D;
        // 
        // xrTable2
        // 
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(415.0417F, 56.25F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable2.SizeF = new System.Drawing.SizeF(300F, 12.5F);
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.Text = "Mẫu số: D01-TS";
        this.xrTableCell3.Weight = 3D;
        // 
        // xrLine1
        // 
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(288.5417F, 50F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(160.4167F, 6.25F);
        // 
        // xrTable1
        // 
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(715.0417F, 50F);
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrTableCell2.Weight = 2.9027402720367474D;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Độc lập - Tự do - Hạnh phúc ";
        this.xrTableCell1.Weight = 2.9027402720367474D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
        this.ReportFooter.HeightF = 210F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(372.9166F, 46.0001F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(342.125F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "(ký, ghi rõ họ tên)";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(372.9166F, 23.00008F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(342.125F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Người đề nghị";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(372.9166F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(342.1251F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = "..................., ngày .......... tháng ......... năm ..........";
        // 
        // PageFooter
        // 
        this.PageFooter.Name = "PageFooter";
        // 
        // rp_DonDeNghi
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter});
        this.Margins = new System.Drawing.Printing.Margins(55, 56, 49, 100);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
