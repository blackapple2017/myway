<%@ WebHandler Language="C#" Class="BangTinhCheDoBaoHiem" %>

using System;
using System.Web;

public class BangTinhCheDoBaoHiem : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 30;
        string SearchKey = string.Empty;
        int Count = 0;
        string MaDonVi = string.Empty;
      
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["searchkey"]))
        {
            SearchKey = context.Request["searchkey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["madonvi"]))
        {
            MaDonVi = context.Request["madonvi"];
        }
        var data = new BangTinhCheDoBaoHiemController().GetAllRecord(start, limit, SearchKey, MaDonVi, out Count);
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