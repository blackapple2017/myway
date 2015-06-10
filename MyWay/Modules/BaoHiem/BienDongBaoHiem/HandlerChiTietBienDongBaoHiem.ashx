<%@ WebHandler Language="C#" Class="HandlerChiTietBienDongBaoHiem" %>

using System;
using System.Web;

public class HandlerChiTietBienDongBaoHiem : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 5;
        var MaNhanVien = context.Request["MaNhanVien"];
        string SearchKey = context.Request["SearchKey"];
       // bool IsDaNghi = false;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        //if (!string.IsNullOrEmpty(SearchKey))
        //    SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        //if (!string.IsNullOrEmpty(context.Request["Loc"]))
        //    IsDaNghi = bool.Parse(context.Request["Loc"]);

        System.Collections.Generic.List<ChiTietNhanVienBienDongInfo> data = null;
            //GetDM_CBInfoByMaDonVi(string madonvi, string maphong, string mato, int start, int limit, out int count, string searchkey, bool IsDaNghi)
            data = new QuanLyBienDongBaoHiemController().GetChiTienNhanVienBienDong(MaNhanVien, start, limit, out count);

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));


    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}