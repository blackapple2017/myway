<%@ WebHandler Language="C#" Class="HandlerDangKyLamThemGio" %>

using System;
using System.Web;

public class HandlerDangKyLamThemGio : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 30;
        var maDonVi = string.Empty;
        var searchKey = string.Empty;
        var count = 0;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"].ToString()))
        {
            maDonVi = context.Request["MaDonVi"].ToString();
        }
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            searchKey = SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]).Replace(' ', '%');
        }
        if (!string.IsNullOrEmpty(context.Request["Month"]))
        {
            month = int.Parse(context.Request["Month"]);
        }
        if (!string.IsNullOrEmpty(context.Request["Year"]))
        {
            year = int.Parse(context.Request["Year"]);
        }
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("ChamCong_CountPhieuLamThemGio", "@MaDonVi", "@SearchKey", "@Month", "@Year", maDonVi, searchKey, month, year).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_GetAllPhieuLamThemGio", "@Start", "@Limit", "@MaDonVi", "@SearchKey", "@Month", "@Year",
            start, limit, maDonVi, searchKey, month, year);
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