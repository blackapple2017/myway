<%@ WebHandler Language="C#" Class="HandlerHopDong" %>

using System;
using System.Web;

public class HandlerHopDong : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        string searchKey = string.Empty;
        int start = 0;
        int limit = 25;
        string maDonVi = string.Empty;
        var data = new System.Data.DataTable();
        int count = 0;
        DateTime? TuNgay = null;
        DateTime? DenNgay = null;
        string LoaiHopDong = string.Empty;
        string ChucDanh = string.Empty;
        string ChucVu = string.Empty;
        string TinhTrangHD = string.Empty;
        int UserID = 0;
        int MenuID = 0;

        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }

        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            string s = context.Request["limit"];
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MaDonVi"]))
        {
            maDonVi = context.Request["MaDonVi"];
        }
        if (!string.IsNullOrEmpty(context.Request["TuNgay"]))
        {
            TuNgay = DateTime.Parse(context.Request["TuNgay"]);
        }
        if (!string.IsNullOrEmpty(context.Request["DenNgay"]))
        {
            DenNgay = DateTime.Parse(context.Request["DenNgay"]);
        }
        if (!string.IsNullOrEmpty(context.Request["LoaiHopDong"]))
        {
            LoaiHopDong = context.Request["LoaiHopDong"];
        }
        if (!string.IsNullOrEmpty(context.Request["ChucDanh"]))
        {
            ChucDanh = context.Request["ChucDanh"];
        }
        if (!string.IsNullOrEmpty(context.Request["ChucVu"]))
        {
            ChucVu = context.Request["ChucVu"];
        }
        if (!string.IsNullOrEmpty(context.Request["TinhTrangHD"]))
        {
            TinhTrangHD = context.Request["TinhTrangHD"];
        }
        if (!string.IsNullOrEmpty(context.Request["UserID"]))
        {
            UserID = int.Parse("0"+context.Request["UserID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["MenuID"]))
        {
            MenuID = int.Parse("0" + context.Request["MenuID"]);
        }

        data = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetAllHopDong", "@MaDonVi", "@SearchKey", "@Start", "@Limit", "@TuNgay", "@DenNgay", "@LoaiHopDong", "@ChucDanh", "@ChucVu", "@TinhTrangHD","@UserID","@MenuID",
                                                                        maDonVi, searchKey, start, limit, TuNgay, DenNgay, LoaiHopDong, ChucDanh, ChucVu, TinhTrangHD,UserID,MenuID);
        var obj = DataController.DataHandler.GetInstance().ExecuteScalar("sp_GetCountHopDong", "@MaDonVi", "@SearchKey", "@TuNgay", "@DenNgay", "@LoaiHopDong", "@ChucDanh", "@ChucVu", "@TinhTrangHD", "@UserID", "@MenuID",
                                                                        maDonVi, searchKey, TuNgay, DenNgay,LoaiHopDong, ChucDanh, ChucVu, TinhTrangHD,UserID,MenuID);
        count = int.Parse("0" + obj.ToString());
        context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}