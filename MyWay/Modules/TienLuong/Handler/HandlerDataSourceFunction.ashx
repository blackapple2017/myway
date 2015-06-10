<%@ WebHandler Language="C#" Class="HandlerDataSourceFunction" %>

using System;
using System.Web;

public class HandlerDataSourceFunction : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/json";

        var start = 0;
        var limit = 50;
        var sort = string.Empty;
        var dir = string.Empty;
        var query = string.Empty;
        var tableName = string.Empty;
        var ma = string.Empty;
        var ten = string.Empty;
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

        if (!string.IsNullOrEmpty(context.Request["table"]))
        {
            tableName = context.Request["table"];
        }
        if (!string.IsNullOrEmpty(context.Request["ma"]))
        {
            ma = context.Request["ma"];
        }
        if (!string.IsNullOrEmpty(context.Request["ten"]))
        {
            ten = context.Request["ten"];
        }
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["query"]) + "%";
        }
        int count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("SELECT COUNT(ID) FROM DM_DataSourceFunctionSalary dm WHERE dm.IsInUsed = 1").ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT[DataSourceFunction] AS 'MA',[NameFunction] AS 'TEN' FROM DM_DataSourceFunctionSalary dm WHERE dm.IsInUsed = 1");
        //count = data.Rows.Count;

        context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}