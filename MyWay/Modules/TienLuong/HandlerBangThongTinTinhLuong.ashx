<%@ WebHandler Language="C#" Class="HandlerBangThongTinTinhLuong" %>

using System;
using System.Web;

public class HandlerBangThongTinTinhLuong : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 10;
        var searchKey = string.Empty;
        var count = 0;
        int IdBangLuong = int.Parse("0" + context.Request["hdfIdBangLuong"]);
        string maDonVi = context.Request["MaDonVi"];
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            searchKey = context.Request["SearchKey"];
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(searchKey) + "%";
        } 
        IdBangLuong = 73;
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("WorldGame_BangThanhToanLuong", "@idBangLuong", "@maDOnVi", "@start", "@limit", "@searchKey",
                                                                                                             IdBangLuong, maDonVi, start, limit, searchKey);
        //   Count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("ChiTietBangLuong_GetCount", "@idBangLuong", IdBangLuong).ToString());
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