using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using DAL;

public partial class Modules_ChamCongDoanhNghiep_BangTheoDoiKhenThuong : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Ext.Net.X.IsAjaxRequest)
        {
            grpDanhSachKhenThuong.GetToolBar().Items.Insert(3, btnReport);
            grpDanhSachKhenThuong.GetAddButton().Listeners.Click.Handler = "wdKhenThuong.show();";
            grpDanhSachKhenThuong.GetEditButton().Listeners.Click.Handler = "btnUpdate.show();btnInsert.hide();btnInsertAndClose.hide();setValueForEdit();";
            grpDanhSachKhenThuong.GetGridPanel().Listeners.RowDblClick.Handler = "btnUpdate.show();btnInsert.hide();btnInsertAndClose.hide();setValueForEdit();";
        }
        grpDanhSachKhenThuong.GetEditButton().DirectEvents.Click.Event += new Ext.Net.ComponentDirectEvent.DirectEventHandler(Click_Event);
        grpDanhSachKhenThuong.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
    }
    void Click_Event(object sender, Ext.Net.DirectEventArgs e)
    {
        try
        {
            cbxChonCanBo.Text = hdfEmployeeName.Text;
            dfNgayQD.SelectedDate = DateTime.Parse(hdfDate.Text);
            wdKhenThuong.Show();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
        wdKhenThuong.Show();
    }

    protected void btnInsert_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_KHENTHUONG khenthuong = new HOSO_KHENTHUONG()
            {
                FR_KEY = decimal.Parse(hdfChonCanBo.Text),
                GHI_CHU = txtDescription.Text,
                LYDO_KTHUONG = txtLyDoKhenThuong.Text,
                SO_QD = txtSoQD.Text,
                SO_TIEN = decimal.Parse("0" + nbfSoTien.Text),
                NGAY_QD = dfNgayQD.SelectedDate,
                SoDiem = double.Parse("0" + nbfSoDiem.Text)
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                khenthuong.PR_KEY = decimal.Parse("0" + grpDanhSachKhenThuong.GetSelectedRecordIDs().FirstOrDefault());
                new HoSoKhenThuongController().UpdateKhenThuong(khenthuong);
                wdKhenThuong.Hide();
            }
            else
            {
                new HoSoKhenThuongController().InsertKhenThuong(khenthuong);
                if (e.ExtraParams["Command"] == "Reset")
                {
                    grpDanhSachKhenThuong.GetResourceManager().RegisterClientScriptBlock("resetForm", "resetForm();");
                }
            }
            grpDanhSachKhenThuong.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}