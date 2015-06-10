<%@ WebHandler Language="C#" Class="UngVienDuTruHandler" %>

using System;
using System.Web;

public class UngVienDuTruHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 10;
        var searchKey = string.Empty;
        var blackorstore = string.Empty;
        var count = 0;
        var DotTuyenDung = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = context.Request["searchKey"];
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["blackorstore"]))
        {
            blackorstore = context.Request["blackorstore"];
        }
        if (!string.IsNullOrEmpty(context.Request["DotTuyenDung"]))
        {
            DotTuyenDung = int.Parse("0" + context.Request["DotTuyenDung"]);
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
        count = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("dbo.TuyenDung_Count_UngVienDuTru", "@searchKey", "@blackorstore", "@DotTuyenDung", "@month", "@year", searchKey, blackorstore, DotTuyenDung, month, year).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_UngVienDuTru", "@start", "@limit", "@searchKey", "@blackorstore", "@DotTuyenDung", "@month", "@year", start, limit, searchKey, blackorstore, DotTuyenDung, month, year);

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}