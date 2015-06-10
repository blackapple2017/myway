using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VaoRaCaInfo
/// </summary>
public class VaoRaCaInfo
{
	public VaoRaCaInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string ID { get;set; }
    public string MaCa { get; set; }
    public string MaChamCong { get; set; }
    public string Time { get; set; }
    
    public string MA_CB { get; set; }
    public string HO_TEN { get; set; }
    public int? Order { get; set; }
    public bool DiVao { get; set; }
    public DateTime NgayChamCong { get; set; }
}