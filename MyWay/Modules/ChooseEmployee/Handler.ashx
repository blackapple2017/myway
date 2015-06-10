<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 20;
        string maDonVi = context.Request["MaDonVi"];
        string searchKey = context.Request["SearchKey"];
        bool isDaNghi = false;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"].ToString());
        }
        if (!string.IsNullOrEmpty(searchKey))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["Loc"]))
        {
            isDaNghi = bool.Parse(context.Request["Loc"]);
        }
        System.Collections.Generic.List<DM_CBInfo> data = null;
        
        data = new HoSoController().GetHOSOInfoByMaDonVi(maDonVi, start, limit, out count, searchKey, isDaNghi);
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