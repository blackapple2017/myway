using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_MUCLUONG_NGACHInfo
/// </summary>
public class DM_MUCLUONG_NGACHInfo
{
	public DM_MUCLUONG_NGACHInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public decimal PR_KEY { get; set; }
    public string MaNgach { get; set; }
    public string TenNgach { get; set; }
    public string MaNhomNgach { get; set; }
    public string TenNhomNgach { get; set; }
    public double? Cap { get; set; }
    public decimal? HeSoLuong { get; set; }
    public string MucLuong { get; set; }
    public int? BacLuong { get; set; }
    public string GhiChu { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    string MaDonVi { get; set; }
}