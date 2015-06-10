<%@ WebHandler Language="C#" Class="HandlerFindHoso" %>

using System;
using System.Web;

public class HandlerFindHoso : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       context.Response.ContentType = "text/json";
        int count = 0;
        var query = string.Empty;
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = context.Request["query"];
           // query = SoftCore.Util.GetInstance().GetKeyword(query);
        }
        if (!string.IsNullOrEmpty(query))
            query = query.Trim();
        var re = new HoSoController().FindHoso(query, out count);
        context.Response.Write(string.Format("{{total:{1},'Hosos':{0}}}", Ext.Net.JSON.Serialize(re), count));
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}