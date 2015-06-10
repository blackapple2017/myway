using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using DAL;
using System.Data;

public partial class Modules_HTMLReport_Default : System.Web.UI.Page
{
    private string HO_TEN = "##{HO_TEN}##";
    private string MA_CB = "##{MA_CB}##";
    private string CMTND = "##{CMTND}##";
    private string DCTT = "##{DCTT}##";
    private string NGHE_NGHIEP = "##{NGHE_NGHIEP}##";
    private string LamTaiViTri = "##{LamTaiViTri}##";
    private string TU_NGAY = "##{TU_NGAY}##";
    private string DEN_NGAY = "##{DEN_NGAY}##";
    private string LUONG_CO_BAN = "##{LUONG_CO_BAN}##";
    private string THOI_GIAN_THU_VIEC = "##{THOI_GIAN_THU_VIEC}##";
    private string NGAY_HIEN_TAI = "##{NGAY_HT}##";
    private string NGAY_BN = "##{NGAY_BN}##";
    private string SOQD = "##{SOQD}##";
    private string LAMVIECTAIBOPHAN = "##{LAMVIECTAIBOPHAN}##";
    private string THOI_HAN_HD = "##{S}##";
    private string MASO_THUE = "##{MASO_THUE}##";
    private string CHUC_VU = "##{CHUC_VU}##";
    private string PHONG_BAN = "##{PHONG_BAN}##";
    private string NGAY_THOI_VIEC = "##{NGAY_THOI_VIEC}##";
    private string HO_TEN_B = "##{HO_TEN_B}##";
    private string QT = "##{QT}##";
    private string NGAY_SINH = "##{NGAY_SINH}##";
    private string NOI_SINH = "##{NOI_SINH}##";
    private string DIA_CHI = "##{DIA_CHI}##";
    private string CMND = "##{CMND}##";
    private string NGAY_CAP = "##{NGAY_CAP}##";
    private string NOI_CAP = "##{NOI_CAP}##";
    private string BD_HDONG = "##{BD_HDONG}##";
    private string KT_HDONG = "##{KT_HDONG}##";
    private string BD_TV_HD = "##{BD_TV_HD}##";
    private string KT_TV_HD = "##{KT_TV_HD}##";
    private string VT_MOI = "##{VT_MOI}##";
    private string DAY = "{D}";
    private string MONTH = "{M}";
    private string YEAR = "{Y}";
    private string GIAMDOC = "##{GIAM_DOC}##";
    private string NOILAMVIEC = "##{NOILAMVIEC}##";
    protected void Page_Load(object sender, EventArgs e)
    {
        ucChooseEmployee1.AfterClickAcceptButton += ucChooseEmployee1_AfterClickAcceptButton;
    }

    protected void cbxQD_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxQD_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("MauBieuQuyetDinh", true);
        cbxQD_Store.DataBind();
    }
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        if (ucChooseEmployee1.SelectedRow.Count() > 0)
        {
            hdfMaCB.Text = ucChooseEmployee1.SelectedRow[0].RecordID;
            //xử lý 
            UpdateFillReport();
        }
    }
    //Xu ly
    void UpdateFillReport()
    {
        string filename1 = cbxQD.SelectedItem.Value;
        if (filename1 == "HopDongDaoTaoMoi.html")
        {
            BindHopDongDaoTaoMoi();

        }
        else if (filename1 == "HopDongLaoDongKD.html")
        {
            BindHopDongLaoDongKD();

        }
        else if (filename1 == "HopDongLaoDongVP.html")
        {
            BindHopDongLaoDongVP();
        }
        else if (filename1 == "HopDongThoiVu.html")
        {
            BindHopDongThoiVu();
        }
        else if (filename1 == "QuyetDinhNghiViec.html")
        {
            //QuyetDinhNghiViec
            BindQuyetDinhNghiViec();
        }
        else if (filename1 == "QuyetDinhThuViec.html")
        {
            BindQuyetDinhThuViec();
        }
        else
        {

            //QuyetDinhThuyenChuyen
            BindQuyetDinhThuThuyenChuyen();
        }
    }
    protected void FillRePort(object sender, DirectEventArgs e)
    {
        if (string.IsNullOrEmpty(hdfMaCB.Text))
        {
            return;
        }
        string filename1 = cbxQD.SelectedItem.Value;
        if (filename1 == "HopDongDaoTaoMoi.html")
        {
            BindHopDongDaoTaoMoi();

        }
        else if (filename1 == "HopDongLaoDongKD.html")
        {
            BindHopDongLaoDongKD();

        }
        else if (filename1 == "HopDongLaoDongVP.html")
        {
            BindHopDongLaoDongVP();
        }
        else if (filename1 == "HopDongThoiVu.html")
        {
            BindHopDongThoiVu();
        }
        else if (filename1 == "QuyetDinhNghiViec.html")
        {
            //QuyetDinhNghiViec
            BindQuyetDinhNghiViec();
        }
        else if (filename1 == "QuyetDinhThuViec.html")
        {
            BindQuyetDinhThuViec();
        }
        else
        {

            //QuyetDinhThuyenChuyen
            BindQuyetDinhThuThuyenChuyen();
        }
        //lấy thông tin cần fill
        //htmlEditor.Value = rs.Replace(HO_TEN, "Lê Văn Anh").Replace(MASO_THUE, "12345").Replace(CHUC_VU, "Nhan vien").Replace(PHONG_BAN, "HCNS").Replace(NGAY_THOI_VIEC, "20/05/2014");
    }
    protected void Printer_Click(object sender, DirectEventArgs e)
    {
        string value = htmlEditor.Value.ToString();
        while (value.IndexOf("redColor___") > 0)
        {
            value = value.Replace("redColor___", "");
        }
        Session["report"] = value;
        RM.RegisterClientScriptBlock("redirect", "window.open('Printed.aspx','_blank')");
    }

    private string GetContent(string fileName)
    {
        return SoftCore.Util.GetInstance().ReadFile(Server.MapPath("~/Modules/HTMLReport/Template/" + fileName));
    }

    #region binding data
    //De nghi Mr. Ha lam dung file HTML va dung ham bind nhe :3
    //Nham cai no sang cai kia
    public void BindHopDongDaoTaoMoi()
    {
        try
        {
            string content = GetContent("HopDongDaoTaoMoi.html");
            HoSoInfo hs = new HoSoController().getHoSoReportHopDong(hdfMaCB.Text);
            if (hs != null)
            {
                DateTime today = DateTime.Now;
                string rs = content.Replace(HO_TEN_B, string.IsNullOrEmpty(hs.HOTEN) ? "..." : hs.HOTEN.ToString()).
                                    Replace(QT, hs.TENNUOC).
                                    Replace(NGAY_SINH, hs.NGAYSINH == null ? "..." : hs.NGAYSINH.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_SINH, hs.NOISINH).
                                    Replace(NGHE_NGHIEP, hs.TENCHUCVU).
                                    Replace(CMND, string.IsNullOrEmpty(hs.SOCMND) ? " " : hs.SOCMND).
                                    Replace(DIA_CHI, hs.DIACHILH).
                                    Replace(NGAY_CAP, hs.NGAYCAPCMND == null ? "..." : hs.NGAYCAPCMND.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_CAP, hs.NOICAPCMNTT).
                                    Replace(BD_HDONG, hs.NGAYBATDAUHOPDONG == null ? "..." : hs.NGAYBATDAUHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(KT_HDONG, hs.NGAYKETTHUCHOPDONG == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(BD_TV_HD, hs.NGAYTUYENDTIEN == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(VT_MOI, " " + hs.TENCHUCVUMOI).
                                    Replace(KT_TV_HD, string.IsNullOrEmpty(hs.NGAYTUYENDTIEN.ToString()) ? "..." : hs.NGAYTUYENDTIEN.Value.Day + "/" + hs.THOIHANHOPDONG + hs.NGAYTUYENDTIEN.Value.Month + "/" + hs.NGAYTUYENDTIEN.Value.Year).
                                    Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).
                                    Replace(GIAMDOC, " " + new HoSoController().GetNameTGD()).
                                    Replace(NGAY_HIEN_TAI, today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString()).
                                    Replace(LUONG_CO_BAN, hs.MUCLUONG.ToString() == "" ? "......" : hs.MUCLUONG.ToString());
                htmlEditor.Value = rs;

            }
            else
            {
                htmlEditor.Value = content;
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void BindHopDongLaoDongKD()
    {
        try
        {
            string content = GetContent("HopDongLaoDongKD.html");
            ReportController rc = new ReportController();
            string tengiamdoc = rc.GetDirectorName(Session["MaDonVi"].ToString(), "");
            HoSoInfo hs = new HoSoController().getHoSoReportHopDong(hdfMaCB.Text);
            if (hs != null)
            {
                DateTime today = DateTime.Now;
                string rs = content.Replace(HO_TEN_B, string.IsNullOrEmpty(hs.HOTEN) ? "..." : hs.HOTEN.ToString()).
                                    Replace(QT, hs.TENNUOC).
                                    Replace(NGAY_SINH, hs.NGAYSINH == null ? "..." : hs.NGAYSINH.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_SINH, hs.NOISINH).
                                    Replace(NGHE_NGHIEP, hs.TENCHUCVU).
                                    Replace(CMND, string.IsNullOrEmpty(hs.SOCMND) ? " " : hs.SOCMND).
                                    Replace(DIA_CHI, hs.DIACHILH).
                                    Replace(NGAY_CAP, hs.NGAYCAPCMND == null ? "..." : hs.NGAYCAPCMND.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_CAP, hs.NOICAPCMNTT).
                                    Replace(BD_HDONG, hs.NGAYBATDAUHOPDONG == null ? "..." : hs.NGAYBATDAUHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(KT_HDONG, hs.NGAYKETTHUCHOPDONG == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(BD_TV_HD, hs.NGAYTUYENDTIEN == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(VT_MOI, " " + hs.TENCHUCVUMOI).
                                    Replace(KT_TV_HD, string.IsNullOrEmpty(hs.NGAYTUYENDTIEN.ToString()) ? "..." : hs.NGAYTUYENDTIEN.Value.Day + "/" + hs.THOIHANHOPDONG + hs.NGAYTUYENDTIEN.Value.Month + "/" + hs.NGAYTUYENDTIEN.Value.Year).
                                    Replace(THOI_HAN_HD, string.IsNullOrEmpty(hs.THOIHANHOPDONG.ToString()) ? "...." : hs.THOIHANHOPDONG.ToString()).
                                    Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).
                                    Replace(GIAMDOC, " " + new HoSoController().GetNameTGD()).
                                    Replace(NGAY_HIEN_TAI, today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString()).
                                    Replace(LUONG_CO_BAN, hs.MUCLUONG.ToString() == "" ? "......" : hs.MUCLUONG.ToString().Replace(LUONG_CO_BAN, hs.MUCLUONG.ToString() == null ? "......" : hs.MUCLUONG.ToString()));
                htmlEditor.Value = rs;

            }
            else
            {
                htmlEditor.Value = content;
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void BindHopDongLaoDongVP()
    {
        try
        {
            string content = GetContent("HopDongLaoDongKD.html");
            ReportController rc = new ReportController();
            string tengiamdoc = rc.GetDirectorName(Session["MaDonVi"].ToString(), "");
            HoSoInfo hs = new HoSoController().getHoSoReportHopDong(hdfMaCB.Text);
            if (hs != null)
            {
                DateTime today = DateTime.Now;
                string rs = content.Replace(HO_TEN_B, string.IsNullOrEmpty(hs.HOTEN) ? "..." : hs.HOTEN.ToString()).
                                    Replace(QT, hs.TENNUOC).
                                    Replace(NGAY_SINH, hs.NGAYSINH == null ? "..." : hs.NGAYSINH.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_SINH, hs.NOISINH).
                                    Replace(NGHE_NGHIEP, hs.TENCHUCVU).
                                    Replace(CMND, string.IsNullOrEmpty(hs.SOCMND) ? " " : hs.SOCMND).
                                    Replace(DIA_CHI, hs.DIACHILH).
                                    Replace(NGAY_CAP, hs.NGAYCAPCMND == null ? "..." : hs.NGAYCAPCMND.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_CAP, hs.NOICAPCMNTT).
                                    Replace(BD_HDONG, hs.NGAYBATDAUHOPDONG == null ? "..." : hs.NGAYBATDAUHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(KT_HDONG, hs.NGAYKETTHUCHOPDONG == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(BD_TV_HD, hs.NGAYTUYENDTIEN == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(VT_MOI, " " + hs.TENCHUCVUMOI).
                                    Replace(KT_TV_HD, string.IsNullOrEmpty(hs.NGAYTUYENDTIEN.ToString()) ? "..." : hs.NGAYTUYENDTIEN.Value.Day + "/" + hs.THOIHANHOPDONG + hs.NGAYTUYENDTIEN.Value.Month + "/" + hs.NGAYTUYENDTIEN.Value.Year).
                                    Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).
                                    Replace(LUONG_CO_BAN, hs.MUCLUONG.ToString() == "" ? "......" : hs.MUCLUONG.ToString()).
                                    Replace(THOI_HAN_HD, string.IsNullOrEmpty(hs.THOIHANHOPDONG.ToString()) ? "...." : hs.THOIHANHOPDONG.ToString()).
                                    Replace(NGAY_HIEN_TAI, today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString()).
                                    Replace(GIAMDOC, " " + new HoSoController().GetNameTGD());
                htmlEditor.Value = rs;

            }
            else
            {
                htmlEditor.Value = content;
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }

    }
    public void BindHopDongThoiVu()
    {
        try
        {
            string content = GetContent("HopDongThoiVu.html");
            ReportController rc = new ReportController();
            string tengiamdoc = rc.GetDirectorName(Session["MaDonVi"].ToString(), "");
            HoSoInfo hs = new HoSoController().getHoSoReportHopDong(hdfMaCB.Text);
            if (hs != null)
            {
                DateTime today = DateTime.Now;
                string rs = content.Replace(HO_TEN_B, string.IsNullOrEmpty(hs.HOTEN) ? "..." : hs.HOTEN.ToString()).
                                    Replace(QT, hs.TENNUOC).
                                    Replace(NGAY_SINH, hs.NGAYSINH == null ? "..." : hs.NGAYSINH.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_SINH, hs.NOISINH).
                                    Replace(NGHE_NGHIEP, hs.TENCHUCVU).
                                    Replace(CMND, string.IsNullOrEmpty(hs.SOCMND) ? " " : hs.SOCMND).
                                    Replace(DIA_CHI, hs.DIACHILH).
                                    Replace(NGAY_CAP, hs.NGAYCAPCMND == null ? "..." : hs.NGAYCAPCMND.Value.ToString("dd/MM/yyyy")).
                                    Replace(NOI_CAP, hs.NOICAPCMNTT).
                                    Replace(BD_HDONG, hs.NGAYBATDAUHOPDONG == null ? "..." : hs.NGAYBATDAUHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(KT_HDONG, hs.NGAYKETTHUCHOPDONG == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(BD_TV_HD, hs.NGAYTUYENDTIEN == null ? "..." : hs.NGAYKETTHUCHOPDONG.Value.ToString("dd/MM/yyyy")).
                                    Replace(VT_MOI, " " + hs.TENCHUCVUMOI).
                                    Replace(KT_TV_HD, string.IsNullOrEmpty(hs.NGAYTUYENDTIEN.ToString()) ? "..." : hs.NGAYTUYENDTIEN.Value.Day + "/" + hs.THOIHANHOPDONG + hs.NGAYTUYENDTIEN.Value.Month + "/" + hs.NGAYTUYENDTIEN.Value.Year).
                                    Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).Replace(LUONG_CO_BAN, hs.MUCLUONG.ToString() == null ? "......" : hs.MUCLUONG.ToString()).
                                    Replace(NGAY_HIEN_TAI, today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString()).
                                 Replace(GIAMDOC, " " + new HoSoController().GetNameTGD());
                htmlEditor.Value = rs;

            }
            else
            {
                htmlEditor.Value = content;
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }

    }
    /// <summary>
    /// @Nghia sua
    /// </summary>
    /// 
    private void BindQuyetDinhNghiViec()
    {
        try
        {
            string content = GetContent("QuyetDinhNghiViec.html");
            //hdf
            DateTime today = DateTime.Now;
            HoSoInfo hoso = new HoSoController().getHoSo(hdfMaCB.Text);
            string rs = content.Replace(HO_TEN, hoso.HOTEN).
                                Replace(MASO_THUE, hoso.MSTCANHAN).
                                Replace(CHUC_VU, hoso.TENCHUCVU).
                                Replace(PHONG_BAN, hoso.PHONGBAN).
                                Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).
                                Replace(NGAY_THOI_VIEC, string.IsNullOrEmpty(hoso.NGAYNGHI.ToString()) ? "..." : hoso.NGAYNGHI.Value.ToString("dd/MM/yyyy"));
            htmlEditor.Value = rs;
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// @Nghia
    /// </summary>BindQuyetDinhThuViec
    private void BindQuyetDinhThuViec()
    {
        try
        {
            DateTime today = DateTime.Now;
            string content = GetContent("QuyetDinhThuViec.html");
            //hdf

            HoSoInfo hoso = new HoSoController().getHoSo(hdfMaCB.Text);
            string rs = content.Replace(HO_TEN, hoso.HOTEN).
                                Replace(NGAY_SINH, hoso.NGAYSINH.Value.Day + "/" + hoso.NGAYSINH.Value.Month + "/" + hoso.NGAYSINH.Value.Year).
                                Replace(CMTND, hoso.SOCMND).
                                Replace(DCTT, hoso.DIACHILH).
                                Replace(NGHE_NGHIEP, hoso.TENCHUCVU).
                                Replace(LamTaiViTri, hoso.TENCHUCVU).
                                Replace(TU_NGAY, hoso.NGAYTHUVIEC == null ? "..." : hoso.NGAYTHUVIEC.Value.ToString("dd/MM/yyyy")).
                                Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).
                                Replace(DEN_NGAY, hoso.NGAYNHANCHINHTHUC == null ? "..." : hoso.NGAYNHANCHINHTHUC.Value.ToString("dd/MM/yyyy")).
                                Replace(LUONG_CO_BAN, hoso.LUONGDONGBHXH.ToString()).
                                Replace(THOI_GIAN_THU_VIEC, hoso.THOIGIANTHUVIEC);
            htmlEditor.Value = rs;
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    private void BindQuyetDinhThuThuyenChuyen()
    {
        try
        {
            DateTime today = DateTime.Now;
            string content = GetContent("QuyetDinhThuyenChuyen.html");
            HoSoInfo hs = new HoSoController().getHoSoDieuChuyen(hdfMaCB.Text);
            //DataTable export = DataController.DataHandler.GetInstance().ExecuteDataTable("report_giaydenghithuyenchuyennhansu", "@MaNhanVien", hdfMaCB.Text);
            if (hs != null)
            {

                string rs = content.Replace(HO_TEN, string.IsNullOrEmpty(hs.HOTEN) ? "..." : hs.HOTEN.ToString()).
                                    Replace(CHUC_VU, string.IsNullOrEmpty(hs.TENCHUCVU) ? "..." : hs.TENCHUCVU.ToString()).
                                    Replace(LAMVIECTAIBOPHAN, string.IsNullOrEmpty(hs.MADONVI) ? "..." : hs.MADONVI.ToString()).
                                    Replace(DAY, today.Day.ToString()).Replace(MONTH, today.Month.ToString()).Replace(YEAR, today.Year.ToString()).
                                    Replace(NOILAMVIEC, string.IsNullOrEmpty(hs.TENKHAC) ? "..." : hs.TENKHAC.ToString()).
                                    Replace(NGAY_BN, hs.NGAYBNCHUCVU == null ? "..." : "ngày " + hs.NGAYBNCHUCVU.Value.Day + " tháng " + hs.NGAYBNCHUCVU.Value.Month + " năm " + hs.NGAYBNCHUCVU.Value.Year).
                                    Replace(MA_CB, string.IsNullOrEmpty(hdfMaCB.Text) ? "..." : hdfMaCB.Text);

                htmlEditor.Value = rs;
            }
            else
            {
                htmlEditor.Value = content;
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion
}