using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CBInfo
/// </summary>
public class DM_CBInfo
{
    public DM_CBInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public decimal PR_KEY { get; set; }
    public string MA_CB { get; set; }
    public string HO_TEN { get; set; }
    public string TEN_CB { get; set; }
    public string MA_PHONG { get; set; }
    public string MA_TO { get; set; }
    public string MA_CONGTRINH { get; set; }
    public string MA_DONVI { get; set; }
    public string GIOI_TINH { get; set; }
    public DateTime? NGAY_SINH { get; set; }
    public string DIA_CHI { get; set; }
    public string TEN_LOAI_HDONG { get; set; }
    public string TEN_TRINHDO { get; set; }
    public string DIENTHOAI { get; set; }
    public string EMAIL { get; set; }
    public string CHUCVU { get; set; }
    /// <summary>
    /// Có thể là đơn vị, phòng, tổ
    /// </summary>
    public string DonViCongTac { get; set; }

    public string HO_CB { set; get; }

    
    public string MA_GIOITINH { set; get; }
    public decimal? HS_LUONG { set; get; }
    public decimal? PHUCAP { set; get; }
    public decimal? PHUCAP_KHAC { set; get; }
    public decimal? HS_DN { set; get; }
    public decimal? MUC_LUONG { set; get; }
    public decimal? LUONG_BHXH { set; get; }
    public string BAC_LUONG { set; get; }
    public DateTime? NGAY_HUONG_LUONG { set; get; }
    public DateTime? NGAY_HUONG_LUONG_NB { set; get; }
    public string BAC_LUONG_NB { set; get; }


    public string MA_CHUCVU { set; get; }

    public string MA_NGACH { set; get; }
    public string MA_CHUYENNGANH { set; get; }
    public string MA_TRINHDO { set; get; }
    public string MA_NUOC { set; get; }
    public string MA_TINHTHANH { set; get; }
    public string SDT { set; get; }

    public string DI_DONG { set; get; }
    public string SO_TAI_KHOAN { set; get; }
    public string CMND { set; get; }
    public string SO_SOBH { set; get; }
    public string MA_NOICAP_BHXH { set; get; }
    public string MA_NH { set; get; }
    public bool? DA_NGHI { set; get; }
    public bool DONG_BHXH { set; get; }
    public string MA_LOAI_HDONG { set; get; }
    public string MA_SO_THUE_CB { set; get; }
    public decimal? SOTIEN_GIAMTRU { set; get; }
    public decimal? SONGUOI_PHUTHUOC { set; get; }
    public bool? CHK_TRUYTHUBH { set; get; }
    public DateTime? NGAY_NGHI { set; get; }
    public string LYDO_NGHI { set; get; }
    public DateTime? DATE_CREATE { set; get; }
    public string USERNAME { set; get; }

    public decimal? LUONG_CB { set; get; }
}