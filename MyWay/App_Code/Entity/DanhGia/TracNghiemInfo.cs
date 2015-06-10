using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TracNghiemInfo
/// </summary>
public class TracNghiemInfo
{
	public TracNghiemInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public string CriterionID { get; set; }
    public string ExplainName { get; set; }
    public int MinPoint { get; set; }
    public int MaxPoint { get; set; }
    public int? Order { get; set; }
}