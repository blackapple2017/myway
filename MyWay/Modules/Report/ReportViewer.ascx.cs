using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Web;
using DevExpress.XtraReports.UI;

public partial class Modules_Report_ReportViewer : System.Web.UI.UserControl
{
    public ReportViewer ReportViewer { get { return ReportViewer1; } }


    public XtraReport Report
    {
        get { return ReportViewer1.Report; }
        set { ReportViewer1.Report = value; }
    }
    
    public bool ReportToolbarsAutoWidth
    {
        get { return ReportToolbar1.Width == Unit.Percentage(100) || ReportToolbar1.Width == Unit.Percentage(100); }
        set { ReportToolbar1.Width = ReportToolbar1.Width = (value ? Unit.Percentage(100) : Unit.Empty); }
    }

      
    protected void Page_Load(object sender, EventArgs e)
    {
      
      XRLabel  xrl_TENHETHONG= new XRLabel();
      
        //  DataBind();
    }
}