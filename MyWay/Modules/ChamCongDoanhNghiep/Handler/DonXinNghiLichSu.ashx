<%@ WebHandler Language="C#" Class="DonXinNghiLichSu" %>

using System;
using System.Web;

public class DonXinNghiLichSu : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int IDDonXinNghi = 0;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["IDDonXinNghi"]))
            IDDonXinNghi = int.Parse(context.Request["IDDonXinNghi"]);


        System.Collections.Generic.List<DonXinNghiLichSuInfo> data = null;
        data = new DonXinNghiController().GetAllDonXinNghiLichSu(IDDonXinNghi, out count);

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