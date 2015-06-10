<%@ WebHandler Language="C#" Class="DanhSachNhanVienSinhNhat" %>

using System;
using System.Web;

public class DanhSachNhanVienSinhNhat : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 30;
        int userID = -1, menuID = DepartmentRoleController.MENUID_BIRTHDAY;
        string MaDonVi = context.Request["MaDonVi"];
        int count = 0;
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
        string dsDv = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID);
        System.Data.DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("home_BirthdayOfEmployee",
                "@MaDonVi", "@MaBoPhan", "@Month", "@start", "@limit",
                MaDonVi, dsDv, DateTime.Now.Month, start, limit);
        count = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("home_CountBirthdayOfEmployee", "@MaDonVi", "@MaBoPhan", "@Month",
                                                                                                                        MaDonVi, dsDv, DateTime.Now.Month));
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