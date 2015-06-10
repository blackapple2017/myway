using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HelpBook_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request.QueryString["link"])
        {
            case "TraCuuNhanh": 
                RM.Listeners.DocumentReady.Handler = "AddContent('idTraCuuNhanh','HtmlBook/BanLamViec/TraCuuNhanh.html','Tra cứu nhanh')";;
                break;
            case "DMCB":
                RM.Listeners.DocumentReady.Handler = "AddContent('idDanhMucCanBoCNVien','HtmlBook/DanhMuc/DanhMucCanBoCNVien.html','Danh mục cán bộ công nhân viên')";;
                break;
            default:
                break;
        }
    }
}