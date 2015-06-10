using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using DataController;
using DAL;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using SoftCore;
using SoftCore.AccessHistory;
using System.Data.SqlClient;
using System.Text;

public partial class Modules_HoSoNhanSu_Default : WebBase
{
    string[] dsDv;
    int countRole = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            date_ngayvaodoan.MaxDate = DateTime.Now;
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            txtReportCreator.Text = CurrentUser.DisplayName;
            // transfer user id
            store_HoSoNhanSu.BaseParams.Add(new Ext.Net.Parameter("uID", CurrentUser.ID.ToString()));
            store_HoSoNhanSu.BaseParams.Add(new Ext.Net.Parameter("mID", MenuID.ToString()));

            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfSelectedDepartment}.setValue('" + DTH.BorderLayout.nodeID + "');#{PagingToolbar1}.pageIndex = 0;#{DirectMethods}.SetValueQuery();"
            }.AddDepartmentList(brlayout, CurrentUser.ID, true);

            SetVisibleByControlID(btnAddNew, btnEdit, btnDelete,
                                  btnBaoCao, btnTienIchHoSo, mnuNhanDoiDuLieu, mnuNhapTuExcel, mnuCapNhatAnhHangLoat);
            if (btnDelete.Visible)
            {
                checkboxSelection.Listeners.RowSelect.Handler += "btnDelete.enable();";
            }
            if (mnuNhanDoiDuLieu.Visible)
            {
                checkboxSelection.Listeners.RowSelect.Handler += "mnuNhanDoiDuLieu.enable();";
            }
            #region phân quyền context menu
            mnuAdd.Visible = btnAddNew.Visible;
            mnuEdit.Visible = btnEdit.Visible;
            mnuDelete.Visible = btnDelete.Visible;
            mnuBaoCao.Visible = btnBaoCao.Visible;
            mnuTienIch.Visible = btnTienIchHoSo.Visible;
            mnuNhanDoi.Visible = mnuNhanDoiDuLieu.Visible;
            mnuNhapExcel.Visible = mnuNhapTuExcel.Visible;
            mnuCapNhatAnh.Visible = mnuCapNhatAnhHangLoat.Visible;
            #endregion
            filterDaNghi.SetValue(0);
        }
        if (btnEdit.Visible)
        {
            checkboxSelection.Listeners.RowSelect.Handler += "btnEdit.enable();";
            grp_HoSoNhanSu.DirectEvents.RowDblClick.Before = "#{hdfCommandButton}.setValue('Edit');#{btnUpdateEdit}.show();#{btn_InsertandClose}.hide();#{btnCapNhat}.hide();";
            grp_HoSoNhanSu.DirectEvents.RowDblClick.EventMask.ShowMask = true;
            grp_HoSoNhanSu.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
        }

        CapNhatAnhHangLoat1.AfterClickXemCanBoChuaCoAnhButton += new EventHandler(AfterClickXemCanBoChuaCoAnhButton_AfterClickXemCanBoChuaCoAnhButton);
        CapNhatAnhHangLoat1.AfterClickHideWindow += new EventHandler(AfterClickHideWindow_AfterClickHideWindow);
        CapNhatAnhHangLoat1.AfterClickCapNhat += new EventHandler(AfterClickCapNhat_AfterClickCapNhat);
    }
    [DirectMethod]
    public void AfterEdit(string MA, string oldValue, string value)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateCategory", "@TableDM", "@ColMa", "@ColTen", "@MA", "@Value", hdfTableDM.Text, hdfColMa.Text, hdfColTen.Text, MA, value);
            this.grpCategory.Store.Primary.CommitChanges();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.Message);
        }
    }
    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_InsertCategory", "@TableDM", "@ColMa", "@ColTen", "@ValueMa", "@ValueTen", hdfTableDM.Text, hdfColMa.Text, hdfColTen.Text, txtMaDM.Text, txtTenDM.Text);
            RM.RegisterClientScriptBlock("add", "addRecordCategory('" + txtMaDM.Text + "','" + txtTenDM.Text + "'); resetInputCategory();");
            //this.grpCategory.Store.Primary.CommitChanges();
        }
        catch (SqlException sqlex)
        {
            if (sqlex.Number == ErrorNumber.DUPLICATE_PRIMARY_KEY)
            {
                Dialog.ShowError("Mã danh mục đã bị trùng");
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.Message);
        }

    }
    protected void btnDeleteCategory_Click(object sender, DirectEventArgs e)
    {
        foreach (var item in RowSelectionModelCategory.SelectedRows)
        {
            int t = 0;
            try
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_DeleteCategoryByMa", "@TableDM", "@ColMa", "@ID", hdfTableDM.Text, hdfColMa.Text, item.RecordID);
                stCategory.RemoveRecord(item.RecordID);
                this.grpCategory.Store.Primary.CommitChanges();
                t = 1;

            }
            catch (SqlException sqlex)
            {
                t = 0;
                if (sqlex.Number == ErrorNumber.DATA_IS_INUSED_IN_OTHER_TABLE)
                {
                    Dialog.ShowError("Danh mục đã được sử dụng không thể xóa");
                }
                if (sqlex.Message.Contains("REFERENCE constraint"))
                {
                    X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa được vì dữ liệu này đang được sử dụng ở chỗ khác !").Show();
                }
            }
            catch (Exception ex)
            {
                t = 0;
                if (ex.Message.Contains("REFERENCE constraint"))
                {
                    X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa được vì dữ liệu này đang được sử dụng ở chỗ khác !").Show();
                }
                else
                {
                    Dialog.ShowError("" + ex.Message);
                }
            }
            if (t == 1)
            {
                Dialog.ShowNotification("Xóa dữ liệu thành công");
            }
        }
        btnDeleteCategory.Disabled = true;
    }
    /// <summary>
    /// Xem nhân viên chưa có ảnh
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void AfterClickXemCanBoChuaCoAnhButton_AfterClickXemCanBoChuaCoAnhButton(object sender, EventArgs e)
    {
        try
        {
            hdfMaDonVi.Text = "";
            filterGioiTinh.Reset();
            filterNgaySinh.Reset();
            filterChucVu.Reset();
            filterCongViec.Reset();
            filterThamNien.Reset();
            filterTrinhDo.Reset();
            filterChuyenNganh.Reset();
            filterTinhThanh.Reset();
            filterLoaiHopDong.Reset();
            filterDiaChiLH.Reset();
            filterDiDong.Reset();
            filterEmail.Reset();
            filterDaNghi.Reset();
            txtSearch.Reset();

            bool isChuaCoAnh = (bool)sender;
            hdfIsChuaCoAnh.Text = isChuaCoAnh.ToString();
            SetValueQuery();
            PagingToolbar1.PageIndex = 0;
            grp_HoSoNhanSu.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    void AfterClickHideWindow_AfterClickHideWindow(object sender, EventArgs e)
    {
        try
        {
            RM.RegisterClientScriptBlock("tbenable", "tb.show();SouthHoSoNhanSu1_Toolbar1sdsds.show();");
            bool isChuaCoAnh = (bool)sender;
            if (hdfIsChuaCoAnh.Text.ToLower() == "true")
            {
                hdfIsChuaCoAnh.Text = isChuaCoAnh.ToString();
                PagingToolbar1.PageIndex = 0;
                grp_HoSoNhanSu.Reload();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }
    /// <summary>
    /// Sau khi cập nhật ảnh hàng loạt thì reload lại grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void AfterClickCapNhat_AfterClickCapNhat(object sender, EventArgs e)
    {
        PagingToolbar1.PageIndex = 0;
        grp_HoSoNhanSu.Reload();
    }

    #region OnRefreshData các ComboBox

    protected void cbx_quoctich_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_quoctich_Store.DataSource = new DM_NUOCController().GetAll();
        cbx_quoctich_Store.DataBind();
    }

    protected void filterTinhThanhStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        filterTinhThanhStore.DataSource = new DM_TINHTHANHController().GetAll();
        filterTinhThanhStore.DataBind();
    }

    protected void cbx_noicaphc_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicaphc_Store.DataSource = new DM_NOICAP_HOCHIEUController().GetAll();
        cbx_noicaphc_Store.DataBind();
    }

    protected void cbx_xeploai_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_xeploai_Store.DataSource = new DM_XEPLOAIController().GetAll1();
        cbx_xeploai_Store.DataBind();
    }

    protected void cbx_tinhoc_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tinhoc_Store.DataSource = new DM_TINHOCController().GetAll();
        cbx_tinhoc_Store.DataBind();
    }

    protected void cbx_ngoaingu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_ngoaingu_Store.DataSource = new DM_NGOAINGUController().GetAll();
        cbx_ngoaingu_Store.DataBind();
    }

    protected void cbx_tdvanhoa_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tdvanhoa_Store.DataSource = new DM_TD_VANHOAController().GetAll();
        cbx_tdvanhoa_Store.DataBind();
    }

    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
        if (dsDv == null || dsDv.Count() == 0)
        {
            dsDv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        }
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            if (dsDv.Contains(info.MA))
                obj.Add(new { MA = info.MA, TEN = info.TEN });
            else
            {
                obj.Add(new { MA = countRole.ToString(), TEN = info.TEN });
                countRole--;
            }
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        cbx_bophan_Store.DataSource = obj;
        cbx_bophan_Store.DataBind();
    }

    protected void cbxHinhThucLamViec_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxHinhThucLamViec_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("HinhThucLamViec", true);
        cbxHinhThucLamViec_Store.DataBind();
    }

    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "----";
            if (dsDv.Contains(item.MA))
                obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            else
            {
                obj.Add(new { MA = countRole.ToString(), TEN = tmp + item.TEN });
                countRole--;
            }
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }

    protected void filterLoaiHopDong_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        filterLoaiHopDong_Store.DataSource = new DM_LOAI_HDONGController().GetAll1();
        filterLoaiHopDong_Store.DataBind();
    }

    protected void cbx_httuyen_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_httuyen_Store.DataSource = new DM_HT_TUYENDUNGController().GetAll();
        cbx_httuyen_Store.DataBind();
    }

    protected void cbx_huongcs_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_huongcs_Store.DataSource = new DM_LOAI_CSController().GetAll();
        cbx_huongcs_Store.DataBind();
    }

    protected void cbx_noikcb_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noikcb_Store.DataSource = new DM_NOI_KCBController().GetAll();
        cbx_noikcb_Store.DataBind();
    }

    protected void cbx_noicapbhxh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicapbhxh_Store.DataSource = new DM_NOICAPBAOHIEMXHController().GetAll();
        cbx_noicapbhxh_Store.DataBind();
    }

    protected void cbx_noicapcmnd_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicapcmnd_Store.DataSource = new DM_NOICAP_CMNDController().GetAll();
        cbx_noicapcmnd_Store.DataBind();
    }

    protected void cbx_trinhdochinhtri_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdochinhtri_Store.DataSource = new DM_TD_CHINHTRIController().GetAll();
        cbx_trinhdochinhtri_Store.DataBind();
    }

    protected void cbx_chuvudang_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_chuvudang_Store.DataSource = new DM_CHUCVU_DANGController().GetAll();
        cbx_chuvudang_Store.DataBind();
    }

    protected void cbx_chucvudoan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_chucvudoan_Store.DataSource = new DM_CHUCVU_DOANController().GetAll();
        cbx_chucvudoan_Store.DataBind();
    }

    protected void cbx_bacquandoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_bacquandoi_Store.DataSource = new DM_CAPBAC_QDOIController().GetAll();
        cbx_bacquandoi_Store.DataBind();
    }

    protected void cbx_chucvuquandoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_chucvuquandoi_Store.DataSource = new DM_CHUCVU_QDOIController().GetAll();
        cbx_chucvuquandoi_Store.DataBind();
    }

    protected void cbx_ttsuckhoe_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_ttsuckhoe_Store.DataSource = new DM_TT_SUCKHOEController().GetAll();
        cbx_ttsuckhoe_Store.DataBind();
    }

    protected void cbx_ngach_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_ngach_Store.DataSource = new DM_NGACHController().GetAll1();
        cbx_ngach_Store.DataBind();
    }

    protected void cbx_trinhdoquanly_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdoquanly_Store.DataSource = new DM_TD_QUANLYController().GetAll();
        cbx_trinhdoquanly_Store.DataBind();
    }

    protected void cbx_trinhdoquanlykt_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdoquanlykt_Store.DataSource = new DM_TD_QLKTController().GetAll();
        cbx_trinhdoquanlykt_Store.DataBind();
    }

    //protected void cbx_congviec_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbx_congviec_Store.DataSource = new DM_CONGVIECController().GetAll();
    //    cbx_congviec_Store.DataBind();
    //}

    protected void cbx_nganhang_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_nganhang_Store.DataSource = new DM_NGANHANGController().GetAll();
        cbx_nganhang_Store.DataBind();
    }

    protected void cbx_lydonghi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_lydonghi_Store.DataSource = new DM_LYDO_NGHIController().GetAll();
        cbx_lydonghi_Store.DataBind();
    }
    protected void cbx_diadiemlamviec_Store_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("SELECT MA_DIADIEM AS 'MA', TEN_DIADIEM AS 'TEN' FROM DM_DIADIEMLAMVIEC");
        cbx_diadiemlamviec_Store.DataSource = table;
        cbx_diadiemlamviec_Store.DataBind();
    }

    protected void filterNgaySinhStore_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("select distinct YEAR(NGAY_SINH) AS NAM_SINH from HOSO where NGAY_SINH is not null order by NAM_SINH ASC");
            List<object> obj = new List<object>();
            obj.Add(new { NAM_SINH = -1, TEN_NAMSINH = "Tất cả" });
            foreach (DataRow item in table.Rows)
            {
                obj.Add(new { NAM_SINH = item["NAM_SINH"], TEN_NAMSINH = item["NAM_SINH"] });
            }
            filterNgaySinhStore.DataSource = obj;
            filterNgaySinhStore.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString());
        }
    }

    protected void cbx_chucvu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_chucvu_Store.DataSource = new DanhMucChucVuController().GetAll();
            cbx_chucvu_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }
    #endregion

    #region DirectMethod

    [DirectMethod]
    public void GeneratePrimaryKey()
    {
        try
        {
            // sinh mã cán bộ
            HoSoController hsController = new HoSoController();
            txt_macb.Text = hsController.GenerateMaCB(Session["MaDonVi"].ToString());
            // sinh phòng ban, tổ đội nếu có
            if (hdfMaDonVi.Text != "" && hdfMaDonVi.Text != Session["MaDonVi"].ToString())
            {
                DM_DONVI phongBan = new DM_DONVIController().GetById(hdfMaDonVi.Text);
                if (phongBan != null)
                {
                    hdfBoPhan.Text = phongBan.MA_DONVI;
                    cbx_bophan.SetValue(phongBan.MA_DONVI);
                }
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification("Có lỗi xảy ra khi sinh mã cán bộ: " + ex.Message);
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdInputEmployee.Title = "Nhập thông tin hồ sơ";
        wdInputEmployee.Icon = Icon.Add;
        //reset ảnh và các combobox
        img_anhdaidien.ImageUrl = "~/Modules/NhanSu/ImageNhanSu/No_person.jpg";
        tab_hosonhansu.ActiveTab = pnl_HoSoNhanSu;
    }

    [DirectMethod]
    public void DeleteRecord()
    {
        SelectedRowCollection SelectedRows = checkboxSelection.SelectedRows;
        int count = 0;
        foreach (var item in SelectedRows)
        {
            decimal prkey = decimal.Parse("0" + item.RecordID);
            try
            {
                new HoSoController().DeleteByMaCB(prkey);
            }
            catch
            {
                count++;
            }
        }
        hdfRecordID.Text = "";
        if (count > 0)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có " + count + " cán bộ không được xóa do đang được sử dụng").Show();
        }
        grp_HoSoNhanSu.Reload();
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        SelectedRowCollection SelectedRows = checkboxSelection.SelectedRows;
        int count = 0, success = 0;
        foreach (var item in SelectedRows)
        {
            decimal prkey = decimal.Parse("0" + item.RecordID);
            try
            {
                new HoSoController().DeleteByMaCB(prkey);
                success++;
            }
            catch
            {
                count++;
            }
        }
        hdfRecordID.Text = "";
        if (count > 0)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có " + count + " cán bộ không được xóa do đang được sử dụng").Show();
        }
        if (success > 0)
            grp_HoSoNhanSu.Reload();
    }

    [DirectMethod]
    public void DisableCbxDanToc()
    {
        if (cbx_quoctich.SelectedItem != null)
        {
            if (cbx_quoctich.SelectedItem.Value != "VIE")
            {
                cbx_dantoc.Disabled = true;
                cbx_tinhthanh.Disabled = true;
            }
            else
            {
                cbx_dantoc.Disabled = false;
                cbx_tinhthanh.Disabled = false;
            }
        }
    }

    [DirectMethod]
    public void SetValueQuery()
    {
        hdfRecordID.Text = "";
        RM.RegisterClientScriptBlock("clearSelections", "grp_HoSoNhanSu.getSelectionModel().clearSelections();");
        string query = string.Empty;
        query += filterGioiTinh.SelectedItem != null ? filterGioiTinh.SelectedItem.Value : ""; query += ";";
        query += filterNgaySinh.SelectedItem.Value != null ? filterNgaySinh.SelectedItem.Value : "-1"; query += ";";
        query += filterTrinhDo.SelectedItem != null ? filterTrinhDo.SelectedItem.Value : ""; query += ";";
        query += filterChuyenNganh.SelectedItem != null ? filterChuyenNganh.SelectedItem.Value : ""; query += ";";
        query += filterTinhThanh.SelectedItem != null ? filterTinhThanh.SelectedItem.Value : ""; query += ";";
        query += filterLoaiHopDong.SelectedItem != null ? filterLoaiHopDong.SelectedItem.Value : ""; query += ";";
        query += Util.GetInstance().GetKeyword(filterDiaChiLH.Text) + ";";
        query += filterDiDong.Text + ";";
        query += filterEmail.Text + ";";
        query += filterDaNghi.SelectedItem.Text != "" ? filterDaNghi.SelectedItem.Value : "-1"; query += ";";
        query += filterChucVu.SelectedItem != null ? filterChucVu.SelectedItem.Value : ""; query += ";";
        query += filterCongViec.SelectedItem != null ? filterCongViec.SelectedItem.Value : ""; query += ";";
        query += filterThamNien.Text; query += ";";
        query += filterHTTuyenDung.SelectedIndex != null ? filterHTTuyenDung.SelectedItem.Value : ""; query += ";";
        query += filterDiaDiemLamViec.SelectedIndex != null ? filterDiaDiemLamViec.SelectedItem.Value : "";
        hdfQuery.Text = query;
        PagingToolbar1.PageIndex = 0;
        grp_HoSoNhanSu.Reload();
    }
    #endregion

    protected void btnAccept_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string path1 = string.Empty;
            //upload file
            HttpPostedFile file = fufUploadControl.PostedFile;
            if (fufUploadControl.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath(hdfImageFolder.Text));
                    if (dir.Exists == false)
                        dir.Create();
                    string[] split = fufUploadControl.FileName.Split(new Char[] { '.' });
                    int pt = split.Count();
                    string dinhDang = split[pt - 1];
                    string path = Server.MapPath(hdfImageFolder.Text + "/HoSoNhanSu_AnhDaiDien_") + Util.GetInstance().GetRandomString(50) + '.' + dinhDang;
                    //                    path1 = hdfImageFolder.Text + "/" + Util.GetInstance().GetRandomString(10) + fufUploadControl.FileName;
                    path1 = hdfImageFolder.Text + "/HoSoNhanSu_AnhDaiDien_" + Util.GetInstance().GetRandomString(50) + '.' + dinhDang;
                    file.SaveAs(path);
                    System.IO.File.Move(path, Server.MapPath(path1));
                    //update ảnh vào csdl 
                    if (!string.IsNullOrEmpty(hdfMaCB.Text))
                    {
                        new HoSoController().UpdateImage(hdfMaCB.Text, path1);
                    }
                    else
                    {
                        new HoSoController().UpdateImage(decimal.Parse("0" + hdfRecordID.Text), path1);
                    }
                    hdfAnhDaiDien.Text = path1;
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
            wdUploadImageWindow.Hide();

            //Hiển thị lại ảnh sau khi đã cập nhật xong
            img_anhdaidien.ImageUrl = path1;//hdfImageFolder.Text + "/" + fufUploadControl.FileName;
            SouthHoSoNhanSu1.SetProfileImage(path1);
            grp_HoSoNhanSu.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }

    //protected void wdInputReportParameter_BeforeShow(object sender, DirectEventArgs e)
    //{
    //    try
    //    {
    //        HeThongController htController = new HeThongController();
    //        // người lập báo cáo
    //        string isLogged = htController.GetValueByName(SystemConfigParameter.SuDungTenDangNhap, Session["MaDonVi"].ToString());
    //        if (isLogged.ToLower() == "true")
    //        {
    //            txtReportCreator.Text = CurrentUser.DisplayName;
    //        }
    //        else
    //        {
    //            txtReportCreator.Text = htController.GetValueByName(SystemConfigParameter.chuky1, Session["MaDonVi"].ToString());
    //        }
    //        // tổng giám đốc
    //        txtDirector.Text = htController.GetValueByName(SystemConfigParameter.chuky2, Session["MaDonVi"].ToString());
    //        // trưởng phòng HCNS
    //        txtRoomHeader.Text = htController.GetValueByName(SystemConfigParameter.chuky4, Session["MaDonVi"].ToString());
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError(ex.Message);
    //    }
    //}

    protected void btnShowReport_Click(object sender, DirectEventArgs e)
    {
        try
        {
            ReportFilter filter = new ReportFilter()
            {
                SessionDepartment = Session["MaDonVi"].ToString(),
                ReportTitle = txtReportTitle.Text,
                Reporter = CurrentUser.DisplayName,
                Name2 = txtRoomHeader.Text,
                Name3 = txtDirector.Text,
                UserID = CurrentUser.ID,
                MenuID = MenuID,
            };
            if (!string.IsNullOrEmpty(txtReportCreator.Text))
            {
                filter.Reporter = txtReportCreator.Text;
            }
            if (!string.IsNullOrEmpty(filterChucVu.SelectedItem.Value))
            {
                filter.WhereClause = "(MA_CHUCVU = N'" + filterChucVu.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterGioiTinh.SelectedItem.Value))
            {
                filter.WhereClause += "(MA_GIOITINH = '" + filterGioiTinh.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterNgaySinh.SelectedItem.Value))
            {
                filter.WhereClause += "(NamSinh = '" + filterNgaySinh.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterCongViec.SelectedItem.Value))
            {
                filter.WhereClause += "(MA_CONGVIEC = '" + filterCongViec.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterChuyenNganh.SelectedItem.Value))
            {
                filter.WhereClause += "(MA_CHUYENNGANH = '" + filterChuyenNganh.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterTrinhDo.SelectedItem.Value))
            {
                filter.WhereClause += "(MA_TRINHDO = '" + filterTrinhDo.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterTinhThanh.SelectedItem.Value))
            {
                filter.WhereClause += "(MA_TINHTHANH = '" + filterTinhThanh.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterLoaiHopDong.SelectedItem.Value))
            {
                filter.WhereClause += "(MA_LOAI_HDONG = '" + filterLoaiHopDong.SelectedItem.Value + "') and ";
            }
            if (!string.IsNullOrEmpty(filterDaNghi.SelectedItem.Value) && filterDaNghi.SelectedItem.Value != "-1")
            {
                //if (filterDaNghi.SelectedItem.Value == "0")
                //{
                //    filter.WhereClause += "(DA_NGHI = '" + filterDaNghi.SelectedItem.Value + "' or DA_NGHI IS NULL) and ";
                //}
                //else
                //{
                //    filter.WhereClause += "(DA_NGHI = '" + filterDaNghi.SelectedItem.Value + "') and ";
                //  }
            }
            if (!string.IsNullOrEmpty(filterEmail.Text))
            {
                filter.WhereClause += "(EMAIL like N'%" + filterEmail.Text + "%') and ";
            }
            if (!string.IsNullOrEmpty(filterDiaChiLH.Text))
            {
                filter.WhereClause += "(DIA_CHI_LH like N'%" + SoftCore.Util.GetInstance().GetKeyword(filterDiaChiLH.Text) + "%') and ";
            }
            if (!string.IsNullOrEmpty(filterDiDong.Text))
            {
                filter.WhereClause += "(DI_DONG like N'" + filterDiDong.Text + "') and ";
            }
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filter.WhereClause += "(HO_TEN like N'%" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text).Replace(" ", "%") + "%') and ";
            }
            filter.WhereClause += " 1 = 1 ";
            if (!string.IsNullOrEmpty(hdfSelectedDepartment.Text))
                filter.SelectedDepartment = "," + new CommonUtil().GetChildIDListFromParentID("DM_DONVI", hdfSelectedDepartment.Text, "MA_DONVI", "PARENT_ID") + hdfSelectedDepartment.Text + ",";
            else
                filter.SelectedDepartment = "";
            Session["rp"] = filter;
            //    query += 'checked=' + hdfMaDonVi.getValue();    
            //    query += '&tnien=' + filterThamNien.getValue(); 
            hdfTypeReport.Text = "DanhSachNhanSu";
            wdInputReportParameter.Hide();
            wdShowReport.Show();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btn_InsertandClose_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (dsDv == null || dsDv.Count() == 0)
            {
                dsDv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
            }
            if (!dsDv.Contains(hdfBoPhan.Text))
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền thao tác với bộ phận này").Show();
                RM.RegisterClientScriptBlock("msg", "cbx_bophan.focus();");
                return;
            }
            SoftCore.Util util = new Util();
            LinqProvider linq = new LinqProvider();
            HoSoController hoso = new HoSoController();
            DAL.HOSO hs = new HOSO();
            if (!string.IsNullOrEmpty(txt_socmnd.Text.Trim()))
            {
                bool isExisting = false;
                DataTable table = hoso.GetByCMDN(txt_socmnd.Text.Trim(), txt_macb.Text == "" ? hdfMaCB.Text : txt_macb.Text, ref isExisting);
                if (isExisting)
                {
                    string error = "Số chứng minh nhân dân \"" + txt_socmnd.Text + "\" đã sử dụng cho cán bộ: " + table.Rows[0]["HO_TEN"].ToString() + " (" + (table.Rows[0]["DA_NGHI"].ToString() == "True" ? "Đã nghỉ" : "Đang làm việc") + ")";
                    X.Msg.Alert("Thông báo từ hệ thống", error).Show();
                    return;
                }
            }
            if (e.ExtraParams["Command"] == "Edit")
            {
                hs = linq.GetDataContext().HOSOs.Where(t => t.MA_CB == hdfMaCB.Text).FirstOrDefault();
            }
            else
            {
                //if (hoso.GetPrKeyByMaCB(hdfMaCB.Text) > 0)
                //    hs.MA_CB = hoso.GenerateMaCB(Session["MaDonVi"].ToString());
                //else
                //    hs.MA_CB = hdfMaCB.Text;
                hdfMaCB.Text = txt_macb.Text;
                hs.MA_CB = hdfMaCB.Text;
            }
            if (string.IsNullOrEmpty(hdfAnhDaiDien.Text) == false)
                hs.PHOTO = hdfAnhDaiDien.Text;
            hs.HO_TEN = txt_hoten.Text;
            // lấy họ và đệm từ họ tên
            int position = hs.HO_TEN.LastIndexOf(' ');
            if (position == -1)
            {
                hs.TEN_CB = hs.HO_TEN;
            }
            else
            {
                hs.TEN_CB = hs.HO_TEN.Substring(position + 1).Trim();
                hs.HO_CB = hs.HO_TEN.Remove(position).Trim();
            }
            hs.BI_DANH = hdfBiDanh.Text;//txt_bidanh.SelectedItem.Value;
            if (!util.IsDateNull(dfNgaySinh.SelectedDate))
                hs.NGAY_SINH = dfNgaySinh.SelectedDate;
            hs.MA_GIOITINH = cbx_gioitinh.SelectedItem.Value;
            hs.ID_MAY_CHAMCONG = txt_machamcong.Text.Trim();
            hs.QueQuan = txt_quequan.Text.Trim();
            hs.MA_TT_HN = hdfHonNhan.Text;
            hs.MA_TP_BANTHAN = hdfThanhPhanBanThan.Text;
            hs.MA_TP_GIADINH = hdfThanhPhanGiaDinh.Text; //cbx_tpgiadinh.SelectedItem.Value;
            hs.NOI_SINH = txt_noisinh.Text;
            hs.MA_NUOC = hdfQuocTich.Text;
            hs.MA_DANTOC = hdfDanToc.Text;
            hs.MA_TONGIAO = hdfTonGiao.Text;//cbx_tongiao.SelectedItem.Value;
            hs.HO_KHAU = txt_hokhau.Text;
            hs.MA_TINHTHANH = hdfTinhThanh.Text;
            //hs.MA_CHUCVU = cbx_chucvu.SelectedItem.Value;
            hs.MA_CHUCVU = hdfChucVu.Text;
            hs.SO_HOCHIEU = txt_sohochieu.Text;
            if (!date_ngaycaphc.SelectedDate.ToString().Contains("0001"))
                hs.NGAYCAP_HOCHIEU = date_ngaycaphc.SelectedDate;
            if (cbx_noicaphc.Value != null)
                hs.MA_NOICAP_HOCHIEU = cbx_noicaphc.Value.ToString();
            if (!date_hethanhc.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_HETHAN_HOCHIEU = date_hethanhc.SelectedDate;
            hs.DI_DONG = txt_didong.Text;
            hs.DT_CQUAN = txt_dtcoquan.Text;
            hs.DT_NHA = txt_dtnha.Text;
            hs.EMAIL = txt_email.Text;
            hs.EMAIL_RIENG = txt_emailkhac.Text;
            hs.DIA_CHI_LH = txt_diachilienhe.Text;
            hs.NHUOC_DIEM = txt_NhuocDiem.Text.Trim();
            hs.SO_THICH = txtSOTHICH.Text.Trim();
            hs.UU_DIEM = txt_UuDiem.Text.Trim();

            hs.MA_TRINHDO = hdfTrinhDo.Text;//  
            hs.MA_CHUYENNGANH = hdfMaChuyenNganh.Text;
            hs.MA_TRUONG_DAOTAO = hdfMaTruongDaoTao.Text;
            hs.MA_XEPLOAI = hdfXepLoai.Text;
            hs.MA_TINHOC = hdfTinHoc.Text;
            hs.MA_NGOAINGU = hdfNgoaiNgu.Text;
            hs.MA_TD_VANHOA = tdVanHoa.Text;
            if (tf_namtotnghiep.Text.Trim() != "")
                hs.NAM_TN = decimal.Parse(tf_namtotnghiep.Text);
            hs.MA_DONVI = hdfBoPhan.Text;

            if (!date_tuyendau.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_TUYEN_DTIEN = date_tuyendau.SelectedDate;
            if (!date_ngaynhanct.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_TUYEN_CHINHTHUC = date_ngaynhanct.SelectedDate;
            if (!string.IsNullOrEmpty(txtSoNgayHocViec.Text))
                hs.SoNgayHocViec = int.Parse(txtSoNgayHocViec.Text);
            if (!string.IsNullOrEmpty(txtThoiGianThuViec.Text))
                hs.ThoiGianThuViec = int.Parse(txtThoiGianThuViec.Text);
            hs.MA_HT_TUYENDUNG = hdfHTTuyenDung.Text;//cbx_httuyen.SelectedItem.Value;
            hs.MA_CONGTRINH = cbx_congtrinh.Text;
            hs.MA_LOAI_CS = hdfHuongChinhSach.Text;//cbx_huongcs.SelectedItem.Value;
            hs.SOTHE_BHXH = txt_sothebhyt.Text;
            hs.MA_NOI_KCB = hdfNoiKhamChuaBenh.Text;//cbx_noikcb.SelectedItem.Value;
            hs.SOTHE_BHXH = txt_sothebhxh.Text;
            hs.MA_NOICAP_BHXH = hdfNoiCapBHXH.Text;//cbx_noicapbhxh.SelectedItem.Value;
            if (!string.IsNullOrEmpty(txt_socmnd.Text))
                hs.SO_CMND = txt_socmnd.Text;
            else hs.SO_CMND = null;
            hs.MA_NOICAP_CMND = hdfNoiCapCMND.Text;
            if (!util.IsDateNull(dfNgayDongBHYT.SelectedDate))
                hs.NGAY_DONGBH = dfNgayDongBHYT.SelectedDate;
            if (!util.IsDateNull(dfNgayHetHanBHYT.SelectedDate))
                hs.NGAY_HETHAN_BHYT = dfNgayHetHanBHYT.SelectedDate;
            hs.TYLE_DONG_BH = txt_tiledongbh.Text;
            if (!util.IsDateNull(dfNgayCapBHXH.SelectedDate))
                hs.NGAYCAP_BHXH = dfNgayCapBHXH.SelectedDate;
            if (!date_vaocongdoan.SelectedDate.ToString().Contains("0001"))
                hs.NgayVaoCongDoan = date_vaocongdoan.SelectedDate;
            hs.ChucVuCongDoan = txt_chucvucongdoan.Text.Trim();
            if (!date_capcmnd.SelectedDate.ToString().Contains("0001"))
                hs.NGAYCAP_CMND = date_capcmnd.SelectedDate;
            hs.MA_TD_CHINHTRI = hdfLyLuanChinhTri.Text;//cbx_trinhdochinhtri.SelectedItem.Value;
            // đảng
            hs.LaDangVien = chkLaDangVien.Checked;
            if (chkLaDangVien.Checked == true)
            {
                if (!date_vaodang.SelectedDate.ToString().Contains("0001"))
                    hs.NGAYVAO_DANG = date_vaodang.SelectedDate;
                if (!date_ngayvaodangct.SelectedDate.ToString().Contains("0001"))
                    hs.NGAY_CTHUC_DANG = date_ngayvaodangct.SelectedDate;
                hs.NOI_KETNAP_DANG = txt_noiketnapdang.Text;
                hs.MA_CHUCVU_DANG = hdfChucVuDang.Text;//cbx_chuvudang.SelectedItem.Value;
                hs.NoiSinhHoatDang = txt_noisinhhoatdang.Text.Trim();
            }
            // quân đội
            hs.DaThamGiaQuanDoi = chkDaThamGiaQuanDoi.Checked;
            if (chkDaThamGiaQuanDoi.Checked == true)
            {
                if (!date_nhapngu.SelectedDate.ToString().Contains("0001"))
                    hs.NGAYVAO_QDOI = date_nhapngu.SelectedDate;
                if (!date_xuatngu.SelectedDate.ToString().Contains("0001"))
                    hs.NGAYRA_QDOI = date_xuatngu.SelectedDate;
                hs.MA_CAPBAC_QDOI = hdfQuanHamCaoNhat.Text;//cbx_bacquandoi.SelectedItem.Value;
                hs.MA_CHUCVU_QDOI = hdfChucVuQuanDoi.Text;//cbx_chucvuquandoi.SelectedItem.Value;
            }
            if (!date_ngayvaodoan.SelectedDate.ToString().Contains("0001"))
                hs.NGAYVAO_DOAN = date_ngayvaodoan.SelectedDate;
            hs.MA_CHUCVU_DOAN = hdfChucVuDoan.Text;//cbx_chucvudoan.SelectedItem.Value;
            if (!date_thamgiacm.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_TGCM = date_thamgiacm.SelectedDate;
            hs.NOI_KETNAP_DOAN = txt_noiketnapdoan.Text;
            if (!date_ketthucbh.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_KTBH = date_ketthucbh.SelectedDate;

            hs.MA_TT_SUCKHOE = hdfTTSucKhoe.Text;// cbx_ttsuckhoe.SelectedItem.Value;
            if (cbNhommau.SelectedIndex >= 0)
            {
                hs.NHOM_MAU = cbNhommau.SelectedItem.Value;
            }
            else
            {
                hs.NHOM_MAU = "";
            }
            if (!string.IsNullOrEmpty(txt_chieucao.Text.ToString().Trim()))
                hs.CHIEU_CAO = Decimal.Parse(txt_chieucao.Text);
            if (!string.IsNullOrEmpty(txt_cannang.Text.ToString().Trim()))
                hs.CAN_NANG = Decimal.Parse(txt_cannang.Text);
            hs.SOHIEU_CCVC = txt_sohieucbccvc.Text;
            if (!date_bonhiemcv.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_BN_CHUCVU = date_bonhiemcv.SelectedDate;
            hs.MA_NGACH = hdfNgach.Text;//cbx_ngach.SelectedItem.Value;
            if (!date_bnngach.SelectedDate.ToString().Contains("0001"))
                hs.NGAY_BN_NGACH = date_bnngach.SelectedDate;
            hs.MA_TD_QUANLY = hdfQuanLyNhaNuoc.Text;
            hs.MA_TD_QLKT = hdfTrinhDoQLKT.Text;//cbx_trinhdoquanlykt.SelectedItem.Value;
            hs.MA_CONGVIEC = hdfViTriCongViec.Text;
            hs.NguoiLienHe = txt_nguoilienhe.Text;
            hs.QuanHeVoiCanBo = txtMoiQH.Text;
            hs.SDTNguoiLienHe = txt_sdtnguoilh.Text;
            hs.EmailNguoiLienHe = txt_emailnguoilh.Text.Trim();
            hs.DiaChiNguoiLienHe = txt_diachinguoilienhe.Text.Trim();
            hs.SO_TAI_KHOAN = txt_sotaikhoan.Text;
            hs.SOTHE_BHYT = txt_sothebhyt.Text;
            hs.TAI_NH = hdfNganHang.Text;//cbx_nganhang.SelectedItem.Value;
            hs.MST_CANHAN = txt_masothuecanhan.Text;
            hs.DA_NGHI = chk_danghi.Checked;

            if (hs.DA_NGHI == true)
            {
                if (!date_nghi.SelectedDate.ToString().Contains("0001"))
                    hs.NGAY_NGHI = date_nghi.SelectedDate;
                hs.MA_LYDO_NGHI = hdfLyDoNghiViec.Text;// cbx_lydonghi.SelectedItem.Value;
            }
            hs.HinhThucLamViec = int.Parse("0" + hdfHinhThucLamViec.Text);
            hs.USERNAME = CurrentUser.ID.ToString();
            hs.DATE_CREATE = DateTime.Now;
            hs.LaThuongBinh = chkLaThuongBinh.Checked;
            if (hs.LaThuongBinh == true)
            {
                hs.HangThuongTat = txt_HangThuongTat.Text;
                hs.SoThuongTat = txt_SoThuongTat.Text;
                hs.HinhThucThuongTat = txt_HinhThucThuongTat.Text;
            }
            if (e.ExtraParams["Command"] == "Edit")
            {
                linq.Save();

                wdInputEmployee.Hide();
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
                RM.RegisterClientScriptBlock("rlst1", "store_HoSoNhanSu.reload();");
            }
            else
            {
                hoso.InsertHoSo(hs);
                Dialog.ShowNotification("Thêm mới thành công!");
                RM.RegisterClientScriptBlock("rlst2", "store_HoSoNhanSu.reload();");
            }

            try
            {
                // thêm dữ liệu vào bảng HOSO_ATM
                if (!string.IsNullOrEmpty(txt_sotaikhoan.Text) && !string.IsNullOrEmpty(hdfNganHang.Text))
                {
                    HOSO_ATM atm = new HOSO_ATM();
                    atm.ATMNumber = txt_sotaikhoan.Text;
                    atm.BankID = hdfNganHang.Text;
                    atm.IsInUsed = true;
                    atm.LastUpdatedBy = CurrentUser.ID;
                    atm.LastUpdatedDate = DateTime.Now;
                    atm.PrKeyHoSo = hs.PR_KEY;

                    HoSoATMController ctr = new HoSoATMController();
                    if (ctr.GetByBankInfo(atm.BankID, atm.PrKeyHoSo) != null)
                    {
                        ctr.Update(atm);
                    }
                    else
                    {
                        ctr.Insert(atm);
                    }
                }
            }
            catch (Exception ex)
            {
                Dialog.ShowError(ex.Message);
            }

            if (e.ExtraParams["Close"] == "True")
            {
                wdInputEmployee.Hide();
            }
            else
            {
                HoSoController hsController = new HoSoController();
                txt_macb.Text = hsController.GenerateMaCB(Session["MaDonVi"].ToString());
                RM.RegisterClientScriptBlock("rs", "ResetControl();");
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void mnuNhanDoiDuLieu_Click(object sender, DirectEventArgs e)
    {
        // hiển thị thông tin lên màn hình sửa
        btnEdit_Click(sender, e);
        // sinh mã cán bộ mới
        string maMoi = new HoSoController().GenerateMaCB(Session["MaDonVi"].ToString());
        txt_macb.SetValue(maMoi);
        txt_macb.Disabled = true;
        hdfMaCB.Text = maMoi;
        wdInputEmployee.Title = "Nhân đôi dữ liệu";
        wdInputEmployee.Icon = Icon.DiskMultiple;
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HOSO hs = new HoSoController().GetByPrKey(decimal.Parse(hdfRecordID.Text));
            DataTable moreInformation = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetMoreInformation", "@prKey", hdfRecordID.Text);
            if (hs != null)
            {
                // Ho so nhan su
                if (!string.IsNullOrEmpty(hs.PHOTO))
                    img_anhdaidien.ImageUrl = hs.PHOTO;
                txt_macb.Text = hs.MA_CB;
                txt_hoten.Text = hs.HO_TEN;
                if (!string.IsNullOrEmpty(hs.BI_DANH))
                {
                    hdfBiDanh.SetValue(hs.BI_DANH);
                    //var tenDiaDiem = DataController.DataHandler.GetInstance().ExecuteScalar("SELECT TEN_DIADIEM FROM DM_DIADIEMLAMVIEC WHERE MA_DIADIEM = '" + hs.BI_DANH + "'");
                    if (hs.DM_DIADIEMLAMVIEC != null)
                    {
                        txt_bidanh.SetValue(hs.BI_DANH);
                        txt_bidanh.Text = hs.DM_DIADIEMLAMVIEC.TEN_DIADIEM;
                    }
                }
                dfNgaySinh.SetValue(hs.NGAY_SINH);
                txt_machamcong.Text = hs.ID_MAY_CHAMCONG;
                txt_quequan.Text = hs.QueQuan;
                cbx_gioitinh.Text = hs.MA_GIOITINH;
                hdfHonNhan.Text = hs.MA_TT_HN;
                cbx_tthonnhan.Text = moreInformation.Rows[0]["TEN_TT_HN"].ToString();
                if (hs.DM_TP_BANTHAN != null)
                {
                    hdfThanhPhanBanThan.Text = hs.MA_TP_BANTHAN;
                    cbx_tpbanthan.SetValue(hs.DM_TP_BANTHAN.TEN_TP_BANTHAN);
                }

                if (hs.DM_TP_GIADINH != null)
                {
                    hdfThanhPhanGiaDinh.Text = hs.MA_TP_GIADINH;
                    cbx_tpgiadinh.SetValue(hs.DM_TP_GIADINH.TEN_TP_GIADINH);
                }
                txt_noisinh.Text = hs.NOI_SINH;
                // cbx_quoctich.SetValue(hs.MA_NUOC);
                hdfQuocTich.Text = hs.MA_NUOC;
                cbx_quoctich.Text = moreInformation.Rows[0]["TEN_NUOC"].ToString();
                cbx_dantoc.Text = moreInformation.Rows[0]["TEN_DANTOC"].ToString();
                hdfDanToc.Text = hs.MA_DANTOC;
                hdfTonGiao.Text = hs.MA_TONGIAO;
                if (hs.DM_TONGIAO != null)
                {
                    cbx_tongiao.SetValue(hs.DM_TONGIAO.TEN_TONGIAO);
                }
                txt_hokhau.Text = hs.HO_KHAU;
                cbx_tinhthanh.Text = moreInformation.Rows[0]["TEN_TINHTHANH"].ToString();
                hdfTinhThanh.Text = hs.MA_TINHTHANH;
                txt_sohochieu.Text = hs.SO_HOCHIEU;
                date_ngaycaphc.SetValue(hs.NGAYCAP_HOCHIEU);
                hdfNoiCapCMND.Text = hs.MA_NOICAP_HOCHIEU;
                if (hs.DM_NOICAP_HOCHIEU != null)
                {
                    cbx_noicaphc.SetValue(hs.DM_NOICAP_HOCHIEU.TEN_NOICAP_HOCHIEU);
                }
                date_hethanhc.SetValue(hs.NGAY_HETHAN_HOCHIEU);

                txt_didong.SetValue(hs.DI_DONG);
                txt_dtcoquan.SetValue(hs.DT_CQUAN);
                txt_dtnha.SetValue(hs.DT_NHA);
                txt_email.Text = hs.EMAIL;
                txt_emailkhac.Text = hs.EMAIL_RIENG;
                txt_diachilienhe.Text = hs.DIA_CHI_LH;
                txtSoNgayHocViec.Text = hs.SoNgayHocViec.ToString();
                txtThoiGianThuViec.Text = hs.ThoiGianThuViec.ToString();
                cbx_trinhdo.Text = moreInformation.Rows[0]["TEN_TRINHDO"].ToString();
                hdfTrinhDo.Text = hs.MA_TRINHDO;
                hdfMaChuyenNganh.Text = hs.MA_CHUYENNGANH;
                if (hs.DM_CHUYENNGANH != null)
                {
                    cbxChuyenNganh.Text = hs.DM_CHUYENNGANH.TEN_CHUYENNGANH;
                }
                hdfMaTruongDaoTao.Text = hs.MA_TRUONG_DAOTAO;
                cbxTruongDaoTao.Text = moreInformation.Rows[0]["TEN_TRUONG_DAOTAO"].ToString();
                hdfXepLoai.Text = hs.MA_XEPLOAI;
                cbx_xeploai.Text = moreInformation.Rows[0]["TEN_XEPLOAI"].ToString();
                cbx_tinhoc.Text = moreInformation.Rows[0]["TEN_TINHOC"].ToString();
                hdfTinHoc.Text = hs.MA_TINHOC;
                cbx_ngoaingu.Text = moreInformation.Rows[0]["TEN_NGOAINGU"].ToString();
                hdfNgoaiNgu.Text = hs.MA_NGOAINGU;
                cbx_tdvanhoa.Text = moreInformation.Rows[0]["TEN_TD_VANHOA"].ToString();
                tdVanHoa.Text = hs.MA_TD_VANHOA;
                tf_namtotnghiep.SetValue(hs.NAM_TN);
                hdfBoPhan.Text = hs.MA_DONVI;
                cbx_bophan.Text = moreInformation.Rows[0]["TEN_DONVI"].ToString();
                date_tuyendau.SetValue(hs.NGAY_TUYEN_DTIEN);
                date_ngaynhanct.SetValue(hs.NGAY_TUYEN_CHINHTHUC);
                //cbx_chucvu.SetValue(hs.MA_CHUCVU);
                hdfChucVu.Text = hs.MA_CHUCVU;
                cbx_chucvu.Text = moreInformation.Rows[0]["TEN_CHUCVU"].ToString();
                hdfHTTuyenDung.Text = hs.MA_HT_TUYENDUNG;
                if (hs.DM_HT_TUYENDUNG != null)
                {
                    cbx_httuyen.SetValue(hs.DM_HT_TUYENDUNG.TEN_HT_TUYENDUNG);
                }
                cbx_congtrinh.Text = hs.MA_CONGTRINH;
                // cbxHinhThucLamViec.SetValue(hs.HinhThucLamViec);
                cbxHinhThucLamViec.Text = moreInformation.Rows[0]["HinhThucLamViec"].ToString();
                hdfHinhThucLamViec.SetValue(hs.HinhThucLamViec);
                // Ho so nhan su them
                hdfHuongChinhSach.SetValue(hs.MA_LOAI_CS);
                if (hs.DM_LOAI_C != null)
                {
                    //cbx_huongcs.SetValue(hs.MA_LOAI_CS);
                    cbx_huongcs.Text = hs.DM_LOAI_C.TEN_LOAI_CS;
                }
                txt_sothebhyt.Text = hs.SOTHE_BHYT;
                // set value for combobox noikcb
                hdfNoiKhamChuaBenh.Text = hs.MA_NOI_KCB;
                if (hs.DM_NOI_KCB != null)
                {
                    cbx_noikcb.SetValue(hs.DM_NOI_KCB.TEN_NOI_KCB);
                }

                txt_sothebhxh.Text = hs.SOTHE_BHXH;
                hdfNoiCapBHXH.Text = hs.MA_NOICAP_BHXH;
                if (hs.DM_NOICAP_BHXH != null)
                {
                    cbx_noicapbhxh.SetValue(hs.DM_NOICAP_BHXH.TEN_NOICAP_BHXH);
                }
                txt_socmnd.SetValue(hs.SO_CMND);
                hdfNoiCapCMND.Text = hs.MA_NOICAP_CMND;
                if (hs.DM_NOICAP_CMND != null)
                {
                    cbx_noicapcmnd.SetValue(hs.DM_NOICAP_CMND.TEN_NOICAP_CMND);
                }
                dfNgayDongBHYT.SetValue(hs.NGAY_DONGBH);
                dfNgayHetHanBHYT.SetValue(hs.NGAY_HETHAN_BHYT);
                dfNgayCapBHXH.SetValue(hs.NGAYCAP_BHXH);
                date_capcmnd.SetValue(hs.NGAYCAP_CMND);
                txt_tiledongbh.Text = hs.TYLE_DONG_BH;
                hdfLyLuanChinhTri.Text = hs.MA_TD_CHINHTRI;
                if (hs.DM_TD_CHINHTRI != null)
                {
                    cbx_trinhdochinhtri.SetValue(hs.DM_TD_CHINHTRI.TEN_TD_CHINHTRI);
                }
                if (hs.LaDangVien != null)
                    chkLaDangVien.Checked = hs.LaDangVien.Value;
                if (chkLaDangVien.Checked == true)
                {
                    date_vaodang.SetValue(hs.NGAYVAO_DANG);
                    hdfChucVuDang.Text = hs.MA_CHUCVU_DANG;
                    if (hs.DM_CHUCVU_DANG != null)
                    {
                        cbx_chuvudang.SetValue(hs.DM_CHUCVU_DANG.TEN_CHUCVU_DANG);
                    }
                    date_ngayvaodangct.SetValue(hs.NGAY_CTHUC_DANG);
                    txt_noiketnapdang.Text = hs.NOI_KETNAP_DANG;
                    txt_noisinhhoatdang.Text = hs.NoiSinhHoatDang;
                }
                if (hs.DaThamGiaQuanDoi != null)
                    chkDaThamGiaQuanDoi.Checked = hs.DaThamGiaQuanDoi.Value;
                if (chkDaThamGiaQuanDoi.Checked == true)
                {
                    date_nhapngu.SetValue(hs.NGAYVAO_QDOI);
                    date_xuatngu.SetValue(hs.NGAYRA_QDOI);
                    hdfQuanHamCaoNhat.Text = hs.MA_CAPBAC_QDOI;
                    if (hs.DM_CAPBAC_QDOI != null)
                    {
                        cbx_bacquandoi.SetValue(hs.DM_CAPBAC_QDOI.TEN_CAPBAC_QDOI);
                    }
                    hdfChucVuQuanDoi.Text = hs.MA_CHUCVU_QDOI;
                    if (hs.DM_CHUCVU_QDOI != null)
                    {
                        cbx_chucvuquandoi.Text = (hs.DM_CHUCVU_QDOI.TEN_CHUCVU_QDOI);
                    }
                }
                date_ngayvaodoan.SetValue(hs.NGAYVAO_DOAN);
                hdfChucVuDoan.Text = hs.MA_CHUCVU_DOAN;
                if (hs.DM_CHUCVU_DOAN != null)
                {
                    cbx_chucvudoan.SetValue(hs.DM_CHUCVU_DOAN.TEN_CHUCVU_DOAN);
                }
                date_thamgiacm.SetValue(hs.NGAY_TGCM);
                txt_noiketnapdoan.Text = hs.NOI_KETNAP_DOAN;
                date_ketthucbh.SetValue(hs.NGAY_KTBH);
                date_vaocongdoan.SetValue(hs.NgayVaoCongDoan);
                txt_chucvucongdoan.Text = hs.ChucVuCongDoan;

                // Thong tin khac
                cbNhommau.SetValue(hs.NHOM_MAU);
                txt_chieucao.SetValue(hs.CHIEU_CAO);
                txt_cannang.SetValue(hs.CAN_NANG);
                txtSOTHICH.Text = hs.SO_THICH;
                hdfTTSucKhoe.Text = hs.MA_TT_SUCKHOE;
                if (hs.DM_TT_SUCKHOE != null)
                {
                    cbx_ttsuckhoe.SetValue(hs.DM_TT_SUCKHOE.TEN_TT_SUCKHOE);
                }
                txt_sohieucbccvc.Text = hs.SOHIEU_CCVC;
                date_bonhiemcv.SetValue(hs.NGAY_BN_CHUCVU);
                date_bnngach.SetValue(hs.NGAY_BN_NGACH);
                txt_UuDiem.Text = hs.UU_DIEM;
                hdfNgach.Text = hs.MA_NGACH;
                if (hs.DM_NGACH != null)
                {
                    cbx_ngach.SetValue(hs.DM_NGACH.TEN_NGACH);
                }
                txt_NhuocDiem.Text = hs.NHUOC_DIEM;
                txt_nguoilienhe.Text = hs.NguoiLienHe;
                txtMoiQH.Text = hs.QuanHeVoiCanBo;
                txt_sdtnguoilh.Text = hs.SDTNguoiLienHe;
                txt_emailnguoilh.Text = hs.EmailNguoiLienHe;
                txt_diachinguoilienhe.Text = hs.DiaChiNguoiLienHe;
                hdfQuanLyNhaNuoc.Text = hs.MA_TD_QUANLY;
                if (hs.DM_TD_QUANLY != null)
                {
                    cbx_trinhdoquanly.SetValue(hs.DM_TD_QUANLY.TEN_TD_QUANLY);
                }
                hdfTrinhDoQLKT.Text = hs.MA_TD_QLKT;
                if (hs.DM_TD_QLKT != null)
                {
                    cbx_trinhdoquanlykt.SetValue(hs.DM_TD_QLKT.TEN_TD_QLKT);
                }
                if (!string.IsNullOrEmpty(hs.MA_CONGVIEC))
                {
                    hdfViTriCongViec.Text = hs.MA_CONGVIEC;
                }
                if (hs.DM_CONGVIEC != null)
                    cbx_congviec.Text = hs.DM_CONGVIEC.TEN_CONGVIEC;

                txt_sotaikhoan.Text = hs.SO_TAI_KHOAN;
                hdfNganHang.Text = hs.TAI_NH;
                if (!string.IsNullOrEmpty(hs.TAI_NH))
                {
                    var d = DataController.DataHandler.GetInstance().ExecuteScalar("SELECT TOP 1 TEN_NH FROM DM_NH WHERE MA_NH = '" + hs.TAI_NH + "' ");
                    cbx_nganhang.SetValue(d == null ? "" : d.ToString());
                }
                txt_masothuecanhan.Text = hs.MST_CANHAN;

                if (hs.LaThuongBinh != null)
                    chkLaThuongBinh.Checked = hs.LaThuongBinh.Value;
                if (chkLaThuongBinh.Checked == true)
                {
                    txt_HangThuongTat.Text = hs.HangThuongTat;
                    txt_SoThuongTat.Text = hs.SoThuongTat;
                    txt_HinhThucThuongTat.Text = hs.HinhThucThuongTat;
                }

                if (hs.DA_NGHI != null)
                    chk_danghi.Checked = bool.Parse(hs.DA_NGHI.ToString());
                if (chk_danghi.Checked)
                {
                    date_nghi.SetValue(hs.NGAY_NGHI);

                    hdfLyDoNghiViec.SetValue(hs.MA_LYDO_NGHI);
                    if (hs.DM_LYDO_NGHI != null)
                    {
                        cbx_lydonghi.Text = hs.DM_LYDO_NGHI.TEN_LYDO_NGHI;
                    }
                }
                if (hs.UserID != null)
                {
                    DAL.User user = new UserController().GetUserNameById(hs.UserID.Value);
                    if (user != null)
                        txt_username.Text = user.UserName;
                }
                string title = string.Empty;
                if (!string.IsNullOrEmpty(hs.USERNAME))
                {
                    HOSO tmp = new HoSoController().GetByUserID(int.Parse(hs.USERNAME));
                    if (tmp != null)
                        title += " (Người tạo: " + tmp.HO_TEN;
                }
                if (hs.PrkeyNguoiDuyet.HasValue && hs.PrkeyNguoiDuyet.Value > 0)
                {
                    HOSO tmp = new HoSoController().GetByPrKey(hs.PrkeyNguoiDuyet.Value);
                    if (tmp != null)
                        title += " - Người duyệt: " + tmp.HO_TEN;
                }
                if (!string.IsNullOrEmpty(title))
                    title += ")";
                title = "Cập nhật thông tin cán bộ" + title;
                wdInputEmployee.Title = title;

                txt_macb.Disabled = true;
                hdfMaCB.Text = hs.MA_CB;
                //wdInputEmployee.Title = "Sửa thông tin hồ sơ";
                wdInputEmployee.Icon = Icon.Pencil;
                wdInputEmployee.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    protected void mnuExportAllNhanSu_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SetValueQuery();
            string Query = hdfQuery.Text;
            string MA_GIOITINH = "", MA_TRINHDO = "", DIA_CHI_LH = "", MA_LOAI_HDONG = "", MA_CONGVIEC = "";
            string MA_CHUYENNGANH = "", MA_TINHTHANH = "", DI_DONG = "", EMAIL = "", MA_CHUCVU = "";
            int DA_NGHI = 0;
            int NGAY_SINH = -1;
            string THAM_NIEN = "";
            string HT_TuyenDung = "";
            string DiaDiemLamViec = "";
            bool isChuaCoAnh = bool.Parse(hdfIsChuaCoAnh.Text);
            int userID = -1, menuID = -1;
            userID = CurrentUser.ID;
            menuID = this.MenuID;
            string[] value = Query.Split(';');  // -1;-1;;;;;;;;0;
            if (value.Length >= 1)  // filter giới tính
                MA_GIOITINH = value[0] == null ? "" : value[0];
            if (value.Length >= 2)  // filter năm sinh
                NGAY_SINH = value[1] != "" ? int.Parse(value[1]) : -1;
            if (value.Length >= 3)  // filter trình độ
                MA_TRINHDO = value[2] == null ? "" : value[2];
            if (value.Length >= 4)  // filter chuyên ngành
                MA_CHUYENNGANH = value[3] == null ? "" : value[3];
            if (value.Length >= 5)  // filter mã tỉnh thành
                MA_TINHTHANH = value[4] == null ? "" : value[4];
            if (value.Length >= 6)  // filter loại hợp đồng
                MA_LOAI_HDONG = value[5] == null ? "" : value[5];
            if (value.Length >= 7)  // filter địa chỉ liên hệ
                DIA_CHI_LH = value[6] == null ? "" : value[6];
            if (value.Length >= 8)  // filter số điện thoại
                DI_DONG = value[7] == null ? "" : value[7];
            if (value.Length >= 9) // filter email
                EMAIL = value[8] == null ? "" : value[8];
            if (value.Length >= 10) // filter trạng thái làm việc
                DA_NGHI = value[9] == "" ? 0 : int.Parse(value[9]);
            if (value.Length >= 11) // filter chức vụ
                MA_CHUCVU = value[10] == null ? "" : value[10];
            if (value.Length >= 12) // filter công việc
                MA_CONGVIEC = value[11] == null ? "" : value[11];
            if (value.Length >= 13)
                THAM_NIEN = value[12] == null ? "" : value[12];
            if (value.Length >= 14)
                HT_TuyenDung = value[13] == null ? "" : value[13];
            if (value.Length >= 15)
                DiaDiemLamViec = value[14] == null ? "" : value[14];
            if (!string.IsNullOrEmpty(THAM_NIEN))
            {
                if (THAM_NIEN.IndexOf('-') == -1) // dang >6
                {
                    THAM_NIEN = "AND dbo.CalculateThamNien(hs.NGAY_TUYEN_DTIEN, case when ISNULL(hs.DA_NGHI, 0) = 0 then GETDATE() else hs.NGAY_NGHI end)" + THAM_NIEN;
                }
                else // dang 6-8
                {
                    THAM_NIEN = "AND dbo.CalculateThamNien(hs.NGAY_TUYEN_DTIEN, case when ISNULL(hs.DA_NGHI, 0) = 0 then GETDATE() else hs.NGAY_NGHI end) > " + THAM_NIEN.Replace("-", "AND dbo.CalculateThamNien(hs.NGAY_TUYEN_DTIEN,case when ISNULL(hs.DA_NGHI, 0) = 0 then GETDATE() else hs.NGAY_NGHI end) <= ");
                }
            }

            string[] params1 = {"@Start", "@Limit", "@SearchKey", "@MaDonVi", 
                                "@MA_GIOITINH", "@NGAY_SINH", 
                                "@MA_TRINHDO", "@MA_CHUYENNGANH", "@MA_TINHTHANH", "@MA_LOAI_HDONG",
                                "@DIA_CHI_LH", "@DI_DONG", "@EMAIL", "@DA_NGHI", "@MA_CHUCVU", "@MA_CONGVIEC", "@IsChuaCoAnh", 
                                "@userID", "@menuID", "@THAM_NIEN","@HT_TUYENDUNG","@DiaDiem"};
            object[] params2 = {0, 99999, txtSearch.Text, hdfMaDonVi.Text,
                                MA_GIOITINH, NGAY_SINH, MA_TRINHDO, MA_CHUYENNGANH,
                                MA_TINHTHANH, MA_LOAI_HDONG, DIA_CHI_LH, DI_DONG, EMAIL, DA_NGHI, MA_CHUCVU, MA_CONGVIEC, isChuaCoAnh, 
                                userID, menuID, THAM_NIEN, HT_TuyenDung, DiaDiemLamViec
                               };
            int start = 0, limit = 10000000;
            limit = (PagingToolbar1.PageIndex+1) * int.Parse("0" + ComboBoxPaging.Text);
            start = limit - int.Parse("0" + ComboBoxPaging.Text);
            DataTable dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable("ExportToExcel_GetAllHOSO", params1, start, limit, txtSearch.Text, hdfMaDonVi.Text,
                                MA_GIOITINH, NGAY_SINH, MA_TRINHDO, MA_CHUYENNGANH,
                                MA_TINHTHANH, MA_LOAI_HDONG, DIA_CHI_LH, DI_DONG, EMAIL, DA_NGHI, MA_CHUCVU, MA_CONGVIEC, isChuaCoAnh,
                                userID, menuID, THAM_NIEN, HT_TuyenDung, DiaDiemLamViec);

            ExportToExcel("HoSoNhanSu.xls", dtTemp);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    public void ExportToExcel(string fileName, DataTable table)
    {
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        try
        {
            StringBuilder sb = new StringBuilder();
            //Tạo dòng tiêu để cho bảng tính
            for (int count = 0; count < table.Columns.Count; count++)
            {
                if (table.Columns[count].ColumnName != null)
                    sb.Append(table.Columns[count].ColumnName);
                if (count < table.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi 
            int soDem = 0;
            while (table.Rows.Count >= soDem + 1)
            {
                sb = new StringBuilder();


                for (int col = 0; col < table.Columns.Count - 1; col++)
                {
                    if (table.Rows[soDem][col] != null)
                        sb.Append(table.Rows[soDem][col].ToString().Replace(",", " "));
                    sb.Append("\t");
                }
                if (table.Rows[soDem][table.Columns.Count - 1] != null)
                    sb.Append(table.Rows[soDem][table.Columns.Count - 1].ToString().Replace(",", " "));


                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                soDem = soDem + 1;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        table.Dispose();
        Response.End();
    }
}