using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachBangLuongInfo
/// </summary>
public class DanhSachBangLuongInfo
{
	public DanhSachBangLuongInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public bool DaKhoa { get; set; }
    public int MenuID { get; set; }
    public string MaDonVi { get; set; }
    public string Description { get; set; }
}