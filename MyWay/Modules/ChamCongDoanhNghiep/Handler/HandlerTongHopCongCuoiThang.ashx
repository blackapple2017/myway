<%@ WebHandler Language="C#" Class="HandlerTongHopCongCuoiThang" %>

using System;
using System.Web;

public class HandlerTongHopCongCuoiThang : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int Start = 0;
        int Limit = 30;
        int Count = 0;
        int Month = DateTime.Now.Month;
        int Year = DateTime.Now.Year;
        string searchKey = string.Empty;
        Start = int.Parse("0" + context.Request["start"]);
        Limit = int.Parse("0" + context.Request["limit"]);
        string maBoPhan = "";
        int userID = 0;
        int menuID = 0;
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["searchKey"]) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["Month"]))
        {
            Month = int.Parse(context.Request["Month"]);
        }
        if (!string.IsNullOrEmpty(context.Request["Year"]))
        {
            Year = int.Parse(context.Request["Year"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MaBoPhan"]))
        {
            maBoPhan = context.Request["MaBoPhan"];
        }
        if (!string.IsNullOrEmpty(context.Request["userID"]))
        {
            userID = int.Parse(context.Request["userID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["menuID"]))
        {
            menuID = int.Parse(context.Request["menuID"]);
        }
        var table = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_GetAllTongHopCongCuoiThang", "@Start", "@Limit", "@searchKey", "@Month", "@Year", "@MaDonVi", "@menuID", "@userID",
                Start, Limit, searchKey, Month, Year, maBoPhan, menuID, userID);
        var c = DataController.DataHandler.GetInstance().ExecuteScalar("ChamCong_GetCountTongHopCongCuoiThang", "@searchKey", "@Month", "@Year", "@MaDonVi", "@menuID", "@userID", searchKey, Month, Year, maBoPhan, menuID, userID);
        Count = int.Parse(c.ToString());
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(table), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}