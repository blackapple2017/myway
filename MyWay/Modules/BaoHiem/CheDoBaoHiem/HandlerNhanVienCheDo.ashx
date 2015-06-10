<%@ WebHandler Language="C#" Class="HandlerNhanVienCheDo" %>

using System;
using System.Web;

public class HandlerNhanVienCheDo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        var MaDonVi = context.Request["MaDonVi"];
        string SearchKey = context.Request["SearchKey"];
        //bool IsDaNghi = false;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }

        System.Collections.Generic.List<NhanVienCheDoInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            data = new CheDoBaoHiemController().GetNhanVienCheDo(MaDonVi, start, limit, SearchKey, out count);

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