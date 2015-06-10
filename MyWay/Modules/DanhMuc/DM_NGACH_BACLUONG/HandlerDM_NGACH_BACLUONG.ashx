<%@ WebHandler Language="C#" Class="HandlerDM_NGACH_BACLUONG" %>

using System;
using System.Web;
using System.Data;

public class HandlerDM_NGACH_BACLUONG : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 10;
        var Count = 0;
        var max = 0;
        string madonvi;
        madonvi = context.Request["MaDonVi"];
        string searchKey = string.Empty;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["max"]))
        {
            max = int.Parse(context.Request["max"]); 
        }
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["searchKey"]) + "%"; 
        }
        DataTable table = CreateDataTable(max);
        var data = new DM_MUCLUONG_NGACHController().GetAllRecord(Start, Limit, madonvi, searchKey, out Count);
        
        for (int i = 0; i < data.Count; i++)
        {
            DataRow dr = table.NewRow();
            dr["PR_KEY"] = data[i].PR_KEY;
            dr["MaNgach"] = data[i].MaNgach;
            dr["TenNgach"] = data[i].TenNgach;
            dr["Cap"] = data[i].Cap;

            string maNgach = data[i].MaNgach;
            while (data[i].MaNgach == maNgach)
            {
                dr["Bac" + data[i].BacLuong] = (data[i].HeSoLuong == null ? "" : Math.Round(data[i].HeSoLuong.Value, 2).ToString()) + "#" + RenderMoney(data[i].MucLuong, '.');
                i++;
                if (i >= data.Count)
                    break;
            }
            table.Rows.Add(dr);
            i--;
        }
        Count = table.Rows.Count;
        
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(table), Count));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private string RenderMoney(string money, char separator)
    {
        int length = money.Length;
        int k = 1;
        string result = "";
        for (int i = length - 1; i >= 0; i--)
        {
            result = money[i] + result;
            if (k % 3 == 0)
                result = separator + result;
            k++;
        }
        return result;
    }

    private DataTable CreateDataTable(int max)
    {
        try
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("PR_KEY");
            dt.Columns.Add("MaNgach");
            dt.Columns.Add("TenNgach"); 
            dt.Columns.Add("Cap");
            for (int i = 0; i < max; i++)
            {
                int k = i + 1;
                dt.Columns.Add("Bac" + k);
            }

            return dt;
        }
        catch
        {
            return null;
        }
    }
}