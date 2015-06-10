using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MenuForSetPermissionController
/// </summary>
public class MenuForSetPermissionController : LinqProvider
{
	public MenuForSetPermissionController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<MenuForSetPermissionInfo> GetByParentID(int parentID)
    {
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("HeThong_GetMenuForSetPermissionByParentID", "@parentID", parentID);
        if (table.Rows.Count == 0)
        {
            return new List<MenuForSetPermissionInfo>();
        }
        else
        {
            List<MenuForSetPermissionInfo> lists = new List<MenuForSetPermissionInfo>();
            foreach (DataRow item in table.Rows)
            {
                MenuForSetPermissionInfo info = new MenuForSetPermissionInfo();
                info.ID = int.Parse("0" + item["ID"].ToString());
                info.MenuID = int.Parse("0" + item["MenuID"].ToString());
                info.MenuName = item["MenuName"].ToString();
                info.ParentID = int.Parse("0" + item["ParentID"].ToString());
                lists.Add(info);
            }
            return lists;
        }
    }
}