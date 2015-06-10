\
<%@ WebHandler Language="C#" Class="HandlerCacMonThiTuyen" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Data;

public class HandlerCacMonThiTuyen : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var searchKey = string.Empty;
        var maDonVi = string.Empty;
        var count = 0;
        var planID = int.Parse("0" + context.Request["PlanID"].ToString());
        //var monThi = new CacMonThiTuyenController().GetAllByPlanID(planID);
        DataTable monThi = new DataTable();
        monThi = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetCacMonThiTuyenByPlanID", "@PlanID", planID);
        //context.Response.Write(string.Format(string.Format("{{'Data':{0}}}", Ext.Net.JSON.Serialize(monThi))));
        count = monThi.Rows.Count;
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(monThi), count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}