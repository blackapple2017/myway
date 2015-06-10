using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NhanVienBienDongInfo
/// </summary>
public class NhanVienBienDongInfo
{
    public int IDNhanVien_BaoHiem { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string Ten { get; set; }
    public string PhongBan { get; set; }
    public int? ThoiGianDongBaoHiem { set; get; }
    public decimal? LuongBaoHiem { set; get; }
    public decimal? PhuCapCV { set; get; }
    public decimal? PhuCapTNN { set; get; }
    public decimal? PhuCapTNVK { set; get; }
    public decimal? PhuCapKhac { set; get; }
    public bool? DangDongBHXH { set; get; }
    public bool? DangDongBHYT { set; get; }
    public bool? DangDongBHTN { set; get; }
    public string TrangThai { get; set; }
    public bool? DaNghi { get; set; }
}

public class SoNgayNghiNhanVienBienDongInfo
{
    public int IDNhanVien_BaoHiem { get; set; }
    public bool? GioiTinh { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public int OmNganNgay { get; set; }
    public int ConOm { get; set; }
    public int OmDaiNgay { get; set; }
    public int DSPHSKDieuTriThuong { get; set; }
    public int DSPHSKOmDau { get; set; }
    public int DSPHSKThaiSan { get; set; }
    public int TranhThai { get; set; }
    public int KhamThai { get; set; }
    public int NghiSinhCon { get; set; }
    public int NhanConNuoi { get; set; }
    public int SayThaiChetLuu { get; set; }
    public int MyProperty { get; set; }
    public string ThangBienDong { get; set; }
}
public class ChiTietNhanVienBienDongInfo
{
    public int IDBienDongBaoHiem { get; set; }
    public int IDQuyDinhBienDong { get; set; }
    public int IDNhanVien_BaoHiem { get; set; }
    public string Loai { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string MaSo { get; set; }
    public DateTime? NgaySinh { get; set; }
    public bool? GioiTinh { get; set; }
    public string ChucVu { get; set; }

    public string MaBienDong { get; set; }
    public string TenBienDong { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public int? SoNgayNghi { get; set; }
    public decimal? TienLuongCu { get; set; }
    public decimal? PhuCapCVCu { get; set; }
    public decimal? PhuCapNgheCu { get; set; }
    public decimal? PhuCapTNVKCu { get; set; }
    public decimal? TienLuongMoi { get; set; }
    public decimal? PhuCapCVMoi { get; set; }
    public decimal? PhuCapTNNgheMoi { get; set; }
    public decimal? PhuCapTNVKMoi { get; set; }
    public DateTime? ThangDangKy { get; set; }
    public DateTime? DenThang { get; set; }
    public bool? KhongTraThe { get; set; }
    public bool? DaCoSo { get; set; }
    public bool? DaDuyet { get; set; }
    public DateTime DateCreate { get; set; }
    public string ThangBienDong { get; set; }
    public string MaDonVi { get; set; }
    public string DienGiai { get; set; }
    public decimal? TruyThuBHXH { get; set; }
    public decimal? TruyThuBHYT { get; set; }
    public decimal? ThoaiThuBHXH { get; set; }
    public decimal? ThoaiThuBHYT { get; set; }
}
public class BienDongTheoThangInfo
{
    public int IDBienDongBaoHiem { get; set; }
    public int IDQuyDinhBienDong { get; set; }
    public int IDNhanVien_BaoHiem { get; set; }
    public string MaCanBo { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public string TenBienDong { get; set; }
    public string Loai { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public int? SoNgay { get; set; }
    public decimal? TienLuongCu { get; set; }
    public decimal? TongPhuCapCu { get; set; }
    public decimal? TienLuongMoi { get; set; }
    public decimal? TongPhuCapMoi { get; set; }
    public bool? KhongTraThe { get; set; }
    public bool? DaCoSo { get; set; }
    public string DienGiai { get; set; }
    public string Thang { get; set; }
}
public class DanhSachBienDongInfo
{
    public int IDBienDongBaoHiem { get; set; }
    public int IDQuyDinhBienDong { get; set; }
    public int IDNhanVien_BaoHiem { get; set; }
    public string MaCanBo { get; set; }
    public string HoTen { get; set; }
    public string Ten { get; set; }
    public string MaSo { get; set; }
    public DateTime? NgaySinh { get; set; }
    public bool? GioiTinh { get; set; }
    public string TenBienDong { get; set; }
    public string Loai { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public DateTime ThangDangKy { get; set; }
    public int? SoNgay { get; set; }
    public decimal? TienLuongCu { get; set; }
    public decimal? TongPhuCapCu { get; set; }
    public decimal? TienLuongMoi { get; set; }
    public decimal? TongPhuCapMoi { get; set; }
    public bool? KhongTraThe { get; set; }
    public bool? DaCoSo { get; set; }
    public string DienGiai { get; set; }
    public string TrangThai { get; set; }
}