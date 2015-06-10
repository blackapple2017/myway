using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using System.Web.UI.WebControls;
using SoftCore.Security;

public partial class Modules_Report_BaoCao_CongThang : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ReportViewer_BangCong.ReportViewer.Report = CreateReport();
    }
    public DevExpress.XtraReports.UI.XtraReport CreateReport()
    { 
        rp_BangChamCongTheoThang ns = new rp_BangChamCongTheoThang();  
        ReportFilter RP = new ReportFilter();
        if (Session["MaDonVi"] != null)
        {
            RP.SessionDepartment = Session["MaDonVi"].ToString();
        }
        RP.Name1 = CurrentUser.DisplayName;
        RP.WhereClause ="IdBangChamCong = '"+  Request.QueryString["id"] + "'";
        ns.BindData(RP); 
        return ns;
        
    }
}