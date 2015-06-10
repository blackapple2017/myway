using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;
using DataController;

public partial class Modules_TuyenDung_DanhSachThamSo_Default : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grpDanhSachThamSo.Title = "Danh sách hình thức làm việc";
    }
     
    protected void grpDanhSachThamSoStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(cbDanhSachThamSo.SelectedItem.Value))
            {
                grpDanhSachThamSoStore.DataSource = new ThamSoTrangThaiController().GetByParamName(ThamSoTrangThaiController.HINH_THUC_LAM_VIEC, Session["MaDonVi"].ToString(), "%" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) + "%");
                grpDanhSachThamSoStore.DataBind();
            }
            else
            {
                grpDanhSachThamSoStore.DataSource = new ThamSoTrangThaiController().GetByParamName(cbDanhSachThamSo.SelectedItem.Value, Session["MaDonVi"].ToString(), "%" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) + "%");
                grpDanhSachThamSoStore.DataBind();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            ThamSoTrangThaiController controller = new ThamSoTrangThaiController();
            DAL.ThamSoTrangThai thamso = controller.GetByID(int.Parse(hdfRecordID.Text));
            if (thamso != null)
            {
                txtGhiChu.Text = thamso.Description;
                txtGiaTri.Text = thamso.Value;
                chkTinhTrang.Checked = thamso.IsInUsed;
            }
            wdThemGiaTri.Show();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        { 
            ThamSoTrangThaiController controller = new ThamSoTrangThaiController();
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                object objIsUsed = DataHandler.GetInstance().ExecuteScalar("CheckThamSoTrangThaiIsUse", "@ID", int.Parse(item.RecordID));
                if (objIsUsed == null || Equals(objIsUsed.ToString(), "true") || Equals(objIsUsed.ToString(), "True"))
                {
                    X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa dữ liệu đang sử dụng!").Show();
                }
                else
                {
                    controller.Delete(int.Parse(item.RecordID));
                }
            }
            btnEdit.Disabled = true;
            btnDelete.Disabled = true;
            grpDanhSachThamSo.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.ThamSoTrangThai thamso = new DAL.ThamSoTrangThai()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Description = txtGhiChu.Text.Trim(),
                MaDonVi = Session["MaDonVi"].ToString(),
                Value = txtGiaTri.Text.Trim(),
                IsInUsed = chkTinhTrang.Checked,
                ParamName = cbDanhSachThamSo.SelectedItem.Value
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                thamso.ID = int.Parse(hdfRecordID.Text);
                new ThamSoTrangThaiController().Update(thamso);
                wdThemGiaTri.Hide();
            }
            else
            {
                new ThamSoTrangThaiController().Add(thamso);
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdThemGiaTri.Hide();
            }
            txtGhiChu.Text = "";
            txtGiaTri.Text = "";
            grpDanhSachThamSo.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}