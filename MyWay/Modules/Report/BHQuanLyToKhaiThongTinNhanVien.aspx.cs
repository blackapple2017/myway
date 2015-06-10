using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using SoftCore.Security;

public partial class Modules_BaoHiem_BHQuanLyToKhaiThongTinNhanVien : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.ReportViewer.Report = CreateReport();
    }
    public DevExpress.XtraReports.UI.XtraReport CreateReport()
    {
        rp_ToKhaiThamGiaBHXH_BHYT tokhai = new rp_ToKhaiThamGiaBHXH_BHYT();
        ReportFilter rp = new ReportFilter();
        if (!string.IsNullOrEmpty(Request.QueryString["prkey"]))
        {//dùng where clause truyền prkey
            rp.WhereClause = Request.QueryString["prkey"].Trim();
            //rp.SessionDepartment = CurrentUser;
            rp.SessionDepartment = Session["MaDonVi"].ToString();
        }
        tokhai.BindData(rp);
        return tokhai;

    }
}