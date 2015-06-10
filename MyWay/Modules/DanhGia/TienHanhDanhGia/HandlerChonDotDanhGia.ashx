<%@ WebHandler Language="C#" Class="HandlerChonDotDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerChonDotDanhGia : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 10;
        string MaDonVi = context.Request["MaDonVi"];
        string MaCB = context.Request["MaCanBo"];
        bool isNguoiQL = bool.Parse(context.Request["IsNguoiQuanLy"]);
        bool isTuDG = bool.Parse(context.Request["IsTuDanhGia"]);
        int CurrentUserID = int.Parse(context.Request["CurrentID"]);
        decimal prkeyQL = 0;
        var Count = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        DAL.HOSO hs = new HoSoController().GetByUserID(CurrentUserID);
        if (hs != null)
        {
            prkeyQL = hs.PR_KEY; 
        }
        System.Data.DataTable data = new System.Data.DataTable();
        if (isNguoiQL)
        {
            data = new DotDanhGiaController().GetAllRecord(Start, Limit, "", MaDonVi, "Đang thực hiện", false, prkeyQL, out Count); 
        }
        else if (isTuDG)
        {
            data = new DotDanhGiaController().GetDotDanhGiaTuDanhGia(Start, Limit, MaCB, MaDonVi, "Đang thực hiện", out Count);
        }
        else
        {
            data = new DotDanhGiaController().GetDotDanhGiaNormal(Start, Limit, MaCB, MaDonVi, "Đang thực hiện", out Count);
        }
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}