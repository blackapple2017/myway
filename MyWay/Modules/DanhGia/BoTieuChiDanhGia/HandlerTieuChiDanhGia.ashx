<%@ WebHandler Language="C#" Class="HandlerTieuChiDanhGia" %>

using System;
using System.Web;
using Controller.DanhGia;

public class HandlerTieuChiDanhGia : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var MaDonVi = string.Empty;//context.Request["MaDonVi"];
        var ParentTCID = string.Empty;
        var Count = 0;

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
        string bienDoi = string.Empty;
        if (!string.IsNullOrEmpty(context.Request["ParentTCID"]))
        {
            ParentTCID = context.Request["ParentTCID"];

            string[] tmp = ParentTCID.Split(',');
            foreach (var item in tmp)
            {
                if (item != "")
                    bienDoi += "'" + item + "',";
            }
            int pos = bienDoi.LastIndexOf(',');
            if (pos != -1)
                bienDoi = bienDoi.Substring(0, pos);
        }
        if (bienDoi == "-1" || bienDoi == "")
            bienDoi = "'" + "'";
        if (ParentTCID == "-1")
            ParentTCID = "";

        var data = new TieuChiDanhGiaController().GetAllRecord(Start, Limit, SearchKey, MaDonVi, ParentTCID, bienDoi, out Count);
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
