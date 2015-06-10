<%@ WebHandler Language="C#" Class="HandlerDanhSachCheDo" %>

using System;
using System.Web;

public class HandlerDanhSachCheDo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
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
        tungay = DateTime.Parse(context.Request["TuNgay"].ToString());
        denngay = DateTime.Parse(context.Request["DenNgay"].ToString());
        SearchKey = "";//tạm thời để searchkey bằng "" đã xử lý sau

        string mabaocao;
        mabaocao = context.Request["MaBaoCao"].ToString();

        System.Collections.Generic.List<DanhSachCheDoBaoCaoInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            data = new CheDoBaoHiemController().GetDanhSachCheDoBaoCao(MaDonVi, mabaocao, start, limit, tungay, denngay, SearchKey, out count);

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