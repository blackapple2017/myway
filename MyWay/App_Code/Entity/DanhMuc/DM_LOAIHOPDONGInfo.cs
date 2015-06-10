using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LOAIHOPDONGInfo
/// </summary>
public class DM_LOAIHOPDONGInfo
{
	public DM_LOAIHOPDONGInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string MA_LOAI_HDONG { get; set; }
    public string TEN_LOAI_HDONG { get; set; }
    public string GHI_CHU { get; set; }
    public int? THOI_HAN_HOPDONG { get; set; }
    public double? HE_SO { get; set; }
}