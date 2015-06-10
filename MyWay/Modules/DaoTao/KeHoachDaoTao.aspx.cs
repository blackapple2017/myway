using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Globalization;
using ExtMessage;
using SoftCore.AccessHistory;
using SoftCore.Security;
using SoftCore;
using DataController;
public partial class Modules_DaoTao_KeHoachDaoTao : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            btnAddNew.Visible = SetVisible(btnAddNew.Text);
            btnEdit.Visible = SetVisible(btnEdit.Text);
            btnDelete.Visible = SetVisible(btnDelete.Text);
            Button2.Visible = SetVisible(Button2.Text);
            mnuChuyenTT.Visible = SetVisible(mnuChuyenTT.Text);
            mnuLocTheoTT.Visible = SetVisible(mnuLocTheoTT.Text);

            btnTienIch.Visible = SetVisible(btnTienIch.Text);
            mnuNhanDoiDuLieu.Visible = SetVisible(mnuNhanDoiDuLieu.Text);

            ////////
            Tab1.Visible = SetVisible(Tab1.Title);

            Tab2.Visible = SetVisible(Tab2.Title);
            btnThemGiaoVienDaoTao.Visible = SetVisible(btnThemGiaoVienDaoTao.Text + " - GVDT");
            Button18.Visible = SetVisible(Button18.Text + " - GVDT");
            btnSuaGiaoVien.Visible = SetVisible(btnSuaGiaoVien.Text + " - GVDT");

            Tab3.Visible = SetVisible(Tab3.Title);
            Button3.Visible = SetVisible(Button3.Text + " - CKCP");
            Button6.Visible = SetVisible(Button6.Text + " - CKCP");
            btnSuaChiPhi.Visible = SetVisible(btnSuaChiPhi.Text + " - CKCP");

            Tab4.Visible = SetVisible(Tab4.Title);
            Button10.Visible = SetVisible(Button10.Text + " - NVDT");
            Button11.Visible = SetVisible(Button11.Text + " - NVDT");
        }

        if (btnEdit.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "#{btnEdit}.enable();";
            checkboxSelection.Listeners.RowDeselect.Handler += "#{btnEdit}.disable();";
            GridPanel1.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
        }
        if (btnDelete.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "#{btnDelete}.enable();";
            checkboxSelection.Listeners.RowDeselect.Handler += "#{btnDelete}.disable();";
        }
        if (mnuNhanDoiDuLieu.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "#{mnuNhanDoiDuLieu}.enable();";
            checkboxSelection.Listeners.RowDeselect.Handler += "#{mnuNhanDoiDuLieu}.disable();";
        }
        if (Button3.Visible)
            checkboxSelection.Listeners.RowSelect.Handler += "Button3.enable();";
        if (Button10.Visible)
            checkboxSelection.Listeners.RowSelect.Handler += "Button10.enable();";
        if (btnThemGiaoVienDaoTao.Visible)
            checkboxSelection.Listeners.RowSelect.Handler += "btnThemGiaoVienDaoTao.enable();";
        if (Tab1.Visible)
            checkboxSelection.Listeners.RowSelect.Handler += "Ext.net.DirectMethods.GetData();";

        if (Tab2.Visible)
        {
            if (btnSuaGiaoVien.Visible)
            {
                RowSelectionModel4.Listeners.RowSelect.Handler += "btnSuaGiaoVien.enable();";
                grp_GiaoVienDaoTao.DirectEvents.DblClick.Before += "#{btn_UpdateClose}.hide();#{Button17}.hide();#{btn_EditGiaoVien}.show();";
                grp_GiaoVienDaoTao.DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaGiaoVien_Click);
            }
        }
        if (Button6.Visible)
        {
            RowSelectionModel2.Listeners.RowSelect.Handler += "Button6.enable();";
            grp_CacKhoanChiPhi.Listeners.Activate.Handler += "Button6.disable();";
        }
        if (btnSuaChiPhi.Visible)
        {
            RowSelectionModel2.Listeners.RowSelect.Handler += "btnSuaChiPhi.enable();";
            grp_CacKhoanChiPhi.DirectEvents.DblClick.Before += "#{btnCapNhatChiPhi}.hide();#{Button7}.hide();#{Button9}.show();";
            grp_CacKhoanChiPhi.DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaChiPhi_Click);
            grp_CacKhoanChiPhi.Listeners.Activate.Handler += "btnSuaChiPhi.disable();";
        }
        if (Button11.Visible)
        {
            RowSelectionModel3.Listeners.RowSelect.Handler += "Button11.enable();";
            grp_CacKhoanChiPhi.Listeners.Activate.Handler += "Button11.disable();";
        }

        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        SelectedRowCollection SelectedRow = sender as SelectedRowCollection;
        DaoTaoController dtController = new DaoTaoController();
        DAL.KEHOACH_DAOTAO khdt = dtController.GetKeHoachDaoTaoByID(hdfRecordID.Text);
        foreach (var item in SelectedRow)
        {
            try
            {
                DAL.DM_NhanVienThamGiaDaoTao nv = new DAL.DM_NhanVienThamGiaDaoTao()
                {
                    MaCanBo = item.RecordID,
                    DaThamGia = true,
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaKhoaDaoTao = hdfRecordID.Text,
                    SoTienCongTyHoTro = khdt.KINHPHI_CTY_HOTRO,
                    SoTienNVDong = khdt.KINHPHI_NHANVIEN_DONG
                };
                dtController.InsertNhanVienThamgiaHoc(nv);
                grp_nhanVienThamGiaDaoTao.Reload();
            }
            catch
            {

            }
        }
    }

    [DirectMethod]
    public void ResetWindow()
    {
        wdAddWindow.Title = "Thêm mới kế hoạch đào tạo";
        wdAddWindow.Icon = Icon.Add;
    }

    [DirectMethod]
    public void DeleteRecord(string id, string type)
    {
        try
        {
            switch (type)
            {
                case "1":   // GridPanel ke hoach dao tao
                    new DaoTaoController().DeleteKeHoachDaoTaoByID(id);
                    GridPanel1.Reload();
                    break;
                case "2":   // Giáo viên đào tạo
                    RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;
                    new DaoTaoController().DeleteGiaoVien(id, sm.SelectedRows[0].RecordID);
                    //new DaoTaoController().DeleteGiaoVienDaoTao(id);
                    grp_GiaoVienDaoTao.Reload();
                    break;
                case "3":   // Các khoản chi phí
                    new DaoTaoController().DeleteChiPhi(int.Parse(id));
                    grp_CacKhoanChiPhi.Reload();
                    break;
                case "4":   // Nhân viên tham gia đào tạo
                    new DaoTaoController().DeleteNhanVien(int.Parse(id));
                    grp_nhanVienThamGiaDaoTao.Reload();
                    break;
            }
            //Dialog.ShowNotification("Xóa dữ liệu thành công");
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

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.KEHOACH_DAOTAO khdt = new DaoTaoController().GetKeHoachDaoTaoByID(hdfRecordID.Text);
            wdAddWindow.Title = "Sửa kế hoạch đào tạo";
            wdAddWindow.Icon = Icon.Pencil;
            frm_txtMaKhoaDaoTao.Text = khdt.MA;
            frm_txtMaKhoaDaoTao.Disabled = true;
            hdfDaoTaoCommand.Text = "Edit";
            frm_txtTenKhoaDaoTao.Text = khdt.TEN_KHOA_HOC;
            frm_cbChungChi.SetValue(khdt.MA_CHUNGCHI);

            frm_txtKinhPhiDuKien.Text = khdt.KINHPHI_DUKIEN != null ? khdt.KINHPHI_DUKIEN.Value.ToString() : "";
            frm_txtKinhPhiThucTe.Text = khdt.KINHPHI_THUCTE != null ? khdt.KINHPHI_THUCTE.Value.ToString() : "";
            frm_txtCongTyHoTro.Text = khdt.KINHPHI_CTY_HOTRO != null ? khdt.KINHPHI_CTY_HOTRO.Value.ToString() : "";
            frm_txtNhanVienDongGop.Text = khdt.KINHPHI_NHANVIEN_DONG != null ? khdt.KINHPHI_NHANVIEN_DONG.Value.ToString() : "";

            if (khdt.TU_NGAY.HasValue)
                frm_dfBatDauDaoTao.SelectedDate = khdt.TU_NGAY.Value;

            if (khdt.DEN_NGAY.HasValue)
                frm_dfKetThucDaoTao.SelectedDate = khdt.DEN_NGAY.Value;

            if (khdt.BATDAU_DANGKY.HasValue)
                frm_dfBatDauDangKy.SelectedDate = khdt.BATDAU_DANGKY.Value;

            if (khdt.HETHAN_DANGKY.HasValue)
                frm_dfHetHanDangKy.SelectedDate = khdt.HETHAN_DANGKY.Value;

            frm_txtDiaDiemDaoTao.Text = khdt.DIA_DIEM_DAOTAO;

            if (khdt.SOLUONG_HOCVIEN.HasValue)
                frm_txtSoLuongHocVien.Text = khdt.SOLUONG_HOCVIEN.Value.ToString();

            frm_txtDoiTuongDaoTao.Text = khdt.DOITUONG_DAOTAO;
            frm_txtThoiLuongDaoTao.Text = khdt.THOI_GIAN_DAOTAO;
            frm_txtLyDoDaoTao.Text = khdt.LYDO_DAOTAO;
            frm_txtNoiDungDaoTao.Text = khdt.NOIDUNG_DAOTAO;
            frm_txtGHiChi.Text = khdt.GHI_CHU;
            frm_cbPhuTrachDaoTao.SetValue(khdt.MA_DONVIPHUTRACHDAOTAO);
            frm_cbTrangThai.SetValue(khdt.TRANG_THAI);
            hdfCurrentStatus.Text = khdt.TRANG_THAI;
            wdAddWindow.Show();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DaoTaoController dtController = new DaoTaoController();
            foreach (var item in RowSelectionModel5.SelectedRows)
            {
                DAL.GiaoVien_KhoaDaoTao gv = new DAL.GiaoVien_KhoaDaoTao()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaGiaoVien = item.RecordID,
                    MaKhoaHoc = hdfRecordID.Text
                };
                dtController.ThemGiaoVienVaoKhoaHoc(gv);
            }
            wdChonTuDanhSachGiaoVien.Hide();
            RM.RegisterClientScriptBlock("ds", "#{grp_GiaoVienDaoTaoStore}.reload();");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void StoreDanhSachGiaoVien_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreDanhSachGiaoVien.DataSource = new DaoTaoController().LayDanhSachGiaoVien();
            StoreDanhSachGiaoVien.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DaoTaoController daotao = new DaoTaoController();
            DAL.KEHOACH_DAOTAO kehoach = new DAL.KEHOACH_DAOTAO()
            {
                MA = frm_txtMaKhoaDaoTao.Text.Trim(),
                TEN_KHOA_HOC = frm_txtTenKhoaDaoTao.Text.Trim(),
                MA_CHUNGCHI = frm_cbChungChi.SelectedItem.Value,
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                MA_DONVI = new UserController().GetDonViByUserID(CurrentUser.ID).FirstOrDefault().MA_DONVI,
                DIA_DIEM_DAOTAO = frm_txtDiaDiemDaoTao.Text,
                THOI_GIAN_DAOTAO = frm_txtThoiLuongDaoTao.Text,
                DOITUONG_DAOTAO = frm_txtDoiTuongDaoTao.Text,
                LYDO_DAOTAO = frm_txtLyDoDaoTao.Text,
                NOIDUNG_DAOTAO = frm_txtNoiDungDaoTao.Text,
                GHI_CHU = frm_txtGHiChi.Text,
                MA_DONVIPHUTRACHDAOTAO = frm_cbPhuTrachDaoTao.SelectedItem.Value,
                TEN_DONVIPHUTRACHDAOTAO = frm_cbPhuTrachDaoTao.SelectedItem.Text,
                TRANG_THAI = frm_cbTrangThai.SelectedItem.Value
            };
            if (!frm_dfBatDauDaoTao.Text.Contains("01/01/0001"))
                kehoach.TU_NGAY = frm_dfBatDauDaoTao.SelectedDate;
            if (!frm_dfKetThucDaoTao.Text.Contains("01/01/0001"))
                kehoach.DEN_NGAY = frm_dfKetThucDaoTao.SelectedDate;
            if (!frm_dfBatDauDangKy.Text.Contains("01/01/0001"))
                kehoach.BATDAU_DANGKY = frm_dfBatDauDangKy.SelectedDate;
            if (!frm_dfHetHanDangKy.Text.Contains("01/01/0001"))
                kehoach.HETHAN_DANGKY = frm_dfHetHanDangKy.SelectedDate;
            //  kehoach.MA_CHUNGCHI = frm_cbChungChi.SelectedItem.Value;
            if (!string.IsNullOrEmpty(frm_txtSoLuongHocVien.Text))
            {
                kehoach.SOLUONG_HOCVIEN = int.Parse(frm_txtSoLuongHocVien.Text);
            }
            if (!string.IsNullOrEmpty(frm_txtKinhPhiDuKien.Text))
            {
                kehoach.KINHPHI_DUKIEN = decimal.Parse(frm_txtKinhPhiDuKien.Text.ToString().Replace(" VNĐ", ""));
            }
            if (!string.IsNullOrEmpty(frm_txtKinhPhiThucTe.Text))
            {
                kehoach.KINHPHI_THUCTE = decimal.Parse(frm_txtKinhPhiThucTe.Text);
            }
            if (!string.IsNullOrEmpty(frm_txtCongTyHoTro.Text))
            {
                kehoach.KINHPHI_CTY_HOTRO = decimal.Parse(frm_txtCongTyHoTro.Text);
            }
            if (!string.IsNullOrEmpty(frm_txtNhanVienDongGop.Text))
            {
                kehoach.KINHPHI_NHANVIEN_DONG = decimal.Parse(frm_txtNhanVienDongGop.Text);
            }
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = "Thêm kế hoạch đào tạo",
                MOTA = "Thêm kế hoạch đào tạo",
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "KEHOACH_DAOTAO",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
            };

            if (e.ExtraParams["Command"] == "Edit")
            {
                accessDiary.CHUCNANG = "Sửa kế hoạch đào tạo";
                accessDiary.MOTA = "Mã kế hoạch đào tạo được sửa là : " + frm_txtMaKhoaDaoTao.Text;
                daotao.Update(kehoach);
            }
            else
            {
                daotao.Insert(kehoach);
            }
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
            if (e.ExtraParams["Close"] == "True")
                wdAddWindow.Hide();
            RM.RegisterClientScriptBlock("zz", "#{Store1}.reload();ResetValue();");
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains(" Cannot insert duplicate key in object "))
            {
                Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("DuplicateMaDaoTao"));
            }
            else
                Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void grp_DanhSachKhoaHocStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        grp_DanhSachKhoaHocStore.DataSource = new DaoTaoController().GetAllKhoaDaoTao();
        grp_DanhSachKhoaHocStore.DataBind();
    }

    protected void ChuyenTrangThai_Click(object sender, DirectEventArgs e)
    {
        DaoTaoController daotaoController = new DaoTaoController();
        daotaoController.ChuyenTrangThai(hdfRecordID.Text, e.ExtraParams["TrangThai"]);
        RM.RegisterClientScriptBlock("rl", "#{Store1}.reload();");
    }

    protected void grp_GiaoVienDaoTaoStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            grp_GiaoVienDaoTaoStore.DataSource = new DaoTaoController().GetGiaoVienDaoTaoByMaKhoaDaoTao(hdfRecordID.Text);
            grp_GiaoVienDaoTaoStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void btnSuaChiPhi_Click(object sender, DirectEventArgs e)
    {
        DaoTaoController daotao = new DaoTaoController();
        DAL.DM_CacKhoanChiChoDaoTao cacKhoanDaoTao = daotao.GetChiPhiDaoTaoByID(int.Parse(hdfChiPhi.Text));
        txtTenKhoanChiPhi.Text = cacKhoanDaoTao.TenChiPhi;
        txtNguonCHi.Text = cacKhoanDaoTao.NguonChi;
        txtSoTienChiPhi.Value = cacKhoanDaoTao.SoTien;
        wdCacKhoanChiPhi.Show();
    }

    protected void grp_nhanVienThamGiaDaoTaoStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<NhanVienThamGiaDaoTaoInfo> nvInfo = new DaoTaoController().GetNhanVienThamGiaDaoTaoByMaDaoTao(hdfRecordID.Text, 0, 1000);
            grp_nhanVienThamGiaDaoTaoStore.DataSource = nvInfo;
            grp_nhanVienThamGiaDaoTaoStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }
    protected void btnCapNhatChiPhi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DM_CacKhoanChiChoDaoTao chiPhi = new DAL.DM_CacKhoanChiChoDaoTao()
            {
                NguonChi = txtNguonCHi.Text,
                TenChiPhi = txtTenKhoanChiPhi.Text,
                SoTien = decimal.Parse("0" + txtSoTienChiPhi.Text.Replace(".", ",")),
                FR_KEY = hdfRecordID.Text,
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now
            };
            if (e.ExtraParams["Edit"] == "True")
            {
                try
                {
                    chiPhi.ID = int.Parse(hdfChiPhi.Text);
                    new DaoTaoController().UpdateChiPhi(chiPhi);
                    Dialog.ShowNotification("Cập nhật dữ liệu thành công!...");
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }

            }
            else
            {
                try
                {
                    new DaoTaoController().InsertChiphiDaotao(chiPhi);
                    Dialog.ShowNotification("Thêm dữ liệu thành công!...");
                }
                catch (Exception ex)
                {

                    Dialog.ShowError(ex.Message);
                }

            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdCacKhoanChiPhi.Hide();
            }
            else
            {
                RM.RegisterClientScriptBlock("123gff", "#{btnCapNhatChiPhi}.show();#{Button7}.show();#{Button9}.hide();txtTenKhoanChiPhi.reset();txtNguonCHi.reset();txtSoTienChiPhi.reset();");
            }
            //   wdCacKhoanChiPhi.Hide();
            RM.RegisterClientScriptBlock("d", "#{grp_CacKhoanChiPhiStore}.reload();");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void HandleChangesGiaoVien(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<GiaoVienThamGiaDaoTaoInfo> records = e.DataHandler.ObjectData<GiaoVienThamGiaDaoTaoInfo>();
        DaoTaoController controller = new DaoTaoController();
        foreach (GiaoVienThamGiaDaoTaoInfo item in records.Deleted)
        {
            controller.DeleteGiaoVien(item.MaGV, hdfRecordID.Text);
        }
    }

    protected void HandleChangesChiPhi(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<CacKhoanChiPhiInfo> records = e.DataHandler.ObjectData<CacKhoanChiPhiInfo>();
        DaoTaoController controller = new DaoTaoController();
        foreach (CacKhoanChiPhiInfo item in records.Deleted)
        {
            controller.DeleteChiPhi(item.ID);
        }
    }

    protected void HandleChangesDaoTao(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<NhanVienThamGiaDaoTaoInfo> record = e.DataHandler.ObjectData<NhanVienThamGiaDaoTaoInfo>();
        DaoTaoController controller = new DaoTaoController();
        foreach (var item in record.Deleted)
        {
            controller.DeleteNhanVien(item.ID);
        }

        foreach (NhanVienThamGiaDaoTaoInfo item in record.Updated)
        {
            controller.UpdateNhanVien(item);
        }
    }

    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<KEHOACH_DAOTAOInfo> records = e.DataHandler.ObjectData<KEHOACH_DAOTAOInfo>();
        foreach (KEHOACH_DAOTAOInfo item in records.Deleted)
        {
            new DaoTaoController().Delete(item.MaKeHoach);
        }
    }

    protected void grp_CacKhoanChiPhiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            grp_CacKhoanChiPhiStore.DataSource = new DaoTaoController().GetCacKhoanChiPhi(hdfRecordID.Text);
            grp_CacKhoanChiPhiStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void btnOkPrimaryKey_Click(object sender, DirectEventArgs e)
    {
        try
        {
            new DaoTaoController().DuplicateRecord(hdfRecordID.Text, txtNewPrimaryKey.Text, CurrentUser.ID, chkDuplicateGiaoVien.Checked, chkDuplicateCacKhoanChiPhi.Checked, chkDuplicateNhanVienThamGiaDaoTao.Checked);
            wdInputNewPrimaryKey.Hide();
            RM.RegisterClientScriptBlock("rl", "#{Store1}.reload();");
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Cannot insert duplicate key in object ") || ex.Message.ToString().Contains("already in use"))
            {
                Dialog.ShowError("Mã kế hoạch đào tạo bị trùng ! Bạn hãy nhập lại mã khác.");
            }
            else
                Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }


    protected void btnChonKhoaHocOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // Dialog.ShowError(RowSelectionModel1.SelectedRecordID);
            DAL.KHOA_DAOTAO khoaDaoTao = new DaoTaoController().GetByMaKhoaDaoTao(hdfMaKhoaHoc.Text);
            if (khoaDaoTao != null)
            {
                frm_txtMaKhoaDaoTao.Text = khoaDaoTao.MA_KHOA;
                frm_txtTenKhoaDaoTao.Text = khoaDaoTao.TEN_KHOAHOC;
                frm_txtThoiLuongDaoTao.Text = khoaDaoTao.ThoiGianDuKien;
                frm_cbChungChi.SetValue(khoaDaoTao.MA_CHUNGCHI);
                if (khoaDaoTao.CHIPHIDUKIEN.HasValue)
                {
                    frm_txtKinhPhiDuKien.Text = khoaDaoTao.CHIPHIDUKIEN.Value.ToString();
                }

                if (khoaDaoTao.CHIPHITHUCTE.HasValue)
                {
                    frm_txtKinhPhiThucTe.Text = khoaDaoTao.CHIPHITHUCTE.Value.ToString();
                }

                frm_txtDiaDiemDaoTao.Text = khoaDaoTao.DIA_DIEM_DAO_TAO;

                if (khoaDaoTao.CongTyHoTro.HasValue)
                {
                    frm_txtCongTyHoTro.Text = khoaDaoTao.CongTyHoTro.Value.ToString();
                }
                if (khoaDaoTao.NhanVienDong.HasValue)
                {
                    frm_txtNhanVienDongGop.Text = khoaDaoTao.NhanVienDong.Value.ToString();
                }

                if (khoaDaoTao.SOLUONGHOCVIEN.HasValue)
                {
                    frm_txtSoLuongHocVien.Text = khoaDaoTao.SOLUONGHOCVIEN.Value.ToString();
                }

                frm_cbPhuTrachDaoTao.SetValue(khoaDaoTao.MA_DONVIPHUTRACH);
            }
            wdChonKhoaHoc.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    //protected void frm_txtLyDoDaoTao_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        Store2.DataSource = DataHandler.GetInstance().ExecuteDataTable("select TEN_LYDO_DAOTAO from DM_LYDO_DAOTAO");
    //        Store2.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError("Lối xảy ra " + ex.Message);
    //    }
    //}
    
    protected void frm_cbPhuTrachDaoTaoStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            frm_cbPhuTrachDaoTaoStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select Ma,Ten from DM_DOITACDAOTAO");
            frm_cbPhuTrachDaoTaoStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    [DirectMethod]
    public void GetData()
    {
        try
        {
            DaoTaoController daotaoController = new DaoTaoController();
            DAL.KEHOACH_DAOTAO daotao = new DaoTaoController().GetByID(hdfRecordID.Text);
            txtTenKhoaHoc.Text = daotao.TEN_KHOA_HOC;

            frm_txtKinhPhiDuKien.Text = daotao.KINHPHI_DUKIEN != null ? SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_DUKIEN.Value.ToString()) : "";
            txtKinhPhiDuKien.Text = daotao.KINHPHI_DUKIEN != null ? SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_DUKIEN.Value.ToString()) : "";
            txtKinhPhiThucTe.Text = daotao.KINHPHI_THUCTE != null ? SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_THUCTE.Value.ToString()) : "";
            txtCongTyHoTro.Text = daotao.KINHPHI_CTY_HOTRO != null ? SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_CTY_HOTRO.Value.ToString()) : "";
            txtNVDongGop.Text = daotao.KINHPHI_NHANVIEN_DONG != null ? SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_NHANVIEN_DONG.Value.ToString()) : "";
            //if (daotao.KINHPHI_DUKIEN.HasValue)
            //    txtKinhPhiDuKien.Text = SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_DUKIEN.Value.ToString());
            //if (daotao.KINHPHI_THUCTE.HasValue)
            //{
            //    txtKinhPhiThucTe.Text = SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_THUCTE.Value.ToString());
            //}
            //if (daotao.KINHPHI_CTY_HOTRO.HasValue)
            //    txtCongTyHoTro.Text = SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_CTY_HOTRO.Value.ToString());
            //if (daotao.KINHPHI_NHANVIEN_DONG.HasValue)
            //    txtNVDongGop.Text = SoftCore.Util.GetInstance().GetFormatCurrencyInVietNam(daotao.KINHPHI_NHANVIEN_DONG.Value.ToString());

            txtNoiDungDaoTao.Text = daotao.NOIDUNG_DAOTAO;

            txtLyDoDaoTao.Text = daotao.LYDO_DAOTAO;
            txtDiaDiemDaoTao.Text = daotao.DIA_DIEM_DAOTAO;
            txtSoLuongHocVien.Text = daotao.SOLUONG_HOCVIEN != null ? daotao.SOLUONG_HOCVIEN.Value.ToString() : "";
            //if (daotao.SOLUONG_HOCVIEN.HasValue)
            //    txtSoLuongHocVien.Text = daotao.SOLUONG_HOCVIEN.Value.ToString();
            txtDoiTuongDaoTao.Text = daotao.DOITUONG_DAOTAO;
            txtThoiGianDaoTao.Text = daotao.THOI_GIAN_DAOTAO;
            txtChungChi.Text = daotao.DM_CHUNGCHI != null ? daotao.DM_CHUNGCHI.TEN_CHUNGCHI : "";
            //if (daotao.DM_CHUNGCHI != null)
            //    txtChungChi.Text = daotao.DM_CHUNGCHI.TEN_CHUNGCHI;

            if (daotao.DEN_NGAY != null && !daotao.DEN_NGAY.ToString().Contains("0001"))
                txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", daotao.DEN_NGAY.Value.ToShortDateString());
            else
                txtDenNgay.Text = "";
            if (daotao.TU_NGAY != null && !daotao.TU_NGAY.ToString().Contains("0001"))
                txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", daotao.TU_NGAY.Value.ToShortDateString());
            else
                txtTuNgay.Text = "";
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void btnSuaGiaoVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DaoTaoController dt = new DaoTaoController();
            DAL.DM_GiaoVienDaoTao gv = dt.GetGiaoVienByMaGiaoVien(RowSelectionModel4.SelectedRows[0].RecordID);
            gv_txtMaGiaoVien.Text = gv.MaGV;
            gv_txtHoten.Text = gv.HoTenGV;
            if (gv.NgaySinh.HasValue)
            {
                df_ngaysinh.SelectedDate = gv.NgaySinh.Value;
            }
            txt_chucvu.Text = gv.ChucVu;
            txt_hocvan.Text = gv.HocVan;
            txt_email.Text = gv.Email;
            txt_dtcq.Text = gv.DTCoQuan;
            chk_nvcongty.Checked = gv.LaNhanvienCty;
            cbx_gioitinh.SetValue(gv.GioiTinh);
            txt_donvicongtac.Text = gv.DonViCongTac;
            txt_diachi.Text = gv.DiaChiLienHe;
            txt_didong.Text = gv.DiDong;
            txt_nhanxet.Text = gv.NhanXet;
            txt_kinhnghiem.Text = gv.KinhNghiemGiangDay;
            gv_txtMaGiaoVien.Disabled = true;
            wdGiaoVien.Show();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void gv_txtMaGiaoVien_Blur(object sender, DirectEventArgs e)
    {
        try
        {
            if (new DaoTaoController().IsDuplicateMaGiaoVien(gv_txtMaGiaoVien.Text))
                Dialog.ShowError("Mã giáo viên này đã tồn tại rồi, đề nghị nhập mã khác !");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

    protected void Button17_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DaoTaoController daotao = new DaoTaoController();
            DAL.DM_GiaoVienDaoTao giaovien = new DAL.DM_GiaoVienDaoTao();
            giaovien.ChucVu = txt_chucvu.Text;
            giaovien.CreatedBy = CurrentUser.ID;
            giaovien.CreatedDate = DateTime.Now;
            giaovien.DiaChiLienHe = txt_diachi.Text;
            giaovien.DiDong = txt_didong.Text;
            giaovien.DiDong = txt_didong.Text;
            giaovien.DonViCongTac = txt_donvicongtac.Text;
            giaovien.DTCoQuan = txt_dtcq.Text;
            giaovien.Email = txt_email.Text;
            giaovien.GioiTinh = bool.Parse(cbx_gioitinh.SelectedItem.Value);
            giaovien.HocVan = txt_hocvan.Text;
            giaovien.HoTenGV = gv_txtHoten.Text;
            giaovien.KinhNghiemGiangDay = txt_kinhnghiem.Text;
            giaovien.LaNhanvienCty = chk_nvcongty.Checked;
            giaovien.MaGV = gv_txtMaGiaoVien.Text;
            giaovien.NhanXet = txt_nhanxet.Text;
            giaovien.MA_DONVI = new UserController().GetDonViByUserID(CurrentUser.ID).FirstOrDefault().MA_DONVI;
            if (df_ngaysinh.SelectedDate.ToString().Contains("01/01/0001") == false)
            {
                giaovien.NgaySinh = df_ngaysinh.SelectedDate;
            }
            if (e.ExtraParams["Command"] == "Edit")
            {
                daotao.UpdateGiaoVien(giaovien);
                RM.RegisterClientScriptBlock("zz", "#{grp_GiaoVienDaoTaoStore}.reload();");
                wdGiaoVien.Hide();

            }
            else
            {
                daotao.InsertGiaoVien(giaovien);
                daotao.ThemGiaoVienVaoKhoaHoc(new DAL.GiaoVien_KhoaDaoTao()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaGiaoVien = giaovien.MaGV,
                    MaKhoaHoc = hdfRecordID.Text
                });
                RM.RegisterClientScriptBlock("zz", "#{grp_GiaoVienDaoTaoStore}.reload();");
                if (e.ExtraParams["Close"] == "True")
                {
                    wdGiaoVien.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("z1", " gv_txtMaGiaoVien.reset();gv_txtHoten.reset();df_ngaysinh.reset();txt_chucvu.reset();" +
                                "txt_hocvan.reset();txt_email.reset();txt_dtcq.reset();chk_nvcongty.reset();cbx_gioitinh.reset();cbx_gioitinh.reset();"
                                + "txt_donvicongtac.reset();txt_diachi.reset();txt_didong.reset();txt_nhanxet.reset();txt_kinhnghiem.reset();gv_txtMaGiaoVien.enable();");
                }

            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lối xảy ra " + ex.Message);
        }
    }

}