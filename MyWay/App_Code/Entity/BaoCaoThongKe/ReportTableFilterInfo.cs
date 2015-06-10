using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportFilterTable
/// </summary>
public class ReportTableFilterInfo
{
	public ReportTableFilterInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; } 
    public string DescriptionTableName { get; set; }
    public string WhereField { get; set; }
}