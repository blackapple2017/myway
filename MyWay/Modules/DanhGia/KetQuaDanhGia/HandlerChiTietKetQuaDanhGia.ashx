<%@ WebHandler Language="C#" Class="HandlerChiTietKetQuaDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerChiTietKetQuaDanhGia : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 20;
        var Count = 0;
        string maDotDanhGia = string.Empty;
        string maCB = string.Empty;
        string SearchKey = string.Empty;

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
            maDotDanhGia = context.Request["MaDotDanhGia"];
        }
        if (!string.IsNullOrEmpty(context.Request["MaCB"]))
        {
            maCB = context.Request["MaCB"]; 
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            //SearchKey = SoftCore.Util.GetInstance().GetKeyword(SearchKey);
        }

        var data = new KetQuaDanhGiaController().GetChiTietKetQuaDanhGia(Start, Limit, maDotDanhGia, maCB, SearchKey, out Count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}