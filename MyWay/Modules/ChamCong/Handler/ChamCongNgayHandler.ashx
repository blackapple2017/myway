<%@ WebHandler Language="C#" Class="ChamCongNgayHandler" %>

using System;
using System.Web;

public class ChamCongNgayHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var SearhKey = context.Request["SearchKey"];
        var idBangChamCong = 0;
        int start = 0;
        int limit = 30;
        int count = 0;
        int day = DateTime.Now.Day;
        if (!string.IsNullOrEmpty(context.Request["DayInMonth"]))
        {
            day = int.Parse(context.Request["DayInMonth"]);
        }
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["IdBangChamCong"]))
        {
            idBangChamCong = int.Parse(context.Request["IdBangChamCong"]);
        }
        else
        {
            idBangChamCong = -1;
        }
        if (string.IsNullOrEmpty(SearhKey))
        {
            SearhKey = "";
        }
        else
        {
            SearhKey = SoftCore.Util.GetInstance().GetKeyword(SearhKey);
        } 
        System.Data.DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("chamcong_BangCongNgay", "@start", "@limit", "@searchkey", "@idBangCong", "@day", start, limit, SearhKey, idBangChamCong, day);
        object obj = DataController.DataHandler.GetInstance().ExecuteScalar("chamcong_CountBangCongNgay", "@searchkey", "idBangCong", "@day", SearhKey, idBangChamCong, day);
        if (obj != null)
        {
            count = int.Parse(obj.ToString()); 
        }
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