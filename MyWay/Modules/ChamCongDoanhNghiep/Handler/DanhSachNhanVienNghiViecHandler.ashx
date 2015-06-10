<%@ WebHandler Language="C#" Class="DanhSachNhanVienNghiViecHandler" %>

using System;
using System.Web;

public class DanhSachNhanVienNghiViecHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        int count = 0;
        string maDonVi = context.Request["maDonVi"];

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }

        var data = new DanhSachNgayPhepController().GetNhanVienDaNghi(start, limit, maDonVi, -1, out count);
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