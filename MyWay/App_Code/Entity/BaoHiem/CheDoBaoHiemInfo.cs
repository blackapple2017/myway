using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CheDoBaoHiemInfo
/// </summary>
public class CheDoBaoHiemInfo
{
    public int IDCheDoBaoHiem { get; set; }
    public int ParentID { get; set; }
    public string MaCheDoBaohiem { get; set; }
    public string TenCheDoBaoHiem { get; set; }
    public int UserID { get; set; }
    public DateTime? DateCreate { get; set; }
    public string MaDonVi { get; set; }
}
public class NhanVienCheDoInfo
{
    public int  IDNhanVien_BaoHiem { get; set; }
    public string MaNhanVien { get; set; }
    public string TenNhanVien { get; set; }
    public string HoDem { get; set; }
    public string Ten { get; set; }
    public string PhongBan { get; set; }
    public string SoSoBHXH { get; set; }
    public string SoTheBHYT { get; set; }
    public int SoThangDongBH { get; set; }
    public int SoNgayNghiOmDau { get; set; }
    public int SoNgayNghiThaiSan { get; set; }
    public int SoNgayNghiDSPHSK { get; set; }
    public decimal TongTienThanhToan { get; set; }
    public string TrangThai { get; set; }
    public bool? DaNghi { get; set; }
}
public class ChiTietNhanVienCheDoInfo
{
    public int IDChiTietCheDoBaoHiem { get; set; }
    public int IDNhanVien_BaoHiem { get; set; }
    public string MaCheDo { get; set; }
    public string TenCheDo { get; set; }
    public string DieuKienHuong { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public int? SoNgayNghi { get; set; }
    public decimal? SoTienDeNghi { get; set; }
    public bool? TinhTrangThanhToan { get; set; }
    public string GhiChu { get; set; }
}

public class NhanVienCheDoTheoThangInfo
{
    public int IDChiTietCheDoBaoHiem { get; set; }
    public int IDBangTinhCheDoBaoHiem { get; set; }
    public int IDNhanVien_BaoHiem { get; set; }
    public string MaCheDo { get; set; }
    public string TenCheDo { get; set; }
    public string DieuKienHuong { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string Ten { get; set; }
    public string PhongBan { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public decimal? TienLuongTinhHuong { get; set; }
    public int? SoNgayNghi { get; set; }
    public decimal? SoTienDeNghi { get; set; }
    public bool? TinhTrangThanhToan { get; set; }
    public string Thang { get; set; }
    public string GhiChu { get; set; }
}

public class DanhSachCheDoBaoCaoInfo
{
    public int IDCheDoBaoHiem { get; set; }
    public int IDNhanVien_BaoHiem { get; set; }
    public string MaCanBo { get; set; }
    public string HoTen { get; set; }
    public string Ten { get; set; }
    public string SoSoBHXH { get; set; }
    public string DieuKienTinhHuong { get; set; }
    public int? ThoiGianDongBHXH { get; set; }
    public decimal? TienLuongTinhHuong { get; set; }
    public int? SoNgayNghi { get; set; }
    public int? LuyKeTuDauNam { get; set; }
    public decimal? SoTienDeNghi { get; set; }
    public string GhiChu { get; set; }
    public string GroupField { get; set; }
}