using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MiniDM_DotTuyenDungInfo
/// </summary>
public class MiniDM_DotTuyenDungInfo
{
	public MiniDM_DotTuyenDungInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public string TenKeHoach { get; set; }
    public string MA_CONGVIEC { get; set; }
    public int SoLuong { get; set; }
    public string TrangThai { get; set; }
    public string MA_PHONG { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}