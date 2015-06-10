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
public class rp_EmployeeDetail : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrl_NGAY_SINH;
    private XRLabel xrl_HO_TEN;
    private XRLabel xrl_TINH_THANH;
    private XRLabel xrl_BI_DANH;
    private XRLabel xrl_TEN_KHAC;
    private XRLabel xrl_NGAY_TUYEN_CHINH;
    private XRLabel xrl_NGAY_TUYEN_DAU;
    private XRLabel xrl_HO_KHAU;
    private XRLabel xrLabel13;
    private XRLabel xrl_DAN_TOC;
    private XRLabel xrl_NOI_O_HIENNAY;
    private XRLabel xrl_TON_GIAO;
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
    private XRCheckBox xrc_NAM;
    private XRCheckBox xrc_NU;
    private XRLabel xrl_NGAYSINH;
    private XRLabel xrl_THEO_HS_GOC;
    private XRLabel xrl_THEO_DV_HC;
    private XRLabel xrLabel15;
    private XRLabel xrl_NGAY_TUYEN_DAUTIEN;
    private XRCheckBox xrc_XETTUYEN;
    private XRCheckBox xrc_THITUYEN;
    private XRCheckBox xrc_TUYENTHANG;
    private XRCheckBox xrc_DACCACH;
    private XRLabel xrl_NGAY_TUYENDUNG_CT;
    private XRLabel xrl_MA_NGACH;
    private XRLabel xrl_NGAY_BNN;
    private XRLabel xrLabel26;
    private XRLabel xrl_PHANTRAN_HUONG;
    private XRLabel xrLabel27;
    private XRLabel xrl_NGAY_NL;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrNgayBoNhiem;
    private XRLabel xrLabel33;
    private XRLabel xrl_HESO_PC_CD;
    private XRLabel xrl_NGAY_BN_CV;
    private XRLabel xrl_NGAY_CAP_BH;
    private XRCheckBox xrc_DAIHOC;
    private XRCheckBox xrc_SauDaiHoc;
    private XRCheckBox xrc_TRUNGCAP;
    private XRCheckBox xrc_CAODANG;
    private XRLabel xrLabel34;
    private XRLabel xrNganh;
    private XRLabel xrLabel36;
    private XRCheckBox xrc_CAOCAP_CTRI;
    private XRCheckBox xrc_SOCAP_CTRI;
    private XRCheckBox xrc_TRUNGCAP_CT;
    private XRCheckBox xrc_CUNHAN_CTRI;
    private XRCheckBox xrc_QL_CVCC;
    private XRCheckBox xrc_QL_CVC;
    private XRCheckBox xrc_QL_CANSU;
    private XRCheckBox xrc_QL_ChuyenVien;
    private XRLabel xrLabel37;
    private XRLabel xrLabel46;
    private XRLabel xrBenhBinh;
    private XRLabel xrThuongBinh;
    private XRLabel xrSDTLienHe;
    private XRLabel xrHoTenLienHe;
    private XRLabel xrLabel43;
    private XRLabel xrLabel42;
    private XRLabel xrLabel41;
    private XRLabel xrLabel40;
    private XRLabel xrl_Mail;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private XRSubreport xrsub_HOSO_QH_GIADINH;
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
    private sub_Quanhe_Giadinh sub_Quanhe_Giadinh1;
    private PageHeaderBand PageHeader;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrSoThich;
    private XRLabel xrLabel50;
    private XRLabel xrUuDiem;
    private XRLabel xrLabel52;
    private XRLabel xrLabel16;
    private XRLabel xrNhuocDiem;
    private XRLabel xr_NgayDong_BHYT;
    private XRLabel xrLabel49;
    private XRLabel xr_SO_THE_BHYT;
    private XRLabel xrNoiCapBHXH;
    private XRLabel xrLabel55;
    private XRLabel xrLabel59;
    private XRLabel xrDanhChinhSachBHXH;
    private XRLabel xr_HetHan_BHYT;
    private XRLabel xrLabel60;
    private XRLabel xrNoiKhamBenh;
    private XRLabel xrLabel62;
    private XRLabel xrTyLeDongBH;
    private XRLabel xrLabel64;
    private XRLabel xrLabel47;
    private XRLabel xrEmailLienHe;
    private XRLabel xrQuanHeVoiCanBo;
    private XRLabel xrDiaChiLienHe;
    private XRLabel xrNgayHetHanBHXH;
    private XRLabel xrLabel32;
    private XRLabel xrBoPhan;
    private XRLabel xrLabel17;
    private XRLabel xrLabel19;
    private XRLabel xrChucVu;
    private XRLabel xrViTriCongViec;
    private XRLabel xrLabel18;
    private XRLabel xrLabel22;
    private XRLabel xrHinhThucLamViec;
    private XRCheckBox xrc_THPT;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrTruongDaoTao;
    private XRLabel xrTaiKhoanNganHang;
    private XRLabel xrTenNganHang;
    private XRLabel xrMaSoThue;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    public string MaDonVi { get; set; }
    public rp_EmployeeDetail()
    {
        InitializeComponent(); 
        xrtngayketxuat.Text = " Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

    }
    public void BindData(DAL.HOSO hs)
    { 
        if (hs == null)
            return;
        sub_Quanhe_Giadinh1.BindData(hs.PR_KEY);
        List<DAL.HOSO> ds = new List<DAL.HOSO>();
        ds.Add(hs);
        //DataSource = ds;
        xrl_HO_TEN.Text += hs.HO_TEN;
        //xrl_BI_DANH.Text += hs.BI_DANH;
        if (hs.DM_TINHTHANH != null)
            xrl_THEO_HS_GOC.Text += hs.DM_TINHTHANH.TEN_TINHTHANH;
        if (hs.DM_DANTOC != null)
            xrl_DAN_TOC.Text += hs.DM_DANTOC.TEN_DANTOC; 
        if (!string.IsNullOrEmpty(hs.MA_NOICAP_CMND))
        {
            xrl_NOICAP_CMND.Text += hs.DM_NOICAP_CMND.TEN_NOICAP_CMND;
        }
        xrl_CAN_NANG.Text += hs.CAN_NANG + " kg";
        xrl_CHIEU_CAO.Text += hs.CHIEU_CAO + " cm";
        xrl_DI_DONG.Text += hs.DI_DONG;
        xrl_DT_COQUAN.Text += hs.DT_CQUAN;
        xrl_DT_NHA.Text += hs.DT_NHA;
        xrl_Mail.Text += hs.EMAIL;
        xrl_HO_KHAU.Text += hs.HO_KHAU;
        xrTaiKhoanNganHang.Text += hs.SO_TAI_KHOAN;
        if (!string.IsNullOrEmpty(hs.TAI_NH))
        {
            DAL.DM_NH nh = new DM_NGANHANGController().GetById(hs.TAI_NH);
            if (nh != null)
                xrTenNganHang.Text += nh.TEN_NH;
        }
        xrMaSoThue.Text += hs.MST_CANHAN;
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
        // ngạch
        if (hs.NGAY_BN_NGACH.HasValue)
        {
            xrl_NGAY_BNN.Text = string.Format("{0:dd/MM/yyyy}", hs.NGAY_BN_NGACH);
        }
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
            xrl_NGAY_BN_CV.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_BN_CHUCVU);
        }
        if (hs.NGAY_BN_NGACH.HasValue)
        {
            xrl_NGAY_BNN.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_BN_NGACH);
        }
        if (hs.NGAY_CTHUC_DANG.HasValue)
            xrl_NGAY_CT_VAO_DANG.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_CTHUC_DANG);
         
        if (hs.NGAY_SINH.HasValue)
        {
            xrl_NGAYSINH.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_SINH);
        }
        // ngày tham gia LLVT cách mạng
        if (hs.NGAY_TGCM.HasValue)
            xrl_NGAY_TGCM.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_TGCM);
        if (hs.NGAY_TUYEN_DTIEN.HasValue)
        {
            xrl_NGAY_TUYEN_DAUTIEN.Text = string.Format("{0:dd/MM/yyyy}", hs.NGAY_TUYEN_DTIEN);

        }
        if (hs.NGAY_TUYEN_CHINHTHUC.HasValue)
        {
            xrl_NGAY_TUYENDUNG_CT.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_TUYEN_CHINHTHUC);
        }
      
        // công việc 
        if (!string.IsNullOrEmpty(hs.MA_DONVI))
        {

        }
        // thẻ bảo hiểm xã hội
        xr_SO_THE_BHYT.Text += hs.SOTHE_BHYT;
        if (hs.NGAY_DONGBH.HasValue)
        {
            xr_NgayDong_BHYT.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_DONGBH);
        }
        if (hs.NGAY_HETHAN_BHYT.HasValue)
        {
            xr_HetHan_BHYT.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_HETHAN_BHYT);
        }
        if (hs.DM_NOI_KCB != null)
        {
            if (hs.DM_NOI_KCB.TEN_NOI_KCB != "")
            {
                xrNoiKhamBenh.Text += hs.DM_NOI_KCB.TEN_NOI_KCB;
            }
        }
        xrTyLeDongBH.Text += hs.TYLE_DONG_BH;
        // thẻ bảo hiểm xã hội
        xrl_SO_THE_BHXH.Text += hs.SOTHE_BHXH;
        if (hs.DM_NOICAP_BHXH != null)
        {
            if (hs.DM_NOICAP_BHXH.TEN_NOICAP_BHXH != null)
            {
                xrNoiCapBHXH.Text += hs.DM_NOICAP_BHXH.TEN_NOICAP_BHXH;
            }
        }
        xrDanhChinhSachBHXH.Text += hs.MA_LOAI_CS;
        if (hs.NGAYCAP_BHXH.HasValue)
        {
            xrl_NGAY_CAP_BH.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYCAP_BHXH);
        }
        if (hs.NGAY_KTBH.HasValue)
        {
            xrNgayHetHanBHXH.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAY_KTBH);
        }
        //ngày vào đảng
        if (hs.NGAYVAO_DANG.HasValue)
            xrl_NGAY_VAO_DANG.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYVAO_DANG);
        // ngày vào đoàn
        if (hs.NGAYVAO_DOAN.HasValue)
            xrl_NGAY_VAO_DOAN.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYVAO_DOAN);
        // ngày cấp CMND
        if (hs.NGAYCAP_CMND.HasValue)
            xrl_NGAYCAP_CMND.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYCAP_CMND);
        // xrl_NGHE_TRUOC_TUYEN.Text += hs.NGHE_TRUOCTUYEN;
        // ngoại ngữ
        if (hs.DM_NGOAINGU != null)
            xrl_NGOAI_NGU.Text += hs.DM_NGOAINGU.TEN_NGOAINGU;
        xrl_NHOM_MAU.Text += hs.NHOM_MAU;
        xrl_NOI_KN_DANG.Text += hs.NOI_KETNAP_DANG;
        xrl_NOI_KN_DOAN.Text += hs.NOI_KETNAP_DOAN;
        xrl_NOI_O_HIENNAY.Text += hs.DIA_CHI_LH;
        xrl_NOI_SINH.Text += hs.NOI_SINH;
        xrl_SO_CMND.Text += hs.SO_CMND;
        // trình độ chính trị
         
        if (hs.MA_TD_CHINHTRI == "01")
            xrc_SOCAP_CTRI.Checked = true;
        else if (hs.MA_TD_CHINHTRI == "02")
            xrc_TRUNGCAP_CT.Checked = true;
        else if (hs.MA_TD_CHINHTRI == "03")
            xrc_CAOCAP_CTRI.Checked = true;
        else if (hs.MA_TD_CHINHTRI == "04")
            xrc_CUNHAN_CTRI.Checked = true;
        // quản lý kinh tế
        if (hs.DM_TD_QLKT != null)
            xrl_TD_QLKT.Text += hs.DM_TD_QLKT.TEN_TD_QLKT;
        // trình độ quản lý
        if (hs.DM_TD_QUANLY != null)
        {
            if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "01")
                xrc_QL_CANSU.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "02")
                xrc_QL_ChuyenVien.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "03")
                xrc_QL_CVC.Checked = true;
            else if (hs.DM_TD_QUANLY.MA_TD_QUANLY == "04")
                xrc_QL_CVCC.Checked = true;
        }
        // trình độ tin học
        if (hs.DM_TINHOC != null)
            xrl_TINHOC.Text += hs.DM_TINHOC.TEN_TINHOC;
        // tôn giáo
        if (hs.DM_TONGIAO != null)
            xrl_TON_GIAO.Text += hs.DM_TONGIAO.TEN_TONGIAO;
        // thành phần gia đình
        if (hs.DM_TP_GIADINH != null) { }
        // tình trạng sức khỏe
        if (hs.DM_TT_SUCKHOE != null)
            xrl_TT_SUCKHOE.Text += hs.DM_TT_SUCKHOE.TEN_TT_SUCKHOE;
        // giới tính
        if (hs.MA_GIOITINH == "M")
        { xrc_NAM.Checked = true; }
        else
            xrc_NU.Checked = true;
        // hình ảnh
        xrPictureBox1.ImageUrl = hs.PHOTO;
        //xrPictureBox1.SizeF = new SizeF(160F, 120F);
        xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
        // ngành
        if (!string.IsNullOrEmpty(hs.MA_CHUYENNGANH))
        {
            xrNganh.Text += hs.DM_CHUYENNGANH.TEN_CHUYENNGANH;
        }

        // chức vụ đoàn
        if (hs.DM_CHUCVU_DOAN != null)
            xrl_CHUCVU_DOAN.Text += hs.DM_CHUCVU_DOAN.TEN_CHUCVU_DOAN;
        // chức vụ đảng
        if (hs.DM_CHUCVU_DANG != null)
            xrl_CHUCVU_DANG.Text += hs.DM_CHUCVU_DANG.TEN_CHUCVU_DANG;
        // chức vụ uan đội
        if (hs.DM_CHUCVU_QDOI != null)
            xrl_CHUCVU_QD.Text += hs.DM_CHUCVU_QDOI.TEN_CHUCVU_QDOI;
        if (hs.NGAYRA_QDOI != null)
            xrl_NGAY_RA_QD.Text += string.Format("{0:dd/MM/yyyy}", hs.NGAYRA_QDOI);
        if (hs.DM_TD_VANHOA != null)
        {
            xrl_TD_VH.Text += hs.DM_TD_VANHOA.TEN_TD_VANHOA;
        }
        if (hs.DM_LOAI_C != null)
            xrl_LOAI_CS.Text += hs.DM_LOAI_C.TEN_LOAI_CS;
        // trình độ chuyên môn cao nhất
        if (hs.DM_TRINHDO != null)
        {
            if (hs.DM_TRINHDO.NhomTrinhDo == "1.SDH")
            {
                xrc_SauDaiHoc.Checked = true;
            }
            else if (hs.DM_TRINHDO.NhomTrinhDo=="2.DH")
            {
                xrc_DAIHOC.Checked = true;
            }
            else if (hs.DM_TRINHDO.NhomTrinhDo =="3.CD")
            {
                xrc_CAODANG.Checked = true;
            }
            else if (hs.DM_TRINHDO.NhomTrinhDo == "4.TC")
            {
                xrc_TRUNGCAP.Checked = true;
            }
            else if (hs.DM_TRINHDO.NhomTrinhDo == "5.PTTH")
            {
                xrc_THPT.Checked = true;
            }
        }
        if (hs.DM_CHUYENNGANH != null)
            xrl_CHUYEN_NGANH.Text += hs.DM_CHUYENNGANH.TEN_CHUYENNGANH;
        if (hs.DM_XEPLOAI != null)
            xrl_XEPLOAI.Text += hs.DM_XEPLOAI.TEN_XEPLOAI;
        //  xrl_PHONGBAN.Text += hs.DM_PHONG.TEN_PHONG;
        // xrl_PHONGBAN.DataBindings.Add("Text", DataSource, "DM_PHONG.TEN_PHONG");
        // sở thích, ưu điểm, nhược điểm
        if (!string.IsNullOrEmpty(hs.SO_THICH))
        {
            xrSoThich.Text = hs.SO_THICH;
        }
        if (!string.IsNullOrEmpty(hs.UU_DIEM))
        {
            xrUuDiem.Text = hs.UU_DIEM;
        }
        if (!string.IsNullOrEmpty(hs.NHUOC_DIEM))
        {
            xrNhuocDiem.Text = hs.NHUOC_DIEM;
        }
        // người liên hệ
        xrHoTenLienHe.Text += hs.NguoiLienHe;
        xrSDTLienHe.Text += hs.SDTNguoiLienHe;
        xrEmailLienHe.Text += hs.EmailNguoiLienHe;
        xrDiaChiLienHe.Text += hs.DiaChiNguoiLienHe;
        xrQuanHeVoiCanBo.Text += hs.QuanHeVoiCanBo;
        // bộ phần
        if (!string.IsNullOrEmpty(hs.MA_DONVI))
        {
            DAL.DM_DONVI dv = new DM_DONVIController().GetById(hs.MA_DONVI);
            if (dv != null)
                xrBoPhan.Text += dv.TEN_DONVI;
        }
        // chức vụ
        if (!string.IsNullOrEmpty(hs.MA_CHUCVU))
        {
            xrChucVu.Text = hs.DM_CHUCVU.TEN_CHUCVU;
        }
        // vị trí công việc
        if (!string.IsNullOrEmpty(hs.MA_CONGVIEC))
        {
            xrViTriCongViec.Text = hs.DM_CONGVIEC.TEN_CONGVIEC;
        }
        // hình thức làm việc
        if (!string.IsNullOrEmpty(hs.HinhThucLamViec.ToString()))
        {
            DAL.ThamSoTrangThai ts = new ThamSoTrangThaiController().GetByID(hs.HinhThucLamViec);
            xrHinhThucLamViec.Text = ts.Value;
        }
        // ngày thử việc
        //if (hs.NGAY_TUYEN_DTIEN.HasValue)
        //{
        //    xrNgayThuViec.Text = string.Format("{0:dd/MM/yyyy}", hs.NGAY_TUYEN_DTIEN);
        //}
        // quân hàm cao nhất
        if (!string.IsNullOrEmpty(hs.MA_CAPBAC_QDOI))
        {
            xrl_CAPBAC_QD.Text += hs.DM_CAPBAC_QDOI.TEN_CAPBAC_QDOI;

        }
        // chức vụ quân đội
        if (hs.DM_CHUCVU_QDOI != null)
        {
            xrl_CHUCVU_QD.Text += hs.DM_CHUCVU_QDOI.TEN_CHUCVU_QDOI;
        }
        // thương binh
        if (hs.LaThuongBinh == true)
        {
            xrThuongBinh.Text += hs.HangThuongTat;
        }
        if (!string.IsNullOrEmpty(hs.SoThuongTat))
        {
            xrBenhBinh.Text += hs.HinhThucThuongTat + " " + hs.SoThuongTat;
        }
        // trường đào tạo
        if (!string.IsNullOrEmpty(hs.MA_TRUONG_DAOTAO))
        {
            xrTruongDaoTao.Text = hs.DM_TRUONG_DAOTAO.TEN_TRUONG_DAOTAO;
        }

        //Bind thông tin gia đình
        sub_Quanhe_Giadinh1.BindData(hs.PR_KEY);
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
            string resourceFileName = "rp_EmployeeDetail.resx";
            System.Resources.ResourceManager resources = global::Resources.rp_EmployeeDetail.ResourceManager;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrMaSoThue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTenNganHang = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTaiKhoanNganHang = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTruongDaoTao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrc_THPT = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrHinhThucLamViec = new DevExpress.XtraReports.UI.XRLabel();
            this.xrViTriCongViec = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrChucVu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBoPhan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNgayHetHanBHXH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDiaChiLienHe = new DevExpress.XtraReports.UI.XRLabel();
            this.xrEmailLienHe = new DevExpress.XtraReports.UI.XRLabel();
            this.xrQuanHeVoiCanBo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTyLeDongBH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNoiKhamBenh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_HetHan_BHYT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDanhChinhSachBHXH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNoiCapBHXH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_NgayDong_BHYT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_SO_THE_BHYT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNhuocDiem = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUuDiem = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSoThich = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_Mail = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBenhBinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrThuongBinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSDTLienHe = new DevExpress.XtraReports.UI.XRLabel();
            this.xrHoTenLienHe = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrc_QL_CVCC = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_QL_CVC = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_QL_CANSU = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_QL_ChuyenVien = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_CUNHAN_CTRI = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_CAOCAP_CTRI = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_SOCAP_CTRI = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_TRUNGCAP_CT = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNganh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrc_DAIHOC = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_SauDaiHoc = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_TRUNGCAP = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_CAODANG = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrl_NGAY_CAP_BH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_HESO_PC_CD = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAY_BN_CV = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNgayBoNhiem = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAY_NL = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_PHANTRAN_HUONG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAY_BNN = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_MA_NGACH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAY_TUYENDUNG_CT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrc_TUYENTHANG = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_DACCACH = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_XETTUYEN = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_THITUYEN = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrl_NGAY_TUYEN_DAUTIEN = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_THEO_DV_HC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_THEO_HS_GOC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAYSINH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrc_NU = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrc_NAM = new DevExpress.XtraReports.UI.XRCheckBox();
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
            this.xrl_TON_GIAO = new DevExpress.XtraReports.UI.XRLabel();
            this.xrl_NGAY_TUYEN_CHINH = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrsub_HOSO_QH_GIADINH = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub_Quanhe_Giadinh1 = new sub_Quanhe_Giadinh();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrl_TEN_HETHONG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtngayketxuat = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel113 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.sub_Quanhe_Giadinh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrMaSoThue,
            this.xrTenNganHang,
            this.xrTaiKhoanNganHang,
            this.xrTruongDaoTao,
            this.xrLabel21,
            this.xrLabel20,
            this.xrc_THPT,
            this.xrLabel22,
            this.xrHinhThucLamViec,
            this.xrViTriCongViec,
            this.xrLabel18,
            this.xrLabel19,
            this.xrChucVu,
            this.xrBoPhan,
            this.xrLabel17,
            this.xrNgayHetHanBHXH,
            this.xrLabel32,
            this.xrDiaChiLienHe,
            this.xrEmailLienHe,
            this.xrQuanHeVoiCanBo,
            this.xrLabel47,
            this.xrTyLeDongBH,
            this.xrLabel64,
            this.xrNoiKhamBenh,
            this.xrLabel62,
            this.xr_HetHan_BHYT,
            this.xrLabel60,
            this.xrLabel59,
            this.xrDanhChinhSachBHXH,
            this.xrNoiCapBHXH,
            this.xrLabel55,
            this.xr_NgayDong_BHYT,
            this.xrLabel49,
            this.xr_SO_THE_BHYT,
            this.xrLabel16,
            this.xrNhuocDiem,
            this.xrUuDiem,
            this.xrLabel52,
            this.xrSoThich,
            this.xrLabel50,
            this.xrl_Mail,
            this.xrLabel46,
            this.xrBenhBinh,
            this.xrThuongBinh,
            this.xrSDTLienHe,
            this.xrHoTenLienHe,
            this.xrLabel43,
            this.xrLabel42,
            this.xrLabel41,
            this.xrLabel40,
            this.xrLabel37,
            this.xrc_QL_CVCC,
            this.xrc_QL_CVC,
            this.xrc_QL_CANSU,
            this.xrc_QL_ChuyenVien,
            this.xrc_CUNHAN_CTRI,
            this.xrc_CAOCAP_CTRI,
            this.xrc_SOCAP_CTRI,
            this.xrc_TRUNGCAP_CT,
            this.xrLabel36,
            this.xrNganh,
            this.xrLabel34,
            this.xrc_DAIHOC,
            this.xrc_SauDaiHoc,
            this.xrc_TRUNGCAP,
            this.xrc_CAODANG,
            this.xrl_NGAY_CAP_BH,
            this.xrl_HESO_PC_CD,
            this.xrl_NGAY_BN_CV,
            this.xrLabel33,
            this.xrNgayBoNhiem,
            this.xrLabel29,
            this.xrLabel28,
            this.xrl_NGAY_NL,
            this.xrLabel27,
            this.xrl_PHANTRAN_HUONG,
            this.xrLabel26,
            this.xrl_NGAY_BNN,
            this.xrl_MA_NGACH,
            this.xrl_NGAY_TUYENDUNG_CT,
            this.xrc_TUYENTHANG,
            this.xrc_DACCACH,
            this.xrc_XETTUYEN,
            this.xrc_THITUYEN,
            this.xrl_NGAY_TUYEN_DAUTIEN,
            this.xrLabel15,
            this.xrl_THEO_DV_HC,
            this.xrl_THEO_HS_GOC,
            this.xrl_NGAYSINH,
            this.xrc_NU,
            this.xrc_NAM,
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
            this.xrl_TON_GIAO,
            this.xrl_NGAY_TUYEN_CHINH,
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
            this.xrPictureBox1});
            this.Detail.HeightF = 1969F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrMaSoThue
            // 
            this.xrMaSoThue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrMaSoThue.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1828.459F);
            this.xrMaSoThue.Name = "xrMaSoThue";
            this.xrMaSoThue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrMaSoThue.SizeF = new System.Drawing.SizeF(422.4585F, 23F);
            this.xrMaSoThue.StylePriority.UseFont = false;
            this.xrMaSoThue.StylePriority.UseTextAlignment = false;
            this.xrMaSoThue.Text = "60. Mã số thuế: ";
            this.xrMaSoThue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrTenNganHang
            // 
            this.xrTenNganHang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTenNganHang.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 1851.459F);
            this.xrTenNganHang.Name = "xrTenNganHang";
            this.xrTenNganHang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTenNganHang.SizeF = new System.Drawing.SizeF(775.9999F, 23F);
            this.xrTenNganHang.StylePriority.UseFont = false;
            this.xrTenNganHang.StylePriority.UseTextAlignment = false;
            this.xrTenNganHang.Text = "61. Tên ngân hàng: ";
            this.xrTenNganHang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrTaiKhoanNganHang
            // 
            this.xrTaiKhoanNganHang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTaiKhoanNganHang.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 1828.459F);
            this.xrTaiKhoanNganHang.Name = "xrTaiKhoanNganHang";
            this.xrTaiKhoanNganHang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTaiKhoanNganHang.SizeF = new System.Drawing.SizeF(353.5415F, 23F);
            this.xrTaiKhoanNganHang.StylePriority.UseFont = false;
            this.xrTaiKhoanNganHang.StylePriority.UseTextAlignment = false;
            this.xrTaiKhoanNganHang.Text = "59. Tài khoản ngân hàng: ";
            this.xrTaiKhoanNganHang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrTruongDaoTao
            // 
            this.xrTruongDaoTao.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTruongDaoTao.LocationFloat = new DevExpress.Utils.PointFloat(152.9202F, 1112.667F);
            this.xrTruongDaoTao.Name = "xrTruongDaoTao";
            this.xrTruongDaoTao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTruongDaoTao.SizeF = new System.Drawing.SizeF(622.2467F, 23F);
            this.xrTruongDaoTao.StylePriority.UseFont = false;
            this.xrTruongDaoTao.StylePriority.UseTextAlignment = false;
            this.xrTruongDaoTao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1112.667F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(151.2508F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "34. Trường đào tạo:";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(52.92601F, 1135.667F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(82.70416F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Ngành:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrc_THPT
            // 
            this.xrc_THPT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_THPT.LocationFloat = new DevExpress.Utils.PointFloat(297.4966F, 1089.667F);
            this.xrc_THPT.Name = "xrc_THPT";
            this.xrc_THPT.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_THPT.StylePriority.UseFont = false;
            this.xrc_THPT.Text = "THPT";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 463.5414F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(224.5824F, 23F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "20. Hình thức làm việc: ";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrHinhThucLamViec
            // 
            this.xrHinhThucLamViec.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrHinhThucLamViec.LocationFloat = new DevExpress.Utils.PointFloat(224.5823F, 463.5414F);
            this.xrHinhThucLamViec.Name = "xrHinhThucLamViec";
            this.xrHinhThucLamViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrHinhThucLamViec.SizeF = new System.Drawing.SizeF(549.7468F, 23F);
            this.xrHinhThucLamViec.StylePriority.UseFont = false;
            this.xrHinhThucLamViec.StylePriority.UseTextAlignment = false;
            this.xrHinhThucLamViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrViTriCongViec
            // 
            this.xrViTriCongViec.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrViTriCongViec.LocationFloat = new DevExpress.Utils.PointFloat(152.0832F, 440.5414F);
            this.xrViTriCongViec.Name = "xrViTriCongViec";
            this.xrViTriCongViec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrViTriCongViec.SizeF = new System.Drawing.SizeF(622.2491F, 23F);
            this.xrViTriCongViec.StylePriority.UseFont = false;
            this.xrViTriCongViec.StylePriority.UseTextAlignment = false;
            this.xrViTriCongViec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 440.5414F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(152.0832F, 22.99994F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "19. Vị trí công việc:";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(377.5F, 417.5414F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(100.4128F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "18. Chức vụ:";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrChucVu
            // 
            this.xrChucVu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrChucVu.LocationFloat = new DevExpress.Utils.PointFloat(477.9127F, 417.5414F);
            this.xrChucVu.Name = "xrChucVu";
            this.xrChucVu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrChucVu.SizeF = new System.Drawing.SizeF(297.2548F, 23F);
            this.xrChucVu.StylePriority.UseFont = false;
            this.xrChucVu.StylePriority.UseTextAlignment = false;
            this.xrChucVu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrBoPhan
            // 
            this.xrBoPhan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrBoPhan.LocationFloat = new DevExpress.Utils.PointFloat(100.8333F, 417.5414F);
            this.xrBoPhan.Name = "xrBoPhan";
            this.xrBoPhan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrBoPhan.SizeF = new System.Drawing.SizeF(276.6667F, 23F);
            this.xrBoPhan.StylePriority.UseFont = false;
            this.xrBoPhan.StylePriority.UseTextAlignment = false;
            this.xrBoPhan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(0.0008821487F, 417.5414F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(100.8324F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "17. Bộ phận:";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrNgayHetHanBHXH
            // 
            this.xrNgayHetHanBHXH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrNgayHetHanBHXH.LocationFloat = new DevExpress.Utils.PointFloat(449.378F, 884.2914F);
            this.xrNgayHetHanBHXH.Name = "xrNgayHetHanBHXH";
            this.xrNgayHetHanBHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNgayHetHanBHXH.SizeF = new System.Drawing.SizeF(324.297F, 23F);
            this.xrNgayHetHanBHXH.StylePriority.UseFont = false;
            this.xrNgayHetHanBHXH.StylePriority.UseTextAlignment = false;
            this.xrNgayHetHanBHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(324.1705F, 884.2914F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(125.2074F, 23F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Ngày hết hạn:";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrDiaChiLienHe
            // 
            this.xrDiaChiLienHe.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrDiaChiLienHe.LocationFloat = new DevExpress.Utils.PointFloat(20.99695F, 1943.459F);
            this.xrDiaChiLienHe.Name = "xrDiaChiLienHe";
            this.xrDiaChiLienHe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrDiaChiLienHe.SizeF = new System.Drawing.SizeF(755.003F, 23F);
            this.xrDiaChiLienHe.StylePriority.UseFont = false;
            this.xrDiaChiLienHe.StylePriority.UseTextAlignment = false;
            this.xrDiaChiLienHe.Text = "Địa chỉ: ";
            this.xrDiaChiLienHe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrEmailLienHe
            // 
            this.xrEmailLienHe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.xrEmailLienHe.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1920.459F);
            this.xrEmailLienHe.Name = "xrEmailLienHe";
            this.xrEmailLienHe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrEmailLienHe.SizeF = new System.Drawing.SizeF(420.7896F, 23F);
            this.xrEmailLienHe.StylePriority.UseFont = false;
            this.xrEmailLienHe.StylePriority.UseTextAlignment = false;
            this.xrEmailLienHe.Text = "Email liên hệ: ";
            this.xrEmailLienHe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrQuanHeVoiCanBo
            // 
            this.xrQuanHeVoiCanBo.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrQuanHeVoiCanBo.LocationFloat = new DevExpress.Utils.PointFloat(20.99694F, 1920.459F);
            this.xrQuanHeVoiCanBo.Name = "xrQuanHeVoiCanBo";
            this.xrQuanHeVoiCanBo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrQuanHeVoiCanBo.SizeF = new System.Drawing.SizeF(332.5446F, 23F);
            this.xrQuanHeVoiCanBo.StylePriority.UseFont = false;
            this.xrQuanHeVoiCanBo.StylePriority.UseTextAlignment = false;
            this.xrQuanHeVoiCanBo.Text = "Quan hệ với cán bộ: ";
            this.xrQuanHeVoiCanBo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(0.5852222F, 1874.459F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(773.4997F, 23F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "62. Thông tin người liên hệ";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrTyLeDongBH
            // 
            this.xrTyLeDongBH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTyLeDongBH.LocationFloat = new DevExpress.Utils.PointFloat(460.2104F, 995.6665F);
            this.xrTyLeDongBH.Name = "xrTyLeDongBH";
            this.xrTyLeDongBH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTyLeDongBH.SizeF = new System.Drawing.SizeF(314.1197F, 23.00012F);
            this.xrTyLeDongBH.StylePriority.UseFont = false;
            this.xrTyLeDongBH.StylePriority.UseTextAlignment = false;
            this.xrTyLeDongBH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel64
            // 
            this.xrLabel64.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(322.5028F, 995.6665F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(137.7075F, 23F);
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.Text = "Tỷ lệ đóng BH";
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrNoiKhamBenh
            // 
            this.xrNoiKhamBenh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrNoiKhamBenh.LocationFloat = new DevExpress.Utils.PointFloat(460.2104F, 971.7084F);
            this.xrNoiKhamBenh.Name = "xrNoiKhamBenh";
            this.xrNoiKhamBenh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNoiKhamBenh.SizeF = new System.Drawing.SizeF(314.1197F, 23F);
            this.xrNoiKhamBenh.StylePriority.UseFont = false;
            this.xrNoiKhamBenh.StylePriority.UseTextAlignment = false;
            this.xrNoiKhamBenh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel62
            // 
            this.xrLabel62.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(322.5028F, 971.7084F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(137.7075F, 23F);
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.Text = "Nơi khám bệnh:";
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_HetHan_BHYT
            // 
            this.xr_HetHan_BHYT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xr_HetHan_BHYT.LocationFloat = new DevExpress.Utils.PointFloat(460.2102F, 947.7505F);
            this.xr_HetHan_BHYT.Name = "xr_HetHan_BHYT";
            this.xr_HetHan_BHYT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_HetHan_BHYT.SizeF = new System.Drawing.SizeF(314.1198F, 23F);
            this.xr_HetHan_BHYT.StylePriority.UseFont = false;
            this.xr_HetHan_BHYT.StylePriority.UseTextAlignment = false;
            this.xr_HetHan_BHYT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(322.5027F, 947.7505F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(137.7075F, 23F);
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "Ngày hết BHYT:";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel59
            // 
            this.xrLabel59.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(324.1704F, 859.2916F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(125.2074F, 23F);
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.Text = "Dạng chính sách:";
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrDanhChinhSachBHXH
            // 
            this.xrDanhChinhSachBHXH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrDanhChinhSachBHXH.LocationFloat = new DevExpress.Utils.PointFloat(449.3778F, 859.2916F);
            this.xrDanhChinhSachBHXH.Name = "xrDanhChinhSachBHXH";
            this.xrDanhChinhSachBHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrDanhChinhSachBHXH.SizeF = new System.Drawing.SizeF(324.297F, 23F);
            this.xrDanhChinhSachBHXH.StylePriority.UseFont = false;
            this.xrDanhChinhSachBHXH.StylePriority.UseTextAlignment = false;
            this.xrDanhChinhSachBHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrNoiCapBHXH
            // 
            this.xrNoiCapBHXH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrNoiCapBHXH.LocationFloat = new DevExpress.Utils.PointFloat(449.3778F, 835.3335F);
            this.xrNoiCapBHXH.Name = "xrNoiCapBHXH";
            this.xrNoiCapBHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNoiCapBHXH.SizeF = new System.Drawing.SizeF(325.7806F, 23F);
            this.xrNoiCapBHXH.StylePriority.UseFont = false;
            this.xrNoiCapBHXH.StylePriority.UseTextAlignment = false;
            this.xrNoiCapBHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel55
            // 
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(324.1704F, 835.3335F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(125.2074F, 23F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = "Nơi cấp:";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_NgayDong_BHYT
            // 
            this.xr_NgayDong_BHYT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xr_NgayDong_BHYT.LocationFloat = new DevExpress.Utils.PointFloat(460.2104F, 921.7084F);
            this.xr_NgayDong_BHYT.Name = "xr_NgayDong_BHYT";
            this.xr_NgayDong_BHYT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_NgayDong_BHYT.SizeF = new System.Drawing.SizeF(314.1208F, 23F);
            this.xr_NgayDong_BHYT.StylePriority.UseFont = false;
            this.xr_NgayDong_BHYT.StylePriority.UseTextAlignment = false;
            this.xr_NgayDong_BHYT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(322.5028F, 921.7084F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(137.7075F, 23F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "Ngày đóng BHYT:";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_SO_THE_BHYT
            // 
            this.xr_SO_THE_BHYT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xr_SO_THE_BHYT.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 921.7084F);
            this.xr_SO_THE_BHYT.Name = "xr_SO_THE_BHYT";
            this.xr_SO_THE_BHYT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_SO_THE_BHYT.SizeF = new System.Drawing.SizeF(318.3333F, 23F);
            this.xr_SO_THE_BHYT.StylePriority.UseFont = false;
            this.xr_SO_THE_BHYT.StylePriority.UseTextAlignment = false;
            this.xr_SO_THE_BHYT.Text = "31. Số sổ bảo hiểm y tế: ";
            this.xr_SO_THE_BHYT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1753.291F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(773.4997F, 23.00012F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "58. Nhược điểm";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrNhuocDiem
            // 
            this.xrNhuocDiem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrNhuocDiem.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1776.291F);
            this.xrNhuocDiem.Name = "xrNhuocDiem";
            this.xrNhuocDiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNhuocDiem.SizeF = new System.Drawing.SizeF(773.4997F, 52.16724F);
            this.xrNhuocDiem.StylePriority.UseFont = false;
            this.xrNhuocDiem.StylePriority.UseTextAlignment = false;
            this.xrNhuocDiem.Text = resources.GetString("xrNhuocDiem.Text");
            this.xrNhuocDiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrUuDiem
            // 
            this.xrUuDiem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrUuDiem.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1701.124F);
            this.xrUuDiem.Name = "xrUuDiem";
            this.xrUuDiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrUuDiem.SizeF = new System.Drawing.SizeF(773.4997F, 52.16699F);
            this.xrUuDiem.StylePriority.UseFont = false;
            this.xrUuDiem.StylePriority.UseTextAlignment = false;
            this.xrUuDiem.Text = resources.GetString("xrUuDiem.Text");
            this.xrUuDiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1678.124F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(773.0792F, 23F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "57. Ưu điểm";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrSoThich
            // 
            this.xrSoThich.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrSoThich.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1629.083F);
            this.xrSoThich.Name = "xrSoThich";
            this.xrSoThich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrSoThich.SizeF = new System.Drawing.SizeF(773.4997F, 49.04175F);
            this.xrSoThich.StylePriority.UseFont = false;
            this.xrSoThich.StylePriority.UseTextAlignment = false;
            this.xrSoThich.Text = resources.GetString("xrSoThich.Text");
            this.xrSoThich.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrLabel50
            // 
            this.xrLabel50.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1606.083F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(772.0043F, 23F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            this.xrLabel50.Text = "56. Sở thích";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrl_Mail
            // 
            this.xrl_Mail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_Mail.LocationFloat = new DevExpress.Utils.PointFloat(135.208F, 276.0001F);
            this.xrl_Mail.Name = "xrl_Mail";
            this.xrl_Mail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_Mail.SizeF = new System.Drawing.SizeF(638.2891F, 23F);
            this.xrl_Mail.StylePriority.UseFont = false;
            this.xrl_Mail.StylePriority.UseTextAlignment = false;
            this.xrl_Mail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1537.083F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(773.0808F, 23F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "(Con thương binh, con liệt sĩ, người nhiễm chất độc da cam Dioxin, gia đình có cô" +
    "ng với CM...)";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrBenhBinh
            // 
            this.xrBenhBinh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrBenhBinh.LocationFloat = new DevExpress.Utils.PointFloat(353.1304F, 1491.082F);
            this.xrBenhBinh.Name = "xrBenhBinh";
            this.xrBenhBinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrBenhBinh.SizeF = new System.Drawing.SizeF(422.0382F, 23F);
            this.xrBenhBinh.StylePriority.UseFont = false;
            this.xrBenhBinh.StylePriority.UseTextAlignment = false;
            this.xrBenhBinh.Text = "53. Bệnh binh :                ";
            this.xrBenhBinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrThuongBinh
            // 
            this.xrThuongBinh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrThuongBinh.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1491.082F);
            this.xrThuongBinh.Name = "xrThuongBinh";
            this.xrThuongBinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrThuongBinh.SizeF = new System.Drawing.SizeF(351.4609F, 23F);
            this.xrThuongBinh.StylePriority.UseFont = false;
            this.xrThuongBinh.StylePriority.UseTextAlignment = false;
            this.xrThuongBinh.Text = "52. Thương binh hạng:    ";
            this.xrThuongBinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrSDTLienHe
            // 
            this.xrSDTLienHe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.xrSDTLienHe.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 1897.459F);
            this.xrSDTLienHe.Name = "xrSDTLienHe";
            this.xrSDTLienHe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrSDTLienHe.SizeF = new System.Drawing.SizeF(420.7896F, 23F);
            this.xrSDTLienHe.StylePriority.UseFont = false;
            this.xrSDTLienHe.StylePriority.UseTextAlignment = false;
            this.xrSDTLienHe.Text = "Số điện thoại: ";
            this.xrSDTLienHe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrHoTenLienHe
            // 
            this.xrHoTenLienHe.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrHoTenLienHe.LocationFloat = new DevExpress.Utils.PointFloat(20.99695F, 1897.459F);
            this.xrHoTenLienHe.Name = "xrHoTenLienHe";
            this.xrHoTenLienHe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrHoTenLienHe.SizeF = new System.Drawing.SizeF(332.5446F, 23F);
            this.xrHoTenLienHe.StylePriority.UseFont = false;
            this.xrHoTenLienHe.StylePriority.UseTextAlignment = false;
            this.xrHoTenLienHe.Text = "Họ tên: ";
            this.xrHoTenLienHe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(353.131F, 1468.082F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(174.3761F, 23F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "51. Chức vụ cao nhất: ";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel42
            // 
            this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(353.7548F, 1422.082F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(204.3813F, 23.00012F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "47. Chức vụ Đảng hiện nay: ";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1422.082F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(132.3012F, 23F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "46. Nơi kết nạp:    ";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1376.082F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(213.542F, 22.99988F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "43. Chức vụ Đoàn hiện nay:  ";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1227.667F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(261.2436F, 22.99988F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "39. Trình độ quản lý kinh tế:   ";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrc_QL_CVCC
            // 
            this.xrc_QL_CVCC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_QL_CVCC.LocationFloat = new DevExpress.Utils.PointFloat(620.4054F, 1204.667F);
            this.xrc_QL_CVCC.Name = "xrc_QL_CVCC";
            this.xrc_QL_CVCC.SizeF = new System.Drawing.SizeF(155.5945F, 23F);
            this.xrc_QL_CVCC.StylePriority.UseFont = false;
            this.xrc_QL_CVCC.Text = "Chuyên viên cao cấp";
            // 
            // xrc_QL_CVC
            // 
            this.xrc_QL_CVC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_QL_CVC.LocationFloat = new DevExpress.Utils.PointFloat(470.0008F, 1204.667F);
            this.xrc_QL_CVC.Name = "xrc_QL_CVC";
            this.xrc_QL_CVC.SizeF = new System.Drawing.SizeF(150.4046F, 23F);
            this.xrc_QL_CVC.StylePriority.UseFont = false;
            this.xrc_QL_CVC.Text = "Chuyên viên chính";
            // 
            // xrc_QL_CANSU
            // 
            this.xrc_QL_CANSU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_QL_CANSU.LocationFloat = new DevExpress.Utils.PointFloat(297.4966F, 1204.667F);
            this.xrc_QL_CANSU.Name = "xrc_QL_CANSU";
            this.xrc_QL_CANSU.SizeF = new System.Drawing.SizeF(69.38107F, 23F);
            this.xrc_QL_CANSU.StylePriority.UseFont = false;
            this.xrc_QL_CANSU.Text = "Cán sự";
            // 
            // xrc_QL_ChuyenVien
            // 
            this.xrc_QL_ChuyenVien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_QL_ChuyenVien.LocationFloat = new DevExpress.Utils.PointFloat(366.8777F, 1204.667F);
            this.xrc_QL_ChuyenVien.Name = "xrc_QL_ChuyenVien";
            this.xrc_QL_ChuyenVien.SizeF = new System.Drawing.SizeF(103.1231F, 23F);
            this.xrc_QL_ChuyenVien.StylePriority.UseFont = false;
            this.xrc_QL_ChuyenVien.Text = "Chuyên viên";
            // 
            // xrc_CUNHAN_CTRI
            // 
            this.xrc_CUNHAN_CTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_CUNHAN_CTRI.LocationFloat = new DevExpress.Utils.PointFloat(470.8431F, 1181.667F);
            this.xrc_CUNHAN_CTRI.Name = "xrc_CUNHAN_CTRI";
            this.xrc_CUNHAN_CTRI.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_CUNHAN_CTRI.StylePriority.UseFont = false;
            this.xrc_CUNHAN_CTRI.Text = "Cử nhân";
            // 
            // xrc_CAOCAP_CTRI
            // 
            this.xrc_CAOCAP_CTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_CAOCAP_CTRI.LocationFloat = new DevExpress.Utils.PointFloat(557.5164F, 1181.667F);
            this.xrc_CAOCAP_CTRI.Name = "xrc_CAOCAP_CTRI";
            this.xrc_CAOCAP_CTRI.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_CAOCAP_CTRI.StylePriority.UseFont = false;
            this.xrc_CAOCAP_CTRI.Text = "Cao cấp";
            // 
            // xrc_SOCAP_CTRI
            // 
            this.xrc_SOCAP_CTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_SOCAP_CTRI.LocationFloat = new DevExpress.Utils.PointFloat(297.4966F, 1181.667F);
            this.xrc_SOCAP_CTRI.Name = "xrc_SOCAP_CTRI";
            this.xrc_SOCAP_CTRI.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_SOCAP_CTRI.StylePriority.UseFont = false;
            this.xrc_SOCAP_CTRI.Text = "Sơ cấp";
            // 
            // xrc_TRUNGCAP_CT
            // 
            this.xrc_TRUNGCAP_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_TRUNGCAP_CT.LocationFloat = new DevExpress.Utils.PointFloat(384.1699F, 1181.667F);
            this.xrc_TRUNGCAP_CT.Name = "xrc_TRUNGCAP_CT";
            this.xrc_TRUNGCAP_CT.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_TRUNGCAP_CT.StylePriority.UseFont = false;
            this.xrc_TRUNGCAP_CT.Text = "Trung cấp";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(297.4966F, 1158.667F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(202.0845F, 23F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "36. Kết quả tốt nghiệp loại:  ";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrNganh
            // 
            this.xrNganh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrNganh.LocationFloat = new DevExpress.Utils.PointFloat(137.7108F, 1135.667F);
            this.xrNganh.Name = "xrNganh";
            this.xrNganh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNganh.SizeF = new System.Drawing.SizeF(160.6184F, 23F);
            this.xrNganh.StylePriority.UseFont = false;
            this.xrNganh.StylePriority.UseTextAlignment = false;
            this.xrNganh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(298.3292F, 1135.667F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(120.2088F, 23F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "Chuyên ngành: ";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrc_DAIHOC
            // 
            this.xrc_DAIHOC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_DAIHOC.LocationFloat = new DevExpress.Utils.PointFloat(557.5164F, 1089.667F);
            this.xrc_DAIHOC.Name = "xrc_DAIHOC";
            this.xrc_DAIHOC.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_DAIHOC.StylePriority.UseFont = false;
            this.xrc_DAIHOC.Text = "Đại học";
            // 
            // xrc_SauDaiHoc
            // 
            this.xrc_SauDaiHoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_SauDaiHoc.LocationFloat = new DevExpress.Utils.PointFloat(644.1896F, 1089.667F);
            this.xrc_SauDaiHoc.Name = "xrc_SauDaiHoc";
            this.xrc_SauDaiHoc.SizeF = new System.Drawing.SizeF(120.6108F, 23F);
            this.xrc_SauDaiHoc.StylePriority.UseFont = false;
            this.xrc_SauDaiHoc.Text = "Sau Đại học";
            // 
            // xrc_TRUNGCAP
            // 
            this.xrc_TRUNGCAP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_TRUNGCAP.LocationFloat = new DevExpress.Utils.PointFloat(384.1699F, 1089.667F);
            this.xrc_TRUNGCAP.Name = "xrc_TRUNGCAP";
            this.xrc_TRUNGCAP.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_TRUNGCAP.StylePriority.UseFont = false;
            this.xrc_TRUNGCAP.Text = "Trung cấp";
            // 
            // xrc_CAODANG
            // 
            this.xrc_CAODANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_CAODANG.LocationFloat = new DevExpress.Utils.PointFloat(470.8431F, 1089.667F);
            this.xrc_CAODANG.Name = "xrc_CAODANG";
            this.xrc_CAODANG.SizeF = new System.Drawing.SizeF(86.67325F, 23F);
            this.xrc_CAODANG.StylePriority.UseFont = false;
            this.xrc_CAODANG.Text = "Cao đẳng";
            // 
            // xrl_NGAY_CAP_BH
            // 
            this.xrl_NGAY_CAP_BH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_CAP_BH.LocationFloat = new DevExpress.Utils.PointFloat(449.3778F, 812.3334F);
            this.xrl_NGAY_CAP_BH.Name = "xrl_NGAY_CAP_BH";
            this.xrl_NGAY_CAP_BH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_CAP_BH.SizeF = new System.Drawing.SizeF(326.6207F, 23F);
            this.xrl_NGAY_CAP_BH.StylePriority.UseFont = false;
            this.xrl_NGAY_CAP_BH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_CAP_BH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_HESO_PC_CD
            // 
            this.xrl_HESO_PC_CD.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HESO_PC_CD.LocationFloat = new DevExpress.Utils.PointFloat(421.0454F, 766.6456F);
            this.xrl_HESO_PC_CD.Name = "xrl_HESO_PC_CD";
            this.xrl_HESO_PC_CD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HESO_PC_CD.SizeF = new System.Drawing.SizeF(353.286F, 22.7915F);
            this.xrl_HESO_PC_CD.StylePriority.UseFont = false;
            this.xrl_HESO_PC_CD.StylePriority.UseTextAlignment = false;
            this.xrl_HESO_PC_CD.Text = "Hệ số phụ cấp chức vụ:   ";
            this.xrl_HESO_PC_CD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_BN_CV
            // 
            this.xrl_NGAY_BN_CV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_BN_CV.LocationFloat = new DevExpress.Utils.PointFloat(153.7532F, 766.5414F);
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
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(22.50071F, 766.5414F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(128.7501F, 23F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Ngày bổ nhiệm: ";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrNgayBoNhiem
            // 
            this.xrNgayBoNhiem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrNgayBoNhiem.LocationFloat = new DevExpress.Utils.PointFloat(153.7532F, 720.541F);
            this.xrNgayBoNhiem.Name = "xrNgayBoNhiem";
            this.xrNgayBoNhiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrNgayBoNhiem.SizeF = new System.Drawing.SizeF(223.7486F, 23F);
            this.xrNgayBoNhiem.StylePriority.UseFont = false;
            this.xrNgayBoNhiem.StylePriority.UseTextAlignment = false;
            this.xrNgayBoNhiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(384.1697F, 674.7495F);
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
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 674.7495F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(262.0835F, 22.7915F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "26. Phụ cấp thâm niên vượt khung %.:   ";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_NL
            // 
            this.xrl_NGAY_NL.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_NL.LocationFloat = new DevExpress.Utils.PointFloat(246.2487F, 651.7495F);
            this.xrl_NGAY_NL.Name = "xrl_NGAY_NL";
            this.xrl_NGAY_NL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_NL.SizeF = new System.Drawing.SizeF(527.8362F, 23F);
            this.xrl_NGAY_NL.StylePriority.UseFont = false;
            this.xrl_NGAY_NL.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_NL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(22.50071F, 650.9992F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(223.748F, 22.7915F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Mốc xét nâng lương lần sau: ";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_PHANTRAN_HUONG
            // 
            this.xrl_PHANTRAN_HUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_PHANTRAN_HUONG.LocationFloat = new DevExpress.Utils.PointFloat(499.5836F, 628.9581F);
            this.xrl_PHANTRAN_HUONG.Name = "xrl_PHANTRAN_HUONG";
            this.xrl_PHANTRAN_HUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_PHANTRAN_HUONG.SizeF = new System.Drawing.SizeF(274.7456F, 22.79138F);
            this.xrl_PHANTRAN_HUONG.StylePriority.UseFont = false;
            this.xrl_PHANTRAN_HUONG.StylePriority.UseTextAlignment = false;
            this.xrl_PHANTRAN_HUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(380.8336F, 628.9581F);
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
            this.xrl_NGAY_BNN.LocationFloat = new DevExpress.Utils.PointFloat(199.5827F, 582.4162F);
            this.xrl_NGAY_BNN.Name = "xrl_NGAY_BNN";
            this.xrl_NGAY_BNN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_BNN.SizeF = new System.Drawing.SizeF(575.5807F, 23F);
            this.xrl_NGAY_BNN.StylePriority.UseFont = false;
            this.xrl_NGAY_BNN.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_BNN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_MA_NGACH
            // 
            this.xrl_MA_NGACH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_MA_NGACH.LocationFloat = new DevExpress.Utils.PointFloat(383.3334F, 559.4163F);
            this.xrl_MA_NGACH.Name = "xrl_MA_NGACH";
            this.xrl_MA_NGACH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_MA_NGACH.SizeF = new System.Drawing.SizeF(392.6652F, 23F);
            this.xrl_MA_NGACH.StylePriority.UseFont = false;
            this.xrl_MA_NGACH.StylePriority.UseTextAlignment = false;
            this.xrl_MA_NGACH.Text = "23. Mã ngạch: ";
            this.xrl_MA_NGACH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_TUYENDUNG_CT
            // 
            this.xrl_NGAY_TUYENDUNG_CT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_TUYENDUNG_CT.LocationFloat = new DevExpress.Utils.PointFloat(224.5824F, 486.5414F);
            this.xrl_NGAY_TUYENDUNG_CT.Name = "xrl_NGAY_TUYENDUNG_CT";
            this.xrl_NGAY_TUYENDUNG_CT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_TUYENDUNG_CT.SizeF = new System.Drawing.SizeF(549.7468F, 23F);
            this.xrl_NGAY_TUYENDUNG_CT.StylePriority.UseFont = false;
            this.xrl_NGAY_TUYENDUNG_CT.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_TUYENDUNG_CT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrc_TUYENTHANG
            // 
            this.xrc_TUYENTHANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_TUYENTHANG.LocationFloat = new DevExpress.Utils.PointFloat(606.0408F, 394.5415F);
            this.xrc_TUYENTHANG.Name = "xrc_TUYENTHANG";
            this.xrc_TUYENTHANG.SizeF = new System.Drawing.SizeF(169.9588F, 22.99997F);
            this.xrc_TUYENTHANG.StylePriority.UseFont = false;
            this.xrc_TUYENTHANG.StylePriority.UseTextAlignment = false;
            this.xrc_TUYENTHANG.Text = "Tuyển thẳng";
            // 
            // xrc_DACCACH
            // 
            this.xrc_DACCACH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_DACCACH.LocationFloat = new DevExpress.Utils.PointFloat(489.3745F, 394.5414F);
            this.xrc_DACCACH.Name = "xrc_DACCACH";
            this.xrc_DACCACH.SizeF = new System.Drawing.SizeF(116.6663F, 23F);
            this.xrc_DACCACH.StylePriority.UseFont = false;
            this.xrc_DACCACH.Text = "Đặc cách";
            // 
            // xrc_XETTUYEN
            // 
            this.xrc_XETTUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_XETTUYEN.LocationFloat = new DevExpress.Utils.PointFloat(377.9169F, 394.5415F);
            this.xrc_XETTUYEN.Name = "xrc_XETTUYEN";
            this.xrc_XETTUYEN.SizeF = new System.Drawing.SizeF(111.4576F, 22.99994F);
            this.xrc_XETTUYEN.StylePriority.UseFont = false;
            this.xrc_XETTUYEN.Text = "Xét tuyển";
            // 
            // xrc_THITUYEN
            // 
            this.xrc_THITUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_THITUYEN.LocationFloat = new DevExpress.Utils.PointFloat(246.249F, 394.5414F);
            this.xrc_THITUYEN.Name = "xrc_THITUYEN";
            this.xrc_THITUYEN.SizeF = new System.Drawing.SizeF(131.2509F, 23F);
            this.xrc_THITUYEN.StylePriority.UseFont = false;
            this.xrc_THITUYEN.Text = "Thi tuyển";
            // 
            // xrl_NGAY_TUYEN_DAUTIEN
            // 
            this.xrl_NGAY_TUYEN_DAUTIEN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_TUYEN_DAUTIEN.LocationFloat = new DevExpress.Utils.PointFloat(173.3333F, 371.5414F);
            this.xrl_NGAY_TUYEN_DAUTIEN.Name = "xrl_NGAY_TUYEN_DAUTIEN";
            this.xrl_NGAY_TUYEN_DAUTIEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_TUYEN_DAUTIEN.SizeF = new System.Drawing.SizeF(602.6663F, 23.00003F);
            this.xrl_NGAY_TUYEN_DAUTIEN.StylePriority.UseFont = false;
            this.xrl_NGAY_TUYEN_DAUTIEN.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_TUYEN_DAUTIEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 253F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(152.0832F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "12. Điện thoại:  ";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_THEO_DV_HC
            // 
            this.xrl_THEO_DV_HC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_THEO_DV_HC.LocationFloat = new DevExpress.Utils.PointFloat(151.0776F, 184F);
            this.xrl_THEO_DV_HC.Name = "xrl_THEO_DV_HC";
            this.xrl_THEO_DV_HC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_THEO_DV_HC.SizeF = new System.Drawing.SizeF(620.9952F, 23F);
            this.xrl_THEO_DV_HC.StylePriority.UseFont = false;
            this.xrl_THEO_DV_HC.StylePriority.UseTextAlignment = false;
            this.xrl_THEO_DV_HC.Text = "- Theo đơn vị hành chính hiện nay: ";
            this.xrl_THEO_DV_HC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_THEO_HS_GOC
            // 
            this.xrl_THEO_HS_GOC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_THEO_HS_GOC.LocationFloat = new DevExpress.Utils.PointFloat(152.0832F, 161.0001F);
            this.xrl_THEO_HS_GOC.Name = "xrl_THEO_HS_GOC";
            this.xrl_THEO_HS_GOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_THEO_HS_GOC.SizeF = new System.Drawing.SizeF(620.9952F, 23F);
            this.xrl_THEO_HS_GOC.StylePriority.UseFont = false;
            this.xrl_THEO_HS_GOC.StylePriority.UseTextAlignment = false;
            this.xrl_THEO_HS_GOC.Text = "- Theo hồ sơ gốc: ";
            this.xrl_THEO_HS_GOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAYSINH
            // 
            this.xrl_NGAYSINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAYSINH.LocationFloat = new DevExpress.Utils.PointFloat(100.8333F, 46F);
            this.xrl_NGAYSINH.Name = "xrl_NGAYSINH";
            this.xrl_NGAYSINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAYSINH.SizeF = new System.Drawing.SizeF(240.4156F, 23F);
            this.xrl_NGAYSINH.StylePriority.UseFont = false;
            this.xrl_NGAYSINH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAYSINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrc_NU
            // 
            this.xrc_NU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_NU.LocationFloat = new DevExpress.Utils.PointFloat(570.8311F, 46F);
            this.xrc_NU.Name = "xrc_NU";
            this.xrc_NU.SizeF = new System.Drawing.SizeF(71.25F, 23F);
            this.xrc_NU.StylePriority.UseFont = false;
            this.xrc_NU.StylePriority.UseTextAlignment = false;
            this.xrc_NU.Text = "Nữ";
            this.xrc_NU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrc_NAM
            // 
            this.xrc_NAM.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrc_NAM.LocationFloat = new DevExpress.Utils.PointFloat(499.5811F, 46F);
            this.xrc_NAM.Name = "xrc_NAM";
            this.xrc_NAM.SizeF = new System.Drawing.SizeF(71.25F, 23F);
            this.xrc_NAM.StylePriority.UseFont = false;
            this.xrc_NAM.StylePriority.UseTextAlignment = false;
            this.xrc_NAM.Text = "Nam";
            this.xrc_NAM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrl_TRINHDO
            // 
            this.xrl_TRINHDO.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TRINHDO.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1089.667F);
            this.xrl_TRINHDO.Name = "xrl_TRINHDO";
            this.xrl_TRINHDO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TRINHDO.SizeF = new System.Drawing.SizeF(296.6598F, 23F);
            this.xrl_TRINHDO.StylePriority.UseFont = false;
            this.xrl_TRINHDO.StylePriority.UseTextAlignment = false;
            this.xrl_TRINHDO.Text = "33. Trình độ chuyên môn cao nhất (v):  ";
            this.xrl_TRINHDO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1330.082F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(774.3306F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "V. THÔNG TIN KHÁC";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1043.667F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(774.3306F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "IV. ĐÀO TẠO, BỒI DƯỠNG";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 536.4163F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(775.9976F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "III. LƯƠNG, PHỤ CẤP HIỆN HƯỞNG";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 348.5414F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(774.3306F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "II. CÔNG TÁC";
            // 
            // xrl_NOI_SINH
            // 
            this.xrl_NOI_SINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NOI_SINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.xrl_NOI_SINH.Name = "xrl_NOI_SINH";
            this.xrl_NOI_SINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOI_SINH.SizeF = new System.Drawing.SizeF(650.5771F, 23.00002F);
            this.xrl_NOI_SINH.StylePriority.UseFont = false;
            this.xrl_NOI_SINH.StylePriority.UseTextAlignment = false;
            this.xrl_NOI_SINH.Text = "6. Nơi sinh: ";
            this.xrl_NOI_SINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_GIOI_TINH
            // 
            this.xrl_GIOI_TINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_GIOI_TINH.LocationFloat = new DevExpress.Utils.PointFloat(341.2489F, 45.99999F);
            this.xrl_GIOI_TINH.Name = "xrl_GIOI_TINH";
            this.xrl_GIOI_TINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_GIOI_TINH.SizeF = new System.Drawing.SizeF(158.3322F, 23.00002F);
            this.xrl_GIOI_TINH.StylePriority.UseFont = false;
            this.xrl_GIOI_TINH.StylePriority.UseTextAlignment = false;
            this.xrl_GIOI_TINH.Text = "3. Giới tính: (v)";
            this.xrl_GIOI_TINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOICAP_CMND
            // 
            this.xrl_NOICAP_CMND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_NOICAP_CMND.LocationFloat = new DevExpress.Utils.PointFloat(262.0835F, 299F);
            this.xrl_NOICAP_CMND.Name = "xrl_NOICAP_CMND";
            this.xrl_NOICAP_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOICAP_CMND.SizeF = new System.Drawing.SizeF(212.7084F, 23.00003F);
            this.xrl_NOICAP_CMND.StylePriority.UseFont = false;
            this.xrl_NOICAP_CMND.StylePriority.UseTextAlignment = false;
            this.xrl_NOICAP_CMND.Text = "Nơi cấp: ";
            this.xrl_NOICAP_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_SO_CMND
            // 
            this.xrl_SO_CMND.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_SO_CMND.LocationFloat = new DevExpress.Utils.PointFloat(0F, 299F);
            this.xrl_SO_CMND.Name = "xrl_SO_CMND";
            this.xrl_SO_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_SO_CMND.SizeF = new System.Drawing.SizeF(262.0835F, 23.00003F);
            this.xrl_SO_CMND.StylePriority.UseFont = false;
            this.xrl_SO_CMND.StylePriority.UseTextAlignment = false;
            this.xrl_SO_CMND.Text = "14. Số CMTND: ";
            this.xrl_SO_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_LOAI_CS
            // 
            this.xrl_LOAI_CS.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_LOAI_CS.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1514.082F);
            this.xrl_LOAI_CS.Name = "xrl_LOAI_CS";
            this.xrl_LOAI_CS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_LOAI_CS.SizeF = new System.Drawing.SizeF(773.0756F, 23.00012F);
            this.xrl_LOAI_CS.StylePriority.UseFont = false;
            this.xrl_LOAI_CS.StylePriority.UseTextAlignment = false;
            this.xrl_LOAI_CS.Text = "54. Đối tượng được hưởng chính sách :     ";
            this.xrl_LOAI_CS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAYCAP_CMND
            // 
            this.xrl_NGAYCAP_CMND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_NGAYCAP_CMND.LocationFloat = new DevExpress.Utils.PointFloat(474.7919F, 299F);
            this.xrl_NGAYCAP_CMND.Name = "xrl_NGAYCAP_CMND";
            this.xrl_NGAYCAP_CMND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAYCAP_CMND.SizeF = new System.Drawing.SizeF(300.1979F, 23F);
            this.xrl_NGAYCAP_CMND.StylePriority.UseFont = false;
            this.xrl_NGAYCAP_CMND.StylePriority.UseTextAlignment = false;
            this.xrl_NGAYCAP_CMND.Text = "Ngày cấp: ";
            this.xrl_NGAYCAP_CMND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_SO_THE_BHXH
            // 
            this.xrl_SO_THE_BHXH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_SO_THE_BHXH.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 812.3334F);
            this.xrl_SO_THE_BHXH.Name = "xrl_SO_THE_BHXH";
            this.xrl_SO_THE_BHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_SO_THE_BHXH.SizeF = new System.Drawing.SizeF(318.3333F, 23F);
            this.xrl_SO_THE_BHXH.StylePriority.UseFont = false;
            this.xrl_SO_THE_BHXH.StylePriority.UseTextAlignment = false;
            this.xrl_SO_THE_BHXH.Text = "30. Số sổ bảo hiểm xã hội:     ";
            this.xrl_SO_THE_BHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAYCAP_BHXH
            // 
            this.xrl_NGAYCAP_BHXH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAYCAP_BHXH.LocationFloat = new DevExpress.Utils.PointFloat(324.1704F, 812.3334F);
            this.xrl_NGAYCAP_BHXH.Name = "xrl_NGAYCAP_BHXH";
            this.xrl_NGAYCAP_BHXH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAYCAP_BHXH.SizeF = new System.Drawing.SizeF(125.2074F, 23F);
            this.xrl_NGAYCAP_BHXH.StylePriority.UseFont = false;
            this.xrl_NGAYCAP_BHXH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAYCAP_BHXH.Text = "Ngày cấp:";
            this.xrl_NGAYCAP_BHXH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TD_QUANLY
            // 
            this.xrl_TD_QUANLY.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TD_QUANLY.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1204.667F);
            this.xrl_TD_QUANLY.Name = "xrl_TD_QUANLY";
            this.xrl_TD_QUANLY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TD_QUANLY.SizeF = new System.Drawing.SizeF(296.6598F, 23F);
            this.xrl_TD_QUANLY.StylePriority.UseFont = false;
            this.xrl_TD_QUANLY.StylePriority.UseTextAlignment = false;
            this.xrl_TD_QUANLY.Text = "38. Trình độ quản lý (v) :        ";
            this.xrl_TD_QUANLY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TD_CHINHTRI
            // 
            this.xrl_TD_CHINHTRI.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TD_CHINHTRI.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1181.667F);
            this.xrl_TD_CHINHTRI.Name = "xrl_TD_CHINHTRI";
            this.xrl_TD_CHINHTRI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TD_CHINHTRI.SizeF = new System.Drawing.SizeF(296.6598F, 23F);
            this.xrl_TD_CHINHTRI.StylePriority.UseFont = false;
            this.xrl_TD_CHINHTRI.StylePriority.UseTextAlignment = false;
            this.xrl_TD_CHINHTRI.Text = "37. Trình độ lý luận chính trị (v):         ";
            this.xrl_TD_CHINHTRI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TD_QLKT
            // 
            this.xrl_TD_QLKT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TD_QLKT.LocationFloat = new DevExpress.Utils.PointFloat(262.9129F, 1227.667F);
            this.xrl_TD_QLKT.Name = "xrl_TD_QLKT";
            this.xrl_TD_QLKT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TD_QLKT.SizeF = new System.Drawing.SizeF(513.0787F, 22.99988F);
            this.xrl_TD_QLKT.StylePriority.UseFont = false;
            this.xrl_TD_QLKT.StylePriority.UseTextAlignment = false;
            this.xrl_TD_QLKT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_BAC_LUONG
            // 
            this.xrl_BAC_LUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_BAC_LUONG.LocationFloat = new DevExpress.Utils.PointFloat(0F, 605.4162F);
            this.xrl_BAC_LUONG.Name = "xrl_BAC_LUONG";
            this.xrl_BAC_LUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_BAC_LUONG.SizeF = new System.Drawing.SizeF(377.4995F, 22.7915F);
            this.xrl_BAC_LUONG.StylePriority.UseFont = false;
            this.xrl_BAC_LUONG.StylePriority.UseTextAlignment = false;
            this.xrl_BAC_LUONG.Text = "25. Bậc lương hiện hưởng:         ";
            this.xrl_BAC_LUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_HUONG_LUONG
            // 
            this.xrl_NGAY_HUONG_LUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_HUONG_LUONG.LocationFloat = new DevExpress.Utils.PointFloat(22.50071F, 628.2077F);
            this.xrl_NGAY_HUONG_LUONG.Name = "xrl_NGAY_HUONG_LUONG";
            this.xrl_NGAY_HUONG_LUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_HUONG_LUONG.SizeF = new System.Drawing.SizeF(354.9993F, 22.7915F);
            this.xrl_NGAY_HUONG_LUONG.StylePriority.UseFont = false;
            this.xrl_NGAY_HUONG_LUONG.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_HUONG_LUONG.Text = "Ngày hưởng: ";
            this.xrl_NGAY_HUONG_LUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_HUONG_TNVK
            // 
            this.xrl_NGAY_HUONG_TNVK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_HUONG_TNVK.LocationFloat = new DevExpress.Utils.PointFloat(560.4199F, 674.7495F);
            this.xrl_NGAY_HUONG_TNVK.Name = "xrl_NGAY_HUONG_TNVK";
            this.xrl_NGAY_HUONG_TNVK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_HUONG_TNVK.SizeF = new System.Drawing.SizeF(213.4926F, 22.7915F);
            this.xrl_NGAY_HUONG_TNVK.StylePriority.UseFont = false;
            this.xrl_NGAY_HUONG_TNVK.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_HUONG_TNVK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_PHUCAP_KHAC
            // 
            this.xrl_PHUCAP_KHAC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_PHUCAP_KHAC.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 789.5414F);
            this.xrl_PHUCAP_KHAC.Name = "xrl_PHUCAP_KHAC";
            this.xrl_PHUCAP_KHAC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_PHUCAP_KHAC.SizeF = new System.Drawing.SizeF(774.3305F, 22.7915F);
            this.xrl_PHUCAP_KHAC.StylePriority.UseFont = false;
            this.xrl_PHUCAP_KHAC.StylePriority.UseTextAlignment = false;
            this.xrl_PHUCAP_KHAC.Text = "29. Tổng mức hưởng các phụ cấp khác:    ";
            this.xrl_PHUCAP_KHAC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_PHUCAP_CHUCVU
            // 
            this.xrl_PHUCAP_CHUCVU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_PHUCAP_CHUCVU.LocationFloat = new DevExpress.Utils.PointFloat(383.3352F, 720.6453F);
            this.xrl_PHUCAP_CHUCVU.Name = "xrl_PHUCAP_CHUCVU";
            this.xrl_PHUCAP_CHUCVU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_PHUCAP_CHUCVU.SizeF = new System.Drawing.SizeF(389.7404F, 22.7915F);
            this.xrl_PHUCAP_CHUCVU.StylePriority.UseFont = false;
            this.xrl_PHUCAP_CHUCVU.StylePriority.UseTextAlignment = false;
            this.xrl_PHUCAP_CHUCVU.Text = "Hệ số phụ cấp chức vụ:   ";
            this.xrl_PHUCAP_CHUCVU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_PHUCAP_TNVK
            // 
            this.xrl_PHUCAP_TNVK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_PHUCAP_TNVK.LocationFloat = new DevExpress.Utils.PointFloat(262.9203F, 674.7495F);
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
            this.xrl_CHUCVU_DANG.LocationFloat = new DevExpress.Utils.PointFloat(558.1362F, 1422.082F);
            this.xrl_CHUCVU_DANG.Name = "xrl_CHUCVU_DANG";
            this.xrl_CHUCVU_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CHUCVU_DANG.SizeF = new System.Drawing.SizeF(214.7543F, 23F);
            this.xrl_CHUCVU_DANG.StylePriority.UseFont = false;
            this.xrl_CHUCVU_DANG.StylePriority.UseTextAlignment = false;
            this.xrl_CHUCVU_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_HS_LUONG
            // 
            this.xrl_HS_LUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HS_LUONG.LocationFloat = new DevExpress.Utils.PointFloat(377.4995F, 605.4162F);
            this.xrl_HS_LUONG.Name = "xrl_HS_LUONG";
            this.xrl_HS_LUONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HS_LUONG.SizeF = new System.Drawing.SizeF(398.5005F, 23.54193F);
            this.xrl_HS_LUONG.StylePriority.UseFont = false;
            this.xrl_HS_LUONG.StylePriority.UseTextAlignment = false;
            this.xrl_HS_LUONG.Text = "Hệ số lương hiện hưởng:    ";
            this.xrl_HS_LUONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOI_KN_DANG
            // 
            this.xrl_NOI_KN_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NOI_KN_DANG.LocationFloat = new DevExpress.Utils.PointFloat(133.9707F, 1422.082F);
            this.xrl_NOI_KN_DANG.Name = "xrl_NOI_KN_DANG";
            this.xrl_NOI_KN_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOI_KN_DANG.SizeF = new System.Drawing.SizeF(219.1597F, 23F);
            this.xrl_NOI_KN_DANG.StylePriority.UseFont = false;
            this.xrl_NOI_KN_DANG.StylePriority.UseTextAlignment = false;
            this.xrl_NOI_KN_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_CT_VAO_DANG
            // 
            this.xrl_NGAY_CT_VAO_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_CT_VAO_DANG.LocationFloat = new DevExpress.Utils.PointFloat(353.7548F, 1399.082F);
            this.xrl_NGAY_CT_VAO_DANG.Name = "xrl_NGAY_CT_VAO_DANG";
            this.xrl_NGAY_CT_VAO_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_CT_VAO_DANG.SizeF = new System.Drawing.SizeF(420.1621F, 23F);
            this.xrl_NGAY_CT_VAO_DANG.StylePriority.UseFont = false;
            this.xrl_NGAY_CT_VAO_DANG.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_CT_VAO_DANG.Text = "45. Ngày chính thức:    ";
            this.xrl_NGAY_CT_VAO_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_VAO_DANG
            // 
            this.xrl_NGAY_VAO_DANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_VAO_DANG.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1399.082F);
            this.xrl_NGAY_VAO_DANG.Name = "xrl_NGAY_VAO_DANG";
            this.xrl_NGAY_VAO_DANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_VAO_DANG.SizeF = new System.Drawing.SizeF(351.4609F, 23F);
            this.xrl_NGAY_VAO_DANG.StylePriority.UseFont = false;
            this.xrl_NGAY_VAO_DANG.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_VAO_DANG.Text = "44. Ngày vào Đảng CSVN:    ";
            this.xrl_NGAY_VAO_DANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CHUCVU_DOAN
            // 
            this.xrl_CHUCVU_DOAN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CHUCVU_DOAN.LocationFloat = new DevExpress.Utils.PointFloat(215.2115F, 1376.082F);
            this.xrl_CHUCVU_DOAN.Name = "xrl_CHUCVU_DOAN";
            this.xrl_CHUCVU_DOAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CHUCVU_DOAN.SizeF = new System.Drawing.SizeF(560.3749F, 22.99988F);
            this.xrl_CHUCVU_DOAN.StylePriority.UseFont = false;
            this.xrl_CHUCVU_DOAN.StylePriority.UseTextAlignment = false;
            this.xrl_CHUCVU_DOAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOI_KN_DOAN
            // 
            this.xrl_NOI_KN_DOAN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NOI_KN_DOAN.LocationFloat = new DevExpress.Utils.PointFloat(353.1304F, 1353.082F);
            this.xrl_NOI_KN_DOAN.Name = "xrl_NOI_KN_DOAN";
            this.xrl_NOI_KN_DOAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOI_KN_DOAN.SizeF = new System.Drawing.SizeF(422.456F, 22.99988F);
            this.xrl_NOI_KN_DOAN.StylePriority.UseFont = false;
            this.xrl_NOI_KN_DOAN.StylePriority.UseTextAlignment = false;
            this.xrl_NOI_KN_DOAN.Text = "47. Nơi vào đoàn:    ";
            this.xrl_NOI_KN_DOAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_VAO_DOAN
            // 
            this.xrl_NGAY_VAO_DOAN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_VAO_DOAN.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1353.082F);
            this.xrl_NGAY_VAO_DOAN.Name = "xrl_NGAY_VAO_DOAN";
            this.xrl_NGAY_VAO_DOAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_VAO_DOAN.SizeF = new System.Drawing.SizeF(351.4609F, 23F);
            this.xrl_NGAY_VAO_DOAN.StylePriority.UseFont = false;
            this.xrl_NGAY_VAO_DOAN.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_VAO_DOAN.Text = "42. Ngày vào Đoàn TNCSHCM:    ";
            this.xrl_NGAY_VAO_DOAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CAPBAC_QD
            // 
            this.xrl_CAPBAC_QD.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CAPBAC_QD.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1468.082F);
            this.xrl_CAPBAC_QD.Name = "xrl_CAPBAC_QD";
            this.xrl_CAPBAC_QD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CAPBAC_QD.SizeF = new System.Drawing.SizeF(351.0402F, 23F);
            this.xrl_CAPBAC_QD.StylePriority.UseFont = false;
            this.xrl_CAPBAC_QD.StylePriority.UseTextAlignment = false;
            this.xrl_CAPBAC_QD.Text = "50. Quân hàm cao nhất:    ";
            this.xrl_CAPBAC_QD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CHUCVU_QD
            // 
            this.xrl_CHUCVU_QD.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CHUCVU_QD.LocationFloat = new DevExpress.Utils.PointFloat(530.1733F, 1468.082F);
            this.xrl_CHUCVU_QD.Name = "xrl_CHUCVU_QD";
            this.xrl_CHUCVU_QD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CHUCVU_QD.SizeF = new System.Drawing.SizeF(245.4124F, 23F);
            this.xrl_CHUCVU_QD.StylePriority.UseFont = false;
            this.xrl_CHUCVU_QD.StylePriority.UseTextAlignment = false;
            this.xrl_CHUCVU_QD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_RA_QD
            // 
            this.xrl_NGAY_RA_QD.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_RA_QD.LocationFloat = new DevExpress.Utils.PointFloat(353.131F, 1445.082F);
            this.xrl_NGAY_RA_QD.Name = "xrl_NGAY_RA_QD";
            this.xrl_NGAY_RA_QD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_RA_QD.SizeF = new System.Drawing.SizeF(420.3753F, 23F);
            this.xrl_NGAY_RA_QD.StylePriority.UseFont = false;
            this.xrl_NGAY_RA_QD.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_RA_QD.Text = "49. Ngày giải ngũ:       ";
            this.xrl_NGAY_RA_QD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_EMAIL
            // 
            this.xrl_EMAIL.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_EMAIL.LocationFloat = new DevExpress.Utils.PointFloat(0F, 276.0001F);
            this.xrl_EMAIL.Name = "xrl_EMAIL";
            this.xrl_EMAIL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_EMAIL.SizeF = new System.Drawing.SizeF(135.208F, 23F);
            this.xrl_EMAIL.StylePriority.UseFont = false;
            this.xrl_EMAIL.StylePriority.UseTextAlignment = false;
            this.xrl_EMAIL.Text = "13. Email:                    ";
            this.xrl_EMAIL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_TGCM
            // 
            this.xrl_NGAY_TGCM.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_TGCM.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1445.082F);
            this.xrl_NGAY_TGCM.Name = "xrl_NGAY_TGCM";
            this.xrl_NGAY_TGCM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_TGCM.SizeF = new System.Drawing.SizeF(351.4615F, 23F);
            this.xrl_NGAY_TGCM.StylePriority.UseFont = false;
            this.xrl_NGAY_TGCM.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_TGCM.Text = "48. Ngày tham gia LLVT:    ";
            this.xrl_NGAY_TGCM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_BN_NGACH
            // 
            this.xrl_NGAY_BN_NGACH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_BN_NGACH.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 582.4162F);
            this.xrl_NGAY_BN_NGACH.Name = "xrl_NGAY_BN_NGACH";
            this.xrl_NGAY_BN_NGACH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_BN_NGACH.SizeF = new System.Drawing.SizeF(199.5826F, 23F);
            this.xrl_NGAY_BN_NGACH.StylePriority.UseFont = false;
            this.xrl_NGAY_BN_NGACH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_BN_NGACH.Text = "24. Ngày bổ nhiệm ngạch:   ";
            this.xrl_NGAY_BN_NGACH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGACH
            // 
            this.xrl_NGACH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGACH.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 559.4163F);
            this.xrl_NGACH.Name = "xrl_NGACH";
            this.xrl_NGACH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGACH.SizeF = new System.Drawing.SizeF(383.3329F, 22.99994F);
            this.xrl_NGACH.StylePriority.UseFont = false;
            this.xrl_NGACH.StylePriority.UseTextAlignment = false;
            this.xrl_NGACH.Text = "22. Ngạch: ";
            this.xrl_NGACH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_BN_CHUVU
            // 
            this.xrl_NGAY_BN_CHUVU.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline);
            this.xrl_NGAY_BN_CHUVU.LocationFloat = new DevExpress.Utils.PointFloat(22.50071F, 720.541F);
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
            this.xrl_CHUCVU.LocationFloat = new DevExpress.Utils.PointFloat(0.002360344F, 697.541F);
            this.xrl_CHUCVU.Name = "xrl_CHUCVU";
            this.xrl_CHUCVU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CHUCVU.SizeF = new System.Drawing.SizeF(775.9976F, 23F);
            this.xrl_CHUCVU.StylePriority.UseFont = false;
            this.xrl_CHUCVU.StylePriority.UseTextAlignment = false;
            this.xrl_CHUCVU.Text = "27. Chức vụ hiện tại:                               ";
            this.xrl_CHUCVU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CONGVIEC
            // 
            this.xrl_CONGVIEC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CONGVIEC.LocationFloat = new DevExpress.Utils.PointFloat(0.002360344F, 743.541F);
            this.xrl_CONGVIEC.Name = "xrl_CONGVIEC";
            this.xrl_CONGVIEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CONGVIEC.SizeF = new System.Drawing.SizeF(774.3305F, 23.00037F);
            this.xrl_CONGVIEC.StylePriority.UseFont = false;
            this.xrl_CONGVIEC.StylePriority.UseTextAlignment = false;
            this.xrl_CONGVIEC.Text = "28. Chức vụ, chức danh kiêm nhiệm:     ";
            this.xrl_CONGVIEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_XEPLOAI
            // 
            this.xrl_XEPLOAI.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_XEPLOAI.LocationFloat = new DevExpress.Utils.PointFloat(499.5811F, 1158.667F);
            this.xrl_XEPLOAI.Name = "xrl_XEPLOAI";
            this.xrl_XEPLOAI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_XEPLOAI.SizeF = new System.Drawing.SizeF(273.0844F, 23F);
            this.xrl_XEPLOAI.StylePriority.UseFont = false;
            this.xrl_XEPLOAI.StylePriority.UseTextAlignment = false;
            this.xrl_XEPLOAI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NAM_TN
            // 
            this.xrl_NAM_TN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NAM_TN.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1158.667F);
            this.xrl_NAM_TN.Name = "xrl_NAM_TN";
            this.xrl_NAM_TN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NAM_TN.SizeF = new System.Drawing.SizeF(296.6598F, 23F);
            this.xrl_NAM_TN.StylePriority.UseFont = false;
            this.xrl_NAM_TN.StylePriority.UseTextAlignment = false;
            this.xrl_NAM_TN.Text = "35. Năm tốt nghiệp:       ";
            this.xrl_NAM_TN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CHUYEN_NGANH
            // 
            this.xrl_CHUYEN_NGANH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CHUYEN_NGANH.LocationFloat = new DevExpress.Utils.PointFloat(418.538F, 1135.667F);
            this.xrl_CHUYEN_NGANH.Multiline = true;
            this.xrl_CHUYEN_NGANH.Name = "xrl_CHUYEN_NGANH";
            this.xrl_CHUYEN_NGANH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CHUYEN_NGANH.SizeF = new System.Drawing.SizeF(357.2165F, 23F);
            this.xrl_CHUYEN_NGANH.StylePriority.UseFont = false;
            this.xrl_CHUYEN_NGANH.StylePriority.UseTextAlignment = false;
            this.xrl_CHUYEN_NGANH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TINHOC
            // 
            this.xrl_TINHOC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TINHOC.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1273.667F);
            this.xrl_TINHOC.Name = "xrl_TINHOC";
            this.xrl_TINHOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TINHOC.SizeF = new System.Drawing.SizeF(773.0756F, 23F);
            this.xrl_TINHOC.StylePriority.UseFont = false;
            this.xrl_TINHOC.StylePriority.UseTextAlignment = false;
            this.xrl_TINHOC.Text = "41. Trình độ tin học A, B, C:    ";
            this.xrl_TINHOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGOAI_NGU
            // 
            this.xrl_NGOAI_NGU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGOAI_NGU.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1250.667F);
            this.xrl_NGOAI_NGU.Name = "xrl_NGOAI_NGU";
            this.xrl_NGOAI_NGU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGOAI_NGU.SizeF = new System.Drawing.SizeF(774.085F, 23F);
            this.xrl_NGOAI_NGU.StylePriority.UseFont = false;
            this.xrl_NGOAI_NGU.StylePriority.UseTextAlignment = false;
            this.xrl_NGOAI_NGU.Text = "40. Ngoại ngữ (Tên ngoại ngữ, trình độ (A, B, C, D, Cử nhân):       ";
            this.xrl_NGOAI_NGU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CAN_NANG
            // 
            this.xrl_CAN_NANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CAN_NANG.LocationFloat = new DevExpress.Utils.PointFloat(354.7911F, 1583.083F);
            this.xrl_CAN_NANG.Name = "xrl_CAN_NANG";
            this.xrl_CAN_NANG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CAN_NANG.SizeF = new System.Drawing.SizeF(419.5396F, 23F);
            this.xrl_CAN_NANG.StylePriority.UseFont = false;
            this.xrl_CAN_NANG.StylePriority.UseTextAlignment = false;
            this.xrl_CAN_NANG.Text = "Cân nặng:                  ";
            this.xrl_CAN_NANG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_CHIEU_CAO
            // 
            this.xrl_CHIEU_CAO.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_CHIEU_CAO.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1583.083F);
            this.xrl_CHIEU_CAO.Name = "xrl_CHIEU_CAO";
            this.xrl_CHIEU_CAO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_CHIEU_CAO.SizeF = new System.Drawing.SizeF(329.7886F, 23F);
            this.xrl_CHIEU_CAO.StylePriority.UseFont = false;
            this.xrl_CHIEU_CAO.StylePriority.UseTextAlignment = false;
            this.xrl_CHIEU_CAO.Text = "Chiều cao:                        ";
            this.xrl_CHIEU_CAO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NHOM_MAU
            // 
            this.xrl_NHOM_MAU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NHOM_MAU.LocationFloat = new DevExpress.Utils.PointFloat(354.7911F, 1560.083F);
            this.xrl_NHOM_MAU.Name = "xrl_NHOM_MAU";
            this.xrl_NHOM_MAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NHOM_MAU.SizeF = new System.Drawing.SizeF(418.7054F, 23F);
            this.xrl_NHOM_MAU.StylePriority.UseFont = false;
            this.xrl_NHOM_MAU.StylePriority.UseTextAlignment = false;
            this.xrl_NHOM_MAU.Text = "Nhóm máu:  ";
            this.xrl_NHOM_MAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TT_SUCKHOE
            // 
            this.xrl_TT_SUCKHOE.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TT_SUCKHOE.LocationFloat = new DevExpress.Utils.PointFloat(1.669494F, 1560.083F);
            this.xrl_TT_SUCKHOE.Name = "xrl_TT_SUCKHOE";
            this.xrl_TT_SUCKHOE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TT_SUCKHOE.SizeF = new System.Drawing.SizeF(351.4609F, 23F);
            this.xrl_TT_SUCKHOE.StylePriority.UseFont = false;
            this.xrl_TT_SUCKHOE.StylePriority.UseTextAlignment = false;
            this.xrl_TT_SUCKHOE.Text = "55. Tình trạng sức khỏe:    ";
            this.xrl_TT_SUCKHOE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TD_VH
            // 
            this.xrl_TD_VH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TD_VH.LocationFloat = new DevExpress.Utils.PointFloat(0.8368333F, 1066.667F);
            this.xrl_TD_VH.Multiline = true;
            this.xrl_TD_VH.Name = "xrl_TD_VH";
            this.xrl_TD_VH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TD_VH.SizeF = new System.Drawing.SizeF(774.3306F, 23F);
            this.xrl_TD_VH.StylePriority.UseFont = false;
            this.xrl_TD_VH.StylePriority.UseTextAlignment = false;
            this.xrl_TD_VH.Text = "32. Trình độ giáo dục phổ thông: ";
            this.xrl_TD_VH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_DT_COQUAN
            // 
            this.xrl_DT_COQUAN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DT_COQUAN.LocationFloat = new DevExpress.Utils.PointFloat(152.0832F, 253F);
            this.xrl_DT_COQUAN.Name = "xrl_DT_COQUAN";
            this.xrl_DT_COQUAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DT_COQUAN.SizeF = new System.Drawing.SizeF(201.4583F, 23F);
            this.xrl_DT_COQUAN.StylePriority.UseFont = false;
            this.xrl_DT_COQUAN.StylePriority.UseTextAlignment = false;
            this.xrl_DT_COQUAN.Text = "CQ: ";
            this.xrl_DT_COQUAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_DT_NHA
            // 
            this.xrl_DT_NHA.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DT_NHA.LocationFloat = new DevExpress.Utils.PointFloat(353.5415F, 253F);
            this.xrl_DT_NHA.Name = "xrl_DT_NHA";
            this.xrl_DT_NHA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DT_NHA.SizeF = new System.Drawing.SizeF(171.8747F, 23F);
            this.xrl_DT_NHA.StylePriority.UseFont = false;
            this.xrl_DT_NHA.StylePriority.UseTextAlignment = false;
            this.xrl_DT_NHA.Text = "NR: ";
            this.xrl_DT_NHA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_DI_DONG
            // 
            this.xrl_DI_DONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DI_DONG.LocationFloat = new DevExpress.Utils.PointFloat(525.4162F, 253F);
            this.xrl_DI_DONG.Name = "xrl_DI_DONG";
            this.xrl_DI_DONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DI_DONG.SizeF = new System.Drawing.SizeF(246.8344F, 23F);
            this.xrl_DI_DONG.StylePriority.UseFont = false;
            this.xrl_DI_DONG.StylePriority.UseTextAlignment = false;
            this.xrl_DI_DONG.Text = "DĐ: ";
            this.xrl_DI_DONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_HT_TUYEN
            // 
            this.xrl_HT_TUYEN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HT_TUYEN.LocationFloat = new DevExpress.Utils.PointFloat(0F, 394.5415F);
            this.xrl_HT_TUYEN.Name = "xrl_HT_TUYEN";
            this.xrl_HT_TUYEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HT_TUYEN.SizeF = new System.Drawing.SizeF(246.2487F, 22.99994F);
            this.xrl_HT_TUYEN.StylePriority.UseFont = false;
            this.xrl_HT_TUYEN.StylePriority.UseTextAlignment = false;
            this.xrl_HT_TUYEN.Text = "16. Hình thức tuyển dụng: (v)  ";
            this.xrl_HT_TUYEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TON_GIAO
            // 
            this.xrl_TON_GIAO.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TON_GIAO.LocationFloat = new DevExpress.Utils.PointFloat(341.2468F, 138.0001F);
            this.xrl_TON_GIAO.Name = "xrl_TON_GIAO";
            this.xrl_TON_GIAO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TON_GIAO.SizeF = new System.Drawing.SizeF(309.3303F, 22.99994F);
            this.xrl_TON_GIAO.StylePriority.UseFont = false;
            this.xrl_TON_GIAO.StylePriority.UseTextAlignment = false;
            this.xrl_TON_GIAO.Text = "8.Tôn giáo: ";
            this.xrl_TON_GIAO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_TUYEN_CHINH
            // 
            this.xrl_NGAY_TUYEN_CHINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_TUYEN_CHINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 486.5414F);
            this.xrl_NGAY_TUYEN_CHINH.Multiline = true;
            this.xrl_NGAY_TUYEN_CHINH.Name = "xrl_NGAY_TUYEN_CHINH";
            this.xrl_NGAY_TUYEN_CHINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_TUYEN_CHINH.SizeF = new System.Drawing.SizeF(224.5824F, 23F);
            this.xrl_NGAY_TUYEN_CHINH.StylePriority.UseFont = false;
            this.xrl_NGAY_TUYEN_CHINH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_TUYEN_CHINH.Text = "21. Ngày tuyển dụng chính thức:";
            this.xrl_NGAY_TUYEN_CHINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_TUYEN_DAU
            // 
            this.xrl_NGAY_TUYEN_DAU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_TUYEN_DAU.LocationFloat = new DevExpress.Utils.PointFloat(0F, 371.5414F);
            this.xrl_NGAY_TUYEN_DAU.Name = "xrl_NGAY_TUYEN_DAU";
            this.xrl_NGAY_TUYEN_DAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_TUYEN_DAU.SizeF = new System.Drawing.SizeF(173.333F, 23.00003F);
            this.xrl_NGAY_TUYEN_DAU.StylePriority.UseFont = false;
            this.xrl_NGAY_TUYEN_DAU.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_TUYEN_DAU.Text = "15. Ngày tuyển đầu tiên:   ";
            this.xrl_NGAY_TUYEN_DAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_HO_KHAU
            // 
            this.xrl_HO_KHAU.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HO_KHAU.LocationFloat = new DevExpress.Utils.PointFloat(0F, 207.0001F);
            this.xrl_HO_KHAU.Name = "xrl_HO_KHAU";
            this.xrl_HO_KHAU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HO_KHAU.SizeF = new System.Drawing.SizeF(775.9998F, 23F);
            this.xrl_HO_KHAU.StylePriority.UseFont = false;
            this.xrl_HO_KHAU.StylePriority.UseTextAlignment = false;
            this.xrl_HO_KHAU.Text = "10. Hộ khẩu thường trú: ";
            this.xrl_HO_KHAU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(775.9999F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "I. THÔNG TIN HỒ SƠ";
            // 
            // xrl_DAN_TOC
            // 
            this.xrl_DAN_TOC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_DAN_TOC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 138F);
            this.xrl_DAN_TOC.Name = "xrl_DAN_TOC";
            this.xrl_DAN_TOC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_DAN_TOC.SizeF = new System.Drawing.SizeF(341.2468F, 23F);
            this.xrl_DAN_TOC.StylePriority.UseFont = false;
            this.xrl_DAN_TOC.StylePriority.UseTextAlignment = false;
            this.xrl_DAN_TOC.Text = "7. Dân tộc: ";
            this.xrl_DAN_TOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NOI_O_HIENNAY
            // 
            this.xrl_NOI_O_HIENNAY.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NOI_O_HIENNAY.LocationFloat = new DevExpress.Utils.PointFloat(0F, 230F);
            this.xrl_NOI_O_HIENNAY.Name = "xrl_NOI_O_HIENNAY";
            this.xrl_NOI_O_HIENNAY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NOI_O_HIENNAY.SizeF = new System.Drawing.SizeF(775.9996F, 23F);
            this.xrl_NOI_O_HIENNAY.StylePriority.UseFont = false;
            this.xrl_NOI_O_HIENNAY.StylePriority.UseTextAlignment = false;
            this.xrl_NOI_O_HIENNAY.Text = "11. Nơi ở hiện nay: ";
            this.xrl_NOI_O_HIENNAY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TEN_KHAC
            // 
            this.xrl_TEN_KHAC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TEN_KHAC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 69F);
            this.xrl_TEN_KHAC.Name = "xrl_TEN_KHAC";
            this.xrl_TEN_KHAC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TEN_KHAC.SizeF = new System.Drawing.SizeF(650.5771F, 23.00002F);
            this.xrl_TEN_KHAC.StylePriority.UseFont = false;
            this.xrl_TEN_KHAC.StylePriority.UseTextAlignment = false;
            this.xrl_TEN_KHAC.Text = "4. Tên gọi khác: ";
            this.xrl_TEN_KHAC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_BI_DANH
            // 
            this.xrl_BI_DANH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_BI_DANH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 92.00002F);
            this.xrl_BI_DANH.Name = "xrl_BI_DANH";
            this.xrl_BI_DANH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_BI_DANH.SizeF = new System.Drawing.SizeF(650.5771F, 23F);
            this.xrl_BI_DANH.StylePriority.UseFont = false;
            this.xrl_BI_DANH.StylePriority.UseTextAlignment = false;
            this.xrl_BI_DANH.Text = "5. Bí danh:  ";
            this.xrl_BI_DANH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_TINH_THANH
            // 
            this.xrl_TINH_THANH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_TINH_THANH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 161F);
            this.xrl_TINH_THANH.Name = "xrl_TINH_THANH";
            this.xrl_TINH_THANH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TINH_THANH.SizeF = new System.Drawing.SizeF(152.0832F, 23F);
            this.xrl_TINH_THANH.StylePriority.UseFont = false;
            this.xrl_TINH_THANH.StylePriority.UseTextAlignment = false;
            this.xrl_TINH_THANH.Text = "9. Quê quán:";
            this.xrl_TINH_THANH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_HO_TEN
            // 
            this.xrl_HO_TEN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_HO_TEN.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23F);
            this.xrl_HO_TEN.Name = "xrl_HO_TEN";
            this.xrl_HO_TEN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_HO_TEN.SizeF = new System.Drawing.SizeF(650.5792F, 23F);
            this.xrl_HO_TEN.StylePriority.UseFont = false;
            this.xrl_HO_TEN.StylePriority.UseTextAlignment = false;
            this.xrl_HO_TEN.Text = "1. Họ và tên khai sinh:  ";
            this.xrl_HO_TEN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrl_NGAY_SINH
            // 
            this.xrl_NGAY_SINH.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrl_NGAY_SINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46F);
            this.xrl_NGAY_SINH.Name = "xrl_NGAY_SINH";
            this.xrl_NGAY_SINH.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_NGAY_SINH.SizeF = new System.Drawing.SizeF(100.8333F, 23F);
            this.xrl_NGAY_SINH.StylePriority.UseFont = false;
            this.xrl_NGAY_SINH.StylePriority.UseTextAlignment = false;
            this.xrl_NGAY_SINH.Text = "2. Ngày sinh:  ";
            this.xrl_NGAY_SINH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(657.9557F, 23.00002F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(105F, 138F);
            this.xrPictureBox1.StylePriority.UseBorders = false;
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
            this.xrsub_HOSO_QH_GIADINH});
            this.Detail1.HeightF = 89.99995F;
            this.Detail1.Name = "Detail1";
            this.Detail1.StylePriority.UseTextAlignment = false;
            this.Detail1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrsub_HOSO_QH_GIADINH
            // 
            this.xrsub_HOSO_QH_GIADINH.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrsub_HOSO_QH_GIADINH.Name = "xrsub_HOSO_QH_GIADINH";
            this.xrsub_HOSO_QH_GIADINH.ReportSource = this.sub_Quanhe_Giadinh1;
            this.xrsub_HOSO_QH_GIADINH.SizeF = new System.Drawing.SizeF(775.9977F, 43.99998F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrl_TEN_HETHONG,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
            this.ReportHeader.HeightF = 158F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrl_TEN_HETHONG
            // 
            this.xrl_TEN_HETHONG.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrl_TEN_HETHONG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrl_TEN_HETHONG.LocationFloat = new DevExpress.Utils.PointFloat(0F, 122.5F);
            this.xrl_TEN_HETHONG.Name = "xrl_TEN_HETHONG";
            this.xrl_TEN_HETHONG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrl_TEN_HETHONG.SizeF = new System.Drawing.SizeF(775.9998F, 20.99998F);
            this.xrl_TEN_HETHONG.StylePriority.UseBorders = false;
            this.xrl_TEN_HETHONG.StylePriority.UseFont = false;
            this.xrl_TEN_HETHONG.StylePriority.UseTextAlignment = false;
            this.xrl_TEN_HETHONG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 97.50001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(775.9998F, 20.99996F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "HỒ SƠ NHÂN VIÊN";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.00001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(775.9998F, 20.99998F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Độc lập - Tự do -Hạnh phúc";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(775.9998F, 23F);
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
            this.xrLabel113});
            this.ReportFooter.HeightF = 179F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel115
            // 
            this.xrLabel115.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(472.4569F, 62.5F);
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
            this.xrtngayketxuat.LocationFloat = new DevExpress.Utils.PointFloat(472.4569F, 10.0001F);
            this.xrtngayketxuat.Name = "xrtngayketxuat";
            this.xrtngayketxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtngayketxuat.SizeF = new System.Drawing.SizeF(276.8737F, 23F);
            this.xrtngayketxuat.StylePriority.UseFont = false;
            this.xrtngayketxuat.Text = "Hà Nội, ngày ........tháng..........năm.............";
            // 
            // xrLabel113
            // 
            this.xrLabel113.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel113.LocationFloat = new DevExpress.Utils.PointFloat(472.4569F, 37.5F);
            this.xrLabel113.Name = "xrLabel113";
            this.xrLabel113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel113.SizeF = new System.Drawing.SizeF(276.8737F, 23F);
            this.xrLabel113.StylePriority.UseFont = false;
            this.xrLabel113.StylePriority.UseTextAlignment = false;
            this.xrLabel113.Text = "PHÒNG HC NHÂN SỰ";
            this.xrLabel113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(649.9583F, 76.99998F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(126.0417F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // rp_EmployeeDetail
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
            this.Margins = new System.Drawing.Printing.Margins(40, 11, 49, 51);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.sub_Quanhe_Giadinh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
