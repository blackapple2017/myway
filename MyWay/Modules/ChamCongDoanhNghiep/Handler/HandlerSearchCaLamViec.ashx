<%@ WebHandler Language="C#" Class="HandlerSearchCaLamViec" %>

using System;
using System.Web;
using Controller.ChamCongDoanhNghiep;

public class HandlerSearchCaLamViec : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/json";

        var start = 0;
        var limit = 10;
        var sort = string.Empty;
        var dir = string.Empty;
        var query = string.Empty;
        var maDonVi = context.Request["MaDonVi"];

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }

        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }

        if (!string.IsNullOrEmpty(context.Request["sort"]))
        {
            sort = context.Request["sort"];
        }

        if (!string.IsNullOrEmpty(context.Request["dir"]))
        {
            dir = context.Request["dir"];
        }

        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["query"]) + "%";
        }
        int count = 0;
        var data = new DanhSachCaController().MiniGetAll(start, limit, query, maDonVi, out count);

        context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}