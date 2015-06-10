<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        string MaDonVi = context.Request["MaDonVi"];
        string maphong="";
        string mato="";
        string SearchKey = context.Request["SearchKey"];
        bool GetDataFromHoSo = true;  // true: DM_CB  false: HOSO
        bool IsDaNghi = false;
        int count = 0;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"].ToString());
        }
        if (!string.IsNullOrEmpty(SearchKey))
        {
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["Loc"]))
        {
            IsDaNghi = bool.Parse(context.Request["Loc"]);
        }
        if (!string.IsNullOrEmpty(context.Request["GetDataFromHoSo"]))
        {
            GetDataFromHoSo = bool.Parse(context.Request["GetDataFromHoSo"]);
        }

        System.Collections.Generic.List<BHNHANVIEN_BAOHIEMInfo> data = null;
        if (!string.IsNullOrEmpty(MaDonVi))
            //GetDM_CBInfoByMaDonVi(string madonvi, string maphong, string mato, int start, int limit, out int count, string searchkey, bool IsDaNghi)
            data = new NhanVien_BaoHiemController().GetHoSoInfoByMaDonVi(MaDonVi,maphong,mato,start, limit, out count, SearchKey, IsDaNghi);

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