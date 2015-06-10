using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using Ext.Net;

/// <summary>
/// Summary description for rp_austfeed_BangTongHopLuongKinhDoanh
/// </summary>
public class rp_austfeed_BangTongHopLuongKinhDoanh : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private GroupHeaderBand GroupHeader1;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell32;
    private XRTable xrTable11;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell10;
    private XRTable xrTable12;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell34;
    private XRTable xrTable13;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell18;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell11;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell24;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell15;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell27;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell20;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell29;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell12;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell40;
    private XRTable xrTable19;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell39;
    private XRTable xrTable14;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTable xrTable15;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell49;
    private XRTable xrTable16;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell48;
    private XRTable xrTable17;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell53;
    private XRTable xrTable18;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell1;
    private XRTable xrTable20;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell60;
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
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTableCell xrTableCell100;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTable xrTable21;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell105;
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
    private XRTableCell xrTableCell137;
    private XRTableCell xrTableCell138;
    private XRTableCell xrTableCell139;
    private XRTableCell xrTableCell140;
    private XRTableCell xrTableCell141;
    private XRTableCell xrTableCell142;
    private XRTableCell xrTableCell143;
    private XRTableCell xrTableCell144;
    private XRTableCell xrTableCell145;
    private XRTableCell xrTableCell146;
    private XRTableCell xrTableCell147;
    private XRTable xrTable22;
    private XRTableRow xrTableRow22;
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
    private XRTable xrTable23;
    private XRTableRow xrTableRow23;
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
    private XRTableCell xrTableCell217;
    private XRTableCell xrTableCell218;
    private XRTableCell xrTableCell219;
    private XRTableCell xrTableCell220;
    private XRTableCell xrTableCell221;
    private XRTableCell xrTableCell222;
    private XRTableCell xrTableCell223;
    private XRTableCell xrTableCell224;
    private XRTableCell xrTableCell225;
    private XRTableCell xrTableCell226;
    private XRTableCell xrTableCell227;
    private XRTableCell xrTableCell228;
    private XRTableCell xrTableCell229;
    private XRTableCell xrTableCell230;
    private XRTableCell xrTableCell231;
    private XRTableCell xrTableCell232;
    private XRTableCell xrTableCell233;
    private XRLabel xrLabel11;
    private XRLabel xrLabel9;
    private XRLabel xrLabel12;
    private XRLabel xrLabel10;
    private XRLabel xrLabel8;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRTableCell xrTableCell234;
    private XRTableCell xrTableCell235;
    private XRTableCell xrTableCell236;
    private XRTableCell xrTableCell237;
    private XRTableCell xrTableCell238;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_austfeed_BangTongHopLuongKinhDoanh()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

        xrTableCell148.Text = STT.ToString();
        STT++;
    }
    public void BinData(ReportFilter filter)
    {
        try
        {
            ReportController rp = new ReportController();
            xrLabel1.Text = rp.GetCompanyName(filter.SessionDepartment);
            xrLabel2.Text = string.Format(xrLabel2.Text, filter.StartMonth, filter.Year);
            DataTable dt = DataHandler.GetInstance().ExecuteDataTable("rp_austfeed_TongHopLuongKinhDoanh", "@Month", "@Year", "@MaBoPhan",
                                                                       filter.StartMonth, filter.Year, filter.SelectedDepartment);
            if (dt.Rows.Count > 0)
            {
                DataSource = dt;
                xrTableCell149.DataBindings.Add("Text", DataSource, "MaCanBo");
                xrTableCell150.DataBindings.Add("Text", DataSource, "HoTen");
                xrTableCell151.DataBindings.Add("Text", DataSource, "ChucVu");
                xrTableCell152.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:n0}");
                xrTableCell153.DataBindings.Add("Text", DataSource, "NgayCongThuong");
                xrTableCell154.DataBindings.Add("Text", DataSource, "LuongTrongThang", "{0:n0}");
                xrTableCell155.DataBindings.Add("Text", DataSource, "SoNgayPhep");
                xrTableCell156.DataBindings.Add("Text", DataSource, "ThanhTienPhep", "{0:n0}");
                xrTableCell157.DataBindings.Add("Text", DataSource, "PCTienAn", "{0:n0}");
                xrTableCell158.DataBindings.Add("Text", DataSource, "PCDienThoai", "{0:n0}");
                xrTableCell159.DataBindings.Add("Text", DataSource, "PCNhaO", "{0:n0}");
                xrTableCell160.DataBindings.Add("Text", DataSource, "ThuongSPCL", "{0:n0}");
                xrTableCell161.DataBindings.Add("Text", DataSource, "ThuongSPKK", "{0:n0}");
                xrTableCell162.DataBindings.Add("Text", DataSource, "ThuongTarget", "{0:n0}");
                xrTableCell163.DataBindings.Add("Text", DataSource, "PhatTarget", "{0:n0}");
                xrTableCell164.DataBindings.Add("Text", DataSource, "ThuongTangTruongThang", "{0:n0}");
                xrTableCell237.DataBindings.Add("Text", DataSource, "PhatTangTruongThang", "{0:n0}");
                xrTableCell165.DataBindings.Add("Text", DataSource, "ThuongTangTruongQuy", "{0:n0}");
                xrTableCell166.DataBindings.Add("Text", DataSource, "PhatTangTruongQuy", "{0:n0}");
                xrTableCell167.DataBindings.Add("Text", DataSource, "DaiLyMoi");
                xrTableCell168.DataBindings.Add("Text", DataSource, "DaiLyDatSL");
                xrTableCell169.DataBindings.Add("Text", DataSource, "ThuongPhatChiTieu", "{0:n0}");
                xrTableCell170.DataBindings.Add("Text", DataSource, "TongPhuCap", "{0:n0}");
                xrTableCell171.DataBindings.Add("Text", DataSource, "TienHoTro", "{0:n0}");
                xrTableCell172.DataBindings.Add("Text", DataSource, "TienBu", "{0:n0}");
                xrTableCell173.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                xrTableCell174.DataBindings.Add("Text", DataSource, "TienAnCa", "{0:n0}");
                xrTableCell175.DataBindings.Add("Text", DataSource, "CongDoan", "{0:n0}");
                xrTableCell176.DataBindings.Add("Text", DataSource, "BHXH", "{0:n0}");
                xrTableCell177.DataBindings.Add("Text", DataSource, "BHYT", "{0:n0}");
                xrTableCell178.DataBindings.Add("Text", DataSource, "BHTN", "{0:n0}");
                xrTableCell179.DataBindings.Add("Text", DataSource, "SoNguoiChiuThue");
                xrTableCell180.DataBindings.Add("Text", DataSource, "TNChiuThue", "{0:n0}");
                xrTableCell181.DataBindings.Add("Text", DataSource, "TienThueTNCN", "{0:n0}");
                xrTableCell182.DataBindings.Add("Text", DataSource, "TienBL", "{0:n0}");
                xrTableCell183.DataBindings.Add("Text", DataSource, "TienTru", "{0:n0}");
                xrTableCell184.DataBindings.Add("Text", DataSource, "TienTamUng", "{0:n0}");
                xrTableCell185.DataBindings.Add("Text", DataSource, "Lan1TienMat", "{0:n0}");
                xrTableCell186.DataBindings.Add("Text", DataSource, "Lan1ChuyenKhoan", "{0:n0}");
                xrTableCell187.DataBindings.Add("Text", DataSource, "TongCacKhoanGiamTru", "{0:n0}");
                xrTableCell188.DataBindings.Add("Text", DataSource, "TongLuongThucNhan", "{0:n0}");
                xrTableCell189.DataBindings.Add("Text", DataSource, "LuongTraQuaTaiKhoan", "{0:n0}");
                xrTableCell190.DataBindings.Add("Text", DataSource, "LuongTraTienMat", "{0:n0}");
                //Group header
                this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                new DevExpress.XtraReports.UI.GroupField("MaDonVi", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
                xrTableCell107.DataBindings.Add("Text", DataSource, "TenDonVi");

                xrTableCell109.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:n0}");
                xrTableCell110.DataBindings.Add("Text", DataSource, "NgayCongThuong");
                xrTableCell111.DataBindings.Add("Text", DataSource, "LuongTrongThang", "{0:n0}");
                xrTableCell112.DataBindings.Add("Text", DataSource, "SoNgayPhep");
                xrTableCell113.DataBindings.Add("Text", DataSource, "ThanhTienPhep", "{0:n0}");
                xrTableCell114.DataBindings.Add("Text", DataSource, "PCTienAn", "{0:n0}");
                xrTableCell115.DataBindings.Add("Text", DataSource, "PCDienThoai", "{0:n0}");
                xrTableCell116.DataBindings.Add("Text", DataSource, "PCNhaO", "{0:n0}");
                xrTableCell117.DataBindings.Add("Text", DataSource, "ThuongSPCL", "{0:n0}");
                xrTableCell118.DataBindings.Add("Text", DataSource, "ThuongSPKK", "{0:n0}");
                xrTableCell119.DataBindings.Add("Text", DataSource, "ThuongTarget", "{0:n0}");
                xrTableCell120.DataBindings.Add("Text", DataSource, "PhatTarget", "{0:n0}");
                xrTableCell121.DataBindings.Add("Text", DataSource, "ThuongTangTruongThang", "{0:n0}");
                xrTableCell236.DataBindings.Add("Text", DataSource, "PhatTangTruongThang", "{0:n0}");
                xrTableCell122.DataBindings.Add("Text", DataSource, "ThuongTangTruongQuy", "{0:n0}");
                xrTableCell123.DataBindings.Add("Text", DataSource, "PhatTangTruongQuy", "{0:n0}");
                xrTableCell124.DataBindings.Add("Text", DataSource, "DaiLyMoi", "{0:n0}");
                xrTableCell125.DataBindings.Add("Text", DataSource, "DaiLyDatSL", "{0:n0}");
                xrTableCell126.DataBindings.Add("Text", DataSource, "ThuongPhatChiTieu", "{0:n0}");
                xrTableCell127.DataBindings.Add("Text", DataSource, "TongPhuCap", "{0:n0}");
                xrTableCell128.DataBindings.Add("Text", DataSource, "TienHoTro", "{0:n0}");
                xrTableCell129.DataBindings.Add("Text", DataSource, "TienBu", "{0:n0}");
                xrTableCell130.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                xrTableCell131.DataBindings.Add("Text", DataSource, "TienAnCa", "{0:n0}");
                xrTableCell132.DataBindings.Add("Text", DataSource, "CongDoan", "{0:n0}");
                xrTableCell133.DataBindings.Add("Text", DataSource, "BHXH", "{0:n0}");
                xrTableCell134.DataBindings.Add("Text", DataSource, "BHYT", "{0:n0}");
                xrTableCell135.DataBindings.Add("Text", DataSource, "BHTN", "{0:n0}");
                xrTableCell136.DataBindings.Add("Text", DataSource, "SoNguoiChiuThue");
                xrTableCell137.DataBindings.Add("Text", DataSource, "TNChiuThue", "{0:n0}");
                xrTableCell138.DataBindings.Add("Text", DataSource, "TienThueTNCN", "{0:n0}");
                xrTableCell139.DataBindings.Add("Text", DataSource, "TienBL", "{0:n0}");
                xrTableCell140.DataBindings.Add("Text", DataSource, "TienTru", "{0:n0}");
                xrTableCell141.DataBindings.Add("Text", DataSource, "TienTamUng", "{0:n0}");
                xrTableCell142.DataBindings.Add("Text", DataSource, "Lan1TienMat", "{0:n0}");
                xrTableCell143.DataBindings.Add("Text", DataSource, "Lan1ChuyenKhoan", "{0:n0}");
                xrTableCell144.DataBindings.Add("Text", DataSource, "TongCacKhoanGiamTru", "{0:n0}");
                xrTableCell145.DataBindings.Add("Text", DataSource, "TongLuongThucNhan", "{0:n0}");
                xrTableCell146.DataBindings.Add("Text", DataSource, "LuongTraQuaTaiKhoan", "{0:n0}");
                xrTableCell147.DataBindings.Add("Text", DataSource, "LuongTraTienMat", "{0:n0}");
                //reportFopter
                xrTableCell195.DataBindings.Add("Text", DataSource, "LuongCoBan", "{0:n0}");
                xrTableCell196.DataBindings.Add("Text", DataSource, "NgayCongThuong");
                xrTableCell197.DataBindings.Add("Text", DataSource, "LuongTrongThang", "{0:n0}");
                xrTableCell198.DataBindings.Add("Text", DataSource, "SoNgayPhep");
                xrTableCell199.DataBindings.Add("Text", DataSource, "ThanhTienPhep", "{0:n0}");
                xrTableCell200.DataBindings.Add("Text", DataSource, "PCTienAn", "{0:n0}");
                xrTableCell201.DataBindings.Add("Text", DataSource, "PCDienThoai", "{0:n0}");
                xrTableCell202.DataBindings.Add("Text", DataSource, "PCNhaO", "{0:n0}");
                xrTableCell203.DataBindings.Add("Text", DataSource, "ThuongSPCL", "{0:n0}");
                xrTableCell204.DataBindings.Add("Text", DataSource, "ThuongSPKK", "{0:n0}");
                xrTableCell205.DataBindings.Add("Text", DataSource, "ThuongTarget", "{0:n0}");
                xrTableCell206.DataBindings.Add("Text", DataSource, "PhatTarget", "{0:n0}");
                xrTableCell207.DataBindings.Add("Text", DataSource, "ThuongTangTruongThang", "{0:n0}");
                xrTableCell238.DataBindings.Add("Text", DataSource, "PhatTangTruongThang", "{0:n0}");
                xrTableCell208.DataBindings.Add("Text", DataSource, "ThuongTangTruongQuy", "{0:n0}");
                xrTableCell209.DataBindings.Add("Text", DataSource, "PhatTangTruongQuy", "{0:n0}");
                xrTableCell210.DataBindings.Add("Text", DataSource, "DaiLyMoi", "{0:n0}");
                xrTableCell211.DataBindings.Add("Text", DataSource, "DaiLyDatSL", "{0:n0}");
                xrTableCell212.DataBindings.Add("Text", DataSource, "ThuongPhatChiTieu", "{0:n0}");
                xrTableCell213.DataBindings.Add("Text", DataSource, "TongPhuCap", "{0:n0}");
                xrTableCell214.DataBindings.Add("Text", DataSource, "TienHoTro", "{0:n0}");
                xrTableCell215.DataBindings.Add("Text", DataSource, "TienBu", "{0:n0}");
                xrTableCell216.DataBindings.Add("Text", DataSource, "TongThuNhap", "{0:n0}");
                xrTableCell217.DataBindings.Add("Text", DataSource, "TienAnCa", "{0:n0}");
                xrTableCell218.DataBindings.Add("Text", DataSource, "CongDoan", "{0:n0}");
                xrTableCell219.DataBindings.Add("Text", DataSource, "BHXH", "{0:n0}");
                xrTableCell220.DataBindings.Add("Text", DataSource, "BHYT", "{0:n0}");
                xrTableCell221.DataBindings.Add("Text", DataSource, "BHTN", "{0:n0}");
                xrTableCell222.DataBindings.Add("Text", DataSource, "SoNguoiChiuThue");
                xrTableCell223.DataBindings.Add("Text", DataSource, "TNChiuThue", "{0:n0}");
                xrTableCell224.DataBindings.Add("Text", DataSource, "TienThueTNCN", "{0:n0}");
                xrTableCell225.DataBindings.Add("Text", DataSource, "TienBL", "{0:n0}");
                xrTableCell226.DataBindings.Add("Text", DataSource, "TienTru", "{0:n0}");
                xrTableCell227.DataBindings.Add("Text", DataSource, "TienTamUng", "{0:n0}");
                xrTableCell228.DataBindings.Add("Text", DataSource, "Lan1TienMat", "{0:n0}");
                xrTableCell229.DataBindings.Add("Text", DataSource, "Lan1ChuyenKhoan", "{0:n0}");
                xrTableCell230.DataBindings.Add("Text", DataSource, "TongCacKhoanGiamTru", "{0:n0}");
                xrTableCell231.DataBindings.Add("Text", DataSource, "TongLuongThucNhan", "{0:n0}");
                xrTableCell232.DataBindings.Add("Text", DataSource, "LuongTraQuaTaiKhoan", "{0:n0}");
                xrTableCell233.DataBindings.Add("Text", DataSource, "LuongTraTienMat", "{0:n0}");
            }
            //Chữ ký
            if (!string.IsNullOrEmpty(filter.Title1))
                xrLabel13.Text = filter.Title1;
            if (!string.IsNullOrEmpty(filter.Title2))
                xrLabel7.Text = filter.Title2;
            if (!string.IsNullOrEmpty(filter.Title3))
                xrLabel8.Text = filter.Title3;
            // người lập
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
        string resourceFileName = "rp_austfeed_BangTongHopLuongKinhDoanh.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable22 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
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
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable21 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.xrTableCell137 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell138 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell142 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell143 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell144 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell145 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrTable23 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
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
        this.xrTableCell217 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell218 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell219 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell220 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell221 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell222 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell223 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell224 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell225 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell226 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell227 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell228 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell229 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell230 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell231 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell232 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell233 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable20 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable19 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell234 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell235 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell236 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell237 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell238 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable22});
        this.Detail.HeightF = 28.12501F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable22
        // 
        this.xrTable22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable22.Font = new System.Drawing.Font("Times New Roman", 5.5F);
        this.xrTable22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable22.Name = "xrTable22";
        this.xrTable22.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTable22.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow22});
        this.xrTable22.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable22.StylePriority.UseBorders = false;
        this.xrTable22.StylePriority.UseFont = false;
        this.xrTable22.StylePriority.UsePadding = false;
        this.xrTable22.StylePriority.UseTextAlignment = false;
        this.xrTable22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTableRow22
        // 
        this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
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
            this.xrTableCell237,
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
            this.xrTableCell176,
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
            this.xrTableCell190});
        this.xrTableRow22.Name = "xrTableRow22";
        this.xrTableRow22.Weight = 1D;
        // 
        // xrTableCell148
        // 
        this.xrTableCell148.Name = "xrTableCell148";
        this.xrTableCell148.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrTableCell148.StylePriority.UsePadding = false;
        this.xrTableCell148.StylePriority.UseTextAlignment = false;
        this.xrTableCell148.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell148.Weight = 0.040219371453935546D;
        this.xrTableCell148.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrTableCell149
        // 
        this.xrTableCell149.Name = "xrTableCell149";
        this.xrTableCell149.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell149.StylePriority.UsePadding = false;
        this.xrTableCell149.StylePriority.UseTextAlignment = false;
        this.xrTableCell149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell149.Weight = 0.063985374771480807D;
        // 
        // xrTableCell150
        // 
        this.xrTableCell150.Name = "xrTableCell150";
        this.xrTableCell150.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell150.StylePriority.UsePadding = false;
        this.xrTableCell150.StylePriority.UseTextAlignment = false;
        this.xrTableCell150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell150.Weight = 0.12797078441222354D;
        // 
        // xrTableCell151
        // 
        this.xrTableCell151.Name = "xrTableCell151";
        this.xrTableCell151.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell151.StylePriority.UsePadding = false;
        this.xrTableCell151.StylePriority.UseTextAlignment = false;
        this.xrTableCell151.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell151.Weight = 0.072980807511854442D;
        // 
        // xrTableCell152
        // 
        this.xrTableCell152.Name = "xrTableCell152";
        this.xrTableCell152.Weight = 0.080376466405892952D;
        // 
        // xrTableCell153
        // 
        this.xrTableCell153.Name = "xrTableCell153";
        this.xrTableCell153.Weight = 0.035606314538819718D;
        // 
        // xrTableCell154
        // 
        this.xrTableCell154.Name = "xrTableCell154";
        this.xrTableCell154.Weight = 0.071212653486122782D;
        // 
        // xrTableCell155
        // 
        this.xrTableCell155.Name = "xrTableCell155";
        this.xrTableCell155.Weight = 0.037507611611207622D;
        // 
        // xrTableCell156
        // 
        this.xrTableCell156.Name = "xrTableCell156";
        this.xrTableCell156.Weight = 0.0750383175705207D;
        // 
        // xrTableCell157
        // 
        this.xrTableCell157.Name = "xrTableCell157";
        this.xrTableCell157.Weight = 0.051642604894132457D;
        // 
        // xrTableCell158
        // 
        this.xrTableCell158.Name = "xrTableCell158";
        this.xrTableCell158.Weight = 0.051642660467018806D;
        // 
        // xrTableCell159
        // 
        this.xrTableCell159.Name = "xrTableCell159";
        this.xrTableCell159.Weight = 0.051642716148871615D;
        // 
        // xrTableCell160
        // 
        this.xrTableCell160.Name = "xrTableCell160";
        this.xrTableCell160.Weight = 0.051642548776413881D;
        // 
        // xrTableCell161
        // 
        this.xrTableCell161.Name = "xrTableCell161";
        this.xrTableCell161.Weight = 0.051642660684951686D;
        // 
        // xrTableCell162
        // 
        this.xrTableCell162.Name = "xrTableCell162";
        this.xrTableCell162.Weight = 0.063985544759133192D;
        // 
        // xrTableCell163
        // 
        this.xrTableCell163.Name = "xrTableCell163";
        this.xrTableCell163.Weight = 0.063985321595856237D;
        // 
        // xrTableCell164
        // 
        this.xrTableCell164.Name = "xrTableCell164";
        this.xrTableCell164.Weight = 0.063985261446379255D;
        // 
        // xrTableCell165
        // 
        this.xrTableCell165.Name = "xrTableCell165";
        this.xrTableCell165.Weight = 0.070446953695042711D;
        // 
        // xrTableCell166
        // 
        this.xrTableCell166.Name = "xrTableCell166";
        this.xrTableCell166.Weight = 0.073304675832744928D;
        // 
        // xrTableCell167
        // 
        this.xrTableCell167.Name = "xrTableCell167";
        this.xrTableCell167.Weight = 0.070501633492422722D;
        // 
        // xrTableCell168
        // 
        this.xrTableCell168.Name = "xrTableCell168";
        this.xrTableCell168.Weight = 0.071078620837419088D;
        // 
        // xrTableCell169
        // 
        this.xrTableCell169.Name = "xrTableCell169";
        this.xrTableCell169.Weight = 0.077437323669628882D;
        // 
        // xrTableCell170
        // 
        this.xrTableCell170.Name = "xrTableCell170";
        this.xrTableCell170.Weight = 0.075211955598764924D;
        // 
        // xrTableCell171
        // 
        this.xrTableCell171.Name = "xrTableCell171";
        this.xrTableCell171.Weight = 0.059054131481721561D;
        // 
        // xrTableCell172
        // 
        this.xrTableCell172.Name = "xrTableCell172";
        this.xrTableCell172.Weight = 0.063344562729272372D;
        // 
        // xrTableCell173
        // 
        this.xrTableCell173.Name = "xrTableCell173";
        this.xrTableCell173.Weight = 0.082679094300627476D;
        // 
        // xrTableCell174
        // 
        this.xrTableCell174.Name = "xrTableCell174";
        this.xrTableCell174.Weight = 0.079199310630505448D;
        // 
        // xrTableCell175
        // 
        this.xrTableCell175.Name = "xrTableCell175";
        this.xrTableCell175.Weight = 0.06760542048396749D;
        // 
        // xrTableCell176
        // 
        this.xrTableCell176.Name = "xrTableCell176";
        this.xrTableCell176.Weight = 0.067605752613688286D;
        // 
        // xrTableCell177
        // 
        this.xrTableCell177.Name = "xrTableCell177";
        this.xrTableCell177.Weight = 0.067605083123857421D;
        // 
        // xrTableCell178
        // 
        this.xrTableCell178.Name = "xrTableCell178";
        this.xrTableCell178.Weight = 0.067605529450411317D;
        // 
        // xrTableCell179
        // 
        this.xrTableCell179.Name = "xrTableCell179";
        this.xrTableCell179.Weight = 0.05804900844092778D;
        // 
        // xrTableCell180
        // 
        this.xrTableCell180.Name = "xrTableCell180";
        this.xrTableCell180.Weight = 0.080764128913391228D;
        // 
        // xrTableCell181
        // 
        this.xrTableCell181.Name = "xrTableCell181";
        this.xrTableCell181.Weight = 0.069400208523766D;
        // 
        // xrTableCell182
        // 
        this.xrTableCell182.Name = "xrTableCell182";
        this.xrTableCell182.Weight = 0.06632769652650819D;
        // 
        // xrTableCell183
        // 
        this.xrTableCell183.Name = "xrTableCell183";
        this.xrTableCell183.Weight = 0.066327696526508245D;
        // 
        // xrTableCell184
        // 
        this.xrTableCell184.Name = "xrTableCell184";
        this.xrTableCell184.Weight = 0.077737588551188314D;
        // 
        // xrTableCell185
        // 
        this.xrTableCell185.Name = "xrTableCell185";
        this.xrTableCell185.Weight = 0.077724645081124311D;
        // 
        // xrTableCell186
        // 
        this.xrTableCell186.Name = "xrTableCell186";
        this.xrTableCell186.Weight = 0.077724421917847369D;
        // 
        // xrTableCell187
        // 
        this.xrTableCell187.Name = "xrTableCell187";
        this.xrTableCell187.Weight = 0.069599270166819036D;
        // 
        // xrTableCell188
        // 
        this.xrTableCell188.Name = "xrTableCell188";
        this.xrTableCell188.Weight = 0.077641405178816278D;
        // 
        // xrTableCell189
        // 
        this.xrTableCell189.Name = "xrTableCell189";
        this.xrTableCell189.Weight = 0.083485716657621112D;
        // 
        // xrTableCell190
        // 
        this.xrTableCell190.Name = "xrTableCell190";
        this.xrTableCell190.Weight = 0.083485716657621112D;
        // 
        // TopMargin
        // 
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel9,
            this.xrLabel12,
            this.xrLabel10,
            this.xrLabel8,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel7,
            this.xrLabel6});
        this.BottomMargin.HeightF = 179F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1337.5F, 137.5F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(201.0419F, 25F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(650F, 137.5F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(201.0416F, 25F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Văn Thị Xuân";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(1287.5F, 12.5F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(308.3389F, 25F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Hưng Yên, Ngày 12 tháng 12 năm 2014";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(1337.5F, 37.5F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Tổng giám đốc";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(650F, 37.5F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Kế toán trưởng";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(50F, 137.5F);
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
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(50F, 37.5F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Người lập";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 37.5F);
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
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 137.5F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Nguyễn Viết Trung";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.HeightF = 65F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(551.0417F, 25F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(552.0833F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "BẢNG THANH TOÁN TIỀN LƯƠNG THÁNG {0}.{1}";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(551.0417F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(552.0833F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CÔNG TY CỔ PHẦN AUSTFEED VIỆT NAM";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable21});
        this.GroupHeader1.HeightF = 28.12501F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable21
        // 
        this.xrTable21.BackColor = System.Drawing.Color.Silver;
        this.xrTable21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable21.Font = new System.Drawing.Font("Times New Roman", 5.5F, System.Drawing.FontStyle.Bold);
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
            this.xrTableCell105,
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
            this.xrTableCell236,
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
            this.xrTableCell136,
            this.xrTableCell137,
            this.xrTableCell138,
            this.xrTableCell139,
            this.xrTableCell140,
            this.xrTableCell141,
            this.xrTableCell142,
            this.xrTableCell143,
            this.xrTableCell144,
            this.xrTableCell145,
            this.xrTableCell146,
            this.xrTableCell147});
        this.xrTableRow21.Name = "xrTableRow21";
        this.xrTableRow21.Weight = 1D;
        // 
        // xrTableCell105
        // 
        this.xrTableCell105.Name = "xrTableCell105";
        this.xrTableCell105.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrTableCell105.StylePriority.UsePadding = false;
        this.xrTableCell105.StylePriority.UseTextAlignment = false;
        this.xrTableCell105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell105.Weight = 0.040219371453935546D;
        // 
        // xrTableCell107
        // 
        this.xrTableCell107.Name = "xrTableCell107";
        this.xrTableCell107.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell107.StylePriority.UsePadding = false;
        this.xrTableCell107.StylePriority.UseTextAlignment = false;
        this.xrTableCell107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell107.Weight = 0.19195615918370435D;
        // 
        // xrTableCell108
        // 
        this.xrTableCell108.Name = "xrTableCell108";
        this.xrTableCell108.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell108.StylePriority.UsePadding = false;
        this.xrTableCell108.StylePriority.UseTextAlignment = false;
        this.xrTableCell108.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell108.Weight = 0.072980807511854442D;
        // 
        // xrTableCell109
        // 
        this.xrTableCell109.Name = "xrTableCell109";
        this.xrTableCell109.Weight = 0.080376466405892952D;
        // 
        // xrTableCell110
        // 
        this.xrTableCell110.Name = "xrTableCell110";
        this.xrTableCell110.Weight = 0.035606314538819718D;
        // 
        // xrTableCell111
        // 
        this.xrTableCell111.Name = "xrTableCell111";
        this.xrTableCell111.Weight = 0.071212653486122782D;
        // 
        // xrTableCell112
        // 
        this.xrTableCell112.Name = "xrTableCell112";
        this.xrTableCell112.Weight = 0.037507611611207622D;
        // 
        // xrTableCell113
        // 
        this.xrTableCell113.Name = "xrTableCell113";
        this.xrTableCell113.Weight = 0.0750383175705207D;
        // 
        // xrTableCell114
        // 
        this.xrTableCell114.Name = "xrTableCell114";
        this.xrTableCell114.Weight = 0.051642604894132457D;
        // 
        // xrTableCell115
        // 
        this.xrTableCell115.Name = "xrTableCell115";
        this.xrTableCell115.Weight = 0.051642660467018806D;
        // 
        // xrTableCell116
        // 
        this.xrTableCell116.Name = "xrTableCell116";
        this.xrTableCell116.Weight = 0.051642716148871615D;
        // 
        // xrTableCell117
        // 
        this.xrTableCell117.Name = "xrTableCell117";
        this.xrTableCell117.Weight = 0.051642548776413881D;
        // 
        // xrTableCell118
        // 
        this.xrTableCell118.Name = "xrTableCell118";
        this.xrTableCell118.Weight = 0.051642660684951686D;
        // 
        // xrTableCell119
        // 
        this.xrTableCell119.Name = "xrTableCell119";
        this.xrTableCell119.Weight = 0.063985433177494708D;
        // 
        // xrTableCell120
        // 
        this.xrTableCell120.Name = "xrTableCell120";
        this.xrTableCell120.Weight = 0.063985433177494722D;
        // 
        // xrTableCell121
        // 
        this.xrTableCell121.Name = "xrTableCell121";
        this.xrTableCell121.Weight = 0.063985261446379255D;
        // 
        // xrTableCell122
        // 
        this.xrTableCell122.Name = "xrTableCell122";
        this.xrTableCell122.Weight = 0.070447232649138922D;
        // 
        // xrTableCell123
        // 
        this.xrTableCell123.Name = "xrTableCell123";
        this.xrTableCell123.Weight = 0.073304564251106444D;
        // 
        // xrTableCell124
        // 
        this.xrTableCell124.Name = "xrTableCell124";
        this.xrTableCell124.Weight = 0.070501633492422722D;
        // 
        // xrTableCell125
        // 
        this.xrTableCell125.Name = "xrTableCell125";
        this.xrTableCell125.Weight = 0.071078620837419088D;
        // 
        // xrTableCell126
        // 
        this.xrTableCell126.Name = "xrTableCell126";
        this.xrTableCell126.Weight = 0.077437100506351914D;
        // 
        // xrTableCell127
        // 
        this.xrTableCell127.Name = "xrTableCell127";
        this.xrTableCell127.Weight = 0.075212067180403408D;
        // 
        // xrTableCell128
        // 
        this.xrTableCell128.Name = "xrTableCell128";
        this.xrTableCell128.Weight = 0.059054131481721561D;
        // 
        // xrTableCell129
        // 
        this.xrTableCell129.Name = "xrTableCell129";
        this.xrTableCell129.Weight = 0.063344562729272372D;
        // 
        // xrTableCell130
        // 
        this.xrTableCell130.Name = "xrTableCell130";
        this.xrTableCell130.Weight = 0.082679094300627476D;
        // 
        // xrTableCell131
        // 
        this.xrTableCell131.Name = "xrTableCell131";
        this.xrTableCell131.Weight = 0.079199310630505448D;
        // 
        // xrTableCell132
        // 
        this.xrTableCell132.Name = "xrTableCell132";
        this.xrTableCell132.Weight = 0.06760542048396749D;
        // 
        // xrTableCell133
        // 
        this.xrTableCell133.Name = "xrTableCell133";
        this.xrTableCell133.Weight = 0.067605752613688286D;
        // 
        // xrTableCell134
        // 
        this.xrTableCell134.Name = "xrTableCell134";
        this.xrTableCell134.Weight = 0.067605083123857421D;
        // 
        // xrTableCell135
        // 
        this.xrTableCell135.Name = "xrTableCell135";
        this.xrTableCell135.Weight = 0.067605529450411317D;
        // 
        // xrTableCell136
        // 
        this.xrTableCell136.Name = "xrTableCell136";
        this.xrTableCell136.Weight = 0.05804900844092778D;
        // 
        // xrTableCell137
        // 
        this.xrTableCell137.Name = "xrTableCell137";
        this.xrTableCell137.Weight = 0.080764128913391228D;
        // 
        // xrTableCell138
        // 
        this.xrTableCell138.Name = "xrTableCell138";
        this.xrTableCell138.Weight = 0.069400208523766D;
        // 
        // xrTableCell139
        // 
        this.xrTableCell139.Name = "xrTableCell139";
        this.xrTableCell139.Weight = 0.06632769652650819D;
        // 
        // xrTableCell140
        // 
        this.xrTableCell140.Name = "xrTableCell140";
        this.xrTableCell140.Weight = 0.066327696526508245D;
        // 
        // xrTableCell141
        // 
        this.xrTableCell141.Name = "xrTableCell141";
        this.xrTableCell141.Weight = 0.077737588551188314D;
        // 
        // xrTableCell142
        // 
        this.xrTableCell142.Name = "xrTableCell142";
        this.xrTableCell142.Weight = 0.077724645081124311D;
        // 
        // xrTableCell143
        // 
        this.xrTableCell143.Name = "xrTableCell143";
        this.xrTableCell143.Weight = 0.077724421917847369D;
        // 
        // xrTableCell144
        // 
        this.xrTableCell144.Name = "xrTableCell144";
        this.xrTableCell144.Weight = 0.069599270166819036D;
        // 
        // xrTableCell145
        // 
        this.xrTableCell145.Name = "xrTableCell145";
        this.xrTableCell145.Weight = 0.077641405178816278D;
        // 
        // xrTableCell146
        // 
        this.xrTableCell146.Name = "xrTableCell146";
        this.xrTableCell146.Weight = 0.083485716657621112D;
        // 
        // xrTableCell147
        // 
        this.xrTableCell147.Name = "xrTableCell147";
        this.xrTableCell147.Weight = 0.083485716657621112D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable23});
        this.ReportFooter.HeightF = 28.12501F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrTable23
        // 
        this.xrTable23.BackColor = System.Drawing.Color.Silver;
        this.xrTable23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable23.Font = new System.Drawing.Font("Times New Roman", 5.5F, System.Drawing.FontStyle.Bold);
        this.xrTable23.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable23.Name = "xrTable23";
        this.xrTable23.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
        this.xrTable23.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow23});
        this.xrTable23.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable23.StylePriority.UseBackColor = false;
        this.xrTable23.StylePriority.UseBorders = false;
        this.xrTable23.StylePriority.UseFont = false;
        this.xrTable23.StylePriority.UsePadding = false;
        this.xrTable23.StylePriority.UseTextAlignment = false;
        this.xrTable23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTableRow23
        // 
        this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
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
            this.xrTableCell238,
            this.xrTableCell208,
            this.xrTableCell209,
            this.xrTableCell210,
            this.xrTableCell211,
            this.xrTableCell212,
            this.xrTableCell213,
            this.xrTableCell214,
            this.xrTableCell215,
            this.xrTableCell216,
            this.xrTableCell217,
            this.xrTableCell218,
            this.xrTableCell219,
            this.xrTableCell220,
            this.xrTableCell221,
            this.xrTableCell222,
            this.xrTableCell223,
            this.xrTableCell224,
            this.xrTableCell225,
            this.xrTableCell226,
            this.xrTableCell227,
            this.xrTableCell228,
            this.xrTableCell229,
            this.xrTableCell230,
            this.xrTableCell231,
            this.xrTableCell232,
            this.xrTableCell233});
        this.xrTableRow23.Name = "xrTableRow23";
        this.xrTableRow23.Weight = 1D;
        // 
        // xrTableCell191
        // 
        this.xrTableCell191.Name = "xrTableCell191";
        this.xrTableCell191.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrTableCell191.StylePriority.UsePadding = false;
        this.xrTableCell191.StylePriority.UseTextAlignment = false;
        this.xrTableCell191.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell191.Weight = 0.040219371453935546D;
        // 
        // xrTableCell192
        // 
        this.xrTableCell192.Name = "xrTableCell192";
        this.xrTableCell192.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell192.StylePriority.UsePadding = false;
        this.xrTableCell192.StylePriority.UseTextAlignment = false;
        this.xrTableCell192.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell192.Weight = 0.063985374771480807D;
        // 
        // xrTableCell193
        // 
        this.xrTableCell193.Name = "xrTableCell193";
        this.xrTableCell193.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell193.StylePriority.UsePadding = false;
        this.xrTableCell193.StylePriority.UseTextAlignment = false;
        this.xrTableCell193.Text = "Tổng cộng:";
        this.xrTableCell193.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell193.Weight = 0.12797078441222354D;
        // 
        // xrTableCell194
        // 
        this.xrTableCell194.Name = "xrTableCell194";
        this.xrTableCell194.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
        this.xrTableCell194.StylePriority.UsePadding = false;
        this.xrTableCell194.StylePriority.UseTextAlignment = false;
        this.xrTableCell194.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell194.Weight = 0.072980807511854442D;
        // 
        // xrTableCell195
        // 
        this.xrTableCell195.Name = "xrTableCell195";
        this.xrTableCell195.Weight = 0.080376466405892952D;
        // 
        // xrTableCell196
        // 
        this.xrTableCell196.Name = "xrTableCell196";
        this.xrTableCell196.Weight = 0.035606314538819718D;
        // 
        // xrTableCell197
        // 
        this.xrTableCell197.Name = "xrTableCell197";
        this.xrTableCell197.Weight = 0.071212653486122782D;
        // 
        // xrTableCell198
        // 
        this.xrTableCell198.Name = "xrTableCell198";
        this.xrTableCell198.Weight = 0.037507611611207622D;
        // 
        // xrTableCell199
        // 
        this.xrTableCell199.Name = "xrTableCell199";
        this.xrTableCell199.Weight = 0.0750383175705207D;
        // 
        // xrTableCell200
        // 
        this.xrTableCell200.Name = "xrTableCell200";
        this.xrTableCell200.Weight = 0.051642604894132457D;
        // 
        // xrTableCell201
        // 
        this.xrTableCell201.Name = "xrTableCell201";
        this.xrTableCell201.Weight = 0.051642660467018806D;
        // 
        // xrTableCell202
        // 
        this.xrTableCell202.Name = "xrTableCell202";
        this.xrTableCell202.Weight = 0.051642716148871615D;
        // 
        // xrTableCell203
        // 
        this.xrTableCell203.Name = "xrTableCell203";
        this.xrTableCell203.Weight = 0.051642548776413881D;
        // 
        // xrTableCell204
        // 
        this.xrTableCell204.Name = "xrTableCell204";
        this.xrTableCell204.Weight = 0.051642660684951686D;
        // 
        // xrTableCell205
        // 
        this.xrTableCell205.Name = "xrTableCell205";
        this.xrTableCell205.Weight = 0.063985600549952421D;
        // 
        // xrTableCell206
        // 
        this.xrTableCell206.Name = "xrTableCell206";
        this.xrTableCell206.Weight = 0.063985210014217753D;
        // 
        // xrTableCell207
        // 
        this.xrTableCell207.Name = "xrTableCell207";
        this.xrTableCell207.Weight = 0.063985149864740756D;
        // 
        // xrTableCell208
        // 
        this.xrTableCell208.Name = "xrTableCell208";
        this.xrTableCell208.Weight = 0.070447065276681181D;
        // 
        // xrTableCell209
        // 
        this.xrTableCell209.Name = "xrTableCell209";
        this.xrTableCell209.Weight = 0.073304564251106444D;
        // 
        // xrTableCell210
        // 
        this.xrTableCell210.Name = "xrTableCell210";
        this.xrTableCell210.Weight = 0.070501633492422722D;
        // 
        // xrTableCell211
        // 
        this.xrTableCell211.Name = "xrTableCell211";
        this.xrTableCell211.Weight = 0.071078620837419088D;
        // 
        // xrTableCell212
        // 
        this.xrTableCell212.Name = "xrTableCell212";
        this.xrTableCell212.Weight = 0.077437323669628882D;
        // 
        // xrTableCell213
        // 
        this.xrTableCell213.Name = "xrTableCell213";
        this.xrTableCell213.Weight = 0.075211955598764924D;
        // 
        // xrTableCell214
        // 
        this.xrTableCell214.Name = "xrTableCell214";
        this.xrTableCell214.Weight = 0.059054131481721561D;
        // 
        // xrTableCell215
        // 
        this.xrTableCell215.Name = "xrTableCell215";
        this.xrTableCell215.Weight = 0.063344562729272372D;
        // 
        // xrTableCell216
        // 
        this.xrTableCell216.Name = "xrTableCell216";
        this.xrTableCell216.Weight = 0.082679094300627476D;
        // 
        // xrTableCell217
        // 
        this.xrTableCell217.Name = "xrTableCell217";
        this.xrTableCell217.Weight = 0.079199310630505448D;
        // 
        // xrTableCell218
        // 
        this.xrTableCell218.Name = "xrTableCell218";
        this.xrTableCell218.Weight = 0.06760542048396749D;
        // 
        // xrTableCell219
        // 
        this.xrTableCell219.Name = "xrTableCell219";
        this.xrTableCell219.Weight = 0.067605752613688286D;
        // 
        // xrTableCell220
        // 
        this.xrTableCell220.Name = "xrTableCell220";
        this.xrTableCell220.Weight = 0.067605083123857421D;
        // 
        // xrTableCell221
        // 
        this.xrTableCell221.Name = "xrTableCell221";
        this.xrTableCell221.Weight = 0.067605529450411317D;
        // 
        // xrTableCell222
        // 
        this.xrTableCell222.Name = "xrTableCell222";
        this.xrTableCell222.Weight = 0.05804900844092778D;
        // 
        // xrTableCell223
        // 
        this.xrTableCell223.Name = "xrTableCell223";
        this.xrTableCell223.Weight = 0.080764128913391228D;
        // 
        // xrTableCell224
        // 
        this.xrTableCell224.Name = "xrTableCell224";
        this.xrTableCell224.Weight = 0.069400208523766D;
        // 
        // xrTableCell225
        // 
        this.xrTableCell225.Name = "xrTableCell225";
        this.xrTableCell225.Weight = 0.06632769652650819D;
        // 
        // xrTableCell226
        // 
        this.xrTableCell226.Name = "xrTableCell226";
        this.xrTableCell226.Weight = 0.066327696526508245D;
        // 
        // xrTableCell227
        // 
        this.xrTableCell227.Name = "xrTableCell227";
        this.xrTableCell227.Weight = 0.077737588551188314D;
        // 
        // xrTableCell228
        // 
        this.xrTableCell228.Name = "xrTableCell228";
        this.xrTableCell228.Weight = 0.077724645081124311D;
        // 
        // xrTableCell229
        // 
        this.xrTableCell229.Name = "xrTableCell229";
        this.xrTableCell229.Weight = 0.077724421917847369D;
        // 
        // xrTableCell230
        // 
        this.xrTableCell230.Name = "xrTableCell230";
        this.xrTableCell230.Weight = 0.069599270166819036D;
        // 
        // xrTableCell231
        // 
        this.xrTableCell231.Name = "xrTableCell231";
        this.xrTableCell231.Weight = 0.077641405178816278D;
        // 
        // xrTableCell232
        // 
        this.xrTableCell232.Name = "xrTableCell232";
        this.xrTableCell232.Weight = 0.083485716657621112D;
        // 
        // xrTableCell233
        // 
        this.xrTableCell233.Name = "xrTableCell233";
        this.xrTableCell233.Weight = 0.083485716657621112D;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable20,
            this.xrTable1});
        this.PageHeader.HeightF = 148.3333F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable20
        // 
        this.xrTable20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable20.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
        this.xrTable20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 120.2083F);
        this.xrTable20.Name = "xrTable20";
        this.xrTable20.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
        this.xrTable20.SizeF = new System.Drawing.SizeF(1641F, 28.12501F);
        this.xrTable20.StylePriority.UseBorders = false;
        this.xrTable20.StylePriority.UseFont = false;
        this.xrTable20.StylePriority.UseTextAlignment = false;
        this.xrTable20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow20
        // 
        this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell60,
            this.xrTableCell63,
            this.xrTableCell64,
            this.xrTableCell65,
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell68,
            this.xrTableCell69,
            this.xrTableCell70,
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell75,
            this.xrTableCell76,
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell81,
            this.xrTableCell235,
            this.xrTableCell82,
            this.xrTableCell83,
            this.xrTableCell84,
            this.xrTableCell85,
            this.xrTableCell86,
            this.xrTableCell87,
            this.xrTableCell88,
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrTableCell91,
            this.xrTableCell92,
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell95,
            this.xrTableCell96,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99,
            this.xrTableCell100,
            this.xrTableCell102,
            this.xrTableCell103,
            this.xrTableCell104,
            this.xrTableCell101});
        this.xrTableRow20.Name = "xrTableRow20";
        this.xrTableRow20.Weight = 1D;
        // 
        // xrTableCell60
        // 
        this.xrTableCell60.Name = "xrTableCell60";
        this.xrTableCell60.Text = "1";
        this.xrTableCell60.Weight = 0.040219371453935546D;
        // 
        // xrTableCell63
        // 
        this.xrTableCell63.Name = "xrTableCell63";
        this.xrTableCell63.Text = "2";
        this.xrTableCell63.Weight = 0.063985374771480807D;
        // 
        // xrTableCell64
        // 
        this.xrTableCell64.Name = "xrTableCell64";
        this.xrTableCell64.Text = "3";
        this.xrTableCell64.Weight = 0.12797078441222354D;
        // 
        // xrTableCell65
        // 
        this.xrTableCell65.Name = "xrTableCell65";
        this.xrTableCell65.Text = "10";
        this.xrTableCell65.Weight = 0.072980807511854442D;
        // 
        // xrTableCell66
        // 
        this.xrTableCell66.Name = "xrTableCell66";
        this.xrTableCell66.Text = "11";
        this.xrTableCell66.Weight = 0.080376466405892952D;
        // 
        // xrTableCell67
        // 
        this.xrTableCell67.Name = "xrTableCell67";
        this.xrTableCell67.Text = "16";
        this.xrTableCell67.Weight = 0.035606314538819718D;
        // 
        // xrTableCell68
        // 
        this.xrTableCell68.Name = "xrTableCell68";
        this.xrTableCell68.Text = "17";
        this.xrTableCell68.Weight = 0.071212653486122782D;
        // 
        // xrTableCell69
        // 
        this.xrTableCell69.Name = "xrTableCell69";
        this.xrTableCell69.Text = "18";
        this.xrTableCell69.Weight = 0.037507611611207622D;
        // 
        // xrTableCell70
        // 
        this.xrTableCell70.Name = "xrTableCell70";
        this.xrTableCell70.Text = "19";
        this.xrTableCell70.Weight = 0.0750383175705207D;
        // 
        // xrTableCell71
        // 
        this.xrTableCell71.Name = "xrTableCell71";
        this.xrTableCell71.Text = "20";
        this.xrTableCell71.Weight = 0.051642604894132457D;
        // 
        // xrTableCell72
        // 
        this.xrTableCell72.Name = "xrTableCell72";
        this.xrTableCell72.Text = "21";
        this.xrTableCell72.Weight = 0.051642660467018806D;
        // 
        // xrTableCell73
        // 
        this.xrTableCell73.Name = "xrTableCell73";
        this.xrTableCell73.Text = "22";
        this.xrTableCell73.Weight = 0.051642716148871615D;
        // 
        // xrTableCell74
        // 
        this.xrTableCell74.Name = "xrTableCell74";
        this.xrTableCell74.Text = "23";
        this.xrTableCell74.Weight = 0.051642548776413881D;
        // 
        // xrTableCell75
        // 
        this.xrTableCell75.Name = "xrTableCell75";
        this.xrTableCell75.Text = "24";
        this.xrTableCell75.Weight = 0.051642660684951686D;
        // 
        // xrTableCell76
        // 
        this.xrTableCell76.Name = "xrTableCell76";
        this.xrTableCell76.Text = "25";
        this.xrTableCell76.Weight = 0.063985488968313936D;
        // 
        // xrTableCell77
        // 
        this.xrTableCell77.Name = "xrTableCell77";
        this.xrTableCell77.Text = "26";
        this.xrTableCell77.Weight = 0.063985321595856223D;
        // 
        // xrTableCell78
        // 
        this.xrTableCell78.Name = "xrTableCell78";
        this.xrTableCell78.Text = "42";
        this.xrTableCell78.Weight = 0.063985149864740756D;
        // 
        // xrTableCell79
        // 
        this.xrTableCell79.Name = "xrTableCell79";
        this.xrTableCell79.Text = "56";
        this.xrTableCell79.Weight = 0.0639857121315909D;
        // 
        // xrTableCell80
        // 
        this.xrTableCell80.Name = "xrTableCell80";
        this.xrTableCell80.Text = "58";
        this.xrTableCell80.Weight = 0.070446958489566225D;
        // 
        // xrTableCell81
        // 
        this.xrTableCell81.Name = "xrTableCell81";
        this.xrTableCell81.Text = "59";
        this.xrTableCell81.Weight = 0.073304564251106444D;
        // 
        // xrTableCell82
        // 
        this.xrTableCell82.Name = "xrTableCell82";
        this.xrTableCell82.Text = "60";
        this.xrTableCell82.Weight = 0.071078620183620433D;
        // 
        // xrTableCell83
        // 
        this.xrTableCell83.Name = "xrTableCell83";
        this.xrTableCell83.Text = "61";
        this.xrTableCell83.Weight = 0.077437323669628882D;
        // 
        // xrTableCell84
        // 
        this.xrTableCell84.Name = "xrTableCell84";
        this.xrTableCell84.Text = "62";
        this.xrTableCell84.Weight = 0.075211955598764924D;
        // 
        // xrTableCell85
        // 
        this.xrTableCell85.Name = "xrTableCell85";
        this.xrTableCell85.Text = "64";
        this.xrTableCell85.Weight = 0.059054131481721561D;
        // 
        // xrTableCell86
        // 
        this.xrTableCell86.Name = "xrTableCell86";
        this.xrTableCell86.Text = "65";
        this.xrTableCell86.Weight = 0.063344562729272372D;
        // 
        // xrTableCell87
        // 
        this.xrTableCell87.Name = "xrTableCell87";
        this.xrTableCell87.Text = "66";
        this.xrTableCell87.Weight = 0.082679094300627476D;
        // 
        // xrTableCell88
        // 
        this.xrTableCell88.Name = "xrTableCell88";
        this.xrTableCell88.Text = "67";
        this.xrTableCell88.Weight = 0.079199310630505448D;
        // 
        // xrTableCell89
        // 
        this.xrTableCell89.Name = "xrTableCell89";
        this.xrTableCell89.Text = "68";
        this.xrTableCell89.Weight = 0.06760542048396749D;
        // 
        // xrTableCell90
        // 
        this.xrTableCell90.Name = "xrTableCell90";
        this.xrTableCell90.Text = "70";
        this.xrTableCell90.Weight = 0.067605752613688286D;
        // 
        // xrTableCell91
        // 
        this.xrTableCell91.Name = "xrTableCell91";
        this.xrTableCell91.Text = "71";
        this.xrTableCell91.Weight = 0.067605083123857421D;
        // 
        // xrTableCell92
        // 
        this.xrTableCell92.Name = "xrTableCell92";
        this.xrTableCell92.Text = "72";
        this.xrTableCell92.Weight = 0.067605529450411317D;
        // 
        // xrTableCell93
        // 
        this.xrTableCell93.Name = "xrTableCell93";
        this.xrTableCell93.Text = "73";
        this.xrTableCell93.Weight = 0.05804900844092778D;
        // 
        // xrTableCell94
        // 
        this.xrTableCell94.Name = "xrTableCell94";
        this.xrTableCell94.Text = "74";
        this.xrTableCell94.Weight = 0.080764128913391228D;
        // 
        // xrTableCell95
        // 
        this.xrTableCell95.Name = "xrTableCell95";
        this.xrTableCell95.Text = "75";
        this.xrTableCell95.Weight = 0.069400208523766D;
        // 
        // xrTableCell96
        // 
        this.xrTableCell96.Name = "xrTableCell96";
        this.xrTableCell96.Text = "76";
        this.xrTableCell96.Weight = 0.06632769652650819D;
        // 
        // xrTableCell97
        // 
        this.xrTableCell97.Name = "xrTableCell97";
        this.xrTableCell97.Text = "77";
        this.xrTableCell97.Weight = 0.066327696526508245D;
        // 
        // xrTableCell98
        // 
        this.xrTableCell98.Name = "xrTableCell98";
        this.xrTableCell98.Text = "78";
        this.xrTableCell98.Weight = 0.077737588551188314D;
        // 
        // xrTableCell99
        // 
        this.xrTableCell99.Name = "xrTableCell99";
        this.xrTableCell99.Text = "79";
        this.xrTableCell99.Weight = 0.077724645081124311D;
        // 
        // xrTableCell100
        // 
        this.xrTableCell100.Name = "xrTableCell100";
        this.xrTableCell100.Text = "80";
        this.xrTableCell100.Weight = 0.077724421917847369D;
        // 
        // xrTableCell102
        // 
        this.xrTableCell102.Name = "xrTableCell102";
        this.xrTableCell102.Weight = 0.069599270166819036D;
        // 
        // xrTableCell103
        // 
        this.xrTableCell103.Name = "xrTableCell103";
        this.xrTableCell103.Weight = 0.077641405178816278D;
        // 
        // xrTableCell104
        // 
        this.xrTableCell104.Name = "xrTableCell104";
        this.xrTableCell104.Weight = 0.083485716657621112D;
        // 
        // xrTableCell101
        // 
        this.xrTableCell101.Name = "xrTableCell101";
        this.xrTableCell101.Text = "81";
        this.xrTableCell101.Weight = 0.083485716657621112D;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(1641F, 120.2083F);
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
            this.xrTableCell4,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell18,
            this.xrTableCell2,
            this.xrTableCell58,
            this.xrTableCell57,
            this.xrTableCell62,
            this.xrTableCell40,
            this.xrTableCell59,
            this.xrTableCell61,
            this.xrTableCell1});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "STT";
        this.xrTableCell5.Weight = 0.21999999999999978D;
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
        this.xrTableCell7.Weight = 0.700000019073486D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Chức vụ";
        this.xrTableCell4.Weight = 0.39920531988143915D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "Lương cơ bản";
        this.xrTableCell8.Weight = 0.43958373904228187D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10,
            this.xrTable11});
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Weight = 0.58437530457973474D;
        // 
        // xrTable10
        // 
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0.007534027F, 0F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable10.SizeF = new System.Drawing.SizeF(58.43F, 23.95833F);
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.Text = "Lương tháng";
        this.xrTableCell32.Weight = 3D;
        // 
        // xrTable11
        // 
        this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(0.007537842F, 23.95833F);
        this.xrTable11.Name = "xrTable11";
        this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
        this.xrTable11.SizeF = new System.Drawing.SizeF(58.42999F, 96.24999F);
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell35});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.StylePriority.UseBorders = false;
        this.xrTableCell33.Text = "Ngày công thường";
        this.xrTableCell33.Weight = 1D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.Text = "Lương trong tháng";
        this.xrTableCell35.Weight = 2D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable12,
            this.xrTable13});
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Weight = 0.615625610053539D;
        // 
        // xrTable12
        // 
        this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable12.Name = "xrTable12";
        this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12});
        this.xrTable12.SizeF = new System.Drawing.SizeF(61.54999F, 23.95834F);
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell34});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.StylePriority.UseBorders = false;
        this.xrTableCell34.Text = "Phép";
        this.xrTableCell34.Weight = 3D;
        // 
        // xrTable13
        // 
        this.xrTable13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.95833F);
        this.xrTable13.Name = "xrTable13";
        this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
        this.xrTable13.SizeF = new System.Drawing.SizeF(61.54999F, 95.41667F);
        this.xrTable13.StylePriority.UseBorders = false;
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36,
            this.xrTableCell38});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.Text = "Số ngày";
        this.xrTableCell36.Weight = 1D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.Text = "Thành tiền";
        this.xrTableCell38.Weight = 2D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable3});
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Weight = 5.2081835912168017D;
        // 
        // xrTable2
        // 
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.95833F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(520.8182F, 96.24999F);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell3,
            this.xrTableCell14,
            this.xrTableCell17,
            this.xrTableCell16,
            this.xrTableCell11,
            this.xrTableCell15,
            this.xrTableCell20,
            this.xrTableCell234,
            this.xrTableCell12});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.Text = "PC Tiền ăn";
        this.xrTableCell13.Weight = 0.16271628136092148D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "PC điện thoại";
        this.xrTableCell3.Weight = 0.16271628136092153D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = "PC nhà ở";
        this.xrTableCell14.Weight = 0.16271628136092137D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Text = "Thưởng SP chiến lược";
        this.xrTableCell17.Weight = 0.16271628136092151D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Text = "Thưởng SP khuyến khích";
        this.xrTableCell16.Weight = 0.16271628136092148D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5,
            this.xrTable4});
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Weight = 0.80642350930590889D;
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(140F, 25F);
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell24});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseBorders = false;
        this.xrTableCell24.Text = "Thưởng/ phạt Target, tăng trưởng tháng";
        this.xrTableCell24.Weight = 2.3342692984501876D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(140F, 71.25F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell22,
            this.xrTableCell25,
            this.xrTableCell21});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.Text = "Thưởng Target";
        this.xrTableCell23.Weight = 0.58333333333333337D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Text = "Phạt Target";
        this.xrTableCell22.Weight = 0.58333333333333326D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Text = "Thưởng tăng trưởng";
        this.xrTableCell25.Weight = 0.58333333333333326D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Text = "Phạt tăng trưởng";
        this.xrTableCell21.Weight = 0.58333333333333337D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7});
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Weight = 0.45102113402325567D;
        // 
        // xrTable6
        // 
        this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0.09752909F, 0F);
        this.xrTable6.Name = "xrTable6";
        this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
        this.xrTable6.SizeF = new System.Drawing.SizeF(78.3F, 25F);
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Borders = DevExpress.XtraPrinting.BorderSide.Top;
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseBorders = false;
        this.xrTableCell27.Text = "Thưởng/ phạt tăng trưởng quý";
        this.xrTableCell27.Weight = 2.4020421008473027D;
        // 
        // xrTable7
        // 
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable7.SizeF = new System.Drawing.SizeF(78.29999F, 71.25F);
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28,
            this.xrTableCell26});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.Text = "Thưởng tăng trưởng";
        this.xrTableCell28.Weight = 1.4764196132568692D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.Text = "Phạt tăng trưởng";
        this.xrTableCell26.Weight = 1.5235803867431308D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8,
            this.xrTable9});
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Weight = 0.44800628840498619D;
        // 
        // xrTable8
        // 
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0.006561279F, 0F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
        this.xrTable8.SizeF = new System.Drawing.SizeF(77.77002F, 24.99999F);
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell29});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.StylePriority.UseBorders = false;
        this.xrTableCell29.Text = "Thưởng đại lý";
        this.xrTableCell29.Weight = 2.3333999633789064D;
        // 
        // xrTable9
        // 
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0.01657104F, 25F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable9.SizeF = new System.Drawing.SizeF(77.76001F, 71.24998F);
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell31,
            this.xrTableCell30});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.StylePriority.UseBorders = false;
        this.xrTableCell31.Text = "Đại lý mới";
        this.xrTableCell31.Weight = 1.5D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.Text = "Đại lý đạt sản lượng";
        this.xrTableCell30.Weight = 1.5D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "Tổng phụ cấp";
        this.xrTableCell12.Weight = 0.2369772333218291D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0.01840591F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(520.8F, 23.95833F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.Text = "Chế độ kinh doanh";
        this.xrTableCell19.Weight = 12.499199707031252D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Tiền hỗ trợ";
        this.xrTableCell2.Weight = 0.32302642568945905D;
        // 
        // xrTableCell58
        // 
        this.xrTableCell58.Name = "xrTableCell58";
        this.xrTableCell58.Text = "Tiền bù";
        this.xrTableCell58.Weight = 0.346495360136032D;
        // 
        // xrTableCell57
        // 
        this.xrTableCell57.Name = "xrTableCell57";
        this.xrTableCell57.Text = "Tổng thu nhập";
        this.xrTableCell57.Weight = 0.45225402712821927D;
        // 
        // xrTableCell62
        // 
        this.xrTableCell62.Name = "xrTableCell62";
        this.xrTableCell62.Text = "Tiền ăn ca";
        this.xrTableCell62.Weight = 0.43321960330009468D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable19,
            this.xrTable14});
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.Text = "xrTableCell40";
        this.xrTableCell40.Weight = 5.0000012195110308D;
        // 
        // xrTable19
        // 
        this.xrTable19.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 0F);
        this.xrTable19.Name = "xrTable19";
        this.xrTable19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19});
        this.xrTable19.SizeF = new System.Drawing.SizeF(500F, 25F);
        // 
        // xrTableRow19
        // 
        this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell39});
        this.xrTableRow19.Name = "xrTableRow19";
        this.xrTableRow19.Weight = 1D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseBorders = false;
        this.xrTableCell39.Text = "Các khoản giảm trừ";
        this.xrTableCell39.Weight = 5.4000010762119492D;
        // 
        // xrTable14
        // 
        this.xrTable14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrTable14.Name = "xrTable14";
        this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
        this.xrTable14.SizeF = new System.Drawing.SizeF(500F, 94.37501F);
        this.xrTable14.StylePriority.UseBorders = false;
        // 
        // xrTableRow14
        // 
        this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell37,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell41,
            this.xrTableCell48,
            this.xrTableCell42});
        this.xrTableRow14.Name = "xrTableRow14";
        this.xrTableRow14.Weight = 1D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
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
        this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell45.Name = "xrTableCell45";
        this.xrTableCell45.StylePriority.UseBorders = false;
        this.xrTableCell45.Text = "BHTN 1%";
        this.xrTableCell45.Weight = 0.22188117561541587D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable15,
            this.xrTable16});
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.Text = " ";
        this.xrTableCell46.Weight = 0.68335718515343546D;
        // 
        // xrTable15
        // 
        this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0.006835938F, 0F);
        this.xrTable15.Name = "xrTable15";
        this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
        this.xrTable15.SizeF = new System.Drawing.SizeF(113.886F, 25F);
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrTableCell49
        // 
        this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell49.Name = "xrTableCell49";
        this.xrTableCell49.StylePriority.UseBorders = false;
        this.xrTableCell49.Text = "Thu nhập chịu thuế";
        this.xrTableCell49.Weight = 1.2555999755859375D;
        // 
        // xrTable16
        // 
        this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0.006835938F, 25F);
        this.xrTable16.Name = "xrTable16";
        this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
        this.xrTable16.SizeF = new System.Drawing.SizeF(113.886F, 69.37501F);
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrTableCell50
        // 
        this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
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
            this.xrTable17,
            this.xrTable18});
        this.xrTableCell48.Name = "xrTableCell48";
        this.xrTableCell48.Text = " ";
        this.xrTableCell48.Weight = 0.76531766766053821D;
        // 
        // xrTable17
        // 
        this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(0.007202148F, 0F);
        this.xrTable17.Name = "xrTable17";
        this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
        this.xrTable17.SizeF = new System.Drawing.SizeF(127.5459F, 24.99999F);
        // 
        // xrTableRow17
        // 
        this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53});
        this.xrTableRow17.Name = "xrTableRow17";
        this.xrTableRow17.Weight = 1D;
        // 
        // xrTableCell53
        // 
        this.xrTableCell53.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell53.Name = "xrTableCell53";
        this.xrTableCell53.StylePriority.UseBorders = false;
        this.xrTableCell53.Text = "Tiền tạm ứng";
        this.xrTableCell53.Weight = 4.764538494732764D;
        // 
        // xrTable18
        // 
        this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(0.007324219F, 25F);
        this.xrTable18.Name = "xrTable18";
        this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
        this.xrTable18.SizeF = new System.Drawing.SizeF(127.5457F, 69.37501F);
        // 
        // xrTableRow18
        // 
        this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56});
        this.xrTableRow18.Name = "xrTableRow18";
        this.xrTableRow18.Weight = 1D;
        // 
        // xrTableCell54
        // 
        this.xrTableCell54.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
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
        // xrTableCell59
        // 
        this.xrTableCell59.Name = "xrTableCell59";
        this.xrTableCell59.Text = "Tổng lương thực nhận";
        this.xrTableCell59.Weight = 0.4246972632408148D;
        // 
        // xrTableCell61
        // 
        this.xrTableCell61.Name = "xrTableCell61";
        this.xrTableCell61.Text = "Lương trả qua tài khoản";
        this.xrTableCell61.Weight = 0.45666625857353216D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "Lương trả tiền mặt";
        this.xrTableCell1.Weight = 0.45666625857353205D;
        // 
        // xrTableCell234
        // 
        this.xrTableCell234.Name = "xrTableCell234";
        this.xrTableCell234.Text = "Thưởng/ phạt chỉ tiêu";
        this.xrTableCell234.Weight = 0.24399042813941266D;
        // 
        // xrTableCell235
        // 
        this.xrTableCell235.Name = "xrTableCell235";
        this.xrTableCell235.Weight = 0.070501624557174333D;
        // 
        // xrTableCell236
        // 
        this.xrTableCell236.Name = "xrTableCell236";
        this.xrTableCell236.Weight = 0.063985372592151937D;
        // 
        // xrTableCell237
        // 
        this.xrTableCell237.Name = "xrTableCell237";
        this.xrTableCell237.Weight = 0.063985428382971166D;
        // 
        // xrTableCell238
        // 
        this.xrTableCell238.Name = "xrTableCell238";
        this.xrTableCell238.Weight = 0.0639855957554289D;
        // 
        // rp_austfeed_BangTongHopLuongKinhDoanh
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.ReportFooter,
            this.PageHeader});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(7, 6, 100, 179);
        this.PageHeight = 1169;
        this.PageWidth = 1654;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
