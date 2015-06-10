<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        string MaDonVi = context.Request["MaDonVi"];
        string MaPhong = context.Request["MaPhong"];
        string MaTo = context.Request["MaTo"];
        string SearchKey = context.Request["SearchKey"];
        int roleID = -1;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"].ToString());
        }
        if (!string.IsNullOrEmpty(SearchKey))
        {
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["RoleID"]))
        {
            roleID = int.Parse(context.Request["RoleID"]);
        }
        System.Collections.Generic.List<SoftCore.User.UserInfo> data = new UserController().GetUsersListByMaDonVi(MaDonVi, SearchKey, start, limit, out count, roleID);
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