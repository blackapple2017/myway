using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_DOTTUYENDUNGInfo
/// </summary>
public class DM_DOTTUYENDUNGInfo
{
	public DM_DOTTUYENDUNGInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int? ID { get; set; }
    public string TenKeHoach { get; set; }
    public string MA_CHUCVU{ get; set;}
    public DateTime? NgayBatDau{get;set;}
    public DateTime? NgayKetThuc{get;set;}
    public int? SoLuongCanTuyen{get; set;}
    public string LyDoTuyen{get; set;}
    public double? KinhPhiDuTru{get; set;}
}