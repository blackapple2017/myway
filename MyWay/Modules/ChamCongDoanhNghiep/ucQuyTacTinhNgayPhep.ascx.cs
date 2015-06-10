using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_ucQuyTacTinhNgayPhep : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void grpQuyTacTinhNgayPhepStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            grpQuyTacTinhNgayPhepStore.DataSource = new QuyTacTinhNgayPhepController().GetAll(Session["MaDonVi"].ToString());
            grpQuyTacTinhNgayPhepStore.DataBind();
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
            DAL.QuyTacTinhNgayPhep obj = new DAL.QuyTacTinhNgayPhep()
            {
                CreatedBy = CurrentUser.ID,
                IsInUsed = chkIsInUsed.Checked,
                TinhTheoNam = bool.Parse(cbThoiGian.SelectedItem.Value),
                ThamNienTu = int.Parse(nbfTu.Text),
                MaHinhThucLamViec = int.Parse(cbHinhThucLamViec.SelectedItem.Value),
                CreatedDate = DateTime.Now,
                MaDonVi = Session["MaDonVi"].ToString(),
                SoNgayPhepDuocHuong = int.Parse(nbfSoNPDuocHuong.Text), 
            };
            if (!string.IsNullOrEmpty(nbfDen.Text))
            {
                obj.ThamNienDen = int.Parse(nbfDen.Text);
            }
            if (e.ExtraParams["Command"] == "Update")
            {
                obj.ID = int.Parse(RowSelectionModel1.SelectedRow.RecordID);
                new QuyTacTinhNgayPhepController().Update(obj);
                Dialog.ShowNotification("Cập nhật thành công !");
            }
            else
            {
                new QuyTacTinhNgayPhepController().Add(obj);
                Dialog.ShowNotification("Thêm mới thành công !");
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdTaoQuyTac.Hide();
            }
            else
            {
                //reset các giá trị trên window
                nbfTu.Reset();
                nbfDen.Reset();
                cbThoiGian.Reset();
                nbfSoNPDuocHuong.Reset();
                cbHinhThucLamViec.Reset();
                chkIsInUsed.Reset();
            }
            grpQuyTacTinhNgayPhep.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbHinhThucLamViecStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            ThamSoTrangThaiController controller = new ThamSoTrangThaiController();
            cbHinhThucLamViecStore.DataSource = controller.GetByParamName(ThamSoTrangThaiController.HINH_THUC_LAM_VIEC, true);
            cbHinhThucLamViecStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    //Show Edit Form
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.QuyTacTinhNgayPhep existing = new QuyTacTinhNgayPhepController().GetByID(int.Parse(RowSelectionModel1.SelectedRecordID));
            if (existing != null)
            {
                nbfTu.Value = existing.ThamNienTu.ToString();
                if (existing.ThamNienDen.HasValue)
                {
                    nbfDen.Value = existing.ThamNienDen.Value.ToString();
                }
                cbThoiGian.SetValue(existing.TinhTheoNam.ToString());
                nbfSoNPDuocHuong.Text = existing.SoNgayPhepDuocHuong.ToString();
                cbHinhThucLamViec.SetValue(existing.MaHinhThucLamViec);
                chkIsInUsed.Checked = existing.IsInUsed;
                wdTaoQuyTac.Show();
            }
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
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                new QuyTacTinhNgayPhepController().Delete(int.Parse(item.RecordID));
            }
            grpQuyTacTinhNgayPhep.Reload();
            btnDelete.Disabled = true;
            btnEdit.Disabled = true;
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}