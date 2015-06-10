using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TuCapNhatInfo
/// </summary>
public class TuCapNhatInfo
{
	public TuCapNhatInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string MaCB { get; set; }
    public string HoTen { get; set; }
    public string BoPhan { get; set; }
    public DateTime? CapNhatLanCuoi { get; set; }
    public string TrangThaiDuyet { get; set; }
    public string TaiKhoanDangNhap { get; set; }
    public string LyDoKhongDuyet { get; set; }
    public int? UserID { get; set; }
    public string NguoiDuyet { get; set; }
}