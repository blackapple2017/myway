<%@ WebHandler Language="C#" Class="HandlerGuiDonNghiPhep" %>

using System;
using System.Web;

public class HandlerGuiDonNghiPhep : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        string macb = "";
        string SearchKey = context.Request["SearchKey"];
        // bool IsDaNghi = false;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["MaCB"]))
            macb = context.Request["MaCB"].ToString();
        if (!string.IsNullOrEmpty(context.Request["Start"]))
            start = int.Parse(context.Request["Start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["Limit"]))
            limit = int.Parse(context.Request["Limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";

        var data = new DonXinNghiController().GetAll(macb, start, limit, SearchKey, out count);

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