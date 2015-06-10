<%@ WebHandler Language="C#" Class="QuanLyBangPhanCaHandler" %>

using System;
using System.Web;

public class QuanLyBangPhanCaHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        int count = 0;
        string thanghaynam = context.Request["ThangHayNam"].ToString();
        string maDonVi = context.Request["maDonVi"];

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }

        var data = new DanhSachBangPhanCaController().GetByMaDonVi(maDonVi, -1, -1, start, limit, out count,thanghaynam);
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