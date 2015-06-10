<%@ WebHandler Language="C#" Class="HandlerQuanLyBienDong" %>

using System;
using System.Web;

public class HandlerQuanLyBienDong : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        var MaDonVi = context.Request["MaDonVi"];
        string SearchKey = context.Request["SearchKey"];
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
      
        System.Collections.Generic.List<NhanVienBienDongInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            //GetDM_CBInfoByMaDonVi(string madonvi, string maphong, string mato, int start, int limit, out int count, string searchkey, bool IsDaNghi)
        data = new QuanLyBienDongBaoHiemController().GetNhanVienBienDong(MaDonVi,start,limit,SearchKey,out count);

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