using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using System.Data;
using DataController;
using Controller.ChamCongDoanhNghiep;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_ThietLapCaChoBoPhan : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            SetVisibleByControlID(btnEdit);
        }
        if (btnEdit.Visible)
        {
            grpDanhSachDonVi.Listeners.RowDblClick.Handler = "setValuewdChinhSuaCaLamViec();wdChinhSuaCaLamViec.show();";
        }
    }

    protected void cbCaLamViecStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            DanhSachCaController controller = new DanhSachCaController();
            cbCaLamViecStore.DataSource = controller.GetByMaDonVi(Session["MaDonVi"].ToString());
            cbCaLamViecStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void grpDanhSachDonViStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<DonViInfo> data = new List<DonViInfo>();
            new ThietLapCaTheoBoPhanController().LayCon(new List<string>() { Session["MaDonVi"].ToString() }, ref data, 0);
            grpDanhSachDonViStore.DataSource = data;
            grpDanhSachDonViStore.DataBind();
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
            ThietLapCaTheoBoPhanController controller = new ThietLapCaTheoBoPhanController();
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                DAL.ThietLapCaTheoBoPhan obj = new DAL.ThietLapCaTheoBoPhan()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaCaThu7 = cbCaThu7.SelectedItem.Value,
                    MaCaChuNhat = cbCaChuNhat.SelectedItem.Value,
                    MaCa = cbCaLamViec.SelectedItem.Value,
                    MaDonVi = item.RecordID,
                    SoNgayCongChuan = double.Parse(txtSoNgayCongChuan.Text.Replace('.', ','))
                };
                controller.UpdateCa(obj);
            }
            grpDanhSachDonVi.Reload();
            wdChinhSuaCaLamViec.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}