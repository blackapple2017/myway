<%@ WebHandler Language="C#" Class="LichHenPhongVanHandler" %>

using System;
using System.Web;

public class LichHenPhongVanHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 10;
        var searchKey = string.Empty;
        var count = 0;

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
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("dbo.TuyenDung_Count_LichHenPhongVan_HoSo", "@searchKey", searchKey).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_LichHenPhongVan", "@start", "@limit", "@searchKey", start, limit, searchKey);

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}