<%@ WebHandler Language="C#" Class="PhieuTraLuongHandler" %>

using System;
using System.Web;

public class PhieuTraLuongHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        int start = 0;
        int limit = 10;
        int count = 0;
        var maCB = context.Request["MaCB"]; 
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());

        var data = new DanhSachBangLuongController().GetSalaryListOfEmployee(maCB, start, limit, out count); 
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}