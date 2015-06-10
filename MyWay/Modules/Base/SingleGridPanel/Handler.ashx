<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = int.Parse("0" + context.Request["start"]);
        //if (start == 0)
        //{
        //    start += 1;
        //}
        //var limit = int.Parse("0" + context.Request["PageSize"]);
        var limit = int.Parse("0" + context.Request["limit"]);        
        var dataSouce = context.Request["DataSource"];
        var column = context.Request["column"];
        var searchField = context.Request["SearchField"];
        var searchKey = context.Request["SearchKey"];
        var IDProperty = context.Request["IDProperty"];
        var maDonVi = context.Request["MaDonVi"];
        var maDonViColumn = context.Request["MaDonViColumn"];
        var count = 0;
        var whereClause = string.Empty;
        string searchWhere = "";
        var orderBy = context.Request["OrderBy"];
        if (string.IsNullOrEmpty(orderBy))
        {
            orderBy = IDProperty;
        }
        if (!string.IsNullOrEmpty(context.Request["WhereClause"]))
        {
            whereClause = " where " + context.Request["WhereClause"];
        }

        if (!string.IsNullOrEmpty(searchField) && !string.IsNullOrEmpty(searchKey))
        {
            string[] searchFieldList = searchField.Split(',');
            string[] splitedKeyWord = SoftCore.Util.GetInstance().GetKeyword(searchKey).Split(' ');
            foreach (string col in searchFieldList)
            {
                if (!string.IsNullOrEmpty(col))
                {
                    string s = "";
                    foreach (string item in splitedKeyWord)
                    {
                        s += "[" + col + "] like N'%" + item + "%' and ";
                    }
                    s = s.Remove(s.LastIndexOf(" and "));
                    searchWhere += "(" + s + ") or ";
                }
            }
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause += " and " + searchWhere.Remove(searchWhere.LastIndexOf(" or"));
            }
            else
            {
                whereClause = " where " + searchWhere.Remove(searchWhere.LastIndexOf(" or"));
            }
        }
        if (!string.IsNullOrEmpty(maDonViColumn))
        {
            System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
            string str = "('";
            foreach (var item in idList)
            {
                str += item + "','";
            }
            str += "')";
            string filter = maDonViColumn + " in " + str;
            if (string.IsNullOrEmpty(whereClause))
            {
                whereClause = " where " + filter;
            }
            else
            {
                whereClause += " and " + filter;
            }
        }
        try
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("select count(" + IDProperty + ") from " + dataSouce + whereClause).ToString());
            string sql = string.Format("select {0} from (select {1},ROW_NUMBER() OVER( ORDER BY " + orderBy + ") row from {2}" + whereClause + ")a where row between {3} and {4}", column, column, dataSouce, start + 1, start + limit);
            System.Data.DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable(sql);
            context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
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