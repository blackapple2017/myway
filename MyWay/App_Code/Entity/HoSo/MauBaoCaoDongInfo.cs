using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MauBaoCaoDongInfo
/// </summary>
public class MauBaoCaoDongInfo
{
	public MauBaoCaoDongInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string ReportName { get; set; }
    public string ReportContent { get; set; }
    public string ContentBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? EditedDate { get; set; }
    public int? EditedBy { get; set; }
}