<%@ WebHandler Language="C#" Class="DanhSachBangLuong" %>

using System;
using System.Web;

public class DanhSachBangLuong : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        string MaDonVi = string.Empty;
        int MenuID = 0;
        int count = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"]);
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"]);
        MaDonVi = context.Request["MaDonVi"];
        if (!string.IsNullOrEmpty(context.Request["MenuID"]))
            MenuID = int.Parse("0" + context.Request["MenuID"]);

        var data = new DanhSachBangLuongController().GetByMenuID(MaDonVi, MenuID, start, limit, out count);
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