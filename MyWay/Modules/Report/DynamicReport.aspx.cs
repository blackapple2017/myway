using Ext.Net;
using ExtMessage;
using SoftCore.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Modules_Report_DynamicReport : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        DAL.MauBaoCaoDong bcd = new DAL.MauBaoCaoDong();
        string name = txtNameHTML.Text;
        string s = htmlEditor.Text;
        bcd.ReportName = name;
        bcd.ReportContent = s;
        bcd.ContentBy = "";
        bcd.CreatedDate = DateTime.Now;
        bcd.CreatedBy = CurrentUser.ID;
        new MauBaoCaoDongController().InsertMauBCD(bcd);
        cbxBC_Store.DataSource = new MauBaoCaoDongController().GetByName();
        cbxBC_Store.DataBind();
        Dialog.ShowNotification("Thêm mới mẫu báo cáo: " + "\n" + name + " thành công");
        wdNameFileHTML.Hide();
    }
    protected void cbxBC_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxBC_Store.DataSource = new MauBaoCaoDongController().GetByName();
        cbxBC_Store.DataBind();
    }
    public void FillRePort(object sender, DirectEventArgs e)
    {
        int ID = int.Parse(hdfMaBC.Text);
        MauBaoCaoDongInfo content = new MauBaoCaoDongController().GetContent(ID);
        htmlEditor.Text = content.ReportContent;
    }

    public void Update_Click(object sender, DirectEventArgs e)
    {
        int ID = int.Parse(hdfMaBC.Text);
        MauBaoCaoDongInfo content = new MauBaoCaoDongController().GetContent(ID);
        DAL.MauBaoCaoDong bcd = new DAL.MauBaoCaoDong();
        //htmlEditor.Text = content.ReportContent;
        bcd.ReportContent = htmlEditor.Text;
        bcd.EditedDate = DateTime.Now;
        bcd.EditedBy = CurrentUser.ID;
        bcd.ID = ID;
        new MauBaoCaoDongController().Update(bcd);
        Dialog.ShowNotification("Cập nhật mẫu báo cáo: " + "\n" + content.ReportName.ToString() + " thành công");
    }
    public void Delete_Click(object sender, DirectEventArgs e)
    {
        int ID = int.Parse(hdfMaBC.Text);
        new MauBaoCaoDongController().Delete(ID);
        Dialog.ShowNotification("Xóa mẫu quyết định thành công");
        htmlEditor.Reset();
        cbxBC.Reset();
        cbxBC_Store.DataSource = new MauBaoCaoDongController().GetByName();
        cbxBC_Store.DataBind();
    }
}