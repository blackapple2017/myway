using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using DevExpress.XtraPrinting;

/// <summary>
/// Summary description for rpt_NhanSu_Detail
/// </summary>
public class rpt_NhanSu_Detail : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel6;
    private XRLabel xrl_NGAY_SINH;
    private XRLabel xrl_HO_TEN;
    private XRLabel xrl_TINH_THANH;
    private XRLabel xrl_BI_DANH;
    private XRLabel xrl_TEN_KHAC;
    private XRLabel xrl_NGAY_TUYEN_CHINH;
    private XRLabel xrl_NGHE_TRUOC_TUYEN;
    private XRLabel xrl_NGAY_TUYEN_DAU;
    private XRLabel xrl_HO_KHAU;
    private XRLabel xrLabel13;
    private XRLabel xrl_DAN_TOC;
    private XRLabel xrl_NOI_O_HIENNAY;
    private XRLabel xrl_TON_GIAO;
    private XRLabel xrl_NGAY_VAO_CT;
    private XRLabel xrl_HT_TUYEN;
    private XRLabel xrl_DI_DONG;
    private XRLabel xrl_DT_NHA;
    private XRLabel xrl_DT_COQUAN;
    private XRLabel xrl_TD_VH;
    private XRLabel xrl_TT_SUCKHOE;
    private XRLabel xrl_NHOM_MAU;
    private XRLabel xrl_CHIEU_CAO;
    private XRLabel xrl_CAN_NANG;
    private XRLabel xrl_NGOAI_NGU;
    private XRLabel xrl_TINHOC;
    private XRLabel xrl_CHUYEN_NGANH;
    private XRLabel xrl_NAM_TN;
    private XRLabel xrl_XEPLOAI;
    private XRLabel xrl_CONGVIEC;
    private XRLabel xrl_CHUCVU;
    private XRLabel xrl_NGAY_BN_CHUVU;
    private XRLabel xrl_NGACH;
    private XRLabel xrl_NGAY_BN_NGACH;
    private XRLabel xrl_NGAY_TGCM;
    private XRLabel xrl_EMAIL;
    private XRLabel xrl_NGAY_RA_QD;
    private XRLabel xrl_CHUCVU_QD;
    private XRLabel xrl_CAPBAC_QD;
    private XRLabel xrl_NGAY_VAO_DOAN;
    private XRLabel xrl_NOI_KN_DOAN;
    private XRLabel xrl_CHUCVU_DOAN;
    private XRLabel xrl_NGAY_VAO_DANG;
    private XRLabel xrl_CHUCVU_DANG;
    private XRLabel xrl_HS_LUONG;
    private XRLabel xrl_NOI_KN_DANG;
    private XRLabel xrl_NGAY_CT_VAO_DANG;
    private XRLabel xrl_PHUCAP_KHAC;
    private XRLabel xrl_PHUCAP_CHUCVU;
    private XRLabel xrl_PHUCAP_TNVK;
    private XRLabel xrl_NGAY_HUONG_TNVK;
    private XRLabel xrl_BAC_LUONG;
    private XRLabel xrl_NGAY_HUONG_LUONG;
    private XRLabel xrl_SO_THE_BHXH;
    private XRLabel xrl_NGAYCAP_BHXH;
    private XRLabel xrl_TD_QUANLY;
    private XRLabel xrl_TD_CHINHTRI;
    private XRLabel xrl_TD_QLKT;
    private XRLabel xrl_NANGLUC;
    private XRLabel xrl_NOICAP_CMND;
    private XRLabel xrl_SO_CMND;
    private XRLabel xrl_LOAI_CS;
    private XRLabel xrl_NGAYCAP_CMND;
    private XRLabel xrl_GIOI_TINH;
    private XRLabel xrl_NOI_SINH;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrl_TRINHDO;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel9;
    private XRLabel xrLabel12;
    private XRLabel xrLabel14;
    private XRCheckBox xrc_NAM;
    private XRCheckBox xrc_NU;
    private XRLabel xrl_NGAYSINH;
    private XRLabel xrl_THEO_HS_GOC;
    private XRLabel xrl_THEO_DV_HC;
    private XRLabel xrLabel15;
    private XRLabel xrl_NGAY_TUYEN_DAUTIEN;
    private XRLabel xrLabel16;
    private XRCheckBox xrc_XETTUYEN;
    private XRCheckBox xrc_THITUYEN;
    private XRCheckBox xrc_TUYENTHANG;
    private XRCheckBox xrc_DACCACH;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRCheckBox xrc_TAPSU;
    private XRCheckBox xrc_DUBI;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRCheckBox xrc_TRUOC_T7;
    private XRCheckBox xrc_HD_KXD_TH;
    private XRCheckBox xrc_HD_CO_TH;
    private XRCheckBox xrc_HD_THUVIEC;
    private XRCheckBox xrc_HD_DACBIET;
    private XRLabel xrLabel22;
    private XRCheckBox xrc_HD_KXD_TH_1;
    private XRCheckBox xrc_HD_CO_TH_1;
    private XRCheckBox xrc_TUYEN_CT;
    private XRLabel xrl_NGAY_TUYENDUNG_CT;
    private XRLabel xrLabel23;
    private XRLabel xrl_NGAYVAO_CT;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrl_MA_NGACH;
    private XRLabel xrl_NGAY_BNN;
    private XRLabel xrLabel26;
    private XRLabel xrl_PHANTRAN_HUONG;
    private XRLabel xrLabel27;
    private XRLabel xrl_NGAY_NL;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel33;
    private XRLabel xrl_HESO_PC_CD;
    private XRLabel xrl_NGAY_BN_CV;
    private XRLabel xrl_NGAY_CAP_BH;
    private XRCheckBox xrc_DAIHOC;
    private XRCheckBox xrc_THACSY;
    private XRCheckBox xrc_TRUNGCAP;
    private XRCheckBox xrc_CAODANG;
    private XRCheckBox xrc_TIENSY;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRCheckBox xrc_CAOCAP_CTRI;
    private XRCheckBox xrc_SOCAP_CTRI;
    private XRCheckBox xrc_TRUNGCAP_CT;
    private XRCheckBox xrc_CUNHAN_CTRI;
    private XRCheckBox xrc_QL_CVCC;
    private XRCheckBox xrc_QL_CUNHAN;
    private XRCheckBox xrc_QL_CVC;
    private XRCheckBox xrc_QL_CANSU;
    private XRCheckBox xrc_QL_CONGVIEC;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRCheckBox xrCheckBox4;
    private XRCheckBox xrc_QUOCPHONG;
    private XRCheckBox xrc_ANNINH;
    private XRCheckBox xrc_TC_TK_TH;
    private XRCheckBox xrc_LD_CHIHUY;
    private XRLabel xrLabel46;
    private XRLabel xrLabel45;
    private XRLabel xrLabel44;
    private XRLabel xrl_NAM_PHONGTANG;
    private XRLabel xrl_DANHHIEU_NN_T;
    private XRLabel xrLabel43;
    private XRLabel xrLabel42;
    private XRLabel xrLabel41;
    private XRLabel xrLabel40;
    private XRLabel xrl_NAM_PHONGCHUC;
    private XRLabel xrl_CHUCDANH_KH;
    private XRCheckBox xrc_TUYENTRUYEN_VD;
    private XRCheckBox xrc_PT_TH;
    private XRCheckBox xrc_NC_CS;
    private XRCheckBox xrc_TT_KT;
    private XRCheckBox xrc_PM_SK_CM;
    private XRLabel xrLabel47;
    private XRLabel xrLabel48;
    private XRLabel xrl_Mail;
    private XRLabel xrLabel49;
    private XRLabel xrLabel50;
    private XRLabel xrLabel51;
    private XRLabel xrLabel53;
    private XRLabel xrLabel52;
    private XRLabel xrLabel55;
    private XRLabel xrLabel54;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private XRLabel xrLabel56;
    private XRSubreport xrsub_QTCT;
    private XRSubreport xrsub_HOSO_QH_GIADINH;
    private XRSubreport xrsub_QT_DT;
    private sub_QTDaoTao sub_Quatrinh_Daotao1;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrl_TEN_HETHONG;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel115;
    private XRLabel xrtngayketxuat;
    private XRLabel xrLabel113;
    private XRLabel xrLabel112;
    private sub_Quanhe_Giadinh sub_Quanhe_Giadinh1;
    private PageHeaderBand PageHeader;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private sub_Quatrinh_Congtac sub_Quatrinh_Congtac1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    public string MaDonVi { get; set; }
    public rpt_NhanSu_Detail()
    {
        InitializeComponent(); 
        xrtngayketxuat.Text = " Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

    }
    public void BindData(DAL.HOSO hs)
    { 
        if (hs == null)
            return;
        sub_Quanhe_Giadinh1.BindData(hs.PR_KEY);
        sub_Quatrinh_Congtac1.DataSource = new HOSO_QT_CTACController().GetElementByFr_key(hs.PR_KEY);
        sub_Quatrinh_Daotao1.DataSource = new HOSO_QT_DAOTAOController().GetHOSODTFr_key(hs.PR_KEY);
        List<DAL.HOSO> ds = new List<DAL.HOSO>();
        ds.Add(hs);
        DataSource = ds;
        xrl_HO_TEN.Text += hs.HO_TEN;
        //  xrl_BAC_LUONG.Text += hs.BAC_LUONG;
        xrl_BI_DANH.Text += hs.BI_DANH;
        if (hs.DM_TINHTHANH != null)
            xrl_THEO_HS_GOC.Text += hs.DM_TINHTHANH.TEN_TINHTHANH;
        if (hs.DM_DANTOC != null)
            xrl_DAN_TOC.Text += hs.DM_DANTOC.TEN_DANTOC;
        if (hs.DM_NOICAP_CMND != null)
            xrl_NOICAP_CMND.Text += hs.DM_NOICAP_CMND.TEN_NOICAP_CMND;
        xrl_CAN_NANG.Text += hs.CAN_NANG + " kg";
        xrl_CHIEU_CAO.Text += hs.CHIEU_CAO + " m";
        xrl_DI_DONG.Text += hs.DI_DONG;
        xrl_DT_COQUAN.Text += hs.DT_CQUAN;
        xrl_DT_NHA.Text += hs.DT_NHA;
        xrl_Mail.Text += hs.EMAIL;
        xrl_HO_KHAU.Text += hs.HO_KHAU;
        //   xrl_HS_LUONG.Text += hs.HS_LUONG;
        if (hs.DM_HT_TUYENDUNG != null) 
        {
            if (hs.DM_HT_TUYENDUNG.MA_HT_TUYENDUNG == "TT")
                xrc_THITUYEN.Checked = true;
            else if (hs.DM_HT_TUYENDUNG.MA_HT_TUYENDUNG == "XT")
                xrc_XETTUYEN.Checked = true;
            else if (hs.DM_HT_TUYENDUNG.MA_HT_TUYENDUNG == "DC")
                xrc_DACCACH.Checked = true;
            else if (hs.DM_HT_TUYENDUNG.MA_HT_TUYENDUNG == "TUT")
                xrc_TUYENTHANG.Checked = true;
        }
        if (hs.DM_CONGVIEC != null)
            xrl_CONGVIEC.Text += hs.DM_CONGVIEC.TEN_CONGVIEC;
        xrl_NAM_TN.Text += hs.NAM_TN;

        if (hs.DM_CHUCVU != null)
            xrl_CHUCVU.Text += hs.DM_CHUCVU.TEN_CHUCVU;
        if (hs.DM_NGACH != null)
        {
            xrl_NGACH.Text += hs.DM_NGACH.TEN_NGACH;
            xrl_MA_NGACH.Text += hs.DM_NGACH.MA_NGACH;
        }
        //xrl_PHUCAP_CHUCVU.Text += hs.PHUCAP_CHUCVU;
        //xrl_PHUCAP_KHAC.Text += hs.PHUCAP_KHAC;
        //xrl_PHUCAP_TNVK.Text += hs.PHUCAP_TNVK;
        if (hs.NGAY_BN_CHUCVU.HasValue)
        {
            xrl_NGAY_BN_CV.Text += "Ngày" + hs.NGAY_BN_CHUCVU.Value.Day + " tháng " + hs.NGAY_BN_CHUCVU.Value.Month + " năm " + hs.NGAY_BN_CHUCVU.Value.Year;
        }
        if (hs.NGAY_BN_NGACH.HasValue)
        {
            xrl_NGAY_BNN.Text += "Ngày " + hs.NGAY_BN_NGACH.Value.Day + " tháng " + hs.NGAY_BN_NGACH.Value.Month + " năm " + hs.NGAY_BN_NGACH.Value.Year;
        }
        if (hs.NGAY_CTHUC_DANG.HasValue)
            xrl_NGAY_CT_VAO_DANG.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_CTHUC_DANG);
        //if (hs.NGAY_HLUONG.HasValue)
        //    xrl_NGAY_HUONG_LUONG.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_HLUONG);
        //if (hs.NGAY_HUONG_TNVK.HasValue)
        //    xrl_NGAY_HUONG_TNVK.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_HUONG_TNVK);
   
            if (hs.NGAY_SINH.HasValue)
            {
                xrl_NGAYSINH.Text += "Ngày " + hs.NGAY_SINH.Value.Day + " tháng " + hs.NGAY_SINH.Value.Month + " năm " + hs.NGAY_SINH.Value.Year;
            }
        if (hs.NGAY_TGCM.HasValue)
            xrl_NGAY_TGCM.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_TGCM);
        if (hs.NGAY_TUYEN_DTIEN.HasValue)
        {
            xrl_NGAY_TUYEN_DAUTIEN.Text = "Ngày " + hs.NGAY_TUYEN_DTIEN.Value.Day + " tháng " + hs.NGAY_TUYEN_DTIEN.Value.Month + " năm " + hs.NGAY_TUYEN_DTIEN.Value.Year;

        }
        if (hs.NGAY_TUYEN_CHINHTHUC.HasValue)
        {
            xrl_NGAY_TUYENDUNG_CT.Text += "Ngày " + hs.NGAY_TUYEN_CHINHTHUC.Value.Day + " tháng " + hs.NGAY_TUYEN_CHINHTHUC.Value.Month + " năm " + hs.NGAY_TUYEN_CHINHTHUC.Value.Year;
        }
        //if (hs.NGAY_VAO_CHINHTHUC.HasValue)
        //{
        //    xrl_NGAYVAO_CT.Text += hs.NGAY_VAO_CHINHTHUC.Value.Day;
        //    xrl_THANGVAO_CT.Text += hs.NGAY_VAO_CHINHTHUC.Value.Month;
        //    xrl_NAMVAO_CT.Text += hs.NGAY_VAO_CHINHTHUC.Value.Year;
        //}
        if (hs.NGAYVAO_DANG.HasValue)
            xrl_NGAY_VAO_DANG.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYVAO_DANG);
        if (hs.NGAYVAO_QDOI.HasValue)
            xrl_NGAY_VAO_DOAN.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYVAO_DOAN);
        if (hs.NGAYCAP_BHXH.HasValue)
        {
            xrl_NGAY_CAP_BH.Text += "Ngày " + hs.NGAYCAP_BHXH.Value.Day + " tháng " + hs.NGAYCAP_BHXH.Value.Month + " năm " + hs.NGAYCAP_BHXH.Value.Year;
        }
        if (hs.NGAYCAP_CMND.HasValue)
            xrl_NGAYCAP_CMND.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYCAP_CMND);
        // xrl_NGHE_TRUOC_TUYEN.Text += hs.NGHE_TRUOCTUYEN;
        if (hs.DM_NGOAINGU != null)
            xrl_NGOAI_NGU.Text += hs.DM_NGOAINGU.TEN_NGOAINGU;
        xrl_NHOM_MAU.Text += hs.NHOM_MAU;
        xrl_NOI_KN_DANG.Text += hs.NOI_KETNAP_DANG;
        xrl_NOI_KN_DOAN.Text += hs.NOI_KETNAP_DOAN;
        xrl_NOI_O_HIENNAY.Text += hs.HO_KHAU;
        xrl_NOI_SINH.Text += hs.NOI_SINH;
        if (hs.DM_NUOC != null)
            xrl_SO_CMND.Text += hs.SO_CMND;
        xrl_SO_THE_BHXH.Text += hs.SOTHE_BHXH;
        if (hs.DM_TD_CHINHTRI != null)
        {
            if (hs.DM_TD_CHINHTRI.MA_TD_CHINHTRI == "01")
                xrc_SOCAP_CTRI.Checked = true;
            else if (hs.DM_TD_CHINHTRI.MA_TD_CHINHTRI == "02")
                xrc_TRUNGCAP_CT.Checked = true;
            else if (hs.DM_TD_CHINHTRI.MA_TD_CHINHTRI == "03")
                xrc_CAOCAP_CTRI.Checked = true;
            else if (hs.DM_TD_CHINHTRI.MA_TD_CHINHTRI == "04")
                xrc_CUNHAN_CTRI.Checked = true;
        }

        if (hs.DM_TD_QLKT != null)
            xrl_TD_QLKT.Text += hs.DM_TD_QLKT.TEN_TD_QLKT;
        if (hs.DM_TD_QUANLY != null)
        {
            if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "01")
                xrc_QL_CANSU.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "02")
                xrc_QL_CONGVIEC.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "03")
                xrc_QL_CVC.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "04")
                xrc_QL_CVCC.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "05")
                xrc_QL_CUNHAN.Checked = true;
        }
        if (hs.DM_TINHOC != null)
            xrl_TINHOC.Text += hs.DM_TINHOC.TEN_TINHOC;

        if (hs.DM_TONGIAO != null)
            xrl_TON_GIAO.Text += hs.DM_TONGIAO.TEN_TONGIAO;
        if (hs.DM_TP_GIADINH != null)
            if (hs.DM_TT_SUCKHOE != null)
                xrl_TT_SUCKHOE.Text += hs.DM_TT_SUCKHOE.TEN_TT_SUCKHOE;
        if (hs.MA_GIOITINH == "M") { xrc_NAM.Checked = true; }
        else
            xrc_NU.Checked = true;
        xrPictureBox1.ImageUrl = hs.PHOTO;
        //xrPictureBox1.SizeF = new SizeF(160F, 120F);
       xrPictureBox1.Sizing=ImageSizeMode.StretchImage;
       	

      
        if (hs.DM_CHUCVU_DOAN != null)
            xrl_CHUCVU_DOAN.Text += hs.DM_CHUCVU_DOAN.TEN_CHUCVU_DOAN;
        if (hs.DM_CHUCVU_DANG != null)
            xrl_CHUCVU_DANG.Text += hs.DM_CHUCVU_DANG.TEN_CHUCVU_DANG;
        if (hs.DM_CHUCVU_QDOI != null)
            xrl_CHUCVU_QD.Text += hs.DM_CHUCVU_QDOI.TEN_CHUCVU_QDOI;
        if (hs.NGAYRA_QDOI != null)
            xrl_NGAY_RA_QD.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYRA_QDOI);
        if (hs.DM_TD_VANHOA != null)
            xrl_TD_VH.Text += hs.DM_TD_VANHOA.TEN_TD_VANHOA;
        if (hs.DM_LOAI_C != null)
            xrl_LOAI_CS.Text += hs.DM_LOAI_C.TEN_LOAI_CS;
        if (hs.DM_TRINHDO != null)
        {
            if (hs.DM_TRINHDO.MA_TRINHDO == "TC")
                xrc_TRUNGCAP.Checked = true;
            else if (hs.DM_TRINHDO.MA_TRINHDO == "CD")
                xrc_CAODANG.Checked = true;
            else if (hs.DM_TRINHDO.MA_TRINHDO == "DH")
                xrc_DAIHOC.Checked = true;
            else if (hs.DM_TRINHDO.MA_TRINHDO == "TH.S")
                xrc_THACSY.Checked = true;
            else if (hs.DM_TRINHDO.MA_TRINHDO == "TS")
                xrc_TIENSY.Checked = true;
        }
        if (hs.DM_CHUYENNGANH != null)
            xrl_CHUYEN_NGANH.Text += hs.DM_CHUYENNGANH.TEN_CHUYENNGANH;
        if (hs.DM_XEPLOAI != null)
            xrl_XEPLOAI.Text += hs.DM_XEPLOAI.TEN_XEPLOAI; 
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
        string resourceFileName = "rpt_NhanSu_ChiTiet.resx";
        System.Resources.ResourceManager resources = global::Resources.rpt_NhanSu_ChiTiet.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_Mail = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_PM_SK_CM = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_NC_CS = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_TT_KT = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_TUYENTRUYEN_VD = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_PT_TH = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_TC_TK_TH = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_LD_CHIHUY = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NAM_PHONGTANG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_DANHHIEU_NN_T = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NAM_PHONGCHUC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHUCDANH_KH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrCheckBox4 = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_QUOCPHONG = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_ANNINH = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_QL_CVCC = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_QL_CUNHAN = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_QL_CVC = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_QL_CANSU = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_QL_CONGVIEC = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_CUNHAN_CTRI = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_CAOCAP_CTRI = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_SOCAP_CTRI = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_TRUNGCAP_CT = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_TIENSY = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_DAIHOC = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_THACSY = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_TRUNGCAP = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_CAODANG = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrl_NGAY_CAP_BH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_HESO_PC_CD = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_BN_CV = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_NL = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_PHANTRAN_HUONG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_BNN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_MA_NGACH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAYVAO_CT = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_TUYENDUNG_CT = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_TUYEN_CT = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_HD_CO_TH_1 = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_HD_KXD_TH_1 = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_HD_DACBIET = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_HD_THUVIEC = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_HD_CO_TH = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_HD_KXD_TH = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_TRUOC_T7 = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_TAPSU = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_DUBI = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_TUYENTHANG = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_DACCACH = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_XETTUYEN = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_THITUYEN = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_TUYEN_DAUTIEN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_THEO_DV_HC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_THEO_HS_GOC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAYSINH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrc_NU = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrc_NAM = new DevExpress.XtraReports.UI.XRCheckBox();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TRINHDO = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NOI_SINH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_GIOI_TINH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NOICAP_CMND = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_SO_CMND = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_LOAI_CS = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAYCAP_CMND = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NANGLUC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_SO_THE_BHXH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAYCAP_BHXH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TD_QUANLY = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TD_CHINHTRI = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TD_QLKT = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_BAC_LUONG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_HUONG_LUONG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_HUONG_TNVK = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_PHUCAP_KHAC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_PHUCAP_CHUCVU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_PHUCAP_TNVK = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHUCVU_DANG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_HS_LUONG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NOI_KN_DANG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_CT_VAO_DANG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_VAO_DANG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHUCVU_DOAN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NOI_KN_DOAN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_VAO_DOAN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CAPBAC_QD = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHUCVU_QD = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_RA_QD = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_EMAIL = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_TGCM = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_BN_NGACH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGACH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_BN_CHUVU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHUCVU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CONGVIEC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_XEPLOAI = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NAM_TN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHUYEN_NGANH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TINHOC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGOAI_NGU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CAN_NANG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_CHIEU_CAO = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NHOM_MAU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TT_SUCKHOE = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TD_VH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_DT_COQUAN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_DT_NHA = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_DI_DONG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_HT_TUYEN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_VAO_CT = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TON_GIAO = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_TUYEN_CHINH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGHE_TRUOC_TUYEN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_TUYEN_DAU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_HO_KHAU = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_DAN_TOC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NOI_O_HIENNAY = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TEN_KHAC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_BI_DANH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_TINH_THANH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_HO_TEN = new DevExpress.XtraReports.UI.XRLabel();
        this.xrl_NGAY_SINH = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
        this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
        this.xrsub_QT_DT = new DevExpress.XtraReports.UI.XRSubreport();
        this.sub_Quatrinh_Daotao1 = new sub_QTDaoTao();
        this.xrsub_HOSO_QH_GIADINH = new DevExpress.XtraReports.UI.XRSubreport();
        this.sub_Quanhe_Giadinh1 = new sub_Quanhe_Giadinh();
        this.xrsub_QTCT = new DevExpress.XtraReports.UI.XRSubreport();
        this.sub_Quatrinh_Congtac1 = new sub_Quatrinh_Congtac();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrl_TEN_HETHONG = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel113 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel112 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        ((System.ComponentModel.ISupportInitialize)(this.sub_Quatrinh_Daotao1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.sub_Quanhe_Giadinh1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.sub_Quatrinh_Congtac1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel55,
            this.xrLabel54,
            this.xrLabel53,
            this.xrLabel52,
            this.xrLabel51,
            this.xrLabel50,
            this.xrLabel49,
            this.xrl_Mail,
            this.xrLabel48,
            this.xrLabel47,
            this.xrc_PM_SK_CM,
            this.xrc_NC_CS,
            this.xrc_TT_KT,
            this.xrc_TUYENTRUYEN_VD,
            this.xrc_PT_TH,
            this.xrc_TC_TK_TH,
            this.xrc_LD_CHIHUY,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLabel44,
            this.xrl_NAM_PHONGTANG,
            this.xrl_DANHHIEU_NN_T,
            this.xrLabel43,
            this.xrLabel42,
            this.xrLabel41,
            this.xrLabel40,
            this.xrl_NAM_PHONGCHUC,
            this.xrl_CHUCDANH_KH,
            this.xrCheckBox4,
            this.xrc_QUOCPHONG,
            this.xrc_ANNINH,
            this.xrLabel39,
            this.xrLabel38,
            this.xrLabel37,
            this.xrc_QL_CVCC,
            this.xrc_QL_CUNHAN,
            this.xrc_QL_CVC,
            this.xrc_QL_CANSU,
            this.xrc_QL_CONGVIEC,
            this.xrc_CUNHAN_CTRI,
            this.xrc_CAOCAP_CTRI,
            this.xrc_SOCAP_CTRI,
            this.xrc_TRUNGCAP_CT,
            this.xrLabel36,
            this.xrLabel35,
            this.xrLabel34,
            this.xrc_TIENSY,
            this.xrc_DAIHOC,
            this.xrc_THACSY,
            this.xrc_TRUNGCAP,
            this.xrc_CAODANG,
            this.xrl_NGAY_CAP_BH,
            this.xrl_HESO_PC_CD,
            this.xrl_NGAY_BN_CV,
            this.xrLabel33,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel28,
            this.xrl_NGAY_NL,
            this.xrLabel27,
            this.xrl_PHANTRAN_HUONG,
            this.xrLabel26,
            this.xrl_NGAY_BNN,
            this.xrl_MA_NGACH,
            this.xrLabel25,
            this.xrLabel24,
            this.xrl_NGAYVAO_CT,
            this.xrLabel23,
            this.xrl_NGAY_TUYENDUNG_CT,
            this.xrc_TUYEN_CT,
            this.xrc_HD_CO_TH_1,
            this.xrc_HD_KXD_TH_1,
            this.xrLabel22,
            this.xrc_HD_DACBIET,
            this.xrc_HD_THUVIEC,
            this.xrc_HD_CO_TH,
            this.xrc_HD_KXD_TH,
            this.xrc_TRUOC_T7,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrc_TAPSU,
            this.xrc_DUBI,
            this.xrLabel18,
            this.xrLabel17,
            this.xrc_TUYENTHANG,
            this.xrc_DACCACH,
            this.xrc_XETTUYEN,
            this.xrc_THITUYEN,
            this.xrLabel16,
            this.xrl_NGAY_TUYEN_DAUTIEN,
            this.xrLabel15,
            this.xrl_THEO_DV_HC,
            this.xrl_THEO_HS_GOC,
            this.xrl_NGAYSINH,
            this.xrc_NU,
            this.xrc_NAM,
            this.xrLabel14,
            this.xrLabel12,
            this.xrLabel9,
            this.xrLabel2,
            this.xrLabel1,
            this.xrl_TRINHDO,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel8,
            this.xrLabel7,
            this.xrl_NOI_SINH,
            this.xrl_GIOI_TINH,
            this.xrl_NOICAP_CMND,
            this.xrl_SO_CMND,
            this.xrl_LOAI_CS,
            this.xrl_NGAYCAP_CMND,
            this.xrl_NANGLUC,
            this.xrl_SO_THE_BHXH,
            this.xrl_NGAYCAP_BHXH,
            this.xrl_TD_QUANLY,
            this.xrl_TD_CHINHTRI,
            this.xrl_TD_QLKT,
            this.xrl_BAC_LUONG,
            this.xrl_NGAY_HUONG_LUONG,
            this.xrl_NGAY_HUONG_TNVK,
            this.xrl_PHUCAP_KHAC,
            this.xrl_PHUCAP_CHUCVU,
            this.xrl_PHUCAP_TNVK,
            this.xrl_CHUCVU_DANG,
            this.xrl_HS_LUONG,
            this.xrl_NOI_KN_DANG,
            this.xrl_NGAY_CT_VAO_DANG,
            this.xrl_NGAY_VAO_DANG,
            this.xrl_CHUCVU_DOAN,
            this.xrl_NOI_KN_DOAN,
            this.xrl_NGAY_VAO_DOAN,
            this.xrl_CAPBAC_QD,
            this.xrl_CHUCVU_QD,
            this.xrl_NGAY_RA_QD,
            this.xrl_EMAIL,
            this.xrl_NGAY_TGCM,
            this.xrl_NGAY_BN_NGACH,
            this.xrl_NGACH,
            this.xrl_NGAY_BN_CHUVU,
            this.xrl_CHUCVU,
            this.xrl_CONGVIEC,
            this.xrl_XEPLOAI,
            this.xrl_NAM_TN,
            this.xrl_CHUYEN_NGANH,
            this.xrl_TINHOC,
            this.xrl_NGOAI_NGU,
            this.xrl_CAN_NANG,
            this.xrl_CHIEU_CAO,
            this.xrl_NHOM_MAU,
            this.xrl_TT_SUCKHOE,
            this.xrl_TD_VH,
            this.xrl_DT_COQUAN,
            this.xrl_DT_NHA,
            this.xrl_DI_DONG,
            this.xrl_HT_TUYEN,
            this.xrl_NGAY_VAO_CT,
            this.xrl_TON_GIAO,
            this.xrl_NGAY_TUYEN_CHINH,
            this.xrl_NGHE_TRUOC_TUYEN,
            this.xrl_NGAY_TUYEN_DAU,
            this.xrl_HO_KHAU,
            this.xrLabel13,
            this.xrl_DAN_TOC,
            this.xrl_NOI_O_HIENNAY,
            this.xrl_TEN_KHAC,
            this.xrl_BI_DANH,
            this.xrl_TINH_THANH,
            this.xrl_HO_TEN,
            this.xrl_NGAY_SINH,
            this.xrLabel6,
            this.xrLabel56});
        this.Detail.HeightF = 2431.375F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel55
        // 
        this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(0.8354346F, 2296.834F);
        this.xrLabel55.Name = "xrLabel55";
        this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel55.SizeF = new System.Drawing.SizeF(772.0839F, 111.541F);
        this.xrLabel55.StylePriority.UseFont = false;
        this.xrLabel55.StylePriority.UseTextAlignment = false;
        this.xrLabel55.Text = resources.GetString("xrLabel55.Text");
        this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        // 
        // xrLabel54
        // 
        this.xrLabel54.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2248.834F);
        this.xrLabel54.Name = "xrLabel54";
        this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel54.SizeF = new System.Drawing.SizeF(772.0847F, 48F);
        this.xrLabel54.StylePriority.UseFont = false;
        this.xrLabel54.StylePriority.UseTextAlignment = false;
        this.xrLabel54.Text = "70. Có thân nhân (Cha, Mẹ, Vợ, Chồng, con, anh chị em ruột) ở nước ngoài (thời gi" +
            "an, làm gì, địa chỉ....)?";
        this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        // 
        // xrLabel53
        // 
        this.xrLabel53.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2137.292F);
        this.xrLabel53.Name = "xrLabel53";
        this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel53.SizeF = new System.Drawing.SizeF(772.3342F, 111.5417F);
        this.xrLabel53.StylePriority.UseFont = false;
        this.xrLabel53.StylePriority.UseTextAlignment = false;
        this.xrLabel53.Text = resources.GetString("xrLabel53.Text");
        this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        // 
        // xrLabel52
        // 
        this.xrLabel52.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(1.666021F, 2077.833F);
        this.xrLabel52.Name = "xrLabel52";
        this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel52.SizeF = new System.Drawing.SizeF(772.334F, 59.45825F);
        this.xrLabel52.StylePriority.UseFont = false;
        this.xrLabel52.StylePriority.UseTextAlignment = false;
        this.xrLabel52.Text = "69. Tham gia hoặc quan hệ với các tổ chức chính trị, kinh tế, xã hội nào ở nước n" +
            "goài (Thời gian, làm gì, tổ chức nào, đặt trụ sở ở đâu....?)";
        this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        // 
        // xrLabel51
        // 
        this.xrLabel51.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(2.501408F, 1980.875F);
        this.xrLabel51.Name = "xrLabel51";
        this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel51.SizeF = new System.Drawing.SizeF(771.084F, 96.95837F);
        this.xrLabel51.StylePriority.UseFont = false;
        this.xrLabel51.StylePriority.UseTextAlignment = false;
        this.xrLabel51.Text = resources.GetString("xrLabel51.Text");
        this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        // 
        // xrLabel50
        // 
        this.xrLabel50.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(1.833638F, 1908.917F);
        this.xrLabel50.Name = "xrLabel50";
        this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel50.SizeF = new System.Drawing.SizeF(771.0858F, 71.95837F);
        this.xrLabel50.StylePriority.UseFont = false;
        this.xrLabel50.StylePriority.UseTextAlignment = false;
        this.xrLabel50.Text = resources.GetString("xrLabel50.Text");
        this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        // 
        // xrLabel49
        // 
        this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1885.917F);
        this.xrLabel49.Name = "xrLabel49";
        this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel49.SizeF = new System.Drawing.SizeF(771.4978F, 23F);
        this.xrLabel49.StylePriority.UseFont = false;
        this.xrLabel49.Text = "ĐẶC ĐIỂM LỊCH SỬ BẢN THÂN";
        // 
        // xrl_Mail
        // 
        this.xrl_Mail.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_Mail.LocationFloat = new DevExpress.Utils.PointFloat(152.0833F, 390.9999F);
        this.xrl_Mail.Name = "xrl_Mail";
        this.xrl_Mail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_Mail.SizeF = new System.Drawing.SizeF(621.0837F, 23F);
        this.xrl_Mail.StylePriority.UseFont = false;
        this.xrl_Mail.StylePriority.UseTextAlignment = false;
        this.xrl_Mail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel48
        // 
        this.xrLabel48.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1862.917F);
        this.xrLabel48.Name = "xrLabel48";
        this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel48.SizeF = new System.Drawing.SizeF(771.2904F, 23F);
        this.xrLabel48.StylePriority.UseFont = false;
        this.xrLabel48.StylePriority.UseTextAlignment = false;
        this.xrLabel48.Text = "67. Kỷ luật cao nhất (về Đảng, chính quyền, đoàn thể, năm):       ";
        this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel47
        // 
        this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1839.917F);
        this.xrLabel47.Name = "xrLabel47";
        this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel47.SizeF = new System.Drawing.SizeF(771.2904F, 23F);
        this.xrLabel47.StylePriority.UseFont = false;
        this.xrLabel47.StylePriority.UseTextAlignment = false;
        this.xrLabel47.Text = "66. Khen thưởng cao nhất (hình thức, năm):          ";
        this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_PM_SK_CM
        // 
        this.xrc_PM_SK_CM.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_PM_SK_CM.LocationFloat = new DevExpress.Utils.PointFloat(8.958459F, 1816.917F);
        this.xrc_PM_SK_CM.Name = "xrc_PM_SK_CM";
        this.xrc_PM_SK_CM.SizeF = new System.Drawing.SizeF(762.124F, 23F);
        this.xrc_PM_SK_CM.StylePriority.UseFont = false;
        this.xrc_PM_SK_CM.Text = "Phát minh, sáng kiến chuyên môn";
        // 
        // xrc_NC_CS
        // 
        this.xrc_NC_CS.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_NC_CS.LocationFloat = new DevExpress.Utils.PointFloat(8.958459F, 1793.917F);
        this.xrc_NC_CS.Name = "xrc_NC_CS";
        this.xrc_NC_CS.SizeF = new System.Drawing.SizeF(230.4161F, 23F);
        this.xrc_NC_CS.StylePriority.UseFont = false;
        this.xrc_NC_CS.Text = "Nghiên cứu chính sách";
        // 
        // xrc_TT_KT
        // 
        this.xrc_TT_KT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TT_KT.LocationFloat = new DevExpress.Utils.PointFloat(239.3746F, 1793.917F);
        this.xrc_TT_KT.Name = "xrc_TT_KT";
        this.xrc_TT_KT.SizeF = new System.Drawing.SizeF(530.8735F, 23F);
        this.xrc_TT_KT.StylePriority.UseFont = false;
        this.xrc_TT_KT.Text = "Thanh tra, kiểm tra";
        // 
        // xrc_TUYENTRUYEN_VD
        // 
        this.xrc_TUYENTRUYEN_VD.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TUYENTRUYEN_VD.LocationFloat = new DevExpress.Utils.PointFloat(239.3746F, 1770.917F);
        this.xrc_TUYENTRUYEN_VD.Name = "xrc_TUYENTRUYEN_VD";
        this.xrc_TUYENTRUYEN_VD.SizeF = new System.Drawing.SizeF(531.7074F, 23F);
        this.xrc_TUYENTRUYEN_VD.StylePriority.UseFont = false;
        this.xrc_TUYENTRUYEN_VD.Text = "Tuyên truyền, vận động";
        // 
        // xrc_PT_TH
        // 
        this.xrc_PT_TH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_PT_TH.LocationFloat = new DevExpress.Utils.PointFloat(8.958459F, 1770.917F);
        this.xrc_PT_TH.Name = "xrc_PT_TH";
        this.xrc_PT_TH.SizeF = new System.Drawing.SizeF(230.4161F, 23F);
        this.xrc_PT_TH.StylePriority.UseFont = false;
        this.xrc_PT_TH.Text = "Phân tích, tổng hợp";
        // 
        // xrc_TC_TK_TH
        // 
        this.xrc_TC_TK_TH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TC_TK_TH.LocationFloat = new DevExpress.Utils.PointFloat(239.3746F, 1747.917F);
        this.xrc_TC_TK_TH.Name = "xrc_TC_TK_TH";
        this.xrc_TC_TK_TH.SizeF = new System.Drawing.SizeF(532.1249F, 22.99988F);
        this.xrc_TC_TK_TH.StylePriority.UseFont = false;
        this.xrc_TC_TK_TH.Text = "Tổ chức triển khai thực hiện";
        // 
        // xrc_LD_CHIHUY
        // 
        this.xrc_LD_CHIHUY.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_LD_CHIHUY.LocationFloat = new DevExpress.Utils.PointFloat(8.958459F, 1747.917F);
        this.xrc_LD_CHIHUY.Name = "xrc_LD_CHIHUY";
        this.xrc_LD_CHIHUY.SizeF = new System.Drawing.SizeF(230.4161F, 23F);
        this.xrc_LD_CHIHUY.StylePriority.UseFont = false;
        this.xrc_LD_CHIHUY.Text = "Lãnh đạo, chỉ huy";
        // 
        // xrLabel46
        // 
        this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1701.917F);
        this.xrLabel46.Name = "xrLabel46";
        this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel46.SizeF = new System.Drawing.SizeF(772.7504F, 23F);
        this.xrLabel46.StylePriority.UseFont = false;
        this.xrLabel46.StylePriority.UseTextAlignment = false;
        this.xrLabel46.Text = "(Con thương binh, con liệt sĩ, người nhiễm chất độc da cam Dioxin, gia đình có cô" +
            "ng với CM...)";
        this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel45
        // 
        this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1655.917F);
        this.xrLabel45.Name = "xrLabel45";
        this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel45.SizeF = new System.Drawing.SizeF(419.6258F, 22.99988F);
        this.xrLabel45.StylePriority.UseFont = false;
        this.xrLabel45.StylePriority.UseTextAlignment = false;
        this.xrLabel45.Text = "63. Bệnh binh :                ";
        this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel44
        // 
        this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(0.8334954F, 1655.917F);
        this.xrLabel44.Name = "xrLabel44";
        this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel44.SizeF = new System.Drawing.SizeF(352.708F, 23F);
        this.xrLabel44.StylePriority.UseFont = false;
        this.xrLabel44.StylePriority.UseTextAlignment = false;
        this.xrLabel44.Text = "62. Thương binh hạng:    ";
        this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NAM_PHONGTANG
        // 
        this.xrl_NAM_PHONGTANG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrl_NAM_PHONGTANG.LocationFloat = new DevExpress.Utils.PointFloat(353.5421F, 1586.917F);
        this.xrl_NAM_PHONGTANG.Name = "xrl_NAM_PHONGTANG";
        this.xrl_NAM_PHONGTANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NAM_PHONGTANG.SizeF = new System.Drawing.SizeF(419.8322F, 23.00012F);
        this.xrl_NAM_PHONGTANG.StylePriority.UseFont = false;
        this.xrl_NAM_PHONGTANG.StylePriority.UseTextAlignment = false;
        this.xrl_NAM_PHONGTANG.Text = "60. Năm phong tặng:   ";
        this.xrl_NAM_PHONGTANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_DANHHIEU_NN_T
        // 
        this.xrl_DANHHIEU_NN_T.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_DANHHIEU_NN_T.LocationFloat = new DevExpress.Utils.PointFloat(0.8334954F, 1586.917F);
        this.xrl_DANHHIEU_NN_T.Name = "xrl_DANHHIEU_NN_T";
        this.xrl_DANHHIEU_NN_T.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_DANHHIEU_NN_T.SizeF = new System.Drawing.SizeF(352.7086F, 23F);
        this.xrl_DANHHIEU_NN_T.StylePriority.UseFont = false;
        this.xrl_DANHHIEU_NN_T.StylePriority.UseTextAlignment = false;
        this.xrl_DANHHIEU_NN_T.Text = "59. Danh hiệu NN phong tặng :  ";
        this.xrl_DANHHIEU_NN_T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel43
        // 
        this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(353.5421F, 1563.917F);
        this.xrLabel43.Name = "xrLabel43";
        this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel43.SizeF = new System.Drawing.SizeF(174.3761F, 23F);
        this.xrLabel43.StylePriority.UseFont = false;
        this.xrLabel43.StylePriority.UseTextAlignment = false;
        this.xrLabel43.Text = "58. Chức vụ cao nhất: ";
        this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel42
        // 
        this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(353.5421F, 1517.916F);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.SizeF = new System.Drawing.SizeF(206.0409F, 23.00012F);
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.StylePriority.UseTextAlignment = false;
        this.xrLabel42.Text = "54. Chức vụ Đảng hiện nay: ";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel41
        // 
        this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1517.916F);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel41.SizeF = new System.Drawing.SizeF(135.209F, 23F);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.StylePriority.UseTextAlignment = false;
        this.xrLabel41.Text = "53. Nơi kết nạp:    ";
        this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel40
        // 
        this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1471.916F);
        this.xrLabel40.Name = "xrLabel40";
        this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel40.SizeF = new System.Drawing.SizeF(242.7087F, 22.99988F);
        this.xrLabel40.StylePriority.UseFont = false;
        this.xrLabel40.StylePriority.UseTextAlignment = false;
        this.xrLabel40.Text = "50. Chức vụ Đoàn hiện nay:  ";
        this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NAM_PHONGCHUC
        // 
        this.xrl_NAM_PHONGCHUC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NAM_PHONGCHUC.LocationFloat = new DevExpress.Utils.PointFloat(386.4577F, 1402.916F);
        this.xrl_NAM_PHONGCHUC.Name = "xrl_NAM_PHONGCHUC";
        this.xrl_NAM_PHONGCHUC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NAM_PHONGCHUC.SizeF = new System.Drawing.SizeF(386.2949F, 23F);
        this.xrl_NAM_PHONGCHUC.StylePriority.UseFont = false;
        this.xrl_NAM_PHONGCHUC.StylePriority.UseTextAlignment = false;
        this.xrl_NAM_PHONGCHUC.Text = "Năm phong chức danh:  ";
        this.xrl_NAM_PHONGCHUC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHUCDANH_KH
        // 
        this.xrl_CHUCDANH_KH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHUCDANH_KH.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1402.916F);
        this.xrl_CHUCDANH_KH.Name = "xrl_CHUCDANH_KH";
        this.xrl_CHUCDANH_KH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHUCDANH_KH.SizeF = new System.Drawing.SizeF(385.6252F, 23F);
        this.xrl_CHUCDANH_KH.StylePriority.UseFont = false;
        this.xrl_CHUCDANH_KH.StylePriority.UseTextAlignment = false;
        this.xrl_CHUCDANH_KH.Text = "47. Chức danh khoa học :      ";
        this.xrl_CHUCDANH_KH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrCheckBox4
        // 
        this.xrCheckBox4.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrCheckBox4.LocationFloat = new DevExpress.Utils.PointFloat(537.4994F, 1379.916F);
        this.xrCheckBox4.Name = "xrCheckBox4";
        this.xrCheckBox4.SizeF = new System.Drawing.SizeF(235.2532F, 23F);
        this.xrCheckBox4.StylePriority.UseFont = false;
        this.xrCheckBox4.Text = "An ninh, quốc phòng";
        // 
        // xrc_QUOCPHONG
        // 
        this.xrc_QUOCPHONG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_QUOCPHONG.LocationFloat = new DevExpress.Utils.PointFloat(402.9157F, 1379.916F);
        this.xrc_QUOCPHONG.Name = "xrc_QUOCPHONG";
        this.xrc_QUOCPHONG.SizeF = new System.Drawing.SizeF(133.1248F, 23F);
        this.xrc_QUOCPHONG.StylePriority.UseFont = false;
        this.xrc_QUOCPHONG.Text = "Quốc phòng";
        // 
        // xrc_ANNINH
        // 
        this.xrc_ANNINH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_ANNINH.LocationFloat = new DevExpress.Utils.PointFloat(297.4997F, 1379.916F);
        this.xrc_ANNINH.Name = "xrc_ANNINH";
        this.xrc_ANNINH.SizeF = new System.Drawing.SizeF(104.1667F, 23F);
        this.xrc_ANNINH.StylePriority.UseFont = false;
        this.xrc_ANNINH.Text = "An ninh";
        // 
        // xrLabel39
        // 
        this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1379.916F);
        this.xrLabel39.Name = "xrLabel39";
        this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel39.SizeF = new System.Drawing.SizeF(296.6672F, 23F);
        this.xrLabel39.StylePriority.UseFont = false;
        this.xrLabel39.StylePriority.UseTextAlignment = false;
        this.xrLabel39.Text = "46. Kiến thức an ninh, quốc phòng (v): ";
        this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel38
        // 
        this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(404.5846F, 1356.916F);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.SizeF = new System.Drawing.SizeF(367.3359F, 23F);
        this.xrLabel38.StylePriority.UseFont = false;
        this.xrLabel38.StylePriority.UseTextAlignment = false;
        this.xrLabel38.Text = "45. Tiếng dân tộc thiểu số:  ";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel37
        // 
        this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0.8354346F, 1310.917F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(251.4988F, 22.99988F);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.Text = "42. Trình độ quản lý kinh tế:   ";
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_QL_CVCC
        // 
        this.xrc_QL_CVCC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_QL_CVCC.LocationFloat = new DevExpress.Utils.PointFloat(537.4993F, 1287.917F);
        this.xrc_QL_CVCC.Name = "xrc_QL_CVCC";
        this.xrc_QL_CVCC.SizeF = new System.Drawing.SizeF(80.41675F, 23F);
        this.xrc_QL_CVCC.StylePriority.UseFont = false;
        this.xrc_QL_CVCC.Text = "CVCC";
        // 
        // xrc_QL_CUNHAN
        // 
        this.xrc_QL_CUNHAN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_QL_CUNHAN.LocationFloat = new DevExpress.Utils.PointFloat(617.916F, 1287.917F);
        this.xrc_QL_CUNHAN.Name = "xrc_QL_CUNHAN";
        this.xrc_QL_CUNHAN.SizeF = new System.Drawing.SizeF(155.6694F, 23F);
        this.xrc_QL_CUNHAN.StylePriority.UseFont = false;
        this.xrc_QL_CUNHAN.Text = "Cử nhân";
        // 
        // xrc_QL_CVC
        // 
        this.xrc_QL_CVC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_QL_CVC.LocationFloat = new DevExpress.Utils.PointFloat(472.4996F, 1287.917F);
        this.xrc_QL_CVC.Name = "xrc_QL_CVC";
        this.xrc_QL_CVC.SizeF = new System.Drawing.SizeF(63.54099F, 23F);
        this.xrc_QL_CVC.StylePriority.UseFont = false;
        this.xrc_QL_CVC.Text = "CVC";
        // 
        // xrc_QL_CANSU
        // 
        this.xrc_QL_CANSU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_QL_CANSU.LocationFloat = new DevExpress.Utils.PointFloat(297.4996F, 1287.917F);
        this.xrc_QL_CANSU.Name = "xrc_QL_CANSU";
        this.xrc_QL_CANSU.SizeF = new System.Drawing.SizeF(104.1668F, 23F);
        this.xrc_QL_CANSU.StylePriority.UseFont = false;
        this.xrc_QL_CANSU.Text = "Cán sự";
        // 
        // xrc_QL_CONGVIEC
        // 
        this.xrc_QL_CONGVIEC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_QL_CONGVIEC.LocationFloat = new DevExpress.Utils.PointFloat(402.9157F, 1287.917F);
        this.xrc_QL_CONGVIEC.Name = "xrc_QL_CONGVIEC";
        this.xrc_QL_CONGVIEC.SizeF = new System.Drawing.SizeF(69.58389F, 23F);
        this.xrc_QL_CONGVIEC.StylePriority.UseFont = false;
        this.xrc_QL_CONGVIEC.Text = "CV";
        // 
        // xrc_CUNHAN_CTRI
        // 
        this.xrc_CUNHAN_CTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_CUNHAN_CTRI.LocationFloat = new DevExpress.Utils.PointFloat(617.9161F, 1264.917F);
        this.xrc_CUNHAN_CTRI.Name = "xrc_CUNHAN_CTRI";
        this.xrc_CUNHAN_CTRI.SizeF = new System.Drawing.SizeF(156.0839F, 23F);
        this.xrc_CUNHAN_CTRI.StylePriority.UseFont = false;
        this.xrc_CUNHAN_CTRI.Text = "Cử nhân";
        // 
        // xrc_CAOCAP_CTRI
        // 
        this.xrc_CAOCAP_CTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_CAOCAP_CTRI.LocationFloat = new DevExpress.Utils.PointFloat(537.4993F, 1264.917F);
        this.xrc_CAOCAP_CTRI.Name = "xrc_CAOCAP_CTRI";
        this.xrc_CAOCAP_CTRI.SizeF = new System.Drawing.SizeF(80.41663F, 23F);
        this.xrc_CAOCAP_CTRI.StylePriority.UseFont = false;
        this.xrc_CAOCAP_CTRI.Text = "Cao cấp";
        // 
        // xrc_SOCAP_CTRI
        // 
        this.xrc_SOCAP_CTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_SOCAP_CTRI.LocationFloat = new DevExpress.Utils.PointFloat(297.4996F, 1264.917F);
        this.xrc_SOCAP_CTRI.Name = "xrc_SOCAP_CTRI";
        this.xrc_SOCAP_CTRI.SizeF = new System.Drawing.SizeF(104.1668F, 23F);
        this.xrc_SOCAP_CTRI.StylePriority.UseFont = false;
        this.xrc_SOCAP_CTRI.Text = "Sơ cấp";
        // 
        // xrc_TRUNGCAP_CT
        // 
        this.xrc_TRUNGCAP_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TRUNGCAP_CT.LocationFloat = new DevExpress.Utils.PointFloat(402.9157F, 1264.917F);
        this.xrc_TRUNGCAP_CT.Name = "xrc_TRUNGCAP_CT";
        this.xrc_TRUNGCAP_CT.SizeF = new System.Drawing.SizeF(134.5837F, 23F);
        this.xrc_TRUNGCAP_CT.StylePriority.UseFont = false;
        this.xrc_TRUNGCAP_CT.Text = "Trung cấp";
        // 
        // xrLabel36
        // 
        this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(300.0002F, 1241.917F);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(184.3732F, 23F);
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        this.xrLabel36.Text = "Kết quả tốt nghiệp loại:  ";
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel35
        // 
        this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(25.00024F, 1218.917F);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.SizeF = new System.Drawing.SizeF(60.83377F, 23F);
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.StylePriority.UseTextAlignment = false;
        this.xrLabel35.Text = "Ngành: ";
        this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel34
        // 
        this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(300.0002F, 1218.917F);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(120.2088F, 23F);
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UseTextAlignment = false;
        this.xrLabel34.Text = "Chuyên ngành: ";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_TIENSY
        // 
        this.xrc_TIENSY.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TIENSY.LocationFloat = new DevExpress.Utils.PointFloat(619.585F, 1195.917F);
        this.xrc_TIENSY.Name = "xrc_TIENSY";
        this.xrc_TIENSY.SizeF = new System.Drawing.SizeF(153.1693F, 23F);
        this.xrc_TIENSY.StylePriority.UseFont = false;
        this.xrc_TIENSY.Text = "Tiến sỹ";
        // 
        // xrc_DAIHOC
        // 
        this.xrc_DAIHOC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_DAIHOC.LocationFloat = new DevExpress.Utils.PointFloat(475.6272F, 1195.917F);
        this.xrc_DAIHOC.Name = "xrc_DAIHOC";
        this.xrc_DAIHOC.SizeF = new System.Drawing.SizeF(63.54099F, 23F);
        this.xrc_DAIHOC.StylePriority.UseFont = false;
        this.xrc_DAIHOC.Text = "ĐH";
        // 
        // xrc_THACSY
        // 
        this.xrc_THACSY.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_THACSY.LocationFloat = new DevExpress.Utils.PointFloat(539.1682F, 1195.917F);
        this.xrc_THACSY.Name = "xrc_THACSY";
        this.xrc_THACSY.SizeF = new System.Drawing.SizeF(80.41675F, 23F);
        this.xrc_THACSY.StylePriority.UseFont = false;
        this.xrc_THACSY.Text = "Thạc sỹ";
        // 
        // xrc_TRUNGCAP
        // 
        this.xrc_TRUNGCAP.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TRUNGCAP.LocationFloat = new DevExpress.Utils.PointFloat(297.4996F, 1195.917F);
        this.xrc_TRUNGCAP.Name = "xrc_TRUNGCAP";
        this.xrc_TRUNGCAP.SizeF = new System.Drawing.SizeF(105.0015F, 23F);
        this.xrc_TRUNGCAP.StylePriority.UseFont = false;
        this.xrc_TRUNGCAP.Text = "Trung cấp";
        // 
        // xrc_CAODANG
        // 
        this.xrc_CAODANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_CAODANG.LocationFloat = new DevExpress.Utils.PointFloat(402.9157F, 1195.917F);
        this.xrc_CAODANG.Name = "xrc_CAODANG";
        this.xrc_CAODANG.SizeF = new System.Drawing.SizeF(72.71155F, 23F);
        this.xrc_CAODANG.StylePriority.UseFont = false;
        this.xrc_CAODANG.Text = "CĐ";
        // 
        // xrl_NGAY_CAP_BH
        // 
        this.xrl_NGAY_CAP_BH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_CAP_BH.LocationFloat = new DevExpress.Utils.PointFloat(401.6664F, 1126.917F);
        this.xrl_NGAY_CAP_BH.Name = "xrl_NGAY_CAP_BH";
        this.xrl_NGAY_CAP_BH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_CAP_BH.SizeF = new System.Drawing.SizeF(368.5817F, 23F);
        this.xrl_NGAY_CAP_BH.StylePriority.UseFont = false;
        this.xrl_NGAY_CAP_BH.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_CAP_BH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_HESO_PC_CD
        // 
        this.xrl_HESO_PC_CD.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_HESO_PC_CD.LocationFloat = new DevExpress.Utils.PointFloat(421.0426F, 1081.125F);
        this.xrl_HESO_PC_CD.Name = "xrl_HESO_PC_CD";
        this.xrl_HESO_PC_CD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_HESO_PC_CD.SizeF = new System.Drawing.SizeF(350.4577F, 22.7915F);
        this.xrl_HESO_PC_CD.StylePriority.UseFont = false;
        this.xrl_HESO_PC_CD.StylePriority.UseTextAlignment = false;
        this.xrl_HESO_PC_CD.Text = "Hệ số phụ cấp chức vụ:   ";
        this.xrl_HESO_PC_CD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_BN_CV
        // 
        this.xrl_NGAY_BN_CV.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_BN_CV.LocationFloat = new DevExpress.Utils.PointFloat(153.7504F, 1081.125F);
        this.xrl_NGAY_BN_CV.Name = "xrl_NGAY_BN_CV";
        this.xrl_NGAY_BN_CV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_BN_CV.SizeF = new System.Drawing.SizeF(267.2922F, 23F);
        this.xrl_NGAY_BN_CV.StylePriority.UseFont = false;
        this.xrl_NGAY_BN_CV.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_BN_CV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel33
        // 
        this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(25.00024F, 1081.125F);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel33.SizeF = new System.Drawing.SizeF(128.7501F, 23F);
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.StylePriority.UseTextAlignment = false;
        this.xrLabel33.Text = "Ngày bổ nhiệm: ";
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(153.7504F, 1035.125F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(267.2922F, 23F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel29
        // 
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(383.3329F, 989.3331F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(176.2502F, 22.7915F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = "Ngày hưởng PCTNVK:    ";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel28
        // 
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(0F, 989.3331F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(262.0835F, 22.7915F);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.Text = "32. Phụ cấp thâm niên vượt khung %.:   ";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_NL
        // 
        this.xrl_NGAY_NL.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_NL.LocationFloat = new DevExpress.Utils.PointFloat(245.416F, 966.3329F);
        this.xrl_NGAY_NL.Name = "xrl_NGAY_NL";
        this.xrl_NGAY_NL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_NL.SizeF = new System.Drawing.SizeF(524.832F, 23F);
        this.xrl_NGAY_NL.StylePriority.UseFont = false;
        this.xrl_NGAY_NL.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_NL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(20.83338F, 966.5419F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(224.5826F, 22.7915F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "Mốc xét nâng lương lần sau: ";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_PHANTRAN_HUONG
        // 
        this.xrl_PHANTRAN_HUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_PHANTRAN_HUONG.LocationFloat = new DevExpress.Utils.PointFloat(499.5831F, 943.5417F);
        this.xrl_PHANTRAN_HUONG.Name = "xrl_PHANTRAN_HUONG";
        this.xrl_PHANTRAN_HUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_PHANTRAN_HUONG.SizeF = new System.Drawing.SizeF(273.1692F, 22.79144F);
        this.xrl_PHANTRAN_HUONG.StylePriority.UseFont = false;
        this.xrl_PHANTRAN_HUONG.StylePriority.UseTextAlignment = false;
        this.xrl_PHANTRAN_HUONG.Text = "......................";
        this.xrl_PHANTRAN_HUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(380.8331F, 943.5416F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(118.7499F, 22.7915F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "% hưởng: ";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_BNN
        // 
        this.xrl_NGAY_BNN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_BNN.LocationFloat = new DevExpress.Utils.PointFloat(250.4161F, 896.9999F);
        this.xrl_NGAY_BNN.Name = "xrl_NGAY_BNN";
        this.xrl_NGAY_BNN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_BNN.SizeF = new System.Drawing.SizeF(520.6659F, 23F);
        this.xrl_NGAY_BNN.StylePriority.UseFont = false;
        this.xrl_NGAY_BNN.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_BNN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_MA_NGACH
        // 
        this.xrl_MA_NGACH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_MA_NGACH.LocationFloat = new DevExpress.Utils.PointFloat(383.3329F, 873.9995F);
        this.xrl_MA_NGACH.Name = "xrl_MA_NGACH";
        this.xrl_MA_NGACH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_MA_NGACH.SizeF = new System.Drawing.SizeF(388.1679F, 23F);
        this.xrl_MA_NGACH.StylePriority.UseFont = false;
        this.xrl_MA_NGACH.StylePriority.UseTextAlignment = false;
        this.xrl_MA_NGACH.Text = "30. Mã ngạch:  ";
        this.xrl_MA_NGACH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0.8334954F, 827.9996F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(361.25F, 23F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "28. Lĩnh vực theo dõi (đối với cán bộ,CC lãnh đạo): ";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0.8334954F, 804.9996F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(771.5007F, 23F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "27. Công việc chuyên môn hiện nay: ";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAYVAO_CT
        // 
        this.xrl_NGAYVAO_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAYVAO_CT.LocationFloat = new DevExpress.Utils.PointFloat(224.5834F, 781.9996F);
        this.xrl_NGAYVAO_CT.Name = "xrl_NGAYVAO_CT";
        this.xrl_NGAYVAO_CT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAYVAO_CT.SizeF = new System.Drawing.SizeF(545.6646F, 23F);
        this.xrl_NGAYVAO_CT.StylePriority.UseFont = false;
        this.xrl_NGAYVAO_CT.StylePriority.UseTextAlignment = false;
        this.xrl_NGAYVAO_CT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0.8334954F, 758.9996F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(249.5826F, 23F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "25. Cơ quan tuyển dụng chính thức:     ";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_TUYENDUNG_CT
        // 
        this.xrl_NGAY_TUYENDUNG_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_TUYENDUNG_CT.LocationFloat = new DevExpress.Utils.PointFloat(224.5834F, 735.9996F);
        this.xrl_NGAY_TUYENDUNG_CT.Name = "xrl_NGAY_TUYENDUNG_CT";
        this.xrl_NGAY_TUYENDUNG_CT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_TUYENDUNG_CT.SizeF = new System.Drawing.SizeF(549.4166F, 23F);
        this.xrl_NGAY_TUYENDUNG_CT.StylePriority.UseFont = false;
        this.xrl_NGAY_TUYENDUNG_CT.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_TUYENDUNG_CT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_TUYEN_CT
        // 
        this.xrc_TUYEN_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TUYEN_CT.LocationFloat = new DevExpress.Utils.PointFloat(489.3736F, 689.9995F);
        this.xrc_TUYEN_CT.Name = "xrc_TUYEN_CT";
        this.xrc_TUYEN_CT.SizeF = new System.Drawing.SizeF(283.7925F, 23F);
        this.xrc_TUYEN_CT.StylePriority.UseFont = false;
        this.xrc_TUYEN_CT.Text = "Tuyển dụng chính thức";
        // 
        // xrc_HD_CO_TH_1
        // 
        this.xrc_HD_CO_TH_1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_HD_CO_TH_1.LocationFloat = new DevExpress.Utils.PointFloat(489.3745F, 712.9996F);
        this.xrc_HD_CO_TH_1.Name = "xrc_HD_CO_TH_1";
        this.xrc_HD_CO_TH_1.SizeF = new System.Drawing.SizeF(283.7928F, 23F);
        this.xrc_HD_CO_TH_1.StylePriority.UseFont = false;
        this.xrc_HD_CO_TH_1.Text = "Hợp đồng có thời hạn";
        // 
        // xrc_HD_KXD_TH_1
        // 
        this.xrc_HD_KXD_TH_1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_HD_KXD_TH_1.LocationFloat = new DevExpress.Utils.PointFloat(189.5834F, 712.9996F);
        this.xrc_HD_KXD_TH_1.Name = "xrc_HD_KXD_TH_1";
        this.xrc_HD_KXD_TH_1.SizeF = new System.Drawing.SizeF(297.7081F, 23F);
        this.xrc_HD_KXD_TH_1.StylePriority.UseFont = false;
        this.xrc_HD_KXD_TH_1.Text = "Hợp đồng không xác định thời hạn";
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(189.5834F, 689.9996F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(297.7081F, 23F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "23.3 Nhân viên thừa hành phục vụ: (v)    ";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_HD_DACBIET
        // 
        this.xrc_HD_DACBIET.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_HD_DACBIET.LocationFloat = new DevExpress.Utils.PointFloat(489.3745F, 666.9997F);
        this.xrc_HD_DACBIET.Name = "xrc_HD_DACBIET";
        this.xrc_HD_DACBIET.SizeF = new System.Drawing.SizeF(283.7925F, 23F);
        this.xrc_HD_DACBIET.StylePriority.UseFont = false;
        this.xrc_HD_DACBIET.Text = "Hợp đồng đặc biệt";
        // 
        // xrc_HD_THUVIEC
        // 
        this.xrc_HD_THUVIEC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_HD_THUVIEC.LocationFloat = new DevExpress.Utils.PointFloat(189.5833F, 666.9997F);
        this.xrc_HD_THUVIEC.Name = "xrc_HD_THUVIEC";
        this.xrc_HD_THUVIEC.SizeF = new System.Drawing.SizeF(297.7081F, 23F);
        this.xrc_HD_THUVIEC.StylePriority.UseFont = false;
        this.xrc_HD_THUVIEC.Text = "Hợp đồng thử việc";
        // 
        // xrc_HD_CO_TH
        // 
        this.xrc_HD_CO_TH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_HD_CO_TH.LocationFloat = new DevExpress.Utils.PointFloat(489.3745F, 643.9995F);
        this.xrc_HD_CO_TH.Name = "xrc_HD_CO_TH";
        this.xrc_HD_CO_TH.SizeF = new System.Drawing.SizeF(283.7916F, 23F);
        this.xrc_HD_CO_TH.StylePriority.UseFont = false;
        this.xrc_HD_CO_TH.Text = "Hợp đồng có thời hạn";
        // 
        // xrc_HD_KXD_TH
        // 
        this.xrc_HD_KXD_TH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_HD_KXD_TH.LocationFloat = new DevExpress.Utils.PointFloat(189.5833F, 643.9996F);
        this.xrc_HD_KXD_TH.Name = "xrc_HD_KXD_TH";
        this.xrc_HD_KXD_TH.SizeF = new System.Drawing.SizeF(297.7081F, 23F);
        this.xrc_HD_KXD_TH.StylePriority.UseFont = false;
        this.xrc_HD_KXD_TH.Text = "Hợp đồng không xác định thời hạn";
        // 
        // xrc_TRUOC_T7
        // 
        this.xrc_TRUOC_T7.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TRUOC_T7.LocationFloat = new DevExpress.Utils.PointFloat(606.0407F, 597.9996F);
        this.xrc_TRUOC_T7.Name = "xrc_TRUOC_T7";
        this.xrc_TRUOC_T7.SizeF = new System.Drawing.SizeF(165.4586F, 23F);
        this.xrc_TRUOC_T7.StylePriority.UseFont = false;
        // 
        // xrLabel21
        // 
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(187.9166F, 620.9996F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(583.5825F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "b. Viên chức tuyển dụng chính thức từ tháng 7/2003 đến nay:";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(187.9166F, 597.9996F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(418.1241F, 23F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "a. Viên chức tuyển dụng chính thức trước tháng 7/2003:  ";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel19
        // 
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(187.9166F, 574.9995F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(585.4578F, 23F);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "23.2 Viên chức: (v)    ";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_TAPSU
        // 
        this.xrc_TAPSU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TAPSU.LocationFloat = new DevExpress.Utils.PointFloat(606.0407F, 551.9996F);
        this.xrc_TAPSU.Name = "xrc_TAPSU";
        this.xrc_TAPSU.SizeF = new System.Drawing.SizeF(165.4584F, 23F);
        this.xrc_TAPSU.StylePriority.UseFont = false;
        this.xrc_TAPSU.StylePriority.UseTextAlignment = false;
        this.xrc_TAPSU.Text = "Tập sự";
        // 
        // xrc_DUBI
        // 
        this.xrc_DUBI.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_DUBI.LocationFloat = new DevExpress.Utils.PointFloat(489.3745F, 551.9996F);
        this.xrc_DUBI.Name = "xrc_DUBI";
        this.xrc_DUBI.SizeF = new System.Drawing.SizeF(116.6662F, 23F);
        this.xrc_DUBI.StylePriority.UseFont = false;
        this.xrc_DUBI.Text = "Dự bị";
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(187.9166F, 551.9996F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(301.4579F, 23F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "23.1 Công chức : Tuyển dụng chính thức :    ";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel17
        // 
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 551.9996F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(187.9166F, 23F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "23. Vị trí tuyển dụng: (v)    ";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_TUYENTHANG
        // 
        this.xrc_TUYENTHANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_TUYENTHANG.LocationFloat = new DevExpress.Utils.PointFloat(606.0408F, 505.9998F);
        this.xrc_TUYENTHANG.Name = "xrc_TUYENTHANG";
        this.xrc_TUYENTHANG.SizeF = new System.Drawing.SizeF(166.2923F, 23F);
        this.xrc_TUYENTHANG.StylePriority.UseFont = false;
        this.xrc_TUYENTHANG.StylePriority.UseTextAlignment = false;
        this.xrc_TUYENTHANG.Text = "Tuyển thẳng";
        // 
        // xrc_DACCACH
        // 
        this.xrc_DACCACH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_DACCACH.LocationFloat = new DevExpress.Utils.PointFloat(489.3745F, 505.9997F);
        this.xrc_DACCACH.Name = "xrc_DACCACH";
        this.xrc_DACCACH.SizeF = new System.Drawing.SizeF(116.6663F, 23F);
        this.xrc_DACCACH.StylePriority.UseFont = false;
        this.xrc_DACCACH.Text = "Đặc cách";
        // 
        // xrc_XETTUYEN
        // 
        this.xrc_XETTUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_XETTUYEN.LocationFloat = new DevExpress.Utils.PointFloat(377.9169F, 505.9998F);
        this.xrc_XETTUYEN.Name = "xrc_XETTUYEN";
        this.xrc_XETTUYEN.SizeF = new System.Drawing.SizeF(111.4576F, 22.99994F);
        this.xrc_XETTUYEN.StylePriority.UseFont = false;
        this.xrc_XETTUYEN.Text = "Xét tuyển";
        // 
        // xrc_THITUYEN
        // 
        this.xrc_THITUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_THITUYEN.LocationFloat = new DevExpress.Utils.PointFloat(246.249F, 505.9998F);
        this.xrc_THITUYEN.Name = "xrc_THITUYEN";
        this.xrc_THITUYEN.SizeF = new System.Drawing.SizeF(131.2509F, 23F);
        this.xrc_THITUYEN.StylePriority.UseFont = false;
        this.xrc_THITUYEN.Text = "Thi tuyển";
        // 
        // xrLabel16
        // 
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 482.9998F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(318.5825F, 22.99997F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "20. Cơ quan tuyển dụng đầu tiên:     ";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_TUYEN_DAUTIEN
        // 
        this.xrl_NGAY_TUYEN_DAUTIEN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_TUYEN_DAUTIEN.LocationFloat = new DevExpress.Utils.PointFloat(173.3333F, 459.9998F);
        this.xrl_NGAY_TUYEN_DAUTIEN.Name = "xrl_NGAY_TUYEN_DAUTIEN";
        this.xrl_NGAY_TUYEN_DAUTIEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_TUYEN_DAUTIEN.SizeF = new System.Drawing.SizeF(596.9147F, 23.00003F);
        this.xrl_NGAY_TUYEN_DAUTIEN.StylePriority.UseFont = false;
        this.xrl_NGAY_TUYEN_DAUTIEN.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_TUYEN_DAUTIEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel15
        // 
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 367.9999F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(152.0832F, 23F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "16. Điện thoại:  ";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_THEO_DV_HC
        // 
        this.xrl_THEO_DV_HC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_THEO_DV_HC.LocationFloat = new DevExpress.Utils.PointFloat(152.0833F, 298.9999F);
        this.xrl_THEO_DV_HC.Name = "xrl_THEO_DV_HC";
        this.xrl_THEO_DV_HC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_THEO_DV_HC.SizeF = new System.Drawing.SizeF(619.4161F, 23F);
        this.xrl_THEO_DV_HC.StylePriority.UseFont = false;
        this.xrl_THEO_DV_HC.StylePriority.UseTextAlignment = false;
        this.xrl_THEO_DV_HC.Text = "- Theo đơn vị hành chính hiện nay:          ";
        this.xrl_THEO_DV_HC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_THEO_HS_GOC
        // 
        this.xrl_THEO_HS_GOC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_THEO_HS_GOC.LocationFloat = new DevExpress.Utils.PointFloat(152.0832F, 276F);
        this.xrl_THEO_HS_GOC.Name = "xrl_THEO_HS_GOC";
        this.xrl_THEO_HS_GOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_THEO_HS_GOC.SizeF = new System.Drawing.SizeF(619.4161F, 23F);
        this.xrl_THEO_HS_GOC.StylePriority.UseFont = false;
        this.xrl_THEO_HS_GOC.StylePriority.UseTextAlignment = false;
        this.xrl_THEO_HS_GOC.Text = "- Theo hồ sơ gốc:     ";
        this.xrl_THEO_HS_GOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAYSINH
        // 
        this.xrl_NGAYSINH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAYSINH.LocationFloat = new DevExpress.Utils.PointFloat(100.8333F, 207F);
        this.xrl_NGAYSINH.Name = "xrl_NGAYSINH";
        this.xrl_NGAYSINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAYSINH.SizeF = new System.Drawing.SizeF(671.0842F, 23F);
        this.xrl_NGAYSINH.StylePriority.UseFont = false;
        this.xrl_NGAYSINH.StylePriority.UseTextAlignment = false;
        this.xrl_NGAYSINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrc_NU
        // 
        this.xrc_NU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_NU.LocationFloat = new DevExpress.Utils.PointFloat(699.9998F, 161F);
        this.xrc_NU.Name = "xrc_NU";
        this.xrc_NU.SizeF = new System.Drawing.SizeF(72.33289F, 23F);
        this.xrc_NU.StylePriority.UseFont = false;
        this.xrc_NU.StylePriority.UseTextAlignment = false;
        this.xrc_NU.Text = "Nữ";
        this.xrc_NU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrc_NAM
        // 
        this.xrc_NAM.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrc_NAM.LocationFloat = new DevExpress.Utils.PointFloat(606.0407F, 161F);
        this.xrc_NAM.Name = "xrc_NAM";
        this.xrc_NAM.SizeF = new System.Drawing.SizeF(71.25F, 23F);
        this.xrc_NAM.StylePriority.UseFont = false;
        this.xrc_NAM.StylePriority.UseTextAlignment = false;
        this.xrc_NAM.Text = "Nam";
        this.xrc_NAM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 115F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(771.5003F, 22.99999F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "4.  Số hiệu công chức, viên chức:         ";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 92.00001F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(772.3328F, 23F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Mã số hồ sơ: ";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 68.99999F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(772.3328F, 23F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Phòng, ban đang công tác:";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.99997F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(772.3328F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "2.  Cơ quan, đơn vị Cơ quan, đơn vị sử dụng CBCCVC:  ";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(772.3327F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "1.  Cơ quan, đơn vị có thẩm quyền quản lý CBCCVC:  ";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TRINHDO
        // 
        this.xrl_TRINHDO.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TRINHDO.LocationFloat = new DevExpress.Utils.PointFloat(0.8354346F, 1195.917F);
        this.xrl_TRINHDO.Name = "xrl_TRINHDO";
        this.xrl_TRINHDO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TRINHDO.SizeF = new System.Drawing.SizeF(296.6642F, 23F);
        this.xrl_TRINHDO.StylePriority.UseFont = false;
        this.xrl_TRINHDO.StylePriority.UseTextAlignment = false;
        this.xrl_TRINHDO.Text = "38. Trình độ chuyên môn cao nhất (v):  ";
        this.xrl_TRINHDO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(2.501297F, 1425.916F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(769.4161F, 23F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.Text = "V. THÔNG TIN KHÁC";
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(2.501297F, 1149.917F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(769.4161F, 23F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.Text = "IV. ĐÀO TẠO, BỒI DƯỠNG";
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 850.9996F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(772.3338F, 23F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.Text = "III. LƯƠNG, PHỤ CẤP HIỆN HƯỞNG";
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 436.9999F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(772.3326F, 23F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.Text = "III. CÔNG TÁC";
        // 
        // xrl_NOI_SINH
        // 
        this.xrl_NOI_SINH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NOI_SINH.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 230F);
        this.xrl_NOI_SINH.Name = "xrl_NOI_SINH";
        this.xrl_NOI_SINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NOI_SINH.SizeF = new System.Drawing.SizeF(772.3342F, 23.00002F);
        this.xrl_NOI_SINH.StylePriority.UseFont = false;
        this.xrl_NOI_SINH.StylePriority.UseTextAlignment = false;
        this.xrl_NOI_SINH.Text = "10. Nơi sinh:                    ";
        this.xrl_NOI_SINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_GIOI_TINH
        // 
        this.xrl_GIOI_TINH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_GIOI_TINH.LocationFloat = new DevExpress.Utils.PointFloat(447.7085F, 161F);
        this.xrl_GIOI_TINH.Name = "xrl_GIOI_TINH";
        this.xrl_GIOI_TINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_GIOI_TINH.SizeF = new System.Drawing.SizeF(158.3322F, 23.00002F);
        this.xrl_GIOI_TINH.StylePriority.UseFont = false;
        this.xrl_GIOI_TINH.StylePriority.UseTextAlignment = false;
        this.xrl_GIOI_TINH.Text = "6. Giới tính: (v)";
        this.xrl_GIOI_TINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NOICAP_CMND
        // 
        this.xrl_NOICAP_CMND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_NOICAP_CMND.LocationFloat = new DevExpress.Utils.PointFloat(262.0835F, 413.9999F);
        this.xrl_NOICAP_CMND.Name = "xrl_NOICAP_CMND";
        this.xrl_NOICAP_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NOICAP_CMND.SizeF = new System.Drawing.SizeF(212.7084F, 23.00003F);
        this.xrl_NOICAP_CMND.StylePriority.UseFont = false;
        this.xrl_NOICAP_CMND.StylePriority.UseTextAlignment = false;
        this.xrl_NOICAP_CMND.Text = "Nơi cấp:  ";
        this.xrl_NOICAP_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_SO_CMND
        // 
        this.xrl_SO_CMND.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_SO_CMND.LocationFloat = new DevExpress.Utils.PointFloat(0F, 413.9998F);
        this.xrl_SO_CMND.Name = "xrl_SO_CMND";
        this.xrl_SO_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_SO_CMND.SizeF = new System.Drawing.SizeF(262.0835F, 23.00003F);
        this.xrl_SO_CMND.StylePriority.UseFont = false;
        this.xrl_SO_CMND.StylePriority.UseTextAlignment = false;
        this.xrl_SO_CMND.Text = "18. Số CMTND:         ";
        this.xrl_SO_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_LOAI_CS
        // 
        this.xrl_LOAI_CS.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_LOAI_CS.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1678.917F);
        this.xrl_LOAI_CS.Name = "xrl_LOAI_CS";
        this.xrl_LOAI_CS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_LOAI_CS.SizeF = new System.Drawing.SizeF(772.7504F, 23F);
        this.xrl_LOAI_CS.StylePriority.UseFont = false;
        this.xrl_LOAI_CS.StylePriority.UseTextAlignment = false;
        this.xrl_LOAI_CS.Text = "64. Đối tượng được hưởng chính sách :     ";
        this.xrl_LOAI_CS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAYCAP_CMND
        // 
        this.xrl_NGAYCAP_CMND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_NGAYCAP_CMND.LocationFloat = new DevExpress.Utils.PointFloat(474.7919F, 413.9999F);
        this.xrl_NGAYCAP_CMND.Name = "xrl_NGAYCAP_CMND";
        this.xrl_NGAYCAP_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAYCAP_CMND.SizeF = new System.Drawing.SizeF(299.2081F, 23F);
        this.xrl_NGAYCAP_CMND.StylePriority.UseFont = false;
        this.xrl_NGAYCAP_CMND.StylePriority.UseTextAlignment = false;
        this.xrl_NGAYCAP_CMND.Text = "Ngày cấp:  ";
        this.xrl_NGAYCAP_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NANGLUC
        // 
        this.xrl_NANGLUC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NANGLUC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1724.917F);
        this.xrl_NANGLUC.Name = "xrl_NANGLUC";
        this.xrl_NANGLUC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NANGLUC.SizeF = new System.Drawing.SizeF(771.2936F, 23.00012F);
        this.xrl_NANGLUC.StylePriority.UseFont = false;
        this.xrl_NANGLUC.StylePriority.UseTextAlignment = false;
        this.xrl_NANGLUC.Text = "65. Năng lực sở trường (v):   ";
        this.xrl_NANGLUC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_SO_THE_BHXH
        // 
        this.xrl_SO_THE_BHXH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_SO_THE_BHXH.LocationFloat = new DevExpress.Utils.PointFloat(1.667086F, 1126.917F);
        this.xrl_SO_THE_BHXH.Name = "xrl_SO_THE_BHXH";
        this.xrl_SO_THE_BHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_SO_THE_BHXH.SizeF = new System.Drawing.SizeF(318.3333F, 23F);
        this.xrl_SO_THE_BHXH.StylePriority.UseFont = false;
        this.xrl_SO_THE_BHXH.StylePriority.UseTextAlignment = false;
        this.xrl_SO_THE_BHXH.Text = "36. Số sổ bảo hiểm xã hội:     ";
        this.xrl_SO_THE_BHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAYCAP_BHXH
        // 
        this.xrl_NGAYCAP_BHXH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrl_NGAYCAP_BHXH.LocationFloat = new DevExpress.Utils.PointFloat(322.5005F, 1126.917F);
        this.xrl_NGAYCAP_BHXH.Name = "xrl_NGAYCAP_BHXH";
        this.xrl_NGAYCAP_BHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAYCAP_BHXH.SizeF = new System.Drawing.SizeF(79.16589F, 23F);
        this.xrl_NGAYCAP_BHXH.StylePriority.UseFont = false;
        this.xrl_NGAYCAP_BHXH.StylePriority.UseTextAlignment = false;
        this.xrl_NGAYCAP_BHXH.Text = "Ngày cấp:";
        this.xrl_NGAYCAP_BHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TD_QUANLY
        // 
        this.xrl_TD_QUANLY.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TD_QUANLY.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1287.917F);
        this.xrl_TD_QUANLY.Name = "xrl_TD_QUANLY";
        this.xrl_TD_QUANLY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TD_QUANLY.SizeF = new System.Drawing.SizeF(297.4996F, 23F);
        this.xrl_TD_QUANLY.StylePriority.UseFont = false;
        this.xrl_TD_QUANLY.StylePriority.UseTextAlignment = false;
        this.xrl_TD_QUANLY.Text = "41. Trình độ quản lý HCNN (v) :        ";
        this.xrl_TD_QUANLY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TD_CHINHTRI
        // 
        this.xrl_TD_CHINHTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TD_CHINHTRI.LocationFloat = new DevExpress.Utils.PointFloat(0.8335908F, 1264.917F);
        this.xrl_TD_CHINHTRI.Name = "xrl_TD_CHINHTRI";
        this.xrl_TD_CHINHTRI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TD_CHINHTRI.SizeF = new System.Drawing.SizeF(296.666F, 23F);
        this.xrl_TD_CHINHTRI.StylePriority.UseFont = false;
        this.xrl_TD_CHINHTRI.StylePriority.UseTextAlignment = false;
        this.xrl_TD_CHINHTRI.Text = "40. Trình độ lý luận chính trị (v):         ";
        this.xrl_TD_CHINHTRI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TD_QLKT
        // 
        this.xrl_TD_QLKT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TD_QLKT.LocationFloat = new DevExpress.Utils.PointFloat(250.4161F, 1310.917F);
        this.xrl_TD_QLKT.Name = "xrl_TD_QLKT";
        this.xrl_TD_QLKT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TD_QLKT.SizeF = new System.Drawing.SizeF(519.8319F, 22.99988F);
        this.xrl_TD_QLKT.StylePriority.UseFont = false;
        this.xrl_TD_QLKT.StylePriority.UseTextAlignment = false;
        this.xrl_TD_QLKT.Text = "..";
        this.xrl_TD_QLKT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_BAC_LUONG
        // 
        this.xrl_BAC_LUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_BAC_LUONG.LocationFloat = new DevExpress.Utils.PointFloat(0F, 919.9996F);
        this.xrl_BAC_LUONG.Name = "xrl_BAC_LUONG";
        this.xrl_BAC_LUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_BAC_LUONG.SizeF = new System.Drawing.SizeF(380.8331F, 22.7915F);
        this.xrl_BAC_LUONG.StylePriority.UseFont = false;
        this.xrl_BAC_LUONG.StylePriority.UseTextAlignment = false;
        this.xrl_BAC_LUONG.Text = "31. Bậc lương hiện hưởng:         ";
        this.xrl_BAC_LUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_HUONG_LUONG
        // 
        this.xrl_NGAY_HUONG_LUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_HUONG_LUONG.LocationFloat = new DevExpress.Utils.PointFloat(22.50021F, 943.5416F);
        this.xrl_NGAY_HUONG_LUONG.Name = "xrl_NGAY_HUONG_LUONG";
        this.xrl_NGAY_HUONG_LUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_HUONG_LUONG.SizeF = new System.Drawing.SizeF(358.3329F, 22.7915F);
        this.xrl_NGAY_HUONG_LUONG.StylePriority.UseFont = false;
        this.xrl_NGAY_HUONG_LUONG.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_HUONG_LUONG.Text = "Ngày hưởng                                ";
        this.xrl_NGAY_HUONG_LUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_HUONG_TNVK
        // 
        this.xrl_NGAY_HUONG_TNVK.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_HUONG_TNVK.LocationFloat = new DevExpress.Utils.PointFloat(559.5832F, 989.3331F);
        this.xrl_NGAY_HUONG_TNVK.Name = "xrl_NGAY_HUONG_TNVK";
        this.xrl_NGAY_HUONG_TNVK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_HUONG_TNVK.SizeF = new System.Drawing.SizeF(211.9176F, 22.7915F);
        this.xrl_NGAY_HUONG_TNVK.StylePriority.UseFont = false;
        this.xrl_NGAY_HUONG_TNVK.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_HUONG_TNVK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_PHUCAP_KHAC
        // 
        this.xrl_PHUCAP_KHAC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_PHUCAP_KHAC.LocationFloat = new DevExpress.Utils.PointFloat(1.667086F, 1104.125F);
        this.xrl_PHUCAP_KHAC.Name = "xrl_PHUCAP_KHAC";
        this.xrl_PHUCAP_KHAC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_PHUCAP_KHAC.SizeF = new System.Drawing.SizeF(771.0851F, 22.7915F);
        this.xrl_PHUCAP_KHAC.StylePriority.UseFont = false;
        this.xrl_PHUCAP_KHAC.StylePriority.UseTextAlignment = false;
        this.xrl_PHUCAP_KHAC.Text = "35. Tổng mức hưởng các phụ cấp khác:    ";
        this.xrl_PHUCAP_KHAC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_PHUCAP_CHUCVU
        // 
        this.xrl_PHUCAP_CHUCVU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_PHUCAP_CHUCVU.LocationFloat = new DevExpress.Utils.PointFloat(421.0426F, 1035.333F);
        this.xrl_PHUCAP_CHUCVU.Name = "xrl_PHUCAP_CHUCVU";
        this.xrl_PHUCAP_CHUCVU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_PHUCAP_CHUCVU.SizeF = new System.Drawing.SizeF(350.4573F, 22.7915F);
        this.xrl_PHUCAP_CHUCVU.StylePriority.UseFont = false;
        this.xrl_PHUCAP_CHUCVU.StylePriority.UseTextAlignment = false;
        this.xrl_PHUCAP_CHUCVU.Text = "Hệ số phụ cấp chức vụ:   ";
        this.xrl_PHUCAP_CHUCVU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_PHUCAP_TNVK
        // 
        this.xrl_PHUCAP_TNVK.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_PHUCAP_TNVK.LocationFloat = new DevExpress.Utils.PointFloat(262.0835F, 989.3331F);
        this.xrl_PHUCAP_TNVK.Name = "xrl_PHUCAP_TNVK";
        this.xrl_PHUCAP_TNVK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_PHUCAP_TNVK.SizeF = new System.Drawing.SizeF(121.2494F, 22.7915F);
        this.xrl_PHUCAP_TNVK.StylePriority.UseFont = false;
        this.xrl_PHUCAP_TNVK.StylePriority.UseTextAlignment = false;
        this.xrl_PHUCAP_TNVK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHUCVU_DANG
        // 
        this.xrl_CHUCVU_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHUCVU_DANG.LocationFloat = new DevExpress.Utils.PointFloat(559.5829F, 1517.917F);
        this.xrl_CHUCVU_DANG.Name = "xrl_CHUCVU_DANG";
        this.xrl_CHUCVU_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHUCVU_DANG.SizeF = new System.Drawing.SizeF(214.0024F, 23F);
        this.xrl_CHUCVU_DANG.StylePriority.UseFont = false;
        this.xrl_CHUCVU_DANG.StylePriority.UseTextAlignment = false;
        this.xrl_CHUCVU_DANG.Text = "..";
        this.xrl_CHUCVU_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_HS_LUONG
        // 
        this.xrl_HS_LUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_HS_LUONG.LocationFloat = new DevExpress.Utils.PointFloat(380.8331F, 920.7502F);
        this.xrl_HS_LUONG.Name = "xrl_HS_LUONG";
        this.xrl_HS_LUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_HS_LUONG.SizeF = new System.Drawing.SizeF(391.5011F, 22.79156F);
        this.xrl_HS_LUONG.StylePriority.UseFont = false;
        this.xrl_HS_LUONG.StylePriority.UseTextAlignment = false;
        this.xrl_HS_LUONG.Text = "Hệ số lương hiện hưởng:    ";
        this.xrl_HS_LUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NOI_KN_DANG
        // 
        this.xrl_NOI_KN_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NOI_KN_DANG.LocationFloat = new DevExpress.Utils.PointFloat(136.0414F, 1517.916F);
        this.xrl_NOI_KN_DANG.Name = "xrl_NOI_KN_DANG";
        this.xrl_NOI_KN_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NOI_KN_DANG.SizeF = new System.Drawing.SizeF(217.5001F, 23F);
        this.xrl_NOI_KN_DANG.StylePriority.UseFont = false;
        this.xrl_NOI_KN_DANG.StylePriority.UseTextAlignment = false;
        this.xrl_NOI_KN_DANG.Text = "..";
        this.xrl_NOI_KN_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_CT_VAO_DANG
        // 
        this.xrl_NGAY_CT_VAO_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_CT_VAO_DANG.LocationFloat = new DevExpress.Utils.PointFloat(354.1659F, 1494.916F);
        this.xrl_NGAY_CT_VAO_DANG.Name = "xrl_NGAY_CT_VAO_DANG";
        this.xrl_NGAY_CT_VAO_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_CT_VAO_DANG.SizeF = new System.Drawing.SizeF(418.7534F, 23F);
        this.xrl_NGAY_CT_VAO_DANG.StylePriority.UseFont = false;
        this.xrl_NGAY_CT_VAO_DANG.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_CT_VAO_DANG.Text = "52. Ngày chính thức:    ";
        this.xrl_NGAY_CT_VAO_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_VAO_DANG
        // 
        this.xrl_NGAY_VAO_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_VAO_DANG.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1494.916F);
        this.xrl_NGAY_VAO_DANG.Name = "xrl_NGAY_VAO_DANG";
        this.xrl_NGAY_VAO_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_VAO_DANG.SizeF = new System.Drawing.SizeF(353.3335F, 23F);
        this.xrl_NGAY_VAO_DANG.StylePriority.UseFont = false;
        this.xrl_NGAY_VAO_DANG.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_VAO_DANG.Text = "51. Ngày vào Đảng CSVN:    ";
        this.xrl_NGAY_VAO_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHUCVU_DOAN
        // 
        this.xrl_CHUCVU_DOAN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHUCVU_DOAN.LocationFloat = new DevExpress.Utils.PointFloat(246.249F, 1471.916F);
        this.xrl_CHUCVU_DOAN.Name = "xrl_CHUCVU_DOAN";
        this.xrl_CHUCVU_DOAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHUCVU_DOAN.SizeF = new System.Drawing.SizeF(526.9178F, 22.99988F);
        this.xrl_CHUCVU_DOAN.StylePriority.UseFont = false;
        this.xrl_CHUCVU_DOAN.StylePriority.UseTextAlignment = false;
        this.xrl_CHUCVU_DOAN.Text = "..";
        this.xrl_CHUCVU_DOAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NOI_KN_DOAN
        // 
        this.xrl_NOI_KN_DOAN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NOI_KN_DOAN.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1448.916F);
        this.xrl_NOI_KN_DOAN.Name = "xrl_NOI_KN_DOAN";
        this.xrl_NOI_KN_DOAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NOI_KN_DOAN.SizeF = new System.Drawing.SizeF(420.4584F, 22.99988F);
        this.xrl_NOI_KN_DOAN.StylePriority.UseFont = false;
        this.xrl_NOI_KN_DOAN.StylePriority.UseTextAlignment = false;
        this.xrl_NOI_KN_DOAN.Text = "49. Nơi vào đoàn:    ";
        this.xrl_NOI_KN_DOAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_VAO_DOAN
        // 
        this.xrl_NGAY_VAO_DOAN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_VAO_DOAN.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1448.916F);
        this.xrl_NGAY_VAO_DOAN.Name = "xrl_NGAY_VAO_DOAN";
        this.xrl_NGAY_VAO_DOAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_VAO_DOAN.SizeF = new System.Drawing.SizeF(352.7097F, 23F);
        this.xrl_NGAY_VAO_DOAN.StylePriority.UseFont = false;
        this.xrl_NGAY_VAO_DOAN.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_VAO_DOAN.Text = "48. Ngày vào Đoàn TNCSHCM:    ";
        this.xrl_NGAY_VAO_DOAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CAPBAC_QD
        // 
        this.xrl_CAPBAC_QD.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CAPBAC_QD.LocationFloat = new DevExpress.Utils.PointFloat(2.501408F, 1563.917F);
        this.xrl_CAPBAC_QD.Name = "xrl_CAPBAC_QD";
        this.xrl_CAPBAC_QD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CAPBAC_QD.SizeF = new System.Drawing.SizeF(351.0402F, 23F);
        this.xrl_CAPBAC_QD.StylePriority.UseFont = false;
        this.xrl_CAPBAC_QD.StylePriority.UseTextAlignment = false;
        this.xrl_CAPBAC_QD.Text = "57. Quân hàm cao nhất:    ";
        this.xrl_CAPBAC_QD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHUCVU_QD
        // 
        this.xrl_CHUCVU_QD.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHUCVU_QD.LocationFloat = new DevExpress.Utils.PointFloat(530.5845F, 1563.917F);
        this.xrl_CHUCVU_QD.Name = "xrl_CHUCVU_QD";
        this.xrl_CHUCVU_QD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHUCVU_QD.SizeF = new System.Drawing.SizeF(241.5002F, 23F);
        this.xrl_CHUCVU_QD.StylePriority.UseFont = false;
        this.xrl_CHUCVU_QD.StylePriority.UseTextAlignment = false;
        this.xrl_CHUCVU_QD.Text = "..";
        this.xrl_CHUCVU_QD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_RA_QD
        // 
        this.xrl_NGAY_RA_QD.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_RA_QD.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1540.917F);
        this.xrl_NGAY_RA_QD.Name = "xrl_NGAY_RA_QD";
        this.xrl_NGAY_RA_QD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_RA_QD.SizeF = new System.Drawing.SizeF(417.542F, 23F);
        this.xrl_NGAY_RA_QD.StylePriority.UseFont = false;
        this.xrl_NGAY_RA_QD.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_RA_QD.Text = "56. Ngày giải ngũ:       ";
        this.xrl_NGAY_RA_QD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_EMAIL
        // 
        this.xrl_EMAIL.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_EMAIL.LocationFloat = new DevExpress.Utils.PointFloat(0.8334319F, 390.9998F);
        this.xrl_EMAIL.Name = "xrl_EMAIL";
        this.xrl_EMAIL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_EMAIL.SizeF = new System.Drawing.SizeF(151.2499F, 23F);
        this.xrl_EMAIL.StylePriority.UseFont = false;
        this.xrl_EMAIL.StylePriority.UseTextAlignment = false;
        this.xrl_EMAIL.Text = "17. Email:                    ";
        this.xrl_EMAIL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_TGCM
        // 
        this.xrl_NGAY_TGCM.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_TGCM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1540.917F);
        this.xrl_NGAY_TGCM.Name = "xrl_NGAY_TGCM";
        this.xrl_NGAY_TGCM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_TGCM.SizeF = new System.Drawing.SizeF(353.5415F, 23F);
        this.xrl_NGAY_TGCM.StylePriority.UseFont = false;
        this.xrl_NGAY_TGCM.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_TGCM.Text = "55. Ngày tham gia LLVT:    ";
        this.xrl_NGAY_TGCM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_BN_NGACH
        // 
        this.xrl_NGAY_BN_NGACH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_BN_NGACH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 896.9998F);
        this.xrl_NGAY_BN_NGACH.Name = "xrl_NGAY_BN_NGACH";
        this.xrl_NGAY_BN_NGACH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_BN_NGACH.SizeF = new System.Drawing.SizeF(249.5826F, 23F);
        this.xrl_NGAY_BN_NGACH.StylePriority.UseFont = false;
        this.xrl_NGAY_BN_NGACH.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_BN_NGACH.Text = "30. Ngày bổ nhiệm ngạch:   ";
        this.xrl_NGAY_BN_NGACH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGACH
        // 
        this.xrl_NGACH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGACH.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 873.9998F);
        this.xrl_NGACH.Name = "xrl_NGACH";
        this.xrl_NGACH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGACH.SizeF = new System.Drawing.SizeF(383.3329F, 22.99994F);
        this.xrl_NGACH.StylePriority.UseFont = false;
        this.xrl_NGACH.StylePriority.UseTextAlignment = false;
        this.xrl_NGACH.Text = "29. Ngạch:  ";
        this.xrl_NGACH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_BN_CHUVU
        // 
        this.xrl_NGAY_BN_CHUVU.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
        this.xrl_NGAY_BN_CHUVU.LocationFloat = new DevExpress.Utils.PointFloat(25.00024F, 1035.125F);
        this.xrl_NGAY_BN_CHUVU.Name = "xrl_NGAY_BN_CHUVU";
        this.xrl_NGAY_BN_CHUVU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_BN_CHUVU.SizeF = new System.Drawing.SizeF(128.7501F, 23F);
        this.xrl_NGAY_BN_CHUVU.StylePriority.UseFont = false;
        this.xrl_NGAY_BN_CHUVU.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_BN_CHUVU.Text = "Ngày bổ nhiệm:   ";
        this.xrl_NGAY_BN_CHUVU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHUCVU
        // 
        this.xrl_CHUCVU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHUCVU.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1012.125F);
        this.xrl_CHUCVU.Name = "xrl_CHUCVU";
        this.xrl_CHUCVU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHUCVU.SizeF = new System.Drawing.SizeF(771.5008F, 23F);
        this.xrl_CHUCVU.StylePriority.UseFont = false;
        this.xrl_CHUCVU.StylePriority.UseTextAlignment = false;
        this.xrl_CHUCVU.Text = "33. Chức vụ hiện tại:                               ";
        this.xrl_CHUCVU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CONGVIEC
        // 
        this.xrl_CONGVIEC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CONGVIEC.LocationFloat = new DevExpress.Utils.PointFloat(1.667086F, 1058.125F);
        this.xrl_CONGVIEC.Name = "xrl_CONGVIEC";
        this.xrl_CONGVIEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CONGVIEC.SizeF = new System.Drawing.SizeF(769.4164F, 23.00012F);
        this.xrl_CONGVIEC.StylePriority.UseFont = false;
        this.xrl_CONGVIEC.StylePriority.UseTextAlignment = false;
        this.xrl_CONGVIEC.Text = "34. Chức vụ, chức danh kiêm nhiệm:     ";
        this.xrl_CONGVIEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_XEPLOAI
        // 
        this.xrl_XEPLOAI.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_XEPLOAI.LocationFloat = new DevExpress.Utils.PointFloat(484.3734F, 1241.917F);
        this.xrl_XEPLOAI.Name = "xrl_XEPLOAI";
        this.xrl_XEPLOAI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_XEPLOAI.SizeF = new System.Drawing.SizeF(289.212F, 23F);
        this.xrl_XEPLOAI.StylePriority.UseFont = false;
        this.xrl_XEPLOAI.StylePriority.UseTextAlignment = false;
        this.xrl_XEPLOAI.Text = "..";
        this.xrl_XEPLOAI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NAM_TN
        // 
        this.xrl_NAM_TN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NAM_TN.LocationFloat = new DevExpress.Utils.PointFloat(1.667086F, 1241.917F);
        this.xrl_NAM_TN.Name = "xrl_NAM_TN";
        this.xrl_NAM_TN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NAM_TN.SizeF = new System.Drawing.SizeF(298.3331F, 23F);
        this.xrl_NAM_TN.StylePriority.UseFont = false;
        this.xrl_NAM_TN.StylePriority.UseTextAlignment = false;
        this.xrl_NAM_TN.Text = "39. Năm tốt nghiệp:       ";
        this.xrl_NAM_TN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHUYEN_NGANH
        // 
        this.xrl_CHUYEN_NGANH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHUYEN_NGANH.LocationFloat = new DevExpress.Utils.PointFloat(420.209F, 1218.917F);
        this.xrl_CHUYEN_NGANH.Name = "xrl_CHUYEN_NGANH";
        this.xrl_CHUYEN_NGANH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHUYEN_NGANH.SizeF = new System.Drawing.SizeF(352.5428F, 23F);
        this.xrl_CHUYEN_NGANH.StylePriority.UseFont = false;
        this.xrl_CHUYEN_NGANH.StylePriority.UseTextAlignment = false;
        this.xrl_CHUYEN_NGANH.Text = "..";
        this.xrl_CHUYEN_NGANH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TINHOC
        // 
        this.xrl_TINHOC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TINHOC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1356.916F);
        this.xrl_TINHOC.Name = "xrl_TINHOC";
        this.xrl_TINHOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TINHOC.SizeF = new System.Drawing.SizeF(403.7509F, 23F);
        this.xrl_TINHOC.StylePriority.UseFont = false;
        this.xrl_TINHOC.StylePriority.UseTextAlignment = false;
        this.xrl_TINHOC.Text = "44. Trình độ tin học A, B, C:    ";
        this.xrl_TINHOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGOAI_NGU
        // 
        this.xrl_NGOAI_NGU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGOAI_NGU.LocationFloat = new DevExpress.Utils.PointFloat(0.8324305F, 1333.916F);
        this.xrl_NGOAI_NGU.Name = "xrl_NGOAI_NGU";
        this.xrl_NGOAI_NGU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGOAI_NGU.SizeF = new System.Drawing.SizeF(772.0879F, 23F);
        this.xrl_NGOAI_NGU.StylePriority.UseFont = false;
        this.xrl_NGOAI_NGU.StylePriority.UseTextAlignment = false;
        this.xrl_NGOAI_NGU.Text = "43. Ngoại ngữ (Tên ngoại ngữ, trình độ (A, B, C, D, Cử nhân):       ";
        this.xrl_NGOAI_NGU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CAN_NANG
        // 
        this.xrl_CAN_NANG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CAN_NANG.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1632.917F);
        this.xrl_CAN_NANG.Name = "xrl_CAN_NANG";
        this.xrl_CAN_NANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CAN_NANG.SizeF = new System.Drawing.SizeF(418.3759F, 23F);
        this.xrl_CAN_NANG.StylePriority.UseFont = false;
        this.xrl_CAN_NANG.StylePriority.UseTextAlignment = false;
        this.xrl_CAN_NANG.Text = "Cân nặng:                  ";
        this.xrl_CAN_NANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_CHIEU_CAO
        // 
        this.xrl_CHIEU_CAO.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_CHIEU_CAO.LocationFloat = new DevExpress.Utils.PointFloat(24.99998F, 1632.917F);
        this.xrl_CHIEU_CAO.Name = "xrl_CHIEU_CAO";
        this.xrl_CHIEU_CAO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_CHIEU_CAO.SizeF = new System.Drawing.SizeF(328.5421F, 23F);
        this.xrl_CHIEU_CAO.StylePriority.UseFont = false;
        this.xrl_CHIEU_CAO.StylePriority.UseTextAlignment = false;
        this.xrl_CHIEU_CAO.Text = "Chiều cao:                        ";
        this.xrl_CHIEU_CAO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NHOM_MAU
        // 
        this.xrl_NHOM_MAU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NHOM_MAU.LocationFloat = new DevExpress.Utils.PointFloat(353.5421F, 1609.917F);
        this.xrl_NHOM_MAU.Name = "xrl_NHOM_MAU";
        this.xrl_NHOM_MAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NHOM_MAU.SizeF = new System.Drawing.SizeF(418.3752F, 23F);
        this.xrl_NHOM_MAU.StylePriority.UseFont = false;
        this.xrl_NHOM_MAU.StylePriority.UseTextAlignment = false;
        this.xrl_NHOM_MAU.Text = "Nhóm máu:  ";
        this.xrl_NHOM_MAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TT_SUCKHOE
        // 
        this.xrl_TT_SUCKHOE.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TT_SUCKHOE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1609.917F);
        this.xrl_TT_SUCKHOE.Name = "xrl_TT_SUCKHOE";
        this.xrl_TT_SUCKHOE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TT_SUCKHOE.SizeF = new System.Drawing.SizeF(353.5421F, 23F);
        this.xrl_TT_SUCKHOE.StylePriority.UseFont = false;
        this.xrl_TT_SUCKHOE.StylePriority.UseTextAlignment = false;
        this.xrl_TT_SUCKHOE.Text = "61. Tình trạng sức khỏe:    ";
        this.xrl_TT_SUCKHOE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TD_VH
        // 
        this.xrl_TD_VH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TD_VH.LocationFloat = new DevExpress.Utils.PointFloat(1.666021F, 1172.917F);
        this.xrl_TD_VH.Name = "xrl_TD_VH";
        this.xrl_TD_VH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TD_VH.SizeF = new System.Drawing.SizeF(771.0865F, 23F);
        this.xrl_TD_VH.StylePriority.UseFont = false;
        this.xrl_TD_VH.StylePriority.UseTextAlignment = false;
        this.xrl_TD_VH.Text = "37. Trình độ giáo dục phổ thông :   Lớp :  ";
        this.xrl_TD_VH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_DT_COQUAN
        // 
        this.xrl_DT_COQUAN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_DT_COQUAN.LocationFloat = new DevExpress.Utils.PointFloat(152.0833F, 367.9999F);
        this.xrl_DT_COQUAN.Name = "xrl_DT_COQUAN";
        this.xrl_DT_COQUAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_DT_COQUAN.SizeF = new System.Drawing.SizeF(201.4583F, 23F);
        this.xrl_DT_COQUAN.StylePriority.UseFont = false;
        this.xrl_DT_COQUAN.StylePriority.UseTextAlignment = false;
        this.xrl_DT_COQUAN.Text = "CQ:    ";
        this.xrl_DT_COQUAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_DT_NHA
        // 
        this.xrl_DT_NHA.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_DT_NHA.LocationFloat = new DevExpress.Utils.PointFloat(353.5416F, 367.9999F);
        this.xrl_DT_NHA.Name = "xrl_DT_NHA";
        this.xrl_DT_NHA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_DT_NHA.SizeF = new System.Drawing.SizeF(171.8747F, 23F);
        this.xrl_DT_NHA.StylePriority.UseFont = false;
        this.xrl_DT_NHA.StylePriority.UseTextAlignment = false;
        this.xrl_DT_NHA.Text = "NR:  ";
        this.xrl_DT_NHA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_DI_DONG
        // 
        this.xrl_DI_DONG.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_DI_DONG.LocationFloat = new DevExpress.Utils.PointFloat(527.0833F, 367.9999F);
        this.xrl_DI_DONG.Name = "xrl_DI_DONG";
        this.xrl_DI_DONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_DI_DONG.SizeF = new System.Drawing.SizeF(246.0833F, 23F);
        this.xrl_DI_DONG.StylePriority.UseFont = false;
        this.xrl_DI_DONG.StylePriority.UseTextAlignment = false;
        this.xrl_DI_DONG.Text = "DĐ:  ";
        this.xrl_DI_DONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_HT_TUYEN
        // 
        this.xrl_HT_TUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_HT_TUYEN.LocationFloat = new DevExpress.Utils.PointFloat(0.0003178914F, 505.9998F);
        this.xrl_HT_TUYEN.Name = "xrl_HT_TUYEN";
        this.xrl_HT_TUYEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_HT_TUYEN.SizeF = new System.Drawing.SizeF(246.2487F, 22.99994F);
        this.xrl_HT_TUYEN.StylePriority.UseFont = false;
        this.xrl_HT_TUYEN.StylePriority.UseTextAlignment = false;
        this.xrl_HT_TUYEN.Text = "21. Hình thức tuyển dụng: (v)  ";
        this.xrl_HT_TUYEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_VAO_CT
        // 
        this.xrl_NGAY_VAO_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_VAO_CT.LocationFloat = new DevExpress.Utils.PointFloat(1.66707F, 781.9996F);
        this.xrl_NGAY_VAO_CT.Name = "xrl_NGAY_VAO_CT";
        this.xrl_NGAY_VAO_CT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_VAO_CT.SizeF = new System.Drawing.SizeF(222.9163F, 23F);
        this.xrl_NGAY_VAO_CT.StylePriority.UseFont = false;
        this.xrl_NGAY_VAO_CT.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_VAO_CT.Text = "26. Ngày vào cơ quan hiện nay: ";
        this.xrl_NGAY_VAO_CT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TON_GIAO
        // 
        this.xrl_TON_GIAO.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TON_GIAO.LocationFloat = new DevExpress.Utils.PointFloat(447.7084F, 252.9999F);
        this.xrl_TON_GIAO.Name = "xrl_TON_GIAO";
        this.xrl_TON_GIAO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TON_GIAO.SizeF = new System.Drawing.SizeF(325.877F, 23F);
        this.xrl_TON_GIAO.StylePriority.UseFont = false;
        this.xrl_TON_GIAO.StylePriority.UseTextAlignment = false;
        this.xrl_TON_GIAO.Text = "12.Tôn giáo:           ";
        this.xrl_TON_GIAO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_TUYEN_CHINH
        // 
        this.xrl_NGAY_TUYEN_CHINH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_TUYEN_CHINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 735.9996F);
        this.xrl_NGAY_TUYEN_CHINH.Name = "xrl_NGAY_TUYEN_CHINH";
        this.xrl_NGAY_TUYEN_CHINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_TUYEN_CHINH.SizeF = new System.Drawing.SizeF(224.5834F, 23F);
        this.xrl_NGAY_TUYEN_CHINH.StylePriority.UseFont = false;
        this.xrl_NGAY_TUYEN_CHINH.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_TUYEN_CHINH.Text = "24. Ngày tuyển dụng chính thức:     ";
        this.xrl_NGAY_TUYEN_CHINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGHE_TRUOC_TUYEN
        // 
        this.xrl_NGHE_TRUOC_TUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGHE_TRUOC_TUYEN.LocationFloat = new DevExpress.Utils.PointFloat(0F, 528.9997F);
        this.xrl_NGHE_TRUOC_TUYEN.Name = "xrl_NGHE_TRUOC_TUYEN";
        this.xrl_NGHE_TRUOC_TUYEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGHE_TRUOC_TUYEN.SizeF = new System.Drawing.SizeF(774F, 22.99994F);
        this.xrl_NGHE_TRUOC_TUYEN.StylePriority.UseFont = false;
        this.xrl_NGHE_TRUOC_TUYEN.StylePriority.UseTextAlignment = false;
        this.xrl_NGHE_TRUOC_TUYEN.Text = "22. Nghề nghiệp trước khi tuyển dụng:         ";
        this.xrl_NGHE_TRUOC_TUYEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_TUYEN_DAU
        // 
        this.xrl_NGAY_TUYEN_DAU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_TUYEN_DAU.LocationFloat = new DevExpress.Utils.PointFloat(0.0003178914F, 459.9998F);
        this.xrl_NGAY_TUYEN_DAU.Name = "xrl_NGAY_TUYEN_DAU";
        this.xrl_NGAY_TUYEN_DAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_TUYEN_DAU.SizeF = new System.Drawing.SizeF(173.333F, 23.00003F);
        this.xrl_NGAY_TUYEN_DAU.StylePriority.UseFont = false;
        this.xrl_NGAY_TUYEN_DAU.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_TUYEN_DAU.Text = "19. Ngày tuyển đầu tiên:   ";
        this.xrl_NGAY_TUYEN_DAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_HO_KHAU
        // 
        this.xrl_HO_KHAU.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_HO_KHAU.LocationFloat = new DevExpress.Utils.PointFloat(0F, 321.9999F);
        this.xrl_HO_KHAU.Name = "xrl_HO_KHAU";
        this.xrl_HO_KHAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_HO_KHAU.SizeF = new System.Drawing.SizeF(773.1667F, 23F);
        this.xrl_HO_KHAU.StylePriority.UseFont = false;
        this.xrl_HO_KHAU.StylePriority.UseTextAlignment = false;
        this.xrl_HO_KHAU.Text = "14. Hộ khẩu thường trú:    ";
        this.xrl_HO_KHAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel13
        // 
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 138F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(772.3327F, 23F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.Text = "II. THÔNG TIN HỒ SƠ";
        // 
        // xrl_DAN_TOC
        // 
        this.xrl_DAN_TOC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_DAN_TOC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 253F);
        this.xrl_DAN_TOC.Name = "xrl_DAN_TOC";
        this.xrl_DAN_TOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_DAN_TOC.SizeF = new System.Drawing.SizeF(447.7083F, 23F);
        this.xrl_DAN_TOC.StylePriority.UseFont = false;
        this.xrl_DAN_TOC.StylePriority.UseTextAlignment = false;
        this.xrl_DAN_TOC.Text = "11. Dân tộc:                   ";
        this.xrl_DAN_TOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NOI_O_HIENNAY
        // 
        this.xrl_NOI_O_HIENNAY.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NOI_O_HIENNAY.LocationFloat = new DevExpress.Utils.PointFloat(0F, 344.9999F);
        this.xrl_NOI_O_HIENNAY.Name = "xrl_NOI_O_HIENNAY";
        this.xrl_NOI_O_HIENNAY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NOI_O_HIENNAY.SizeF = new System.Drawing.SizeF(772.3334F, 23F);
        this.xrl_NOI_O_HIENNAY.StylePriority.UseFont = false;
        this.xrl_NOI_O_HIENNAY.StylePriority.UseTextAlignment = false;
        this.xrl_NOI_O_HIENNAY.Text = "15. Nơi ở hiện nay:  ";
        this.xrl_NOI_O_HIENNAY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TEN_KHAC
        // 
        this.xrl_TEN_KHAC.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TEN_KHAC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 184F);
        this.xrl_TEN_KHAC.Name = "xrl_TEN_KHAC";
        this.xrl_TEN_KHAC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TEN_KHAC.SizeF = new System.Drawing.SizeF(447.7085F, 23.00002F);
        this.xrl_TEN_KHAC.StylePriority.UseFont = false;
        this.xrl_TEN_KHAC.StylePriority.UseTextAlignment = false;
        this.xrl_TEN_KHAC.Text = "7. Tên gọi khác: ";
        this.xrl_TEN_KHAC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_BI_DANH
        // 
        this.xrl_BI_DANH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_BI_DANH.LocationFloat = new DevExpress.Utils.PointFloat(447.7084F, 184F);
        this.xrl_BI_DANH.Name = "xrl_BI_DANH";
        this.xrl_BI_DANH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_BI_DANH.SizeF = new System.Drawing.SizeF(324.6244F, 23F);
        this.xrl_BI_DANH.StylePriority.UseFont = false;
        this.xrl_BI_DANH.StylePriority.UseTextAlignment = false;
        this.xrl_BI_DANH.Text = "8. Bí danh:  ";
        this.xrl_BI_DANH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_TINH_THANH
        // 
        this.xrl_TINH_THANH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_TINH_THANH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 276F);
        this.xrl_TINH_THANH.Name = "xrl_TINH_THANH";
        this.xrl_TINH_THANH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TINH_THANH.SizeF = new System.Drawing.SizeF(152.0832F, 23F);
        this.xrl_TINH_THANH.StylePriority.UseFont = false;
        this.xrl_TINH_THANH.StylePriority.UseTextAlignment = false;
        this.xrl_TINH_THANH.Text = "13. Quê quán:";
        this.xrl_TINH_THANH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_HO_TEN
        // 
        this.xrl_HO_TEN.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_HO_TEN.LocationFloat = new DevExpress.Utils.PointFloat(0.8334954F, 161F);
        this.xrl_HO_TEN.Name = "xrl_HO_TEN";
        this.xrl_HO_TEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_HO_TEN.SizeF = new System.Drawing.SizeF(446.875F, 23F);
        this.xrl_HO_TEN.StylePriority.UseFont = false;
        this.xrl_HO_TEN.StylePriority.UseTextAlignment = false;
        this.xrl_HO_TEN.Text = "5. Họ và tên khai sinh:  ";
        this.xrl_HO_TEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrl_NGAY_SINH
        // 
        this.xrl_NGAY_SINH.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrl_NGAY_SINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 207F);
        this.xrl_NGAY_SINH.Name = "xrl_NGAY_SINH";
        this.xrl_NGAY_SINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_NGAY_SINH.SizeF = new System.Drawing.SizeF(100.8333F, 23F);
        this.xrl_NGAY_SINH.StylePriority.UseFont = false;
        this.xrl_NGAY_SINH.StylePriority.UseTextAlignment = false;
        this.xrl_NGAY_SINH.Text = "9. Ngày sinh:  ";
        this.xrl_NGAY_SINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(224.5833F, 23F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.Text = "I. THÔNG TIN CHUNG";
        // 
        // xrLabel56
        // 
        this.xrLabel56.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2408.375F);
        this.xrLabel56.Name = "xrLabel56";
        this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel56.SizeF = new System.Drawing.SizeF(772.3326F, 23F);
        this.xrLabel56.StylePriority.UseFont = false;
        this.xrLabel56.StylePriority.UseTextAlignment = false;
        this.xrLabel56.Text = "VI. CÁC QUÁ TRÌNH:";
        this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
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
        this.BottomMargin.HeightF = 51F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // DetailReport
        // 
        this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
        this.DetailReport.Level = 0;
        this.DetailReport.Name = "DetailReport";
        // 
        // Detail1
        // 
        this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrsub_QT_DT,
            this.xrsub_HOSO_QH_GIADINH,
            this.xrsub_QTCT});
        this.Detail1.HeightF = 89.99995F;
        this.Detail1.Name = "Detail1";
        this.Detail1.StylePriority.UseTextAlignment = false;
        this.Detail1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrsub_QT_DT
        // 
        this.xrsub_QT_DT.LocationFloat = new DevExpress.Utils.PointFloat(0.0003178914F, 23.00008F);
        this.xrsub_QT_DT.Name = "xrsub_QT_DT";
        this.xrsub_QT_DT.ReportSource = this.sub_Quatrinh_Daotao1;
        this.xrsub_QT_DT.SizeF = new System.Drawing.SizeF(772.9201F, 23F);
        // 
        // xrsub_HOSO_QH_GIADINH
        // 
        this.xrsub_HOSO_QH_GIADINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.99991F);
        this.xrsub_HOSO_QH_GIADINH.Name = "xrsub_HOSO_QH_GIADINH";
        this.xrsub_HOSO_QH_GIADINH.ReportSource = this.sub_Quanhe_Giadinh1;
        this.xrsub_HOSO_QH_GIADINH.SizeF = new System.Drawing.SizeF(772.9193F, 43.99998F);
        // 
        // xrsub_QTCT
        // 
        this.xrsub_QTCT.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrsub_QTCT.Name = "xrsub_QTCT";
        this.xrsub_QTCT.ReportSource = this.sub_Quatrinh_Congtac1;
        this.xrsub_QTCT.SizeF = new System.Drawing.SizeF(771.9174F, 23F);
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TEN_HETHONG,
            this.xrPictureBox1,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
        this.ReportHeader.HeightF = 191F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrl_TEN_HETHONG
        // 
        this.xrl_TEN_HETHONG.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrl_TEN_HETHONG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrl_TEN_HETHONG.LocationFloat = new DevExpress.Utils.PointFloat(224.0013F, 122.5F);
        this.xrl_TEN_HETHONG.Name = "xrl_TEN_HETHONG";
        this.xrl_TEN_HETHONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrl_TEN_HETHONG.SizeF = new System.Drawing.SizeF(548.3315F, 20.99998F);
        this.xrl_TEN_HETHONG.StylePriority.UseBorders = false;
        this.xrl_TEN_HETHONG.StylePriority.UseFont = false;
        this.xrl_TEN_HETHONG.StylePriority.UseTextAlignment = false;
        this.xrl_TEN_HETHONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrPictureBox1
        // 
        this.xrPictureBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
        this.xrPictureBox1.Name = "xrPictureBox1";
        this.xrPictureBox1.SizeF = new System.Drawing.SizeF(142.0832F, 181F);
        this.xrPictureBox1.StylePriority.UseBorders = false;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(224.0013F, 97.50001F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(548.3315F, 20.99996F);
        this.xrLabel5.StylePriority.UseBorders = false;
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "PHIẾU CÁN BỘ, CÔNG CHỨC, VIÊN CHỨC";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(224.0013F, 35.00001F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(548.3315F, 20.99998F);
        this.xrLabel4.StylePriority.UseBorders = false;
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Độc lập - Tự do -Hạnh phúc";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(224.0013F, 10.00001F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(548.3315F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel115,
            this.xrtngayketxuat,
            this.xrLabel113,
            this.xrLabel112});
        this.ReportFooter.HeightF = 179F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel115
        // 
        this.xrLabel115.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(495.0438F, 60.00001F);
        this.xrLabel115.Name = "xrLabel115";
        this.xrLabel115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel115.SizeF = new System.Drawing.SizeF(278.1223F, 23F);
        this.xrLabel115.StylePriority.UseFont = false;
        this.xrLabel115.StylePriority.UseTextAlignment = false;
        this.xrLabel115.Text = "(Ký tên, đóng dấu)";
        this.xrLabel115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrtngayketxuat
        // 
        this.xrtngayketxuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
        this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(495.0438F, 10.00001F);
        this.xrtngayketxuat.Name = "xrtngayketxuat";
        this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(278.9562F, 23F);
        this.xrtngayketxuat.StylePriority.UseFont = false;
        this.xrtngayketxuat.Text = "Hà Nội, ngày ........tháng..........năm.............";
        // 
        // xrLabel113
        // 
        this.xrLabel113.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel113.LocationFloat = new DevExpress.Utils.PointFloat(495.0438F, 35.0001F);
        this.xrLabel113.Name = "xrLabel113";
        this.xrLabel113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel113.SizeF = new System.Drawing.SizeF(276.8737F, 23F);
        this.xrLabel113.StylePriority.UseFont = false;
        this.xrLabel113.StylePriority.UseTextAlignment = false;
        this.xrLabel113.Text = "GIÁM ĐỐC";
        this.xrLabel113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel112
        // 
        this.xrLabel112.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel112.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
        this.xrLabel112.Name = "xrLabel112";
        this.xrLabel112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel112.SizeF = new System.Drawing.SizeF(224.5834F, 23F);
        this.xrLabel112.StylePriority.UseFont = false;
        this.xrLabel112.StylePriority.UseTextAlignment = false;
        this.xrLabel112.Text = "NGƯỜI KHAI";
        this.xrLabel112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.HeightF = 0F;
        this.PageHeader.Name = "PageHeader";
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.HeightF = 0F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Name = "GroupFooter1";
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
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(646.8787F, 35.41667F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        // 
        // rpt_NhanSu_Detail
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.DetailReport,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter});
        this.Margins = new System.Drawing.Printing.Margins(40, 36, 49, 51);
        this.Version = "10.1";
        ((System.ComponentModel.ISupportInitialize)(this.sub_Quatrinh_Daotao1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.sub_Quanhe_Giadinh1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.sub_Quatrinh_Congtac1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
