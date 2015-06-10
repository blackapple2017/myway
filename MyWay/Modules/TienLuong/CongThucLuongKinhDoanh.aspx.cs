using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;

public partial class Modules_TienLuong_CongThucLuongKinhDoanh : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CongThucLuongKinhDoanhController controller = new CongThucLuongKinhDoanhController();
            DAL.CongThucLuongKinhDoanh lkd = new DAL.CongThucLuongKinhDoanh();
            if (e.ExtraParams["Edit"] == "True")
            {
                lkd = controller.GetById(int.Parse("0" + hdfRecordID.Text));
            }
            lkd.Nhom = cbx_Nhom.SelectedItem.Value;
            lkd.MaChucVu = hdfChucVu.Text;
            lkd.PhanTramTu = double.Parse("0" + txtPhanTramTu.Text.Replace('.', ','));
            lkd.PhanTramDen = double.Parse("0" + txtPhanTramDen.Text.Replace('.', ','));
            lkd.SanLuongTu = double.Parse("0" + txtSanLuongTu.Text.Replace('.', ','));
            lkd.SanLuongDen = double.Parse("0" + txtSanLuongDen.Text.Replace('.', ','));
            try
            {
                lkd.TienThuong = double.Parse(txtTienThuong.Text.Replace('.', ','));
            }
            catch (Exception)
            {
                lkd.TienThuong = 0;
            }
            if (e.ExtraParams["Edit"] == "True")
            {
                lkd.ID = int.Parse("0" + hdfRecordID.Text);
                controller.Update(lkd);
                Dialog.ShowNotification("Cập nhật công thức lương thành công");
                wdAddWindow.Hide();
            }
            else
            {
                controller.Insert(lkd);
                Dialog.ShowNotification("Thêm mới công thức lương thành công");
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddWindow.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rsf", "ResetForm();");
                }
            }
            GridCongThucLuongKinhDoanh.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra: " + ex.Message);
        }
    }
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        //try
        //{
        //    DAL.Product product = new ProductController().GetById(hdfRecordID.Text);
        //    if (product != null)
        //    {
        //        txtMaSanPham.Text = product.PRODUCT_ID;
        //        txtTenSanPham.Text = product.PRODUCT_NAME;
        //        txtPrice.SetValue(product.PRICE);
        //        txtUnit.Text = product.UNIT;
        //        txtMinQuantity.SetValue(product.QUANTITY_MIN);
        //        txtMaxQuantity.SetValue(product.QUANTITY_MAX);
        //        txtBinQuantity.SetValue(product.BIN_QUANTITY);
        //        chkIsInUse.Checked = product.IsInUse;

        //        txtMaSanPham.Disabled = true;
        //        wdAddWindow.Show();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Dialog.ShowError("Có lỗi xảy ra: " + ex.Message);
        //}
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CongThucLuongKinhDoanhController controller = new CongThucLuongKinhDoanhController();
            SelectedRowCollection selecteds = checkboxSelection.SelectedRows;
            foreach (var item in selecteds)
            {
                controller.Delete(int.Parse(item.RecordID));
            }
            GridCongThucLuongKinhDoanh.Reload();
            btnEditCongThuc.Disabled = true;
            btnXoaCongThuc.Disabled = true;
            Dialog.ShowNotification("Xóa thành công dữ liệu chọn");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra: " + ex.Message);
        }
    }
}