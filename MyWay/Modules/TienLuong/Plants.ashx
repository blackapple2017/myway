<%@ WebHandler Language="C#" Class="Plants" %>

using System;
using System.Web;

public class Plants : IHttpHandler {
    
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";

        var start = 0;
        var limit = 10;
        var sort = string.Empty;
        var dir = string.Empty;
        var query = string.Empty;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }

        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }

        if (!string.IsNullOrEmpty(context.Request["sort"]))
        {
            sort = context.Request["sort"];
        }

        if (!string.IsNullOrEmpty(context.Request["dir"]))
        {
            dir = context.Request["dir"];
        }

        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = context.Request["query"];
        }

        Ext.Net.Paging<Ext.Net.Examples.Examples.Form.ComboBox.Custom_Search.Plant> plants = Ext.Net.Examples.Examples.Form.ComboBox.Custom_Search.Plant.PlantsPaging(start, limit, sort, dir, query);

        context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", Ext.Net.JSON.Serialize(plants.Data), plants.TotalRecords));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
 

}