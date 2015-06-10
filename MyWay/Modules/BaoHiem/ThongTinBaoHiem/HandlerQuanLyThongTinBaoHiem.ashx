<%@ WebHandler Language="C#" Class="HandlerQuanLyThongTinBaoHiem" %>

using System;
using System.Web;

public class HandlerQuanLyThongTinBaoHiem : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var MaDonVi = context.Request["MaDonVi"];
        var Thang = DateTime.Now.Month;
        var Nam = DateTime.Now.Year;
        var ParentTCID = string.Empty;
        var Count = 0;
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
        if (!string.IsNullOrEmpty(context.Request["Thang"]))
        {
            Thang = int.Parse(context.Request["Thang"]);
        }
        if (!string.IsNullOrEmpty(context.Request["Nam"]))
        {
            Nam = int.Parse(context.Request["Nam"]);
        }

        var data = new QuanLyThongTinBaoHiemController().GetNhanVienBaoHiem(MaDonVi, Start, Limit, SearchKey, out Count);
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