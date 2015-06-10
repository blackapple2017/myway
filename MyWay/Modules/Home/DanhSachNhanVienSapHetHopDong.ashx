<%@ WebHandler Language="C#" Class="DanhSachNhanVienSapHetHopDong" %>

using System;
using System.Web;

public class DanhSachNhanVienSapHetHopDong : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 30;
        string MaDonVi = context.Request["MaDonVi"];
        int count = 0, userID = -1, menuID = DepartmentRoleController.MENUID_CONTRACT;
        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["userID"]))
        {
            userID = int.Parse(context.Request["userID"]); 
        }
        //if (start == 0)
        //{
        //    start = 1;
        //}
        System.Data.DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("Hopdong_DanhSachNhanVienSapHetHopDong", "@start", "@limit", "@day", "@MaDonVi", "@UserID", "@MenuID", start, limit, 30, MaDonVi, userID, menuID);
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("Hopdong_CountDanhSachNhanVienSapHetHopDong", "@day", "@MaDonVi", "@UserID", "@MenuID", 30, MaDonVi, userID, menuID).ToString()); 
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