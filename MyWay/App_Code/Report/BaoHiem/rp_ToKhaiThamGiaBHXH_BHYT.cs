using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraPrinting;

/// <summary>
/// Summary description for rp_ToKhaiThamGiaBHXH_BHYT
/// </summary>
public class rp_ToKhaiThamGiaBHXH_BHYT : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private XRPictureBox xrt_anhthe;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRCheckBox chknam;
    private XRCheckBox chknu;
    private XRLabel xrLabel9;
    private XRLabel xrlhokhauthuongtru;
    private XRLabel xrl_dtcodinh;
    private XRLabel xrlchungminhso;
    private XRLabel xrLabel14;
    private XRLabel xrlsoloaihopdong;
    private XRLabel xrldiachi;
    private XRLabel xrlchucdanh;
    private XRLabel xrl_luongchinh;
    private XRLabel xrLabel20;
    private XRLabel xrlmasobaohiemxh;
    private XRLabel xrlsothebhyt;
    private XRLabel xrlnoidangky;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel32;
    private XRLabel xrl_hoten;
    private XRLabel xrLabel39;
    private XRTable xrTable2;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell7;
    private XRLabel xrLabel38;
    private XRTableCell xrldantoc;
    private XRLabel xrlQuoctich;
    private XRLabel xrldidong;
    private XRLabel xrlngaycap;
    private XRLabel xrl_noicap;
    private XRLabel xrlngayloaihopdong;
    private XRLabel xrlhieulucngay;
    private XRLabel xrlloaihopdong;
    private XRLabel xrlpccv1;
    private XRLabel xrltnn1;
    private XRLabel xrltnvk1;
    private XRLabel xrlkhac1;
    private XRLabel xrl_luongchinh1;
    private XRLabel xrlpccv;
    private XRLabel xrltnn;
    private XRLabel xrltnvk;
    private XRLabel xrlkhac;
    private XRTable xrTable28;
    private XRTableRow xrTableRow38;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell84;
    private XRTable xrTable31;
    private XRTableRow xrTableRow43;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTable xrTable32;
    private XRTableRow xrTableRow44;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell5;
    private XRTable xrTable33;
    private XRTableRow xrTableRow45;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell92;
    private XRTableCell xrDotXetTuyen;
    private XRTableCell xrMucHuongSoMoi;
    private XRTableCell xrMucHuongSoChenhLech;
    private XRTable xrTable3;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTable xrTable23;
    private XRTableRow xrTableRow28;
    private XRTableCell xrt_chuky3;
    private XRLabel xrLabel13;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel21;
    private XRLabel xrLabel23;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel46;
    private XRLabel xrLabel45;
    private XRLabel xrLabel48;
    private XRLabel xrLabel47;
    private XRLabel xrLabel57;
    private XRLabel xrLabel56;
    private XRLabel xrLabel55;
    private XRLabel xrLabel54;
    private XRLabel xrLabel53;
    private XRLabel xrLabel52;
    private XRLabel xrLabel51;
    private XRLabel xrLabel50;
    private XRLabel xrLabel49;
    private XRLabel xrLabel59;
    private XRLabel xrLabel17;
    private XRLabel xrLabel61;
    private XRLabel xrLabel60;
    private XRLabel xrLabel58;
    private XRLabel xrLabel10;
    private XRLabel xrLabel62;
    private XRLabel xrLabel34;
    private XRLabel xrLabel33;
    private XRLabel xrLabel31;
    private XRLabel xrLabel30;
    private XRLabel xrLabel29;
    private XRLabel xrLabel26;
    private XRLabel xrLabel22;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel64;
    private XRLabel xrLabel65;
    private XRLabel xrLabel66;
    private XRLabel xrLabel67;
    private XRLabel xrLabel68;
    private XRLabel xrLabel69;
    private XRLabel xrLabel70;
    private XRLabel xrLabel71;
    private XRLabel xrLabel72;
    private XRLabel xrLabel73;
    private XRLabel xrLabel84;
    private XRLabel xrLabel85;
    private XRLabel xrLabel74;
    private XRLabel xrLabel75;
    private XRLabel xrLabel76;
    private XRLabel xrLabel77;
    private XRLabel xrLabel78;
    private XRLabel xrLabel79;
    private XRLabel xrLabel80;
    private XRLabel xrLabel81;
    private XRLabel xrLabel82;
    private XRLabel xrLabel83;
    private XRLabel xrLabel63;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_ToKhaiThamGiaBHXH_BHYT()
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
        if (rp.EmployeeCode != 0 && rp.WhereClause == "1 = 1")
            rp.WhereClause = new HoSoController().TraVeMaCbByPRKEY(rp.EmployeeCode);
        DataTable dt = new DataController.DataHandler().ExecuteDataTable("BaoCaoThongTinNhanVienBaoHiem", "@MaNhanVien", rp.WhereClause);
        if (dt.Rows.Count > 0)
        {
            DataSource = dt;
            xrt_anhthe.ImageUrl = dt.Rows[0]["PHOTO"].ToString();
            xrt_anhthe.Sizing = ImageSizeMode.StretchImage;
            xrl_hoten.Text = dt.Rows[0]["HoTen"].ToString().ToUpper();
            string noisinh = dt.Rows[0]["NOI_SINH"].ToString();
            string[] noisinh1 = noisinh.Split(',');
            string hk1 = dt.Rows[0]["HO_KHAU"].ToString();
            string[] hokhau = hk1.Split(',');
            string dc1 = dt.Rows[0]["DIA_CHI_LH"].ToString();
            string[] diachi = dc1.Split(',');
            int count = noisinh1.Length;
            int counthk = hokhau.Length;
            int countdc = diachi.Length;
            string ns1,ns2,ns3,ns4,ns5,ns6,ns7,ns8;
            if (count == 1)
            {
                xrLabel19.Text = noisinh1[0];
            }
            else if (count == 2)
            {
                xrLabel18.Text = noisinh1[0];
                xrLabel19.Text = noisinh1[1];
            }
            else
            {
                xrLabel15.Text = noisinh1[0];
                xrLabel18.Text = noisinh1[1];
                xrLabel19.Text = noisinh1[2];
            }
            if (counthk == 1)
            {
                xrLabel47.Text = hokhau[0];
            }
            else if (counthk == 2)
            {
                xrLabel45.Text = hokhau[0];
                xrLabel47.Text = hokhau[1];
            }
            else if (counthk == 3)
            {
                xrLabel44.Text = hokhau[0];
                xrLabel45.Text = hokhau[1];
                xrLabel47.Text = hokhau[2];
            }
            else {
                xrLabel42.Text = hokhau[0];
                xrLabel44.Text = hokhau[1];
                xrLabel45.Text = hokhau[2];
                xrLabel47.Text = hokhau[3];
            }
            if (countdc == 1)
            {
                xrLabel56.Text = diachi[0];
            }
            else if (countdc == 2)
            {
                xrLabel54.Text = diachi[0];
                xrLabel56.Text = diachi[1];
            }
            else if (countdc == 3)
            {
                xrLabel52.Text = diachi[0];
                xrLabel54.Text = diachi[1];
                xrLabel56.Text = diachi[2];
            }
            else
            {
                xrLabel50.Text = diachi[0];
                xrLabel52.Text = diachi[1];
                xrLabel54.Text = diachi[2];
                xrLabel56.Text = diachi[3];
            }
            string sosobhxh = "";
            if (!string.IsNullOrEmpty(dt.Rows[0]["SoSoBHXH"].ToString()))
            {
                xrLabel6.Text = "Số định danh: ";
                sosobhxh = dt.Rows[0]["SoSoBHXH"].ToString();
                xrLabel63.Text = sosobhxh[0].ToString();
                for (int i = 1; i < sosobhxh.Length; i++)
                {
                    XRLabel label = new XRLabel();
                    label.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    label.Font = new System.Drawing.Font("Times New Roman", 10F);
                    label.LocationFloat = new DevExpress.Utils.PointFloat(371.4584F + (i * 17.7083F), 200.9583F);
                    label.Name = "label" + i.ToString();
                    label.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                    label.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
                    label.StylePriority.UseBorders = false;
                    label.StylePriority.UseFont = false;
                    label.StylePriority.UseTextAlignment = false;
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

                    label.Text = sosobhxh[i].ToString();
                    this.ReportHeader.Controls.Add(label);
                }
            }
            else
            {
                for (int j = 0; j <= 10; j++)
                {
                    XRLabel label = new XRLabel();
                    label.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    label.Font = new System.Drawing.Font("Times New Roman", 10F);
                    label.LocationFloat = new DevExpress.Utils.PointFloat(371.4584F + (j * 17.7083F), 200.9583F);
                    label.Name = "label" + j.ToString();
                    label.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                    label.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
                    label.Text = sosobhxh[j].ToString();
                    this.ReportHeader.Controls.Add(label);
                }
            }
            if (dt.Rows[0]["GioiTinh"].ToString() == "True")
            {
                chknam.Checked = true;
            }
            if (dt.Rows[0]["GioiTinh"].ToString() == "False")
            {
                chknu.Checked = true;
            }
            string ngaysinh1 = Convert.ToDateTime(dt.Rows[0]["NgaySinh"].ToString()).Day.ToString();
            if (ngaysinh1.Length == 1)
            {
                ns1 = "0";
                ns2 = ngaysinh1.Substring(0, 1);

            }
            else
            {
                ns1 = ngaysinh1.Substring(0, 1);
                ns2 = ngaysinh1.Substring(1, 1);
            }
            string ngaysinh2 = Convert.ToDateTime(dt.Rows[0]["NgaySinh"].ToString()).Month.ToString();
            if (ngaysinh2.Length == 1)
            {
                ns3 = "0";
                ns4 = ngaysinh2.Substring(0, 1);
            }
            else
            {
                ns3 = ngaysinh2.Substring(0, 1);
                ns4 = ngaysinh2.Substring(1, 1);
            }
             
            string ngaysinh3 = Convert.ToDateTime(dt.Rows[0]["NgaySinh"].ToString()).Year.ToString();
             ns5 = ngaysinh3.Substring(0, 1);
             ns6 = ngaysinh3.Substring(1, 1);
             ns7 = ngaysinh3.Substring(2, 1);
             ns8 = ngaysinh3.Substring(3, 1);

            xrLabel11.Text = ns1.ToString();
            xrLabel12.Text = ns2.ToString();
            xrLabel26.Text = ns3.ToString();
            xrLabel29.Text = ns4.ToString();
            xrLabel31.Text = ns5.ToString();
            xrLabel33.Text = ns6.ToString();
            xrLabel34.Text = ns7.ToString();
            xrLabel62.Text = ns8.ToString();
            xrldantoc.Text = dt.Rows[0]["TEN_DANTOC"].ToString();
            xrlQuoctich.Text = dt.Rows[0]["TEN_NUOC"].ToString();
            //if (!string.IsNullOrEmpty(dt.Rows[0]["HoKhauThuongTruTamTru"].ToString().Trim()))
            //{
            //    xrlhokhauthuongtru.Text = "[06]. Hộ khẩu thường trú hoặc tạm trú: " + dt.Rows[0]["HoKhauThuongTruTamTru"].ToString();
            //}
            //if (!string.IsNullOrEmpty(dt.Rows[0]["DiaChiLienHe"].ToString().Trim()))
            //{
            //    xrldiachilienhe.Text = "[07]. Địa chỉ liên hệ: " + dt.Rows[0]["DiaChiLienHe"].ToString();
            //}
            if (!string.IsNullOrEmpty(dt.Rows[0]["DI_DONG"].ToString().Trim()))
            {
                xrl_dtcodinh.Text = "[11]. Số điện thoại liên hệ : " + dt.Rows[0]["DI_DONG"].ToString() + ",";
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["EMAIL"].ToString().Trim()))
            {
                xrldidong.Text = "[12] Email: " + dt.Rows[0]["EMAIL"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["SoCMTND"].ToString().Trim()))
            {
                xrlchungminhso.Text = "[08]. Số chứng minh thư (hộ chiếu): ";
                string socmtnd = dt.Rows[0]["SoCMTND"].ToString();
                if (socmtnd.Length == 9)
                {
                    xrLabel83.Text = socmtnd.Substring(0, 1).ToString();
                    xrLabel82.Text = socmtnd.Substring(1, 1).ToString();
                    xrLabel81.Text = socmtnd.Substring(2, 1).ToString();
                    xrLabel80.Text = socmtnd.Substring(3, 1).ToString();
                    xrLabel79.Text = socmtnd.Substring(4, 1).ToString();
                    xrLabel78.Text = socmtnd.Substring(5, 1).ToString();
                    xrLabel77.Text = socmtnd.Substring(6, 1).ToString();
                    xrLabel76.Text = socmtnd.Substring(7, 1).ToString();
                    xrLabel75.Text = socmtnd.Substring(8, 1).ToString();
                }
                else
                {
                    xrLabel83.Text = socmtnd.Substring(0, 1).ToString();
                    xrLabel82.Text = socmtnd.Substring(1, 1).ToString();
                    xrLabel81.Text = socmtnd.Substring(2, 1).ToString();
                    xrLabel80.Text = socmtnd.Substring(3, 1).ToString();
                    xrLabel79.Text = socmtnd.Substring(4, 1).ToString();
                    xrLabel78.Text = socmtnd.Substring(5, 1).ToString();
                    xrLabel77.Text = socmtnd.Substring(6, 1).ToString();
                    xrLabel76.Text = socmtnd.Substring(7, 1).ToString();
                    xrLabel75.Text = socmtnd.Substring(8, 1).ToString();
                    xrLabel74.Text = socmtnd.Substring(9, 1).ToString();
                    xrLabel84.Text = socmtnd.Substring(10, 1).ToString();
                    xrLabel85.Text = socmtnd.Substring(11, 1).ToString();
                }
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["NgayCapCMTND"].ToString()))
            {
                string ngaycap1 = dt.Rows[0]["NgayCapCMTND"].ToString();
                ////if (ngaycap1.Length == 1)
                ////{
                ////    nc1 = "0";
                ////    nc2 = ngaycap1.Substring(0, 1);

                ////}
                ////else
                ////{
                ////    nc1 = ngaycap1.Substring(0, 1);
                ////    nc2 = ngaycap1.Substring(1, 1);
                ////}
                ////string ngaycap2 = Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"].ToString()).Month.ToString();
                ////if (ngaycap2.Length == 1)
                ////{
                ////    nc3 = "0";
                ////    nc4 = ngaycap2.Substring(0, 1);
                ////}
                ////else
                ////{
                ////    nc3 = ngaycap2.Substring(0, 1);
                ////    nc4 = ngaycap2.Substring(1, 1);
                ////}

                ////string ngaycap3 = Convert.ToDateTime(dt.Rows[0]["NgayCapCMTND"].ToString()).Year.ToString();
                ////nc5 = ngaycap3.Substring(0, 1);
                ////nc6 = ngaycap3.Substring(1, 1);
                ////nc7 = ngaycap3.Substring(2, 1);
                ////nc8 = ngaycap3.Substring(3, 1);


                xrLabel64.Text = ngaycap1.Substring(0, 1).ToString();
                xrLabel65.Text = ngaycap1.Substring(1, 1).ToString();
                xrLabel67.Text = ngaycap1.Substring(3, 1).ToString();
                xrLabel68.Text = ngaycap1.Substring(4, 1).ToString();
                xrLabel70.Text = ngaycap1.Substring(6, 1).ToString();
                xrLabel71.Text = ngaycap1.Substring(7, 1).ToString();
                xrLabel72.Text = ngaycap1.Substring(8, 1).ToString();
                xrLabel73.Text = ngaycap1.Substring(9, 1).ToString();
            }
            else
            {
                xrLabel64.Text = "";
                xrLabel65.Text = "";
                xrLabel67.Text = "";
                xrLabel68.Text = "";
                xrLabel70.Text = "";
                xrLabel71.Text = "";
                xrLabel72.Text = "";
                xrLabel73.Text = "";
            }
            
            if (!string.IsNullOrEmpty(dt.Rows[0]["ThanNhan"].ToString()))
            {
                xrLabel36.Text = dt.Rows[0]["ThanNhan"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["TEN_NOICAP_CMND"].ToString()))
            {
                xrl_noicap.Text = "nơi cấp: " + dt.Rows[0]["TEN_NOICAP_CMND"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["SO_HDONG"].ToString().Trim()))
            {
                xrlsoloaihopdong.Text = "[14]. Quyết định tuyển dụng, hợp đồng lao động (hoặc HĐLV): số " + dt.Rows[0]["SO_HDONG"].ToString().Trim();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["NGAY_HDONG"].ToString().Trim()))
            {
                xrlngayloaihopdong.Text = "ngày: " + Convert.ToDateTime(dt.Rows[0]["NGAY_HDONG"]).Day + "/" + Convert.ToDateTime(dt.Rows[0]["NGAY_HDONG"]).Month + "/" + Convert.ToDateTime(dt.Rows[0]["NGAY_HDONG"]).Year + ",";
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["NGAY_HDONG"].ToString().Trim()))
            {
                xrlhieulucngay.Text = "có  hiệu lực từ ngày " + Convert.ToDateTime(dt.Rows[0]["NGAY_HDONG"]).Day + "/" + Convert.ToDateTime(dt.Rows[0]["NGAY_HDONG"]).Month + "/" + Convert.ToDateTime(dt.Rows[0]["NGAY_HDONG"]).Year + ",";
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["TEN_LOAI_HDONG"].ToString()))
            {
                xrlloaihopdong.Text = "loại hợp đồng: " + dt.Rows[0]["TEN_LOAI_HDONG"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["TEN_DONVI"].ToString()))
            {
                xrldiachi.Text = "[15]. Tên cơ quan, đơn vị, địa chỉ: " + dt.Rows[0]["TEN_DONVI"].ToString();
            }
            //if (!string.IsNullOrEmpty(dt.Rows[0]["TEN_DIADIEM"].ToString()))
            //{
            //xrLabel17.Text = "[12]. Nơi làm việc: Thông Lương Hội - Thị trấn Lương Bằng - Huyện Kim Động - Tỉnh Hưng Yên ";
            //}
            if (!string.IsNullOrEmpty(dt.Rows[0]["TEN_CHUCVU"].ToString()))
            {
                xrlchucdanh.Text = "[16]. Chức vụ, chức danh nghề, công việc: " + dt.Rows[0]["TEN_CHUCVU"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["LuongBaoHiem"].ToString()))
            {
                //xrl_luongchinh.Text = "[14]. Lương chính: " + string.Format("{0:0,0}",dt.Rows[0]["LuongBaoHiem"].ToString());
                xrl_luongchinh1.DataBindings.Add("Text", DataSource, "LuongBaoHiem", "{0:n0}");
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["SoSoBHXH"].ToString()))
            {
                xrlmasobaohiemxh.Text = "[19]. Mã số bảo hiểm xã hội đã được cấp( nếu có): " + dt.Rows[0]["SoSoBHXH"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["SoTheBHYT"].ToString()))
            {
                xrlsothebhyt.Text = "[17]. Mã số thẻ bảo hiểm y tế đã được cấp( nếu có): " + dt.Rows[0]["SoTheBHYT"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["NoiDangKyKCB"].ToString()))
            {
                xrlnoidangky.Text = "[13]. Nơi đăng ký khám chữa bệnh ban đầu: " + dt.Rows[0]["NoiDangKyKCB"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["PhuCapCV"].ToString()))
            {
                xrlpccv.DataBindings.Add("Text", DataSource, "PhuCapCV", "{0:n0}");
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["PhuCapTNN"].ToString()))
            {
                xrltnn.DataBindings.Add("Text", DataSource, "PhuCapTNN", "{0:n0}");
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["PhuCapTNVK"].ToString()))
            {
                xrltnvk.DataBindings.Add("Text", DataSource, "PhuCapTNVK", "{0:n0}");
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["PhuCapKhac"].ToString()))
            {
                xrlkhac.DataBindings.Add("Text", DataSource, "PhuCapKhac", "{0:n0}");
            }
            string soquyetdinh;
            string tenquyetdinh;
            DateTime? ngayhieuluc;
            DateTime? hethieuluc;
            DateTime? ngayky;
            decimal? luongbaohiem;
            decimal? phucapcv;
            decimal? phucaptnn;
            decimal? phucaptnvk;
            decimal? phucapkhac;
            new BaoHiemController().TTQuyetDinhLuongMoiNhat(Convert.ToInt32(dt.Rows[0]["IDNhanVien_BaoHiem"].ToString()), out soquyetdinh, out tenquyetdinh, out ngayky, out  ngayhieuluc, out hethieuluc, out luongbaohiem, out  phucapcv, out  phucaptnn, out  phucaptnvk, out phucapkhac);
            if (!string.IsNullOrEmpty(soquyetdinh))
            {
                xrlsoloaihopdong.Text = "[14]. Quyết định tuyển dụng, hợp đồng lao động (hoặc HĐLV): số " + soquyetdinh;
            }
            //if (!string.IsNullOrEmpty(ngayhieuluc.ToString()))
            //{
            //    xrlhieulucngay.Text = "có  hiệu lực từ ngày " + Convert.ToDateTime(ngayhieuluc).Day + "/" + Convert.ToDateTime(ngayhieuluc).Month + "/" + Convert.ToDateTime(ngayhieuluc).Year;
            //}
            if (!string.IsNullOrEmpty(ngayky.ToString()))
            {
                xrlngayloaihopdong.Text = "Ngày " + Convert.ToDateTime(ngayky).Day + "/" + Convert.ToDateTime(ngayky).Month + "/" + Convert.ToDateTime(ngayky).Year;
            }
            //xrLabel26.Text = ReportController.GetInstance().GetFooterReport(rp.SessionDepartment, DateTime.Now);
            //xrLabel32.Text = ReportController.GetInstance().GetFooterReport(rp.SessionDepartment, DateTime.Now);
            //xrLabel10.Text = ReportController.GetInstance().GetFooterReport(rp.SessionDepartment, DateTime.Now);
        }
    }
    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "rp_ToKhaiThamGiaBHXH_BHYT.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_ToKhaiThamGiaBHXH_BHYT.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable23 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_chuky3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable33 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow45 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrDotXetTuyen = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrMucHuongSoMoi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrMucHuongSoChenhLech = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable28 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow38 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable31 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow43 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable32 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow44 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrlkhac = new DevExpress.XtraReports.UI.XRLabel();
            this.xrltnvk = new DevExpress.XtraReports.UI.XRLabel();
            this.xrltnn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlpccv = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_luongchinh1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlkhac1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrltnvk1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrltnn1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlpccv1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlloaihopdong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlhieulucngay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlngayloaihopdong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_noicap = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlngaycap = new DevExpress.XtraReports.UI.XRLabel();
            this.xrldidong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlQuoctich = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrldantoc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_hoten = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlnoidangky = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlsothebhyt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlmasobaohiemxh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_luongchinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlchucdanh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrldiachi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlsoloaihopdong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlchungminhso = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_dtcodinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlhokhauthuongtru = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.chknu = new DevExpress.XtraReports.UI.XRCheckBox();
            this.chknam = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrt_anhthe = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel84,
            this.xrLabel85,
            this.xrLabel74,
            this.xrLabel75,
            this.xrLabel76,
            this.xrLabel77,
            this.xrLabel78,
            this.xrLabel79,
            this.xrLabel80,
            this.xrLabel81,
            this.xrLabel82,
            this.xrLabel83,
            this.xrLabel64,
            this.xrLabel65,
            this.xrLabel66,
            this.xrLabel67,
            this.xrLabel68,
            this.xrLabel69,
            this.xrLabel70,
            this.xrLabel71,
            this.xrLabel72,
            this.xrLabel73,
            this.xrLabel62,
            this.xrLabel34,
            this.xrLabel33,
            this.xrLabel31,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel26,
            this.xrLabel22,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel61,
            this.xrLabel60,
            this.xrLabel58,
            this.xrLabel17,
            this.xrLabel59,
            this.xrLabel57,
            this.xrLabel56,
            this.xrLabel55,
            this.xrLabel54,
            this.xrLabel53,
            this.xrLabel52,
            this.xrLabel51,
            this.xrLabel50,
            this.xrLabel49,
            this.xrLabel48,
            this.xrLabel47,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLabel43,
            this.xrLabel44,
            this.xrLabel41,
            this.xrLabel42,
            this.xrLabel40,
            this.xrLabel37,
            this.xrLabel23,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel19,
            this.xrLabel21,
            this.xrLabel16,
            this.xrLabel18,
            this.xrLabel15,
            this.xrLabel13,
            this.xrTable23,
            this.xrTable3,
            this.xrTable33,
            this.xrTable28,
            this.xrlkhac,
            this.xrltnvk,
            this.xrltnn,
            this.xrlpccv,
            this.xrl_luongchinh1,
            this.xrlkhac1,
            this.xrltnvk1,
            this.xrltnn1,
            this.xrlpccv1,
            this.xrlloaihopdong,
            this.xrlhieulucngay,
            this.xrlngayloaihopdong,
            this.xrl_noicap,
            this.xrlngaycap,
            this.xrldidong,
            this.xrlQuoctich,
            this.xrTable2,
            this.xrLabel38,
            this.xrLabel39,
            this.xrl_hoten,
            this.xrLabel32,
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel25,
            this.xrLabel24,
            this.xrlnoidangky,
            this.xrlsothebhyt,
            this.xrlmasobaohiemxh,
            this.xrLabel20,
            this.xrl_luongchinh,
            this.xrlchucdanh,
            this.xrldiachi,
            this.xrlsoloaihopdong,
            this.xrLabel14,
            this.xrlchungminhso,
            this.xrl_dtcodinh,
            this.xrlhokhauthuongtru,
            this.xrLabel9,
            this.chknu,
            this.chknam,
            this.xrLabel8,
            this.xrLabel7});
            this.Detail.HeightF = 1215F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrLabel84
            // 
            this.xrLabel84.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel84.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(400.6042F, 207F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel84.StylePriority.UseBorders = false;
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel85
            // 
            this.xrLabel85.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel85.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(418.3125F, 207F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel85.StylePriority.UseBorders = false;
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel74
            // 
            this.xrLabel74.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel74.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(382.8959F, 207F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel74.StylePriority.UseBorders = false;
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel75
            // 
            this.xrLabel75.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel75.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(365.1876F, 207F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel75.StylePriority.UseBorders = false;
            this.xrLabel75.StylePriority.UseFont = false;
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel76
            // 
            this.xrLabel76.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel76.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(347.4791F, 207F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel76.StylePriority.UseBorders = false;
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel77
            // 
            this.xrLabel77.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel77.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(329.7709F, 207F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel77.StylePriority.UseBorders = false;
            this.xrLabel77.StylePriority.UseFont = false;
            this.xrLabel77.StylePriority.UseTextAlignment = false;
            this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel78
            // 
            this.xrLabel78.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel78.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(312.0626F, 207F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel78.StylePriority.UseBorders = false;
            this.xrLabel78.StylePriority.UseFont = false;
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel79
            // 
            this.xrLabel79.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel79.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(294.3541F, 207F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel79.StylePriority.UseBorders = false;
            this.xrLabel79.StylePriority.UseFont = false;
            this.xrLabel79.StylePriority.UseTextAlignment = false;
            this.xrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel80
            // 
            this.xrLabel80.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel80.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(276.6459F, 207F);
            this.xrLabel80.Name = "xrLabel80";
            this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel80.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel80.StylePriority.UseBorders = false;
            this.xrLabel80.StylePriority.UseFont = false;
            this.xrLabel80.StylePriority.UseTextAlignment = false;
            this.xrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel81
            // 
            this.xrLabel81.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel81.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(258.9376F, 207F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel81.StylePriority.UseBorders = false;
            this.xrLabel81.StylePriority.UseFont = false;
            this.xrLabel81.StylePriority.UseTextAlignment = false;
            this.xrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel82
            // 
            this.xrLabel82.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel82.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(241.2292F, 207F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel82.StylePriority.UseBorders = false;
            this.xrLabel82.StylePriority.UseFont = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel83.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(223.5209F, 207F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel83.StylePriority.UseBorders = false;
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel64
            // 
            this.xrLabel64.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel64.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(117.2709F, 230.5F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel64.StylePriority.UseBorders = false;
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel65
            // 
            this.xrLabel65.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel65.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(134.9792F, 230.5F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel65.StylePriority.UseBorders = false;
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel66
            // 
            this.xrLabel66.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrLabel66.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(152.6876F, 230.5F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel66.StylePriority.UseBorders = false;
            this.xrLabel66.StylePriority.UseFont = false;
            this.xrLabel66.StylePriority.UseTextAlignment = false;
            this.xrLabel66.Text = "-";
            this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel67
            // 
            this.xrLabel67.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel67.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(170.3959F, 230.5F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel67.StylePriority.UseBorders = false;
            this.xrLabel67.StylePriority.UseFont = false;
            this.xrLabel67.StylePriority.UseTextAlignment = false;
            this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel68
            // 
            this.xrLabel68.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel68.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(188.1041F, 230.5F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel68.StylePriority.UseBorders = false;
            this.xrLabel68.StylePriority.UseFont = false;
            this.xrLabel68.StylePriority.UseTextAlignment = false;
            this.xrLabel68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel69
            // 
            this.xrLabel69.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(205.8126F, 230.5F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel69.StylePriority.UseBorders = false;
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "-";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel70
            // 
            this.xrLabel70.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(223.5209F, 230.5F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel70.StylePriority.UseBorders = false;
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel71.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(241.2291F, 230.5F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel71.StylePriority.UseBorders = false;
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel72
            // 
            this.xrLabel72.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel72.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(258.9376F, 230.5F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel72.StylePriority.UseBorders = false;
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel73
            // 
            this.xrLabel73.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel73.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(276.6459F, 230.5F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(17.7083F, 22.5F);
            this.xrLabel73.StylePriority.UseBorders = false;
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.StylePriority.UseTextAlignment = false;
            this.xrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel62
            // 
            this.xrLabel62.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel62.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(371.4584F, 46.00011F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel62.StylePriority.UseBorders = false;
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(353.75F, 46.00011F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel34.StylePriority.UseBorders = false;
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(336.0417F, 46.00011F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(318.3334F, 46.00011F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(300.625F, 46.00011F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "-";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(282.9167F, 46.00011F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(265.2084F, 46.00011F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(247.5F, 46.00011F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "-";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(229.7917F, 46.00011F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(212.0835F, 46.00011F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(138.5417F, 184.0001F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(663.5414F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "_________________________________________________________________________________" +
    "_____________";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel61
            // 
            this.xrLabel61.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(0.0001827876F, 650.3614F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(802.0831F, 23F);
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.StylePriority.UseTextAlignment = false;
            this.xrLabel61.Text = "III. CHỈ THAM GIA BẢO HIỂM Y TẾ ";
            this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(0.0001827876F, 696.3614F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(804.1666F, 23F);
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "[22]. Mức tiền làm căn cứ đóng bảo hiểm y tế: ___________________________________" +
    "____________________________________";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel58
            // 
            this.xrLabel58.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(0.0001827876F, 673.3614F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(804.1664F, 23F);
            this.xrLabel58.StylePriority.UseFont = false;
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            this.xrLabel58.Text = "[21]. Tham gia bảo hiểm y tế theo đối tượng: ____________________________________" +
    "____________________________________";
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 581.3613F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(802.0831F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "II. THAM GIA BẢO HIỂM XÃ HỘI TỰ NGUYỆN";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel59
            // 
            this.xrLabel59.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(0.8336942F, 415.9167F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(802.0831F, 23F);
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.Text = "I. CÙNG THAM GIA BẢO HIỂM XÃ HỘI BẮT BUỘC, BẢO HIỂM Y TẾ";
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel57
            // 
            this.xrLabel57.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(539.5833F, 323.9166F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(112.5F, 23F);
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.Text = "[10.4]. Tỉnh, TP:";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel56
            // 
            this.xrLabel56.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(652.0832F, 323.9166F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(152.0211F, 23F);
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel55
            // 
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(266.4582F, 323.9167F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(138.5417F, 22.99999F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = "[10.3]. Quận, huyện:";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel54
            // 
            this.xrLabel54.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(404.9998F, 323.9167F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(134.5834F, 23F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(0F, 323.9166F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(116.4587F, 23F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "[10.2]. Xã, phường:";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(116.4587F, 323.9166F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(148.0622F, 23F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(213.1042F, 300.9167F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(221.0417F, 22.99998F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "[10.1]. Số nhà, đường phố, thôn xóm:";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel50
            // 
            this.xrLabel50.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(436.4373F, 300.9167F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(312.4376F, 23.00001F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(0F, 300.9167F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(213.1042F, 23F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "[10]. Địa chỉ liên hệ (nơi sinh sống):                        ";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel48
            // 
            this.xrLabel48.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(539.5833F, 276F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(112.5F, 23F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            this.xrLabel48.Text = "[09.4]. Tỉnh, TP:";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(652.0832F, 276F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(152.0211F, 23F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "_____________________";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(266.4582F, 276F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(138.5417F, 22.99999F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "[09.3]. Quận, huyện:";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel45
            // 
            this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(404.9999F, 276F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(134.5834F, 23F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "__________________";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(0F, 276F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(116.4587F, 23F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "[09.2]. Xã, phường:";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel44
            // 
            this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(116.4587F, 276F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(148.0622F, 23F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "____________________";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(181.6667F, 253.0001F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(221.0417F, 22.99998F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "[09.1]. Số nhà, đường phố, thôn xóm:";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel42
            // 
            this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(404.9999F, 253F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(312.4376F, 23.00001F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(0F, 253F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(181.6667F, 23F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "[09]. Địa chỉ đăng ký hộ khẩu:                        ";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0F, 184.0001F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(138.5417F, 23F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "[07.2]. Thân nhân khác:";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0F, 161.0001F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(96.02081F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "[07]. Thân nhân                ";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(96.02081F, 161.0001F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(243.9796F, 23F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "[07.1]. Cha hoặc Mẹ hoặc Người giám hộ:";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(340.0005F, 161.0001F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(462.0826F, 23F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "_________________________________________________________________";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(138.5417F, 138.0001F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(325.8743F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "_____________________________________________";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(0.0001854367F, 138.0001F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(138.5415F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "[06.3]. Tỉnh, TP:                     ";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(464.416F, 115.0001F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(120.0002F, 22.99999F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "[06.2]. Quận, huyện:                      ";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(584.4161F, 115.0001F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(220.0002F, 22.99999F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "______________________________";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(138.5417F, 115.0001F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(325.8743F, 23.00002F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "_____________________________________________";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115.0001F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(138.5417F, 22.99999F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "[06.1]. Xã, phường:";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable23
            // 
            this.xrTable23.LocationFloat = new DevExpress.Utils.PointFloat(0.8336067F, 1012.639F);
            this.xrTable23.Name = "xrTable23";
            this.xrTable23.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow28});
            this.xrTable23.SizeF = new System.Drawing.SizeF(804.1663F, 36.45837F);
            this.xrTable23.StylePriority.UseTextAlignment = false;
            this.xrTable23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow28
            // 
            this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_chuky3});
            this.xrTableRow28.Name = "xrTableRow28";
            this.xrTableRow28.Weight = 1D;
            // 
            // xrt_chuky3
            // 
            this.xrt_chuky3.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrt_chuky3.Name = "xrt_chuky3";
            this.xrt_chuky3.StylePriority.UseFont = false;
            this.xrt_chuky3.Text = "PHỤ LỤC : THỜI GIAM LÀM VIỆC CÓ ĐÓNG BHXH CHƯA HƯỞNG MỘT LẦN";
            this.xrt_chuky3.Weight = 3D;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0.8336067F, 1180F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable3.SizeF = new System.Drawing.SizeF(804.1664F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "....";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell6.Weight = 0.31709852578702136D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "....";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrTableCell8.Weight = 0.31709849829126535D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 1.2110191684297258D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell10.Weight = 0.37952536405878634D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell11.Weight = 0.38762940715213323D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell12.Weight = 0.38762903628106793D;
            // 
            // xrTable33
            // 
            this.xrTable33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable33.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable33.LocationFloat = new DevExpress.Utils.PointFloat(0.8336067F, 1155F);
            this.xrTable33.Name = "xrTable33";
            this.xrTable33.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow45});
            this.xrTable33.SizeF = new System.Drawing.SizeF(804.1664F, 25F);
            this.xrTable33.StylePriority.UseBorders = false;
            this.xrTable33.StylePriority.UseFont = false;
            // 
            // xrTableRow45
            // 
            this.xrTableRow45.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrTableCell92,
            this.xrDotXetTuyen,
            this.xrMucHuongSoMoi,
            this.xrMucHuongSoChenhLech});
            this.xrTableRow45.Name = "xrTableRow45";
            this.xrTableRow45.Weight = 1D;
            // 
            // xrTableCell89
            // 
            this.xrTableCell89.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell89.StylePriority.UseFont = false;
            this.xrTableCell89.StylePriority.UsePadding = false;
            this.xrTableCell89.StylePriority.UseTextAlignment = false;
            this.xrTableCell89.Text = "1";
            this.xrTableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell89.Weight = 0.31709852578702136D;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell90.StylePriority.UseFont = false;
            this.xrTableCell90.StylePriority.UsePadding = false;
            this.xrTableCell90.StylePriority.UseTextAlignment = false;
            this.xrTableCell90.Text = "2";
            this.xrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell90.Weight = 0.31709849829126535D;
            // 
            // xrTableCell92
            // 
            this.xrTableCell92.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell92.StylePriority.UseFont = false;
            this.xrTableCell92.StylePriority.UsePadding = false;
            this.xrTableCell92.StylePriority.UseTextAlignment = false;
            this.xrTableCell92.Text = "3";
            this.xrTableCell92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell92.Weight = 1.2110191684297258D;
            // 
            // xrDotXetTuyen
            // 
            this.xrDotXetTuyen.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrDotXetTuyen.Name = "xrDotXetTuyen";
            this.xrDotXetTuyen.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrDotXetTuyen.StylePriority.UseFont = false;
            this.xrDotXetTuyen.StylePriority.UsePadding = false;
            this.xrDotXetTuyen.StylePriority.UseTextAlignment = false;
            this.xrDotXetTuyen.Text = "4";
            this.xrDotXetTuyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrDotXetTuyen.Weight = 0.37952536405878634D;
            // 
            // xrMucHuongSoMoi
            // 
            this.xrMucHuongSoMoi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrMucHuongSoMoi.Name = "xrMucHuongSoMoi";
            this.xrMucHuongSoMoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrMucHuongSoMoi.StylePriority.UseFont = false;
            this.xrMucHuongSoMoi.StylePriority.UsePadding = false;
            this.xrMucHuongSoMoi.StylePriority.UseTextAlignment = false;
            this.xrMucHuongSoMoi.Text = "5";
            this.xrMucHuongSoMoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrMucHuongSoMoi.Weight = 0.38762940715213323D;
            // 
            // xrMucHuongSoChenhLech
            // 
            this.xrMucHuongSoChenhLech.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrMucHuongSoChenhLech.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrMucHuongSoChenhLech.Name = "xrMucHuongSoChenhLech";
            this.xrMucHuongSoChenhLech.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrMucHuongSoChenhLech.StylePriority.UseBorders = false;
            this.xrMucHuongSoChenhLech.StylePriority.UseFont = false;
            this.xrMucHuongSoChenhLech.StylePriority.UsePadding = false;
            this.xrMucHuongSoChenhLech.StylePriority.UseTextAlignment = false;
            this.xrMucHuongSoChenhLech.Text = "6";
            this.xrMucHuongSoChenhLech.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrMucHuongSoChenhLech.Weight = 0.38762903628106793D;
            // 
            // xrTable28
            // 
            this.xrTable28.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable28.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable28.LocationFloat = new DevExpress.Utils.PointFloat(0.8336067F, 1062.292F);
            this.xrTable28.Name = "xrTable28";
            this.xrTable28.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow38});
            this.xrTable28.SizeF = new System.Drawing.SizeF(804.1664F, 92.70834F);
            this.xrTable28.StylePriority.UseBorders = false;
            this.xrTable28.StylePriority.UseFont = false;
            this.xrTable28.StylePriority.UseTextAlignment = false;
            this.xrTable28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow38
            // 
            this.xrTableRow38.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell5,
            this.xrTableCell84});
            this.xrTableRow38.Name = "xrTableRow38";
            this.xrTableRow38.Weight = 1D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Multiline = true;
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Text = "Từ \r\ntháng năm";
            this.xrTableCell72.Weight = 0.212055750789581D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Multiline = true;
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.Text = "Đến \r\ntháng năm";
            this.xrTableCell73.Weight = 0.2120557517391562D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Text = "Diễn giải";
            this.xrTableCell74.Weight = 0.80985425568374092D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Căn cứ đóng";
            this.xrTableCell5.Weight = 0.253802929178347D;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable31,
            this.xrTable32});
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.Text = "xrTableCell16";
            this.xrTableCell84.Weight = 0.518444509084595D;
            // 
            // xrTable31
            // 
            this.xrTable31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable31.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46.35417F);
            this.xrTable31.Name = "xrTable31";
            this.xrTable31.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow43});
            this.xrTable31.SizeF = new System.Drawing.SizeF(207.8123F, 46.35417F);
            this.xrTable31.StylePriority.UseFont = false;
            this.xrTable31.StylePriority.UseTextAlignment = false;
            this.xrTable31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow43
            // 
            this.xrTableRow43.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell85,
            this.xrTableCell86});
            this.xrTableRow43.Name = "xrTableRow43";
            this.xrTableRow43.Weight = 1D;
            // 
            // xrTableCell85
            // 
            this.xrTableCell85.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.StylePriority.UseBorders = false;
            this.xrTableCell85.Text = "BHXH";
            this.xrTableCell85.Weight = 1.5D;
            // 
            // xrTableCell86
            // 
            this.xrTableCell86.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell86.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.StylePriority.UseBorders = false;
            this.xrTableCell86.StylePriority.UseFont = false;
            this.xrTableCell86.Text = "BHTN";
            this.xrTableCell86.Weight = 1.5D;
            // 
            // xrTable32
            // 
            this.xrTable32.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable32.LocationFloat = new DevExpress.Utils.PointFloat(0F, 7.629395E-06F);
            this.xrTable32.Name = "xrTable32";
            this.xrTable32.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow44});
            this.xrTable32.SizeF = new System.Drawing.SizeF(207.8123F, 46.35418F);
            this.xrTable32.StylePriority.UseFont = false;
            this.xrTable32.StylePriority.UseTextAlignment = false;
            this.xrTable32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow44
            // 
            this.xrTableRow44.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell87});
            this.xrTableRow44.Name = "xrTableRow44";
            this.xrTableRow44.Weight = 1D;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell87.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.StylePriority.UseBorders = false;
            this.xrTableCell87.StylePriority.UseFont = false;
            this.xrTableCell87.Text = "Tỷ lệ đóng (%)";
            this.xrTableCell87.Weight = 3D;
            // 
            // xrlkhac
            // 
            this.xrlkhac.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlkhac.LocationFloat = new DevExpress.Utils.PointFloat(325.3752F, 558.3613F);
            this.xrlkhac.Name = "xrlkhac";
            this.xrlkhac.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlkhac.SizeF = new System.Drawing.SizeF(86.45844F, 23F);
            this.xrlkhac.StylePriority.UseFont = false;
            this.xrlkhac.StylePriority.UseTextAlignment = false;
            this.xrlkhac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrltnvk
            // 
            this.xrltnvk.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrltnvk.LocationFloat = new DevExpress.Utils.PointFloat(678.1249F, 535.3613F);
            this.xrltnvk.Name = "xrltnvk";
            this.xrltnvk.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrltnvk.SizeF = new System.Drawing.SizeF(85.66614F, 23F);
            this.xrltnvk.StylePriority.UseFont = false;
            this.xrltnvk.StylePriority.UseTextAlignment = false;
            this.xrltnvk.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrltnn
            // 
            this.xrltnn.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrltnn.LocationFloat = new DevExpress.Utils.PointFloat(116.4587F, 558.3613F);
            this.xrltnn.Name = "xrltnn";
            this.xrltnn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrltnn.SizeF = new System.Drawing.SizeF(131.0413F, 23F);
            this.xrltnn.StylePriority.UseFont = false;
            this.xrltnn.StylePriority.UseTextAlignment = false;
            this.xrltnn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlpccv
            // 
            this.xrlpccv.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlpccv.LocationFloat = new DevExpress.Utils.PointFloat(455.8749F, 535.3612F);
            this.xrlpccv.Name = "xrlpccv";
            this.xrlpccv.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlpccv.SizeF = new System.Drawing.SizeF(83.70831F, 23F);
            this.xrlpccv.StylePriority.UseFont = false;
            this.xrlpccv.StylePriority.UseTextAlignment = false;
            this.xrlpccv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_luongchinh1
            // 
            this.xrl_luongchinh1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_luongchinh1.LocationFloat = new DevExpress.Utils.PointFloat(117.5004F, 535.3613F);
            this.xrl_luongchinh1.Name = "xrl_luongchinh1";
            this.xrl_luongchinh1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_luongchinh1.SizeF = new System.Drawing.SizeF(129.9995F, 23F);
            this.xrl_luongchinh1.StylePriority.UseFont = false;
            this.xrl_luongchinh1.StylePriority.UseTextAlignment = false;
            this.xrl_luongchinh1.Text = "________________";
            this.xrl_luongchinh1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlkhac1
            // 
            this.xrlkhac1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlkhac1.LocationFloat = new DevExpress.Utils.PointFloat(247.5F, 558.3613F);
            this.xrlkhac1.Name = "xrlkhac1";
            this.xrlkhac1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlkhac1.SizeF = new System.Drawing.SizeF(77.87524F, 23F);
            this.xrlkhac1.StylePriority.UseFont = false;
            this.xrlkhac1.StylePriority.UseTextAlignment = false;
            this.xrlkhac1.Text = "[18.4]. Khác";
            this.xrlkhac1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrltnvk1
            // 
            this.xrltnvk1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrltnvk1.LocationFloat = new DevExpress.Utils.PointFloat(539.5833F, 535.3613F);
            this.xrltnvk1.Name = "xrltnvk1";
            this.xrltnvk1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrltnvk1.SizeF = new System.Drawing.SizeF(138.5417F, 23F);
            this.xrltnvk1.StylePriority.UseFont = false;
            this.xrltnvk1.StylePriority.UseTextAlignment = false;
            this.xrltnvk1.Text = "[18.2]. TN vượt khung:";
            this.xrltnvk1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrltnn1
            // 
            this.xrltnn1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrltnn1.LocationFloat = new DevExpress.Utils.PointFloat(0.8336942F, 558.3613F);
            this.xrltnn1.Name = "xrltnn1";
            this.xrltnn1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrltnn1.SizeF = new System.Drawing.SizeF(115.625F, 23F);
            this.xrltnn1.StylePriority.UseFont = false;
            this.xrltnn1.StylePriority.UseTextAlignment = false;
            this.xrltnn1.Text = "[18.3]. TN nghề";
            this.xrltnn1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlpccv1
            // 
            this.xrlpccv1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlpccv1.LocationFloat = new DevExpress.Utils.PointFloat(343.5208F, 535.3613F);
            this.xrlpccv1.Name = "xrlpccv1";
            this.xrlpccv1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlpccv1.SizeF = new System.Drawing.SizeF(112.3541F, 23F);
            this.xrlpccv1.StylePriority.UseFont = false;
            this.xrlpccv1.StylePriority.UseTextAlignment = false;
            this.xrlpccv1.Text = "[18.1]. Chức vụ:";
            this.xrlpccv1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlloaihopdong
            // 
            this.xrlloaihopdong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlloaihopdong.LocationFloat = new DevExpress.Utils.PointFloat(413.1252F, 464.3613F);
            this.xrlloaihopdong.Name = "xrlloaihopdong";
            this.xrlloaihopdong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlloaihopdong.SizeF = new System.Drawing.SizeF(304.5834F, 25.00009F);
            this.xrlloaihopdong.StylePriority.UseFont = false;
            this.xrlloaihopdong.StylePriority.UseTextAlignment = false;
            this.xrlloaihopdong.Text = "loại hợp đồng_______________________________________________________________";
            this.xrlloaihopdong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlhieulucngay
            // 
            this.xrlhieulucngay.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlhieulucngay.LocationFloat = new DevExpress.Utils.PointFloat(165.6252F, 464.3613F);
            this.xrlhieulucngay.Name = "xrlhieulucngay";
            this.xrlhieulucngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlhieulucngay.SizeF = new System.Drawing.SizeF(247.5F, 25.00006F);
            this.xrlhieulucngay.StylePriority.UseFont = false;
            this.xrlhieulucngay.StylePriority.UseTextAlignment = false;
            this.xrlhieulucngay.Text = "có  hiệu lực từ ngày ____/____/____";
            this.xrlhieulucngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlngayloaihopdong
            // 
            this.xrlngayloaihopdong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlngayloaihopdong.LocationFloat = new DevExpress.Utils.PointFloat(0.8336942F, 464.3613F);
            this.xrlngayloaihopdong.Name = "xrlngayloaihopdong";
            this.xrlngayloaihopdong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlngayloaihopdong.SizeF = new System.Drawing.SizeF(164.7915F, 25F);
            this.xrlngayloaihopdong.StylePriority.UseFont = false;
            this.xrlngayloaihopdong.StylePriority.UseTextAlignment = false;
            this.xrlngayloaihopdong.Text = "ngày ____/____/____                     ";
            this.xrlngayloaihopdong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_noicap
            // 
            this.xrl_noicap.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_noicap.LocationFloat = new DevExpress.Utils.PointFloat(335F, 230F);
            this.xrl_noicap.Name = "xrl_noicap";
            this.xrl_noicap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_noicap.SizeF = new System.Drawing.SizeF(427.5002F, 23F);
            this.xrl_noicap.StylePriority.UseFont = false;
            this.xrl_noicap.StylePriority.UseTextAlignment = false;
            this.xrl_noicap.Text = "[08.2]. Nơi cấp: _____________________________________________";
            this.xrl_noicap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlngaycap
            // 
            this.xrlngaycap.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlngaycap.LocationFloat = new DevExpress.Utils.PointFloat(0F, 230F);
            this.xrlngaycap.Name = "xrlngaycap";
            this.xrlngaycap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlngaycap.SizeF = new System.Drawing.SizeF(116.4587F, 23F);
            this.xrlngaycap.StylePriority.UseFont = false;
            this.xrlngaycap.StylePriority.UseTextAlignment = false;
            this.xrlngaycap.Text = "[08.1]. Ngày cấp: ";
            this.xrlngaycap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrldidong
            // 
            this.xrldidong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrldidong.LocationFloat = new DevExpress.Utils.PointFloat(404.9998F, 346.9167F);
            this.xrldidong.Name = "xrldidong";
            this.xrldidong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrldidong.SizeF = new System.Drawing.SizeF(397.917F, 23F);
            this.xrldidong.StylePriority.UseFont = false;
            this.xrldidong.StylePriority.UseTextAlignment = false;
            this.xrldidong.Text = "[12] Email: _____________________________________________";
            this.xrldidong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlQuoctich
            // 
            this.xrlQuoctich.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlQuoctich.LocationFloat = new DevExpress.Utils.PointFloat(667.0625F, 69.00027F);
            this.xrlQuoctich.Name = "xrlQuoctich";
            this.xrlQuoctich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlQuoctich.SizeF = new System.Drawing.SizeF(135.4167F, 23F);
            this.xrlQuoctich.StylePriority.UseFont = false;
            this.xrlQuoctich.StylePriority.UseTextAlignment = false;
            this.xrlQuoctich.Text = "__________________";
            this.xrlQuoctich.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(314.4122F, 69.00027F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(242.9837F, 22.99998F);
            this.xrTable2.StylePriority.UseFont = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrldantoc});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "[04]. Dân tộc: ";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell7.Weight = 2.2353157699119084D;
            // 
            // xrldantoc
            // 
            this.xrldantoc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrldantoc.Name = "xrldantoc";
            this.xrldantoc.StylePriority.UseFont = false;
            this.xrldantoc.StylePriority.UseTextAlignment = false;
            this.xrldantoc.Text = "________________";
            this.xrldantoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrldantoc.Weight = 2.9601789241734253D;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(557.3959F, 69.00027F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(109.6666F, 23F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "[05]. Quốc tịch:                       ";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0F, 69.00008F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(138.5417F, 23F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UsePadding = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "[03]. Giới tính:  ";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_hoten
            // 
            this.xrl_hoten.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_hoten.LocationFloat = new DevExpress.Utils.PointFloat(218.75F, 23.00011F);
            this.xrl_hoten.Name = "xrl_hoten";
            this.xrl_hoten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_hoten.SizeF = new System.Drawing.SizeF(311.4583F, 23F);
            this.xrl_hoten.StylePriority.UseFont = false;
            this.xrl_hoten.StylePriority.UseTextAlignment = false;
            this.xrl_hoten.Text = "__________________________________________";
            this.xrl_hoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(427.9585F, 820.0975F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(362.4583F, 27.16669F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "............, Ngày ...... tháng ....... năm .........";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(464.416F, 874.4309F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(302.4584F, 27.16669F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "(Ký, ghi rõ họ tên)";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(464.416F, 847.2642F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(302.4584F, 27.16669F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Người khai ";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(495.4539F, 761.1111F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(256.5103F, 58.98633F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Tôi cam đoan những nội dung kê khai là đúng và chịu trách nhiệm trước pháp luật v" +
    "ề những nội dung đã kê khai";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0.8335511F, 720.5696F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(803.2708F, 23.00006F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "[23]. Phương thức đóng: _________________________________________________________" +
    "______________________________";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlnoidangky
            // 
            this.xrlnoidangky.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlnoidangky.LocationFloat = new DevExpress.Utils.PointFloat(0F, 371.0417F);
            this.xrlnoidangky.Multiline = true;
            this.xrlnoidangky.Name = "xrlnoidangky";
            this.xrlnoidangky.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlnoidangky.SizeF = new System.Drawing.SizeF(804.1666F, 21.875F);
            this.xrlnoidangky.StylePriority.UseFont = false;
            this.xrlnoidangky.StylePriority.UseTextAlignment = false;
            this.xrlnoidangky.Text = resources.GetString("xrlnoidangky.Text");
            this.xrlnoidangky.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlsothebhyt
            // 
            this.xrlsothebhyt.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlsothebhyt.LocationFloat = new DevExpress.Utils.PointFloat(0F, 627.3614F);
            this.xrlsothebhyt.Name = "xrlsothebhyt";
            this.xrlsothebhyt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlsothebhyt.SizeF = new System.Drawing.SizeF(804.1666F, 23F);
            this.xrlsothebhyt.StylePriority.UseFont = false;
            this.xrlsothebhyt.StylePriority.UseTextAlignment = false;
            this.xrlsothebhyt.Text = "[20]. Mã số thẻ bảo hiểm y tế đã được cấp( nếu có): _____________________________" +
    "______________________________________";
            this.xrlsothebhyt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlmasobaohiemxh
            // 
            this.xrlmasobaohiemxh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlmasobaohiemxh.LocationFloat = new DevExpress.Utils.PointFloat(0F, 604.3613F);
            this.xrlmasobaohiemxh.Name = "xrlmasobaohiemxh";
            this.xrlmasobaohiemxh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlmasobaohiemxh.SizeF = new System.Drawing.SizeF(804.1664F, 23F);
            this.xrlmasobaohiemxh.StylePriority.UseFont = false;
            this.xrlmasobaohiemxh.StylePriority.UseTextAlignment = false;
            this.xrlmasobaohiemxh.Text = "[19]. Mã số bảo hiểm xã hội đã được cấp( nếu có): _______________________________" +
    "_____________________________________";
            this.xrlmasobaohiemxh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(247.5F, 535.3612F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(96.02081F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "[18]. Phụ cấp:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_luongchinh
            // 
            this.xrl_luongchinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_luongchinh.LocationFloat = new DevExpress.Utils.PointFloat(0.8336067F, 535.3613F);
            this.xrl_luongchinh.Name = "xrl_luongchinh";
            this.xrl_luongchinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_luongchinh.SizeF = new System.Drawing.SizeF(115.6251F, 23F);
            this.xrl_luongchinh.StylePriority.UseFont = false;
            this.xrl_luongchinh.StylePriority.UseTextAlignment = false;
            this.xrl_luongchinh.Text = "[17]. Lương chính:";
            this.xrl_luongchinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlchucdanh
            // 
            this.xrlchucdanh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlchucdanh.LocationFloat = new DevExpress.Utils.PointFloat(0F, 512.3613F);
            this.xrlchucdanh.Name = "xrlchucdanh";
            this.xrlchucdanh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlchucdanh.SizeF = new System.Drawing.SizeF(803.2706F, 23F);
            this.xrlchucdanh.StylePriority.UseFont = false;
            this.xrlchucdanh.StylePriority.UseTextAlignment = false;
            this.xrlchucdanh.Text = "[16]. Chức vụ, chức danh nghề, công việc: _______________________________________" +
    "____________________________________    ";
            this.xrlchucdanh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrldiachi
            // 
            this.xrldiachi.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrldiachi.LocationFloat = new DevExpress.Utils.PointFloat(0.8336942F, 489.3613F);
            this.xrldiachi.Name = "xrldiachi";
            this.xrldiachi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrldiachi.SizeF = new System.Drawing.SizeF(803.2706F, 23F);
            this.xrldiachi.StylePriority.UseFont = false;
            this.xrldiachi.StylePriority.UseTextAlignment = false;
            this.xrldiachi.Text = "[15]. Tên cơ quan, đơn vị, địa chỉ: _____________________________________________" +
    "_____________________________________      ";
            this.xrldiachi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlsoloaihopdong
            // 
            this.xrlsoloaihopdong.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlsoloaihopdong.LocationFloat = new DevExpress.Utils.PointFloat(0.8331617F, 439.3613F);
            this.xrlsoloaihopdong.Multiline = true;
            this.xrlsoloaihopdong.Name = "xrlsoloaihopdong";
            this.xrlsoloaihopdong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlsoloaihopdong.SizeF = new System.Drawing.SizeF(614.8335F, 25F);
            this.xrlsoloaihopdong.StylePriority.UseFont = false;
            this.xrlsoloaihopdong.StylePriority.UseTextAlignment = false;
            this.xrlsoloaihopdong.Text = "[14]. Quyết định tuyển dụng, hợp đồng lao động (hợp đồng làm việc): số___________" +
    "________ ,\r\n\r\n";
            this.xrlsoloaihopdong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0.8336942F, 392.9167F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(802.0831F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "B. THAM GIA BẢO HIỂM XÃ HỘI, BẢO HIỂM Y TẾ: ";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlchungminhso
            // 
            this.xrlchungminhso.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlchungminhso.LocationFloat = new DevExpress.Utils.PointFloat(0F, 207.0001F);
            this.xrlchungminhso.Name = "xrlchungminhso";
            this.xrlchungminhso.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlchungminhso.SizeF = new System.Drawing.SizeF(209.3749F, 23F);
            this.xrlchungminhso.StylePriority.UseFont = false;
            this.xrlchungminhso.StylePriority.UseTextAlignment = false;
            this.xrlchungminhso.Text = "[08]. Số chứng minh thư (hộ chiếu):  ";
            this.xrlchungminhso.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_dtcodinh
            // 
            this.xrl_dtcodinh.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrl_dtcodinh.LocationFloat = new DevExpress.Utils.PointFloat(5.5631E-05F, 346.9167F);
            this.xrl_dtcodinh.Name = "xrl_dtcodinh";
            this.xrl_dtcodinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_dtcodinh.SizeF = new System.Drawing.SizeF(402.7083F, 23F);
            this.xrl_dtcodinh.StylePriority.UseFont = false;
            this.xrl_dtcodinh.StylePriority.UseTextAlignment = false;
            this.xrl_dtcodinh.Text = "[11]. Số điện thoại liên hệ : ________________________________                   " +
    "";
            this.xrl_dtcodinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlhokhauthuongtru
            // 
            this.xrlhokhauthuongtru.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrlhokhauthuongtru.LocationFloat = new DevExpress.Utils.PointFloat(0F, 92.00023F);
            this.xrlhokhauthuongtru.Name = "xrlhokhauthuongtru";
            this.xrlhokhauthuongtru.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlhokhauthuongtru.SizeF = new System.Drawing.SizeF(247.5F, 23F);
            this.xrlhokhauthuongtru.StylePriority.UseFont = false;
            this.xrlhokhauthuongtru.StylePriority.UseTextAlignment = false;
            this.xrlhokhauthuongtru.Text = "[06]. Nơi cấp giấy khai sinh (quê quán):                          ";
            this.xrlhokhauthuongtru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0.0001854367F, 46.00008F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(165.625F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "[02]. Ngày tháng năm sinh: ";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // chknu
            // 
            this.chknu.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chknu.LocationFloat = new DevExpress.Utils.PointFloat(223.5209F, 69.00011F);
            this.chknu.Name = "chknu";
            this.chknu.SizeF = new System.Drawing.SizeF(67.70831F, 23.00013F);
            this.chknu.StylePriority.UseFont = false;
            this.chknu.Text = " Nữ";
            // 
            // chknam
            // 
            this.chknam.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chknam.LocationFloat = new DevExpress.Utils.PointFloat(155.8126F, 68.99995F);
            this.chknam.Name = "chknam";
            this.chknam.SizeF = new System.Drawing.SizeF(67.70831F, 23.00013F);
            this.chknam.StylePriority.UseFont = false;
            this.chknam.Text = " Nam";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 23.00008F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(193.3332F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "[01]. Họ và tên ( viết chữ in hoa):                                              " +
    "               ";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(804.1666F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "A. THÔNG TIN CỦA NGƯỜI THAM GIA: ";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 29F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 14F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel63,
            this.xrLabel6,
            this.xrt_anhthe,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 239F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel63
            // 
            this.xrLabel63.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel63.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(395.4169F, 200.1666F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(17.7083F, 23F);
            this.xrLabel63.StylePriority.UseBorders = false;
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(268.4376F, 200.1666F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(114.4583F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Số định danh:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrt_anhthe
            // 
            this.xrt_anhthe.LocationFloat = new DevExpress.Utils.PointFloat(65.62513F, 99.75001F);
            this.xrt_anhthe.Name = "xrt_anhthe";
            this.xrt_anhthe.SizeF = new System.Drawing.SizeF(100F, 124.2083F);
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(404.9999F, 116.3333F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(278.125F, 8.416672F);
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(45.60416F, 91.33333F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(184.375F, 8.416672F);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(186.6666F, 149.6666F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(496.4583F, 41.74998F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "TỜ KHAI THAM GIA \r\nBẢO HIỂM XÃ HỘI, BẢO HIỂM Y TẾ ";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(349.375F, 68.33334F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(387.0833F, 47.99998F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM\r\nĐộc lập - Tự do - Hạnh phúc";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 68.33334F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(280.8333F, 22.99998F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "BẢO HIỂM XÃ HỘI VIỆT NAM ";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(558.6458F, 17.79165F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(244.2709F, 39.66669F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "( Ban hành kèm theo QĐ số:  /QĐ - BHXH\r\nngày 10/10/2014 của BHXH Việt Nam)";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(619.25F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(143.2501F, 17.79166F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Mẫu số: TK1 - TS\r\n";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rp_ToKhaiThamGiaBHXH_BHYT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(12, 10, 29, 14);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "14.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
