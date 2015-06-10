<%@ WebHandler Language="C#" Class="GetDownloadLink" %>

using System;
using System.Web;

public class GetDownloadLink : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string fileName = context.Request["FileName"];
        string path = context.Request["Path"];
        context.Response.Clear();
        context.Response.ContentType = "application/octet-stream";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        context.Response.WriteFile(path); //Server.MapPath("\\servername\folder1\folder2\folder3\abc.txt")
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}