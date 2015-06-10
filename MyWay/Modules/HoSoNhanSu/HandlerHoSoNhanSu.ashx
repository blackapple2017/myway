<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Ext.Net;
using System.Collections.Generic;
using SoftCore.Security;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var Count = 0;
        string MaDonVi = context.Request["MaDonVi"].ToString();
        string Query = context.Request["Query"].ToString();
        string MA_GIOITINH = "", MA_TRINHDO = "", DIA_CHI_LH = "", MA_LOAI_HDONG = "", MA_CONGVIEC = "";
        string MA_CHUYENNGANH = "", MA_TINHTHANH = "", DI_DONG = "", EMAIL = "", MA_CHUCVU = "";
        int DA_NGHI = 0;
        int NGAY_SINH = -1;
        string THAM_NIEN = "";
        string HT_TuyenDung = "";
        string DiaDiemLamViec = "";
        bool isChuaCoAnh = bool.Parse(context.Request["IsChuaCoAnh"]);
        int userID = -1, menuID = -1;

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
            SearchKey = SoftCore.Util.GetInstance().GetKeyword(SearchKey).Replace(" ","%");
        }
        if (!string.IsNullOrEmpty(context.Request["uID"]))
        {
            userID = int.Parse(context.Request["uID"]); 
        }
        if (!string.IsNullOrEmpty(context.Request["mID"]))
        {
            menuID = int.Parse(context.Request["mID"]); 
        }

        string[] value = Query.Split(';');  // -1;-1;;;;;;;;0;
        if (value.Length >= 1)  // filter giới tính
            MA_GIOITINH = value[0] == null ? "" : value[0];
        if (value.Length >= 2)  // filter năm sinh
            NGAY_SINH = value[1] != "" ? int.Parse(value[1]) : -1;
        if (value.Length >= 3)  // filter trình độ
            MA_TRINHDO = value[2] == null ? "" : value[2];
        if (value.Length >= 4)  // filter chuyên ngành
            MA_CHUYENNGANH = value[3] == null ? "" : value[3];
        if (value.Length >= 5)  // filter mã tỉnh thành
            MA_TINHTHANH = value[4] == null ? "" : value[4];
        if (value.Length >= 6)  // filter loại hợp đồng
            MA_LOAI_HDONG = value[5] == null ? "" : value[5];
        if (value.Length >= 7)  // filter địa chỉ liên hệ
            DIA_CHI_LH = value[6] == null ? "" : value[6];
        if (value.Length >= 8)  // filter số điện thoại
            DI_DONG = value[7] == null ? "" : value[7];
        if (value.Length >= 9) // filter email
            EMAIL = value[8] == null ? "" : value[8];
        if (value.Length >= 10) // filter trạng thái làm việc
            DA_NGHI = value[9] == "" ? 0 : int.Parse(value[9]);
        if (value.Length >= 11) // filter chức vụ
            MA_CHUCVU = value[10] == null ? "" : value[10];
        if (value.Length >= 12) // filter công việc
            MA_CONGVIEC = value[11] == null ? "" : value[11];
        if (value.Length >= 13)
            THAM_NIEN = value[12] == null ? "" : value[12];
        if (value.Length >= 14)
            HT_TuyenDung = value[13] == null ? "" : value[13];
        if (value.Length >= 15)
            DiaDiemLamViec = value[14] == null ? "" : value[14];
        // xử lý filter thâm niên
        if (!string.IsNullOrEmpty(THAM_NIEN))
        {
            if (THAM_NIEN.IndexOf('-') == -1) // dang >6
            {
                THAM_NIEN = "AND dbo.CalculateThamNien(hs.NGAY_TUYEN_DTIEN, case when ISNULL(hs.DA_NGHI, 0) = 0 then GETDATE() else hs.NGAY_NGHI end)" + THAM_NIEN;
            }
            else // dang 6-8
            {
                THAM_NIEN = "AND dbo.CalculateThamNien(hs.NGAY_TUYEN_DTIEN, case when ISNULL(hs.DA_NGHI, 0) = 0 then GETDATE() else hs.NGAY_NGHI end) > " + THAM_NIEN.Replace("-", "AND dbo.CalculateThamNien(hs.NGAY_TUYEN_DTIEN,case when ISNULL(hs.DA_NGHI, 0) = 0 then GETDATE() else hs.NGAY_NGHI end) <= ");
            }
        }

        /******* Filter *******/
        string[] params1 = {"@Start", "@Limit", "@SearchKey", "@MaDonVi", 
                                "@MA_GIOITINH", "@NGAY_SINH", 
                                "@MA_TRINHDO", "@MA_CHUYENNGANH", "@MA_TINHTHANH", "@MA_LOAI_HDONG",
                                "@DIA_CHI_LH", "@DI_DONG", "@EMAIL", "@DA_NGHI", "@MA_CHUCVU", "@MA_CONGVIEC", "@IsChuaCoAnh", 
                                "@userID", "@menuID", "@THAM_NIEN","@HT_TUYENDUNG","@DiaDiem"};

        string[] params2 = {"@SearchKey", "@MaDonVi", 
                                "@MA_GIOITINH", "@NGAY_SINH", 
                                "@MA_TRINHDO", "@MA_CHUYENNGANH", "@MA_TINHTHANH", "@MA_LOAI_HDONG",
                                "@DIA_CHI_LH", "@DI_DONG", "@EMAIL", "@DA_NGHI", "@MA_CHUCVU", "@MA_CONGVIEC", "@IsChuaCoAnh", 
                                "@userID", "@menuID", "@THAM_NIEN","@HT_TUYENDUNG","@DiaDiem"};

        /***** End Filter *****/

        var hoso = DataController.DataHandler.GetInstance().ExecuteDataTable("GetAllHOSO", params1, Start, Limit, SearchKey, MaDonVi,
                                MA_GIOITINH, NGAY_SINH, MA_TRINHDO, MA_CHUYENNGANH,
                                MA_TINHTHANH, MA_LOAI_HDONG, DIA_CHI_LH, DI_DONG, EMAIL, DA_NGHI, MA_CHUCVU, MA_CONGVIEC, isChuaCoAnh, 
                                userID, menuID, THAM_NIEN, HT_TuyenDung, DiaDiemLamViec);

        object obj = DataController.DataHandler.GetInstance().ExecuteScalar("CountHOSO", params2, SearchKey, MaDonVi,
                                MA_GIOITINH, NGAY_SINH, MA_TRINHDO, MA_CHUYENNGANH,
                                MA_TINHTHANH, MA_LOAI_HDONG, DIA_CHI_LH, DI_DONG, EMAIL, DA_NGHI, MA_CHUCVU, MA_CONGVIEC, isChuaCoAnh, 
                                userID, menuID, THAM_NIEN, HT_TuyenDung, DiaDiemLamViec);

        if (obj != null)
        {
            Count = int.Parse(obj.ToString());
        }

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(hoso), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}