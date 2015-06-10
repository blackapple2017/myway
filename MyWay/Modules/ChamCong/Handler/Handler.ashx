<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 10;
        int count = 0; 
        int year = DateTime.Now.Year;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        string SearchKey = context.Request["SearchKey"];
        if (!string.IsNullOrEmpty(SearchKey))
        {
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        var rs = new Controller.ChamCongDoanhNghiep.DanhSachBangTongHopCongController().GetTimeSheetBoardList(start, limit, SearchKey, "", out count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(rs), count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}