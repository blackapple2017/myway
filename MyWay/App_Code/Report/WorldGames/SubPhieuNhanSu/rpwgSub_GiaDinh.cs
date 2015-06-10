using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// Summary description for rpwgSub_GiaDinh
/// </summary>
public class rpwgSub_GiaDinh : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell24;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell28;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell23;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell64;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableRow xrTableRow22;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableRow xrTableRow23;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableRow xrTableRow24;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTableRow xrTableRow25;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTableCell xrTableCell100;
    private XRTableRow xrTableRow26;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTableRow xrTableRow27;
    private XRTableCell xrTableCell105;
    private XRTableCell xrTableCell106;
    private XRTableCell xrTableCell107;
    private XRTableCell xrTableCell108;
    private XRTableRow xrTableRow28;
    private XRTableCell xrTableCell109;
    private XRTableCell xrTableCell110;
    private XRTableCell xrTableCell111;
    private XRTableCell xrTableCell112;
    private XRTableRow xrTableRow30;
    private XRTableCell xrTableCell117;
    private XRTableCell xrTableCell118;
    private XRTableCell xrTableCell119;
    private XRTableCell xrTableCell120;
    private XRTableRow xrTableRow31;
    private XRTableCell xrTableCell121;
    private XRTableCell xrTableCell122;
    private XRTableCell xrTableCell123;
    private XRTableCell xrTableCell124;
    private XRTableRow xrTableRow32;
    private XRTableCell xrTableCell125;
    private XRTableCell xrTableCell126;
    private XRTableCell xrTableCell127;
    private XRTableCell xrTableCell128;
    private XRTableRow xrTableRow33;
    private XRTableCell xrTableCell129;
    private XRTableCell xrTableCell130;
    private XRTableCell xrTableCell131;
    private XRTableCell xrTableCell132;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpwgSub_GiaDinh()
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

    public void BinData(string prkey, string madonvi)
    {
        List<GetSubGiaDinhInfo> listQuanHe = new WGGetSubGiaDinh().GetAll(decimal.Parse("0" + prkey));
        var bode = listQuanHe.Where(p => p.TenQuanHe == "Bố đẻ").FirstOrDefault();
        if (bode != null)
        {
            xrTableCell2.Text = bode.HO_TEN.ToUpper();
            xrTableCell6.Text = bode.TUOI;
            xrTableCell10.Text = bode.NGHE_NGHIEP;
            xrTableCell14.Text = bode.NOI_LAMVIEC;

        }
        else
        {
            var boduong = listQuanHe.Where(p => p.TenQuanHe == "Bố dượng").FirstOrDefault();
            if (boduong != null)
            {
                xrTableCell2.Text = boduong.HO_TEN.ToUpper();
                xrTableCell6.Text = boduong.TUOI;
                xrTableCell10.Text = boduong.NGHE_NGHIEP;
                xrTableCell14.Text = boduong.NOI_LAMVIEC;

            }
        }
        var mede = listQuanHe.Where(p => p.TenQuanHe == "Mẹ đẻ").FirstOrDefault();
        if (mede != null)
        {
            xrTableCell4.Text = mede.HO_TEN.ToUpper();
            xrTableCell8.Text = mede.TUOI;
            xrTableCell12.Text = mede.NGHE_NGHIEP;
            xrTableCell16.Text = mede.NOI_LAMVIEC;
        }

        var vochong = listQuanHe.Where(p => p.TenQuanHe == "Vợ" || p.TenQuanHe == "Chồng").FirstOrDefault();
        if (vochong != null)
        {
            xrTableCell22.Text = vochong.HO_TEN.ToUpper();
            xrTableCell26.Text = vochong.TUOI;
            xrTableCell30.Text = vochong.NGHE_NGHIEP;
            xrTableCell34.Text = vochong.NOI_LAMVIEC;
        }

        var con = listQuanHe.Where(p => p.TenQuanHe.Contains("Con")).ToList();
        if (con != null)
        {
            if (con.Count > 0)
            {
                xrTableCell50.Text = con[0].HO_TEN.ToUpper();
                xrTableCell54.Text = con[0].TUOI;
                xrTableCell46.Text = con[0].NGHE_NGHIEP;
                xrTableCell58.Text = con[0].NOI_LAMVIEC;
            }
            if (con.Count > 1)
            {
                xrTableCell52.Text = con[1].HO_TEN.ToUpper();
                xrTableCell56.Text = con[1].TUOI;
                xrTableCell48.Text = con[1].NGHE_NGHIEP;
                xrTableCell60.Text = con[1].NOI_LAMVIEC;
            }
            if (con.Count > 2)
            {
                xrTableCell66.Text = con[2].HO_TEN.ToUpper();
                xrTableCell70.Text = con[2].TUOI;
                xrTableCell74.Text = con[2].NGHE_NGHIEP;
                xrTableCell82.Text = con[2].NOI_LAMVIEC;
            }
            if (con.Count > 3)
            {
                xrTableCell68.Text = con[3].HO_TEN.ToUpper();
                xrTableCell72.Text = con[3].TUOI;
                xrTableCell76.Text = con[3].NGHE_NGHIEP;
                xrTableCell84.Text = con[3].NOI_LAMVIEC;
            }
        }

        var anhchiem = listQuanHe.Where(p => p.TenQuanHe.Contains("Anh") || p.TenQuanHe.Contains("Chị") || p.TenQuanHe.Contains("Em")).ToList();
        if (anhchiem != null)
        {
            if (anhchiem.Count > 0)
            {
                xrTableCell90.Text = anhchiem[0].HO_TEN.ToUpper();
                xrTableCell94.Text = anhchiem[0].TUOI;
                xrTableCell102.Text = anhchiem[0].NGHE_NGHIEP;
                xrTableCell106.Text = anhchiem[0].NOI_LAMVIEC;
            }
            if (anhchiem.Count > 1)
            {
                xrTableCell92.Text = anhchiem[1].HO_TEN.ToUpper();
                xrTableCell96.Text = anhchiem[1].TUOI;
                xrTableCell104.Text = anhchiem[1].NGHE_NGHIEP;
                xrTableCell108.Text = anhchiem[1].NOI_LAMVIEC;
            }
            if (anhchiem.Count > 2)
            {
                xrTableCell98.Text = anhchiem[2].HO_TEN.ToUpper();
                xrTableCell118.Text = anhchiem[2].TUOI;
                xrTableCell122.Text = anhchiem[2].NGHE_NGHIEP;
                xrTableCell126.Text = anhchiem[2].NOI_LAMVIEC;
            }
            if (anhchiem.Count > 3)
            {
                xrTableCell100.Text = anhchiem[3].HO_TEN.ToUpper();
                xrTableCell120.Text = anhchiem[3].TUOI;
                xrTableCell124.Text = anhchiem[3].NGHE_NGHIEP;
                xrTableCell128.Text = anhchiem[3].NOI_LAMVIEC;
            }
        }

    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        string resourceFileName = "rpwgSub_GiaDinh.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell119 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow31 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell121 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell122 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell124 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow32 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell125 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell126 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell127 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell128 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow33 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell129 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell130 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell131 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell132 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.Detail.HeightF = 800F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable1
        // 
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.xrTableRow3,
            this.xrTableRow4,
            this.xrTableRow5,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow8,
            this.xrTableRow9,
            this.xrTableRow10,
            this.xrTableRow11,
            this.xrTableRow13,
            this.xrTableRow14,
            this.xrTableRow12,
            this.xrTableRow15,
            this.xrTableRow16,
            this.xrTableRow17,
            this.xrTableRow18,
            this.xrTableRow19,
            this.xrTableRow21,
            this.xrTableRow20,
            this.xrTableRow22,
            this.xrTableRow23,
            this.xrTableRow24,
            this.xrTableRow26,
            this.xrTableRow27,
            this.xrTableRow28,
            this.xrTableRow25,
            this.xrTableRow30,
            this.xrTableRow31,
            this.xrTableRow32,
            this.xrTableRow33});
        this.xrTable1.SizeF = new System.Drawing.SizeF(774.9999F, 800F);
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.Text = "Họ tên bố:";
        this.xrTableCell1.Weight = 0.5362901221998605D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.Weight = 1.0645162979745364D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.Text = "Họ tên mẹ:";
        this.xrTableCell3.Weight = 0.47580624742138833D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.Weight = 0.92338733240421489D;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Năm sinh:";
        this.xrTableCell5.Weight = 0.53629012219985817D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Weight = 1.0645162979745386D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = "Năm sinh:";
        this.xrTableCell7.Weight = 0.47580624742138833D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Weight = 0.92338733240421489D;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Nghề nghiệp:";
        this.xrTableCell9.Weight = 0.53629012219985817D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Weight = 1.0645162979745386D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Text = "Nghề nghiệp:";
        this.xrTableCell11.Weight = 0.47580624742138833D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Weight = 0.92338733240421489D;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Text = "Nơi làm việc:";
        this.xrTableCell13.Weight = 0.53629012219985817D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Weight = 1.0645162979745386D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Text = "Nơi làm việc";
        this.xrTableCell15.Weight = 0.47580624742138833D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Weight = 0.92338733240421489D;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Weight = 0.5362901221998605D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Weight = 1.0645162979745364D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.Weight = 0.47580624742138833D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Weight = 0.92338733240421489D;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseBackColor = false;
        this.xrTableCell21.StylePriority.UseFont = false;
        this.xrTableCell21.Text = "Họ và tên vợ(chồng):";
        this.xrTableCell21.Weight = 0.53629012219986283D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseFont = false;
        this.xrTableCell22.Weight = 1.0645162979745342D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Weight = 0.47580624742138833D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Weight = 0.92338733240421489D;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Text = "Sinh năm:";
        this.xrTableCell25.Weight = 0.53629000406728844D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Weight = 1.0645164161071083D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.Weight = 0.47580624742138833D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.Weight = 0.92338733240421489D;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.Text = "Nghề nghiệp:";
        this.xrTableCell29.Weight = 0.53629029939871753D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.Weight = 1.0645161207756793D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.Weight = 0.47580601115623011D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.Weight = 0.9233875686693731D;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.Text = "Nơi làm việc:";
        this.xrTableCell33.Weight = 0.53629035846500239D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.Weight = 1.0645160617093945D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.Weight = 0.47580624742138833D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.Weight = 0.92338733240421489D;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40});
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Weight = 0.53629006313357563D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.Weight = 1.0645163570408212D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.Weight = 0.47580601115623011D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.Weight = 0.9233875686693731D;
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44});
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell41
        // 
        this.xrTableCell41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.xrTableCell41.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell41.Name = "xrTableCell41";
        this.xrTableCell41.StylePriority.UseBackColor = false;
        this.xrTableCell41.StylePriority.UseFont = false;
        this.xrTableCell41.Text = "Họ tên con:";
        this.xrTableCell41.Weight = 0.53629041753128959D;
        // 
        // xrTableCell42
        // 
        this.xrTableCell42.Name = "xrTableCell42";
        this.xrTableCell42.Weight = 1.0645160026431071D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Name = "xrTableCell43";
        this.xrTableCell43.Weight = 0.47580601115623011D;
        // 
        // xrTableCell44
        // 
        this.xrTableCell44.Name = "xrTableCell44";
        this.xrTableCell44.Weight = 0.9233875686693731D;
        // 
        // xrTableRow13
        // 
        this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49,
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52});
        this.xrTableRow13.Name = "xrTableRow13";
        this.xrTableRow13.Weight = 1D;
        // 
        // xrTableCell49
        // 
        this.xrTableCell49.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTableCell49.Name = "xrTableCell49";
        this.xrTableCell49.StylePriority.UseFont = false;
        this.xrTableCell49.Text = "Họ và tên:";
        this.xrTableCell49.Weight = 0.53629000406728844D;
        // 
        // xrTableCell50
        // 
        this.xrTableCell50.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell50.Name = "xrTableCell50";
        this.xrTableCell50.StylePriority.UseFont = false;
        this.xrTableCell50.Weight = 1.0645164161071086D;
        // 
        // xrTableCell51
        // 
        this.xrTableCell51.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.xrTableCell51.Name = "xrTableCell51";
        this.xrTableCell51.StylePriority.UseFont = false;
        this.xrTableCell51.Text = "Họ và tên:";
        this.xrTableCell51.Weight = 0.47580624742138833D;
        // 
        // xrTableCell52
        // 
        this.xrTableCell52.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell52.Name = "xrTableCell52";
        this.xrTableCell52.StylePriority.UseFont = false;
        this.xrTableCell52.Weight = 0.92338733240421489D;
        // 
        // xrTableRow14
        // 
        this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56});
        this.xrTableRow14.Name = "xrTableRow14";
        this.xrTableRow14.Weight = 1D;
        // 
        // xrTableCell53
        // 
        this.xrTableCell53.Name = "xrTableCell53";
        this.xrTableCell53.Text = "Sinh năm:";
        this.xrTableCell53.Weight = 0.53629041753128726D;
        // 
        // xrTableCell54
        // 
        this.xrTableCell54.Name = "xrTableCell54";
        this.xrTableCell54.Weight = 1.0645160026431095D;
        // 
        // xrTableCell55
        // 
        this.xrTableCell55.Name = "xrTableCell55";
        this.xrTableCell55.Text = "Sinh năm:";
        this.xrTableCell55.Weight = 0.47580601115623011D;
        // 
        // xrTableCell56
        // 
        this.xrTableCell56.Name = "xrTableCell56";
        this.xrTableCell56.Weight = 0.9233875686693731D;
        // 
        // xrTableRow12
        // 
        this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell48});
        this.xrTableRow12.Name = "xrTableRow12";
        this.xrTableRow12.Weight = 1D;
        // 
        // xrTableCell45
        // 
        this.xrTableCell45.Name = "xrTableCell45";
        this.xrTableCell45.Text = "Nghề nghiệp:";
        this.xrTableCell45.Weight = 0.53629047659757223D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Multiline = true;
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.Weight = 1.0645159435768246D;
        // 
        // xrTableCell47
        // 
        this.xrTableCell47.Name = "xrTableCell47";
        this.xrTableCell47.Text = "Nghề nghiệp:";
        this.xrTableCell47.Weight = 0.47580624742138833D;
        // 
        // xrTableCell48
        // 
        this.xrTableCell48.Name = "xrTableCell48";
        this.xrTableCell48.Weight = 0.92338733240421489D;
        // 
        // xrTableRow15
        // 
        this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell57,
            this.xrTableCell58,
            this.xrTableCell59,
            this.xrTableCell60});
        this.xrTableRow15.Name = "xrTableRow15";
        this.xrTableRow15.Weight = 1D;
        // 
        // xrTableCell57
        // 
        this.xrTableCell57.Name = "xrTableCell57";
        this.xrTableCell57.Text = "Nơi làm việc:";
        this.xrTableCell57.Weight = 0.53629006313357563D;
        // 
        // xrTableCell58
        // 
        this.xrTableCell58.Name = "xrTableCell58";
        this.xrTableCell58.Weight = 1.0645163570408212D;
        // 
        // xrTableCell59
        // 
        this.xrTableCell59.Name = "xrTableCell59";
        this.xrTableCell59.Text = "Nơi làm việc:";
        this.xrTableCell59.Weight = 0.47580601115623011D;
        // 
        // xrTableCell60
        // 
        this.xrTableCell60.Name = "xrTableCell60";
        this.xrTableCell60.Weight = 0.9233875686693731D;
        // 
        // xrTableRow16
        // 
        this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell63,
            this.xrTableCell64});
        this.xrTableRow16.Name = "xrTableRow16";
        this.xrTableRow16.Weight = 1D;
        // 
        // xrTableCell61
        // 
        this.xrTableCell61.Name = "xrTableCell61";
        this.xrTableCell61.Weight = 0.53629053566385709D;
        // 
        // xrTableCell62
        // 
        this.xrTableCell62.Name = "xrTableCell62";
        this.xrTableCell62.Weight = 1.0645158845105398D;
        // 
        // xrTableCell63
        // 
        this.xrTableCell63.Name = "xrTableCell63";
        this.xrTableCell63.Weight = 0.47580601115623017D;
        // 
        // xrTableCell64
        // 
        this.xrTableCell64.Name = "xrTableCell64";
        this.xrTableCell64.Weight = 0.9233875686693731D;
        // 
        // xrTableRow17
        // 
        this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell65,
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell68});
        this.xrTableRow17.Name = "xrTableRow17";
        this.xrTableRow17.Weight = 1D;
        // 
        // xrTableCell65
        // 
        this.xrTableCell65.Name = "xrTableCell65";
        this.xrTableCell65.Text = "Họ và tên:";
        this.xrTableCell65.Weight = 0.53629053566385476D;
        // 
        // xrTableCell66
        // 
        this.xrTableCell66.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell66.Name = "xrTableCell66";
        this.xrTableCell66.StylePriority.UseFont = false;
        this.xrTableCell66.Weight = 1.064515884510542D;
        // 
        // xrTableCell67
        // 
        this.xrTableCell67.Name = "xrTableCell67";
        this.xrTableCell67.Text = "Họ và tên:";
        this.xrTableCell67.Weight = 0.47580601115623011D;
        // 
        // xrTableCell68
        // 
        this.xrTableCell68.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell68.Name = "xrTableCell68";
        this.xrTableCell68.StylePriority.UseFont = false;
        this.xrTableCell68.Weight = 0.9233875686693731D;
        // 
        // xrTableRow18
        // 
        this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell69,
            this.xrTableCell70,
            this.xrTableCell71,
            this.xrTableCell72});
        this.xrTableRow18.Name = "xrTableRow18";
        this.xrTableRow18.Weight = 1D;
        // 
        // xrTableCell69
        // 
        this.xrTableCell69.Name = "xrTableCell69";
        this.xrTableCell69.Text = "Sinh năm:";
        this.xrTableCell69.Weight = 0.53629006313357563D;
        // 
        // xrTableCell70
        // 
        this.xrTableCell70.Name = "xrTableCell70";
        this.xrTableCell70.Weight = 1.0645163570408212D;
        // 
        // xrTableCell71
        // 
        this.xrTableCell71.Name = "xrTableCell71";
        this.xrTableCell71.Text = "Sinh năm:";
        this.xrTableCell71.Weight = 0.47580601115623011D;
        // 
        // xrTableCell72
        // 
        this.xrTableCell72.Name = "xrTableCell72";
        this.xrTableCell72.Weight = 0.9233875686693731D;
        // 
        // xrTableRow19
        // 
        this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell75,
            this.xrTableCell76});
        this.xrTableRow19.Name = "xrTableRow19";
        this.xrTableRow19.Weight = 1D;
        // 
        // xrTableCell73
        // 
        this.xrTableCell73.Name = "xrTableCell73";
        this.xrTableCell73.Text = "Nghề nghiệp:";
        this.xrTableCell73.Weight = 0.53629006313357563D;
        // 
        // xrTableCell74
        // 
        this.xrTableCell74.Name = "xrTableCell74";
        this.xrTableCell74.Weight = 1.0645163570408212D;
        // 
        // xrTableCell75
        // 
        this.xrTableCell75.Name = "xrTableCell75";
        this.xrTableCell75.Text = "Nghề nghiệp:";
        this.xrTableCell75.Weight = 0.47580601115623011D;
        // 
        // xrTableCell76
        // 
        this.xrTableCell76.Name = "xrTableCell76";
        this.xrTableCell76.Weight = 0.9233875686693731D;
        // 
        // xrTableRow21
        // 
        this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell81,
            this.xrTableCell82,
            this.xrTableCell83,
            this.xrTableCell84});
        this.xrTableRow21.Name = "xrTableRow21";
        this.xrTableRow21.Weight = 1D;
        // 
        // xrTableCell81
        // 
        this.xrTableCell81.Name = "xrTableCell81";
        this.xrTableCell81.Text = "Nơi làm việc:";
        this.xrTableCell81.Weight = 0.536290594730142D;
        // 
        // xrTableCell82
        // 
        this.xrTableCell82.Name = "xrTableCell82";
        this.xrTableCell82.Weight = 1.0645158254442548D;
        // 
        // xrTableCell83
        // 
        this.xrTableCell83.Name = "xrTableCell83";
        this.xrTableCell83.Text = "Nơi làm việc:";
        this.xrTableCell83.Weight = 0.47580624742138833D;
        // 
        // xrTableCell84
        // 
        this.xrTableCell84.Name = "xrTableCell84";
        this.xrTableCell84.Weight = 0.92338733240421489D;
        // 
        // xrTableRow20
        // 
        this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrTableCell79,
            this.xrTableCell80});
        this.xrTableRow20.Name = "xrTableRow20";
        this.xrTableRow20.Weight = 1D;
        // 
        // xrTableCell77
        // 
        this.xrTableCell77.Name = "xrTableCell77";
        this.xrTableCell77.Weight = 0.53629000406728844D;
        // 
        // xrTableCell78
        // 
        this.xrTableCell78.Name = "xrTableCell78";
        this.xrTableCell78.Weight = 1.0645164161071086D;
        // 
        // xrTableCell79
        // 
        this.xrTableCell79.Name = "xrTableCell79";
        this.xrTableCell79.Weight = 0.47580624742138833D;
        // 
        // xrTableCell80
        // 
        this.xrTableCell80.Name = "xrTableCell80";
        this.xrTableCell80.Weight = 0.92338733240421489D;
        // 
        // xrTableRow22
        // 
        this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell85,
            this.xrTableCell86,
            this.xrTableCell87,
            this.xrTableCell88});
        this.xrTableRow22.Name = "xrTableRow22";
        this.xrTableRow22.Weight = 1D;
        // 
        // xrTableCell85
        // 
        this.xrTableCell85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.xrTableCell85.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell85.Name = "xrTableCell85";
        this.xrTableCell85.StylePriority.UseBackColor = false;
        this.xrTableCell85.StylePriority.UseFont = false;
        this.xrTableCell85.Text = "Anh chị em:";
        this.xrTableCell85.Weight = 0.53629006313357563D;
        // 
        // xrTableCell86
        // 
        this.xrTableCell86.Name = "xrTableCell86";
        this.xrTableCell86.Weight = 1.0645163570408212D;
        // 
        // xrTableCell87
        // 
        this.xrTableCell87.Name = "xrTableCell87";
        this.xrTableCell87.Weight = 0.47580601115623011D;
        // 
        // xrTableCell88
        // 
        this.xrTableCell88.Name = "xrTableCell88";
        this.xrTableCell88.Weight = 0.9233875686693731D;
        // 
        // xrTableRow23
        // 
        this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrTableCell91,
            this.xrTableCell92});
        this.xrTableRow23.Name = "xrTableRow23";
        this.xrTableRow23.Weight = 1D;
        // 
        // xrTableCell89
        // 
        this.xrTableCell89.Name = "xrTableCell89";
        this.xrTableCell89.Text = "Họ và tên:";
        this.xrTableCell89.Weight = 0.53629065379642915D;
        // 
        // xrTableCell90
        // 
        this.xrTableCell90.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell90.Name = "xrTableCell90";
        this.xrTableCell90.StylePriority.UseFont = false;
        this.xrTableCell90.Weight = 1.0645157663779676D;
        // 
        // xrTableCell91
        // 
        this.xrTableCell91.Name = "xrTableCell91";
        this.xrTableCell91.Text = "Họ và tên:";
        this.xrTableCell91.Weight = 0.47580601115623011D;
        // 
        // xrTableCell92
        // 
        this.xrTableCell92.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell92.Name = "xrTableCell92";
        this.xrTableCell92.StylePriority.UseFont = false;
        this.xrTableCell92.Weight = 0.9233875686693731D;
        // 
        // xrTableRow24
        // 
        this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell95,
            this.xrTableCell96});
        this.xrTableRow24.Name = "xrTableRow24";
        this.xrTableRow24.Weight = 1D;
        // 
        // xrTableCell93
        // 
        this.xrTableCell93.Name = "xrTableCell93";
        this.xrTableCell93.Text = "Quan hệ/Sinh Năm:";
        this.xrTableCell93.Weight = 0.53629000406728844D;
        // 
        // xrTableCell94
        // 
        this.xrTableCell94.Name = "xrTableCell94";
        this.xrTableCell94.Weight = 1.0645164161071086D;
        // 
        // xrTableCell95
        // 
        this.xrTableCell95.Name = "xrTableCell95";
        this.xrTableCell95.Text = "Quan hệ/Sinh Năm:";
        this.xrTableCell95.Weight = 0.47580624742138833D;
        // 
        // xrTableCell96
        // 
        this.xrTableCell96.Name = "xrTableCell96";
        this.xrTableCell96.Weight = 0.92338733240421489D;
        // 
        // xrTableRow26
        // 
        this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell101,
            this.xrTableCell102,
            this.xrTableCell103,
            this.xrTableCell104});
        this.xrTableRow26.Name = "xrTableRow26";
        this.xrTableRow26.Weight = 1D;
        // 
        // xrTableCell101
        // 
        this.xrTableCell101.Name = "xrTableCell101";
        this.xrTableCell101.Text = "Nghề nghiệp:";
        this.xrTableCell101.Weight = 0.536290594730142D;
        // 
        // xrTableCell102
        // 
        this.xrTableCell102.Name = "xrTableCell102";
        this.xrTableCell102.Weight = 1.0645158254442548D;
        // 
        // xrTableCell103
        // 
        this.xrTableCell103.Name = "xrTableCell103";
        this.xrTableCell103.Text = "Nghề nghiệp:";
        this.xrTableCell103.Weight = 0.47580624742138833D;
        // 
        // xrTableCell104
        // 
        this.xrTableCell104.Name = "xrTableCell104";
        this.xrTableCell104.Weight = 0.92338733240421489D;
        // 
        // xrTableRow27
        // 
        this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell105,
            this.xrTableCell106,
            this.xrTableCell107,
            this.xrTableCell108});
        this.xrTableRow27.Name = "xrTableRow27";
        this.xrTableRow27.Weight = 1D;
        // 
        // xrTableCell105
        // 
        this.xrTableCell105.Name = "xrTableCell105";
        this.xrTableCell105.Text = "Nơi làm việc:";
        this.xrTableCell105.Weight = 0.5362906537964246D;
        // 
        // xrTableCell106
        // 
        this.xrTableCell106.Name = "xrTableCell106";
        this.xrTableCell106.Weight = 1.0645157663779723D;
        // 
        // xrTableCell107
        // 
        this.xrTableCell107.Name = "xrTableCell107";
        this.xrTableCell107.Text = "Nơi làm việc:";
        this.xrTableCell107.Weight = 0.47580601115623017D;
        // 
        // xrTableCell108
        // 
        this.xrTableCell108.Name = "xrTableCell108";
        this.xrTableCell108.Weight = 0.9233875686693731D;
        // 
        // xrTableRow28
        // 
        this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell109,
            this.xrTableCell110,
            this.xrTableCell111,
            this.xrTableCell112});
        this.xrTableRow28.Name = "xrTableRow28";
        this.xrTableRow28.Weight = 1D;
        // 
        // xrTableCell109
        // 
        this.xrTableCell109.Name = "xrTableCell109";
        this.xrTableCell109.Weight = 0.536290771928999D;
        // 
        // xrTableCell110
        // 
        this.xrTableCell110.Name = "xrTableCell110";
        this.xrTableCell110.Weight = 1.0645156482453977D;
        // 
        // xrTableCell111
        // 
        this.xrTableCell111.Name = "xrTableCell111";
        this.xrTableCell111.Weight = 0.47580601115623011D;
        // 
        // xrTableCell112
        // 
        this.xrTableCell112.Name = "xrTableCell112";
        this.xrTableCell112.Weight = 0.9233875686693731D;
        // 
        // xrTableRow25
        // 
        this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99,
            this.xrTableCell100});
        this.xrTableRow25.Name = "xrTableRow25";
        this.xrTableRow25.Weight = 1D;
        // 
        // xrTableCell97
        // 
        this.xrTableCell97.Name = "xrTableCell97";
        this.xrTableCell97.Text = "Họ và tên:";
        this.xrTableCell97.Weight = 0.53629077192899666D;
        // 
        // xrTableCell98
        // 
        this.xrTableCell98.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell98.Name = "xrTableCell98";
        this.xrTableCell98.StylePriority.UseFont = false;
        this.xrTableCell98.Weight = 1.0645156482454001D;
        // 
        // xrTableCell99
        // 
        this.xrTableCell99.Name = "xrTableCell99";
        this.xrTableCell99.Text = "Họ và tên:";
        this.xrTableCell99.Weight = 0.47580601115623011D;
        // 
        // xrTableCell100
        // 
        this.xrTableCell100.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell100.Name = "xrTableCell100";
        this.xrTableCell100.StylePriority.UseFont = false;
        this.xrTableCell100.Weight = 0.9233875686693731D;
        // 
        // xrTableRow30
        // 
        this.xrTableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell117,
            this.xrTableCell118,
            this.xrTableCell119,
            this.xrTableCell120});
        this.xrTableRow30.Name = "xrTableRow30";
        this.xrTableRow30.Weight = 1D;
        // 
        // xrTableCell117
        // 
        this.xrTableCell117.Name = "xrTableCell117";
        this.xrTableCell117.Text = "Quan hệ/Sinh Năm:";
        this.xrTableCell117.Weight = 0.53629006313357563D;
        // 
        // xrTableCell118
        // 
        this.xrTableCell118.Name = "xrTableCell118";
        this.xrTableCell118.Weight = 1.0645163570408212D;
        // 
        // xrTableCell119
        // 
        this.xrTableCell119.Name = "xrTableCell119";
        this.xrTableCell119.Text = "Quan hệ/Sinh Năm:";
        this.xrTableCell119.Weight = 0.47580601115623011D;
        // 
        // xrTableCell120
        // 
        this.xrTableCell120.Name = "xrTableCell120";
        this.xrTableCell120.Weight = 0.9233875686693731D;
        // 
        // xrTableRow31
        // 
        this.xrTableRow31.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell121,
            this.xrTableCell122,
            this.xrTableCell123,
            this.xrTableCell124});
        this.xrTableRow31.Name = "xrTableRow31";
        this.xrTableRow31.Weight = 1D;
        // 
        // xrTableCell121
        // 
        this.xrTableCell121.Name = "xrTableCell121";
        this.xrTableCell121.Text = "Nghề nghiệp:";
        this.xrTableCell121.Weight = 0.53629077192899666D;
        // 
        // xrTableCell122
        // 
        this.xrTableCell122.Name = "xrTableCell122";
        this.xrTableCell122.Weight = 1.0645156482454001D;
        // 
        // xrTableCell123
        // 
        this.xrTableCell123.Name = "xrTableCell123";
        this.xrTableCell123.Text = "Nghề nghiệp:";
        this.xrTableCell123.Weight = 0.47580601115623011D;
        // 
        // xrTableCell124
        // 
        this.xrTableCell124.Name = "xrTableCell124";
        this.xrTableCell124.Weight = 0.9233875686693731D;
        // 
        // xrTableRow32
        // 
        this.xrTableRow32.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell125,
            this.xrTableCell126,
            this.xrTableCell127,
            this.xrTableCell128});
        this.xrTableRow32.Name = "xrTableRow32";
        this.xrTableRow32.Weight = 1D;
        // 
        // xrTableCell125
        // 
        this.xrTableCell125.Name = "xrTableCell125";
        this.xrTableCell125.Text = "Nơi làm việc:";
        this.xrTableCell125.Weight = 0.53629006313357563D;
        // 
        // xrTableCell126
        // 
        this.xrTableCell126.Name = "xrTableCell126";
        this.xrTableCell126.Weight = 1.0645163570408212D;
        // 
        // xrTableCell127
        // 
        this.xrTableCell127.Name = "xrTableCell127";
        this.xrTableCell127.Text = "Nơi làm việc:";
        this.xrTableCell127.Weight = 0.47580601115623011D;
        // 
        // xrTableCell128
        // 
        this.xrTableCell128.Name = "xrTableCell128";
        this.xrTableCell128.Weight = 0.9233875686693731D;
        // 
        // xrTableRow33
        // 
        this.xrTableRow33.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell129,
            this.xrTableCell130,
            this.xrTableCell131,
            this.xrTableCell132});
        this.xrTableRow33.Name = "xrTableRow33";
        this.xrTableRow33.Weight = 1D;
        // 
        // xrTableCell129
        // 
        this.xrTableCell129.Name = "xrTableCell129";
        this.xrTableCell129.Weight = 0.53629006313357563D;
        // 
        // xrTableCell130
        // 
        this.xrTableCell130.Name = "xrTableCell130";
        this.xrTableCell130.Weight = 1.0645163570408212D;
        // 
        // xrTableCell131
        // 
        this.xrTableCell131.Name = "xrTableCell131";
        this.xrTableCell131.Weight = 0.47580601115623011D;
        // 
        // xrTableCell132
        // 
        this.xrTableCell132.Name = "xrTableCell132";
        this.xrTableCell132.Weight = 0.9233875686693731D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 0F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 0F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // rpwgSub_GiaDinh
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
        this.Margins = new System.Drawing.Printing.Margins(41, 34, 0, 0);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
