using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;

/// <summary>
/// daibx   22/09/2013
/// </summary>
public partial class Modules_DanhMuc_DM_NGACH_BACLUONG_DM_NGACH_BACLUONG : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            int maxBacLuong = new DM_NGACHController().GetMaxBacLuong();
            hdfMax.Text = maxBacLuong.ToString();
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            hdfLuongCoBan.Text = new HeThongController().GetValueByName(SystemConfigParameter.LUONG_CB, Session["MaDonVi"].ToString());

            var grid = GridPanel1;
            var store = grid.GetStore();
            var cm = grid.ColumnModel;

            Renderer f = new Renderer();
            f.Fn = "RenderCap";

            for (int i = 0; i < maxBacLuong; i++)
            {
                int k = i + 1;
                // add to store
                store.Reader[0].Fields.Add("Bac" + k);
                Column column = new Column()
                {
                    ColumnID = "Bac" + k,
                    Header = "Bậc " + k,
                    Width = 100,
                    DataIndex = "Bac" + k,
                    Align = Alignment.Right,
                    Renderer = f
                };
                cm.Columns.Add(column);
            }
        }
    }

    #region combobox refresh data

    protected void cbxNhomNgachStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxNhomNgachStore.DataSource = new DanhMucNhomNgachController().GetByAll();
        cbxNhomNgachStore.DataBind();
    }

    protected void cbxNgachStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (cbxNhomNgach.SelectedItem.Value != null)
        {
            string maNhom = cbxNhomNgach.SelectedItem.Value;
            List<StoreComboObject> obj = new DM_NGACHController().GetByMaNhomNgach(maNhom);
            cbxNgachStore.DataSource = obj;
            cbxNgachStore.DataBind();
        }
    }

    public void cbxBacStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DAL.DM_NHOM_NGACH nn = new DanhMucNhomNgachController().GetByID(hdfMaNhomNgach.Text);
        if (nn != null)
        {
            List<int> dsbac = new DM_MUCLUONG_NGACHController().GetExistBacLuong(hdfMaNgach.Text);
            List<StoreComboObject> objs = new List<StoreComboObject>();
            for (int i = 1; i <= nn.SOBAC_TOIDA; i++)
            {
                if (!dsbac.Contains(i))
                {
                    StoreComboObject stob = new StoreComboObject
                    {
                        MA = i.ToString(),
                        TEN = "Bậc " + i
                    };
                    objs.Add(stob);
                }
            }
            cbxBacStore.DataSource = objs;
            cbxBacStore.DataBind();
        }
    }

    #endregion

    #region direct event
    protected void mnuThemMoi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CellSelectionModel sm = GridPanel1.SelectionModel.Primary as CellSelectionModel;
            string maNgach = sm.SelectedCell.RecordID;
            string tmpBac = sm.SelectedCell.Name;
            int bac = 0;
            if (tmpBac.StartsWith("Bac"))
            {
                bac = int.Parse(tmpBac.Replace("Bac", "").Trim());
                DM_MUCLUONG_NGACHInfo ngach = new DM_MUCLUONG_NGACHController().GetByMaNgachAndBacLuong(maNgach, bac);
                if (ngach != null)
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Ngạch: " + ngach.TenNgach + ", bậc " + ngach.BacLuong + " đã có giá trị").Show();
                    return;
                }
                DM_NGACHInfo ng = new DM_NGACHController().GetByMaNgach(maNgach);
                if (ng == null)
                    return;
                hdfMaNhomNgach.Text = ng.MA_NHOM_NGACH;
                cbxNhomNgach.Text = ng.TEN_NHOM_NGACH;
                hdfMaNgach.Text = ng.MA_NGACH;
                cbxNgach.Text = ng.TEN_NGACH;
                hdfBac.Text = bac.ToString();
                cbxBac.Text = "Bậc " + bac;

                wdThemMoiMucLuongNgach.Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (e.ExtraParams["Command"] != "Edit")
            {
                DAL.DM_MUCLUONG_NGACH tmp = new DM_MUCLUONG_NGACHController().GetByNhomNgachBacNgach(hdfMaNhomNgach.Text, hdfMaNgach.Text, int.Parse(hdfBac.Text));
                if (tmp != null)
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Ngạch và bậc " + tmp.BAC_LUONG + " đã có dữ liệu. Bạn không thể thêm mới dữ liệu khác").Show();
                    return;
                }
            }
            DAL.DM_MUCLUONG_NGACH ngach = new DAL.DM_MUCLUONG_NGACH()
            {
                MA_NHOM_NGACH = hdfMaNhomNgach.Text,
                MA_NGACH = hdfMaNgach.Text,
                BAC_LUONG = int.Parse(hdfBac.Text),
                HS_LUONG = decimal.Parse(txtHeSoLuong.Text.Replace('.', ',')),
                MUC_LUONG = txtMucLuong.Text,
                GHI_CHU = txtGhiChu.Text,
                USERNAME = CurrentUser.DisplayName,
                DATE_CREATE = DateTime.Now,
                MA_DONVI = Session["MaDonVi"].ToString()
            };
            //if (!string.IsNullOrEmpty(txtCap.Text))
            //    ngach.CAP = double.Parse(txtCap.Text.Replace('.', ','));
            if (e.ExtraParams["Command"] == "Edit")
            {
                ngach.PR_KEY = decimal.Parse(hdfRecordID.Text);
                new DM_MUCLUONG_NGACHController().Update(ngach);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công");
                wdThemMoiMucLuongNgach.Hide();
            }
            else
            {
                new DM_MUCLUONG_NGACHController().Insert(ngach);
                Dialog.ShowNotification("Thêm mới dữ liệu thành công!");
                if (e.ExtraParams["Close"] == "True")
                {
                    wdThemMoiMucLuongNgach.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rs1", "ResetWdThemMucLuongNgach();");
                }
            }
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnSuaNgach_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CellSelectionModel sm = GridPanel1.SelectionModel.Primary as CellSelectionModel;
            string maNgach = sm.SelectedCell.RecordID;
            string tmpBac = sm.SelectedCell.Name;
            int bac = 0;
            if (tmpBac.StartsWith("Bac"))
            {
                bac = int.Parse(tmpBac.Replace("Bac", "").Trim());
                DM_MUCLUONG_NGACHInfo ngach = new DM_MUCLUONG_NGACHController().GetByMaNgachAndBacLuong(maNgach, bac);
                if (ngach == null)
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy dữ liệu").Show();
                    return;
                }
                hdfRecordID.Text = ngach.PR_KEY.ToString();

                hdfMaNhomNgach.Text = ngach.MaNhomNgach;
                cbxNhomNgach.Text = ngach.TenNhomNgach;
                hdfMaNgach.Text = ngach.MaNgach;
                cbxNgach.Text = ngach.TenNgach;
                hdfBac.Text = ngach.BacLuong.ToString();
                cbxBac.Text = "Bậc " + ngach.BacLuong.ToString();
                //txtCap.SetValue(ngach.Cap);
                txtHeSoLuong.SetValue(ngach.HeSoLuong);
                txtMucLuong.SetValue(ngach.MucLuong);
                txtGhiChu.Text = ngach.GhiChu;

                wdThemMoiMucLuongNgach.Title = "Sửa thông tin lương của ngạch";
                wdThemMoiMucLuongNgach.Icon = Icon.Pencil;
                wdThemMoiMucLuongNgach.Show();
            }
            else
            {
                Dialog.ShowNotification("Thông tin này không được phép thay đổi");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnXoaNgach_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CellSelectionModel sm = GridPanel1.SelectionModel.Primary as CellSelectionModel;
            string maNgach = sm.SelectedCell.RecordID;
            string tmpBac = sm.SelectedCell.Name;
            int bac = 0;
            if (tmpBac.StartsWith("Bac"))
            {
                bac = int.Parse(tmpBac.Replace("Bac", "").Trim());
                DM_MUCLUONG_NGACHInfo ngach = new DM_MUCLUONG_NGACHController().GetByMaNgachAndBacLuong(maNgach, bac);
                if (ngach == null)
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy dữ liệu").Show();
                    return;
                }
                new DM_MUCLUONG_NGACHController().Delete(ngach.PR_KEY);
                Dialog.ShowNotification("Đã xóa dữ liệu của ngạch: " + ngach.TenNgach + ", bậc : " + ngach.BacLuong);
                GridPanel1.Reload();
            }
            else
            {
                Dialog.ShowNotification("Dữ liệu này không thể xóa!");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    #region DirectMethods
    public void ResetWindowTitle()
    {
        wdThemMoiMucLuongNgach.Title = "Thêm mới thông tin lương cho ngạch";
        wdThemMoiMucLuongNgach.Icon = Icon.Add;
    }
    #endregion
}