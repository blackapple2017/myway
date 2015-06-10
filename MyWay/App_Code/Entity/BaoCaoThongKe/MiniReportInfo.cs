using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MiniReportInfo
/// </summary>
public class MiniReportInfo
{
	public MiniReportInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public string Name { get; set; }
    public string Tooltip { get; set; }
    public string ImageReportPreview { get; set; }
    public string Javascript { get; set; }
}