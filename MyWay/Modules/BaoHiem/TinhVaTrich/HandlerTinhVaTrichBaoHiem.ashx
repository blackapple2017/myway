<%@ WebHandler Language="C#" Class="HandlerTinhVaTrichBaoHiem" %>

using System;
using System.Web;

public class HandlerTinhVaTrichBaoHiem : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int Start = int.Parse("0" + context.Request["start"]);
        int Limit = int.Parse("0" + context.Request["limit"]);
        string SearchKey = string.Empty;
        string MaDonVi = context.Request["MaDonVi"];
        bool LocQuanLyBaoHiem=bool.Parse(context.Request["LocQuanLyBaoHiem"]);
        int IDBangLuong = int.Parse("0" + context.Request["IDBangLuong"]);
        var Count = 0;
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        var data = new BHDONGBAOHIEMTHANGControllor().GetBHDONGBAOHIEMTHANG(MaDonVi, IDBangLuong,LocQuanLyBaoHiem, Start, Limit, SearchKey, out Count);
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