using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_BANGCAP_UNGVIENInfo1
/// </summary>
public class HOSO_BANGCAP_UNGVIENInfo1
{
	public HOSO_BANGCAP_UNGVIENInfo1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int? ID { get; set; }
    public decimal? FR_KEY { get; set; }
    public string TEN_TRUONG_DAOTAO { get; set; }
    public string KHOA { get; set; }
    public string TEN_CHUYENNGANH { get; set; }
    public string TEN_TRINHDO { get; set; }
    public string TEN_HT_DAOTAO { get; set; }
    public string TEN_XEPLOAI { get; set; }
    public bool? DA_TN { get; set; }
    public DateTime? NGAY_NHANBANG { get; set; }
    public DateTime? TU_NGAY { get; set; }
    public DateTime? DEN_NGAY { get; set; }
}