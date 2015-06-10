<%@ WebHandler Language="C#" Class="BangLuongDong" %>

using System;
using System.Web;

public class BangLuongDong : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int start = 0, limit = 30;
        string searchKey = string.Empty;
        int idBangLuong = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"]);
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"]);
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
            searchKey = SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]);
        if (!string.IsNullOrEmpty(context.Request["IDBangLuong"]))
            idBangLuong = int.Parse("0" + context.Request["IDBangLuong"]);

        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_GetBangLuongDong", "@Start", "@Limit", "@SearchKey", "@IdBangLuong", 
            start, limit, searchKey, idBangLuong);
        var count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("TienLuong_CountBangLuongDong", "@SearchKey", "@IdBangLuong", searchKey, idBangLuong).ToString());
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