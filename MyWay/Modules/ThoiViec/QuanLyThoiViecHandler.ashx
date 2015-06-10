<%@ WebHandler Language="C#" Class="QuanLyThoiViecHandler" %>

using System;
using System.Web;

public class QuanLyThoiViecHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var start = 0;
        var limit = 10;
        var searchKey = string.Empty;
        var maDonVi = context.Request["MaDonVi"];
        var count = 0;
        var Query = string.Empty;
        var tinhTrang = -1;
        var maBoPhan = string.Empty;
        var daTraThe = string.Empty;
        var daTraSo = -1;
        var hoanTatCongNo = -1;
        var banGiaoTaiSan = -1;
        int menuID = -1, userID = -1;

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
        if (!string.IsNullOrEmpty(context.Request["uID"]))
        {
            userID = int.Parse(context.Request["uID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["mID"]))
        {
            menuID = int.Parse(context.Request["mID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["Query"]))
        {
            Query = context.Request["Query"];
        }
        if (Query != "")
        {
            string[] value = Query.Split(';');
            if (value.Length >= 1)
                tinhTrang = value[0] == null ? -1 : int.Parse(value[0].ToString());
            if (value.Length >= 2)
                daTraThe = value[1] == null ? "" : value[1].ToString();
            if (value.Length >= 3)
                daTraSo = value[2] == null ? -1 : int.Parse(value[2]);
            if (value.Length >= 4)
                hoanTatCongNo = value[3] == null ? -1 : int.Parse(value[3]);
            if (value.Length >= 5)
                banGiaoTaiSan = value[4] == null ? -1 : int.Parse(value[4]);
        }

        var data = new Controller.ThoiViec.DanhSachCanBoThoiViecController().GetAll(start, limit, maDonVi, searchKey, tinhTrang, daTraThe, daTraSo, hoanTatCongNo, banGiaoTaiSan, userID, menuID, out count);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}