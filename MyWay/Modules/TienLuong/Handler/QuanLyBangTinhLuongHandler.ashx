<%@ WebHandler Language="C#" Class="QuanLyBangTinhLuongHandler" %>

using System;
using System.Web;

public class QuanLyBangTinhLuongHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        int count = 0;
        var MaDonVi = context.Request["MaDonVi"];
        //string SearchKey = context.Request["SearchKey"];
        if (!string.IsNullOrEmpty(context.Request["Start"]))
            start = int.Parse(context.Request["Start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["Limit"]))
            limit = int.Parse(context.Request["Limit"].ToString());
        //if (!string.IsNullOrEmpty(SearchKey))
        //    SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        System.Collections.Generic.List<DanhSachBangLuongInfo> data = null;
        data = new DanhSachBangLuongController().GetAll(MaDonVi, start, limit, out count);

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