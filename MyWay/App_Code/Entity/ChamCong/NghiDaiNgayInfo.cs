using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NghiDaiNgayInfo
/// </summary>
public class NghiDaiNgayInfo
{
	public NghiDaiNgayInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public decimal PR_KEYHOSO { get; set; }
    public string HoTen { get; set; }
    public string LyDoNghi { get; set; }
    public bool DongBH { get; set; }
    public DateTime NgayNopDon { get; set; }
    public DateTime? NgayDangKyNghi { get; set; }
    public DateTime? NgayDiLamLai { get; set; }
    public DateTime? NgayNghiThucTe { get; set; }
    public DateTime? NgayDiLamLaiThucTe { get; set; }
    public string GhiChu { get; set; }
}