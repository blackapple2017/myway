using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachBangPhanCaInfo
/// </summary>
public class DanhSachBangPhanCaInfo
{
	public DanhSachBangPhanCaInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public int Nam { get; set; }
    public string TenBangPhanCa { get; set; }
    public string MaDonVi { get; set; }
    public int SoNguoi { get; set; }
    public int Thang { get; set; }
    public string NguoiTao { get; set; }
    public DateTime? NgayTao { get; set; }
}