using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Drawing.Printing;
using DevExpress.Xpo;

/// <summary>
/// Summary description for sub_DienBienLuong
/// </summary>
public class sub_DienBienLuong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel36;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell thang8;
    private XRTableRow xrTableRow2;
    private XRTableCell bac8;
    private XRTableRow xrTableRow3;
    private XRTableCell luong8;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private ReportFooterBand ReportFooter;
    private XRTableCell thang4;
    private XRTableCell bac4;
    private XRTableCell luong4;
    private XRTableCell thang2;
    private XRTableCell bac2;
    private XRTableCell luong2;
    private XRTableCell thang6;
    private XRTableCell bac6;
    private XRTableCell luong6;
    private XRTableCell thang1;
    private XRTableCell bac1;
    private XRTableCell luong1;
    private XRTableCell thang3;
    private XRTableCell bac3;
    private XRTableCell luog3;
    private XRTableCell thang5;
    private XRTableCell bac5;
    private XRTableCell luong5;
    private XRTableCell thang7;
    private XRTableCell bac7;
    private XRTableCell luong7;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public sub_DienBienLuong()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

    }
    private void XtraReport1_BeforePrint(object sender, PrintEventArgs e)
    {

    }
    public void BinData(ReportFilter rp)
    {
        DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("Get_SubDienBienLuong", "@Id", rp.EmployeeCode);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i <dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    thang1.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac1.Text = dt.Rows[i][1].ToString();
                    luong1.Text = dt.Rows[i][2].ToString();
                }
                if (i == 1)
                {
                    thang2.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac2.Text = dt.Rows[i][1].ToString();
                    luong2.Text = dt.Rows[i][2].ToString();
                }
                if (i == 2)
                {
                    thang3.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac3.Text = dt.Rows[i][1].ToString();
                    luog3.Text = dt.Rows[i][2].ToString();
                }
                if (i == 3)
                {
                    thang4.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac4.Text = dt.Rows[i][1].ToString();
                    luong4.Text = dt.Rows[i][2].ToString();
                }
                if (i == 4)
                {
                    thang5.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac5.Text = dt.Rows[i][1].ToString();
                    luong5.Text = dt.Rows[i][2].ToString();
                }
                if (i == 5)
                {
                    thang6.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac6.Text = dt.Rows[i][1].ToString();
                    luong6.Text = dt.Rows[i][2].ToString();
                }
                if (i == 6)
                {
                    thang7.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac7.Text = dt.Rows[i][1].ToString();
                    luong7.Text = dt.Rows[i][2].ToString();
                }
                if (i == 7)
                {
                    thang7.Text = string.Format("{0:MM/yyyy}", dt.Rows[i][0]);
                    bac8.Text = dt.Rows[i][1].ToString();
                    luong8.Text = dt.Rows[i][2].ToString();
                }
            }
        }
        //  this.ReportFooter.Controls.Add(CreateXRTable(dt));
    }
    public XRTable CreateXRTable(DataTable dt)
    {
        int cellsInRow = 3;
        int rowsCount = 3;
        float rowHeight = 25f;
        XRTable table = new XRTable();
        table.Borders = DevExpress.XtraPrinting.BorderSide.All;
        table.BeginInit();
        //for (int i = 0; i < rowsCount; i++)
        //{
        //    XRTableRow row = new XRTableRow();
        //    row.HeightF = rowHeight;
        //    for (int j = 0; j < 10; j++)
        //    {
        //        XRTableCell cell = new XRTableCell();
        //        if (j==0)
        //        {
        //            cell.Text = "tên cán bộ";
        //        }
        //        cell.Text = "a";
        //        row.Cells.Add(cell);
        //    }

        //    table.Rows.Add(row);
        //}

        for (int i = 0; i < rowsCount; i++)
        {
            XRTableRow row = new XRTableRow();
            row.HeightF = rowHeight;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                XRTableCell cell = new XRTableCell();
                if (j == 1)
                {
                    cell.Text = "tên cán bộ";
                }
                cell.Text = dt.Rows[0][j].ToString();
                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
        }

        table.BeforePrint += new PrintEventHandler(table_BeforePrint);
        //.AdjustSize();
        table.EndInit();
        return table;
    }

    // The following code makes the table span to the entire page width.
    void table_BeforePrint(object sender, PrintEventArgs e)
    {
        XRTable table = ((XRTable)sender);
        table.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);
        table.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
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
            string resourceFileName = "sub_DienBienLuong.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.thang8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bac8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luog3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.luong8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 75F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.xrTableRow3});
            this.xrTable1.SizeF = new System.Drawing.SizeF(778.9999F, 75F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.thang1,
            this.thang2,
            this.thang3,
            this.thang4,
            this.thang5,
            this.thang6,
            this.thang7,
            this.thang8});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Tháng/năm";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell1.Weight = 0.54926185846972542D;
            // 
            // thang1
            // 
            this.thang1.Name = "thang1";
            this.thang1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.thang1.StylePriority.UsePadding = false;
            this.thang1.StylePriority.UseTextAlignment = false;
            this.thang1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang1.Weight = 0.30634226769128431D;
            // 
            // thang2
            // 
            this.thang2.Name = "thang2";
            this.thang2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang2.StylePriority.UsePadding = false;
            this.thang2.StylePriority.UseTextAlignment = false;
            this.thang2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang2.Weight = 0.30634226769128431D;
            // 
            // thang3
            // 
            this.thang3.Name = "thang3";
            this.thang3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang3.StylePriority.UsePadding = false;
            this.thang3.StylePriority.UseTextAlignment = false;
            this.thang3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang3.Weight = 0.30634226769128431D;
            // 
            // thang4
            // 
            this.thang4.Name = "thang4";
            this.thang4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang4.StylePriority.UsePadding = false;
            this.thang4.StylePriority.UseTextAlignment = false;
            this.thang4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang4.Weight = 0.30634226769128431D;
            // 
            // thang5
            // 
            this.thang5.Name = "thang5";
            this.thang5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang5.StylePriority.UsePadding = false;
            this.thang5.StylePriority.UseTextAlignment = false;
            this.thang5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang5.Weight = 0.30634226769128431D;
            // 
            // thang6
            // 
            this.thang6.Name = "thang6";
            this.thang6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang6.StylePriority.UsePadding = false;
            this.thang6.StylePriority.UseTextAlignment = false;
            this.thang6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang6.Weight = 0.30634226769128431D;
            // 
            // thang7
            // 
            this.thang7.Name = "thang7";
            this.thang7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang7.StylePriority.UsePadding = false;
            this.thang7.StylePriority.UseTextAlignment = false;
            this.thang7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang7.Weight = 0.30634226769128431D;
            // 
            // thang8
            // 
            this.thang8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.thang8.Name = "thang8";
            this.thang8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.thang8.StylePriority.UseBorders = false;
            this.thang8.StylePriority.UsePadding = false;
            this.thang8.StylePriority.UseTextAlignment = false;
            this.thang8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.thang8.Weight = 0.30634226769128431D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.bac1,
            this.bac2,
            this.bac3,
            this.bac4,
            this.bac5,
            this.bac6,
            this.bac7,
            this.bac8});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Mã ngạch/bậc";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell2.Weight = 0.54926185846972542D;
            // 
            // bac1
            // 
            this.bac1.Name = "bac1";
            this.bac1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac1.StylePriority.UsePadding = false;
            this.bac1.StylePriority.UseTextAlignment = false;
            this.bac1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac1.Weight = 0.30634226769128431D;
            // 
            // bac2
            // 
            this.bac2.Name = "bac2";
            this.bac2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac2.StylePriority.UsePadding = false;
            this.bac2.StylePriority.UseTextAlignment = false;
            this.bac2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac2.Weight = 0.30634226769128431D;
            // 
            // bac3
            // 
            this.bac3.Name = "bac3";
            this.bac3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac3.StylePriority.UsePadding = false;
            this.bac3.StylePriority.UseTextAlignment = false;
            this.bac3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac3.Weight = 0.30634226769128431D;
            // 
            // bac4
            // 
            this.bac4.Name = "bac4";
            this.bac4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac4.StylePriority.UsePadding = false;
            this.bac4.StylePriority.UseTextAlignment = false;
            this.bac4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac4.Weight = 0.30634226769128431D;
            // 
            // bac5
            // 
            this.bac5.Name = "bac5";
            this.bac5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac5.StylePriority.UsePadding = false;
            this.bac5.StylePriority.UseTextAlignment = false;
            this.bac5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac5.Weight = 0.30634226769128431D;
            // 
            // bac6
            // 
            this.bac6.Name = "bac6";
            this.bac6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac6.StylePriority.UsePadding = false;
            this.bac6.StylePriority.UseTextAlignment = false;
            this.bac6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac6.Weight = 0.30634226769128431D;
            // 
            // bac7
            // 
            this.bac7.Name = "bac7";
            this.bac7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac7.StylePriority.UsePadding = false;
            this.bac7.StylePriority.UseTextAlignment = false;
            this.bac7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac7.Weight = 0.30634226769128431D;
            // 
            // bac8
            // 
            this.bac8.Name = "bac8";
            this.bac8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.bac8.StylePriority.UsePadding = false;
            this.bac8.StylePriority.UseTextAlignment = false;
            this.bac8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.bac8.Weight = 0.30634226769128431D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.luong1,
            this.luong2,
            this.luog3,
            this.luong4,
            this.luong5,
            this.luong6,
            this.luong7,
            this.luong8});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Hệ số lương";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell3.Weight = 0.54926185846972542D;
            // 
            // luong1
            // 
            this.luong1.Name = "luong1";
            this.luong1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luong1.StylePriority.UsePadding = false;
            this.luong1.StylePriority.UseTextAlignment = false;
            this.luong1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong1.Weight = 0.30634226769128431D;
            // 
            // luong2
            // 
            this.luong2.Name = "luong2";
            this.luong2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luong2.StylePriority.UsePadding = false;
            this.luong2.StylePriority.UseTextAlignment = false;
            this.luong2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong2.Weight = 0.30634226769128431D;
            // 
            // luog3
            // 
            this.luog3.Name = "luog3";
            this.luog3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luog3.StylePriority.UsePadding = false;
            this.luog3.StylePriority.UseTextAlignment = false;
            this.luog3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luog3.Weight = 0.30634226769128431D;
            // 
            // luong4
            // 
            this.luong4.Name = "luong4";
            this.luong4.StylePriority.UseTextAlignment = false;
            this.luong4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong4.Weight = 0.30634226769128431D;
            // 
            // luong5
            // 
            this.luong5.Name = "luong5";
            this.luong5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luong5.StylePriority.UsePadding = false;
            this.luong5.StylePriority.UseTextAlignment = false;
            this.luong5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong5.Weight = 0.30634226769128431D;
            // 
            // luong6
            // 
            this.luong6.Name = "luong6";
            this.luong6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luong6.StylePriority.UsePadding = false;
            this.luong6.StylePriority.UseTextAlignment = false;
            this.luong6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong6.Weight = 0.30634226769128431D;
            // 
            // luong7
            // 
            this.luong7.Name = "luong7";
            this.luong7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luong7.StylePriority.UsePadding = false;
            this.luong7.StylePriority.UseTextAlignment = false;
            this.luong7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong7.Weight = 0.30634226769128431D;
            // 
            // luong8
            // 
            this.luong8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.luong8.Name = "luong8";
            this.luong8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.luong8.StylePriority.UseBorders = false;
            this.luong8.StylePriority.UsePadding = false;
            this.luong8.StylePriority.UseTextAlignment = false;
            this.luong8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.luong8.Weight = 0.30634226769128431D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 48F;
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
            this.xrLabel36});
            this.PageHeader.HeightF = 23F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel36.Multiline = true;
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(778.9995F, 23F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = "31) Diễn biến quá trình lương của cán bộ, công chức";
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 180F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // sub_DienBienLuong
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(36, 35, 48, 100);
            this.Version = "10.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XtraReport1_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
