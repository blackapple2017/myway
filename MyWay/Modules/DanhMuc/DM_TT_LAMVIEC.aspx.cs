using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;

public partial class Modules_DanhMuc_DM_TT_LAMVIEC : SoftCore.Security.WebBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            // button
            btnAddNew.Visible = SetVisible(btnAddNew.Text);
            btnEdit.Visible = SetVisible(btnEdit.Text);
            btnDelete.Visible = SetVisible(btnDelete.Text);
            // context menu
            mnuAddNew.Visible = SetVisible(btnAddNew.Text);
            mnuEdit.Visible = SetVisible(btnEdit.Text);
            mnuDelete.Visible = SetVisible(btnDelete.Text);
        }

        if (btnAddNew.Visible)
        {

        }
        if (btnEdit.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnEdit.enable();";
            GridPanel1.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
        }
        if (btnDelete.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnDelete.enable();";
        }
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        DAL.DM_TT_LAMVIEC obj = new DAL.DM_TT_LAMVIEC();
        KyHieuChamCongController ctr = new KyHieuChamCongController();
        obj.KYHIEU_TT_LAMVIEC = txtKYHIEU_TT_LAMVIEC.Text;
        obj.TEN_TT_LAMVIEC = txtTEN_TT_LAMVIEC.Text;
        obj.DIEN_GIAI = txtDIEN_GIAI.Text;
        if (!string.IsNullOrEmpty(txtSTT.Text))
            obj.STT = decimal.Parse(txtSTT.Text);
        else
            obj.STT = 0;
        obj.CREATED_USER = CurrentUser.DisplayName;
        obj.DATE_CREATE = DateTime.Now;
        obj.IS_IN_USED = chkIsIS_IN_USED.Checked;
        //obj.QUI_UOC_CHAM_CONG = txtQUI_UOC_CHAM_CONG.SelectedItem.Value;
        obj.SoCongHuongLuong = nfSoCongHuong.Text == "" ? 0 : double.Parse(nfSoCongHuong.Text.Replace('.', ','));
        obj.NhomKyHieu = cbxNhomKyHieu.SelectedItem.Value;
        obj.MA_DONVI = Session["MaDonVi"].ToString();
        try
        {
            if (e.ExtraParams["Command"] == "Edit")
            {
                obj.PR_KEY = int.Parse(hdfRecordID.Text);
                ctr.Update(obj);
                Dialog.ShowNotification(CommonMessage.INSERT_SUCCESSFULLY);
                wdAddWindow.Hide();
                //RM.RegisterClientScriptBlock("fd", string.Format("addUpdatedRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", txtKYHIEU_TT_LAMVIEC.Text, txtTEN_TT_LAMVIEC.Text, txtDIEN_GIAI.Text, txtSTT.Text, CurrentUser.DisplayName, DateTime.Now, chkIsIS_IN_USED.Checked, txtQUI_UOC_CHAM_CONG.SelectedItem.Value));
            }
            else
            {
                if (ctr.CheckDuplicateSignal(obj.KYHIEU_TT_LAMVIEC, Session["MaDonVi"].ToString()))
                {
                    X.MessageBox.Alert("Có lỗi xảy ra", "Kí hiệu chấm công bị trùng, bạn vui lòng chọn kí hiệu khác").Show();
                    return;
                }
                int prkey = ctr.Insert(obj);
                Dialog.ShowNotification(CommonMessage.INSERT_SUCCESSFULLY);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddWindow.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rs", "resetWindowHide();");
                }
                //RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}')", txtKYHIEU_TT_LAMVIEC.Text, txtTEN_TT_LAMVIEC.Text, txtDIEN_GIAI.Text, txtSTT.Text, CurrentUser.DisplayName, DateTime.Now, chkIsIS_IN_USED.Checked, txtQUI_UOC_CHAM_CONG.SelectedItem.Value, prkey));
            }
            GridPanel1.Reload();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            if (ex.Number == 2627)
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Qui ước chấm công bị trùng, bạn hãy chọn quy ước chấm công khác").Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }


    [DirectMethod]
    public void DeleteRecord(int pr_key)
    {
        new KyHieuChamCongController().DeleteByPrkey(pr_key);
        hdfRecordID.Text = "";
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới kí hiệu chấm công";
        hdfCommand.SetValue("");
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DAL.DM_TT_LAMVIEC record = new KyHieuChamCongController().GetbyPrKey(int.Parse(hdfRecordID.Text));
        txtKYHIEU_TT_LAMVIEC.Text = record.KYHIEU_TT_LAMVIEC;
        txtTEN_TT_LAMVIEC.Text = record.TEN_TT_LAMVIEC;
        txtDIEN_GIAI.Text = record.DIEN_GIAI;
        txtSTT.Text = record.STT.Value.ToString();
        chkIsIS_IN_USED.Checked = record.IS_IN_USED;
        //txtQUI_UOC_CHAM_CONG.SetValue(record.QUI_UOC_CHAM_CONG);
        nfSoCongHuong.SetValue(record.SoCongHuongLuong);
        cbxNhomKyHieu.SetValue(record.NhomKyHieu);

        hdfCommand.Text = "Update";
        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa kí hiệu chấm công";
        wdAddWindow.Show();
    }
}