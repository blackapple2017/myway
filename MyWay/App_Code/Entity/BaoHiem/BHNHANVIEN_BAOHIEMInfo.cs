using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Lê Văn Anh
/// </summary>

public class BHNHANVIEN_BAOHIEMInfo
{
    public int IDNhanVien_BaoHiem { set; get; }
    public string MaNhanVien { set; get; }
    public string HoTen { set; get; }
    public string Ho { get; set; }
    public string Ten { get; set; }
    public string MaBoPhan { get; set; }
    public string TenBoPhan { get; set; }
    public bool? GioiTinh { set; get; }
    public DateTime? NgaySinh { set; get; }
    public string HoKhauThuongTruTamTru { set; get; }
    public string DiaChiLienHe { set; get; }
    public string SoCMTND { set; get; }
    public DateTime? NgayCapCMTND { set; get; }
    public string NoiCapCMTND { set; get; }
    public string MaChucVu { set; get; }
    public string TenChucVu { get; set; }
    public decimal? LuongBaoHiem { set; get; }
    public DateTime NgayBatDauHopDong { get; set; }
    public string TenLoaiHopDong { get; set; }
    public decimal? PhuCapCV { set; get; }
    public decimal? PhuCapTNN { set; get; }
    public decimal? PhuCapTNVK { set; get; }
    public decimal? PhuCapKhac { set; get; }
    public string NoiDangKyKCB { set; get; }
    public string LoaiBHYT { set; get; }
    public string SoTheBHYT { set; get; }
    public DateTime? TuThangBHYT { set; get; }
    public DateTime? DenThangBHYT { set; get; }
    public string DoiTuongHuongBHYTMuc { set; get; }
    public bool? BHXHTrangThaiDangKyCQBH { set; get; }
    public DateTime? NgayDangKyBHXH { set; get; }
    public string TrangThaiCapSoBHXH { set; get; }
    public string NoiCapSoBHXH { set; get; }
    public DateTime? NgayCapSoBHXH { set; get; }
    public string SoSoBHXH { set; get; }
    public bool? DangDongBHXH { set; get; }
    public bool? DangDongBHYT { set; get; }
    public bool? DangDongBHTN { set; get; }
    public int? ThoiGianDongBHXHTruocKhiVaoCongTy { set; get; }
    public int? ThoiGianDongBaoHiem { set; get; }
    public int UserID { set; get; }
    public bool DaNghi { get; set; }
    public DateTime DateCreate { set; get; }
    public string MaDonVi { set; get; }
    
}
/// <summary>
/// Infolite dùng cho việc chọn nhân viên bảo hiểm
/// </summary>
public class BHNHANVIEN_BAOHIEMLiteInfo
{
    public int PR_KEY { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public DateTime? NgaySinh { get; set; }
    public string TenPhong { get; set; }
    public string SoSoBHXH { get; set; }
    public string SoTheBHYT { get; set; }
}