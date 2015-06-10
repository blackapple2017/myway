<%@ WebHandler Language="C#" Class="HandlerKetQuaDanhGia_DotDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerKetQuaDanhGia_DotDanhGia : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 20;
        var SearchKey = string.Empty;
        var Count = 0;
        string madonvi;
        madonvi = string.Empty; //context.Request["MaDonVi"];
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

        var data = new DotDanhGiaController().GetAllRecord(Start, Limit, SearchKey, madonvi, "", true, 0, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
