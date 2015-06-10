<%@ WebHandler Language="C#" Class="HandlerDanhSachBienDong" %>

using System;
using System.Web;

public class HandlerDanhSachBienDong : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        var MaDonVi = context.Request["MaDonVi"];
        DateTime tungay, denngay;
        string SearchKey = context.Request["SearchKey"];
        bool IsDaNghi = false;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
            IsDaNghi = bool.Parse(context.Request["SearchKey"]);

        string a = context.Request["TuNgay"].ToString();

        if (!string.IsNullOrEmpty(context.Request["TuNgay"]))
        {
            //string[] date = context.Request["TuNgay"].ToString().Split('-');
            //tungay = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            tungay = DateTime.Parse(context.Request["TuNgay"].ToString());
        }
        else
        {
            tungay = new DateTime(1901, 1, 1);
        }
        if (!string.IsNullOrEmpty(context.Request["DenNgay"]))
        {
            //string[] date = context.Request["DenNgay"].ToString().Split('-');
            //denngay = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            denngay = DateTime.Parse(context.Request["DenNgay"].ToString());
        }
        else
        {
            denngay = new DateTime(2900, 1, 1);
        }
        SearchKey = "";//tạm thời để searchkey bằng "" đã xử lý sau

        System.Collections.Generic.List<DanhSachBienDongInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            data = new QuanLyBienDongBaoHiemController().GetDanhSachBienDong(MaDonVi, start, limit, SearchKey, tungay, denngay, out count);

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