using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Report_BHDonDeNghi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.ReportViewer.Report = CreateReport();
    }
    public DevExpress.XtraReports.UI.XtraReport CreateReport()
    {
        rp_DonDeNghi denghi = new rp_DonDeNghi();
        if (Session["rp"]!=null)
        {
            ReportFilter rp =(ReportFilter)Session["rp"];
            denghi.BindData(rp);
        }
      
        return denghi;

    }
}