using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHBIENDONGBAOHIEMInfo
{
    public int IDBienDongBaoHiem { set; get; }
    public int IDQuyDinhBienDong { set; get; }
    public int IDNhanVien_BaoHiem { set; get; }
    public DateTime? TuNgay { set; get; }
    public DateTime? DenNgay { set; get; }
    public string Loai { set; get; }
    public string MaNhanVien { set; get; }
    public string HoTen { set; get; }
    public string MaSo { set; get; }
    public DateTime? NgaySinh { set; get; }
    public bool? GioiTinh { set; get; }
    public string ChucVu { set; get; }
    public decimal? TienLuongCu { set; get; }
    public decimal? PhuCapCVCu { set; get; }
    public decimal? PhuCapTNVKCu { set; get; }
    public decimal? PhuCapTNNVKMoi { set; get; }
    public decimal? PhuCapNgheCu { set; get; }
    public decimal? TienLuongMoi { set; get; }
    public decimal? PhuCapCVMoi { set; get; }
    public decimal? PhuCapTNNgheMoi { set; get; }
    public DateTime? TuThang { set; get; }
    public DateTime? DenThang { set; get; }
    public bool? KhongTraThe { set; get; }
    public bool? DaCoSo { set; get; }
    public int UserID { set; get; }
    public DateTime DateCreate { set; get; }
    public string MaDonVi { set; get; }
}
