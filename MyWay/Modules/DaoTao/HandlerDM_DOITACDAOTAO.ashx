<%@ WebHandler Language="C#" Class="HandlerDM_DOITACDAOTAO" %>

using System;
using System.Web;

public class HandlerDM_DOITACDAOTAO : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        int Start = 0;
        int Limit = 10;
        string SearchKey = string.Empty;
        int Count = 0;
        string MaDonVi = string.Empty;
       
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            MaDonVi = context.Request["MaDonVi"]; 
        }

        var data = new DoiTacDaoTaoController().GetAllRecord(Start, Limit, SearchKey, MaDonVi, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
