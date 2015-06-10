using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;


public partial class Modules_DanhMuc_DanhMucPhuCapPhucLoi : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();

        }

        if (btnAddNew.Visible)
        {

        }
        if (btnEdit.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnEdit.enable();";
            GridPanel1.DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
        }
        if (btnDelete.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnDelete.enable();";
        }
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        var dmc = new DanhMucPhuCapPhucLoiController();
        DAL.DanhMucPhuCapPhucLoi item = new DAL.DanhMucPhuCapPhucLoi();
        item.Ten = txtTenPhuCap.Text;
        if (!string.IsNullOrEmpty(txtHeSo.Text))
            item.HeSo = Convert.ToDouble(txtHeSo.Text.Replace('.', ','));
        if (!string.IsNullOrEmpty(txtSoTien.Text))
            item.SoTien = Convert.ToDouble(txtSoTien.Text);
        if (!string.IsNullOrEmpty(txtPhanTram.Text))
            item.PhanTram = Convert.ToDouble(txtPhanTram.Text.Replace('.', ','));
        item.IsPhuCap = cbbLaPhuCap.SelectedItem.Value == "0" ? false : true;
        item.NhomLoaiPhuCapPhucLoi = hdfNhomLoaiPhuCap.Text;
        item.TinhVaoBH = ckTinhVaoBH.Checked;
        item.CreatedBy = CurrentUser.ID;
        item.CreatedDate = DateTime.Now;
        if (Session["MaDonVi"] != null)
        {
            item.MaDonVi = Session["MaDonVi"].ToString();
        }
        if (e.ExtraParams["Command"] == "Edit")
        {
            item.ID = Convert.ToInt32(Convert.ToInt32(hdfRecordID.Text));
            dmc.Update(item);
            wdAddWindow.Hide();
        }
        else
        {
            dmc.Insert(item);
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
            RM.RegisterClientScriptBlock("adsfasdf", "resetWindowHide();");
        }

        GridPanel1.Reload();

    }


    [DirectMethod]
    public void DeleteRecord(int pr_key)
    {
        new DanhMucPhuCapPhucLoiController().Delete(pr_key);
        hdfRecordID.Text = "";
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới kí hiệu chấm công";
        hdfCommand.SetValue("");
    }

    public void Reset(object sender, DirectEventArgs e)
    {
        if (e.ExtraParams["Them"] == "True")
        {
            wdAddWindow.Title = "Thêm phụ cấp phúc lợi";
            wdAddWindow.Icon = Icon.Add;
            wdAddWindow.Show();
        }
        else
        {
            wdAddWindow.Title = "Sửa phụ cấp phúc lợi";
            wdAddWindow.Icon = Icon.Pencil;
        }
    }
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        var dmc = new DanhMucPhuCapPhucLoiController();
        DAL.DanhMucPhuCapPhucLoi item = new DAL.DanhMucPhuCapPhucLoi();
        DAL.DanhMucPhuCapPhucLoi edit = dmc.Lay1BanGhi(Convert.ToInt32(hdfRecordID.Text));
        txtTenPhuCap.Text = edit.Ten;
        txtSoTien.Text = edit.SoTien == null ? "" : edit.SoTien.ToString();
        txtHeSo.Text = edit.HeSo == null ? "" : edit.HeSo.ToString();
        txtPhanTram.Text = edit.PhanTram == null ? "" : edit.PhanTram.ToString();
        cbbLaPhuCap.Value = edit.IsPhuCap == true ? "1" : "0";
        hdfNhomLoaiPhuCap.Text = edit.NhomLoaiPhuCapPhucLoi;
        cbbNhomLoaiPhuCap.SelectedItem.Value = edit.NhomLoaiPhuCapPhucLoi;
        ckTinhVaoBH.Checked = edit.TinhVaoBH == true ? true : false;
        wdAddWindow.Title = "Sửa phụ cấp phúc lợi";
        wdAddWindow.Icon = Icon.Pencil;
        RM.RegisterClientScriptBlock("xxx", "cbbNhomLoaiPhuCap.triggers[0].show();");
        wdAddWindow.Show();

    }
    protected void StoreNhomLoaiPhuCap_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> data = new DanhMucPhuCapPhucLoiController().GetStoreNhomLoai();
        StoreComboObject a = new StoreComboObject();
        a.MA = "(BH)PhuCapChucVu";
        a.TEN = "(BH) Phụ cấp chức vụ";
        StoreComboObject a1 = new StoreComboObject();
        a1.MA = "(BH)PhuCapThamNienVuotKhung";
        a1.TEN = "(BH) Phụ cấp thâm niêm vượt khung";
        StoreComboObject a2 = new StoreComboObject();
        a2.MA = "(BH)PhuCapThamNienNghe";
        a2.TEN = "(BH) Phụ cấp thâm niêm nghề";
        StoreComboObject a3 = new StoreComboObject();
        a3.MA = "(BH)PhuCapKhac";
        a3.TEN = "(BH) Phụ cấp khác";
        data.Add(a);
        data.Add(a1);
        data.Add(a2);
        data.Add(a3);
        StoreNhomLoaiPhuCap.DataSource = data;
        StoreNhomLoaiPhuCap.DataBind();
    }

}