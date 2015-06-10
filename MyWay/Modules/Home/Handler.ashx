<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Keyword = context.Request["keyword"];
        int start = 0;
        int limit = 0;
        int userID = -1;
        int menuID = DepartmentRoleController.MENUID_EMPLOYEE;
        bool isAllEmployee = true;
        var MaDonVi = context.Request["MaDonVi"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(Keyword))
        {
            Keyword = "%" + SoftCore.Util.GetInstance().GetKeyword(Keyword).Replace(' ', '%') + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["UserID"]))
        {
            userID = int.Parse(context.Request["UserID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["IsAllEmployee"]))
        {
            isAllEmployee = bool.Parse(context.Request["IsAllEmployee"]); 
        }
        int count = 0;
        System.Collections.Generic.List<HoSoInfo> data = new HoSoController().GetHoso(start, limit, MaDonVi, out count, Keyword, userID, menuID, isAllEmployee);
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