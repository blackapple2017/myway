<%@ WebHandler Language="C#" Class="HandlerNhanVienCheDoTheoThang" %>

using System;
using System.Web;

public class HandlerNhanVienCheDoTheoThang : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        int thang = 0;
        int nam = 0;
        if (context.Request["Nam"].ToString() != "")
            nam = Convert.ToInt32(context.Request["Nam"].ToString());
        if (context.Request["Thang"].ToString() != "")
            thang = Convert.ToInt32(context.Request["Thang"].ToString());
        var MaDonVi = context.Request["MaDonVi"];
        string SearchKey = context.Request["SearchKey"];
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";

        System.Collections.Generic.List<NhanVienCheDoTheoThangInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            data = new CheDoBaoHiemController().GetNhanVienCheDoTheoThang(MaDonVi,thang,nam, start, limit, SearchKey, out count);

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