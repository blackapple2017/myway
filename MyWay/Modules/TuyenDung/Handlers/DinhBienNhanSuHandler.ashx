<%@ WebHandler Language="C#" Class="DinhBienNhanSuHandler" %>

using System;
using System.Web;

public class DinhBienNhanSuHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        var uInfo = context.Session["CURRENTUSER"] as SoftCore.User.UserInfo;
        if(uInfo == null) return;
        var type = Convert.ToString(context.Request["Type"]);
        var start = 0;
        var limit = 20;
        switch (type)
        {
         
            case "UpdateGrid":
                int id = Convert.ToInt32(context.Request["Id"]);
                string column = Convert.ToString(context.Request["Column"]);
                int value = Convert.ToInt32(context.Request["Value"]);
                new DinhBienNhanSuController().UpdateColumnValue(id,column,value);
                break;
            case "GetWorkList":
                 if(context.Request["start"]!=string.Empty)
                 start = Convert.ToInt32(context.Request["start"]);
                if (context.Request["limit"] != string.Empty)
                    limit = Convert.ToInt32(context.Request["limit"]);
                var query = string.Empty;
                if (!string.IsNullOrEmpty(context.Request["query"]))
                {
                    query = context.Request["query"];
                    query = "%" + SoftCore.Util.GetInstance().GetKeyword(query) + "%";
                }
                
                int count2 = 0;
                var data2 = new DM_CONGVIECController().GetBySearchKeys(start,limit,query,out count2);
                context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data2), count2));
                break;
            default:
                
                if(context.Request["start"]!=string.Empty)
                 start = Convert.ToInt32(context.Request["start"]);
                if (context.Request["limit"] != string.Empty)
                    limit = Convert.ToInt32(context.Request["limit"]);
                var year = 0;
                if (!string.IsNullOrEmpty(context.Request["Year"]))
                    year = Convert.ToInt32(context.Request["Year"]);
                var maPhong = string.Empty;
                if (!string.IsNullOrEmpty(context.Request["MaPhong"]))
                    maPhong = Convert.ToString(context.Request["MaPhong"]);
                var searchKey = string.Empty;
                if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
                {
                    searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]) + "%";
                    //var searchKey2 = context.Request["SearchKey"];
                    //var searchKey3 = So context.Request["SearchKey"];
                }
                int count = 0;
                var data = new DinhBienNhanSuController().GetByYearAndSearchKey(year,maPhong, searchKey, start, limit, ref count);
                context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
                break;
        }
     
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}