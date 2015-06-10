using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Ext.Net;
using System.Data;
using DataController;
/// <summary>
/// Summary description for rp_austfeed_BangTongHopLuongVanPhong
/// </summary>
public class rp_austfeed_BangTongHopLuongVanPhong : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRLabel xrLabel2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell12;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell13;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell16;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell25;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell26;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell31;
    private XRTable xrTable11;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTable xrTable12;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell36;
    private XRTable xrTable13;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTable xrTable14;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell49;
    private XRTable xrTable15;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTable xrTable16;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell53;
    private XRTable xrTable17;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTable xrTable18;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell64;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTable xrTable19;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTableCell xrTableCell100;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTableCell xrTableCell105;
    private XRTableCell xrTableCell106;
    private XRTableCell xrTableCell107;
    private XRTableCell xrTableCell108;
    private XRTableCell xrTableCell109;
    private XRTableCell xrTableCell110;
    private XRTableCell xrTableCell111;
    private XRTableCell xrTableCell112;
    private XRTableCell xrTableCell113;
    private XRTableCell xrTableCell114;
    private XRTableCell xrTableCell115;
    private XRTableCell xrTableCell116;
    private XRTableCell xrTableCell117;
    private XRTableCell xrTableCell118;
    private XRTableCell xrTableCell119;
    private XRTableCell xrTableCell120;
    private XRTableCell xrTableCell121;
    private XRTableCell xrTableCell122;
    private XRTableCell xrTableCell123;
    private XRTableCell xrTableCell124;
    private XRTableCell xrTableCell125;
    private XRTableCell xrTableCell126;
    private XRTableCell xrTableCell127;
    private XRTableCell xrTableCell128;
    private XRTableCell xrTableCell129;
    private XRTableCell xrTableCell130;
    private XRTableCell xrTableCell131;
    private XRTableCell xrTableCell132;
    private XRTableCell xrTableCell133;
    private XRTableCell xrTableCell134;
    private XRTableCell xrTableCell135;
    private XRTableCell xrTableCell136;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel12;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable20;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell137;
    private XRTableCell xrTableCell139;
    private XRTableCell xrTableCell140;
    private XRTableCell xrTableCell141;
    private XRTableCell xrTableCell142;
    private XRTableCell xrTableCell143;
    private XRTableCell xrTableCell144;
    private XRTableCell xrTableCell145;
    private XRTableCell xrTableCell146;
    private XRTableCell xrTableCell147;
    private XRTableCell xrTableCell148;
    private XRTableCell xrTableCell149;
    private XRTableCell xrTableCell150;
    private XRTableCell xrTableCell151;
    private XRTableCell xrTableCell152;
    private XRTableCell xrTableCell153;
    private XRTableCell xrTableCell154;
    private XRTableCell xrTableCell155;
    private XRTableCell xrTableCell156;
    private XRTableCell xrTableCell157;
    private XRTableCell xrTableCell158;
    private XRTableCell xrTableCell159;
    private XRTableCell xrTableCell160;
    private XRTableCell xrTableCell161;
    private XRTableCell xrTableCell162;
    private XRTableCell xrTableCell163;
    private XRTableCell xrTableCell164;
    private XRTableCell xrTableCell165;
    private XRTableCell xrTableCell166;
    private XRTableCell xrTableCell167;
    private XRTableCell xrTableCell168;
    private XRTableCell xrTableCell169;
    private XRTableCell xrTableCell170;
    private XRTableCell xrTableCell171;
    private XRTableCell xrTableCell172;
    private XRTableCell xrTableCell173;
    private XRTableCell xrTableCell174;
    private XRTableCell xrTableCell175;
    private XRTableCell xrTableCell176;
    private XRTable xrTable21;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell177;
    private XRTableCell xrTableCell178;
    private XRTableCell xrTableCell179;
    private XRTableCell xrTableCell180;
    private XRTableCell xrTableCell181;
    private XRTableCell xrTableCell182;
    private XRTableCell xrTableCell183;
    private XRTableCell xrTableCell184;
    private XRTableCell xrTableCell185;
    private XRTableCell xrTableCell186;
    private XRTableCell xrTableCell187;
    private XRTableCell xrTableCell188;
    private XRTableCell xrTableCell189;
    private XRTableCell xrTableCell190;
    private XRTableCell xrTableCell191;
    private XRTableCell xrTableCell192;
    private XRTableCell xrTableCell193;
    private XRTableCell xrTableCell194;
    private XRTableCell xrTableCell195;
    private XRTableCell xrTableCell196;
    private XRTableCell xrTableCell197;
    private XRTableCell xrTableCell198;
    private XRTableCell xrTableCell199;
    private XRTableCell xrTableCell200;
    private XRTableCell xrTableCell201;
    private XRTableCell xrTableCell202;
    private XRTableCell xrTableCell203;
    private XRTableCell xrTableCell204;
    private XRTableCell xrTableCell205;
    private XRTableCell xrTableCell206;
    private XRTableCell xrTableCell207;
    private XRTableCell xrTableCell208;
    private XRTableCell xrTableCell209;
    private XRTableCell xrTableCell210;
    private XRTableCell xrTableCell211;
    private XRTableCell xrTableCell212;
    private XRTableCell xrTableCell213;
    private XRTableCell xrTableCell214;
    private XRTableCell xrTableCell215;
    private XRTableCell xrTableCell216;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_austfeed_BangTongHopLuongVanPhong()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrTableCell97.Text = STT.ToString();
        STT++;
    }
    public void BinData(ReportFilter filter)
    {
        try
        {
            ReportController rp = new ReportController();
            xrLabel1.Text = rp.GetCompanyName(filter.SessionDepartment);
            xrLabel2.Text = string.Format(xrLabel2.Text, filter.StartMonth, filter.Year);
            DataTable dt = DataHandler.GetInstance().ExecuteDataTable("rp_austfeed_TongHopLuongVanPhong", "@Month", "@Year", "@MaBoPhan",
                                                                       filter.StartMonth, filter.Year, filter.SelectedDepartment);
            if (dt.Rows.Count > 0)
            {
                DataSource = dt;
                xrTableCell98.DataBindings.Add("Text", DataSource, "MaCanBo");
                xrTableCell99.DataBindings.Add("Text", DataSource, "HoTen");
                xrTableCell100.DataBindings.Add("Text", DataSource, "ChucVu");
                xrTableCell101.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:n0}");
                xrTableCell102.DataBindings.Add("Text", DataSource, "NgayCongThuong");
                xrTableCell103.DataBindings.Add("Text", DataSource, "LuongTrongThang", "{0:n0}");
                xrTableCell104.DataBindings.Add("Text", DataSource, "Gio130");
                xrTableCell105.DataBindings.Add("Text", DataSource, "Gio150");
                xrTableCell106.DataBindings.Add("Text", DataSource, "Gio195");
                xrTableCell107.DataBindings.Add("Text", DataSource, "Gio200");
                xrTableCell108.DataBindings.Add("Text", DataSource, "Gio260");
                xrTableCell109.DataBindings.Add("Text", DataSource, "Gio300");
                xrTableCell110.DataBindings.Add("Text", DataSource, "TienLamThem", "{0:n0}");
                xrTableCell111.DataBindings.Add("Text", DataSource, "SoNgayPhep");
                xrTableCell112.DataBindings.Add("Text", DataSource, "ThanhTienPhep", "{0:n0}");
                xrTableCell113.DataBindings.Add("Text", DataSource, "TienThuongCV", "{0:n0}");
                xrTableCell114.DataBindings.Add("Text", DataSource, "TongPhuCap", "{0:n0}");
                xrTableCell115.DataBindings.Add("Text", DataSource, "SoNamThamNien");
                xrTableCell116.DataBindings.Add("Text", DataSource, "SoTienThamNien", "{0:n0}");
                xrTableCell117.DataBindings.Add("Text", DataSource, "TienHoTro", "{0:n0}");
                xrTableCell118.DataBindings.Add("Text", DataSource, "TienBu", "{0:n0}");
                xrTableCell119.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                xrTableCell120.DataBindings.Add("Text", DataSource, "TienAnCa", "{0:n0}");
                xrTableCell121.DataBindings.Add("Text", DataSource, "CongDoan", "{0:n0}");
                xrTableCell122.DataBindings.Add("Text", DataSource, "BHXH", "{0:n0}");
                xrTableCell123.DataBindings.Add("Text", DataSource, "BHYT", "{0:n0}");
                xrTableCell124.DataBindings.Add("Text", DataSource, "BHTN", "{0:n0}");
                xrTableCell125.DataBindings.Add("Text", DataSource, "SoNguoiChiuThue", "{0:n0}");
                xrTableCell126.DataBindings.Add("Text", DataSource, "TNChiuThue", "{0:n0}");
                xrTableCell127.DataBindings.Add("Text", DataSource, "TienThueTNCN", "{0:n0}");
                xrTableCell128.DataBindings.Add("Text", DataSource, "TienBL", "{0:n0}");
                xrTableCell129.DataBindings.Add("Text", DataSource, "TruTien", "{0:n0}");
                xrTableCell130.DataBindings.Add("Text", DataSource, "TienTamUng", "{0:n0}");
                xrTableCell131.DataBindings.Add("Text", DataSource, "Lan1TienMat", "{0:n0}");
                xrTableCell132.DataBindings.Add("Text", DataSource, "Lan1ChuyenKhoan", "{0:n0}");
                xrTableCell133.DataBindings.Add("Text", DataSource, "TongCacKhoanGT", "{0:n0}");
                xrTableCell134.DataBindings.Add("Text", DataSource, "TongLuongThucNhan", "{0:n0}");
                xrTableCell135.DataBindings.Add("Text", DataSource, "LuongTraQuaTK", "{0:n0}");
                xrTableCell136.DataBindings.Add("Text", DataSource, "LuongTraTienMat", "{0:n0}");
                //Group header
                this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                new DevExpress.XtraReports.UI.GroupField("MaDonVi", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
                xrTableCell139.DataBindings.Add("Text", DataSource, "TenDonVi");
                xrTableCell141.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:n0}");
                xrTableCell142.DataBindings.Add("Text", DataSource, "NgayCongThuong");
                xrTableCell143.DataBindings.Add("Text", DataSource, "LuongTrongThang", "{0:n0}");
                xrTableCell144.DataBindings.Add("Text", DataSource, "Gio130");
                xrTableCell145.DataBindings.Add("Text", DataSource, "Gio150");
                xrTableCell146.DataBindings.Add("Text", DataSource, "Gio195");
                xrTableCell147.DataBindings.Add("Text", DataSource, "Gio200");
                xrTableCell148.DataBindings.Add("Text", DataSource, "Gio260");
                xrTableCell149.DataBindings.Add("Text", DataSource, "Gio300");
                xrTableCell150.DataBindings.Add("Text", DataSource, "TienLamThem", "{0:n0}");
                xrTableCell151.DataBindings.Add("Text", DataSource, "SoNgayPhep");
                xrTableCell152.DataBindings.Add("Text", DataSource, "ThanhTienPhep", "{0:n0}");
                xrTableCell153.DataBindings.Add("Text", DataSource, "TienThuongCV", "{0:n0}");
                xrTableCell154.DataBindings.Add("Text", DataSource, "TongPhuCap", "{0:n0}");
                xrTableCell155.DataBindings.Add("Text", DataSource, "SoNamThamNien");
                xrTableCell156.DataBindings.Add("Text", DataSource, "SoTienThamNien", "{0:n0}");
                xrTableCell157.DataBindings.Add("Text", DataSource, "TienHoTro", "{0:n0}");
                xrTableCell158.DataBindings.Add("Text", DataSource, "TienBu", "{0:n0}");
                xrTableCell159.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                xrTableCell160.DataBindings.Add("Text", DataSource, "TienAnCa", "{0:n0}");
                xrTableCell161.DataBindings.Add("Text", DataSource, "CongDoan", "{0:n0}");
                xrTableCell162.DataBindings.Add("Text", DataSource, "BHXH", "{0:n0}");
                xrTableCell163.DataBindings.Add("Text", DataSource, "BHYT", "{0:n0}");
                xrTableCell164.DataBindings.Add("Text", DataSource, "BHTN", "{0:n0}");
                xrTableCell165.DataBindings.Add("Text", DataSource, "SoNguoiChiuThue", "{0:n0}");
                xrTableCell166.DataBindings.Add("Text", DataSource, "TNChiuThue", "{0:n0}");
                xrTableCell167.DataBindings.Add("Text", DataSource, "TienThueTNCN", "{0:n0}");
                xrTableCell168.DataBindings.Add("Text", DataSource, "TienBL", "{0:n0}");
                xrTableCell169.DataBindings.Add("Text", DataSource, "TruTien", "{0:n0}");
                xrTableCell170.DataBindings.Add("Text", DataSource, "TienTamUng", "{0:n0}");
                xrTableCell171.DataBindings.Add("Text", DataSource, "Lan1TienMat", "{0:n0}");
                xrTableCell172.DataBindings.Add("Text", DataSource, "Lan1ChuyenKhoan", "{0:n0}");
                xrTableCell173.DataBindings.Add("Text", DataSource, "TongCacKhoanGT", "{0:n0}");
                xrTableCell174.DataBindings.Add("Text", DataSource, "TongLuongThucNhan", "{0:n0}");
                xrTableCell175.DataBindings.Add("Text", DataSource, "LuongTraQuaTK", "{0:n0}");
                xrTableCell176.DataBindings.Add("Text", DataSource, "LuongTraTienMat", "{0:n0}");
                //reportFopter
                xrTableCell181.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:n0}");
                xrTableCell182.DataBindings.Add("Text", DataSource, "NgayCongThuong");
                xrTableCell183.DataBindings.Add("Text", DataSource, "LuongTrongThang", "{0:n0}");
                xrTableCell184.DataBindings.Add("Text", DataSource, "Gio130");
                xrTableCell185.DataBindings.Add("Text", DataSource, "Gio150");
                xrTableCell186.DataBindings.Add("Text", DataSource, "Gio195");
                xrTableCell187.DataBindings.Add("Text", DataSource, "Gio200");
                xrTableCell188.DataBindings.Add("Text", DataSource, "Gio260");
                xrTableCell189.DataBindings.Add("Text", DataSource, "Gio300");
                xrTableCell190.DataBindings.Add("Text", DataSource, "TienLamThem", "{0:n0}");
                xrTableCell191.DataBindings.Add("Text", DataSource, "SoNgayPhep");
                xrTableCell192.DataBindings.Add("Text", DataSource, "ThanhTienPhep", "{0:n0}");
                xrTableCell193.DataBindings.Add("Text", DataSource, "TienThuongCV", "{0:n0}");
                xrTableCell194.DataBindings.Add("Text", DataSource, "TongPhuCap", "{0:n0}");
                xrTableCell195.DataBindings.Add("Text", DataSource, "SoNamThamNien");
                xrTableCell196.DataBindings.Add("Text", DataSource, "SoTienThamNien", "{0:n0}");
                xrTableCell197.DataBindings.Add("Text", DataSource, "TienHoTro", "{0:n0}");
                xrTableCell198.DataBindings.Add("Text", DataSource, "TienBu", "{0:n0}");
                xrTableCell199.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                xrTableCell200.DataBindings.Add("Text", DataSource, "TienAnCa", "{0:n0}");
                xrTableCell201.DataBindings.Add("Text", DataSource, "CongDoan", "{0:n0}");
                xrTableCell202.DataBindings.Add("Text", DataSource, "BHXH", "{0:n0}");
                xrTableCell203.DataBindings.Add("Text", DataSource, "BHYT", "{0:n0}");
                xrTableCell204.DataBindings.Add("Text", DataSource, "BHTN", "{0:n0}");
                xrTableCell205.DataBindings.Add("Text", DataSource, "SoNguoiChiuThue", "{0:n0}");
                xrTableCell206.DataBindings.Add("Text", DataSource, "TNChiuThue", "{0:n0}");
                xrTableCell207.DataBindings.Add("Text", DataSource, "TienThueTNCN", "{0:n0}");
                xrTableCell208.DataBindings.Add("Text", DataSource, "TienBL", "{0:n0}");
                xrTableCell209.DataBindings.Add("Text", DataSource, "TruTien", "{0:n0}");
                xrTableCell210.DataBindings.Add("Text", DataSource, "TienTamUng", "{0:n0}");
                xrTableCell211.DataBindings.Add("Text", DataSource, "Lan1TienMat", "{0:n0}");
                xrTableCell212.DataBindings.Add("Text", DataSource, "Lan1ChuyenKhoan", "{0:n0}");
                xrTableCell213.DataBindings.Add("Text", DataSource, "TongCacKhoanGT", "{0:n0}");
                xrTableCell214.DataBindings.Add("Text", DataSource, "TongLuongThucNhan", "{0:n0}");
                xrTableCell215.DataBindings.Add("Text", DataSource, "LuongTraQuaTK", "{0:n0}");
                xrTableCell216.DataBindings.Add("Text", DataSource, "LuongTraTienMat", "{0:n0}");
            }
            //Chữ ký
            if (!string.IsNullOrEmpty(filter.Title1))
                xrLabel13.Text = filter.Title1;
            if (!string.IsNullOrEmpty(filter.Title2))
                xrLabel7.Text = filter.Title2;
            if (!string.IsNullOrEmpty(filter.Title3))
                xrLabel8.Text = filter.Title3;
            // người lập báo cáo
            if (!string.IsNullOrEmpty(filter.Name1))
                xrLabel14.Text = filter.Name1;
            else xrLabel14.Text = filter.Reporter;
            // giám đốc HCNS
            if (!string.IsNullOrEmpty(filter.Name2))
                xrLabel6.Text = filter.Name2;
            else
                xrLabel6.Text = rp.GetHeadOfHRroom(filter.SessionDepartment, xrLabel6.Text);
            // kế toán trưởng
            if (!string.IsNullOrEmpty(filter.Name3))
                xrLabel9.Text = filter.Name3;
            else
                xrLabel9.Text = rp.GetHeadAccountant(filter.SessionDepartment, xrLabel9.Text);
            xrLabel11.Text = rp.GetDirectorName(filter.SessionDepartment, xrLabel11.Text);
            xrLabel12.Text = rp.GetFooterReport(filter.SessionDepartment, filter.ReportedDate);
        }
        catch (Exception e)
        {
            X.Msg.Alert("Thông báo", "Có lỗi: " + e).Show();
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
        string resourceFileName = "rp_austfeed_BangTongHopLuongVanPhong.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary17 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary18 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary19 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary20 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary21 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary22 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary23 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary24 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary25 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary26 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary27 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary28 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary29 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary30 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary31 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary32 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary33 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary34 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary35 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary36 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary37 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary38 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary39 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary40 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary41 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary42 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary43 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary44 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary45 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary46 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary47 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary48 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary49 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary50 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary51 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary52 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary53 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary54 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary55 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary56 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary57 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary58 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary59 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary60 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary61 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary62 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary63 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary64 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary65 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary66 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary67 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary68 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary69 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary70 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary71 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary72 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable19 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell115 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell116 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell119 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell121 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell122 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell124 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell125 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell126 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell127 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell128 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell129 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell130 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell131 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell132 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell133 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell134 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell135 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell136 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable21 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell177 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell178 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell179 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell180 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell181 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell182 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell183 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell184 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell185 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell186 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell187 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell188 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell189 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell190 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell191 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell192 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell193 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell194 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell195 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell196 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell197 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell198 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell199 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell200 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell201 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell202 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell203 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell204 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell205 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell206 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell207 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell208 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell209 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell210 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell211 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell212 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell213 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell214 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell215 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell216 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable20 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell137 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell142 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell143 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell144 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell145 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell148 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell149 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell150 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell151 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell152 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell153 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell154 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell156 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell157 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell158 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell159 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell160 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell161 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell162 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell163 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell164 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell165 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell166 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell167 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell168 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell169 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell170 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell171 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell172 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell173 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell174 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell175 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell176 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable19});
        this.Detail.HeightF = 28.12501F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.StylePriority.UseBorders = false;
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable19
        // 
        this.xrTable19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable19.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable19.Name = "xrTable19";
        this.xrTable19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19});
        this.xrTable19.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable19.StylePriority.UseBorders = false;
        this.xrTable19.StylePriority.UseTextAlignment = false;
        this.xrTable19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow19
        // 
        this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99,
            this.xrTableCell100,
            this.xrTableCell101,
            this.xrTableCell102,
            this.xrTableCell103,
            this.xrTableCell104,
            this.xrTableCell105,
            this.xrTableCell106,
            this.xrTableCell107,
            this.xrTableCell108,
            this.xrTableCell109,
            this.xrTableCell110,
            this.xrTableCell111,
            this.xrTableCell112,
            this.xrTableCell113,
            this.xrTableCell114,
            this.xrTableCell115,
            this.xrTableCell116,
            this.xrTableCell117,
            this.xrTableCell118,
            this.xrTableCell119,
            this.xrTableCell120,
            this.xrTableCell121,
            this.xrTableCell122,
            this.xrTableCell123,
            this.xrTableCell124,
            this.xrTableCell125,
            this.xrTableCell126,
            this.xrTableCell127,
            this.xrTableCell128,
            this.xrTableCell129,
            this.xrTableCell130,
            this.xrTableCell131,
            this.xrTableCell132,
            this.xrTableCell133,
            this.xrTableCell134,
            this.xrTableCell135,
            this.xrTableCell136});
        this.xrTableRow19.Name = "xrTableRow19";
        this.xrTableRow19.Weight = 1D;
        // 
        // xrTableCell97
        // 
        this.xrTableCell97.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell97.Name = "xrTableCell97";
        this.xrTableCell97.StylePriority.UseFont = false;
        this.xrTableCell97.Weight = 0.04427548256827013D;
        this.xrTableCell97.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTableCell98
        // 
        this.xrTableCell98.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell98.Name = "xrTableCell98";
        this.xrTableCell98.StylePriority.UseFont = false;
        this.xrTableCell98.StylePriority.UseTextAlignment = false;
        this.xrTableCell98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell98.Weight = 0.06398543056230005D;
        // 
        // xrTableCell99
        // 
        this.xrTableCell99.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell99.Name = "xrTableCell99";
        this.xrTableCell99.StylePriority.UseFont = false;
        this.xrTableCell99.StylePriority.UseTextAlignment = false;
        this.xrTableCell99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell99.Weight = 0.13394563943420068D;
        // 
        // xrTableCell100
        // 
        this.xrTableCell100.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell100.Name = "xrTableCell100";
        this.xrTableCell100.StylePriority.UseFont = false;
        this.xrTableCell100.StylePriority.UseTextAlignment = false;
        this.xrTableCell100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell100.Weight = 0.081231411893799288D;
        // 
        // xrTableCell101
        // 
        this.xrTableCell101.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell101.Name = "xrTableCell101";
        this.xrTableCell101.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell101.StylePriority.UseFont = false;
        this.xrTableCell101.StylePriority.UsePadding = false;
        this.xrTableCell101.StylePriority.UseTextAlignment = false;
        this.xrTableCell101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell101.Weight = 0.10131013720301432D;
        // 
        // xrTableCell102
        // 
        this.xrTableCell102.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell102.Name = "xrTableCell102";
        this.xrTableCell102.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell102.StylePriority.UseFont = false;
        this.xrTableCell102.StylePriority.UsePadding = false;
        this.xrTableCell102.StylePriority.UseTextAlignment = false;
        this.xrTableCell102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell102.Weight = 0.044211776426548943D;
        // 
        // xrTableCell103
        // 
        this.xrTableCell103.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell103.Name = "xrTableCell103";
        this.xrTableCell103.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell103.StylePriority.UseFont = false;
        this.xrTableCell103.StylePriority.UsePadding = false;
        this.xrTableCell103.StylePriority.UseTextAlignment = false;
        this.xrTableCell103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell103.Weight = 0.11118145442314076D;
        // 
        // xrTableCell104
        // 
        this.xrTableCell104.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell104.Name = "xrTableCell104";
        this.xrTableCell104.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell104.StylePriority.UseFont = false;
        this.xrTableCell104.StylePriority.UsePadding = false;
        this.xrTableCell104.StylePriority.UseTextAlignment = false;
        this.xrTableCell104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell104.Weight = 0.049512345350638615D;
        // 
        // xrTableCell105
        // 
        this.xrTableCell105.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell105.Name = "xrTableCell105";
        this.xrTableCell105.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell105.StylePriority.UseFont = false;
        this.xrTableCell105.StylePriority.UsePadding = false;
        this.xrTableCell105.StylePriority.UseTextAlignment = false;
        this.xrTableCell105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell105.Weight = 0.048750715674168443D;
        // 
        // xrTableCell106
        // 
        this.xrTableCell106.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell106.Name = "xrTableCell106";
        this.xrTableCell106.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell106.StylePriority.UseFont = false;
        this.xrTableCell106.StylePriority.UsePadding = false;
        this.xrTableCell106.StylePriority.UseTextAlignment = false;
        this.xrTableCell106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell106.Weight = 0.048750799360397307D;
        // 
        // xrTableCell107
        // 
        this.xrTableCell107.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell107.Name = "xrTableCell107";
        this.xrTableCell107.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell107.StylePriority.UseFont = false;
        this.xrTableCell107.StylePriority.UsePadding = false;
        this.xrTableCell107.StylePriority.UseTextAlignment = false;
        this.xrTableCell107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell107.Weight = 0.048750785194759609D;
        // 
        // xrTableCell108
        // 
        this.xrTableCell108.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell108.Name = "xrTableCell108";
        this.xrTableCell108.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell108.StylePriority.UseFont = false;
        this.xrTableCell108.StylePriority.UsePadding = false;
        this.xrTableCell108.StylePriority.UseTextAlignment = false;
        this.xrTableCell108.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell108.Weight = 0.048750687451859488D;
        // 
        // xrTableCell109
        // 
        this.xrTableCell109.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell109.Name = "xrTableCell109";
        this.xrTableCell109.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell109.StylePriority.UseFont = false;
        this.xrTableCell109.StylePriority.UsePadding = false;
        this.xrTableCell109.StylePriority.UseTextAlignment = false;
        this.xrTableCell109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell109.Weight = 0.04875079903349798D;
        // 
        // xrTableCell110
        // 
        this.xrTableCell110.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell110.Name = "xrTableCell110";
        this.xrTableCell110.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell110.StylePriority.UseFont = false;
        this.xrTableCell110.StylePriority.UsePadding = false;
        this.xrTableCell110.StylePriority.UseTextAlignment = false;
        this.xrTableCell110.Text = " ";
        this.xrTableCell110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell110.Weight = 0.08226691085634108D;
        // 
        // xrTableCell111
        // 
        this.xrTableCell111.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell111.Name = "xrTableCell111";
        this.xrTableCell111.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell111.StylePriority.UseFont = false;
        this.xrTableCell111.StylePriority.UsePadding = false;
        this.xrTableCell111.StylePriority.UseTextAlignment = false;
        this.xrTableCell111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell111.Weight = 0.041438187280128387D;
        // 
        // xrTableCell112
        // 
        this.xrTableCell112.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell112.Name = "xrTableCell112";
        this.xrTableCell112.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell112.StylePriority.UseFont = false;
        this.xrTableCell112.StylePriority.UsePadding = false;
        this.xrTableCell112.StylePriority.UseTextAlignment = false;
        this.xrTableCell112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell112.Weight = 0.082876260363423646D;
        // 
        // xrTableCell113
        // 
        this.xrTableCell113.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell113.Name = "xrTableCell113";
        this.xrTableCell113.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell113.StylePriority.UseFont = false;
        this.xrTableCell113.StylePriority.UsePadding = false;
        this.xrTableCell113.StylePriority.UseTextAlignment = false;
        this.xrTableCell113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell113.Weight = 0.063985380001870124D;
        // 
        // xrTableCell114
        // 
        this.xrTableCell114.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell114.Name = "xrTableCell114";
        this.xrTableCell114.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell114.StylePriority.UseFont = false;
        this.xrTableCell114.StylePriority.UsePadding = false;
        this.xrTableCell114.StylePriority.UseTextAlignment = false;
        this.xrTableCell114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell114.Weight = 0.073126033629534237D;
        // 
        // xrTableCell115
        // 
        this.xrTableCell115.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell115.Name = "xrTableCell115";
        this.xrTableCell115.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell115.StylePriority.UseFont = false;
        this.xrTableCell115.StylePriority.UsePadding = false;
        this.xrTableCell115.StylePriority.UseTextAlignment = false;
        this.xrTableCell115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell115.Weight = 0.045703841737680946D;
        // 
        // xrTableCell116
        // 
        this.xrTableCell116.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell116.Name = "xrTableCell116";
        this.xrTableCell116.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell116.StylePriority.UseFont = false;
        this.xrTableCell116.StylePriority.UsePadding = false;
        this.xrTableCell116.StylePriority.UseTextAlignment = false;
        this.xrTableCell116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell116.Weight = 0.0731262567928112D;
        // 
        // xrTableCell117
        // 
        this.xrTableCell117.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell117.Name = "xrTableCell117";
        this.xrTableCell117.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell117.StylePriority.UseFont = false;
        this.xrTableCell117.StylePriority.UsePadding = false;
        this.xrTableCell117.StylePriority.UseTextAlignment = false;
        this.xrTableCell117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell117.Weight = 0.06398537607907813D;
        // 
        // xrTableCell118
        // 
        this.xrTableCell118.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell118.Name = "xrTableCell118";
        this.xrTableCell118.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell118.StylePriority.UseFont = false;
        this.xrTableCell118.StylePriority.UsePadding = false;
        this.xrTableCell118.StylePriority.UseTextAlignment = false;
        this.xrTableCell118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell118.Weight = 0.063985376079078143D;
        // 
        // xrTableCell119
        // 
        this.xrTableCell119.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell119.Name = "xrTableCell119";
        this.xrTableCell119.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell119.StylePriority.UseFont = false;
        this.xrTableCell119.StylePriority.UsePadding = false;
        this.xrTableCell119.StylePriority.UseTextAlignment = false;
        this.xrTableCell119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell119.Weight = 0.12911346756344086D;
        // 
        // xrTableCell120
        // 
        this.xrTableCell120.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell120.Name = "xrTableCell120";
        this.xrTableCell120.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell120.StylePriority.UseFont = false;
        this.xrTableCell120.StylePriority.UsePadding = false;
        this.xrTableCell120.StylePriority.UseTextAlignment = false;
        this.xrTableCell120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell120.Weight = 0.098644308023958349D;
        // 
        // xrTableCell121
        // 
        this.xrTableCell121.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell121.Name = "xrTableCell121";
        this.xrTableCell121.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell121.StylePriority.UseFont = false;
        this.xrTableCell121.StylePriority.UsePadding = false;
        this.xrTableCell121.StylePriority.UseTextAlignment = false;
        this.xrTableCell121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell121.Weight = 0.074535196834334072D;
        // 
        // xrTableCell122
        // 
        this.xrTableCell122.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell122.Name = "xrTableCell122";
        this.xrTableCell122.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell122.StylePriority.UseFont = false;
        this.xrTableCell122.StylePriority.UsePadding = false;
        this.xrTableCell122.StylePriority.UseTextAlignment = false;
        this.xrTableCell122.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell122.Weight = 0.0745349736710571D;
        // 
        // xrTableCell123
        // 
        this.xrTableCell123.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell123.Name = "xrTableCell123";
        this.xrTableCell123.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell123.StylePriority.UseFont = false;
        this.xrTableCell123.StylePriority.UsePadding = false;
        this.xrTableCell123.StylePriority.UseTextAlignment = false;
        this.xrTableCell123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell123.Weight = 0.074534863397015955D;
        // 
        // xrTableCell124
        // 
        this.xrTableCell124.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell124.Name = "xrTableCell124";
        this.xrTableCell124.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell124.StylePriority.UseFont = false;
        this.xrTableCell124.StylePriority.UsePadding = false;
        this.xrTableCell124.StylePriority.UseTextAlignment = false;
        this.xrTableCell124.Text = " ";
        this.xrTableCell124.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell124.Weight = 0.074547583703802975D;
        // 
        // xrTableCell125
        // 
        this.xrTableCell125.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell125.Name = "xrTableCell125";
        this.xrTableCell125.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell125.StylePriority.UseFont = false;
        this.xrTableCell125.StylePriority.UsePadding = false;
        this.xrTableCell125.StylePriority.UseTextAlignment = false;
        this.xrTableCell125.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell125.Weight = 0.06398492844492687D;
        // 
        // xrTableCell126
        // 
        this.xrTableCell126.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell126.Name = "xrTableCell126";
        this.xrTableCell126.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell126.StylePriority.UseFont = false;
        this.xrTableCell126.StylePriority.UsePadding = false;
        this.xrTableCell126.StylePriority.UseTextAlignment = false;
        this.xrTableCell126.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell126.Weight = 0.089043486488802559D;
        // 
        // xrTableCell127
        // 
        this.xrTableCell127.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell127.Name = "xrTableCell127";
        this.xrTableCell127.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell127.StylePriority.UseFont = false;
        this.xrTableCell127.StylePriority.UsePadding = false;
        this.xrTableCell127.StylePriority.UseTextAlignment = false;
        this.xrTableCell127.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell127.Weight = 0.076514430630141683D;
        // 
        // xrTableCell128
        // 
        this.xrTableCell128.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell128.Name = "xrTableCell128";
        this.xrTableCell128.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell128.StylePriority.UseFont = false;
        this.xrTableCell128.StylePriority.UsePadding = false;
        this.xrTableCell128.StylePriority.UseTextAlignment = false;
        this.xrTableCell128.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell128.Weight = 0.073126254177616562D;
        // 
        // xrTableCell129
        // 
        this.xrTableCell129.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell129.Name = "xrTableCell129";
        this.xrTableCell129.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell129.StylePriority.UseFont = false;
        this.xrTableCell129.StylePriority.UsePadding = false;
        this.xrTableCell129.StylePriority.UseTextAlignment = false;
        this.xrTableCell129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell129.Weight = 0.073139309229319022D;
        // 
        // xrTableCell130
        // 
        this.xrTableCell130.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell130.Name = "xrTableCell130";
        this.xrTableCell130.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell130.StylePriority.UseFont = false;
        this.xrTableCell130.StylePriority.UsePadding = false;
        this.xrTableCell130.StylePriority.UseTextAlignment = false;
        this.xrTableCell130.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell130.Weight = 0.085691797232061245D;
        // 
        // xrTableCell131
        // 
        this.xrTableCell131.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell131.Name = "xrTableCell131";
        this.xrTableCell131.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell131.StylePriority.UseFont = false;
        this.xrTableCell131.StylePriority.UsePadding = false;
        this.xrTableCell131.StylePriority.UseTextAlignment = false;
        this.xrTableCell131.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell131.Weight = 0.085691741441241975D;
        // 
        // xrTableCell132
        // 
        this.xrTableCell132.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell132.Name = "xrTableCell132";
        this.xrTableCell132.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell132.StylePriority.UseFont = false;
        this.xrTableCell132.StylePriority.UsePadding = false;
        this.xrTableCell132.StylePriority.UseTextAlignment = false;
        this.xrTableCell132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell132.Weight = 0.085691350905507335D;
        // 
        // xrTableCell133
        // 
        this.xrTableCell133.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell133.Name = "xrTableCell133";
        this.xrTableCell133.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell133.StylePriority.UseFont = false;
        this.xrTableCell133.StylePriority.UsePadding = false;
        this.xrTableCell133.StylePriority.UseTextAlignment = false;
        this.xrTableCell133.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell133.Weight = 0.076733130641567643D;
        // 
        // xrTableCell134
        // 
        this.xrTableCell134.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell134.Name = "xrTableCell134";
        this.xrTableCell134.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell134.StylePriority.UseFont = false;
        this.xrTableCell134.StylePriority.UsePadding = false;
        this.xrTableCell134.StylePriority.UseTextAlignment = false;
        this.xrTableCell134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell134.Weight = 0.10588026308272397D;
        // 
        // xrTableCell135
        // 
        this.xrTableCell135.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell135.Name = "xrTableCell135";
        this.xrTableCell135.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell135.StylePriority.UseFont = false;
        this.xrTableCell135.StylePriority.UsePadding = false;
        this.xrTableCell135.StylePriority.UseTextAlignment = false;
        this.xrTableCell135.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell135.Weight = 0.099250165810314817D;
        // 
        // xrTableCell136
        // 
        this.xrTableCell136.Font = new System.Drawing.Font("Times New Roman", 6F);
        this.xrTableCell136.Name = "xrTableCell136";
        this.xrTableCell136.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell136.StylePriority.UseFont = false;
        this.xrTableCell136.StylePriority.UsePadding = false;
        this.xrTableCell136.StylePriority.UseTextAlignment = false;
        this.xrTableCell136.Text = " ";
        this.xrTableCell136.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell136.Weight = 0.095441661325625593D;
        // 
        // TopMargin
        // 
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
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.HeightF = 58F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(500F, 22.99999F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(552.0834F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "BẢNG THANH TOÁN TIỀN LƯƠNG THÁNG {0}.{1}";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(552.0834F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CÔNG TY CỔ PHẦN AUSTFEED VIỆT NAM";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable18,
            this.xrTable1});
        this.PageHeader.HeightF = 130.625F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable18
        // 
        this.xrTable18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable18.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 102.5F);
        this.xrTable18.Name = "xrTable18";
        this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
        this.xrTable18.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable18.StylePriority.UseBorders = false;
        this.xrTable18.StylePriority.UseFont = false;
        this.xrTable18.StylePriority.UseTextAlignment = false;
        this.xrTable18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow18
        // 
        this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell60,
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell65,
            this.xrTableCell63,
            this.xrTableCell64,
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell70,
            this.xrTableCell68,
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell69,
            this.xrTableCell57,
            this.xrTableCell76,
            this.xrTableCell75,
            this.xrTableCell74,
            this.xrTableCell78,
            this.xrTableCell77,
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell73,
            this.xrTableCell81,
            this.xrTableCell83,
            this.xrTableCell84,
            this.xrTableCell82,
            this.xrTableCell85,
            this.xrTableCell58,
            this.xrTableCell89,
            this.xrTableCell88,
            this.xrTableCell87,
            this.xrTableCell90,
            this.xrTableCell91,
            this.xrTableCell86,
            this.xrTableCell92,
            this.xrTableCell95,
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell96,
            this.xrTableCell59});
        this.xrTableRow18.Name = "xrTableRow18";
        this.xrTableRow18.Weight = 1D;
        // 
        // xrTableCell60
        // 
        this.xrTableCell60.Name = "xrTableCell60";
        this.xrTableCell60.Text = "1";
        this.xrTableCell60.Weight = 0.04427548256827013D;
        // 
        // xrTableCell61
        // 
        this.xrTableCell61.Name = "xrTableCell61";
        this.xrTableCell61.Text = "2";
        this.xrTableCell61.Weight = 0.06398543056230005D;
        // 
        // xrTableCell62
        // 
        this.xrTableCell62.Name = "xrTableCell62";
        this.xrTableCell62.Text = "3";
        this.xrTableCell62.Weight = 0.13394563943420068D;
        // 
        // xrTableCell65
        // 
        this.xrTableCell65.Name = "xrTableCell65";
        this.xrTableCell65.Text = "10";
        this.xrTableCell65.Weight = 0.081231411893799288D;
        // 
        // xrTableCell63
        // 
        this.xrTableCell63.Name = "xrTableCell63";
        this.xrTableCell63.Text = "11";
        this.xrTableCell63.Weight = 0.10109689074416921D;
        // 
        // xrTableCell64
        // 
        this.xrTableCell64.Name = "xrTableCell64";
        this.xrTableCell64.Text = "16";
        this.xrTableCell64.Weight = 0.044425022885394065D;
        // 
        // xrTableCell66
        // 
        this.xrTableCell66.Name = "xrTableCell66";
        this.xrTableCell66.Text = "17";
        this.xrTableCell66.Weight = 0.11118145442314076D;
        // 
        // xrTableCell67
        // 
        this.xrTableCell67.Name = "xrTableCell67";
        this.xrTableCell67.Text = "18";
        this.xrTableCell67.Weight = 0.049512345350638615D;
        // 
        // xrTableCell70
        // 
        this.xrTableCell70.Name = "xrTableCell70";
        this.xrTableCell70.Text = "19";
        this.xrTableCell70.Weight = 0.048750715674168443D;
        // 
        // xrTableCell68
        // 
        this.xrTableCell68.Name = "xrTableCell68";
        this.xrTableCell68.Text = "20";
        this.xrTableCell68.Weight = 0.048750799360397307D;
        // 
        // xrTableCell71
        // 
        this.xrTableCell71.Name = "xrTableCell71";
        this.xrTableCell71.Text = "21";
        this.xrTableCell71.Weight = 0.048750785194759609D;
        // 
        // xrTableCell72
        // 
        this.xrTableCell72.Name = "xrTableCell72";
        this.xrTableCell72.Text = "22";
        this.xrTableCell72.Weight = 0.048750687451859488D;
        // 
        // xrTableCell69
        // 
        this.xrTableCell69.Name = "xrTableCell69";
        this.xrTableCell69.Text = "23";
        this.xrTableCell69.Weight = 0.04875079903349798D;
        // 
        // xrTableCell57
        // 
        this.xrTableCell57.Name = "xrTableCell57";
        this.xrTableCell57.Text = "24";
        this.xrTableCell57.Weight = 0.08226691085634108D;
        // 
        // xrTableCell76
        // 
        this.xrTableCell76.Name = "xrTableCell76";
        this.xrTableCell76.Text = "25";
        this.xrTableCell76.Weight = 0.041438187280128387D;
        // 
        // xrTableCell75
        // 
        this.xrTableCell75.Name = "xrTableCell75";
        this.xrTableCell75.Text = "26";
        this.xrTableCell75.Weight = 0.082876260363423646D;
        // 
        // xrTableCell74
        // 
        this.xrTableCell74.Name = "xrTableCell74";
        this.xrTableCell74.Text = "42";
        this.xrTableCell74.Weight = 0.063985380001870124D;
        // 
        // xrTableCell78
        // 
        this.xrTableCell78.Name = "xrTableCell78";
        this.xrTableCell78.Text = "56";
        this.xrTableCell78.Weight = 0.073126033629534237D;
        // 
        // xrTableCell77
        // 
        this.xrTableCell77.Name = "xrTableCell77";
        this.xrTableCell77.Text = "58";
        this.xrTableCell77.Weight = 0.045703841737680946D;
        // 
        // xrTableCell79
        // 
        this.xrTableCell79.Name = "xrTableCell79";
        this.xrTableCell79.Text = "59";
        this.xrTableCell79.Weight = 0.0731262567928112D;
        // 
        // xrTableCell80
        // 
        this.xrTableCell80.Name = "xrTableCell80";
        this.xrTableCell80.Text = "60";
        this.xrTableCell80.Weight = 0.06398537607907813D;
        // 
        // xrTableCell73
        // 
        this.xrTableCell73.Name = "xrTableCell73";
        this.xrTableCell73.Text = "61";
        this.xrTableCell73.Weight = 0.063985376079078143D;
        // 
        // xrTableCell81
        // 
        this.xrTableCell81.Name = "xrTableCell81";
        this.xrTableCell81.Text = "62";
        this.xrTableCell81.Weight = 0.12911346756344086D;
        // 
        // xrTableCell83
        // 
        this.xrTableCell83.Name = "xrTableCell83";
        this.xrTableCell83.Text = "64";
        this.xrTableCell83.Weight = 0.098644308023958349D;
        // 
        // xrTableCell84
        // 
        this.xrTableCell84.Name = "xrTableCell84";
        this.xrTableCell84.Text = "65";
        this.xrTableCell84.Weight = 0.074535196834334072D;
        // 
        // xrTableCell82
        // 
        this.xrTableCell82.Name = "xrTableCell82";
        this.xrTableCell82.Text = "66";
        this.xrTableCell82.Weight = 0.0745349736710571D;
        // 
        // xrTableCell85
        // 
        this.xrTableCell85.Name = "xrTableCell85";
        this.xrTableCell85.Text = "67";
        this.xrTableCell85.Weight = 0.074534863397015955D;
        // 
        // xrTableCell58
        // 
        this.xrTableCell58.Name = "xrTableCell58";
        this.xrTableCell58.Text = "68";
        this.xrTableCell58.Weight = 0.074547583703802975D;
        // 
        // xrTableCell89
        // 
        this.xrTableCell89.Name = "xrTableCell89";
        this.xrTableCell89.Text = "70";
        this.xrTableCell89.Weight = 0.06398492844492687D;
        // 
        // xrTableCell88
        // 
        this.xrTableCell88.Name = "xrTableCell88";
        this.xrTableCell88.Text = "71";
        this.xrTableCell88.Weight = 0.089043486488802559D;
        // 
        // xrTableCell87
        // 
        this.xrTableCell87.Name = "xrTableCell87";
        this.xrTableCell87.Text = "72";
        this.xrTableCell87.Weight = 0.076514430630141683D;
        // 
        // xrTableCell90
        // 
        this.xrTableCell90.Name = "xrTableCell90";
        this.xrTableCell90.Text = "73";
        this.xrTableCell90.Weight = 0.073126254177616562D;
        // 
        // xrTableCell91
        // 
        this.xrTableCell91.Name = "xrTableCell91";
        this.xrTableCell91.Text = "74";
        this.xrTableCell91.Weight = 0.073139309229319022D;
        // 
        // xrTableCell86
        // 
        this.xrTableCell86.Name = "xrTableCell86";
        this.xrTableCell86.Text = "75";
        this.xrTableCell86.Weight = 0.085691797232061245D;
        // 
        // xrTableCell92
        // 
        this.xrTableCell92.Name = "xrTableCell92";
        this.xrTableCell92.Text = "76";
        this.xrTableCell92.Weight = 0.085691741441241975D;
        // 
        // xrTableCell95
        // 
        this.xrTableCell95.Name = "xrTableCell95";
        this.xrTableCell95.Text = "77";
        this.xrTableCell95.Weight = 0.085691350905507335D;
        // 
        // xrTableCell93
        // 
        this.xrTableCell93.Name = "xrTableCell93";
        this.xrTableCell93.Text = "78";
        this.xrTableCell93.Weight = 0.076733130641567643D;
        // 
        // xrTableCell94
        // 
        this.xrTableCell94.Name = "xrTableCell94";
        this.xrTableCell94.Text = "79";
        this.xrTableCell94.Weight = 0.10588026308272397D;
        // 
        // xrTableCell96
        // 
        this.xrTableCell96.Name = "xrTableCell96";
        this.xrTableCell96.Text = "80";
        this.xrTableCell96.Weight = 0.099250165810314817D;
        // 
        // xrTableCell59
        // 
        this.xrTableCell59.Name = "xrTableCell59";
        this.xrTableCell59.Text = "81";
        this.xrTableCell59.Weight = 0.095441661325625593D;
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1641F, 102.5F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell4,
            this.xrTableCell9,
            this.xrTableCell3,
            this.xrTableCell2,
            this.xrTableCell29,
            this.xrTableCell25,
            this.xrTableCell33,
            this.xrTableCell24,
            this.xrTableCell39,
            this.xrTableCell35,
            this.xrTableCell34,
            this.xrTableCell38,
            this.xrTableCell40,
            this.xrTableCell1});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "STT";
        this.xrTableCell5.Weight = 0.24218727111816385D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Mã số";
        this.xrTableCell6.Weight = 0.34999999999999987D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Họ và tên";
        this.xrTableCell7.Weight = 0.7326823234558103D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Chức vụ";
        this.xrTableCell8.Weight = 0.4443359279632566D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.Text = "Lương cơ bản";
        this.xrTableCell4.Weight = 0.55299998283386231D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable3});
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = " ";
        this.xrTableCell9.Weight = 0.85116722106933573D;
        // 
        // xrTable2
        // 
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 25F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(85F, 77.49999F);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.Text = "Ngày công thường";
        this.xrTableCell10.Weight = 0.53050219064873327D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Lương trong tháng";
        this.xrTableCell11.Weight = 1.3340818547614228D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(85F, 25F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.Text = "Lương tháng";
        this.xrTableCell12.Weight = 2.14736786920028D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable5});
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.Text = " ";
        this.xrTableCell3.Weight = 2.0541661834716791D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0.4165955F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(205.0001F, 25F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.Text = "Tiền làm thêm giờ";
        this.xrTableCell13.Weight = 2.12D;
        // 
        // xrTable5
        // 
        this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(205.4166F, 77.49998F);
        this.xrTable5.StylePriority.UseBorders = false;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell15});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7});
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = " ";
        this.xrTableCell14.Weight = 2.2700467379588D;
        // 
        // xrTable6
        // 
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(160F, 25F);
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Top;
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.Text = "Số giờ làm thêm";
        this.xrTableCell16.Weight = 3.222377402317977D;
        // 
        // xrTable7
        // 
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0.416626F, 25F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(160F, 52.49998F);
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20,
            this.xrTableCell17,
            this.xrTableCell21,
            this.xrTableCell18,
            this.xrTableCell22,
            this.xrTableCell19});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.Text = "130%";
        this.xrTableCell20.Weight = 0.5D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Text = "150%";
        this.xrTableCell17.Weight = 0.5D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Text = "195%";
        this.xrTableCell21.Weight = 0.5D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Text = "200%";
        this.xrTableCell18.Weight = 0.5D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Text = "260%";
        this.xrTableCell22.Weight = 0.5D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.Text = "300%";
        this.xrTableCell19.Weight = 0.5D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Tiền làm thêm";
        this.xrTableCell15.Weight = 0.63679252480560877D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8,
            this.xrTable9});
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "xrTableCell2";
        this.xrTableCell2.Weight = 0.67999999999999972D;
        // 
        // xrTable8
        // 
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(67.99994F, 25F);
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell26});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.Text = "Phép";
        this.xrTableCell26.Weight = 3D;
        // 
        // xrTable9
        // 
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 25F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable9.SizeF = new System.Drawing.SizeF(67.99994F, 77.49999F);
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27,
            this.xrTableCell28});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseBorders = false;
        this.xrTableCell27.Text = "số ngày";
        this.xrTableCell27.Weight = 1D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.Text = "Thành tiền";
        this.xrTableCell28.Weight = 2D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseBorders = false;
        this.xrTableCell29.Text = "Tiền thưởng công việc";
        this.xrTableCell29.Weight = 0.34999999999999992D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10,
            this.xrTable11});
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Text = "xrTableCell25";
        this.xrTableCell25.Weight = 1.0499999999999998D;
        // 
        // xrTable10
        // 
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.041667F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable10.SizeF = new System.Drawing.SizeF(105F, 25F);
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell31});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseBorders = false;
        this.xrTableCell31.Text = "Phụ cấp thâm niên";
        this.xrTableCell31.Weight = 3D;
        // 
        // xrTable11
        // 
        this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26.04167F);
        this.xrTable11.Name = "xrTable11";
        this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
        this.xrTable11.SizeF = new System.Drawing.SizeF(105F, 76.45831F);
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell30,
            this.xrTableCell32});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.Text = "Tổng phụ cấp";
        this.xrTableCell23.Weight = 1.1428571428571428D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.Text = "Số năm";
        this.xrTableCell30.Weight = 0.71428571428571441D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.Text = "Số tiền";
        this.xrTableCell32.Weight = 1.1428571428571428D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.Text = "Tiền hỗ trợ";
        this.xrTableCell33.Weight = 0.35D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Text = "Tiền bù";
        this.xrTableCell24.Weight = 0.35D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.Text = "Tổng thu nhập";
        this.xrTableCell39.Weight = 0.70625001907348639D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseBorders = false;
        this.xrTableCell35.Text = "Tiền ăn ca";
        this.xrTableCell35.Weight = 0.53958314895629889D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable13,
            this.xrTable12});
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.Text = "xrTableCell34";
        this.xrTableCell34.Weight = 5.512500648498535D;
        // 
        // xrTable13
        // 
        this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0.0001831055F, 26.04167F);
        this.xrTable13.Name = "xrTable13";
        this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
        this.xrTable13.SizeF = new System.Drawing.SizeF(551.25F, 76.45834F);
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell37,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell41,
            this.xrTableCell48,
            this.xrTableCell42});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell43.Name = "xrTableCell43";
        this.xrTableCell43.StylePriority.UseBorders = false;
        this.xrTableCell43.Text = "Công đoàn 1%";
        this.xrTableCell43.Weight = 0.2218811756154159D;
        // 
        // xrTableCell44
        // 
        this.xrTableCell44.Name = "xrTableCell44";
        this.xrTableCell44.Text = "BHXH 8%";
        this.xrTableCell44.Weight = 0.22188117561541593D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Text = "BHYT 1.5%";
        this.xrTableCell37.Weight = 0.22188117561541593D;
        // 
        // xrTableCell45
        // 
        this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell45.Name = "xrTableCell45";
        this.xrTableCell45.StylePriority.UseBorders = false;
        this.xrTableCell45.Text = "BHTN 1%";
        this.xrTableCell45.Weight = 0.22188117561541587D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable14,
            this.xrTable15});
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.Text = " ";
        this.xrTableCell46.Weight = 0.68335718515343546D;
        // 
        // xrTable14
        // 
        this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(0.006866455F, 0F);
        this.xrTable14.Name = "xrTable14";
        this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
        this.xrTable14.SizeF = new System.Drawing.SizeF(125.56F, 25F);
        // 
        // xrTableRow14
        // 
        this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49});
        this.xrTableRow14.Name = "xrTableRow14";
        this.xrTableRow14.Weight = 1D;
        // 
        // xrTableCell49
        // 
        this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell49.Name = "xrTableCell49";
        this.xrTableCell49.StylePriority.UseBorders = false;
        this.xrTableCell49.Text = "Thu nhập chịu thuế";
        this.xrTableCell49.Weight = 1.2555999755859375D;
        // 
        // xrTable15
        // 
        this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0.006835938F, 25F);
        this.xrTable15.Name = "xrTable15";
        this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
        this.xrTable15.SizeF = new System.Drawing.SizeF(125.5599F, 51.45832F);
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrTableCell50
        // 
        this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell50.Name = "xrTableCell50";
        this.xrTableCell50.StylePriority.UseBorders = false;
        this.xrTableCell50.Text = "Số người";
        this.xrTableCell50.Weight = 0.83625397632869169D;
        // 
        // xrTableCell51
        // 
        this.xrTableCell51.Name = "xrTableCell51";
        this.xrTableCell51.Text = "TN chịu thuế";
        this.xrTableCell51.Weight = 1.1637460236713082D;
        // 
        // xrTableCell52
        // 
        this.xrTableCell52.Name = "xrTableCell52";
        this.xrTableCell52.Text = "Tiền thuế TNCN";
        this.xrTableCell52.Weight = 1D;
        // 
        // xrTableCell47
        // 
        this.xrTableCell47.Name = "xrTableCell47";
        this.xrTableCell47.Text = "Tiền BL";
        this.xrTableCell47.Weight = 0.2176870702243246D;
        // 
        // xrTableCell41
        // 
        this.xrTableCell41.Name = "xrTableCell41";
        this.xrTableCell41.Text = "Trừ tiền";
        this.xrTableCell41.Weight = 0.21768708339542975D;
        // 
        // xrTableCell48
        // 
        this.xrTableCell48.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable16,
            this.xrTable17});
        this.xrTableCell48.Name = "xrTableCell48";
        this.xrTableCell48.Text = " ";
        this.xrTableCell48.Weight = 0.76531766766053821D;
        // 
        // xrTable16
        // 
        this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0.007202148F, 0F);
        this.xrTable16.Name = "xrTable16";
        this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
        this.xrTable16.SizeF = new System.Drawing.SizeF(140.62F, 24.99999F);
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrTableCell53
        // 
        this.xrTableCell53.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell53.Name = "xrTableCell53";
        this.xrTableCell53.StylePriority.UseBorders = false;
        this.xrTableCell53.Text = "Tiền tạm ứng";
        this.xrTableCell53.Weight = 4.764538494732764D;
        // 
        // xrTable17
        // 
        this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(0.007324219F, 25F);
        this.xrTable17.Name = "xrTable17";
        this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
        this.xrTable17.SizeF = new System.Drawing.SizeF(140.62F, 51.45832F);
        // 
        // xrTableRow17
        // 
        this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56});
        this.xrTableRow17.Name = "xrTableRow17";
        this.xrTableRow17.Weight = 1D;
        // 
        // xrTableCell54
        // 
        this.xrTableCell54.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell54.Name = "xrTableCell54";
        this.xrTableCell54.StylePriority.UseBorders = false;
        this.xrTableCell54.Text = "Tiền tạm ứng";
        this.xrTableCell54.Weight = 1D;
        // 
        // xrTableCell55
        // 
        this.xrTableCell55.Name = "xrTableCell55";
        this.xrTableCell55.Text = "Lần 1 tiền mặt";
        this.xrTableCell55.Weight = 1D;
        // 
        // xrTableCell56
        // 
        this.xrTableCell56.Name = "xrTableCell56";
        this.xrTableCell56.Text = "Lần 1 chuyển khoản";
        this.xrTableCell56.Weight = 1D;
        // 
        // xrTableCell42
        // 
        this.xrTableCell42.Name = "xrTableCell42";
        this.xrTableCell42.Text = "Tổng các khoản giám trừ";
        this.xrTableCell42.Weight = 0.22842629110460838D;
        // 
        // xrTable12
        // 
        this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(0.0001907349F, 1.041667F);
        this.xrTable12.Name = "xrTable12";
        this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12});
        this.xrTable12.SizeF = new System.Drawing.SizeF(551.25F, 25F);
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.Text = "Các khoản giảm trừ";
        this.xrTableCell36.Weight = 5.4000010762119492D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.Text = "Tổng lương thực nhận";
        this.xrTableCell38.Weight = 0.57916631698608367D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.Text = "Lương trả cho tài khoản";
        this.xrTableCell40.Weight = 0.542896738052368D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Lương trả tiền mặt";
        this.xrTableCell1.Weight = 0.52206421852111806D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel14,
            this.xrLabel13,
            this.xrTable21,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6});
        this.ReportFooter.HeightF = 203F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(59.21173F, 159.8334F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(200.925F, 25F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Người lập";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(59.095F, 62.5F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Người lập";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable21
        // 
        this.xrTable21.BackColor = System.Drawing.Color.Silver;
        this.xrTable21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable21.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTable21.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable21.Name = "xrTable21";
        this.xrTable21.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTable21.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow21});
        this.xrTable21.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable21.StylePriority.UseBackColor = false;
        this.xrTable21.StylePriority.UseBorders = false;
        this.xrTable21.StylePriority.UseFont = false;
        this.xrTable21.StylePriority.UsePadding = false;
        this.xrTable21.StylePriority.UseTextAlignment = false;
        this.xrTable21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTableRow21
        // 
        this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell177,
            this.xrTableCell178,
            this.xrTableCell179,
            this.xrTableCell180,
            this.xrTableCell181,
            this.xrTableCell182,
            this.xrTableCell183,
            this.xrTableCell184,
            this.xrTableCell185,
            this.xrTableCell186,
            this.xrTableCell187,
            this.xrTableCell188,
            this.xrTableCell189,
            this.xrTableCell190,
            this.xrTableCell191,
            this.xrTableCell192,
            this.xrTableCell193,
            this.xrTableCell194,
            this.xrTableCell195,
            this.xrTableCell196,
            this.xrTableCell197,
            this.xrTableCell198,
            this.xrTableCell199,
            this.xrTableCell200,
            this.xrTableCell201,
            this.xrTableCell202,
            this.xrTableCell203,
            this.xrTableCell204,
            this.xrTableCell205,
            this.xrTableCell206,
            this.xrTableCell207,
            this.xrTableCell208,
            this.xrTableCell209,
            this.xrTableCell210,
            this.xrTableCell211,
            this.xrTableCell212,
            this.xrTableCell213,
            this.xrTableCell214,
            this.xrTableCell215,
            this.xrTableCell216});
        this.xrTableRow21.Name = "xrTableRow21";
        this.xrTableRow21.Weight = 1D;
        // 
        // xrTableCell177
        // 
        this.xrTableCell177.Name = "xrTableCell177";
        this.xrTableCell177.Weight = 0.04427548256827013D;
        // 
        // xrTableCell178
        // 
        this.xrTableCell178.Name = "xrTableCell178";
        this.xrTableCell178.StylePriority.UsePadding = false;
        this.xrTableCell178.StylePriority.UseTextAlignment = false;
        this.xrTableCell178.Weight = 0.06398543056230005D;
        // 
        // xrTableCell179
        // 
        this.xrTableCell179.Name = "xrTableCell179";
        this.xrTableCell179.StylePriority.UsePadding = false;
        this.xrTableCell179.StylePriority.UseTextAlignment = false;
        this.xrTableCell179.Text = "Tổng cộng";
        this.xrTableCell179.Weight = 0.13394563943420068D;
        // 
        // xrTableCell180
        // 
        this.xrTableCell180.Name = "xrTableCell180";
        this.xrTableCell180.StylePriority.UsePadding = false;
        this.xrTableCell180.StylePriority.UseTextAlignment = false;
        this.xrTableCell180.Weight = 0.081231411893799288D;
        // 
        // xrTableCell181
        // 
        this.xrTableCell181.Name = "xrTableCell181";
        xrSummary1.FormatString = "{0:n0}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell181.Summary = xrSummary1;
        this.xrTableCell181.Weight = 0.10131013720301432D;
        // 
        // xrTableCell182
        // 
        this.xrTableCell182.Name = "xrTableCell182";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell182.Summary = xrSummary2;
        this.xrTableCell182.Weight = 0.044211776426548943D;
        // 
        // xrTableCell183
        // 
        this.xrTableCell183.Name = "xrTableCell183";
        xrSummary3.FormatString = "{0:n0}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell183.Summary = xrSummary3;
        this.xrTableCell183.Weight = 0.11118145442314076D;
        // 
        // xrTableCell184
        // 
        this.xrTableCell184.Name = "xrTableCell184";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell184.Summary = xrSummary4;
        this.xrTableCell184.Weight = 0.049512345350638615D;
        // 
        // xrTableCell185
        // 
        this.xrTableCell185.Name = "xrTableCell185";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell185.Summary = xrSummary5;
        this.xrTableCell185.Weight = 0.048750715674168443D;
        // 
        // xrTableCell186
        // 
        this.xrTableCell186.Name = "xrTableCell186";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell186.Summary = xrSummary6;
        this.xrTableCell186.Weight = 0.048750799360397307D;
        // 
        // xrTableCell187
        // 
        this.xrTableCell187.Name = "xrTableCell187";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell187.Summary = xrSummary7;
        this.xrTableCell187.Weight = 0.048750785194759609D;
        // 
        // xrTableCell188
        // 
        this.xrTableCell188.Name = "xrTableCell188";
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell188.Summary = xrSummary8;
        this.xrTableCell188.Weight = 0.048750687451859488D;
        // 
        // xrTableCell189
        // 
        this.xrTableCell189.Name = "xrTableCell189";
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell189.Summary = xrSummary9;
        this.xrTableCell189.Weight = 0.04875079903349798D;
        // 
        // xrTableCell190
        // 
        this.xrTableCell190.Name = "xrTableCell190";
        xrSummary10.FormatString = "{0:n0}";
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell190.Summary = xrSummary10;
        this.xrTableCell190.Text = " ";
        this.xrTableCell190.Weight = 0.08226691085634108D;
        // 
        // xrTableCell191
        // 
        this.xrTableCell191.Name = "xrTableCell191";
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell191.Summary = xrSummary11;
        this.xrTableCell191.Weight = 0.041438187280128387D;
        // 
        // xrTableCell192
        // 
        this.xrTableCell192.Name = "xrTableCell192";
        xrSummary12.FormatString = "{0:n0}";
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell192.Summary = xrSummary12;
        this.xrTableCell192.Weight = 0.082876260363423646D;
        // 
        // xrTableCell193
        // 
        this.xrTableCell193.Name = "xrTableCell193";
        xrSummary13.FormatString = "{0:n0}";
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell193.Summary = xrSummary13;
        this.xrTableCell193.Weight = 0.063985380001870124D;
        // 
        // xrTableCell194
        // 
        this.xrTableCell194.Name = "xrTableCell194";
        xrSummary14.FormatString = "{0:n0}";
        xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell194.Summary = xrSummary14;
        this.xrTableCell194.Weight = 0.073126033629534237D;
        // 
        // xrTableCell195
        // 
        this.xrTableCell195.Name = "xrTableCell195";
        xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell195.Summary = xrSummary15;
        this.xrTableCell195.Weight = 0.045703841737680946D;
        // 
        // xrTableCell196
        // 
        this.xrTableCell196.Name = "xrTableCell196";
        xrSummary16.FormatString = "{0:n0}";
        xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell196.Summary = xrSummary16;
        this.xrTableCell196.Weight = 0.0731262567928112D;
        // 
        // xrTableCell197
        // 
        this.xrTableCell197.Name = "xrTableCell197";
        xrSummary17.FormatString = "{0:n0}";
        xrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell197.Summary = xrSummary17;
        this.xrTableCell197.Weight = 0.06398537607907813D;
        // 
        // xrTableCell198
        // 
        this.xrTableCell198.Name = "xrTableCell198";
        xrSummary18.FormatString = "{0:n0}";
        xrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell198.Summary = xrSummary18;
        this.xrTableCell198.Weight = 0.063985376079078143D;
        // 
        // xrTableCell199
        // 
        this.xrTableCell199.Name = "xrTableCell199";
        xrSummary19.FormatString = "{0:n0}";
        xrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell199.Summary = xrSummary19;
        this.xrTableCell199.Weight = 0.12911346756344086D;
        // 
        // xrTableCell200
        // 
        this.xrTableCell200.Name = "xrTableCell200";
        xrSummary20.FormatString = "{0:n0}";
        xrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell200.Summary = xrSummary20;
        this.xrTableCell200.Weight = 0.098644308023958349D;
        // 
        // xrTableCell201
        // 
        this.xrTableCell201.Name = "xrTableCell201";
        xrSummary21.FormatString = "{0:n0}";
        xrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell201.Summary = xrSummary21;
        this.xrTableCell201.Weight = 0.074535196834334072D;
        // 
        // xrTableCell202
        // 
        this.xrTableCell202.Name = "xrTableCell202";
        xrSummary22.FormatString = "{0:n0}";
        xrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell202.Summary = xrSummary22;
        this.xrTableCell202.Weight = 0.0745349736710571D;
        // 
        // xrTableCell203
        // 
        this.xrTableCell203.Name = "xrTableCell203";
        xrSummary23.FormatString = "{0:n0}";
        xrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell203.Summary = xrSummary23;
        this.xrTableCell203.Weight = 0.074534863397015955D;
        // 
        // xrTableCell204
        // 
        this.xrTableCell204.Name = "xrTableCell204";
        xrSummary24.FormatString = "{0:n0}";
        xrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell204.Summary = xrSummary24;
        this.xrTableCell204.Text = " ";
        this.xrTableCell204.Weight = 0.074547583703802975D;
        // 
        // xrTableCell205
        // 
        this.xrTableCell205.Name = "xrTableCell205";
        xrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell205.Summary = xrSummary25;
        this.xrTableCell205.Weight = 0.06398492844492687D;
        // 
        // xrTableCell206
        // 
        this.xrTableCell206.Name = "xrTableCell206";
        xrSummary26.FormatString = "{0:n0}";
        xrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell206.Summary = xrSummary26;
        this.xrTableCell206.Weight = 0.089043486488802559D;
        // 
        // xrTableCell207
        // 
        this.xrTableCell207.Name = "xrTableCell207";
        xrSummary27.FormatString = "{0:n0}";
        xrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell207.Summary = xrSummary27;
        this.xrTableCell207.Weight = 0.076514430630141683D;
        // 
        // xrTableCell208
        // 
        this.xrTableCell208.Name = "xrTableCell208";
        xrSummary28.FormatString = "{0:n0}";
        xrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell208.Summary = xrSummary28;
        this.xrTableCell208.Weight = 0.073126254177616562D;
        // 
        // xrTableCell209
        // 
        this.xrTableCell209.Name = "xrTableCell209";
        xrSummary29.FormatString = "{0:n0}";
        xrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell209.Summary = xrSummary29;
        this.xrTableCell209.Weight = 0.073139309229319022D;
        // 
        // xrTableCell210
        // 
        this.xrTableCell210.Name = "xrTableCell210";
        xrSummary30.FormatString = "{0:n0}";
        xrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell210.Summary = xrSummary30;
        this.xrTableCell210.Weight = 0.085691797232061245D;
        // 
        // xrTableCell211
        // 
        this.xrTableCell211.Name = "xrTableCell211";
        xrSummary31.FormatString = "{0:n0}";
        xrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell211.Summary = xrSummary31;
        this.xrTableCell211.Weight = 0.085691741441241975D;
        // 
        // xrTableCell212
        // 
        this.xrTableCell212.Name = "xrTableCell212";
        xrSummary32.FormatString = "{0:n0}";
        xrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell212.Summary = xrSummary32;
        this.xrTableCell212.Weight = 0.085691350905507335D;
        // 
        // xrTableCell213
        // 
        this.xrTableCell213.Name = "xrTableCell213";
        xrSummary33.FormatString = "{0:n0}";
        xrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell213.Summary = xrSummary33;
        this.xrTableCell213.Weight = 0.076733130641567643D;
        // 
        // xrTableCell214
        // 
        this.xrTableCell214.Name = "xrTableCell214";
        xrSummary34.FormatString = "{0:n0}";
        xrSummary34.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell214.Summary = xrSummary34;
        this.xrTableCell214.Weight = 0.10588026308272397D;
        // 
        // xrTableCell215
        // 
        this.xrTableCell215.Name = "xrTableCell215";
        xrSummary35.FormatString = "{0:n0}";
        xrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell215.Summary = xrSummary35;
        this.xrTableCell215.Weight = 0.099250165810314817D;
        // 
        // xrTableCell216
        // 
        this.xrTableCell216.Name = "xrTableCell216";
        xrSummary36.FormatString = "{0:n0}";
        xrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell216.Summary = xrSummary36;
        this.xrTableCell216.Text = " ";
        this.xrTableCell216.Weight = 0.095441661325625593D;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(1293.987F, 40.04167F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(308.3389F, 25F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Hưng Yên, Ngày 12 tháng 12 năm 2014";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1351.171F, 162.3749F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(201.0419F, 25F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(1351.171F, 65.04167F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Tổng giám đốc";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(665.7469F, 159.8334F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(201.0416F, 25F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Văn Thị Xuân";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(665.7468F, 62.5F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Kế toán trưởng";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(348.1529F, 62.5F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Giám đốc HCNS";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(348.1529F, 159.8334F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Nguyễn Viết Trung";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable20});
        this.GroupHeader1.HeightF = 28.12501F;
        this.GroupHeader1.Name = "GroupHeader1";
        this.GroupHeader1.StylePriority.UseFont = false;
        // 
        // xrTable20
        // 
        this.xrTable20.BackColor = System.Drawing.Color.Silver;
        this.xrTable20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable20.Name = "xrTable20";
        this.xrTable20.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
        this.xrTable20.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable20.StylePriority.UseBackColor = false;
        this.xrTable20.StylePriority.UseBorders = false;
        this.xrTable20.StylePriority.UseFont = false;
        this.xrTable20.StylePriority.UseTextAlignment = false;
        this.xrTable20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow20
        // 
        this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell137,
            this.xrTableCell139,
            this.xrTableCell140,
            this.xrTableCell141,
            this.xrTableCell142,
            this.xrTableCell143,
            this.xrTableCell144,
            this.xrTableCell145,
            this.xrTableCell146,
            this.xrTableCell147,
            this.xrTableCell148,
            this.xrTableCell149,
            this.xrTableCell150,
            this.xrTableCell151,
            this.xrTableCell152,
            this.xrTableCell153,
            this.xrTableCell154,
            this.xrTableCell155,
            this.xrTableCell156,
            this.xrTableCell157,
            this.xrTableCell158,
            this.xrTableCell159,
            this.xrTableCell160,
            this.xrTableCell161,
            this.xrTableCell162,
            this.xrTableCell163,
            this.xrTableCell164,
            this.xrTableCell165,
            this.xrTableCell166,
            this.xrTableCell167,
            this.xrTableCell168,
            this.xrTableCell169,
            this.xrTableCell170,
            this.xrTableCell171,
            this.xrTableCell172,
            this.xrTableCell173,
            this.xrTableCell174,
            this.xrTableCell175,
            this.xrTableCell176});
        this.xrTableRow20.Name = "xrTableRow20";
        this.xrTableRow20.Weight = 1D;
        // 
        // xrTableCell137
        // 
        this.xrTableCell137.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell137.Name = "xrTableCell137";
        this.xrTableCell137.StylePriority.UseFont = false;
        this.xrTableCell137.Weight = 0.04427548256827013D;
        // 
        // xrTableCell139
        // 
        this.xrTableCell139.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell139.Name = "xrTableCell139";
        this.xrTableCell139.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell139.StylePriority.UseFont = false;
        this.xrTableCell139.StylePriority.UsePadding = false;
        this.xrTableCell139.StylePriority.UseTextAlignment = false;
        this.xrTableCell139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell139.Weight = 0.19793106999650073D;
        // 
        // xrTableCell140
        // 
        this.xrTableCell140.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell140.Name = "xrTableCell140";
        this.xrTableCell140.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell140.StylePriority.UseFont = false;
        this.xrTableCell140.StylePriority.UsePadding = false;
        this.xrTableCell140.StylePriority.UseTextAlignment = false;
        this.xrTableCell140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell140.Weight = 0.081231411893799288D;
        // 
        // xrTableCell141
        // 
        this.xrTableCell141.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell141.Name = "xrTableCell141";
        this.xrTableCell141.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell141.StylePriority.UseFont = false;
        this.xrTableCell141.StylePriority.UsePadding = false;
        this.xrTableCell141.StylePriority.UseTextAlignment = false;
        xrSummary37.FormatString = "{0:n0}";
        xrSummary37.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell141.Summary = xrSummary37;
        this.xrTableCell141.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell141.Weight = 0.10131013720301432D;
        // 
        // xrTableCell142
        // 
        this.xrTableCell142.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell142.Name = "xrTableCell142";
        this.xrTableCell142.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell142.StylePriority.UseFont = false;
        this.xrTableCell142.StylePriority.UsePadding = false;
        this.xrTableCell142.StylePriority.UseTextAlignment = false;
        xrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell142.Summary = xrSummary38;
        this.xrTableCell142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell142.Weight = 0.044211776426548943D;
        // 
        // xrTableCell143
        // 
        this.xrTableCell143.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell143.Name = "xrTableCell143";
        this.xrTableCell143.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell143.StylePriority.UseFont = false;
        this.xrTableCell143.StylePriority.UsePadding = false;
        this.xrTableCell143.StylePriority.UseTextAlignment = false;
        xrSummary39.FormatString = "{0:n0}";
        xrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell143.Summary = xrSummary39;
        this.xrTableCell143.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell143.Weight = 0.11118145442314076D;
        // 
        // xrTableCell144
        // 
        this.xrTableCell144.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell144.Name = "xrTableCell144";
        this.xrTableCell144.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell144.StylePriority.UseFont = false;
        this.xrTableCell144.StylePriority.UsePadding = false;
        this.xrTableCell144.StylePriority.UseTextAlignment = false;
        xrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell144.Summary = xrSummary40;
        this.xrTableCell144.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell144.Weight = 0.049512345350638615D;
        // 
        // xrTableCell145
        // 
        this.xrTableCell145.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell145.Name = "xrTableCell145";
        this.xrTableCell145.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell145.StylePriority.UseFont = false;
        this.xrTableCell145.StylePriority.UsePadding = false;
        this.xrTableCell145.StylePriority.UseTextAlignment = false;
        xrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell145.Summary = xrSummary41;
        this.xrTableCell145.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell145.Weight = 0.048750715674168443D;
        // 
        // xrTableCell146
        // 
        this.xrTableCell146.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell146.Name = "xrTableCell146";
        this.xrTableCell146.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell146.StylePriority.UseFont = false;
        this.xrTableCell146.StylePriority.UsePadding = false;
        this.xrTableCell146.StylePriority.UseTextAlignment = false;
        xrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell146.Summary = xrSummary42;
        this.xrTableCell146.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell146.Weight = 0.048750799360397307D;
        // 
        // xrTableCell147
        // 
        this.xrTableCell147.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell147.Name = "xrTableCell147";
        this.xrTableCell147.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell147.StylePriority.UseFont = false;
        this.xrTableCell147.StylePriority.UsePadding = false;
        this.xrTableCell147.StylePriority.UseTextAlignment = false;
        xrSummary43.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell147.Summary = xrSummary43;
        this.xrTableCell147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell147.Weight = 0.048750785194759609D;
        // 
        // xrTableCell148
        // 
        this.xrTableCell148.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell148.Name = "xrTableCell148";
        this.xrTableCell148.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell148.StylePriority.UseFont = false;
        this.xrTableCell148.StylePriority.UsePadding = false;
        this.xrTableCell148.StylePriority.UseTextAlignment = false;
        xrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell148.Summary = xrSummary44;
        this.xrTableCell148.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell148.Weight = 0.048750687451859488D;
        // 
        // xrTableCell149
        // 
        this.xrTableCell149.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell149.Name = "xrTableCell149";
        this.xrTableCell149.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell149.StylePriority.UseFont = false;
        this.xrTableCell149.StylePriority.UsePadding = false;
        this.xrTableCell149.StylePriority.UseTextAlignment = false;
        xrSummary45.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell149.Summary = xrSummary45;
        this.xrTableCell149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell149.Weight = 0.04875079903349798D;
        // 
        // xrTableCell150
        // 
        this.xrTableCell150.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell150.Name = "xrTableCell150";
        this.xrTableCell150.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell150.StylePriority.UseFont = false;
        this.xrTableCell150.StylePriority.UsePadding = false;
        this.xrTableCell150.StylePriority.UseTextAlignment = false;
        xrSummary46.FormatString = "{0:n0}";
        xrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell150.Summary = xrSummary46;
        this.xrTableCell150.Text = " ";
        this.xrTableCell150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell150.Weight = 0.08226691085634108D;
        // 
        // xrTableCell151
        // 
        this.xrTableCell151.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell151.Name = "xrTableCell151";
        this.xrTableCell151.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell151.StylePriority.UseFont = false;
        this.xrTableCell151.StylePriority.UsePadding = false;
        this.xrTableCell151.StylePriority.UseTextAlignment = false;
        xrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell151.Summary = xrSummary47;
        this.xrTableCell151.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell151.Weight = 0.041438187280128387D;
        // 
        // xrTableCell152
        // 
        this.xrTableCell152.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell152.Name = "xrTableCell152";
        this.xrTableCell152.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell152.StylePriority.UseFont = false;
        this.xrTableCell152.StylePriority.UsePadding = false;
        this.xrTableCell152.StylePriority.UseTextAlignment = false;
        xrSummary48.FormatString = "{0:n0}";
        xrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell152.Summary = xrSummary48;
        this.xrTableCell152.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell152.Weight = 0.082876260363423646D;
        // 
        // xrTableCell153
        // 
        this.xrTableCell153.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell153.Name = "xrTableCell153";
        this.xrTableCell153.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell153.StylePriority.UseFont = false;
        this.xrTableCell153.StylePriority.UsePadding = false;
        this.xrTableCell153.StylePriority.UseTextAlignment = false;
        xrSummary49.FormatString = "{0:n0}";
        xrSummary49.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell153.Summary = xrSummary49;
        this.xrTableCell153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell153.Weight = 0.063985380001870124D;
        // 
        // xrTableCell154
        // 
        this.xrTableCell154.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell154.Name = "xrTableCell154";
        this.xrTableCell154.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell154.StylePriority.UseFont = false;
        this.xrTableCell154.StylePriority.UsePadding = false;
        this.xrTableCell154.StylePriority.UseTextAlignment = false;
        xrSummary50.FormatString = "{0:n0}";
        xrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell154.Summary = xrSummary50;
        this.xrTableCell154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell154.Weight = 0.073126033629534237D;
        // 
        // xrTableCell155
        // 
        this.xrTableCell155.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell155.Name = "xrTableCell155";
        this.xrTableCell155.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell155.StylePriority.UseFont = false;
        this.xrTableCell155.StylePriority.UsePadding = false;
        this.xrTableCell155.StylePriority.UseTextAlignment = false;
        xrSummary51.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell155.Summary = xrSummary51;
        this.xrTableCell155.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell155.Weight = 0.045703841737680946D;
        // 
        // xrTableCell156
        // 
        this.xrTableCell156.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell156.Name = "xrTableCell156";
        this.xrTableCell156.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell156.StylePriority.UseFont = false;
        this.xrTableCell156.StylePriority.UsePadding = false;
        this.xrTableCell156.StylePriority.UseTextAlignment = false;
        xrSummary52.FormatString = "{0:n0}";
        xrSummary52.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell156.Summary = xrSummary52;
        this.xrTableCell156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell156.Weight = 0.0731262567928112D;
        // 
        // xrTableCell157
        // 
        this.xrTableCell157.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell157.Name = "xrTableCell157";
        this.xrTableCell157.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell157.StylePriority.UseFont = false;
        this.xrTableCell157.StylePriority.UsePadding = false;
        this.xrTableCell157.StylePriority.UseTextAlignment = false;
        xrSummary53.FormatString = "{0:n0}";
        xrSummary53.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell157.Summary = xrSummary53;
        this.xrTableCell157.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell157.Weight = 0.06398537607907813D;
        // 
        // xrTableCell158
        // 
        this.xrTableCell158.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell158.Name = "xrTableCell158";
        this.xrTableCell158.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell158.StylePriority.UseFont = false;
        this.xrTableCell158.StylePriority.UsePadding = false;
        this.xrTableCell158.StylePriority.UseTextAlignment = false;
        xrSummary54.FormatString = "{0:n0}";
        xrSummary54.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell158.Summary = xrSummary54;
        this.xrTableCell158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell158.Weight = 0.063985376079078143D;
        // 
        // xrTableCell159
        // 
        this.xrTableCell159.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell159.Name = "xrTableCell159";
        this.xrTableCell159.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell159.StylePriority.UseFont = false;
        this.xrTableCell159.StylePriority.UsePadding = false;
        this.xrTableCell159.StylePriority.UseTextAlignment = false;
        xrSummary55.FormatString = "{0:n0}";
        xrSummary55.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell159.Summary = xrSummary55;
        this.xrTableCell159.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell159.Weight = 0.12911346756344086D;
        // 
        // xrTableCell160
        // 
        this.xrTableCell160.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell160.Name = "xrTableCell160";
        this.xrTableCell160.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell160.StylePriority.UseFont = false;
        this.xrTableCell160.StylePriority.UsePadding = false;
        this.xrTableCell160.StylePriority.UseTextAlignment = false;
        xrSummary56.FormatString = "{0:n0}";
        xrSummary56.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell160.Summary = xrSummary56;
        this.xrTableCell160.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell160.Weight = 0.098644308023958349D;
        // 
        // xrTableCell161
        // 
        this.xrTableCell161.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell161.Name = "xrTableCell161";
        this.xrTableCell161.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell161.StylePriority.UseFont = false;
        this.xrTableCell161.StylePriority.UsePadding = false;
        this.xrTableCell161.StylePriority.UseTextAlignment = false;
        xrSummary57.FormatString = "{0:n0}";
        xrSummary57.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell161.Summary = xrSummary57;
        this.xrTableCell161.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell161.Weight = 0.074535196834334072D;
        // 
        // xrTableCell162
        // 
        this.xrTableCell162.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell162.Name = "xrTableCell162";
        this.xrTableCell162.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell162.StylePriority.UseFont = false;
        this.xrTableCell162.StylePriority.UsePadding = false;
        this.xrTableCell162.StylePriority.UseTextAlignment = false;
        xrSummary58.FormatString = "{0:n0}";
        xrSummary58.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell162.Summary = xrSummary58;
        this.xrTableCell162.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell162.Weight = 0.0745349736710571D;
        // 
        // xrTableCell163
        // 
        this.xrTableCell163.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell163.Name = "xrTableCell163";
        this.xrTableCell163.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell163.StylePriority.UseFont = false;
        this.xrTableCell163.StylePriority.UsePadding = false;
        this.xrTableCell163.StylePriority.UseTextAlignment = false;
        xrSummary59.FormatString = "{0:n0}";
        xrSummary59.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell163.Summary = xrSummary59;
        this.xrTableCell163.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell163.Weight = 0.074534863397015955D;
        // 
        // xrTableCell164
        // 
        this.xrTableCell164.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell164.Name = "xrTableCell164";
        this.xrTableCell164.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell164.StylePriority.UseFont = false;
        this.xrTableCell164.StylePriority.UsePadding = false;
        this.xrTableCell164.StylePriority.UseTextAlignment = false;
        xrSummary60.FormatString = "{0:n0}";
        xrSummary60.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell164.Summary = xrSummary60;
        this.xrTableCell164.Text = " ";
        this.xrTableCell164.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell164.Weight = 0.074547583703802975D;
        // 
        // xrTableCell165
        // 
        this.xrTableCell165.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell165.Name = "xrTableCell165";
        this.xrTableCell165.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell165.StylePriority.UseFont = false;
        this.xrTableCell165.StylePriority.UsePadding = false;
        this.xrTableCell165.StylePriority.UseTextAlignment = false;
        xrSummary61.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell165.Summary = xrSummary61;
        this.xrTableCell165.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell165.Weight = 0.06398492844492687D;
        // 
        // xrTableCell166
        // 
        this.xrTableCell166.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell166.Name = "xrTableCell166";
        this.xrTableCell166.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell166.StylePriority.UseFont = false;
        this.xrTableCell166.StylePriority.UsePadding = false;
        this.xrTableCell166.StylePriority.UseTextAlignment = false;
        xrSummary62.FormatString = "{0:n0}";
        xrSummary62.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell166.Summary = xrSummary62;
        this.xrTableCell166.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell166.Weight = 0.089043486488802559D;
        // 
        // xrTableCell167
        // 
        this.xrTableCell167.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell167.Name = "xrTableCell167";
        this.xrTableCell167.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell167.StylePriority.UseFont = false;
        this.xrTableCell167.StylePriority.UsePadding = false;
        this.xrTableCell167.StylePriority.UseTextAlignment = false;
        xrSummary63.FormatString = "{0:n0}";
        xrSummary63.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell167.Summary = xrSummary63;
        this.xrTableCell167.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell167.Weight = 0.076514430630141683D;
        // 
        // xrTableCell168
        // 
        this.xrTableCell168.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell168.Name = "xrTableCell168";
        this.xrTableCell168.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell168.StylePriority.UseFont = false;
        this.xrTableCell168.StylePriority.UsePadding = false;
        this.xrTableCell168.StylePriority.UseTextAlignment = false;
        xrSummary64.FormatString = "{0:n0}";
        xrSummary64.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell168.Summary = xrSummary64;
        this.xrTableCell168.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell168.Weight = 0.073126254177616562D;
        // 
        // xrTableCell169
        // 
        this.xrTableCell169.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell169.Name = "xrTableCell169";
        this.xrTableCell169.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell169.StylePriority.UseFont = false;
        this.xrTableCell169.StylePriority.UsePadding = false;
        this.xrTableCell169.StylePriority.UseTextAlignment = false;
        xrSummary65.FormatString = "{0:n0}";
        xrSummary65.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell169.Summary = xrSummary65;
        this.xrTableCell169.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell169.Weight = 0.073139309229319022D;
        // 
        // xrTableCell170
        // 
        this.xrTableCell170.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell170.Name = "xrTableCell170";
        this.xrTableCell170.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell170.StylePriority.UseFont = false;
        this.xrTableCell170.StylePriority.UsePadding = false;
        this.xrTableCell170.StylePriority.UseTextAlignment = false;
        xrSummary66.FormatString = "{0:n0}";
        xrSummary66.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell170.Summary = xrSummary66;
        this.xrTableCell170.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell170.Weight = 0.085691797232061245D;
        // 
        // xrTableCell171
        // 
        this.xrTableCell171.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell171.Name = "xrTableCell171";
        this.xrTableCell171.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell171.StylePriority.UseFont = false;
        this.xrTableCell171.StylePriority.UsePadding = false;
        this.xrTableCell171.StylePriority.UseTextAlignment = false;
        xrSummary67.FormatString = "{0:n0}";
        xrSummary67.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell171.Summary = xrSummary67;
        this.xrTableCell171.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell171.Weight = 0.085691741441241975D;
        // 
        // xrTableCell172
        // 
        this.xrTableCell172.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell172.Name = "xrTableCell172";
        this.xrTableCell172.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell172.StylePriority.UseFont = false;
        this.xrTableCell172.StylePriority.UsePadding = false;
        this.xrTableCell172.StylePriority.UseTextAlignment = false;
        xrSummary68.FormatString = "{0:n0}";
        xrSummary68.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell172.Summary = xrSummary68;
        this.xrTableCell172.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell172.Weight = 0.085691350905507335D;
        // 
        // xrTableCell173
        // 
        this.xrTableCell173.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell173.Name = "xrTableCell173";
        this.xrTableCell173.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell173.StylePriority.UseFont = false;
        this.xrTableCell173.StylePriority.UsePadding = false;
        this.xrTableCell173.StylePriority.UseTextAlignment = false;
        xrSummary69.FormatString = "{0:n0}";
        xrSummary69.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell173.Summary = xrSummary69;
        this.xrTableCell173.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell173.Weight = 0.076733130641567643D;
        // 
        // xrTableCell174
        // 
        this.xrTableCell174.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell174.Name = "xrTableCell174";
        this.xrTableCell174.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell174.StylePriority.UseFont = false;
        this.xrTableCell174.StylePriority.UsePadding = false;
        this.xrTableCell174.StylePriority.UseTextAlignment = false;
        xrSummary70.FormatString = "{0:n0}";
        xrSummary70.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell174.Summary = xrSummary70;
        this.xrTableCell174.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell174.Weight = 0.10588026308272397D;
        // 
        // xrTableCell175
        // 
        this.xrTableCell175.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell175.Name = "xrTableCell175";
        this.xrTableCell175.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell175.StylePriority.UseFont = false;
        this.xrTableCell175.StylePriority.UsePadding = false;
        this.xrTableCell175.StylePriority.UseTextAlignment = false;
        xrSummary71.FormatString = "{0:n0}";
        xrSummary71.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell175.Summary = xrSummary71;
        this.xrTableCell175.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell175.Weight = 0.099250165810314817D;
        // 
        // xrTableCell176
        // 
        this.xrTableCell176.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
        this.xrTableCell176.Name = "xrTableCell176";
        this.xrTableCell176.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTableCell176.StylePriority.UseFont = false;
        this.xrTableCell176.StylePriority.UsePadding = false;
        this.xrTableCell176.StylePriority.UseTextAlignment = false;
        xrSummary72.FormatString = "{0:n0}";
        xrSummary72.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell176.Summary = xrSummary72;
        this.xrTableCell176.Text = " ";
        this.xrTableCell176.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell176.Weight = 0.095441661325625593D;
        // 
        // rp_austfeed_BangTongHopLuongVanPhong
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
        this.Margins = new System.Drawing.Printing.Margins(7, 6, 100, 100);
        this.PageHeight = 1169;
        this.PageWidth = 1654;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
