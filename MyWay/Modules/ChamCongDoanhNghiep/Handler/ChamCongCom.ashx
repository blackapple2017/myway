<%@ WebHandler Language="C#" Class="ChamCongCom" %>

using System;
using System.Web;

public class ChamCongCom : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 25;
        int menuID = 0, userID = 0;
        string Month = context.Request["Month"];
        string Year = context.Request["Year"];
        string SearchKey = context.Request["SearchKey"];
        // bool IsDaNghi = false;

        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        if (!string.IsNullOrEmpty(context.Request["UserID"]))
            userID = int.Parse(context.Request["UserID"]);
        if (!string.IsNullOrEmpty(context.Request["MenuID"]))
            menuID = int.Parse(context.Request["MenuID"]);
            
        var data = new ChamCongComController().GetAllByCombobox(Month,Year,start, limit, out count, SearchKey, menuID, userID);

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