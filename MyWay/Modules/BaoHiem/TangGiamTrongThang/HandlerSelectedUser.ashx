<%@ WebHandler Language="C#" Class="HandlerSelectedUser" %>

using System;
using System.Web;

public class HandlerSelectedUser : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 20;
        var SearchKey = string.Empty;
        var MaDonVi = string.Empty;
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
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            MaDonVi = context.Request["MaDonVi"]; 
        }
        System.Data.DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("GetNhanVienByMaCanBo", 
                "@Start", "@Limit", "@MaDonVi", "@SearchKey", Start, Limit, MaDonVi, SearchKey);
        Count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountNhanVienByMaCanBo",
                "@MaDonVi", "@SearchKey", MaDonVi, SearchKey).ToString());
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}