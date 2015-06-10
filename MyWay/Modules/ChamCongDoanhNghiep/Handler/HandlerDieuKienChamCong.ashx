<%@ WebHandler Language="C#" Class="HandlerDieuKienChamCong" %>

using System;
using System.Web;

public class HandlerDieuKienChamCong : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 30;
        var count = 0;

        var groupID = int.Parse("0" + context.Request["groupID"]);
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        var data = new DieuKienChamCongController().GetConditionList(groupID, start, limit, out count, true);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}