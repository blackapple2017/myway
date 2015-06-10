<%@ WebHandler Language="C#" Class="BangPhanCaThang" %>

using System;
using System.Web;

public class BangPhanCaThang : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 5;
        int count = 0;
        int userID=0;
        int menuID=0;
        int idbangphanca = int.Parse("0" + context.Request["IDBangPhanCa"].ToString());
        string madonvi = "";

        string SearchKey = context.Request["SearchKey"];
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
            madonvi = context.Request["MaDonVi"].ToString();
        if (!string.IsNullOrEmpty(context.Request["Start"]))
            start = int.Parse(context.Request["Start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["Limit"]))
            limit = int.Parse(context.Request["Limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        if (!string.IsNullOrEmpty(context.Request["UserID"]))
            userID =int.Parse(context.Request["UserID"].ToString());
        if (!string.IsNullOrEmpty(context.Request["MenuID"]))
            menuID = int.Parse(context.Request["MenuID"].ToString());
        var data = new BangPhanCaThangController().GetBangPhanCaThang(madonvi, idbangphanca, start, limit, SearchKey, out count,userID,menuID);

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