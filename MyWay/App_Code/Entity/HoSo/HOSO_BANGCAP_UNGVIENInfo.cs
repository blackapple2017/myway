using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_BANGCAP_UNGVIENInfo
/// </summary>
public class HOSO_BANGCAP_UNGVIENInfo
{
	public HOSO_BANGCAP_UNGVIENInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int? ID { get; set; }
    public decimal? FR_KEY { get; set; }
    public string MA_TRUONG_DAOTAO { get; set; }
    public string KHOA { get; set; }
    public string MA_CHUYENNGANH { get; set; }
    public string MA_TRINHDO { get; set; }
    public string MA_HT_DAOTAO { get; set; }
    public string MA_XEPLOAI { get; set; }
    public bool? DA_TN { get; set; }
    public DateTime? NGAY_NHANBANG { get; set; }
    public DateTime? TU_NGAY { get; set; }
    public DateTime? DEN_NGAY { get; set; }
   
}