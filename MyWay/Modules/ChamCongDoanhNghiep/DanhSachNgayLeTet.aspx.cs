using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_DanhSachNgayLeTet : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grpDanhSachNgayLeTet.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaClick); 
        grpDanhSachNgayLeTet.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaClick);
        if (!X.IsAjaxRequest)
        {
            grpDanhSachNgayLeTet.GetAddButton().Listeners.Click.Handler = "btnThemClick()";
            grpDanhSachNgayLeTet.GetGridPanel().Listeners.RowContextMenu.Handler = "e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());grpDanhSachNgayLeTet_GridPanel1.getSelectionModel().selectRow(rowIndex);";
        }
    }
    protected void btnSuaClick(object sender, DirectEventArgs e)
    {
        try
        {

            if (grpDanhSachNgayLeTet.GetSelectedRecordIDs().Count > 1)
            {
                X.Msg.Alert("Thông báo", "Bạn chỉ được chọn 1 dòng").Show();
                return;
            }
            wdAddWindow.Icon = Icon.Pencil;
            wdAddWindow.Title = "Sửa một ngày nghỉ lễ, tết";
            DAL.DanhSachNgayLe ngayle = new DanhSachNgayLeController().GetByID(int.Parse(grpDanhSachNgayLeTet.GetSelectedRecordIDs().FirstOrDefault().ToString()));
            txtTenNgayLe.Text = ngayle.TenNgayLe; 
            txtNgay.Text = ngayle.Ngay.ToString();
            txtThang.Text = ngayle.Thang.ToString();
            cbbLoaiNgay.Value = ngayle.AmLich.ToString(); 
            btnCapNhatSua.Show();
            btnCapNhatThem.Hide();
            btnCapNhatThemVaDongLai.Hide();
            wdAddWindow.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhatThem_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachNgayLe ngayle = new DAL.DanhSachNgayLe()
            {
                AmLich = bool.Parse(cbbLoaiNgay.SelectedItem.Value),
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                KiHieuChamCong = "L",
                Ngay = int.Parse(txtNgay.Text),
                Thang = int.Parse(txtThang.Text),
                TenNgayLe = txtTenNgayLe.Text
            };
            new DanhSachNgayLeController().Insert(ngayle);
            Dialog.ShowNotification("Thông báo", "Đã lưu thành công ngày lễ/ tết: " + txtTenNgayLe.Text);
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
            else
            {
                grpDanhSachNgayLeTet.GetResourceManager().RegisterClientScriptBlock("r1", "resetForm();");
            }
            grpDanhSachNgayLeTet.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhatSua_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachNgayLe ngayle = new DanhSachNgayLeController().GetByID(int.Parse(grpDanhSachNgayLeTet.GetSelectedRecordIDs().FirstOrDefault().ToString()));
            ngayle.TenNgayLe = txtTenNgayLe.Text;
            ngayle.AmLich = bool.Parse(cbbLoaiNgay.SelectedItem.Value);
            ngayle.Ngay = int.Parse(txtNgay.Text);
            ngayle.Thang = int.Parse(txtThang.Text);
            //   ngayle.KiHieuChamCong = txtKyHieuChamCong.Text;

            new DanhSachNgayLeController().Update(ngayle);
            Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
            grpDanhSachNgayLeTet.GetGridPanel().Reload();
            wdAddWindow.Hide();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

}