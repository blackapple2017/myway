<%@ WebHandler Language="C#" Class="HandlerBHCHEDOBAOHIEM" %>

using System;
using System.Web;

public class HandlerBHCHEDOBAOHIEM : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 10;
        var SearchKey = string.Empty;
        var Count = 0;
        string IdCheDoBH = "";
        string MaDonVi = "";
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
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            MaDonVi = context.Request["MaDonVi"];
        }
        if (!string.IsNullOrEmpty(context.Request["IdCheDoBH"]))
        {
            IdCheDoBH = context.Request["IdCheDoBH"];
        }
        var data = new BHCHEDOBAOHIEMController().GetAllRecord(Start, Limit, SearchKey, out Count, "", IdCheDoBH);
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
