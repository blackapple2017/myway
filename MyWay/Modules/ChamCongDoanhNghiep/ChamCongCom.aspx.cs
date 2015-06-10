using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_ChamCongCom : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            cbxThang.SelectedIndex = DateTime.Now.Month - 1;
            nbfNam.Value = DateTime.Now.Year;
            hdfMenuID.SetValue(MenuID);
            hdfUserID.SetValue(CurrentUser.ID);
        }
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void AfterEdit(int id, int prkey, string field, string oldValue, string newValue, object customer)
    { 
        ChamCongComController ChamCongComController = new ChamCongComController();
        ChamCongComController.UpdateChamCongCom(id, prkey, field, newValue);
        this.grpEmployeeList.Store.Primary.CommitChanges();
        grpEmployeeList.Reload();
     //   Dialog.ShowNotification("AfterEdit");
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void Insert(int prkey, string field, string oldValue, string newValue, object customer)
    {
        ChamCongComController ChamCongComController = new ChamCongComController();
        DateTime date = new DateTime(int.Parse(nbfNam.Text), int.Parse(cbxThang.SelectedItem.Value), 1);
        ChamCongComController.InsertChamCongCom(date, prkey, field, newValue);
        this.grpEmployeeList.Store.Primary.CommitChanges();
        grpEmployeeList.Reload();
    //    Dialog.ShowNotification("Insert");
    }
}