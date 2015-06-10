<%@ WebHandler Language="C#" Class="HopDongHandler" %>

using System;
using System.Web;

public class HopDongHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 10;
        var SearchKey = string.Empty;
        var Count = 0; 
       
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

        var loaiHopDong = new DM_LOAI_HDONGController().GetAll(Start, Limit, SearchKey, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(loaiHopDong), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}