using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;

public partial class Modules_DanhMuc_DM_HINHTHUC_LAMVIEC : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            grpWorkingStatus.GetAddButton().Listeners.Click.Handler = "wdWorkingStatus.show();";
            grpWorkingStatus.GetEditButton().Listeners.Click.Handler = "btnUpdate.show();btnInsert.hide();btnInsertAndClose.hide();";
            grpWorkingStatus.GetGridPanel().Listeners.RowDblClick.Handler = "btnUpdate.show();btnInsert.hide();btnInsertAndClose.hide();";
        }
        grpWorkingStatus.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
        grpWorkingStatus.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
    }

    void Click_Event(object sender, DirectEventArgs e)
    {
        try
        {
            ThamSoTrangThaiController controller = new ThamSoTrangThaiController();
            DAL.ThamSoTrangThai item = controller.GetByID(int.Parse("0" + grpWorkingStatus.GetSelectedRecordIDs().FirstOrDefault()));
            if (item != null)
            {
                txtDescription.Text = item.Description;
                txtWorkingStatusName.Text = item.Value;
            }
            //DAL.ThamSoTrangThai item = new DAL.ThamSoTrangThai()
            //{
            //    CreatedBy = CurrentUser.ID,
            //    CreatedDate = DateTime.Now,
            //    Description = txtDescription.Text,
            //    IsInUsed = true,
            //    MaDonVi = Session["MaDonVi"].ToString(),
            //    Value = txtWorkingStatusName.Text,
            //    ParamName = ThamSoTrangThaiController.HINH_THUC_LAM_VIEC
            //};
            //foreach (var i in grpWorkingStatus.GetSelectedRecordIDs())
            //{
            //    item.ID = int.Parse(i);
            //}
            //controller.Update(item);
            wdWorkingStatus.Show();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        try
        {
            ThamSoTrangThaiController controller = new ThamSoTrangThaiController();
            DAL.ThamSoTrangThai item = new DAL.ThamSoTrangThai()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Description = txtDescription.Text,
                IsInUsed = true,
                MaDonVi = Session["MaDonVi"].ToString(),
                Value = txtWorkingStatusName.Text,
                ParamName = ThamSoTrangThaiController.HINH_THUC_LAM_VIEC
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                item.ID = int.Parse("0" + grpWorkingStatus.GetSelectedRecordIDs().FirstOrDefault());
                controller.Update(item);
            }
            else
            {
                controller.Add(item);
            } 
            if (e.ExtraParams["Close"] == "True")
            {
                wdWorkingStatus.Hide();
            }
            else
            {
                txtWorkingStatusName.Text = "";
                txtDescription.Text = "";
            }
            grpWorkingStatus.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}