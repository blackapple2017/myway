<%@ WebHandler Language="C#" Class="KetQuaThiTuyenHandler" %>

using System;
using System.Web;

public class KetQuaThiTuyenHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var maUngVien = 0;
        var maVongPV = 0;

        if (!string.IsNullOrEmpty(context.Request["maUngVien"]))
        {
            maUngVien = int.Parse(context.Request["maUngVien"]);
        }
        if (!string.IsNullOrEmpty(context.Request["maVongPV"]))
        {
            maVongPV = int.Parse(context.Request["maVongPV"]);
        }
        var data = new KetQuaThiTuyenController().GetAll(maUngVien, maVongPV);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), data.Rows.Count));
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}