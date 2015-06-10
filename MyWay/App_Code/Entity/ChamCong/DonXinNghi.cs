using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DonXinNghiController
/// </summary>
public class DonXinNghiInfo
{
    public int ID { get; set; }
    public string MaCB { get; set; }
    public string HoTen { get; set; }
    public string BoPhan { get; set; }
    public DateTime NgayNopDon { get; set; }
    public DateTime NghiTuNgay { get; set; }
    public DateTime NghiDenNgay { get; set; }
    public string LyDoNghi { get; set; }
    public string TrangThaiDuyet { get; set; }
    public string MaCBDangDuyet { get; set; }
    public string TenCBDangDuyet { get; set; }
    public string TenPhongCBDangDuyet { get; set; }
    public string MaLyDoNghi { get; set; }
    public double? SoNgayNghi { get; set; }
    public double? SoNgayNghiTruPhep { get; set; }
    public double? SoNgayNghiTruLuong { get; set; }
    public double? SoNgayNghiCheDo { get; set; }
    public string KyHieuChamCong { get; set; }
    public string PhanTramHuongLuong { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
}
public class DonXinNghiLichSuInfo
{
    public DateTime NgayDuyet { get; set; }
    public string MaCBDuyet { get; set; }
    public string TenCBDuyet { get; set; }
    public string TrangThai { get; set; }
    public string GhiChu { get; set; }
}