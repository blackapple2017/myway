<%@ WebHandler Language="C#" Class="ChonBangChamCongHandler" %>

using System;
using System.Web;

public class ChonBangChamCongHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        int count = 0;
        int thang = 0;
        int nam = 0;
        if (context.Request["Thang"] != "")
            thang =int.Parse( context.Request["Thang"].ToString());
        if (context.Request["Nam"] != "")
            nam = int.Parse(context.Request["Nam"].ToString());
        var MaDonVi = context.Request["MaDonVi"];
        //string SearchKey = context.Request["SearchKey"];
        if (!string.IsNullOrEmpty(context.Request["Start"]))
            start = int.Parse(context.Request["Start"].ToString());
        if (!string.IsNullOrEmpty(context.Request["Limit"]))
            limit = int.Parse(context.Request["Limit"].ToString());
        //if (!string.IsNullOrEmpty(SearchKey))
        //    SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        System.Collections.Generic.List<DanhSachBangTongHopCongInfo> data = null;
        data = null;//new  Controller.ChamCongDoanhNghiep.DanhSachBangTongHopCongController().GetByAll(MaDonVi,thang,nam, start, limit,"", out count);

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