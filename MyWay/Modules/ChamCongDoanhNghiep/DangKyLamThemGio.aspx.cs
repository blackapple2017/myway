using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;
using Controller.ChamCongDoanhNghiep;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_DangKyLamThemGio : WebBase
{
    SoftCore.Util util = new SoftCore.Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearch.reset();PagingToolbar1.pageIndex = 0; grpDangKyLamThemGioStore.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);

            SetVisibleByControlID(mnuThemMotCanBo, mnuThemCanBoHangLoat, btnDieuChinh, btnXoa);
        }
        if (btnDieuChinh.Visible)
        {
            grpDangKyLamThemGio.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnDieuChinh_Click);
            grpDangKyLamThemGio.DirectEvents.RowDblClick.Before = "if (CheckSelectedRow(#{grpDangKyLamThemGio}) == false) {return false;} btnCapNhat.hide(); btnEdit.show(); btnCapNhatDongLai.hide();";
        }

        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    public void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            hdfTotalRecord.Text = ucChooseEmployee1.SelectedRow.Count.ToString();
            foreach (var item in ucChooseEmployee1.SelectedRow)
            {
                // get employee information
                HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
                string pr_keyhoso = hs.PR_KEY.ToString();
                string ma_cb = hs.MA_CB;
                string ho_ten = hs.HO_TEN;
                string ten_donvi = new DM_DONVIController().GetNameById(hs.MA_DONVI);
                string ten_chucvu = "";
                if (hs.DM_CHUCVU != null)
                    ten_chucvu = hs.DM_CHUCVU.TEN_CHUCVU;
                string ten_congviec = "";
                if (hs.DM_CONGVIEC != null)
                    ten_congviec = hs.DM_CONGVIEC.TEN_CONGVIEC;
                // insert record to grid
                RM.RegisterClientScriptBlock("insert" + pr_keyhoso, string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", pr_keyhoso, ma_cb, ho_ten, ten_donvi, ten_chucvu, ten_congviec));
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    #region Direct Event
    protected void cbxChonCanBo_Selected(object sender, DirectEventArgs e)
    {
        try
        {
            decimal prkey = decimal.Parse(cbxChonCanBo.SelectedItem.Value);
            HOSO hs = new HoSoController().GetByPrKey(prkey);
            if (hs != null)
            {
                hdfChonCanBo.Text = hs.MA_CB;
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
            string error = string.Empty;
            DAL.DangKyLamThemGio dk = new DangKyLamThemGio
            {
                MaCB = hdfChonCanBo.Text,
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                GhiChu = txtGhiChu.Text,
                GioBatDauSauCa = GetTime(tfGioBatDauSauCa.Text),
                GioKetThucSauCa = GetTime(tfGioKetThucSauCa.Text),
                FrkeyMaCa = int.Parse(cbxChonCa.SelectedItem.Value),
            };
            if (!util.IsDateNull(dfTuNgay.SelectedDate))
                dk.TuNgay = dfTuNgay.SelectedDate;
            if (!util.IsDateNull(dfDenNgay.SelectedDate))
                dk.DenNgay = dfDenNgay.SelectedDate;

            if (e.ExtraParams["Command"] == "Edit")
            {
                dk.ID = int.Parse(hdfRecordID.Text);
                new DangKyLamThemGioController().Update(dk);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công");
                wdThemCanBo.Hide();
            }
            else
            {
                List<DAL.DangKyLamThemGio> tmp = new DangKyLamThemGioController().GetByMaCanBoAndFrkeyCa(dk.MaCB, dk.FrkeyMaCa);
                if (CheckGiaoNhau(tmp, dk) == false)
                {
                    new DangKyLamThemGioController().Insert(dk);
                    Dialog.ShowNotification("Đăng ký làm thêm thành công");
                }
                else
                {
                    error += dk.MaCB + ", ";
                }
                if (string.IsNullOrEmpty(error))
                {
                    Dialog.ShowNotification("Đăng ký thành công!");
                }
                else
                {
                    error = error.Remove(error.LastIndexOf(','));
                    X.Msg.Alert("Thông báo từ hệ thống", "Các cán bộ có mã " + error + " đã đăng ký trùng giờ làm thêm").Show();
                }
                if (e.ExtraParams["Close"] == "True")
                {
                    wdThemCanBo.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rs1", "ResetWdThemCanBo();");
                }
            }
            grpDangKyLamThemGio.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    /// <summary>
    /// Kiểm tra sự giao nhau của các lần đăng ký làm thêm giờ
    /// </summary>
    /// <param name="dkys">Danh sách các lần đã đăng ký</param>
    /// <param name="dkyNew">lần đăng ký cần kiểm tra</param>
    /// <returns><b>true</b> nếu giao nhau, <b>false</b> nếu không giao nhau</returns>
    private bool CheckGiaoNhau(List<DAL.DangKyLamThemGio> dkys, DangKyLamThemGio dkyNew)
    {
        TimeController timeController = new TimeController();
        foreach (var item in dkys)
        {
            if (item.TuNgay <= dkyNew.TuNgay && dkyNew.TuNgay <= item.DenNgay ||
                item.TuNgay <= dkyNew.DenNgay && dkyNew.DenNgay <= item.DenNgay)
            {
                if (timeController.GetTotalTimeInMinutes(item.GioBatDauSauCa, dkyNew.GioBatDauSauCa) >= 0 &&
                    timeController.GetTotalTimeInMinutes(item.GioKetThucSauCa, dkyNew.GioBatDauSauCa) <= 0 ||
                    timeController.GetTotalTimeInMinutes(item.GioBatDauSauCa, dkyNew.GioKetThucSauCa) >= 0 &&
                    timeController.GetTotalTimeInMinutes(item.GioKetThucSauCa, dkyNew.GioKetThucSauCa) <= 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        try
        {
            ChangeRecords<DangKyLamThemGioHangLoatInfo> dky = e.DataHandler.ObjectData<DangKyLamThemGioHangLoatInfo>();
            string error = string.Empty;

            foreach (DangKyLamThemGioHangLoatInfo created in dky.Created)
            {
                DAL.DangKyLamThemGio lamtg = new DangKyLamThemGio
                {
                    MaCB = created.MA_CB,
                    FrkeyMaCa = int.Parse(cbxChonCaHL.SelectedItem.Value),
                    TuNgay = dfTuNgayHL.SelectedDate,
                    DenNgay = dfDenNgayHL.SelectedDate,
                    GioBatDauSauCa = GetTime(tfGioBatDauHL.Text),
                    GioKetThucSauCa = GetTime(tfGioKetThucHL.Text),
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    GhiChu = txtGhiChuHL.Text,
                };
                List<DAL.DangKyLamThemGio> tmp = new DangKyLamThemGioController().GetByMaCanBoAndFrkeyCa(lamtg.MaCB, lamtg.FrkeyMaCa);
                if (CheckGiaoNhau(tmp, lamtg) == false)
                {
                    new DangKyLamThemGioController().Insert(lamtg);
                }
                else
                {
                    error += lamtg.MaCB + ", ";
                }
            }
            grpDangKyLamThemGio.Reload();
            if (string.IsNullOrEmpty(error))
            {
                Dialog.ShowNotification("Đăng ký thành công!");
            }
            else
            {
                error = error.Remove(error.LastIndexOf(','));
                X.Msg.Alert("Thông báo từ hệ thống", "Các cán bộ có mã " + error + " đã đăng ký trùng giờ làm thêm").Show();
            }
            wdThemCanBoHangLoat.Hide();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnDieuChinh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfRecordID.Text == "")
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy dũ liệu").Show();
                return;
            }
            DAL.DangKyLamThemGio dky = new DangKyLamThemGioController().GetById(int.Parse(hdfRecordID.Text));
            if (dky != null)
            {
                DAL.HOSO hs = new HoSoController().GetByMaCB(dky.MaCB);
                hdfChonCanBo.Text = hs.MA_CB;
                cbxChonCanBo.Text = hs.HO_TEN;
                cbxChonCa.SetValue(dky.FrkeyMaCa);

                if (!util.IsDateNull(dky.TuNgay))
                    dfTuNgay.SetValue(dky.TuNgay);
                if (!util.IsDateNull(dky.DenNgay))
                    dfDenNgay.SetValue(dky.DenNgay);
                tfGioBatDauSauCa.SetValue(dky.GioBatDauSauCa);
                tfGioKetThucSauCa.SetValue(dky.GioKetThucSauCa);
                txtGhiChu.Text = dky.GhiChu;

                wdThemCanBo.Title = "Sửa thông tin đăng ký làm thêm giờ";
                wdThemCanBo.Icon = Icon.Pencil;
                wdThemCanBo.Show();
                btnDieuChinh.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnXoa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SelectedRowCollection selectedRows = RowSelectionModel1.SelectedRows;
            foreach (var item in selectedRows)
            {
                new DangKyLamThemGioController().Delete(int.Parse(item.RecordID));
            }
            grpDangKyLamThemGio.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    #region DirectMethods
    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdThemCanBo.Title = "Thêm cán bộ đăng ký làm thêm giờ";
        wdThemCanBo.Icon = Icon.UserAdd;
    }
    #endregion

    #region ComboBox/GridPanel OnRefreshData
    protected void cbxChonCaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxChonCaStore.DataSource = new DanhSachCaController().MiniGetAll(Session["MaDonVi"].ToString());
        cbxChonCaStore.DataBind();
    }
    #endregion

    #region Other Functions
    private string GetTime(string time)
    {
        if (time == "" || time.Contains("-"))
            return "";
        int pos = time.LastIndexOf(':');
        if (pos == -1)
            return "";
        return time.Substring(0, pos);
    }
    #endregion
}