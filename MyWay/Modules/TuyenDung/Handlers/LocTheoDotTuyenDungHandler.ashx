<%@ WebHandler Language="C#" Class="LocTheoDotTuyenDungHandler" %>

using System;
using System.Web;

public class LocTheoDotTuyenDungHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        var start = 0;
        var limit = 4;
        var sort = string.Empty;
        var dir = string.Empty;
        var query = string.Empty;
        int Count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = context.Request["query"];
        }
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = context.Request["query"];
            query = SoftCore.Util.GetInstance().GetKeyword(query);
        }
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_LocKeHoachTuyenDung", "@start", "@limit", "@searchKey", start, limit, query);
        var count = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_Count_KeHoachTuyenDung", "@searchKey", query);
        Count = Convert.ToInt32(count.Rows.Count);
        context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}