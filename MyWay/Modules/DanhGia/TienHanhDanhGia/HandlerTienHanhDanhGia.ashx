<%@ WebHandler Language="C#" Class="HandlerTienHanhDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerTienHanhDanhGia : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 20;
        string MaCB = string.Empty;
        string MaDotDanhGia = string.Empty;
        bool IsTuDanhGia = bool.Parse(context.Request["IsTuDanhGia"]);
        bool IsNguoiQL = bool.Parse(context.Request["IsNguoiQL"]);
        var Count = 0; 
        int createdBy = int.Parse(context.Request["CreatedBy"]);
       
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MaCB"]))
        {
            MaCB = context.Request["MaCB"];
        }
        if (!string.IsNullOrEmpty(context.Request["MaDotDanhGia"]))
        {
            MaDotDanhGia = context.Request["MaDotDanhGia"]; 
        }

        System.Data.DataTable data = new System.Data.DataTable();
        data = new TieuChi_DotDanhGiaController().GetTieuChiDanhGiaByMaCB(Start, Limit, MaCB, MaDotDanhGia, createdBy, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
