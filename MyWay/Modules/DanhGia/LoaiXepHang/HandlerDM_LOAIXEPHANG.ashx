<%@ WebHandler Language="C#" Class="HandlerDM_LOAIXEPHANG" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerDM_LOAIXEPHANG : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 20;
        var SearchKey = string.Empty;
        var Count = 0;
        string maDV = string.Empty;//context.Request["MaDonVi"];
        int maLoaiXepHang = -1;

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
        if (!string.IsNullOrEmpty(context.Request["MaLoaiXepHang"]))
        {
            maLoaiXepHang = int.Parse(context.Request["MaLoaiXepHang"]); 
        }

        var data = new LoaiXepHangController().GetAllRecord(Start, Limit, SearchKey, maDV, maLoaiXepHang, out Count);
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
