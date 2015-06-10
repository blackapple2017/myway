using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TangGiamBHTrongThangInfo
/// </summary>
public class TangGiamBHTrongThangInfo
{
	public TangGiamBHTrongThangInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public decimal ID { get; set; }
    public int? IDNhanVien_BaoHiem { get; set; }
    public string MaNhanVien { get; set; }
    public decimal LuongBaoHiem { get; set; }
    public string HoTen { get; set; }
    public string TenChucVu { get; set; }
    public string TenBoPhan { get; set; }
    public decimal? Plus { get; set; }
    public decimal? Minus { get; set; }
    public string Notes { get; set; }

}