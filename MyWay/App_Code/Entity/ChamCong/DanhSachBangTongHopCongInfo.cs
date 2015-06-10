using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachBangTongHopCongInfo
/// </summary>
public class DanhSachBangTongHopCongInfo
{
	public DanhSachBangTongHopCongInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public string Title { get; set; }
    public int Thang { get; set; }
    public int Nam { get; set; }
    public DateTime CreatedDate { get; set; }
    public string MaDonVi { get; set; }
    public string TenDonVi { get; set; }
    public string DaKhoa { get; set; }
    public bool Lock { get; set; } 
    public int CreatedBy { get; set; }
}