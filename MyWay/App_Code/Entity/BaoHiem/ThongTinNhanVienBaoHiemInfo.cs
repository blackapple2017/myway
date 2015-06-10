using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThongTinNhanVienBaoHiemInfo
/// </summary>
public class ThongTinNhanVienBaoHiemInfo
{
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string HoDem { get; set; }
    public string Ten { get; set; }
    public string PhongBan { get; set; }
    public decimal? LuongBaoHiem { get; set; }
    public decimal? PhuCapCV { get; set; }
    public decimal? PhuCapVuotKhung { get; set; }
    public decimal? PhuCapNghe { get; set; }
    public decimal? PhuCapKhac { get; set; }
    public DateTime? NgayDangKyBHXH { get; set; }
    public string SoSoBHXH { get; set; }
    public int? ThoiGianDongBaoHiem { get; set; }
    public bool? DangDongBHXH { get; set; }
    public bool? DangDongBHYT { get; set; }
    public bool? DangDongBHTN { get; set; }
    public string SoTheBHYT { get; set; }
    public DateTime? TuThangBHYT { get; set; }
    public DateTime? DenThangBHYT { get; set; }
    public bool? BHXHTrangThaiDangKyCQBH { get; set; }
    public string TrangThai { get; set; }
    public string NoiCapBHXH { get; set; }
}