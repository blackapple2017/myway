<%@ WebHandler Language="C#" Class="HandlerSearchDanhSachCa" %>

using System;
using System.Web;

public class HandlerSearchDanhSachCa : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var MaDonVi = context.Request["MaDonVi"];
        var Count = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["query"]) + "%";
        }
        var data = new Controller.ChamCongDoanhNghiep.DanhSachCaController().MiniGetAll(Start, Limit, SearchKey, MaDonVi, out Count);
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