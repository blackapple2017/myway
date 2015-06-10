<%@ WebHandler Language="C#" Class="ChamCongTheoThangHandler" %>

using System;
using System.Web;

public class ChamCongTheoThangHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var searhKey = context.Request["SearhKey"];
        var idBangChamLuong = 0; 
        int start = 0;
        int limit = 30;
        int count = 0;
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
            idBangChamLuong = int.Parse(context.Request["IdBangChamCong"]);
        }
        else
        {
            idBangChamLuong = -1;// new ChamCongThangController().GetCurrentByDatetime(MaDonVi).ID;  
        }
        System.Collections.Generic.IEnumerable<BangChamCongThangInfo> data = null;
        if (string.IsNullOrEmpty(searhKey))
            data = new ChamCongThangController().GetDataForGrid(idBangChamLuong, "", start, limit, out count);
        else
        {
            searhKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searhKey) + "%";
            data = new ChamCongThangController().GetDataForGrid(idBangChamLuong, searhKey, start, limit, out count);
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