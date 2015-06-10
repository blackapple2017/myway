<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Linq;
public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        string MaDonVi = context.Request["MaDonVi"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"].ToString());
        }
        SoftCore.Security.RoleController roleController = new SoftCore.Security.RoleController();
        System.Collections.Generic.List<SoftCore.Security.RoleInfo> roleData = roleController.GetAllRoles(0, -1, MaDonVi);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(roleData), roleData.Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}