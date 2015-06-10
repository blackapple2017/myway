<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 10;
        var count = 0;
        string searchKey = context.Request["searchKey"];
        string trangThaiDuyet = context.Request["filter"];
        string donVi = context.Request["department"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(searchKey))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        } 
        var data = new TuCapNhatController().GetAll(start, limit, searchKey, trangThaiDuyet, out count, donVi);
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