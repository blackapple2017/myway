using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rpwgThoaThuanHocViec
/// </summary>
public class rpwgThoaThuanHocViec : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRRichText xrRichText1;
    private XRLine xrLine1;
    private XRRichText xrRichText2;
    private XRRichText xrRichText3;
    private XRRichText xrRichText4;
    private XRRichText xrRichText5;
    private XRRichText xrRichText6;
    private XRRichText xrRichText7;
    private XRRichText xrRichText8;
    private XRRichText xrRichText10;
    private XRRichText xrRichText11;
    private XRRichText xrRichText12;
    private XRRichText xrRichText14;
    private XRRichText xrRichText15;
    private XRRichText xrRichText16;
    private XRRichText xrRichText17;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rpwgThoaThuanHocViec()
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
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("WG_ThoaThuanHocViec", "@Prkey", filter.PrKeyHoSo);
            if (table.Rows.Count > 0)
            {
                HeThongController htController = new HeThongController();
                ReportController rpController = new ReportController();
                string giamDoc = htController.GetValueByName(SystemConfigParameter.chuky2, filter.SessionDepartmentID);
                // Hà Nội, ngày {0} tháng {1} năm {2}
                xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{0}", DateTime.Now.ToString("dd"));
                xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{1}", DateTime.Now.ToString("MM"));
                xrRichText5.Rtf = rpController.Convertstringtortf(xrRichText5.Rtf, "{2}", DateTime.Now.ToString("yyyy"));
                // Hôm nay, ngày {0} tại Công ty cổ phần Thế giới Giải trí.
                xrRichText7.Rtf = rpController.Convertstringtortf(xrRichText7.Rtf, "{0}", DateTime.Now.ToString("dd/MM/yyyy"));
//              Chúng tôi, một bên là:  	Ông {0} (gọi tắt là Người sử dụng lao động)
//              Chức vụ		   :  	Tổng Giám Đốc 
//              Đại diện cho   :  	Công ty cổ phần thế giới Giải trí (gọi tắt là Công ty)
//              Địa chỉ 	   :    191 Bà Triệu-Hai Bà Trưng-Hà Nội
//              Và một bên là  :  	{1} (gọi tắt là Người lao động)
//              Sinh ngày 	   :    {2}
//              CMND số	       :    {3}   cấp ngày {4}    nơi cấp : {5}
//              Địa chỉ thường trú: {6}
//              Chỗ ở hiện tại :    {7}
//              Điện thoại di động: {8}    ĐTNR: {9}
                string ngayCapCMND = table.Rows[0]["NgayCapCMND"].ToString();
                string ngaySinh = table.Rows[0]["NgaySinh"].ToString();
                string noiCapCMND = table.Rows[0]["NoiCapCMND"].ToString();
                string diaChiThuongTru = table.Rows[0]["DiaChiThuongTru"].ToString();
                string choOHienNay = table.Rows[0]["ChoOHienNay"].ToString();
                string diDong = table.Rows[0]["DiDong"].ToString();
                string nhaRieng = table.Rows[0]["DTNR"].ToString();
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{0}", giamDoc);
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{1}", table.Rows[0]["HoTen"].ToString());
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{2}", string.IsNullOrEmpty(ngaySinh) ? "..." : ngaySinh.Remove(10));
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{3}", table.Rows[0]["SoCMND"].ToString());
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{4}", string.IsNullOrEmpty(ngayCapCMND) ? "..." : ngayCapCMND.Remove(10));
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{5}", string.IsNullOrEmpty(noiCapCMND) ? "..." : noiCapCMND);
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{6}", string.IsNullOrEmpty(diaChiThuongTru) ? "..." : diaChiThuongTru);
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{7}", string.IsNullOrEmpty(choOHienNay) ? "..." : choOHienNay);
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{8}", string.IsNullOrEmpty(diDong) ? "..." : diDong);
                xrRichText8.Rtf = rpController.Convertstringtortf(xrRichText8.Rtf, "{9}", string.IsNullOrEmpty(nhaRieng) ? "..." : nhaRieng);
//              Thoả thuận ký kết bản thoả thuận học việc và cam kết thực hiện đúng những điều khoản sau:
//              Điều 1: Thời hạn và công việc:
//              -	Thời hạn học việc: {0}
//              -	Từ ngày {1} tháng {2} năm {3}    đến ngày {4} tháng {5} năm {6}  
//              -	Địa điểm học việc:  Công ty cổ phần Thế giới Giải trí & các chi nhánh của Công ty
//              -	Chức vụ: {7}      ;Công việc phải làm: Theo bản mô tả công việc
                int soNgay = filter.DenNgay.Subtract(filter.TuNgay).Days;
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{0}", soNgay.ToString() + " ngày");
                // từ ngày
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{1}", filter.TuNgay.ToString("dd"));
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{2}", filter.TuNgay.ToString("MM"));
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{3}", filter.TuNgay.ToString("yyyy"));
                DateTime denNgay = filter.DenNgay;
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{4}", denNgay.ToString("dd"));
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{5}", denNgay.ToString("MM"));
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{6}", denNgay.ToString("yyyy"));
                string chucVu = table.Rows[0]["TEN_CHUCVU"].ToString();
                xrRichText10.Rtf = rpController.Convertstringtortf(xrRichText10.Rtf, "{7}", string.IsNullOrEmpty(chucVu) ? "..." : chucVu);
                // mức lương
                xrRichText12.Rtf = rpController.Convertstringtortf(xrRichText12.Rtf, "{0}", filter.SoTien.ToString("n0"));
                string thanhChu = SoftCore.Util.GetInstance().DocTienBangChu(filter.SoTien, " đồng");
                xrRichText12.Rtf = rpController.Convertstringtortf(xrRichText12.Rtf, "{1}", thanhChu);
            }
            else
            {
                ExtMessage.Dialog.Alert("Không tìm thấy dữ liệu của cán bộ");
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
            string resourceFileName = "rpwgThoaThuanHocViec.resx";
            System.Resources.ResourceManager resources = global::Resources.rpwgThoaThuanHocViec.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrRichText17 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText16 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText15 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText14 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText12 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText11 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText10 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText8 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText7 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText6 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText5 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText17,
            this.xrRichText16,
            this.xrRichText15,
            this.xrRichText14,
            this.xrRichText12,
            this.xrRichText11,
            this.xrRichText10,
            this.xrRichText8,
            this.xrRichText7,
            this.xrRichText6,
            this.xrRichText5,
            this.xrRichText4,
            this.xrRichText3,
            this.xrRichText2,
            this.xrLine1,
            this.xrRichText1});
            this.Detail.HeightF = 1913F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrRichText17
            // 
            this.xrRichText17.LocationFloat = new DevExpress.Utils.PointFloat(404.3748F, 1881.625F);
            this.xrRichText17.Name = "xrRichText17";
            this.xrRichText17.SerializableRtfString = resources.GetString("xrRichText17.SerializableRtfString");
            this.xrRichText17.SizeF = new System.Drawing.SizeF(315.625F, 23F);
            // 
            // xrRichText16
            // 
            this.xrRichText16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1881.625F);
            this.xrRichText16.Name = "xrRichText16";
            this.xrRichText16.SerializableRtfString = resources.GetString("xrRichText16.SerializableRtfString");
            this.xrRichText16.SizeF = new System.Drawing.SizeF(229.1667F, 23F);
            // 
            // xrRichText15
            // 
            this.xrRichText15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1601.792F);
            this.xrRichText15.Name = "xrRichText15";
            this.xrRichText15.SerializableRtfString = resources.GetString("xrRichText15.SerializableRtfString");
            this.xrRichText15.SizeF = new System.Drawing.SizeF(719.9999F, 266.75F);
            // 
            // xrRichText14
            // 
            this.xrRichText14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1347.542F);
            this.xrRichText14.Name = "xrRichText14";
            this.xrRichText14.SerializableRtfString = resources.GetString("xrRichText14.SerializableRtfString");
            this.xrRichText14.SizeF = new System.Drawing.SizeF(719.9999F, 254.25F);
            // 
            // xrRichText12
            // 
            this.xrRichText12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 796.5833F);
            this.xrRichText12.Name = "xrRichText12";
            this.xrRichText12.SerializableRtfString = resources.GetString("xrRichText12.SerializableRtfString");
            this.xrRichText12.SizeF = new System.Drawing.SizeF(720F, 550F);
            // 
            // xrRichText11
            // 
            this.xrRichText11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 656.9167F);
            this.xrRichText11.Name = "xrRichText11";
            this.xrRichText11.SerializableRtfString = resources.GetString("xrRichText11.SerializableRtfString");
            this.xrRichText11.SizeF = new System.Drawing.SizeF(720F, 139.6667F);
            // 
            // xrRichText10
            // 
            this.xrRichText10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 478.7083F);
            this.xrRichText10.Name = "xrRichText10";
            this.xrRichText10.SerializableRtfString = resources.GetString("xrRichText10.SerializableRtfString");
            this.xrRichText10.SizeF = new System.Drawing.SizeF(720F, 178.2084F);
            // 
            // xrRichText8
            // 
            this.xrRichText8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 173.7083F);
            this.xrRichText8.Name = "xrRichText8";
            this.xrRichText8.SerializableRtfString = resources.GetString("xrRichText8.SerializableRtfString");
            this.xrRichText8.SizeF = new System.Drawing.SizeF(720F, 305F);
            // 
            // xrRichText7
            // 
            this.xrRichText7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 143.7083F);
            this.xrRichText7.Name = "xrRichText7";
            this.xrRichText7.SerializableRtfString = resources.GetString("xrRichText7.SerializableRtfString");
            this.xrRichText7.SizeF = new System.Drawing.SizeF(719.9999F, 30F);
            // 
            // xrRichText6
            // 
            this.xrRichText6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 93.70833F);
            this.xrRichText6.Name = "xrRichText6";
            this.xrRichText6.SerializableRtfString = resources.GetString("xrRichText6.SerializableRtfString");
            this.xrRichText6.SizeF = new System.Drawing.SizeF(719.9999F, 35.5F);
            // 
            // xrRichText5
            // 
            this.xrRichText5.LocationFloat = new DevExpress.Utils.PointFloat(326.0417F, 56.50002F);
            this.xrRichText5.Name = "xrRichText5";
            this.xrRichText5.SerializableRtfString = resources.GetString("xrRichText5.SerializableRtfString");
            this.xrRichText5.SizeF = new System.Drawing.SizeF(393.9583F, 23F);
            // 
            // xrRichText4
            // 
            this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(326.0417F, 22.99999F);
            this.xrRichText4.Name = "xrRichText4";
            this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
            this.xrRichText4.SizeF = new System.Drawing.SizeF(393.9583F, 23F);
            // 
            // xrRichText3
            // 
            this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(326.0417F, 0F);
            this.xrRichText3.Name = "xrRichText3";
            this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
            this.xrRichText3.SizeF = new System.Drawing.SizeF(393.9583F, 23F);
            // 
            // xrRichText2
            // 
            this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(33.95834F, 55.16667F);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
            this.xrRichText2.SizeF = new System.Drawing.SizeF(244.1667F, 23F);
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(430.8333F, 46F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(181.25F, 10.5F);
            // 
            // xrRichText1
            // 
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(278.125F, 39.66667F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 43F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 40F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // rpwgThoaThuanHocViec
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(64, 66, 43, 40);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
