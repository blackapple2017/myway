<%@ WebHandler Language="C#" Class="NghiDaiNgay" %>

using System;
using System.Web;

public class NghiDaiNgay : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        int count = 0;
        var MaDonVi = context.Request["MaDonVi"];
        string SearchKey = context.Request["SearchKey"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        
        System.Collections.Generic.List<NghiDaiNgayInfo> data = null;
            data = new NghiDaiNgayController().GetAll(MaDonVi, start, limit, SearchKey, out count);

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