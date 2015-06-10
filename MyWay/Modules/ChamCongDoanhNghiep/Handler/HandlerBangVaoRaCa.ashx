<%@ WebHandler Language="C#" Class="HandlerBangVaoRaCa" %>

using System;
using System.Web;
using System.Data;

public class HandlerBangVaoRaCa : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 30;
        int count = 0;
        var max = 0;
        DateTime ngay = DateTime.Now;
        if (!string.IsNullOrEmpty(context.Request["ngay"]))
            ngay = DateTime.Parse(context.Request["ngay"].ToString().Remove(10));
        string searchKey = string.Empty;
        start = int.Parse("0" + context.Request["start"]);
        limit = int.Parse("0" + context.Request["limit"]);
        if (!string.IsNullOrEmpty(context.Request["max"]))
        {
            max = int.Parse(context.Request["max"].ToString());
        }
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["searchKey"]) + "%";
        }
        //  max = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("  ").ToString());
        DataTable table = CreateDataTable(max);

        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("GetAllVaoRaCa", "@Start", "@Limit", "@Date", "@searchKey", start, limit, ngay, searchKey);
        object obj = DataController.DataHandler.GetInstance().ExecuteScalar("CountVaoRaCa", "@Date", "@searchKey", ngay, searchKey);
        if (obj != null)
        {
            count = int.Parse(obj.ToString());
        }
        for (int i = 0; i < data.Rows.Count; i++)
        {
            int j = 1;
            DataRow it = data.Rows[i];
            DataRow dr = table.NewRow();
            dr["MA_CB"] = it["MA_CB"];
            dr["HO_TEN"] = it["HO_TEN"];
            dr["MaChamCong"] = it["MaChamCong"];
            dr["PhongBan"] = it["PhongBan"];
            dr["TEN_DIADIEM"] = it["TEN_DIADIEM"];
            string maChamCong = it["MaChamCong"].ToString();
            while (it["MaChamCong"].ToString() == maChamCong)
            {
                dr["Lan" + j] = it["Time"];
                j++;
                i++;
                if (i >= data.Rows.Count)
                    break;
                it = data.Rows[i];
            }
            table.Rows.Add(dr);
            i--;
        }

        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(table), count));
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

            dt.Columns.Add("MA_CB");
            dt.Columns.Add("HO_TEN");
            dt.Columns.Add("MaChamCong");
            dt.Columns.Add("PhongBan");
            dt.Columns.Add("TEN_DIADIEM");
            for (int i = 0; i < max; i++)
            {
                int k = i + 1;
                dt.Columns.Add("Lan" + k);
            }

            return dt;
        }
        catch
        {
            return null;
        }
    }

}