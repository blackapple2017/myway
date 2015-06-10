<%@ WebHandler Language="C#" Class="ChonNguoiChamThiHandler" %>

using System;
using System.Web;

public class ChonNguoiChamThiHandler : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/json";
        var start = 0;
        var limit = 4;
        var KeHoachTuyenDung = 0;
        int Count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["KeHoachTuyenDung"]))
        {
            KeHoachTuyenDung = int.Parse(context.Request["KeHoachTuyenDung"]);
        }


        Count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("dbo.TuyenDung_Count_ChonNguoiChamThi", "@KeHoachTuyenDung", KeHoachTuyenDung).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_ChonNguoiChamThi", "@start", "@limit", "@KeHoachTuyenDung", start, limit, KeHoachTuyenDung);

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }        
    public bool IsReusable {
        get {
            return false;
        }
    }

}