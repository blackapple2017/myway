using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_LichPhanCaThang
/// </summary>
public class rp_LichPhanCaThang : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private PageFooterBand PageFooter;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell41;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrt_le;
    private XRTableRow xrTableRow6;
    private XRTableCell h1;
    private XRTableCell h2;
    private XRTableCell h3;
    private XRTableCell h4;
    private XRTableCell h5;
    private XRTableCell h6;
    private XRTableCell h7;
    private XRTableCell h8;
    private XRTableCell h9;
    private XRTableCell h10;
    private XRTableCell h11;
    private XRTableCell h12;
    private XRTableCell h13;
    private XRTableCell h14;
    private XRTableCell h15;
    private XRTableCell h16;
    private XRTableCell h17;
    private XRTableCell h18;
    private XRTableCell h19;
    private XRTableCell h20;
    private XRTableCell h21;
    private XRTableCell h22;
    private XRTableCell h23;
    private XRTableCell h24;
    private XRTableCell h25;
    private XRTableCell h26;
    private XRTableCell h27;
    private XRTableCell h28;
    private XRTableCell h29;
    private XRTableCell h30;
    private XRTableCell h31;
    private XRTable xrTable5;
    private XRTableRow xrTableRow7;
    private XRTableCell xrt_hovaten;
    private XRTableCell xrt_24;
    private XRTableCell xrTableCell77;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_12;
    private XRTableCell xrTableCell80;
    private XRTableCell xrt_6;
    private XRTableCell xrt_2;
    private XRTableCell xrt_1;
    private XRTableCell xrt_3;
    private XRTableCell xrt_4;
    private XRTableCell xrt_5;
    private XRTableCell xrt_7;
    private XRTableCell xrt_8;
    private XRTableCell xrt_9;
    private XRTableCell xrt_10;
    private XRTableCell xrt_11;
    private XRTableCell xrt_13;
    private XRTableCell xrt_14;
    private XRTableCell xrt_15;
    private XRTableCell xrt_16;
    private XRTableCell xrt_17;
    private XRTableCell xrt_18;
    private XRTableCell xrt_19;
    private XRTableCell xrt_20;
    private XRTableCell xrt_21;
    private XRTableCell xrt_22;
    private XRTableCell xrt_23;
    private XRTableCell xrt_25;
    private XRTableCell xrt_26;
    private XRTableCell xrt_27;
    private XRTableCell xrt_28;
    private XRTableCell xrt_29;
    private XRTableCell xrt_30;
    private XRTableCell xrt_31;
    private XRTableCell xrt_socong;
    private XRTableCell xrt_phep;
    private XRTableCell xrt_chedo;
    private XRTableCell xrTableCell113;
    private XRLabel xrl_TenThanhPho;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TitleBC;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrt_todoi;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel9;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRTable xrTable10;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell154;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell193;
    private XRLabel xrLabel10;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRTable xrTable9;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell231;
    private XRTableCell xrTableCell233;
    private XRTableCell hc1;
    private XRTableCell hc2;
    private XRTableCell hc3;
    private XRTableCell hc4;
    private XRTableCell hc5;
    private XRTableCell hc6;
    private XRTableCell hc7;
    private XRTableCell hc8;
    private XRTableCell hc9;
    private XRTableCell hc10;
    private XRTableCell hc11;
    private XRTableCell hc12;
    private XRTableCell hc13;
    private XRTableCell hc14;
    private XRTableCell hc15;
    private XRTableCell hc16;
    private XRTableCell hc17;
    private XRTableCell hc18;
    private XRTableCell hc19;
    private XRTableCell hc20;
    private XRTableCell hc21;
    private XRTableCell hc22;
    private XRTableCell hc23;
    private XRTableCell hc24;
    private XRTableCell hc25;
    private XRTableCell hc26;
    private XRTableCell hc27;
    private XRTableCell hc28;
    private XRTableCell hc29;
    private XRTableCell hc30;
    private XRTableCell hc31;
    private XRTableCell xrTableCell265;
    private XRTableCell xrTableCell266;
    private XRTableCell xrTableCell267;
    private XRTableCell xrTableCell268;
    private XRTableCell xrTableCell269;
    private XRTable xrTable8;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell192;
    private XRTableCell xrTableCell194;
    private XRTableCell c1;
    private XRTableCell c2;
    private XRTableCell c3;
    private XRTableCell c4;
    private XRTableCell c5;
    private XRTableCell c6;
    private XRTableCell c7;
    private XRTableCell c8;
    private XRTableCell c9;
    private XRTableCell c10;
    private XRTableCell c11;
    private XRTableCell c12;
    private XRTableCell c13;
    private XRTableCell c14;
    private XRTableCell c15;
    private XRTableCell c16;
    private XRTableCell c17;
    private XRTableCell c18;
    private XRTableCell c19;
    private XRTableCell c20;
    private XRTableCell c21;
    private XRTableCell c22;
    private XRTableCell c23;
    private XRTableCell c24;
    private XRTableCell c25;
    private XRTableCell c26;
    private XRTableCell c27;
    private XRTableCell c28;
    private XRTableCell c29;
    private XRTableCell c30;
    private XRTableCell c31;
    private XRTableCell xrTableCell226;
    private XRTableCell xrTableCell227;
    private XRTableCell xrTableCell228;
    private XRTableCell xrTableCell229;
    private XRTableCell xrTableCell230;
    private XRTable xrTable7;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell153;
    private XRTableCell xrTableCell155;
    private XRTableCell s1;
    private XRTableCell s2;
    private XRTableCell s3;
    private XRTableCell s4;
    private XRTableCell s5;
    private XRTableCell s6;
    private XRTableCell s7;
    private XRTableCell s8;
    private XRTableCell s9;
    private XRTableCell s10;
    private XRTableCell s11;
    private XRTableCell s12;
    private XRTableCell s13;
    private XRTableCell s14;
    private XRTableCell s15;
    private XRTableCell s16;
    private XRTableCell s17;
    private XRTableCell s18;
    private XRTableCell s19;
    private XRTableCell s20;
    private XRTableCell s21;
    private XRTableCell s22;
    private XRTableCell s23;
    private XRTableCell s24;
    private XRTableCell s25;
    private XRTableCell s26;
    private XRTableCell s27;
    private XRTableCell s28;
    private XRTableCell s29;
    private XRTableCell s30;
    private XRTableCell s31;
    private XRTableCell xrTableCell187;
    private XRTableCell xrTableCell188;
    private XRTableCell xrTableCell189;
    private XRTableCell xrTableCell190;
    private XRTableCell xrTableCell191;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell39;
    private XRLabel xrl_ten3;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten1;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer1;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer2;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rp_LichPhanCaThang()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    int STT = 1;
    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        foreach (XRTableRow item in xrTable5.Rows)
        {
            foreach (XRTableCell item1 in item.Cells)
            {

                try
                {
                    if (GetCurrentColumnValue("sx").ToString() == "0")
                    {
                        item1.Font = new Font("Times New Roman", 9, FontStyle.Bold, GraphicsUnit.Point);
                    }
                    else
                    {
                        item1.Font = new Font("Times New Roman", 9, FontStyle.Regular, GraphicsUnit.Point);
                    }
                }
                catch
                {

                }
            }
        }
        try
        {
            if (GetCurrentColumnValue("sx").ToString() == "0")
            {
                xrt_stt.Text = STT.ToString();
                STT++;

            }
            else
            {
                xrt_stt.Text = "";
            }
        }
        catch
        {

        }
    }
    public void BindData(ReportFilter rp)
    {
        xrtngayketxuat.Text = " Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //xrl_TenCongTy.Text = rp.TenDonVi;
        //xrl_TenThanhPho.Text = rp.TenThanhPho.ToUpper();
        //DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("GetBangPhanCaThang_BaoCao", "@IDBangPhanCa", "@MaDonVi", "@MaBoPhan", rp.IdPhanCa, rp.MaDonVi, rp.MaBoPhan);
        //if (!string.IsNullOrEmpty(rp.ThangPhanCa))
        //{

        //    xrl_TitleBC.Text = "LỊCH PHÂN CA THÁNG " + rp.ThangPhanCa;
        //}
        //else
        //{

        //    xrl_TitleBC.Text = "LỊCH PHÂN CA THÁNG ";
        //}
        
      //  DataSource = data;
        xrt_todoi.DataBindings.Add("Text", DataSource, "ToDoi");
        xrt_hovaten.DataBindings.Add("Text", DataSource, "TenCB");
        xrt_1.DataBindings.Add("Text", DataSource, "Ngay01");
        xrt_2.DataBindings.Add("Text", DataSource, "Ngay02");
        xrt_3.DataBindings.Add("Text", DataSource, "Ngay03");
        xrt_4.DataBindings.Add("Text", DataSource, "Ngay04");
        xrt_5.DataBindings.Add("Text", DataSource, "Ngay05");
        xrt_6.DataBindings.Add("Text", DataSource, "Ngay06");
        xrt_7.DataBindings.Add("Text", DataSource, "Ngay07");
        xrt_8.DataBindings.Add("Text", DataSource, "Ngay08");
        xrt_9.DataBindings.Add("Text", DataSource, "Ngay09");
        xrt_10.DataBindings.Add("Text", DataSource, "Ngay10");
        xrt_11.DataBindings.Add("Text", DataSource, "Ngay11");
        xrt_12.DataBindings.Add("Text", DataSource, "Ngay12");
        xrt_13.DataBindings.Add("Text", DataSource, "Ngay13");
        xrt_14.DataBindings.Add("Text", DataSource, "Ngay14");
        xrt_15.DataBindings.Add("Text", DataSource, "Ngay15");
        xrt_16.DataBindings.Add("Text", DataSource, "Ngay16");
        xrt_17.DataBindings.Add("Text", DataSource, "Ngay17");
        xrt_18.DataBindings.Add("Text", DataSource, "Ngay18");
        xrt_19.DataBindings.Add("Text", DataSource, "Ngay19");
        xrt_20.DataBindings.Add("Text", DataSource, "Ngay20");
        xrt_21.DataBindings.Add("Text", DataSource, "Ngay21");
        xrt_22.DataBindings.Add("Text", DataSource, "Ngay22");
        xrt_23.DataBindings.Add("Text", DataSource, "Ngay23");
        xrt_24.DataBindings.Add("Text", DataSource, "Ngay24");
        xrt_25.DataBindings.Add("Text", DataSource, "Ngay25");
        xrt_26.DataBindings.Add("Text", DataSource, "Ngay26");
        xrt_27.DataBindings.Add("Text", DataSource, "Ngay27");
        xrt_28.DataBindings.Add("Text", DataSource, "Ngay28");
        xrt_29.DataBindings.Add("Text", DataSource, "Ngay29");
        xrt_30.DataBindings.Add("Text", DataSource, "Ngay30");
        xrt_31.DataBindings.Add("Text", DataSource, "Ngay31");
        xrt_socong.DataBindings.Add("Text", DataSource, "SoCong");
        xrt_phep.DataBindings.Add("Text", DataSource, "NghiPhep");
        xrt_chedo.DataBindings.Add("Text", DataSource, "NghiCheDo");
        xrt_le.DataBindings.Add("Text", DataSource, "Nghile");
        // Thực thi thêm store để fill lên Sáng, chiều, hành chính
        // Sáng
        DataTable data1 = DataController.DataHandler.GetInstance().ExecuteDataTable("BangPhanCaThang_Sang", "@IDBangPhanCa", 1);

        s1.DataBindings.Add("Text", data1, "Ngay01"); s16.DataBindings.Add("Text", data1, "Ngay16");
        s2.DataBindings.Add("Text", data1, "Ngay02"); s17.DataBindings.Add("Text", data1, "Ngay17");
        s3.DataBindings.Add("Text", data1, "Ngay03"); s18.DataBindings.Add("Text", data1, "Ngay18");
        s4.DataBindings.Add("Text", data1, "Ngay04"); s19.DataBindings.Add("Text", data1, "Ngay19");
        s5.DataBindings.Add("Text", data1, "Ngay05"); s20.DataBindings.Add("Text", data1, "Ngay20");
        s6.DataBindings.Add("Text", data1, "Ngay06"); s21.DataBindings.Add("Text", data1, "Ngay21");
        s7.DataBindings.Add("Text", data1, "Ngay07"); s22.DataBindings.Add("Text", data1, "Ngay22");
        s8.DataBindings.Add("Text", data1, "Ngay08"); s23.DataBindings.Add("Text", data1, "Ngay23");
        s9.DataBindings.Add("Text", data1, "Ngay09"); s24.DataBindings.Add("Text", data1, "Ngay24");
        s10.DataBindings.Add("Text", data1, "Ngay10"); s25.DataBindings.Add("Text", data1, "Ngay25");
        s11.DataBindings.Add("Text", data1, "Ngay11"); s26.DataBindings.Add("Text", data1, "Ngay26");
        s12.DataBindings.Add("Text", data1, "Ngay12"); s27.DataBindings.Add("Text", data1, "Ngay27");
        s13.DataBindings.Add("Text", data1, "Ngay13"); s28.DataBindings.Add("Text", data1, "Ngay28");
        s14.DataBindings.Add("Text", data1, "Ngay14"); s29.DataBindings.Add("Text", data1, "Ngay29");
        s15.DataBindings.Add("Text", data1, "Ngay15"); s30.DataBindings.Add("Text", data1, "Ngay30"); s31.DataBindings.Add("Text", data1, "Ngay31");
        //Chiều
        DataTable datachieu = DataController.DataHandler.GetInstance().ExecuteDataTable("BangPhanCaThang_Chieu", "@IDBangPhanCa", 1);

        c1.DataBindings.Add("Text", datachieu, "Ngay01"); c16.DataBindings.Add("Text", datachieu, "Ngay16");
        c2.DataBindings.Add("Text", datachieu, "Ngay02"); c17.DataBindings.Add("Text", datachieu, "Ngay17");
        c3.DataBindings.Add("Text", datachieu, "Ngay03"); c18.DataBindings.Add("Text", datachieu, "Ngay18");
        c4.DataBindings.Add("Text", datachieu, "Ngay04"); c19.DataBindings.Add("Text", datachieu, "Ngay19");
        c5.DataBindings.Add("Text", datachieu, "Ngay05"); c20.DataBindings.Add("Text", datachieu, "Ngay20");
        c6.DataBindings.Add("Text", datachieu, "Ngay06"); c21.DataBindings.Add("Text", datachieu, "Ngay21");
        c7.DataBindings.Add("Text", datachieu, "Ngay07"); c22.DataBindings.Add("Text", datachieu, "Ngay22");
        c8.DataBindings.Add("Text", datachieu, "Ngay08"); c23.DataBindings.Add("Text", datachieu, "Ngay23");
        c9.DataBindings.Add("Text", datachieu, "Ngay09"); c24.DataBindings.Add("Text", datachieu, "Ngay24");
        c10.DataBindings.Add("Text", datachieu, "Ngay10"); c25.DataBindings.Add("Text", datachieu, "Ngay25");
        c11.DataBindings.Add("Text", datachieu, "Ngay11"); c26.DataBindings.Add("Text", datachieu, "Ngay26");
        c12.DataBindings.Add("Text", datachieu, "Ngay12"); c27.DataBindings.Add("Text", datachieu, "Ngay27");
        c13.DataBindings.Add("Text", datachieu, "Ngay13"); c28.DataBindings.Add("Text", datachieu, "Ngay28");
        c14.DataBindings.Add("Text", datachieu, "Ngay14"); c29.DataBindings.Add("Text", datachieu, "Ngay29");
        c15.DataBindings.Add("Text", datachieu, "Ngay15"); c30.DataBindings.Add("Text", datachieu, "Ngay30"); c31.DataBindings.Add("Text", datachieu, "Ngay31");
        // hành chính
        DataTable datahanhchinh = DataController.DataHandler.GetInstance().ExecuteDataTable("BangPhanCaThang_HanhChinh", "@IDBangPhanCa", 1);
        hc1.DataBindings.Add("Text", datahanhchinh, "Ngay01"); hc16.DataBindings.Add("Text", datahanhchinh, "Ngay16");
        hc2.DataBindings.Add("Text", datahanhchinh, "Ngay02"); hc17.DataBindings.Add("Text", datahanhchinh, "Ngay17");
        hc3.DataBindings.Add("Text", datahanhchinh, "Ngay03"); hc18.DataBindings.Add("Text", datahanhchinh, "Ngay18");
        hc4.DataBindings.Add("Text", datahanhchinh, "Ngay04"); hc19.DataBindings.Add("Text", datahanhchinh, "Ngay19");
        hc5.DataBindings.Add("Text", datahanhchinh, "Ngay05"); hc20.DataBindings.Add("Text", datahanhchinh, "Ngay20");
        hc6.DataBindings.Add("Text", datahanhchinh, "Ngay06"); hc21.DataBindings.Add("Text", datahanhchinh, "Ngay21");
        hc7.DataBindings.Add("Text", datahanhchinh, "Ngay07"); hc22.DataBindings.Add("Text", datahanhchinh, "Ngay22");
        hc8.DataBindings.Add("Text", datahanhchinh, "Ngay08"); hc23.DataBindings.Add("Text", datahanhchinh, "Ngay23");
        hc9.DataBindings.Add("Text", datahanhchinh, "Ngay09"); hc24.DataBindings.Add("Text", datahanhchinh, "Ngay24");
        hc10.DataBindings.Add("Text", datahanhchinh, "Ngay10"); hc25.DataBindings.Add("Text", datahanhchinh, "Ngay25");
        hc11.DataBindings.Add("Text", datahanhchinh, "Ngay11"); hc26.DataBindings.Add("Text", datahanhchinh, "Ngay26");
        hc12.DataBindings.Add("Text", datahanhchinh, "Ngay12"); hc27.DataBindings.Add("Text", datahanhchinh, "Ngay27");
        hc13.DataBindings.Add("Text", datahanhchinh, "Ngay13"); hc28.DataBindings.Add("Text", datahanhchinh, "Ngay28");
        hc14.DataBindings.Add("Text", datahanhchinh, "Ngay14"); hc29.DataBindings.Add("Text", datahanhchinh, "Ngay29");
        hc15.DataBindings.Add("Text", datahanhchinh, "Ngay15"); hc30.DataBindings.Add("Text", datahanhchinh, "Ngay30"); hc31.DataBindings.Add("Text", datahanhchinh, "Ngay31");
        //
        FindDayOfWeek(rp);

        //if (!string.IsNullOrEmpty(rp.TenBaoCao))
        //{
        //    xrl_TitleBC.Text = rp.TenBaoCao.ToUpper();
        //}
        //if (!string.IsNullOrEmpty(rp.Footer1))
        //{
        //    xrl_footer1.Text = rp.Footer1;
        //}
        //if (!string.IsNullOrEmpty(rp.Footer2))
        //{
        //    xrl_footer2.Text = rp.Footer2;
        //}
        //if (!string.IsNullOrEmpty(rp.Footer3))
        //{
        //    xrl_footer3.Text = rp.Footer3;
        //}

        //if (!string.IsNullOrEmpty(rp.Ten1))
        //{
        //    xrl_ten1.Text = rp.Ten1;
        //}
        //else
        //{
        //    xrl_ten1.Text = rp.NguoiLapBaoCao.ToString();
        //}

        //if (!string.IsNullOrEmpty(rp.Ten2))
        //{
        //    xrl_ten2.Text = rp.Ten2;
        //}
        //if (!string.IsNullOrEmpty(rp.Ten3))
        //{
        //    xrl_ten3.Text = rp.Ten3;
        //}
    }
    private void FindDayOfWeek(ReportFilter rp)
    {
        //int year = Convert.ToInt32(rp.nam_chamcong);
        //int month = Convert.ToInt32(rp.thang);
        //int totalDay = DateTime.DaysInMonth(year, month);//tổng số ngày trong tháng 

        //DevExpress.XtraReports.UI.XRTableCell h = new XRTableCell();
        //for (int i = 1; i <= totalDay; i++)
        //{
        //    h = GetControlByName("h" + i);
        //    h.Text = GetVietnameseDayOfWeek(new DateTime(year, month, i).DayOfWeek.ToString()).ToString();
        //}
    }
    DevExpress.XtraReports.UI.XRTableCell GetControlByName(string Name)
    {
        foreach (DevExpress.XtraReports.UI.XRTableCell c in this.xrTableRow6.Cells)
            if (c.Name == Name)
                return c;

        return null;
    }
    private string GetVietnameseDayOfWeek(string dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case "Monday":
                return "2";
            case "Tuesday":
                return "3";
            case "Wednesday":
                return "4";
            case "Thursday":
                return "5";
            case "Friday":
                return "6";
            case "Saturday":
                return "7";
            case "Sunday":
                return "CN";
            default:
                return "";
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
        string resourceFileName = "rp_LichPhanCaThang.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_hovaten = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_socong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_phep = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_chedo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.h31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrt_le = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell231 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell233 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.hc31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell265 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell266 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell267 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell268 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell269 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell192 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell194 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.c31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell226 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell227 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell228 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell229 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell230 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell153 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.s31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell187 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell188 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell189 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell190 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell191 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell154 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell193 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrt_todoi = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable5
        // 
        this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable5.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
        this.xrTable5.SizeF = new System.Drawing.SizeF(1605F, 25F);
        this.xrTable5.StylePriority.UseBorders = false;
        this.xrTable5.StylePriority.UseFont = false;
        this.xrTable5.StylePriority.UseTextAlignment = false;
        this.xrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_hovaten,
            this.xrTableCell80,
            this.xrt_1,
            this.xrt_2,
            this.xrt_3,
            this.xrt_4,
            this.xrt_5,
            this.xrt_6,
            this.xrt_7,
            this.xrt_8,
            this.xrt_9,
            this.xrt_10,
            this.xrt_11,
            this.xrt_12,
            this.xrt_13,
            this.xrt_14,
            this.xrt_15,
            this.xrt_16,
            this.xrt_17,
            this.xrt_18,
            this.xrt_19,
            this.xrt_20,
            this.xrt_21,
            this.xrt_22,
            this.xrt_23,
            this.xrt_24,
            this.xrt_25,
            this.xrt_26,
            this.xrt_27,
            this.xrt_28,
            this.xrt_29,
            this.xrt_30,
            this.xrt_31,
            this.xrt_socong,
            this.xrt_phep,
            this.xrt_chedo,
            this.xrTableCell113,
            this.xrTableCell77});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrt_stt
        // 
        this.xrt_stt.Name = "xrt_stt";
        this.xrt_stt.Weight = 0.0658098737770152D;
        this.xrt_stt.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
        // 
        // xrt_hovaten
        // 
        this.xrt_hovaten.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_hovaten.Name = "xrt_hovaten";
        this.xrt_hovaten.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrt_hovaten.StylePriority.UseBorders = false;
        this.xrt_hovaten.StylePriority.UsePadding = false;
        this.xrt_hovaten.StylePriority.UseTextAlignment = false;
        this.xrt_hovaten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrt_hovaten.Weight = 0.24123831775700932D;
        // 
        // xrTableCell80
        // 
        this.xrTableCell80.Name = "xrTableCell80";
        this.xrTableCell80.Weight = 0.065347603771174073D;
        // 
        // xrt_1
        // 
        this.xrt_1.Name = "xrt_1";
        this.xrt_1.Weight = 0.065347544946403144D;
        // 
        // xrt_2
        // 
        this.xrt_2.Name = "xrt_2";
        this.xrt_2.Weight = 0.056058507544972075D;
        // 
        // xrt_3
        // 
        this.xrt_3.Name = "xrt_3";
        this.xrt_3.Weight = 0.056058457633045206D;
        // 
        // xrt_4
        // 
        this.xrt_4.Name = "xrt_4";
        this.xrt_4.Weight = 0.06189974758112541D;
        // 
        // xrt_5
        // 
        this.xrt_5.Name = "xrt_5";
        this.xrt_5.Weight = 0.0716349107082759D;
        // 
        // xrt_6
        // 
        this.xrt_6.Name = "xrt_6";
        this.xrt_6.Weight = 0.063846739207472761D;
        // 
        // xrt_7
        // 
        this.xrt_7.Name = "xrt_7";
        this.xrt_7.Weight = 0.069687884321836646D;
        // 
        // xrt_8
        // 
        this.xrt_8.Name = "xrt_8";
        this.xrt_8.Weight = 0.06579355792464496D;
        // 
        // xrt_9
        // 
        this.xrt_9.Name = "xrt_9";
        this.xrt_9.Weight = 0.078692968315053208D;
        // 
        // xrt_10
        // 
        this.xrt_10.Name = "xrt_10";
        this.xrt_10.Weight = 0.061169319063703577D;
        // 
        // xrt_11
        // 
        this.xrt_11.Name = "xrt_11";
        this.xrt_11.Weight = 0.076746061583545716D;
        // 
        // xrt_12
        // 
        this.xrt_12.Name = "xrt_12";
        this.xrt_12.Weight = 0.070499027778055071D;
        // 
        // xrt_13
        // 
        this.xrt_13.Name = "xrt_13";
        this.xrt_13.Weight = 0.064658006329402773D;
        // 
        // xrt_14
        // 
        this.xrt_14.Name = "xrt_14";
        this.xrt_14.Weight = 0.070904819096360316D;
        // 
        // xrt_15
        // 
        this.xrt_15.Name = "xrt_15";
        this.xrt_15.Weight = 0.070904594492689432D;
        // 
        // xrt_16
        // 
        this.xrt_16.Name = "xrt_16";
        this.xrt_16.Weight = 0.074798867412816716D;
        // 
        // xrt_17
        // 
        this.xrt_17.Name = "xrt_17";
        this.xrt_17.Weight = 0.063816190880035678D;
        // 
        // xrt_18
        // 
        this.xrt_18.Name = "xrt_18";
        this.xrt_18.Weight = 0.0716046195163905D;
        // 
        // xrt_19
        // 
        this.xrt_19.Name = "xrt_19";
        this.xrt_19.Weight = 0.069657313043826108D;
        // 
        // xrt_20
        // 
        this.xrt_20.Name = "xrt_20";
        this.xrt_20.Weight = 0.069657427239640843D;
        // 
        // xrt_21
        // 
        this.xrt_21.Name = "xrt_21";
        this.xrt_21.Weight = 0.071604505821923209D;
        // 
        // xrt_22
        // 
        this.xrt_22.Name = "xrt_22";
        this.xrt_22.Weight = 0.069657541407602941D;
        // 
        // xrt_23
        // 
        this.xrt_23.Name = "xrt_23";
        this.xrt_23.Weight = 0.071604163610489546D;
        // 
        // xrt_24
        // 
        this.xrt_24.Name = "xrt_24";
        this.xrt_24.Weight = 0.071604619948106379D;
        // 
        // xrt_25
        // 
        this.xrt_25.Name = "xrt_25";
        this.xrt_25.Weight = 0.063380275262850561D;
        // 
        // xrt_26
        // 
        this.xrt_26.Name = "xrt_26";
        this.xrt_26.Weight = 0.073115325642523266D;
        // 
        // xrt_27
        // 
        this.xrt_27.Name = "xrt_27";
        this.xrt_27.Weight = 0.06922116858936922D;
        // 
        // xrt_28
        // 
        this.xrt_28.Name = "xrt_28";
        this.xrt_28.Weight = 0.074525294794100472D;
        // 
        // xrt_29
        // 
        this.xrt_29.Name = "xrt_29";
        this.xrt_29.Weight = 0.070227393034462571D;
        // 
        // xrt_30
        // 
        this.xrt_30.Name = "xrt_30";
        this.xrt_30.Weight = 0.070228077540887779D;
        // 
        // xrt_31
        // 
        this.xrt_31.Name = "xrt_31";
        this.xrt_31.Weight = 0.076203362295560767D;
        // 
        // xrt_socong
        // 
        this.xrt_socong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrt_socong.Name = "xrt_socong";
        this.xrt_socong.StylePriority.UseBorders = false;
        this.xrt_socong.Weight = 0.096118449273510487D;
        // 
        // xrt_phep
        // 
        this.xrt_phep.Name = "xrt_phep";
        this.xrt_phep.Weight = 0.0774710967161945D;
        // 
        // xrt_chedo
        // 
        this.xrt_chedo.Name = "xrt_chedo";
        this.xrt_chedo.Weight = 0.077470155519859793D;
        // 
        // xrTableCell113
        // 
        this.xrTableCell113.Name = "xrTableCell113";
        this.xrTableCell113.Weight = 0.077470854286835561D;
        // 
        // xrTableCell77
        // 
        this.xrTableCell77.Name = "xrTableCell77";
        this.xrTableCell77.Weight = 0.16426535633122805D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 50F;
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
        this.PageHeader.HeightF = 53.125F;
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
        this.xrTable1.SizeF = new System.Drawing.SizeF(1605F, 53.125F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell1});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "STT";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.065809897796337891D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.Text = "Họ và tên";
        this.xrTableCell5.Weight = 0.24123834561173163D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable3});
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "xrTableCell1";
        this.xrTableCell1.Weight = 2.6929517565919303D;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow6});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1177.083F, 53.125F);
        this.xrTable2.StylePriority.UseBorders = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell10,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell12,
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell3,
            this.xrTableCell16,
            this.xrTableCell15,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell14,
            this.xrTableCell20,
            this.xrTableCell19,
            this.xrTableCell21,
            this.xrTableCell29,
            this.xrTableCell24,
            this.xrTableCell28,
            this.xrTableCell23,
            this.xrTableCell27,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell22,
            this.xrTableCell31,
            this.xrTableCell30,
            this.xrTableCell32,
            this.xrTableCell6,
            this.xrTableCell35,
            this.xrTableCell34,
            this.xrTableCell33});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = "Ngày";
        this.xrTableCell2.Weight = 0.13515097817163532D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = "1";
        this.xrTableCell10.Weight = 0.13515097817163532D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = "2";
        this.xrTableCell8.Weight = 0.11593964335531762D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "3";
        this.xrTableCell9.Weight = 0.11593952538132418D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "4";
        this.xrTableCell7.Weight = 0.1280201802811152D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Text = "5";
        this.xrTableCell12.Weight = 0.14815444781544226D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "6";
        this.xrTableCell11.Weight = 0.13204698659838321D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Text = "7";
        this.xrTableCell13.Weight = 0.14412764149817425D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "8";
        this.xrTableCell3.Weight = 0.13607367494165787D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Text = "9";
        this.xrTableCell16.Weight = 0.16275173778481761D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "10";
        this.xrTableCell15.Weight = 0.12650989064586107D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Text = "11";
        this.xrTableCell17.Weight = 0.15872505047550359D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Text = "12";
        this.xrTableCell18.Weight = 0.14580524693104102D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Text = "13";
        this.xrTableCell14.Weight = 0.1337249459532302D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Text = "14";
        this.xrTableCell20.Weight = 0.14664427925603935D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.Text = "15";
        this.xrTableCell19.Weight = 0.14664427925603946D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Text = "16";
        this.xrTableCell21.Weight = 0.15469789189057537D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.Text = "17";
        this.xrTableCell29.Weight = 0.1319838827739373D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Text = "18";
        this.xrTableCell24.Weight = 0.14809181588697007D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.Text = "19";
        this.xrTableCell28.Weight = 0.14406441969973488D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Text = "20";
        this.xrTableCell23.Weight = 0.14406465564772175D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.Text = "21";
        this.xrTableCell27.Weight = 0.1480915799389832D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Text = "22";
        this.xrTableCell25.Weight = 0.14406465564772175D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Text = "23";
        this.xrTableCell26.Weight = 0.14809110804300948D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Text = "24";
        this.xrTableCell22.Weight = 0.14809181588697D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.Text = "25";
        this.xrTableCell31.Weight = 0.13108231651332583D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.Text = "26";
        this.xrTableCell30.Weight = 0.1512162301256727D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.Text = "27";
        this.xrTableCell32.Weight = 0.14316286818587271D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "28";
        this.xrTableCell6.Weight = 0.1541320843498688D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.Text = "29";
        this.xrTableCell35.Weight = 0.14524391569135359D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.Text = "30";
        this.xrTableCell34.Weight = 0.14524457929506657D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.Text = "31";
        this.xrTableCell33.Weight = 0.15760242658840604D;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell39,
            this.h1,
            this.h2,
            this.h3,
            this.h4,
            this.h5,
            this.h6,
            this.h7,
            this.h8,
            this.h9,
            this.h10,
            this.h11,
            this.h12,
            this.h13,
            this.h14,
            this.h15,
            this.h16,
            this.h17,
            this.h18,
            this.h19,
            this.h20,
            this.h21,
            this.h22,
            this.h23,
            this.h24,
            this.h25,
            this.h26,
            this.h27,
            this.h28,
            this.h29,
            this.h30,
            this.h31});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.Text = "Thứ";
        this.xrTableCell39.Weight = 0.13515097817163532D;
        // 
        // h1
        // 
        this.h1.Name = "h1";
        this.h1.Weight = 0.13515097817163532D;
        // 
        // h2
        // 
        this.h2.Name = "h2";
        this.h2.Weight = 0.11593964335531762D;
        // 
        // h3
        // 
        this.h3.Name = "h3";
        this.h3.Weight = 0.11593952538132418D;
        // 
        // h4
        // 
        this.h4.Name = "h4";
        this.h4.Weight = 0.1280201802811152D;
        // 
        // h5
        // 
        this.h5.Name = "h5";
        this.h5.Weight = 0.14815444781544226D;
        // 
        // h6
        // 
        this.h6.Name = "h6";
        this.h6.Weight = 0.13204698659838321D;
        // 
        // h7
        // 
        this.h7.Name = "h7";
        this.h7.Weight = 0.14412764149817425D;
        // 
        // h8
        // 
        this.h8.Name = "h8";
        this.h8.Weight = 0.13607367494165787D;
        // 
        // h9
        // 
        this.h9.Name = "h9";
        this.h9.Weight = 0.16275173778481761D;
        // 
        // h10
        // 
        this.h10.Name = "h10";
        this.h10.Weight = 0.12650989064586107D;
        // 
        // h11
        // 
        this.h11.Name = "h11";
        this.h11.Weight = 0.15872505047550359D;
        // 
        // h12
        // 
        this.h12.Name = "h12";
        this.h12.Weight = 0.14580524693104102D;
        // 
        // h13
        // 
        this.h13.Name = "h13";
        this.h13.Weight = 0.1337249459532302D;
        // 
        // h14
        // 
        this.h14.Name = "h14";
        this.h14.Weight = 0.14664427925603935D;
        // 
        // h15
        // 
        this.h15.Name = "h15";
        this.h15.Weight = 0.14664427925603946D;
        // 
        // h16
        // 
        this.h16.Name = "h16";
        this.h16.Weight = 0.15469789189057537D;
        // 
        // h17
        // 
        this.h17.Name = "h17";
        this.h17.Weight = 0.1319838827739373D;
        // 
        // h18
        // 
        this.h18.Name = "h18";
        this.h18.Weight = 0.14809181588697007D;
        // 
        // h19
        // 
        this.h19.Name = "h19";
        this.h19.Weight = 0.14406441969973488D;
        // 
        // h20
        // 
        this.h20.Name = "h20";
        this.h20.Weight = 0.14406465564772175D;
        // 
        // h21
        // 
        this.h21.Name = "h21";
        this.h21.Weight = 0.1480915799389832D;
        // 
        // h22
        // 
        this.h22.Name = "h22";
        this.h22.Weight = 0.14406465564772175D;
        // 
        // h23
        // 
        this.h23.Name = "h23";
        this.h23.Weight = 0.14809110804300948D;
        // 
        // h24
        // 
        this.h24.Name = "h24";
        this.h24.Weight = 0.14809181588697D;
        // 
        // h25
        // 
        this.h25.Name = "h25";
        this.h25.Weight = 0.13108231651332583D;
        // 
        // h26
        // 
        this.h26.Name = "h26";
        this.h26.Weight = 0.1512162301256727D;
        // 
        // h27
        // 
        this.h27.Name = "h27";
        this.h27.Weight = 0.14316286818587271D;
        // 
        // h28
        // 
        this.h28.Name = "h28";
        this.h28.Weight = 0.1541320843498688D;
        // 
        // h29
        // 
        this.h29.Name = "h29";
        this.h29.Weight = 0.14524391569135359D;
        // 
        // h30
        // 
        this.h30.Name = "h30";
        this.h30.Weight = 0.14524457929506657D;
        // 
        // h31
        // 
        this.h31.Name = "h31";
        this.h31.Weight = 0.15760242658840604D;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(1177.083F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(263.6456F, 53.125F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTableCell38});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell36.Multiline = true;
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.Text = "Số \r\ncông";
        this.xrTableCell36.Weight = 0.58514299455732866D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Text = "xrTableCell37";
        this.xrTableCell37.Weight = 1.4148570054426712D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4,
            this.xrTableRow5});
        this.xrTable4.SizeF = new System.Drawing.SizeF(124.3405F, 53.125F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell41
        // 
        this.xrTableCell41.Multiline = true;
        this.xrTableCell41.Name = "xrTableCell41";
        this.xrTableCell41.Text = "Các ngày nghỉ";
        this.xrTableCell41.Weight = 3D;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrt_le});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell42
        // 
        this.xrTableCell42.Name = "xrTableCell42";
        this.xrTableCell42.Text = "F";
        this.xrTableCell42.Weight = 1D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Name = "xrTableCell43";
        this.xrTableCell43.Text = "CĐ";
        this.xrTableCell43.Weight = 1D;
        // 
        // xrt_le
        // 
        this.xrt_le.Name = "xrt_le";
        this.xrt_le.Text = "Lễ";
        this.xrt_le.Weight = 1D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Multiline = true;
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.Text = "Ký\r\nXác nhận";
        this.xrTableCell38.Weight = 1D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten3,
            this.xrl_ten2,
            this.xrl_ten1,
            this.xrtngayketxuat,
            this.xrl_footer1,
            this.xrl_footer3,
            this.xrl_footer2,
            this.xrTable9,
            this.xrTable8,
            this.xrTable7,
            this.xrLabel9,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel11,
            this.xrLabel12,
            this.xrTable10,
            this.xrLabel10,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel24});
        this.ReportFooter.HeightF = 455F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrl_ten3
        // 
        this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1180.171F, 406.25F);
        this.xrl_ten3.Name = "xrl_ten3";
        this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten3.SizeF = new System.Drawing.SizeF(295.4998F, 23F);
        this.xrl_ten3.StylePriority.UseFont = false;
        this.xrl_ten3.StylePriority.UseTextAlignment = false;
        this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten2
        // 
        this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(625.8593F, 406.25F);
        this.xrl_ten2.Name = "xrl_ten2";
        this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
        this.xrl_ten2.StylePriority.UseFont = false;
        this.xrl_ten2.StylePriority.UseTextAlignment = false;
        this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_ten1
        // 
        this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(77.70074F, 406.25F);
        this.xrl_ten1.Name = "xrl_ten1";
        this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
        this.xrl_ten1.StylePriority.UseFont = false;
        this.xrl_ten1.StylePriority.UseTextAlignment = false;
        this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1180.171F, 268.75F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(295.4998F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
        this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer1
        // 
        this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(77.70074F, 293.75F);
        this.xrl_footer1.Name = "xrl_footer1";
        this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer1.StylePriority.UseFont = false;
        this.xrl_footer1.StylePriority.UseTextAlignment = false;
        this.xrl_footer1.Text = "NGƯỜI LẬP";
        this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer3
        // 
        this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1180.171F, 293.75F);
        this.xrl_footer3.Name = "xrl_footer3";
        this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer3.SizeF = new System.Drawing.SizeF(295.5F, 23F);
        this.xrl_footer3.StylePriority.UseFont = false;
        this.xrl_footer3.StylePriority.UseTextAlignment = false;
        this.xrl_footer3.Text = "GIÁM ĐỐC";
        this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_footer2
        // 
        this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(625.8593F, 293.75F);
        this.xrl_footer2.Name = "xrl_footer2";
        this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
        this.xrl_footer2.StylePriority.UseFont = false;
        this.xrl_footer2.StylePriority.UseTextAlignment = false;
        this.xrl_footer2.Text = "PHÒNG TCHC";
        this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTable9
        // 
        this.xrTable9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 76.04166F);
        this.xrTable9.Name = "xrTable9";
        this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
        this.xrTable9.SizeF = new System.Drawing.SizeF(1605F, 25F);
        this.xrTable9.StylePriority.UseBorders = false;
        this.xrTable9.StylePriority.UseFont = false;
        this.xrTable9.StylePriority.UseTextAlignment = false;
        this.xrTable9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell231,
            this.xrTableCell233,
            this.hc1,
            this.hc2,
            this.hc3,
            this.hc4,
            this.hc5,
            this.hc6,
            this.hc7,
            this.hc8,
            this.hc9,
            this.hc10,
            this.hc11,
            this.hc12,
            this.hc13,
            this.hc14,
            this.hc15,
            this.hc16,
            this.hc17,
            this.hc18,
            this.hc19,
            this.hc20,
            this.hc21,
            this.hc22,
            this.hc23,
            this.hc24,
            this.hc25,
            this.hc26,
            this.hc27,
            this.hc28,
            this.hc29,
            this.hc30,
            this.hc31,
            this.xrTableCell265,
            this.xrTableCell266,
            this.xrTableCell267,
            this.xrTableCell268,
            this.xrTableCell269});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell231
        // 
        this.xrTableCell231.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableCell231.Name = "xrTableCell231";
        this.xrTableCell231.StylePriority.UseFont = false;
        this.xrTableCell231.StylePriority.UseTextAlignment = false;
        this.xrTableCell231.Text = "3";
        this.xrTableCell231.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell231.Weight = 0.0658098737770152D;
        // 
        // xrTableCell233
        // 
        this.xrTableCell233.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell233.Name = "xrTableCell233";
        this.xrTableCell233.StylePriority.UseFont = false;
        this.xrTableCell233.StylePriority.UseTextAlignment = false;
        this.xrTableCell233.Text = "HÀNH CHÍNH";
        this.xrTableCell233.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell233.Weight = 0.30658583596488026D;
        // 
        // hc1
        // 
        this.hc1.Name = "hc1";
        this.hc1.Weight = 0.0653476305097063D;
        // 
        // hc2
        // 
        this.hc2.Name = "hc2";
        this.hc2.Weight = 0.056058507544972075D;
        // 
        // hc3
        // 
        this.hc3.Name = "hc3";
        this.hc3.Weight = 0.056058457633045206D;
        // 
        // hc4
        // 
        this.hc4.Name = "hc4";
        this.hc4.Weight = 0.06189974758112541D;
        // 
        // hc5
        // 
        this.hc5.Name = "hc5";
        this.hc5.Weight = 0.0716349107082759D;
        // 
        // hc6
        // 
        this.hc6.Name = "hc6";
        this.hc6.Weight = 0.063846739207472761D;
        // 
        // hc7
        // 
        this.hc7.Name = "hc7";
        this.hc7.Weight = 0.069687884321836646D;
        // 
        // hc8
        // 
        this.hc8.Name = "hc8";
        this.hc8.Weight = 0.06579355792464496D;
        // 
        // hc9
        // 
        this.hc9.Name = "hc9";
        this.hc9.Weight = 0.078692968315053208D;
        // 
        // hc10
        // 
        this.hc10.Name = "hc10";
        this.hc10.Weight = 0.061169319063703577D;
        // 
        // hc11
        // 
        this.hc11.Name = "hc11";
        this.hc11.Weight = 0.076746061583545716D;
        // 
        // hc12
        // 
        this.hc12.Name = "hc12";
        this.hc12.Weight = 0.070499027778055071D;
        // 
        // hc13
        // 
        this.hc13.Name = "hc13";
        this.hc13.Weight = 0.064658006329402773D;
        // 
        // hc14
        // 
        this.hc14.Name = "hc14";
        this.hc14.Weight = 0.070904819096360316D;
        // 
        // hc15
        // 
        this.hc15.Name = "hc15";
        this.hc15.Weight = 0.070904594492689432D;
        // 
        // hc16
        // 
        this.hc16.Name = "hc16";
        this.hc16.Weight = 0.074798867412816716D;
        // 
        // hc17
        // 
        this.hc17.Name = "hc17";
        this.hc17.Weight = 0.063816190880035678D;
        // 
        // hc18
        // 
        this.hc18.Name = "hc18";
        this.hc18.Weight = 0.0716046195163905D;
        // 
        // hc19
        // 
        this.hc19.Name = "hc19";
        this.hc19.Weight = 0.069657313043826108D;
        // 
        // hc20
        // 
        this.hc20.Name = "hc20";
        this.hc20.Weight = 0.069657427239640843D;
        // 
        // hc21
        // 
        this.hc21.Name = "hc21";
        this.hc21.Weight = 0.071604505821923209D;
        // 
        // hc22
        // 
        this.hc22.Name = "hc22";
        this.hc22.Weight = 0.069657541407602941D;
        // 
        // hc23
        // 
        this.hc23.Name = "hc23";
        this.hc23.Weight = 0.071604163610489546D;
        // 
        // hc24
        // 
        this.hc24.Name = "hc24";
        this.hc24.Weight = 0.071604619948106379D;
        // 
        // hc25
        // 
        this.hc25.Name = "hc25";
        this.hc25.Weight = 0.063380275262850561D;
        // 
        // hc26
        // 
        this.hc26.Name = "hc26";
        this.hc26.Weight = 0.073115325642523266D;
        // 
        // hc27
        // 
        this.hc27.Name = "hc27";
        this.hc27.Weight = 0.06922116858936922D;
        // 
        // hc28
        // 
        this.hc28.Name = "hc28";
        this.hc28.Weight = 0.074525294794100472D;
        // 
        // hc29
        // 
        this.hc29.Name = "hc29";
        this.hc29.Weight = 0.070227393034462571D;
        // 
        // hc30
        // 
        this.hc30.Name = "hc30";
        this.hc30.Weight = 0.070228077540887779D;
        // 
        // hc31
        // 
        this.hc31.Name = "hc31";
        this.hc31.Weight = 0.076203362295560767D;
        // 
        // xrTableCell265
        // 
        this.xrTableCell265.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell265.Name = "xrTableCell265";
        this.xrTableCell265.StylePriority.UseBorders = false;
        this.xrTableCell265.Weight = 0.096118449273510487D;
        // 
        // xrTableCell266
        // 
        this.xrTableCell266.Name = "xrTableCell266";
        this.xrTableCell266.Weight = 0.0774710967161945D;
        // 
        // xrTableCell267
        // 
        this.xrTableCell267.Name = "xrTableCell267";
        this.xrTableCell267.Weight = 0.077470155519859793D;
        // 
        // xrTableCell268
        // 
        this.xrTableCell268.Name = "xrTableCell268";
        this.xrTableCell268.Weight = 0.077470854286835561D;
        // 
        // xrTableCell269
        // 
        this.xrTableCell269.Name = "xrTableCell269";
        this.xrTableCell269.Weight = 0.16426535633122805D;
        // 
        // xrTable8
        // 
        this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 51.04167F);
        this.xrTable8.Name = "xrTable8";
        this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
        this.xrTable8.SizeF = new System.Drawing.SizeF(1605F, 25F);
        this.xrTable8.StylePriority.UseBorders = false;
        this.xrTable8.StylePriority.UseFont = false;
        this.xrTable8.StylePriority.UseTextAlignment = false;
        this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell192,
            this.xrTableCell194,
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.c6,
            this.c7,
            this.c8,
            this.c9,
            this.c10,
            this.c11,
            this.c12,
            this.c13,
            this.c14,
            this.c15,
            this.c16,
            this.c17,
            this.c18,
            this.c19,
            this.c20,
            this.c21,
            this.c22,
            this.c23,
            this.c24,
            this.c25,
            this.c26,
            this.c27,
            this.c28,
            this.c29,
            this.c30,
            this.c31,
            this.xrTableCell226,
            this.xrTableCell227,
            this.xrTableCell228,
            this.xrTableCell229,
            this.xrTableCell230});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell192
        // 
        this.xrTableCell192.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableCell192.Name = "xrTableCell192";
        this.xrTableCell192.StylePriority.UseFont = false;
        this.xrTableCell192.StylePriority.UseTextAlignment = false;
        this.xrTableCell192.Text = "2";
        this.xrTableCell192.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell192.Weight = 0.0658098737770152D;
        // 
        // xrTableCell194
        // 
        this.xrTableCell194.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell194.Name = "xrTableCell194";
        this.xrTableCell194.StylePriority.UseFont = false;
        this.xrTableCell194.StylePriority.UseTextAlignment = false;
        this.xrTableCell194.Text = "CHIỀU";
        this.xrTableCell194.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell194.Weight = 0.30658583596488026D;
        // 
        // c1
        // 
        this.c1.Name = "c1";
        this.c1.Weight = 0.0653476305097063D;
        // 
        // c2
        // 
        this.c2.Name = "c2";
        this.c2.Weight = 0.056058507544972075D;
        // 
        // c3
        // 
        this.c3.Name = "c3";
        this.c3.Weight = 0.056058457633045206D;
        // 
        // c4
        // 
        this.c4.Name = "c4";
        this.c4.Weight = 0.06189974758112541D;
        // 
        // c5
        // 
        this.c5.Name = "c5";
        this.c5.Weight = 0.0716349107082759D;
        // 
        // c6
        // 
        this.c6.Name = "c6";
        this.c6.Weight = 0.063846739207472761D;
        // 
        // c7
        // 
        this.c7.Name = "c7";
        this.c7.Weight = 0.069687884321836646D;
        // 
        // c8
        // 
        this.c8.Name = "c8";
        this.c8.Weight = 0.06579355792464496D;
        // 
        // c9
        // 
        this.c9.Name = "c9";
        this.c9.Weight = 0.078692968315053208D;
        // 
        // c10
        // 
        this.c10.Name = "c10";
        this.c10.Weight = 0.061169319063703577D;
        // 
        // c11
        // 
        this.c11.Name = "c11";
        this.c11.Weight = 0.076746061583545716D;
        // 
        // c12
        // 
        this.c12.Name = "c12";
        this.c12.Weight = 0.070499027778055071D;
        // 
        // c13
        // 
        this.c13.Name = "c13";
        this.c13.Weight = 0.064658006329402773D;
        // 
        // c14
        // 
        this.c14.Name = "c14";
        this.c14.Weight = 0.070904819096360316D;
        // 
        // c15
        // 
        this.c15.Name = "c15";
        this.c15.Weight = 0.070904594492689432D;
        // 
        // c16
        // 
        this.c16.Name = "c16";
        this.c16.Weight = 0.074798867412816716D;
        // 
        // c17
        // 
        this.c17.Name = "c17";
        this.c17.Weight = 0.063816190880035678D;
        // 
        // c18
        // 
        this.c18.Name = "c18";
        this.c18.Weight = 0.0716046195163905D;
        // 
        // c19
        // 
        this.c19.Name = "c19";
        this.c19.Weight = 0.069657313043826108D;
        // 
        // c20
        // 
        this.c20.Name = "c20";
        this.c20.Weight = 0.069657427239640843D;
        // 
        // c21
        // 
        this.c21.Name = "c21";
        this.c21.Weight = 0.071604505821923209D;
        // 
        // c22
        // 
        this.c22.Name = "c22";
        this.c22.Weight = 0.069657541407602941D;
        // 
        // c23
        // 
        this.c23.Name = "c23";
        this.c23.Weight = 0.071604163610489546D;
        // 
        // c24
        // 
        this.c24.Name = "c24";
        this.c24.Weight = 0.071604619948106379D;
        // 
        // c25
        // 
        this.c25.Name = "c25";
        this.c25.Weight = 0.063380275262850561D;
        // 
        // c26
        // 
        this.c26.Name = "c26";
        this.c26.Weight = 0.073115325642523266D;
        // 
        // c27
        // 
        this.c27.Name = "c27";
        this.c27.Weight = 0.06922116858936922D;
        // 
        // c28
        // 
        this.c28.Name = "c28";
        this.c28.Weight = 0.074525294794100472D;
        // 
        // c29
        // 
        this.c29.Name = "c29";
        this.c29.Weight = 0.070227393034462571D;
        // 
        // c30
        // 
        this.c30.Name = "c30";
        this.c30.Weight = 0.070228077540887779D;
        // 
        // c31
        // 
        this.c31.Name = "c31";
        this.c31.Weight = 0.076203362295560767D;
        // 
        // xrTableCell226
        // 
        this.xrTableCell226.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell226.Name = "xrTableCell226";
        this.xrTableCell226.StylePriority.UseBorders = false;
        this.xrTableCell226.Weight = 0.096118449273510487D;
        // 
        // xrTableCell227
        // 
        this.xrTableCell227.Name = "xrTableCell227";
        this.xrTableCell227.Weight = 0.0774710967161945D;
        // 
        // xrTableCell228
        // 
        this.xrTableCell228.Name = "xrTableCell228";
        this.xrTableCell228.Weight = 0.077470155519859793D;
        // 
        // xrTableCell229
        // 
        this.xrTableCell229.Name = "xrTableCell229";
        this.xrTableCell229.Weight = 0.077470854286835561D;
        // 
        // xrTableCell230
        // 
        this.xrTableCell230.Name = "xrTableCell230";
        this.xrTableCell230.Weight = 0.16426535633122805D;
        // 
        // xrTable7
        // 
        this.xrTable7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable7.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 26.04167F);
        this.xrTable7.Name = "xrTable7";
        this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
        this.xrTable7.SizeF = new System.Drawing.SizeF(1605F, 25F);
        this.xrTable7.StylePriority.UseBorders = false;
        this.xrTable7.StylePriority.UseFont = false;
        this.xrTable7.StylePriority.UseTextAlignment = false;
        this.xrTable7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell153,
            this.xrTableCell155,
            this.s1,
            this.s2,
            this.s3,
            this.s4,
            this.s5,
            this.s6,
            this.s7,
            this.s8,
            this.s9,
            this.s10,
            this.s11,
            this.s12,
            this.s13,
            this.s14,
            this.s15,
            this.s16,
            this.s17,
            this.s18,
            this.s19,
            this.s20,
            this.s21,
            this.s22,
            this.s23,
            this.s24,
            this.s25,
            this.s26,
            this.s27,
            this.s28,
            this.s29,
            this.s30,
            this.s31,
            this.xrTableCell187,
            this.xrTableCell188,
            this.xrTableCell189,
            this.xrTableCell190,
            this.xrTableCell191});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell153
        // 
        this.xrTableCell153.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableCell153.Name = "xrTableCell153";
        this.xrTableCell153.StylePriority.UseFont = false;
        this.xrTableCell153.StylePriority.UseTextAlignment = false;
        this.xrTableCell153.Text = "1";
        this.xrTableCell153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell153.Weight = 0.0658098737770152D;
        // 
        // xrTableCell155
        // 
        this.xrTableCell155.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrTableCell155.Name = "xrTableCell155";
        this.xrTableCell155.StylePriority.UseFont = false;
        this.xrTableCell155.StylePriority.UseTextAlignment = false;
        this.xrTableCell155.Text = "SÁNG";
        this.xrTableCell155.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell155.Weight = 0.30658577892267813D;
        // 
        // s1
        // 
        this.s1.Name = "s1";
        this.s1.Weight = 0.0653476875519084D;
        // 
        // s2
        // 
        this.s2.Name = "s2";
        this.s2.Weight = 0.056058507544972075D;
        // 
        // s3
        // 
        this.s3.Name = "s3";
        this.s3.Weight = 0.056058457633045206D;
        // 
        // s4
        // 
        this.s4.Name = "s4";
        this.s4.Weight = 0.06189974758112541D;
        // 
        // s5
        // 
        this.s5.Name = "s5";
        this.s5.Weight = 0.0716349107082759D;
        // 
        // s6
        // 
        this.s6.Name = "s6";
        this.s6.Weight = 0.063846739207472761D;
        // 
        // s7
        // 
        this.s7.Name = "s7";
        this.s7.Weight = 0.069687884321836646D;
        // 
        // s8
        // 
        this.s8.Name = "s8";
        this.s8.Weight = 0.06579355792464496D;
        // 
        // s9
        // 
        this.s9.Name = "s9";
        this.s9.Weight = 0.078692968315053208D;
        // 
        // s10
        // 
        this.s10.Name = "s10";
        this.s10.Weight = 0.061169319063703577D;
        // 
        // s11
        // 
        this.s11.Name = "s11";
        this.s11.Weight = 0.076746061583545716D;
        // 
        // s12
        // 
        this.s12.Name = "s12";
        this.s12.Weight = 0.070499027778055071D;
        // 
        // s13
        // 
        this.s13.Name = "s13";
        this.s13.Weight = 0.064658006329402773D;
        // 
        // s14
        // 
        this.s14.Name = "s14";
        this.s14.Weight = 0.070904819096360316D;
        // 
        // s15
        // 
        this.s15.Name = "s15";
        this.s15.Weight = 0.070904594492689432D;
        // 
        // s16
        // 
        this.s16.Name = "s16";
        this.s16.Weight = 0.074798867412816716D;
        // 
        // s17
        // 
        this.s17.Name = "s17";
        this.s17.Weight = 0.063816190880035678D;
        // 
        // s18
        // 
        this.s18.Name = "s18";
        this.s18.Weight = 0.0716046195163905D;
        // 
        // s19
        // 
        this.s19.Name = "s19";
        this.s19.Weight = 0.069657313043826108D;
        // 
        // s20
        // 
        this.s20.Name = "s20";
        this.s20.Weight = 0.069657427239640843D;
        // 
        // s21
        // 
        this.s21.Name = "s21";
        this.s21.Weight = 0.071604505821923209D;
        // 
        // s22
        // 
        this.s22.Name = "s22";
        this.s22.Weight = 0.069657541407602941D;
        // 
        // s23
        // 
        this.s23.Name = "s23";
        this.s23.Weight = 0.071604163610489546D;
        // 
        // s24
        // 
        this.s24.Name = "s24";
        this.s24.Weight = 0.071604619948106379D;
        // 
        // s25
        // 
        this.s25.Name = "s25";
        this.s25.Weight = 0.063380275262850561D;
        // 
        // s26
        // 
        this.s26.Name = "s26";
        this.s26.Weight = 0.073115325642523266D;
        // 
        // s27
        // 
        this.s27.Name = "s27";
        this.s27.Weight = 0.06922116858936922D;
        // 
        // s28
        // 
        this.s28.Name = "s28";
        this.s28.Weight = 0.074525294794100472D;
        // 
        // s29
        // 
        this.s29.Name = "s29";
        this.s29.Weight = 0.070227393034462571D;
        // 
        // s30
        // 
        this.s30.Name = "s30";
        this.s30.Weight = 0.070228077540887779D;
        // 
        // s31
        // 
        this.s31.Name = "s31";
        this.s31.Weight = 0.076203362295560767D;
        // 
        // xrTableCell187
        // 
        this.xrTableCell187.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell187.Name = "xrTableCell187";
        this.xrTableCell187.StylePriority.UseBorders = false;
        this.xrTableCell187.Weight = 0.096118449273510487D;
        // 
        // xrTableCell188
        // 
        this.xrTableCell188.Name = "xrTableCell188";
        this.xrTableCell188.Weight = 0.0774710967161945D;
        // 
        // xrTableCell189
        // 
        this.xrTableCell189.Name = "xrTableCell189";
        this.xrTableCell189.Weight = 0.077470155519859793D;
        // 
        // xrTableCell190
        // 
        this.xrTableCell190.Name = "xrTableCell190";
        this.xrTableCell190.Weight = 0.077470854286835561D;
        // 
        // xrTableCell191
        // 
        this.xrTableCell191.Name = "xrTableCell191";
        this.xrTableCell191.Weight = 0.16426535633122805D;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(660.4514F, 125F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.Text = "Hành chính ( H+ ):";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(299.631F, 125F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(101.0417F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Ca sáng (S+):";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(400.6726F, 125F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = "Từ 07h30 đến 11h30";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(299.631F, 148F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(101.0417F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.Text = "Ca sáng (S):";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(400.6726F, 148F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.Text = "Từ 07h30 đến 15h15";
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(299.6309F, 171F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(101.0417F, 23F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.Text = "Ca chiều (C+):";
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(400.6726F, 171F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.Text = "Từ 13h00 đến 17h00";
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(400.6726F, 194.0001F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.Text = "Từ 15h15 đến 22h30";
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(299.631F, 194.0001F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(101.0417F, 23F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.Text = "Ca chiều (C):";
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(660.4513F, 148F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.Text = "Hành chính ( H ):";
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(781.2847F, 148F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.Text = "Từ 07h30 đến 17h00";
        // 
        // xrTable10
        // 
        this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125F);
        this.xrTable10.Name = "xrTable10";
        this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12,
            this.xrTableRow13});
        this.xrTable10.SizeF = new System.Drawing.SizeF(205.243F, 50F);
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell154});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell154
        // 
        this.xrTableCell154.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrTableCell154.Name = "xrTableCell154";
        this.xrTableCell154.StylePriority.UseFont = false;
        this.xrTableCell154.StylePriority.UseTextAlignment = false;
        this.xrTableCell154.Text = "GHI CHÚ";
        this.xrTableCell154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell154.Weight = 3D;
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell193});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrTableCell193
        // 
        this.xrTableCell193.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrTableCell193.Name = "xrTableCell193";
        this.xrTableCell193.StylePriority.UseFont = false;
        this.xrTableCell193.Text = "Chỉ được đổi ca 01 lần/tháng";
        this.xrTableCell193.Weight = 3D;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(781.2847F, 125F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.Text = "Từ 07h30 đến 15h30";
        // 
        // xrLabel15
        // 
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(781.2847F, 194.0001F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.Text = "Nghỉ theo lịch phân ca";
        // 
        // xrLabel16
        // 
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(660.4514F, 194.0001F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.Text = "Ngày nghỉ (N):";
        // 
        // xrLabel13
        // 
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(660.4514F, 171F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.Text = "Cả ngày (X): ";
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(781.2847F, 171F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.Text = "Từ 7h30 đến 22h30";
        // 
        // xrLabel19
        // 
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(1031.466F, 125F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.Text = "Nghỉ bù ( NB ):";
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(1152.3F, 148F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(200.9773F, 23F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.Text = "Nghỉ theo chế độ phép của công ty";
        // 
        // xrLabel17
        // 
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(1031.466F, 148F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.Text = "Nghỉ phép (NP):";
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(1152.299F, 171F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.Text = "Từ 7h30 đến 22h30";
        // 
        // xrLabel21
        // 
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(1031.466F, 171F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.Text = "Nghỉ lễ ( L ):";
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(1152.3F, 125F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(200.9772F, 23F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.Text = "Ngày nghỉ bù do làm thừa công";
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(45.83329F, 236.875F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(426.4236F, 23F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.Text = "Phân lịch tăng cường quân số tối đa vào các ngày: Thứ 7, chủ nhật";
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 236.875F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(45.83332F, 23F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.Text = "Chú ý:";
        // 
        // PageFooter
        // 
        this.PageFooter.HeightF = 191F;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrl_TenThanhPho
        // 
        this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
        this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(557.2917F, 23F);
        this.xrl_TenThanhPho.StylePriority.UseFont = false;
        this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
        this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
        this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TenCongTy
        // 
        this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
        this.xrl_TenCongTy.Name = "xrl_TenCongTy";
        this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(557.2917F, 23F);
        this.xrl_TenCongTy.StylePriority.UseFont = false;
        this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
        this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
        this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrl_TitleBC
        // 
        this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
        this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 68.75F);
        this.xrl_TitleBC.Name = "xrl_TitleBC";
        this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(1605F, 29.25F);
        this.xrl_TitleBC.StylePriority.UseFont = false;
        this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
        this.xrl_TitleBC.Text = "LỊCH PHÂN CA THÁNG";
        this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrt_todoi,
            this.xrl_TitleBC,
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
        this.ReportHeader.HeightF = 127F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrt_todoi
        // 
        this.xrt_todoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrt_todoi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 97.99998F);
        this.xrt_todoi.Name = "xrt_todoi";
        this.xrt_todoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrt_todoi.SizeF = new System.Drawing.SizeF(1605F, 23F);
        this.xrt_todoi.StylePriority.UseFont = false;
        this.xrt_todoi.StylePriority.UseTextAlignment = false;
        this.xrt_todoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // rp_LichPhanCaThang
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(25, 24, 50, 100);
        this.PageHeight = 1169;
        this.PageWidth = 1654;
        this.PaperKind = System.Drawing.Printing.PaperKind.A3;
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

}
