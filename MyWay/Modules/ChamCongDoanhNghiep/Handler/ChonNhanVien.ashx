<%@ WebHandler Language="C#" Class="ChonNhanVien" %>

using System;
using System.Web;

public class ChonNhanVien : IHttpHandler {


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        var start = 0;
        var limit = 4;
        var sort = string.Empty;
        var dir = string.Empty;
        var query = string.Empty;
        int Count = 0;
        var MaDonVi = "";
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = context.Request["query"];
        }
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            System.Collections.Generic.List<string> list = new DM_DONVIController().getChildID(context.Request["MaDonVi"], true);
            foreach (string item in list)
            {
                MaDonVi += item + ",";
            }
            MaDonVi = MaDonVi.Remove(MaDonVi.LastIndexOf(","));
        }
        if (!string.IsNullOrEmpty(context.Request["query"]))
        {
            query = context.Request["query"];
            query = SoftCore.Util.GetInstance().GetKeyword(query);
        }
        // var data = new DM_DOITACDAOTAOController().GetAllRecord(start, limit, query, MaDonVi, out Count);
        var data = GetAllRecord(start, limit, query, MaDonVi.ToString(), out Count);
        //context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));

        context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
    public System.Data.DataTable GetAllRecord(int start, int limit, string query, string MaDonVi, out int count)
    {
        System.Data.DataTable ccount = DataController.DataHandler.GetInstance().ExecuteDataTable("CountDM_NhanVien", "@searchKey", "@MaDonVi", query, MaDonVi);
        count = Convert.ToInt32(ccount.Rows.Count);
        System.Data.DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("GetTaiSanByDonVi", "@start", "@limit", "@searchKey", "@MaDonVi", start, limit, query, MaDonVi);
        return dt;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}