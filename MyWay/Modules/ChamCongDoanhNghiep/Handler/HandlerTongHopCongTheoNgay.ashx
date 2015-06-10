<%@ WebHandler Language="C#" Class="HandlerTongHopCongTheoNgay" %>

using System;
using System.Web;
using System.Data;

public class HandlerTongHopCongTheoNgay : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int Start = 0;
        int Limit = 30;
        int Count = 0;
        var max = 0;
        int userID = 0;
        int menuID = 0;
        var bophan = string.Empty;
        DateTime ngay = DateTime.Now;
        if (!string.IsNullOrEmpty(context.Request["ngay"]))
            ngay = DateTime.Parse(context.Request["ngay"].ToString().Remove(10));
        string searchKey = string.Empty;
        Start = int.Parse("0" + context.Request["start"]);
        Limit = int.Parse("0" + context.Request["limit"]);
        //if (!string.IsNullOrEmpty(context.Request["max"]))
        //{
        //    max = int.Parse(context.Request["max"].ToString());
        //}
        if (!string.IsNullOrEmpty(context.Request["bophan"]))
        {
            bophan = context.Request["bophan"].ToString();
        }
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["searchKey"]) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["userID"]))
        {
            userID = int.Parse(context.Request["userID"]);
        }
        if (!string.IsNullOrEmpty(context.Request["menuID"]))
        {
            menuID = int.Parse(context.Request["menuID"]);
        }
        max = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("LaySoLuotChamCongLonNhat").ToString());
        DataTable table = CreateDataTable(max);

        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("GetAllTongHopCongTheoNgay", "@Start", "@Limit", "@Date", "@searchKey", "@bophan", "@userID", "@menuID", Start, Limit, ngay, searchKey, bophan, userID, menuID);
        object obj = DataController.DataHandler.GetInstance().ExecuteScalar("CountTongHopCongTheoNgay", "@Date", "@searchKey", "@bophan", "@userID", "@menuID", ngay, searchKey, bophan, userID, menuID);
        if (obj != null)
        {
            Count = int.Parse(obj.ToString());
        }
        for (int i = 0; i < data.Rows.Count; i++)
        {
            int j = 1;
            DataRow it = data.Rows[i];
            DataRow dr = table.NewRow();
            dr["ID"] = it["ID"];
            dr["MA_CB"] = it["MA_CB"];
            dr["HO_TEN"] = it["HO_TEN"];
            dr["MaChamCong"] = it["MaChamCong"];
            dr["PhongBan"] = it["PhongBan"];
            dr["TEN_CB"] = it["TEN_CB"];
            dr["SoPhutDiMuon"] = it["SoPhutDiMuon"];
            dr["SoPhutVeSom"] = it["SoPhutVeSom"];
            dr["SoGio"] = it["SoGio"];
            dr["GioHanhChinh"] = it["GioHanhChinh"];
            dr["GioThua"] = it["GioThua"];
            dr["Gio300"] = it["Gio300"];
            dr["KyHieuChamCong"] = it["KyHieuChamCong"];
            dr["GhiChu"] = it["GhiChu"];
            dr["TEN_DIADIEM"] = it["TEN_DIADIEM"];
            dr["TenCa"] = it["TenCa"];
            string MaChamCong = it["MaChamCong"].ToString();
            if (max > 0)
                while (it["MaChamCong"].ToString() == MaChamCong)
                {
                    dr["Lan" + j] = it["Time"];
                    j++;
                    i++;
                    if (i >= data.Rows.Count)
                        break;
                    it = data.Rows[i];
                }
            else i++;
            table.Rows.Add(dr);
            i--;
        }

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(table), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private DataTable CreateDataTable(int max)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("MA_CB");
            dt.Columns.Add("HO_TEN");
            dt.Columns.Add("MaChamCong");
            dt.Columns.Add("PhongBan");
            dt.Columns.Add("TEN_CB");
            dt.Columns.Add("TEN_DIADIEM");
            for (int i = 0; i < max; i++)
            {
                int k = i + 1;
                dt.Columns.Add("Lan" + k);
            }
            dt.Columns.Add("SoPhutDiMuon");
            dt.Columns.Add("SoPhutVeSom");
            dt.Columns.Add("SoGio");
            dt.Columns.Add("GioHanhChinh");
            dt.Columns.Add("GioThua");
            dt.Columns.Add("Gio300");
            dt.Columns.Add("KyHieuChamCong");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("TenCa");

            return dt;
        }
        catch
        {
            return null;
        }
    }

}