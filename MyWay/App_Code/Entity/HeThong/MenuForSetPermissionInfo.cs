using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuForSetPermissionInfo
/// </summary>
public class MenuForSetPermissionInfo
{
	public MenuForSetPermissionInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public int MenuID { get; set; }
    public string MenuName { get; set; }
    public int ParentID { get; set; }
}