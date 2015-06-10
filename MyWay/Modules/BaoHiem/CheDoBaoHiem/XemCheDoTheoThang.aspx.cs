using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;

public partial class Modules_BaoHiem_XemCheDoTheoThang : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        int menuID = int.Parse("" + Request.QueryString["menuID"]);
        new DTH.BorderLayout()
        {
            menuID = menuID,
            script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; grpCheDoTheoThangStore.reload();"
        }.AddDepartmentList(BorderLayout1, CurrentUser.ID, true);
        cbbThang.SetValue(0);
        spinNam.Value = DateTime.Now.Year;
    }
}