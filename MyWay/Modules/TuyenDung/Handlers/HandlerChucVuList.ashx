<%@ WebHandler Language="C#" Class="HandlerChucVuList" %>

using System;
using System.Web;

public class HandlerChucVuList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {       
        context.Response.ContentType = "text/json";
        var query = context.Request["query"];
        var CVs = new DM_CHUCVUController().GetALL();
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(CVs), CVs.Count));
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}