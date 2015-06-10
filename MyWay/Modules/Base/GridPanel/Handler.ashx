<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Linq;
public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        var Start = 0;
        var Limit = 10;
        var TableName = "";
        var Column = "*";
        int Count = 0;
        var Keyword = "";
        var where = "";
        var GridName = string.Empty;
        var PrimaryKey = string.Empty;
        var OutsideQuery = string.Empty;
        var OrderBy = string.Empty;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }

        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["gridName"]))
        {
            GridName = context.Request["gridName"];
        }
        if (!string.IsNullOrEmpty(context.Request["table"]))
        {
            TableName = context.Request["table"];
        }
        if (!string.IsNullOrEmpty(context.Request["primarykey"]))
        {
            PrimaryKey = context.Request["primarykey"];
        }
        if (!string.IsNullOrEmpty(context.Request["keyword"]))
        {
            Keyword = context.Request["keyword"];
        }
        if (!string.IsNullOrEmpty(context.Request["where"]))
        {
            where = "where " + context.Request["where"];
        }
        if (!string.IsNullOrEmpty(context.Request["OrderBy"]))
        {
            OrderBy = context.Request["OrderBy"];
        }
        else
        {
            OrderBy = "order by " + PrimaryKey + " desc";
        }
        if (!string.IsNullOrEmpty(context.Request["Column"]))
        {
            Column = context.Request["Column"];
        }
        if (!string.IsNullOrEmpty(Keyword))
        {
            if (string.IsNullOrEmpty(where))
            {
                where = "where ";
            }
            else
            {
                where += " and ";
            }
            string search = "";
            System.Collections.Generic.List<WebUI.Entity.GridPanelColumnInfo> columnList = (from t in WebUI.Controller.GridController.GetInstance().GetColumnInfo(GridName, TableName, 1)
                                                                                            where t.AllowSearch == true
                                                                                            select t).ToList();
            foreach (WebUI.Entity.GridPanelColumnInfo col in columnList)
            {
                if (col.DataType.ToString().Equals("System.String"))
                {
                    string[] splitedKeyWord = SoftCore.Util.GetInstance().GetKeyword(Keyword).Split(' ');
                    string s = "";
                    foreach (string item in splitedKeyWord)
                    {
                        s += "[" + col.ColumnName + "] like N'%" + item + "%' and ";
                    }
                    s = s.Remove(s.LastIndexOf(" and "));
                    search += "(" + s + ") or ";
                }
                else
                {
                    search += "[" + col.ColumnName + "] like N'" + Keyword + "' or ";
                }
            }
            where = where + " (" + search.Remove(search.LastIndexOf(" or ")) + ")";
        }
        if (!string.IsNullOrEmpty(context.Request["OutsideQuery"]))
        {
            OutsideQuery = context.Request["OutsideQuery"];
            //Query từ ngoài truyền vào, query này là do control phụ của developer phát triển truyền vào
            if (string.IsNullOrEmpty(where) == true)
            {
                where = " where " + OutsideQuery;
            }
            else
            {
                where += " and " + OutsideQuery;
            }
            //#end
        }
        if (!string.IsNullOrEmpty(context.Request["FilterAtRuntime"]))
        {
            if (string.IsNullOrEmpty(where) == true)
            {
                where = " where " + context.Request["FilterAtRuntime"];
            }
            else
            {
                where += " and " + context.Request["FilterAtRuntime"];
            }
        }
        try
        {
            Count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("select count(" + PrimaryKey + ") from " + TableName + " " + where).ToString());
            string sql = string.Format("select {0} from (select {1},ROW_NUMBER() OVER(" + OrderBy + ") row from {2} {5})a where row between {3} and {4}", Column, Column, TableName, Start+1, Start + Limit, where);
            System.Data.DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable(sql);
            context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
        }
        catch
        {
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}