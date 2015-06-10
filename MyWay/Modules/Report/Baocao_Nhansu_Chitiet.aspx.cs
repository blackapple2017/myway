using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Resources;
using ExtMessage;

public partial class Modules_Report_Baocao_Nhansu_Chitiet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Report_baocao_nhansu_chitiet.ReportViewer.Report = CreateReport();
    }
    public DevExpress.XtraReports.UI.XtraReport CreateReport()
    {  //Mẫu 2C
      //  rpt_NhanSu_Detail nsct = new rpt_NhanSu_Detail();
  //      sub_QTDaoTao qtdt = new sub_QTDaoTao();
       // sub_DienBienLuong dbl = new sub_DienBienLuong();
        rp_EmployeeDetail employee = new rp_EmployeeDetail(); //Mẫu tùy chỉnh DTH
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["prkey"]))
            {
                ReportFilter RP = new ReportFilter();
                RP.EmployeeCode = decimal.Parse(Request.QueryString["prkey"].ToString());
                decimal prkey = decimal.Parse(Request.QueryString["prkey"].ToString());
                DAL.HOSO hs = new HoSoController().GetByPrKey(prkey);
                //nsct.BindData(hs);
                //qtdt.BinData(RP);
                //dbl.BinData(RP); 
                employee.BindData(hs);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                ReportFilter RP = new ReportFilter();
                decimal prkey = decimal.Parse(Request.QueryString["prkey"].ToString());
                DAL.HOSO hs = new HoSoController().GetByPrKey(prkey);
                RP.EmployeeCode = hs.PR_KEY;
                //nsct.BindData(hs);
                //qtdt.BinData(RP);
                //dbl.BinData(RP);
                employee.BindData(hs);
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra " + ex.Message);
        }
        //return nsct;
        return employee;
    }
}