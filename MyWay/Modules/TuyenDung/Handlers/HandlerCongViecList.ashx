<%@ WebHandler Language="C#" Class="HandlerCongViecList" %>

using System;
using System.Web;

public class HandlerCongViecList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/json";
        var query = context.Request["query"];
        var CVs = new DM_CONGVIECController().GetAll();
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(CVs), CVs.Count));       
    } 
    public bool IsReusable {
        get {
            return false;
        }
    }

}