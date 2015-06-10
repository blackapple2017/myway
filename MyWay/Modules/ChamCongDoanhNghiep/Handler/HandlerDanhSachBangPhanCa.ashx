<%@ WebHandler Language="C#" Class="HandlerDanhSachBangPhanCa" %>

using System;
using System.Web;

public class HandlerDanhSachBangPhanCa : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        string maDonVi = string.Empty;
        int count = 0;
        int month = -1;
        int year = -1;
        int userID = 0;
        int menuID = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"]);
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"]);
        maDonVi = context.Request["maDonVi"];
        if (!string.IsNullOrEmpty(context.Request["month"]))
            month = int.Parse(context.Request["month"]);
        if (!string.IsNullOrEmpty(context.Request["year"]))
            year = int.Parse(context.Request["year"]);
        if (!string.IsNullOrEmpty(context.Request["userID"]))
        {
            userID = int.Parse(context.Request["userID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["menuID"]))
        {
            menuID = int.Parse(context.Request["menuID"]);
        }
        var data = new DanhSachBangPhanCaController().GetAllByMonthYear(maDonVi, month, year, start, limit, out count, userID, menuID);
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