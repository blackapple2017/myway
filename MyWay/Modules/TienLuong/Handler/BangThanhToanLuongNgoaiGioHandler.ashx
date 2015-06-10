<%@ WebHandler Language="C#" Class="BangThanhToanLuongNgoaiGioHandler" %>

using System;
using System.Web;

public class BangThanhToanLuongNgoaiGioHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 20;
        int count = 0;
        int idBangChamCong = int.Parse("0" + context.Request["IDBangChamCong"]);
        var searchKey = context.Request["SearchKey"];
        //start = int.Parse("0" + context.Request["Start"].ToString());
        //limit = int.Parse("0" + context.Request["Limit"].ToString());
        //if (start == 0)
        //{
        //    start += 1;
        //}

        if (!string.IsNullOrEmpty(searchKey))
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        var data = new BangThanhToanLuongNgoaiGioController().GetAll(idBangChamCong, start, limit, searchKey, out count);
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