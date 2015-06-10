<%@ WebHandler Language="C#" Class="HandlerQuanLyBangTinhVaTrich" %>

using System;
using System.Web;

public class HandlerQuanLyBangTinhVaTrich : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        var Start =  int.Parse("0"+context.Request["start"]);
        var Limit = int.Parse("0"+context.Request["limit"]);
        var MaDonVi = context.Request["MaDonVi"];
        var Count = 0; 
        var data = new TinhVaTrichController().GetThangTrich(MaDonVi, Start, Limit, out Count);
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