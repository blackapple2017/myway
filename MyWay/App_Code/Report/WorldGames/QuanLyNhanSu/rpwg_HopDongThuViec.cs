using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rpwg_HopDongThuViec
/// </summary>
public class rpwg_HopDongThuViec : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private XRRichText xrRichText2;
    private XRRichText xrRichText1;
    private XRRichText xrRichText3;
    private XRLabel xrLabel2;
    private XRRichText xrRichText4;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwg_HopDongThuViec()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public void BindData(ReportFilterEmployeeProfile filter)
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("WG_GetHopDongThuViec", "@Prkey", filter.PrKeyHoSo);
            if (table.Rows.Count > 0)
            {
                HeThongController htController = new HeThongController();
                ReportController rpController = new ReportController();
                string giamDoc = ReportController.GetInstance().GetDirectorName(filter.SessionDepartmentID, filter.Ten2);

                xrLabel2.Text = string.Format(xrLabel2.Text, filter.SoQuyetDinh);
                // Hà Nội, ngày {0} tháng {1} năm {2}
                xrLabel1.Text = string.Format(xrLabel1.Text, DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
                // giam doc
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{0}", giamDoc.ToUpper());
                // nhân viên
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{1}", table.Rows[0]["HO_TEN"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{2}", table.Rows[0]["NGAY_SINH"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{3}", table.Rows[0]["TEN_NUOC"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{4}", table.Rows[0]["SO_CMND"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{5}", table.Rows[0]["NGAYCAP_CMND"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{6}", table.Rows[0]["TEN_NOICAP_CMND"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{7}", table.Rows[0]["HO_KHAU"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{8}", table.Rows[0]["DIA_CHI_LH"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{9}", table.Rows[0]["DI_DONG"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{10}", table.Rows[0]["TEN_TRINHDO"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{11}", table.Rows[0]["TEN_CHUYENNGANH"].ToString());


                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{12}", filter.Thang.ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{13}", filter.TuNgay.ToString("dd"));
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{14}", filter.TuNgay.ToString("MM"));
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{15}", filter.TuNgay.ToString("yyyy"));
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{16}", table.Rows[0]["TEN_DONVI"].ToString());
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{17}", table.Rows[0]["TEN_DONVI"].ToString());

                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{18}", filter.SoTien.ToString("n0"));
                xrRichText4.Rtf = rpController.Convertstringtortf(xrRichText4.Rtf, "{19}", SoftCore.Util.GetInstance().DocTienBangChu(filter.SoTien, " đồng"));




            }
        }
        catch (Exception)
        {

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
            string resourceFileName = "rpwg_HopDongThuViec.resx";
            System.Resources.ResourceManager resources = global::Resources.rpwg_HopDongThuViec.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText4,
            this.xrLabel2,
            this.xrRichText3,
            this.xrLabel1,
            this.xrRichText2,
            this.xrRichText1});
            this.Detail.HeightF = 1809F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 111.5417F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(296.875F, 23F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Số: {0}";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrRichText3
            // 
            this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 143.7083F);
            this.xrRichText3.Name = "xrRichText3";
            this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
            this.xrRichText3.SizeF = new System.Drawing.SizeF(732.9999F, 29.25F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(353.1249F, 50.08332F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(379.875F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Hà Nội, ngày {0} tháng {1} năm {2}";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrRichText2
            // 
            this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(353.1249F, 0F);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
            this.xrRichText2.SizeF = new System.Drawing.SizeF(379.8751F, 50.08334F);
            // 
            // xrRichText1
            // 
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(296.875F, 111.5417F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 77F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 78F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrRichText4
            // 
            this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 195.7917F);
            this.xrRichText4.Name = "xrRichText4";
            this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
            this.xrRichText4.SizeF = new System.Drawing.SizeF(732.9999F, 1613.208F);
            // 
            // rpwg_HopDongThuViec
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(64, 53, 77, 78);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
