<%@ WebHandler Language="C#" Class="HandlerTongHopCongTheoThang" %>

using System;
using System.Web;
using Controller.ChamCongDoanhNghiep;

public class HandlerTongHopCongTheoThang : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 25;
        int thang, nam, userID, menuID;
        var SearchKey = string.Empty;
        var maBoPhan = "";
        var Count = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        userID = int.Parse(context.Request["UserID"]);
        menuID = int.Parse(context.Request["MenuID"]);
        thang = int.Parse(context.Request["Thang"]);
        nam = int.Parse(context.Request["Nam"]);
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["MaBoPhan"]))
        {
            maBoPhan = context.Request["MaBoPhan"];
        }
        
        var data = new TongHopCongController().GetByAll(Start, Limit, thang, nam, SearchKey, maBoPhan, userID, menuID, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}