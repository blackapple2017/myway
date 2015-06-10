<%@ WebHandler Language="C#" Class="HandlerQuanLyNghiBu" %>

using System;
using System.Web;
using DataController;

public class HandlerQuanLyNghiBu : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 30;
        int year = 0;
        string SearchKey = context.Request["SearchKey"];
        // bool IsDaNghi = false;
        var maBoPhan = string.Empty;
        int menuID = -1, userID = -1;
        int count = 0;
        menuID = int.Parse(context.Request["MenuID"]);
        userID = int.Parse(context.Request["UserID"]);
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            maBoPhan = context.Request["MaDonVi"];
        }
        if (!string.IsNullOrEmpty(context.Request["year"]))
            year = int.Parse("0" + context.Request["year"].ToString());
        if (!string.IsNullOrEmpty(context.Request["Start"]))
            start = int.Parse(context.Request["Start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["Limit"]))
            limit = int.Parse(context.Request["Limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";

        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("ChamCong_QuanLyNghiBu_Count", "@Year", "@SearchKey", "@MaDonVi", "@UserID", "@MenuID", year, SearchKey, maBoPhan, userID, menuID).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_QuanLyNghiBu", "@start", "@limit", "@Year", "@SearchKey", "@MaDonVi", "@UserID", "@MenuID", start, limit, year, SearchKey, maBoPhan, userID, menuID);


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