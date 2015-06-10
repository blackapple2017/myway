<%@ WebHandler Language="C#" Class="DuyetDonXinNghi" %>

using System;
using System.Web;

public class DuyetDonXinNghi : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 15;
        int count = 0;
        var MaDonVi = context.Request["MaDonVi"];
        var MaCanBo = context.Request["MaCB"];
        string LocTheoTrangThai = context.Request["LocTheoTrangThai"];
        string SearchKey = context.Request["SearchKey"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
            start = int.Parse(context.Request["start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["limit"]))
            limit = int.Parse(context.Request["limit"].ToString());
        if (!string.IsNullOrEmpty(SearchKey))
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        bool hcsnduyet = bool.Parse(context.Request["HCSNDuyet"].ToString());
        System.Collections.Generic.List<DonXinNghiInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            data = new DonXinNghiController().GetAllDuyetDonXinNghi(MaDonVi, MaCanBo, start, limit, SearchKey, hcsnduyet,LocTheoTrangThai, out count);

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