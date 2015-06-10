<%@ WebHandler Language="C#" Class="KeHoachTuyenDung" %>

using System;
using System.Web;

public class KeHoachTuyenDung : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 1;
        var Limit = 10;
        var SearchKey = string.Empty;
        var Count = 0;
        //int IdDotTuyenDung = -1;
        //string MaDonVi = context.Request["MaDonVi"];
        //string SQLQuery = context.Request["SQLQuery"];

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
            SearchKey = SoftCore.Util.GetInstance().GetKeyword(SearchKey);
        }
        //if (!string.IsNullOrEmpty(context.Request["IdDotTuyenDung"]))
        //{
        //    IdDotTuyenDung = int.Parse(context.Request["IdDotTuyenDung"]);
        //}
        //  var kehoach = new KEHOACH_TUYENDUNGController().GetHoSoUngVien(Start, Limit, "%" + SearchKey + "%", out Count, MaDonVi);
        bool checkToHOSO = false;
        if (!string.IsNullOrEmpty(context.Request["checkToHOSO"]))
        {
            checkToHOSO = context.Request["checkToHOSO"] == "false" ? false : true;
        }
        System.Data.DataTable kehoach = DataController.DataHandler.GetInstance().ExecuteDataTable("tuyendung_danhsachUV",
                                                                                                    "@SearchKey",
                                                                                                    "@Start",
                                                                                                    "@Limit",
                                                                                                    "@checkToHOSO", SearchKey, Start, Limit, checkToHOSO);
        object obj = DataController.DataHandler.GetInstance().ExecuteScalar("tuyendung_CountdanhsachUV", "@SearchKey", "@checkToHOSO", SearchKey, checkToHOSO);
        if (obj != null)
        {
            Count = int.Parse(obj.ToString());
        }
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(kehoach), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}