using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan
/// </summary>
public class rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private ReportFooterBand ReportFooter;
    private GroupFooterBand GroupFooter1;
    private XRLabel xrl_TitleBC;
    private XRLabel xrl_TenCongTy;
    private XRLabel xrl_TenThanhPho;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell19;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell20;
    private XRTable xrTable4;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell21;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell22;
    private XRTable xrTable5;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTable xrTable6;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell26;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell27;
    private XRTable xrTable7;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell31;
    private XRTable xrTable8;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell32;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell33;
    private XRTable xrTable9;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell34;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell35;
    private XRTable xrTable10;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell37;
    private XRTable xrTable11;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell38;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell39;
    private XRTable xrTable12;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell40;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell41;
    private XRTable xrTable13;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell42;
    private XRTableRow xrTableRow22;
    private XRTableCell xrTableCell43;
    private XRTable xrTable14;
    private XRTableRow xrTableRow23;
    private XRTableCell xrTableCell44;
    private XRTableRow xrTableRow24;
    private XRTableCell xrTableCell45;
    private XRTable xrTable15;
    private XRTableRow xrTableRow25;
    private XRTableCell xrTableCell46;
    private XRTableRow xrTableRow26;
    private XRTableCell xrTableCell47;
    private XRTable xrTable16;
    private XRTableRow xrTableRow27;
    private XRTableCell xrTableCell48;
    private XRTableRow xrTableRow28;
    private XRTableCell xrTableCell49;
    private XRTable xrTable17;
    private XRTableRow xrTableRow29;
    private XRTableCell xrTableCell50;
    private XRTableRow xrTableRow30;
    private XRTableCell xrTableCell51;
    private XRTable xrTable18;
    private XRTableRow xrTableRow31;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTable xrTable19;
    private XRTableRow xrTableRow32;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell57;
    private XRTable xrTable20;
    private XRTableRow xrTableRow33;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTable xrTable21;
    private XRTableRow xrTableRow34;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTable xrTable22;
    private XRTableRow xrTableRow35;
    private XRTableCell xrTableCell64;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTable xrTable23;
    private XRTableRow xrTableRow36;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private XRTable xrTable24;
    private XRTableRow xrTableRow37;
    private XRTableCell xrTableCell70;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTable xrTable25;
    private XRTableRow xrTableRow38;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTable xrTable26;
    private XRTableRow xrTableRow39;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xagag;
    private XRTable xrTable27;
    private XRTableRow xrTableRow40;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTable xrTable28;
    private XRTableRow xrTableRow41;
    private XRTableCell xrt_thuviec4;
    private XRTableCell xrt_tong8;
    private XRTableCell xrt_tongldbinhquan;
    private XRTableCell xrt_stt;
    private XRTableCell xrt_tenphong;
    private XRTableCell xrTableCell87;
    private XRTableCell xrt_chinhthuc2;
    private XRTableCell xrt_tong1;
    private XRTableCell xrt_chinhthuc3;
    private XRTableCell xrt_chinhthuc6;
    private XRTableCell xrt_chinhthuc5;
    private XRTableCell xrt_tong4;
    private XRTableCell xrt_thucviec6;
    private XRTableCell xrt_tong7;
    private XRTableCell xrt_thuviec7;
    private XRTableCell xrt_thuviec8;
    private XRTableCell xrt_thuviec11;
    private XRTableCell xrt_tong9;
    private XRTableCell xrt_chinhthuc12;
    private XRTableCell xrt_tong11;
    private XRTableCell xrt_chinhthuc10;
    private XRTableCell xrt_chinhthuc9;
    private XRTableCell xrt_tongldthuviec;
    private XRTableCell xrt_thuviec1;
    private XRTableCell xrt_ct1;
    private XRTableCell xrt_thuviec2;
    private XRTableCell xrt_tong2;
    private XRTableCell xrt_thucviec3;
    private XRTableCell xrt_tong3;
    private XRTableCell xrt_chinhthuc4;
    private XRTableCell xrt_thuviec5;
    private XRTableCell xrt_tong5;
    private XRTableCell xrt_tong6;
    private XRTableCell xrt_chinhthuc7;
    private XRTableCell xrt_chinhthuc8;
    private XRTableCell xrt_thuviec9;
    private XRTableCell xrt_thuviec10;
    private XRTableCell xrt_tong10;
    private XRTableCell xrt_chinhthuc11;
    private XRTableCell xrt_thuviec12;
    private XRTableCell xrt_tong12;
    private XRTableCell xrt_tongldchinhthuc;
    private XRTable xrTable29;
    private XRTableRow xrTableRow42;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrt_congthuviec1;
    private XRTableCell xrt_congchinhthuc1;
    private XRTableCell xrt_congtong1;
    private XRTableCell xrt_congthuviec2;
    private XRTableCell xrt_tongchinhthuc2;
    private XRTableCell xrt_congtong2;
    private XRTableCell xrt_congthuviec3;
    private XRTableCell xrt_tongchinhthuc3;
    private XRTableCell xrt_congtong3;
    private XRTableCell xrt_congthuviec4;
    private XRTableCell xrt_congchinhthuc4;
    private XRTableCell xrt_congtong4;
    private XRTableCell xrt_congthuviec5;
    private XRTableCell xrt_congchinhthuc5;
    private XRTableCell xrt_congtong5;
    private XRTableCell xrt_congthuviec6;
    private XRTableCell xrt_congchinhthuc6;
    private XRTableCell xrt_congtong6;
    private XRTableCell xrt_congthuviec7;
    private XRTableCell xrt_congchinhthuc7;
    private XRTableCell xrt_congtong7;
    private XRTableCell xrt_congthuviec8;
    private XRTableCell xrt_congchinhthuc8;
    private XRTableCell xrt_congtong8;
    private XRTableCell xrt_congthuviec9;
    private XRTableCell xrt_congchinhthuc9;
    private XRTableCell xrt_congtong9;
    private XRTableCell xrt_congthuviec10;
    private XRTableCell xrt_congchinhthuc10;
    private XRTableCell xrt_congtong10;
    private XRTableCell xrt_congthuviec11;
    private XRTableCell xrt_congchinhthuc11;
    private XRTableCell xrt_congtong11;
    private XRTableCell xrt_congthuviec12;
    private XRTableCell xrt_congchinhthuc12;
    private XRTableCell xrt_congtong12;
    private XRTableCell xrt_congthuviectong;
    private XRTableCell xrt_congchinhthuctong;
    private XRTableCell xrt_congtongtong;
    private PageFooterBand PageFooter;
    private XRLabel xrl_ten1;
    private XRLabel xrl_ten2;
    private XRLabel xrl_ten3;
    private XRLabel xrtngayketxuat;
    private XRLabel xrl_footer2;
    private XRLabel xrl_footer3;
    private XRLabel xrl_footer1;
    private XRPageInfo xrPageInfo1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    public void BinData(ReportFilter rp)
    {

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
            string resourceFileName = "rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable28 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow41 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrt_stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tenphong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_ct1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thucviec3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thucviec6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_thuviec12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_chinhthuc12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tong12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongldthuviec = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongldchinhthuc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongldbinhquan = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_TitleBC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenCongTy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_TenThanhPho = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow31 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable19 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow32 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable20 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow33 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable21 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow34 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable22 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow35 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable23 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow36 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable24 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow37 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable25 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow38 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable26 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow39 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xagag = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable27 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow40 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow29 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrl_ten1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_ten3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_footer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrTable29 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow42 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongchinhthuc2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_tongchinhthuc3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviec12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuc12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtong12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congthuviectong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congchinhthuctong = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrt_congtongtong = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable28});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable28
            // 
            this.xrTable28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable28.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable28.Name = "xrTable28";
            this.xrTable28.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow41});
            this.xrTable28.SizeF = new System.Drawing.SizeF(2313F, 25F);
            this.xrTable28.StylePriority.UseBorders = false;
            // 
            // xrTableRow41
            // 
            this.xrTableRow41.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrt_stt,
            this.xrt_tenphong,
            this.xrTableCell87,
            this.xrt_thuviec1,
            this.xrt_ct1,
            this.xrt_tong1,
            this.xrt_thuviec2,
            this.xrt_chinhthuc2,
            this.xrt_tong2,
            this.xrt_thucviec3,
            this.xrt_chinhthuc3,
            this.xrt_tong3,
            this.xrt_thuviec4,
            this.xrt_chinhthuc4,
            this.xrt_tong4,
            this.xrt_thuviec5,
            this.xrt_chinhthuc5,
            this.xrt_tong5,
            this.xrt_thucviec6,
            this.xrt_chinhthuc6,
            this.xrt_tong6,
            this.xrt_thuviec7,
            this.xrt_chinhthuc7,
            this.xrt_tong7,
            this.xrt_thuviec8,
            this.xrt_chinhthuc8,
            this.xrt_tong8,
            this.xrt_thuviec9,
            this.xrt_chinhthuc9,
            this.xrt_tong9,
            this.xrt_thuviec10,
            this.xrt_chinhthuc10,
            this.xrt_tong10,
            this.xrt_thuviec11,
            this.xrt_chinhthuc11,
            this.xrt_tong11,
            this.xrt_thuviec12,
            this.xrt_chinhthuc12,
            this.xrt_tong12,
            this.xrt_tongldthuviec,
            this.xrt_tongldchinhthuc,
            this.xrt_tongldbinhquan});
            this.xrTableRow41.Name = "xrTableRow41";
            this.xrTableRow41.Weight = 1D;
            // 
            // xrt_stt
            // 
            this.xrt_stt.Name = "xrt_stt";
            this.xrt_stt.Weight = 0.058203743342206349D;
            // 
            // xrt_tenphong
            // 
            this.xrt_tenphong.Name = "xrt_tenphong";
            this.xrt_tenphong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrt_tenphong.StylePriority.UsePadding = false;
            this.xrt_tenphong.StylePriority.UseTextAlignment = false;
            this.xrt_tenphong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrt_tenphong.Weight = 0.16623438484102937D;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell87.StylePriority.UsePadding = false;
            this.xrTableCell87.StylePriority.UseTextAlignment = false;
            this.xrTableCell87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell87.Weight = 0.093250018972884541D;
            // 
            // xrt_thuviec1
            // 
            this.xrt_thuviec1.Name = "xrt_thuviec1";
            this.xrt_thuviec1.Weight = 0.062263506061612323D;
            // 
            // xrt_ct1
            // 
            this.xrt_ct1.Name = "xrt_ct1";
            this.xrt_ct1.Weight = 0.062263624394754427D;
            // 
            // xrt_tong1
            // 
            this.xrt_tong1.Name = "xrt_tong1";
            this.xrt_tong1.Weight = 0.062263584812936867D;
            // 
            // xrt_thuviec2
            // 
            this.xrt_thuviec2.Name = "xrt_thuviec2";
            this.xrt_thuviec2.Weight = 0.071002617235538315D;
            // 
            // xrt_chinhthuc2
            // 
            this.xrt_chinhthuc2.Name = "xrt_chinhthuc2";
            this.xrt_chinhthuc2.Weight = 0.063530876278373977D;
            // 
            // xrt_tong2
            // 
            this.xrt_tong2.Name = "xrt_tong2";
            this.xrt_tong2.Weight = 0.056310202790053721D;
            // 
            // xrt_thucviec3
            // 
            this.xrt_thucviec3.Name = "xrt_thucviec3";
            this.xrt_thucviec3.Weight = 0.073013491901217087D;
            // 
            // xrt_chinhthuc3
            // 
            this.xrt_chinhthuc3.Name = "xrt_chinhthuc3";
            this.xrt_chinhthuc3.Weight = 0.0653297111473323D;
            // 
            // xrt_tong3
            // 
            this.xrt_tong3.Name = "xrt_tong3";
            this.xrt_tong3.Weight = 0.057949008782888667D;
            // 
            // xrt_thuviec4
            // 
            this.xrt_thuviec4.Name = "xrt_thuviec4";
            this.xrt_thuviec4.Weight = 0.073013096495351981D;
            // 
            // xrt_chinhthuc4
            // 
            this.xrt_chinhthuc4.Name = "xrt_chinhthuc4";
            this.xrt_chinhthuc4.Weight = 0.065329936681230313D;
            // 
            // xrt_tong4
            // 
            this.xrt_tong4.Name = "xrt_tong4";
            this.xrt_tong4.Weight = 0.0708752008909181D;
            // 
            // xrt_thuviec5
            // 
            this.xrt_thuviec5.Name = "xrt_thuviec5";
            this.xrt_thuviec5.Weight = 0.079363036791457758D;
            // 
            // xrt_chinhthuc5
            // 
            this.xrt_chinhthuc5.Name = "xrt_chinhthuc5";
            this.xrt_chinhthuc5.Weight = 0.071011283179722468D;
            // 
            // xrt_tong5
            // 
            this.xrt_tong5.Name = "xrt_tong5";
            this.xrt_tong5.Weight = 0.062940857336363218D;
            // 
            // xrt_thucviec6
            // 
            this.xrt_thucviec6.Name = "xrt_thucviec6";
            this.xrt_thucviec6.Weight = 0.082194175770396741D;
            // 
            // xrt_chinhthuc6
            // 
            this.xrt_chinhthuc6.Name = "xrt_chinhthuc6";
            this.xrt_chinhthuc6.Weight = 0.073544597018570829D;
            // 
            // xrt_tong6
            // 
            this.xrt_tong6.Name = "xrt_tong6";
            this.xrt_tong6.Weight = 0.065186640606173893D;
            // 
            // xrt_thuviec7
            // 
            this.xrt_thuviec7.Name = "xrt_thuviec7";
            this.xrt_thuviec7.Weight = 0.082948130231462858D;
            // 
            // xrt_chinhthuc7
            // 
            this.xrt_chinhthuc7.Name = "xrt_chinhthuc7";
            this.xrt_chinhthuc7.Weight = 0.074219537925556D;
            // 
            // xrt_tong7
            // 
            this.xrt_tong7.Name = "xrt_tong7";
            this.xrt_tong7.Weight = 0.065784187515113654D;
            // 
            // xrt_thuviec8
            // 
            this.xrt_thuviec8.Name = "xrt_thuviec8";
            this.xrt_thuviec8.Weight = 0.076615037771081362D;
            // 
            // xrt_chinhthuc8
            // 
            this.xrt_chinhthuc8.Name = "xrt_chinhthuc8";
            this.xrt_chinhthuc8.Weight = 0.068552361717753779D;
            // 
            // xrt_tong8
            // 
            this.xrt_tong8.Name = "xrt_tong8";
            this.xrt_tong8.Weight = 0.073731414951287433D;
            // 
            // xrt_thuviec9
            // 
            this.xrt_thuviec9.Name = "xrt_thuviec9";
            this.xrt_thuviec9.Weight = 0.083963166361218186D;
            // 
            // xrt_chinhthuc9
            // 
            this.xrt_chinhthuc9.Name = "xrt_chinhthuc9";
            this.xrt_chinhthuc9.Weight = 0.07512818802513857D;
            // 
            // xrt_tong9
            // 
            this.xrt_tong9.Name = "xrt_tong9";
            this.xrt_tong9.Weight = 0.066589596689777875D;
            // 
            // xrt_thuviec10
            // 
            this.xrt_thuviec10.Name = "xrt_thuviec10";
            this.xrt_thuviec10.Weight = 0.077897490309579431D;
            // 
            // xrt_chinhthuc10
            // 
            this.xrt_chinhthuc10.Name = "xrt_chinhthuc10";
            this.xrt_chinhthuc10.Weight = 0.069032746446687471D;
            // 
            // xrt_tong10
            // 
            this.xrt_tong10.Name = "xrt_tong10";
            this.xrt_tong10.Weight = 0.061186808881674326D;
            // 
            // xrt_thuviec11
            // 
            this.xrt_thuviec11.Name = "xrt_thuviec11";
            this.xrt_thuviec11.Weight = 0.077951954890555217D;
            // 
            // xrt_chinhthuc11
            // 
            this.xrt_chinhthuc11.Name = "xrt_chinhthuc11";
            this.xrt_chinhthuc11.Weight = 0.069748534140162077D;
            // 
            // xrt_tong11
            // 
            this.xrt_tong11.Name = "xrt_tong11";
            this.xrt_tong11.Weight = 0.061822047576394756D;
            // 
            // xrt_thuviec12
            // 
            this.xrt_thuviec12.Name = "xrt_thuviec12";
            this.xrt_thuviec12.Weight = 0.07365843597514346D;
            // 
            // xrt_chinhthuc12
            // 
            this.xrt_chinhthuc12.Name = "xrt_chinhthuc12";
            this.xrt_chinhthuc12.Weight = 0.065907979649562645D;
            // 
            // xrt_tong12
            // 
            this.xrt_tong12.Name = "xrt_tong12";
            this.xrt_tong12.Weight = 0.058417377956326372D;
            // 
            // xrt_tongldthuviec
            // 
            this.xrt_tongldthuviec.Name = "xrt_tongldthuviec";
            this.xrt_tongldthuviec.Weight = 0.067627275268425407D;
            // 
            // xrt_tongldchinhthuc
            // 
            this.xrt_tongldchinhthuc.Name = "xrt_tongldchinhthuc";
            this.xrt_tongldchinhthuc.Weight = 0.060511251158032048D;
            // 
            // xrt_tongldbinhquan
            // 
            this.xrt_tongldbinhquan.Name = "xrt_tongldbinhquan";
            this.xrt_tongldbinhquan.Weight = 0.053632881228053861D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 47F;
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
            this.xrl_TitleBC,
            this.xrl_TenCongTy,
            this.xrl_TenThanhPho});
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_TitleBC
            // 
            this.xrl_TitleBC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_TitleBC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 52.08333F);
            this.xrl_TitleBC.Name = "xrl_TitleBC";
            this.xrl_TitleBC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TitleBC.SizeF = new System.Drawing.SizeF(2313F, 23F);
            this.xrl_TitleBC.StylePriority.UseFont = false;
            this.xrl_TitleBC.StylePriority.UseTextAlignment = false;
            this.xrl_TitleBC.Text = "BÁO CÁO SỐ LƯỢNG LAO ĐỘNG THÁNG... NĂM.....";
            this.xrl_TitleBC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenCongTy
            // 
            this.xrl_TenCongTy.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_TenCongTy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 27.08333F);
            this.xrl_TenCongTy.Name = "xrl_TenCongTy";
            this.xrl_TenCongTy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenCongTy.SizeF = new System.Drawing.SizeF(641.0156F, 23F);
            this.xrl_TenCongTy.StylePriority.UseFont = false;
            this.xrl_TenCongTy.StylePriority.UseTextAlignment = false;
            this.xrl_TenCongTy.Text = "CÔNG TY CỔ PHẦN CÔNG NGHỆ DTH VÀ GIẢI PHÁP SỐ";
            this.xrl_TenCongTy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_TenThanhPho
            // 
            this.xrl_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrl_TenThanhPho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.083333F);
            this.xrl_TenThanhPho.Name = "xrl_TenThanhPho";
            this.xrl_TenThanhPho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TenThanhPho.SizeF = new System.Drawing.SizeF(641.0156F, 23F);
            this.xrl_TenThanhPho.StylePriority.UseFont = false;
            this.xrl_TenThanhPho.StylePriority.UseTextAlignment = false;
            this.xrl_TenThanhPho.Text = "THÀNH PHỐ HÀ NỘI";
            this.xrl_TenThanhPho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader.HeightF = 132.7083F;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(2313F, 132.7083F);
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
            this.xrTableCell6,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell1,
            this.xrTableCell12,
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell10,
            this.xrTableCell14,
            this.xrTableCell2,
            this.xrTableCell15,
            this.xrTableCell31,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "STT";
            this.xrTableCell4.Weight = 0.058203770183558295D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Tên đơn vị/Phòng ban";
            this.xrTableCell5.Weight = 0.1662343145189891D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Mã đơn vị";
            this.xrTableCell6.Weight = 0.093250002533236065D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "1";
            this.xrTableCell9.Weight = 0.1867907087472008D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4,
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(144.0156F, 64.37498F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.Text = "Tháng 1";
            this.xrTableCell20.Weight = 3D;
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
            this.xrTableCell19.Text = "Số lượng";
            this.xrTableCell19.Weight = 3D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37498F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(144.0156F, 67.70833F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.Text = "Thử việc";
            this.xrTableCell16.Weight = 1D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Chính thức";
            this.xrTableCell17.Weight = 1D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "Tổng";
            this.xrTableCell18.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable5});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "2";
            this.xrTableCell7.Weight = 0.19084382706579064D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5,
            this.xrTableRow6});
            this.xrTable4.SizeF = new System.Drawing.SizeF(147.1406F, 64.37498F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.Text = "Tháng 2";
            this.xrTableCell21.Weight = 3D;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.Text = "Số lượng";
            this.xrTableCell22.Weight = 3D;
            // 
            // xrTable5
            // 
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 64.37498F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable5.SizeF = new System.Drawing.SizeF(147.1405F, 67.70832F);
            this.xrTable5.StylePriority.UseBorders = false;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.Text = "Thử việc";
            this.xrTableCell23.Weight = 1.3569927621500231D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "Chính thức";
            this.xrTableCell24.Weight = 1.21419379214638D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Text = "Tổng";
            this.xrTableCell25.Weight = 1.0761990878123122D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "1";
            this.xrTableCell8.Weight = 0.19624812995722629D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8,
            this.xrTableRow9});
            this.xrTable6.SizeF = new System.Drawing.SizeF(151.3073F, 64.37498F);
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
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.Multiline = true;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.Text = "Tháng 3\r\n";
            this.xrTableCell26.Weight = 3D;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseBorders = false;
            this.xrTableCell27.Text = "Số lượng";
            this.xrTableCell27.Weight = 3D;
            // 
            // xrTable7
            // 
            this.xrTable7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37498F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable7.SizeF = new System.Drawing.SizeF(151.3073F, 68.33332F);
            this.xrTable7.StylePriority.UseBorders = false;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.Text = "Thử việc";
            this.xrTableCell28.Weight = 1.3569927621500231D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "Chính thức";
            this.xrTableCell29.Weight = 1.21419379214638D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Text = "Tổng";
            this.xrTableCell30.Weight = 1.0761990878123122D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable18,
            this.xrTable8});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "2";
            this.xrTableCell1.Weight = 0.20926207852889281D;
            // 
            // xrTable18
            // 
            this.xrTable18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(0.03382365F, 64.37502F);
            this.xrTable18.Name = "xrTable18";
            this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow31});
            this.xrTable18.SizeF = new System.Drawing.SizeF(161.3073F, 68.33332F);
            this.xrTable18.StylePriority.UseBorders = false;
            // 
            // xrTableRow31
            // 
            this.xrTableRow31.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell52,
            this.xrTableCell53,
            this.xrTableCell54});
            this.xrTableRow31.Name = "xrTableRow31";
            this.xrTableRow31.Weight = 1D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.StylePriority.UseBorders = false;
            this.xrTableCell52.Text = "Thử việc";
            this.xrTableCell52.Weight = 1.3569927621500231D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Text = "Chính thức";
            this.xrTableCell53.Weight = 1.21419379214638D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Text = "Tổng";
            this.xrTableCell54.Weight = 1.3172573066728013D;
            // 
            // xrTable8
            // 
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11,
            this.xrTableRow12});
            this.xrTable8.SizeF = new System.Drawing.SizeF(161.3411F, 64.37498F);
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32});
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell32.Multiline = true;
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.Text = "Tháng 4\r\n";
            this.xrTableCell32.Weight = 3D;
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33});
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseBorders = false;
            this.xrTableCell33.Text = "Số lượng";
            this.xrTableCell33.Weight = 3D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable19,
            this.xrTable9});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "3";
            this.xrTableCell12.Weight = 0.21331525622020278D;
            // 
            // xrTable19
            // 
            this.xrTable19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable19.LocationFloat = new DevExpress.Utils.PointFloat(0.0001220703F, 64.37502F);
            this.xrTable19.Name = "xrTable19";
            this.xrTable19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow32});
            this.xrTable19.SizeF = new System.Drawing.SizeF(164.4659F, 68.33333F);
            this.xrTable19.StylePriority.UseBorders = false;
            // 
            // xrTableRow32
            // 
            this.xrTableRow32.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell55,
            this.xrTableCell56,
            this.xrTableCell57});
            this.xrTableRow32.Name = "xrTableRow32";
            this.xrTableRow32.Weight = 1D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StylePriority.UseBorders = false;
            this.xrTableCell55.Text = "Thử việc";
            this.xrTableCell55.Weight = 1.3569927621500231D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Text = "Chính thức";
            this.xrTableCell56.Weight = 1.21419379214638D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Text = "Tổng";
            this.xrTableCell57.Weight = 1.0761990878123122D;
            // 
            // xrTable9
            // 
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0.0001220703F, 0F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13,
            this.xrTableRow14});
            this.xrTable9.SizeF = new System.Drawing.SizeF(164.4659F, 64.37498F);
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell34});
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell34.Multiline = true;
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StylePriority.UseBorders = false;
            this.xrTableCell34.Text = "Tháng 5\r\n";
            this.xrTableCell34.Weight = 3D;
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell35});
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Weight = 1D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StylePriority.UseBorders = false;
            this.xrTableCell35.Text = "Số lượng";
            this.xrTableCell35.Weight = 3D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10,
            this.xrTable20});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "4";
            this.xrTableCell11.Weight = 0.22092525813675415D;
            // 
            // xrTable10
            // 
            this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable10.Name = "xrTable10";
            this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15,
            this.xrTableRow16});
            this.xrTable10.SizeF = new System.Drawing.SizeF(170.3334F, 64.37498F);
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell36});
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Weight = 1D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell36.Multiline = true;
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseBorders = false;
            this.xrTableCell36.Text = "Tháng 6\r\n";
            this.xrTableCell36.Weight = 3D;
            // 
            // xrTableRow16
            // 
            this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37});
            this.xrTableRow16.Name = "xrTableRow16";
            this.xrTableRow16.Weight = 1D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseBorders = false;
            this.xrTableCell37.Text = "Số lượng";
            this.xrTableCell37.Weight = 3D;
            // 
            // xrTable20
            // 
            this.xrTable20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable20.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 64.37502F);
            this.xrTable20.Name = "xrTable20";
            this.xrTable20.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow33});
            this.xrTable20.SizeF = new System.Drawing.SizeF(170.3331F, 68.33333F);
            this.xrTable20.StylePriority.UseBorders = false;
            // 
            // xrTableRow33
            // 
            this.xrTableRow33.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell58,
            this.xrTableCell59,
            this.xrTableCell60});
            this.xrTableRow33.Name = "xrTableRow33";
            this.xrTableRow33.Weight = 1D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.StylePriority.UseBorders = false;
            this.xrTableCell58.Text = "Thử việc";
            this.xrTableCell58.Weight = 1.3569927621500231D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Text = "Chính thức";
            this.xrTableCell59.Weight = 1.21419379214638D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Text = "Tổng";
            this.xrTableCell60.Weight = 1.0761990878123122D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable21,
            this.xrTable11});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "5";
            this.xrTableCell13.Weight = 0.2229520053096628D;
            // 
            // xrTable21
            // 
            this.xrTable21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable21.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37502F);
            this.xrTable21.Name = "xrTable21";
            this.xrTable21.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow34});
            this.xrTable21.SizeF = new System.Drawing.SizeF(171.8961F, 67.7083F);
            this.xrTable21.StylePriority.UseBorders = false;
            // 
            // xrTableRow34
            // 
            this.xrTableRow34.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell63});
            this.xrTableRow34.Name = "xrTableRow34";
            this.xrTableRow34.Weight = 0.990853211257057D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.StylePriority.UseBorders = false;
            this.xrTableCell61.Text = "Thử việc";
            this.xrTableCell61.Weight = 1.3569927621500231D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Text = "Chính thức";
            this.xrTableCell62.Weight = 1.21419379214638D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Text = "Tổng";
            this.xrTableCell63.Weight = 1.0761990878123122D;
            // 
            // xrTable11
            // 
            this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable11.Name = "xrTable11";
            this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17,
            this.xrTableRow18});
            this.xrTable11.SizeF = new System.Drawing.SizeF(171.8961F, 64.37498F);
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell38});
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Weight = 1D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell38.Multiline = true;
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StylePriority.UseBorders = false;
            this.xrTableCell38.Text = "Tháng 7\r\n";
            this.xrTableCell38.Weight = 3D;
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell39});
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Weight = 1D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.StylePriority.UseBorders = false;
            this.xrTableCell39.Text = "Số lượng";
            this.xrTableCell39.Weight = 3D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable22,
            this.xrTable12});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "6";
            this.xrTableCell10.Weight = 0.21889851096384569D;
            // 
            // xrTable22
            // 
            this.xrTable22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable22.LocationFloat = new DevExpress.Utils.PointFloat(0.0003662109F, 64.37502F);
            this.xrTable22.Name = "xrTable22";
            this.xrTable22.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow35});
            this.xrTable22.SizeF = new System.Drawing.SizeF(168.7704F, 67.7083F);
            this.xrTable22.StylePriority.UseBorders = false;
            // 
            // xrTableRow35
            // 
            this.xrTableRow35.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell64,
            this.xrTableCell65,
            this.xrTableCell66});
            this.xrTableRow35.Name = "xrTableRow35";
            this.xrTableRow35.Weight = 1D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.StylePriority.UseBorders = false;
            this.xrTableCell64.Text = "Thử việc";
            this.xrTableCell64.Weight = 1.3569927621500231D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Text = "Chính thức";
            this.xrTableCell65.Weight = 1.21419379214638D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Text = "Tổng";
            this.xrTableCell66.Weight = 1.305923883654319D;
            // 
            // xrTable12
            // 
            this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(0.0002441406F, 0F);
            this.xrTable12.Name = "xrTable12";
            this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19,
            this.xrTableRow20});
            this.xrTable12.SizeF = new System.Drawing.SizeF(168.7706F, 64.37498F);
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell40});
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Weight = 1D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell40.Multiline = true;
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.StylePriority.UseBorders = false;
            this.xrTableCell40.Text = "Tháng 8\r\n";
            this.xrTableCell40.Weight = 3D;
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41});
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.Text = "Số lượng";
            this.xrTableCell41.Weight = 3D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable23,
            this.xrTable13});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "7";
            this.xrTableCell14.Weight = 0.22568109217939361D;
            // 
            // xrTable23
            // 
            this.xrTable23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable23.LocationFloat = new DevExpress.Utils.PointFloat(0.0002543131F, 64.37502F);
            this.xrTable23.Name = "xrTable23";
            this.xrTable23.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow36});
            this.xrTable23.SizeF = new System.Drawing.SizeF(174F, 68.33333F);
            this.xrTable23.StylePriority.UseBorders = false;
            // 
            // xrTableRow36
            // 
            this.xrTableRow36.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell67,
            this.xrTableCell68,
            this.xrTableCell69});
            this.xrTableRow36.Name = "xrTableRow36";
            this.xrTableRow36.Weight = 1D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.StylePriority.UseBorders = false;
            this.xrTableCell67.Text = "Thử việc";
            this.xrTableCell67.Weight = 1.3569927621500231D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Text = "Chính thức";
            this.xrTableCell68.Weight = 1.21419379214638D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Text = "Tổng";
            this.xrTableCell69.Weight = 1.0761990878123122D;
            // 
            // xrTable13
            // 
            this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0.0002441406F, 0F);
            this.xrTable13.Name = "xrTable13";
            this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow21,
            this.xrTableRow22});
            this.xrTable13.SizeF = new System.Drawing.SizeF(174F, 64.37498F);
            // 
            // xrTableRow21
            // 
            this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell42});
            this.xrTableRow21.Name = "xrTableRow21";
            this.xrTableRow21.Weight = 1D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell42.Multiline = true;
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.Text = "Tháng 9\r\n";
            this.xrTableCell42.Weight = 3D;
            // 
            // xrTableRow22
            // 
            this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell43});
            this.xrTableRow22.Name = "xrTableRow22";
            this.xrTableRow22.Weight = 1D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StylePriority.UseBorders = false;
            this.xrTableCell43.Text = "Số lượng";
            this.xrTableCell43.Weight = 3D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable24,
            this.xrTable14});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "8";
            this.xrTableCell2.Weight = 0.20811705830496105D;
            // 
            // xrTable24
            // 
            this.xrTable24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37502F);
            this.xrTable24.Name = "xrTable24";
            this.xrTable24.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow37});
            this.xrTable24.SizeF = new System.Drawing.SizeF(160.4585F, 67.7083F);
            this.xrTable24.StylePriority.UseBorders = false;
            // 
            // xrTableRow37
            // 
            this.xrTableRow37.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell70,
            this.xrTableCell71,
            this.xrTableCell72});
            this.xrTableRow37.Name = "xrTableRow37";
            this.xrTableRow37.Weight = 1D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StylePriority.UseBorders = false;
            this.xrTableCell70.Text = "Thử việc";
            this.xrTableCell70.Weight = 1.3701256707355631D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.Text = "Chính thức";
            this.xrTableCell71.Weight = 1.21419379214638D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Text = "Tổng";
            this.xrTableCell72.Weight = 1.0761990878123122D;
            // 
            // xrTable14
            // 
            this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable14.Name = "xrTable14";
            this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow23,
            this.xrTableRow24});
            this.xrTable14.SizeF = new System.Drawing.SizeF(160.4583F, 64.37498F);
            // 
            // xrTableRow23
            // 
            this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell44});
            this.xrTableRow23.Name = "xrTableRow23";
            this.xrTableRow23.Weight = 1D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell44.Multiline = true;
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.Text = "Tháng 10\r\n";
            this.xrTableCell44.Weight = 3D;
            // 
            // xrTableRow24
            // 
            this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45});
            this.xrTableRow24.Name = "xrTableRow24";
            this.xrTableRow24.Weight = 1D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.Text = "Số lượng";
            this.xrTableCell45.Weight = 3D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable25,
            this.xrTable15});
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "9";
            this.xrTableCell15.Weight = 0.20952237100762D;
            // 
            // xrTable25
            // 
            this.xrTable25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable25.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37502F);
            this.xrTable25.Name = "xrTable25";
            this.xrTable25.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow38});
            this.xrTable25.SizeF = new System.Drawing.SizeF(161.5419F, 68.33333F);
            this.xrTable25.StylePriority.UseBorders = false;
            // 
            // xrTableRow38
            // 
            this.xrTableRow38.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell75});
            this.xrTableRow38.Name = "xrTableRow38";
            this.xrTableRow38.Weight = 1D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.StylePriority.UseBorders = false;
            this.xrTableCell73.Text = "Thử việc";
            this.xrTableCell73.Weight = 1.3569927621500231D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Text = "Chính thức";
            this.xrTableCell74.Weight = 1.21419379214638D;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Text = "Tổng";
            this.xrTableCell75.Weight = 1.0761990878123122D;
            // 
            // xrTable15
            // 
            this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable15.Name = "xrTable15";
            this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow25,
            this.xrTableRow26});
            this.xrTable15.SizeF = new System.Drawing.SizeF(161.5417F, 64.37498F);
            // 
            // xrTableRow25
            // 
            this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell46});
            this.xrTableRow25.Name = "xrTableRow25";
            this.xrTableRow25.Weight = 1D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell46.Multiline = true;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.Text = "Tháng 11\r\n";
            this.xrTableCell46.Weight = 3D;
            // 
            // xrTableRow26
            // 
            this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell47});
            this.xrTableRow26.Name = "xrTableRow26";
            this.xrTableRow26.Weight = 1D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.StylePriority.UseBorders = false;
            this.xrTableCell47.Text = "Số lượng";
            this.xrTableCell47.Weight = 3D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable26,
            this.xrTable16});
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "10";
            this.xrTableCell31.Weight = 0.19798395574943256D;
            // 
            // xrTable26
            // 
            this.xrTable26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable26.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37502F);
            this.xrTable26.Name = "xrTable26";
            this.xrTable26.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow39});
            this.xrTable26.SizeF = new System.Drawing.SizeF(152.6454F, 68.33333F);
            this.xrTable26.StylePriority.UseBorders = false;
            // 
            // xrTableRow39
            // 
            this.xrTableRow39.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell76,
            this.xrTableCell77,
            this.xagag});
            this.xrTableRow39.Name = "xrTableRow39";
            this.xrTableRow39.Weight = 1D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.StylePriority.UseBorders = false;
            this.xrTableCell76.Text = "Thử việc";
            this.xrTableCell76.Weight = 1.3569927621500231D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Text = "Chính thức";
            this.xrTableCell77.Weight = 1.21419379214638D;
            // 
            // xagag
            // 
            this.xagag.Name = "xagag";
            this.xagag.Text = "Tổng";
            this.xagag.Weight = 1.0761990878123122D;
            // 
            // xrTable16
            // 
            this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable16.Name = "xrTable16";
            this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow27,
            this.xrTableRow28});
            this.xrTable16.SizeF = new System.Drawing.SizeF(152.6456F, 64.37498F);
            // 
            // xrTableRow27
            // 
            this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell48});
            this.xrTableRow27.Name = "xrTableRow27";
            this.xrTableRow27.Weight = 1D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell48.Multiline = true;
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.StylePriority.UseBorders = false;
            this.xrTableCell48.Text = "Tháng 12\r\n";
            this.xrTableCell48.Weight = 3D;
            // 
            // xrTableRow28
            // 
            this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49});
            this.xrTableRow28.Name = "xrTableRow28";
            this.xrTableRow28.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.Text = "Số lượng";
            this.xrTableCell49.Weight = 3D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable27,
            this.xrTable17});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "11";
            this.xrTableCell3.Weight = 0.18177166059323319D;
            // 
            // xrTable27
            // 
            this.xrTable27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable27.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64.37502F);
            this.xrTable27.Name = "xrTable27";
            this.xrTable27.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow40});
            this.xrTable27.SizeF = new System.Drawing.SizeF(140.146F, 67.7083F);
            this.xrTable27.StylePriority.UseBorders = false;
            // 
            // xrTableRow40
            // 
            this.xrTableRow40.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell81});
            this.xrTableRow40.Name = "xrTableRow40";
            this.xrTableRow40.Weight = 1D;
            // 
            // xrTableCell79
            // 
            this.xrTableCell79.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.StylePriority.UseBorders = false;
            this.xrTableCell79.Text = "Thử việc";
            this.xrTableCell79.Weight = 1.3569927621500231D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.Text = "Chính thức";
            this.xrTableCell80.Weight = 1.21419379214638D;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.Text = "Tổng";
            this.xrTableCell81.Weight = 1.0761990878123122D;
            // 
            // xrTable17
            // 
            this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable17.Name = "xrTable17";
            this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow29,
            this.xrTableRow30});
            this.xrTable17.SizeF = new System.Drawing.SizeF(140.146F, 64.37498F);
            // 
            // xrTableRow29
            // 
            this.xrTableRow29.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell50});
            this.xrTableRow29.Name = "xrTableRow29";
            this.xrTableRow29.Weight = 1D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell50.Multiline = true;
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.Text = "Tổng lao động BQ";
            this.xrTableCell50.Weight = 3D;
            // 
            // xrTableRow30
            // 
            this.xrTableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell51});
            this.xrTableRow30.Name = "xrTableRow30";
            this.xrTableRow30.Weight = 1D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseBorders = false;
            this.xrTableCell51.Text = "Số lượng";
            this.xrTableCell51.Weight = 3D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_ten1,
            this.xrl_ten2,
            this.xrl_ten3,
            this.xrtngayketxuat,
            this.xrl_footer2,
            this.xrl_footer3,
            this.xrl_footer1});
            this.ReportFooter.HeightF = 351F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrl_ten1
            // 
            this.xrl_ten1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten1.LocationFloat = new DevExpress.Utils.PointFloat(94.14533F, 124.875F);
            this.xrl_ten1.Name = "xrl_ten1";
            this.xrl_ten1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten1.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten1.StylePriority.UseFont = false;
            this.xrl_ten1.StylePriority.UseTextAlignment = false;
            this.xrl_ten1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten2
            // 
            this.xrl_ten2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten2.LocationFloat = new DevExpress.Utils.PointFloat(996.875F, 149.875F);
            this.xrl_ten2.Name = "xrl_ten2";
            this.xrl_ten2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten2.SizeF = new System.Drawing.SizeF(302.1819F, 23F);
            this.xrl_ten2.StylePriority.UseFont = false;
            this.xrl_ten2.StylePriority.UseTextAlignment = false;
            this.xrl_ten2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_ten3
            // 
            this.xrl_ten3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrl_ten3.LocationFloat = new DevExpress.Utils.PointFloat(1953.125F, 149.875F);
            this.xrl_ten3.Name = "xrl_ten3";
            this.xrl_ten3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_ten3.SizeF = new System.Drawing.SizeF(296.5F, 23F);
            this.xrl_ten3.StylePriority.UseFont = false;
            this.xrl_ten3.StylePriority.UseTextAlignment = false;
            this.xrl_ten3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrtngayketxuat
            // 
            this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(1953.125F, 24.87501F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(296.5F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.StylePriority.UseTextAlignment = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày 15 tháng 4 năm 2013";
            this.xrtngayketxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer2
            // 
            this.xrl_footer2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer2.LocationFloat = new DevExpress.Utils.PointFloat(996.875F, 49.875F);
            this.xrl_footer2.Name = "xrl_footer2";
            this.xrl_footer2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer2.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer2.StylePriority.UseFont = false;
            this.xrl_footer2.StylePriority.UseTextAlignment = false;
            this.xrl_footer2.Text = "PHÒNG TCHC";
            this.xrl_footer2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer3
            // 
            this.xrl_footer3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer3.LocationFloat = new DevExpress.Utils.PointFloat(1953.125F, 49.875F);
            this.xrl_footer3.Name = "xrl_footer3";
            this.xrl_footer3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer3.SizeF = new System.Drawing.SizeF(296.5002F, 23F);
            this.xrl_footer3.StylePriority.UseFont = false;
            this.xrl_footer3.StylePriority.UseTextAlignment = false;
            this.xrl_footer3.Text = "GIÁM ĐỐC";
            this.xrl_footer3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrl_footer1
            // 
            this.xrl_footer1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrl_footer1.LocationFloat = new DevExpress.Utils.PointFloat(94.14533F, 24.87501F);
            this.xrl_footer1.Name = "xrl_footer1";
            this.xrl_footer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_footer1.SizeF = new System.Drawing.SizeF(304.1828F, 23F);
            this.xrl_footer1.StylePriority.UseFont = false;
            this.xrl_footer1.StylePriority.UseTextAlignment = false;
            this.xrl_footer1.Text = "NGƯỜI LẬP";
            this.xrl_footer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable29});
            this.GroupFooter1.HeightF = 25F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrTable29
            // 
            this.xrTable29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable29.Name = "xrTable29";
            this.xrTable29.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow42});
            this.xrTable29.SizeF = new System.Drawing.SizeF(2313F, 25F);
            this.xrTable29.StylePriority.UseBorders = false;
            // 
            // xrTableRow42
            // 
            this.xrTableRow42.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell78,
            this.xrTableCell82,
            this.xrTableCell83,
            this.xrt_congthuviec1,
            this.xrt_congchinhthuc1,
            this.xrt_congtong1,
            this.xrt_congthuviec2,
            this.xrt_tongchinhthuc2,
            this.xrt_congtong2,
            this.xrt_congthuviec3,
            this.xrt_tongchinhthuc3,
            this.xrt_congtong3,
            this.xrt_congthuviec4,
            this.xrt_congchinhthuc4,
            this.xrt_congtong4,
            this.xrt_congthuviec5,
            this.xrt_congchinhthuc5,
            this.xrt_congtong5,
            this.xrt_congthuviec6,
            this.xrt_congchinhthuc6,
            this.xrt_congtong6,
            this.xrt_congthuviec7,
            this.xrt_congchinhthuc7,
            this.xrt_congtong7,
            this.xrt_congthuviec8,
            this.xrt_congchinhthuc8,
            this.xrt_congtong8,
            this.xrt_congthuviec9,
            this.xrt_congchinhthuc9,
            this.xrt_congtong9,
            this.xrt_congthuviec10,
            this.xrt_congchinhthuc10,
            this.xrt_congtong10,
            this.xrt_congthuviec11,
            this.xrt_congchinhthuc11,
            this.xrt_congtong11,
            this.xrt_congthuviec12,
            this.xrt_congchinhthuc12,
            this.xrt_congtong12,
            this.xrt_congthuviectong,
            this.xrt_congchinhthuctong,
            this.xrt_congtongtong});
            this.xrTableRow42.Name = "xrTableRow42";
            this.xrTableRow42.Weight = 1D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Weight = 0.058203743342206349D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell82.StylePriority.UseFont = false;
            this.xrTableCell82.StylePriority.UsePadding = false;
            this.xrTableCell82.StylePriority.UseTextAlignment = false;
            this.xrTableCell82.Text = "Cộng";
            this.xrTableCell82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell82.Weight = 0.16623438484102937D;
            // 
            // xrTableCell83
            // 
            this.xrTableCell83.Name = "xrTableCell83";
            this.xrTableCell83.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell83.StylePriority.UsePadding = false;
            this.xrTableCell83.StylePriority.UseTextAlignment = false;
            this.xrTableCell83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell83.Weight = 0.093250018972884541D;
            // 
            // xrt_congthuviec1
            // 
            this.xrt_congthuviec1.Name = "xrt_congthuviec1";
            this.xrt_congthuviec1.Weight = 0.062263506061612323D;
            // 
            // xrt_congchinhthuc1
            // 
            this.xrt_congchinhthuc1.Name = "xrt_congchinhthuc1";
            this.xrt_congchinhthuc1.Weight = 0.062263624394754427D;
            // 
            // xrt_congtong1
            // 
            this.xrt_congtong1.Name = "xrt_congtong1";
            this.xrt_congtong1.Weight = 0.062263584812936867D;
            // 
            // xrt_congthuviec2
            // 
            this.xrt_congthuviec2.Name = "xrt_congthuviec2";
            this.xrt_congthuviec2.Weight = 0.071002617235538315D;
            // 
            // xrt_tongchinhthuc2
            // 
            this.xrt_tongchinhthuc2.Name = "xrt_tongchinhthuc2";
            this.xrt_tongchinhthuc2.Weight = 0.063530876278373977D;
            // 
            // xrt_congtong2
            // 
            this.xrt_congtong2.Name = "xrt_congtong2";
            this.xrt_congtong2.Weight = 0.056310202790053721D;
            // 
            // xrt_congthuviec3
            // 
            this.xrt_congthuviec3.Name = "xrt_congthuviec3";
            this.xrt_congthuviec3.Weight = 0.073013491901217087D;
            // 
            // xrt_tongchinhthuc3
            // 
            this.xrt_tongchinhthuc3.Name = "xrt_tongchinhthuc3";
            this.xrt_tongchinhthuc3.Weight = 0.0653297111473323D;
            // 
            // xrt_congtong3
            // 
            this.xrt_congtong3.Name = "xrt_congtong3";
            this.xrt_congtong3.Weight = 0.057949008782888667D;
            // 
            // xrt_congthuviec4
            // 
            this.xrt_congthuviec4.Name = "xrt_congthuviec4";
            this.xrt_congthuviec4.Weight = 0.073013096495351981D;
            // 
            // xrt_congchinhthuc4
            // 
            this.xrt_congchinhthuc4.Name = "xrt_congchinhthuc4";
            this.xrt_congchinhthuc4.Weight = 0.065329936681230313D;
            // 
            // xrt_congtong4
            // 
            this.xrt_congtong4.Name = "xrt_congtong4";
            this.xrt_congtong4.Weight = 0.0708752008909181D;
            // 
            // xrt_congthuviec5
            // 
            this.xrt_congthuviec5.Name = "xrt_congthuviec5";
            this.xrt_congthuviec5.Weight = 0.079363036791457758D;
            // 
            // xrt_congchinhthuc5
            // 
            this.xrt_congchinhthuc5.Name = "xrt_congchinhthuc5";
            this.xrt_congchinhthuc5.Weight = 0.071011283179722468D;
            // 
            // xrt_congtong5
            // 
            this.xrt_congtong5.Name = "xrt_congtong5";
            this.xrt_congtong5.Weight = 0.062940857336363218D;
            // 
            // xrt_congthuviec6
            // 
            this.xrt_congthuviec6.Name = "xrt_congthuviec6";
            this.xrt_congthuviec6.Weight = 0.082194175770396741D;
            // 
            // xrt_congchinhthuc6
            // 
            this.xrt_congchinhthuc6.Name = "xrt_congchinhthuc6";
            this.xrt_congchinhthuc6.Weight = 0.073544597018570829D;
            // 
            // xrt_congtong6
            // 
            this.xrt_congtong6.Name = "xrt_congtong6";
            this.xrt_congtong6.Weight = 0.065186640606173893D;
            // 
            // xrt_congthuviec7
            // 
            this.xrt_congthuviec7.Name = "xrt_congthuviec7";
            this.xrt_congthuviec7.Weight = 0.082948130231462858D;
            // 
            // xrt_congchinhthuc7
            // 
            this.xrt_congchinhthuc7.Name = "xrt_congchinhthuc7";
            this.xrt_congchinhthuc7.Weight = 0.074219537925556D;
            // 
            // xrt_congtong7
            // 
            this.xrt_congtong7.Name = "xrt_congtong7";
            this.xrt_congtong7.Weight = 0.065784187515113654D;
            // 
            // xrt_congthuviec8
            // 
            this.xrt_congthuviec8.Name = "xrt_congthuviec8";
            this.xrt_congthuviec8.Weight = 0.076615037771081362D;
            // 
            // xrt_congchinhthuc8
            // 
            this.xrt_congchinhthuc8.Name = "xrt_congchinhthuc8";
            this.xrt_congchinhthuc8.Weight = 0.068552361717753779D;
            // 
            // xrt_congtong8
            // 
            this.xrt_congtong8.Name = "xrt_congtong8";
            this.xrt_congtong8.Weight = 0.073731414951287433D;
            // 
            // xrt_congthuviec9
            // 
            this.xrt_congthuviec9.Name = "xrt_congthuviec9";
            this.xrt_congthuviec9.Weight = 0.083963166361218186D;
            // 
            // xrt_congchinhthuc9
            // 
            this.xrt_congchinhthuc9.Name = "xrt_congchinhthuc9";
            this.xrt_congchinhthuc9.Weight = 0.07512818802513857D;
            // 
            // xrt_congtong9
            // 
            this.xrt_congtong9.Name = "xrt_congtong9";
            this.xrt_congtong9.Weight = 0.066589596689777875D;
            // 
            // xrt_congthuviec10
            // 
            this.xrt_congthuviec10.Name = "xrt_congthuviec10";
            this.xrt_congthuviec10.Weight = 0.077897490309579431D;
            // 
            // xrt_congchinhthuc10
            // 
            this.xrt_congchinhthuc10.Name = "xrt_congchinhthuc10";
            this.xrt_congchinhthuc10.Weight = 0.069032746446687471D;
            // 
            // xrt_congtong10
            // 
            this.xrt_congtong10.Name = "xrt_congtong10";
            this.xrt_congtong10.Weight = 0.061186808881674326D;
            // 
            // xrt_congthuviec11
            // 
            this.xrt_congthuviec11.Name = "xrt_congthuviec11";
            this.xrt_congthuviec11.Weight = 0.077951954890555217D;
            // 
            // xrt_congchinhthuc11
            // 
            this.xrt_congchinhthuc11.Name = "xrt_congchinhthuc11";
            this.xrt_congchinhthuc11.Weight = 0.069748534140162077D;
            // 
            // xrt_congtong11
            // 
            this.xrt_congtong11.Name = "xrt_congtong11";
            this.xrt_congtong11.Weight = 0.061822047576394756D;
            // 
            // xrt_congthuviec12
            // 
            this.xrt_congthuviec12.Name = "xrt_congthuviec12";
            this.xrt_congthuviec12.Weight = 0.07365843597514346D;
            // 
            // xrt_congchinhthuc12
            // 
            this.xrt_congchinhthuc12.Name = "xrt_congchinhthuc12";
            this.xrt_congchinhthuc12.Weight = 0.065907979649562645D;
            // 
            // xrt_congtong12
            // 
            this.xrt_congtong12.Name = "xrt_congtong12";
            this.xrt_congtong12.Weight = 0.058417377956326372D;
            // 
            // xrt_congthuviectong
            // 
            this.xrt_congthuviectong.Name = "xrt_congthuviectong";
            this.xrt_congthuviectong.Weight = 0.067627275268425407D;
            // 
            // xrt_congchinhthuctong
            // 
            this.xrt_congchinhthuctong.Name = "xrt_congchinhthuctong";
            this.xrt_congchinhthuctong.Weight = 0.060511251158032048D;
            // 
            // xrt_congtongtong
            // 
            this.xrt_congtongtong.Name = "xrt_congtongtong";
            this.xrt_congtongtong.Weight = 0.053632881228053861D;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrPageInfo1.Format = "Trang {0} của {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2186.958F, 37.5F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.GroupFooter1,
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 47, 100);
            this.PageHeight = 1654;
            this.PageWidth = 2339;
            this.PaperKind = System.Drawing.Printing.PaperKind.A2;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
