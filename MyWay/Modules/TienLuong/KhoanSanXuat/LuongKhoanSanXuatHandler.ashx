<%@ WebHandler Language="C#" Class="LuongKhoanSanXuatHandler" %>

using System;
using System.Web;
using System.Data;

public class LuongKhoanSanXuatHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Start = 0;
        var Limit = 10;
        var Count = 0;
        var max = 0;
        int month = DateTime.Now.Month, year = DateTime.Now.Year;
        string madonvi;
        int menuID, userID;
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
        if (!string.IsNullOrEmpty(context.Request["month"]))
        {
            month = int.Parse(context.Request["month"]); 
        }
        if (!string.IsNullOrEmpty(context.Request["year"]))
        {
            year = int.Parse(context.Request["year"]);
        }
        userID = int.Parse(context.Request["UserID"]);
        menuID = int.Parse(context.Request["MenuID"]);
        max = DateTime.DaysInMonth(year, month);
        if (!string.IsNullOrEmpty(context.Request["searchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["searchKey"]) + "%";
        }
        DataTable table = CreateDataTable(max);
        var data = new TinhLuongKhoanController().GetLuongKhoanSanPham(Start, Limit, month, year, madonvi, searchKey, userID, menuID, out Count);

        for (int i = 0; i < data.Count; i++)
        {
            DataRow dr = table.NewRow();
            dr["MA_CB"] = data[i].MaCanBo;
            dr["HO_TEN"] = data[i].HoTen + "##" + RenderMoney(data[i].LuongQuyetDinh.ToString(), '.');
            dr["TEN_CHUCVU"] = data[i].ChucVu + "##" + data[i].TenDonVi + "##" + data[i].MaDonVi;
            decimal tongLuong = 0;
            string maCanBo = data[i].MaCanBo;
            while (data[i].MaCanBo == maCanBo)
            {
                dr["Ngay" + data[i].Ngay] = GetValue(data[i].SoGioDangKy) + "##" + GetValue(data[i].SoGioLamViec) + 
                        "##" + GetValue(data[i].SanPhamChinh) + "##" + GetValue(data[i].SanPhamPhu) + "##"
                        + RenderMoney(data[i].TongLuong.ToString(), '.') + 
                        "##" + data[i].LuongQuyetDinh + "##" + data[i].MaDonVi;
                tongLuong += data[i].TongLuong == null ? 0 : data[i].TongLuong.Value;
                i++;
                if (i >= data.Count)
                    break;
            }
            dr["TONG_LUONG"] = Math.Round(tongLuong, 0);
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

    private string GetValue(double? value)
    {
        if (value == null)
            return "";
        return value.ToString(); 
    }

    private string GetValue(decimal value)
    {
        if (value == null)
            return "";
        return value.ToString(); 
    }

    private string RenderMoney(string money, char separator)
    {
        if (string.IsNullOrEmpty(money))
            money = "0";
        if (money.LastIndexOf(',') >= 0)
            money = money.Remove(money.LastIndexOf(','));
        if (money.LastIndexOf('.') >= 0)
            money = money.Remove(money.LastIndexOf('.'));
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
        if (result.StartsWith(".")) 
            result = result.Substring(1);
        return result;
    }

    private DataTable CreateDataTable(int max)
    {
        try
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MA_CB");
            dt.Columns.Add("HO_TEN");
            dt.Columns.Add("TEN_CHUCVU");
            for (int i = 0; i < max; i++)
            {
                int k = i + 1;
                dt.Columns.Add("Ngay" + k);
            }
            dt.Columns.Add("TONG_LUONG");

            return dt;
        }
        catch
        {
            return null;
        }
    }
}