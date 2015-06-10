<%@ WebHandler Language="C#" Class="HandlerTangGiamBHTrongThang" %>

using System;
using System.Web;

public class HandlerTangGiamBHTrongThang : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var MaDonVi = context.Request["MaDonVi"];
        var Month = DateTime.Now.Month;
        var Year = DateTime.Now.Year;
        var Count = 0;
        int menuID, userID;
        menuID = int.Parse(context.Request["MenuID"]);
        userID = int.Parse(context.Request["UserID"]);
        //bool ngaydilam = bool.Parse(context.Request["NgayDiLam"]);
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
        if (!string.IsNullOrEmpty(context.Request["Month"]))
        {
            Month = int.Parse(context.Request["Month"]);
        }
        if (!string.IsNullOrEmpty(context.Request["Year"]))
        {
            Year = int.Parse(context.Request["Year"]);
        }
        var data = new BHTangGiamBHTrongThangController().getAllInMonth(Start, Limit, Month, Year, SearchKey, MaDonVi, userID, menuID, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}