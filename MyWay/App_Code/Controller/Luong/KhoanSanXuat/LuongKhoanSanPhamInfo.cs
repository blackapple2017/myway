using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LuongKhoanSanPhamInfo
/// </summary>
public class LuongKhoanSanPhamInfo
{
	public LuongKhoanSanPhamInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string MaCanBo { get; set; }
    public string TenCanBo { get; set; }
    public string HoTen { get; set; }
    public string ChucVu { get; set; }
    public double? LuongQuyetDinh { get; set; }
    public double SoGioDangKy { get; set; }
    public double SoGioLamViec { get; set; }
    public decimal SanPhamChinh { get; set; }
    public decimal SanPhamPhu { get; set; }
    public decimal LuongSanPham { get; set; }
    public decimal? LuongCongNhat { get; set; }
    public decimal? LuongKhac { get; set; }
    public double? LuongHoTro { get; set; }
    public decimal? TongLuong { get; set; }
    public int Ngay { get; set; }
    public string MaDonVi { get; set; }
    public string TenDonVi { get; set; }
}