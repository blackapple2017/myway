using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportFilter
/// </summary>
 
public class ReportFilterInfoBase //report fillter base. dùng chung cho tất cả các report filter
{
    public string ReportTitle { get; set; }
    public string ChildrenOfDepartmentID { get; set; } //1 dãy mã đơn vị của người dùng đăng nhập vào cách nhau bằng "," ví dụ "01,011,012,...."
    public string SessionDepartmentID { get; set; }//session MaDonVi: vd: "01"
    public string CheckedDepartmentID { get; set; }//Mã bộ phận mà người dùng chọn trên filter ví dụ: "HN001,HN0011,HN0012,DN001,DN0011,DN0013"
    public string CityName { get; set; } //đề nghị bỏ
    public string CompanyName { get; set; } //đề nghị bỏ

    public string Footer1 { get; set; }
    public string Footer2 { get; set; }
    public string Footer3 { get; set; }
    public string Footer4 { get; set; }

    public string Ten1 { get; set; }
    public string Ten2 { get; set; }
    public string Ten3 { get; set; }
    public string Ten4 { get; set; }
}

public class ReportFilterDanhSach : ReportFilterInfoBase
{
    public string MaDonVi { get; set; }
    public string CheckedMaDonVi { get; set; }
    public string ChuyenNganh { get; set; }
    public string TinhThanh { get; set; }
    public string DiaChi { get; set; }
    public string GioiTinh { get; set; } //M F
    public string ChucVu { get; set; }
    public string ViTriCongViec { get; set; }
    public int Nam { get; set; }
    public string TrinhDo { get; set; }//trình độ học vấn 
    public string HopDong { get; set; }
    public string DiDong { get; set; }
    public string Email { get; set; }
    public int DaNghi { get; set; }
    public string ThamNien { get; set; }
    public string SearchKey { get; set; }
}
//sap toi bo?
public class ReportFilterEmployeeProfile : ReportFilterInfoBase
{
    public decimal PrKeyHoSo { get; set; }
    public string MaCB { get; set; }
    public string GioiTinh { get; set; } //M F
    public string ChucVu { get; set; }
    public string ViTriCongViec { get; set; }
    public string CapBac { get; set; }
    public string ChucVuQuanDoi { get; set; }
    public string TrinhDo { get; set; }//trình độ học vấn 
    public int ThamNienTu { get; set; } //Thâm niên từ
    public int ThamNienDen { get; set; } //Thâm niên đến
    public string ChinhSach { get; set; }
    public string HopDong { get; set; }
    public string DieuKienKhac { get; set; }
    public string HinhThucLamViec { get; set; } 
    public bool DaThamGiaCongDoan { get; set; }
    public bool LaDangVien { get; set; } 
    public int TuoiTu { get; set; } //Tuổi từ
    public int TuoiDen { get; set; } //Tuổi đến
    public bool LaThuongBinh { get; set; }
    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }
    public int Thang { get; set; }
    // daibx - 14/01/2014
    public int IdQuyetDinhLuong { get; set; }
    public long SoTien { get; set; }
    public string SoQuyetDinh { get; set; } 
}

/// <summary>
/// Class chứa filter tuyển dụng
/// </summary>
public class ReportFilterRecuitment : ReportFilterInfoBase
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
/// <summary>
/// Class chứa filter chấm công
/// </summary>
public class ReportFilterTimeKeeper : ReportFilterInfoBase  
{
    public int IDBangChamCong { get; set; }
    public int IDBangPhanCa { get; set; }
    public int IDDanhSachBangTongHopCong { get; set; }
    public int ThangBaoCao { get; set; }
    public int NamBaoCao { get; set; }
    public DateTime? ThangNam { get; set; }
    public DateTime? NgayThang { get; set; }
    public DateTime? ChonNgay { get; set; }
    public int ChonNam { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public string MaChucVu { get; set; }
    public string MaViTriCongViec { get; set; }
    public string MaNhanVien { get; set; }
}
/// <summary>
/// Class chứa filter thôi việc
/// </summary>
public class ReportFilterSeverance : ReportFilterInfoBase
{
    public int StartMonth { get; set; }
    public int EndMonth { get; set; }
    public int Year { get; set; } 
}

/// <summary>
/// ReportFilter dành cho bảng lương
/// </summary>
public class ReportFilterSalary : ReportFilterInfoBase
{
    public int IDBangLuong { get; set; }
    public int IdBangThuong { get; set; }
    public int IdBangPhat { get; set; }
    public string MaCB { get; set; }
    /// <summary>
    /// Tên bảng lương
    /// </summary>
    public string SalaryBoardTitle { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
public class ReportFilterTax : ReportFilterInfoBase
{
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public string MaSoThue { get; set; }
    public string DiaChi { get; set; }
    public string DienThoai { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public int Nam { get; set; }
    public string MaCB { get; set; }
}