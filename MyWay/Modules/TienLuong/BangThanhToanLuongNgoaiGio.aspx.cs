using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using LinqToExcel;
using System.Globalization;
using System.Text;
using System.Data;

public partial class Modules_TienLuong_BangThanhToanLuongNgoaiGio : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!X.IsAjaxRequest)
        {
            //SingleGridPanel.GetAddButton().Hidden=true;
            //SingleGridPanel.GetEditButton().Hidden = true;
            //SingleGridPanel.GetDeleteButton().Hidden = true;
            //SingleGridPanel.GetGridPanel().Header = false;
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }
}