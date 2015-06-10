using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhieuLamThemGioInfo
/// </summary>
public class PhieuLamThemGioInfo
{
	public PhieuLamThemGioInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public decimal ID { get; set; }
    public decimal PrkeyHoSo { get; set; }
    public string MA_CB { get; set; }
    public string HO_TEN { get; set; }
    public string TEN_DONVI { get; set; }
    public string GioBatDau { get; set; }
    public string GioKetThuc { get; set; }
    public DateTime NgayDangKy { get; set; }
    public float LamThemNgayThuong { get; set; }
    public float LamThemNgayNghi { get; set; }
    public float LamThemNgayLe { get; set; }
    public string NoiDung { get; set; }
}