<%@ WebHandler Language="C#" Class="HandlerDangKyDongMoi" %>

using System;
using System.Web;

public class HandlerDangKyDongMoi : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var MaDonVi = context.Request["MaDonVi"];
        var Thang = DateTime.Now.Month;
        var Nam = DateTime.Now.Year;
        var ParentTCID = string.Empty;
        var Count = 0;
        bool loaihd = bool.Parse(context.Request["LoaiHD"]);
        //bool ngaydilam = bool.Parse(context.Request["NgayDiLam"]);
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        //if (!string.IsNullOrEmpty(context.Request["Thang"]))
        //{
        //    Thang = int.Parse(context.Request["Thang"]);
        //}
        //if (!string.IsNullOrEmpty(context.Request["Nam"]))
        //{
        //    Nam = int.Parse(context.Request["Nam"]);
        //}

        var data = new DangKyDongMoiController().GetDangKyDongMoi(Start, Limit, SearchKey, MaDonVi, out Count, true,loaihd);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}