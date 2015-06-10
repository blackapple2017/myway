using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Ext.Net;
using DataController;
using SoftCore.Security;

public partial class Modules_BaoHiem_XemTheoBienDong : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        grpBienDongTheoThangStore.Sort("TuNgay", Ext.Net.SortDirection.DESC);
        int menuID = int.Parse("" + Request.QueryString["menuID"]);
        new DTH.BorderLayout()
        {
            menuID = menuID,
            script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; grpBienDongTheoThangStore.reload();"
        }.AddDepartmentList(BorderLayout1, CurrentUser.ID, true);
        cbbThang.SetValue(0);
        spinNam.Value = DateTime.Now.Year;
       // RM.RegisterClientScriptBlock("rml", "#{grpBienDongTheoThangStore}.reload();");
    }
}