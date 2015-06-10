<%@ WebHandler Language="C#" Class="KeHoachTuyenDungHandler" %>

using System;
using System.Web;

public class KeHoachTuyenDungHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 20;
        var SearchKey = string.Empty;
        var Count = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey).Replace(" ", "%") + "%";
        }
        int month = 0;
        int year = 0;
        if (!string.IsNullOrEmpty(context.Request["month"]))
        {
            month = int.Parse("0" + context.Request["month"]);
        }
        if (!string.IsNullOrEmpty(context.Request["year"]))
        {
            year = int.Parse("0" + context.Request["year"]);
        }
        Count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("TuyenDung_Count_KeHoachTuyenDung", "@searchKey", "@month", "@year", SearchKey, month, year).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_KeHoachTuyenDung", "@start", "@limit", "@searchKey", "@month", "@year", Start, Limit, SearchKey, month, year);

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}