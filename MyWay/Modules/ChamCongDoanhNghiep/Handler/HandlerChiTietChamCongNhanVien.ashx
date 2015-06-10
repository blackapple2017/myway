<%@ WebHandler Language="C#" Class="HandlerChiTietChamCongNhanVien" %>

using System;
using System.Web;
using System.Data;

public class HandlerChiTietChamCongNhanVien : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        int month = 0;
        int year = DateTime.Now.Year;
        int Count = 0;
        var max = 0;
        var bophan = string.Empty;
        var prKey = string.Empty;
        // tạm thời lấy Ma_CB vào prKey
        if (!string.IsNullOrEmpty(context.Request["PrKey"]))
            prKey = context.Request["PrKey"].ToString();
        month = int.Parse("0" + context.Request["Month"]);
        year = int.Parse("0" + context.Request["Year"]);
        max = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("LaySoLuotChamCongLonNhat").ToString());
        
        DataTable table = CreateDataTable(max);

        var data = DataController.DataHandler.GetInstance().ExecuteDataTable("ChiTietChamCongNhanVien", "@Month", "@Year", "@MA_CB", month, year, prKey);
        for (int i = 0; i < data.Rows.Count; i++)
        {
            int j = 1;
            DataRow it = data.Rows[i];
            DataRow dr = table.NewRow();
            dr["ID"] = it["ID"];
            dr["KyHieuChamCong"] = it["KyHieuChamCong"];
            dr["GhiChu"] = it["GhiChu"];
            dr["NgayChamCong"] = it["NgayChamCong"];
            DateTime MaChamCong = DateTime.Parse(it["NgayChamCong"].ToString());
            if (max > 0)
                while (DateTime.Parse(it["NgayChamCong"].ToString()).Date == MaChamCong.Date)
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
        Count = table.Rows.Count;
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(table), Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private DataTable CreateDataTable(int max)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NgayChamCong");
            for (int i = 0; i < max; i++)
            {
                int k = i + 1;
                dt.Columns.Add("Lan" + k);
            }
            dt.Columns.Add("KyHieuChamCong");
            dt.Columns.Add("GhiChu");

            return dt;
        }
        catch
        {
            return null;
        }
    }
}