<%@ WebHandler Language="C#" Class="CongThucLuongKinhDoanhHandler" %>

using System;
using System.Web;
using System.Data;

public class CongThucLuongKinhDoanhHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var start = 0;
        var limit = 50;
        var searchKey = string.Empty;
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
            searchKey = context.Request["SearchKey"];
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        }

        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("TienLuong_CountCongThucLuongKinhDoanh", "@SearchKey", searchKey).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_GetCongThucLuongKinhDoanh", "@Start", "@Limit", "@SearchKey",
                start, limit, searchKey);
        
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}