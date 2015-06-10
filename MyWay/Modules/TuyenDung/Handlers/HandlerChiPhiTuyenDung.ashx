<%@ WebHandler Language="C#" Class="HandlerChiPhiTuyenDung" %>
using System;
using System.Web;
using System.Collections.Generic;

public class HandlerChiPhiTuyenDung : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        var searchKey = string.Empty;
        var maDonVi = string.Empty;
        var type = "";
        if (!string.IsNullOrEmpty(context.Request["type"]))
        {
            type = Convert.ToString(context.Request["type"]);
        }
        var maKHTD = int.Parse("0" + context.Request["PlanID"].ToString());
        var cptds = new ChiPhiTuyenDungController().GetRecruitmentCosts(maKHTD);
        context.Response.Write(string.Format("{{'Data':{0}}}", Ext.Net.JSON.Serialize(cptds)));
    }
     
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}