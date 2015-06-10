<%@ WebHandler Language="C#" Class="KeHoachDaoTao" %>

using System;
using System.Web;

public class KeHoachDaoTao : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 10;
        var SearchKey = string.Empty;
        var Count = 0;
        string MaDonVi = string.Empty;
        string TrangThai = context.Request["TrangThai"];

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

        var daotao = new DaoTaoController().GetKeHoachDaoTao(MaDonVi, Start, Limit, out Count, SearchKey, TrangThai);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(daotao), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}