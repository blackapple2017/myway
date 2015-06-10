<%@ WebHandler Language="C#" Class="HandlerDangKyLamThemGio" %>

using System;
using System.Web;

public class HandlerDangKyLamThemGio : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var start = 0;
        var limit = 30;
        var searchKey = string.Empty;
        var count = 0;
        DateTime? dateTu = new DateTime();
        DateTime? dateDen = new DateTime();

        string madonvi = context.Request["MaDonVi"].ToString();
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
            searchKey = SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]);
        }
        if (!string.IsNullOrEmpty(context.Request["TuNgay"]))
        {
            string[] date = context.Request["TuNgay"].ToString().Split('/');
            dateTu = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            //dateDen = DateTime.Parse(context.Request["DenNgay"]);
        }
        else
        {
            dateTu = new DateTime(1901, 1, 1);
        }
        if (!string.IsNullOrEmpty(context.Request["DenNgay"]))
        {
            string[] date = context.Request["DenNgay"].ToString().Split('/');
            dateDen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            //dateDen = DateTime.Parse(context.Request["DenNgay"]);
        }
        else
        {
            dateDen = new DateTime(2900, 1, 1); 
        }

        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("ChamCong_CountDangKyLamThemGio", "@TuNgay", "@DenNgay", "@SearchKey", 
            dateTu, dateDen, searchKey).ToString());
        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_GetAllDangKyLamThemGio", "@MaDonVi", "@Start", "@Limit", "@TuNgay", "@DenNgay", "@SearchKey",
            madonvi, start, limit, dateTu, dateDen, searchKey);
        foreach (System.Data.DataRow row in data.Rows)
        {
            int tgian = new TimeController().GetTotalTimeInMinutes(row["GioBatDauSauCa"].ToString(), row["GioKetThucSauCa"].ToString());
            if (tgian % 60 == 0)
                row["TongGio"] = (tgian / 60) + " giờ";
            else
                row["TongGio"] = (tgian / 60) + " giờ " + (tgian % 60) + " phút";
        }
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