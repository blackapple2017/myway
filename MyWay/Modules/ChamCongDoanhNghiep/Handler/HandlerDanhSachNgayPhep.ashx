<%@ WebHandler Language="C#" Class="HandlerDanhSachNgayPhep" %>

using System;
using System.Web;

public class HandlerDanhSachNgayPhep : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 25;
        int Year = DateTime.Now.Year;
        var SearchKey = string.Empty;
        var maBoPhan = string.Empty;
        var Count = 0;
        int menuID = -1, userID = -1;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        menuID = int.Parse(context.Request["MenuID"]);
        userID = int.Parse(context.Request["UserID"]);
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            maBoPhan = context.Request["MaDonVi"]; 
        }
        Year = int.Parse(context.Request["Year"]);
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetTongSoNgayPhep", "@Start", "@Limit", "@SearchKey", "@Year", "@MaDonVi", "@UserID", "@MenuID", Start, Limit, SearchKey, Year, maBoPhan, userID, menuID);
        Count = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("sp_GetCountTongSoNgayPhep", "@SearchKey", "@Year", "@MaDonVi", "@UserID", "@MenuID", SearchKey, Year, maBoPhan, userID, menuID));
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}