<%@ WebHandler Language="C#" Class="HandlerDanhGia" %>

using System;
using System.Web;
using Controller.HoSo;

public class HandlerDanhGia : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 10;
        var Count = 0;
        string MaCB = string.Empty;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MaCB"]))
        {
            MaCB = context.Request["MaCB"];
        }
        if (MaCB != "")
        {
            DAL.HOSO hs = new HoSoController().GetByPrKey(decimal.Parse(MaCB));
            MaCB = hs.MA_CB;
        }

        var data = new HoSoDanhGiaController().GetDanhGiaByPrkeyCB(Start, Limit, MaCB, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}