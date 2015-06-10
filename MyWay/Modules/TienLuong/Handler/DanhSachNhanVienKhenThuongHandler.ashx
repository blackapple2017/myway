<%@ WebHandler Language="C#" Class="DanhSachNhanVienKhenThuongHandler" %>

using System;
using System.Web;
using System.Data;

public class DanhSachNhanVienKhenThuongHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        int start = 0;
        int limit = 25;
        string searchKey = string.Empty;
        int idBangThuongPhat = -1;
        int count = 0;

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }

        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }

        if (!string.IsNullOrEmpty(context.Request["IdBangThuong"]))
        {
            idBangThuongPhat = int.Parse(context.Request["IdBangThuong"]); 
        }

        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            searchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(context.Request["SearchKey"]) + "%"; 
        }

        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("TienLuong_CountDanhSachCanBoThuongPhat", "@IdBangThuongPhat", "@SearchKey", idBangThuongPhat, searchKey).ToString());

        DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_GetDanhSachCanBoThuongPhat", "@Start", "@Limit", "@IdBangThuongPhat", "@SearchKey", start, limit, idBangThuongPhat, searchKey);

        //for (int i = 0; i < data.Rows.Count; i++)
        //{
        //    string ngay = data.Rows[i]["Ngay"].ToString();
        //    if (ngay.IndexOf("1900") > 0 || ngay.IndexOf("0001") > 0)
        //        data.Rows[i]["Ngay"] = null;
        //}
        
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}