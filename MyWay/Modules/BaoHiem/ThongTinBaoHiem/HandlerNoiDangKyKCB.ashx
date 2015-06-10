<%@ WebHandler Language="C#" Class="HandlerNoiDangKyKCB" %>

using System;
using System.Web;

public class HandlerNoiDangKyKCB : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var start = 0;
        var limit = 10;
        var SearchKey = string.Empty;
        var MaDonVi = context.Request["MaDonVi"];
        var count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }

        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }


        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }

        var data = new DM_NOI_KCBController().GetNoiKCB(MaDonVi, SearchKey, start, limit,out count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}