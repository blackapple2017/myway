<%@ WebHandler Language="C#" Class="HandlerCanBoBiDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerCanBoBiDanhGia : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 20;
        var Count = 0;
        string MaDotDanhGia = string.Empty;
        string MaCB = context.Request["MaCB"];
        string MaBoPhan = context.Request["MaBoPhan"];
        bool IsTuDanhGia = bool.Parse(context.Request["IsTuDanhGia"]);
        bool IsNguoiQL = bool.Parse(context.Request["IsNguoiQL"]);
        int createdBy = int.Parse(context.Request["CreatedBy"]);

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

        System.Data.DataTable data = new System.Data.DataTable();
        if (IsNguoiQL)  // Lấy danh sách cán bộ người quản lý được đánh giá
        {
            data = new CanBoDuocDanhGiaController().GetAllRecord(Start, Limit, MaDotDanhGia, createdBy, out Count);
        }
        else if (IsTuDanhGia)   // Cán bộ tự đánh giá
        {
            data = new CanBoDuocDanhGiaController().GetAllCanBoTuDanhGia(Start, Limit, MaCB, MaDotDanhGia, createdBy, out Count);
        }
        else  // đánh giá thông thường
        {
            data = new CanBoDuocDanhGiaController().GetAllCanBoNormal(Start, Limit, MaDotDanhGia, MaBoPhan, MaCB, createdBy, out Count);
        }
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}