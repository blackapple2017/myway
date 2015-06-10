using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_QuyetDinhLuong
/// </summary>
public class rp_QuyetDinhLuong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrt_tenbaocao;
    private XRLabel xrlSoQuyetDinh;
    private XRLabel xrt_ngayketxuat;
    private XRLabel xrlTitle;
    private XRLabel xrlCanCu;
    private PageHeaderBand PageHeader;
    private XRLabel xrt_tenphucap;
    private XRLabel xrt_tien;
    private XRLabel xrNoiDungQD;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrlNoiNhan;
    private XRLabel xrlXepLuongVoi;
    private XRLabel xrLabel5;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrlNgach;
    private XRLabel xrLabel18;
    private XRLabel xrlBacLuong;
    private XRLabel xrLabel17;
    private XRLabel xrlHeSoLuong;
    private XRLabel xrlMucLuong;
    private XRLabel xrlLuongDongBH;
    private XRLabel xrlBacLuongNB;
    private XRLabel xrLabel19;
    private XRLabel xrlChucDanh;
    private XRLabel xrlPhongBan;
    private XRLabel xrlThuNhapGop;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel6;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_QuyetDinhLuong()
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

    public void BindData(ReportFilterQuyetDinhLuong filter)
    {
        // get salary dicision by prkeyHoSo
        string tenTP = new HeThongController().GetValueByName(SystemConfigParameter.CITY, filter.MaDonVi);
        string tenDV = new DM_DONVIController().GetNameById(filter.MaDonVi);
        xrt_ngayketxuat.Text = tenTP + ", ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        DataTable salaryDecision = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetSalaryDecisionByID", "@ID", filter.ID);
        double totalSalary = 0;
        if (salaryDecision.Rows.Count > 0)
        {
            xrlSoQuyetDinh.Text = "Số: " + salaryDecision.Rows[0]["SoQuyetDinh"];
            xrlTitle.Text = xrlTitle.Text.Replace("{1}", salaryDecision.Rows[0]["HO_TEN"].ToString());
            xrlTitle.Text = xrlTitle.Text.Replace("{2}", salaryDecision.Rows[0]["MA_CB"].ToString());
            xrlCanCu.Text = xrlCanCu.Text.Replace("{3}", tenDV);
            xrlXepLuongVoi.Text = xrlXepLuongVoi.Text.Replace("{4}", salaryDecision.Rows[0]["HO_TEN"].ToString());
            xrlChucDanh.Text = salaryDecision.Rows[0]["TEN_CHUCVU"].ToString();
            xrlPhongBan.Text = xrlPhongBan.Text.Replace("{7}", salaryDecision.Rows[0]["TEN_DONVI"].ToString());
            xrlNgach.Text = salaryDecision.Rows[0]["TEN_NGACH"].ToString();
            xrlBacLuong.Text = salaryDecision.Rows[0]["BacLuong"].ToString();
            xrlHeSoLuong.Text = salaryDecision.Rows[0]["HeSoLuong"].ToString();
            if (!Convert.IsDBNull(salaryDecision.Rows[0]["LuongCung"]))
            {
                double tmp = Convert.ToDouble(salaryDecision.Rows[0]["LuongCung"]);
                if (tmp > 0)
                    totalSalary += tmp;
                xrlMucLuong.Text = Convert.ToDecimal(salaryDecision.Rows[0]["LuongCung"]).ToString("n0") + " VND";
            }
            else
                xrlMucLuong.Text = "";
            if (!Convert.IsDBNull(salaryDecision.Rows[0]["LuongDongBHXH"]))
            {
                double tmp = Convert.ToDouble(salaryDecision.Rows[0]["LuongDongBHXH"]);
                if (tmp > 0)
                    totalSalary -= tmp;
                xrlLuongDongBH.Text = Convert.ToDecimal(salaryDecision.Rows[0]["LuongDongBHXH"]).ToString("n0") + " VND";
            }
            else
                xrlLuongDongBH.Text = "";
            xrlBacLuongNB.Text = salaryDecision.Rows[0]["BacLuongNB"].ToString();

            xrNoiDungQD.Text = xrNoiDungQD.Text.Replace("{14}", tenDV);
            string ngayHL = salaryDecision.Rows[0]["NgayHieuLuc"].ToString();
            if (!string.IsNullOrEmpty(ngayHL))
            {
                xrNoiDungQD.Text = xrNoiDungQD.Text.Replace("{15}", string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngayHL)));
            }
            else
            {
                xrNoiDungQD.Text = xrNoiDungQD.Text.Replace("{15}", ".....");
            }
            string ngayHLNB = salaryDecision.Rows[0]["NgayHuongLuongNB"].ToString();
            if (!string.IsNullOrEmpty(ngayHLNB))
            {
                xrNoiDungQD.Text = xrNoiDungQD.Text.Replace("{16}", string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngayHLNB)));
            }
            else
            {
                xrNoiDungQD.Text = xrNoiDungQD.Text.Replace("{16}", ".....");
            }
            xrNoiDungQD.Text = xrNoiDungQD.Text.Replace("{18}", salaryDecision.Rows[0]["HO_TEN"].ToString());

            xrlNoiNhan.Text = xrlNoiNhan.Text.Replace("{19}", salaryDecision.Rows[0]["HO_TEN"].ToString());
        }

        DataTable phucapInformation = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetPhuCapByPrkeyHoSoLuong", "@PrkeyHoSoLuong", filter.ID);
        foreach (DataRow item in phucapInformation.Rows)
        {
            if (!Convert.IsDBNull(item["SoTien"]))
            {
                double tmp = Convert.ToDouble(item["SoTien"]);
                if (tmp > 0)
                    totalSalary += tmp;
            }
        }
        xrlThuNhapGop.Text = xrlThuNhapGop.Text.Replace("{8}", string.Format("{0:n0} VND", totalSalary));

        DataSource = phucapInformation;
        xrt_tenphucap.DataBindings.Add("Text", DataSource, "Ten", "+ {0}");
        xrt_tien.DataBindings.Add("Text", DataSource, "SoTien", "{0:n0} VND");
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_QuyetDinhLuong.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_QuyetDinhLuong.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tien = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tenphucap = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrlCanCu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_ngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlSoQuyetDinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_tenbaocao = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrlNoiNhan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNoiDungQD = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlThuNhapGop = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPhongBan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlChucDanh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlBacLuongNB = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlLuongDongBH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlMucLuong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlHeSoLuong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlBacLuong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlNgach = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlXepLuongVoi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrt_tien,
            this.xrt_tenphucap});
            this.Detail.HeightF = 34F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(406.25F, 9.999974F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel19.Text = " :";
            // 
            // xrt_tien
            // 
            this.xrt_tien.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_tien.LocationFloat = new DevExpress.Utils.PointFloat(433.3333F, 9.999974F);
            this.xrt_tien.Name = "xrt_tien";
            this.xrt_tien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tien.SizeF = new System.Drawing.SizeF(155.2085F, 23F);
            this.xrt_tien.StylePriority.UseFont = false;
            this.xrt_tien.StylePriority.UseTextAlignment = false;
            this.xrt_tien.Text = "500.0000 VNĐ";
            this.xrt_tien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrt_tenphucap
            // 
            this.xrt_tenphucap.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_tenphucap.LocationFloat = new DevExpress.Utils.PointFloat(41.6667F, 9.999974F);
            this.xrt_tenphucap.Name = "xrt_tenphucap";
            this.xrt_tenphucap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tenphucap.SizeF = new System.Drawing.SizeF(364.5833F, 23.00001F);
            this.xrt_tenphucap.StylePriority.UseFont = false;
            this.xrt_tenphucap.Text = "+ Phụ cấp xăng xe";
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlCanCu,
            this.xrlTitle,
            this.xrt_ngayketxuat,
            this.xrlSoQuyetDinh,
            this.xrt_tenbaocao});
            this.ReportHeader.HeightF = 151.2083F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrlCanCu
            // 
            this.xrlCanCu.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlCanCu.LocationFloat = new DevExpress.Utils.PointFloat(2.885278F, 127.3333F);
            this.xrlCanCu.Name = "xrlCanCu";
            this.xrlCanCu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlCanCu.SizeF = new System.Drawing.SizeF(801.6719F, 23.87499F);
            this.xrlCanCu.StylePriority.UseFont = false;
            this.xrlCanCu.Text = "Căn cứ Quy chế hệ thống chế độ đãi ngộ hiện hành của {3}; Tổng Giám đốc thông báo" +
    ":";
            // 
            // xrlTitle
            // 
            this.xrlTitle.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrlTitle.LocationFloat = new DevExpress.Utils.PointFloat(1.442655F, 85.50002F);
            this.xrlTitle.Name = "xrlTitle";
            this.xrlTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTitle.SizeF = new System.Drawing.SizeF(804.5574F, 21.95834F);
            this.xrlTitle.StylePriority.UseFont = false;
            this.xrlTitle.StylePriority.UseTextAlignment = false;
            this.xrlTitle.Text = "V/v: Xếp lương với bà {1} (Mã CBNV: {2})";
            this.xrlTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrt_ngayketxuat
            // 
            this.xrt_ngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_ngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(455.6093F, 20.79166F);
            this.xrt_ngayketxuat.Name = "xrt_ngayketxuat";
            this.xrt_ngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_ngayketxuat.SizeF = new System.Drawing.SizeF(350.3907F, 23F);
            this.xrt_ngayketxuat.StylePriority.UseFont = false;
            this.xrt_ngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrt_ngayketxuat.Text = "Hà Nội, ngày 01 tháng 02 năm 2013";
            this.xrt_ngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrlSoQuyetDinh
            // 
            this.xrlSoQuyetDinh.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlSoQuyetDinh.LocationFloat = new DevExpress.Utils.PointFloat(1.442655F, 20.79166F);
            this.xrlSoQuyetDinh.Name = "xrlSoQuyetDinh";
            this.xrlSoQuyetDinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlSoQuyetDinh.SizeF = new System.Drawing.SizeF(141.6667F, 23F);
            this.xrlSoQuyetDinh.StylePriority.UseFont = false;
            this.xrlSoQuyetDinh.Text = "Số: 12/9/2013/QĐL";
            // 
            // xrt_tenbaocao
            // 
            this.xrt_tenbaocao.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrt_tenbaocao.LocationFloat = new DevExpress.Utils.PointFloat(2.885278F, 63.54163F);
            this.xrt_tenbaocao.Name = "xrt_tenbaocao";
            this.xrt_tenbaocao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrt_tenbaocao.SizeF = new System.Drawing.SizeF(801.6719F, 21.95834F);
            this.xrt_tenbaocao.StylePriority.UseFont = false;
            this.xrt_tenbaocao.StylePriority.UseTextAlignment = false;
            this.xrt_tenbaocao.Text = "QUYẾT ĐỊNH";
            this.xrt_tenbaocao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlNoiNhan,
            this.xrLabel8,
            this.xrLabel7,
            this.xrNoiDungQD});
            this.ReportFooter.HeightF = 313.8333F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrlNoiNhan
            // 
            this.xrlNoiNhan.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlNoiNhan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 181.2917F);
            this.xrlNoiNhan.Multiline = true;
            this.xrlNoiNhan.Name = "xrlNoiNhan";
            this.xrlNoiNhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNoiNhan.SizeF = new System.Drawing.SizeF(222.9167F, 65.70834F);
            this.xrlNoiNhan.StylePriority.UseFont = false;
            this.xrlNoiNhan.Text = "- Ông (Bà) {19};\r\n- P. ..........;\r\n- Lưu: ..........;";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 158.2917F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Nơi nhận: ";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(483.7344F, 130.5F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(320.823F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "TỔNG GIÁM ĐỐC";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrNoiDungQD
            // 
            this.xrNoiDungQD.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrNoiDungQD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrNoiDungQD.Multiline = true;
            this.xrNoiDungQD.Name = "xrNoiDungQD";
            this.xrNoiDungQD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNoiDungQD.SizeF = new System.Drawing.SizeF(806F, 130.5F);
            this.xrNoiDungQD.StylePriority.UseFont = false;
            this.xrNoiDungQD.Text = resources.GetString("xrNoiDungQD.Text");
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel2,
            this.xrlThuNhapGop,
            this.xrlPhongBan,
            this.xrlChucDanh,
            this.xrlBacLuongNB,
            this.xrlLuongDongBH,
            this.xrlMucLuong,
            this.xrlHeSoLuong,
            this.xrLabel17,
            this.xrlBacLuong,
            this.xrLabel18,
            this.xrlNgach,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel5,
            this.xrlXepLuongVoi,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23});
            this.PageHeader.HeightF = 340F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(206.25F, 173.7499F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel6.Text = " :";
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(406.25F, 284F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel2.Text = " :";
            // 
            // xrlThuNhapGop
            // 
            this.xrlThuNhapGop.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlThuNhapGop.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 103.0833F);
            this.xrlThuNhapGop.Name = "xrlThuNhapGop";
            this.xrlThuNhapGop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlThuNhapGop.SizeF = new System.Drawing.SizeF(581.6406F, 23F);
            this.xrlThuNhapGop.StylePriority.UseFont = false;
            this.xrlThuNhapGop.Text = "{8}/tháng, trong đó:";
            // 
            // xrlPhongBan
            // 
            this.xrlPhongBan.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlPhongBan.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 67.58331F);
            this.xrlPhongBan.Name = "xrlPhongBan";
            this.xrlPhongBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPhongBan.SizeF = new System.Drawing.SizeF(581.6406F, 23F);
            this.xrlPhongBan.StylePriority.UseFont = false;
            this.xrlPhongBan.Text = "{7}, cụ thể như sau:";
            // 
            // xrlChucDanh
            // 
            this.xrlChucDanh.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlChucDanh.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 33.41668F);
            this.xrlChucDanh.Name = "xrlChucDanh";
            this.xrlChucDanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlChucDanh.SizeF = new System.Drawing.SizeF(581.6406F, 23F);
            this.xrlChucDanh.StylePriority.UseFont = false;
            this.xrlChucDanh.Text = "Giảng viên";
            // 
            // xrlBacLuongNB
            // 
            this.xrlBacLuongNB.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlBacLuongNB.LocationFloat = new DevExpress.Utils.PointFloat(433.3333F, 317F);
            this.xrlBacLuongNB.Name = "xrlBacLuongNB";
            this.xrlBacLuongNB.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlBacLuongNB.SizeF = new System.Drawing.SizeF(155.2085F, 23F);
            this.xrlBacLuongNB.StylePriority.UseFont = false;
            this.xrlBacLuongNB.StylePriority.UseTextAlignment = false;
            this.xrlBacLuongNB.Text = "12";
            this.xrlBacLuongNB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrlLuongDongBH
            // 
            this.xrlLuongDongBH.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlLuongDongBH.LocationFloat = new DevExpress.Utils.PointFloat(433.3333F, 284F);
            this.xrlLuongDongBH.Name = "xrlLuongDongBH";
            this.xrlLuongDongBH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlLuongDongBH.SizeF = new System.Drawing.SizeF(155.2085F, 23F);
            this.xrlLuongDongBH.StylePriority.UseFont = false;
            this.xrlLuongDongBH.StylePriority.UseTextAlignment = false;
            this.xrlLuongDongBH.Text = "2,700,000 VND";
            this.xrlLuongDongBH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrlMucLuong
            // 
            this.xrlMucLuong.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlMucLuong.LocationFloat = new DevExpress.Utils.PointFloat(433.3333F, 246.8333F);
            this.xrlMucLuong.Name = "xrlMucLuong";
            this.xrlMucLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlMucLuong.SizeF = new System.Drawing.SizeF(155.2085F, 23.00002F);
            this.xrlMucLuong.StylePriority.UseFont = false;
            this.xrlMucLuong.StylePriority.UseTextAlignment = false;
            this.xrlMucLuong.Text = "10,016,000 VND";
            this.xrlMucLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrlHeSoLuong
            // 
            this.xrlHeSoLuong.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlHeSoLuong.LocationFloat = new DevExpress.Utils.PointFloat(433.3333F, 209.2499F);
            this.xrlHeSoLuong.Name = "xrlHeSoLuong";
            this.xrlHeSoLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlHeSoLuong.SizeF = new System.Drawing.SizeF(155.2085F, 23F);
            this.xrlHeSoLuong.StylePriority.UseFont = false;
            this.xrlHeSoLuong.StylePriority.UseTextAlignment = false;
            this.xrlHeSoLuong.Text = "2.34";
            this.xrlHeSoLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(322.9167F, 173.7499F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = ", bao gồm:";
            // 
            // xrlBacLuong
            // 
            this.xrlBacLuong.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlBacLuong.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 173.7499F);
            this.xrlBacLuong.Name = "xrlBacLuong";
            this.xrlBacLuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlBacLuong.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrlBacLuong.StylePriority.UseFont = false;
            this.xrlBacLuong.Text = "{6}";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(41.6667F, 173.7499F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(164.5833F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "+ Bậc lương";
            // 
            // xrlNgach
            // 
            this.xrlNgach.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlNgach.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 136.4167F);
            this.xrlNgach.Name = "xrlNgach";
            this.xrlNgach.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNgach.SizeF = new System.Drawing.SizeF(581.6405F, 23F);
            this.xrlNgach.StylePriority.UseFont = false;
            this.xrlNgach.Text = "{5}";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(73.95827F, 317F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(332.2917F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "Bậc lương nội bộ";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(73.95827F, 284F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(332.2917F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "Lương đóng Bảo hiểm";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(73.95827F, 246.8333F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(332.2918F, 23.00002F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Mức lương";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(73.95827F, 209.2499F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(332.2918F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Hệ số lương";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(41.6667F, 136.4167F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(164.5833F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "+ Ngạch lương";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(27.08333F, 103.0833F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(179.1667F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "- Thu nhập gộp/tháng";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(27.0833F, 67.58331F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(179.1667F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Phòng ban";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(27.0833F, 33.41668F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(179.1667F, 22.99999F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Chức danh";
            // 
            // xrlXepLuongVoi
            // 
            this.xrlXepLuongVoi.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrlXepLuongVoi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrlXepLuongVoi.Name = "xrlXepLuongVoi";
            this.xrlXepLuongVoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlXepLuongVoi.SizeF = new System.Drawing.SizeF(804.5573F, 23F);
            this.xrlXepLuongVoi.StylePriority.UseFont = false;
            this.xrlXepLuongVoi.Text = " 1) Xếp lương đối với ông (bà) {4}";
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(406.25F, 317F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel1.Text = " :";
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(406.25F, 246.8333F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel3.Text = " :";
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(406.25F, 209.2499F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel4.Text = " :";
            // 
            // xrLabel20
            // 
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(206.2501F, 136.4167F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel20.Text = " :";
            // 
            // xrLabel21
            // 
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(206.2501F, 103.0833F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel21.Text = " :";
            // 
            // xrLabel22
            // 
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(206.25F, 67.58331F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel22.Text = " :";
            // 
            // xrLabel23
            // 
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(206.25F, 33.41668F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(16.66666F, 23F);
            this.xrLabel23.Text = " :";
            // 
            // rp_QuyetDinhLuong
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(10, 11, 49, 100);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
