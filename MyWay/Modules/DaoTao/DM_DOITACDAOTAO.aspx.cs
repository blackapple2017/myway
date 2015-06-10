using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;

public partial class Modules_DaoTao_DM_DOITACDAOTAO : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            //grp_DonViPhuTrachDaoTao.Reload();
            // Phân quyền 
            btnAddNew.Visible = SetVisible(btnAddNew.Text);
            btnEdit.Visible = SetVisible(btnEdit.Text);
            btnDelete.Visible = SetVisible(btnDelete.Text);
            btnTienIch.Visible = SetVisible(btnTienIch.Text);
            mnuNhanDoiDuLieu.Visible = SetVisible(mnuNhanDoiDuLieu.Text);

            // context menu
            mnuAddNew.Visible = SetVisible(btnAddNew.Text);
            mnuDelete.Visible = SetVisible(btnDelete.Text);
            mnuEdit.Visible = SetVisible(btnEdit.Text);
            mnuDuplicateData.Visible = SetVisible(mnuNhanDoiDuLieu.Text);
        }

        if (btnEdit.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnEdit.enable();";
            grp_DonViPhuTrachDaoTao.DirectEvents.RowDblClick.EventMask.ShowMask = true;
            grp_DonViPhuTrachDaoTao.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
            btnDelete.Listeners.Click.Handler += "btnEdit.disable();";
        }
        if (btnDelete.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnDelete.enable();";
            btnDelete.Listeners.Click.Handler += "btnDelete.disable();";
        }
        if (mnuNhanDoiDuLieu.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "mnuNhanDoiDuLieu.enable();";
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DM_DOITACDAOTAOInfo obj = new DM_DOITACDAOTAOInfo();
            DoiTacDaoTaoController ctr = new DoiTacDaoTaoController();
            obj.Ma = txtMa.Text;
            obj.Ten = txtTen.Text;
            obj.DiaChiLienHe = txtDiaChiLienHe.Text;
            obj.TruSoChinh = txtTruSoChinh.Text;
            obj.Fax = txtFax.Text;
            obj.Phone = txtPhone.Text;
            obj.Email = txtEmail.Text;
            obj.Website = txtWebsite.Text;
            obj.MA_DONVI = Session["MaDonVi"].ToString();
            obj.CreatedUser = CurrentUser.ID;
            if (e.ExtraParams["Command"] == "Edit")
            {
                obj.Ma = hdfRecordID.Text;
                ctr.Update(obj);
                wdAddWindow.Hide();
                RM.RegisterClientScriptBlock("fd", string.Format("addUpdatedRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", txtMa.Text, txtTen.Text, txtDiaChiLienHe.Text, txtTruSoChinh.Text, txtFax.Text, txtPhone.Text, txtEmail.Text, txtWebsite.Text));
            }
            else
            {
                ctr.Insert(obj);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddWindow.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("ds", "resetWindowHide();");
                }
                RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", txtMa.Text, txtTen.Text, txtDiaChiLienHe.Text, txtTruSoChinh.Text, txtFax.Text, txtPhone.Text, txtEmail.Text, txtWebsite.Text));
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
            {
                Dialog.ShowError("Mã đào tạo không được trùng !");
            }
            else
                Dialog.ShowError(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new DoiTacDaoTaoController().GetByPrkey(txtmaloaihdcoppy.Text);
            if (record.Rows.Count > 0)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
            }
            else
            {
                record = new DoiTacDaoTaoController().GetByPrkey(hdfRecordID.Text);
                record.Rows[0]["Ma"] = txtmaloaihdcoppy.Text;
                DM_DOITACDAOTAOInfo item = new DM_DOITACDAOTAOInfo()
                {
                    Ma = record.Rows[0]["Ma"].ToString(),
                    Ten = record.Rows[0]["Ten"].ToString(),
                    DiaChiLienHe = record.Rows[0]["DiaChiLienHe"].ToString(),
                    TruSoChinh = record.Rows[0]["TruSoChinh"].ToString(),
                    Fax = record.Rows[0]["Fax"].ToString(),
                    Phone = record.Rows[0]["Phone"].ToString(),
                    Email = record.Rows[0]["Email"].ToString(),
                    Website = record.Rows[0]["Website"].ToString(),
                    MA_DONVI = record.Rows[0]["MA_DONVI"].ToString(),
                    CreatedUser = int.Parse(record.Rows[0]["CreatedUser"].ToString()),
                };
                new DoiTacDaoTaoController().Insert(item);
                RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", item.Ma, item.Ten, item.DiaChiLienHe, item.TruSoChinh, item.Fax, item.Phone, item.Email, item.Website));
            }
            wdInputNewPrimaryKey.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }

    }

    [DirectMethod]
    public void DeleteRecord(string pr_key)
    {
        try
        {
            new DoiTacDaoTaoController().DeleteByPrkey(pr_key);
            hdfRecordID.Text = "";
        }
        catch (Exception ex)
        {

            if (ex.Message.Contains("REFERENCE constraint"))
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa được vì dữ liệu này đang được sử dụng ở chỗ khác !").Show();
            }
            else
                X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }

    }


    public void DeleteRecord1(object sender, DirectEventArgs e)
    {
        try
        {
            //new DoiTacDaoTaoController().DeleteByPrkey(pr_key);
            //hdfRecordID.Text = "";
        }
        catch (Exception ex)
        {

            if (ex.Message.Contains("REFERENCE constraint"))
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa được vì dữ liệu này đang được sử dụng ở chỗ khác !").Show();
            }
            else
                X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }

    }

    /*[DirectMethod]
    public void NhanDoiDuLieuTuTang()
    {
        {NhanDoiDuLieuTuTangCode}
    }*/

    public void mnuNhanDoiDuLieu_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new DoiTacDaoTaoController().GetByPrkey(hdfRecordID.Text);
            DM_DOITACDAOTAOInfo item = new DM_DOITACDAOTAOInfo()
            {
                Ten = record.Rows[0]["Ten"].ToString(),
                DiaChiLienHe = record.Rows[0]["DiaChiLienHe"].ToString(),
                TruSoChinh = record.Rows[0]["TruSoChinh"].ToString(),
                Fax = record.Rows[0]["Fax"].ToString(),
                Phone = record.Rows[0]["Phone"].ToString(),
                Email = record.Rows[0]["Email"].ToString(),
                Website = record.Rows[0]["Website"].ToString(),
                MA_DONVI = record.Rows[0]["MA_DONVI"].ToString(),
                CreatedUser = int.Parse(record.Rows[0]["CreatedUser"].ToString()),
            };
            item.Ma = new DoiTacDaoTaoController().Insert(item);
            RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", item.Ma, item.Ten, item.DiaChiLienHe, item.TruSoChinh, item.Fax, item.Phone, item.Email, item.Website));
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới thông tin đơn vị phụ trách đào tạo";
        hdfCommand.SetValue("");
        txtMa.Disabled = false;
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DataTable record = new DoiTacDaoTaoController().GetByPrkey(hdfRecordID.Text);
        txtMa.Text = record.Rows[0]["Ma"].ToString();
        txtTen.Text = record.Rows[0]["Ten"].ToString();
        txtDiaChiLienHe.Text = record.Rows[0]["DiaChiLienHe"].ToString();
        txtTruSoChinh.Text = record.Rows[0]["TruSoChinh"].ToString();
        txtFax.Text = record.Rows[0]["Fax"].ToString();
        txtPhone.Text = record.Rows[0]["Phone"].ToString();
        txtEmail.Text = record.Rows[0]["Email"].ToString();
        txtWebsite.Text = record.Rows[0]["Website"].ToString();
        txtMa.Disabled = true;

        hdfCommand.Text = "Update";
        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa thông tin đơn vị phụ trách đào tạo";
        wdAddWindow.Show();
    }
}
