using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;

/// <summary>
/// Summary description for rp_austfeed_BaoCaoLamThemGio
/// </summary>
public class rp_austfeed_BaoCaoLamThemGio : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell40;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell39;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell45;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell49;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell50;
    private XRTable xrTable11;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTable xrTable10;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell55;
    private XRTable xrTable13;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell64;
    private XRTable xrTable12;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell60;
    private XRTable xrTable15;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private XRTable xrTable14;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell65;
    private XRTable xrTable17;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTable xrTable16;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell70;
    private XRTable xrTable19;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTable xrTable18;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell75;
    private XRTable xrTable21;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTable xrTable20;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell80;
    private XRTable xrTable23;
    private XRTableRow xrTableRow23;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTable xrTable22;
    private XRTableRow xrTableRow22;
    private XRTableCell xrTableCell85;
    private XRTable xrTable25;
    private XRTableRow xrTableRow25;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTable xrTable24;
    private XRTableRow xrTableRow24;
    private XRTableCell xrTableCell90;
    private XRTable xrTable27;
    private XRTableRow xrTableRow27;
    private XRTableCell xrTableCell96;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTable xrTable26;
    private XRTableRow xrTableRow26;
    private XRTableCell xrTableCell95;
    private XRTable xrTable29;
    private XRTableRow xrTableRow29;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTable xrTable28;
    private XRTableRow xrTableRow28;
    private XRTableCell xrTableCell100;
    private XRTable xrTable31;
    private XRTableRow xrTableRow31;
    private XRTableCell xrTableCell106;
    private XRTableCell xrTableCell107;
    private XRTableCell xrTableCell108;
    private XRTableCell xrTableCell109;
    private XRTable xrTable30;
    private XRTableRow xrTableRow30;
    private XRTableCell xrTableCell105;
    private XRTable xrTable33;
    private XRTableRow xrTableRow33;
    private XRTableCell xrTableCell111;
    private XRTableCell xrTableCell112;
    private XRTableCell xrTableCell113;
    private XRTableCell xrTableCell114;
    private XRTable xrTable32;
    private XRTableRow xrTableRow32;
    private XRTableCell xrTableCell110;
    private XRTable xrTable35;
    private XRTableRow xrTableRow35;
    private XRTableCell xrTableCell116;
    private XRTableCell xrTableCell117;
    private XRTableCell xrTableCell118;
    private XRTableCell xrTableCell119;
    private XRTable xrTable34;
    private XRTableRow xrTableRow34;
    private XRTableCell xrTableCell115;
    private XRTable xrTable37;
    private XRTableRow xrTableRow37;
    private XRTableCell xrTableCell121;
    private XRTableCell xrTableCell122;
    private XRTableCell xrTableCell123;
    private XRTableCell xrTableCell124;
    private XRTable xrTable36;
    private XRTableRow xrTableRow36;
    private XRTableCell xrTableCell120;
    private XRTable xrTable39;
    private XRTableRow xrTableRow39;
    private XRTableCell xrTableCell126;
    private XRTableCell xrTableCell127;
    private XRTableCell xrTableCell128;
    private XRTableCell xrTableCell129;
    private XRTable xrTable38;
    private XRTableRow xrTableRow38;
    private XRTableCell xrTableCell125;
    private XRTable xrTable41;
    private XRTableRow xrTableRow41;
    private XRTableCell xrTableCell131;
    private XRTableCell xrTableCell132;
    private XRTableCell xrTableCell133;
    private XRTableCell xrTableCell134;
    private XRTable xrTable40;
    private XRTableRow xrTableRow40;
    private XRTableCell xrTableCell130;
    private XRTable xrTable43;
    private XRTableRow xrTableRow43;
    private XRTableCell xrTableCell136;
    private XRTableCell xrTableCell137;
    private XRTableCell xrTableCell138;
    private XRTableCell xrTableCell139;
    private XRTable xrTable42;
    private XRTableRow xrTableRow42;
    private XRTableCell xrTableCell135;
    private XRTable xrTable45;
    private XRTableRow xrTableRow45;
    private XRTableCell xrTableCell141;
    private XRTableCell xrTableCell142;
    private XRTableCell xrTableCell143;
    private XRTableCell xrTableCell144;
    private XRTable xrTable44;
    private XRTableRow xrTableRow44;
    private XRTableCell xrTableCell140;
    private XRTable xrTable47;
    private XRTableRow xrTableRow47;
    private XRTableCell xrTableCell146;
    private XRTableCell xrTableCell147;
    private XRTableCell xrTableCell148;
    private XRTableCell xrTableCell149;
    private XRTable xrTable46;
    private XRTableRow xrTableRow46;
    private XRTableCell xrTableCell145;
    private XRTable xrTable49;
    private XRTableRow xrTableRow49;
    private XRTableCell xrTableCell151;
    private XRTableCell xrTableCell152;
    private XRTableCell xrTableCell153;
    private XRTableCell xrTableCell154;
    private XRTable xrTable48;
    private XRTableRow xrTableRow48;
    private XRTableCell xrTableCell150;
    private XRTable xrTable51;
    private XRTableRow xrTableRow51;
    private XRTableCell xrTableCell156;
    private XRTableCell xrTableCell157;
    private XRTableCell xrTableCell158;
    private XRTableCell xrTableCell159;
    private XRTable xrTable50;
    private XRTableRow xrTableRow50;
    private XRTableCell xrTableCell155;
    private XRTable xrTable53;
    private XRTableRow xrTableRow53;
    private XRTableCell xrTableCell164;
    private XRTable xrTable52;
    private XRTableRow xrTableRow52;
    private XRTableCell xrTableCell160;
    private XRTableCell xrTableCell161;
    private XRTableCell xrTableCell162;
    private XRTableCell xrTableCell163;
    private XRTable xrTable55;
    private XRTableRow xrTableRow55;
    private XRTableCell xrTableCell169;
    private XRTable xrTable54;
    private XRTableRow xrTableRow54;
    private XRTableCell xrTableCell165;
    private XRTableCell xrTableCell166;
    private XRTableCell xrTableCell167;
    private XRTableCell xrTableCell168;
    private XRTable xrTable57;
    private XRTableRow xrTableRow57;
    private XRTableCell xrTableCell174;
    private XRTable xrTable56;
    private XRTableRow xrTableRow56;
    private XRTableCell xrTableCell170;
    private XRTableCell xrTableCell171;
    private XRTableCell xrTableCell172;
    private XRTableCell xrTableCell173;
    private XRTable xrTable59;
    private XRTableRow xrTableRow59;
    private XRTableCell xrTableCell179;
    private XRTable xrTable58;
    private XRTableRow xrTableRow58;
    private XRTableCell xrTableCell175;
    private XRTableCell xrTableCell176;
    private XRTableCell xrTableCell177;
    private XRTableCell xrTableCell178;
    private XRTable xrTable61;
    private XRTableRow xrTableRow61;
    private XRTableCell xrTableCell184;
    private XRTable xrTable60;
    private XRTableRow xrTableRow60;
    private XRTableCell xrTableCell180;
    private XRTableCell xrTableCell181;
    private XRTableCell xrTableCell182;
    private XRTableCell xrTableCell183;
    private XRTable xrTable63;
    private XRTableRow xrTableRow63;
    private XRTableCell xrTableCell186;
    private XRTableCell xrTableCell187;
    private XRTableCell xrTableCell188;
    private XRTableCell xrTableCell189;
    private XRTable xrTable62;
    private XRTableRow xrTableRow62;
    private XRTableCell xrTableCell185;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable64;
    private XRTableRow xrTableRow64;
    private XRTableCell xrTableCell196;
    private XRTable xrTable66;
    private XRTableRow xrTableRow66;
    private XRTableCell xrTableCell195;
    private XRTableCell xrTableCell197;
    private XRTableCell xrTableCell198;
    private XRTableCell xrTableCell199;
    private XRTableCell xrTableCell200;
    private XRTableCell xrTableCell201;
    private XRTableCell xrTableCell202;
    private XRTableCell xrTableCell191;
    private XRTableCell xrTableCell192;
    private XRTableCell xrTableCell193;
    private XRTableCell xrTableCell194;
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
    private XRTableCell xrTableCell234;
    private XRTableCell xrTableCell235;
    private XRTableCell xrTableCell236;
    private XRTableCell xrTableCell237;
    private XRTableCell xrTableCell238;
    private XRTableCell xrTableCell239;
    private XRTableCell xrTableCell240;
    private XRTableCell xrTableCell241;
    private XRTableCell xrTableCell242;
    private XRTableCell xrTableCell243;
    private XRTableCell xrTableCell244;
    private XRTableCell xrTableCell245;
    private XRTableCell xrTableCell246;
    private XRTableCell xrTableCell247;
    private XRTableCell xrTableCell248;
    private XRTableCell xrTableCell249;
    private XRTableCell xrTableCell250;
    private XRTableCell xrTableCell251;
    private XRTableCell xrTableCell252;
    private XRTableCell xrTableCell253;
    private XRTableCell xrTableCell254;
    private XRTableCell xrTableCell255;
    private XRTableCell xrTableCell256;
    private XRTableCell xrTableCell257;
    private XRTableCell xrTableCell258;
    private XRTableCell xrTableCell259;
    private XRTableCell xrTableCell260;
    private XRTableCell xrTableCell261;
    private XRTableCell xrTableCell262;
    private XRTableCell xrTableCell263;
    private XRTableCell xrTableCell264;
    private XRTableCell xrTableCell265;
    private XRTableCell xrTableCell266;
    private XRTableCell xrTableCell267;
    private XRTableCell xrTableCell268;
    private XRTableCell xrTableCell269;
    private XRTableCell xrTableCell270;
    private XRTableCell xrTableCell271;
    private XRTableCell xrTableCell272;
    private XRTableCell xrTableCell273;
    private XRTableCell xrTableCell274;
    private XRTableCell xrTableCell275;
    private XRTableCell xrTableCell276;
    private XRTableCell xrTableCell277;
    private XRTableCell xrTableCell278;
    private XRTableCell xrTableCell279;
    private XRTableCell xrTableCell280;
    private XRTableCell xrTableCell281;
    private XRTableCell xrTableCell282;
    private XRTableCell xrTableCell283;
    private XRTableCell xrTableCell284;
    private XRTableCell xrTableCell285;
    private XRTableCell xrTableCell286;
    private XRTableCell xrTableCell287;
    private XRTableCell xrTableCell288;
    private XRTableCell xrTableCell289;
    private XRTableCell xrTableCell290;
    private XRTableCell xrTableCell291;
    private XRTableCell xrTableCell292;
    private XRTableCell xrTableCell293;
    private XRTableCell xrTableCell294;
    private XRTableCell xrTableCell295;
    private XRTableCell xrTableCell296;
    private XRTableCell xrTableCell297;
    private XRTableCell xrTableCell298;
    private XRTableCell xrTableCell299;
    private XRTableCell xrTableCell300;
    private XRTableCell xrTableCell301;
    private XRTableCell xrTableCell302;
    private XRTableCell xrTableCell303;
    private XRTableCell xrTableCell304;
    private XRTableCell xrTableCell305;
    private XRTableCell xrTableCell306;
    private XRTableCell xrTableCell307;
    private XRTableCell xrTableCell308;
    private XRTableCell xrTableCell309;
    private XRTableCell xrTableCell310;
    private XRTableCell xrTableCell311;
    private XRTableCell xrTableCell312;
    private XRTableCell xrTableCell313;
    private XRTableCell xrTableCell314;
    private XRTableCell xrTableCell315;
    private XRTableCell xrTableCell316;
    private XRTableCell xrTableCell317;
    private XRTableCell xrTableCell318;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public rp_austfeed_BaoCaoLamThemGio()
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    int STT = 1;

    private void BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        xrTableCell195.Text = STT.ToString();
        STT++;
    }
    public void BinData(ReportFilter filter)
    {
        try
        {
            ReportController rpCtr = new ReportController();
            xrLabel2.Text = rpCtr.GetCompanyName(filter.SessionDepartment);
            
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("rp_austfeed_BaoCaoLamThemGio", "@Thang", "@Nam", "@MaDonVi", filter.StartMonth, filter.Year, filter.SelectedDepartment);
            DataSource = table;
            //Tên Mã CCVC
            xrTableCell198.DataBindings.Add("Text", DataSource, "MA_CB");
            xrTableCell199.DataBindings.Add("Text", DataSource, "HO_TEN");
            //Ngay 1
            xrTableCell227.DataBindings.Add("Text", DataSource, "Gio100N1", "{0:n1}");
            xrTableCell226.DataBindings.Add("Text", DataSource, "Gio130N1", "{0:n1}");
            xrTableCell228.DataBindings.Add("Text", DataSource, "Gio150N1", "{0:n1}");
            xrTableCell200.DataBindings.Add("Text", DataSource, "Gio195N1", "{0:n1}");
            //Ngay 2
            xrTableCell230.DataBindings.Add("Text", DataSource, "Gio100N2", "{0:n1}");
            xrTableCell229.DataBindings.Add("Text", DataSource, "Gio130N2", "{0:n1}");
            xrTableCell231.DataBindings.Add("Text", DataSource, "Gio150N2", "{0:n1}");
            xrTableCell201.DataBindings.Add("Text", DataSource, "Gio195N2", "{0:n1}");
            //Ngay 3
            xrTableCell233.DataBindings.Add("Text", DataSource, "Gio100N3", "{0:n1}");
            xrTableCell232.DataBindings.Add("Text", DataSource, "Gio130N3", "{0:n1}");
            xrTableCell234.DataBindings.Add("Text", DataSource, "Gio150N3", "{0:n1}");
            xrTableCell202.DataBindings.Add("Text", DataSource, "Gio195N3", "{0:n1}");
            //Ngay 4
            xrTableCell236.DataBindings.Add("Text", DataSource, "Gio100N4", "{0:n1}");
            xrTableCell235.DataBindings.Add("Text", DataSource, "Gio130N4", "{0:n1}");
            xrTableCell237.DataBindings.Add("Text", DataSource, "Gio150N4", "{0:n1}");
            xrTableCell191.DataBindings.Add("Text", DataSource, "Gio195N4", "{0:n1}");
            //ngay 5
            xrTableCell239.DataBindings.Add("Text", DataSource, "Gio100N5", "{0:n1}");
            xrTableCell238.DataBindings.Add("Text", DataSource, "Gio130N5", "{0:n1}");
            xrTableCell240.DataBindings.Add("Text", DataSource, "Gio150N5", "{0:n1}");
            xrTableCell192.DataBindings.Add("Text", DataSource, "Gio195N5", "{0:n1}");
            //Ngay 6
            xrTableCell242.DataBindings.Add("Text", DataSource, "Gio100N6", "{0:n1}");
            xrTableCell241.DataBindings.Add("Text", DataSource, "Gio130N6", "{0:n1}");
            xrTableCell243.DataBindings.Add("Text", DataSource, "Gio150N6", "{0:n1}");
            xrTableCell193.DataBindings.Add("Text", DataSource, "Gio195N6", "{0:n1}");
            //ngay 7
            xrTableCell245.DataBindings.Add("Text", DataSource, "Gio100N7", "{0:n1}");
            xrTableCell244.DataBindings.Add("Text", DataSource, "Gio130N7", "{0:n1}");
            xrTableCell246.DataBindings.Add("Text", DataSource, "Gio150N7", "{0:n1}");
            xrTableCell194.DataBindings.Add("Text", DataSource, "Gio195N7", "{0:n1}");
            //Ngay 8
            xrTableCell248.DataBindings.Add("Text", DataSource, "Gio100N8", "{0:n1}");
            xrTableCell247.DataBindings.Add("Text", DataSource, "Gio130N8", "{0:n1}");
            xrTableCell249.DataBindings.Add("Text", DataSource, "Gio150N8", "{0:n1}");
            xrTableCell203.DataBindings.Add("Text", DataSource, "Gio195N8", "{0:n1}");
            //Nagy 9
            xrTableCell251.DataBindings.Add("Text", DataSource, "Gio100N9", "{0:n1}");
            xrTableCell250.DataBindings.Add("Text", DataSource, "Gio130N9", "{0:n1}");
            xrTableCell252.DataBindings.Add("Text", DataSource, "Gio150N9", "{0:n1}");
            xrTableCell204.DataBindings.Add("Text", DataSource, "Gio195N9", "{0:n1}");
            //Ngay 10
            xrTableCell254.DataBindings.Add("Text", DataSource, "Gio100N10", "{0:n1}");
            xrTableCell253.DataBindings.Add("Text", DataSource, "Gio130N10", "{0:n1}");
            xrTableCell255.DataBindings.Add("Text", DataSource, "Gio150N10", "{0:n1}");
            xrTableCell205.DataBindings.Add("Text", DataSource, "Gio195N10", "{0:n1}");
            //Nagy 11
            xrTableCell257.DataBindings.Add("Text", DataSource, "Gio100N11", "{0:n1}");
            xrTableCell256.DataBindings.Add("Text", DataSource, "Gio130N11", "{0:n1}");
            xrTableCell258.DataBindings.Add("Text", DataSource, "Gio150N11", "{0:n1}");
            xrTableCell206.DataBindings.Add("Text", DataSource, "Gio195N11", "{0:n1}");
            //Ngay 12
            xrTableCell260.DataBindings.Add("Text", DataSource, "Gio100N12", "{0:n1}");
            xrTableCell259.DataBindings.Add("Text", DataSource, "Gio130N12", "{0:n1}");
            xrTableCell261.DataBindings.Add("Text", DataSource, "Gio150N12", "{0:n1}");
            xrTableCell207.DataBindings.Add("Text", DataSource, "Gio195N12", "{0:n1}");
            //Ngay 13
            xrTableCell263.DataBindings.Add("Text", DataSource, "Gio100N13", "{0:n1}");
            xrTableCell262.DataBindings.Add("Text", DataSource, "Gio130N13", "{0:n1}");
            xrTableCell264.DataBindings.Add("Text", DataSource, "Gio150N13", "{0:n1}");
            xrTableCell197.DataBindings.Add("Text", DataSource, "Gio195N13", "{0:n1}");
            //Ngay 14
            xrTableCell266.DataBindings.Add("Text", DataSource, "Gio100N14", "{0:n1}");
            xrTableCell265.DataBindings.Add("Text", DataSource, "Gio130N14", "{0:n1}");
            xrTableCell267.DataBindings.Add("Text", DataSource, "Gio150N14", "{0:n1}");
            xrTableCell208.DataBindings.Add("Text", DataSource, "Gio195N14", "{0:n1}");
            //Ngay 15
            xrTableCell269.DataBindings.Add("Text", DataSource, "Gio100N15", "{0:n1}");
            xrTableCell268.DataBindings.Add("Text", DataSource, "Gio130N15", "{0:n1}");
            xrTableCell270.DataBindings.Add("Text", DataSource, "Gio150N15", "{0:n1}");
            xrTableCell209.DataBindings.Add("Text", DataSource, "Gio195N15", "{0:n1}");
            //Ngay 16
            xrTableCell272.DataBindings.Add("Text", DataSource, "Gio100N16", "{0:n1}");
            xrTableCell271.DataBindings.Add("Text", DataSource, "Gio130N16", "{0:n1}");
            xrTableCell273.DataBindings.Add("Text", DataSource, "Gio150N16", "{0:n1}");
            xrTableCell210.DataBindings.Add("Text", DataSource, "Gio195N16", "{0:n1}");
            //Ngay 17
            xrTableCell275.DataBindings.Add("Text", DataSource, "Gio100N17", "{0:n1}");
            xrTableCell274.DataBindings.Add("Text", DataSource, "Gio130N17", "{0:n1}");
            xrTableCell276.DataBindings.Add("Text", DataSource, "Gio150N17", "{0:n1}");
            xrTableCell211.DataBindings.Add("Text", DataSource, "Gio195N17", "{0:n1}");
            //Ngay 18
            xrTableCell278.DataBindings.Add("Text", DataSource, "Gio100N18", "{0:n1}");
            xrTableCell277.DataBindings.Add("Text", DataSource, "Gio130N18", "{0:n1}");
            xrTableCell279.DataBindings.Add("Text", DataSource, "Gio150N18", "{0:n1}");
            xrTableCell212.DataBindings.Add("Text", DataSource, "Gio195N18", "{0:n1}");
            //Ngay 19
            xrTableCell281.DataBindings.Add("Text", DataSource, "Gio100N19", "{0:n1}");
            xrTableCell280.DataBindings.Add("Text", DataSource, "Gio130N19", "{0:n1}");
            xrTableCell282.DataBindings.Add("Text", DataSource, "Gio150N19", "{0:n1}");
            xrTableCell213.DataBindings.Add("Text", DataSource, "Gio195N19", "{0:n1}");
            //Ngay 20
            xrTableCell284.DataBindings.Add("Text", DataSource, "Gio100N20", "{0:n1}");
            xrTableCell283.DataBindings.Add("Text", DataSource, "Gio130N20", "{0:n1}");
            xrTableCell285.DataBindings.Add("Text", DataSource, "Gio150N20", "{0:n1}");
            xrTableCell214.DataBindings.Add("Text", DataSource, "Gio195N20", "{0:n1}");
            //Ngay 21
            xrTableCell287.DataBindings.Add("Text", DataSource, "Gio100N21", "{0:n1}");
            xrTableCell286.DataBindings.Add("Text", DataSource, "Gio130N21", "{0:n1}");
            xrTableCell288.DataBindings.Add("Text", DataSource, "Gio150N21", "{0:n1}");
            xrTableCell215.DataBindings.Add("Text", DataSource, "Gio195N21", "{0:n1}");
            //Ngay 22
            xrTableCell290.DataBindings.Add("Text", DataSource, "Gio100N22", "{0:n1}");
            xrTableCell289.DataBindings.Add("Text", DataSource, "Gio130N22", "{0:n1}");
            xrTableCell291.DataBindings.Add("Text", DataSource, "Gio150N22", "{0:n1}");
            xrTableCell216.DataBindings.Add("Text", DataSource, "Gio195N22", "{0:n1}");
            //Ngay 23
            xrTableCell293.DataBindings.Add("Text", DataSource, "Gio100N23", "{0:n1}");
            xrTableCell292.DataBindings.Add("Text", DataSource, "Gio130N23", "{0:n1}");
            xrTableCell294.DataBindings.Add("Text", DataSource, "Gio150N23", "{0:n1}");
            xrTableCell217.DataBindings.Add("Text", DataSource, "Gio195N23", "{0:n1}");
            //Ngay 24
            xrTableCell296.DataBindings.Add("Text", DataSource, "Gio100N24", "{0:n1}");
            xrTableCell295.DataBindings.Add("Text", DataSource, "Gio130N24", "{0:n1}");
            xrTableCell297.DataBindings.Add("Text", DataSource, "Gio150N24", "{0:n1}");
            xrTableCell218.DataBindings.Add("Text", DataSource, "Gio195N24", "{0:n1}");
            //Ngay 25
            xrTableCell299.DataBindings.Add("Text", DataSource, "Gio100N25", "{0:n1}");
            xrTableCell298.DataBindings.Add("Text", DataSource, "Gio130N25", "{0:n1}");
            xrTableCell300.DataBindings.Add("Text", DataSource, "Gio150N25", "{0:n1}");
            xrTableCell219.DataBindings.Add("Text", DataSource, "Gio195N25", "{0:n1}");
            //Ngay 26
            xrTableCell302.DataBindings.Add("Text", DataSource, "Gio100N26", "{0:n1}");
            xrTableCell301.DataBindings.Add("Text", DataSource, "Gio130N26", "{0:n1}");
            xrTableCell303.DataBindings.Add("Text", DataSource, "Gio150N26", "{0:n1}");
            xrTableCell220.DataBindings.Add("Text", DataSource, "Gio195N26", "{0:n1}");
            //Ngay 27
            xrTableCell305.DataBindings.Add("Text", DataSource, "Gio100N27", "{0:n1}");
            xrTableCell304.DataBindings.Add("Text", DataSource, "Gio130N27", "{0:n1}");
            xrTableCell306.DataBindings.Add("Text", DataSource, "Gio150N27", "{0:n1}");
            xrTableCell221.DataBindings.Add("Text", DataSource, "Gio195N27", "{0:n1}");
            //Ngay 28
            xrTableCell308.DataBindings.Add("Text", DataSource, "Gio100N28", "{0:n1}");
            xrTableCell307.DataBindings.Add("Text", DataSource, "Gio130N28", "{0:n1}");
            xrTableCell309.DataBindings.Add("Text", DataSource, "Gio150N28", "{0:n1}");
            xrTableCell222.DataBindings.Add("Text", DataSource, "Gio195N28", "{0:n1}");
            //Ngay 29
            xrTableCell311.DataBindings.Add("Text", DataSource, "Gio100N29", "{0:n1}");
            xrTableCell310.DataBindings.Add("Text", DataSource, "Gio130N29", "{0:n1}");
            xrTableCell312.DataBindings.Add("Text", DataSource, "Gio150N29", "{0:n1}");
            xrTableCell223.DataBindings.Add("Text", DataSource, "Gio195N29", "{0:n1}");
            //Ngay 30
            xrTableCell314.DataBindings.Add("Text", DataSource, "Gio100N30", "{0:n1}");
            xrTableCell313.DataBindings.Add("Text", DataSource, "Gio130N30", "{0:n1}");
            xrTableCell315.DataBindings.Add("Text", DataSource, "Gio150N30", "{0:n1}");
            xrTableCell224.DataBindings.Add("Text", DataSource, "Gio195N30", "{0:n1}");
            //Ngay 31
            xrTableCell317.DataBindings.Add("Text", DataSource, "Gio100N31", "{0:n1}");
            xrTableCell316.DataBindings.Add("Text", DataSource, "Gio130N31", "{0:n1}");
            xrTableCell318.DataBindings.Add("Text", DataSource, "Gio150N31", "{0:n1}");
            xrTableCell225.DataBindings.Add("Text", DataSource, "Gio195N31", "{0:n1}");

            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MA_DONVI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            xrTableCell196.DataBindings.Add("Text", DataSource, "TEN_DONVI").ToString().ToUpper();

            xrLabel3.Text = string.Format(xrLabel3.Text, filter.StartMonth,filter.Year);
        }
        catch (Exception)
        {

            throw;
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
            string resourceFileName = "rp_austfeed_BaoCaoLamThemGio.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable66 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow66 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell195 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell198 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell199 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell227 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell226 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell228 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell200 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell230 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell229 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell231 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell201 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell233 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell232 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell234 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell202 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell236 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell235 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell237 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell191 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell239 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell238 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell240 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell192 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell242 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell241 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell243 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell193 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell245 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell244 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell246 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell194 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell248 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell247 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell249 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell203 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell251 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell250 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell252 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell204 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell254 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell253 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell255 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell205 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell257 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell256 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell258 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell206 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell260 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell259 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell261 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell207 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell263 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell262 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell264 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell197 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell266 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell265 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell267 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell208 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell269 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell268 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell270 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell209 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell272 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell271 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell273 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell210 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell275 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell274 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell276 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell211 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell278 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell277 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell279 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell212 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell281 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell280 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell282 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell213 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell284 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell283 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell285 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell214 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell287 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell286 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell288 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell215 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell290 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell289 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell291 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell216 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell293 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell292 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell294 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell217 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell296 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell295 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell297 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell218 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell299 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell298 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell300 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell219 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell302 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell301 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell303 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell220 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell305 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell304 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell306 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell221 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell308 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell307 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell309 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell222 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell311 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell310 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell312 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell223 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell314 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell313 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell315 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell224 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell317 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell316 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell318 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell225 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable24 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable25 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable20 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable21 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable22 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable23 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable26 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable27 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable28 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable29 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow29 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable30 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable31 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow31 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable19 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable38 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow38 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell125 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable39 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow39 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell126 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell127 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell128 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell129 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable32 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow32 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable33 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow33 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable36 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow36 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable37 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow37 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell121 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell122 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell124 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable34 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow34 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell115 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable35 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow35 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell116 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell119 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable40 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow40 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell130 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable41 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow41 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell131 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell132 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell133 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell134 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable62 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow62 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell185 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable63 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow63 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell186 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell187 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell188 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell189 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable61 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow61 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell184 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable60 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow60 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell180 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell181 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell182 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell183 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable59 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow59 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell179 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable58 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow58 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell175 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell176 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell177 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell178 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable57 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow57 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell174 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable56 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow56 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell170 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell171 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell172 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell173 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable55 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow55 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell169 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable54 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow54 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell165 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell166 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell167 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell168 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable53 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow53 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell164 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable52 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow52 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell160 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell161 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell162 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell163 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable44 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow44 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable45 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow45 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell142 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell143 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell144 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable42 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow42 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell135 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable43 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow43 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell136 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell137 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell138 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable50 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow50 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable51 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow51 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell156 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell157 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell158 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell159 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable48 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow48 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell150 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable49 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow49 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell151 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell152 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell153 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell154 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable46 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow46 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell145 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable47 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow47 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell148 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell149 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable64 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow64 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell196 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable66});
            this.Detail.HeightF = 15F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BeforePrint);
            // 
            // xrTable66
            // 
            this.xrTable66.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable66.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable66.Name = "xrTable66";
            this.xrTable66.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow66});
            this.xrTable66.SizeF = new System.Drawing.SizeF(1642.05F, 15F);
            this.xrTable66.StylePriority.UseBorders = false;
            this.xrTable66.StylePriority.UseTextAlignment = false;
            this.xrTable66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow66
            // 
            this.xrTableRow66.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell195,
            this.xrTableCell198,
            this.xrTableCell199,
            this.xrTableCell227,
            this.xrTableCell226,
            this.xrTableCell228,
            this.xrTableCell200,
            this.xrTableCell230,
            this.xrTableCell229,
            this.xrTableCell231,
            this.xrTableCell201,
            this.xrTableCell233,
            this.xrTableCell232,
            this.xrTableCell234,
            this.xrTableCell202,
            this.xrTableCell236,
            this.xrTableCell235,
            this.xrTableCell237,
            this.xrTableCell191,
            this.xrTableCell239,
            this.xrTableCell238,
            this.xrTableCell240,
            this.xrTableCell192,
            this.xrTableCell242,
            this.xrTableCell241,
            this.xrTableCell243,
            this.xrTableCell193,
            this.xrTableCell245,
            this.xrTableCell244,
            this.xrTableCell246,
            this.xrTableCell194,
            this.xrTableCell248,
            this.xrTableCell247,
            this.xrTableCell249,
            this.xrTableCell203,
            this.xrTableCell251,
            this.xrTableCell250,
            this.xrTableCell252,
            this.xrTableCell204,
            this.xrTableCell254,
            this.xrTableCell253,
            this.xrTableCell255,
            this.xrTableCell205,
            this.xrTableCell257,
            this.xrTableCell256,
            this.xrTableCell258,
            this.xrTableCell206,
            this.xrTableCell260,
            this.xrTableCell259,
            this.xrTableCell261,
            this.xrTableCell207,
            this.xrTableCell263,
            this.xrTableCell262,
            this.xrTableCell264,
            this.xrTableCell197,
            this.xrTableCell266,
            this.xrTableCell265,
            this.xrTableCell267,
            this.xrTableCell208,
            this.xrTableCell269,
            this.xrTableCell268,
            this.xrTableCell270,
            this.xrTableCell209,
            this.xrTableCell272,
            this.xrTableCell271,
            this.xrTableCell273,
            this.xrTableCell210,
            this.xrTableCell275,
            this.xrTableCell274,
            this.xrTableCell276,
            this.xrTableCell211,
            this.xrTableCell278,
            this.xrTableCell277,
            this.xrTableCell279,
            this.xrTableCell212,
            this.xrTableCell281,
            this.xrTableCell280,
            this.xrTableCell282,
            this.xrTableCell213,
            this.xrTableCell284,
            this.xrTableCell283,
            this.xrTableCell285,
            this.xrTableCell214,
            this.xrTableCell287,
            this.xrTableCell286,
            this.xrTableCell288,
            this.xrTableCell215,
            this.xrTableCell290,
            this.xrTableCell289,
            this.xrTableCell291,
            this.xrTableCell216,
            this.xrTableCell293,
            this.xrTableCell292,
            this.xrTableCell294,
            this.xrTableCell217,
            this.xrTableCell296,
            this.xrTableCell295,
            this.xrTableCell297,
            this.xrTableCell218,
            this.xrTableCell299,
            this.xrTableCell298,
            this.xrTableCell300,
            this.xrTableCell219,
            this.xrTableCell302,
            this.xrTableCell301,
            this.xrTableCell303,
            this.xrTableCell220,
            this.xrTableCell305,
            this.xrTableCell304,
            this.xrTableCell306,
            this.xrTableCell221,
            this.xrTableCell308,
            this.xrTableCell307,
            this.xrTableCell309,
            this.xrTableCell222,
            this.xrTableCell311,
            this.xrTableCell310,
            this.xrTableCell312,
            this.xrTableCell223,
            this.xrTableCell314,
            this.xrTableCell313,
            this.xrTableCell315,
            this.xrTableCell224,
            this.xrTableCell317,
            this.xrTableCell316,
            this.xrTableCell318,
            this.xrTableCell225});
            this.xrTableRow66.Name = "xrTableRow66";
            this.xrTableRow66.Weight = 1D;
            // 
            // xrTableCell195
            // 
            this.xrTableCell195.Name = "xrTableCell195";
            this.xrTableCell195.Weight = 0.018269807906435953D;
            this.xrTableCell195.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BeforePrint);
            // 
            // xrTableCell198
            // 
            this.xrTableCell198.Name = "xrTableCell198";
            this.xrTableCell198.Weight = 0.0548095538146407D;
            // 
            // xrTableCell199
            // 
            this.xrTableCell199.Name = "xrTableCell199";
            this.xrTableCell199.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.xrTableCell199.StylePriority.UsePadding = false;
            this.xrTableCell199.StylePriority.UseTextAlignment = false;
            this.xrTableCell199.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell199.Weight = 0.10642185686331684D;
            // 
            // xrTableCell227
            // 
            this.xrTableCell227.Name = "xrTableCell227";
            this.xrTableCell227.Weight = 0.022745952706332229D;
            // 
            // xrTableCell226
            // 
            this.xrTableCell226.Name = "xrTableCell226";
            this.xrTableCell226.Weight = 0.022745952706332229D;
            // 
            // xrTableCell228
            // 
            this.xrTableCell228.Name = "xrTableCell228";
            this.xrTableCell228.Weight = 0.022745952706332229D;
            // 
            // xrTableCell200
            // 
            this.xrTableCell200.Name = "xrTableCell200";
            this.xrTableCell200.Weight = 0.022745952706332229D;
            // 
            // xrTableCell230
            // 
            this.xrTableCell230.Name = "xrTableCell230";
            this.xrTableCell230.Weight = 0.022745938186763959D;
            // 
            // xrTableCell229
            // 
            this.xrTableCell229.Name = "xrTableCell229";
            this.xrTableCell229.Weight = 0.022745938186763959D;
            // 
            // xrTableCell231
            // 
            this.xrTableCell231.Name = "xrTableCell231";
            this.xrTableCell231.Weight = 0.022745938186763959D;
            // 
            // xrTableCell201
            // 
            this.xrTableCell201.Name = "xrTableCell201";
            this.xrTableCell201.Weight = 0.022745938186763959D;
            // 
            // xrTableCell233
            // 
            this.xrTableCell233.Name = "xrTableCell233";
            this.xrTableCell233.Weight = 0.022745958804550992D;
            // 
            // xrTableCell232
            // 
            this.xrTableCell232.Name = "xrTableCell232";
            this.xrTableCell232.Weight = 0.022745958804550992D;
            // 
            // xrTableCell234
            // 
            this.xrTableCell234.Name = "xrTableCell234";
            this.xrTableCell234.Weight = 0.022745958804550992D;
            // 
            // xrTableCell202
            // 
            this.xrTableCell202.Name = "xrTableCell202";
            this.xrTableCell202.Weight = 0.022745958804550992D;
            // 
            // xrTableCell236
            // 
            this.xrTableCell236.Name = "xrTableCell236";
            this.xrTableCell236.Weight = 0.022745941235873313D;
            // 
            // xrTableCell235
            // 
            this.xrTableCell235.Name = "xrTableCell235";
            this.xrTableCell235.Weight = 0.022745941235873313D;
            // 
            // xrTableCell237
            // 
            this.xrTableCell237.Name = "xrTableCell237";
            this.xrTableCell237.Weight = 0.022745941235873313D;
            // 
            // xrTableCell191
            // 
            this.xrTableCell191.Name = "xrTableCell191";
            this.xrTableCell191.Weight = 0.022745941235873313D;
            // 
            // xrTableCell239
            // 
            this.xrTableCell239.Name = "xrTableCell239";
            this.xrTableCell239.Weight = 0.022745960329105697D;
            // 
            // xrTableCell238
            // 
            this.xrTableCell238.Name = "xrTableCell238";
            this.xrTableCell238.Weight = 0.022745960329105697D;
            // 
            // xrTableCell240
            // 
            this.xrTableCell240.Name = "xrTableCell240";
            this.xrTableCell240.Weight = 0.022745960329105697D;
            // 
            // xrTableCell192
            // 
            this.xrTableCell192.Name = "xrTableCell192";
            this.xrTableCell192.Weight = 0.022745960329105697D;
            // 
            // xrTableCell242
            // 
            this.xrTableCell242.Name = "xrTableCell242";
            this.xrTableCell242.Weight = 0.022745941998150665D;
            // 
            // xrTableCell241
            // 
            this.xrTableCell241.Name = "xrTableCell241";
            this.xrTableCell241.Weight = 0.022745941998150665D;
            // 
            // xrTableCell243
            // 
            this.xrTableCell243.Name = "xrTableCell243";
            this.xrTableCell243.Weight = 0.022745941998150665D;
            // 
            // xrTableCell193
            // 
            this.xrTableCell193.Name = "xrTableCell193";
            this.xrTableCell193.Weight = 0.022745941998150665D;
            // 
            // xrTableCell245
            // 
            this.xrTableCell245.Name = "xrTableCell245";
            this.xrTableCell245.Weight = 0.022745960710244373D;
            // 
            // xrTableCell244
            // 
            this.xrTableCell244.Name = "xrTableCell244";
            this.xrTableCell244.Weight = 0.022745960710244373D;
            // 
            // xrTableCell246
            // 
            this.xrTableCell246.Name = "xrTableCell246";
            this.xrTableCell246.Weight = 0.022745960710244373D;
            // 
            // xrTableCell194
            // 
            this.xrTableCell194.Name = "xrTableCell194";
            this.xrTableCell194.Weight = 0.022745960710244373D;
            // 
            // xrTableCell248
            // 
            this.xrTableCell248.Name = "xrTableCell248";
            this.xrTableCell248.Weight = 0.022745942188720003D;
            // 
            // xrTableCell247
            // 
            this.xrTableCell247.Name = "xrTableCell247";
            this.xrTableCell247.Weight = 0.022745942188720003D;
            // 
            // xrTableCell249
            // 
            this.xrTableCell249.Name = "xrTableCell249";
            this.xrTableCell249.Weight = 0.022745942188720003D;
            // 
            // xrTableCell203
            // 
            this.xrTableCell203.Name = "xrTableCell203";
            this.xrTableCell203.Weight = 0.022745942188720003D;
            // 
            // xrTableCell251
            // 
            this.xrTableCell251.Name = "xrTableCell251";
            this.xrTableCell251.Weight = 0.022745960805529042D;
            // 
            // xrTableCell250
            // 
            this.xrTableCell250.Name = "xrTableCell250";
            this.xrTableCell250.Weight = 0.022745960805529042D;
            // 
            // xrTableCell252
            // 
            this.xrTableCell252.Name = "xrTableCell252";
            this.xrTableCell252.Weight = 0.022745960805529042D;
            // 
            // xrTableCell204
            // 
            this.xrTableCell204.Name = "xrTableCell204";
            this.xrTableCell204.Weight = 0.022745960805529042D;
            // 
            // xrTableCell254
            // 
            this.xrTableCell254.Name = "xrTableCell254";
            this.xrTableCell254.Weight = 0.022745942236362282D;
            // 
            // xrTableCell253
            // 
            this.xrTableCell253.Name = "xrTableCell253";
            this.xrTableCell253.Weight = 0.022745942236362282D;
            // 
            // xrTableCell255
            // 
            this.xrTableCell255.Name = "xrTableCell255";
            this.xrTableCell255.Weight = 0.022745942236362282D;
            // 
            // xrTableCell205
            // 
            this.xrTableCell205.Name = "xrTableCell205";
            this.xrTableCell205.Weight = 0.022745942236362282D;
            // 
            // xrTableCell257
            // 
            this.xrTableCell257.Name = "xrTableCell257";
            this.xrTableCell257.Weight = 0.022745960829350181D;
            // 
            // xrTableCell256
            // 
            this.xrTableCell256.Name = "xrTableCell256";
            this.xrTableCell256.Weight = 0.022745960829350181D;
            // 
            // xrTableCell258
            // 
            this.xrTableCell258.Name = "xrTableCell258";
            this.xrTableCell258.Weight = 0.022745960829350181D;
            // 
            // xrTableCell206
            // 
            this.xrTableCell206.Name = "xrTableCell206";
            this.xrTableCell206.Weight = 0.022745960829350181D;
            // 
            // xrTableCell260
            // 
            this.xrTableCell260.Name = "xrTableCell260";
            this.xrTableCell260.Weight = 0.022745956187058547D;
            // 
            // xrTableCell259
            // 
            this.xrTableCell259.Name = "xrTableCell259";
            this.xrTableCell259.Weight = 0.022745956187058547D;
            // 
            // xrTableCell261
            // 
            this.xrTableCell261.Name = "xrTableCell261";
            this.xrTableCell261.Weight = 0.022745956187058547D;
            // 
            // xrTableCell207
            // 
            this.xrTableCell207.Name = "xrTableCell207";
            this.xrTableCell207.Weight = 0.022745956187058547D;
            // 
            // xrTableCell263
            // 
            this.xrTableCell263.Name = "xrTableCell263";
            this.xrTableCell263.Weight = 0.022745953865912633D;
            // 
            // xrTableCell262
            // 
            this.xrTableCell262.Name = "xrTableCell262";
            this.xrTableCell262.Weight = 0.022745953865912633D;
            // 
            // xrTableCell264
            // 
            this.xrTableCell264.Name = "xrTableCell264";
            this.xrTableCell264.Weight = 0.022745953865912633D;
            // 
            // xrTableCell197
            // 
            this.xrTableCell197.Name = "xrTableCell197";
            this.xrTableCell197.Weight = 0.022745953865912633D;
            // 
            // xrTableCell266
            // 
            this.xrTableCell266.Name = "xrTableCell266";
            this.xrTableCell266.Weight = 0.0227459527053398D;
            // 
            // xrTableCell265
            // 
            this.xrTableCell265.Name = "xrTableCell265";
            this.xrTableCell265.Weight = 0.0227459527053398D;
            // 
            // xrTableCell267
            // 
            this.xrTableCell267.Name = "xrTableCell267";
            this.xrTableCell267.Weight = 0.0227459527053398D;
            // 
            // xrTableCell208
            // 
            this.xrTableCell208.Name = "xrTableCell208";
            this.xrTableCell208.Weight = 0.0227459527053398D;
            // 
            // xrTableCell269
            // 
            this.xrTableCell269.Name = "xrTableCell269";
            this.xrTableCell269.Weight = 0.022745952125053315D;
            // 
            // xrTableCell268
            // 
            this.xrTableCell268.Name = "xrTableCell268";
            this.xrTableCell268.Weight = 0.022745952125053315D;
            // 
            // xrTableCell270
            // 
            this.xrTableCell270.Name = "xrTableCell270";
            this.xrTableCell270.Weight = 0.022745952125053315D;
            // 
            // xrTableCell209
            // 
            this.xrTableCell209.Name = "xrTableCell209";
            this.xrTableCell209.Weight = 0.022745952125053315D;
            // 
            // xrTableCell272
            // 
            this.xrTableCell272.Name = "xrTableCell272";
            this.xrTableCell272.Weight = 0.022745951834910128D;
            // 
            // xrTableCell271
            // 
            this.xrTableCell271.Name = "xrTableCell271";
            this.xrTableCell271.Weight = 0.022745951834910128D;
            // 
            // xrTableCell273
            // 
            this.xrTableCell273.Name = "xrTableCell273";
            this.xrTableCell273.Weight = 0.022745951834910128D;
            // 
            // xrTableCell210
            // 
            this.xrTableCell210.Name = "xrTableCell210";
            this.xrTableCell210.Weight = 0.022745951834910128D;
            // 
            // xrTableCell275
            // 
            this.xrTableCell275.Name = "xrTableCell275";
            this.xrTableCell275.Weight = 0.022745951689838451D;
            // 
            // xrTableCell274
            // 
            this.xrTableCell274.Name = "xrTableCell274";
            this.xrTableCell274.Weight = 0.022745951689838451D;
            // 
            // xrTableCell276
            // 
            this.xrTableCell276.Name = "xrTableCell276";
            this.xrTableCell276.Weight = 0.022745951689838451D;
            // 
            // xrTableCell211
            // 
            this.xrTableCell211.Name = "xrTableCell211";
            this.xrTableCell211.Weight = 0.022745951689838451D;
            // 
            // xrTableCell278
            // 
            this.xrTableCell278.Name = "xrTableCell278";
            this.xrTableCell278.Weight = 0.02274595161730264D;
            // 
            // xrTableCell277
            // 
            this.xrTableCell277.Name = "xrTableCell277";
            this.xrTableCell277.Weight = 0.02274595161730264D;
            // 
            // xrTableCell279
            // 
            this.xrTableCell279.Name = "xrTableCell279";
            this.xrTableCell279.Weight = 0.02274595161730264D;
            // 
            // xrTableCell212
            // 
            this.xrTableCell212.Name = "xrTableCell212";
            this.xrTableCell212.Weight = 0.02274595161730264D;
            // 
            // xrTableCell281
            // 
            this.xrTableCell281.Name = "xrTableCell281";
            this.xrTableCell281.Weight = 0.022745951581034735D;
            // 
            // xrTableCell280
            // 
            this.xrTableCell280.Name = "xrTableCell280";
            this.xrTableCell280.Weight = 0.022745951581034735D;
            // 
            // xrTableCell282
            // 
            this.xrTableCell282.Name = "xrTableCell282";
            this.xrTableCell282.Weight = 0.022745951581034735D;
            // 
            // xrTableCell213
            // 
            this.xrTableCell213.Name = "xrTableCell213";
            this.xrTableCell213.Weight = 0.022745951581034735D;
            // 
            // xrTableCell284
            // 
            this.xrTableCell284.Name = "xrTableCell284";
            this.xrTableCell284.Weight = 0.022745958532293595D;
            // 
            // xrTableCell283
            // 
            this.xrTableCell283.Name = "xrTableCell283";
            this.xrTableCell283.Weight = 0.022745958532293595D;
            // 
            // xrTableCell285
            // 
            this.xrTableCell285.Name = "xrTableCell285";
            this.xrTableCell285.Weight = 0.022745958532293595D;
            // 
            // xrTableCell214
            // 
            this.xrTableCell214.Name = "xrTableCell214";
            this.xrTableCell214.Weight = 0.022745958532293595D;
            // 
            // xrTableCell287
            // 
            this.xrTableCell287.Name = "xrTableCell287";
            this.xrTableCell287.Weight = 0.022745955038530233D;
            // 
            // xrTableCell286
            // 
            this.xrTableCell286.Name = "xrTableCell286";
            this.xrTableCell286.Weight = 0.022745955038530233D;
            // 
            // xrTableCell288
            // 
            this.xrTableCell288.Name = "xrTableCell288";
            this.xrTableCell288.Weight = 0.022745955038530233D;
            // 
            // xrTableCell215
            // 
            this.xrTableCell215.Name = "xrTableCell215";
            this.xrTableCell215.Weight = 0.022745955038530233D;
            // 
            // xrTableCell290
            // 
            this.xrTableCell290.Name = "xrTableCell290";
            this.xrTableCell290.Weight = 0.022745960261041365D;
            // 
            // xrTableCell289
            // 
            this.xrTableCell289.Name = "xrTableCell289";
            this.xrTableCell289.Weight = 0.022745960261041365D;
            // 
            // xrTableCell291
            // 
            this.xrTableCell291.Name = "xrTableCell291";
            this.xrTableCell291.Weight = 0.022745960261041365D;
            // 
            // xrTableCell216
            // 
            this.xrTableCell216.Name = "xrTableCell216";
            this.xrTableCell216.Weight = 0.022745960261041365D;
            // 
            // xrTableCell293
            // 
            this.xrTableCell293.Name = "xrTableCell293";
            this.xrTableCell293.Weight = 0.022745955902904097D;
            // 
            // xrTableCell292
            // 
            this.xrTableCell292.Name = "xrTableCell292";
            this.xrTableCell292.Weight = 0.022745955902904097D;
            // 
            // xrTableCell294
            // 
            this.xrTableCell294.Name = "xrTableCell294";
            this.xrTableCell294.Weight = 0.022745955902904097D;
            // 
            // xrTableCell217
            // 
            this.xrTableCell217.Name = "xrTableCell217";
            this.xrTableCell217.Weight = 0.022745955902904097D;
            // 
            // xrTableCell296
            // 
            this.xrTableCell296.Name = "xrTableCell296";
            this.xrTableCell296.Weight = 0.022745960693228262D;
            // 
            // xrTableCell295
            // 
            this.xrTableCell295.Name = "xrTableCell295";
            this.xrTableCell295.Weight = 0.022745960693228262D;
            // 
            // xrTableCell297
            // 
            this.xrTableCell297.Name = "xrTableCell297";
            this.xrTableCell297.Weight = 0.022745960693228262D;
            // 
            // xrTableCell218
            // 
            this.xrTableCell218.Name = "xrTableCell218";
            this.xrTableCell218.Weight = 0.022745960693228262D;
            // 
            // xrTableCell299
            // 
            this.xrTableCell299.Name = "xrTableCell299";
            this.xrTableCell299.Weight = 0.022745956118997566D;
            // 
            // xrTableCell298
            // 
            this.xrTableCell298.Name = "xrTableCell298";
            this.xrTableCell298.Weight = 0.022745956118997566D;
            // 
            // xrTableCell300
            // 
            this.xrTableCell300.Name = "xrTableCell300";
            this.xrTableCell300.Weight = 0.022745956118997566D;
            // 
            // xrTableCell219
            // 
            this.xrTableCell219.Name = "xrTableCell219";
            this.xrTableCell219.Weight = 0.022745956118997566D;
            // 
            // xrTableCell302
            // 
            this.xrTableCell302.Name = "xrTableCell302";
            this.xrTableCell302.Weight = 0.022745960801275D;
            // 
            // xrTableCell301
            // 
            this.xrTableCell301.Name = "xrTableCell301";
            this.xrTableCell301.Weight = 0.022745960801275D;
            // 
            // xrTableCell303
            // 
            this.xrTableCell303.Name = "xrTableCell303";
            this.xrTableCell303.Weight = 0.022745960801275D;
            // 
            // xrTableCell220
            // 
            this.xrTableCell220.Name = "xrTableCell220";
            this.xrTableCell220.Weight = 0.022745960801275D;
            // 
            // xrTableCell305
            // 
            this.xrTableCell305.Name = "xrTableCell305";
            this.xrTableCell305.Weight = 0.022745956173020922D;
            // 
            // xrTableCell304
            // 
            this.xrTableCell304.Name = "xrTableCell304";
            this.xrTableCell304.Weight = 0.022745956173020922D;
            // 
            // xrTableCell306
            // 
            this.xrTableCell306.Name = "xrTableCell306";
            this.xrTableCell306.Weight = 0.022745956173020922D;
            // 
            // xrTableCell221
            // 
            this.xrTableCell221.Name = "xrTableCell221";
            this.xrTableCell221.Weight = 0.022745956173020922D;
            // 
            // xrTableCell308
            // 
            this.xrTableCell308.Name = "xrTableCell308";
            this.xrTableCell308.Weight = 0.022745955601242082D;
            // 
            // xrTableCell307
            // 
            this.xrTableCell307.Name = "xrTableCell307";
            this.xrTableCell307.Weight = 0.022745955601242082D;
            // 
            // xrTableCell309
            // 
            this.xrTableCell309.Name = "xrTableCell309";
            this.xrTableCell309.Weight = 0.022745955601242082D;
            // 
            // xrTableCell222
            // 
            this.xrTableCell222.Name = "xrTableCell222";
            this.xrTableCell222.Weight = 0.022745955601242082D;
            // 
            // xrTableCell311
            // 
            this.xrTableCell311.Name = "xrTableCell311";
            this.xrTableCell311.Weight = 0.022745957057700862D;
            // 
            // xrTableCell310
            // 
            this.xrTableCell310.Name = "xrTableCell310";
            this.xrTableCell310.Weight = 0.022745957057700862D;
            // 
            // xrTableCell312
            // 
            this.xrTableCell312.Name = "xrTableCell312";
            this.xrTableCell312.Weight = 0.022745957057700862D;
            // 
            // xrTableCell223
            // 
            this.xrTableCell223.Name = "xrTableCell223";
            this.xrTableCell223.Weight = 0.022745957057700862D;
            // 
            // xrTableCell314
            // 
            this.xrTableCell314.Name = "xrTableCell314";
            this.xrTableCell314.Weight = 0.022746018768117302D;
            // 
            // xrTableCell313
            // 
            this.xrTableCell313.Name = "xrTableCell313";
            this.xrTableCell313.Weight = 0.022746018768117302D;
            // 
            // xrTableCell315
            // 
            this.xrTableCell315.Name = "xrTableCell315";
            this.xrTableCell315.Weight = 0.022746018768117302D;
            // 
            // xrTableCell224
            // 
            this.xrTableCell224.Name = "xrTableCell224";
            this.xrTableCell224.Weight = 0.022746018768117302D;
            // 
            // xrTableCell317
            // 
            this.xrTableCell317.Name = "xrTableCell317";
            this.xrTableCell317.Weight = 0.022746018768117302D;
            // 
            // xrTableCell316
            // 
            this.xrTableCell316.Name = "xrTableCell316";
            this.xrTableCell316.Weight = 0.022746018768117302D;
            // 
            // xrTableCell318
            // 
            this.xrTableCell318.Name = "xrTableCell318";
            this.xrTableCell318.Weight = 0.022746018768117302D;
            // 
            // xrTableCell225
            // 
            this.xrTableCell225.Name = "xrTableCell225";
            this.xrTableCell225.Weight = 0.022746018768117302D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 15F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 23F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 44.16668F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1642.05F, 32.55209F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell11,
            this.xrTableCell10,
            this.xrTableCell9,
            this.xrTableCell13,
            this.xrTableCell12,
            this.xrTableCell16,
            this.xrTableCell15,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell14,
            this.xrTableCell20,
            this.xrTableCell19,
            this.xrTableCell21,
            this.xrTableCell8,
            this.xrTableCell25,
            this.xrTableCell24,
            this.xrTableCell23,
            this.xrTableCell27,
            this.xrTableCell26,
            this.xrTableCell28,
            this.xrTableCell22,
            this.xrTableCell32,
            this.xrTableCell30,
            this.xrTableCell29,
            this.xrTableCell31,
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "TT";
            this.xrTableCell1.Weight = 0.018248175182481716D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Mã cán bộ";
            this.xrTableCell2.Weight = 0.054744525547445168D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Họ và tên";
            this.xrTableCell4.Weight = 0.10629562043795637D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Weight = 0.090875890133154558D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell40});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.StylePriority.UseBorders = false;
            this.xrTableCell40.Text = "01";
            this.xrTableCell40.Weight = 3D;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54168F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell35,
            this.xrTableCell38,
            this.xrTableCell36});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell37.Multiline = true;
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseBorders = false;
            this.xrTableCell37.Text = "100\r\n%";
            this.xrTableCell37.Weight = 0.5D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Text = "130%";
            this.xrTableCell35.Weight = 0.5D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "150%";
            this.xrTableCell38.Weight = 0.5D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Text = "195%";
            this.xrTableCell36.Weight = 0.5D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable5});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "02";
            this.xrTableCell6.Weight = 0.0908758344441436D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-06F, 3.973643E-06F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell39});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.StylePriority.UseBorders = false;
            this.xrTableCell39.Text = "02";
            this.xrTableCell39.Weight = 3D;
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(1.986822E-05F, 13.54168F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell41.Multiline = true;
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.Text = "100\r\n%";
            this.xrTableCell41.Weight = 0.5D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Text = "130%";
            this.xrTableCell42.Weight = 0.5D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Text = "150%";
            this.xrTableCell43.Weight = 0.5D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Text = "195%";
            this.xrTableCell44.Weight = 0.5D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable7});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "03";
            this.xrTableCell7.Weight = 0.09087591797766037D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(7.152557E-05F, 0F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.Text = "03";
            this.xrTableCell45.Weight = 3D;
            // 
            // xrTable7
            // 
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 13.54167F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable7.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell49});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell46.Multiline = true;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.Text = "100\r\n%";
            this.xrTableCell46.Weight = 0.5D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Text = "130%";
            this.xrTableCell47.Weight = 0.5D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Text = "150%";
            this.xrTableCell48.Weight = 0.5D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Text = "195%";
            this.xrTableCell49.Weight = 0.5D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable10,
            this.xrTable11});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "04";
            this.xrTableCell11.Weight = 0.090875905795689035D;
            // 
            // xrTable10
            // 
            this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 3.973643E-06F);
            this.xrTable10.Name = "xrTable10";
            this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable10.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell55});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StylePriority.UseBorders = false;
            this.xrTableCell55.Text = "04";
            this.xrTableCell55.Weight = 3D;
            // 
            // xrTable11
            // 
            this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 13.54167F);
            this.xrTable11.Name = "xrTable11";
            this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
            this.xrTable11.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell56,
            this.xrTableCell57,
            this.xrTableCell58,
            this.xrTableCell59});
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell56.Multiline = true;
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.StylePriority.UseBorders = false;
            this.xrTableCell56.Text = "100\r\n%";
            this.xrTableCell56.Weight = 0.5D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Text = "130%";
            this.xrTableCell57.Weight = 0.5D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Text = "150%";
            this.xrTableCell58.Weight = 0.5D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Text = "195%";
            this.xrTableCell59.Weight = 0.5D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable12,
            this.xrTable13});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "05";
            this.xrTableCell10.Weight = 0.090875919717941817D;
            // 
            // xrTable12
            // 
            this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-05F, 7.947286E-06F);
            this.xrTable12.Name = "xrTable12";
            this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12});
            this.xrTable12.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell60});
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.StylePriority.UseBorders = false;
            this.xrTableCell60.Text = "05";
            this.xrTableCell60.Weight = 3D;
            // 
            // xrTable13
            // 
            this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-05F, 13.54169F);
            this.xrTable13.Name = "xrTable13";
            this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
            this.xrTable13.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell63,
            this.xrTableCell64});
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell61.Multiline = true;
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.StylePriority.UseBorders = false;
            this.xrTableCell61.Text = "100\r\n%";
            this.xrTableCell61.Weight = 0.5D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Text = "130%";
            this.xrTableCell62.Weight = 0.5D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Text = "150%";
            this.xrTableCell63.Weight = 0.5D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Text = "195%";
            this.xrTableCell64.Weight = 0.5D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable14,
            this.xrTable15});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "06";
            this.xrTableCell9.Weight = 0.090875907535970579D;
            // 
            // xrTable14
            // 
            this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 7.947286E-06F);
            this.xrTable14.Name = "xrTable14";
            this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
            this.xrTable14.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell65});
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Weight = 1D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.StylePriority.UseBorders = false;
            this.xrTableCell65.Text = "06";
            this.xrTableCell65.Weight = 3D;
            // 
            // xrTable15
            // 
            this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 13.54169F);
            this.xrTable15.Name = "xrTable15";
            this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
            this.xrTable15.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell68,
            this.xrTableCell69});
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Weight = 1D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell66.Multiline = true;
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseBorders = false;
            this.xrTableCell66.Text = "100\r\n%";
            this.xrTableCell66.Weight = 0.5D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Text = "130%";
            this.xrTableCell67.Weight = 0.5D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Text = "150%";
            this.xrTableCell68.Weight = 0.5D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Text = "195%";
            this.xrTableCell69.Weight = 0.5D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8,
            this.xrTable9});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "07";
            this.xrTableCell13.Weight = 0.090875919717941844D;
            // 
            // xrTable8
            // 
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 7.947286E-06F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable8.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell50});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.Text = "07";
            this.xrTableCell50.Weight = 3D;
            // 
            // xrTable9
            // 
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 13.54169F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.xrTable9.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell51,
            this.xrTableCell52,
            this.xrTableCell53,
            this.xrTableCell54});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell51.Multiline = true;
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseBorders = false;
            this.xrTableCell51.Text = "100\r\n%";
            this.xrTableCell51.Weight = 0.5D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Text = "130%";
            this.xrTableCell52.Weight = 0.5D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Text = "150%";
            this.xrTableCell53.Weight = 0.5D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Text = "195%";
            this.xrTableCell54.Weight = 0.5D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable24,
            this.xrTable25});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "08";
            this.xrTableCell12.Weight = 0.090875919717941844D;
            // 
            // xrTable24
            // 
            this.xrTable24.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 1.192093E-05F);
            this.xrTable24.Name = "xrTable24";
            this.xrTable24.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow24});
            this.xrTable24.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow24
            // 
            this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell90});
            this.xrTableRow24.Name = "xrTableRow24";
            this.xrTableRow24.Weight = 1D;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.StylePriority.UseBorders = false;
            this.xrTableCell90.Text = "08";
            this.xrTableCell90.Weight = 3D;
            // 
            // xrTable25
            // 
            this.xrTable25.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 13.54169F);
            this.xrTable25.Name = "xrTable25";
            this.xrTable25.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow25});
            this.xrTable25.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow25
            // 
            this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell91,
            this.xrTableCell92,
            this.xrTableCell93,
            this.xrTableCell94});
            this.xrTableRow25.Name = "xrTableRow25";
            this.xrTableRow25.Weight = 1D;
            // 
            // xrTableCell91
            // 
            this.xrTableCell91.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell91.Multiline = true;
            this.xrTableCell91.Name = "xrTableCell91";
            this.xrTableCell91.StylePriority.UseBorders = false;
            this.xrTableCell91.Text = "100\r\n%";
            this.xrTableCell91.Weight = 0.5D;
            // 
            // xrTableCell92
            // 
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.Text = "130%";
            this.xrTableCell92.Weight = 0.5D;
            // 
            // xrTableCell93
            // 
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.Text = "150%";
            this.xrTableCell93.Weight = 0.5D;
            // 
            // xrTableCell94
            // 
            this.xrTableCell94.Name = "xrTableCell94";
            this.xrTableCell94.Text = "195%";
            this.xrTableCell94.Weight = 0.5D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable20,
            this.xrTable21});
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "09";
            this.xrTableCell16.Weight = 0.090875911451604244D;
            // 
            // xrTable20
            // 
            this.xrTable20.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 1.589457E-05F);
            this.xrTable20.Name = "xrTable20";
            this.xrTable20.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
            this.xrTable20.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell80});
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Weight = 1D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.StylePriority.UseBorders = false;
            this.xrTableCell80.Text = "09";
            this.xrTableCell80.Weight = 3D;
            // 
            // xrTable21
            // 
            this.xrTable21.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 13.54168F);
            this.xrTable21.Name = "xrTable21";
            this.xrTable21.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow21});
            this.xrTable21.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
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
            this.xrTableCell81.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell81.Multiline = true;
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.StylePriority.UseBorders = false;
            this.xrTableCell81.Text = "100\r\n%";
            this.xrTableCell81.Weight = 0.5D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.Text = "130%";
            this.xrTableCell82.Weight = 0.5D;
            // 
            // xrTableCell83
            // 
            this.xrTableCell83.Name = "xrTableCell83";
            this.xrTableCell83.Text = "150%";
            this.xrTableCell83.Weight = 0.5D;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.Text = "195%";
            this.xrTableCell84.Weight = 0.5D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable22,
            this.xrTable23});
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "10";
            this.xrTableCell15.Weight = 0.090875904490477874D;
            // 
            // xrTable22
            // 
            this.xrTable22.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 1.589457E-05F);
            this.xrTable22.Name = "xrTable22";
            this.xrTable22.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow22});
            this.xrTable22.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow22
            // 
            this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell85});
            this.xrTableRow22.Name = "xrTableRow22";
            this.xrTableRow22.Weight = 1D;
            // 
            // xrTableCell85
            // 
            this.xrTableCell85.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.StylePriority.UseBorders = false;
            this.xrTableCell85.Text = "10";
            this.xrTableCell85.Weight = 3D;
            // 
            // xrTable23
            // 
            this.xrTable23.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 13.5417F);
            this.xrTable23.Name = "xrTable23";
            this.xrTable23.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow23});
            this.xrTable23.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow23
            // 
            this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell86,
            this.xrTableCell87,
            this.xrTableCell88,
            this.xrTableCell89});
            this.xrTableRow23.Name = "xrTableRow23";
            this.xrTableRow23.Weight = 1D;
            // 
            // xrTableCell86
            // 
            this.xrTableCell86.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell86.Multiline = true;
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.StylePriority.UseBorders = false;
            this.xrTableCell86.Text = "100\r\n%";
            this.xrTableCell86.Weight = 0.5D;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.Text = "130%";
            this.xrTableCell87.Weight = 0.5D;
            // 
            // xrTableCell88
            // 
            this.xrTableCell88.Name = "xrTableCell88";
            this.xrTableCell88.Text = "150%";
            this.xrTableCell88.Weight = 0.5D;
            // 
            // xrTableCell89
            // 
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.Text = "195%";
            this.xrTableCell89.Weight = 0.5D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable26,
            this.xrTable27});
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "11";
            this.xrTableCell17.Weight = 0.090875925373857053D;
            // 
            // xrTable26
            // 
            this.xrTable26.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.986822E-05F);
            this.xrTable26.Name = "xrTable26";
            this.xrTable26.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow26});
            this.xrTable26.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow26
            // 
            this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell95});
            this.xrTableRow26.Name = "xrTableRow26";
            this.xrTableRow26.Weight = 1D;
            // 
            // xrTableCell95
            // 
            this.xrTableCell95.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell95.Name = "xrTableCell95";
            this.xrTableCell95.StylePriority.UseBorders = false;
            this.xrTableCell95.Text = "11";
            this.xrTableCell95.Weight = 3D;
            // 
            // xrTable27
            // 
            this.xrTable27.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54169F);
            this.xrTable27.Name = "xrTable27";
            this.xrTable27.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow27});
            this.xrTable27.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow27
            // 
            this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell96,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99});
            this.xrTableRow27.Name = "xrTableRow27";
            this.xrTableRow27.Weight = 1D;
            // 
            // xrTableCell96
            // 
            this.xrTableCell96.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell96.Multiline = true;
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.StylePriority.UseBorders = false;
            this.xrTableCell96.Text = "100\r\n%";
            this.xrTableCell96.Weight = 0.5D;
            // 
            // xrTableCell97
            // 
            this.xrTableCell97.Name = "xrTableCell97";
            this.xrTableCell97.Text = "130%";
            this.xrTableCell97.Weight = 0.5D;
            // 
            // xrTableCell98
            // 
            this.xrTableCell98.Name = "xrTableCell98";
            this.xrTableCell98.Text = "150%";
            this.xrTableCell98.Weight = 0.5D;
            // 
            // xrTableCell99
            // 
            this.xrTableCell99.Name = "xrTableCell99";
            this.xrTableCell99.Text = "195%";
            this.xrTableCell99.Weight = 0.5D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable28,
            this.xrTable29});
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "12";
            this.xrTableCell18.Weight = 0.090875904272942648D;
            // 
            // xrTable28
            // 
            this.xrTable28.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.986822E-05F);
            this.xrTable28.Name = "xrTable28";
            this.xrTable28.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow28});
            this.xrTable28.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow28
            // 
            this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell100});
            this.xrTableRow28.Name = "xrTableRow28";
            this.xrTableRow28.Weight = 1D;
            // 
            // xrTableCell100
            // 
            this.xrTableCell100.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell100.Name = "xrTableCell100";
            this.xrTableCell100.StylePriority.UseBorders = false;
            this.xrTableCell100.Text = "12";
            this.xrTableCell100.Weight = 3D;
            // 
            // xrTable29
            // 
            this.xrTable29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54169F);
            this.xrTable29.Name = "xrTable29";
            this.xrTable29.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow29});
            this.xrTable29.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow29
            // 
            this.xrTableRow29.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell101,
            this.xrTableCell102,
            this.xrTableCell103,
            this.xrTableCell104});
            this.xrTableRow29.Name = "xrTableRow29";
            this.xrTableRow29.Weight = 1D;
            // 
            // xrTableCell101
            // 
            this.xrTableCell101.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell101.Multiline = true;
            this.xrTableCell101.Name = "xrTableCell101";
            this.xrTableCell101.StylePriority.UseBorders = false;
            this.xrTableCell101.Text = "100\r\n%";
            this.xrTableCell101.Weight = 0.5D;
            // 
            // xrTableCell102
            // 
            this.xrTableCell102.Name = "xrTableCell102";
            this.xrTableCell102.Text = "130%";
            this.xrTableCell102.Weight = 0.5D;
            // 
            // xrTableCell103
            // 
            this.xrTableCell103.Name = "xrTableCell103";
            this.xrTableCell103.Text = "150%";
            this.xrTableCell103.Weight = 0.5D;
            // 
            // xrTableCell104
            // 
            this.xrTableCell104.Name = "xrTableCell104";
            this.xrTableCell104.Text = "195%";
            this.xrTableCell104.Weight = 0.5D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable30,
            this.xrTable31});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "13";
            this.xrTableCell14.Weight = 0.090875911234069046D;
            // 
            // xrTable30
            // 
            this.xrTable30.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.986822E-05F);
            this.xrTable30.Name = "xrTable30";
            this.xrTable30.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow30});
            this.xrTable30.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow30
            // 
            this.xrTableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell105});
            this.xrTableRow30.Name = "xrTableRow30";
            this.xrTableRow30.Weight = 1D;
            // 
            // xrTableCell105
            // 
            this.xrTableCell105.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell105.Name = "xrTableCell105";
            this.xrTableCell105.StylePriority.UseBorders = false;
            this.xrTableCell105.Text = "13";
            this.xrTableCell105.Weight = 3D;
            // 
            // xrTable31
            // 
            this.xrTable31.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54169F);
            this.xrTable31.Name = "xrTable31";
            this.xrTable31.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow31});
            this.xrTable31.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow31
            // 
            this.xrTableRow31.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell106,
            this.xrTableCell107,
            this.xrTableCell108,
            this.xrTableCell109});
            this.xrTableRow31.Name = "xrTableRow31";
            this.xrTableRow31.Weight = 1D;
            // 
            // xrTableCell106
            // 
            this.xrTableCell106.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell106.Multiline = true;
            this.xrTableCell106.Name = "xrTableCell106";
            this.xrTableCell106.StylePriority.UseBorders = false;
            this.xrTableCell106.Text = "100\r\n%";
            this.xrTableCell106.Weight = 0.5D;
            // 
            // xrTableCell107
            // 
            this.xrTableCell107.Name = "xrTableCell107";
            this.xrTableCell107.Text = "130%";
            this.xrTableCell107.Weight = 0.5D;
            // 
            // xrTableCell108
            // 
            this.xrTableCell108.Name = "xrTableCell108";
            this.xrTableCell108.Text = "150%";
            this.xrTableCell108.Weight = 0.5D;
            // 
            // xrTableCell109
            // 
            this.xrTableCell109.Name = "xrTableCell109";
            this.xrTableCell109.Text = "195%";
            this.xrTableCell109.Weight = 0.5D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable18,
            this.xrTable19});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "14";
            this.xrTableCell20.Weight = 0.090875934075265036D;
            // 
            // xrTable18
            // 
            this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.986822E-05F);
            this.xrTable18.Name = "xrTable18";
            this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
            this.xrTable18.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell75});
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Weight = 1D;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.StylePriority.UseBorders = false;
            this.xrTableCell75.Text = "14";
            this.xrTableCell75.Weight = 3D;
            // 
            // xrTable19
            // 
            this.xrTable19.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.5417F);
            this.xrTable19.Name = "xrTable19";
            this.xrTable19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19});
            this.xrTable19.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell76,
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrTableCell79});
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Weight = 1D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell76.Multiline = true;
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.StylePriority.UseBorders = false;
            this.xrTableCell76.Text = "100\r\n%";
            this.xrTableCell76.Weight = 0.5D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Text = "130%";
            this.xrTableCell77.Weight = 0.5D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Text = "150%";
            this.xrTableCell78.Weight = 0.5D;
            // 
            // xrTableCell79
            // 
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.Text = "195%";
            this.xrTableCell79.Weight = 0.5D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable38,
            this.xrTable39});
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "15";
            this.xrTableCell19.Weight = 0.090875934075265036D;
            // 
            // xrTable38
            // 
            this.xrTable38.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.986822E-05F);
            this.xrTable38.Name = "xrTable38";
            this.xrTable38.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow38});
            this.xrTable38.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow38
            // 
            this.xrTableRow38.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell125});
            this.xrTableRow38.Name = "xrTableRow38";
            this.xrTableRow38.Weight = 1D;
            // 
            // xrTableCell125
            // 
            this.xrTableCell125.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell125.Name = "xrTableCell125";
            this.xrTableCell125.StylePriority.UseBorders = false;
            this.xrTableCell125.Text = "15";
            this.xrTableCell125.Weight = 3D;
            // 
            // xrTable39
            // 
            this.xrTable39.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.5417F);
            this.xrTable39.Name = "xrTable39";
            this.xrTable39.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow39});
            this.xrTable39.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow39
            // 
            this.xrTableRow39.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell126,
            this.xrTableCell127,
            this.xrTableCell128,
            this.xrTableCell129});
            this.xrTableRow39.Name = "xrTableRow39";
            this.xrTableRow39.Weight = 1D;
            // 
            // xrTableCell126
            // 
            this.xrTableCell126.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell126.Multiline = true;
            this.xrTableCell126.Name = "xrTableCell126";
            this.xrTableCell126.StylePriority.UseBorders = false;
            this.xrTableCell126.Text = "100\r\n%";
            this.xrTableCell126.Weight = 0.5D;
            // 
            // xrTableCell127
            // 
            this.xrTableCell127.Name = "xrTableCell127";
            this.xrTableCell127.Text = "130%";
            this.xrTableCell127.Weight = 0.5D;
            // 
            // xrTableCell128
            // 
            this.xrTableCell128.Name = "xrTableCell128";
            this.xrTableCell128.Text = "150%";
            this.xrTableCell128.Weight = 0.5D;
            // 
            // xrTableCell129
            // 
            this.xrTableCell129.Name = "xrTableCell129";
            this.xrTableCell129.Text = "195%";
            this.xrTableCell129.Weight = 0.5D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable32,
            this.xrTable33});
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "16";
            this.xrTableCell21.Weight = 0.090875934075265036D;
            // 
            // xrTable32
            // 
            this.xrTable32.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 1.986822E-05F);
            this.xrTable32.Name = "xrTable32";
            this.xrTable32.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow32});
            this.xrTable32.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow32
            // 
            this.xrTableRow32.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell110});
            this.xrTableRow32.Name = "xrTableRow32";
            this.xrTableRow32.Weight = 1D;
            // 
            // xrTableCell110
            // 
            this.xrTableCell110.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell110.Name = "xrTableCell110";
            this.xrTableCell110.StylePriority.UseBorders = false;
            this.xrTableCell110.Text = "16";
            this.xrTableCell110.Weight = 3D;
            // 
            // xrTable33
            // 
            this.xrTable33.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 13.5417F);
            this.xrTable33.Name = "xrTable33";
            this.xrTable33.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow33});
            this.xrTable33.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow33
            // 
            this.xrTableRow33.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell111,
            this.xrTableCell112,
            this.xrTableCell113,
            this.xrTableCell114});
            this.xrTableRow33.Name = "xrTableRow33";
            this.xrTableRow33.Weight = 1D;
            // 
            // xrTableCell111
            // 
            this.xrTableCell111.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell111.Multiline = true;
            this.xrTableCell111.Name = "xrTableCell111";
            this.xrTableCell111.StylePriority.UseBorders = false;
            this.xrTableCell111.Text = "100\r\n%";
            this.xrTableCell111.Weight = 0.5D;
            // 
            // xrTableCell112
            // 
            this.xrTableCell112.Name = "xrTableCell112";
            this.xrTableCell112.Text = "130%";
            this.xrTableCell112.Weight = 0.5D;
            // 
            // xrTableCell113
            // 
            this.xrTableCell113.Name = "xrTableCell113";
            this.xrTableCell113.Text = "150%";
            this.xrTableCell113.Weight = 0.5D;
            // 
            // xrTableCell114
            // 
            this.xrTableCell114.Name = "xrTableCell114";
            this.xrTableCell114.Text = "195%";
            this.xrTableCell114.Weight = 0.5D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable36,
            this.xrTable37});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "17";
            this.xrTableCell8.Weight = 0.090875934075265036D;
            // 
            // xrTable36
            // 
            this.xrTable36.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 3.178914E-05F);
            this.xrTable36.Name = "xrTable36";
            this.xrTable36.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow36});
            this.xrTable36.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow36
            // 
            this.xrTableRow36.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell120});
            this.xrTableRow36.Name = "xrTableRow36";
            this.xrTableRow36.Weight = 1D;
            // 
            // xrTableCell120
            // 
            this.xrTableCell120.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell120.Name = "xrTableCell120";
            this.xrTableCell120.StylePriority.UseBorders = false;
            this.xrTableCell120.Text = "17";
            this.xrTableCell120.Weight = 3D;
            // 
            // xrTable37
            // 
            this.xrTable37.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 13.54171F);
            this.xrTable37.Name = "xrTable37";
            this.xrTable37.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow37});
            this.xrTable37.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow37
            // 
            this.xrTableRow37.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell121,
            this.xrTableCell122,
            this.xrTableCell123,
            this.xrTableCell124});
            this.xrTableRow37.Name = "xrTableRow37";
            this.xrTableRow37.Weight = 1D;
            // 
            // xrTableCell121
            // 
            this.xrTableCell121.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell121.Multiline = true;
            this.xrTableCell121.Name = "xrTableCell121";
            this.xrTableCell121.StylePriority.UseBorders = false;
            this.xrTableCell121.Text = "100\r\n%";
            this.xrTableCell121.Weight = 0.5D;
            // 
            // xrTableCell122
            // 
            this.xrTableCell122.Name = "xrTableCell122";
            this.xrTableCell122.Text = "130%";
            this.xrTableCell122.Weight = 0.5D;
            // 
            // xrTableCell123
            // 
            this.xrTableCell123.Name = "xrTableCell123";
            this.xrTableCell123.Text = "150%";
            this.xrTableCell123.Weight = 0.5D;
            // 
            // xrTableCell124
            // 
            this.xrTableCell124.Name = "xrTableCell124";
            this.xrTableCell124.Text = "195%";
            this.xrTableCell124.Weight = 0.5D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable34,
            this.xrTable35});
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Text = "18";
            this.xrTableCell25.Weight = 0.090875908406111441D;
            // 
            // xrTable34
            // 
            this.xrTable34.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 3.576279E-05F);
            this.xrTable34.Name = "xrTable34";
            this.xrTable34.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow34});
            this.xrTable34.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow34
            // 
            this.xrTableRow34.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell115});
            this.xrTableRow34.Name = "xrTableRow34";
            this.xrTableRow34.Weight = 1D;
            // 
            // xrTableCell115
            // 
            this.xrTableCell115.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell115.Name = "xrTableCell115";
            this.xrTableCell115.StylePriority.UseBorders = false;
            this.xrTableCell115.Text = "18";
            this.xrTableCell115.Weight = 3D;
            // 
            // xrTable35
            // 
            this.xrTable35.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 13.5417F);
            this.xrTable35.Name = "xrTable35";
            this.xrTable35.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow35});
            this.xrTable35.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow35
            // 
            this.xrTableRow35.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell116,
            this.xrTableCell117,
            this.xrTableCell118,
            this.xrTableCell119});
            this.xrTableRow35.Name = "xrTableRow35";
            this.xrTableRow35.Weight = 1D;
            // 
            // xrTableCell116
            // 
            this.xrTableCell116.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell116.Multiline = true;
            this.xrTableCell116.Name = "xrTableCell116";
            this.xrTableCell116.StylePriority.UseBorders = false;
            this.xrTableCell116.Text = "100\r\n%";
            this.xrTableCell116.Weight = 0.5D;
            // 
            // xrTableCell117
            // 
            this.xrTableCell117.Name = "xrTableCell117";
            this.xrTableCell117.Text = "130%";
            this.xrTableCell117.Weight = 0.5D;
            // 
            // xrTableCell118
            // 
            this.xrTableCell118.Name = "xrTableCell118";
            this.xrTableCell118.Text = "150%";
            this.xrTableCell118.Weight = 0.5D;
            // 
            // xrTableCell119
            // 
            this.xrTableCell119.Name = "xrTableCell119";
            this.xrTableCell119.Text = "195%";
            this.xrTableCell119.Weight = 0.5D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable40,
            this.xrTable41});
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "19";
            this.xrTableCell24.Weight = 0.090875908406111441D;
            // 
            // xrTable40
            // 
            this.xrTable40.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 3.576279E-05F);
            this.xrTable40.Name = "xrTable40";
            this.xrTable40.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow40});
            this.xrTable40.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow40
            // 
            this.xrTableRow40.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell130});
            this.xrTableRow40.Name = "xrTableRow40";
            this.xrTableRow40.Weight = 1D;
            // 
            // xrTableCell130
            // 
            this.xrTableCell130.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell130.Name = "xrTableCell130";
            this.xrTableCell130.StylePriority.UseBorders = false;
            this.xrTableCell130.Text = "19";
            this.xrTableCell130.Weight = 3D;
            // 
            // xrTable41
            // 
            this.xrTable41.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 13.5417F);
            this.xrTable41.Name = "xrTable41";
            this.xrTable41.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow41});
            this.xrTable41.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow41
            // 
            this.xrTableRow41.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell131,
            this.xrTableCell132,
            this.xrTableCell133,
            this.xrTableCell134});
            this.xrTableRow41.Name = "xrTableRow41";
            this.xrTableRow41.Weight = 1D;
            // 
            // xrTableCell131
            // 
            this.xrTableCell131.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell131.Multiline = true;
            this.xrTableCell131.Name = "xrTableCell131";
            this.xrTableCell131.StylePriority.UseBorders = false;
            this.xrTableCell131.Text = "100\r\n%";
            this.xrTableCell131.Weight = 0.5D;
            // 
            // xrTableCell132
            // 
            this.xrTableCell132.Name = "xrTableCell132";
            this.xrTableCell132.Text = "130%";
            this.xrTableCell132.Weight = 0.5D;
            // 
            // xrTableCell133
            // 
            this.xrTableCell133.Name = "xrTableCell133";
            this.xrTableCell133.Text = "150%";
            this.xrTableCell133.Weight = 0.5D;
            // 
            // xrTableCell134
            // 
            this.xrTableCell134.Name = "xrTableCell134";
            this.xrTableCell134.Text = "195%";
            this.xrTableCell134.Weight = 0.5D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable62,
            this.xrTable63});
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Text = "20";
            this.xrTableCell23.Weight = 0.090875905795689035D;
            // 
            // xrTable62
            // 
            this.xrTable62.LocationFloat = new DevExpress.Utils.PointFloat(8.742014E-05F, 8.34465E-05F);
            this.xrTable62.Name = "xrTable62";
            this.xrTable62.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow62});
            this.xrTable62.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow62
            // 
            this.xrTableRow62.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell185});
            this.xrTableRow62.Name = "xrTableRow62";
            this.xrTableRow62.Weight = 1D;
            // 
            // xrTableCell185
            // 
            this.xrTableCell185.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell185.Name = "xrTableCell185";
            this.xrTableCell185.StylePriority.UseBorders = false;
            this.xrTableCell185.Text = "20";
            this.xrTableCell185.Weight = 3D;
            // 
            // xrTable63
            // 
            this.xrTable63.LocationFloat = new DevExpress.Utils.PointFloat(8.742014E-05F, 13.54177F);
            this.xrTable63.Name = "xrTable63";
            this.xrTable63.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow63});
            this.xrTable63.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow63
            // 
            this.xrTableRow63.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell186,
            this.xrTableCell187,
            this.xrTableCell188,
            this.xrTableCell189});
            this.xrTableRow63.Name = "xrTableRow63";
            this.xrTableRow63.Weight = 1D;
            // 
            // xrTableCell186
            // 
            this.xrTableCell186.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell186.Multiline = true;
            this.xrTableCell186.Name = "xrTableCell186";
            this.xrTableCell186.StylePriority.UseBorders = false;
            this.xrTableCell186.Text = "100\r\n%";
            this.xrTableCell186.Weight = 0.5D;
            // 
            // xrTableCell187
            // 
            this.xrTableCell187.Name = "xrTableCell187";
            this.xrTableCell187.Text = "130%";
            this.xrTableCell187.Weight = 0.5D;
            // 
            // xrTableCell188
            // 
            this.xrTableCell188.Name = "xrTableCell188";
            this.xrTableCell188.Text = "150%";
            this.xrTableCell188.Weight = 0.5D;
            // 
            // xrTableCell189
            // 
            this.xrTableCell189.Name = "xrTableCell189";
            this.xrTableCell189.Text = "195%";
            this.xrTableCell189.Weight = 0.5D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable61,
            this.xrTable60});
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Text = "21";
            this.xrTableCell27.Weight = 0.090875927549209035D;
            // 
            // xrTable61
            // 
            this.xrTable61.LocationFloat = new DevExpress.Utils.PointFloat(5.5631E-05F, 7.947286E-05F);
            this.xrTable61.Name = "xrTable61";
            this.xrTable61.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow61});
            this.xrTable61.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow61
            // 
            this.xrTableRow61.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell184});
            this.xrTableRow61.Name = "xrTableRow61";
            this.xrTableRow61.Weight = 1D;
            // 
            // xrTableCell184
            // 
            this.xrTableCell184.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell184.Name = "xrTableCell184";
            this.xrTableCell184.StylePriority.UseBorders = false;
            this.xrTableCell184.Text = "21";
            this.xrTableCell184.Weight = 3D;
            // 
            // xrTable60
            // 
            this.xrTable60.LocationFloat = new DevExpress.Utils.PointFloat(0.0001827876F, 13.54175F);
            this.xrTable60.Name = "xrTable60";
            this.xrTable60.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow60});
            this.xrTable60.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow60
            // 
            this.xrTableRow60.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell180,
            this.xrTableCell181,
            this.xrTableCell182,
            this.xrTableCell183});
            this.xrTableRow60.Name = "xrTableRow60";
            this.xrTableRow60.Weight = 1D;
            // 
            // xrTableCell180
            // 
            this.xrTableCell180.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell180.Multiline = true;
            this.xrTableCell180.Name = "xrTableCell180";
            this.xrTableCell180.StylePriority.UseBorders = false;
            this.xrTableCell180.Text = "100\r\n%";
            this.xrTableCell180.Weight = 0.5D;
            // 
            // xrTableCell181
            // 
            this.xrTableCell181.Name = "xrTableCell181";
            this.xrTableCell181.Text = "130%";
            this.xrTableCell181.Weight = 0.5D;
            // 
            // xrTableCell182
            // 
            this.xrTableCell182.Name = "xrTableCell182";
            this.xrTableCell182.Text = "150%";
            this.xrTableCell182.Weight = 0.5D;
            // 
            // xrTableCell183
            // 
            this.xrTableCell183.Name = "xrTableCell183";
            this.xrTableCell183.Text = "195%";
            this.xrTableCell183.Weight = 0.5D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable59,
            this.xrTable58});
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Text = "22";
            this.xrTableCell26.Weight = 0.090875927549209035D;
            // 
            // xrTable59
            // 
            this.xrTable59.LocationFloat = new DevExpress.Utils.PointFloat(0F, 7.549921E-05F);
            this.xrTable59.Name = "xrTable59";
            this.xrTable59.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow59});
            this.xrTable59.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow59
            // 
            this.xrTableRow59.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell179});
            this.xrTableRow59.Name = "xrTableRow59";
            this.xrTableRow59.Weight = 1D;
            // 
            // xrTableCell179
            // 
            this.xrTableCell179.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell179.Name = "xrTableCell179";
            this.xrTableCell179.StylePriority.UseBorders = false;
            this.xrTableCell179.Text = "22";
            this.xrTableCell179.Weight = 3D;
            // 
            // xrTable58
            // 
            this.xrTable58.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54174F);
            this.xrTable58.Name = "xrTable58";
            this.xrTable58.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow58});
            this.xrTable58.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow58
            // 
            this.xrTableRow58.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell175,
            this.xrTableCell176,
            this.xrTableCell177,
            this.xrTableCell178});
            this.xrTableRow58.Name = "xrTableRow58";
            this.xrTableRow58.Weight = 1D;
            // 
            // xrTableCell175
            // 
            this.xrTableCell175.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell175.Multiline = true;
            this.xrTableCell175.Name = "xrTableCell175";
            this.xrTableCell175.StylePriority.UseBorders = false;
            this.xrTableCell175.Text = "100\r\n%";
            this.xrTableCell175.Weight = 0.5D;
            // 
            // xrTableCell176
            // 
            this.xrTableCell176.Name = "xrTableCell176";
            this.xrTableCell176.Text = "130%";
            this.xrTableCell176.Weight = 0.5D;
            // 
            // xrTableCell177
            // 
            this.xrTableCell177.Name = "xrTableCell177";
            this.xrTableCell177.Text = "150%";
            this.xrTableCell177.Weight = 0.5D;
            // 
            // xrTableCell178
            // 
            this.xrTableCell178.Name = "xrTableCell178";
            this.xrTableCell178.Text = "195%";
            this.xrTableCell178.Weight = 0.5D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable57,
            this.xrTable56});
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "23";
            this.xrTableCell28.Weight = 0.090875927549209035D;
            // 
            // xrTable57
            // 
            this.xrTable57.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 7.549921E-05F);
            this.xrTable57.Name = "xrTable57";
            this.xrTable57.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow57});
            this.xrTable57.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow57
            // 
            this.xrTableRow57.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell174});
            this.xrTableRow57.Name = "xrTableRow57";
            this.xrTableRow57.Weight = 1D;
            // 
            // xrTableCell174
            // 
            this.xrTableCell174.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell174.Name = "xrTableCell174";
            this.xrTableCell174.StylePriority.UseBorders = false;
            this.xrTableCell174.Text = "23";
            this.xrTableCell174.Weight = 3D;
            // 
            // xrTable56
            // 
            this.xrTable56.LocationFloat = new DevExpress.Utils.PointFloat(0.0002702077F, 13.54176F);
            this.xrTable56.Name = "xrTable56";
            this.xrTable56.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow56});
            this.xrTable56.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow56
            // 
            this.xrTableRow56.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell170,
            this.xrTableCell171,
            this.xrTableCell172,
            this.xrTableCell173});
            this.xrTableRow56.Name = "xrTableRow56";
            this.xrTableRow56.Weight = 1D;
            // 
            // xrTableCell170
            // 
            this.xrTableCell170.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell170.Multiline = true;
            this.xrTableCell170.Name = "xrTableCell170";
            this.xrTableCell170.StylePriority.UseBorders = false;
            this.xrTableCell170.Text = "100\r\n%";
            this.xrTableCell170.Weight = 0.5D;
            // 
            // xrTableCell171
            // 
            this.xrTableCell171.Name = "xrTableCell171";
            this.xrTableCell171.Text = "130%";
            this.xrTableCell171.Weight = 0.5D;
            // 
            // xrTableCell172
            // 
            this.xrTableCell172.Name = "xrTableCell172";
            this.xrTableCell172.Text = "150%";
            this.xrTableCell172.Weight = 0.5D;
            // 
            // xrTableCell173
            // 
            this.xrTableCell173.Name = "xrTableCell173";
            this.xrTableCell173.Text = "195%";
            this.xrTableCell173.Weight = 0.5D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable55,
            this.xrTable54});
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Text = "24";
            this.xrTableCell22.Weight = 0.090875927549209035D;
            // 
            // xrTable55
            // 
            this.xrTable55.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.755193E-05F);
            this.xrTable55.Name = "xrTable55";
            this.xrTable55.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow55});
            this.xrTable55.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow55
            // 
            this.xrTableRow55.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell169});
            this.xrTableRow55.Name = "xrTableRow55";
            this.xrTableRow55.Weight = 1D;
            // 
            // xrTableCell169
            // 
            this.xrTableCell169.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell169.Name = "xrTableCell169";
            this.xrTableCell169.StylePriority.UseBorders = false;
            this.xrTableCell169.Text = "24";
            this.xrTableCell169.Weight = 3D;
            // 
            // xrTable54
            // 
            this.xrTable54.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 13.54175F);
            this.xrTable54.Name = "xrTable54";
            this.xrTable54.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow54});
            this.xrTable54.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow54
            // 
            this.xrTableRow54.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell165,
            this.xrTableCell166,
            this.xrTableCell167,
            this.xrTableCell168});
            this.xrTableRow54.Name = "xrTableRow54";
            this.xrTableRow54.Weight = 1D;
            // 
            // xrTableCell165
            // 
            this.xrTableCell165.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell165.Multiline = true;
            this.xrTableCell165.Name = "xrTableCell165";
            this.xrTableCell165.StylePriority.UseBorders = false;
            this.xrTableCell165.Text = "100\r\n%";
            this.xrTableCell165.Weight = 0.5D;
            // 
            // xrTableCell166
            // 
            this.xrTableCell166.Name = "xrTableCell166";
            this.xrTableCell166.Text = "130%";
            this.xrTableCell166.Weight = 0.5D;
            // 
            // xrTableCell167
            // 
            this.xrTableCell167.Name = "xrTableCell167";
            this.xrTableCell167.Text = "150%";
            this.xrTableCell167.Weight = 0.5D;
            // 
            // xrTableCell168
            // 
            this.xrTableCell168.Name = "xrTableCell168";
            this.xrTableCell168.Text = "195%";
            this.xrTableCell168.Weight = 0.5D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable53,
            this.xrTable52});
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "25";
            this.xrTableCell32.Weight = 0.090875908406111441D;
            // 
            // xrTable53
            // 
            this.xrTable53.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.755193E-05F);
            this.xrTable53.Name = "xrTable53";
            this.xrTable53.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow53});
            this.xrTable53.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow53
            // 
            this.xrTableRow53.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell164});
            this.xrTableRow53.Name = "xrTableRow53";
            this.xrTableRow53.Weight = 1D;
            // 
            // xrTableCell164
            // 
            this.xrTableCell164.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell164.Name = "xrTableCell164";
            this.xrTableCell164.StylePriority.UseBorders = false;
            this.xrTableCell164.Text = "25";
            this.xrTableCell164.Weight = 3D;
            // 
            // xrTable52
            // 
            this.xrTable52.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54175F);
            this.xrTable52.Name = "xrTable52";
            this.xrTable52.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow52});
            this.xrTable52.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow52
            // 
            this.xrTableRow52.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell160,
            this.xrTableCell161,
            this.xrTableCell162,
            this.xrTableCell163});
            this.xrTableRow52.Name = "xrTableRow52";
            this.xrTableRow52.Weight = 1D;
            // 
            // xrTableCell160
            // 
            this.xrTableCell160.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell160.Multiline = true;
            this.xrTableCell160.Name = "xrTableCell160";
            this.xrTableCell160.StylePriority.UseBorders = false;
            this.xrTableCell160.Text = "100\r\n%";
            this.xrTableCell160.Weight = 0.5D;
            // 
            // xrTableCell161
            // 
            this.xrTableCell161.Name = "xrTableCell161";
            this.xrTableCell161.Text = "130%";
            this.xrTableCell161.Weight = 0.5D;
            // 
            // xrTableCell162
            // 
            this.xrTableCell162.Name = "xrTableCell162";
            this.xrTableCell162.Text = "150%";
            this.xrTableCell162.Weight = 0.5D;
            // 
            // xrTableCell163
            // 
            this.xrTableCell163.Name = "xrTableCell163";
            this.xrTableCell163.Text = "195%";
            this.xrTableCell163.Weight = 0.5D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable44,
            this.xrTable45});
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Text = "26";
            this.xrTableCell30.Weight = 0.090875908406111428D;
            // 
            // xrTable44
            // 
            this.xrTable44.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.755193E-05F);
            this.xrTable44.Name = "xrTable44";
            this.xrTable44.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow44});
            this.xrTable44.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow44
            // 
            this.xrTableRow44.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell140});
            this.xrTableRow44.Name = "xrTableRow44";
            this.xrTableRow44.Weight = 1D;
            // 
            // xrTableCell140
            // 
            this.xrTableCell140.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell140.Name = "xrTableCell140";
            this.xrTableCell140.StylePriority.UseBorders = false;
            this.xrTableCell140.Text = "26";
            this.xrTableCell140.Weight = 3D;
            // 
            // xrTable45
            // 
            this.xrTable45.LocationFloat = new DevExpress.Utils.PointFloat(4.768372E-05F, 13.54173F);
            this.xrTable45.Name = "xrTable45";
            this.xrTable45.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow45});
            this.xrTable45.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow45
            // 
            this.xrTableRow45.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell141,
            this.xrTableCell142,
            this.xrTableCell143,
            this.xrTableCell144});
            this.xrTableRow45.Name = "xrTableRow45";
            this.xrTableRow45.Weight = 1D;
            // 
            // xrTableCell141
            // 
            this.xrTableCell141.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell141.Multiline = true;
            this.xrTableCell141.Name = "xrTableCell141";
            this.xrTableCell141.StylePriority.UseBorders = false;
            this.xrTableCell141.Text = "100\r\n%";
            this.xrTableCell141.Weight = 0.5D;
            // 
            // xrTableCell142
            // 
            this.xrTableCell142.Name = "xrTableCell142";
            this.xrTableCell142.Text = "130%";
            this.xrTableCell142.Weight = 0.5D;
            // 
            // xrTableCell143
            // 
            this.xrTableCell143.Name = "xrTableCell143";
            this.xrTableCell143.Text = "150%";
            this.xrTableCell143.Weight = 0.5D;
            // 
            // xrTableCell144
            // 
            this.xrTableCell144.Name = "xrTableCell144";
            this.xrTableCell144.Text = "195%";
            this.xrTableCell144.Weight = 0.5D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable42,
            this.xrTable43});
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "27";
            this.xrTableCell29.Weight = 0.090875905795689049D;
            // 
            // xrTable42
            // 
            this.xrTable42.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 6.755193E-05F);
            this.xrTable42.Name = "xrTable42";
            this.xrTable42.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow42});
            this.xrTable42.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow42
            // 
            this.xrTableRow42.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell135});
            this.xrTableRow42.Name = "xrTableRow42";
            this.xrTableRow42.Weight = 1D;
            // 
            // xrTableCell135
            // 
            this.xrTableCell135.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell135.Name = "xrTableCell135";
            this.xrTableCell135.StylePriority.UseBorders = false;
            this.xrTableCell135.Text = "27";
            this.xrTableCell135.Weight = 3D;
            // 
            // xrTable43
            // 
            this.xrTable43.LocationFloat = new DevExpress.Utils.PointFloat(0.000222524F, 13.54173F);
            this.xrTable43.Name = "xrTable43";
            this.xrTable43.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow43});
            this.xrTable43.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow43
            // 
            this.xrTableRow43.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell136,
            this.xrTableCell137,
            this.xrTableCell138,
            this.xrTableCell139});
            this.xrTableRow43.Name = "xrTableRow43";
            this.xrTableRow43.Weight = 1D;
            // 
            // xrTableCell136
            // 
            this.xrTableCell136.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell136.Multiline = true;
            this.xrTableCell136.Name = "xrTableCell136";
            this.xrTableCell136.StylePriority.UseBorders = false;
            this.xrTableCell136.Text = "100\r\n%";
            this.xrTableCell136.Weight = 0.5D;
            // 
            // xrTableCell137
            // 
            this.xrTableCell137.Name = "xrTableCell137";
            this.xrTableCell137.Text = "130%";
            this.xrTableCell137.Weight = 0.5D;
            // 
            // xrTableCell138
            // 
            this.xrTableCell138.Name = "xrTableCell138";
            this.xrTableCell138.Text = "150%";
            this.xrTableCell138.Weight = 0.5D;
            // 
            // xrTableCell139
            // 
            this.xrTableCell139.Name = "xrTableCell139";
            this.xrTableCell139.Text = "195%";
            this.xrTableCell139.Weight = 0.5D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable50,
            this.xrTable51});
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "28";
            this.xrTableCell31.Weight = 0.090875912756815419D;
            // 
            // xrTable50
            // 
            this.xrTable50.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.960464E-05F);
            this.xrTable50.Name = "xrTable50";
            this.xrTable50.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow50});
            this.xrTable50.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow50
            // 
            this.xrTableRow50.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell155});
            this.xrTableRow50.Name = "xrTableRow50";
            this.xrTableRow50.Weight = 1D;
            // 
            // xrTableCell155
            // 
            this.xrTableCell155.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell155.Name = "xrTableCell155";
            this.xrTableCell155.StylePriority.UseBorders = false;
            this.xrTableCell155.Text = "28";
            this.xrTableCell155.Weight = 3D;
            // 
            // xrTable51
            // 
            this.xrTable51.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 13.54173F);
            this.xrTable51.Name = "xrTable51";
            this.xrTable51.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow51});
            this.xrTable51.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow51
            // 
            this.xrTableRow51.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell156,
            this.xrTableCell157,
            this.xrTableCell158,
            this.xrTableCell159});
            this.xrTableRow51.Name = "xrTableRow51";
            this.xrTableRow51.Weight = 1D;
            // 
            // xrTableCell156
            // 
            this.xrTableCell156.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell156.Multiline = true;
            this.xrTableCell156.Name = "xrTableCell156";
            this.xrTableCell156.StylePriority.UseBorders = false;
            this.xrTableCell156.Text = "100\r\n%";
            this.xrTableCell156.Weight = 0.5D;
            // 
            // xrTableCell157
            // 
            this.xrTableCell157.Name = "xrTableCell157";
            this.xrTableCell157.Text = "130%";
            this.xrTableCell157.Weight = 0.5D;
            // 
            // xrTableCell158
            // 
            this.xrTableCell158.Name = "xrTableCell158";
            this.xrTableCell158.Text = "150%";
            this.xrTableCell158.Weight = 0.5D;
            // 
            // xrTableCell159
            // 
            this.xrTableCell159.Name = "xrTableCell159";
            this.xrTableCell159.Text = "195%";
            this.xrTableCell159.Weight = 0.5D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable48,
            this.xrTable49});
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Text = "29";
            this.xrTableCell33.Weight = 0.090875904925548243D;
            // 
            // xrTable48
            // 
            this.xrTable48.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 5.165736E-05F);
            this.xrTable48.Name = "xrTable48";
            this.xrTable48.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow48});
            this.xrTable48.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow48
            // 
            this.xrTableRow48.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell150});
            this.xrTableRow48.Name = "xrTableRow48";
            this.xrTableRow48.Weight = 1D;
            // 
            // xrTableCell150
            // 
            this.xrTableCell150.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell150.Name = "xrTableCell150";
            this.xrTableCell150.StylePriority.UseBorders = false;
            this.xrTableCell150.Text = "29";
            this.xrTableCell150.Weight = 3D;
            // 
            // xrTable49
            // 
            this.xrTable49.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 13.54173F);
            this.xrTable49.Name = "xrTable49";
            this.xrTable49.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow49});
            this.xrTable49.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow49
            // 
            this.xrTableRow49.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell151,
            this.xrTableCell152,
            this.xrTableCell153,
            this.xrTableCell154});
            this.xrTableRow49.Name = "xrTableRow49";
            this.xrTableRow49.Weight = 1D;
            // 
            // xrTableCell151
            // 
            this.xrTableCell151.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell151.Multiline = true;
            this.xrTableCell151.Name = "xrTableCell151";
            this.xrTableCell151.StylePriority.UseBorders = false;
            this.xrTableCell151.Text = "100\r\n%";
            this.xrTableCell151.Weight = 0.5D;
            // 
            // xrTableCell152
            // 
            this.xrTableCell152.Name = "xrTableCell152";
            this.xrTableCell152.Text = "130%";
            this.xrTableCell152.Weight = 0.5D;
            // 
            // xrTableCell153
            // 
            this.xrTableCell153.Name = "xrTableCell153";
            this.xrTableCell153.Text = "150%";
            this.xrTableCell153.Weight = 0.5D;
            // 
            // xrTableCell154
            // 
            this.xrTableCell154.Name = "xrTableCell154";
            this.xrTableCell154.Text = "195%";
            this.xrTableCell154.Weight = 0.5D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable46,
            this.xrTable47});
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Text = "30";
            this.xrTableCell34.Weight = 0.090875946257236218D;
            // 
            // xrTable46
            // 
            this.xrTable46.LocationFloat = new DevExpress.Utils.PointFloat(4.768372E-05F, 5.165736E-05F);
            this.xrTable46.Name = "xrTable46";
            this.xrTable46.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow46});
            this.xrTable46.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow46
            // 
            this.xrTableRow46.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell145});
            this.xrTableRow46.Name = "xrTableRow46";
            this.xrTableRow46.Weight = 1D;
            // 
            // xrTableCell145
            // 
            this.xrTableCell145.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell145.Name = "xrTableCell145";
            this.xrTableCell145.StylePriority.UseBorders = false;
            this.xrTableCell145.Text = "30";
            this.xrTableCell145.Weight = 3D;
            // 
            // xrTable47
            // 
            this.xrTable47.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54173F);
            this.xrTable47.Name = "xrTable47";
            this.xrTable47.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow47});
            this.xrTable47.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow47
            // 
            this.xrTableRow47.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell146,
            this.xrTableCell147,
            this.xrTableCell148,
            this.xrTableCell149});
            this.xrTableRow47.Name = "xrTableRow47";
            this.xrTableRow47.Weight = 1D;
            // 
            // xrTableCell146
            // 
            this.xrTableCell146.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell146.Multiline = true;
            this.xrTableCell146.Name = "xrTableCell146";
            this.xrTableCell146.StylePriority.UseBorders = false;
            this.xrTableCell146.Text = "100\r\n%";
            this.xrTableCell146.Weight = 0.5D;
            // 
            // xrTableCell147
            // 
            this.xrTableCell147.Name = "xrTableCell147";
            this.xrTableCell147.Text = "130%";
            this.xrTableCell147.Weight = 0.5D;
            // 
            // xrTableCell148
            // 
            this.xrTableCell148.Name = "xrTableCell148";
            this.xrTableCell148.Text = "150%";
            this.xrTableCell148.Weight = 0.5D;
            // 
            // xrTableCell149
            // 
            this.xrTableCell149.Name = "xrTableCell149";
            this.xrTableCell149.Text = "195%";
            this.xrTableCell149.Weight = 0.5D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable16,
            this.xrTable17});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "31";
            this.xrTableCell3.Weight = 0.090875946257236218D;
            // 
            // xrTable16
            // 
            this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 3.973643E-05F);
            this.xrTable16.Name = "xrTable16";
            this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16});
            this.xrTable16.SizeF = new System.Drawing.SizeF(49.8F, 13.54168F);
            // 
            // xrTableRow16
            // 
            this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell70});
            this.xrTableRow16.Name = "xrTableRow16";
            this.xrTableRow16.Weight = 1D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StylePriority.UseBorders = false;
            this.xrTableCell70.Text = "31";
            this.xrTableCell70.Weight = 3D;
            // 
            // xrTable17
            // 
            this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.54172F);
            this.xrTable17.Name = "xrTable17";
            this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
            this.xrTable17.SizeF = new System.Drawing.SizeF(49.8F, 19.01041F);
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74});
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Weight = 1D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell71.Multiline = true;
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseBorders = false;
            this.xrTableCell71.Text = "100\r\n%";
            this.xrTableCell71.Weight = 0.5D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Text = "130%";
            this.xrTableCell72.Weight = 0.5D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.Text = "150%";
            this.xrTableCell73.Weight = 0.5D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Text = "195%";
            this.xrTableCell74.Weight = 0.5D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrTable1});
            this.ReportHeader.HeightF = 76.71877F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(100F, 21F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(352.0833F, 10.5F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "THÁNG {0} NĂM {1}";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(100F, 10.5F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(352.0833F, 10.5F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "CÔNG TY TNHH AUSTFEED VIỆT NAM";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(352.0833F, 10.5F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "BÁO CÁO LÀM THÊM GIỜ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable64});
            this.GroupHeader1.HeightF = 15F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable64
            // 
            this.xrTable64.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable64.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable64.Name = "xrTable64";
            this.xrTable64.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow64});
            this.xrTable64.SizeF = new System.Drawing.SizeF(1642.05F, 15F);
            this.xrTable64.StylePriority.UseBorders = false;
            // 
            // xrTableRow64
            // 
            this.xrTableRow64.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell196});
            this.xrTableRow64.Name = "xrTableRow64";
            this.xrTableRow64.Weight = 1D;
            // 
            // xrTableCell196
            // 
            this.xrTableCell196.Name = "xrTableCell196";
            this.xrTableCell196.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrTableCell196.StylePriority.UsePadding = false;
            this.xrTableCell196.StylePriority.UseTextAlignment = false;
            this.xrTableCell196.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell196.Weight = 2.9999999999999996D;
            // 
            // rp_austfeed_BaoCaoLamThemGio
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1});
            this.Font = new System.Drawing.Font("Times New Roman", 5F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(4, 6, 15, 23);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
