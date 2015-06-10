using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_UNGVIEN_CHUNGCHIInfo1
/// </summary>
public class HOSO_UNGVIEN_CHUNGCHIInfo1
{
	public HOSO_UNGVIEN_CHUNGCHIInfo1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int? ID { get; set; }
    public string TenChungChi { get; set; }
    public string TEN_XEPLOAI { get; set; } 
    public string NoiDaoTao { get; set; }
    public DateTime? NgayCap { get; set; }
    public DateTime? NgayHetHan { get; set; }
    public string GhiChu { get; set; }
}