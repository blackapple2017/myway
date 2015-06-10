<%@ WebHandler Language="C#" Class="UngVienTrungTuyen" %>

using System;
using System.Web;

public class UngVienTrungTuyen : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 10;
        var SearchKey = string.Empty;
        var Count = 0;
        var DotTuyenDung = 0;
        var GioiTinh = context.Request["gioiTinhHander"];
        string vitriUngTuyen = context.Request["vitriUngTuyenHanlder"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            SearchKey = context.Request["searchKey"];
            SearchKey = SoftCore.Util.GetInstance().GetKeyword(SearchKey);
        }
        if (!string.IsNullOrEmpty(context.Request["DotTuyenDung"]))
        {
            DotTuyenDung = int.Parse("0" + context.Request["DotTuyenDung"]);
        }
        int month = 0;
        int year = 0;
        if (!string.IsNullOrEmpty(context.Request["month"]))
        {
            month = int.Parse("0" + context.Request["month"]);
        }
        if (!string.IsNullOrEmpty(context.Request["year"]))
        {
            year = int.Parse("0" + context.Request["year"]);
        }
        var rs = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetUngVienTrungTuyen", "@searchKey", "@DotTuyenDung", "@start", "@limit", "@month", "@year", SearchKey, DotTuyenDung, Start, Limit, month, year);
        Count = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetCountUngVienTrungTuyen", "@searchKey", "@DotTuyenDung", "@start", "@limit", "@month", "@year", SearchKey, DotTuyenDung, Start, Limit, month, year));
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(rs), Count));

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}