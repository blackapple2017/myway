using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalaryBoardConfigInfo
/// </summary>
public class SalaryBoardConfigInfo
{
	public SalaryBoardConfigInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Diễn giải tên cột, ColumnHeader
    /// </summary>
    public string ColumnDescription { get; set; }
    /// <summary>
    /// Tên cột C1,C2,...Cn, tương đương DataIndex
    /// </summary>
    public string ColumnName { get; set; }
    public string RenderJS { get; set; }
    public int Width { get; set; } 
    public bool AllowSum { get; set; }
    public bool EditOnGrid { get; set; }
    public string DataSourceFunction { get; set; }
}