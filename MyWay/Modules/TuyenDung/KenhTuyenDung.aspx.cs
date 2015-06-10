using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
using DAL;
using DataController;
using System.Data;

public partial class Modules_TuyenDung_NguonTuyenDung : WebBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            btnAddRecord.Listeners.Click.Handler = "wdNguonTuyenDung.show();btnAddAndClose.show();btnUpdate.hide();btnAdd.show();";
            btnEdit.Listeners.Click.Handler = "btnUpdate.show();btnAdd.hide();btnAddAndClose.hide();";
            gpTuyenDung.Listeners.RowDblClick.Handler = "btnUpdate.show();btnAdd.hide();btnAddAndClose.hide();";
            //LoadTreeNguonDan();
        }
        // btnEdit.DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
        // btnEdit.DirectEvents.Click.EventMask.ShowMask = true;
        gpTuyenDung.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
        gpTuyenDung.DirectEvents.RowDblClick.EventMask.ShowMask = true;
    }
    protected void Click_Event(object sender, DirectEventArgs e)
    {
        NguonTuyenDungController item = new NguonTuyenDungController();
        DAL.KenhTuyenDung data = item.GetByID(int.Parse("0" + hdfRecordID.Text));
        txt_GhiChu.Text = "" + data.Description;
        txt_LinkNguon.Text = "" + data.LinkUrl;
        txtTenNguon.Text = "" + data.Name;
        hdfRecordID.Text = data.ID.ToString();
        if (txt_LinkNguon.Text.Length > 1)
        {
            wdNguonTuyenDung.Show();
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        NguonTuyenDungController item = new NguonTuyenDungController();
        int selectID = int.Parse("0" + hdfRecordID.Text);

        DAL.KenhTuyenDung data = new DAL.KenhTuyenDung()
        {
            Name = txtTenNguon.Text,
            LinkUrl = txt_LinkNguon.Text,
            Description = txt_GhiChu.Text
        };

        if (e.ExtraParams["Command"] == "Update")
        {

            data.ID = selectID;
            item.Update(data);
            RM.RegisterClientScriptBlock("rl", "#{Store1}.reload();");
            wdNguonTuyenDung.Hide();

            Dialog.ShowNotification("Sửa thành công");
        }
        else
        {
            item.Insert(data);
            RM.RegisterClientScriptBlock("reset", "resetForm();");
            RM.RegisterClientScriptBlock("rl123", "#{Store1}.reload();");
            Dialog.ShowNotification("Thêm thành công");
        }
        gpTuyenDung.Reload();


        if (e.ExtraParams["Close"] == "True")
        {
            wdNguonTuyenDung.Hide();
        }

    }  
    protected void btnDeleteNguon_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string sql = "delete from tuyendung.KenhTuyenDung where ID in (";
            foreach (var item in rsm.SelectedRows)
            {
                sql += item.RecordID + ",";
            }
            sql += "-1)";
            DataHandler.GetInstance().ExecuteNonQuery(sql);
            RM.RegisterClientScriptBlock("rl", "#{Store1}.reload();");
            btnDeleteNguon.Disabled = true;
            btnEdit.Disabled = true;
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    } 
    protected void cbxChonNguonTuyenDung_store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            Store1.DataSource = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_LayDanhSachNguonTuyenDung");
            Store1.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
}