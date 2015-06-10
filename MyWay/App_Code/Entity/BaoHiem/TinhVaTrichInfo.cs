using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TinhVaTrichInfo
/// </summary>
public class TinhVaTrichInfo
{
    public int IDDongBaoHiemThang { get; set; }
    public int MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public decimal LuongDongBH { get; set; }
    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }
    public decimal SoTienNVBHXH { get; set; }
    public decimal SoTienNVBHYT { get; set; }
    public decimal SoTienNVBHTN { get; set; }
    public decimal SoTienDVBHXH { get; set; }
    public decimal SoTienDVBHYT { get; set; }
    public decimal SoTienDVBHTN { get; set; }
    public decimal TongTienDongBHNV { get; set; }
    public decimal TongTienDongBHDV { get; set; }
    public decimal TongCong { get; set; }
}
public class ThangTrichBHInfo
{
    public int IDBangLuong { get; set; }
    public string TenBangLuong { get; set; }
    public int ThangNam { get; set; }
    public int SoNhanVien { get; set; }
    public double TienNhanVienTrich { get; set; }
    public double TienDonViTrich { get; set; }
    public double TongTien { get; set; }
    public bool DaKhoa { get; set; }
}