<%@ WebHandler Language="C#" Class="HandlerHoSoDienBienLuong" %>

using System;
using System.Web;

public class HandlerHoSoDienBienLuong : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 10;
        var Count = 0;
        decimal PrkeyHoSo = 0;
        var SearchKey = string.Empty;

        if (!string.IsNullOrEmpty(context.Request["Start"]))
        {
            Start = int.Parse(context.Request["Start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["Limit"]))
        {
            Limit = int.Parse(context.Request["Limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["PrKeyHoSo"]))
        {
            PrkeyHoSo = decimal.Parse(context.Request["PrKeyHoSo"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]) + "%";
        }

        var data = new HoSoLuongController().GetAll(PrkeyHoSo, Start, Limit, SearchKey, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}