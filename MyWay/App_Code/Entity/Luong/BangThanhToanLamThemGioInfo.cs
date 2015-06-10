using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangThanhToanLamThemGioInfo
/// </summary>
public class BangThanhToanLamThemGioInfo
{
	public BangThanhToanLamThemGioInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public decimal PRKEY { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string BoPhan { get; set; }
    public double LuongCung { get; set; }
    public string NgayDangKyLamThem { get; set; }
    public double GioCongLamThemNgayThuong { get; set; }
    public double SoTienLamThemNgayThuong { get; set; }
    public double GioCongLamThemNgayNghi { get; set; }
    public double SoTienLamThemNgayNghi { get; set; }
    public double GioCongLamThemNgayLe { get; set; }
    public double SoTienLamThemNgayLe { get; set; }
    public double TongCongTien { get; set; }
}