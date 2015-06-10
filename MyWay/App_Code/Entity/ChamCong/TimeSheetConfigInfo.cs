using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeSheetConfigInfo
/// </summary>
public class TimeSheetConfigInfo
{
	public TimeSheetConfigInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string ColumnName { get; set; }
    public string ColumnDescription { get; set; }
    public int Width { get; set; }
    public string Align { get; set; }
    public bool DisplayOnGrid { get; set; }
    public int Order { get; set; }
    public string RenderJS { get; set; }
}