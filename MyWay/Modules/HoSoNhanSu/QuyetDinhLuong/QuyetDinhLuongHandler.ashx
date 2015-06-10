<%@ WebHandler Language="C#" Class="QuyetDinhLuongHandler" %>

using System;
using System.Web;

public class QuyetDinhLuongHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 10;
        var count = 0;
        int userID = 0;
        int menuID = 0;
        string maDonVi = context.Request["maDonVi"];
        string searchKey = string.Empty;
        string trangThai = context.Request["trangThai"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["searchKey"]) + "%"; 
        }
        if (!string.IsNullOrEmpty(context.Request["userID"]))
        {
            userID = int.Parse(context.Request["userID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["menuID"]))
        {
            menuID = int.Parse(context.Request["menuID"]);
        }
        //  limit = 100;//tạm thời fix
        var data = new HoSoLuongController().GetAll(maDonVi, start, limit, searchKey, out count, trangThai, userID, menuID);
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