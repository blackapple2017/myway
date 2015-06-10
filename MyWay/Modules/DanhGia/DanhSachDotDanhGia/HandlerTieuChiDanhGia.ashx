<%@ WebHandler Language="C#" Class="HandlerTieuChiDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerTieuChiDanhGia : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 10;
        var Count = 0;
        string MaDonVi = context.Request["MaDonVi"];
        string MaDotDanhGia = string.Empty;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MaDotDanhGia"]))
        {
            MaDotDanhGia = context.Request["MaDotDanhGia"]; 
        }

        var data = new TieuChi_DotDanhGiaController().GetByMaDotDanhGia(Start, Limit, MaDotDanhGia, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}