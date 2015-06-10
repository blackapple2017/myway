using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SystemConfigParameter
/// </summary>
public class SystemConfigParameter
{
	public SystemConfigParameter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public const string EMAIL = "EMAIL";
    public const string PASSWORD_EMAIL = "PASSWORD";
    public const string MENU_TYPE = "MENU_TYPE";
    public const string COMPANY_NAME = "COMPANY_NAME";
    public const string COMPANY_ADDRESS = "COMPANY_ADDRESS";
    public const string COMPANY_MASOTHUE = "COMPANY_MASOTHUE";
    public const string COMPANY_DIENTHOAI = "COMPANY_DIENTHOAI";
    public const string COMPANY_FAX = "COMPANY_FAX";
    public const string COMPANY_EMAIL = "COMPANY_EMAIL";
    public const string CITY = "CITY";
    public const string PREFIX = "PREFIX";
    public const string NUMBER_OF_CHARACTER = "NUMBER_OF_CHARACTER";

    public const string EXCEL_FORMAT_DOC = "DOC";
    public const string EXCEL_FORMAT_NGANG = "NGANG";
    public const string PHANCA_TYPE_THANG = "THANG";
    public const string PHANCA_TYPE_BOPHAN = "BOPHAN";

    public const string BAO_HET_HAN_HOP_DONG = "HETHANHOPDONG";

    public const string LOGO_COMPANY = "LOGOCOMPANY";

    #region cấu hình sinh số quyết định
    public const string SUFFIX_SOHOPDONG = "SUFFIX_SOHOPDONG";
    public const string SUFFIX_SOQDKHENTHUONG = "SUFFIX_SOQDKHENTHUONG";
    public const string SUFFIX_SOQDKYLUAT = "SUFFIX_SOQDKYLUAT";
    public const string SUFFIX_SOQDCONGTAC = "SUFFIX_SOQDCONGTAC";
    public const string SUFFIX_SOQDDIEUCHUYEN = "SUFFIX_SOQDDIEUCHUYEN";
    public const string SUFFIX_SOQDLUONG = "SUFFIX_SOQDLUONG";
    #endregion
    #region  cấu hình sinh chữ ký báo cáo
    public const string SuDungTenDangNhap = "SuDungTenDangNhap";
    public const string chuky1 = "chuky1";
    public const string chuky2 = "chuky2";
    public const string chuky3 = "chuky3";
    public const string chuky4 = "chuky4";
    #endregion
    #region tham số điều kiện chấm công
    public const string SO_PHUT_TOI_THIEU_DUOC_TINH_LAM_THEM = "MINIMIZE_MINUTE_MEAN_OT";
    public const string SO_PHUT_DI_MUON_COI_LA_NGHI = "MIN_LATE_MEAN_ABSENCE";
    public const string SO_PHUT_CHO_PHEP_VE_SOM = "ALLOW_GOHOME_EARLY";
    public const string SO_PHUT_CHO_PHEP_DI_MUON = "ALLOW_LATE";
    public const string HINH_THUC_LAM_CN = "WORKING_SUNDAY";
    public const string HINH_THUC_LAM_T7 = "WORKING_SATURDAY";
    public const string KET_THUC_LAM_CHIEU = "END_WORKING_PM";
    public const string BAT_DAU_LAM_CHIEU = "START_WORKING_PM";
    public const string KET_THUC_LAM_SANG = "END_WORKING_SA";
    public const string BAT_DAU_LAM_SANG = "START_WORKING_SA";
    public const string CHO_PHEP_LAM_THEM_DAU_GIO = "ALLOW_OT_AT_FIRSTTIME";

  //  public const string CONG_CHUAN = "CONG_CHUAN";
    #endregion

    #region các cột hiển thị ở bảng chấm công
    public const string OM_KHONG_LUONG = "OM_KHONG_LUONG";
    public const string OM_CO_LUONG = "OM_CO_LUONG";
    public const string DIEU_DUONG = "DIEU_DUONG";
    public const string PHEP = "PHEP";
    public const string TNLD = "TNLD";
    public const string CHEDO = "CHEDO";
    public const string HOC = "HOC";
    public const string QSU = "QSU";
    public const string VHTT = "VHTT";
    public const string NGHI_LE = "NGHI_LE";
    public const string NGHI_CO_LUONG = "NGHI_CO_LUONG";
    public const string NGH_KHONG_LUONG = "NGH_KHONG_LUONG";
    public const string TQUAN = "TQUAN";
    public const string NGHI_BU = "NGHI_BU";
    public const string LAM_BU = "LAM_BU";
    public const string NGHI_VO_LY_DO = "NGHI_VO_LY_DO";
    public const string SO_PHUT_OT = "SO_PHUT_OT";
    public const string SO_PHUT_OT_NGAYNGHI = "SO_PHUT_OT_NGAYNGHI";
    public const string SOPHUT_DIMUON = "SOPHUT_DIMUON";
    public const string SOPHUT_VESOM = "SOPHUT_VESOM";
    #endregion

    //Lưu số ngày phép theo quy định của nhà nước
    public const string SO_NGAY_PHEP = "SO_NGAY_PHEP";

    //lưu thông tin lương cơ bản theo quy định của nhà nước
    public const string LUONG_CB = "LUONG_CB";

    #region cấu hình các cột hiển thị trong quyết định lương
    public const string QDL_LUONGCUNG = "QDL_LUONGCUNG";
    public const string QDL_HESOLUONG = "QDL_HESOLUONG";
    public const string QDL_PHANTRAMHL = "QDL_PHANTRAMHL";
    public const string QDL_LOAILUONG = "QDL_LOAILUONG";
    public const string QDL_LUONGDONGBHXH = "QDL_LUONGDONGBHXH";
    public const string QDL_BACLUONG = "QDL_BACLUONG";
    public const string QDL_BACLUONGNB = "QDL_BACLUONGNB";
    public const string QDL_NGAYHL = "QDL_NGAYHL";
    public const string QDL_NGAYHLNB = "QDL_NGAYHLNB";
    public const string QDL_SOQD = "QDL_SOQD";
    public const string QDL_NGAYQD = "QDL_NGAYQD";
    public const string QDL_NGAYHIEULUC = "QDL_NGAYHIEULUC";
    public const string QDL_NGAYHETHIEULUC = "QDL_NGAYHETHIEULUC";
    public const string QDL_NGUOIQD = "QDL_NGUOIQD";
    #endregion

    #region cấu hình các cột hiển thị trên grid của danh sách ca
    public const string DSC_GIOVAO = "DSC_GIOVAO";
    public const string DSC_GIORA = "DSC_GIORA";
    public const string DSC_SOGIOLAM = "DSC_SOGIOLAM";
    public const string DSC_CHOPHEPDIMUON = "DSC_CHOPHEPDIMUON";
    public const string DSC_CHOPHEPVESOM = "DSC_CHOPHEPVESOM";
    public const string DSC_BATDAUTINHLAMTHEMDAUGIO = "DSC_BATDAUTINHLAMTHEMDAUGIO";
    public const string DSC_BATDAULAMTHEMCUOIGIO = "DSC_BATDAULAMTHEMCUOIGIO";
    public const string DSC_APDUNGTUNGAY = "DSC_APDUNGTUNGAY";
    public const string DSC_APDUNGDENNGAY = "DSC_APDUNGDENNGAY";

    public const string DSC_QUETTHEDAUCA = "DSC_QUETTHEDAUCA";
    public const string DSC_QUETTHENGHIDAUCA = "DSC_QUETTHENGHIDAUCA";
    public const string DSC_QUETTHEVAOCASAU = "DSC_QUETTHEVAOCASAU";
    public const string DSC_QUETTHECUOICA = "DSC_QUETTHECUOICA";
    public const string DSC_PHUCAPCA = "DSC_PHUCAPCA";
    public const string DSC_MUCLUONGCA = "DSC_MUCLUONGCA";
    public const string DSC_NGAYAPDUNG = "DSC_NGAYAPDUNG";
    public const string DSC_NGAYTAO = "DSC_NGAYTAO";
    public const string DSC_LOAICA = "DSC_LOAICA";
    #endregion

    #region cấu hình chấm công
    public const string CHAMCONG_EXCEL_FORMAT = "CHAMCONG_EXCEL_FORMAT";
    public const string CHAMCONG_PHANCA_TYPE = "CHAMCONG_PHANCA_TYPE";
    #endregion
}