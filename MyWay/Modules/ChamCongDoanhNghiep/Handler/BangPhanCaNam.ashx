<%@ WebHandler Language="C#" Class="BangPhanCaNam" %>

using System;
using System.Web;

public class BangPhanCaNam : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        int count = 0;
        int maBangPhanCa = 0;

        string maDonVi = context.Request["maDonVi"];
        string searchKey = context.Request["searchKey"];

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["maBangPhanCa"]))
        {
            maBangPhanCa = int.Parse(context.Request["maBangPhanCa"]);
        }

        if (!string.IsNullOrEmpty(searchKey))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        }

        var data = new BangPhanCaNamController().GetAll(start, limit, out count, searchKey, maBangPhanCa, maDonVi);
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